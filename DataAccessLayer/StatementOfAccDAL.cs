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
    public class StatementOfAccDAL:BaseDataAccess
    {
        Decimal openingBalance = 0;
         private Database myDataBase;
         public StatementOfAccDAL(Database m_database)
        {
            myDataBase = m_database;
        }

         public List<StatementOfAccDom> ReadStatementofAccById(int agentId, DateTime fromDate, DateTime toDate, int? LocId)
         {
             
             List<StatementOfAccDom> lststmtdom = new List<StatementOfAccDom>();
             DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.READ_STATEMENTOFACCOUNT);
             if (LocId != 0)
             {
                 myDataBase.AddInParameter(dbcommand, "@LocationId", DbType.Int32, LocId);
             }
             else
             {
                 myDataBase.AddInParameter(dbcommand, "@LocationId", DbType.Int32, DBNull.Value);
             }
             myDataBase.AddInParameter(dbcommand, "@agentId", DbType.Int32, agentId);
             myDataBase.AddInParameter(dbcommand, "@in_from_date", DbType.DateTime, fromDate);
             myDataBase.AddInParameter(dbcommand, "@in_to_date", DbType.DateTime, toDate);
             using(IDataReader reader=myDataBase.ExecuteReader(dbcommand))
             {
                while(reader.Read())
                {
                    StatementOfAccDom stmtOfAccDom = new StatementOfAccDom();
                    stmtOfAccDom.Narration = GetStringFromDataReader(reader, "Narration");
                    stmtOfAccDom.Particular = GetStringFromDataReader(reader, "Particular");
                    stmtOfAccDom.DocDate = GetStringFromDataReader(reader, "DocDate");
                    stmtOfAccDom.CrAmount = GetDecimalFromDataReader(reader, "CrAmount");
                    stmtOfAccDom.DrAmount = GetDecimalFromDataReader(reader, "DrAmount");
                    //stmtOfAccDom.TotalAmmount = GetDecimalFromDataReader(reader, "totamount");
                    stmtOfAccDom.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
                    stmtOfAccDom.AgentAddress = GetStringFromDataReader(reader, "AGENT_ADDRESS");
                    stmtOfAccDom.InvoiceType = GetStringFromDataReader(reader, "Type");
                    stmtOfAccDom.BalanceOpening = GetDecimalFromDataReader(reader, "Opening");
                    stmtOfAccDom.AgentId = GetIntegerFromDataReader(reader, "AGENT_ID");
                    stmtOfAccDom.FromDate = GetDateFromReader(reader, "FromDate");
                    stmtOfAccDom.ToDate = GetDateFromReader(reader, "Todate");
                    lststmtdom.Add(stmtOfAccDom);
                    openingBalance = stmtOfAccDom.BalanceOpening;                    
                }
                 
             }
             return lststmtdom;

         }

         public List<StatementOfAccDom> ReadAgentName()
         {
             
             List<StatementOfAccDom> lstAgentName = new List<StatementOfAccDom>();
             DbCommand dbcommand = myDataBase.GetSqlStringCommand("select * from AGENT order by AGENT_NAME asc");
             using (IDataReader reader = myDataBase.ExecuteReader(dbcommand))
             {

                 while (reader.Read())
                 {
                     StatementOfAccDom stmtOfAcc = new StatementOfAccDom();
                     stmtOfAcc.AgentId = GetIntegerFromDataReader(reader, "AGENT_ID");
                     stmtOfAcc.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
                     stmtOfAcc.AgentAddress = GetStringFromDataReader(reader, "AGENT_ADDRESS");
                     //stmtOfAcc.AgentAddress = GetStringFromDataReader(reader, "AGENT_ADDRESS");
                     lstAgentName.Add(stmtOfAcc);
                 }
             }
             return lstAgentName;

         }
         public List<StatementOfAccDom> ReadAgentAddress(int agentId)
         {

             List<StatementOfAccDom> lstAgentAddress = new List<StatementOfAccDom>();
             DbCommand dbcommand = myDataBase.GetSqlStringCommand("select AGENT_ADDRESS,AGENT_ID,OPENING_BALANCE from AGENT where AGENT_ID='" + agentId + "'");
             using (IDataReader reader = myDataBase.ExecuteReader(dbcommand))
             {

                 while (reader.Read())
                 {
                     StatementOfAccDom stmtOfAcc = new StatementOfAccDom();
                     stmtOfAcc.AgentId = GetIntegerFromDataReader(reader, "AGENT_ID");
                     stmtOfAcc.AgentAddress = GetStringFromDataReader(reader, "AGENT_ADDRESS");
                     stmtOfAcc.BalanceOpening =GetDecimalFromDataReader (reader, "OPENING_BALANCE");
                     lstAgentAddress.Add(stmtOfAcc);
                 }
             }
             return lstAgentAddress;
         }
    }
}
