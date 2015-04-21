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
    public partial class InsuranceQuery : System.Web.UI.Page
    {
        VisaRequirementBusinessAccess advs = new VisaRequirementBusinessAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountry();
                BindState();
            }

        }
        public void BindCountry()
        {
            var lst = advs.ReadCountry();
            chkCountry.DataSource = lst;
            chkCountry.DataTextField = "CountryName";
            //chkCountry.DataValueField = "COUNTRY_ID";
            chkCountry.DataBind();
        }
        public void BindState()
        {
            var lst = advs.ReadAllState();
            ddlState.DataSource = lst;
            ddlState.DataTextField = "state";
            ddlState.DataValueField = "stateId";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlState.SelectedValue = "0";
        }
        protected void btnSendQuery_Click(object sender, EventArgs e)
        {
            string country = "";
            string sendQuery = "<span style='margin-top: 20px; margin-bottom: 10px; color: red; border-bottom: 3px solid #e2e2e2; display: inline-block; font-size:20px'>Query</span><table cellpadding='8' cellspacing='0' border='0' style='font-size:12px; width:527px;'><tr><td style='background:#666; color:#fff'>Your Plan/Requirements</td><td style='background:#666; color:#fff'>Date of travel</td><td style='background:#666; color:#fff'>Duration</td><td style='background:#666; color:#fff'>Number of Persons</td><td style='background:#666; color:#fff'>Country</td><td style='background:#666; color:#fff'>Passport issue from</td></tr><tr>";
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
            var countrylist = country.Replace(",", "," + Environment.NewLine);
            string travelDate = txtTravl.Text;
            string returnDate = txtreturn.Text;
            record += "<td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'>" + txtdescribe.Text + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'>" + txtfrmdate.Text + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'>" + ddlapllicant.SelectedValue + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'> Adult: " + ddlchildren06.SelectedValue + ", Kids: " + ddlchilred6.SelectedValue + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2;'>" + countrylist + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2;'>" + ddlState.SelectedItem.Text + "</td></tr></table>";
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