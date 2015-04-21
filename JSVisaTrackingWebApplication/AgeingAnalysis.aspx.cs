using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using JSVisaTrackingWebApplication.Shared;

namespace JSVisaTrackingWebApplication
{
    public partial class AgeingAnalysis : System.Web.UI.Page
    {
        #region Global Variable(s)

        Decimal TotalBillAmt = 0;
        Decimal TotalCreditAmt = 0;
        Decimal TotalBalance = 0;
        AgeingAnalysisBusinessAccess ageingBAL = new AgeingAnalysisBusinessAccess();
        ReceiptGenerationBusinessAccess rcptGenrBusinessAccess = new ReceiptGenerationBusinessAccess();
        SummaryReportBusinessAccess summaryBusinessAccess = new SummaryReportBusinessAccess();
        BasePage basePage = new BasePage();

        #endregion

        #region Protected Function(s)

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                int LocId = basePage.LoggedInUser.UserLocation.LocationId;
                int userId = basePage.LoggedInUser.UserTypeId;

                if (userId == Convert.ToInt32(UserType.Admin))
                {
                    LocId = 0;
                    basePage.BindDropDown(ddlAgent, "AgentName", "AgentId", summaryBusinessAccess.Agentbind(LocId,0));
                }
                else
                {
                    basePage.BindDropDown(ddlAgent, "AgentName", "AgentId", summaryBusinessAccess.Agentbind(LocId,basePage.LoggedInUser.AgentId));
                }
                
                //List<Agent> lstagent = rcptGenrBusinessAccess.AgentBind();
                //basePage.BindDropDown(ddlAgent, "AgentName", "AgentId", lstagent);

                Reset();
                btnExport.Visible = false;                
            }            
        }

        protected void btnAgeingAnalysis_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Summary.ValidationGroup = "a";
            }
            if (Convert.ToInt32(txtStartDay.Text) > Convert.ToInt32(txtEndDay.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('First No. Should Be Less Than Second No.');", true);
                Reset();
            }
            else
            {
                DateTime StartDate = DateTime.Today.AddDays(-Convert.ToInt32(txtEndDay.Text) + 1);
                DateTime LastDate = DateTime.Today.AddDays(-Convert.ToInt32(txtStartDay.Text) + 1);
                Int32 AgentId = Convert.ToInt32(ddlAgent.SelectedItem.Value);

                List<Remielsoft.JetSave.DomianObjectModel.AgeingAnalysis> lstAging = new List<Remielsoft.JetSave.DomianObjectModel.AgeingAnalysis>();
               
                System.Threading.Thread.Sleep(1000);

                int LocId = basePage.LoggedInUser.UserLocation.LocationId;
                int userId = basePage.LoggedInUser.UserTypeId;
                if (userId == Convert.ToInt32(UserType.Admin))
                {
                    LocId = 0;
                    lstAging = ageingBAL.ReadAnalysis(StartDate, LastDate, AgentId, LocId);
                }
                else
                {
                    lstAging = ageingBAL.ReadAnalysis(StartDate, LastDate, AgentId, LocId);
                }
                
                Session["lstAging"] = lstAging;

                if (lstAging.Count == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('No Record Found Of This Agent Or With These Days.');", true);
                    txtStartDay.Focus();
                }
                else
                {
                    GridBind();
                    btnExport.Visible = true;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
            btnExport.Visible = false;
        }

        protected void grdvAgeingAnalysis_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblBillAmount = (Label)e.Row.FindControl("lblBillAmount");
                Label lblUnallocatedCredit = (Label)e.Row.FindControl("lblUnallocatedCredit");
                Label lblBalance = (Label)e.Row.FindControl("lblBalance");

                Decimal BillAmt = Convert.ToDecimal(lblBillAmount.Text);
                Decimal CreditAmt = Convert.ToDecimal(lblUnallocatedCredit.Text);
                Decimal Balance = Convert.ToDecimal(lblBalance.Text);

                TotalBalance += Balance;
                TotalBillAmt += BillAmt;
                TotalCreditAmt += CreditAmt;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].ColumnSpan = 2;
                e.Row.Cells.RemoveAt(1);
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;

                Label lblTotalBillAmount = (Label)e.Row.FindControl("lblTotalBillAmount");
                Label lblTotalUnallocatedCredit = (Label)e.Row.FindControl("lblTotalUnallocatedCredit");
                Label lblTotalBalance = (Label)e.Row.FindControl("lblTotalBalance");

                lblTotalBalance.Text = TotalBalance.ToString();
                lblTotalBillAmount.Text = TotalBillAmt.ToString();
                lblTotalUnallocatedCredit.Text = TotalCreditAmt.ToString();
            }
        }

        protected void AddMergedCells(GridViewRow objgridviewrow, TableCell objtablecell, int colspan, string celltext, string backcolor)
        {
            objtablecell = new TableCell();
            objtablecell.Text = celltext;
            objtablecell.ColumnSpan = colspan;
            objtablecell.Style.Add("background-color", backcolor);
            objtablecell.Font.Bold = true;
            objtablecell.ForeColor = System.Drawing.Color.Black;
            objtablecell.HorizontalAlign = HorizontalAlign.Center;
            objgridviewrow.Cells.Add(objtablecell);
        }

        protected void grdvAgeingAnalysis_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView objGridView = (GridView)sender;
                GridViewRow objgridviewrow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell objtablecell = new TableCell();

                #region Merge cells

                AddMergedCells(objgridviewrow, objtablecell, 5, "Receivable By Aging Analysis", System.Drawing.Color.White.Name);
                objGridView.Controls[0].Controls.AddAt(0, objgridviewrow);

                #endregion
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=AgingAnalysisReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.xls";

            StringBuilder sb = new StringBuilder();
            StringWriter stringWrite = new StringWriter(sb);
            HtmlTextWriter htm = new HtmlTextWriter(stringWrite);
            grdvAgeingAnalysis.AllowPaging = false;

            this.GridBind();
            grdvAgeingAnalysis.HeaderRow.BackColor = System.Drawing.Color.White;
            grdvAgeingAnalysis.FooterRow.BackColor = System.Drawing.Color.White;
            grdvAgeingAnalysis.FooterRow.ForeColor = System.Drawing.Color.Black;
            grdvAgeingAnalysis.FooterRow.HorizontalAlign = HorizontalAlign.Right;

            grdvAgeingAnalysis.RenderControl(htm);
            Response.Write(stringWrite);
            Response.Flush();
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        #endregion

        #region Public Function(s)

        public void GridBind()
        {
            List<Remielsoft.JetSave.DomianObjectModel.AgeingAnalysis> lstAging = (List<Remielsoft.JetSave.DomianObjectModel.AgeingAnalysis>)Session["lstAging"];
            grdvAgeingAnalysis.DataSource = lstAging;
            grdvAgeingAnalysis.DataBind();
        }

        public void Reset()
        {
            txtEndDay.Text = string.Empty;
            txtStartDay.Text = string.Empty;
            grdvAgeingAnalysis.DataSource = null;
            grdvAgeingAnalysis.DataBind();
            ddlAgent.SelectedValue = "0";
        }

        #endregion
    }
}