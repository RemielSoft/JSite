using JSVisaTrackingWebApplication.Shared;
using Remielsoft.JetSave.BusinessAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSVisaTrackingWebApplication
{
    public partial class AddConsulate : System.Web.UI.Page
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
            locationDOM.City = txtCityName.Text;
            locationDOM.Created_By = basePage.LoggedInUser.LoginId;
            locationDOM.Created_Date = DateTime.Now;
            locationBusinessAccess.insertConsulate(locationDOM);
            Response.Write("<Script Language=javascript>alert('Consulate Saved Successfully.');</Script>");
            Bindgried(null);
            Clear();
        }
        public void Bindgried(int? id)
        {
            GrdCity.DataSource = locationBusinessAccess.ReadConsulate(id);
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

                List<LocationMaster> llst = locationBusinessAccess.ReadConsulate(Id);
                txtCityName.Text = llst[0].City;
                txtDescription.Text = llst[0].LocationTitle;
                BtnAdd.Visible = false;
                btnupdate.Visible = true;

            }
            if (e.CommandName == "cmddelete")
            {
                locationBusinessAccess.DeleteConsulate(Id, "Admin", DateTime.Now);
                Bindgried(null);
                txtCityName.Text = "";
                txtDescription.Text = "";
                btnupdate.Text = "Add";

            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(Session["Id"]);
            LocationMaster locationUpdate = new LocationMaster();
            locationUpdate.LocationTitle = txtDescription.Text;
            locationUpdate.City = txtCityName.Text;
            locationUpdate.Modified_By = basePage.LoggedInUser.LoginId;
            locationUpdate.Modified_Date = DateTime.Now;
            locationBusinessAccess.UpdateConsulate(Id, locationUpdate);
            Response.Write("<Script Language=javascript>alert('Consulate Updated Successfully.');</Script>");
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
            txtDescription.Text = string.Empty;
        }

    }
}