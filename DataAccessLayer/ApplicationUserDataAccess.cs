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
    public class ApplicationUserDataAccess : BaseDataAccess
    {
        private Database myDataBase;
        public ApplicationUserDataAccess(Database m_database)
        {
            myDataBase = m_database;
        }
        public List<ApplicationUser> ReadUsers()
        {

            List<ApplicationUser> lstAppusers = new List<ApplicationUser>();
            ApplicationUser aapUser = null;
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("Select * from Admin");
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                   lstAppusers.Add(GenerateApplicationUserFromDataReader(reader));
                    //lstAppusers.Add(aapUser);
                }
            }
            return lstAppusers;

        }

        private ApplicationUser GenerateApplicationUserFromDataReader(IDataReader reader)
        {
            ApplicationUser aapUser = new ApplicationUser();
            aapUser.UserName = GetStringFromDataReader(reader, "ADMIN_LOGINNAME");
            aapUser.UserId = GetIntegerFromDataReader(reader, "ADMIN_ID");
            aapUser.UserLocation.LocationName = GetStringFromDataReader(reader, "ADMIN_AREACODE");
            return aapUser;
        }
    }
}
