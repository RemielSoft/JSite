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
    public class EmbsyFeeBusinessAccess:BaseBusinessAccess
    {
        private EmbsyFeeDataAccess embsyFeeDataAccess;

        private Database myDataBase;
        public EmbsyFeeBusinessAccess()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            embsyFeeDataAccess = new EmbsyFeeDataAccess(myDataBase);
        }

        #region Bind DropDownList NO. of Visit

        public List<Embsy> Read()
        {
            return embsyFeeDataAccess.BindDropDownNoOfVisit();

        }
        #endregion

        #region BindDropDown Visa Duration

        public List<Embsy> BindVisaDuraion()
        {
            List<Embsy> lst = new List<Embsy>();
            lst = embsyFeeDataAccess.BindDdlVisaDuration();
            return lst;
        }
        #endregion

        #region ReadEmbassyFeesCountry

        public List<Embsy> ReadEmbassyFeesCountry()
        {
            List<Embsy> lst = new List<Embsy>();
            lst = embsyFeeDataAccess.ReadEmbassyFeesCountry();
            return lst;
        }
        #endregion

        #region Bind DropDown Process Time

        public List<Embsy> BindProcessTime()
        {
            return embsyFeeDataAccess.BindDdlProcessTime();
        }
        #endregion

        #region ReadEmbsyMasterId

        public List<Embsy> GetId1(int countryId)
        {
            return embsyFeeDataAccess.GetId(countryId);
        }
        #endregion

        #region Insert the table

        public void InsertEmbsyFee(Embsy embsy, int masterid)
        {
            embsyFeeDataAccess.InsertFees(embsy, masterid);
        }
        #endregion

        #region Bind Grid

        public List<Embsy> GridBind1()
        {
            List<Embsy> lst = new List<Embsy>();
            lst = embsyFeeDataAccess.Gridbind();
            return lst;
        }
        #endregion

        #region ddl_no_ofvisit selectedIndexChange change the Fees Value

        //public List<Embsy> ddl_select_change1(string novisit)
        //{             
        //    return embsyFeeDataAccess.ddl_select_change(novisit);
        //}
        #endregion

        #region Row Command Edit Grid

        public List<Embsy> Edit1(int id)
        {
            return embsyFeeDataAccess.Edit(id);
        }
        #endregion

        #region Button Update

        public void Update1(int id, Embsy embsy)
        {
            embsyFeeDataAccess.Update(id, embsy);
        }
        #endregion

        #region Delete

        public void Delete1(int id)
        {
            embsyFeeDataAccess.Delete(id);
        }
        #endregion

        public List<Embsy> BindGridByCountryId(Int32 CountryId)
        {
            return embsyFeeDataAccess.GridbindByCountryId(CountryId);
        }

        public List<Embsy> BindGridByVisaTypeId(Int32 VisaTypeId)
        {
            return embsyFeeDataAccess.GridbindByVisaTypeId(VisaTypeId);
        }

        public List<Embsy> BindGridByVisaDurationId(Int32 VisaDurationId)
        {
            return embsyFeeDataAccess.GridbindByVisaDurationId(VisaDurationId);
        }

        public List<Embsy> BindGridByNoOfVisitId(Int32 NoOfVisitId)
        {
            return embsyFeeDataAccess.GridbindByNoOfVisitId(NoOfVisitId);
        }

        public List<Embsy> BindGridByProcessTimeId(Int32 ProcessTimeId)
        {
            return embsyFeeDataAccess.GridbindByProcessTimeId(ProcessTimeId);
        }

        public List<Embsy> BindGridByAll(Int32 CountryId, Int32 VisaTypeId, Int32 VisaDurationId, Int32 NoOfVisitId, Int32 ProcessTimeId)
        {
            return embsyFeeDataAccess.GridbindByAll(CountryId, VisaTypeId, VisaDurationId, NoOfVisitId, ProcessTimeId);
        }

        public void UpdateFees(int id, Decimal Fees)
        {
            embsyFeeDataAccess.UpdateFees(id, Fees);
        }
    }
}
