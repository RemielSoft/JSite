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
    public partial class printInvoice : System.Web.UI.Page
    {
        #region Global Variables..
        GenerateInvoiceBAL generateBAL = new GenerateInvoiceBAL();
        ConsignmentBusinessAccess consignmentBAL = new ConsignmentBusinessAccess();
        SummaryReportBusinessAccess summaryBusinessAccess = new SummaryReportBusinessAccess();
        List<BillItem> lstBillItem = new List<BillItem>();
        List<AdditonalInfo> lstaddpax = new List<AdditonalInfo>();
        BasePage basePage = new BasePage();
        Bill billDOM = new Bill();
        List<Bill> lstBill = new List<Bill>();
        #endregion

        #region Protected Method..
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int LocId = 0;
                int userId = 1;
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
            Session.Remove("CurrentTable");
            Session.Remove("lstpax");
            Session.Remove("AgentId");
            Session.Remove("lstBillItem");
            Session.Remove("lstBillItemm");
            Session.Remove("billitem");
            Session.Remove("tempdata");
            //Session.RemoveAll();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchCategory();
        }
        protected void gvPrintInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPrintInvoice.PageIndex = e.NewPageIndex;
            SearchCategory();
        }
        protected void gvPrintInvoice_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int version = 0;
            int Billid = 0;
            Bill billDOM = new Bill();
            billDOM.BillItemDetails = new List<BillItem>();
            List<Bill> lst = new List<Bill>();
            List<Bill> lstBill = (List<Bill>)Session["lstBill"];
            int LocId = 0;
            int userId = 1;

            if (e.CommandName == "lnkPrint")
            {
                string str = e.CommandArgument.ToString();
               
                string[] str1 = str.Split(',');
                Billid = Convert.ToInt32(str1[0]);
                int versionNo = Convert.ToInt32(str1[1]);
                version = Convert.ToInt32(Session["version"]);
                if (version != 0)
                {
                    for (int i = 0; i < lstBill.Count; i++)
                    {
                        if (Billid == lstBill[i].BillId)
                        {
                            Session["flag"] = 1;
                            int billId = lstBill[i].BillId;
                            int CG_Id = lstBill[i].ConsignmentId;
                            if (userId == 1 || userId == 4)
                            {
                                LocId = 0;
                                lstBillItem = generateBAL.ReadBillItemRePrintInvoice(billId, LocId, version);
                                lst = generateBAL.ReadBillRePrintInvoiceByBilId(billId, LocId, version);
                            }
                            else
                            {
                                lstBillItem = generateBAL.ReadBillItemRePrintInvoice(billId, LocId, version);
                                lst = generateBAL.ReadBillRePrintInvoiceByBilId(billId, LocId, version);
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
                            billDOM.BillDate = lst[0].BillDate;
                            billDOM.BillId = lst[0].BillId;
                            billDOM.ServiceCharge = lst[0].ServiceCharge;
                            billDOM.ServiceTax = lst[0].ServiceTax;
                            billDOM.TotalAmount = lst[0].TotalAmount;
                            billDOM.Paxs = lst[0].Paxs;
                            billDOM.BillId = lst[0].BillId;

                            Session["billDOM"] = billDOM;
                            Session["AgentName"] = lstBill[i].AgentDetails.AgentName;
                            Session["AgentAddress"] = lstBill[i].AgentDetails.AgentAddress;
                            Session["AgentPhone"] = lstBill[i].AgentDetails.AgentPhone;
                            Session["ConsignmentId"] = CG_Id;
                        }
                    }
                }
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Please Select Version For Print Invoice. ')</script>");
                }
                if (Billid > 0 && version > 0)
                {

                    //Response.Redirect("PreviewPrintInvoice.aspx?CG_Id=" + ConsignmentId);
                    string url = "PreviewPrintInvoice.aspx?Bill_Id=" + Billid;
                    string fullURL = "window.open('" + url + "', '_blank', 'height=500,width=800,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=no,titlebar=no' );";
                    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                }
            }
            if (e.CommandName == "lnkRePrint")
            {
                string str = e.CommandArgument.ToString();
                string[] str1 = str.Split(',');
                Billid = Convert.ToInt32(str1[0]);
                int versionNo = Convert.ToInt32(str1[1]);
                version = Convert.ToInt32(Session["version"]);
                if (version != 0)
                {
                    for (int i = 0; i < lstBill.Count; i++)
                    {
                        if (Billid == lstBill[i].BillId)
                        {
                            Session["flag"] = 2;
                            int billId = lstBill[i].BillId;
                            int CG_Id = lstBill[i].ConsignmentId;
                           
                            if (userId == 1 || userId == 4)
                            {
                                LocId = 0;
                                lstBillItem = generateBAL.ReadBillItemRePrintInvoice(billId, LocId, version);
                                lst = generateBAL.ReadBillRePrintInvoiceByBilId(billId, LocId, version);
                            }
                            else
                            {
                                lstBillItem = generateBAL.ReadBillItemRePrintInvoice(billId, LocId, version);
                                lst = generateBAL.ReadBillRePrintInvoiceByBilId(billId, LocId, version);
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
                            billDOM.BillDate = lst[0].BillDate;
                            billDOM.BillId = lst[0].BillId;
                            billDOM.ServiceCharge = lst[0].ServiceCharge;
                            billDOM.ServiceTax = lst[0].ServiceTax;
                            billDOM.TotalAmount = lst[0].TotalAmount;
                            billDOM.Paxs = lst[0].Paxs;
                            billDOM.BillId = lst[0].BillId;

                            Session["billDOM"] = billDOM;
                            Session["AgentName"] = lstBill[i].AgentDetails.AgentName;
                            Session["AgentAddress"] = lstBill[i].AgentDetails.AgentAddress;
                            Session["AgentPhone"] = lstBill[i].AgentDetails.AgentPhone;
                            Session["ConsignmentId"] = CG_Id;
                        }
                    }
                }
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Please Select Version For RePrint Invoice. ')</script>");
                }
                if (Billid > 0 && version > 0)
                {

                    //Response.Redirect("PreviewPrintInvoice.aspx?CG_Id=" + ConsignmentId);
                    string url = "PreviewPrintInvoice.aspx?Bill_Id=" + Billid;
                    string fullURL = "window.open('" + url + "', '_blank', 'height=500,width=800,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=no,titlebar=no' );";
                    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                }
            }
            if (e.CommandName == "lnkEdit")
            {
                string str = e.CommandArgument.ToString();
                string[] str1 = str.Split(',');
                Billid = Convert.ToInt32(str1[0]);
                int versionNo = Convert.ToInt32(str1[1]);
                Session["version"] = versionNo;
                for (int i = 0; i < lstBill.Count; i++)
                {
                    if (Billid == lstBill[i].BillId && versionNo == lstBill[i].Version)
                    {
                        int billId = lstBill[i].BillId;
                        int CG_Id = lstBill[i].ConsignmentId;
                        version = lstBill[i].Version;
                        lstaddpax = consignmentBAL.ReadDataByAdditonalPaxsId(CG_Id, 0);
                        if (lstaddpax.Count != 0)
                        {
                            Session["consignmentEditpax"] = lstaddpax;
                        }
                        Session["AgentId"] = lstBill[i].AgentDetails.AgentId;
                        Session["AgentName"] = lstBill[i].AgentDetails.AgentName;
                        Session["AgentAddress"] = lstBill[i].AgentDetails.AgentAddress;
                        Session["AgentPhone"] = lstBill[i].AgentDetails.AgentPhone;
                        Session["billId"] = lstBill[i].BillId;
                        Session["ConsignmentId"] = CG_Id;
                        Session["Type"] = lstBill[i].BillType;
                        if (CG_Id > 0)
                        {
                            Response.Redirect("GenerateInvoiceForm.aspx?CG_Id=" + CG_Id);
                        }
                    }
                }

            }
        }

        protected void ddlVersion_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            if (ddl.SelectedItem.Text != "--Select--")
            {
                int selectedValue = Convert.ToInt32(ddl.SelectedValue);
                Session["version"] = selectedValue;
            }
            else
            {
                Session.Remove("version");
            }
        }
        protected void rbtPrintInv_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvPrintInvoice.Visible = false;
        }

        #endregion

        #region Public Method..
        public void SearchCategory()
        {

            if (rbtPrintInv.SelectedValue == "2")
            {
                InvoiceType = "Normal";
                rbtPrintInv.ClearSelection();
            }
            else if (rbtPrintInv.SelectedValue == "1")
            {
                InvoiceType = "Advance";
                rbtPrintInv.ClearSelection();
            }
            else if (rbtPrintInv.SelectedValue == "3")
            {
                InvoiceType = "Additional";
                rbtPrintInv.ClearSelection();
            }
            else if (txtConsignmentNo.Text != "")
            {
                ConsignmentNo = Convert.ToInt32(txtConsignmentNo.Text);
                txtConsignmentNo.Text = string.Empty;
            }
            else if (ddlagentName.SelectedIndex != 0)
            {
                AgentName = ddlagentName.SelectedItem.Text;
                ddlagentName.SelectedIndex = 0;
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Please Select Option For Print Invoice. ')</script>");
            }
            GridBindFrPrintInvoice();
        }
        public void GridBindFrPrintInvoice()
        {
            gvPrintInvoice.Visible = true;
            billDOM.AgentDetails = new Agent();
            int LocId = 0;
            int userId = 1;
            if (ConsignmentNo != 0)
            {
                if (userId == 1 || userId == 4)
                {
                    LocId = 0;
                    lstBill = generateBAL.ReadBillRePrintInvoiceByConsignmentId(ConsignmentNo, LocId);
                }
                else
                {
                    lstBill = generateBAL.ReadBillRePrintInvoiceByConsignmentId(ConsignmentNo, LocId);
                }
                Session["ConsignmentNo"] = null;
            }
            else if (!string.IsNullOrEmpty(InvoiceType))
            {
                if (userId == 1 || userId == 4)
                {
                    LocId = 0;
                    lstBill = generateBAL.ReadBillRePrintInvoice(InvoiceType, LocId);
                }
                else
                {
                    lstBill = generateBAL.ReadBillRePrintInvoice(InvoiceType, LocId);
                }
                Session["InvoiceType"] = null;
            }
            else if (AgentName != null)
            {
                if (userId == 1 || userId == 4)
                {
                    LocId = 0;
                    lstBill = generateBAL.ReadBillRePrintInvoiceByAgentName(AgentName, LocId);
                }
                else
                {
                    lstBill = generateBAL.ReadBillRePrintInvoiceByAgentName(AgentName, LocId);
                }
                Session["agentName"] = null;
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('No Record Found')</script>");
            }
            if (lstBill.Count == 0)
            {
                gvPrintInvoice.DataSource = null;
                gvPrintInvoice.DataBind();
                Response.Write("<script LANGUAGE='JavaScript' >alert('No Record Found')</script>");
            }
            else
            {
                gvPrintInvoice.DataSource = lstBill;
                gvPrintInvoice.DataBind();
                if (gvPrintInvoice.Rows.Count > 0)
                {
                    for (int i = 0; i < gvPrintInvoice.Rows.Count; i++)
                    {
                        int bId = lstBill[i].BillId;
                        DropDownList sup = (DropDownList)gvPrintInvoice.Rows[i].FindControl("ddlVersion");
                        List<Bill> lst = generateBAL.ReadVersionNumber(bId);
                        sup.DataSource = lst;
                        sup.DataTextField = "Version";
                        sup.DataValueField = "Version";

                        sup.DataBind();
                        sup.Items.Insert(0, new ListItem("--Select--"));
                    }
                }

                Session["lstBill"] = lstBill;
            }
        }

        #endregion

        #region Public Properties..
        public string InvoiceType
        {
            get
            {
                return Convert.ToString(Session["InvoiceType"]);
            }
            set
            {
                Session["InvoiceType"] = value;
            }

        }
        public int ConsignmentNo
        {
            get
            {
                return Convert.ToInt32(Session["ConsignmentNo"]);
            }
            set
            {
                Session["ConsignmentNo"] = value;
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

        #endregion

        protected void gvPrintInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                UserDom user = new UserDom();
                UserBAL userBal = new UserBAL();
                user = userBal.ReadUserByLoginId("12");

                // Removinfg Aspx page acton CommandName lnkEdit

                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lbtnEdit");
                
                //lnkEdit.Visible = false;
                //if (1 == 1)
                //{
                //    lnkEdit.Visible = true;
                //}
            }
        }

    }
}