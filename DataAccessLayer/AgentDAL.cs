using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DataAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace Remielsoft.JetSave.DataAccessLayer
{
    public class AgentDAL : BaseDataAccess
    {
        private Database myDataBase;

        public AgentDAL(Database m_database)
        {
            myDataBase = m_database;
        }

        public Boolean insertagentdetail(Agent addAgentDom)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.CREATE_AGENT);
            myDataBase.AddInParameter(dbCommand, "@AGENT_COUNTRYID", DbType.Int32, addAgentDom.AgentCountryId);
            myDataBase.AddInParameter(dbCommand, "@AGENT_STATEID", DbType.Int32, addAgentDom.AgentStateId);
            myDataBase.AddInParameter(dbCommand, "@AGENT_CITYID", DbType.Int32, addAgentDom.AgentCityId);
            myDataBase.AddInParameter(dbCommand, "@AGENT_USERNAME", DbType.String, addAgentDom.AgentUserName);
            myDataBase.AddInParameter(dbCommand, "@AGENT_PASSWORD", DbType.String, addAgentDom.AgentPassword);
            myDataBase.AddInParameter(dbCommand, "@AGENT_CPERSON", DbType.String, addAgentDom.AgentCPerson);
            myDataBase.AddInParameter(dbCommand, "@AGENT_NAME", DbType.String, addAgentDom.AgentName);
            myDataBase.AddInParameter(dbCommand, "@AGENT_ADDRESS", DbType.String, addAgentDom.AgentAddress);
            myDataBase.AddInParameter(dbCommand, "@AGENT_CITY", DbType.String, addAgentDom.AgentCity);
            myDataBase.AddInParameter(dbCommand, "@AGENT_PIN", DbType.String, addAgentDom.AgentPin);
            myDataBase.AddInParameter(dbCommand, "@AGENT_EMAIL", DbType.String, addAgentDom.AgentEmail);
            myDataBase.AddInParameter(dbCommand, "@AGENT_PHONE", DbType.String, addAgentDom.AgentPhone);
            myDataBase.AddInParameter(dbCommand, "@AGENT_FAX", DbType.String, addAgentDom.AgentFax);
            myDataBase.AddInParameter(dbCommand, "@AGENT_ENABLE", DbType.String, addAgentDom.AgentEnable);
            myDataBase.AddInParameter(dbCommand, "@AGENT_PRORITY", DbType.Int32, addAgentDom.AgentPrority);
            myDataBase.AddInParameter(dbCommand, "@AGENT_SCHARGE", DbType.Decimal, addAgentDom.AgentSCharge);
            myDataBase.AddInParameter(dbCommand, "@AGENT_CCHARGE", DbType.Decimal, addAgentDom.AgentCCharge);
            myDataBase.AddInParameter(dbCommand, "@TALLY_ACNAME", DbType.String, addAgentDom.TallyAcName);
            myDataBase.AddInParameter(dbCommand, "@AGENT_DDCHARGE", DbType.Decimal, addAgentDom.AgentDDCharge);
            myDataBase.AddInParameter(dbCommand, "@OPENING_BALANCE", DbType.Decimal, addAgentDom.OpeningBalance);
            myDataBase.AddInParameter(dbCommand, "@CreateBy", DbType.String, addAgentDom.Created_By);
            myDataBase.ExecuteNonQuery(dbCommand);
            return true;
        }
        public List<Agent> ReadUsers(String name, int? LocId, int agentId)
        {
            List<Agent> adlst = new List<Agent>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_AGENT_RECORD);
            if (!string.IsNullOrEmpty(name))
            {
                myDataBase.AddInParameter(dbCommand, "@AGENT_NAME", DbType.String, name);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@AGENT_NAME", DbType.String, DBNull.Value);
            }
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }

            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }

            if (agentId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@agent_id", DbType.Int32, agentId);
            }

            else
            {
                myDataBase.AddInParameter(dbCommand, "@agent_id", DbType.Int32, DBNull.Value);
            }
            // myDataBase.AddInParameter(dbCommand, "@AGENT_NAME", DbType.String, name);

            Agent addAgentDom = new Agent();
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    addAgentDom = GeneraterecordFromDataReader(reader);
                    adlst.Add(addAgentDom);
                }

                return adlst;
            }
        }
        public List<Agent> ReadAgent(int? agentId)
        {
            List<Agent> adlst = new List<Agent>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_AGENT);
            if (agentId != null)
            {
                myDataBase.AddInParameter(dbCommand, "@inAgentId", DbType.Int32, agentId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@inAgentId", DbType.Int32, DBNull.Value);
            }
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Agent agent = new Agent();
                    agent.AgentId = Convert.ToInt32(reader["AGENT_ID"]);
                    agent.AgentName = Convert.ToString(reader["AGENT_NAME"]);
                    adlst.Add(agent);
                }

                return adlst;
            }

        }

        /////////////////////////////////////////////////////////////////////////////

        public List<Agent> ReadUsersByEnable(String name, String Status)
        {
            List<Agent> adlst = new List<Agent>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_AGENT_RECORD_BY_STATUS);
            if (!string.IsNullOrEmpty(name))
            {
                myDataBase.AddInParameter(dbCommand, "@AGENT_NAME", DbType.String, name);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@AGENT_NAME", DbType.String, DBNull.Value);
            }





            if (!string.IsNullOrEmpty(Status))
            {
                myDataBase.AddInParameter(dbCommand, "@AGENT_ENABLE", DbType.String, Status);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@AGENT_ENABLE", DbType.String, DBNull.Value);
            }

            Agent addAgentDom = new Agent();
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    addAgentDom = GeneraterecordFromDataReader(reader);
                    adlst.Add(addAgentDom);
                }

                return adlst;
            }
        }


        /// ////////////////////////////////////////////////////////////////////////////



        private Agent GeneraterecordFromDataReader(IDataReader reader)
        {
            Agent addAgentDom = new Agent();
            addAgentDom.AgentId = GetIntegerFromDataReader(reader, "AGENT_ID");
            addAgentDom.AgentLocationId = GetIntegerFromDataReader(reader, "LocationId");
            addAgentDom.AgentUserName = GetStringFromDataReader(reader, "AGENT_USERNAME");
            addAgentDom.AgentPassword = GetStringFromDataReader(reader, "AGENT_PASSWORD");
            addAgentDom.AgentCPerson = GetStringFromDataReader(reader, "AGENT_CPERSON");
            addAgentDom.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
            addAgentDom.AgentAddress = GetStringFromDataReader(reader, "AGENT_ADDRESS");
            addAgentDom.AgentCity = GetStringFromDataReader(reader, "AGENT_CITY");
            addAgentDom.AgentPin = GetStringFromDataReader(reader, "AGENT_PIN");
            addAgentDom.AgentEmail = GetStringFromDataReader(reader, "AGENT_EMAIL");
            addAgentDom.AgentPhone = GetStringFromDataReader(reader, "AGENT_PHONE");
            addAgentDom.AgentFax = GetStringFromDataReader(reader, "AGENT_FAX");
            addAgentDom.AgentEnable = GetStringFromDataReader(reader, "AGENT_ENABLE");
            addAgentDom.AgentPrority = GetIntegerFromDataReader(reader, "AGENT_PRORITY");
            addAgentDom.AgentSCharge = GetDecimalFromDataReader(reader, "AGENT_SCHARGE");
            addAgentDom.AgentCCharge = GetDecimalFromDataReader(reader, "AGENT_CCHARGE");
            addAgentDom.TallyAcName = GetStringFromDataReader(reader, "TALLY_ACNAME");
            addAgentDom.AgentDDCharge = GetDecimalFromDataReader(reader, "AGENT_DDCHARGE");
            addAgentDom.OpeningBalance = GetDecimalFromDataReader(reader, "OPENING_BALANCE");
            return addAgentDom;

        }
        public void Delete(int agentId)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.DELETE_AGENT);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@AGENT_ID", DbType.Int32, agentId);
            myDataBase.ExecuteNonQuery(dbCommand);
        }
        public List<Agent> Updaterecord(int AGENT_ID, Agent addAgentDom)
        {
            List<Agent> lst = new List<Agent>();

            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_AGENT);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@AGENT_ID", DbType.Int32, AGENT_ID);
            myDataBase.AddInParameter(dbCommand, "@AGENT_USERNAME", DbType.String, addAgentDom.AgentUserName);
            myDataBase.AddInParameter(dbCommand, "@AGENT_PASSWORD", DbType.String, addAgentDom.AgentPassword);
            myDataBase.AddInParameter(dbCommand, "@AGENT_CPERSON", DbType.String, addAgentDom.AgentCPerson);
            myDataBase.AddInParameter(dbCommand, "@AGENT_NAME", DbType.String, addAgentDom.AgentName);
            myDataBase.AddInParameter(dbCommand, "@AGENT_ADDRESS", DbType.String, addAgentDom.AgentAddress);
            myDataBase.AddInParameter(dbCommand, "@AGENT_CITY", DbType.String, addAgentDom.AgentCity);
            myDataBase.AddInParameter(dbCommand, "@AGENT_PIN", DbType.String, addAgentDom.AgentPin);
            myDataBase.AddInParameter(dbCommand, "@AGENT_EMAIL", DbType.String, addAgentDom.AgentEmail);
            myDataBase.AddInParameter(dbCommand, "@AGENT_PHONE", DbType.String, addAgentDom.AgentPhone);
            myDataBase.AddInParameter(dbCommand, "@AGENT_FAX", DbType.String, addAgentDom.AgentFax);
            myDataBase.AddInParameter(dbCommand, "@AGENT_ENABLE", DbType.String, addAgentDom.AgentEnable);
            myDataBase.AddInParameter(dbCommand, "@AGENT_PRORITY", DbType.String, addAgentDom.AgentPrority);
            myDataBase.AddInParameter(dbCommand, "@AGENT_SCHARGE", DbType.String, addAgentDom.AgentSCharge);
            myDataBase.AddInParameter(dbCommand, "@AGENT_CCHARGE", DbType.String, addAgentDom.AgentCCharge);
            myDataBase.AddInParameter(dbCommand, "@TALLY_ACNAME", DbType.String, addAgentDom.TallyAcName);
            myDataBase.AddInParameter(dbCommand, "@AGENT_DDCHARGE", DbType.String, addAgentDom.AgentDDCharge);
            myDataBase.AddInParameter(dbCommand, "@OPENING_BALANCE", DbType.String, addAgentDom.OpeningBalance);
            myDataBase.ExecuteNonQuery(dbCommand);
            lst.Add(addAgentDom);
            return lst;
        }
        public List<Agent> ReadAgentList(int? LocId)
        {
            List<Agent> lstAgent = new List<Agent>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.LIST_AGENT);
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }

            IDataReader reader = myDataBase.ExecuteReader(dbCommand);
            {
                while (reader.Read())
                {
                    Agent addAgentDom = new Agent();


                    addAgentDom.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
                    addAgentDom.AgentAddress = GetStringFromDataReader(reader, "AGENT_ADDRESS");
                    addAgentDom.AgentCity = GetStringFromDataReader(reader, "AGENT_CITY");
                    addAgentDom.AgentPin = GetStringFromDataReader(reader, "AGENT_PIN");
                    addAgentDom.AgentPhone = GetStringFromDataReader(reader, "AGENT_PHONE");
                    addAgentDom.AgentUserName = GetStringFromDataReader(reader, "AGENT_USERNAME");
                    lstAgent.Add(addAgentDom);
                }
                return lstAgent;
            }
        }
        public List<Agent> Gridbind(string city)
        {
            List<Agent> lst = new List<Agent>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.SELECT_AGENTEMAIL_LIST);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@city", DbType.String, city);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
                while (reader.Read())
                {
                    Agent addAgentDom = new Agent();
                    addAgentDom.AgentId = GetIntegerFromDataReader(reader, "AGENT_ID");
                    addAgentDom.AgentCPerson = GetStringFromDataReader(reader, "AGENT_CPERSON");
                    addAgentDom.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
                    addAgentDom.AgentAddress = GetStringFromDataReader(reader, "AGENT_ADDRESS");
                    addAgentDom.AgentCity = GetStringFromDataReader(reader, "AGENT_CITY");
                    addAgentDom.AgentPin = GetStringFromDataReader(reader, "AGENT_PIN");
                    addAgentDom.AgentEmail = GetStringFromDataReader(reader, "AGENT_EMAIL");
                    addAgentDom.AgentPhone = GetStringFromDataReader(reader, "AGENT_PHONE");
                    addAgentDom.AgentFax = GetStringFromDataReader(reader, "AGENT_FAX");
                    lst.Add(addAgentDom);
                }
            return lst;
        }

        public int ValidateAgent(string agentUserName, string agentPassword)
        {
            int agentId;

            String sqlCommand = DBConstant.VALIDATE_AGENT_MASTER;
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(sqlCommand);

            myDataBase.AddInParameter(dbCommand, "@in_AgentuserName", DbType.String, agentUserName);
            myDataBase.AddInParameter(dbCommand, "@in_Password", DbType.String, agentPassword);
            myDataBase.AddOutParameter(dbCommand, "@out_AgentId", DbType.Int32, 10);
            myDataBase.ExecuteNonQuery(dbCommand);
            int.TryParse(myDataBase.GetParameterValue(dbCommand, "@out_AgentId").ToString(), out agentId);

            return agentId;
        }

        #region AgentInfo Read..
        public List<Agent> ReadAgentInfo(int? id, string city)
        {
            List<Agent> lstagent = new List<Agent>();
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.READ_AGENTINFO);
            myDataBase.AddInParameter(dbcommand, "@in_Agent_Id", DbType.Int32, id);
            if (city == null)
            {
                myDataBase.AddInParameter(dbcommand, "@inAgentCity", DbType.String, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbcommand, "@inAgentCity", DbType.String, city);
            }


            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    Agent agent = new Agent();
                    agent.AgentId = GetIntegerFromDataReader(reader1, "AgentId");
                    agent.AgentCityId = GetIntegerFromDataReader(reader1, "cityId");
                    agent.AgentCityName = GetStringFromDataReader(reader1, "cityName");
                    agent.AgentCountryId = GetIntegerFromDataReader(reader1, "countryId");
                    agent.AgentCountryName = GetStringFromDataReader(reader1, "countryName");
                    agent.AgentStateId = GetIntegerFromDataReader(reader1, "stateId");
                    agent.AgentStateName = GetStringFromDataReader(reader1, "stateName");
                    agent.AgentName = GetStringFromDataReader(reader1, "AgentName");
                    agent.AgentUserName = GetStringFromDataReader(reader1, "AgentUserName");
                    agent.AgentCPerson = GetStringFromDataReader(reader1, "AgentCPerson");
                    agent.AgentAddress = GetStringFromDataReader(reader1, "AgentAddress");
                    agent.AgentCity = GetStringFromDataReader(reader1, "AgentCity");
                    agent.AgentPassword = GetStringFromDataReader(reader1, "AgentPassword");
                    agent.AgentPin = GetStringFromDataReader(reader1, "AgentPin");
                    agent.AgentEmail = GetStringFromDataReader(reader1, "AgentEmail");
                    agent.AgentPhone = GetStringFromDataReader(reader1, "AgentPhone");
                    agent.AgentFax = GetStringFromDataReader(reader1, "AgentFax");
                    agent.AgentEnable = GetStringFromDataReader(reader1, "AgentEnable");
                    agent.AgentPrority = GetIntegerFromDataReader(reader1, "AgentPrority");
                    agent.AgentSCharge = GetDecimalFromDataReader(reader1, "AgentSCharge");
                    agent.AgentCCharge = GetDecimalFromDataReader(reader1, "AgentCCharge");
                    agent.TallyAcName = GetStringFromDataReader(reader1, "TallyAcName");
                    agent.AgentDDCharge = GetDecimalFromDataReader(reader1, "AgentDDCharge");
                    agent.OpeningBalance = GetDecimalFromDataReader(reader1, "OpeningBalance");



                    lstagent.Add(agent);
                }
            }
            return lstagent;
        }
        #endregion

        #region AgentInfo Update
        public void UpdateAgentInfo(int Id, Agent agentmasterupdate)
        {

            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_AGENTINFO);
            dbcommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbcommand, "@in_AgentId", DbType.Int32, Id);
            myDataBase.AddInParameter(dbcommand, "@in_AgentCountryId", DbType.Int32, agentmasterupdate.AgentCountryId);
            myDataBase.AddInParameter(dbcommand, "@in_AgentCityId", DbType.Int32, agentmasterupdate.AgentCityId);
            myDataBase.AddInParameter(dbcommand, "@in_AgentStateId", DbType.Int32, agentmasterupdate.AgentStateId);
            myDataBase.AddInParameter(dbcommand, "@in_AgentUserName", DbType.String, agentmasterupdate.AgentUserName);
            myDataBase.AddInParameter(dbcommand, "@in_AgentPassword", DbType.String, agentmasterupdate.AgentPassword);
            myDataBase.AddInParameter(dbcommand, "@in_AgentCPerson", DbType.String, agentmasterupdate.AgentCPerson);
            myDataBase.AddInParameter(dbcommand, "@in_AgentName", DbType.String, agentmasterupdate.AgentName);
            myDataBase.AddInParameter(dbcommand, "@in_AgentAddress", DbType.String, agentmasterupdate.AgentAddress);
            myDataBase.AddInParameter(dbcommand, "@in_AgentCity", DbType.String, agentmasterupdate.AgentCity);
            myDataBase.AddInParameter(dbcommand, "@in_AgentPin", DbType.String, agentmasterupdate.AgentPin);
            myDataBase.AddInParameter(dbcommand, "@in_AgentEmail", DbType.String, agentmasterupdate.AgentEmail);
            myDataBase.AddInParameter(dbcommand, "@in_AgentPhone", DbType.String, agentmasterupdate.AgentPhone);
            myDataBase.AddInParameter(dbcommand, "@in_AgentFax", DbType.String, agentmasterupdate.AgentFax);
            myDataBase.AddInParameter(dbcommand, "@in_AgentEnable", DbType.String, agentmasterupdate.AgentEnable);
            myDataBase.AddInParameter(dbcommand, "@in_AgentPriority", DbType.String, agentmasterupdate.AgentPrority);
            myDataBase.AddInParameter(dbcommand, "@in_AgentSCharge", DbType.Decimal, agentmasterupdate.AgentSCharge);
            myDataBase.AddInParameter(dbcommand, "@in_AgentCCharge", DbType.Decimal, agentmasterupdate.AgentCCharge);
            myDataBase.AddInParameter(dbcommand, "@in_TallyAcName", DbType.String, agentmasterupdate.TallyAcName);
            myDataBase.AddInParameter(dbcommand, "@in_AgentDCharge", DbType.Decimal, agentmasterupdate.AgentDDCharge);
            myDataBase.AddInParameter(dbcommand, "@in_AgentOpeningBalance", DbType.Decimal, agentmasterupdate.OpeningBalance);
            myDataBase.AddInParameter(dbcommand, "@in_ModifiedBy", DbType.String, agentmasterupdate.Modified_By);
            myDataBase.AddInParameter(dbcommand, "@in_ModifiedDate", DbType.DateTime, agentmasterupdate.Modified_Date);
            myDataBase.ExecuteNonQuery(dbcommand);

        }
        #endregion

        public Agent ReadAgentById(string agentId)
        {
            Agent agentDom = new Agent();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_AGENT_USER);
            if (agentId != null)
            {
                myDataBase.AddInParameter(dbCommand, "@AGENT_USERNAME", DbType.String, agentId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@AGENT_USERNAME", DbType.String, DBNull.Value);
            }

            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    agentDom = GeneraterecordFromDataReader(reader);
                }

                return agentDom;
            }
        }






        public void UpdateAgentStatusById(int id, string status)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_AGENT_STATUSBY_ID);
            myDataBase.AddInParameter(dbCommand, "@in_AgentId", DbType.Int32, id);
            myDataBase.AddInParameter(dbCommand, "@in_Status", DbType.String, status);
            myDataBase.ExecuteNonQuery(dbCommand);

        }
    }
}
