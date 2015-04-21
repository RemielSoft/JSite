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
    public partial class AddCity : System.Web.UI.Page
    {
        int id = 0;
        BasePage basePage = new BasePage();
        LocationBusinessAccess locationBusinessAccess = new LocationBusinessAccess();
        VisaRequirementBusinessAccess advs = new VisaRequirementBusinessAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountry();
                Bindgried(null);
                btnupdate.Visible = false;
            }
        }

        public void BindCountry()
        {
            var lst = advs.ReadCountry();
            ddlCountry.DataSource = lst;
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataValueField = "COUNTRY_ID";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void BindState()
        {
            int countryId =Convert.ToInt32(ddlCountry.SelectedValue);
            var lst = advs.ReadStateByCountryID(countryId);
            ddlState.DataSource = lst;
            ddlState.DataTextField = "state";
            ddlState.DataValueField = "stateId";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            LocationMaster locationDOM = new LocationMaster();
            locationDOM.stateId =Convert.ToInt32(ddlState.SelectedValue);
            locationDOM.City = txtCityName.Text;
            locationDOM.Created_By = basePage.LoggedInUser.LoginId;
            locationDOM.Created_Date = DateTime.Now;
            locationBusinessAccess.insertCity(locationDOM);
            Response.Write("<Script Language=javascript>alert('City Saved Successfully.');</Script>");
            Bindgried(null);
            Clear();
        }
        public void Bindgried(int? id)
        {
            GrdCity.DataSource = locationBusinessAccess.ReadCity(id);
            GrdCity.DataBind();
        }

        protected void GrdCity_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdCity.PageIndex = e.NewPageIndex;
            Bindgried(null);

        }

        protected void GrdCity_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument);
            Session["Id"] = Id;
            if (e.CommandName == "cmdedit")
            {

                List<LocationMaster> llst = locationBusinessAccess.ReadCity(Id);
                txtCityName.Text = llst[0].City;
                ddlCountry.SelectedItem.Text = llst[0].Country;
                ddlCountry.SelectedValue = Convert.ToString(llst[0].CountryId);
                ddlState.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlState.SelectedItem.Text = llst[0].stateName;
                ddlState.SelectedValue = Convert.ToString(llst[0].stateId);
                BtnAdd.Visible = false;
                btnupdate.Visible = true;

            }
            if (e.CommandName == "cmddelete")
            {
                locationBusinessAccess.DeleteCity(Id, "Admin", DateTime.Now);
                Bindgried(null);
                txtCityName.Text = "";
              
                btnupdate.Text = "Add";

            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(Session["Id"]);
            LocationMaster locationUpdate = new LocationMaster();
            locationUpdate.stateId = Convert.ToInt32(ddlState.SelectedValue);
            locationUpdate.City = txtCityName.Text;
            locationUpdate.Modified_By = basePage.LoggedInUser.LoginId;
            locationUpdate.Modified_Date = DateTime.Now;
            locationBusinessAccess.CityUpdate(Id, locationUpdate);
            Response.Write("<Script Language=javascript>alert('City Updated Successfully.');</Script>");
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
            txtCityName.Text = string.Empty;
           
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindState();
        }


    }
}