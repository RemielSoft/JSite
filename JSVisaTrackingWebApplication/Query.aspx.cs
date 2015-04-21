using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Net;

namespace JSVisaTrackingWebApplication
{
    public partial class Query : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSendQuery_Click(object sender, EventArgs e)
        {
            string airRailway = "";
            string hotel = "";
            string car = "";
            string sendQuery = "<span style='margin-top: 20px; margin-bottom: 10px; color: red; border-bottom: 3px solid #e2e2e2; display: inline-block; font-size:20px'>Query</span><table cellpadding='8' cellspacing='0' border='0' style='font-size:12px; width:527px;'><tr><td style='background:#666; color:#fff'>Describe Your Travel Plan/Requirements</td><td style='background:#666; color:#fff'>Expected Arrival</td><td style='background:#666; color:#fff'>Duration</td><td style='background:#666; color:#fff'>Number of Persons</td><td style='background:#666; color:#fff'>Budget</td><td style='background:#666; color:#fff'>Also Interested</td></tr><tr>";
            string record = "";
            if (chkairrail.Checked)
            {
                airRailway = chkairrail.Text;

            }
            if (chkhotel.Checked)
            {
                hotel = chkhotel.Text;

            }
            else
            {
                hotel.Replace(",", "");
            }
            if (chkcar.Checked)
            {
                car = chkcar.Text;

            }
            record += "<td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'>" + txtdescribe.Text + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'>" + txtfrmdate.Text + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'>" + ddlduration.SelectedValue + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'> 'Adult:'" + ddlnoOfPersons.SelectedValue + ", 'Kids:' " + ddlkids.SelectedValue + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2;'>" + ddlbudget.SelectedValue + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2; border-left:none;'>" + airRailway + " , " + hotel + "," + car + "</td></tr></table>";
            string contactdetails = "<span style='margin-top: 20px; margin-bottom: 10px; color: red; border-bottom: 3px solid #e2e2e2; display: inline-block; font-size:20px'>Contact Information</span><table cellpadding='8' cellspacing='0' border='0' style='font-size:12px; width:527px;'><tr><td style='background:#666; color:#fff'>Your Name</td><td style='background:#666; color:#fff'>Your Email</td><td style='background:#666; color:#fff'>Company Name</td><td style='background:#666; color:#fff'>Website</td><td style='background:#666; color:#fff'>Country</td><td style='background:#666; color:#fff'>City</td><td style='background:#666; color:#fff'>Mobile</td></tr><tr>";


            string info = "<td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'>" + txtyourname.Text + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'>" + txtyouremail.Text + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'>" + txtcompanyname.Text + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'> " + txtwebsite.Text + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2; border-right:none;'>" + txtcountry.Text + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2;'>" + txtcity.Text + "</td><td class='auto-style2' style='border: 1px solid #e2e2e2; border-left:none;'>" + txtmobile.Text + "</td></tr></table>";

            MailMessage msg = new MailMessage();
            SmtpClient sp = new SmtpClient("smtp.gmail.com", 587);
            NetworkCredential ncr = new NetworkCredential("payments@jetsavetours.com", "hbfewui2838y");
            sp.Credentials = ncr;
            sp.EnableSsl = true;
            msg.To.Add("divakersingh3414@gmail.com");
            msg.CC.Add(txtyouremail.Text);
            MailAddress mailAddress = new MailAddress("payments@jetsavetours.com");
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


        }
    }
}




