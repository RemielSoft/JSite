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
    public partial class AddVisaType : System.Web.UI.Page
    {
        VisaRequirement visaType = new VisaRequirement();
        VisaRequirementBusinessAccess visaBal = new VisaRequirementBusinessAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindgridVisaType();
                btnupdate.Visible = false;
                BtnAdd.Visible = true;
            }
        }

        protected void grdVisaType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument);
            Session["Id"] = Id;
            if (e.CommandName == "cmdedit")
            {

                List<VisaRequirement> lstVisa = visaBal.ReadVisaTypeOne(Id);
                txtVisaType.Text = lstVisa[0].DESCRIPTION_ONE;
                BtnAdd.Visible = false;
                btnupdate.Visible = true;

            }
            if (e.CommandName == "cmddelete")
            {
                visaBal.DeleteVisaTypeOne(Id);
                BindgridVisaType();
                txtVisaType.Text = "";
                btnupdate.Text = "Add";
            }
        }

        protected void grdVisaType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdVisaType.PageIndex = e.NewPageIndex;
            BindgridVisaType();
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            visaType.DESCRIPTION_ONE = txtVisaType.Text;
            visaType.Created_By = User.Identity.Name;
            int status = visaBal.CreateVisaTypeOne(visaType);
            if (status==1)
            {
                 Response.Write("<Script Language=javascript>alert('Visa Type Already Exists.');</Script>");
            }
            else
            {
                Response.Write("<Script Language=javascript>alert('Visa Type Saved Successfully.');</Script>");
            }
           
            BtnAdd.Visible = true;
            btnupdate.Visible = false;
            BindgridVisaType();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(Session["Id"]);
            visaType.TYPE_ONE_ID = Id;
            visaType.DESCRIPTION_ONE = txtVisaType.Text;
            visaType.Modified_By = User.Identity.Name;
            visaBal.UpdateVisaTypeOne(visaType);
            Response.Write("<Script Language=javascript>alert('Visa Type Updated Successfully.');</Script>");
            BtnAdd.Visible = true;
            btnupdate.Visible = false;
            BindgridVisaType();
        }
        private void BindgridVisaType()
        {
            Clear();
            var lstVisaTypeOne = visaBal.ReadVisaTypeOne(null);
            grdVisaType.DataSource = lstVisaTypeOne;
            grdVisaType.DataBind();
        }

        protected void btncancle_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            // txtDescription.Text = "";
            txtVisaType.Text = "";
        }
    }
}