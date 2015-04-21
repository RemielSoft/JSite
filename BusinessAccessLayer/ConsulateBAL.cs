using Microsoft.Practices.EnterpriseLibrary.Data;
using Remielsoft.JetSave.DataAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.BusinessAccessLayer
{
    public class ConsulateBAL : BaseBusinessAccess
    {
          private Database myDataBase;
        private ConsulateDAL conDal;
        public ConsulateBAL()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            conDal = new ConsulateDAL(myDataBase);
        }
       
        public List<Consulate> ReadConsulate()
        {
            List<Consulate> lstCon = new List<Consulate>();
            lstCon = conDal.ReadConsulate();
            return lstCon;
        }
    }
}
