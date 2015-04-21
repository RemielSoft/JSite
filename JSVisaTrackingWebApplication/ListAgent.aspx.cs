using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using JSVisaTrackingWebApplication.Shared;


namespace JSVisaTrackingWebApplication
{
    public partial class ListAgent : System.Web.UI.Page
    {
        Agent adAgentDom = new Agent();
        AgentBAL adAgentBal = new AgentBAL();
        BasePage basePage = new BasePage();
        protected void Page_Load(object sender, EventArgs e)
        {
            Bindgrid();
        }
        public List<Agent> Bindgrid()
        {
            List<Agent> lstAgent = new List<Agent>();
            int LocId = basePage.LoggedInUser.UserLocation.LocationId;
            int userId = basePage.LoggedInUser.UserTypeId;
            if (userId == Convert.ToInt32(UserType.Admin))
            {
                LocId = 0;
                lstAgent = adAgentBal.ReadAgentList(LocId);
            }
            else
            {
                lstAgent = adAgentBal.ReadAgentList(LocId);
            }
            gridlist.DataSource = lstAgent;
            gridlist.DataBind();
            return lstAgent;

        }

        protected void gridlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridlist.PageIndex = e.NewPageIndex;
            Bindgrid();
        }
    }
}