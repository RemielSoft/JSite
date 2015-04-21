using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
namespace JSVisaTrackingWebApplication
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ApplicationUser> lstUsers = null;

            ApplicationUserBusinessAccess appBA = new ApplicationUserBusinessAccess();

           lstUsers= appBA.ReadUsres();
            //Change by Divaker
           //gvUsers.DataSource = lstUsers;
           //gvUsers.DataBind();


        }
    }
}
