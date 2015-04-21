using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.BusinessAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;

namespace JSVisaTrackingWebApplication
{
    public partial class BillRegisterInfoShow : System.Web.UI.Page
    {
        BillRegisterBusinessAccess billRegisterBal = new BillRegisterBusinessAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            int frb = Convert.ToInt32(Session["frombill"]);
            int tob = Convert.ToInt32(Session["tobill"]);
            
            DateTime frd = Convert.ToDateTime(Session["fromDate"]);
            DateTime tod = Convert.ToDateTime(Session["toDate"]);
            int loc = Convert.ToInt32(Session["LocationId"]);

            if (Request.QueryString["Req"] != null)
            {
                gv_billRegister.DataSource = billRegisterBal.BillRegisterInfoFromBillNo(frb,tob,loc);
                gv_billRegister.DataBind();
            }

            if (Request.QueryString["Req1"] != null)
            {
                gv_billRegister.DataSource = billRegisterBal.BillRegisterInfoByDate(frd,tod,loc);
                gv_billRegister.DataBind();
            }
        }

        
    }
}