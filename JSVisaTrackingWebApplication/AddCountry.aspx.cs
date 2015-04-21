using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.Globalization;
using JSVisaTrackingWebApplication.Shared;

namespace JSVisaTrackingWebApplication
{
    public partial class AddCountry : System.Web.UI.Page
    {

        int id = 0;
        BasePage basePage = new BasePage();
        LocationBusinessAccess locationBusinessAccess = new LocationBusinessAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindgried(null);
                btnupdate.Visible = false;
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            LocationMaster locationDOM = new LocationMaster();
            locationDOM.LocationTitle = txtDescription.Text;
            locationDOM.Country = txtCountryName.Text;
            locationDOM.Created_By = basePage.LoggedInUser.LoginId;
            locationDOM.Created_Date = DateTime.Now;
            locationBusinessAccess.insertCountry(locationDOM);
            Response.Write("<Script Language=javascript>alert('Country Saved Successfully.');</Script>");
            Bindgried(null);
            Clear();
        }
        public void Bindgried(int? id)
        {
            GrdCountry.DataSource = locationBusinessAccess.ReadCountry(id);
            GrdCountry.DataBind();
        }

        protected void GrdCountry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdCountry.PageIndex = e.NewPageIndex;
            Bindgried(null);

        }

        protected void GrdCountry_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument);
            Session["Id"] = Id;
            if (e.CommandName == "cmdedit")
            {

                List<LocationMaster> llst = locationBusinessAccess.ReadCountry(Id);
                txtCountryName.Text = llst[0].Country;
                txtDescription.Text = llst[0].LocationTitle;
                BtnAdd.Visible = false;
                btnupdate.Visible = true;

            }
            if (e.CommandName == "cmddelete")
            {
                locationBusinessAccess.DeleteCountry(Id, "Admin", DateTime.Now);
                Bindgried(null);
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(Session["Id"]);
            LocationMaster locationUpdate = new LocationMaster();
            locationUpdate.LocationTitle = txtDescription.Text;
            locationUpdate.Country = txtCountryName.Text;
            locationUpdate.Modified_By = basePage.LoggedInUser.LoginId;
            locationUpdate.Modified_Date = DateTime.Now;
            locationBusinessAccess.CountryUpdate(Id, locationUpdate);
            Response.Write("<Script Language=javascript>alert('Country Updated Successfully.');</Script>");
            Bindgried(null);
            BtnAdd.Visible = true;
            btnupdate.Visible = false;
            Clear();
        }

        protected void btncancle_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtCountryName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
    }
}