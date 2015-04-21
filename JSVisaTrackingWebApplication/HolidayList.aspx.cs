using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using JSVisaTrackingWebApplication.Shared;

namespace JSVisaTrackingWebApplication
{
    public partial class HolidayList : System.Web.UI.Page
    {
        #region Global Variable(s)
        BasePage basePage = new BasePage();
        HolidayBusinessAccess holidayBusinessAccess = new HolidayBusinessAccess();
        UserBAL userBal = new UserBAL();
        List<Holiday> holidays = new List<Holiday>();
        #endregion

        #region Protected Functions

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlyear.SelectedItem.Text = DateTime.Now.Year.ToString();
                ddlmonth.SelectedItem.Text = String.Format("{0:MMMM}", DateTime.Now);
                //basePage.BindDropDown(ddl_location, "LocationName", "LocationId", holidayBusinessAccess.BindDdlLocation());
                Bindgried(null);
               // GrdHoliday.Columns[2].Visible = false;

                //lblholidayList.Visible = true;
            }
            //else
            //{
            //    GrdHoliday.DataSource = holidays;
            //    GrdHoliday.DataBind();
            //}
            //int userId = basePage.LoggedInUser.UserTypeId;
            //if (userId == Convert.ToInt32(UserType.Admin))
            //{
            //    //rbtnlstPurpose.Visible = true;
            //}
            //else
            //{
            //   // mail.Enabled = false;
            //}

            //Bindgried(null);
            //lblholidayList.Visible = true;
        }

        protected void btn_go_Click(object sender, EventArgs e)
        {
            //GridviewBind();
        }

        protected void grid_holiday_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            ViewState["Id"] = id;
            if (e.CommandName == "cmdedit")
            {
                Response.Redirect("CountryHolidayForm.aspx?REQ_ID=" + id);
            }
            else if (e.CommandName == "cmddel")
            {
                holidayBusinessAccess.Delete1(id);
                // Bindgried();
            }
        }

        protected void grid_holiday_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                UserDom user = new UserDom();
                user = userBal.ReadUserByLoginId(basePage.LoggedInUser.LoginId);
                LinkButton lnkEdit = (LinkButton)e.Row.FindControl("LinkButton3");

                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("LinkButton5");
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
                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.EditHoliday))))
                        {
                            if (lnkEdit != null)
                            {
                                lnkEdit.Visible = true;

                            }
                        }
                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.DeleteHoliday))))
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

        protected void grid_holiday_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdHoliday.PageIndex = e.NewPageIndex;
           // Bindgried(null);
        }

        #endregion

        #region Private Method(s)

        public void Bindgried(int? id)
        {
            GrdHoliday.DataSource = holidayBusinessAccess.ReadHoliday(id);
            GrdHoliday.DataBind();
            GrdHoliday.Columns[2].Visible = false;
        }

        #endregion

        protected void GrdHoliday_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GrdHoliday_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnshowholiday_Click(object sender, EventArgs e)
        {
           

            int year = 0;
            int monthNumber = 0;

            if (ddlyear.SelectedValue !="")
            {
                year = Convert.ToInt32(ddlyear.SelectedItem.Value);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(btnshowholiday, GetType(), "a", "alert('Please Select Year')", true);
            }
            if (ddlmonth.SelectedValue != "")
            {
                monthNumber = DateTime.Parse("01-" + ddlmonth.SelectedItem.Value + "-" + year).Month;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(btnshowholiday, GetType(), "a", "alert('Please Select Month')", true);
            }
            holidays = holidayBusinessAccess.ReadHolidaysByMonthYear(year,monthNumber);
            //GrdHoliday.DataSource = "";
            if (holidays.Count>0)
            {
               
                GrdHoliday.DataSource = holidays;
                GrdHoliday.DataBind();
                GrdHoliday.Visible = true;
                //Response.Redirect(Request.RawUrl);
            }
            else
            {
               // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No Record Found');", true);
                GrdHoliday.Visible = false;

            }
            
        }


    }
}