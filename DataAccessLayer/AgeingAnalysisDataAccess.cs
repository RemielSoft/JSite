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
    public class AgeingAnalysisDataAccess : BaseDataAccess
    {
        String queryBill;
        String queryReceipt;
        private Database myDatabase;       
        public AgeingAnalysisDataAccess(Database m_Databse)
        {
            myDatabase = m_Databse;
        }

        public List<AgeingAnalysis> ReadAgeingAnalysis(DateTime StartDate, DateTime LastDate, Int32 AgentId, int? LocId)
        {
            if (AgentId == 0)
            {                
                if (LocId != 0)
                {
                    queryBill = "SELECT AGENT.AGENT_ID, AGENT.AGENT_NAME, ISNULL(SUM(BILL.NetTotalAmt),0) AS TOTAL_BILL FROM BILL INNER JOIN CONSIGNMENT ON BILL.FK_CG_ID=CONSIGNMENT.CG_ID INNER JOIN AGENT ON AGENT.AGENT_ID=CONSIGNMENT.FK_AGENT_ID WHERE (BILL.BILL_DATE BETWEEN '" + StartDate.ToShortDateString() + "' AND '" + LastDate.ToShortDateString() + "') AND (RECIEPT.LocationId=" + LocId + ") GROUP BY AGENT.AGENT_ID,AGENT.AGENT_NAME";
                }
                else
                {
                    queryBill = "SELECT AGENT.AGENT_ID, AGENT.AGENT_NAME, ISNULL(SUM(BILL.NetTotalAmt),0) AS TOTAL_BILL FROM BILL INNER JOIN CONSIGNMENT ON BILL.FK_CG_ID=CONSIGNMENT.CG_ID INNER JOIN AGENT ON AGENT.AGENT_ID=CONSIGNMENT.FK_AGENT_ID WHERE (BILL.BILL_DATE BETWEEN '" + StartDate.ToShortDateString() + "' AND '" + LastDate.ToShortDateString() + "') GROUP BY AGENT.AGENT_ID,AGENT.AGENT_NAME";
                }

                List<AgeingAnalysis> lst = new List<AgeingAnalysis>();
                DbCommand dbCommand = myDatabase.GetSqlStringCommand(queryBill);
                using (IDataReader reader = myDatabase.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        AgeingAnalysis ageingAnalysis = new AgeingAnalysis();
                        ageingAnalysis.AgentId = GetIntegerFromDataReader(reader, "AGENT_ID");
                        ageingAnalysis.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
                        ageingAnalysis.TotalBillAmt = GetDecimalFromDataReader(reader, "TOTAL_BILL");
                        ageingAnalysis.Balance = ageingAnalysis.TotalBillAmt;
                        lst.Add(ageingAnalysis);
                    }
                }                

                if (LocId != 0)
                {
                    queryReceipt = "SELECT AGENT.AGENT_ID,ISNULL(SUM(RECIEPT.RCPT_AMOUNT),0) AS UNALLOCATED_CREDIT FROM RECIEPT INNER JOIN AGENT ON RECIEPT.FK_AGENT_ID=AGENT.AGENT_ID WHERE (RECIEPT.RCPT_DATE BETWEEN '" + StartDate.ToShortDateString() + "' AND '" + LastDate.ToShortDateString() + "') AND (RECIEPT.LocationId=" + LocId + ")  AND (RECIEPT.IsDeleted=0) GROUP BY AGENT.AGENT_ID,AGENT.AGENT_NAME";
                }
                else
                {
                    queryReceipt = "SELECT AGENT.AGENT_ID,ISNULL(SUM(RECIEPT.RCPT_AMOUNT),0) AS UNALLOCATED_CREDIT FROM RECIEPT INNER JOIN AGENT ON RECIEPT.FK_AGENT_ID=AGENT.AGENT_ID WHERE (RECIEPT.RCPT_DATE BETWEEN '" + StartDate.ToShortDateString() + "' AND '" + LastDate.ToShortDateString() + "') AND (RECIEPT.IsDeleted=0) GROUP BY AGENT.AGENT_ID,AGENT.AGENT_NAME";
                }
                List<AgeingAnalysis> lst1 = new List<AgeingAnalysis>();
                DbCommand dbCommand1 = myDatabase.GetSqlStringCommand(queryReceipt);
                using (IDataReader reader = myDatabase.ExecuteReader(dbCommand1))
                {
                    while (reader.Read())
                    {
                        AgeingAnalysis ageingAnalysis = new AgeingAnalysis();
                        ageingAnalysis.AgentId = GetIntegerFromDataReader(reader, "AGENT_ID");
                        ageingAnalysis.ReceiptAmount = GetDecimalFromDataReader(reader, "UNALLOCATED_CREDIT");
                        lst1.Add(ageingAnalysis);
                    }
                }

                for (int i = 0; i < lst1.Count; i++)
                {
                    for (int j = 0; j < lst.Count; j++)
                    {
                        if (Convert.ToInt32(lst1[i].AgentId) == Convert.ToInt32(lst[j].AgentId))
                        {
                            lst[j].ReceiptAmount = Convert.ToDecimal(lst1[i].ReceiptAmount);
                            lst[j].Balance = lst[j].TotalBillAmt - lst[j].ReceiptAmount;
                            break;
                        }
                    }
                }
                return lst;
            }


            
            else
            {
                if (LocId != 0)
                {
                    queryBill = "SELECT AGENT.AGENT_ID, AGENT.AGENT_NAME, ISNULL(SUM(BILL.NetTotalAmt),0) AS TOTAL_BILL FROM BILL INNER JOIN CONSIGNMENT ON BILL.FK_CG_ID=CONSIGNMENT.CG_ID INNER JOIN AGENT ON AGENT.AGENT_ID=CONSIGNMENT.FK_AGENT_ID WHERE (BILL.BILL_DATE BETWEEN '" + StartDate.ToShortDateString() + "' AND '" + LastDate.ToShortDateString() + "') AND (AGENT.AGENT_ID=" + AgentId +") AND (RECIEPT.LocationId=" + LocId + ") GROUP BY AGENT.AGENT_ID,AGENT.AGENT_NAME";
                }
                else
                {
                    queryBill = "SELECT AGENT.AGENT_ID, AGENT.AGENT_NAME, ISNULL(SUM(BILL.NetTotalAmt),0) AS TOTAL_BILL FROM BILL INNER JOIN CONSIGNMENT ON BILL.FK_CG_ID=CONSIGNMENT.CG_ID INNER JOIN AGENT ON AGENT.AGENT_ID=CONSIGNMENT.FK_AGENT_ID WHERE (BILL.BILL_DATE BETWEEN '" + StartDate.ToShortDateString() + "' AND '" + LastDate.ToShortDateString() + "') AND (AGENT.AGENT_ID=" + AgentId + ") GROUP BY AGENT.AGENT_ID,AGENT.AGENT_NAME";
                }
                List<AgeingAnalysis> lst = new List<AgeingAnalysis>();
                DbCommand dbCommand = myDatabase.GetSqlStringCommand(queryBill);                
                using (IDataReader reader = myDatabase.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        AgeingAnalysis ageingAnalysis = new AgeingAnalysis();
                        ageingAnalysis.AgentId = GetIntegerFromDataReader(reader, "AGENT_ID");
                        ageingAnalysis.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
                        ageingAnalysis.TotalBillAmt = GetDecimalFromDataReader(reader, "TOTAL_BILL");
                        ageingAnalysis.Balance = ageingAnalysis.TotalBillAmt;
                        lst.Add(ageingAnalysis);
                    }
                }

                if (LocId != 0)
                {
                    queryReceipt = "SELECT AGENT.AGENT_ID,ISNULL(SUM(RECIEPT.RCPT_AMOUNT),0) AS UNALLOCATED_CREDIT FROM RECIEPT INNER JOIN AGENT ON RECIEPT.FK_AGENT_ID=AGENT.AGENT_ID WHERE (RECIEPT.RCPT_DATE BETWEEN '" + StartDate.ToShortDateString() + "' AND '" + LastDate.ToShortDateString() + "') AND (AGENT.AGENT_ID="+ AgentId +") AND (RECIEPT.LocationId=" + LocId + ")  AND (RECIEPT.IsDeleted=0) GROUP BY AGENT.AGENT_ID,AGENT.AGENT_NAME";
                }
                else
                {
                    queryReceipt = "SELECT AGENT.AGENT_ID,ISNULL(SUM(RECIEPT.RCPT_AMOUNT),0) AS UNALLOCATED_CREDIT FROM RECIEPT INNER JOIN AGENT ON RECIEPT.FK_AGENT_ID=AGENT.AGENT_ID WHERE (RECIEPT.RCPT_DATE BETWEEN '" + StartDate.ToShortDateString() + "' AND '" + LastDate.ToShortDateString() + "') AND (AGENT.AGENT_ID=" + AgentId + ")  AND (RECIEPT.IsDeleted=0) GROUP BY AGENT.AGENT_ID,AGENT.AGENT_NAME";
                }
                List<AgeingAnalysis> lst1 = new List<AgeingAnalysis>();
                DbCommand dbCommand1 = myDatabase.GetSqlStringCommand(queryReceipt);                
                using (IDataReader reader=myDatabase.ExecuteReader(dbCommand1))
                {
                    while (reader.Read())
                    {
                        AgeingAnalysis ageingAnalysis = new AgeingAnalysis();
                        ageingAnalysis.AgentId = GetIntegerFromDataReader(reader, "AGENT_ID");
                        ageingAnalysis.ReceiptAmount = GetDecimalFromDataReader(reader, "UNALLOCATED_CREDIT");                        
                        lst1.Add(ageingAnalysis);
                    }
                }

               
                for (int i = 0; i < lst1.Count; i++)
                {
                    for (int j = 0; j < lst.Count; j++)
                    {
                        if (Convert.ToInt32(lst1[i].AgentId) == Convert.ToInt32(lst[j].AgentId))
                        {
                            lst[j].ReceiptAmount = Convert.ToDecimal(lst1[i].ReceiptAmount);
                            lst[j].Balance = lst[j].TotalBillAmt - lst[j].ReceiptAmount;
                            break;
                        }
                    }
                }
                return lst;
            }
        }        
    }
}
