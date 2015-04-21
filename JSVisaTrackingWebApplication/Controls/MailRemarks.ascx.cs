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

namespace JSVisaTrackingWebApplication.Controls
{
    public partial class MailRemarks : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                repeaterbind();
            }
        }
        public void repeaterbind()
        {
            ConsignmentBusinessAccess consignBal = new ConsignmentBusinessAccess();
            List<Consignment> lstcon = (List<Consignment>)Session["listconsign"];
            ReptrMailRemarks.DataSource = lstcon;

            ReptrMailRemarks.DataBind();

        }
        protected void BtnMailremark_Click(object sender, EventArgs e)
        {
            //List<Consignment> lstcon = (List<Consignment>)Session["listconsign"];
            
            //for (int i = 0; i < lstcon.Count; i++)
            //{
            //    ConsignmentBusinessAccess consignBal = new ConsignmentBusinessAccess();
            //    MailRemark mailremarks = new MailRemark();
            //    mailremarks.ConsignmentId = lstcon[i].ConsignmentId.ToString() ;
            //    mailremarks.CountryId = lstcon[i].Country_Id;
            //   // mailremarks.SubmissionDate =  lstcon[i].CgSubmissionDate;
            //    //mailremarks.CheckOnDate=lstcon[i].CgCheckOnDate;
            //   // mailremarks.CollectionDate = lstcon[i].CG_COLLECTION_DATE;
            //    mailremarks.CollectedFlag = 5;
            //    mailremarks.Remarks = "pp";
            //    consignBal.CreateMailRemarks(mailremarks);
          //  }
        }
    }
}