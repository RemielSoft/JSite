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
    public partial class AddVisaForm : System.Web.UI.Page
    {
        VisaRequirementBusinessAccess advs = new VisaRequirementBusinessAccess();
        BasePage bp = new BasePage();
        VisaForm visaFormDOM = new VisaForm();
        VisaFormBL visaFormBAL = new VisaFormBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindConsulate();
                bp.BindDropDown(DropDownList_contry, "CountryName", "COUNTRY_ID", advs.ReadCountry());
            }
            btnsave.Visible = false;
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            bind();
            btnsave.Visible = true;
            Clean();
        }
        public void Clean()
        {
            CheckBoxcity.SelectedIndex = -1;
            txtvisatitle.Text = string.Empty;
        }
        private List<VisaForm> list
        {
            get
            {
                return (List<VisaForm>)ViewState["list"];
            }
            set
            {
                ViewState["list"] = value;
            }
        }
        public List<VisaForm> bind()
        {

            if (list == null)
            {
                list = new List<VisaForm>();
                string str = null;

                for (int i = 0; i <= CheckBoxcity.Items.Count - 1; i++)
                {

                    if (CheckBoxcity.Items[i].Selected)
                    {
                        if (str == "")
                        {
                            str = CheckBoxcity.Items[i].Text;
                        }
                        else
                        {
                            str += CheckBoxcity.Items[i].Text + ",";
                        }
                    }
                }
                visaFormDOM.VisaCity = str;
                visaFormDOM.CountryForVisa = DropDownList_contry.SelectedItem.Text;
                visaFormDOM.CountryId = Convert.ToInt32(DropDownList_contry.SelectedItem.Value);
                visaFormDOM.FilePath = ("/AddVisaForm/" + uploadform.FileName);
                visaFormDOM.VisaTitle = txtvisatitle.Text;
                visaFormDOM.LocationId = bp.LoggedInUser.UserLocation.LocationId;
                visaFormDOM.Created_By = bp.LoggedInUser.LoginId;
                visaFormDOM.Form = "/AddVisaForm/" + uploadform.FileName;
                string filename1 = Path.GetFileName(uploadform.PostedFile.FileName);
                uploadform.PostedFile.SaveAs(Server.MapPath("/AddVisaForm/" + uploadform.FileName));
                //uploadform.SaveAs(Server.MapPath("/AddVisaForm/" + filename1));
                list.Add(visaFormDOM);
                // Session["filename1"] = filename1;              
                Visa_gridview.DataSource = list;
                Visa_gridview.DataBind();
            }
            else
            {
                string str = null;
                for (int i = 0; i <= CheckBoxcity.Items.Count - 1; i++)
                {
                    if (CheckBoxcity.Items[i].Selected)
                    {
                        if (str == "")
                        {
                            str = CheckBoxcity.Items[i].Text;
                        }
                        else
                        {
                            str += CheckBoxcity.Items[i].Text;
                        }
                    }
                }
                visaFormDOM.VisaCity = str;
                visaFormDOM.CountryForVisa = DropDownList_contry.SelectedItem.Text;
                visaFormDOM.VisaTitle = txtvisatitle.Text;
                visaFormDOM.Form = uploadform.FileName;
                visaFormDOM.CountryId = Convert.ToInt32(DropDownList_contry.SelectedItem.Value);
                visaFormDOM.LocationId = bp.LoggedInUser.UserLocation.LocationId;
                visaFormDOM.Created_By = bp.LoggedInUser.LoginId;
                string filename1 = Path.GetFileName(uploadform.PostedFile.FileName);
                uploadform.SaveAs(Server.MapPath("/AddVisaForm/" + filename1));
                visaFormDOM.FilePath = ("/AddVisaForm/" + filename1);
                list.Add(visaFormDOM);
                // Session["filename1"] = filename1;
                Visa_gridview.DataSource = list;
                Visa_gridview.DataBind();
            }
            return list;
        }


        public void BindConsulate()
        {
            var listConsulate = advs.ReadConsulate();
            CheckBoxcity.DataSource = listConsulate;
            CheckBoxcity.DataTextField = "consulate_name";
            //ChkBoxList.DataValueField = "Country_Id";
            CheckBoxcity.DataBind();

        }






        protected void btnsave_Click(object sender, EventArgs e)
        {
            VisaFormBL adviabal = new VisaFormBL();
            visaFormBAL.Insertrecord(list);
            Visa_gridview.DataSource = null;
            Visa_gridview.DataBind();
            btnsave.Visible = false;
            list = null;
        }

        protected void Visa_gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "cmdDelete")
            {
                visaFormBAL.deleterecord(id);
                BindGridByCountry();
               // list.RemoveAt(index);
                //if (list.Count == 0)
                //{
                //    list = null;
                //    btnsave.Visible = false;
                //}
                //Visa_gridview.DataSource = list;
                //Visa_gridview.DataBind();
            }
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridByCountry();
        }
        private void BindGridByCountry()
        {
            string country = DropDownList_contry.SelectedItem.Text;
            List<VisaForm> lstVisa = new List<VisaForm>();
            for (int i = 0; i <= CheckBoxcity.Items.Count - 1; i++)
            {
                if (CheckBoxcity.Items[i].Selected)
                {
                    string consulate = CheckBoxcity.Items[i].Text;
                    lstVisa = visaFormBAL.ReadVisaFormByCountry(country, consulate);

                }
                else
                {
                    lstVisa = visaFormBAL.ReadVisaFormByCountry(country, null);
                }
            }
            Visa_gridview.DataSource = lstVisa;
            Visa_gridview.DataBind();
        }
    }
}