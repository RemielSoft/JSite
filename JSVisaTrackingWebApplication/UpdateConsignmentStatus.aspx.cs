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

namespace JSVisaTrackingWebApplication
{
    public partial class UpdateConsignmentStatus :BasePage
    {
        BasePage basePage = new BasePage();
        UserBAL userBal = new UserBAL();
        Int32 DaysCount = Convert.ToInt32(ConfigurationManager.AppSettings["No_Of_Days"]);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ToDate = DateTime.Now.AddDays(-DaysCount);
                FromDate = DateTime.Now;
                txtfrmdate.Text = ToDate.ToString("MM/dd/yyyy");
                txttodate.Text = FromDate.ToString("MM/dd/yyyy");
                BindConsignmentGrid();   
            }
        }

        public void BindConsignmentGrid()
        {
            int locationId = basePage.LoggedInUser.UserLocation.LocationId;
            int userType = basePage.LoggedInUser.UserTypeId;
            DateTime fromDate = Convert.ToDateTime(txtfrmdate.Text);
            DateTime toDate = Convert.ToDateTime(txttodate.Text);
            ConsignmentBusinessAccess consignmentBal = new ConsignmentBusinessAccess();
            if (fromDate <= toDate)
            {
                List<Consignment> lstconsignment;
                if (userType == Convert.ToInt32(UserType.Admin) || userType == Convert.ToInt32(UserType.SuperAdmin))
                {
                    locationId = 0;
                   // lstconsignment = consignmentBal.ReadConsignmentDataByDates(fromDate, toDate,0,0,locationId,null,0,null);
                }
                else{
                   // lstconsignment = consignmentBal.ReadConsignmentDataByDates(fromDate, toDate,0,0,locationId,null,0, null);
                }
                 
                //if (lstconsignment.Count > 0)
                //{
                //    gridViewConsignment.DataSource = lstconsignment;
                //    gridViewConsignment.DataBind();
                    
                //}
                //else
                //{
                //    ShowMessageWithUpdatePanel("Record Not Found");                    
                //}
            }
            else
            {
                //txtfrmdate.Text = "";
                txttodate.Text = "";
                ShowMessageWithUpdatePanel("ToDate Can Not be Less Then FromDate");                   
            }

        }

        protected void gridViewConsignment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gridViewConsignment.PageIndex = e.NewPageIndex;
            BindConsignmentGrid();   
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            BindConsignmentGrid();
        }

        protected void gridViewConsignment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ConsignmentBusinessAccess consignmentBal = new ConsignmentBusinessAccess();
            int id = Convert.ToInt32(e.CommandArgument);
            Session["consignmentId"] = id;
            if (e.CommandName == "cmdViewCon")
            {
                string Id1 = "view";
                Response.Redirect("AddConsignment.aspx?ConsignmentId=" + id + "&cons=" + Id1);



            }
        }

        protected void gridViewConsignment_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridViewConsignment.EditIndex = e.NewEditIndex;
            BindConsignmentGrid();   
        }

        protected void gridViewConsignment_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int consignmentId = Convert.ToInt32(Session["consignmentId"]);
            DropDownList drpdwnStatus = (DropDownList)gridViewConsignment.Rows[e.RowIndex].FindControl("DrpdnConsignStatus");
            DropDownList drpdwndocumntStatus = (DropDownList)gridViewConsignment.Rows[e.RowIndex].FindControl("DDlConsignDocumntStatus");
            Consignment consignment = new Consignment();
            ConsignmentBusinessAccess consignmentBal = new ConsignmentBusinessAccess();
            consignment.ConsignmentVisaStatusId = Convert.ToInt32(drpdwnStatus.SelectedItem.Value);
            consignment.ConsignmentDocumnetStatusId = Convert.ToInt32(drpdwndocumntStatus.SelectedItem.Value);
            consignmentBal.UpdateConsignmentStatus(consignment, consignmentId);
            gridViewConsignment.EditIndex = -1;
            BindConsignmentGrid();   
            

        }

        protected void gridViewConsignment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                UserDom user = new UserDom();
                user = userBal.ReadUserByLoginId(basePage.LoggedInUser.LoginId);
                LinkButton lnkEdit = (LinkButton)e.Row.FindControl("linbtn_edit");
                LinkButton LinbtnViewConsign = (LinkButton)e.Row.FindControl("LinbtnViewConsign");


                if (basePage.LoggedInUser.UserTypeId != Convert.ToInt32(UserType.Admin) && user.UserTask.Count > 0)
                {
                    for (int i = 0; i < user.UserTask.Count; i++)
                    {
                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.UpdateConsignmentStatus))))
                        {
                            if (lnkEdit != null)
                            {
                                lnkEdit.Visible = true;
                            }

                        }
                        else
                        {
                            lnkEdit.Visible = false ;
                        }
                    }
                }
            }
        }

        protected void gridViewConsignment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridViewConsignment.EditIndex = -1;
            BindConsignmentGrid();   
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

        #endregion
    }
}