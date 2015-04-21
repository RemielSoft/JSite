using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace Remielsoft.JetSave.DataAccessLayer
{
    public class GenerateInvoiceDAL : BaseDataAccess
    {
        private Database myDataBase;
        public GenerateInvoiceDAL(Database m_database)
        {
            myDataBase = m_database;
        }

        #region Read Invoice Details

        public List<BillItem> ReadInvoiceDetails(Int32 visaTypeOneId, Int32 visaTypeTwoId, Int32 AgentId, Int32 CountryId)
        {
            List<BillItem> lstBillItem = new List<BillItem>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_NEWBILLCHARGE);
            myDataBase.AddInParameter(dbCommand, "@VisaTypeOneId", DbType.Int32, visaTypeOneId);
            myDataBase.AddInParameter(dbCommand, "@VisaTypeTwoId", DbType.Int32, visaTypeTwoId);
            myDataBase.AddInParameter(dbCommand, "@agentId", DbType.Int32, AgentId);
            myDataBase.AddInParameter(dbCommand, "@CountryId ", DbType.Int32, CountryId);

            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    BillItem billItemDOM = new BillItem();
                    billItemDOM.BillItemDescription = GetStringFromDataReader(reader, "DESCRIPTION");
                    billItemDOM.ItemCharge = GetDecimalFromDataReader(reader, "CHARGE");
                    if (CountryId == 0)
                    {
                        billItemDOM.CountryId = 0;
                    }
                    else
                    {
                        billItemDOM.CountryId = GetIntegerFromDataReader(reader, "CountryId");
                    }
                    lstBillItem.Add(billItemDOM);
                }
            }
            return lstBillItem;
        }

        #endregion

        #region Read Service TAX

        public List<Bill> ReadServiceTax()
        {
            List<Bill> lstServiceTax = new List<Bill>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_SERVICECHARGE);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Bill billDOM = new Bill();
                    billDOM.ServiceTax = GetDecimalFromDataReader(reader, "MISC_AMOUNT");
                    lstServiceTax.Add(billDOM);
                }
            }
            return lstServiceTax;

        }
        #endregion

        #region Read Service Charge

        public List<Bill> ReadServiceCharge()
        {
            List<Bill> lstServiceCharge = new List<Bill>();
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("select MISC_AMOUNT from MISC_CHARGES where upper( MISC_SERVICECHARGES)='TRUE'");
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Bill billDOM = new Bill();
                    billDOM.ServiceCharge = GetDecimalFromDataReader(reader, "MISC_AMOUNT");
                    lstServiceCharge.Add(billDOM);
                }
            }
            return lstServiceCharge;

        }
        #endregion

        #region Read Version Number

        public List<Bill> ReadVersionNumber(int no)
        {
            List<Bill> lst = new List<Bill>();
            DbCommand dbCommand = myDataBase.GetSqlStringCommand(" select * from bill_history where bill_id='" + no + "'");
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Bill billDOM = new Bill();
                    billDOM.BillId = GetIntegerFromDataReader(reader, "BILL_ID");
                   // billDOM.Version = GetIntegerFromDataReader(reader, "Versioning");
                    lst.Add(billDOM);
                }
            }
            return lst;

        }
        #endregion

        #region Read Email For Preview Invoice

        public List<Bill> ReadPreviewEmailShow(int LocId)
        {
            List<Bill> lstEmail = new List<Bill>();
            string query = null;
            if (LocId == 0)
            {
                query = "select Bill_EmailId.*,Location.LocationAddress from bill_emailId inner join Location on Bill_EmailId.LocationId=Location.LocationId where  Bill_EmailId.LocationId=62";
            }
            else
            {
                query = "select Bill_EmailId.*,Location.LocationAddress from bill_emailId inner join Location on Bill_EmailId.LocationId=Location.LocationId where  Bill_EmailId.LocationId='" + LocId + "'";
            }
            DbCommand dbCommand = myDataBase.GetSqlStringCommand(query);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Bill billDOM = new Bill();
                    billDOM.AgentDetails = new Agent();
                    billDOM.AgentDetails.AgentEmail = GetStringFromDataReader(reader, "Email");
                    billDOM.AgentDetails.AgentFax = GetStringFromDataReader(reader, "FaxNo");
                    billDOM.AgentDetails.AgentPhone = GetStringFromDataReader(reader, "Phone");
                    billDOM.AgentDetails.AgentAddress = GetStringFromDataReader(reader, "LocationAddress");
                    lstEmail.Add(billDOM);
                }
            }
            return lstEmail;

        }
        #endregion

        #region Read Micwllaneous Charge

        public List<Miscellaneous> ReadMicCharges(string description)
        {
            List<Miscellaneous> lstMicCharge = new List<Miscellaneous>();
            DbCommand dbcommand = myDataBase.GetSqlStringCommand("select MISC_ID,APPLICABLE,MISC_DESCRIPTION as Description,MISC_AMOUNT as Charge from MISC_CHARGES where MISC_DESCRIPTION='" + description + "'");
            using (IDataReader reader = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader.Read())
                {
                    Miscellaneous MichlaDOM = new Miscellaneous();

                    MichlaDOM.Description = GetStringFromDataReader(reader, "Description");
                    MichlaDOM.Amount = GetDecimalFromDataReader(reader, "Charge");
                    MichlaDOM.Per_consignment = GetStringFromDataReader(reader, "APPLICABLE");
                    lstMicCharge.Add(MichlaDOM);

                }
            }

            return lstMicCharge;
        }
        #endregion

        #region Invoice Insert

        public int CreateInvoice(Bill billDOM)
        {
            int billId;

            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.CREATE_INVOICE);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, billDOM.LocationId);
            myDataBase.AddInParameter(dbCommand, "@BILL_DATE", DbType.DateTime, billDOM.BillDate);
            myDataBase.AddInParameter(dbCommand, "@BILL_TYPE", DbType.String, billDOM.BillType);
            myDataBase.AddInParameter(dbCommand, "@FK_CG_ID", DbType.String, billDOM.ConsignmentId);
            myDataBase.AddInParameter(dbCommand, "@PAXS", DbType.String, billDOM.Paxs);
            myDataBase.AddInParameter(dbCommand, "@ServiceCharge", DbType.Decimal, billDOM.ServiceCharge);
            myDataBase.AddInParameter(dbCommand, "@TotalAmt", DbType.Decimal, billDOM.TotalAmount);
            myDataBase.AddInParameter(dbCommand, "@ServiceTax", DbType.Decimal, billDOM.ServiceTax);
            myDataBase.AddOutParameter(dbCommand, "@out_BILL_ID", DbType.Int32, 10);
            myDataBase.ExecuteNonQuery(dbCommand);
            int.TryParse(myDataBase.GetParameterValue(dbCommand, "@out_BILL_ID").ToString(), out billId);

            return billId;
        }

        #endregion

        #region Invoice Insert IN Bill Details

        public void CreateBillDetails(BillItem billItemDOM)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.CREATE_BILLDETAILS);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@FK_BILLMSTR_ID", DbType.Int32, billItemDOM.BillItemId);
            myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, billItemDOM.LocationId);
            myDataBase.AddInParameter(dbCommand, "@DESCRIPTION", DbType.String, billItemDOM.BillItemDescription);
            myDataBase.AddInParameter(dbCommand, "@VISAFEES", DbType.Decimal, billItemDOM.ItemCharge);
            myDataBase.AddInParameter(dbCommand, "@NOOFVIsa", DbType.Int32, billItemDOM.ItemQuantity);
            myDataBase.ExecuteNonQuery(dbCommand);
        }

        public void CreateModBillDetails(BillItem billItemDOM, int billid, int version)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.CREATE_MODBILLDETAILS);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@FK_BILLMSTR_ID", DbType.Int32, billid);
            myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, billItemDOM.LocationId);
            myDataBase.AddInParameter(dbCommand, "@DESCRIPTION", DbType.String, billItemDOM.BillItemDescription);
            myDataBase.AddInParameter(dbCommand, "@VISAFEES", DbType.Decimal, billItemDOM.ItemCharge);
            myDataBase.AddInParameter(dbCommand, "@NOOFVIsa", DbType.Int32, billItemDOM.ItemQuantity);
            myDataBase.AddInParameter(dbCommand, "@Versioning", DbType.Int32, version);
            myDataBase.ExecuteNonQuery(dbCommand);
        }


        #endregion



        #region Invoice Update

        public void UpdateInvoice(Bill billDOM, int version, int billid)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_INVOICE);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@billid", DbType.Int32, billid);
            myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, billDOM.LocationId);
            myDataBase.AddInParameter(dbCommand, "@BILL_DATE", DbType.DateTime, billDOM.BillDate);
            myDataBase.AddInParameter(dbCommand, "@BILL_TYPE", DbType.String, billDOM.BillType);
            myDataBase.AddInParameter(dbCommand, "@FK_CG_ID", DbType.String, billDOM.ConsignmentId);
            myDataBase.AddInParameter(dbCommand, "@PAXS", DbType.String, billDOM.Paxs);
            myDataBase.AddInParameter(dbCommand, "@ServiceCharge", DbType.Decimal, billDOM.ServiceCharge);
            myDataBase.AddInParameter(dbCommand, "@TotalAmt", DbType.Decimal, billDOM.TotalAmount);
            myDataBase.AddInParameter(dbCommand, "@ServiceTax", DbType.Decimal, billDOM.ServiceTax);
            myDataBase.AddInParameter(dbCommand, "@Versioning", DbType.Int32, version);
            myDataBase.ExecuteNonQuery(dbCommand);
        }

        #endregion

        #region Invoice Update IN Bill Details

        public void UpdateBillDetails(BillItem billItemDOM, int version, int billid, int id)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_BILLDETAILS);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@id", DbType.Int32, id);
            myDataBase.AddInParameter(dbCommand, "@billid", DbType.Int32, billid);
            myDataBase.AddInParameter(dbCommand, "@DESCRIPTION", DbType.String, billItemDOM.BillItemDescription);
            myDataBase.AddInParameter(dbCommand, "@VISAFEES", DbType.Decimal, billItemDOM.ItemCharge);
            myDataBase.AddInParameter(dbCommand, "@NOOFVIsa", DbType.Int32, billItemDOM.ItemQuantity);
            myDataBase.AddInParameter(dbCommand, "@Versioning", DbType.Int32, version);
            myDataBase.ExecuteNonQuery(dbCommand);
        }


        #endregion

        #region Read Bill For RePrintInvoice

        public List<Bill> ReadBillRePrintInvoice(string InvoiceType, int? LocId)
        {

            List<Bill> lstBill = new List<Bill>();

            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_BillRePrintInvoiceBy_BillType);
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            myDataBase.AddInParameter(dbCommand, "@BILL_TYPE", DbType.String, InvoiceType);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

                while (reader.Read())
                {
                    Bill billDOM = new Bill();
                    billDOM.AgentDetails = new Agent();
                    billDOM.BillId = GetIntegerFromDataReader(reader, "BILL_ID");
                    billDOM.BillDate = GetDateFromReader(reader, "BILL_DATE");
                    billDOM.ConsignmentId = GetIntegerFromDataReader(reader, "FK_CG_ID");
                    billDOM.AgentDetails.AgentId = GetIntegerFromDataReader(reader, "AGENT_ID");
                    billDOM.BillType = GetStringFromDataReader(reader, "BILL_TYPE");
                    billDOM.Paxs = GetStringFromDataReader(reader, "PAXS");
                    billDOM.ServiceCharge = GetDecimalFromDataReader(reader, "ServiceCharge");
                    billDOM.TotalAmount = GetDecimalFromDataReader(reader, "TotalAmt");
                    billDOM.ServiceTax = GetDecimalFromDataReader(reader, "ServiceTax");
                    billDOM.Version = GetIntegerFromDataReader(reader, "Versioning");
                    billDOM.AgentDetails.AgentPhone = GetStringFromDataReader(reader, "AGENT_PHONE");
                    billDOM.AgentDetails.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
                    billDOM.AgentDetails.AgentAddress = GetStringFromDataReader(reader, "AGENT_ADDRESS");

                    lstBill.Add(billDOM);
                }
            return lstBill;

        }

        #endregion

        #region Read Bill For RePrintInvoice By ConsignmentId

        public List<Bill> ReadBillRePrintInvoiceByConsignmentId(int ConsignmentId, int? LocId)
        {

            List<Bill> lstBill = new List<Bill>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_BillRePrintInvoiceBy_ConsignmentId);
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            if (ConsignmentId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@FK_CG_ID", DbType.Int32, ConsignmentId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@FK_CG_ID", DbType.Int32, DBNull.Value);
            }
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

                while (reader.Read())
                {
                    Bill billDOM = new Bill();
                    billDOM.AgentDetails = new Agent();
                    billDOM.BillId = GetIntegerFromDataReader(reader, "BILL_ID");
                    billDOM.BillDate = GetDateFromReader(reader, "BILL_DATE");
                    billDOM.ConsignmentId = GetIntegerFromDataReader(reader, "FK_CG_ID");
                    billDOM.AgentDetails.AgentId = GetIntegerFromDataReader(reader, "AGENT_ID");
                    billDOM.BillType = GetStringFromDataReader(reader, "BILL_TYPE");
                    billDOM.Paxs = GetStringFromDataReader(reader, "PAXS");
                    billDOM.ServiceCharge = GetDecimalFromDataReader(reader, "ServiceCharge");
                    billDOM.TotalAmount = GetDecimalFromDataReader(reader, "TotalAmt");
                    billDOM.ServiceTax = GetDecimalFromDataReader(reader, "ServiceTax");
                    billDOM.Version = GetIntegerFromDataReader(reader, "Versioning");
                    billDOM.AgentDetails.AgentPhone = GetStringFromDataReader(reader, "AGENT_PHONE");
                    billDOM.AgentDetails.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
                    billDOM.AgentDetails.AgentAddress = GetStringFromDataReader(reader, "AGENT_ADDRESS");
                    lstBill.Add(billDOM);
                }
            return lstBill;

        }

        #endregion

        #region Read Bill For RePrintInvoice By Agent Name

        public List<Bill> ReadBillRePrintInvoiceByAgentName(string agentName, int? LocId)
        {

            List<Bill> lstBill = new List<Bill>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_BillRePrintInvoiceBy_AgentName);
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            myDataBase.AddInParameter(dbCommand, "@AGENT_NAME", DbType.String, agentName);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

                while (reader.Read())
                {
                    Bill billDOM = new Bill();
                    billDOM.AgentDetails = new Agent();
                    billDOM.BillId = GetIntegerFromDataReader(reader, "BILL_ID");
                    billDOM.BillDate = GetDateFromReader(reader, "BILL_DATE");
                    billDOM.ConsignmentId = GetIntegerFromDataReader(reader, "FK_CG_ID");
                    billDOM.AgentDetails.AgentId = GetIntegerFromDataReader(reader, "AGENT_ID");
                    billDOM.BillType = GetStringFromDataReader(reader, "BILL_TYPE");
                    billDOM.Paxs = GetStringFromDataReader(reader, "PAXS");
                    billDOM.ServiceCharge = GetDecimalFromDataReader(reader, "ServiceCharge");
                    billDOM.TotalAmount = GetDecimalFromDataReader(reader, "TotalAmt");
                    billDOM.ServiceTax = GetDecimalFromDataReader(reader, "ServiceTax");
                    billDOM.Version = GetIntegerFromDataReader(reader, "Versioning");
                    billDOM.AgentDetails.AgentPhone = GetStringFromDataReader(reader, "AGENT_PHONE");
                    billDOM.AgentDetails.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
                    billDOM.AgentDetails.AgentAddress = GetStringFromDataReader(reader, "AGENT_ADDRESS");
                    lstBill.Add(billDOM);
                }
            return lstBill;

        }

        #endregion


        #region Read Bill For RePrintInvoice By BilId

        public List<Bill> ReadBillRePrintInvoiceByBilId(int Billid, int? LocId, int version)
        {

            List<Bill> lstBill = new List<Bill>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_BillRePrintInvoiceBy_BilId);
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            if (Billid != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@billid", DbType.Int32, Billid);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@billid", DbType.Int32, DBNull.Value);
            }
            myDataBase.AddInParameter(dbCommand, "@version", DbType.Int32, version);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

                while (reader.Read())
                {
                    Bill billDOM = new Bill();
                    billDOM.AgentDetails = new Agent();
                    billDOM.BillId = GetIntegerFromDataReader(reader, "BILL_ID");
                    billDOM.BillDate = GetDateFromReader(reader, "BILL_DATE");
                    billDOM.ConsignmentId = GetIntegerFromDataReader(reader, "FK_CG_ID");
                    billDOM.AgentDetails.AgentId = GetIntegerFromDataReader(reader, "AGENT_ID");
                    billDOM.BillType = GetStringFromDataReader(reader, "BILL_TYPE");
                    billDOM.Paxs = GetStringFromDataReader(reader, "PAXS");
                    billDOM.ServiceCharge = GetDecimalFromDataReader(reader, "ServiceCharge");
                    billDOM.TotalAmount = GetDecimalFromDataReader(reader, "TotalAmt");
                    billDOM.ServiceTax = GetDecimalFromDataReader(reader, "ServiceTax");
                    billDOM.Version = GetIntegerFromDataReader(reader, "Versioning");
                    billDOM.AgentDetails.AgentPhone = GetStringFromDataReader(reader, "AGENT_PHONE");
                    billDOM.AgentDetails.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
                    billDOM.AgentDetails.AgentAddress = GetStringFromDataReader(reader, "AGENT_ADDRESS");
                    lstBill.Add(billDOM);
                }
            return lstBill;

        }

        #endregion

        #region Read BillItemDetails For Preview

        public List<BillItem> ReadBillItemPePrintInvoice(int billid, int? LocId, int? version)
        {

            List<BillItem> lstBillItem = new List<BillItem>();

            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_BillRePrintInvoiceBy_BillId);
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            if (version != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@Version", DbType.Int32, version);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@Version", DbType.Int32, DBNull.Value);
            }
            myDataBase.AddInParameter(dbCommand, "@FK_BILLMSTR_ID", DbType.Int32, billid);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

                while (reader.Read())
                {
                    BillItem billItemDOM = new BillItem();

                    billItemDOM.BillItemDescription = GetStringFromDataReader(reader, "DESCRIPTION");
                    billItemDOM.ItemCharge = GetDecimalFromDataReader(reader, "VISAFEES");
                    billItemDOM.ItemQuantity = GetIntegerFromDataReader(reader, "NOOFVIsa");
                    lstBillItem.Add(billItemDOM);
                }
            return lstBillItem;

        }

        #endregion

        #region Read Consignment By Date for print Invoice

        public List<Bill> ReadConsignmentDetailsByDate(DateTime FromDate, DateTime ToDate, int? LocId)
        {
            List<Bill> lstBill = new List<Bill>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_CONSIGNMENTBY_CONSIGNMENTDATE);
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            myDataBase.AddInParameter(dbCommand, "@in_from_date", DbType.DateTime, FromDate);
            myDataBase.AddInParameter(dbCommand, "@in_to_date", DbType.DateTime, ToDate);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Bill billDOM = new Bill();

                    billDOM.PaxDetails = new Pax();
                    billDOM.BillConsignment = new Consignment();
                    billDOM.AgentDetails = new Agent();

                    billDOM.ConsignmentId = GetIntegerFromDataReader(reader, "CG_ID");
                    billDOM.BillConsignment.CgDate = GetDateFromReader(reader, "CG_DATE");
                    billDOM.BillConsignment.FkAgentId = GetIntegerFromDataReader(reader, "FK_AGENT_ID");
                    billDOM.BillConsignment.CgNoOfPass = GetIntegerFromDataReader(reader, "CG_NOOFPASS");
                    billDOM.AgentDetails.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
                    billDOM.AgentDetails.AgentAddress = GetStringFromDataReader(reader, "AGENT_ADDRESS");
                    ////billDOM.PaxDetails.CountryId = GetIntegerFromDataReader(reader, "COUNTRY_ID");
                    ////billDOM.PaxDetails.VisaTypeOneId = GetIntegerFromDataReader(reader, "VISA_TYPE_ONE_ID");
                    ////billDOM.PaxDetails.VisaTypeTwoId = GetIntegerFromDataReader(reader, "VISA_TYPE_TWO_ID");

                    lstBill.Add(billDOM);
                }

            }
            return lstBill;
        }

        #endregion

        #region Read Consignment By ConsignmentId for print Invoice

        public List<Bill> ReadConsignmentDetailsById(int id, int? LocId)
        {
            List<Bill> lstBill = new List<Bill>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_CONSIGNMENTBY_CONSIGNMENTID);
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            myDataBase.AddInParameter(dbCommand, "@CG_ID", DbType.Int32, id);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Bill billDOM = new Bill();

                    billDOM.PaxDetails = new Pax();
                    billDOM.BillConsignment = new Consignment();
                    billDOM.AgentDetails = new Agent();

                    billDOM.ConsignmentId = GetIntegerFromDataReader(reader, "CG_ID");
                    billDOM.BillDate = GetDateFromReader(reader, "CG_DATE");
                    billDOM.BillConsignment.FkAgentId = GetIntegerFromDataReader(reader, "FK_AGENT_ID");
                    billDOM.BillConsignment.CgNoOfPass = GetIntegerFromDataReader(reader, "CG_NOOFPASS");
                    billDOM.AgentDetails.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
                    billDOM.AgentDetails.AgentAddress = GetStringFromDataReader(reader, "AGENT_ADDRESS");
                    billDOM.Version = GetIntegerFromDataReader(reader, "Versioning");
                    billDOM.BillId = GetIntegerFromDataReader(reader, "BILL_ID");
                    billDOM.TotalAmount = GetDecimalFromDataReader(reader, "TotalAmt");
                    billDOM.BillType = GetStringFromDataReader(reader, "BILL_TYPE");
                    billDOM.PaxDetails.CountryName = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    billDOM.BillConsignment.CgCorporate = GetStringFromDataReader(reader, "CG_CORPORATE");
                    billDOM.Paxs = GetStringFromDataReader(reader, "PAXS");
                    ////billDOM.PaxDetails.VisaTypeTwoId = GetIntegerFromDataReader(reader, "VISA_TYPE_TWO_ID");

                    lstBill.Add(billDOM);
                }

            }
            return lstBill;
        }
        #endregion

        #region Read Reciept By ConsignmentNo for print Recipt

        public List<Bill> ReadReceiptBYConsignment(int consignmentNo, int? LocId)
        {
            List<Bill> lstBill = new List<Bill>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_RECEITPBY_CONSIGNMENTID);
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            myDataBase.AddInParameter(dbCommand, "@Consignment", DbType.Int32, consignmentNo);
            if (LocId == 0)
            {
                using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
                    while (reader.Read())
                    {
                        Bill bill = new Bill();

                        bill.BillConsignment = new Consignment();
                        bill.AgentDetails = new Agent();
                        bill.BillId = GetIntegerFromDataReader(reader, "RCPT_ID");
                        bill.TotalAmount = GetDecimalFromDataReader(reader, "RCPT_AMOUNT");
                        bill.BillDate = GetDateFromReader(reader, "RCPT_DATE");
                        bill.BillType = GetStringFromDataReader(reader, "RCPT_TYPE");
                        bill.BillType = GetStringFromDataReader(reader, "MyDocType");
                        bill.BillConsignment.CG_ID = GetStringFromDataReader(reader, "FK_CG_ID");
                        bill.AgentDetails.AgentName = GetStringFromDataReader(reader, "TALLY_ACNAME");
                        lstBill.Add(bill);
                    }
                return lstBill;
            }
            else
            {
                using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
                    while (reader.Read())
                    {
                        Bill bill = new Bill();
                        bill.BillConsignment = new Consignment();
                        bill.AgentDetails = new Agent();
                        bill.BillId = GetIntegerFromDataReader(reader, "RCPT_ID");
                        bill.TotalAmount = GetDecimalFromDataReader(reader, "RCPT_AMOUNT");
                        bill.BillDate = GetDateFromReader(reader, "RCPT_DATE");
                        bill.BillType = GetStringFromDataReader(reader, "RCPT_TYPE");
                        bill.BillType = GetStringFromDataReader(reader, "MyDocType");
                        bill.BillConsignment.CG_ID = GetStringFromDataReader(reader, "FK_CG_ID");
                        bill.AgentDetails.AgentName = GetStringFromDataReader(reader, "TALLY_ACNAME");
                        lstBill.Add(bill);
                    }
                return lstBill;
            }
        }
        #endregion


        #region Read Reciept By AgentName for print Recipt

        public List<Bill> ReadReceiptBYAgentName(string agentName, int? LocId)
        {
            List<Bill> lstBill = new List<Bill>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_RECEITPBY_AGENTNAME);
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            myDataBase.AddInParameter(dbCommand, "@AgentName", DbType.String, agentName);
            if (LocId == 0)
            {
                using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
                    while (reader.Read())
                    {
                        Bill bill = new Bill();

                        bill.BillConsignment = new Consignment();
                        bill.AgentDetails = new Agent();
                        bill.BillId = GetIntegerFromDataReader(reader, "RCPT_ID");
                        bill.TotalAmount = GetDecimalFromDataReader(reader, "RCPT_AMOUNT");
                        bill.BillDate = GetDateFromReader(reader, "RCPT_DATE");
                        bill.BillType = GetStringFromDataReader(reader, "RCPT_TYPE");
                        bill.BillType = GetStringFromDataReader(reader, "MyDocType");
                        bill.BillConsignment.CG_ID = GetStringFromDataReader(reader, "FK_CG_ID");
                        bill.AgentDetails.AgentName = GetStringFromDataReader(reader, "TALLY_ACNAME");
                        lstBill.Add(bill);
                    }
                return lstBill;
            }
            else
            {
                using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
                    while (reader.Read())
                    {
                        Bill bill = new Bill();
                        bill.BillConsignment = new Consignment();
                        bill.AgentDetails = new Agent();
                        bill.BillId = GetIntegerFromDataReader(reader, "RCPT_ID");
                        bill.TotalAmount = GetDecimalFromDataReader(reader, "RCPT_AMOUNT");
                        bill.BillDate = GetDateFromReader(reader, "RCPT_DATE");
                        bill.BillType = GetStringFromDataReader(reader, "RCPT_TYPE");
                        bill.BillType = GetStringFromDataReader(reader, "MyDocType");
                        bill.BillConsignment.CG_ID = GetStringFromDataReader(reader, "FK_CG_ID");
                        bill.AgentDetails.AgentName = GetStringFromDataReader(reader, "TALLY_ACNAME");
                        lstBill.Add(bill);
                    }
                return lstBill;
            }
        }
        #endregion
        #region Read Consignment By AgentName for print Invoice

        public List<Bill> ReadConsignmentDetailsByAgentName(string agentName, int? LocId)
        {
            List<Bill> lstBill = new List<Bill>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_CONSIGNMENTBY_CONSIGNMENTAGENTNAME);
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            myDataBase.AddInParameter(dbCommand, "@AGENT_NAME", DbType.String, agentName);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Bill billDOM = new Bill();
                    billDOM.PaxDetails = new Pax();
                    billDOM.BillConsignment = new Consignment();
                    billDOM.AgentDetails = new Agent();
                    billDOM.ConsignmentId = GetIntegerFromDataReader(reader, "CG_ID");
                    billDOM.BillId = GetIntegerFromDataReader(reader, "BILL_ID");
                    billDOM.TotalAmount = GetDecimalFromDataReader(reader, "TotalAmt");
                    billDOM.BillType = GetStringFromDataReader(reader, "BILL_TYPE");
                    billDOM.BillDate = GetDateFromReader(reader, "CG_DATE");
                     billDOM.BillConsignment.CgDate = GetDateFromReader(reader, "CG_DATE");
                  //  billDOM.Version = GetIntegerFromDataReader(reader, "Versioning");
                    billDOM.BillConsignment.FkAgentId = GetIntegerFromDataReader(reader, "FK_AGENT_ID");
                    billDOM.BillConsignment.CgNoOfPass = GetIntegerFromDataReader(reader, "CG_NOOFPASS");
                    billDOM.AgentDetails.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
                    billDOM.AgentDetails.AgentAddress = GetStringFromDataReader(reader, "AGENT_ADDRESS");
                    billDOM.PaxDetails.CountryName = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    billDOM.BillConsignment.CgCorporate = GetStringFromDataReader(reader, "CG_CORPORATE");
                    billDOM.Paxs = GetStringFromDataReader(reader, "PAXS");
                    lstBill.Add(billDOM);
                }

            }
            return lstBill;
        }


        public List<Bill> ReadConsignmentDetailsByAgentNameAndDate(string agentName, DateTime FromDate, DateTime ToDate)
        {
            List<Bill> lstBill = new List<Bill>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_CONSIGNMENTBY_CONSIGNMENTAGENTNAME_DATE);
            myDataBase.AddInParameter(dbCommand, "@AGENT_NAME", DbType.String, agentName);
            myDataBase.AddInParameter(dbCommand, "@fromDate", DbType.String, FromDate);
            myDataBase.AddInParameter(dbCommand, "@toDate", DbType.String, ToDate);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Bill billDOM = new Bill();
                    billDOM.PaxDetails = new Pax();
                    billDOM.BillConsignment = new Consignment();
                    billDOM.AgentDetails = new Agent();
                    billDOM.ConsignmentId = GetIntegerFromDataReader(reader, "CG_ID");
                    billDOM.BillId = GetIntegerFromDataReader(reader, "BILL_ID");
                    billDOM.TotalAmount = GetDecimalFromDataReader(reader, "TotalAmt");
                    billDOM.BillType = GetStringFromDataReader(reader, "BILL_TYPE");
                    billDOM.BillDate = GetDateFromReader(reader, "CG_DATE");
                    billDOM.BillConsignment.CgDate = GetDateFromReader(reader, "CG_DATE");
                    //  billDOM.Version = GetIntegerFromDataReader(reader, "Versioning");
                    billDOM.BillConsignment.FkAgentId = GetIntegerFromDataReader(reader, "FK_AGENT_ID");
                    billDOM.BillConsignment.CgNoOfPass = GetIntegerFromDataReader(reader, "CG_NOOFPASS");
                    billDOM.AgentDetails.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
                    billDOM.AgentDetails.AgentAddress = GetStringFromDataReader(reader, "AGENT_ADDRESS");
                    billDOM.PaxDetails.CountryName = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    billDOM.BillConsignment.CgCorporate = GetStringFromDataReader(reader, "CG_CORPORATE");
                    billDOM.Paxs = GetStringFromDataReader(reader, "PAXS");
                    lstBill.Add(billDOM);
                }

            }
            return lstBill;
        }








        public List<Bill> ReadCountCGIDBill(int CgId)
        {
            List<Bill> lstBill = new List<Bill>();
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("select count(fk_cg_id) as count from Bill where fk_cg_id='" + CgId + "'");

            myDataBase.AddInParameter(dbCommand, "@FK_CG_ID", DbType.Int32, CgId);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Bill billDOM = new Bill();
                    billDOM.count = GetIntegerFromDataReader(reader, "count");
                    lstBill.Add(billDOM);
                }
            }
            return lstBill;
        }

        public List<BillItem> ReadBillIDBill(int billid, int id)
        {

            List<BillItem> lst = new List<BillItem>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_BILLDETAILSBY_ID);
            if (billid != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@billId", DbType.Int32, billid);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@billId", DbType.Int32, DBNull.Value);
            }
            if (id != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@id", DbType.Int32, id);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@id", DbType.Int32, DBNull.Value);
            }
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    BillItem billItemDOM = new BillItem();
                    billItemDOM.BillItemId = GetIntegerFromDataReader(reader, "id");
                    lst.Add(billItemDOM);
                }
            }
            return lst;
        }
        #endregion

        #region Read Invoice No By ConsignmentId for print Invoice

        public List<Bill> ReadMaxBillIdForPrint()
        {
            List<Bill> lstBill = new List<Bill>();
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("select MAX(bill_id) as BillId  from BILL");
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

                while (reader.Read())
                {
                    Bill billDOM = new Bill();
                    billDOM.BillId = GetIntegerFromDataReader(reader, "BillId");
                    lstBill.Add(billDOM);
                }
            return lstBill;

        }

        #endregion

        #region Read Bill Id By Consignment Id

        public List<Bill> ReadBillIdByConsignmentId(int id, string VisaType)
        {
            List<Bill> lstBill = new List<Bill>();
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("select bill_id as BillId from BILL where FK_CG_ID='" + id + "'   and bill_type='" + VisaType + "'");
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

                while (reader.Read())
                {
                    Bill billDOM = new Bill();
                    billDOM.BillId = GetIntegerFromDataReader(reader, "BillId");
                   // billDOM.Version = GetIntegerFromDataReader(reader, "Versioning");
                    lstBill.Add(billDOM);
                }
            return lstBill;
        }


        public List<Bill> ReadConsignmentByIdAdvanceSearch(int consignmentId, int? locationId)
        {
            List<Bill> lstBill = new List<Bill>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_CONSIGNMENTBY_CONSIGNMENTID_ADVANCE_SEARCH);
            if (locationId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, locationId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            myDataBase.AddInParameter(dbCommand, "@CG_ID", DbType.Int32, consignmentId);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Bill billDOM = new Bill();

                    billDOM.PaxDetails = new Pax();
                    billDOM.BillConsignment = new Consignment();
                    billDOM.AgentDetails = new Agent();

                    billDOM.ConsignmentId = GetIntegerFromDataReader(reader, "CG_ID");
                    billDOM.BillConsignment.CgDate = GetDateFromReader(reader, "CG_DATE");
                    billDOM.BillConsignment.FkAgentId = GetIntegerFromDataReader(reader, "FK_AGENT_ID");
                    billDOM.BillConsignment.CgNoOfPass = GetIntegerFromDataReader(reader, "CG_NOOFPASS");
                    billDOM.AgentDetails.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
                    billDOM.AgentDetails.AgentAddress = GetStringFromDataReader(reader, "AGENT_ADDRESS");
                    ////billDOM.PaxDetails.CountryId = GetIntegerFromDataReader(reader, "COUNTRY_ID");
                    ////billDOM.PaxDetails.VisaTypeOneId = GetIntegerFromDataReader(reader, "VISA_TYPE_ONE_ID");
                    ////billDOM.PaxDetails.VisaTypeTwoId = GetIntegerFromDataReader(reader, "VISA_TYPE_TWO_ID");

                    lstBill.Add(billDOM);
                }

            }
            return lstBill;
        }
        #endregion

        #region Login SuperAdmin

        public int LoginWithSuperAdmin(string UserName, string Password)
        {
            int RtValues = 0;
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.SUPERADMINLOGIN);

            myDataBase.AddInParameter(dbCommand, "@in_UserName", DbType.String, UserName);

            myDataBase.AddInParameter(dbCommand, "@in_Password", DbType.String, Password);

            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    RtValues = GetIntegerFromDataReader(reader, "Count");
                }
            }
            return RtValues;
        }
        #endregion

    }
}
