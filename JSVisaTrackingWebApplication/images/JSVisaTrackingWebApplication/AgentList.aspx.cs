using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.Globalization;

namespace JSVisaTrackingWebApplication
{
    public partial class AgentList : System.Web.UI.Page
    {
        AgentListBAL obbal = new AgentListBAL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void search()
        {
            LstAgent.DataSource = obbal.read(txtname.Text);
            LstAgent.DataTextField = "Agent_name";
            LstAgent.DataValueField = "Agent_Id";
            LstAgent.DataBind();
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {

            search();
        }


        protected void btnAddConsignment_Click(object sender, EventArgs e)
        {
            if (LstAgent.Items.Count > 0)
            {
                int AgenID;
                string AgentName;
                AgentName = LstAgent.SelectedItem.Text;
                AgenID = Convert.ToInt32(LstAgent.SelectedItem.Value);
                Response.Redirect("AddConsignment.aspx?AgentID=" + AgenID + "&AgentName=" + AgentName);
            }
            else
                LblAgent.Text = "Please select Agent Name*";

        }
    }
}