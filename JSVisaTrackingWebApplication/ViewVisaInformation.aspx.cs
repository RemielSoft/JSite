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
    public partial class ViewVisaInformation : System.Web.UI.Page
    {
        VisaRequirementBusinessAccess visaReqBal = new VisaRequirementBusinessAccess();
        VisaRequirement visaRequirement = new VisaRequirement();
        BasePage basePage = new BasePage();
        UserBAL userBal = new UserBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVisaInfoGrid();
            }
        }
        public void BindVisaInfoGrid()
        {
            gridview_visaInfo.DataSource = visaReqBal.ReadVisaRequirement();
            gridview_visaInfo.DataBind();

        }
        protected void gridview_visaInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview_visaInfo.PageIndex = e.NewPageIndex;
            gridview_visaInfo.DataBind();
        }
        protected void gridview_visaInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            ViewState["Id"] = id;

            if (e.CommandName == "cmdEdit")
            {
                string view = "";
                Response.Redirect("AddVisaInformation.aspx?REQ_ID=" + id + "&Viewid=" + view);

            }
            else if (e.CommandName == "cmdView")
            {
                string view = "2";
                Response.Redirect("AddVisaInformation.aspx?REQ_ID=" + id + "&Viewid=" + view);

            }
            else if (e.CommandName == "cmdDelete")
            {
                visaReqBal.DeleteVisaRequirement(id);


            }
            BindVisaInfoGrid();
        }

        protected void SearchVisaInfo()
        {

            gridview_visaInfo.DataSource = visaReqBal.ReadVisaRequirementByCountryName(txtcountrysearch.Text);
            gridview_visaInfo.DataBind();
        }

        protected void LnkBtnSearch_Click(object sender, EventArgs e)
        {
            SearchVisaInfo();
        }

        protected void gridview_visaInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                UserDom user = new UserDom();
                user = userBal.ReadUserByLoginId(basePage.LoggedInUser.LoginId);
                LinkButton lnkEdit = (LinkButton)e.Row.FindControl("btnEdit");
                
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("btnDelete");
                lnkEdit.Visible = false;
               
                lnkDelete.Visible = false;
                if (basePage.LoggedInUser.UserTypeId == Convert.ToInt32(UserType.Admin))
                {
                    lnkEdit.Visible = true;
                    
                    lnkDelete.Visible = true;
                }
                else if (basePage.LoggedInUser.UserTypeId != Convert.ToInt32(UserType.Admin) && user.UserTask.Count > 0)
                {
                    for (int i = 0; i < user.UserTask.Count; i++)
                    {
                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.EditVisaInfo))))
                        {
                            if (lnkEdit != null)
                            {
                                lnkEdit.Visible = true;
                               
                            }
                        }
                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.DeleteVisaInfo))))
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

    }
}