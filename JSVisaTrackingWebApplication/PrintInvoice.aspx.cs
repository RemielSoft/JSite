using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.Configuration;
using JSVisaTrackingWebApplication.Shared;

namespace JSVisaTrackingWebApplication
{
    public partial class PrintInvoice : System.Web.UI.Page
    {
        #region Global Properties..

        int id = 0;
        int LocId;
        int userId;
        int ConsignmentId;
        string agentName;
        DateTime FromDate;
        DateTime ToDate;
        BasePage basePage = new BasePage();
        GenerateInvoiceBAL generateBAL = new GenerateInvoiceBAL();
        SummaryReportBusinessAccess summaryBusinessAccess = new SummaryReportBusinessAccess();
        Bill billDOM = new Bill();
        List<Bill> lstBill = new List<Bill>();
        List<Bill> lstBillLt = new List<Bill>();
        List<Bill> lstBillCt = new List<Bill>();
        List<Bill> lstBillid = new List<Bill>();
        ConsignmentBusinessAccess consignmentBAL = new ConsignmentBusinessAccess();
        List<AdditonalInfo> lstaddpax = new List<AdditonalInfo>();
        List<Pax> lstPax = new List<Pax>();
        List<Pax> lstPax1 = new List<Pax>();
        Int32 DaysCount = Convert.ToInt32(ConfigurationManager.AppSettings["No_of_Days"]);

        #endregion

        #region Protected Method...

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //txtFromDate.Text = DateTime.Now.AddDays(-DaysCount).ToString("MM/dd/yyyy");
                //txtEndDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                if (basePage.LoggedInUser.UserLocation != null)
                {
                    LocId = basePage.LoggedInUser.UserLocation.LocationId;
                }
                userId = basePage.LoggedInUser.UserTypeId;
                if (userId == Convert.ToInt32(UserType.Admin) || userId == Convert.ToInt32(UserType.SuperAdmin))
                {
                    
                    basePage.BindDropDown(ddlagentName, "AgentName", "AgentId", summaryBusinessAccess.Agentbind(LocId,0));
                }
                else
                {
                    basePage.BindDropDown(ddlagentName, "AgentName", "AgentId", summaryBusinessAccess.Agentbind(LocId, basePage.LoggedInUser.AgentId));
                }

            }
            Session.Remove("CurrentTable");
            Session.Remove("lstpax");
            Session.Remove("AgentId");
            Session.Remove("lstBillItem");
            Session.Remove("lstBillItemm");
            Session.Remove("billitem");
            Session.Remove("tempdata");
            Session.Remove("Type");
            Session.Remove("version");
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (basePage.LoggedInUser.UserLocation != null)
            {
                LocId = basePage.LoggedInUser.UserLocation.LocationId;
            }
            userId = basePage.LoggedInUser.UserTypeId;
            if (txtConsignmentNo.Text != "")
            {
                id = Convert.ToInt32(txtConsignmentNo.Text);
                if (userId == Convert.ToInt32(UserType.Admin) || userId == Convert.ToInt32(UserType.SuperAdmin))
                {
                    LocId = 0;
                    lstBillLt = generateBAL.ReadConsignmentDetailsById(id, LocId);
                }
                else
                {
                    lstBillLt = generateBAL.ReadConsignmentDetailsById(id, LocId);
                }
                txtConsignmentNo.Text = string.Empty;
            }

            else if ((txtFromDate.Text != "") && (txtEndDate.Text != ""))
            {
                FromDate = Convert.ToDateTime(txtFromDate.Text);
                ToDate = Convert.ToDateTime(txtEndDate.Text);
                if (FromDate <= ToDate)
                {
                    if (userId == Convert.ToInt32(UserType.Admin) || userId == Convert.ToInt32(UserType.SuperAdmin))
                    {
                        LocId = 0;

                        lstBillLt = generateBAL.ReadConsignmentDetailsByDate(FromDate, ToDate, LocId);
                    }
                    else
                    {
                        lstBillLt = generateBAL.ReadConsignmentDetailsByDate(FromDate, ToDate, LocId);
                    }
                }
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('From Date Must Be Less Or Equal To ToDate.')</script>");
                }
                txtEndDate.Text = string.Empty;
                txtFromDate.Text = string.Empty;
            }
            else if (ddlagentName.SelectedItem.Value != "0")
            {
                agentName = Convert.ToString(ddlagentName.SelectedItem.Text);
                if (userId == Convert.ToInt32(UserType.Admin) || userId == Convert.ToInt32(UserType.SuperAdmin))
                {
                    LocId = 0;
                    lstBillLt = generateBAL.ReadConsignmentDetailsByAgentName(agentName, LocId);
                }
                else
                {
                    lstBillLt = generateBAL.ReadConsignmentDetailsByAgentName(agentName, LocId);
                }
                ddlagentName.SelectedIndex = 0;
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Please Inter Value For Search Invoice.')</script>");
            }
            Session["lstBillLt"] = lstBillLt;
            BindGridView();
        }
        protected void gridviewPrintInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewPrintInvoice.PageIndex = e.NewPageIndex;
            BindGridView();
        }
        protected void gridviewPrintInvoice_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Print")
            {
                billDOM.AgentDetails = new Agent();
                billDOM.BillConsignment = new Consignment();
                billDOM.PaxDetails = new Pax();
                List<Bill> lstBill = (List<Bill>)Session["lstBill"];
                ConsignmentId = Convert.ToInt32(e.CommandArgument);
                for (int i = 0; i < lstBill.Count; i++)
                {
                    if (ConsignmentId == lstBill[i].ConsignmentId)
                    {
                        if (basePage.LoggedInUser.UserLocation != null)
                        {
                            LocId = basePage.LoggedInUser.UserLocation.LocationId;
                        }
                        userId = basePage.LoggedInUser.UserTypeId;
                        if (userId == Convert.ToInt32(UserType.Admin) || userId == Convert.ToInt32(UserType.SuperAdmin))
                        {
                            LocId = 0;
                            lstaddpax = consignmentBAL.ReadDataByAdditonalPaxsId(ConsignmentId, LocId);
                        }
                        else
                        {
                            lstaddpax = consignmentBAL.ReadDataByAdditonalPaxsId(ConsignmentId, LocId);
                        }

                        if (lstaddpax.Count != 0)
                        {
                            Session["consignmentEditpax"] = lstaddpax;
                        }
                        if (userId == Convert.ToInt32(UserType.Admin) || userId == Convert.ToInt32(UserType.SuperAdmin))
                        {
                            LocId = 0;
                            //lstPax1 = consignmentBAL.ReadDataByPaxConsignmentId(ConsignmentId, LocId);
                        }
                        else
                        {
                            //lstPax1 = consignmentBAL.ReadDataByPaxConsignmentId(ConsignmentId, LocId);
                        }
                        if (lstPax1.Count != 0)
                        {
                            Session["PaxName"] = lstPax1[0].PaxName;
                        }
                        Session["AgentId"] = lstBill[i].BillConsignment.FkAgentId;
                        Session["AgentName"] = lstBill[i].AgentDetails.AgentName;
                        Session["AgentAddress"] = lstBill[i].AgentDetails.AgentAddress;
                        Session["quantity"] = lstBill[i].BillConsignment.CgNoOfPass;
                        Session["ConsignmentId"] = lstBill[i].ConsignmentId;
                        Session["billId"] = lstBill[i].BillId;
                    }
                }
                if (ConsignmentId > 0)
                {
                    Response.Redirect("GenerateInvoiceForm.aspx?CG_Id=" + ConsignmentId);
                }
            }
        }

        #endregion

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
                    gridviewPrintInvoice.DataSource = lstBill;
                    gridviewPrintInvoice.DataBind();
                    Session["lstBill"] = lstBill;
                }
                Session.Remove("lstBillLt");
            }
        }
        #endregion
    }
}