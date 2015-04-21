using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.DataAccessLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Remielsoft.JetSave.BusinessAccessLayer
{
    public class DataExportTallyBusinessAccess : BaseBusinessAccess
    {
        private DataExportTallyDataAccess dataExportTallyDAL;

        private Database myDatabase;

        public DataExportTallyBusinessAccess()
        {
            myDatabase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            dataExportTallyDAL = new DataExportTallyDataAccess(myDatabase);
        }

        public List<DataExportTally> ReadExportDataTally(DateTime FromDate, DateTime ToDate,int? LocId)
        {
            List<DataExportTally> lst = new List<DataExportTally>();
            lst = dataExportTallyDAL.ReadExportData(FromDate, ToDate,LocId);
            return lst;

            //StringBuilder finalTallyFile = new StringBuilder();
            //List<DataExportTally> dtExpTally = dataExportTallyDAL.ReadExportData(FromDate, ToDate);
            //List<DataExportTally> dtExpTallyRecipt = null;

            //var rr = dtExpTally.Where(dharam => dharam.isReciptData == true);

            //dtExpTallyRecipt = rr.ToList();
            //We need to write One Note Pad File using StreamWriter 
            //First Select the Recipt Lines

            //Appand Line By Line for recipt
            //Append Line By Line for Bill
        }        
    }
}
