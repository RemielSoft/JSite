using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.Web.Configuration;
using JSVisaTrackingWebApplication.Shared;
using System.IO;
using System.Net;
using System.Web.UI.HtmlControls;
namespace JSVisaTrackingWebApplication
{
    public partial class StatementOfAccount : System.Web.UI.Page
    {

         #region Global Variables....

        decimal debit = 0, credit = 0, balance = 0;
        BasePage basePage = new BasePage();
        List<StatementOfAccDom> lst = new List<StatementOfAccDom>();
        StatementOfAccBAL stmtOfAccBal = new StatementOfAccBAL();
       SummaryReportBusinessAccess summaryBusinessAccess=new SummaryReportBusinessAccess();

        #endregion

         #region private_methods...

       protected void Page_Load(object sender, EventArgs e)
       {
           if (!IsPostBack)
           {
               btnExport.Visible = false;
               tblSecond.Visible = false;
               txtfrmdate.Text = System.DateTime.Today.ToShortDateString();
               txttodate.Text = System.DateTime.Today.ToShortDateString();

               int LocId = basePage.LoggedInUser.UserLocation.LocationId;
               int userId = basePage.LoggedInUser.UserTypeId;
               if (userId == Convert.ToInt32(UserType.Admin))
               {
                   LocId = 0;
                   basePage.BindDropDown(ddlagentList, "AgentName", "AgentId", summaryBusinessAccess.Agentbind(LocId,0));
               }
               else
               {
                   basePage.BindDropDown(ddlagentList, "AgentName", "AgentId", summaryBusinessAccess.Agentbind(LocId,basePage.LoggedInUser.AgentId));
               }

           }
       }

       protected void btndisplay_Click(object sender, EventArgs e)
       {

           StatementOfAccDom stateDom = new StatementOfAccDom();
           int agentId = Convert.ToInt32(ddlagentList.SelectedItem.Value);
           DateTime FromDate = Convert.ToDateTime(txtfrmdate.Text);
           DateTime ToDate = Convert.ToDateTime(txttodate.Text);
           lblStatDate.Text = FromDate.ToShortDateString() + "  To " + ToDate.ToShortDateString();
           lblPartyName.Text = ddlagentList.SelectedItem.Text;
           int LocId = basePage.LoggedInUser.UserLocation.LocationId;
           int userId = basePage.LoggedInUser.UserTypeId;

           if (ToDate < FromDate)
           {
               Response.Write("<Script language='javascript'>alert('From Date Must Be Less Than To Date')</Script>");
               grdStatement.DataSource = null;
               grdStatement.DataBind();
           }

           foreach (ListItem listItem in ddlagentList.Items)
           {
               if (listItem != null)
               {

                   List<StatementOfAccDom> lstAgentAddrs = stmtOfAccBal.ReadAgentAddress(agentId);

                   lblPartyAddress.Text = lstAgentAddrs[0].AgentAddress.ToString();
                   lblOpenBalance.Text = lstAgentAddrs[0].BalanceOpening.ToString();

               }


           }

           if (userId == Convert.ToInt32(UserType.Admin))
           {
               LocId = 0;
               lst = stmtOfAccBal.ReadStatementofAccById(agentId, FromDate, ToDate, LocId);
           }
           else
           {
               lst = stmtOfAccBal.ReadStatementofAccById(agentId, FromDate, ToDate, LocId);
           }

           if (lst.Count != 0)
           {

               List<StatementOfAccDom> lstNew = new List<StatementOfAccDom>();
               decimal balance = 0;

               for (int i = 0; i < lst.Count; i++)
               {

                   StatementOfAccDom stmtDom = new StatementOfAccDom();
                   if (i == 0)
                   {
                       stmtDom.DocDate = lst[i].DocDate;
                       stmtDom.Narration = lst[i].Narration;
                       stmtDom.Particular = lst[i].Particular;
                       stmtDom.CrAmount = lst[i].CrAmount;
                       stmtDom.DrAmount = lst[i].DrAmount;
                       decimal OpeningBalance = Convert.ToDecimal(lblOpenBalance.Text);
                       stmtDom.Balance = ((OpeningBalance + stmtDom.DrAmount) - stmtDom.CrAmount);
                       balance = stmtDom.Balance;
                       lstNew.Add(stmtDom);
                   }
                   else
                   {
                       stmtDom.DocDate = lst[i].DocDate;
                       stmtDom.Narration = lst[i].Narration;
                       stmtDom.Particular = lst[i].Particular;
                       stmtDom.CrAmount = lst[i].CrAmount;
                       stmtDom.DrAmount = lst[i].DrAmount;
                       decimal OpeningBalance = Convert.ToDecimal(lblOpenBalance.Text);
                       stmtDom.Balance = balance + stmtDom.DrAmount - stmtDom.CrAmount;
                       balance = stmtDom.Balance;
                       lstNew.Add(stmtDom);
                   }

               }
               grdStatement.DataSource = lstNew;
               grdStatement.DataBind();

               Session["lstnew"] = lstNew;

               //btndisplay.Visible = true;
               //btnCancel.Visible = true;
               tblSecond.Visible = true;
               //tblFirst.Visible = true;
               btnExport.Visible = true;
               grdStatement.Visible = true;

           }
           else
           {
               Response.Write("<Script language='javascript'>alert('No Record Found ')</Script>");
               grdStatement.DataSource = null;
               grdStatement.DataBind();

               //btndisplay.Visible = true;
               //btnCancel.Visible = true;
               tblSecond.Visible = false;
               //tblFirst.Visible = true;
               btnExport.Visible = false;
               grdStatement.Visible = true;
           }

           //Clear();
       }

       protected void btnCancel_Click(object sender, EventArgs e)
       {

           ddlagentList.SelectedValue = "0";

           txtfrmdate.Text = System.DateTime.Today.ToShortDateString();
           txttodate.Text = System.DateTime.Today.ToShortDateString();


       }

       protected void btnExport_Click(object sender, EventArgs e)
       {
           List<StatementOfAccDom> lstStmtAct = (List<StatementOfAccDom>)Session["lstnew"];
           try
           {
               Response.Clear();
               Response.ClearHeaders();
               Response.AddHeader("content-disposition", "attachment;filename=StatementOfAccount.xls");
               Response.Charset = "";
               Response.ContentType = "application/vnd.xls";
               StringBuilder sb = new StringBuilder();
               StringWriter stringWrite = new StringWriter(sb);
               HtmlTextWriter htm = new HtmlTextWriter(stringWrite);
               grdStatement.AllowPaging = false;
               //grid_search.Columns.RemoveAt(8);
               grdStatement.DataSource = lstStmtAct;
               grdStatement.DataBind();
               //gvSample is Gridview server control
               grdStatement.RenderControl(htm);
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

       protected void grdStatement_RowDataBound(object sender, GridViewRowEventArgs e)
       {
           if (e.Row.RowType == DataControlRowType.DataRow)
           {

               Label lbldebit = (Label)e.Row.FindControl("lbldebit");
               Label lblcredit = (Label)e.Row.FindControl("lblcredit");
               Label lblbalance = (Label)e.Row.FindControl("lblbalance");
               decimal lblDEBIT = Convert.ToDecimal(lbldebit.Text);
               decimal lblCREDIT = Convert.ToDecimal(lblcredit.Text);
               decimal lblBALANCE = Convert.ToDecimal(lblbalance.Text);
               debit += lblDEBIT;
               credit += lblCREDIT;
               balance += lblBALANCE;
           }

           if (e.Row.RowType == DataControlRowType.Footer)
           {
               e.Row.Cells[1].Font.Bold = true;
               Label lblDrAmt = (Label)e.Row.FindControl("lblDrAmt");
               lblDrAmt.Text = debit.ToString();
               Label lblCrAmt = (Label)e.Row.FindControl("lblCrAmt");
               lblCrAmt.Text = credit.ToString();
               Label lblBALANCE = ((Label)e.Row.FindControl("lblBALANCE"));
               lblBALANCE.Text = balance.ToString();


           }
       }

       protected void grdStatement_PageIndexChanging(object sender, GridViewPageEventArgs e)
       {
           List<StatementOfAccDom> lstdom = (List<StatementOfAccDom>)Session["lstnew"];
           grdStatement.PageIndex = e.NewPageIndex;
           grdStatement.DataSource = lstdom;
           grdStatement.DataBind();

       }

       #endregion

         #region public_methods..

       public void Clear()
       {
           txtfrmdate.Text = System.DateTime.Today.ToShortDateString();
           txttodate.Text = System.DateTime.Today.ToShortDateString();
           ddlagentList.SelectedValue = "0";

       }

       #endregion
       
    }
}