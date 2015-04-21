using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using JSVisaTrackingWebApplication.Shared;

namespace JSVisaTrackingWebApplication
{
    public partial class ReceiptGeneration : System.Web.UI.Page
    {
        #region Global Variable(s)

        Decimal TotalAdjustedAmt = 0;
        String MyReciptType = "";
        String MyNarrationtext = "";

        int count = 0;

        BasePage basePage = new BasePage();
        ReceiptGenerationBusinessAccess rcptGenrBusinessAccess = new ReceiptGenerationBusinessAccess();
        SummaryReportBusinessAccess summaryBusinessAccess = new SummaryReportBusinessAccess();
        #endregion

        #region Protected Functions

        protected void Page_Load(object sender, EventArgs e)
        {
            int LocId = basePage.LoggedInUser.UserLocation.LocationId;
            int userId = basePage.LoggedInUser.UserTypeId;
            if (!IsPostBack)
            {
                txtRcptDate.Text = System.DateTime.Today.ToShortDateString();

                if (Request.QueryString["lstReceipt"] != null)
                {
                    if (userId == Convert.ToInt32(UserType.Admin))
                    {
                        LocId = 0;
                        basePage.BindDropDown(ddlPartyName, "AgentName", "AgentId", summaryBusinessAccess.Agentbind(LocId,0));
                    }
                    else
                    {
                        basePage.BindDropDown(ddlPartyName, "AgentName", "AgentId", summaryBusinessAccess.Agentbind(LocId,basePage.LoggedInUser.AgentId));
                    }
                    EditReceipt();
                    txtRcptAmount.ReadOnly = true;
                }
                else
                {
                    txtRcptAmount.ReadOnly = false;
                    Session["lstRcptDetails"] = null;
                    Session["lstReceipt"] = null;

                    //List<Agent> lstagent = rcptGenrBusinessAccess.AgentBind();
                    if (userId == Convert.ToInt32(UserType.Admin))
                    {
                        LocId = 0;
                        basePage.BindDropDown(ddlPartyName, "AgentName", "AgentId", summaryBusinessAccess.Agentbind(LocId,0));
                    }
                    else
                    {
                        basePage.BindDropDown(ddlPartyName, "AgentName", "AgentId", summaryBusinessAccess.Agentbind(LocId,basePage.LoggedInUser.AgentId));
                    }
                    tbl2.Visible = false;
                    divBtnAdd.Visible = false;
                    divbtnSave.Visible = false;
                    Reset();
                }
            }
        }

        protected void rbtnPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableDisablePaymentMode();
            if (Request.QueryString["lstReceipt"] != null)
            {
                List<Receipt> lstRcpt = (List<Receipt>)Session["lstReceipt"];
                Int32 RcptId = Convert.ToInt32(lstRcpt[0].RcptNo);

                gridviewReceipt.DataSource = rcptGenrBusinessAccess.ReadRcptDetailsByRcptNo(RcptId);
                gridviewReceipt.DataBind();
            }
        }

        protected void ddlPartyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Receipt> lst = new List<Receipt>();
            Int32 AgentId = Convert.ToInt32(ddlPartyName.SelectedItem.Value);
            Session["agentName"] = ddlPartyName.SelectedItem.Text;
            lst = rcptGenrBusinessAccess.OutstandingAmount(AgentId);
            if (lst[0].OutstandingAmount <= 0)
            {
                string strconfirm = "<script>if(!window.confirm('The Outstanding Amount For This Agent Is Either Zero Or Negative. Are You Want To Create Advance Receipt?')){window.location.href='ReceiptGeneration.aspx'}</script>";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Confirm", strconfirm, false);
                txtOutstanding.Text = lst[0].OutstandingAmount.ToString();
                rbtnReceiptType.SelectedValue = "2";

                divbtnSave.Visible = true;
                btnSave.Visible = true;
                btnGenerateReceipt.Visible = false;
                btnNext.Visible = false;
                btnPreview.Visible = false;
                List<Agent> lstAgent = rcptGenrBusinessAccess.ReadAgentAddress(AgentId);
                txtAddress.Text = lstAgent[0].AgentAddress;
            }
            else
            {
                int LocId = basePage.LoggedInUser.UserLocation.LocationId;
                int userId = basePage.LoggedInUser.UserTypeId;

                if (userId == Convert.ToInt32(UserType.Admin))
                {
                    LocId = 0;
                    basePage.BindDropDown(ddlInvoice, "InvoiceNo", "InvoiceNo", rcptGenrBusinessAccess.BindInvoice(AgentId, LocId));
                }
                else
                {
                    basePage.BindDropDown(ddlInvoice, "InvoiceNo", "InvoiceNo", rcptGenrBusinessAccess.BindInvoice(AgentId, LocId));
                }

                txtOutstanding.Text = lst[0].OutstandingAmount.ToString();
                rbtnReceiptType.SelectedValue = "1";
                btnNext.Visible = true;
                divbtnSave.Visible = false;
                lblAgent.Text = Session["agentName"].ToString();

                List<Agent> lstAgent = rcptGenrBusinessAccess.ReadAgentAddress(AgentId);
                txtAddress.Text = lstAgent[0].AgentAddress;
            }
            tbl2.Visible = false;
            divBtnAdd.Visible = false;
        }

        protected void gridviewReceipt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblAdjustedAmt = (Label)e.Row.FindControl("lblAdjustedAmt");

                Decimal AdjustedAmt = Convert.ToDecimal(lblAdjustedAmt.Text);

                TotalAdjustedAmt += AdjustedAmt;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].ColumnSpan = 4;
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells.RemoveAt(3);
                e.Row.Cells.RemoveAt(2);
                e.Row.Cells.RemoveAt(1);

                Label lblTotalAdjustedAmt = (Label)e.Row.FindControl("lblTotalAdjustedAmt");

                lblTotalAdjustedAmt.Text = TotalAdjustedAmt.ToString();

                Session["TotalAdjustedAmt"] = lblTotalAdjustedAmt.Text;
            }
        }

        protected void ddlInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 InvoiceId = Convert.ToInt32(ddlInvoice.SelectedItem.Value);
            int LocId = basePage.LoggedInUser.UserLocation.LocationId;
            int userId = basePage.LoggedInUser.UserTypeId;

            if (userId == Convert.ToInt32(UserType.Admin))
            {
                LocId = 0;
                List<ReceiptDetails> lst = rcptGenrBusinessAccess.ReceiptDetail(InvoiceId, LocId);
                if (lst.Count != 0)
                {
                    txtInvoiceDate.Text = lst[0].InvoiceDate.ToShortDateString();
                    txtTotalInvoiceAmount.Text = lst[0].InvoiceAmount.ToString();
                    txtAdjustedAmt.Text = lst[0].AdjustedAmount.ToString();
                }
                else
                {
                    txtInvoiceDate.Text = string.Empty;
                    txtTotalInvoiceAmount.Text = string.Empty;
                    txtAdjustedAmt.Text = string.Empty;
                }
            }
            else
            {
                List<ReceiptDetails> lst = rcptGenrBusinessAccess.ReceiptDetail(InvoiceId, LocId);
                if (lst.Count != 0)
                {
                    txtInvoiceDate.Text = lst[0].InvoiceDate.ToShortDateString();
                    txtTotalInvoiceAmount.Text = lst[0].InvoiceAmount.ToString();
                    txtAdjustedAmt.Text = lst[0].AdjustedAmount.ToString();
                }
                else
                {
                    txtInvoiceDate.Text = string.Empty;
                    txtTotalInvoiceAmount.Text = string.Empty;
                    txtAdjustedAmt.Text = string.Empty;
                }
            }
            List<ReceiptDetails> lstRcptDetails = (List<ReceiptDetails>)Session["lstRcptDetails"];
            gridviewReceipt.DataSource = lstRcptDetails;
            gridviewReceipt.DataBind();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            tbl2.Visible = true;
            divBtnAdd.Visible = true;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ddlInvoice.SelectedValue != "0")
            {
                ReceiptDetails receiptDtl = new ReceiptDetails();
                if (Session["lstRcptDetails"] == null)
                {
                    receiptDtl.InvoiceAmount = Convert.ToDecimal(txtTotalInvoiceAmount.Text);
                    receiptDtl.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
                    receiptDtl.InvoiceNo = Convert.ToInt32(ddlInvoice.SelectedItem.Text);
                    receiptDtl.AdjustedAmount = Convert.ToDecimal(txtAdjustedAmt.Text);
                    List<ReceiptDetails> lst = new List<ReceiptDetails>();
                    lst.Add(receiptDtl);
                    Session["lstRcptDetails"] = lst;
                    gridviewReceipt.DataSource = lst;
                    gridviewReceipt.DataBind();
                }
                else
                {

                    List<ReceiptDetails> lst = (List<ReceiptDetails>)Session["lstRcptDetails"];
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (ddlInvoice.SelectedItem.Text == lst[i].InvoiceNo.ToString())
                        {
                            lst.RemoveAt(i);
                        }
                    }
                    receiptDtl.InvoiceAmount = Convert.ToDecimal(txtTotalInvoiceAmount.Text);
                    receiptDtl.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
                    receiptDtl.InvoiceNo = Convert.ToInt32(ddlInvoice.SelectedItem.Text);
                    receiptDtl.AdjustedAmount = Convert.ToDecimal(txtAdjustedAmt.Text);
                    lst.Add(receiptDtl);
                    gridviewReceipt.DataSource = lst;
                    gridviewReceipt.DataBind();
                    Session["lstRcptDetails"] = lst;
                }
                btnSave.Visible = true;
                btnCancel.Visible = true;
                divbtnSave.Visible = true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ReceiptRecord();
            int LocId = basePage.LoggedInUser.UserLocation.LocationId;
            int userId = basePage.LoggedInUser.UserTypeId;
            if (rbtnReceiptType.SelectedValue == "2")
            {
                Receipt receipt = (Receipt)Session["lstReceipt"];
                int receiptId = rcptGenrBusinessAccess.InsertReceipt(receipt, LocId);
                Session["RcptId"] = receiptId;

                string strconfirm = "<script>if(!window.confirm('Record Saved Successfully With Receipt No. " + receiptId + ". Do You Want to Print Receipt?')){window.location.href='ReceiptGeneration.aspx'}</script>";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Confirm", strconfirm, false);

                btnSave.Visible = false;
                btnGenerateReceipt.Visible = true;
                tbl2.Visible = false;
                btnAdd.Visible = false;
            }
            else
            {
                Receipt receipt = (Receipt)Session["lstReceipt"];
                receipt.rcptDetails = new ReceiptDetails();
                List<ReceiptDetails> listRcptDetail = (List<ReceiptDetails>)Session["lstRcptDetails"];
                receipt.ReceiptDetail = listRcptDetail;
                Session["lstReceipt"] = receipt;
                Decimal receiptAmt = receipt.RcptAmount;
                Decimal TotalAdjustedAmount = Convert.ToDecimal(Session["TotalAdjustedAmt"]);
                if (receiptAmt == TotalAdjustedAmount)
                {
                    Receipt receipt1 = (Receipt)Session["lstReceipt"];

                    btnSave.Visible = false;
                    btnPreview.Visible = true;
                    btnGenerateReceipt.Visible = true;
                    GridFooterShow();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('Receipt Amount Should Be Equals To Total Adjusted Amount.');", true);
                    txtRcptAmount.Focus();
                    GridFooterShow();
                    btnSave.Visible = true;
                    btnCancel.Visible = true;
                    ddlInvoice.SelectedValue = "0";
                    txtInvoiceDate.Text = string.Empty;
                    txtTotalInvoiceAmount.Text = string.Empty;
                    txtAdjustedAmt.Text = string.Empty;
                }
                gridviewReceipt.DataSource = listRcptDetail;
                gridviewReceipt.DataBind();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('Record Will Save Only At Generate Receipt Button Click.');", true);
            }
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            Session["NewlstReceipt"] = Session["lstReceipt"];
            Session["NewlstRcptDetails"] = Session["lstRcptDetails"];
            string RcptId = "N/A (Please Click On Generate Receipt Button.)";
            string url = "ReceiptPrint.aspx?receiptId=" + RcptId;
            string fullUrl = "window.open('" + url + "','_blank','height=500,width=800,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=no,titlebar=no,addressbars=0,directories=no');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullUrl, true);
            GridFooterShow();
            btnPreview.Visible = true;
            btnGenerateReceipt.Visible = true;
        }

        protected void btnGenerateReceipt_Click(object sender, EventArgs e)
        {
            Session["NewlstReceipt"] = Session["lstReceipt"];
            Session["NewlstRcptDetails"] = Session["lstRcptDetails"];
            int LocId = basePage.LoggedInUser.UserLocation.LocationId;
            int userId = basePage.LoggedInUser.UserTypeId;

            if (rbtnReceiptType.SelectedValue == "2")
            {
                int RcptId = Convert.ToInt32(Session["RcptId"]);
                string url = "ReceiptPrint.aspx?receiptAdvance=" + RcptId;
                string fullUrl = "window.open('" + url + "','_blank','height=500,width=800,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=no,titlebar=no,addressbars=0,directories=no');";
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullUrl, true);
                GridFooterShow();
                Reset();
            }
            else
            {
                Receipt receipt = (Receipt)Session["lstReceipt"];
                List<ReceiptDetails> listRcptDetail = (List<ReceiptDetails>)Session["lstRcptDetails"];
                receipt.ReceiptDetail = listRcptDetail;
                Session["lstReceipt"] = receipt;
                Decimal receiptAmt = receipt.RcptAmount;
                Decimal TotalAdjustedAmount = Convert.ToDecimal(Session["TotalAdjustedAmt"]);

                Receipt receipt1 = (Receipt)Session["lstReceipt"];
                int receiptId = rcptGenrBusinessAccess.InsertReceipt(receipt1, LocId);
                string url = "ReceiptPrint.aspx?receiptId=" + receiptId;
                string fullUrl = "window.open('" + url + "','_blank','height=500,width=800,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=no,titlebar=no,addressbars=0,directories=no');";
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullUrl, true);
                GridFooterShow();
                Reset();
                Session["lstReceipt"] = null;
                Session["lstRcptDetails"] = null;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
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
            Reset();
            tbl2.Visible = false;
            divBtnAdd.Visible = false;
            divbtnSave.Visible = false;
            Session["lstRcptDetails"] = null;
            Session["lstReceipt"] = null;
            gridviewReceipt.DataSource = null;
            gridviewReceipt.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Receipt receipt = new Receipt();
            receipt.agent = new Agent();
            receipt.RcptNo = Convert.ToInt32(txtRecptNo.Text);
            receipt.agent.AgentId = Convert.ToInt32(ddlPartyName.SelectedItem.Value);
            receipt.agent.AgentName = ddlPartyName.SelectedItem.Text;
            receipt.RcptDate = Convert.ToDateTime(txtRcptDate.Text);

            receipt.RcptType = rbtnReceiptType.SelectedItem.Text;
            receipt.RcptAmount = Convert.ToDecimal(txtRcptAmount.Text);

            #region CommentedCode
            //if (rbtnPaymentMode.SelectedValue.ToString() == "1")
            //{
            //    txtChequeNo.Enabled = false;
            //    txtIssuingBank.Enabled = false;
            //    divdated.Visible = false;
            //    txtChequeNo.Text = string.Empty;
            //    txtIssuingBank.Text = string.Empty;
            //    txtDated.Text = string.Empty;
            //    receipt.PaymentMode = "CR";
            //}
            //else //if (receipt.PaymentMode == "2")
            //{
            //    divdated.Visible = true;
            //    txtChequeNo.Enabled = true;
            //    txtIssuingBank.Enabled = true;
            //    receipt.PaymentMode = "BR";
            //}
            //if (receipt.PaymentMode == "BR")
            //{
            //    ddlCreditAccount.Items.Clear();
            //    ddlCreditAccount.Items.Add("--Select--");
            //    ddlCreditAccount.Items.Add("ORIENTAL BANK OF COMMERCE 4284");
            //    ddlCreditAccount.Items.Add("ICICI BANK C/A 629105036637");
            //    ddlCreditAccount.Items.Add("ICICI BANK C/A 072205000464");
            //    //ddlCreditAccount.Items.Insert(0, new ListItem("--Select--", "0"));
            //    //ddlCreditAccount.Items.Insert(1, new ListItem("ORIENTAL BANK OF COMMERCE 4284", "1"));
            //    //ddlCreditAccount.Items.Insert(2, new ListItem("ICICI BANK C/A 629105036637", "2"));
            //    //ddlCreditAccount.Items.Insert(3, new ListItem("ICICI BANK C/A 072205000464", "3"));
            //}
            //else //if (MyReciptType == "CR")
            //{
            //    ddlCreditAccount.Items.Clear();
            //    ddlCreditAccount.Items.Insert(0, new ListItem("--Select--", "0"));
            //    ddlCreditAccount.Items.Insert(1, new ListItem("Cash", "1"));
            //}
            #endregion

            receipt.CreditAccount = ddlCreditAccount.SelectedItem.Text;
            receipt.ChequeNo = txtChequeNo.Text;
            receipt.IssuingBank = txtIssuingBank.Text;
            receipt.IssuingDate = Convert.ToDateTime(txtDated.Text);
            if (rbtnPaymentMode.SelectedValue.ToString() == "2")
            {
                MyNarrationtext = "Cheque No. '" + txtChequeNo.Text + "' OF '" + txtIssuingBank.Text + "'  Dated  '" + txtDated.Text + "'";
                txtRemark.Text = string.Empty;
                MyReciptType = "BR";
            }
            else
            {
                MyReciptType = "CR";
                MyNarrationtext = "";
                txtDated.Text = "12:00:00 AM";
            }
            receipt.PaymentMode = MyReciptType;
            receipt.Remarks = txtRemark.Text + " " + MyNarrationtext.ToString();
            Session["lstReceipt"] = receipt;
            rcptGenrBusinessAccess.UpdateReceipt(receipt);
            Session["RcptId"] = receipt.RcptNo;
            Session["NewlstReceipt"] = Session["lstReceipt"];
            string strconfirm = "<script>if(!window.confirm('Record Updated Successfully With Receipt No. " + txtRecptNo.Text + ". Do You Want to Print Receipt?')){window.location.href='ReceiptGeneration.aspx'}</script>";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Confirm", strconfirm, false);

            string url = "ReceiptPrint.aspx?receiptUpdate=" + receipt.RcptNo;
            string fullUrl = "window.open('" + url + "','_blank','height=500,width=800,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=no,titlebar=no,addressbars=0,directories=no');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullUrl, true);
            GridFooterShow();

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
            rbtnPaymentMode.SelectedItem.Value = "1";
            EnableDisablePaymentMode();
            Reset();
            Session["lstReceipt"] = null;
            Session["lstRcptDetails"] = null;
        }

        protected void gridviewReceipt_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdDelete"))
            {
                List<ReceiptDetails> list = (List<ReceiptDetails>)Session["lstRcptDetails"];
                int Index = Convert.ToInt32(e.CommandArgument);
                list.RemoveAt(Index);
                gridviewReceipt.DataSource = list;
                gridviewReceipt.DataBind();

                ddlInvoice.SelectedValue = "0";
                txtInvoiceDate.Text = string.Empty;
                txtTotalInvoiceAmount.Text = string.Empty;
                txtAdjustedAmt.Text = string.Empty;
            }
        }

        protected void rbtnReceiptType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtnReceiptType.SelectedValue == "1")
            {
                divbtnSave.Visible = false;
                btnNext.Visible = true;
                btnSave.Visible = true;
                btnCancel.Visible = true;
                btnPreview.Visible = false;
                btnGenerateReceipt.Visible = false;
            }
            else
            {
                divbtnSave.Visible = true;
                btnNext.Visible = false;
                btnSave.Visible = true;
                btnCancel.Visible = true;
                btnPreview.Visible = false;
                btnGenerateReceipt.Visible = false;
            }
        }
        #endregion

        #region Public Method(s)

        public void ReceiptRecord()
        {
            if (rbtnPaymentMode.SelectedValue.ToString() == "2")
            {
                MyReciptType = "BR";
                MyNarrationtext = "Cheque No. '" + txtChequeNo.Text + "' OF '" + txtIssuingBank.Text + "'  Dated  '" + txtDated.Text + "'";
            }
            else
            {
                MyReciptType = "CR";
                MyNarrationtext = "";
                txtDated.Text = "12:00:00 AM";
            }

            Receipt receipt = new Receipt();
            receipt.rcptDetails = new ReceiptDetails();
            receipt.agent = new Agent();
            receipt.agent.AgentId = Convert.ToInt32(ddlPartyName.SelectedItem.Value);
            receipt.RcptDate = Convert.ToDateTime(txtRcptDate.Text);
            receipt.PaymentMode = MyReciptType.ToString();
            receipt.RcptType = rbtnReceiptType.SelectedItem.Text;
            receipt.RcptAmount = Convert.ToDecimal(txtRcptAmount.Text);
            receipt.CreditAccount = ddlCreditAccount.SelectedItem.Text;
            receipt.ChequeNo = txtChequeNo.Text;
            receipt.IssuingBank = txtIssuingBank.Text;
            receipt.agent.AgentLocationId = basePage.LoggedInUser.UserLocation.LocationId;
            receipt.IssuingDate = Convert.ToDateTime(txtDated.Text);
            receipt.rcptDetails.AdjustedAmount = Convert.ToDecimal(txtRcptAmount.Text);
            receipt.Remarks = txtRemark.Text + " " + MyNarrationtext.ToString();

            Session["lstReceipt"] = receipt;
            tbl2.Visible = true;
            divBtnAdd.Visible = true;
            GridFooterShow();
        }

        public void EnableDisablePaymentMode()
        {
            if (rbtnPaymentMode.SelectedItem.Value == "1")
            {
                txtChequeNo.Enabled = false;
                txtIssuingBank.Enabled = false;
                divdated.Visible = false;
                txtChequeNo.Text = string.Empty;
                txtIssuingBank.Text = string.Empty;

                span1.Visible = false;
                span2.Visible = false;
                span3.Visible = false;

                MyReciptType = "CR";

                ddlCreditAccount.Items.Clear();
                ddlCreditAccount.Items.Add("--Select--");
                ddlCreditAccount.Items.Add("Cash");

                RFV4.ValidationGroup = "b";
                RFV5.ValidationGroup = "b";
                RFV9.ValidationGroup = "b";
            }
            else if (rbtnPaymentMode.SelectedItem.Value == "2")
            {
                divdated.Visible = true;
                txtChequeNo.Enabled = true;
                txtIssuingBank.Enabled = true;
                MyReciptType = "BR";

                span1.Visible = true;
                span2.Visible = true;
                span3.Visible = true;

                ddlCreditAccount.Items.Clear();
                ddlCreditAccount.Items.Add("--Select--");
                ddlCreditAccount.Items.Add("ORIENTAL BANK OF COMMERCE 4284");
                ddlCreditAccount.Items.Add("ICICI BANK C/A 629105036637");
                ddlCreditAccount.Items.Add("ICICI BANK C/A 072205000464");

                RFV4.ValidationGroup = "a";
                RFV5.ValidationGroup = "a";
                RFV9.ValidationGroup = "a";

            }
        }

        public void Reset()
        {
            EnableDisablePaymentMode();
            txtAddress.Text = string.Empty;
            txtAdjustedAmt.Text = string.Empty;
            txtChequeNo.Text = string.Empty;
            divdated.Visible = false;
            txtInvoiceDate.Text = string.Empty;
            txtIssuingBank.Text = string.Empty;
            txtOutstanding.Text = string.Empty;
            txtRcptAmount.Text = string.Empty;
            txtRcptDate.Text = System.DateTime.Today.ToShortDateString();
            txtRecptNo.Text = string.Empty;
            txtRemark.Text = string.Empty;
            txtTotalInvoiceAmount.Text = string.Empty;
            ddlCreditAccount.SelectedItem.Text = "--Select--";
            ddlInvoice.Items.Clear();
            ddlPartyName.SelectedValue = "0";
            rbtnPaymentMode.SelectedValue = "1";
            rbtnReceiptType.SelectedValue = "1";

            gridviewReceipt.DataSource = null;
            gridviewReceipt.DataBind();
            btnNext.Visible = true;
            tbl2.Visible = false;
            divBtnAdd.Visible = false;
            divbtnSave.Visible = false;
            EnableDisablePaymentMode();
            btnUpdate.Visible = false;
        }

        public void GridFooterShow()
        {
            if (gridviewReceipt.Rows.Count > 0)
            {
                Label lblTotalAdjustedAmt = (Label)gridviewReceipt.FooterRow.FindControl("lblTotalAdjustedAmt");

                gridviewReceipt.FooterRow.Cells[0].ColumnSpan = 3;
                gridviewReceipt.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                gridviewReceipt.FooterRow.Cells[0].Font.Bold = true;
                gridviewReceipt.FooterRow.Cells.RemoveAt(2);
                gridviewReceipt.FooterRow.Cells.RemoveAt(1);

                lblTotalAdjustedAmt.Text = Session["TotalAdjustedAmt"].ToString();
                if (Convert.ToDecimal(txtRcptAmount.Text) == Convert.ToDecimal(lblTotalAdjustedAmt.Text))
                {
                    btnSave.Visible = true;
                    btnCancel.Visible = true;
                    btnPreview.Visible = true;
                    btnGenerateReceipt.Visible = true;
                }
                else
                {
                    btnSave.Visible = false;
                    btnPreview.Visible = false;
                    btnGenerateReceipt.Visible = false;
                    btnCancel.Visible = false;
                }
            }
        }

        public void EditReceipt()
        {
            if (Request.QueryString["lstReceipt"] != null)
            {
                List<Receipt> lstRcpt = (List<Receipt>)Session["lstReceipt"];
                String RcptType = lstRcpt[0].RcptType.ToString();

                Int32 RcptId = Convert.ToInt32(lstRcpt[0].RcptNo);

                if (RcptType == "Advance")
                {
                    rbtnReceiptType.SelectedValue = "2";

                    txtRcptDate.Text = lstRcpt[0].RcptDate.ToString();
                    txtRcptAmount.Text = lstRcpt[0].RcptAmount.ToString();
                    txtRecptNo.Text = lstRcpt[0].RcptNo.ToString();
                    ddlPartyName.SelectedItem.Text = lstRcpt[0].agent.AgentName.ToString();
                    ddlPartyName.SelectedItem.Value = lstRcpt[0].agent.AgentId.ToString();
                    txtAddress.Text = lstRcpt[0].agent.AgentAddress;

                    if (lstRcpt[0].PaymentMode == "CR")
                    {
                        rbtnPaymentMode.SelectedValue = "1";
                        EnableDisablePaymentMode();
                    }
                    else
                    {
                        rbtnPaymentMode.SelectedValue = "2";
                        EnableDisablePaymentMode();
                    }

                    ddlCreditAccount.SelectedItem.Text = lstRcpt[0].CreditAccount.ToString();
                    txtChequeNo.Text = lstRcpt[0].ChequeNo;
                    txtIssuingBank.Text = lstRcpt[0].IssuingBank;
                    txtDated.Text = lstRcpt[0].IssuingDate.ToShortDateString();
                    txtRemark.Text = lstRcpt[0].Remarks;

                    divBtnAdd.Visible = false;
                    btnSave.Visible = false;
                    divbtnSave.Visible = true;
                    btnPreview.Visible = false;
                    btnGenerateReceipt.Visible = false;
                    btnCancel.Visible = true;
                    btnUpdate.Visible = true;
                }
                else
                {
                    rbtnReceiptType.SelectedValue = "1";

                    txtRcptDate.Text = lstRcpt[0].RcptDate.ToString();
                    txtRcptAmount.Text = lstRcpt[0].RcptAmount.ToString();
                    txtRecptNo.Text = lstRcpt[0].RcptNo.ToString();
                    ddlPartyName.SelectedItem.Text = lstRcpt[0].agent.AgentName.ToString();
                    ddlPartyName.SelectedItem.Value = lstRcpt[0].agent.AgentId.ToString();
                    txtAddress.Text = lstRcpt[0].agent.AgentAddress;

                    if (lstRcpt[0].PaymentMode == "CR")
                    {
                        rbtnPaymentMode.SelectedValue = "1";
                        EnableDisablePaymentMode();
                    }
                    else
                    {
                        rbtnPaymentMode.SelectedValue = "2";
                        EnableDisablePaymentMode();
                    }

                    ddlCreditAccount.SelectedItem.Text = lstRcpt[0].CreditAccount.ToString();
                    txtChequeNo.Text = lstRcpt[0].ChequeNo;
                    txtIssuingBank.Text = lstRcpt[0].IssuingBank;
                    txtDated.Text = lstRcpt[0].IssuingDate.ToShortDateString();
                    txtRemark.Text = lstRcpt[0].Remarks;

                    gridviewReceipt.DataSource = rcptGenrBusinessAccess.ReadRcptDetailsByRcptNo(RcptId);
                    gridviewReceipt.DataBind();

                    foreach (DataControlField col in gridviewReceipt.Columns)
                    {
                        if (col.HeaderText == "Action")
                        {
                            col.Visible = false;
                        }
                    }

                    gridviewReceipt.Visible = true;
                    divBtnAdd.Visible = false;
                    btnSave.Visible = false;
                    divbtnSave.Visible = true;
                    btnPreview.Visible = false;
                    btnGenerateReceipt.Visible = false;
                    btnCancel.Visible = true;
                    btnUpdate.Visible = true;
                }
            }
            List<Receipt> lst = new List<Receipt>();
            Int32 AgentId = Convert.ToInt32(ddlPartyName.SelectedItem.Value);
            lst = rcptGenrBusinessAccess.OutstandingAmount(AgentId);
            txtOutstanding.Text = lst[0].OutstandingAmount.ToString();

            btnNext.Visible = false;
            tbl2.Visible = false;
        }
        #endregion
    }
}