using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace Remielsoft.JetSave.DataAccessLayer
{
    public class ReceiptGenerationDataAccess:BaseDataAccess
    { 
        private Database myDataBase;

        public ReceiptGenerationDataAccess(Database m_Database)
        {
            myDataBase = m_Database;
        }

        public int InsertReceipt(Receipt receipt,int LocId)
        {
            receipt.rcptDetails = new ReceiptDetails();
            int receiptId;
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.CREATE_RECEIPT);            
            myDataBase.AddInParameter(dbCommand, "@FK_AGENT_ID", DbType.Int32, receipt.agent.AgentId);
            myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            myDataBase.AddInParameter(dbCommand, "@RCPT_DATE", DbType.DateTime, receipt.RcptDate);
            myDataBase.AddInParameter(dbCommand, "@RCPT_TYPE", DbType.String, receipt.PaymentMode);
            myDataBase.AddInParameter(dbCommand, "@RCPT_NATURE", DbType.String, receipt.RcptType);
            myDataBase.AddInParameter(dbCommand, "@RCPT_AMOUNT", DbType.Decimal, receipt.RcptAmount);
            myDataBase.AddInParameter(dbCommand, "@ACCOUNT", DbType.String, receipt.CreditAccount);
            myDataBase.AddInParameter(dbCommand, "@RCPT_CHQ_NO", DbType.String, receipt.ChequeNo);
            myDataBase.AddInParameter(dbCommand, "@ISSUING_BANK", DbType.String, receipt.IssuingBank);
            myDataBase.AddInParameter(dbCommand, "@ISSUE_DATE", DbType.DateTime, receipt.IssuingDate);
            myDataBase.AddInParameter(dbCommand, "@ADV_ADJ", DbType.Decimal, receipt.rcptDetails.AdjustedAmount);
            myDataBase.AddInParameter(dbCommand, "@REMARKS", DbType.String, receipt.Remarks);            

            myDataBase.AddOutParameter(dbCommand, "@out_ReceiptId", DbType.Int32, 20);
            myDataBase.ExecuteNonQuery(dbCommand);
            int.TryParse(myDataBase.GetParameterValue(dbCommand, "@out_ReceiptId").ToString(), out receiptId);

            return receiptId;
        }


        #region Adjustment Invoice Amount.......

        public List<Receipt> AdjustmentAmount(int agentId)
        {
            List<Receipt> lst = new List<Receipt>();
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("SELECT  RCPT_ID, (RCPT_AMOUNT - isnull(ADV_ADJ,0)) AS ADVANCEAMT, CONVERT(varchar(10),RCPT_ID)+'('+CONVERT(varchar(20),(RCPT_AMOUNT-ADV_ADJ))+')' As RecieptIdAmount FROM RECIEPT  WHERE ((RCPT_AMOUNT - isnull(ADV_ADJ,0)) > 0)   AND (FK_AGENT_ID = '"+agentId+"') AND (RCPT_NATURE = '  Advance')");
          
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Receipt reCiept = new Receipt();
                    reCiept.RcptNo = GetIntegerFromDataReader(reader, "RCPT_ID");
                    reCiept.AdvAdj = GetDecimalFromDataReader(reader, "ADVANCEAMT");
                    reCiept.RcptNoAdvAdj = GetStringFromDataReader(reader, "RecieptIdAmount");
                    lst.Add(reCiept);
                }
            }
            return lst;
        }

        public List<ReceiptDetails> ReadTotalAdjustedAmount(Int64 RcptNo)
        {
            List<ReceiptDetails> lstRcpt = new List<ReceiptDetails>();
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("SELECT SUM(ADJ_AMOUNT) AS AMOUNT_ADJUSTED From RECIEPT_DETAIL GROUP BY FK_RCPT_ID Having (FK_RCPT_ID = '"+RcptNo+"')");
            
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    ReceiptDetails rcptDetails = new ReceiptDetails();
                    rcptDetails.AdjustedAmount = GetDecimalFromDataReader(reader, "AMOUNT_ADJUSTED");

                    lstRcpt.Add(rcptDetails);
                }
            }
            return lstRcpt;
        }

        public void UpdateAdjustedReciept(Receipt receipt, Int64 reciptId)
        {
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("UPDATE RECIEPT SET ADV_ADJ ='"+receipt.AdvAdj+"' where  RCPT_ID ='"+reciptId+"'");
            myDataBase.AddInParameter(dbCommand, "@ADV_ADJ", DbType.Decimal, receipt.AdvAdj);
            myDataBase.ExecuteNonQuery(dbCommand);
        }

        #endregion


        public List<Receipt> ReadOutstandingAmount(Int32 AgentId)
        {
            List<Receipt> lstCrAmt = new List<Receipt>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_CREDIT_AMOUNT);
            myDataBase.AddInParameter(dbCommand, "@AgentId", DbType.Int32, AgentId);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Receipt receipt = new Receipt();
                    receipt.agent=new Agent();
                    receipt.TotalCreditAmount = GetDecimalFromDataReader(reader, "CrAmount");                    
                    lstCrAmt.Add(receipt);                    
                }
                if (lstCrAmt.Count == 0)
                {
                    Receipt receipt = new Receipt();
                    receipt.TotalCreditAmount = 0;
                    lstCrAmt.Add(receipt);
                }
            }

            List<Receipt> lstDrAmt = new List<Receipt>();
            dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_DEBIT_AMOUNT);
            myDataBase.AddInParameter(dbCommand, "@AgentId", DbType.Int32, AgentId); 
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Receipt receipt = new Receipt();
                    receipt.agent = new Agent();
                    receipt.TotalDebitAmount = GetDecimalFromDataReader(reader, "DrAmount");
                    lstDrAmt.Add(receipt);
                }
                if (lstDrAmt.Count == 0)
                {
                    Receipt receipt = new Receipt();
                    receipt.TotalDebitAmount = 0;
                    lstDrAmt.Add(receipt);
                }
            }
            List<Receipt> lst=new List<Receipt>();
            Receipt receipt1 = new Receipt();
            receipt1.OutstandingAmount = Convert.ToDecimal(lstCrAmt[0].TotalCreditAmount - lstDrAmt[0].TotalDebitAmount);
            lst.Add(receipt1);
            return lst;
        }

        public List<Agent> ReadAgentAddress(Int32 AgentId)
        {
            List<Agent> lst = new List<Agent>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_AGENT_ADDRESS);
            myDataBase.AddInParameter(dbCommand, "@AgentId", DbType.Int32, AgentId);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Agent agent = new Agent();
                    agent.AgentAddress = GetStringFromDataReader(reader, "AGENT_ADDRESS");
                    agent.AgentLocationId = GetIntegerFromDataReader(reader, "LocationId");
                    lst.Add(agent);
                }
            }
            return lst;
        }

        public List<Receipt> BindInvoiceNo(Int32 AgentId, int? LocId)
        {
            List<Receipt> lst = new List<Receipt>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_INVOICE_DETAIL);
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            myDataBase.AddInParameter(dbCommand, "@AgentId", DbType.Int32, AgentId); 
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Receipt receipt = new Receipt();                                       
                    receipt.agent = new Agent();
                    receipt.InvoiceNo = GetIntegerFromDataReader(reader, "InvoiceId");
                    receipt.agent.AgentName = GetStringFromDataReader(reader, "AgentName");                    
                    lst.Add(receipt);
                }
            }
            return lst;
        }

        public List<ReceiptDetails> ReadReceiptDetail(Int32 InvoiceId,int? LocId)
        {
            List<ReceiptDetails> lst = new List<ReceiptDetails>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_RECEIPT_DETAIL);
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            myDataBase.AddInParameter(dbCommand, "@InvoiceId", DbType.Int32, InvoiceId);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    ReceiptDetails receiptDetails = new ReceiptDetails();
                    receiptDetails.InvoiceNo = GetIntegerFromDataReader(reader, "InvoiceId");
                    receiptDetails.InvoiceDate = GetDateFromReader(reader, "InvoiceDate");
                    receiptDetails.InvoiceAmount = GetDecimalFromDataReader(reader, "InvoiceAmount");
                    receiptDetails.AdjustedAmount = GetDecimalFromDataReader(reader, "InvoiceAmount");
                    receiptDetails.LocationId = GetIntegerFromDataReader(reader, "LocationId");
                    lst.Add(receiptDetails);
                }
            }
            return lst;
        }

        public void InsertReceiptDetail(ReceiptDetails receiptDetail)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.CREATE_RECEIPT_DETAIL);
            myDataBase.AddInParameter(dbCommand, "@FK_RCPT_ID", DbType.Int32, receiptDetail.FkRcptId);
            myDataBase.AddInParameter(dbCommand, "@INVOICE_NO", DbType.Int32, receiptDetail.InvoiceNo);
            myDataBase.AddInParameter(dbCommand, "@INV_TOT_AMOUNT", DbType.Decimal, receiptDetail.InvoiceAmount);
            myDataBase.AddInParameter(dbCommand, "@ADJ_AMOUNT", DbType.Decimal, receiptDetail.AdjustedAmount);
            myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, receiptDetail.LocationId);
            
            myDataBase.ExecuteNonQuery(dbCommand);            
        }

        public void InsertReceiptDetail1(ReceiptDetails receiptDetail)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.CREATE_RECEIPT_DETAIL);
            myDataBase.AddInParameter(dbCommand, "@FK_RCPT_ID", DbType.Int32, receiptDetail.FkRcptId);
            myDataBase.AddInParameter(dbCommand, "@INVOICE_NO", DbType.Int32, receiptDetail.InvoiceNo);
            myDataBase.AddInParameter(dbCommand, "@INV_TOT_AMOUNT", DbType.Decimal, receiptDetail.InvoiceAmount);
            myDataBase.AddInParameter(dbCommand, "@ADJ_AMOUNT", DbType.Decimal, receiptDetail.AdjustedAmount);
            myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, receiptDetail.LocationId);

            myDataBase.ExecuteNonQuery(dbCommand);
        }

        public List<Receipt> ReadReceitpAll(Int32 RcptNo, int? LocId)
        {
            List<Receipt> lstRcpt = new List<Receipt>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_ALL_RECEIPT_DETAIL);
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            myDataBase.AddInParameter(dbCommand, "@RcptNo", DbType.Int32, RcptNo);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Receipt receipt = new Receipt();
                    receipt.agent = new Agent();

                    receipt.RcptNo = GetIntegerFromDataReader(reader, "RCPT_ID");
                    receipt.RcptDate = GetDateFromReader(reader, "RCPT_DATE");
                    receipt.agent.AgentId = GetIntegerFromDataReader(reader, "AGENT_ID");
                    receipt.agent.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
                    receipt.agent.AgentAddress = GetStringFromDataReader(reader, "AgentAddress");
                    receipt.agent.AgentEmail = GetStringFromDataReader(reader, "AGENT_EMAIL");
                    receipt.RcptType = GetStringFromDataReader(reader, "RCPT_NATURE");
                    receipt.PaymentMode = GetStringFromDataReader(reader, "RCPT_TYPE");
                    receipt.CreditAccount = GetStringFromDataReader(reader, "ACCOUNT");
                    receipt.RcptAmount = GetDecimalFromDataReader(reader, "RCPT_AMOUNT");
                    receipt.ChequeNo = GetStringFromDataReader(reader, "RCPT_CHQ_NO");
                    receipt.IssuingBank = GetStringFromDataReader(reader, "ISSUING_BANK");
                    receipt.IssuingDate = GetDateFromReader(reader, "ISSUE_DATE");
                    receipt.AdvAdj = GetDecimalFromDataReader(reader, "ADV_ADJ");
                    receipt.Remarks = GetStringFromDataReader(reader, "remarks");

                    lstRcpt.Add(receipt);
                }
            }
            return lstRcpt;
        }

        public List<ReceiptDetails> ReadReceitpDetailsByRcptNo(Int32 RcptNo)
        {
            List<ReceiptDetails> lstRcptDetails = new List<ReceiptDetails>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_RECEIPT_DETAIL_BY_RCPT_NO);
            myDataBase.AddInParameter(dbCommand, "@RcptNo", DbType.Int32, RcptNo);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    ReceiptDetails rcptDetails = new ReceiptDetails();
                                        
                    rcptDetails.InvoiceNo = GetIntegerFromDataReader(reader, "INVOICE_NO");
                    rcptDetails.InvoiceDate = GetDateFromReader(reader, "BILL_DATE");
                    rcptDetails.InvoiceAmount = GetDecimalFromDataReader(reader, "INV_TOT_AMOUNT");
                    rcptDetails.AdjustedAmount = GetDecimalFromDataReader(reader, "ADJ_AMOUNT");

                    lstRcptDetails.Add(rcptDetails);
                }
            }
            return lstRcptDetails;
        }

        public void UpdateReceipt(Receipt receipt)
        {                        
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_RECEIPT);
            myDataBase.AddInParameter(dbCommand, "@RCPT_ID", DbType.Int32, receipt.RcptNo);
            myDataBase.AddInParameter(dbCommand, "@FK_AGENT_ID", DbType.Int32, receipt.agent.AgentId);
            myDataBase.AddInParameter(dbCommand, "@RCPT_DATE", DbType.DateTime, receipt.RcptDate);
            myDataBase.AddInParameter(dbCommand, "@RCPT_TYPE", DbType.String, receipt.PaymentMode);
            myDataBase.AddInParameter(dbCommand, "@RCPT_NATURE", DbType.String, receipt.RcptType);
            myDataBase.AddInParameter(dbCommand, "@RCPT_AMOUNT", DbType.Decimal, receipt.RcptAmount);
            myDataBase.AddInParameter(dbCommand, "@ACCOUNT", DbType.String, receipt.CreditAccount);
            myDataBase.AddInParameter(dbCommand, "@RCPT_CHQ_NO", DbType.String, receipt.ChequeNo);
            myDataBase.AddInParameter(dbCommand, "@ISSUING_BANK", DbType.String, receipt.IssuingBank);
            myDataBase.AddInParameter(dbCommand, "@ISSUE_DATE", DbType.DateTime, receipt.IssuingDate);
            myDataBase.AddInParameter(dbCommand, "@ADV_ADJ", DbType.Decimal,0);
            myDataBase.AddInParameter(dbCommand, "@REMARKS", DbType.String, receipt.Remarks);
            myDataBase.ExecuteNonQuery(dbCommand);
        }

        public void DeleteReceipt(Int32 RcptId)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.DELETE_RECEIPT);
            myDataBase.AddInParameter(dbCommand, "@RcptNo", DbType.Int32, RcptId);
            myDataBase.ExecuteNonQuery(dbCommand);

            //DbCommand dbCommand1 = myDataBase.GetSqlStringCommand("UPDATE RECIEPT_DETAIL SET IsDeleted =" + 1 + " WHERE FK_RCPT_ID=" + RcptId + "");
            //myDataBase.ExecuteNonQuery(dbCommand1);
        }
    }
}
