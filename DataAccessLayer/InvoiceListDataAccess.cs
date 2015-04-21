using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace Remielsoft.JetSave.DataAccessLayer
{
  public  class InvoiceListDataAccess:BaseDataAccess
    {
       private Database myDataBase;

       public InvoiceListDataAccess(Database m_database)
        {
            myDataBase = m_database;
        }

       public List<Bill> ReadDataByInvoiceConsignmentId(int consignmentId, int? LocId)
       {
           List<Bill> lstBill = new List<Bill>();

           DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_BILLBY_BILLCONSIGNMENTID);
           if (LocId != 0)
           {
               myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
           }
           else
           {
               myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
           }
           myDataBase.AddInParameter(dbCommand, "@FK_CG_ID", DbType.Int32, consignmentId);
           using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

               while (reader.Read())
               {   
                   Bill bill = new Bill();
                   bill.BillConsignment = new Consignment();
                   bill.AgentDetails = new Agent();
                   bill.BillId = GetIntegerFromDataReader(reader, "BILL_ID");
                   bill.ServiceCharge = GetDecimalFromDataReader(reader, "ServiceCharge");
                   bill.ServiceTax = GetDecimalFromDataReader(reader, "ServiceTax");
                //   bill.Version = GetIntegerFromDataReader(reader, "Versioning");
                   bill.BillDate = GetDateFromReader(reader, "BILLDATE");
                   bill.BillType = GetStringFromDataReader(reader, "BILL_TYPE");
                   bill.TotalAmount = GetDecimalFromDataReader(reader, "TotalAmt");
                    bill.ConsignmentId = GetIntegerFromDataReader(reader, "FK_CG_ID");
                   bill.BillType = GetStringFromDataReader(reader, "MyDocType");
                   bill.AgentDetails.AgentName = GetStringFromDataReader(reader, "TALLY_ACNAME");
                   bill.AgentDetails.AgentAddress = GetStringFromDataReader(reader, "AGENT_ADDRESS");
                   bill.AgentDetails.AgentPhone = GetStringFromDataReader(reader, "AGENT_PHONE");
                   bill.BillConsignment.CgDate = GetDateFromReader(reader, "CG_DATE");
                   bill.BillConsignment.CgCorporate = GetStringFromDataReader(reader, "CG_CORPORATE");
                   bill.Paxs = GetStringFromDataReader(reader, "PAXS");
                   lstBill.Add(bill);
               }
           return lstBill;
       }

       public List<Bill> ReadDataByInvoiceBillId(int billId, int? LocId)
       {
           List<Bill> lstBill = new List<Bill>();

           DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_BILLBY_BILLID);
           if (LocId != 0)
           {
               myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
           }
           else
           {
               myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
           }
           myDataBase.AddInParameter(dbCommand, "@BILL_ID", DbType.Int32, billId);
           using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

               while (reader.Read())
               {
                   Bill bill = new Bill();
                   bill.BillConsignment = new Consignment();
                   bill.PaxDetails = new Pax();
                   bill.AgentDetails = new Agent();
                   bill.BillId = GetIntegerFromDataReader(reader, "BILL_ID");
                   bill.ServiceCharge = GetDecimalFromDataReader(reader, "ServiceCharge");
                   bill.ServiceTax = GetDecimalFromDataReader(reader, "ServiceTax");
                 //  bill.Version = GetIntegerFromDataReader(reader, "Versioning");
                   bill.AgentDetails.AgentId = GetIntegerFromDataReader(reader, "AGENT_ID");
                   bill.BillDate = GetDateFromReader(reader, "BILLDATE");
                   bill.BillType = GetStringFromDataReader(reader, "BILL_TYPE");
                   bill.TotalAmount = GetDecimalFromDataReader(reader, "TotalAmt");
                   bill.ConsignmentId = GetIntegerFromDataReader(reader, "FK_CG_ID");
                   bill.BillType = GetStringFromDataReader(reader, "MyDocType");
                   bill.AgentDetails.AgentName = GetStringFromDataReader(reader, "TALLY_ACNAME");
                   bill.AgentDetails.AgentAddress = GetStringFromDataReader(reader, "AGENT_ADDRESS");
                   bill.AgentDetails.AgentPhone = GetStringFromDataReader(reader, "AGENT_PHONE");
                   bill.BillConsignment.CgCorporate = GetStringFromDataReader(reader, "CG_CORPORATE");
                   bill.PaxDetails.CountryName = GetStringFromDataReader(reader, "COUNTRY_NAME");
                   bill.BillConsignment.CgNoOfPass = GetIntegerFromDataReader(reader, "CG_NOOFPASS");
                   bill.Paxs = GetStringFromDataReader(reader, "PAXS");
                   lstBill.Add(bill);
               }
           return lstBill;
       }

       public List<Bill> ReadDataByInvoiceDates(DateTime fromDate, DateTime toDate, int? LocId)
       {
           List<Bill> lstBill = new List<Bill>();

           DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_BILLBY_BILLDATE);
           //if (LocId != 0)
           //{
           //    myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
           //}
           //else
           //{
           //    myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
           //}
           myDataBase.AddInParameter(dbCommand, "@in_from_date", DbType.DateTime, fromDate);
           myDataBase.AddInParameter(dbCommand, "@in_to_date", DbType.DateTime, toDate);
           using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

               while (reader.Read())
               {
                   Bill bill = new Bill();
                   bill.PaxDetails = new Pax();
                   bill.BillConsignment = new Consignment();
                   bill.AgentDetails = new Agent();
                   bill.BillId = GetIntegerFromDataReader(reader, "BILL_ID");
                   bill.ServiceCharge = GetDecimalFromDataReader(reader, "ServiceCharge");
                   bill.ServiceTax = GetDecimalFromDataReader(reader, "ServiceTax");
                //   bill.Version = GetIntegerFromDataReader(reader, "Versioning");
                   bill.TotalAmount = GetDecimalFromDataReader(reader, "TotalAmt");
                   bill.BillDate = GetDateFromReader(reader, "BILLDATE");
                   bill.BillType = GetStringFromDataReader(reader, "BILL_TYPE");
                 
                   bill.ConsignmentId = GetIntegerFromDataReader(reader, "FK_CG_ID");
                   bill.AgentDetails.AgentName = GetStringFromDataReader(reader, "TALLY_ACNAME");
                   bill.AgentDetails.AgentAddress = GetStringFromDataReader(reader, "AGENT_ADDRESS");
                   bill.AgentDetails.AgentPhone = GetStringFromDataReader(reader, "AGENT_PHONE");
                   bill.PaxDetails.CountryName = GetStringFromDataReader(reader, "COUNTRY_NAME");
                   bill.BillConsignment.CgNoOfPass = GetIntegerFromDataReader(reader, "CG_NOOFPASS");
                   bill.BillConsignment.CgCorporate = GetStringFromDataReader(reader, "CG_CORPORATE");
                   bill.Paxs = GetStringFromDataReader(reader, "PAXS");
                  
                   lstBill.Add(bill);
               }
           return lstBill;
       }

       public List<Bill> ReadDataByReceiptId(int receiptId, int? LocId)
       {
           List<Bill> lstBill = new List<Bill>();
           if (LocId == 0)
           {
               DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_ALL_RECEIPT_DETAIL);
               myDataBase.AddInParameter(dbCommand, "@RcptNo", DbType.Int32, receiptId);
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
               DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_ALL_RECEIPT_DETAIL);
               myDataBase.AddInParameter(dbCommand, "@RcptNo", DbType.Int32, receiptId);
               myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, receiptId);
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

       public List<Bill> ReadDataByReceiptDates(DateTime fromDate, DateTime toDate, int? LocId)
       {
           List<Bill> lstBill = new List<Bill>();
           if (LocId == 0)
           {
               DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_RECEIPT_BY_DATE);
               myDataBase.AddInParameter(dbCommand, "@in_FromDate", DbType.Date, fromDate);
               myDataBase.AddInParameter(dbCommand, "@in_ToDate", DbType.Date, toDate);
               using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

                   while (reader.Read())
                   {
                       Bill bill = new Bill();

                       bill.BillConsignment = new Consignment();
                       bill.AgentDetails = new Agent();
                       bill.BillId = GetIntegerFromDataReader(reader, "BILL_ID");
                       bill.TotalAmount = GetDecimalFromDataReader(reader, "TotalAmt");
                       bill.BillDate = GetDateFromReader(reader, "BILLDATE");
                       bill.BillType = GetStringFromDataReader(reader, "BILL_TYPE");
                       bill.BillType = GetStringFromDataReader(reader, "MyDocType");
                       bill.BillConsignment.CG_ID = GetStringFromDataReader(reader, "FK_CG_ID");
                       bill.AgentDetails.AgentName = GetStringFromDataReader(reader, "TALLY_ACNAME");
                       lstBill.Add(bill);
                   }
               return lstBill;
           }
           else
           {
               DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_RECEIPT_BY_DATE);
               myDataBase.AddInParameter(dbCommand, "@in_FromDate", DbType.Date, fromDate);
               myDataBase.AddInParameter(dbCommand, "@in_ToDate", DbType.Date, toDate);
               myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
               using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

                   while (reader.Read())
                   {
                       Bill bill = new Bill();

                       bill.BillConsignment = new Consignment();
                       bill.AgentDetails = new Agent();
                       bill.BillId = GetIntegerFromDataReader(reader, "BILL_ID");
                       bill.TotalAmount = GetDecimalFromDataReader(reader, "TotalAmt");
                       bill.BillDate = GetDateFromReader(reader, "BILLDATE");
                       bill.BillType = GetStringFromDataReader(reader, "BILL_TYPE");
                       bill.BillType = GetStringFromDataReader(reader, "MyDocType");
                       bill.BillConsignment.CG_ID = GetStringFromDataReader(reader, "FK_CG_ID");
                       bill.AgentDetails.AgentName = GetStringFromDataReader(reader, "TALLY_ACNAME");
                       lstBill.Add(bill);
                   }
               return lstBill;
           }
       }

    }
     
}
