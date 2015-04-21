using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DataAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;

namespace Remielsoft.JetSave.BusinessAccessLayer
{
    public class EmbsyMasterBusinessAccess:BaseBusinessAccess
    {
        private EmbsyMasterDataAccess embsyDal;

        private Database myDataBase;
        public EmbsyMasterBusinessAccess()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            embsyDal = new EmbsyMasterDataAccess(myDataBase);
        }

        #region Embassy Master Insert

        public void Insert1(Embsy embsy)
        {            
            embsyDal.Insert(embsy);
        }

        #endregion

        #region Grid Bind

        public List<Embsy> Gridbind()
        {
            List<Embsy> lst = new List<Embsy>();
            lst = embsyDal.GridBind();
            return lst;
        }

        #region Read Country

        public List<Embsy> ReadCountry()
        {
            return embsyDal.ReadCountry();
        }
        #endregion

        public List<Embsy> ReadEmbassyMasterByCountryId(Int32 CountryId)
        {
            List<Embsy> lst = new List<Embsy>();
            lst = embsyDal.ReadEmbassyMasterByCountryId(CountryId);
            return lst;
        }

        #endregion

        #region Edit,Delete Gridview

        public List<Embsy> Edit1(int id)
        {
            return embsyDal.Edit(id);
        }

        #endregion

        #region Embassy Master Update

        public void Update1(Embsy embsy)
        {
            embsyDal.Update(embsy);
        }

        #endregion

        #region Embassy Master Delete

        public void Delete1(int id)
        {
            embsyDal.Delete(id);
        }

        #endregion
    }
}
