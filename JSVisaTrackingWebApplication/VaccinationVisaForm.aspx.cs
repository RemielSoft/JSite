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
    public partial class VaccinationVisaForm : System.Web.UI.Page
    {

        VisaRequirementBusinessAccess advs = new VisaRequirementBusinessAccess();
        BasePage bp = new BasePage();
        VisaForm visaFormDOM = new VisaForm();
        VisaFormBL visaFormBAL = new VisaFormBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindVaccinationGrid();
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
            visaFormBAL.InsertVaccination(visaFormDOM);
            lst.Add(visaFormDOM);
            BindVaccinationGrid();
           // bind();
        }

        protected void Vaccination_gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
           // Label lblForm = null;
            if (e.CommandName == "cmdDelete")
            {
                visaFormBAL.DeleteVaccination(id);
                BindVaccinationGrid();
                //foreach (GridViewRow item in Vaccination_gridview.Rows)
                //{
                //    lblForm = (Label)item.FindControl("lbl_title");
                //    string formname = lblForm.Text;
                //    File.Delete(Server.MapPath(formname));
                //    visaFormBAL.DeleteVaccination(id);
                //    BindVaccinationGrid();
                //    break;
                //}
            }
        }
        private List<VisaForm> list
        {
            get
            {
                return (List<VisaForm>)Session["list"];
            }
            set
            {
                Session["list"] = value;
            }
        }
        public List<VisaForm> bind()
        {
            if (list == null)
            {
                list = new List<VisaForm>();
                visaFormDOM.FilePath = ("/AddVisaForm/" + uploadform.FileName);
                visaFormDOM.VisaTitle = txtvisatitle.Text;
                visaFormDOM.LocationId = bp.LoggedInUser.UserLocation.LocationId;
                visaFormDOM.Created_By = bp.LoggedInUser.LoginId;
                visaFormDOM.Form = "/AddVisaForm/" + uploadform.FileName;
                string filename1 = Path.GetFileName(uploadform.PostedFile.FileName);
                uploadform.PostedFile.SaveAs(Server.MapPath("/AddVisaForm/" + uploadform.FileName));
                visaFormBAL.InsertVaccination(visaFormDOM);
                list.Add(visaFormDOM);
                BindVaccinationGrid();
            }
            else
            {
                visaFormDOM.FilePath = ("/AddVisaForm/" + uploadform.FileName);
                visaFormDOM.VisaTitle = txtvisatitle.Text;
                visaFormDOM.LocationId = bp.LoggedInUser.UserLocation.LocationId;
                visaFormDOM.Created_By = bp.LoggedInUser.LoginId;
                visaFormDOM.Form = "/AddVisaForm/" + uploadform.FileName;
                string filename1 = Path.GetFileName(uploadform.PostedFile.FileName);
                uploadform.PostedFile.SaveAs(Server.MapPath("/AddVisaForm/" + uploadform.FileName));
                list.Add(visaFormDOM);
                BindVaccinationGrid();
            }
            return list;
        }

        public void BindVaccinationGrid()
        {
            var lst = visaFormBAL.ReadVaccination(null);
            Vaccination_gridview.DataSource = lst;
            Vaccination_gridview.DataBind();
           
        }
    }
}