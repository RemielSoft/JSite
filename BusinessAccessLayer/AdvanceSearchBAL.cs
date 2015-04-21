using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.DataAccessLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
namespace Remielsoft.JetSave.BusinessAccessLayer
{
    public class AdvanceSearchBAL : BaseBusinessAccess
    {

         private Database myDataBase;
         private AdvanceSearchDataAccess advanceSearchDal;

        public AdvanceSearchBAL()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            advanceSearchDal = new AdvanceSearchDataAccess(myDataBase);
            
        }

        #region BindDropDown...

        public List<AdvanceSearchDom> ReadAgentNameList()
        {
            List<AdvanceSearchDom> lstdom = advanceSearchDal.ReadAgentNameList();
            return lstdom;
        }
        public List<AdvanceSearchDom> ReadCountryNameList()
        {
            List<AdvanceSearchDom> lstdom = advanceSearchDal.ReadCountryNameList();
            return lstdom;
        }
        public List<AdvanceSearchDom> ReadAreaCodeList()
        {
            List<AdvanceSearchDom> lstdom = advanceSearchDal.ReadAreaCodeList();
            return lstdom;
        }

        #endregion


        #region ReadAdvanceSearch..

        public List<AdvanceSearchDom> ReadAdvanceSearch(int conId, int agentId, int countryId, string agentName, string countryName, DateTime? fromDate, DateTime? toDate,int? LocId)
         {
             return advanceSearchDal.ReadAdvanceSearch(conId, agentId, countryId, agentName, countryName, fromDate, toDate, LocId);
         }

        #endregion

    }
}
