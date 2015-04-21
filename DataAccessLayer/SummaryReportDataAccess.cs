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
    public class SummaryReportDataAccess:BaseDataAccess
    {
        private Database MyDataBase;

        public SummaryReportDataAccess(Database M_database)
        {
            MyDataBase = M_database;
        }
        public List<Agent> BindAgent(int? LocId ,int? agentId)
        {
            List<Agent> llst = new List<Agent>();
            DbCommand dbCommand = MyDataBase.GetStoredProcCommand(DBConstant.LIST_AGENT);
            if(LocId!=0)
            {
                MyDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                MyDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }

            if (agentId != 0)
            {
                MyDataBase.AddInParameter(dbCommand, "@AgentId", DbType.Int32, agentId);
            }

            else
            {
                MyDataBase.AddInParameter(dbCommand, "@AgentId", DbType.Int32, DBNull.Value);
            }
           
            using (IDataReader reader = MyDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Agent agent = new Agent();
                    agent.AgentId = GetIntegerFromDataReader(reader, "AGENT_ID");
                    agent.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
                    llst.Add(agent);
                }
            }

            return llst;
        }
        public List<summaryReport> ReadSummaryReport(DateTime Fromdate, DateTime todate, int AgentIds,int? LocId)
        {
            List<summaryReport> lst = new List<summaryReport>();
            DbCommand dbCommand = MyDataBase.GetStoredProcCommand(DBConstant.READ_SUMMARYREPORT);
            if (LocId != 0)
            {
                MyDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                MyDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            MyDataBase.AddInParameter(dbCommand, "@in_from_date", DbType.DateTime, Fromdate);
            MyDataBase.AddInParameter(dbCommand, "@in_to_date", DbType.DateTime, todate);
            MyDataBase.AddInParameter(dbCommand, "@in_agent_Id", DbType.Int32, AgentIds);
            using (IDataReader ireader = MyDataBase.ExecuteReader(dbCommand))
            {
                while (ireader.Read())
                {
                    summaryReport summaryReport = new summaryReport();
                    summaryReport.PartyName = GetStringFromDataReader(ireader, "Agent_Name");
                    summaryReport.Country = GetStringFromDataReader(ireader, "Country_Name");
                    summaryReport.NumberOfPassport = GetIntegerFromDataReader(ireader, "No_of_Passport");
                    summaryReport.PaxName = GetStringFromDataReader(ireader, "Pax_Name");
                    summaryReport.PassportNumber = GetStringFromDataReader(ireader, "Passport_No");
                    summaryReport.Remarks = GetStringFromDataReader(ireader, "Remarks");
                    lst.Add(summaryReport);
                }
            }
            return lst;
        }


    }
}
