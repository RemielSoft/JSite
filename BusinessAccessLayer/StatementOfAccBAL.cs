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
   public  class StatementOfAccBAL:BaseBusinessAccess
    {
       private Database myDataBase;
        private StatementOfAccDAL stmtOfAccDal;
        public StatementOfAccBAL()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            stmtOfAccDal = new StatementOfAccDAL(myDataBase);
        }
        public List<StatementOfAccDom> ReadStatementofAccById(int agentId,DateTime fromDate,DateTime toDate,int? LocId)
        {
            return stmtOfAccDal.ReadStatementofAccById(agentId, fromDate, toDate,LocId);
        }
        public List<StatementOfAccDom> ReadAgentName( )
        {
            return stmtOfAccDal.ReadAgentName();
        }
        public List<StatementOfAccDom> ReadAgentAddress(int agentId)
        {
            return stmtOfAccDal.ReadAgentAddress(agentId);
        }
    }
}
