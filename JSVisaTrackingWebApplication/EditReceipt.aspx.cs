using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using JSVisaTrackingWebApplication.Shared;

namespace JSVisaTrackingWebApplication
{
    public partial class EditReceipt : System.Web.UI.Page
    {
        ReceiptGenerationBusinessAccess rcptBal = new ReceiptGenerationBusinessAccess();
        BasePage basePage = new BasePage();        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {     
            Int32 RcptId = Convert.ToInt32(txtRcptNo.Text);
            List<Receipt> lstReceipt = new List<Receipt>();
            int LocId = basePage.LoggedInUser.UserLocation.LocationId;
            int userId = basePage.LoggedInUser.UserTypeId;
            if (userId == Convert.ToInt32(UserType.Admin))
            {
                LocId = 0;
                lstReceipt = rcptBal.ReadRcptAll(RcptId, LocId);
            }
            else
            {
                lstReceipt = rcptBal.ReadRcptAll(RcptId, LocId);
            }

            if (lstReceipt.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('No Receipt Found With This Receipt No.');", true);
                txtRcptNo.Focus();
            }
            else
            {
                Session["lstReceipt"] = lstReceipt;
                Response.Redirect("ReceiptGeneration.aspx?lstReceipt=" + lstReceipt);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Int32 RcptId = Convert.ToInt32(txtRcptNo.Text);
            List<Receipt> lstReceipt = new List<Receipt>();
            int LocId = basePage.LoggedInUser.UserLocation.LocationId;
            int userId = basePage.LoggedInUser.UserTypeId;
            if (userId == Convert.ToInt32(UserType.Admin))
            {
                LocId = 0;
                lstReceipt = rcptBal.ReadRcptAll(RcptId, LocId);
            }
            else
            {
                lstReceipt = rcptBal.ReadRcptAll(RcptId, LocId);
            }
            if (lstReceipt.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('No Receipt Found With This Receipt No.');", true);
                txtRcptNo.Focus();
            }
            else
            {
                rcptBal.DeleteReceipt(RcptId);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('Record Deleted Successfully.');", true);
                txtRcptNo.Text = string.Empty;
            }
        }
    }
}