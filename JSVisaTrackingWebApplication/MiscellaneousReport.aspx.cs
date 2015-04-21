using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.Web.Configuration;
using JSVisaTrackingWebApplication.Shared;
using System.IO;
using System.Net;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace JSVisaTrackingWebApplication
{
    public partial class MiscellaneousReport : System.Web.UI.Page
    {
        #region global Variables...

        BasePage basePage = new BasePage();
        UserBAL userBal = new UserBAL();
        decimal TotalAmt = 0,ServiceCharge=0,Tax=0;
        LocationBusinessAccess locationBusinessAccess = new LocationBusinessAccess();
        SummaryReportBusinessAccess summaryBusinessAccess = new SummaryReportBusinessAccess();
        MiscellaneousReportBAL mislaneousReportBal = new MiscellaneousReportBAL();
        int LocId = 0;
        #endregion

        #region private_mathods...

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                //txtFromDate.Text = System.DateTime.Today.ToShortDateString();
                //txtTodate.Text = System.DateTime.Today.ToShortDateString();
                btnExport.Visible = false;
                radiobtnMiscllReport.SelectedValue = "1";
                trdate.Visible = true;
                lblcountryName.Visible = true;
                ddlCountryName.Visible = true;
                lblAgentName.Visible = false;
                ddlagentName.Visible = false;
                lbldiv.Visible = false;
                BindListBoxCountryName();
                if (basePage.LoggedInUser.UserLocation != null)
                {
                    int LocId = basePage.LoggedInUser.UserLocation.LocationId;
                }
                int userId = basePage.LoggedInUser.UserTypeId;
                if (userId == Convert.ToInt32(UserType.Admin))
                {
                    LocId = 0;
                    basePage.BindDropDown(ddlagentName, "AgentName", "AgentId", summaryBusinessAccess.Agentbind(LocId,0));
                }
                else
                {
                    basePage.BindDropDown(ddlagentName, "AgentName", "AgentId", summaryBusinessAccess.Agentbind(LocId,basePage.LoggedInUser.AgentId));
                }


            }


        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
            if (radiobtnMiscllReport.SelectedValue == "2")
            {
              

                if (ddlagentName.SelectedValue != "0" && ddlCountryName.SelectedValue == "0" && txtFromDate.Text == "" && txtTodate.Text == "")
                {
                    grdAll.Visible = true;
                    GetMisceReportByAgent();
                    grdAll.Columns[0].Visible = true;
                    grdAll.Columns[1].Visible = false;
                    lbldiv.Visible = false;
                }
                else if (ddlagentName.SelectedValue == "0" && ddlCountryName.SelectedValue != "0" && txtFromDate.Text == "" && txtTodate.Text == "")
                {
                    grdAll.Visible = true;
                    GetMisceReportByCountry();
                    grdAll.Columns[0].Visible = false;
                    grdAll.Columns[1].Visible = true;
                    lbldiv.Visible = false;

                }
                else if (ddlagentName.SelectedValue != "0" && ddlCountryName.SelectedValue != "0" && txtFromDate.Text == "" && txtTodate.Text == "")
                {
                    grdAll.Visible = true;
                    GetMiscellaneousReport();
                    lbldiv.Visible = false;
                    grdAll.Columns[0].Visible = true;
                    grdAll.Columns[1].Visible = true;
                }
                else
                {
                    grdAll.Visible = true;
                    GetMiscellaneousReport();
                    grdAll.Columns[0].Visible = true;
                    grdAll.Columns[1].Visible = true;
                    lbldiv.Visible = true;

                }
            }

            else if (radiobtnMiscllReport.SelectedValue == "1")
            {
                if (txtFromDate.Text != "" && txtTodate.Text != "")
                {
                    lbldiv.Visible = true;
                }
                else if (txtFromDate.Text != "" && txtTodate.Text != "" && ddlCountryName.SelectedValue != "0")
                {
                    lbldiv.Visible = true;
                }
                else if (ddlCountryName.SelectedValue != "0")
                {
                    lbldiv.Visible = false;
                }
                GetMiscllReportByConsolidated();
                grdAll.Columns[0].Visible = false;
                grdAll.Visible = true;
               
            }



            //Clear();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            List<MiscellaneousReportDOM> lstMicDom = (List<MiscellaneousReportDOM>)Session["lstdom"];
            try
            {
                Response.Clear();
                Response.ClearHeaders();
                Response.AddHeader("content-disposition", "attachment;filename=MiscellaneousReport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder sb = new StringBuilder();
                StringWriter stringWrite = new StringWriter(sb);
                HtmlTextWriter htm = new HtmlTextWriter(stringWrite);
                grdAll.AllowPaging = false;
                //grid_search.Columns.RemoveAt(8);
                grdAll.DataSource = lstMicDom;
                grdAll.DataBind();
                //gvSample is Gridview server control
                grdAll.RenderControl(htm);
                Response.Write(stringWrite);
                Response.End();
            }
            catch (Exception ex)
            {
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtFromDate.Text = string.Empty;
            txtTodate.Text = string.Empty;
            ddlagentName.SelectedValue = "0";
            ddlCountryName.SelectedValue = "0";


            radiobtnMiscllReport.SelectedValue = "1";
            trdate.Visible = true;
            lblcountryName.Visible = true;
            ddlCountryName.Visible = true;
            lblAgentName.Visible = false;
            ddlagentName.Visible = false;
            // grdAll.Visible = false;
            //btnExport.Visible = true;

        }

        protected void grdAll_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblServiceCharge = (Label)e.Row.FindControl("lblServiceCharge");
                Label lblServiceTax = (Label)e.Row.FindControl("lblServiceTax");
                Label lblTotalamt = (Label)e.Row.FindControl("lblTotalamt");
                decimal lblcharge = Convert.ToDecimal(lblServiceCharge.Text);
                decimal lblTax = Convert.ToDecimal(lblServiceTax.Text);
                decimal lblamont = Convert.ToDecimal(lblTotalamt.Text);
                ServiceCharge += lblcharge;
                Tax += lblTax;
                TotalAmt += lblamont;

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells[1].Font.Bold = false;
                if (txtFromDate.Text != "" && txtTodate.Text != "")
                {
                    Label lblcountry = (Label)e.Row.FindControl("lblfooterCountry");
                    lblcountry.Text = string.Empty;
                }
                Label lblCharge = (Label)e.Row.FindControl("lblCharge");
                lblCharge.Text = ServiceCharge.ToString();
                Label lblTax = (Label)e.Row.FindControl("lblTax");
                lblTax.Text = Tax.ToString();
                Label lblGrandtotl = ((Label)e.Row.FindControl("lblGrandtotl"));
                lblGrandtotl.Text = TotalAmt.ToString();


            }


        }

        protected void grdAll_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            List<MiscellaneousReportDOM> lstMicDom = (List<MiscellaneousReportDOM>)Session["lstdom"];
            grdAll.PageIndex = e.NewPageIndex;
            grdAll.DataSource = lstMicDom;
            grdAll.DataBind();
        }

        protected void radiobtnMiscllReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radiobtnMiscllReport.SelectedValue == "1")
            {
                trdate.Visible = true;
                lblcountryName.Visible = true;
                ddlCountryName.Visible = true;
                lblAgentName.Visible = false;
                ddlagentName.Visible = false;
                txtFromDate.Text = string.Empty;
                txtTodate.Text = string.Empty;
                ddlCountryName.SelectedValue = "0";
                grdAll.Visible = false;
                lbldiv.Visible = false;
                btnExport.Visible = false;

            }

            else if (radiobtnMiscllReport.SelectedValue == "2")
            {
                trdate.Visible = true;
                lblcountryName.Visible = true;
                ddlCountryName.Visible = true;
                lblAgentName.Visible = true;
                ddlagentName.Visible = true;
                txtFromDate.Text = string.Empty;
                txtTodate.Text = string.Empty;
                ddlCountryName.SelectedValue = "0";
                ddlagentName.SelectedValue = "0";
                grdAll.Visible = false;
                lbldiv.Visible = false;
                btnExport.Visible = false;
            }
        }

        #endregion
       

        #region BindDropdown...

        public void BindListBoxCountryName()
        {
            List<MiscellaneousReportDOM> lstCountryDom = new List<MiscellaneousReportDOM>();
            lstCountryDom = mislaneousReportBal.ReadCountryName();
            if (lstCountryDom.Count > 0)
            {
                basePage.BindDropDown(ddlCountryName, "CountryName", "CountryId", lstCountryDom);
            }
           
        }

     

        //public void Citybind()
        //{
        //    ddlcityName. DataSource = locationBusinessAccess.Readcityddl();
        //    ddlcityName.DataTextField = "City";
        //    ddlcityName.DataValueField = "CityId";
        //    ddlcityName.DataBind();
        //    ddlcityName.Items.Insert(0, new ListItem("--Select--", "0"));
        //    ddlcityName.SelectedValue = "0";
        //}


        #endregion

        #region GetMiscellaneousReport Method..

        public void GetMisceReportByAgent()
        {
            List<MiscellaneousReportDOM> lstdom = new List<MiscellaneousReportDOM>();
            int LocId = basePage.LoggedInUser.UserLocation.LocationId;
            int userId = basePage.LoggedInUser.UserTypeId;
            string agentName = null;
            if (ddlagentName.SelectedIndex > 0)
            {
                agentName = ddlagentName.SelectedItem.Text;

            }
            if (userId == Convert.ToInt32(UserType.Admin))
            {
                LocId = 0;
                lstdom = mislaneousReportBal.ReadMiscellReportByAgent(agentName , LocId);
            }
            else
            {
                lstdom = mislaneousReportBal.ReadMiscellReportByAgent(agentName, LocId);
            }
            if (lstdom.Count > 0)
            {
                grdAll.DataSource = lstdom;
                grdAll.DataBind();
                btnExport.Visible = true;
                
            }
            else
            {
                grdAll.DataSource = null;
                grdAll.DataBind();
                btnExport.Visible = false;
                lbldiv.Visible = false;
                
                ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "test1", "alert('No Record Found')", true);
            }
        }

        public void GetMisceReportByCountry()
        {
            List<MiscellaneousReportDOM> lstdom = new List<MiscellaneousReportDOM>();
            int LocId = basePage.LoggedInUser.UserLocation.LocationId;
            int userId = basePage.LoggedInUser.UserTypeId;
            string countryName = null;
            if (ddlCountryName.SelectedIndex > 0)
            {
                countryName = ddlCountryName.SelectedItem.Text;

            }
            if (userId == Convert.ToInt32(UserType.Admin))
            {
                LocId = 0;
                lstdom = mislaneousReportBal.ReadMiscellReportByCountry(countryName, LocId);
            }
            else
            {
                lstdom = mislaneousReportBal.ReadMiscellReportByCountry(countryName, LocId);
            }
            if (lstdom.Count > 0)
            {
                grdAll.DataSource = lstdom;
                grdAll.DataBind();
                btnExport.Visible = true;
                
            }
            else
            {
                grdAll.DataSource = null;
                grdAll.DataBind();
                btnExport.Visible = false;
                lbldiv.Visible = false;
                
                ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "test1", "alert('No Record Found')", true);
            }
        }

        public void GetMiscellaneousReport()
        {
            int LocId = basePage.LoggedInUser.UserLocation.LocationId;
            int userId = basePage.LoggedInUser.UserTypeId;
            DateTime? fromDate = null;
            DateTime? toDate = null;
             string agentName = null;
             string countryName = null;
             
             if (txtFromDate.Text == "" && txtTodate.Text == "" && ddlagentName.SelectedValue == "0" && ddlCountryName.SelectedValue == "0")
             {
                 ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "test1", "alert('Please Select Option For Search')", true);
                 grdAll.DataSource = null;
                 grdAll.DataBind();
                 btnExport.Visible = false;
                 lbldiv.Visible = false;
             }
             else
             {
             
             if (txtFromDate.Text == "" && txtTodate.Text == "")
             {
                 fromDate = DateTime.MinValue;
                 toDate = DateTime.MinValue;
             }
             
             else if (txtFromDate.Text!= "" && txtTodate.Text == "")
            {
                fromDate = Convert.ToDateTime(txtFromDate.Text);
                toDate = DateTime.MinValue;
                ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "test1", "alert('Please Select Both Dates')", true);
            }
             else if (txtFromDate.Text == "" && txtTodate.Text != "")
             {
                 fromDate = DateTime.MinValue;
                 toDate = Convert.ToDateTime(txtTodate.Text);
                 ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "test1", "alert('Please Select Both Dates')", true);
             }
             else
             {
                 fromDate = Convert.ToDateTime(txtFromDate.Text);
                 toDate = Convert.ToDateTime(txtTodate.Text);
                 lblDate.Text = fromDate.Value.ToShortDateString() + " TO " + toDate.Value.ToShortDateString();
                 if (toDate < fromDate)
                 {
                     ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "test1", "alert('From Date Must Be Less Than To Date')", true);
                 }
             }
               if (ddlagentName.SelectedIndex > 0)
                {
                     agentName = ddlagentName.SelectedItem.Text;
                   
                }
                if (ddlCountryName.SelectedIndex > 0)
                {
                    countryName = ddlCountryName.SelectedItem.Text;
                    
                }
               
                List<MiscellaneousReportDOM> lstdom = new List<MiscellaneousReportDOM>();
                
            if (userId == Convert.ToInt32(UserType.Admin))
                {
                    LocId = 0;
                    lstdom = mislaneousReportBal.ReadMiscellaneousReport(fromDate, toDate, agentName, countryName,LocId);
                }
                else
                {
                    lstdom = mislaneousReportBal.ReadMiscellaneousReport(fromDate, toDate, agentName, countryName, LocId);
                }

            if ((txtFromDate.Text == "" && txtTodate.Text == "") || (txtFromDate.Text != "" && txtTodate.Text != ""))
            {
                if (lstdom.Count > 0)
                {
                    grdAll.DataSource = lstdom;
                    grdAll.DataBind();
                    btnExport.Visible = true;
                    
                }
                else
                {
                    grdAll.DataSource = null;
                    grdAll.DataBind();
                    btnExport.Visible = false;
                    lbldiv.Visible = false;
                    ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "test1", "alert('No Record Found')", true);
                }
                Session["lstdom"] = lstdom;
            }
             
             }
        }

        public void GetMiscllReportByConsolidated()
        {
            int LocId = basePage.LoggedInUser.UserLocation.LocationId;
            int userId = basePage.LoggedInUser.UserTypeId;
            DateTime? fromDate = null;
            DateTime? toDate = null;
             string countryName = null;
             
             if (txtFromDate.Text == "" && txtTodate.Text == "" && ddlagentName.SelectedValue == "0" && ddlCountryName.SelectedValue == "0")
             {
                 ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "test1", "alert('Please Select Option For Search')", true);
                 grdAll.DataSource = null;
                 grdAll.DataBind();
                 btnExport.Visible = false;
                 lbldiv.Visible = false;
             }
             else
             {
             
             if (txtFromDate.Text == "" && txtTodate.Text == "")
             {
                 fromDate = DateTime.MinValue;
                 toDate = DateTime.MinValue;
                 
             }
             
             else if (txtFromDate.Text!= "" && txtTodate.Text == "")
            {
                fromDate = Convert.ToDateTime(txtFromDate.Text);
                toDate = DateTime.MinValue;
                ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "test1", "alert('Please Select Both Dates')", true);
            }
             else if (txtFromDate.Text == "" && txtTodate.Text != "")
             {
                 fromDate = DateTime.MinValue;
                 toDate = Convert.ToDateTime(txtTodate.Text);
                 ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "test1", "alert('Please Select Both Dates')", true);
             }
             else
             {
                 fromDate = Convert.ToDateTime(txtFromDate.Text);
                 toDate = Convert.ToDateTime(txtTodate.Text);
                 lblDate.Text = fromDate.Value.ToShortDateString() + " TO " + toDate.Value.ToShortDateString();
                 if (toDate < fromDate)
                 {
                     ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "test1", "alert('From Date Must Be Less Than To Date')", true);
                 }
             }
             if (ddlCountryName.SelectedIndex > 0)
             {
                 countryName = ddlCountryName.SelectedItem.Text;

             }

             List<MiscellaneousReportDOM> lstdom = new List<MiscellaneousReportDOM>();

             if (userId == Convert.ToInt32(UserType.Admin))
             {
                 LocId = 0;
                 lstdom = mislaneousReportBal.ReadMiscellaneousReportByConsolidated(fromDate, toDate, countryName, LocId);
             }
             else
             {
                 lstdom = mislaneousReportBal.ReadMiscellaneousReportByConsolidated(fromDate, toDate, countryName, LocId);
             }

             if ((txtFromDate.Text == "" && txtTodate.Text == "") || (txtFromDate.Text != "" && txtTodate.Text != ""))
             {
                 if (lstdom.Count > 0)
                 {
                     grdAll.DataSource = lstdom;
                     grdAll.DataBind();
                     btnExport.Visible = true;
                     
                 }
                 else
                 {
                     grdAll.DataSource = null;
                     grdAll.DataBind();
                     btnExport.Visible = false;
                     lbldiv.Visible = false;
                     
                     ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "test1", "alert('No Record Found')", true);
                 }
                 Session["lstdom"] = lstdom;
             }

             }
        }

        #endregion


       
     

        

     

       

    
        #region Clear....

        public void Clear()
        {
            txtFromDate.Text = System.DateTime.Today.ToShortDateString();
            txtTodate.Text = System.DateTime.Today.ToShortDateString();
            ddlagentName.SelectedValue = "0";
            ddlCountryName.SelectedValue = "0";
            //grdAll.Visible = false;
        }
        #endregion

     

      
    }
}