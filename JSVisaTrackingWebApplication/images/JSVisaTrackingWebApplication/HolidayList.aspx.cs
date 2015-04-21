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

namespace JSVisaTrackingWebApplication
{
    public partial class HolidayList : System.Web.UI.Page
    {
        #region Global Variable(s)

        HolidayBusinessAccess holidayBusinessAccess = new HolidayBusinessAccess();

        #endregion

        #region Protected Functions

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownLocation();               
            }
        }       

        protected void btn_go_Click(object sender, EventArgs e)
        {           
           GridviewBind();
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
                GridviewBind();
            }
        }
        
        #endregion

        #region Private Method(s)

        public void GridviewBind()
        {
            string location = ddl_location.SelectedItem.Text;
            grid_holiday.DataSource = holidayBusinessAccess.BindGridview1(location);
            grid_holiday.DataBind();
        }        

        public List<LocationMaster> BindDropDownLocation()
        {
            List<LocationMaster> lst = holidayBusinessAccess.BindDdlLocation();
            ddl_location.DataSource = lst;
            ddl_location.DataTextField = "LocationName";
            ddl_location.DataValueField = "LocationId";
            ddl_location.DataBind();
            ddl_location.Items.Insert(0, new ListItem("--Select--", "0"));
            return lst;
        }

        #endregion       
    }
}