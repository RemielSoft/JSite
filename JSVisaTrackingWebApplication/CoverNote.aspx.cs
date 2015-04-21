using JSVisaTrackingWebApplication.Shared;
using Remielsoft.JetSave.BusinessAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSVisaTrackingWebApplication
{
    public partial class CoverNote : System.Web.UI.Page
    {
        VisaRequirementBusinessAccess advs = new VisaRequirementBusinessAccess();
        BasePage bp = new BasePage();
        VisaForm visaFormDOM = new VisaForm();
        VisaFormBL visaFormBAL = new VisaFormBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCoverNoteGrid();
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            var lst = new List<VisaForm>();
            visaFormDOM.FilePath = ("/AddVisaForm/" + uploadform.FileName);
            visaFormDOM.VisaTitle = txtvisatitle.Text;
            visaFormDOM.LocationId = bp.LoggedInUser.UserLocation.LocationId;
            visaFormDOM.Created_By = bp.LoggedInUser.LoginId;
            visaFormDOM.Form = "/AddVisaForm/" + uploadform.FileName;
            string filename1 = Path.GetFileName(uploadform.PostedFile.FileName);
            uploadform.PostedFile.SaveAs(Server.MapPath("/AddVisaForm/" + uploadform.FileName));
            visaFormBAL.InsertCoverNote(visaFormDOM);
            lst.Add(visaFormDOM);
            BindCoverNoteGrid();
          
        }

        protected void CoverNote_gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "cmdDelete")
            {
                visaFormBAL.DeleteCoverNote(id);
                BindCoverNoteGrid();
            }
        }
        public void BindCoverNoteGrid()
        {
            var lst = visaFormBAL.ReadCoverNote(null);
            CoverNote_gridview.DataSource = lst;
            CoverNote_gridview.DataBind();

        }
    }
}