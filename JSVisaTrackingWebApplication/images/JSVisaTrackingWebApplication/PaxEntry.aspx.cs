using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;


namespace JSVisaTrackingWebApplication
{
    public partial class PaxEntry : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDown();
                if (Request.QueryString["AgentID"] != null)
                {

                    Lblagentname.Text = Request.QueryString["AgentName"];
                }

            }

        }

        public void FillDropDown()
        {
            PaxEntryBAL paxBal = new PaxEntryBAL();
            Pax pax = new Pax();
            int countryId = Convert.ToInt32(Session["CountryId"]);
            ddlCountry.DataSource = paxBal.ReadCountry(countryId);
            ddlCountry.DataTextField = "Country_Name";
            ddlCountry.DataValueField = "EMBS_ID";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlCountry.SelectedValue = "0";
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaxEntryBAL paxBal = new PaxEntryBAL();
            Pax pax = new Pax();
            int MyEmbassyId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
            ddlVisaType.DataSource = paxBal.ReadVisaType(MyEmbassyId);
            ddlVisaType.DataTextField = "DESCRIPTION_ONE";
            ddlVisaType.DataValueField = "TYPE_ONE_ID";
            ddlVisaType.DataBind();
            ddlVisaType.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlVisaType.SelectedValue = "0";
        }

        protected void ddlVisaType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaxEntryBAL paxBal = new PaxEntryBAL();
            Pax pax = new Pax();
            int MyEmbassyId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
            int MyVisaTypeId = Convert.ToInt32(ddlVisaType.SelectedItem.Value);
            ddlnoofvisit.DataSource = paxBal.ReadNo_Of_Visit(MyEmbassyId, MyVisaTypeId);
            ddlnoofvisit.DataTextField = "DESCRIPTION_TWO";
            ddlnoofvisit.DataValueField = "TYPE_TWO_ID";
            ddlnoofvisit.DataBind();
            ddlnoofvisit.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlnoofvisit.SelectedValue = "0";
        }

        protected void ddlnoofvisit_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaxEntryBAL paxBal = new PaxEntryBAL();
            Pax pax = new Pax();
            int MyEmbassyId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
            int MyVisaTypeId = Convert.ToInt32(ddlVisaType.SelectedItem.Value);
            int MyNoofEntry = Convert.ToInt32(ddlnoofvisit.SelectedItem.Value);
            ddlVisaDuration.DataSource = paxBal.ReadVisaDuration(MyVisaTypeId, MyNoofEntry, MyEmbassyId);
            ddlVisaDuration.DataTextField = "VISA_DESCRIPTION";
            ddlVisaDuration.DataValueField = "DURATION_ID";
            ddlVisaDuration.DataBind();
            ddlVisaDuration.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlVisaDuration.SelectedValue = "0";
        }

        protected void ddlVisaDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaxEntryBAL paxBal = new PaxEntryBAL();
            Pax pax = new Pax();
            int MyEmbassyId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
            int MyVisaTypeId = Convert.ToInt32(ddlVisaType.SelectedItem.Value);
            int MyNoofEntry = Convert.ToInt32(ddlnoofvisit.SelectedItem.Value);
            int MyVisaDurationId = Convert.ToInt32(ddlVisaDuration.SelectedItem.Value);
            ddlprocesstime.DataSource = paxBal.ReadProcessTime(MyVisaTypeId, MyNoofEntry, MyEmbassyId, MyVisaDurationId);
            ddlprocesstime.DataTextField = "DESCRIPTION";
            ddlprocesstime.DataValueField = "PROCESS_TIME_ID";
            ddlprocesstime.DataBind();

        }

        public void BindGrid()
        {
            PaxEntryBAL paxBal = new PaxEntryBAL();
            int paxId = Convert.ToInt32(Session["PaxId"]);
            int consignmentId = Convert.ToInt32(Session["ID"]);
            gridview_Pax.DataSource = paxBal.BindGrid(paxId, consignmentId);
            gridview_Pax.DataBind();

        }

        protected void addpax_Click(object sender, EventArgs e)
        {

            PaxEntryBAL paxBal = new PaxEntryBAL();
            Pax pax = new Pax();

            pax.FKConsignmentId = Convert.ToInt32(Session["ID"]);
            pax.FkPaxId = Convert.ToInt32(Session["PaxId"]);
            pax.CountryId = Convert.ToInt32(Session["CountryId"]);
            pax.VisaTypeOneId = Convert.ToInt32(ddlVisaType.SelectedItem.Value);
            pax.VisaTypeTwoId = Convert.ToInt32(ddlnoofvisit.SelectedItem.Value);
            pax.DurationId = Convert.ToInt32(ddlVisaDuration.SelectedItem.Value);
            pax.ProcessTimeid = Convert.ToInt32(ddlprocesstime.SelectedItem.Value);
            //Session["ObjPaxAdditionalInfo"] = pax;
            paxBal.CreateAdditonalPax(pax);


            BindGrid();
            Response.Redirect("AddConsignment.aspx");
            ScriptManager.RegisterClientScriptBlock(addpax, GetType(), "test", "alert(' Pax Saved  successfully!!!')", true);
        }



        protected void btnPaxEntry_Click(object sender, EventArgs e)
        {

            PaxEntryBAL paxBal = new PaxEntryBAL();
            Pax pax = new Pax();
            pax.ConsignmentId = Convert.ToInt32(Session["ID"]);
            pax.PaxName = txt_paxname.Text;
            pax.DateOfBirth = Convert.ToDateTime(txt_dob.Text);
            pax.PaxPassportNo = txt_PassportNo.Text;

            if (chktickets.Checked == true)
            {
                pax.PaxTicket = 'Y';
            }
            else
                pax.PaxTicket = 'N';

            if (chkMedIns.Checked == true)
            {
                pax.PaxMedInsurance = 'Y';
            }
            else
                pax.PaxMedInsurance = 'N';

            if (chkCreditCard.Checked == true)
            {
                pax.PaxCreditCard = 'Y';
            }
            else
                pax.PaxCreditCard = 'N';

            if (chkcertificate.Checked == true)
            {
                pax.PaxCertificates = 'Y';
            }
            else
                pax.PaxCertificates = 'N';

            if (chkItPaper.Checked == true)
            {
                pax.PaxItPaper = 'Y';
            }
            else
                pax.PaxItPaper = 'N';

            if (chkDraft.Checked == true)
            {
                pax.PaxDraft = 'Y';
            }
            else
                pax.PaxDraft = 'N';

            pax.PaxRemarks = txtPaxRemarks.Text;

            int paxId = paxBal.CreatePax(pax);
            Session["PaxId"] = paxId;
            FillDropDown();
            ScriptManager.RegisterClientScriptBlock(btnPaxEntry, GetType(), "test", "alert('Fill Additional Pax Info!!!')", true);
            divPax.Visible = false;
            DivAdditional.Visible = true;
        }



    }
}