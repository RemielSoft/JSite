using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.Drawing;
using System.Net;

namespace JSVisaTrackingWebApplication
{
    public partial class ShowVisaForm : System.Web.UI.Page
    {
        VisaFormBL visafmbl = new VisaFormBL();
        VisaForm advisaform = new VisaForm();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList_selectcity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList_selectcity.SelectedValue == "Delhi")
            {

                VisaForm advisaform = new VisaForm();
                List<VisaForm> adlst = new List<VisaForm>();
                adlst = visafmbl.ReadDelhiForm();
                Visa_gridshow.DataSource = adlst;
                Visa_gridshow.DataBind();
            }
            else if (RadioButtonList_selectcity.SelectedValue == "Mumbai")
            {
                VisaForm advisaform = new VisaForm();
                List<VisaForm> adlst = new List<VisaForm>();
                adlst = visafmbl.ReadMumbaiForm();
                Visa_gridshow.DataSource = adlst;
                Visa_gridshow.DataBind();
            }
            else if (RadioButtonList_selectcity.SelectedValue == "Channai")
            {
                VisaForm advisaform = new VisaForm();
                List<VisaForm> adlst = new List<VisaForm>();
                adlst = visafmbl.ReadChannaiForm();
                Visa_gridshow.DataSource = adlst;
                Visa_gridshow.DataBind();
            }
            else if (RadioButtonList_selectcity.SelectedValue == "Bangalore")
            {

                VisaForm advisaform = new VisaForm();
                List<VisaForm> adlst = new List<VisaForm>();
                adlst = visafmbl.ReadBangaloreForm();
                Visa_gridshow.DataSource = adlst;
                Visa_gridshow.DataBind();
            }
        }

        protected void LinkButtonA_Click(object sender, EventArgs e)
        {
            if (RadioButtonList_selectcity.SelectedValue == "Delhi")
            {
                string strCity = "Delhi";
                string strStartCountry = ((LinkButton)sender).CommandArgument;
                VisaForm advisaform = new VisaForm();
                List<VisaForm> adlst = new List<VisaForm>();
                adlst = visafmbl.ReadForm(strStartCountry, strCity);

                Visa_gridshow.DataSource = adlst;
                Visa_gridshow.DataBind();
            }
            else if (RadioButtonList_selectcity.SelectedValue == "Mumbai")
            {
                string strCity = "Mumbai";
                string strStartCountry = ((LinkButton)sender).CommandArgument;
                VisaForm advisaform = new VisaForm();
                List<VisaForm> adlst = new List<VisaForm>();
                adlst = visafmbl.ReadForm(strStartCountry, strCity);

                Visa_gridshow.DataSource = adlst;
                Visa_gridshow.DataBind();
            }
            else if (RadioButtonList_selectcity.SelectedValue == "Channai")
            {
                string strCity = "Channai";
                string strStartCountry = ((LinkButton)sender).CommandArgument;
                VisaForm advisaform = new VisaForm();
                List<VisaForm> adlst = new List<VisaForm>();
                adlst = visafmbl.ReadForm(strStartCountry, strCity);

                Visa_gridshow.DataSource = adlst;
                Visa_gridshow.DataBind();
            }
            else if (RadioButtonList_selectcity.SelectedValue == "Bangalore")
            {
                string strCity = "Bangalore";
                string strStartCountry = ((LinkButton)sender).CommandArgument;
                VisaForm advisaform = new VisaForm();
                List<VisaForm> adlst = new List<VisaForm>();
                adlst = visafmbl.ReadForm(strStartCountry, strCity);

                Visa_gridshow.DataSource = adlst;
                Visa_gridshow.DataBind();
            }
        }
        protected void OpenPDF(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            string path = Server.MapPath("~/Form/" + lnk.CommandArgument.ToString());
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(path);

            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
            
        }


    }
}