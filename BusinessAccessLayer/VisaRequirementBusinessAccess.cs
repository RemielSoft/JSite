using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DataAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Remielsoft.JetSave.BusinessAccessLayer
{
    public class VisaRequirementBusinessAccess : BaseBusinessAccess
    {
        private Database myDataBase;
        private VisaRequirementDataAccess addVisainfodl;
        public VisaRequirementBusinessAccess()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            addVisainfodl = new VisaRequirementDataAccess(myDataBase);
        }

        #region insert bal visa info

        public void CreateVisaRequirement(VisaRequirement ob)
        {
            addVisainfodl.CreateVisaRequirement(ob);
        }
        #endregion

        #region update bal visa info
        public void UpdateVisaRequirement(VisaRequirement ob, int req_id)
        {
            addVisainfodl.UpdateVisaRequirement(ob, req_id);

        }
        #endregion

        #region delete bal visa info
        public void DeleteVisaRequirement(int id)
        {
            addVisainfodl.DeleteVisaRequirement(id);
        }
        #endregion

        #region Dropdown bal visa info
        public List<VisaRequirement> ReadStateByCountryID(int id)
        {
            return addVisainfodl.ReadStateByCountryID(id);
        }

        public List<VisaRequirement> ReadCityByStateID(int id)
        {
            return addVisainfodl.ReadCityByStateID(id);
        }
        public List<VisaRequirement> ReadCountry()
        {

            return addVisainfodl.ReadCountry();
        }
        public List<VisaRequirement> ReadAllState()
        {

            return addVisainfodl.ReadAllState();
        }
        
        public List<VisaRequirement> ReadConsulate()
        {

            return addVisainfodl.ReadConsulate();
        }
        
        public List<VisaRequirement> ReadVisaType()
        {

            return addVisainfodl.ReadVisaType();
        }
        #endregion

        #region edit bal visa info
        public List<VisaRequirement> ReadVisaRequirementByReqId(int id)
        {
            return addVisainfodl.ReadVisaRequirementByReqId(id);
        }
        #endregion

        #region showvisa info bal
        public List<VisaRequirement> ShowVisaRequirement(string CountryName, string VisaType, string Consulate)
        {
            return addVisainfodl.ShowVisaRequirement(CountryName, VisaType, Consulate);
        }

        #endregion

        #region gridview bind

        public List<VisaRequirement> ReadVisaRequirement()
        {
            return addVisainfodl.ReadVisaRequirement();
        }
        #endregion

        #region search in gridview bal

        public List<VisaRequirement> ReadVisaRequirementByCountryName(string country_name)
        {
            return addVisainfodl.ReadVisaRequirementByCountryName(country_name);
        }
        #endregion

        #region Visa Type Added By Divaker...

        public int CreateVisaTypeOne(VisaRequirement visa)
        {
            int status = addVisainfodl.CreateVisaTypeOne(visa);
            return status;
        }
        public List<VisaRequirement> ReadVisaTypeOne(int? id)
        {
            List<VisaRequirement> lst = new List<VisaRequirement>();
            lst = addVisainfodl.ReadVisaTypeOne(id);
            return lst;
        }
        public void UpdateVisaTypeOne(VisaRequirement visa)
        {
            addVisainfodl.UpdateVisaTypeOne(visa);
        }
        public void DeleteVisaTypeOne(int id)
        {
            addVisainfodl.DeleteVisaTypeOne(id);
        }
        #endregion

        public List<VisaRequirement> ReadSchengenCountry(int? id)
        {
            return addVisainfodl.ReadSchengenCountry(id);
        }

        public List<VisaForm> ReadSchengenForm(int? id)
        {
            return addVisainfodl.ReadSchengenForm(id);
        }
    }
}
