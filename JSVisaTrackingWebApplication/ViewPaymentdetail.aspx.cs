using AmexQuickPay;
using OnlinePayment;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSVisaTrackingWebApplication
{
    public partial class ViewPaymentdetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            AmexQuickPay.QuickPayClientAPI quickPayClientAPI = new QuickPayClientAPI();
            if (PaymentGen.payment != null)
            {
                var x = PaymentGen.payment;
                var amount = Convert.ToDouble(PaymentGen.payment[1]);
                // lblAmount.Text = PaymentGen.payment[1];
                lblAmount.Text = PaymentGen.payment[1];
                lblCustomerName.Text = PaymentGen.payment[2];
                lblEmail.Text = PaymentGen.payment[3];
                lblStreetAddress.Text = PaymentGen.payment[8];
                lblStateName.Text = PaymentGen.payment[7];
                lblCountryName.Text = PaymentGen.payment[5];
                lblZipCode.Text = PaymentGen.payment[9];
                string orderId = PaymentGen.payment[0];
                // generate payment request message
                string encId = ConfigurationManager.AppSettings["Enc_Id"].ToString();
                MID.Value = ConfigurationManager.AppSettings["MID"].ToString();
                string url = ConfigurationManager.AppSettings["RedirectUrl"].ToString();
                string mgsrequest = quickPayClientAPI.generateDigitalOrder(MID.Value, orderId, (Convert.ToDecimal(lblAmount.Text) * 100).ToString(), url, encId);
                // string mgsrequest = quickPayClientAPI.getTransactionStatus(MID.Value, orderId, lblAmount.Text, url, encId);

                merchantRequest.Value = mgsrequest;
            }
        }



        protected void btnGoNow_Click(object sender, EventArgs e)
        {

        }

        protected void btnPayNow_Click(object sender, EventArgs e)
        {

        }

    }
}
