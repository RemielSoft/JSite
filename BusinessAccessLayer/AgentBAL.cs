using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Remielsoft.JetSave.DataAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Remielsoft.JetSave.BusinessAccessLayer
{
    public class AgentBAL : BaseBusinessAccess
    {
        private Database myDataBase;
        private AgentDAL addAgentDal;
        public AgentBAL()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            addAgentDal = new AgentDAL(myDataBase);
        }


        public void UpdateAgentStatusById(int id,string status)
        {
            addAgentDal.UpdateAgentStatusById(id, status);
        }
        public Boolean InsertAgentDetail(Agent ad)
        {
            return addAgentDal.insertagentdetail(ad);
            
        }

        #region AgentInfo Read..
        public List<Agent> ReadAgentInfo(int? id, string city)
        {
            return addAgentDal.ReadAgentInfo(id, city);
        }
       #endregion

        #region AgentInfo Update
        public void AgentInfoUpdate(int Id, Agent agentmasterUpdate)
        {
            addAgentDal.UpdateAgentInfo(Id, agentmasterUpdate);
        }
        #endregion


        public int ValidateAgent(string agentUserName,string agentpassword)
        {
            Int32 agentId= 0;
            try
            {
                agentId = addAgentDal.ValidateAgent(agentUserName, agentpassword);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
          
            return agentId;

        }
        public List<Agent> ReadUsers(String name, int? LocId,int agentId)
        {
            List<Agent> adlst = new List<Agent>();
            adlst = addAgentDal.ReadUsers(name, LocId, agentId);
            return adlst;
        }
        public List<Agent> ReadAgent(int? id)
        {
            List<Agent> adlst = new List<Agent>();
            adlst = addAgentDal.ReadAgent(id);
            return adlst;
        }


        ///////////////////////////////////////
        public List<Agent> ReadUsersStatus(String name,  String status)
        {
            List<Agent> adlst = new List<Agent>();
            adlst = addAgentDal.ReadUsersByEnable(name, status);
            return adlst;
        }

        
        ////////////////////////////////////////
        
        public void DeleteAgent(int AGENT_ID)
        {
            addAgentDal.Delete(AGENT_ID);
        }
        public List<Agent> updaterecord(int AGENT_ID, Agent ad)
        {
            return addAgentDal.Updaterecord(AGENT_ID, ad);
        }
        public List<Agent> ReadAgentList(int? LocId)
        {
            List<Agent> lstAgent = new List<Agent>();
            lstAgent = addAgentDal.ReadAgentList(LocId);
           return lstAgent;

        }
        public List<Agent> GridbindEmail(string city)
        {
            List<Agent> lst = new List<Agent>();
            lst = addAgentDal.Gridbind(city);
            return lst;
        }
        public Agent ReadAgentById(string agentId)
        {
            Agent agent = addAgentDal.ReadAgentById(agentId);
            return agent;
        }
    }
}
