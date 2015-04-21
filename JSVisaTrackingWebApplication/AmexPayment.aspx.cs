using OnlinePayment;
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
    public partial class AmexPayment : System.Web.UI.Page
    {
        VisaRequirementBusinessAccess visaReqBal = new VisaRequirementBusinessAccess();
        public List<string> lstPayment = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
           // SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
           // NetworkCredential ncr = new NetworkCredential("payments@jetsavetours.com", " hbfewui2838y");
           // smtpClient.Credentials = ncr;
           // smtpClient.EnableSsl = true;
           // MailMessage msg = new MailMessage();
           ////  msg.To.Add("divakersingh3414@gmail.com ");
           // //   msg.CC.Add("perveshd@remielsoft.com");
           // MailAddress mailAddress = new MailAddress("payments@jetsavetours.com");
           // msg.From = mailAddress;
           // msg.Body = "<table width='100%' cellpadding='10' cellspacing='0' border='1'><thead><tr><td>C. No</td><td>Visa</td><td>No. of Pax</td><td>Submission Date</td><td>Collection Date</td><td>Check On Date</td><td>Corporate</td><td>Sent By</td><td>ASP Email</td><td>Remark</td></tr></thead><tbody><tr><td>DEL615093</td><td>Visa</td><td>No. of Pax</td><td>Submission Date</td><td>Collection Date</td><td>Check On Date</td><td>Corporate</td><td>Sent By</td><td>ASP Email</td><td>Remark</td></tr></tbody></table>";
           //  //   + "<tbody><tr><td>DEL615093</td><td>Visa</td><td>No. of Pax</td><td>Submission Date</td><td>Collection Date</td><td>Check On Date</td><td>Corporate</td><td>Sent By</td><td>ASP Email</td><td>Remark</td></tr></tbody></table>";
           // msg.IsBodyHtml = true;

           // smtpClient.Send(msg);
            BindCountry();
            ddlCountry.SelectedIndex = -1;
           
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            PaymentGen.payment = new List<string>();
           
            PaymentGen.payment.Add(txtOrderNo.Text);
            PaymentGen.payment.Add(txtAmount.Text);
            PaymentGen.payment.Add(txtName.Text);
            PaymentGen.payment.Add(txtEmail.Text);
            PaymentGen.payment.Add(txtPhone.Text);
            PaymentGen.payment.Add(ddlCountry.SelectedValue);
            PaymentGen.payment.Add(txtCity.Text);
            PaymentGen.payment.Add(txtState.Text);
            PaymentGen.payment.Add(txtAddress.Text);
            PaymentGen.payment.Add(txtZipPin.Text);
            PaymentGen.payment.Add(txtOrderDetail.Text);

            Response.Redirect("ViewPaymentdetail.aspx");
        }

        public void BindCountry()
        {
            ddlCountry.DataSource = visaReqBal.ReadCountry();
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataValueField = "COUNTRY_ID";
            ddlCountry.DataBind();

        }


    }
}