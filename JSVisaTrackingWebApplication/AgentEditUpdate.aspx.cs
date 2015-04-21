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
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace JSVisaTrackingWebApplication
{
    public partial class AgentEditUpdate : System.Web.UI.Page
    {
        #region global Properties..
        Agent adAgentDom = new Agent();
        AgentBAL adAgentBal = new AgentBAL();
        BasePage basePage = new BasePage();
        UserBAL userBal = new UserBAL();
        VisaRequirementBusinessAccess advs = new VisaRequirementBusinessAccess();
        LocationBusinessAccess locationBusinessAccess = new LocationBusinessAccess();
        #endregion
        #region Protected Method..
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                divcity.Visible = true;
                HideAgentInfoControls();
                btnupdateStatus.Visible = false;
                BindActiveAgentDetails();
                BindCountry();
                BindAllState();
                BindCity();
                BindAgentCity();
            }
            else
            {
                btnupdateStatus.Visible = true;
            }
        }
        #region public
        public List<Agent> BindGrid(string city)
        {
            List<Agent> lst = new List<Agent>();
            lst = adAgentBal.ReadAgentInfo(null, city);
            if (lst.Count == 0)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('No Record Found')</script>");
            }
            else
            {
                btnExport.Visible = true;
            }
            gvDetails.DataSource = lst;
            gvDetails.DataBind();
            //if (txt_city.Text == "")
            //{
            //    Response.Write("<script LANGUAGE='JavaScript' >alert('Please Enter Agent/City')</script>");
            //    grid_search.Visible = false;
            //}
            return lst;

        }

        
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string city = ddlCity.SelectedItem.Text;
            // gvDetails.Visible = false;
            grid_search.Visible = true;
            BindGrid(city);
        }

        protected void grid_search_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string city = ddlCity.SelectedItem.Text;
            grid_search.PageIndex = e.NewPageIndex;
            BindGrid(city);
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCityName(string prefixText)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT(AGENT_CITY) FROM AGENT WHERE AGENT_CITY LIKE @city+'%'", con);
            cmd.Parameters.AddWithValue("@city", prefixText);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            List<string> CityName = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CityName.Add(dt.Rows[i]["AGENT_CITY"].ToString());
            }
            return CityName;
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=Agent.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.xls";
            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);
            HtmlTextWriter htm = new HtmlTextWriter(stringWriter);
            gvDetails.AllowPaging = true;
            BindActiveAgentDetails();
            //gridViewConsignment.FooterRow.HorizontalAlign = HorizontalAlign.Right;
            gvDetails.RenderControl(htm);
            gvDetails.Columns.RemoveAt(18);
            Response.Write(stringWriter);
            Response.End();
            // btnExport.Visible = false;
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }


        #endregion

        public void BindState()
        {
            int countryId = Convert.ToInt32(ddlCountry.SelectedValue);
            var lst = advs.ReadStateByCountryID(countryId);
            ddlState.DataSource = lst;
            ddlState.DataTextField = "state";
            ddlState.DataValueField = "stateId";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void BindCityByStateID()
        {
            int stateId = Convert.ToInt32(ddlState.SelectedValue);
            var lst = advs.ReadCityByStateID(stateId);
            ddlagentCity.DataSource = lst;
            ddlagentCity.DataTextField = "consulate_name";
            ddlagentCity.DataValueField = "consulate_id";
            ddlagentCity.DataBind();
            ddlagentCity.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void BindCity()
        {
            ddlCity.DataSource = locationBusinessAccess.ReadCity(null);
            ddlCity.DataTextField = "City";
            ddlCity.DataValueField = "CityId";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("--Select--", "0"));
            // ddlCity.SelectedValue = "0";
        }
        public void BindAgentCity()
        {
            ddlagentCity.DataSource = locationBusinessAccess.ReadCity(null);
            ddlagentCity.DataTextField = "City";
            ddlagentCity.DataValueField = "CityId";
            ddlagentCity.DataBind();
            ddlagentCity.Items.Insert(0, new ListItem("--Select--", "0"));
            // ddlCity.SelectedValue = "0";
        }
        public void BindActiveAgentDetails()
        {
            var listActiveAgent = adAgentBal.ReadAgentInfo(null, null);
            if (listActiveAgent.Count > 0)
            {
                btnExport.Visible = true;
            }
            else
            {
                btnExport.Visible = false;
            }
            gvDetails.DataSource = listActiveAgent;
            gvDetails.DataBind();

        }
        protected void gvDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // gvDetails.EditIndex = e.NewEditIndex;
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
            Response.Write("<script LANGUAGE='JavaScript' >alert('Agent details deleted successfully')</script>");
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

            //adAgentDom.AgentUserName = txtusername.Text;
            //adAgentDom.AgentPassword = txtpass.Text;
            adAgentDom.AgentCPerson = txtcper.Text;
            adAgentDom.AgentName = txtname.Text;
            adAgentDom.AgentAddress = txtadd.Text;
            adAgentDom.AgentCity = txtcity.Text;
            adAgentDom.AgentPin = txtpin.Text;
            adAgentDom.AgentEmail = txtemail.Text;
            adAgentDom.AgentPhone = txtphone.Text;
            adAgentDom.AgentFax = txtfax.Text;
            adAgentDom.AgentEnable = txtenable.Text;
            adAgentDom.AgentPrority = Convert.ToInt32(txtpro.Text);
            adAgentDom.AgentSCharge = Convert.ToDecimal(txtscharge.Text);
            adAgentDom.AgentCCharge = Convert.ToDecimal(txtccharge.Text);
            adAgentDom.TallyAcName = txttally.Text;
            adAgentDom.AgentDDCharge = Convert.ToDecimal(txtdcharge.Text);
            adAgentDom.OpeningBalance = Convert.ToDecimal(txtopening.Text);
            adAgentBal.updaterecord(AgentId, adAgentDom);
            Response.Write("<script LANGUAGE='JavaScript' >alert('Agent Details Updated successfully')</script>");
            //lblresult.Text = AgentName + " Details Updated successfully";
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
                lnkEdit.Visible = true;
                lnkDelete.Visible = true;
                if (basePage.LoggedInUser.UserTypeId == Convert.ToInt32(UserType.Admin))
                {
                    lnkEdit.Visible = true;
                    lnkDelete.Visible = true;
                }
                else if (basePage.LoggedInUser.UserTypeId != Convert.ToInt32(UserType.Admin) && user.UserTask.Count > 0)
                {
                    for (int i = 0; i < user.UserTask.Count; i++)
                    {
                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.EditAgent))))
                        {
                            if (lnkEdit != null)
                            {
                                lnkEdit.Visible = true;
                            }
                        }
                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.DeleteAgent))))
                        {
                            if (lnkDelete != null)
                            {
                                lnkDelete.Visible = true;
                            }
                        }
                    }
                }
            }
        }
        protected void lnksearch_Click(object sender, EventArgs e)
        {
            grid_search.Visible = false;
            gvDetails.Visible = true;
            // btnExport.Visible = false;
            BindAgentDetails();

        }
        #endregion
        #region Public Method..


        //protected void btn_search_Click1(object sender, EventArgs e)
        //{
        //    BindAgentDetails();
        //}
        public void BindAgentDetails()
        {
            int LocId = basePage.LoggedInUser.UserLocation.LocationId;
            int userId = basePage.LoggedInUser.UserTypeId;
            Agent adAgentDom = new Agent();
            List<Agent> adlst = new List<Agent>();
            if (userId == Convert.ToInt32(UserType.Admin))
            {
                //if (txt_search.Text == "")
                //{
                //    Response.Write("<script LANGUAGE='JavaScript' >alert('Please Enter Agent/City')</script>");
                //}
                // else
                // {
                LocId = 0;
                adlst = adAgentBal.ReadUsers(txt_search.Text.Trim(), LocId, 0);
                //  }
            }
            else
            {
                adlst = adAgentBal.ReadUsers(txt_search.Text.Trim(), LocId, 0);
            }
            //if (adlst.Count == 0)
            //{
            //    Response.Write("<script LANGUAGE='JavaScript' >alert('No Record Found')</script>");
            //}
            gvDetails.DataSource = adlst;
            gvDetails.DataBind();
            System.Threading.Thread.Sleep(500);
            txt_search.Text = "";
            ddlStatus.SelectedIndex = -1;

        }
        #endregion

        protected void grid_search_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            // BtnAdd.Visible = false;
            // btnupdate.Visible = true;
        }

        protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument);
            Session["Id"] = Id;
            if (e.CommandName == "Cancel")
            {

            }
            if (e.CommandName == "Edit")
            {
                divcity.Visible = false;
                LinkButton1.Visible = false;
                agent.Visible = false;
                status.Visible = false;
                List<Agent> llst = adAgentBal.ReadAgentInfo(Id, null);

                txtagentname.Text = llst[0].AgentName;
                txtusername.Text = llst[0].AgentUserName;
                txtagentpwd.Text = llst[0].AgentPassword;
                txtagentcp.Text = llst[0].AgentCPerson;
                txtagentaddress.Text = llst[0].AgentAddress;
                ddlagentCity.SelectedItem.Text = llst[0].AgentCity;
                ddlagentCity.SelectedValue = Convert.ToString(llst[0].AgentCityId);
                ddlCountry.SelectedValue = Convert.ToString(llst[0].AgentCountryId);
                ddlCountry.SelectedItem.Text = llst[0].AgentCountryName;
                ddlState.SelectedValue = Convert.ToString(llst[0].AgentStateId);
                ddlState.SelectedItem.Text = llst[0].AgentStateName;
                // txtcity.Text = llst[0].AgentCity;
                txtpin.Text = llst[0].AgentPin;
                txtemailid.Text = llst[0].AgentEmail;
                txtph.Text = llst[0].AgentPhone;
                txtfax.Text = llst[0].AgentFax;
                txtenable.Text = llst[0].AgentEnable;
                txtpriority.Text = llst[0].AgentPrority.ToString();
                txtscharge.Text = llst[0].AgentSCharge.ToString();
                txtccharge.Text = llst[0].AgentCCharge.ToString();
                txttallyaccnt.Text = llst[0].TallyAcName;
                txtdcharge.Text = llst[0].AgentDDCharge.ToString();
                txtob.Text = llst[0].OpeningBalance.ToString();
                ShowAgentInfoControls();

            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            divcity.Visible = true;
            LinkButton1.Visible = true;
            agent.Visible = true;
            status.Visible = true;
            int Id = Convert.ToInt32(Session["Id"]);
            Agent agentupdate = new Agent();
            agentupdate.AgentCityId = Convert.ToInt32(ddlagentCity.SelectedValue);
            agentupdate.AgentStateId = Convert.ToInt32(ddlState.SelectedValue);
            agentupdate.AgentCountryId = Convert.ToInt32(ddlCountry.SelectedValue);
            agentupdate.AgentName = txtagentname.Text;
            agentupdate.AgentUserName = txtusername.Text;
            agentupdate.AgentPassword = txtagentpwd.Text;
            agentupdate.AgentFax = txtfax.Text;
            agentupdate.AgentAddress = txtagentaddress.Text;
            agentupdate.AgentCCharge = Convert.ToDecimal(txtccharge.Text);
            agentupdate.AgentCity = ddlagentCity.SelectedItem.Text;
            agentupdate.AgentCPerson = txtagentcp.Text;
            agentupdate.AgentDDCharge = Convert.ToDecimal(txtdcharge.Text);
            agentupdate.AgentEmail = txtemailid.Text;
            agentupdate.AgentEnable = txtenable.Text;
            agentupdate.AgentPhone = txtph.Text;
            agentupdate.AgentPin = txtpin.Text;
            agentupdate.AgentPrority = Convert.ToInt32(txtpriority.Text);
            agentupdate.AgentSCharge = Convert.ToDecimal(txtscharge.Text);
            // agentupdate.AgentCity = txtcity.Text;
            agentupdate.TallyAcName = txttallyaccnt.Text;
            agentupdate.Modified_By = basePage.LoggedInUser.LoginId;
            agentupdate.Modified_Date = DateTime.Now;
            adAgentBal.AgentInfoUpdate(Id, agentupdate);
            Response.Write("<Script Language=javascript>alert('AgentInfo Updated Successfully.');</Script>");
            // BindAgentDetails();
            BindActiveAgentDetails();
            HideAgentInfoControls();

        }

        public void ShowAgentInfoControls()
        {
            txtagentaddress.Visible = true;
            txtagentcp.Visible = true;
            txtagentname.Visible = true;
            txtagentpwd.Visible = true;
            txtccharge.Visible = true;
            lblCity.Visible = true;
            lblState.Visible = true;
            lblCountry.Visible = true;
            txtdcharge.Visible = true;
            txtemailid.Visible = true;
            txtenable.Visible = true;
            txtfax.Visible = true;
            txtob.Visible = true;
            txtph.Visible = true;
            txtpin.Visible = true;
            txtpriority.Visible = true;
            txtscharge.Visible = true;
            txttallyaccnt.Visible = true;
            txtusername.Visible = true;
            lbladdress.Visible = true;
            lblagentcp.Visible = true;
            lblagentname.Visible = true;
            lblagentpwd.Visible = true;
            lblccharge.Visible = true;
            ddlagentCity.Visible = true;
            ddlCountry.Visible = true;
            ddlState.Visible = true;
            lbldcharge.Visible = true;
            lblemailid.Visible = true;
            lblenable.Visible = true;
            lblfax.Visible = true;
            lblopenbal.Visible = true;
            lblph.Visible = true;
            lblpin.Visible = true;
            lblpriority.Visible = true;
            lblresult.Visible = true;
            lblscharge.Visible = true;
            lbltallyaccnt.Visible = true;
            lblusername.Visible = true;
            btnupdate.Visible = true;
            btnExport.Visible = false;
        }
        public void HideAgentInfoControls()
        {
            txtagentaddress.Visible = false;
            txtagentcp.Visible = false;
            txtagentname.Visible = false;
            txtagentpwd.Visible = false;
            txtccharge.Visible = false;
            ddlagentCity.Visible = false;
            ddlCountry.Visible = false;
            ddlState.Visible = false;
            txtdcharge.Visible = false;
            txtemailid.Visible = false;
            txtenable.Visible = false;
            txtfax.Visible = false;
            txtob.Visible = false;
            txtph.Visible = false;
            txtpin.Visible = false;
            txtpriority.Visible = false;
            txtscharge.Visible = false;
            txttallyaccnt.Visible = false;
            txtusername.Visible = false;

            lbladdress.Visible = false;
            lblagentcp.Visible = false;
            lblagentname.Visible = false;
            lblagentpwd.Visible = false;
            lblccharge.Visible = false;
            lblCity.Visible = false;
            lblState.Visible = false;
            lblCountry.Visible = false;
            lbldcharge.Visible = false;
            lblemailid.Visible = false;
            lblenable.Visible = false;
            lblfax.Visible = false;
            lblopenbal.Visible = false;
            lblph.Visible = false;
            lblpin.Visible = false;
            lblpriority.Visible = false;
            lblresult.Visible = false;
            lblscharge.Visible = false;
            lbltallyaccnt.Visible = false;
            lblusername.Visible = false;
            btnupdate.Visible = false;
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            //System.Threading.Thread.Sleep(500);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {

            string AgentName = txt_search.Text.Trim();
            var lst = adAgentBal.ReadUsersStatus(AgentName, ddlStatus.SelectedValue);
            gvDetails.DataSource = lst;
            gvDetails.DataBind();
        }

        protected void btnupdateStatus_Click(object sender, EventArgs e)
        {
            int Id = 0;
            Agent agentupdate = new Agent();
            //lbleditusr
            Label lblAgentId = null;
            RadioButton rbGridWala = null;
            string enableStatus = "";
            foreach (GridViewRow item in gvDetails.Rows)
            {
                rbGridWala = (RadioButton)item.FindControl("RBtnY");
                if (rbGridWala.Checked == true)
                {
                    enableStatus = "Y";
                }
                else
                {
                    enableStatus = "N";
                }
                lblAgentId = (Label)item.FindControl("lblitemUsr");
                int id = Convert.ToInt32(lblAgentId.Text);
                if (rbGridWala != null && lblAgentId != null)
                    adAgentBal.UpdateAgentStatusById(id, enableStatus);
            }
            Response.Write("<script LANGUAGE='JavaScript' >alert('Agent Status Updated successfully')</script>");

            BindAgentDetails();
        }
        public void BindCountry()
        {
            var lst = advs.ReadCountry();
            ddlCountry.DataSource = lst;
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataValueField = "COUNTRY_ID";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        public void BindAllState()
        {
            var lst = advs.ReadAllState();
            ddlState.DataSource = lst;
            ddlState.DataTextField = "state";
            ddlState.DataValueField = "stateId";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        protected void RBtnY_CheckedChanged(object sender, EventArgs e)
        {
            string ctrlName = ((Control)sender).ID;

        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindState();
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCityByStateID();
        }



    }
}