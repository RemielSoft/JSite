using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Text;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.Globalization;
using JSVisaTrackingWebApplication.Shared;

namespace JSVisaTrackingWebApplication
{
    public partial class SummaryReport : System.Web.UI.Page
    {
        BasePage basePage = new BasePage();
        SummaryReportBusinessAccess summaryBusinessAccess = new SummaryReportBusinessAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int LocId = basePage.LoggedInUser.UserLocation.LocationId;
                int userId = basePage.LoggedInUser.UserTypeId;
                if (userId == Convert.ToInt32(UserType.Admin))
                {
                    LocId = 0;
                    basePage.BindDropDown(ddlPartyName, "AgentName", "AgentId", summaryBusinessAccess.Agentbind(LocId,0));
                }
                else
                {
                    basePage.BindDropDown(ddlPartyName, "AgentName", "AgentId", summaryBusinessAccess.Agentbind(LocId,basePage.LoggedInUser.AgentId));
                }
                
                DivExport.Visible = false;
                tbl2.Visible = false;
                divsearch.Visible = true;
            }
        }

        protected void btnGO_Click(object sender, EventArgs e)
        {
           
            DateTime fromdate = Convert.ToDateTime(txt_fromDate.Text.Trim());
            DateTime todate = Convert.ToDateTime(txt_toDate.Text.Trim());
            ViewState["fromdate"] = fromdate;
            ViewState["todate"] = todate;
            if (fromdate > todate)
            {
                Response.Write("<Script Language=javascript>alert('From Date Must Be Less Than To Date ');</Script> "); 
             }
            else
            {

                gried();
                if (grdsummary.Rows.Count == 0)
                {
                    Response.Write("<Script Language=javascript>alert('Data Not Found.');</Script>");
                    tbl1.Visible = true;
                    DivExport.Visible = false;
                    tbl2.Visible = false;
                    divsearch.Visible = true;
                 }
                  

                else
                {
                    //gried();
                    tbl1.Visible = false;
                    DivExport.Visible = true;
                    tbl2.Visible = true;
                    divsearch.Visible = false;
                    
                }
                
            }
            
            
        }
        public void gried()
        {
            summaryReport summarReport = new summaryReport();
            List<summaryReport> lstSummary = new List<summaryReport>();
            DateTime fromdate = Convert.ToDateTime(ViewState["fromdate"]);
            DateTime todate = Convert.ToDateTime(ViewState["todate"]);
            int AgentIds = Convert.ToInt32(ddlPartyName.SelectedItem.Value);
            int LocId = basePage.LoggedInUser.UserLocation.LocationId;
            int userId = basePage.LoggedInUser.UserTypeId;
            if (userId == Convert.ToInt32(UserType.Admin))
            {
                LocId = 0;
                lstSummary=summaryBusinessAccess.readReport(fromdate, todate, AgentIds, LocId);
            }
            else
            {
                lstSummary = summaryBusinessAccess.readReport(fromdate, todate, AgentIds, LocId);
            }

            grdsummary.DataSource = lstSummary;

            grdsummary.DataBind();

            lblPartyName.Text = ddlPartyName.SelectedItem.Text;
            lbldate.Text = (txt_fromDate.Text)+" To "+(txt_toDate.Text);
           

        }

        protected void btncancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("SummaryReport.aspx");
        }


        protected void grdsummary_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdsummary.PageIndex = e.NewPageIndex;
            gried();
        }

        protected void btnexport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=SummaryReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.xls";
            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);
            HtmlTextWriter htm = new HtmlTextWriter(stringWriter);
            grdsummary.AllowPaging = false;
            gried();
            Label1.RenderControl(htm);
            lblPartyName.RenderControl(htm);
            Label2.RenderControl(htm);
            lbldate.RenderControl(htm);
            grdsummary.RenderControl(htm);
            Response.Write(stringWriter);
            Response.End();
            btnexport.Visible = false;
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            txt_fromDate.Text = "";
            txt_toDate.Text = "";
            ddlPartyName.ClearSelection();
        }

        //protected void grdsummary_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    GridViewRow row = e.Row;
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        row.Cells[5].Text = row.Cells[5].Text.Replace("====================", "<br />");
        //    }
        //}

        }
    }
