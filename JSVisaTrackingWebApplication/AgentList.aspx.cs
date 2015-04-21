using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.Globalization;
using JSVisaTrackingWebApplication.Shared;
//using System.Windows.Forms;

namespace JSVisaTrackingWebApplication
{
    public partial class AgentList : System.Web.UI.Page
    {
        BasePage basePage = new BasePage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                //Session.Remove("ConsignmentDetails");
                //Session.Remove("NewMailRemarks");
                //Session.Remove("consignmentEditpax");
                //Session.Remove("pax");
                //Session.Remove("paxAdditional");
                //Session.Remove("VisaTypeOneId");
                //Session.Remove("CurrentTable");
                //Session.Remove("CurrentTable");
                //Session.Remove("lstBillItem");
                //Session.Remove("lstBillItemm");
                //Session.Remove("lstBillItems");
                //Session.Remove("billIdds");
                //Session.Remove("billitem");
                //Session.Remove("tempdata");
                //Session.Remove("Type");
                //Session.Remove("version");
                Session.RemoveAll();
                AgentBAL agntBal = new AgentBAL();
                List<Agent> lstAgent = new List<Agent>();
                int LocId = basePage.LoggedInUser.UserLocation.LocationId;
                int userId = basePage.LoggedInUser.UserTypeId;
                if (userId == Convert.ToInt32(UserType.Admin))
                {
                    LocId = 0;
                    lstAgent = agntBal.ReadUsers("", LocId,0);
                }
                else
                {
                    lstAgent = agntBal.ReadUsers("", LocId, basePage.LoggedInUser.AgentId);
                }
                LstAgent.DataSource = lstAgent;
                LstAgent.DataTextField = "AgentName";
                LstAgent.DataValueField = "AgentId";
                LstAgent.DataBind();
            }

           
        }
        
        protected void btnAddConsignment_Click(object sender, EventArgs e)
        {
            if (LstAgent.Items.Count > 0 && LstAgent.SelectedIndex>=0)
            {
                int AgenID;
                string AgentName;
                string strAgentName = LstAgent.SelectedItem.Text;
                AgentName =strAgentName.Replace('&','!');
                AgenID = Convert.ToInt32(LstAgent.SelectedItem.Value);
                
                Response.Redirect("AddConsignment.aspx?AgentID=" + AgenID + "&AgentName=" + AgentName);
            }
            else
                Response.Write("<script type=\"text/javascript\">alert('Please Select Agent');</script>"); 

        }

        protected void LstAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtname.Text = LstAgent.SelectedItem.Text;
        }

        protected void btnsearch_Click1(object sender, EventArgs e)
        {
            AgentBAL agntBal = new AgentBAL();
            List<Agent> lstAgent = new List<Agent>();
            int LocId = basePage.LoggedInUser.UserLocation.LocationId;
            int userId = basePage.LoggedInUser.UserTypeId;
            if (userId == Convert.ToInt32(UserType.Admin))
            {
                LocId = 0;
                lstAgent = agntBal.ReadUsers(txtname.Text, LocId,0);
            }
            else
            {
                lstAgent = agntBal.ReadUsers(txtname.Text, LocId, basePage.LoggedInUser.AgentId);
            }

            if (lstAgent.Count > 0)
            {

                LstAgent.DataSource = lstAgent;
                LstAgent.DataTextField = "AgentName";
                LstAgent.DataValueField = "AgentId";
                LstAgent.DataBind();
                System.Threading.Thread.Sleep(1000);
                //this.LstAgent.MouseDoubleClick += new MouseEventHandler(LstAgent_MouseDoubleClick);
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Record Not Found');</script>");
            }
        }
    }
}