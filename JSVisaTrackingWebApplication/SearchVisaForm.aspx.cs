using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;

namespace JSVisaTrackingWebApplication
{
    public partial class SearchVisaForm : System.Web.UI.Page
    {
        VisaForm advisaform = new VisaForm();
        VisaFormBL visafmbl = new VisaFormBL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_search_Click1(object sender, EventArgs e)
        {
            Agent ad = new Agent();

            List<VisaForm> adlst = new List<VisaForm>();

            adlst = visafmbl.ReadVisarecord(txt_search.Text.Trim());


            gvDetails.DataSource = adlst;
            gvDetails.DataBind();

        }
        protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Values["Id"].ToString());

            visafmbl.deleterecord(Id);
            List<VisaForm> adlst = new List<VisaForm>();

           adlst = visafmbl.ReadVisarecord(txt_search.Text.Trim());


            gvDetails.DataSource = adlst;
            gvDetails.DataBind();
            

        }
    }
}