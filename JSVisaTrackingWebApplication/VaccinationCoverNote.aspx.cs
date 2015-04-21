using JSVisaTrackingWebApplication.Shared;
using Remielsoft.JetSave.BusinessAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSVisaTrackingWebApplication
{
    public partial class VaccinationCoverNote : System.Web.UI.Page
    {
        VisaRequirementBusinessAccess advs = new VisaRequirementBusinessAccess();
        BasePage bp = new BasePage();
        VisaForm visaFormDOM = new VisaForm();
        VisaFormBL visaFormBAL = new VisaFormBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCoverNoteGrid();
            BindVaccinationGrid();
        }
        public void BindCoverNoteGrid()
        {
            var lst = visaFormBAL.ReadCoverNote(null);
            CoverNote_gridview.DataSource = lst;
            CoverNote_gridview.DataBind();

        }

        public void BindVaccinationGrid()
        {
            var lst = visaFormBAL.ReadVaccination(null);
            grdVaccination.DataSource = lst;
            grdVaccination.DataBind();

        }
    }
}