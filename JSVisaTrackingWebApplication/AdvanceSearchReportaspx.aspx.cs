using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using JSVisaTrackingWebApplication.Shared;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;

namespace JSVisaTrackingWebApplication
{
    public partial class AdvanceSearchaspx : System.Web.UI.Page
    {
        AdvanceSearchBAL advanceSearchBal = new AdvanceSearchBAL();
        SummaryReportBusinessAccess summaryBusinessAccess = new SummaryReportBusinessAccess();
        AgentBAL adAgentBal = new AgentBAL();
        BasePage basePage = new BasePage();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTotalPass.Visible = false;
                lblTotalVisa.Visible = false;
               
                List<Agent> lstAgent = new List<Agent>();
                BindListBoxCountryName();
                int LocId = basePage.LoggedInUser.UserLocation.LocationId;
                int userId = basePage.LoggedInUser.UserTypeId;
                if (userId == Convert.ToInt32(UserType.Admin))
                {
                    LocId = 0;
                    basePage.BindDropDown(ddlAgentName, "AgentName", "AgentId", summaryBusinessAccess.Agentbind(LocId,0));
                }
                else
                {
                    basePage.BindDropDown(ddlAgentName, "AgentName", "AgentId", summaryBusinessAccess.Agentbind(LocId,basePage.LoggedInUser.AgentId));
                }
                //int LocId = basePage.LoggedInUser.UserLocation.LocationId;
                //int userId = basePage.LoggedInUser.UserTypeId;
                //if (userId == Convert.ToInt32(UserType.Admin))
                //{
                //    LocId = 0;
                //    lstAgent = adAgentBal.ReadAgentList(LocId);
                //}
                //else
                //{
                //    lstAgent = adAgentBal.ReadAgentList(LocId);
                //}
                //ddlAgentName.DataSource = lstAgent;
                //ddlAgentName.DataTextField = "AgentName";
                //ddlAgentName.DataValueField = "AgentId";
                //ddlAgentName.DataBind();
                //ddlAgentName.Items.Insert(0, new ListItem("--Select--", "0"));
                //ddlAgentName.SelectedValue = "0";
                
            }
        }

        public void BindListBoxCountryName()
        {
            List<MiscellaneousReportDOM> lstCountryDom = new List<MiscellaneousReportDOM>();
            MiscellaneousReportBAL mislaneousReportBal = new MiscellaneousReportBAL();
            lstCountryDom = mislaneousReportBal.ReadCountryName();
            if (lstCountryDom.Count > 0)
            {
                basePage.BindDropDown(DropDownList1, "CountryName", "CountryId", mislaneousReportBal.ReadCountryName());
            }

        }

        #region GetAdvanceSearchMethods....

        public void GetAdvanceSearch()
        {
            Int64 sum = 0;
            int conId = 0;
            int agentId = 0;
            int countryId = 0;
            string agentName = null;
            string countryName = null;
            string paxName = null;
            string passportNo = null;
            List<AdvanceSearchDom> lstdom = new List<AdvanceSearchDom>();
            DateTime? fromDate = null;
            DateTime? toDate = null;


            if (txtFromDate.Text == "" && txtToDate.Text == "" && ddlAgentName.SelectedValue == "" && DropDownList1.SelectedValue == "" && txtConsignment.Text == "" )
            {

                ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "test1", "alert('Please Select Option For Search ')", true);

            }
               
            else
            {
                if (ddlAgentName.SelectedIndex > 0)
                {
                    agentId = Convert.ToInt32(ddlAgentName.SelectedItem.Value);
                }
                else
                {
                    agentId = 0;
                }
                if (DropDownList1.SelectedIndex > 0)
                {
                    countryId = Convert.ToInt32(DropDownList1.SelectedItem.Value);
                }
                else
                {
                    countryId = 0;
                }

                if (txtConsignment.Text != "")
                {
                    conId = Convert.ToInt32(txtConsignment.Text);
                }
                else
                {
                    conId = 0;
                }


                //if (txtPaxName.Text != "")
                //{
                //    paxName = txtPaxName.Text;
                //}
                //else
                //{
                //    paxName = null;
                //}

                if (txtFromDate.Text == "" && txtToDate.Text == "")
                {
                    fromDate = DateTime.MinValue;
                    toDate = DateTime.MinValue;
                }
                else if (txtFromDate.Text != "" && txtToDate.Text == "")
                {
                    fromDate = Convert.ToDateTime(txtFromDate.Text);
                    toDate = DateTime.MinValue;
                    ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "test1", "alert('Please Select Both Date')", true);

                }
                else if (txtFromDate.Text == "" && txtToDate.Text != "")
                {
                    fromDate = DateTime.MinValue;
                    toDate = Convert.ToDateTime(txtToDate.Text);
                    ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "test1", "alert('Please Select Both Date')", true);
                }
                else
                {
                    fromDate = Convert.ToDateTime(txtFromDate.Text);
                    toDate = Convert.ToDateTime(txtToDate.Text);
                    if (toDate < fromDate)
                    {
                        ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "test1", "alert('From Date Must Be Less Than To Date')", true);
                    }
                }


               
                int LocId = basePage.LoggedInUser.UserLocation.LocationId;
                int userId = basePage.LoggedInUser.UserTypeId;
                if (userId == Convert.ToInt32(UserType.Admin))
                {
                    LocId = 0;
                    lstdom = advanceSearchBal.ReadAdvanceSearch(conId, agentId, countryId, agentName, countryName,  fromDate, toDate, LocId);
                }
                else
                {
                    lstdom = advanceSearchBal.ReadAdvanceSearch(conId, agentId, countryId, agentName, countryName, fromDate, toDate, LocId);
                }


                if ((txtFromDate.Text == "" && txtToDate.Text == "") || (txtFromDate.Text != "" && txtToDate.Text != ""))
                {
                    if (lstdom.Count != 0)
                    {
                        grdViewSearch.DataSource = lstdom;
                        grdViewSearch.DataBind();

                        for (int i = 0; i < lstdom.Count; i++)
                        {

                            sum = sum + lstdom[i].TotalVisa;
                        }
                        lblTotalVisa.Text = sum.ToString();
                        lblTotalPass.Visible = true;
                        lblTotalVisa.Visible = true;
                        grdViewSearch.Visible = true;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "test1", "alert('No Record Found')", true);
                        grdViewSearch.DataSource = null;
                        grdViewSearch.DataBind();
                        lblTotalPass.Visible = false;
                        lblTotalVisa.Visible = false;
                    }
                }
                else
                {
                    grdViewSearch.DataSource = null;
                    grdViewSearch.DataBind();
                    lblTotalPass.Visible = false;
                    lblTotalVisa.Visible = false;
                }

                Session["lstAdvSearch"] = lstdom;
            }
        }

        #endregion

        #region BtnSearchClickEvent..

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            GetAdvanceSearch();
            
            

            // Clear();
        }

        #endregion



        #region gridviewRowCommand....

        protected void grdViewSearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = 0;
            id = Convert.ToInt32(e.CommandArgument);
            // this.ConsignmentId = consigmrntId;
            if (e.CommandName == "cmdConsgmntId")
            {
                string id1 = "EditAdvanceConsignment";
                Response.Redirect("AddConsignment.aspx?ConsignmentId=" + id + "&consignment=" + id1);
            }
        }

        protected void grdViewSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            List<AdvanceSearchDom> lstSearch=(List<AdvanceSearchDom>)Session["lstAdvSearch"];
            grdViewSearch.PageIndex = e.NewPageIndex;
            grdViewSearch.DataSource = lstSearch;
            grdViewSearch.DataBind();
        }
        #endregion

        #region  Cancelclick...

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            EnableCondition();
           // grdViewSearch.Visible = false;
        }

        #endregion

        #region clear...

        public void Clear()
        {
            ddlAgentName.SelectedValue = "0";
            DropDownList1.SelectedValue = "0";
            txtFromDate.Text = string.Empty;
            txtToDate.Text = string.Empty;
            txtConsignment.Text = string.Empty;
            //txtPaxName.Text = string.Empty;

        }

        #endregion

        public void EnableCondition()
        {

            ddlAgentName.SelectedValue = "0";
            DropDownList1.SelectedValue = "0";
            txtFromDate.Text = string.Empty;
            txtToDate.Text = string.Empty;
            txtConsignment.Text = string.Empty;
            //txtPaxName.Text = string.Empty;

        }

       
    }
}