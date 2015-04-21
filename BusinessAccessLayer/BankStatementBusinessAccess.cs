using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DataAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Remielsoft.JetSave.BusinessAccessLayer
{
    public class BankStatementBusinessAccess:BaseBusinessAccess
    {
          private Database myDataBase;
        private BankStatementDataAccess bankstatementDataAccess;
       
        public BankStatementBusinessAccess()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            bankstatementDataAccess = new BankStatementDataAccess(myDataBase);
           
        }
        public List<BankStatement> readBankstatement(DateTime fromDate,DateTime toDate,string bankName,int? LocId )
        {
            List<BankStatement> lst = new List<BankStatement>();
            lst = bankstatementDataAccess.readdBankSatetment(fromDate, toDate, bankName, LocId);

            return lst;

        }
        public List<BankStatement> readAllBank(DateTime fromDate,DateTime toDate,int? LocId)
        {
            List<BankStatement> lst = new List<BankStatement>();
            lst = bankstatementDataAccess.readBankall(fromDate, toDate, LocId);

            return lst;


    }
}
}
