using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using JSVisaTrackingWebApplication.Shared;
using System.Configuration;
using System.IO;
using System.Text;

namespace JSVisaTrackingWebApplication
{
    public partial class EditDeleteConsignment :BasePage
    {
       
        UserBAL userBal = new UserBAL();
        AgentBAL agentBal = new AgentBAL();
        VisaRequirementBusinessAccess BL = new VisaRequirementBusinessAccess();
        // Int32 DaysCount = Convert.ToInt32(ConfigurationManager.AppSettings["No_Of_Days"]);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // ToDate = DateTime.Now;
                //  FromDate = DateTime.Now;
                // txtfrmdate.Text = ToDate.ToString();
                //txttodate.Text = FromDate.ToString();
                //Session.Remove("lstcountry");
                //Session.Remove("listconsign");
                //Session.Remove("MailRemarks");
                //Session.Remove("listMail");
                //Session.Remove("pax");
                Session.RemoveAll();
                int LocId = LoggedInUser.UserLocation.LocationId;
                BindDropDown(ddlcountry, "CountryName", "COUNTRY_ID", BL.ReadCountry());
                int userId = LoggedInUser.UserTypeId;
                if (userId == Convert.ToInt32(UserType.Admin))
                {
                    LocId = 0;
                    BindDropDown(ddlAgent, "AgentName", "AgentId", agentBal.ReadUsers("", LocId,0));
                }
                else
                {
                    BindDropDown(ddlAgent, "AgentName", "AgentId", agentBal.ReadUsers("", LocId, 0));
                }               

            }

        }
        public void BindConsignmentGrid()
        {
            if (txtfrmdate.Text == "" && txttodate.Text == ""  && txtConsignmentNosearch.Text == "" && ddlAgent.SelectedIndex==0 && ddlcountry.SelectedIndex==0)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Please Select Any Option To Search. ')</script>");

            }
            else
            {
                int locationId = LoggedInUser.UserLocation.LocationId;
                int usertype = LoggedInUser.UserTypeId;
                string PaxName = null;
                string PaxPassportNo = null;
                int consignmentNo = 0;
                ResetViewState();
                ConsignmentBusinessAccess consignmentBal = new ConsignmentBusinessAccess();
                List<Consignment> lstConsignment;

                if (!string.IsNullOrEmpty(txtfrmdate.Text))
                {
                    FromDate = Convert.ToDateTime(txtfrmdate.Text);
                }
                if (!string.IsNullOrEmpty(txttodate.Text))
                {
                    ToDate = Convert.ToDateTime(txttodate.Text);
                }
                if (!string.IsNullOrEmpty(txtConsignmentNosearch.Text))
                {
                    consignmentNo = Convert.ToInt32(txtConsignmentNosearch.Text);
                }
                countryId = Convert.ToInt32(ddlcountry.SelectedValue);
                agentId = Convert.ToInt32(ddlAgent.SelectedValue);
                string deliveryStatus = null;
                    if (usertype == Convert.ToInt32(UserType.Admin))
                    {
                        locationId = 0;
                      //  lstConsignment = consignmentBal.ReadConsignmentDataByDates(FromDate, ToDate, countryId, agentId, locationId,  deliveryStatus, consignmentNo);
                    }
                    else
                    {
                       // lstConsignment = consignmentBal.ReadConsignmentDataByDates(FromDate, ToDate, countryId, agentId, locationId,  deliveryStatus, consignmentNo);
                    }

                    //if (lstConsignment.Count > 0)
                    //{

                    //    gridViewConsignment.DataSource = lstConsignment;
                    //    gridViewConsignment.DataBind();                                             
                    //    gridViewConsignment.Visible = true;
                    //}
                    //else
                    //{
                    //    ShowMessageWithUpdatePanel("No Record Found");
                    //    gridViewConsignment.Visible = false;
                    //    clear();
                    //}
                }
        }

        protected void gridViewConsignment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewConsignment.PageIndex = e.NewPageIndex;
            BindConsignmentGrid();
        }

        protected void gridViewConsignment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ConsignmentBusinessAccess consignmentBal = new ConsignmentBusinessAccess();
            int id = Convert.ToInt32(e.CommandArgument);
            ViewState["Id"] = id;
            if (e.CommandName == "cmdEdit")
            {
                string Id1 = "EditConsignment";
                Response.Redirect("AddConsignment.aspx?ConsignmentId=" + id + "&consignment=" + Id1);

            }
            else if (e.CommandName == "cmdViewCon")
            {
                string Id1 = "view";
                Response.Redirect("AddConsignment.aspx?ConsignmentId=" + id + "&cons=" + Id1);
            }
         
            else if (e.CommandName == "cmdDelete")
            {
                consignmentBal.DeleteConsignment(id);


            }
            BindConsignmentGrid();
        }    
     

        protected void btnGo_Click(object sender, EventArgs e)
        {
            BindConsignmentGrid();
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        protected void gridViewConsignment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvChildGrid = (GridView)e.Row.FindControl("gvChildGrid");
                ConsignmentBusinessAccess conbal = new ConsignmentBusinessAccess();
                Label lblConsignmentId = (Label)e.Row.FindControl("lblConsignmentId");
                int ConsignmentId = Convert.ToInt32(lblConsignmentId.Text);
                int locationId = LoggedInUser.UserLocation.LocationId;
                int usertype = LoggedInUser.UserTypeId;
                List<Pax> lstpax = null;
                if (usertype == Convert.ToInt32(UserType.Admin) || usertype == Convert.ToInt32(UserType.SuperAdmin))
                {
                    locationId = 0;
                    lstpax = conbal.ReadDataByPaxsConsignmentId(ConsignmentId, locationId);
                }
                else
                {
                    lstpax = conbal.ReadDataByPaxsConsignmentId(ConsignmentId, locationId);
                }
                var lst = lstpax.Select(a => new { a.PaxName }).Distinct();
                gvChildGrid.DataSource = lst;
                gvChildGrid.DataBind();
                gvChildGrid.ShowHeader = false;

                UserDom user = new UserDom();
                user = userBal.ReadUserByLoginId(LoggedInUser.LoginId);
                LinkButton lnkEdit = (LinkButton)e.Row.FindControl("btnEdit");               
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("btnDelete");
                lnkEdit.Visible = false;                
                lnkDelete.Visible = false;
                if (LoggedInUser.UserTypeId == Convert.ToInt32(UserType.Admin) || LoggedInUser.UserTypeId == Convert.ToInt32(UserType.SuperAdmin))
                {
                    lnkEdit.Visible = true;                    
                    lnkDelete.Visible = true;
                }
                else if (LoggedInUser.UserTypeId != Convert.ToInt32(UserType.Admin) && user.UserTask.Count > 0)
                {
                    for (int i = 0; i < user.UserTask.Count; i++)
                    {
                        if (LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.EditConsignment))))
                        {
                            if (lnkEdit != null)
                            {
                                lnkEdit.Visible = true;                               
                            }
                        }
                        if (LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.DeleteConsignment))))
                        {
                            if (lnkDelete != null)
                            {
                                lnkDelete.Visible = true;
                            }
                        }
                    }
                }
            }

        }

        public void ResetViewState()
        {
            FromDate = DateTime.MinValue;
            ToDate = DateTime.MinValue;
            countryId = 0;
            agentId = 0;
        }
        public void clear()
        {
            txtConsignmentNosearch.Text = string.Empty;
            txtfrmdate.Text = string.Empty;
            txttodate.Text = string.Empty;
            ddlAgent.ClearSelection();
            ddlcountry.ClearSelection();
        }

        #region Public Properties

        public DateTime ToDate
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(ViewState["ToDate"]);
                }
                catch
                {

                    return DateTime.MinValue;
                }
            }
            set { ViewState["ToDate"] = value; }
        }
        public DateTime FromDate
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(ViewState["FromDate"]);
                }
                catch
                {

                    return DateTime.MinValue;
                }
            }
            set { ViewState["FromDate"] = value; }
        }
        public Int32 countryId
        {
            get
            {
                try
                {
                    return (Int32)ViewState["countryId"];
                }
                catch
                {

                    return 0;
                }
            }
            set { ViewState["countryId"] = value; }
        }
        public Int32 agentId
        {
            get
            {
                try
                {
                    return (Int32)ViewState["agentId"];
                }
                catch
                {

                    return 0;
                }
            }
            set { ViewState["agentId"] = value; }
        }
        #endregion


    }
}