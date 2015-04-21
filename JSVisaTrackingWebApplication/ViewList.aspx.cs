using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.Web.Configuration;
using JSVisaTrackingWebApplication.Shared;
using System.Web.Services;
using System.Globalization;
using System.IO;

namespace JSVisaTrackingWebApplication
{
    public partial class ViewList : System.Web.UI.Page
    {
        VisaRequirementBusinessAccess advs = new VisaRequirementBusinessAccess();
        LocationBusinessAccess locationBal = new LocationBusinessAccess();
        BasePage basePage = new BasePage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                basePage.BindDropDown(ddlCountryName, "CountryName", "COUNTRY_ID", advs.ReadCountry());
                BindLocationDropDown();
            }

        }
        public void BindLocationDropDown()
        {
            ddlLocation.DataSource = locationBal.Readcityddl();
            ddlLocation.DataTextField = "City";
            ddlLocation.DataValueField = "CityId";
            ddlLocation.DataBind();
            ddlLocation.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlLocation.SelectedValue = "0";
        }
    }
}