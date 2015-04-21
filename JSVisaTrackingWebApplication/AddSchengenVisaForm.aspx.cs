using JSVisaTrackingWebApplication.Shared;
using Remielsoft.JetSave.BusinessAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSVisaTrackingWebApplication
{
    public partial class AddSchengenVisaForm : System.Web.UI.Page
    {
        VisaRequirementBusinessAccess advs = new VisaRequirementBusinessAccess();
        BasePage bp = new BasePage();
        VisaForm visaFormDOM = new VisaForm();
        VisaFormBL visaFormBAL = new VisaFormBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSchnegenForm();
                BindConsulate();
                BindSchengenCountry();
            }
            btnsave.Visible = false;
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            VisaFormBL adviabal = new VisaFormBL();
            //visaFormBAL.InsertRecordForSchnegenCountry(list);
            Schegen_gridview.DataSource = null;
            Schegen_gridview.DataBind();
            btnsave.Visible = false;
            list = null;
        }

        protected void Schegen_gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Literal lblCountry = null;
            Label lblVisaTitle = null;
            Label lblForm = null;
           // int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "cmdDelete")
            {
                foreach (GridViewRow item in Schegen_gridview.Rows)
                {
                    lblCountry = (Literal)item.FindControl("Values");
                    lblVisaTitle = (Label)item.FindControl("lbl_title");
                    lblForm = (Label)item.FindControl("lbl_Form");
                    string title = lblVisaTitle.Text;
                    string formname = lblForm.Text;
                    string countryName= lblCountry.Text;
                    File.Delete(Server.MapPath(formname));
                    visaFormBAL.deleteSchnegenRecord(title, countryName);
                    BindSchnegenForm();
                    break;
                }
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            bind();
            btnsave.Visible = false;
            Clean();
        }
        public void Clean()
        {
            CheckBoxcity.SelectedIndex = -1;
            txtvisatitle.Text = string.Empty;
        }
        public void BindConsulate()
        {
            ConsulateBAL conBal = new ConsulateBAL();
            ListItem item = new ListItem();
            var listConsulate = conBal.ReadConsulate();
            CheckBoxcity.DataSource = listConsulate;
            CheckBoxcity.DataTextField = "consulateName";
            //ChkBoxList.DataValueField = "Country_Id";
            CheckBoxcity.DataBind();

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
        private void BindSchengenCountry()
        {
            var lst = advs.ReadSchengenCountry(null);
            chkBoxSchegenCountry.DataSource = lst;
            chkBoxSchegenCountry.DataTextField = "CountryName";
            chkBoxSchegenCountry.DataBind();
        }

        public void BindSchnegenForm()
        {
            var listSchnegen = advs.ReadSchengenForm(null);
            Schegen_gridview.DataSource = listSchnegen;
            Schegen_gridview.DataBind();
        }


        public List<VisaForm> bind()
        {

            if (list == null)
            {
                list = new List<VisaForm>();
                string str = null;
                string strCountry = null;
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

                for (int i = 0; i <= chkBoxSchegenCountry.Items.Count - 1; i++)
                {

                    if (chkBoxSchegenCountry.Items[i].Selected)
                    {
                        if (str == "")
                        {
                            strCountry = chkBoxSchegenCountry.Items[i].Text;
                        }
                        else
                        {
                            strCountry += chkBoxSchegenCountry.Items[i].Text + ",";
                        }
                    }
                }

                visaFormDOM.VisaCity = str;
                visaFormDOM.CountryForVisa = strCountry;
                visaFormDOM.FilePath = ("/AddVisaForm/" + uploadform.FileName);
                visaFormDOM.VisaTitle = txtvisatitle.Text;
                visaFormDOM.LocationId = bp.LoggedInUser.UserLocation.LocationId;
                visaFormDOM.Created_By = bp.LoggedInUser.LoginId;
                visaFormDOM.Form = "/AddVisaForm/" + uploadform.FileName;
                string filename1 = Path.GetFileName(uploadform.PostedFile.FileName);
                if (uploadform.FileName=="")
                {
                    //lblmessage.Text = "Please uploade file";
                    //lblmessage.Visible = true;
                }
                else
                {
                    uploadform.PostedFile.SaveAs(Server.MapPath("/AddVisaForm/" + uploadform.FileName));
                    visaFormBAL.InsertRecordForSchnegenCountry(visaFormDOM);
                    list.Add(visaFormDOM);
                    BindSchnegenForm();
                }
               // uploadform.PostedFile.SaveAs(Server.MapPath("/AddVisaForm/" + uploadform.FileName));
                
                //Schegen_gridview.DataSource = list;
                //Schegen_gridview.DataBind();
            }
            else
            {
                string str = null;
                string strCountry = null;
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
                for (int i = 0; i <= chkBoxSchegenCountry.Items.Count - 1; i++)
                {

                    if (chkBoxSchegenCountry.Items[i].Selected)
                    {
                        if (str == "")
                        {
                            strCountry = chkBoxSchegenCountry.Items[i].Text;
                        }
                        else
                        {
                            strCountry += chkBoxSchegenCountry.Items[i].Text + ",";
                        }
                    }
                }
                visaFormDOM.VisaCity = str;
                visaFormDOM.CountryForVisa = strCountry;
                visaFormDOM.VisaTitle = txtvisatitle.Text;
                visaFormDOM.Form = uploadform.FileName;
                // visaFormDOM.CountryId = Convert.ToInt32(DropDownList_contry.SelectedItem.Value);
                visaFormDOM.LocationId = bp.LoggedInUser.UserLocation.LocationId;
                visaFormDOM.Created_By = bp.LoggedInUser.LoginId;
                string filename1 = Path.GetFileName(uploadform.PostedFile.FileName);
                uploadform.SaveAs(Server.MapPath("/AddVisaForm/" + filename1));
                visaFormDOM.FilePath = ("/AddVisaForm/" + filename1);
                visaFormBAL.InsertRecordForSchnegenCountry(visaFormDOM);
                BindSchnegenForm();
                list.Add(visaFormDOM);
               
            }
            return list;
        }
    }
}