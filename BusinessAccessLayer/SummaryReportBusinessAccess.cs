using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DataAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Remielsoft.JetSave.BusinessAccessLayer
{
   public class SummaryReportBusinessAccess:BaseBusinessAccess
    {
       private Database MyDataBase;
       private SummaryReportDataAccess summaryReportDataAccess;

       public SummaryReportBusinessAccess()
       {
           MyDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
           summaryReportDataAccess = new SummaryReportDataAccess(MyDataBase);
       }
       public List<Agent> Agentbind(int? LocId,int? agentId)
       {
           List<Agent> list=new List<Agent>();
           list = summaryReportDataAccess.BindAgent(LocId, agentId);
           return list;
       }
       public List<summaryReport> readReport(DateTime Fromdate, DateTime todate, int AgentIds,int? LocId)
       {
           List<summaryReport> lstReport = new List<summaryReport>();
           lstReport = summaryReportDataAccess.ReadSummaryReport(Fromdate, todate, AgentIds, LocId);
           return lstReport;
       }
    }

}
