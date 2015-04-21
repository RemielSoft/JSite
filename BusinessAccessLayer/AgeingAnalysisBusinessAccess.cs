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
    public class AgeingAnalysisBusinessAccess:BaseBusinessAccess
    {
        AgeingAnalysisDataAccess ageingAnalysisDal;
        Database myDatabase;

        public AgeingAnalysisBusinessAccess()
        {
            myDatabase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            ageingAnalysisDal = new AgeingAnalysisDataAccess(myDatabase);
        }       

        public List<AgeingAnalysis> ReadAnalysis(DateTime StartDate, DateTime LastDate, Int32 AgentId, int? LocId)
        {
            return ageingAnalysisDal.ReadAgeingAnalysis(StartDate, LastDate, AgentId, LocId);
        }        
    }
}
