using AmexQuickPay;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSVisaTrackingWebApplication
{
    public partial class ViewPaymentResponse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string merchantDetailsResp = "";
            string enc_Key = ConfigurationManager.AppSettings["Enc_Id"].ToString();
            AmexQuickPay.QuickPayClientAPI ezeClickClientApi = new QuickPayClientAPI();
            AmexQuickPay.ResponseDTO responseDTO = new ResponseDTO();


            try
            {
                //Response.Write("I am on the page");
                if (Request.Form["merchantResponse"] != null)
                {
                    //  merchantDetailResponse = Request.Form["merchantResponse"].ToString();
                    responseDTO = ezeClickClientApi.getDigitalReceipt(merchantDetailsResp, enc_Key);
                    //retrieve the transaction status
                    if (responseDTO.Qp_PaymentStatus.ToUpper() == "S")
                    {
                        //Transaction is Success
                        //SMTP Client Mail
                        //SmtpClient smtpClient = new SmtpClient("www.gmail.com");
                        //MailMessage msg = new MailMessage();
                        //msg.To.Add("perveshd@remielsoft.com");
                        //MailAddress mailAddress = new MailAddress("updates@jetsavetours.com");
                        //msg.From = mailAddress;
                        //msg.Body = "Payer Pappu";
                        //msg.IsBodyHtml = true;
                        //smtpClient.Send(msg);
                    }
                    else
                    {
                        Response.Write("Fail");
                        //if Transaction is Failed......................
                        //  SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                        //  NetworkCredential ncr = new NetworkCredential("payments@jetsavetours.com", " hbfewui2838y");
                        //  smtpClient.Credentials = ncr;
                        //  smtpClient.EnableSsl = true;
                        //  MailMessage msg = new MailMessage();
                        //  msg.To.Add("divakersingh3414@gmail.com");
                        ////msg.CC.Add("visas@jetsavetours.com");
                        //  MailAddress mailAddress = new MailAddress("payments@jetsavetours.com");
                        //  msg.From = mailAddress;
                        //  msg.Body = "Hello Ok Mail Tested";
                        //  msg.IsBodyHtml = true;
                        //  smtpClient.Send(msg);
                    }
                }
                else
                {
                    // no response retreive from ezeclick. merchant needs to handle the error message
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}