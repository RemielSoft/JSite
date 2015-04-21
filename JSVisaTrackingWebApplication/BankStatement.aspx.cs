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
using JSVisaTrackingWebApplication.Shared;
using System.Globalization;

namespace JSVisaTrackingWebApplication
{
    public partial class BankStatement : System.Web.UI.Page
    {
        // Int64 TotalDebitAmt = 0;
        Decimal TotalDebitAmt = 0;
        //Int64 GrandTotalAmt = 0;
        decimal grandtotal = 0;
        decimal grandtt=0;
        BasePage basePage = new BasePage();
        BankStatementBusinessAccess banksatementbusiness = new BankStatementBusinessAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            btnBack.Visible = false;
            btnExport.Visible = false;
            lbl.Visible = false;
            if (!IsPostBack)
            {
                txt_fromDate.Text = System.DateTime.Today.ToShortDateString();
                txt_toDate.Text = System.DateTime.Today.ToShortDateString();
            }
        }

        protected void btnGO_Click(object sender, EventArgs e)
        {
            BankStatement bankstt = new BankStatement();
            DateTime fromDate = Convert.ToDateTime(txt_fromDate.Text.Trim());
            DateTime toDate = Convert.ToDateTime(txt_toDate.Text.ToString());
            ViewState["fromdate"] = fromDate;
            ViewState["todate"] = toDate;
            if (fromDate > toDate)
            {
                Response.Write("<Script Language=javascript>alert('From Date Must Be Less Than To Date ');</Script> ");
            }
            else if ((Chkicicibank.Checked == false) && (Chkobc.Checked == false) && (Chkall.Checked == false))
            {
                Response.Write("<Script Language=javascript>alert('Please Chek The BankName ');</Script>");
                tbl.Visible = true;
                lbl.Visible = false;
                btnExport.Visible = false;
               
                
            }
            else
            {
                BindGrid();
                if (grdBank.Rows.Count == 0)
                {
                    Response.Write("<Script Language=javascript>alert('Data Not Found.');</Script>");
                    tbl.Visible = true;
                    lbl.Visible = false;
                    Label1.Visible = false;
                    btnExport.Visible = false;
                    btnBack.Visible = false;
                   

                }
            }
            
        }
        public void BindGrid()
        {

            DateTime fromDate = Convert.ToDateTime(ViewState["fromdate"]);
            DateTime toDate = Convert.ToDateTime(ViewState["todate"]);
            List<Remielsoft.JetSave.DomianObjectModel.BankStatement> lstBank = new List<Remielsoft.JetSave.DomianObjectModel.BankStatement>();
            int LocId = basePage.LoggedInUser.UserLocation.LocationId;
            int userId = basePage.LoggedInUser.UserTypeId;
            if ((Chkicicibank.Checked == true) && (Chkobc.Checked == true))
            {
                string bankName = "BANK";


                if (userId == Convert.ToInt32(UserType.Admin))
                {
                    LocId = 0;
                   
                  lstBank = banksatementbusiness.readBankstatement(fromDate, toDate, bankName, LocId); ;
                    
                }
                else
                {
                    
                    lstBank = banksatementbusiness.readBankstatement(fromDate, toDate, bankName, LocId); ;
                  
                }
                for (int i = 0; i < lstBank.Count; i++)
                {
                    grandtotal += lstBank[i].DEBITAMOUNT;

                }
                Session["grandtot"] = grandtotal;
            
                grdBank.DataSource = lstBank;
                grdBank.DataBind();
                Label1.Text = "icici Bank and Obc Bank";
                lbl.Visible = true;
                btnExport.Visible = true;
                btnBack.Visible = true;
                tbl.Visible = false;
               
            }


            else if (Chkobc.Checked == true)
            {
                string bankName = "ORIENTAL BANK OF COMMERCE 4284";
                if (userId == Convert.ToInt32(UserType.Admin))
                {
                    LocId = 0;
                    lstBank = banksatementbusiness.readBankstatement(fromDate, toDate, bankName, LocId);
                   
                }
                else
                {
                    lstBank = banksatementbusiness.readBankstatement(fromDate, toDate, bankName, LocId);
                   
                }
                for (int i = 0; i < lstBank.Count; i++)
                {
                    grandtotal += lstBank[i].DEBITAMOUNT;

                }
                Session["grandtot"] = grandtotal;
            
                grdBank.DataSource = lstBank;
                grdBank.DataBind();
                Label1.Text = bankName;
                lbl.Visible = true;
                btnExport.Visible = true;
                tbl.Visible = false;
                btnBack.Visible = true;
            }
            else if (Chkicicibank.Checked == true)
            {
                string bankName = "ICICI BANK C/A";
                if (userId == Convert.ToInt32(UserType.Admin))
                {
                    LocId = 0;

                    lstBank = banksatementbusiness.readBankstatement(fromDate, toDate, bankName, LocId);
                   
                }
                else
                {
                    lstBank = banksatementbusiness.readBankstatement(fromDate, toDate, bankName, LocId);
                    
                }
                for (int i = 0; i < lstBank.Count; i++)
                {
                    grandtotal += lstBank[i].DEBITAMOUNT;

                }
                Session["grandtot"] = grandtotal;
            
                grdBank.DataSource = lstBank;
                grdBank.DataBind();
                Label1.Text = bankName;
                lbl.Visible = true;
                btnExport.Visible = true;
                tbl.Visible = false;
                btnBack.Visible = true;
               
            }
            else if (Chkall.Checked == true)
            {

                if (userId == Convert.ToInt32(UserType.Admin))
                {
                    LocId = 0;

                    lstBank = banksatementbusiness.readAllBank(fromDate, toDate, LocId);
                   
                }
                else
                {

                    lstBank = banksatementbusiness.readAllBank(fromDate, toDate, LocId);
                   
                }
                for (int i = 0; i < lstBank.Count; i++)
                {
                    grandtotal += lstBank[i].DEBITAMOUNT;

                }
                Session["grandtot"] = grandtotal;
            
                grdBank.DataSource = banksatementbusiness.readAllBank(fromDate, toDate, LocId);
                grdBank.DataBind();
                Label1.Text = "All Statement";
                lbl.Visible = true;
                btnExport.Visible = true;
                tbl.Visible = false;
                btnBack.Visible = true;
            }
            else
            {
                Response.Redirect("BankStatement.aspx");
            }
            
           
            

        }

        protected void grdBank_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                Label lblDebitAmt = (Label)e.Row.FindControl("lblDebitAmt");
                Label lblgrand = (Label)e.Row.FindControl("lblgrandtotal123");
               
                Decimal DebitAmt = Convert.ToDecimal(lblDebitAmt.Text);               
                TotalDebitAmt += DebitAmt;

               // grandtotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DEBITAMOUNT"));
                
                

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                
                e.Row.Cells[0].ColumnSpan = 6;
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells.RemoveAt(5);
                e.Row.Cells.RemoveAt(4);
                 e.Row.Cells.RemoveAt(3);
                e.Row.Cells.RemoveAt(2);
                e.Row.Cells.RemoveAt(1);
                //e.Row.Cells.RemoveAt(1);                
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                Label lblTotalDebit = (Label)e.Row.FindControl("lblTotalDebit");
                Label lblgrand = (Label)e.Row.FindControl("lblgrandtotal123");
               
                lblTotalDebit.Text = TotalDebitAmt.ToString();
               
                grandtt = Convert.ToDecimal(Session["grandtot"]);
                lblgrand.Text = grandtt.ToString(); 
              
                 
                
                    
                    

                
               
                
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=BankStatementReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.xls";
            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);
            HtmlTextWriter htm = new HtmlTextWriter(stringWriter);
            grdBank.AllowPaging = false;
            BindGrid();
            grdBank.FooterRow.HorizontalAlign = HorizontalAlign.Right;
            grdBank.HeaderRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            Label Total = (Label)grdBank.FooterRow.FindControl("lblTotal");
            Total.Visible = false;
            Label amount = (Label)grdBank.FooterRow.FindControl("lblTotalDebit");
            amount.Visible = false;
            lbl.RenderControl(htm);
            Label1.RenderControl(htm);
            grdBank.RenderControl(htm);
            Response.Write(stringWriter);
            Response.End();
            btnExport.Visible = false;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        protected void grdBank_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdBank.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void Chkall_CheckedChanged(object sender, EventArgs e)
        {
            Chkicicibank.Checked = false;
            Chkobc.Checked = false;
            Chkicicibank.Visible = false;
            Chkobc.Visible = false;

            if (Chkall.Checked == false)
            {
                Chkicicibank.Visible = true;
                Chkobc.Visible = true;
            }
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            txt_fromDate.Text = "";
            txt_toDate.Text = "";
            Chkobc.Checked = false;
            Chkicicibank.Checked = false;
            Chkall.Checked = false;
            Chkicicibank.Visible = true;
            Chkobc.Visible = true;
            Chkall.Visible = true;
        }
        protected void btnBack_Click1(object sender, EventArgs e)
        {
            Response.Redirect("BankStatement.aspx");
        }
    }
}