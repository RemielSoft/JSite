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
    public partial class AgentEditUpdate : System.Web.UI.Page
    {
        Agent adAgentDom = new Agent();
        AgentBAL adAgentBal = new AgentBAL();
        BasePage basePage = new BasePage();
        UserBAL userBal = new UserBAL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_search_Click1(object sender, EventArgs e)
        {
            Agent adAgentDom = new Agent();

            List<Agent> adlst = new List<Agent>();

            adlst = adAgentBal.ReadUsers(txt_search.Text.Trim());
            
            gvDetails.DataSource = adlst;
            gvDetails.DataBind();
          

        }
        public void BindAgentDetails()
        {
            Agent adAgentDom = new Agent();
            List<Agent> adlst = new List<Agent>();
            adlst = adAgentBal.ReadUsers(txt_search.Text.Trim());
            gvDetails.DataSource = adlst;
            gvDetails.DataBind();
        }
        protected void gvDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDetails.EditIndex = e.NewEditIndex;
            BindAgentDetails();
        }
        protected void gvDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDetails.EditIndex = -1;
            BindAgentDetails();
        }
        protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int AgentId = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Values["AgentId"].ToString());
            string AgentName = gvDetails.DataKeys[e.RowIndex].Values["AgentName"].ToString();
            adAgentBal.DeleteAgent(AgentId);
            BindAgentDetails();
            lblresult.Text = AgentName + " details deleted successfully";

        }
        protected void gvDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Agent adAgentDom = new Agent();
            int AgentId = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Value.ToString());
            string AgentName = gvDetails.DataKeys[e.RowIndex].Values["AgentName"].ToString();
            TextBox txtusername = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtusername");
            TextBox txtpass = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtpass");
            TextBox txtcper = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtcper");
            TextBox txtname = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtname");
            TextBox txtadd = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtadd");
            TextBox txtcity = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtcity");
            TextBox txtpin = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtpin");
            TextBox txtemail = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtemail");
            TextBox txtphone = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtphone");
            TextBox txtfax = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtfax");
            TextBox txtenable = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtenable");
            TextBox txtpro = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtpro");
            TextBox txtscharge = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtscharge");
            TextBox txtccharge = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtccharge");
            TextBox txttally = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txttally");
            TextBox txtdcharge = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtdcharge");
            TextBox txtopening = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtopening");

            adAgentDom.AgentUserName = txtusername.Text;
            adAgentDom.AgentPassword = txtpass.Text;
            adAgentDom.AgentCPerson = txtcper.Text;
            adAgentDom.AgentName = txtname.Text;
            adAgentDom.AgentAddress = txtadd.Text;
            adAgentDom.AgentCity = txtcity.Text;
            adAgentDom.AgentPin = txtpin.Text;
            adAgentDom.AgentEmail = txtemail.Text;
            adAgentDom.AgentPhone = txtphone.Text;
            adAgentDom.AgentFax = txtfax.Text;
            adAgentDom.AgentEnable = txtenable.Text;
            adAgentDom.AgentPrority = Convert.ToInt32( txtpro.Text);
            adAgentDom.AgentSCharge = Convert.ToDecimal(txtscharge.Text);
            adAgentDom.AgentCCharge = Convert.ToDecimal(txtccharge.Text);
            adAgentDom.TallyAcName = txttally.Text;
            adAgentDom.AgentDDCharge = Convert.ToDecimal(txtdcharge.Text);
            adAgentDom.OpeningBalance = Convert.ToDecimal(txtopening.Text);
            adAgentBal.updaterecord(AgentId, adAgentDom);
            lblresult.Text = AgentName + " Details Updated successfully";
            gvDetails.EditIndex = -1;
            BindAgentDetails();
        }

        protected void gvDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDetails.PageIndex = e.NewPageIndex;
            BindAgentDetails();
        }

        protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                UserDom user = new UserDom();
                user = userBal.ReadUserByLoginId(basePage.LoggedInUser.LoginId);
                LinkButton lnkEdit = (LinkButton)e.Row.FindControl("linbtn_edit");
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("linbtn_delete");
                for (int i = 0; i < user.UserTask.Count; i++)
                {
                    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.Edit_Agent))))
                    {
                        if (lnkEdit != null)
                        {
                            lnkEdit.Visible = false;
                        }
                    }
                    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.Delete_Agent))))
                    {
                        if (lnkDelete != null)
                        {
                            lnkDelete.Visible = false;
                        }
                    }
                }
            }
        }
    }
}