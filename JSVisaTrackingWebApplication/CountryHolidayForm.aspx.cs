using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.BusinessAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using JSVisaTrackingWebApplication.Shared;

namespace JSVisaTrackingWebApplication
{
    public partial class CountryHolidayForm : System.Web.UI.Page
    {
        #region Global Variable(s)
        BasePage basePage = new BasePage();
        HolidayBusinessAccess holidayBusinessAccess = new HolidayBusinessAccess();

        #endregion

        #region Protected Functions

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                basePage.BindDropDown(ddl_location, "LocationName", "LocationId", holidayBusinessAccess.BindDdlLocation());

                if (Request.QueryString["REQ_ID"] != null)
                {
                    btn_update.Visible = true;
                    btn_save.Visible = false;

                    int id = Convert.ToInt32(Request.QueryString["REQ_ID"]);
                    List<Holiday> lst = holidayBusinessAccess.Edit1(id);
                    ddl_month.SelectedValue = lst[0].HoliMonth.ToString();
                    ddl_location.SelectedValue= lst[0].CityId.ToString();
                    rbtnlstPurpose.SelectedValue = lst[0].HoliPurpose.Trim();
                    txt_detail.Text = lst[0].HoliDetails.ToString();
                    txt_notes.Text = lst[0].HoliNotes.ToString();
                }
            }
                     
        }        

        protected void btn_save_Click(object sender, EventArgs e)
        {
            Holiday holiday = new Holiday();
            holiday.HoliMonth = ddl_month.SelectedItem.Text;
            holiday.HoliLocation = ddl_location.SelectedItem.Text; 
            holiday.HoliDetails = txt_detail.Text;
            holiday.HoliNotes = txt_notes.Text;
            holiday.HoliPurpose = rbtnlstPurpose.SelectedItem.Text;
            holidayBusinessAccess.insert_holiday(holiday);

            ScriptManager.RegisterClientScriptBlock(btn_save, GetType(), "a", "alert('Holiday Saved successfully')", true);

            ddl_location.SelectedValue = "0";
            ddl_month.SelectedValue = "0";
            txt_detail.Text = string.Empty;
            txt_notes.Text = string.Empty;
            rbtnlstPurpose.SelectedValue = "0";
        }          

        protected void btn_update_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["REQ_ID"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["REQ_ID"]);
                Holiday holiday = new Holiday();
                holiday.HoliPurpose = rbtnlstPurpose.SelectedValue;
                holiday.HoliMonth = ddl_month.SelectedValue;
                holiday.HoliLocation = ddl_location.SelectedItem.Text;
                holiday.HoliDetails = txt_detail.Text;
                holiday.HoliNotes = txt_notes.Text;
                holidayBusinessAccess.Update1(id, holiday);
                ScriptManager.RegisterClientScriptBlock(btn_update, GetType(), "a", "alert('Record Updated successfully...')", true);
                Response.Redirect("HolidayList.aspx");
            }    
        }
        #endregion       
    }
}