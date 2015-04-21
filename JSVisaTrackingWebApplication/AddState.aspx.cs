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
    public partial class AddState : System.Web.UI.Page
    {
        BasePage basePage = new BasePage();
        LocationBusinessAccess locationBusinessAccess = new LocationBusinessAccess();
        VisaRequirement country = new VisaRequirement();
        VisaRequirementBusinessAccess advs = new VisaRequirementBusinessAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindgried(null);
                BindCountry();
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
        protected void grdState_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument);
            Session["Id"] = Id;
            if (e.CommandName == "cmdedit")
            {
                List<LocationMaster> llst = locationBusinessAccess.ReadState(Id);
                ddlCountry.SelectedItem.Text = llst[0].Country;
                ddlCountry.SelectedItem.Value =Convert.ToString(llst[0].CountryId);
                txtState.Text = llst[0].stateName;
                BtnAdd.Visible = false;
                btnupdate.Visible = true;

            }
            if (e.CommandName == "cmddelete")
            {
                locationBusinessAccess.DeleteState(Id, "Admin", DateTime.Now);
                Bindgried(null);
                txtState.Text = "";
                btnupdate.Text = "Add";

            }
        }

        protected void grdState_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdState.PageIndex = e.NewPageIndex;
            Bindgried(null);

        }
        public void Clear()
        {
            txtState.Text = string.Empty;

        }

        public void Bindgried(int? id)
        {
            grdState.DataSource = locationBusinessAccess.ReadState(id);
            grdState.DataBind();
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(Session["Id"]);
            LocationMaster locationUpdate = new LocationMaster();
            locationUpdate.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
            locationUpdate.stateName = txtState.Text;
            locationUpdate.Modified_By = basePage.LoggedInUser.LoginId;
            locationUpdate.Modified_Date = DateTime.Now;
            locationBusinessAccess.UpdateState(Id, locationUpdate);
            Response.Write("<Script Language=javascript>alert('State Updated Successfully.');</Script>");
            Bindgried(null);
            BtnAdd.Visible = true;
            btnupdate.Visible = false;
            Clear();
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
         {
            LocationMaster locationDOM = new LocationMaster();
            locationDOM.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
            locationDOM.stateName = txtState.Text;
            locationDOM.Created_By = basePage.LoggedInUser.LoginId;
            locationDOM.Created_Date = DateTime.Now;
            locationBusinessAccess.insertState(locationDOM);
            Response.Write("<Script Language=javascript>alert('State Saved Successfully.');</Script>");
            Bindgried(null);
            Clear();
        }

        protected void btncancle_Click(object sender, EventArgs e)
        {
            Clear();
        }

    }
}