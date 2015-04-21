using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace JSVisaTrackingWebApplication
{
    public partial class BillRegister : System.Web.UI.Page
    {
        BillRegisterBusinessAccess billRegisterBal = new BillRegisterBusinessAccess();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            BillRegister billRegister = new BillRegister();
            int locationId= Convert.ToInt32(Session["LocationId"]);
            if (ChkBill.Checked == true)
            {
                int fromBill = Convert.ToInt32(txt_fromBill.Text);
                int toBill = Convert.ToInt32(txt_toBill.Text);
                Session["fromBill"] = fromBill;
                Session["toBill"] = toBill;
                Response.Redirect("BillRegisterInfoShow.aspx?Req=" + fromBill + " and "+ toBill +"" );
            }
            if(ChkPeriod.Checked==true)
            {
                DateTime fromDate = Convert.ToDateTime(txt_fromDate.Text);
                DateTime toDate = Convert.ToDateTime(txt_toDate.Text);
                Session["fromDate"] = fromDate;
                Session["toDate"] = toDate;                
                Response.Redirect("BillRegisterInfoShow.aspx?Req1="+ fromDate +" and "+ toDate +"");
            }
        }
    }
}