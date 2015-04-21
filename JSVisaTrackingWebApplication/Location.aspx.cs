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
        LocationBusinessAccess locationBusinessAccess = new LocationBusinessAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                Citybind();
                Bindgried(null);
                btnupdate.Visible = false;
              

            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {

      
             LocationMaster locationDOM = new LocationMaster();
             locationDOM.CityId = Convert.ToInt32(ddlCity.SelectedItem.Value);
             locationDOM.LocationTitle = txtlocation.Text;
             locationDOM.City = ddlCity.SelectedItem.Text;
             locationDOM.LocationAddress = txtlocationaddress.Text;
             locationDOM.CompanyName = txtcompanyName.Text;
           
             locationDOM.Created_By = basePage.LoggedInUser.LoginId;
             
             locationBusinessAccess.insertLocation(locationDOM);
             Response.Write("<Script Language=javascript>alert('Data Saved Successfully.');</Script>");
             Bindgried(null);
             Empty();
           

        }
        public void Bindgried(int? LocationId)
        {
            Grdlocation.DataSource = locationBusinessAccess.ReadLocation(LocationId);
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
                txtcompanyName.Text = llst[0].CompanyName.ToString();
                //ddlCity.SelectedItem.Text = llst[0].City.ToString();
                txtlocation.Text = llst[0].LocationTitle.ToString();
                txtlocationaddress.Text = llst[0].LocationAddress.ToString();
                ddlCity.SelectedValue = llst[0].CityId.ToString();
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
            Citybind();
            txtcompanyName.Text = "";
            txtlocation.Text = "";
            txtlocationaddress.Text = "";            
            txtsearch.Text = string.Empty;
            ddlCity.SelectedValue = "0";
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {


            int Id = Convert.ToInt32(ViewState["Id"]);
            LocationMaster locationUpdate = new LocationMaster();

            locationUpdate.CityId = Convert.ToInt32(ddlCity.SelectedItem.Value);
            locationUpdate.City = ddlCity.SelectedItem.Text;
            locationUpdate.CompanyName = txtcompanyName.Text;
            locationUpdate.LocationAddress = txtlocationaddress.Text;
            locationUpdate.LocationTitle = txtlocation.Text;
            locationUpdate.Modified_By = basePage.LoggedInUser.LoginId;
            locationUpdate.Modified_Date = System.DateTime.Now;
            locationBusinessAccess.LocationUpdate(Id, locationUpdate);
            Response.Write("<Script Language=javascript>alert('Data Updated Successfully.');</Script>");
            Bindgried(null);           
            BtnAdd.Visible = true;
            btnupdate.Visible = false;
            Empty();






        }

        protected void btncancle_Click(object sender, EventArgs e)
        {
            
            //Bindgried(null);            
            btnupdate.Visible = false;
            BtnAdd.Visible = true;
            Empty();
           
           
        }
        public void searchByCity()
        {
            string city;
            city = txtsearch.Text;
            Grdlocation.DataSource = locationBusinessAccess.searchCity(city);
            Grdlocation.DataBind();


        }

        //protected void btnsearch_Click(object sender, EventArgs e)
        //{
        //    if (txtsearch.Text == "")
        //    {
        //        Response.Write("<Script Language=javascript>alert('Please Enter The Search City.');</Script>");
        //        Bindgried(null);
        //    }
        //    else
        //    {
        //        searchByCity();

        //        if (Grdlocation.Rows.Count == 0)
        //        {
        //            Response.Write("<Script Language=javascript>alert('Data not found.');</Script>");
        //            Bindgried(null);

        //        }
        //        //else 
        //        //{
        //        //    searchByCity();

        //        //}
        //        btnupdate.Visible = false;
        //        BtnAdd.Visible = true;
        //        Empty();
        //    }

        //}
        public void Citybind()
        {
                ddlCity.DataSource = locationBusinessAccess.Readcityddl();
                ddlCity.DataTextField = "City";
                ddlCity.DataValueField = "CityId";
                ddlCity.DataBind();
                ddlCity.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlCity.SelectedValue = "0";
        }

        protected void lnkSearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text == "")
            {
                Response.Write("<Script Language=javascript>alert('Please Enter The Search City.');</Script>");
                Bindgried(null);
            }
            else
            {
                searchByCity();

                if (Grdlocation.Rows.Count == 0)
                {
                    Response.Write("<Script Language=javascript>alert('Data not found.');</Script>");
                    Bindgried(null);

                }
                //else 
                //{
                //    searchByCity();

                //}
                btnupdate.Visible = false;
                BtnAdd.Visible = true;
                Empty();
            }
        }

    }
}