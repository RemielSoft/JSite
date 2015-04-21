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
    public partial class Location : System.Web.UI.Page
    {
       
        BasePage basePage = new BasePage();
        MetaDataBal metaDataBAL = new MetaDataBal();
        LocationBusinessAccess locationBusinessAccess = new LocationBusinessAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                basePage.BindDropDown(ddlCompany, "Name", "Id", metaDataBAL.ReadMetaDataComapany());
                Bindgried(null);
                btnupdate.Visible = false;
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
             
             LocationMaster locationDOM = new LocationMaster();
             locationDOM.CompanyId = Convert.ToInt32(ddlCompany.SelectedItem.Value);
             locationDOM.LocationTitle = txtlocation.Text;
             locationDOM.City = txtcity.Text;
             locationDOM.LocationAddress = txtlocationaddress.Text;
             locationDOM.CreatedBy = "ADMIN";
             
             locationBusinessAccess.insertLocation(locationDOM);
             Bindgried(null);
             Empty();
           

        }
        public void Bindgried(int? LocationId)
        {
            Grdlocation.DataSource = locationBusinessAccess.ReadLocation( LocationId);
            Grdlocation.DataBind();
        }

        protected void Grdlocation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grdlocation.PageIndex = e.NewPageIndex;
            Bindgried(null);
        }

        protected void Grdlocation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument);
            ViewState["Id"] = Id;
            if (e.CommandName == "cmdedit")
            {
                List<LocationMaster> llst = locationBusinessAccess.ReadLocationbyID(Id);
                txtcity.Text = llst[0].City.ToString();
                txtlocation.Text = llst[0].LocationTitle.ToString();
                txtlocationaddress.Text = llst[0].LocationAddress.ToString();
                ddlCompany.SelectedValue = Convert.ToInt32(llst[0].CompanyId).ToString();
                BtnAdd.Visible = false;
                btnupdate.Visible = true;
 
            }
            if (e.CommandName == "cmddelete")
            {
                locationBusinessAccess.DeleteLocation(Id, "Admin", DateTime.Now);
                Bindgried(null);
            }
            
        }
        public void Empty()
        {
            txtcity.Text = "";
            txtlocation.Text = "";
            txtlocationaddress.Text = "";
            ddlCompany.SelectedIndex = -1;
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            
               
                int Id = Convert.ToInt32(ViewState["Id"]);
                LocationMaster locationUpdate = new LocationMaster();
             
                locationUpdate.CompanyId = Convert.ToInt32(ddlCompany.SelectedItem.Value);
                locationUpdate.City = (txtcity.Text);
                locationUpdate.LocationAddress = txtlocationaddress.Text ;
                locationUpdate.LocationTitle = txtlocation.Text;
                locationUpdate.ModifiedBy ="ADMIN";
                locationUpdate.ModifiedDate = System.DateTime.Now;
               locationBusinessAccess.LocationUpdate(Id, locationUpdate);
               Bindgried(null);
               Empty();
               BtnAdd.Visible = true;
               btnupdate.Visible = false;

             

                

            
        }

        protected void btncancle_Click(object sender, EventArgs e)
        {
            Empty();
            btnupdate.Visible = false;
            BtnAdd.Visible = true;
        }
    }
}