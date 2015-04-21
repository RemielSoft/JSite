using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DataAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Remielsoft.JetSave.BusinessAccessLayer
{
    public class ApplicationUserBusinessAccess:BaseBusinessAccess
    {
        private Database myDataBase;
        private ApplicationUserDataAccess applicationUserDataAccess; 
        public ApplicationUserBusinessAccess()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            applicationUserDataAccess = new ApplicationUserDataAccess(myDataBase);
        }

        public List<ApplicationUser> ReadUsres()
        {
            return applicationUserDataAccess.ReadUsers();
        }
    }
}
