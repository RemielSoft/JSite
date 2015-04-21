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
    public class MiscellaneousReportBAL : BaseBusinessAccess
    {
        private Database myDataBase;
        private MiscellaneousReportDAL miscelaReportDal;
        public MiscellaneousReportBAL()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            miscelaReportDal = new MiscellaneousReportDAL(myDataBase);
        }

        public List<MiscellaneousReportDOM> ReadAgentName()
        {
            return miscelaReportDal.ReadAgentName();
        }


        public List<MiscellaneousReportDOM> ReadCountryName()
        {
            return miscelaReportDal.ReadCountryName();
        }


        public List<MiscellaneousReportDOM> ReadMiscellaneousReport(DateTime? fromDate, DateTime? toDate, string agentName, string countryName, int? LocId)
        {
            return miscelaReportDal.ReadMiscellaneousReport(fromDate, toDate, agentName, countryName, LocId);
        }
        public List<MiscellaneousReportDOM> ReadMiscellReportByAgent(string agentName, int? LocId)
        {
            return miscelaReportDal.ReadMiscellReportByAgent(agentName, LocId);
        }

        public List<MiscellaneousReportDOM> ReadMiscellReportByCountry(string countryName, int? LocId)
        {
            return miscelaReportDal.ReadMiscellReportByCountry(countryName, LocId);
        }

        public List<MiscellaneousReportDOM> ReadMiscellaneousReportByConsolidated(DateTime? fromDate, DateTime? toDate, string countryName, int? LocId)
        {
            return miscelaReportDal.ReadMiscellaneousReportByConsolidated(fromDate, toDate, countryName, LocId);
        }
    }
}
