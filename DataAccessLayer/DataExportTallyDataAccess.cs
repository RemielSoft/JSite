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
    public class DataExportTallyDataAccess:BaseDataAccess
    {                
        private Database myDatabase;

        public DataExportTallyDataAccess(Database m_database)
        {
            myDatabase = m_database;
        }        

        public List<DataExportTally> ReadExportData(DateTime FromDate, DateTime ToDate,int? LocId)
        {
            List<DataExportTally> lstDataTally = new List<DataExportTally>();
            int j = 0;
            DbCommand dbCommand1 = myDatabase.GetStoredProcCommand(DBConstant.READ_BILL_FOR_TALLY);
            if (LocId != 0)
            {
                myDatabase.AddInParameter(dbCommand1, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDatabase.AddInParameter(dbCommand1, "@LocationId", DbType.Int32, DBNull.Value);
            }
            myDatabase.AddInParameter(dbCommand1, "@FromDate", DbType.DateTime, FromDate);
            myDatabase.AddInParameter(dbCommand1, "@ToDate", DbType.DateTime, ToDate);
            using (IDataReader reader = myDatabase.ExecuteReader(dbCommand1))
            {
                int i = 0;
                while (reader.Read())
                {
                    DataExportTally dataExport = new DataExportTally();
                    dataExport.agent = new Agent();
                    dataExport.bill = new Bill();
                    dataExport.consingment = new Consignment();
                    dataExport.consingment.pax = new Pax();

                    i = i + 1;
                    dataExport.SrNo = i;
                    dataExport.bill.BillId = GetIntegerFromDataReader(reader, "BILL_ID");
                    dataExport.bill.BillDate = GetDateFromReader(reader, "BILL_DATE");
                    dataExport.agent.AgentId = GetIntegerFromDataReader(reader, "Agent_Id");
                    dataExport.agent.TallyAcName = GetStringFromDataReader(reader, "TALLY_ACNAME");
                    dataExport.bill.ServiceCharge = GetDecimalFromDataReader(reader, "ServiceCharge");
                    dataExport.bill.ServiceTax = GetDecimalFromDataReader(reader, "ServiceTax");
                    dataExport.bill.TotalAmount = GetDecimalFromDataReader(reader, "TotalAmt");
                    dataExport.consingment.CgNoOfPass = GetIntegerFromDataReader(reader, "CG_NOOFPASS");
                    dataExport.consingment.ConsignmentId = GetIntegerFromDataReader(reader, "CG_ID");
                    dataExport.consingment.pax.PaxName = GetStringFromDataReader(reader, "PAXS");
                    dataExport.isReciptData = false;

                    lstDataTally.Add(dataExport);                  
                }
                j = i;
            }

            DbCommand dbCommand = myDatabase.GetStoredProcCommand(DBConstant.READ_RECEIPT_FOR_TALLY);
            if (LocId != 0)
            {
                myDatabase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDatabase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            myDatabase.AddInParameter(dbCommand, "@FromDate", DbType.DateTime, FromDate);
            myDatabase.AddInParameter(dbCommand, "@ToDate", DbType.DateTime, ToDate);
            using (IDataReader reader = myDatabase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    DataExportTally dataExport = new DataExportTally();
                    dataExport.agent = new Agent();
                    dataExport.receipt = new Receipt();
                    dataExport.bill = new Bill();
                    dataExport.consingment = new Consignment();

                    j = j + 1;
                    dataExport.SrNo = j;
                    dataExport.receipt.RcptNo = GetIntegerFromDataReader(reader, "RCPT_ID");
                    dataExport.receipt.RcptType = GetStringFromDataReader(reader, "RCPT_TYPE");
                    dataExport.receipt.RcptDate = GetDateFromReader(reader, "RCPT_DATE");
                    dataExport.receipt.RcptAmount = GetDecimalFromDataReader(reader, "RCPT_AMOUNT");
                    dataExport.agent.AgentId = GetIntegerFromDataReader(reader, "FK_AGENT_ID");
                    dataExport.agent.TallyAcName = GetStringFromDataReader(reader, "TALLY_ACNAME");
                    dataExport.receipt.CreditAccount=GetStringFromDataReader(reader,"ACCOUNT");
                    dataExport.receipt.Remarks=GetStringFromDataReader(reader,"REMARKS");
                    dataExport.isReciptData = true;

                    lstDataTally.Add(dataExport);
                }
            }            
            return lstDataTally;
        }        
    }
}
