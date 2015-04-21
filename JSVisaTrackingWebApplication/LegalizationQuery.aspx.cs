using JSVisaTrackingWebApplication.Shared;
using Remielsoft.JetSave.BusinessAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSVisaTrackingWebApplication
{
    public partial class LegalizationQuery : System.Web.UI.Page
    {
        BasePage bp = new BasePage();
        VisaRequirementBusinessAccess advs = new VisaRequirementBusinessAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountry();
            }
        }
        public void BindCountry()
        {
            var lst = advs.ReadCountry();
            chkCountry.DataSource = lst;
            chkCountry.DataTextField = "CountryName";
            //ChkBoxList.DataValueField = "COUNTRY_ID";
            chkCountry.DataBind();
        }

        protected void btnSendQuery_Click(object sender, EventArgs e)
        {
            string country = "";
            string legalization = "";
            string sendQuery = "<span style='margin-top: 20px; margin-bottom: 10px; color: red; border-bottom: 3px solid #e2e2e2; display: inline-block; font-size:20px'>Query</span><table cellpadding='8' cellspacing='0' border='0' style='font-size:12px; width:527px;'><tr><td style='background:#666; color:#fff'>Your Query</td><td style='background:#666; color:#fff'>Country</td><td style='background:#666; color:#fff'>Type of Document</td><td style='background:#666; color:#fff'>Legalization Service</td><td style='background:#666; color:#fff'>Other field</td></tr><tr>";
            string record = "";
            for (int i = 0; i <= chkCountry.Items.Count - 1; i++)
            {
                if (chkCountry.Items[i].Selected)
                {
                    if (country == "")
                    {
                        country = chkCountry.Items[i].Text + ",";
                    }
                    else
                    {
                        country += chkCountry.Items[i].Text + ",";
                    }
                }
            }
            for (int i = 0; i <= chklegalization.Items.Count - 1; i++)
            {
                if (chklegalization.Items[i].Selected)
                {
                    if (legalization == "")
                    {
                        legalization = chklegalization.Items[i].Text + ",";
                    }
                    else
                    {
                        legalization += chklegalization.Items[i].Text + ",";
                    }
                }
            }
            var legalizationList = legalization.Replace(",", "," + Environment.NewLine);
            var countrylist = country.Replace(",", "," + Environment.NewLine);

            record += "<td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'>" + txtdescribe.Text + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'>" + countrylist + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'>" + txtDocument.Text + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'>" + legalizationList + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'>" + txtOtherfield.Text + "</td></tr></table>";
            string contactdetails = "<span style='margin-top: 20px; margin-bottom: 10px; color: red; border-bottom: 3px solid #e2e2e2; display: inline-block; font-size:20px'>Contact Information</span><table cellpadding='8' cellspacing='0' border='0' style='font-size:12px; width:527px;'><tr><td style='background:#666; color:#fff'>Your Name</td><td style='background:#666; color:#fff'>Your Email</td><td style='background:#666; color:#fff'>Company Name</td><td style='background:#666; color:#fff'>Website</td><td style='background:#666; color:#fff'>Country</td><td style='background:#666; color:#fff'>City</td><td style='background:#666; color:#fff'>Mobile</td></tr><tr>";
            string info = "<td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'>" + txtyourname.Text + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'>" + txtyouremail.Text + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'>" + txtcompanyname.Text + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'> " + txtwebsite.Text + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'>" + txtcountry.Text + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2;'>" + txtcity.Text + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2; border-left:none;'>" + txtmobile.Text + "</td></tr></table>";
            MailMessage msg = new MailMessage();
            SmtpClient sp = new SmtpClient("smtp.gmail.com", 587);
            NetworkCredential ncr = new NetworkCredential("queries@jetsavetours.com", "divaker@remielsoft");
            sp.Credentials = ncr;
            sp.EnableSsl = true;
            msg.To.Add("divakersingh3414@gmail.com");
            //  msg.To.Add("aseem.sharma@jetsavetours.com");
            // msg.To.Add("anil.sharma@jetsavetours.com");
            //  msg.To.Add(" visas@jetsavetours.com");
            msg.CC.Add(txtyouremail.Text);
            MailAddress mailAddress = new MailAddress("queries@jetsavetours.com");
            msg.From = mailAddress;
            msg.IsBodyHtml = true;
            msg.Body = sendQuery + record + contactdetails + info;
            try
            {
                sp.Send(msg);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Message has been sent successfully.');", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + ex.Message + "');", true);
            }
            Response.Redirect("Index.aspx");
        }
    }
}