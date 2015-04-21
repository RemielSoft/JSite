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
using System.Text;

namespace JSVisaTrackingWebApplication
{
    public partial class AddHoliday : System.Web.UI.Page
    {
        #region Global Variable(s)
        BasePage basePage = new BasePage();
        HolidayBusinessAccess holidayBusinessAccess = new HolidayBusinessAccess();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountry();
                Bindgried(null);
                GrdHoliday.Columns[2].Visible = false;
            }
        }

        public void BindCountry()
        {
            ListItem item = new ListItem();

            ChkBoxList.DataSource = holidayBusinessAccess.HolidayCountryBindddl();
            ChkBoxList.DataTextField = "Country_Name";
            //ChkBoxList.DataValueField = "Country_Id";
            ChkBoxList.DataBind();

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {


        }

        public void Bindgried(int? id)
        {
            List<Holiday> listHoliday = new List<Holiday>();
            var lst = holidayBusinessAccess.ReadHoliday(id);
            foreach (var item in lst)
            {
                Holiday holiday = new Holiday();
                holiday.Holiday_Name = item.Holiday_Name;
                holiday.Holiday_Detail = item.Holiday_Detail;
                holiday.Holiday_Date = item.Holiday_Date;
                string[] country = item.Country_Name.Split(',');
                StringBuilder strBuilders = new StringBuilder();
                foreach (var items in country)
                {
                    strBuilders.Append(items + "," + "</br>");
                }
                holiday.Country_Name = string.Format(strBuilders.ToString());
                // holiday.Country_Name = item.Country_Name + "</br>";
                holiday.Holiday_Day = item.Holiday_Day;
                listHoliday.Add(holiday);
            }

            GrdHoliday.DataSource = listHoliday;
            GrdHoliday.DataBind();
            GrdHoliday.Columns[2].Visible = false;
        }

        public void Clear()
        {
            txt_holidayname.Text = "";
            txt_holidesc.Text = "";
            txtholidaydate.Text = "";
            //ChkBoxList.SelectedItem.Selected = false;

        }

        protected void GrdHoliday_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GrdHoliday_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btn_save_Click1(object sender, EventArgs e)
        {
            Holiday holidayDom = new Holiday();
            List<string> lstIds = new List<string>();
            if (txt_holidayname.Text == "" && txtholidaydate.Text == "")
            {
                Response.Write("<Script Language=javascript>alert('Please fill some field.');</Script>");
            }
            else
            {
                if (txt_holidesc.Text=="")
                {
                    if (chkMostEmbsy.Checked)
                    {
                        holidayDom.HoliDetails = lblMost.Text;
                    }
                    if (chkAllEmbsy.Checked)
                    {
                        holidayDom.HoliDetails = lblAllEm.Text; 
                    }
                    if (chkSchenembsy.Checked)
                    {
                        holidayDom.HoliDetails = lblSchengen.Text;
                    }
                    if (chkafrican.Checked)
                    {
                        holidayDom.HoliDetails = lblAfricanEmbsy.Text;
                    }
                }
                else
                {
                    holidayDom.HoliDetails = txt_holidesc.Text;
                }
                holidayDom.Holiday_Date = txtholidaydate.Text;
                holidayDom.Holiday_Name = txt_holidayname.Text;
               
                for (int i = 0; i < ChkBoxList.Items.Count; i++)
                {
                    if (ChkBoxList.Items[i].Selected)
                    {
                        string id = ChkBoxList.Items[i].Value;
                        lstIds.Add(id);
                    }
                }
                string result = string.Join(",", lstIds);
                holidayDom.Country_Name = result;
                //holidayDom.CreatedBy = basePage.LoggedInUser.LoginId;
                //holidayDom.CreatedDate = DateTime.Now;
                holidayBusinessAccess.InsertHolidayAdd(holidayDom);
                Response.Write("<Script Language=javascript>alert('Holiday Saved Successfully.');</Script>");
                Bindgried(null);
                Clear();
               
            }
            uncheckedbox();
        }

        private void uncheckedbox()
        {
            chkMostEmbsy.Checked = false;
            chkAllEmbsy.Checked = false;
            chkafrican.Checked = false;
            chkSchenembsy.Checked = false;
        }

    }
}