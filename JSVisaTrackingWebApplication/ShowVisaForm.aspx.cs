using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Web.Services;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.Drawing;
using System.Net;
using JSVisaTrackingWebApplication.Shared;

namespace JSVisaTrackingWebApplication
{
    public partial class ShowVisaForm : System.Web.UI.Page
    {
        #region Global Varriables..
        public string p;
        VisaFormBL visafmbl = new VisaFormBL();
        VisaForm advisaform = new VisaForm();
        List<VisaForm> adlst = new List<VisaForm>();
        BasePage basePage = new BasePage();
        UserBAL userBal = new UserBAL();

        #endregion

        #region Protected Method..

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void RadioButtonList_selectcity_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindVisaGridByCity();
        }

        protected void LinkButtonA_Click(object sender, EventArgs e)
        {
            if (RadioButtonList_selectcity.SelectedValue == "Delhi")
            {
                string strCity = "Delhi";
                string strStartCountry = ((LinkButton)sender).CommandArgument;
                adlst = visafmbl.ReadForm(strStartCountry, strCity);
                Visa_gridshow.DataSource = adlst;
                Visa_gridshow.DataBind();
            }
            else if (RadioButtonList_selectcity.SelectedValue == "Mumbai")
            {
                string strCity = "Mumbai";
                string strStartCountry = ((LinkButton)sender).CommandArgument;
                adlst = visafmbl.ReadForm(strStartCountry, strCity);
                Visa_gridshow.DataSource = adlst;
                Visa_gridshow.DataBind();
            }
            else if (RadioButtonList_selectcity.SelectedValue == "Chennai")
            {
                string strCity = "Chennai";
                string strStartCountry = ((LinkButton)sender).CommandArgument;
                adlst = visafmbl.ReadForm(strStartCountry, strCity);
                Visa_gridshow.DataSource = adlst;
                Visa_gridshow.DataBind();
            }
            else if (RadioButtonList_selectcity.SelectedValue == "Bangalore")
            {
                string strCity = "Bangalore";
                string strStartCountry = ((LinkButton)sender).CommandArgument;
                adlst = visafmbl.ReadForm(strStartCountry, strCity);
                Visa_gridshow.DataSource = adlst;
                Visa_gridshow.DataBind();
            }
        }

        protected void Visa_gridshow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
       
            if (e.CommandName == "cmddelete")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                visafmbl.deleterecord(Id);
                BindVisaGridByCity();
            }
            else if (e.CommandName == "cmdViewVisaForm")
            {
                p = e.CommandArgument.ToString();
                string path = Server.MapPath(e.CommandArgument.ToString());
                WebClient client = new WebClient();
                if (File.Exists(path))
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "page_index_script", "openPDF();", true);
                }

                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No Visa Form Attached');", true);
                }
            }
        }

        protected void Visa_gridshow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                UserDom user = new UserDom();
                user = userBal.ReadUserByLoginId(basePage.LoggedInUser.LoginId);

                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkButtonDelete");


                lnkDelete.Visible = false;
                if (basePage.LoggedInUser.UserTypeId == Convert.ToInt32(UserType.Admin))
                {

                    lnkDelete.Visible = true;
                }
                else if (basePage.LoggedInUser.UserTypeId != Convert.ToInt32(UserType.Admin) && user.UserTask.Count > 0)
                {
                    for (int i = 0; i < user.UserTask.Count; i++)
                    {

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.DeleteVisaForm))))
                        {
                            if (lnkDelete != null)
                            {
                                lnkDelete.Visible = true;
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Private Methods..


        public void BindVisaGridByCity()
        {
            if (RadioButtonList_selectcity.SelectedValue == "Delhi")
            {
                adlst = visafmbl.ReadDelhiForm();
                Visa_gridshow.DataSource = adlst;
                Visa_gridshow.DataBind();
            }
            else if (RadioButtonList_selectcity.SelectedValue == "Mumbai")
            {
                adlst = visafmbl.ReadMumbaiForm();
                Visa_gridshow.DataSource = adlst;
                Visa_gridshow.DataBind();
            }
            else if (RadioButtonList_selectcity.SelectedValue == "Chennai")
            {
                adlst = visafmbl.ReadChannaiForm();
                Visa_gridshow.DataSource = adlst;
                Visa_gridshow.DataBind();
            }
            else if (RadioButtonList_selectcity.SelectedValue == "Bangalore")
            {

                adlst = visafmbl.ReadBangaloreForm();
                Visa_gridshow.DataSource = adlst;
                Visa_gridshow.DataBind();
            }
        }

        #endregion
    }
}
