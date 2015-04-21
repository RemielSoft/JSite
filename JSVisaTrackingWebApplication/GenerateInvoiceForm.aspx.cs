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

namespace JSVisaTrackingWebApplication
{
    public partial class GenerateInvoiceForm : System.Web.UI.Page
    {

        #region Global Variables

        int i;
        int LocId;
        int userId;
        int flag = 0;
        string AgentAddress;
        string AgentPhone;
        string michlaCharge;
        decimal InvCharge;
        decimal UnAdjAmt;
        int serviceCharge = 0;
        Decimal ServiceTax = 0;
        decimal serviceAmount = 0;
        int itemQuantity = 0;
        string visatype;
        Bill billDOM = new Bill();
        Receipt rect = new Receipt();
        List<Bill> lstBill = new List<Bill>();
        AgentBAL agentBAL = new AgentBAL();
        List<Agent> lstagent = new List<Agent>();
        BasePage basePase = new BasePage();
        BillItem billItemDOM = new BillItem();
        List<Bill> lstServiceTax = new List<Bill>();
        List<Bill> lstServiceCharge = new List<Bill>();
        Miscellaneous MichlaDOM = new Miscellaneous();
        List<Miscellaneous> lstMichla = new List<Miscellaneous>();
        BasePage basePage = new BasePage();
        GenerateInvoiceBAL generateInvoiceBal = new GenerateInvoiceBAL();
        MiscellaneousBusinessAccess miscellaneousBAL = new MiscellaneousBusinessAccess();
        ReceiptGenerationBusinessAccess recieptBAL = new ReceiptGenerationBusinessAccess();
        List<Receipt> lstReciept = new List<Receipt>();
        List<ReceiptDetails> lstReciept1 = new List<ReceiptDetails>();

        #endregion

        #region Protected Method

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Type"] != null)
            {
                ddlMiscelaCharge.Visible = false;
                BtnAddMiscellaneousCharge.Visible = false;
                rbtnInvoice.SelectedIndex = -1;
                visatype = Convert.ToString(Session["Type"]);
                if (visatype == "Normal")
                {
                    rbtnInvoice.SelectedValue = Convert.ToString(2);
                }
                if (visatype == "Advance")
                {
                    rbtnInvoice.SelectedValue = Convert.ToString(1);
                }
                if (visatype == "Additional")
                {
                    rbtnInvoice.SelectedValue = Convert.ToString(3);
                }
            }

            if (rbtnInvoice.SelectedValue == "1" || rbtnInvoice.SelectedValue == "2")
            {
                ddlMiscelaCharge.Visible = true;
                BtnAddMiscellaneousCharge.Visible = true;
                Panel1.Visible = true;
                Panel3.Visible = false;
                if (!IsPostBack)
                {
                    if (Request.QueryString["CG_Id"] != null)
                    {
                        ConsignmentId = Convert.ToInt32(Request.QueryString["CG_Id"]);
                        Consignment consignment = (Consignment)Session["listconsign"];
                        AgentId = Convert.ToInt32(Session["AgentId"]);
                        billIdds = Convert.ToInt32(Session["billId"]);
                        version = Convert.ToInt32(Session["version"]);
                        AgentName = Convert.ToString(Session["AgentName"]);
                        lblAgentName.Text = AgentName;
                        quantity = Convert.ToInt32(Session["quantity"]);
                        PaxName = Convert.ToString(Session["PaxName"]);
                        lstpax = (List<AdditonalInfo>)Session["consignmentEditpax"];
                        BindgvInvoice(lstpax, AgentId);
                        BindMicCharge();
                        btnPreview.Visible = false;
                    }
                    Session.Remove("tempdata");
                }
            }

            else
            {
                ddlMiscelaCharge.Visible = false;
                BtnAddMiscellaneousCharge.Visible = false;
                Panel1.Visible = false;
                Panel3.Visible = true;
                if (Session["CurrentTable"] == null)
                {
                    if (!IsPostBack)
                    {
                        billIdds = Convert.ToInt32(Session["billId"]);
                        version = Convert.ToInt32(Session["version"]);
                        AgentName = Convert.ToString(Session["AgentName"]);
                        BindAdditionalGrid();
                    }
                    btnPreview.Visible = false;
                }
            }
        }

        protected void btnGenerateInvoice_Click(object sender, EventArgs e)
        {
            LocId = basePage.LoggedInUser.UserLocation.LocationId;
            userId = basePage.LoggedInUser.UserTypeId;
            if (rbtnInvoice.SelectedValue == "1" || rbtnInvoice.SelectedValue == "2")
            {
                BindgvInvoice(lstpax, AgentId);
                billDOM = (Bill)Session["billDOM"];
            }
            else
            {
                billDOM = (Bill)Session["billDOMM"];
            }
            if (userId == Convert.ToInt32(UserType.Admin) || userId == Convert.ToInt32(UserType.SuperAdmin))
            {
                LocId = 0;
                lstagent = agentBAL.ReadUsers(AgentName, LocId,0);
            }
            else
            {
                lstagent = agentBAL.ReadUsers(AgentName, LocId, basePage.LoggedInUser.AgentId);
            }
            Session["billDOM"] = billDOM;
            Session["AgentAddress"] = lstagent[0].AgentAddress;
            Session["AgentPhone"] = lstagent[0].AgentPhone;
            if (rbtnInvoice.SelectedValue == "2")
            {
                visatype = "Normal";
            }
            else if (rbtnInvoice.SelectedValue == "1")
            {
                visatype = "Advance";
            }
            else
            {
                visatype = "Additional";
            }

            lstBill = generateInvoiceBal.ReadBillIdByConsignmentId(ConsignmentId, visatype);

            if (lstBill.Count != 0 && version != 0)
            {
                generateInvoiceBal.UpdateInvoice(billDOM, lstBill[0].Version, lstBill[0].BillId);
                string url = "PreviewPrintInvoice.aspx?CG_Id=" + ConsignmentId;
                string fullURL = "window.open('" + url + "', '_blank', 'height=500,width=800,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=no,titlebar=no' );";
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
            }
            else if (lstBill.Count == 0)
            {
                generateInvoiceBal.CreateInvoice(billDOM);
                lstBill = generateInvoiceBal.ReadBillIdByConsignmentId(ConsignmentId, visatype);
                Session["billId"] = lstBill[0].BillId;
                if (chkAdjestAdvance.SelectedValue != "")
                {
                    // AdjustAdvanceReciept();
                }
                if (ConsignmentId > 0)
                {
                    string url = "PreviewPrintInvoice.aspx?CG_Id=" + ConsignmentId;
                    string fullURL = "window.open('" + url + "', '_blank', 'height=500,width=800,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=no,titlebar=no' );";
                    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                }
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('This Type of Invoice already Generated.')</script>");
            }
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session.Remove("lstcountry");
            Session.Remove("listconsign");
            Session.Remove("MailRemarks");
            Session.Remove("VisaTypeOneId");
            Session.Remove("tempdata");
            Response.Redirect("Index.aspx");
        }

        protected void gvInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInvoice.PageIndex = e.NewPageIndex;
            BindgvInvoice(lstpax, AgentId);
        }

        protected void gvInvoice_RowEditing(object sender, GridViewEditEventArgs e)
        {

            if (cmdId == 1)
            {
                int id = Convert.ToInt32(e.NewEditIndex);
                Session["Ids"] = id;
                gvInvoice_RowCancelingEdit(null, null);
                BindgvInvoice(lstpax, AgentId);
            }
            else if (cmdId == 2)
            {
                gvInvoice.EditIndex = Convert.ToInt32(Session["Ids"]);
                BindgvInvoice(lstpax, AgentId);
            }
            else if (basePage.LoggedInUser.UserTypeId == Convert.ToInt32(UserType.SuperAdmin))
            {
                int id = Convert.ToInt32(e.NewEditIndex);
                Session["Ids"] = id;
                gvInvoice.EditIndex = id;
                BindgvInvoice(lstpax, AgentId);
            }
            else
            {
                gvInvoice.EditIndex = Convert.ToInt32(Session["Ids"]);
                BindgvInvoice(lstpax, AgentId);
            }

        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            //AddNewRowToGrid();
        }

        protected void rbtnInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtnInvoice.SelectedValue == "1" || rbtnInvoice.SelectedValue == "2")
            {
                BindgvInvoice(lstpax, AgentId);
            }
        }

        protected void BtnAddMiscellaneousCharge_Click(object sender, EventArgs e)
        {
            if (ddlMiscelaCharge.SelectedIndex != -1)
            {
                if (rbtnInvoice.SelectedValue == "2")
                {
                    lstServiceTax = generateInvoiceBal.ReadServiceTax();
                    lstServiceCharge = generateInvoiceBal.ReadServiceCharge();
                    serviceAmount = lstServiceCharge[0].ServiceCharge;
                    serviceCharge = Convert.ToInt32(serviceAmount);
                    txt_serviceCharge.Text = Convert.ToString(serviceAmount);
                    ServiceTax = Convert.ToDecimal(serviceCharge * (lstServiceTax[0].ServiceTax) / 100);
                    txt_serviceTax.Text = Convert.ToString(String.Format("{0:0.00}", ServiceTax));
                    if (lstBillItem != null)
                    {
                        for (int i = 0; i < lstBillItem.Count; i++)
                        {
                            itemQuantity = lstBillItem[i].ItemQuantity;
                            lstBillItem[i].ItemAmount = lstBillItem[i].ItemQuantity * lstBillItem[i].ItemCharge;
                            lstBillItem[i].TotalAmount = (lstBillItem.Sum(m => m.ItemAmount) + Convert.ToDecimal(serviceCharge) + Convert.ToDecimal(ServiceTax));
                        }
                        txt_totalAmt.Text = lstBillItem.Sum(m => m.ItemAmount).ToString();
                        michlaCharge = ddlMiscelaCharge.SelectedItem.Text;
                        if (ddlMiscelaCharge.SelectedItem.Text == michlaCharge)
                        {
                            lstMichla = generateInvoiceBal.ReadMicCharge(michlaCharge);
                            billItemDOM.BillItemDescription = lstMichla[0].Description;
                            billItemDOM.ItemCharge = lstMichla[0].Amount;
                            if (lstMichla[0].Per_consignment == "c")
                            {
                                billItemDOM.ItemQuantity = 1;
                            }
                            else
                            {
                                billItemDOM.ItemQuantity = quantity;
                            }
                            billItemDOM.ItemAmount = billItemDOM.ItemQuantity * billItemDOM.ItemCharge;
                            txt_totalAmt.Text = Convert.ToString(lstBillItem.Sum(m => m.ItemAmount) + billItemDOM.ItemAmount);
                            txt_NetAmt.Text = Convert.ToString(String.Format("{0:0.00}", lstBillItem.Sum(m => m.ItemAmount) + serviceCharge + ServiceTax + billItemDOM.ItemAmount));
                            lstBillItem.Add(billItemDOM);
                            BindgvInvoice(lstpax, AgentId);
                        }
                    }
                }
                else
                {
                    lstServiceTax = generateInvoiceBal.ReadServiceTax();
                    lstServiceCharge = generateInvoiceBal.ReadServiceCharge();
                    serviceAmount = lstServiceCharge[0].ServiceCharge;
                    serviceCharge = Convert.ToInt32(serviceAmount);
                    txt_serviceCharge.Text = Convert.ToString(serviceAmount);
                    ServiceTax = Convert.ToDecimal(serviceCharge * (lstServiceTax[0].ServiceTax) / 100);
                    txt_serviceTax.Text = Convert.ToString(String.Format("{0:0.00}", ServiceTax));
                    if (lstBillItemm != null)
                    {
                        for (int i = 0; i < lstBillItemm.Count; i++)
                        {
                            itemQuantity = lstBillItemm[i].ItemQuantity;
                            lstBillItemm[i].ItemAmount = lstBillItemm[i].ItemQuantity * lstBillItemm[i].ItemCharge;
                            lstBillItemm[i].TotalAmount = (lstBillItemm.Sum(m => m.ItemAmount) + Convert.ToDecimal(serviceCharge) + Convert.ToDecimal(ServiceTax));
                        }
                        txt_totalAmt.Text = lstBillItemm.Sum(m => m.ItemAmount).ToString();
                        michlaCharge = ddlMiscelaCharge.SelectedItem.Text;
                        if (ddlMiscelaCharge.SelectedItem.Text == michlaCharge)
                        {
                            lstMichla = generateInvoiceBal.ReadMicCharge(michlaCharge);
                            billItemDOM.BillItemDescription = lstMichla[0].Description;
                            billItemDOM.ItemCharge = lstMichla[0].Amount;
                            if (lstMichla[0].Per_consignment == "c")
                            {
                                billItemDOM.ItemQuantity = 1;
                            }
                            else
                            {
                                billItemDOM.ItemQuantity = quantity;
                            }
                            billItemDOM.ItemAmount = billItemDOM.ItemQuantity * billItemDOM.ItemCharge;
                            txt_totalAmt.Text = Convert.ToString(lstBillItemm.Sum(m => m.ItemAmount) + billItemDOM.ItemAmount);
                            txt_NetAmt.Text = Convert.ToString(String.Format("{0:0.00}", lstBillItemm.Sum(m => m.ItemAmount) + serviceCharge + ServiceTax + billItemDOM.ItemAmount));
                            lstBillItemm.Add(billItemDOM);
                            BindgvInvoice(lstpax, AgentId);
                        }
                    }
                }
            }
        }

        protected void gvInvoice_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvInvoice.EditIndex = -1;
            BindgvInvoice(lstpax, AgentId);
        }

        protected void gvInvoice_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GenerateInvoiceBAL generateInvoiceBal = new GenerateInvoiceBAL();
            if (rbtnInvoice.SelectedValue == "2")
            {
                int id = Convert.ToInt32(Session["Ids"]);
                if (lstBillItem != null)
                {
                    TextBox txtDesc = (TextBox)gvInvoice.Rows[e.RowIndex].FindControl("txtDesc");
                    TextBox txtRate = (TextBox)gvInvoice.Rows[e.RowIndex].FindControl("txtRate");
                    TextBox txtqty = (TextBox)gvInvoice.Rows[e.RowIndex].FindControl("txtqty");
                    TextBox txtamt = (TextBox)gvInvoice.Rows[e.RowIndex].FindControl("txtamt");
                    for (int i = 0; i < lstBillItem.Count; i++)
                    {
                        if (i == id)
                        {
                            lstBillItem[i].BillItemDescription = txtDesc.Text;
                            lstBillItem[i].ItemQuantity = Convert.ToInt32(txtqty.Text);
                            lstBillItem[i].ItemCharge = Convert.ToDecimal(txtRate.Text);
                            lstBillItem[i].ItemAmount = Convert.ToDecimal(lstBillItem[i].ItemCharge * lstBillItem[i].ItemQuantity);
                        }
                        else
                        {
                            lstBillItem[i].ItemAmount = lstBillItem[i].ItemQuantity * lstBillItem[i].ItemCharge;
                        }
                        lstBillItem[i].TotalAmount = (lstBillItem.Sum(m => m.ItemAmount));
                    }
                    txt_totalAmt.Text = Convert.ToString((lstBillItem.Sum(m => m.ItemAmount)));
                    lstServiceTax = generateInvoiceBal.ReadServiceTax();
                    lstServiceCharge = generateInvoiceBal.ReadServiceCharge();
                    serviceAmount = lstServiceCharge[0].ServiceCharge;
                    serviceCharge = Convert.ToInt32(serviceAmount);
                    txt_serviceCharge.Text = Convert.ToString(serviceAmount);
                    ServiceTax = Convert.ToDecimal(serviceCharge * (lstServiceTax[0].ServiceTax) / 100);
                    txt_serviceTax.Text = Convert.ToString(String.Format("{0:0.00}", ServiceTax));
                    txt_NetAmt.Text = Convert.ToString(String.Format("{0:0.00}", (Convert.ToDecimal(lstBillItem.Sum(m => m.ItemAmount)) + serviceCharge + ServiceTax)));
                    gvInvoice.EditIndex = -1;
                    BindgvInvoice(lstpax, AgentId);
                }
            }

            else
            {
                int id = Convert.ToInt32(Session["Ids"]);
                if (lstBillItemm != null)
                {
                    TextBox txtDesc = (TextBox)gvInvoice.Rows[e.RowIndex].FindControl("txtDesc");
                    TextBox txtRate = (TextBox)gvInvoice.Rows[e.RowIndex].FindControl("txtRate");
                    TextBox txtqty = (TextBox)gvInvoice.Rows[e.RowIndex].FindControl("txtqty");
                    TextBox txtamt = (TextBox)gvInvoice.Rows[e.RowIndex].FindControl("txtamt");
                    for (int i = 0; i < lstBillItemm.Count; i++)
                    {
                        if (i == id)
                        {
                            lstBillItemm[i].BillItemDescription = txtDesc.Text;
                            lstBillItemm[i].ItemQuantity = Convert.ToInt32(txtqty.Text);
                            lstBillItemm[i].ItemCharge = Convert.ToDecimal(txtRate.Text);
                            lstBillItemm[i].ItemAmount = Convert.ToDecimal(lstBillItemm[i].ItemCharge * lstBillItemm[i].ItemQuantity);
                        }
                        else
                        {
                            lstBillItemm[i].ItemAmount = lstBillItemm[i].ItemQuantity * lstBillItemm[i].ItemCharge;
                        }
                        lstBillItemm[i].TotalAmount = (lstBillItemm.Sum(m => m.ItemAmount));
                    }
                    txt_totalAmt.Text = Convert.ToString((lstBillItemm.Sum(m => m.ItemAmount)));
                    lstServiceTax = generateInvoiceBal.ReadServiceTax();
                    lstServiceCharge = generateInvoiceBal.ReadServiceCharge();
                    serviceAmount = lstServiceCharge[0].ServiceCharge;
                    serviceCharge = Convert.ToInt32(serviceAmount);
                    txt_serviceCharge.Text = Convert.ToString(serviceAmount);
                    ServiceTax = Convert.ToDecimal(serviceCharge * (lstServiceTax[0].ServiceTax) / 100);
                    txt_serviceTax.Text = Convert.ToString(String.Format("{0:0.00}", ServiceTax));
                    txt_NetAmt.Text = Convert.ToString(String.Format("{0:0.00}", (Convert.ToDecimal(lstBillItemm.Sum(m => m.ItemAmount)) + serviceCharge + ServiceTax)));
                    gvInvoice.EditIndex = -1;
                    BindgvInvoice(lstpax, AgentId);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            LocId = basePage.LoggedInUser.UserLocation.LocationId;
            userId = basePage.LoggedInUser.UserTypeId;
            if (userId == Convert.ToInt32(UserType.Admin) || userId == Convert.ToInt32(UserType.SuperAdmin))
            {
                LocId = 0;
                lstagent = agentBAL.ReadUsers(AgentName, LocId,0);
            }
            else
            {
                lstagent = agentBAL.ReadUsers(AgentName, LocId, basePage.LoggedInUser.AgentId);
            }
            if (lstagent[0].AgentAddress != null)
            {
                AgentPhone = lstagent[0].AgentPhone;
                AgentAddress = lstagent[0].AgentAddress;
            }
            else
            {
                AgentPhone = "";
                AgentAddress = "";
            }
            if (rbtnInvoice.SelectedValue == "1" || rbtnInvoice.SelectedValue == "2")
            {
                billDOM = (Bill)Session["billDOM"];
                Session["billDOM"] = billDOM;
            }
            else
            {
                billDOM = (Bill)Session["billDOMM"];
                Session["billDOM"] = billDOM;
            }

            Session["AgentAddress"] = AgentAddress;
            Session["AgentPhone"] = AgentPhone;
            Response.Write("<script LANGUAGE='JavaScript' >alert(' Record Saved Successfully')</script>");
            btnPreview.Visible = true;
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            if (ConsignmentId > 0)
            {
                string url = "PreviewPrintInvoice.aspx?CG_Id=" + ConsignmentId;
                string fullURL = "window.open('" + url + "', '_blank', 'height=500,width=800,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=no,titlebar=no' );";
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
            }
        }

        protected void gvInvoice_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (basePage.LoggedInUser.UserTypeId == Convert.ToInt32(UserType.SuperAdmin))
            {
                if (e.CommandName == "Edit")
                {
                    cmdId = 0;
                }
            }
            else
            {
                if (e.CommandName == "Edit")
                {
                    cmdId = 1;
                    ModalPopupExtender1.Show();
                }
                else
                {
                    cmdId = 2;
                }
            }
        }

        protected void gvItemDesc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (Session["tempdata"] != null)
            {
                List<BillItem> lstData = (List<BillItem>)Session["tempdata"];
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                if (lstData.Count > 0)
                {
                    lstData.Remove(lstData[rowIndex]);
                    Session["tempdata"] = lstData;
                    gvItemDesc.DataSource = lstData;
                    gvItemDesc.DataBind();
                }
            }
        }

        protected void txt_serviceCharge_TextChanged(object sender, EventArgs e)
        {
            CalculateNorAmt();
        }

        protected void txt_serviceTax_TextChanged(object sender, EventArgs e)
        {
            CalculateNorAmt();
        }

        protected void txt_totalAmt_TextChanged(object sender, EventArgs e)
        {
            CalculateNorAmt();
        }

        protected void txtSerTax_TextChanged(object sender, EventArgs e)
        {
            CalculateAdAmt();
        }

        protected void txtSerCharge_TextChanged(object sender, EventArgs e)
        {
            CalculateAdAmt();
        }

        protected void txtAmt_TextChanged(object sender, EventArgs e)
        {
            CalculateAdAmt();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Label3.Text = string.Empty;
            string UserName = txtUserName.Text;
            string Password = txtPassword.Text;
            int RtValue = generateInvoiceBal.LoginWithSuperAdmin(UserName, Password);
            if (RtValue != 0)
            {
                cmdId = 0;
                gvInvoice_RowEditing(null, null);
            }
            else
            {
                gvInvoice_RowCancelingEdit(null, null);
                Label3.Text = "UserName Or Password has Incorrected..";
                ModalPopupExtender1.Show();
                //Response.Write("<script LANGUAGE='JavaScript' >alert('UserName Or Password has Incorrected')</script>");
            }
        }

        protected void btnCnl_Click(object sender, EventArgs e)
        {
            Label3.Text = string.Empty;
            gvInvoice_RowCancelingEdit(null, null);
        }
        #endregion

        #region Public Method..

        public void CalculateNorAmt()
        {
            serviceAmount = Convert.ToDecimal(txt_totalAmt.Text);
            decimal SrvChr = Convert.ToDecimal(txt_serviceCharge.Text);
            ServiceTax = Convert.ToDecimal(txt_serviceTax.Text);
            txt_NetAmt.Text = Convert.ToString(serviceAmount + SrvChr + ServiceTax);
        }

        public void CalculateAdAmt()
        {
            serviceAmount = Convert.ToDecimal(txtAmt.Text);
            decimal SrvChr = Convert.ToDecimal(txtSerCharge.Text);
            ServiceTax = Convert.ToDecimal(txtSerTax.Text);
            txtNetAmt.Text = Convert.ToString(serviceAmount + SrvChr + ServiceTax);
        }

        public void BindRecieptId()
        {
            lstReciept = recieptBAL.AdjustmentAmount(AgentId);
            if (lstReciept.Count == 0)
            {
                lblAdjAmt.Visible = false;
            }
            else
            {
                lblAdjAmt.Visible = true;
                chkAdjestAdvance.DataSource = lstReciept;
                chkAdjestAdvance.DataTextField = "RcptNoAdvAdj";
                chkAdjestAdvance.DataValueField = "RcptNo";
                chkAdjestAdvance.DataBind();
            }
        }

        public void AdjustAdvanceReciept()
        {

            LocId = basePage.LoggedInUser.UserLocation.LocationId;
            billDOM = (Bill)Session["billDOM"];
            int BilllId = Convert.ToInt32(Session["billId"]);
            if (rbtnInvoice.SelectedValue == "2" || rbtnInvoice.SelectedValue == "1")
            {
                InvCharge = Convert.ToDecimal(txt_NetAmt.Text);
            }
            else
            {
                InvCharge = Convert.ToDecimal(txtNetAmt.Text);
            }
            lstReciept = recieptBAL.AdjustmentAmount(AgentId);
            foreach (ListItem item in chkAdjestAdvance.Items)
            {
                foreach (Receipt rcpt in lstReciept)
                {

                    Int64 reciptId = rcpt.RcptNo;
                    Decimal Amount = rcpt.AdvAdj;
                    if (InvCharge > 0)
                    {
                        if (item.Selected == true && reciptId == Convert.ToInt64(item.Value))
                        {
                            if (InvCharge <= Amount)
                            {
                                ReceiptDetails recieptDetal = new ReceiptDetails();
                                recieptDetal.FkRcptId = rcpt.RcptNo;
                                recieptDetal.InvoiceNo = BilllId;
                                recieptDetal.InvoiceAmount = InvCharge;
                                recieptDetal.AdjustedAmount = InvCharge;
                                recieptDetal.LocationId = LocId;
                                recieptBAL.InsertAdustedAmount(recieptDetal);
                                lstReciept1 = recieptBAL.ReadTotalAdjustedAmount(reciptId);
                                decimal totalAmount = lstReciept1[0].AdjustedAmount;
                                rect.AdvAdj = totalAmount;
                                recieptBAL.UpdateAdjustedReciept(rect, reciptId);
                                InvCharge = 0;
                            }
                            else if (InvCharge > Amount)
                            {
                                ReceiptDetails recieptDetal = new ReceiptDetails();
                                recieptDetal.FkRcptId = rcpt.RcptNo;
                                recieptDetal.InvoiceNo = BilllId;
                                recieptDetal.InvoiceAmount = InvCharge;
                                recieptDetal.AdjustedAmount = Amount; ;
                                recieptDetal.LocationId = LocId;
                                recieptBAL.InsertAdustedAmount1(recieptDetal);
                                lstReciept1 = recieptBAL.ReadTotalAdjustedAmount(reciptId);
                                decimal totalAmount = lstReciept1[0].AdjustedAmount;
                                rect.AdvAdj = totalAmount;
                                recieptBAL.UpdateAdjustedReciept(rect, reciptId);
                                UnAdjAmt = InvCharge - Amount;
                                InvCharge = UnAdjAmt;
                            }
                        }
                    }
                }
            }
        }

        public void BindgvInvoice(List<AdditonalInfo> lstpax, Int32 AgentId)
        {
            LocId = basePage.LoggedInUser.UserLocation.LocationId;
            billDOM.BillItemDetails = new List<BillItem>();

            if (rbtnInvoice.SelectedValue == "2" || Convert.ToString(Session["Type"]) == "Normal")
            {
                if (lstBillItem == null && billIdds == 0)
                {
                    lstBillItem = generateInvoiceBal.ReadInvoiceDetals(lstpax, AgentId);
                    flag = 1;
                }
                else if (lstBillItem == null && billIdds != 0)
                {
                    lstBillItem = generateInvoiceBal.ReadBillItemRePrintInvoice(billIdds, 0, version);
                    rbtnInvoice.SelectedValue = Convert.ToString(2);
                }
                lstServiceTax = generateInvoiceBal.ReadServiceTax();
                lstServiceCharge = generateInvoiceBal.ReadServiceCharge();
                serviceAmount = lstServiceCharge[0].ServiceCharge;
                serviceCharge = Convert.ToInt32(serviceAmount);
                txt_serviceCharge.Text = Convert.ToString(serviceAmount);
                lbl_serviceTax.Text = "(" + Convert.ToString(lstServiceTax[0].ServiceTax) + "%" + ")";
                ServiceTax = Convert.ToDecimal(serviceCharge * (lstServiceTax[0].ServiceTax / 100));
                txt_serviceTax.Text = Convert.ToString(String.Format("{0:0.00}", ServiceTax));
                Dictionary<int, int> uniqueCountryId = new Dictionary<int, int>();
                for (int j = 0; j < lstpax.Count; j++)
                {
                    itemQuantity = lstpax.Count(a => a.CountryId == lstpax[j].CountryId);
                    if (uniqueCountryId.ContainsKey(lstpax[j].CountryId))
                    {

                    }
                    else
                    {
                        for (i = 0; i < lstBillItem.Count; i++)
                        {
                            if (flag == 1)
                            {
                                if (lstBillItem[i].CountryId != 0)
                                {
                                    if (lstpax[j].CountryId == lstBillItem[i].CountryId)
                                    {
                                        lstBillItem[i].ItemQuantity = itemQuantity;
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {
                                    lstBillItem[i].ItemQuantity = quantity;
                                }
                            }
                            else
                            {
                                lstBillItem[i].ItemQuantity = lstBillItem[i].ItemQuantity;
                            }
                        }
                        uniqueCountryId.Add(lstpax[j].CountryId, 0);
                    }
                }
                for (i = 0; i < lstBillItem.Count; i++)
                {
                    billDOM.BillItemDetail = new BillItem();
                    lstBillItem[i].ItemAmount = lstBillItem[i].ItemQuantity * lstBillItem[i].ItemCharge;
                    lstBillItem[i].TotalAmount = (lstBillItem.Sum(m => m.ItemAmount) + Convert.ToDecimal(serviceCharge) + Convert.ToDecimal(ServiceTax));
                    billDOM.BillItemDetail.BillItemDescription = lstBillItem[i].BillItemDescription;
                    billDOM.BillItemDetail.ItemCharge = lstBillItem[i].ItemCharge;
                    billDOM.BillItemDetail.ItemQuantity = lstBillItem[i].ItemQuantity;
                    billDOM.BillItemDetail.ItemAmount = lstBillItem[i].ItemAmount;
                    billDOM.BillItemDetails.Add(billDOM.BillItemDetail);
                }
                if (rbtnInvoice.SelectedValue == "1")
                {
                    billDOM.BillType = "Advance";
                }
                else if (rbtnInvoice.SelectedValue == "2")
                {
                    billDOM.BillType = "Normal";
                }
                billDOM.BillDate = DateTime.Now;
                billDOM.ServiceCharge = serviceAmount;
                billDOM.ServiceTax = ServiceTax;
                billDOM.ConsignmentId = ConsignmentId;
                billDOM.Paxs = PaxName;
                billDOM.LocationId = LocId;
                billDOM.TotalAmount = lstBillItem.Sum(m => m.ItemAmount);
                txt_totalAmt.Text = lstBillItem.Sum(m => m.ItemAmount).ToString();
                txt_NetAmt.Text = Convert.ToString(String.Format("{0:0.00}", (Convert.ToDecimal(txt_totalAmt.Text) + serviceCharge + ServiceTax)));
                lstBill.Add(billDOM);
                Session["billDOM"] = billDOM;
                gvInvoice.DataSource = lstBillItem;
                gvInvoice.DataBind();
            }
            else
            {
                if (lstBillItemm == null && billIdds == 0)
                {
                    lstBillItemm = generateInvoiceBal.ReadInvoiceDetals(lstpax, AgentId);
                    flag = 1;
                }
                else if (lstBillItemm == null && billIdds != 0)
                {
                    lstBillItemm = generateInvoiceBal.ReadBillItemRePrintInvoice(billIdds, 0, version);
                    rbtnInvoice.SelectedValue = Convert.ToString(1);

                }
                lstServiceTax = generateInvoiceBal.ReadServiceTax();
                lstServiceCharge = generateInvoiceBal.ReadServiceCharge();
                serviceAmount = lstServiceCharge[0].ServiceCharge;
                serviceCharge = Convert.ToInt32(serviceAmount);
                txt_serviceCharge.Text = Convert.ToString(serviceAmount);
                lbl_serviceTax.Text = "(" + Convert.ToString(lstServiceTax[0].ServiceTax) + "%" + ")";
                ServiceTax = Convert.ToDecimal(serviceCharge * (lstServiceTax[0].ServiceTax / 100));
                txt_serviceTax.Text = Convert.ToString(String.Format("{0:0.00}", ServiceTax));
                Dictionary<int, int> uniqueCountryId = new Dictionary<int, int>();
                for (int j = 0; j < lstpax.Count; j++)
                {
                    itemQuantity = lstpax.Count(a => a.CountryId == lstpax[j].CountryId);
                    if (uniqueCountryId.ContainsKey(lstpax[j].CountryId))
                    {
                    }
                    else
                    {
                        for (i = 0; i < lstBillItemm.Count; i++)
                        {
                            if (flag == 1)
                            {
                                if (lstBillItemm[i].CountryId != 0)
                                {
                                    if (lstpax[j].CountryId == lstBillItemm[i].CountryId)
                                    {
                                        lstBillItemm[i].ItemQuantity = itemQuantity;
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {
                                    lstBillItemm[i].ItemQuantity = quantity;
                                }
                            }
                            else
                            {
                                lstBillItemm[i].ItemQuantity = lstBillItemm[i].ItemQuantity;
                            }
                        }
                        uniqueCountryId.Add(lstpax[j].CountryId, 0);
                    }
                }

                for (i = 0; i < lstBillItemm.Count; i++)
                {
                    billDOM.BillItemDetail = new BillItem();
                    lstBillItemm[i].ItemAmount = lstBillItemm[i].ItemQuantity * lstBillItemm[i].ItemCharge;
                    lstBillItemm[i].TotalAmount = (lstBillItemm.Sum(m => m.ItemAmount) + Convert.ToDecimal(serviceCharge) + Convert.ToDecimal(ServiceTax));
                    billDOM.BillItemDetail.BillItemDescription = lstBillItemm[i].BillItemDescription;
                    billDOM.BillItemDetail.ItemCharge = lstBillItemm[i].ItemCharge;
                    billDOM.BillItemDetail.ItemQuantity = lstBillItemm[i].ItemQuantity;
                    billDOM.BillItemDetail.ItemAmount = lstBillItemm[i].ItemAmount;
                    billDOM.BillItemDetails.Add(billDOM.BillItemDetail);
                }

                if (rbtnInvoice.SelectedValue == "1")
                {
                    billDOM.BillType = "Advance";
                }
                else if (rbtnInvoice.SelectedValue == "2")
                {
                    billDOM.BillType = "Normal";
                }
                billDOM.BillDate = DateTime.Now;
                billDOM.ServiceCharge = serviceAmount;
                billDOM.ServiceTax = ServiceTax;
                billDOM.ConsignmentId = ConsignmentId;
                billDOM.Paxs = PaxName;
                billDOM.LocationId = LocId;
                billDOM.TotalAmount = lstBillItemm.Sum(m => m.ItemAmount);
                txt_totalAmt.Text = lstBillItemm.Sum(m => m.ItemAmount).ToString();
                txt_NetAmt.Text = Convert.ToString(String.Format("{0:0.00}", (Convert.ToDecimal(txt_totalAmt.Text) + serviceCharge + ServiceTax)));
                lstBill.Add(billDOM);
                Session["billDOM"] = billDOM;
                gvInvoice.DataSource = lstBillItemm;
                gvInvoice.DataBind();
            }
        }

        public void BindMicCharge()
        {

            ddlMiscelaCharge.DataSource = miscellaneousBAL.ReadMicDescription();
            ddlMiscelaCharge.DataTextField = "Description";
            ddlMiscelaCharge.DataValueField = "Id";
            ddlMiscelaCharge.DataBind();
            ListItem item = new ListItem("-Select-", "0");
            ddlMiscelaCharge.Items.Insert(0, item);

        }

        #endregion

        #region Privat Method

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            billDOM.BillItemDetail = new BillItem();
            billDOM.BillItemDetails = new List<BillItem>();
            List<BillItem> lst = new List<BillItem>();
            CalculateTexCharges();
            LocId = basePage.LoggedInUser.UserLocation.LocationId;
            billItemDOM.BillItemDescription = txtItemDesc.Text.Trim();
            billItemDOM.ItemQuantity = Convert.ToInt32(txtQuantity.Text.Trim());
            billItemDOM.ItemCharge = Convert.ToDecimal(txtRate.Text.Trim());
            billItemDOM.ItemAmount = CalculateAmount();
            List<BillItem> lstData = (List<BillItem>)Session["tempdata"];
            if (Session["tempdata"] != null)
            {
                lstData.Add(billItemDOM);
                Session["tempdata"] = lstData;
                billDOM.BillItemDetails = lstData;
                billDOM.ServiceCharge = serviceCharge;
                billDOM.ServiceTax = ServiceTax;
                billDOM.BillType = "Additional";
                billDOM.BillDate = DateTime.Now;
                billDOM.ConsignmentId = ConsignmentId;
                billDOM.Paxs = PaxName;
                billDOM.LocationId = LocId;
                decimal amt = Convert.ToDecimal((lstData.Sum(Items => Items.ItemAmount)).ToString());
                billDOM.TotalAmount = amt;
            }
            else
            {
                lst.Add(billItemDOM);
                Session["tempdata"] = lst;
                billDOM.BillItemDetails = lst;
                billDOM.ServiceCharge = serviceCharge;
                billDOM.ServiceTax = ServiceTax;
                billDOM.BillType = "Additional";
                billDOM.BillDate = DateTime.Now;
                billDOM.ConsignmentId = ConsignmentId;
                billDOM.Paxs = PaxName;
                billDOM.LocationId = LocId;
                decimal amt = Convert.ToDecimal((lst.Sum(Items => Items.ItemAmount)).ToString());
                billDOM.TotalAmount = amt;
            }

            Session["billDOMM"] = billDOM;
            BindGrid();
            ClearItems();
            txtItemDesc.Focus();
        }

        public void BindAdditionalGrid()
        {
            List<BillItem> lst = new List<BillItem>();
            List<BillItem> lstD = new List<BillItem>();
            CalculateTexCharges();
            LocId = basePage.LoggedInUser.UserLocation.LocationId;
            if (Session["Type"] != null)
            {
                lst = generateInvoiceBal.ReadBillItemRePrintInvoice(billIdds, 0, version);
                for (i = 0; i < lst.Count; i++)
                {
                    BillItem billitm = new BillItem();
                    billitm.BillItemDescription = lst[i].BillItemDescription;
                    billitm.ItemCharge = lst[i].ItemCharge;
                    billitm.ItemQuantity = lst[i].ItemQuantity;
                    billitm.ItemAmount = lst[i].ItemQuantity * lst[i].ItemCharge;
                    lstD.Add(billitm);
                }
            }
            Session["tempdata"] = lstD;
            billDOM.BillItemDetails = lstD;
            billDOM.ServiceCharge = serviceCharge;
            billDOM.ServiceTax = ServiceTax;
            billDOM.BillType = "Additional";
            billDOM.BillDate = DateTime.Now;
            billDOM.ConsignmentId = ConsignmentId;
            billDOM.Paxs = PaxName;
            billDOM.LocationId = LocId;
            decimal amt = Convert.ToDecimal((lstD.Sum(Items => Items.ItemAmount)).ToString());
            billDOM.TotalAmount = amt;

            Session["billDOMM"] = billDOM;
            BindGrid();
        }

        private void BindGrid()
        {
            if (Session["tempdata"] != null)
            {
                List<BillItem> lstData = (List<BillItem>)Session["tempdata"];
                gvItemDesc.DataSource = lstData;
                gvItemDesc.DataBind();
                Calculate_TotalAmt();
            }
        }

        private void CalculateTexCharges()
        {
            lstServiceTax = generateInvoiceBal.ReadServiceTax();
            lstServiceCharge = generateInvoiceBal.ReadServiceCharge();
            serviceAmount = lstServiceCharge[0].ServiceCharge;
            serviceCharge = Convert.ToInt32(serviceAmount);
            txtSerCharge.Text = Convert.ToString(serviceAmount);
            lbl_serviceTax.Text = "(" + Convert.ToString(lstServiceTax[0].ServiceTax) + "%" + ")";
            ServiceTax = Convert.ToDecimal(serviceCharge * (lstServiceTax[0].ServiceTax / 100));
            txtSerTax.Text = Convert.ToString(String.Format("{0:0.00}", ServiceTax));
        }

        private void Calculate_TotalAmt()
        {
            if (Session["tempdata"] != null)
            {
                List<BillItem> lstData = (List<BillItem>)Session["tempdata"];
                decimal amt = Convert.ToDecimal((lstData.Sum(Items => Items.ItemAmount)).ToString());
                txtAmt.Text = Convert.ToString(String.Format("{0:0.00}", amt));
                txtNetAmt.Text = Convert.ToString(String.Format("{0:0.00}", (Convert.ToDecimal(amt) + Convert.ToDecimal(txtSerCharge.Text) + Convert.ToDecimal(txtSerTax.Text))));
            }
        }

        private decimal CalculateAmount()
        {
            Decimal amount = 0;
            int Qnt = 0;
            decimal total = 0;
            Decimal charge = 0;
            if (!string.IsNullOrEmpty(txtQuantity.Text.Trim()) && !string.IsNullOrEmpty(txtRate.Text.Trim()))
            {
                Qnt = Convert.ToInt32(txtQuantity.Text.Trim());
                charge = Convert.ToDecimal(txtRate.Text.Trim());
                amount = Qnt * charge;
            }
            return amount;
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow item in gvItemDesc.Rows)
                {
                    List<BillItem> lstData = (List<BillItem>)Session["tempdata"];
                    System.Web.UI.WebControls.CheckBox chk = (System.Web.UI.WebControls.CheckBox)item.FindControl("chkRemove");
                    if (chk.Checked == true)
                    {
                        int index = item.RowIndex;
                        lstData.RemoveAt(index);
                        Session["tempdata"] = lstData;
                        BindGrid();
                    }
                    else if (item.RowIndex == gvItemDesc.Rows.Count - 1 && chk.Checked != true)
                    {
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Success", String.Format("alert('{0}');", "Select Any Record to Remove "), true);
                    }

                    Calculate_TotalAmt();
                }

                txtItemDesc.Focus();
            }
            catch (Exception exp)
            {

            }

        }

        protected void txtRate_TextChanged(object sender, EventArgs e)
        {
            txtAmount.Text = CalculateAmount().ToString();
            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                txtQuantity.Focus();
            }
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            txtAmount.Text = CalculateAmount().ToString();
            if (string.IsNullOrEmpty(txtRate.Text))
            {
                txtRate.Focus();
            }
        }

        private void ClearItems()
        {
            txtItemDesc.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtRate.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtItemDesc.Focus();
        }

        #endregion

        #region Public Properties..

        public int cmdId
        {
            get
            {
                return Convert.ToInt32(Session["cmdId"]);
            }
            set
            {
                Session["cmdId"] = value;
            }
        }
        public int billIdds
        {
            get
            {
                return Convert.ToInt32(Session["billIdds"]);
            }
            set
            {
                Session["billIdds"] = value;
            }
        }
        public int version
        {
            get
            {
                return Convert.ToInt32(Session["version"]);
            }
            set
            {
                Session["version"] = value;
            }
        }

        public string ex
        {
            get
            {
                return Convert.ToString(Session["ex"]);
            }
            set
            {
                Session["ex"] = value;
            }
        }

        public List<AdditonalInfo> lstpax
        {
            get
            {
                return (List<AdditonalInfo>)Session["lstpax"];
            }
            set
            {
                Session["lstpax"] = value;
            }
        }

        public int AgentId
        {
            get
            {
                return Convert.ToInt32(Session["AgentId"]);
            }
            set
            {
                Session["AgentId"] = value;
            }
        }

        public int quantity
        {
            get
            {
                return Convert.ToInt32(Session["quantity"]);
            }
            set
            {
                Session["quantity"] = value;
            }
        }

        public int CountryId
        {
            get
            {
                return Convert.ToInt32(Session["CountryId"]);
            }
            set
            {
                Session["CountryId"] = value;
            }
        }

        public int ConsignmentId
        {
            get
            {
                return Convert.ToInt32(Session["ConsignmentId"]);
            }
            set
            {
                Session["ConsignmentId"] = value;
            }
        }

        public string AgentName
        {
            get
            {
                return Convert.ToString(Session["AgentName"]);
            }
            set
            {
                Session["AgentName"] = value;
            }
        }

        public string PaxName
        {
            get
            {
                return Convert.ToString(Session["PaxName"]);
            }
            set
            {
                Session["PaxName"] = value;
            }
        }

        public List<BillItem> lstBillItem
        {
            get
            {
                return (List<BillItem>)Session["lstBillItem"];
            }
            set
            {
                Session["lstBillItem"] = value;
            }
        }
        public List<BillItem> lstBillItemm
        {
            get
            {
                return (List<BillItem>)Session["lstBillItemm"];
            }
            set
            {
                Session["lstBillItemm"] = value;
            }
        }

        #endregion
    }
}