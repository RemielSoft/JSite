using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using JSVisaTrackingWebApplication.Shared;

namespace JSVisaTrackingWebApplication
{
    public partial class InvoiceList : System.Web.UI.Page
    {
        InvoiceListBusinessAccess invoiceBal = new InvoiceListBusinessAccess();
        SummaryReportBusinessAccess summaryBusinessAccess = new SummaryReportBusinessAccess();
        GenerateInvoiceBAL generateBAL = new GenerateInvoiceBAL();
        List<Bill> lstBillLt = new List<Bill>();
        List<Bill> lstBill = new List<Bill>();
        List<Bill> lstBillid = new List<Bill>();
        List<Bill> lstBillCt = new List<Bill>();
        BasePage basePage = new BasePage();
        int userId;
        int LocId = 0;
        int id = 0;
        string agentName;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //txtFromDate.Text = DateTime.Now.ToShortDateString();
                //txtToDate.Text = DateTime.Now.ToShortDateString();
                if (basePage.LoggedInUser.UserLocation != null)
                {
                    LocId = basePage.LoggedInUser.UserLocation.LocationId;
                }
                userId = basePage.LoggedInUser.UserTypeId;
                if (userId == Convert.ToInt32(UserType.Admin) || userId == Convert.ToInt32(UserType.SuperAdmin))
                {

                    basePage.BindDropDown(ddlagentName, "AgentName", "AgentId", summaryBusinessAccess.Agentbind(null, null));
                }
                else
                {
                    basePage.BindDropDown(ddlagentName, "AgentName", "AgentId", summaryBusinessAccess.Agentbind(LocId, basePage.LoggedInUser.AgentId));
                    ddlagentName.SelectedValue = basePage.LoggedInUser.AgentId.ToString();
                    ddlagentName.Enabled = false;
                }
            }
        }

        public List<Bill> GetInvoiceList()
        {
            List<Bill> lstBill = new List<Bill>();
            if (basePage.LoggedInUser.UserLocation != null)
            {
                LocId = basePage.LoggedInUser.UserLocation.LocationId;
            }
            int userId = basePage.LoggedInUser.UserTypeId;
            if (rbtnInvoiceLst.SelectedValue == "1")
            {


                if (txtDocumentNo.Text != "")
                {
                    int billId = Convert.ToInt32(txtDocumentNo.Text);
                    if (userId == Convert.ToInt32(UserType.Admin))
                    {

                        lstBill = invoiceBal.ReadDataByInvoiceBillId(billId, LocId);
                    }
                    else
                    {
                        lstBill = invoiceBal.ReadDataByInvoiceBillId(billId, LocId);
                    }
                }
                else if (txtConsignMntNO.Text != "")
                {

                    id = Convert.ToInt32(txtConsignMntNO.Text);
                    if (userId == Convert.ToInt32(UserType.Admin) || userId == Convert.ToInt32(UserType.SuperAdmin))
                    {
                        LocId = 0;
                        lstBill = generateBAL.ReadConsignmentDetailsById(id, LocId);
                    }
                    else
                    {
                        lstBillLt = generateBAL.ReadConsignmentDetailsById(id, LocId);
                    }
                    txtConsignMntNO.Text = string.Empty;
                }

                else if (txtFromDate.Text != "" && txtToDate.Text != "" && ddlagentName.SelectedItem.Value != "0")
                {
                    DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
                    DateTime toDate = Convert.ToDateTime(txtToDate.Text);
                    agentName = Convert.ToString(ddlagentName.SelectedItem.Text);
                    if (userId == Convert.ToInt32(UserType.Admin) || userId == Convert.ToInt32(UserType.SuperAdmin))
                    {
                        LocId = 0;
                        lstBill = generateBAL.ReadConsignmentDetailsByAgentNameAndDate(agentName, fromDate, toDate);
                        ddlagentName.SelectedIndex = 0;
                    }
                    else
                    {
                        lstBill = generateBAL.ReadConsignmentDetailsByAgentNameAndDate(agentName, fromDate, toDate);
                    }
                   // ddlagentName.SelectedIndex = 0;
                }

                else if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
                    DateTime toDate = Convert.ToDateTime(txtToDate.Text);
                    var totalDays = (toDate - fromDate).TotalDays;
                    if (userId == Convert.ToInt32(UserType.Admin))
                    {
                        LocId = 0;
                        lstBill = invoiceBal.ReadDataByInvoiceDates(fromDate, toDate, LocId);
                    }
                    else
                    {
                        if (totalDays <= 90)
                        {
                            lstBill = invoiceBal.ReadDataByInvoiceDates(fromDate, toDate, LocId);
                        }
                        else
                        {
                            Response.Write("<script LANGUAGE='JavaScript' >alert('You Con seen only Three month invoice.')</script>");
                        }
                    }
                }
                else if (ddlagentName.SelectedItem.Value != "0")
                {
                    agentName = Convert.ToString(ddlagentName.SelectedItem.Text);
                    if (userId == Convert.ToInt32(UserType.Admin) || userId == Convert.ToInt32(UserType.SuperAdmin))
                    {
                        LocId = 0;
                        lstBill = generateBAL.ReadConsignmentDetailsByAgentName(agentName, LocId);
                        ddlagentName.SelectedIndex = 0;
                    }
                    else
                    {
                        lstBill = generateBAL.ReadConsignmentDetailsByAgentName(agentName, LocId);
                    }
                   // ddlagentName.SelectedIndex = 0;
                }

                else
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Please Enter Value For Search Invoice.')</script>");
                }
                Session["lstBill"] = lstBill;

            }
            #region Comment By Rk chauhan Removing Radio button Recipt
            //else if (rbtnInvoiceLst.SelectedValue == "2")
            //{
            //    if (txtDocumentNo.Text != "")
            //    {
            //        int receiptId = Convert.ToInt32(txtDocumentNo.Text);
            //        if (userId == Convert.ToInt32(UserType.Admin))
            //        {
            //            LocId = 0;
            //            lstBill = invoiceBal.ReadDataByReceiptId(receiptId, LocId);
            //        }
            //        else
            //        {
            //            lstBill = invoiceBal.ReadDataByReceiptId(receiptId, LocId);
            //        }

            //    }
            //    else if (txtConsignMntNO.Text != "")
            //    {

            //       int consignmentNo = Convert.ToInt32(txtConsignMntNO.Text);
            //        if (userId == Convert.ToInt32(UserType.Admin) || userId == Convert.ToInt32(UserType.SuperAdmin))
            //        {
            //            LocId = 0;
            //            lstBill = generateBAL.ReadReceiptBYConsignment(consignmentNo, LocId);
            //        }
            //        else
            //        {
            //            lstBillLt = generateBAL.ReadReceiptBYConsignment(consignmentNo, LocId);
            //        }
            //        txtConsignMntNO.Text = string.Empty;
            //    }
            //    else if (ddlagentName.SelectedItem.Value != "0")
            //    {
            //        agentName = Convert.ToString(ddlagentName.SelectedItem.Text);
            //        if (userId == Convert.ToInt32(UserType.Admin) || userId == Convert.ToInt32(UserType.SuperAdmin))
            //        {
            //            LocId = 0;
            //            lstBill = generateBAL.ReadReceiptBYAgentName(agentName, LocId);

            //        }
            //        else
            //        {
            //            lstBill = generateBAL.ReadReceiptBYAgentName(agentName, LocId);
            //        }
            //        ddlagentName.SelectedIndex = 0;
            //    }
            //    else
            //    {
            //        DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            //        DateTime toDate = Convert.ToDateTime(txtToDate.Text);
            //        if (userId == Convert.ToInt32(UserType.Admin))
            //        {
            //            LocId = 0;
            //            lstBill = invoiceBal.ReadDataByReceiptDates(fromDate, toDate, LocId);
            //        }
            //        else
            //        {
            //            lstBill = invoiceBal.ReadDataByReceiptDates(fromDate, toDate, LocId);
            //        }

            //    }

            //}
            #endregion
            return lstBill;
        }
        public void BindGrid()
        {

            lstBill = GetInvoiceList();
            if (lstBill.Count > 0)
            {
                gridviewInvoiceList.DataSource = lstBill;
                gridviewInvoiceList.DataBind();
                gridviewInvoiceList.Visible = true;
                Clear();
            }
            else
            {

                Response.Write("<script LANGUAGE='JavaScript' >alert('No Record Found. ')</script>");

            }
        }
        protected void BtnGo_Click(object sender, EventArgs e)
        {

            BindGrid();

            foreach (DataControlField col in gridviewInvoiceList.Columns)
            {
                if (col.HeaderText == "Ref No.")
                {
                    if (rbtnInvoiceLst.SelectedValue == "2")
                    {
                        col.Visible = false;
                    }
                    else
                    {
                        col.Visible = true;
                    }
                }
            }

            txtConsignMntNO.Text = "";
            txtDocumentNo.Text = "";

        }


        #region Public Method..
        public void BindGridView()
        {
            lstBillLt = (List<Bill>)Session["lstBillLt"];
            if (lstBillLt.Count == 0)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Record Not Found')</script>");
            }
            else
            {
                for (int i = 0; i < lstBillLt.Count; i++)
                {

                    int CgId = lstBillLt[i].ConsignmentId;
                    lstBillCt = generateBAL.ReadCountCGIDBill(CgId);
                    Dictionary<int, int> uniqueCountryId = new Dictionary<int, int>();
                    if (lstBillCt.Count != 3)
                    {
                        if (uniqueCountryId.ContainsKey(CgId))
                        {
                        }
                        else
                        {
                            LocId = 0;
                            lstBillid = generateBAL.ReadConsignmentDetailsById(CgId, LocId);
                            lstBill.AddRange(lstBillid);
                        }
                    }
                }
                if (lstBill.Count == 0)
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Record Not Found')</script>");
                }
                else
                {
                    gridviewInvoiceList.DataSource = lstBill;
                    gridviewInvoiceList.DataBind();
                    Session["lstBill"] = lstBill;
                }
                Session.Remove("lstBillLt");
            }
        }
        #endregion
        protected void rbtnInvoiceLst_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridviewInvoiceList.Visible = true;
            if (rbtnInvoiceLst.SelectedValue == "2")
            {
                txtConsignMntNO.Enabled = true;
            }
            else
            {
                txtConsignMntNO.Enabled = true;
            }
        }

        protected void gridviewInvoiceList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewInvoiceList.PageIndex = e.NewPageIndex;
            BindGrid();

        }

        protected void gridviewInvoiceList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int flag = 0;
            string commndString = e.CommandArgument.ToString();
            string[] str = commndString.Split(',');

            if (e.CommandName == "Print")
            {
                if (rbtnInvoiceLst.SelectedValue == "1")
                {
                    Bill billDOM = new Bill();
                    GenerateInvoiceBAL generateBAL = new GenerateInvoiceBAL();
                    List<Bill> lstBill = (List<Bill>)Session["lstBill"];
                    List<BillItem> lstBillItem = new List<BillItem>();
                    billDOM.BillItemDetails = new List<BillItem>();
                    billDOM.BillConsignment = new Consignment();
                    if (basePage.LoggedInUser.UserLocation != null)
                    {
                        int LocId = basePage.LoggedInUser.UserLocation.LocationId;
                    }
                    int userId = basePage.LoggedInUser.UserTypeId;
                    string strg = e.CommandArgument.ToString();
                    string[] str1 = strg.Split(',');
                    int Billid = Convert.ToInt32(str1[0]);
                    int versionNo = Convert.ToInt32(str1[1]);
                    Session["version"] = versionNo;
                    if (versionNo == 0)
                    {
                        for (int i = 0; i < lstBill.Count; i++)
                        {
                            if (Billid == lstBill[i].BillId)
                            {
                                Session["flag"] = 1;
                                int billId = lstBill[i].BillId;
                                int CG_Id = lstBill[i].ConsignmentId;
                                if (userId == Convert.ToInt32(UserType.Admin) || userId == Convert.ToInt32(UserType.SuperAdmin))
                                {
                                    LocId = 0;
                                    lstBillItem = generateBAL.ReadBillItemRePrintInvoice(billId, null, null);
                                }
                                else
                                {
                                    lstBillItem = generateBAL.ReadBillItemRePrintInvoice(billId, null, null);
                                }

                                for (int j = 0; j < lstBillItem.Count; j++)
                                {
                                    billDOM.BillItemDetail = new BillItem();
                                    billDOM.BillItemDetail.BillItemDescription = lstBillItem[j].BillItemDescription;
                                    billDOM.BillItemDetail.ItemCharge = lstBillItem[j].ItemCharge;
                                    billDOM.BillItemDetail.ItemQuantity = lstBillItem[j].ItemQuantity;
                                    billDOM.BillItemDetail.ItemAmount = lstBillItem[j].ItemCharge * lstBillItem[j].ItemQuantity;
                                    billDOM.BillItemDetails.Add(billDOM.BillItemDetail);
                                }
                                billDOM.BillDate = lstBill[i].BillDate;
                                billDOM.BillId = lstBill[i].BillId;
                                billDOM.ServiceCharge = lstBill[i].ServiceCharge;
                                billDOM.ServiceTax = lstBill[i].ServiceTax;
                                billDOM.TotalAmount = lstBill[i].TotalAmount;
                                billDOM.Paxs = lstBill[i].Paxs;
                                billDOM.BillId = lstBill[i].BillId;

                                Session["billDOM"] = billDOM;
                                Session["AgentName"] = lstBill[i].AgentDetails.AgentName;
                                Session["AgentAddress"] = lstBill[i].AgentDetails.AgentAddress;
                                Session["AgentPhone"] = lstBill[i].AgentDetails.AgentPhone;
                                Session["ConsignmentId"] = CG_Id;
                            }
                        }
                    }
                    //else
                    //{
                    //    Response.Write("<script LANGUAGE='JavaScript' >alert('Please Select Version For Print Invoice. ')</script>");
                    //}
                    if (Billid > 0)
                    {

                        //Response.Redirect("PreviewPrintInvoice.aspx?CG_Id=" + ConsignmentId);
                        string url = "PreviewPrintInvoice.aspx?Bill_Id=" + Billid;
                        string fullURL = "window.open('" + url + "', '_blank', 'height=500,width=800,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=no,titlebar=no' );";
                        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                    }
                }
            }
            if (rbtnInvoiceLst.SelectedValue == "2")
                if (rbtnInvoiceLst.SelectedValue == "2")
                {
                    int rcptId = Convert.ToInt32(str[0]);

                    ReceiptGenerationBusinessAccess rcptGenerationBal = new ReceiptGenerationBusinessAccess();
                    List<Receipt> lstRcpt = new List<Receipt>();
                    // lstRcpt = rcptGenerationBal.ReadRcptAll(rcptId);
                    if (basePage.LoggedInUser.UserLocation != null)
                    {
                        int LocId = basePage.LoggedInUser.UserLocation.LocationId;
                    }
                    int userId = basePage.LoggedInUser.UserTypeId;
                    if (userId == Convert.ToInt32(UserType.Admin))
                    {
                        LocId = 0;
                        lstRcpt = rcptGenerationBal.ReadRcptAll(rcptId, LocId);
                    }
                    else
                    {
                        lstRcpt = rcptGenerationBal.ReadRcptAll(rcptId, LocId);
                    }

                    List<ReceiptDetails> lstRcptDetails = new List<ReceiptDetails>();
                    lstRcptDetails = rcptGenerationBal.ReadRcptDetailsByRcptNo(rcptId);
                    if (lstRcpt.Count == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('No Receipt Found With This Receipt No !!');", true);
                        txtFromDate.Focus();
                    }
                    else
                    {
                        Session["RcptId"] = rcptId;
                        Session["lstRcpt"] = lstRcpt;
                        if (lstRcpt[0].RcptType == "  Advance")
                        {
                            Session["NewlstReceipt"] = lstRcpt;
                            Session["agentName"] = lstRcpt[0].agent.AgentName;
                            if (rcptId > 0)
                            {
                                flag = 1;
                                Session["Flag"] = flag;
                                string url = "ReceiptPrint.aspx?receiptAdvance=" + rcptId;
                                string fullUrl = "window.open('" + url + "','_blank','height=500,width=800,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=no,titlebar=no,addressbars=0,directories=no');";
                                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullUrl, true);
                            }
                            else
                            {
                                Session["Flag"] = flag;
                            }
                        }
                        else
                        {
                            Session["NewlstRcptDetails"] = lstRcptDetails;
                            if (rcptId > 0)
                            {
                                flag = 1;
                                Session["Flag"] = flag;
                                string url = "ReceiptPrint.aspx?RcptId=" + rcptId;
                                string fullUrl = "window.open('" + url + "','_blank','height=500,width=800,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=no,titlebar=no,addressbars=0,directories=no');";
                                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullUrl, true);
                            }
                            else
                            {
                                Session["Flag"] = flag;
                            }
                        }
                    }

                }
        }

        private void Clear()
        {
            txtConsignMntNO.Text = "";
            txtDocumentNo.Text = "";
            txtFromDate.Text = "";
            txtToDate.Text = "";
        }
    }
}
