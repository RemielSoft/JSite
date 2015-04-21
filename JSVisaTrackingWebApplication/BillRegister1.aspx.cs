using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data.Common;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using JSVisaTrackingWebApplication.Shared;
using Remielsoft.JetSave.DomianObjectModel;

namespace JSVisaTrackingWebApplication
{
    public partial class BillRegister1 : System.Web.UI.Page
    {

        #region Global Variable(s)

        Decimal totalVisa = 0;
        Decimal totalAttestation = 0;
        Decimal totalToken = 0;
        Decimal totalVfs = 0;
        Decimal totalHandling = 0;
        Decimal totalCourior = 0;
        Decimal totalDelivery = 0;
        Decimal totalConvenience = 0;
        Decimal totalUrgent = 0;
        Decimal totalDraft = 0;
        Decimal totalInsurance = 0;
        Decimal totalOther = 0;
        Decimal totalService = 0;
        Decimal totalserviceTax = 0;
        Decimal totalAmount = 0;
        int LocId = 0;
        BillRegisterBusinessAccess billRegisterBal = new BillRegisterBusinessAccess();
        SummaryReportBusinessAccess summaryBusinessAccess = new SummaryReportBusinessAccess();
        List<Remielsoft.JetSave.DomianObjectModel.BillRegister> lst = new List<Remielsoft.JetSave.DomianObjectModel.BillRegister>();
        BasePage basePage = new BasePage();

        #endregion
        #region Protected Method(s)

        protected void Page_Load(object sender, EventArgs e)
        {


            var ses = Session["List"];

            if (!IsPostBack)
            {
                if (basePage.LoggedInUser.UserLocation != null)
                {
                    LocId = basePage.LoggedInUser.UserLocation.LocationId;
                }
                int userId = basePage.LoggedInUser.UserTypeId;

                if (userId == Convert.ToInt32(UserType.Admin))
                {
                    // LocId = 0;
                    basePage.BindDropDown(ddlAgentName, "AgentName", "AgentId", summaryBusinessAccess.Agentbind(LocId, 0));
                }
                else
                {
                    basePage.BindDropDown(ddlAgentName, "AgentName", "AgentId", summaryBusinessAccess.Agentbind(LocId, basePage.LoggedInUser.AgentId));
                    ddlAgentName.SelectedValue = basePage.LoggedInUser.AgentId.ToString();
                    ddlAgentName.Enabled = false;

                }
                Reset();
                BindGrid();
                btnExport.Visible = false;
                btnBack.Visible = false;

                txt_fromBill.Visible = false;
                txt_toBill.Visible = false;
                lblbillnofrom.Visible = false;
                lblbillnoTo.Visible = false;

            }
            if (ses != null)
            {
                lblbri.Text = "Bill Summary Information";
                btnExport.Visible = true;
            }
            else
            {
                btnExport.Visible = false;

            }

        }

        public void BindGrid()
        {
            if (Request.QueryString["List"] != null)
            {
                List<Remielsoft.JetSave.DomianObjectModel.BillRegister> lst = (List<Remielsoft.JetSave.DomianObjectModel.BillRegister>)Session["List"];

                gv_billRegister.DataSource = lst;
                gv_billRegister.DataBind();
            }
        }

        protected void gv_billRegister_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.HorizontalAlign = HorizontalAlign.Right;

                Label lbl_visacharge = (Label)e.Row.FindControl("lbl_visacharge");
                Label lbl_attestation = (Label)e.Row.FindControl("lbl_attestation");
                Label lbl_token = (Label)e.Row.FindControl("lbl_token");
                Label lbl_vfs = (Label)e.Row.FindControl("lbl_vfs");
                Label lbl_handling = (Label)e.Row.FindControl("lbl_handling");
                Label lbl_courier = (Label)e.Row.FindControl("lbl_courier");
                Label lbl_Delivery = (Label)e.Row.FindControl("lbl_Delivery");
                Label lbl_Convenience = (Label)e.Row.FindControl("lbl_Convenience");
                Label lbl_Urgent = (Label)e.Row.FindControl("lbl_Urgent");
                Label lbl_Draft = (Label)e.Row.FindControl("lbl_Draft");
                Label lbl_Insurance = (Label)e.Row.FindControl("lbl_Insurance");
                Label lbl_OtherCharges = (Label)e.Row.FindControl("lbl_OtherCharges");
                Label lbl_ServiceTax = (Label)e.Row.FindControl("lbl_ServiceTax");
                Label lbl_ServiceCharge = (Label)e.Row.FindControl("lbl_ServiceCharge");
                Label lbl_Amount = (Label)e.Row.FindControl("lbl_Amount");

                Decimal visa = Convert.ToDecimal(lbl_visacharge.Text);
                Decimal attestation = Convert.ToDecimal(lbl_attestation.Text);
                Decimal token = Convert.ToDecimal(lbl_token.Text);
                Decimal Vfs = Convert.ToDecimal(lbl_vfs.Text);
                Decimal handling = Convert.ToDecimal(lbl_handling.Text);
                Decimal courior = Convert.ToDecimal(lbl_courier.Text);
                Decimal delivery = Convert.ToDecimal(lbl_Delivery.Text);
                Decimal convenience = Convert.ToDecimal(lbl_Convenience.Text);
                Decimal urgent = Convert.ToDecimal(lbl_Urgent.Text);
                Decimal draft = Convert.ToDecimal(lbl_Draft.Text);
                Decimal insurance = Convert.ToDecimal(lbl_Insurance.Text);
                Decimal otherCh = Convert.ToDecimal(lbl_OtherCharges.Text);
                Decimal servive = Convert.ToDecimal(lbl_ServiceCharge.Text);
                Decimal serviceTax = Convert.ToDecimal(lbl_ServiceTax.Text);
                Decimal amount = Convert.ToDecimal(lbl_Amount.Text);

                totalVisa += visa;
                totalAttestation += attestation;
                totalToken += token;
                totalVfs += Vfs;
                totalHandling += handling;
                totalCourior += courior;
                totalDelivery += delivery;
                totalConvenience += convenience;
                totalUrgent += urgent;
                totalDraft += draft;
                totalInsurance += insurance;
                totalOther += otherCh;
                totalService += servive;
                totalserviceTax += serviceTax;
                totalAmount += amount;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].ColumnSpan = 5;
                //e.Row.Cells[0].Text = "Page Total";
                e.Row.Cells[0].Font.Bold = true;
                //e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells.RemoveAt(4);
                e.Row.Cells.RemoveAt(3);
                e.Row.Cells.RemoveAt(2);
                e.Row.Cells.RemoveAt(1);

                Label lblTotalvisa = (Label)e.Row.FindControl("lblTotalvisa");
                Label lblTotalAttestation = (Label)e.Row.FindControl("lblTotalAttestation");
                Label lblTotalToken = (Label)e.Row.FindControl("lblTotalToken");
                Label lblTotalVFS = (Label)e.Row.FindControl("lblTotalVFS");
                Label lblTotalHandling = (Label)e.Row.FindControl("lblTotalHandling");
                Label lblTotalCourior = (Label)e.Row.FindControl("lblTotalCourior");
                Label lblTotalDelivery = (Label)e.Row.FindControl("lblTotalDelivery");
                Label lblTotalConvenience = (Label)e.Row.FindControl("lblTotalConvenience");
                Label lblTotalUrgent = (Label)e.Row.FindControl("lblTotalUrgent");
                Label lblTotalDraft = (Label)e.Row.FindControl("lblTotalDraft");
                Label lblTotalInsurance = (Label)e.Row.FindControl("lblTotalInsurance");
                Label lblTotalOther = (Label)e.Row.FindControl("lblTotalOther");
                Label lblTotalService = (Label)e.Row.FindControl("lblTotalService");
                Label lblTotalServiceTax = (Label)e.Row.FindControl("lblTotalServiceTax");
                Label lblTotalAmount = (Label)e.Row.FindControl("lblTotalAmount");
                lblTotalvisa.Text = totalVisa.ToString();
                lblTotalAttestation.Text = totalAttestation.ToString();
                lblTotalToken.Text = totalToken.ToString();
                lblTotalVFS.Text = totalVfs.ToString();
                lblTotalHandling.Text = totalHandling.ToString();
                lblTotalCourior.Text = totalCourior.ToString();
                lblTotalDelivery.Text = totalDelivery.ToString();
                lblTotalConvenience.Text = totalConvenience.ToString();
                lblTotalUrgent.Text = totalUrgent.ToString();
                lblTotalDraft.Text = totalDraft.ToString();
                lblTotalInsurance.Text = totalInsurance.ToString();
                lblTotalOther.Text = totalOther.ToString();
                lblTotalService.Text = totalService.ToString();
                lblTotalServiceTax.Text = totalserviceTax.ToString();
                lblTotalAmount.Text = totalAmount.ToString();


            }
        }

        protected void gv_billRegister_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView objGridView = (GridView)sender;
                GridViewRow objgridviewrow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell objtablecell = new TableCell();

                #region Merge cells

                AddMergedCells(objgridviewrow, objtablecell, 20, "Bill Summary Report", System.Drawing.Color.White.Name);
                objGridView.Controls[0].Controls.AddAt(0, objgridviewrow);

                #endregion
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=BillRegisterInformationReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.xls";

            StringBuilder sb = new StringBuilder();
            StringWriter stringWrite = new StringWriter(sb);
            HtmlTextWriter htm = new HtmlTextWriter(stringWrite);
            gv_billRegister.AllowPaging = false;
            //grid_search.Columns.RemoveAt(8);


            BindGrid();
            gv_billRegister.HeaderRow.BackColor = System.Drawing.Color.White;
            gv_billRegister.FooterRow.BackColor = System.Drawing.Color.White;
            gv_billRegister.FooterRow.ForeColor = System.Drawing.Color.Black;

            //gvSample is Gridview server control

            gv_billRegister.RenderControl(htm);
            Response.Write(stringWrite);
            Response.End();

            btnExport.Visible = false;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // base.VerifyRenderingInServerForm(control);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("BillRegister.aspx");
        }

        #endregion

        #region Public Methods



        public void AddMergedCells(GridViewRow objgridviewrow, TableCell objtablecell, int colspan, string celltext, string backcolor)
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


        protected void btnGo_Click(object sender, EventArgs e)
        {

            lblbri.Text = "Bill Summary Information";
            btnExport.Visible = true;
            int AgentId = Convert.ToInt32(ddlAgentName.SelectedItem.Value);
            if (rbtnlstSearch.SelectedItem.Value == "1")
            {
                if (txt_fromDate.Text != "" && txt_toDate.Text != "")
                {
                    DateTime fromdate = Convert.ToDateTime(txt_fromDate.Text);
                    DateTime todate = Convert.ToDateTime(txt_toDate.Text);
                    var totalDays = (todate - fromdate).TotalDays;
                    if (fromdate > todate)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('From Date Must Be Less Or Equal To To Date.');", true);
                        txt_fromDate.Focus();
                    }
                    else
                    {
                        if (basePage.LoggedInUser.UserLocation != null)
                        {
                            LocId = basePage.LoggedInUser.UserLocation.LocationId;
                        }
                        int userId = basePage.LoggedInUser.UserTypeId;

                        // List<Remielsoft.JetSave.DomianObjectModel.BillRegister> lst = new List<Remielsoft.JetSave.DomianObjectModel.BillRegister>();

                        if (userId == Convert.ToInt32(UserType.Admin))
                        {
                            LocId = 0;
                            lst = billRegisterBal.BillRegisterInfoByDate(fromdate, todate, AgentId, LocId);
                        }
                        else
                        {
                            if (totalDays <= 30)
                            {
                                lst = billRegisterBal.BillRegisterInfoByDate(fromdate, todate, AgentId, LocId);
                            }
                            else
                            {
                                Response.Write("<script LANGUAGE='JavaScript' >alert('You Con seen only one month invoice.')</script>");
                            }
                        }
                        Session["List"] = lst;
                        if (lst.Count == 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('There Are No Record With These Dates.');", true);
                            btnExport.Visible = false;
                            lblbri.Visible = false;
                            txt_fromDate.Focus();
                            Reset();
                            btnExport.Visible = false;
                        }
                        else
                        {
                            Response.Redirect("BillRegister.aspx?List=" + lst);
                            Reset();
                            btnExport.Visible = true;
                        }
                    }
                }
                else if (ddlAgentName.SelectedValue != null)
                {
                    DateTime? fromdate = null;
                    DateTime? todate = null;
                    if (basePage.LoggedInUser.UserLocation != null)
                    {
                        LocId = basePage.LoggedInUser.UserLocation.LocationId;
                    }
                    int userId = basePage.LoggedInUser.UserTypeId;

                    // List<Remielsoft.JetSave.DomianObjectModel.BillRegister> lst = new List<Remielsoft.JetSave.DomianObjectModel.BillRegister>();

                    if (userId == Convert.ToInt32(UserType.Admin))
                    {
                        LocId = 0;
                        lst = billRegisterBal.BillRegisterInfoByDate(fromdate, todate, AgentId, LocId);
                    }
                    else
                    {
                        lst = billRegisterBal.BillRegisterInfoByDate(fromdate, todate, AgentId, LocId);
                    }
                    Session["List"] = lst;
                    if (lst.Count == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('There Are No Any Record of the Agent...');", true);
                        txt_fromDate.Focus();
                        Reset();
                        btnExport.Visible = false;
                    }
                    else
                    {
                        Response.Redirect("BillRegister.aspx?List=" + lst);
                        Reset();
                        btnExport.Visible = true;
                    }

                }
                else
                {

                }
            }

            if (rbtnlstSearch.SelectedItem.Value == "2")
            {
                int frombill = Convert.ToInt32(txt_fromBill.Text);
                int tobill = Convert.ToInt32(txt_toBill.Text);

                if (frombill > tobill)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('Bill No. From Must Be Less Or Equal To Bill No. To.');", true);
                    txt_fromDate.Focus();
                }
                else
                {
                    if (basePage.LoggedInUser.UserLocation != null)
                    {
                        LocId = basePage.LoggedInUser.UserLocation.LocationId;
                    }
                    int userId = basePage.LoggedInUser.UserTypeId;

                    List<Remielsoft.JetSave.DomianObjectModel.BillRegister> lst = new List<Remielsoft.JetSave.DomianObjectModel.BillRegister>();

                    if (userId == Convert.ToInt32(UserType.Admin))
                    {
                        LocId = 0;
                        lst = billRegisterBal.BillRegisterInfoFromBillNo(frombill, tobill, AgentId, LocId);
                    }
                    else
                    {
                        lst = billRegisterBal.BillRegisterInfoFromBillNo(frombill, tobill, AgentId, LocId);
                    }
                    //lst = billRegisterBal.BillRegisterInfoFromBillNo(frombill, tobill, AgentId);
                    Session["List"] = lst;
                    if (lst.Count == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('There Are No Record With These Bill Nos.');", true);
                        txt_fromBill.Focus();
                        Reset();
                    }
                    else
                    {
                        Response.Redirect("BillRegister.aspx?List=" + lst);
                        Reset();
                        btnExport.Visible = true;
                    }
                }
            }
        }
        protected void rbtnlstSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtnlstSearch.SelectedValue == "1")
            {
                divfromdate.Visible = true;
                divtodate.Visible = true;
                lblFromDate.Visible = true;
                lblToDate.Visible = true;
                FromDateSpan.Visible = true;
                ToDateSpan.Visible = true;
                //RFV1.Visible = true;
                //RFV2.Visible = true;
                RFV3.Visible = false;
                RFV4.Visible = false;
                CV1.Visible = false;
                CV2.Visible = false;

                txt_fromBill.Visible = false;
                txt_toBill.Visible = false;
                lblbillnofrom.Visible = false;
                lblbillnoTo.Visible = false;

                btnGo.ValidationGroup = "a";
                //  RFV5.ValidationGroup = "a";
                if (!IsPostBack)
                {
                    BillRegisterSummry.ValidationGroup = "a";
                }
            }
            if (rbtnlstSearch.SelectedValue == "2")
            {

                lblFromDate.Visible = false;
                lblToDate.Visible = false;
                divfromdate.Visible = false;
                divtodate.Visible = false;
                FromDateSpan.Visible = false;
                ToDateSpan.Visible = false;
                //RFV1.Visible = false;
                //RFV2.Visible = false;
                RFV3.Visible = true;
                RFV4.Visible = true;
                CV1.Visible = true;
                CV2.Visible = true;

                txt_fromBill.Enabled = true;
                txt_toBill.Enabled = true;
                btnGo.ValidationGroup = "b";
                //RFV5.ValidationGroup = "b";
                txt_fromBill.Visible = true;
                txt_toBill.Visible = true;
                lblbillnofrom.Visible = true;
                lblbillnoTo.Visible = true;
                if (!IsPostBack)
                {
                    BillRegisterSummry.ValidationGroup = "b";
                }
            }
        }

        protected void btnCnacel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        #endregion

        #region Public Methods

        //public void BindDDLAgnet()
        //{
        //    Int32 LocationId = Convert.ToInt32(Session["LocationId"]);
        //    //ddlAgentName.DataSource = billRegisterBal.BindAgentDropDown(LocationId);
        //    ddlAgentName.DataSource = billRegisterBal.BindAgentDropDown();
        //    ddlAgentName.DataTextField = "AgentName";
        //    ddlAgentName.DataValueField = "AgentId";
        //    ddlAgentName.DataBind();
        //    ddlAgentName.Items.Insert(0, new ListItem("--Select Agent--", "0"));
        //}

        public void Reset()
        {

            rbtnlstSearch.SelectedValue = "1";
            // ddlAgentName.SelectedValue = "0";
            txt_fromBill.Text = string.Empty;
            // txt_fromDate.Text = System.DateTime.Today.ToShortDateString();
            // txt_toDate.Text = System.DateTime.Today.ToShortDateString();
            txt_toBill.Text = string.Empty;
            divfromdate.Visible = true;
            divtodate.Visible = true;
            lblFromDate.Visible = true;
            lblToDate.Visible = true;
            FromDateSpan.Visible = true;
            ToDateSpan.Visible = true;
            //RFV1.Visible = true;
            //RFV2.Visible = true;
            RFV3.Visible = false;
            RFV4.Visible = false;
            CV1.Visible = false;
            CV2.Visible = false;

            txt_fromBill.Enabled = false;
            txt_toBill.Enabled = false;

            btnGo.ValidationGroup = "a";
            //RFV5.ValidationGroup = "a";
            if (IsPostBack)
            {
                BillRegisterSummry.ValidationGroup = "a";
            }
        }

        #endregion
    }
}