using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Globalization;

namespace Remielsoft.JetSave.DataAccessLayer
{
    public class BillRegisterDataAccess : BaseDataAccess
    {
        #region Global Variables

        public Database myDataBase;
        String queryBill;

        #endregion

        #region Public Methods

        public BillRegisterDataAccess(Database m_database)
        {
            myDataBase = m_database;
        }

        public List<BillRegister> ReadBillRegisterBYFromBillNo(int fromBill, int toBill, int AgentId, int? LocId)
        {
             List<BillRegister> lst = new List<BillRegister>();
             DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_BillBY_BILLID);
            myDataBase.AddInParameter(dbCommand, "@in_fromBillId", DbType.String, fromBill);
            myDataBase.AddInParameter(dbCommand, "@in_toBillId", DbType.String, toBill);
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    BillRegister billRegister = new BillRegister();
                    billRegister.RegisterBill = new Bill();
                    billRegister.RegisterConsignment = new Consignment();

                    billRegister.RegisterBill.Version = GetIntegerFromDataReader(reader, "Versioning");
                    billRegister.RegisterBill.BillId = GetIntegerFromDataReader(reader, "BILL_ID");
                    billRegister.RegisterConsignment.CgNoOfPass = GetIntegerFromDataReader(reader, "CG_NOOFPASS");
                    billRegister.RegisterConsignment.CgCorporate = GetStringFromDataReader(reader, "CG_CORPORATE");
                    billRegister.RegisterConsignment.ConsignmentId = GetIntegerFromDataReader(reader, "FK_CG_ID");
                    billRegister.Amount = GetDecimalFromDataReader(reader, "TotalAmt");
                    billRegister.RegisterBill.BillDate = GetDateFromReader(reader, "BILLDATE");
                    billRegister.RegisterBill.Paxs = GetStringFromDataReader(reader, "PAXS");
                    billRegister.VisaCountry = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    lst.Add(billRegister);
                }
            }
            return lst;
        }

        public List<BillRegister> ReadBillRegisterInformationFromBillNo(int fromBill, int toBill, int AgentId, int? LocId)
        {
            //if (LocId != 0)
            //{
            //    queryBill = "Select CONVERT(VARCHAR(20), BILL.BILL_DATE, 103) AS 'Date', CONVERT(VARCHAR,BILL.BILL_ID,20) AS 'BillNo', UPPER(ISNULL(AGENT.TALLY_ACNAME, AGENT.AGENT_NAME)) AS 'PartyName', UPPER(Bill.PAXS) as Pax,UPPER(COUNTRY.COUNTRY_NAME) AS 'VisaCountry', SUM(ISNULL(Visa.Fee,0)) AS 'VisaCharge', sum(isnull(ATTEST.FEE,0)) AS 'AttestationCharge', SUM(ISNULL(Token.FEE,0)) as 'TokenCharge', SUM(ISNULL(VFS.FEE,0)) as 'VFS/BLS/TTS', SUM(ISNULL(Handling.FEE,0)) as 'Handling', SUM(ISNULL(Courier.FEE,0)) as 'Courier', SUM(ISNULL(Draft.FEE,0)) as 'Draft', SUM(ISNULL(Delivery.FEE,0)) as 'Delivery', SUM(ISNULL(Dropc.FEE,0)) as 'Drop', SUM(ISNULL(Pickup.FEE,0)) as 'Cargo_Pick', sum(isnull(Urgent.FEE,0)) as 'Urgent', sum(isnull(Insurance.FEE,0)) as 'Insurance', CONVERT(VARCHAR,CONSIGNMENT.CG_ID) as ConsimentId,CONSIGNMENT.CG_NOOFPASS AS Passport,CONSIGNMENT.CG_CORPORATE AS Corporate,(CustomBillTotal.TotalAmount+Bill.ServiceCharge +(Bill.ServiceTax) - (Bill.servicecharge + sum(isnull(VFS.FEE,0)) + SUM(ISNULL(Visa.Fee,0))+ sum(isnull(ATTEST.FEE,0)) + sum(isnull(Token.FEE,0)) + sum(isnull(Handling.FEE,0))+ sum(isnull(Courier.FEE,0))+ sum(isnull(Delivery.FEE,0))+ sum(isnull(Dropc.FEE,0)) + sum(isnull(Pickup.FEE,0))+ sum(isnull(Urgent.FEE,0))+ sum(isnull(Draft.FEE,0)) + sum(isnull(Insurance.FEE,0)) +(Bill.ServiceTax))) as 'OtherCharges', Bill.servicecharge As 'ServiceCharge', (BILL.SERVICETAX) as 'S_Tax', CustomBillTotal.TotalAmount+Bill.ServiceCharge+(Bill.ServiceTax) as 'Amount' FROM Bill INNER JOIN CONSIGNMENT ON CONSIGNMENT.CG_ID=BILL.FK_CG_ID INNER JOIN AGENT ON AGENT.AGENT_ID=CONSIGNMENT.FK_AGENT_ID INNER JOIN COUNTRY ON COUNTRY.COUNTRY_ID=CONSIGNMENT.CG_VISACOUNTRY LEFT JOIN (Select SUM(ISNULL(tem.FEE*tem.NoOfVisa,0)) As TotalAmount,BillID as FK_BillMSTR_ID from (Select  BD.FK_BILL_ID as BillID,'' as NoOfVisa,(BD.CHARGE_PERUNIT*BD.UNITS) as FEE, '' as Description FROM  BILL_DETAILS BD UNION Select  VD.FK_BillMSTR_ID as BillID,VD.NoOfVisa as NoOfVisa,VISAFEES as FEE,VD.Description as Description FROM dbo.BILL_VISAFEES VD )tem Group by  tem.BillID) AS CustomBillTotal ON CustomBillTotal.FK_BillMSTR_ID=BILL.BILL_ID LEFT JOIN (Select BD.FK_BillMSTR_ID AS BillID,SUM(ISNULL(BD.VisaFees*NoOfVisa,0)) AS FEE from Bill_VisaFees BD Where BD.Description Like '%Attest%' Group by BD.FK_BillMSTR_ID) AS ATTEST ON BILL.BILL_ID=ATTEST.BillID LEFT JOIN (Select VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD WHERE Description Like '%Visa%' GROUP BY VD.FK_BillMSTR_ID) AS VISA ON VISA.BillID=BILL.BILL_ID LEFT JOIN (Select BD.FK_BillMSTR_ID AS BILLID,SUM(ISNULL(BD.VisaFees*NoOfVisa,0)) AS FEE from Bill_VisaFees BD Where BD.Description Like '%Token%' Group by BD.FK_BillMSTR_ID) as Token ON BILL.BILL_ID=TOKEN.BILLID LEFT JOIN (Select VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%VFS/BLS/TTS%' Group by VD.FK_BillMSTR_ID) as VFS ON VFS.BILLID=BILL.BILL_ID LEFT JOIN (Select VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%Handling%' Group by  VD.FK_BillMSTR_ID) AS HANDLING ON HANDLING.BILLID=BILL.BILL_ID LEFT JOIN (Select VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE  FROM BILL_VISAFEES VD Where VD.Description Like '%Courier%' Group by  VD.FK_BillMSTR_ID) AS Courier  ON COURIER.BILLID=BILL.BILL_ID LEFT JOIN (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%Delivery%' Group by  VD.FK_BillMSTR_ID) AS Delivery ON Delivery.BILLID=BILL.BILL_ID LEFT JOIN (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES,0)) as FEE FROM dbo.BILL_VISAFEES VD Where VD.Description Like '%Dropc%' Group by  VD.FK_BillMSTR_ID) AS Dropc ON Dropc.BillId=BILL.BILL_ID LEFT join (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%Pickup%' Group by  VD.FK_BillMSTR_ID) AS Pickup ON Pickup.BILLID=BILL.BILL_ID LEFT JOIN (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES,0)) as FEE FROM dbo.BILL_VISAFEES VD Where VD.Description Like '%Urgent%' Group by  VD.FK_BillMSTR_ID) AS Urgent ON Urgent.BILLID=BILL.BILL_ID LEFT JOIN (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%Draft%' Group by  VD.FK_BillMSTR_ID) AS Draft ON Draft.BILLID=BILL.BILL_ID LEFT JOIN (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES,0)) as FEE FROM dbo.BILL_VISAFEES VD Where VD.Description Like '%Insurance%' Group by  VD.FK_BillMSTR_ID) AS Insurance ON Insurance.BILLID=BILL.BILL_ID Where Bill.ISCANCELLED <>'Y' AND BILL.BILL_ID>= " + fromBill + " and  BILL.BILL_ID<= " + toBill + " and AGENT.AGENT_ID = " + AgentId + " and BILL.LocationId=" + LocId + "  Group by BILL.BILL_DATE,Bill.Bill_id,Bill.PAXS,AGENT.TALLY_ACNAME,AGENT.AGENT_NAME,COUNTRY.COUNTRY_NAME,Bill.servicecharge,Bill.TotalAmt,Bill.ServiceTax,CustomBillTotal.TotalAmount,CONSIGNMENT.CG_ID,CONSIGNMENT.CG_NOOFPASS,CONSIGNMENT.CG_CORPORATE ORDER BY BILL.BILL_ID ASC";
            //}
            //else
            //{
            //    queryBill = "Select CONVERT(VARCHAR(20), BILL.BILL_DATE, 103) AS 'Date', CONVERT(VARCHAR,BILL.BILL_ID,20) AS 'BillNo', UPPER(ISNULL(AGENT.TALLY_ACNAME, AGENT.AGENT_NAME)) AS 'PartyName', UPPER(Bill.PAXS) as Pax,UPPER(COUNTRY.COUNTRY_NAME) AS 'VisaCountry', SUM(ISNULL(Visa.Fee,0)) AS 'VisaCharge', sum(isnull(ATTEST.FEE,0)) AS 'AttestationCharge', SUM(ISNULL(Token.FEE,0)) as 'TokenCharge', SUM(ISNULL(VFS.FEE,0)) as 'VFS/BLS/TTS', SUM(ISNULL(Handling.FEE,0)) as 'Handling', SUM(ISNULL(Courier.FEE,0)) as 'Courier', SUM(ISNULL(Draft.FEE,0)) as 'Draft', SUM(ISNULL(Delivery.FEE,0)) as 'Delivery', SUM(ISNULL(Dropc.FEE,0)) as 'Drop', SUM(ISNULL(Pickup.FEE,0)) as 'Cargo_Pick', sum(isnull(Urgent.FEE,0)) as 'Urgent', sum(isnull(Insurance.FEE,0)) as 'Insurance', (CustomBillTotal.TotalAmount+Bill.ServiceCharge +(Bill.ServiceTax) - (Bill.servicecharge + sum(isnull(VFS.FEE,0)) + SUM(ISNULL(Visa.Fee,0))+ sum(isnull(ATTEST.FEE,0)) + sum(isnull(Token.FEE,0)) + sum(isnull(Handling.FEE,0))+ sum(isnull(Courier.FEE,0))+ sum(isnull(Delivery.FEE,0))+ sum(isnull(Dropc.FEE,0)) + sum(isnull(Pickup.FEE,0))+ sum(isnull(Urgent.FEE,0))+ sum(isnull(Draft.FEE,0)) + sum(isnull(Insurance.FEE,0)) +(Bill.ServiceTax))) as 'OtherCharges', Bill.servicecharge As 'ServiceCharge', (BILL.SERVICETAX) as 'S_Tax', CustomBillTotal.TotalAmount+Bill.ServiceCharge+(Bill.ServiceTax) as 'Amount' FROM Bill INNER JOIN CONSIGNMENT ON CONSIGNMENT.CG_ID=BILL.FK_CG_ID INNER JOIN AGENT ON AGENT.AGENT_ID=CONSIGNMENT.FK_AGENT_ID INNER JOIN COUNTRY ON COUNTRY.COUNTRY_ID=CONSIGNMENT.CG_VISACOUNTRY LEFT JOIN (Select SUM(ISNULL(tem.FEE*tem.NoOfVisa,0)) As TotalAmount,BillID as FK_BillMSTR_ID from (Select  BD.FK_BILL_ID as BillID,'' as NoOfVisa,(BD.CHARGE_PERUNIT*BD.UNITS) as FEE, '' as Description FROM  BILL_DETAILS BD UNION Select  VD.FK_BillMSTR_ID as BillID,VD.NoOfVisa as NoOfVisa,VISAFEES as FEE,VD.Description as Description FROM dbo.BILL_VISAFEES VD )tem Group by  tem.BillID) AS CustomBillTotal ON CustomBillTotal.FK_BillMSTR_ID=BILL.BILL_ID LEFT JOIN (Select BD.FK_BillMSTR_ID AS BillID,SUM(ISNULL(BD.VisaFees*NoOfVisa,0)) AS FEE from Bill_VisaFees BD Where BD.Description Like '%Attest%' Group by BD.FK_BillMSTR_ID) AS ATTEST ON BILL.BILL_ID=ATTEST.BillID LEFT JOIN (Select VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD WHERE Description Like '%Visa%' GROUP BY VD.FK_BillMSTR_ID) AS VISA ON VISA.BillID=BILL.BILL_ID LEFT JOIN (Select BD.FK_BillMSTR_ID AS BILLID,SUM(ISNULL(BD.VisaFees*NoOfVisa,0)) AS FEE from Bill_VisaFees BD Where BD.Description Like '%Token%' Group by BD.FK_BillMSTR_ID) as Token ON BILL.BILL_ID=TOKEN.BILLID LEFT JOIN (Select VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%VFS/BLS/TTS%' Group by VD.FK_BillMSTR_ID) as VFS ON VFS.BILLID=BILL.BILL_ID LEFT JOIN (Select VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%Handling%' Group by  VD.FK_BillMSTR_ID) AS HANDLING ON HANDLING.BILLID=BILL.BILL_ID LEFT JOIN (Select VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE  FROM BILL_VISAFEES VD Where VD.Description Like '%Courier%' Group by  VD.FK_BillMSTR_ID) AS Courier  ON COURIER.BILLID=BILL.BILL_ID LEFT JOIN (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%Delivery%' Group by  VD.FK_BillMSTR_ID) AS Delivery ON Delivery.BILLID=BILL.BILL_ID LEFT JOIN (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES,0)) as FEE FROM dbo.BILL_VISAFEES VD Where VD.Description Like '%Dropc%' Group by  VD.FK_BillMSTR_ID) AS Dropc ON Dropc.BillId=BILL.BILL_ID LEFT join (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%Pickup%' Group by  VD.FK_BillMSTR_ID) AS Pickup ON Pickup.BILLID=BILL.BILL_ID LEFT JOIN (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES,0)) as FEE FROM dbo.BILL_VISAFEES VD Where VD.Description Like '%Urgent%' Group by  VD.FK_BillMSTR_ID) AS Urgent ON Urgent.BILLID=BILL.BILL_ID LEFT JOIN (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%Draft%' Group by  VD.FK_BillMSTR_ID) AS Draft ON Draft.BILLID=BILL.BILL_ID LEFT JOIN (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES,0)) as FEE FROM dbo.BILL_VISAFEES VD Where VD.Description Like '%Insurance%' Group by  VD.FK_BillMSTR_ID) AS Insurance ON Insurance.BILLID=BILL.BILL_ID Where Bill.ISCANCELLED <>'Y' AND BILL.BILL_ID>= " + fromBill + " and  BILL.BILL_ID<= " + toBill + " and AGENT.AGENT_ID = " + AgentId + " Group by BILL.BILL_DATE,Bill.Bill_id,Bill.PAXS,AGENT.TALLY_ACNAME,AGENT.AGENT_NAME,COUNTRY.COUNTRY_NAME,Bill.servicecharge,Bill.TotalAmt,Bill.ServiceTax,CustomBillTotal.TotalAmount ORDER BY BILL.BILL_ID ASC";
            //}

            List<BillRegister> lstBillRegister = new List<BillRegister>();

           // DbCommand dbCommand = myDataBase.GetSqlStringCommand(queryBill);
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_DATABY_BILLNO);
            myDataBase.AddInParameter(dbCommand, "@in_fromBill", DbType.String, fromBill);
            myDataBase.AddInParameter(dbCommand, "@in_toBill", DbType.String, toBill);
            dbCommand.CommandTimeout = 1500;
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    var billregisterDom = GetDateByBillNumber(reader);
                    lstBillRegister.Add(billregisterDom);
                }
            }
            return lstBillRegister;
        }

        private BillRegister GetDateByBillNumber(IDataReader reader)
        {
            BillRegister billRegister = new BillRegister();
            billRegister.RegisterConsignment = new Consignment();
            billRegister.Date = GetStringFromDataReader(reader, "Date");
            billRegister.BillNo = GetIntegerFromDataReader(reader, "BillNo");
            billRegister.PaxName = GetStringFromDataReader(reader, "Pax");
            billRegister.PartyName = GetStringFromDataReader(reader, "PartyName");
            billRegister.VisaCountry = GetStringFromDataReader(reader, "VisaCountry");
            billRegister.Visa = GetDecimalFromDataReader(reader, "VisaCharge");
            billRegister.Attestation = GetDecimalFromDataReader(reader, "AttestationCharge");
            billRegister.Token = GetDecimalFromDataReader(reader, "TokenCharge");
            billRegister.Vfs = GetDecimalFromDataReader(reader, "VFS/BLS/TTS");
            billRegister.Handling = GetDecimalFromDataReader(reader, "Handling");
            billRegister.Courior = GetDecimalFromDataReader(reader, "Courier");
            billRegister.Delivery = GetDecimalFromDataReader(reader, "Delivery");
            billRegister.Convenience = GetDecimalFromDataReader(reader, "Drop") + GetDecimalFromDataReader(reader, "Cargo_Pick");
            billRegister.Urgent = GetDecimalFromDataReader(reader, "Urgent");
            billRegister.Draft = GetDecimalFromDataReader(reader, "Draft");
            billRegister.Insurance = GetDecimalFromDataReader(reader, "Insurance");
            billRegister.OtherCharge = GetDecimalFromDataReader(reader, "OtherCharges");
            billRegister.ServiceCharge = GetDecimalFromDataReader(reader, "ServiceCharge");
            billRegister.ServiceTax = GetDecimalFromDataReader(reader, "S_Tax");
            billRegister.Amount = GetDecimalFromDataReader(reader, "Amount");
            billRegister.RegisterConsignment.CG_ID = GetStringFromDataReader(reader, "ConsimentId");
            billRegister.RegisterConsignment.CgNoOfPass = GetIntegerFromDataReader(reader, "Passport");
            billRegister.RegisterConsignment.CgCorporate = GetStringFromDataReader(reader, "Corporate");
            return billRegister;
        }
        public List<BillRegister> ReadBillRegisterInformationByDate(DateTime? frDate, DateTime? toDate, int? AgentId, int? LocId)
        {
            //if (LocId != 0)
            //{
            //    queryBill = "Select CONVERT(VARCHAR(20), BILL.BILL_DATE, 103) AS 'Date',CONVERT(VARCHAR,BILL.BILL_ID,20) AS 'BillNo',UPPER(ISNULL(AGENT.TALLY_ACNAME, AGENT.AGENT_NAME)) AS 'PartyName', UPPER(Bill.PAXS) as Pax,left(UPPER(COUNTRY.COUNTRY_NAME),3) AS 'VisaCountry', SUM(ISNULL(VISA.FEE,0)) AS 'VisaCharge', SUM(ISNULL(ATTEST.FEE,0)) AS 'AttestationCharge', SUM(ISNULL(Token.FEE,0)) as 'TokenCharge', SUM(ISNULL(VFS.FEE,0)) as 'VFS/BLS/TTS', SUM(ISNULL(HANDLING.FEE,0)) as 'Handling', SUM(ISNULL(Courier.FEE,0)) as 'Courier', SUM(ISNULL(Draft.FEE,0)) as 'Draft', SUM(ISNULL(Delivery.FEE,0)) as 'Delivery', SUM(ISNULL(Dropc.FEE,0)) as 'Drop', SUM(ISNULL(Pickup.FEE,0)) as 'Cargo_Pick', SUM(ISNULL(Urgent.FEE,0)) as 'Urgent', SUM(ISNULL(Insurance.FEE,0)) as 'Insurance', (CustomBillTotal.TotalAmount+Bill.ServiceCharge +(Bill.servicecharge*Bill.ServiceTax)/100 - (Bill.servicecharge + sum(isnull(VFS.FEE,0)) + SUM(ISNULL(Visa.Fee,0))+ sum(isnull(ATTEST.FEE,0)) + sum(isnull(Token.FEE,0))+ sum(isnull(Handling.FEE,0))+ sum(isnull(Courier.FEE,0)) + sum(isnull(Delivery.FEE,0))+ sum(isnull(Dropc.FEE,0))+ sum(isnull(Pickup.FEE,0)) + sum(isnull(Urgent.FEE,0))+ sum(isnull(Draft.FEE,0)) + sum(isnull(Insurance.FEE,0)) +(Bill.servicecharge*Bill.ServiceTax)/100)) as 'OtherCharges', Bill.servicecharge As 'ServiceCharge', (BILL.SERVICETAX) as 'S_Tax', (CustomBillTotal.TotalAmount+Bill.ServiceCharge + Bill.ServiceTax) as 'Amount' FROM Bill INNER JOIN CONSIGNMENT ON CONSIGNMENT.CG_ID=BILL.FK_CG_ID INNER JOIN AGENT ON AGENT.AGENT_ID=CONSIGNMENT.FK_AGENT_ID INNER JOIN COUNTRY ON COUNTRY.COUNTRY_ID=CONSIGNMENT.CG_VISACOUNTRY LEFT JOIN (Select SUM(ISNULL(tem.FEE*tem.NoOfVisa,0)) As TotalAmount,BillID as FK_BillMSTR_ID from (Select  BD.FK_BILL_ID as BillID,'' as NoOfVisa,(BD.CHARGE_PERUNIT*BD.UNITS) as FEE, '' as Description FROM  BILL_DETAILS BD UNION Select  VD.FK_BillMSTR_ID as BillID,VD.NoOfVisa as NoOfVisa,VISAFEES as FEE,VD.Description as Description FROM dbo.BILL_VISAFEES VD )tem Group by  tem.BillID) AS CustomBillTotal ON CustomBillTotal.FK_BillMSTR_ID=BILL.BILL_ID LEFT JOIN (Select BD.FK_BillMSTR_ID AS BillID,SUM(ISNULL(BD.VisaFees*NoOfVisa,0)) AS FEE from Bill_VisaFees BD Where BD.Description Like '%Attest%' Group by BD.FK_BillMSTR_ID) AS ATTEST ON BILL.BILL_ID=ATTEST.BillID LEFT JOIN (Select VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD WHERE Description Like '%Visa%' GROUP BY VD.FK_BillMSTR_ID) AS VISA ON VISA.BillID=BILL.BILL_ID LEFT JOIN (Select BD.FK_BillMSTR_ID AS BILLID,SUM(ISNULL(BD.VisaFees*NoOfVisa,0)) AS FEE from Bill_VisaFees BD Where BD.Description Like '%Token%' Group by BD.FK_BillMSTR_ID) as Token ON BILL.BILL_ID=TOKEN.BILLID LEFT JOIN (Select VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%VFS/BLS/TTS%' Group by VD.FK_BillMSTR_ID) as VFS ON VFS.BILLID=BILL.BILL_ID LEFT JOIN (Select VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%Handling%' Group by  VD.FK_BillMSTR_ID) AS HANDLING ON HANDLING.BILLID=BILL.BILL_ID LEFT JOIN (Select VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%Courier%' Group by  VD.FK_BillMSTR_ID) AS Courier ON COURIER.BILLID=BILL.BILL_ID LEFT JOIN (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%Delivery%' Group by  VD.FK_BillMSTR_ID) AS Delivery ON Delivery.BILLID=BILL.BILL_ID LEFT JOIN (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES,0)) as FEE FROM dbo.BILL_VISAFEES VD Where VD.Description Like '%Dropc%' Group by  VD.FK_BillMSTR_ID) AS Dropc ON Dropc.BillId=BILL.BILL_ID LEFT join (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%Pickup%' Group by  VD.FK_BillMSTR_ID) AS Pickup ON Pickup.BILLID=BILL.BILL_ID LEFT JOIN (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES,0)) as FEE FROM dbo.BILL_VISAFEES VD Where VD.Description Like '%Urgent%' Group by  VD.FK_BillMSTR_ID) AS Urgent ON Urgent.BILLID=BILL.BILL_ID LEFT JOIN (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%Draft%' Group by  VD.FK_BillMSTR_ID) AS Draft ON Draft.BILLID=BILL.BILL_ID LEFT JOIN (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES,0)) as FEE FROM dbo.BILL_VISAFEES VD Where VD.Description Like '%Insurance%' Group by  VD.FK_BillMSTR_ID) AS Insurance ON Insurance.BILLID=BILL.BILL_ID Where Bill.ISCANCELLED <>'Y' AND CAST(CONVERT(VARCHAR(10), BILL.BILL_DATE, 111) AS DATETIME)>=CAST(CONVERT(VARCHAR(20),'" + fromDate.ToShortDateString() + "' , 131)AS DATETIME) AND  CAST(CONVERT(VARCHAR(10), BILL.BILL_DATE, 111) AS DATETIME)<=CAST(CONVERT(VARCHAR(20),'" + toDate.ToShortDateString() + "' , 131) AS DATETIME) AND AGENT.AGENT_ID = " + AgentId + " and BILL.LocationId=" + LocId + " Group by BILL.BILL_DATE,Bill.Bill_id,Bill.PAXS,AGENT.TALLY_ACNAME,AGENT.AGENT_NAME, VISA.FEE,Token.FEE,VFS.FEE,HANDLING.FEE,Courier.FEE,Delivery.FEE,Dropc.FEE, Pickup.FEE,Urgent.FEE,Draft.FEE,Insurance.FEE, COUNTRY.COUNTRY_NAME,Bill.servicecharge,Bill.TotalAmt,Bill.ServiceTax,CustomBillTotal.TotalAmount ORDER BY BILL.BILL_ID asc";
            //}
            //else
            //{
            //    queryBill = "Select CONVERT(VARCHAR(20), BILL.BILL_DATE, 103) AS 'Date',CONVERT(VARCHAR,BILL.BILL_ID,20) AS 'BillNo',UPPER(ISNULL(AGENT.TALLY_ACNAME, AGENT.AGENT_NAME)) AS 'PartyName', UPPER(Bill.PAXS) as Pax,left(UPPER(COUNTRY.COUNTRY_NAME),3) AS 'VisaCountry', SUM(ISNULL(VISA.FEE,0)) AS 'VisaCharge', SUM(ISNULL(ATTEST.FEE,0)) AS 'AttestationCharge', SUM(ISNULL(Token.FEE,0)) as 'TokenCharge', SUM(ISNULL(VFS.FEE,0)) as 'VFS/BLS/TTS', SUM(ISNULL(HANDLING.FEE,0)) as 'Handling', SUM(ISNULL(Courier.FEE,0)) as 'Courier', SUM(ISNULL(Draft.FEE,0)) as 'Draft', SUM(ISNULL(Delivery.FEE,0)) as 'Delivery', SUM(ISNULL(Dropc.FEE,0)) as 'Drop', SUM(ISNULL(Pickup.FEE,0)) as 'Cargo_Pick', SUM(ISNULL(Urgent.FEE,0)) as 'Urgent', SUM(ISNULL(Insurance.FEE,0)) as 'Insurance', (CustomBillTotal.TotalAmount+Bill.ServiceCharge +(Bill.servicecharge*Bill.ServiceTax)/100 - (Bill.servicecharge + sum(isnull(VFS.FEE,0)) + SUM(ISNULL(Visa.Fee,0))+ sum(isnull(ATTEST.FEE,0)) + sum(isnull(Token.FEE,0))+ sum(isnull(Handling.FEE,0))+ sum(isnull(Courier.FEE,0)) + sum(isnull(Delivery.FEE,0))+ sum(isnull(Dropc.FEE,0))+ sum(isnull(Pickup.FEE,0)) + sum(isnull(Urgent.FEE,0))+ sum(isnull(Draft.FEE,0)) + sum(isnull(Insurance.FEE,0)) +(Bill.servicecharge*Bill.ServiceTax)/100)) as 'OtherCharges', Bill.servicecharge As 'ServiceCharge', (BILL.SERVICETAX) as 'S_Tax', (CustomBillTotal.TotalAmount+Bill.ServiceCharge + Bill.ServiceTax) as 'Amount' FROM Bill INNER JOIN CONSIGNMENT ON CONSIGNMENT.CG_ID=BILL.FK_CG_ID INNER JOIN AGENT ON AGENT.AGENT_ID=CONSIGNMENT.FK_AGENT_ID INNER JOIN COUNTRY ON COUNTRY.COUNTRY_ID=CONSIGNMENT.CG_VISACOUNTRY LEFT JOIN (Select SUM(ISNULL(tem.FEE*tem.NoOfVisa,0)) As TotalAmount,BillID as FK_BillMSTR_ID from (Select  BD.FK_BILL_ID as BillID,'' as NoOfVisa,(BD.CHARGE_PERUNIT*BD.UNITS) as FEE, '' as Description FROM  BILL_DETAILS BD UNION Select  VD.FK_BillMSTR_ID as BillID,VD.NoOfVisa as NoOfVisa,VISAFEES as FEE,VD.Description as Description FROM dbo.BILL_VISAFEES VD )tem Group by  tem.BillID) AS CustomBillTotal ON CustomBillTotal.FK_BillMSTR_ID=BILL.BILL_ID LEFT JOIN (Select BD.FK_BillMSTR_ID AS BillID,SUM(ISNULL(BD.VisaFees*NoOfVisa,0)) AS FEE from Bill_VisaFees BD Where BD.Description Like '%Attest%' Group by BD.FK_BillMSTR_ID) AS ATTEST ON BILL.BILL_ID=ATTEST.BillID LEFT JOIN (Select VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD WHERE Description Like '%Visa%' GROUP BY VD.FK_BillMSTR_ID) AS VISA ON VISA.BillID=BILL.BILL_ID LEFT JOIN (Select BD.FK_BillMSTR_ID AS BILLID,SUM(ISNULL(BD.VisaFees*NoOfVisa,0)) AS FEE from Bill_VisaFees BD Where BD.Description Like '%Token%' Group by BD.FK_BillMSTR_ID) as Token ON BILL.BILL_ID=TOKEN.BILLID LEFT JOIN (Select VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%VFS/BLS/TTS%' Group by VD.FK_BillMSTR_ID) as VFS ON VFS.BILLID=BILL.BILL_ID LEFT JOIN (Select VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%Handling%' Group by  VD.FK_BillMSTR_ID) AS HANDLING ON HANDLING.BILLID=BILL.BILL_ID LEFT JOIN (Select VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%Courier%' Group by  VD.FK_BillMSTR_ID) AS Courier ON COURIER.BILLID=BILL.BILL_ID LEFT JOIN (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%Delivery%' Group by  VD.FK_BillMSTR_ID) AS Delivery ON Delivery.BILLID=BILL.BILL_ID LEFT JOIN (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES,0)) as FEE FROM dbo.BILL_VISAFEES VD Where VD.Description Like '%Dropc%' Group by  VD.FK_BillMSTR_ID) AS Dropc ON Dropc.BillId=BILL.BILL_ID LEFT join (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%Pickup%' Group by  VD.FK_BillMSTR_ID) AS Pickup ON Pickup.BILLID=BILL.BILL_ID LEFT JOIN (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES,0)) as FEE FROM dbo.BILL_VISAFEES VD Where VD.Description Like '%Urgent%' Group by  VD.FK_BillMSTR_ID) AS Urgent ON Urgent.BILLID=BILL.BILL_ID LEFT JOIN (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES*NoOfVisa,0)) as FEE FROM BILL_VISAFEES VD Where VD.Description Like '%Draft%' Group by  VD.FK_BillMSTR_ID) AS Draft ON Draft.BILLID=BILL.BILL_ID LEFT JOIN (Select  VD.FK_BillMSTR_ID as BillID,SUM(ISNULL(VISAFEES,0)) as FEE FROM dbo.BILL_VISAFEES VD Where VD.Description Like '%Insurance%' Group by  VD.FK_BillMSTR_ID) AS Insurance ON Insurance.BILLID=BILL.BILL_ID Where Bill.ISCANCELLED <>'Y' AND CAST(CONVERT(VARCHAR(10), BILL.BILL_DATE, 111) AS DATETIME)>=CAST(CONVERT(VARCHAR(20),'" + fromDate.ToShortDateString() + "' , 131)AS DATETIME) AND  CAST(CONVERT(VARCHAR(10), BILL.BILL_DATE, 111) AS DATETIME)<=CAST(CONVERT(VARCHAR(20),'" + toDate.ToShortDateString() + "' , 131) AS DATETIME) AND AGENT.AGENT_ID = " + AgentId + " Group by BILL.BILL_DATE,Bill.Bill_id,Bill.PAXS,AGENT.TALLY_ACNAME,AGENT.AGENT_NAME, VISA.FEE,Token.FEE,VFS.FEE,HANDLING.FEE,Courier.FEE,Delivery.FEE,Dropc.FEE, Pickup.FEE,Urgent.FEE,Draft.FEE,Insurance.FEE, COUNTRY.COUNTRY_NAME,Bill.servicecharge,Bill.TotalAmt,Bill.ServiceTax,CustomBillTotal.TotalAmount ORDER BY BILL.BILL_ID asc";
            //}
            List<BillRegister> lstBillregister = new List<BillRegister>();
            if (frDate != null && toDate != null)
            {
                DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_DATABY_DATE);

                dbCommand.CommandTimeout = 1500;
                string FromDate = frDate.Value.ToString("MM/dd/yyyy");
                string todateDate = toDate.Value.ToString("MM/dd/yyyy");
                myDataBase.AddInParameter(dbCommand, "in_FromDateA", DbType.String, FromDate);
                myDataBase.AddInParameter(dbCommand, "in_ToDateB", DbType.String, todateDate);

                if (AgentId != 0)
                {
                    myDataBase.AddInParameter(dbCommand, "@inAgentId", DbType.Int32, AgentId);
                }
                else
                {
                    myDataBase.AddInParameter(dbCommand, "@inAgentId", DbType.Int32, DBNull.Value);
                }
                using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
                {
                    
                    while (reader.Read())
                    {
                        var billregisterDom = GenrateRecord(reader);
                        lstBillregister.Add(billregisterDom);
                    }
                }
                return lstBillregister;
            }
            if (AgentId != null)
            {
                BillRegister billregisterDom = new BillRegister();
                DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_DATABY_AGENTID);
                dbCommand.CommandTimeout = 1500;
                myDataBase.AddInParameter(dbCommand, "@in_Agent_Id", DbType.Int32, AgentId);

                using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        billregisterDom = GenrateRecord(reader);
                        lstBillregister.Add(billregisterDom);
                    }
                }
                return lstBillregister;
            }
            return lstBillregister;
        }

        #endregion

        private BillRegister GenrateRecord(IDataReader reader)
        {
            BillRegister billRegister = new BillRegister();
            billRegister.RegisterConsignment = new Consignment();
            billRegister.Date = GetStringFromDataReader(reader, "Date");
            billRegister.BillNo = GetIntegerFromDataReader(reader, "BillNo");
            billRegister.PaxName = GetStringFromDataReader(reader, "Pax");
            billRegister.PartyName = GetStringFromDataReader(reader, "PartyName");
            billRegister.VisaCountry = GetStringFromDataReader(reader, "VisaCountry");
            billRegister.Visa = GetDecimalFromDataReader(reader, "VisaCharge");
            billRegister.Attestation = GetDecimalFromDataReader(reader, "AttestationCharge");
            billRegister.Token = GetDecimalFromDataReader(reader, "TokenCharge");
            billRegister.Vfs = GetDecimalFromDataReader(reader, "VFS/BLS/TTS");
            billRegister.Handling = GetDecimalFromDataReader(reader, "Handling");
            billRegister.Courior = GetDecimalFromDataReader(reader, "Courier");
            billRegister.Delivery = GetDecimalFromDataReader(reader, "Delivery");
            billRegister.Convenience = GetDecimalFromDataReader(reader, "Drop") + GetDecimalFromDataReader(reader, "Cargo_Pick");
            billRegister.Urgent = GetDecimalFromDataReader(reader, "Urgent");
            billRegister.Draft = GetDecimalFromDataReader(reader, "Draft");
            billRegister.Insurance = GetDecimalFromDataReader(reader, "Insurance");
            billRegister.OtherCharge = GetDecimalFromDataReader(reader, "OtherCharges");
            billRegister.ServiceCharge = GetDecimalFromDataReader(reader, "ServiceCharge");
            billRegister.ServiceTax = GetDecimalFromDataReader(reader, "S_Tax");
            billRegister.Amount = GetDecimalFromDataReader(reader, "Amount");
            billRegister.RegisterConsignment.CG_ID = GetStringFromDataReader(reader, "ConsimentId");
            billRegister.RegisterConsignment.CgNoOfPass = GetIntegerFromDataReader(reader, "Passport");
            billRegister.RegisterConsignment.CgCorporate = GetStringFromDataReader(reader, "Corporate");
            return billRegister;
        }

        public List<BillRegister> BillRegisterByDate(DateTime? fromDate, DateTime? toDate, int? agentId, int? LocId)
        {
            List<BillRegister> lstBillRegister = new List<BillRegister>();
            if (fromDate != null && toDate != null && agentId!=null)
            {
                DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_BILLBY_BILLDATE);
                string FromDate = fromDate.Value.ToString("MM/dd/yyyy");
                string todateDate = toDate.Value.ToString("MM/dd/yyyy");
                myDataBase.AddInParameter(dbCommand, "@in_from_date", DbType.DateTime, FromDate);
                myDataBase.AddInParameter(dbCommand, "@in_to_date", DbType.DateTime, todateDate);
                if (agentId != 0)
                {
                    myDataBase.AddInParameter(dbCommand, "@inAgentId", DbType.Int32, agentId);
                }
                else
                {
                    myDataBase.AddInParameter(dbCommand, "@inAgentId", DbType.Int32, DBNull.Value);
                }
               
                using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

                    while (reader.Read())
                    {
                        var billregisterDom = READ(reader);
                        lstBillRegister.Add(billregisterDom);
                    }
                return lstBillRegister;
            }
            if (agentId != null)
            {
                BillRegister billregisterDom = new BillRegister();
                DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_BillRegisterBY_AGENTID);
                myDataBase.AddInParameter(dbCommand, "@inAgentId", DbType.Int32, agentId);
                if (LocId != 0)
                {
                    myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
                }
                else
                {
                    myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
                }
                using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        billregisterDom = READ(reader);
                        lstBillRegister.Add(billregisterDom);
                    }
                }
                return lstBillRegister;
            }
            return lstBillRegister;
        }
        public BillRegister READ(IDataReader reader)
        {
            BillRegister billRegister = new BillRegister();
            billRegister.RegisterBill = new Bill();
            billRegister.RegisterConsignment = new Consignment();

           //billRegister.RegisterBill.Version = GetIntegerFromDataReader(reader, "Versioning");
            billRegister.RegisterBill.BillId = GetIntegerFromDataReader(reader, "BILL_ID");
            billRegister.RegisterConsignment.CgNoOfPass = GetIntegerFromDataReader(reader, "CG_NOOFPASS");
            billRegister.RegisterConsignment.CgCorporate = GetStringFromDataReader(reader, "CG_CORPORATE");
            billRegister.RegisterConsignment.ConsignmentId = GetIntegerFromDataReader(reader, "FK_CG_ID");
            billRegister.Amount = GetDecimalFromDataReader(reader, "TotalAmt");
            billRegister.RegisterBill.BillDate = GetDateFromReader(reader, "BILLDATE");
            billRegister.RegisterBill.Paxs = GetStringFromDataReader(reader, "PAXS");
            billRegister.VisaCountry = GetStringFromDataReader(reader, "COUNTRY_NAME");
            return billRegister;
        }
    }
}
