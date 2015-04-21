using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.Web.Configuration;
using JSVisaTrackingWebApplication.Shared;

namespace JSVisaTrackingWebApplication
{
    public partial class AddConsignment : System.Web.UI.Page
    {
        VisaRequirementBusinessAccess visaReqBal = new VisaRequirementBusinessAccess();
        BasePage basePage = new BasePage();
        LocationBusinessAccess locationBAL = new LocationBusinessAccess();
        ConsignmentBusinessAccess consignBal = new ConsignmentBusinessAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                FillDropDown();
                if (Request.QueryString["AgentID"] != null)
                {
                    LblAgentName.Text = Request.QueryString["AgentName"];

                    //lblPAXAgent.Text = Request.QueryString["AgentName"];
                }
                if (Session["ConsignmentId"] != null)
                {
                    LblRefNo.Text = Session["ConsignmentId"].ToString();
                    Lblrefno1.Text = Session["ConsignmentId"].ToString();
                }
               

           BindCountryList();
            MailRemarkGridBind();
            FillPaxGrid();
            BtnConsignmentUpdate.Visible = false;
            if (Request.QueryString["ConsignmentId"] != null)
            {
                BtnConsignmentUpdate.Visible = true;
                BtnConsignmentSave.Visible = false;

                ConsignmentBusinessAccess consignBal = new ConsignmentBusinessAccess();
                //Btnupdate.Visible = true;

                int id = Convert.ToInt32(Request.QueryString["ConsignmentId"]);
                List<Consignment> lst = consignBal.ReadDataByConsignmentId(id);

                //DrpdnVisaCountry.SelectedItem.Text = lst[0].CountryName.ToString();


                //txtSubmDate.Text = lst[0].CgSubmissionDate.ToString();
               // txtChkDate.Text = lst[0].CgCheckOnDate.ToString();
                //txtTravlDate.Text = lst[0].CgTravelDates.ToString();

                txtGroup.Text = lst[0].CgGroupRep.ToString();
                TxtInstruction.Text = lst[0].CgInstruction.ToString();
                txtRemark.Text = lst[0].CgRemarks.ToString();

                //ChckbxCollctd.Text = lst[0].CG_COLLECTED;
              //  ChckbxBlnkColDate.Text = lst[0].CG_BLANK_COLLECTION_DATE;
               // ChckbxDisabl.Text = lst[0].CG_DISABLE;
               // ChckbxBlankSubDate.Text = lst[0].CG_BLANK_SUBMISSION_DATE;
                txtAreaCod.Text = lst[0].CgAreaCode;
                //consignment.CG_TRANSFER_TO = DrpdnTransfer.SelectedItem.Text;


                txtNoPassport.Text = lst[0].CgNoOfPass.ToString();
                txtNoDD.Text = lst[0].CgNoOfDD.ToString();
                txtEnterdBy.Text = lst[0].CgEnteredBy;
                txtSntName.Text = lst[0].CgSentBy;
                txtCorporate.Text = lst[0].CgCorporate;
                txtmob.Text = lst[0].CgMobNo;

                txtEmail.Text = lst[0].CgAspMail;
                
                //showTable.Visible = true;
            }

            }
        }
            
        

        public void BindCountryList()
        {
            LstCountry.DataSource = visaReqBal.ReadCountry();
            LstCountry.DataTextField = "CountryName";
            LstCountry.DataValueField = "COUNTRY_ID";
            LstCountry.DataBind();

        }

        protected void BtnMveCountryRht_Click(object sender, EventArgs e)
        {
            string s = LstCountry.SelectedItem.ToString();
            string st = LstCountry.SelectedItem.Value;
            LstCountry.Items.Remove(s);
            LstSelectedCountry.Items.Add(new ListItem(s, st));

            DrpdnVisaCountry.Items.Add(new ListItem(s, st));

        }
        
        protected void BtnMveCountryLft_Click(object sender, EventArgs e)
        {
            string s = LstSelectedCountry.SelectedItem.ToString();
            LstSelectedCountry.Items.Remove(s);
            DrpdnVisaCountry.Items.Remove(s);
            LstCountry.Items.Add(s);
        }

        protected void BtnConsignmentSave_Click(object sender, EventArgs e)
        {
            ConsignmentBusinessAccess consignBal = new ConsignmentBusinessAccess();
            Consignment consignment = new Consignment();
            string  othrCountry=null;
            consignment.FkAgentId = Convert.ToInt32(Request.QueryString["AgentID"]);
            consignment.CgVisaCountry = Convert.ToInt32(DrpdnVisaCountry.SelectedItem.Value);
            Session["CountryId"] = Convert.ToInt32(DrpdnVisaCountry.SelectedItem.Value);
           foreach (ListItem item in LstSelectedCountry.Items)
            {
              
             othrCountry+= item.Text+","; 
            }
            consignment.CgOtherCountries = othrCountry;
            consignment.CgSubmissionDate = (txtSubmDate.Text);
            consignment.CgCheckOnDate = (txtChkDate.Text);
            consignment.CgTravelDates = (txtTravlDate.Text);
            consignment.CG_COLLECTION_DATE = (txtTravlDate.Text);
            consignment.CgGroupRep = txtGroup.Text;
            consignment.CgInstruction = TxtInstruction.Text;
            consignment.CgRemarks = txtRemark.Text;

            consignment.CG_COLLECTED = ChckbxCollctd.Text = "";
            consignment.CG_BLANK_COLLECTION_DATE = ChckbxBlnkColDate.Text = "";
            if (ChckbxDisabl.Checked == true)
            {
                consignment.CG_DISABLE = ChckbxDisabl.Text = "Y";
            }
            else
            consignment.CG_DISABLE = ChckbxDisabl.Text = "N";
            consignment.CG_BLANK_SUBMISSION_DATE = ChckbxBlankSubDate.Text = "";
            consignment.CgAreaCode = txtAreaCod.Text;
            consignment.CgNoOfPass = Convert.ToInt32(txtNoPassport.Text);
            consignment.CgNoOfDD = Convert.ToInt32(txtNoDD.Text);
            consignment.CgEnteredBy = txtEnterdBy.Text;
            consignment.CgSentBy = txtSntName.Text;
            consignment.CgCorporate = txtCorporate.Text;
            consignment.CgMobNo = txtmob.Text;

            consignment.CG_EMAIL = txtEmail.Text;
            //Session["ObjConsinment"] = consignment;
           
            int consgnmentId = consignBal.CreateConsignment(consignment);
            Session["ConsignmentId"] = consgnmentId;
            List<Consignment> lstConsign = new List<Consignment>();
            foreach (ListItem item in LstSelectedCountry.Items)
            {
                int consignmentId = Convert.ToInt32(Session["ConsignmentId"]);
                Consignment consign = new Consignment();
                consign.ConsignmentId = consignmentId;
                consign.CountryName = item.Text;
                consign.Country_Id =Convert.ToInt32( item.Value);
                consign.CgSubmissionDate = DateTime.Now.ToString("dd/MM/yyyy");
                consign.CG_COLLECTION_DATE = DateTime.Now.ToString("dd/MM/yyyy");
                consign.CgCheckOnDate = DateTime.Now.ToString("dd/MM/yyyy");
                lstConsign.Add(consign);

            }
            Session["listconsign"] = lstConsign;

            ScriptManager.RegisterClientScriptBlock(BtnConsignmentSave, GetType(), "test", "alert('Consignment Add   successfully!!!')", true);
            Response.Redirect("AddConsignment.aspx");
        }

        protected void Wizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            
            ConsignmentBusinessAccess consignBal = new ConsignmentBusinessAccess();
            Consignment consignment = new Consignment();
            string othrCountry = null;
            consignment.FkAgentId = Convert.ToInt32(Request.QueryString["AgentID"]);
            consignment.CgVisaCountry = Convert.ToInt32(DrpdnVisaCountry.SelectedItem.Value);
            Session["CountryId"] = Convert.ToInt32(DrpdnVisaCountry.SelectedItem.Value);
            foreach (ListItem item in LstSelectedCountry.Items)
            {

                othrCountry += item.Text + ",";
            }
            consignment.CgOtherCountries = othrCountry;
            consignment.CgSubmissionDate = (txtSubmDate.Text);
            consignment.CgCheckOnDate = (txtChkDate.Text);
            consignment.CgTravelDates = (txtTravlDate.Text);
            consignment.CG_COLLECTION_DATE = (txtTravlDate.Text);
            consignment.CgGroupRep = txtGroup.Text;
            consignment.CgInstruction = TxtInstruction.Text;
            consignment.CgRemarks = txtRemark.Text;

            consignment.CG_COLLECTED = ChckbxCollctd.Text = "";
            consignment.CG_BLANK_COLLECTION_DATE = ChckbxBlnkColDate.Text = "";
            if (ChckbxDisabl.Checked == true)
            {
                consignment.CG_DISABLE = ChckbxDisabl.Text = "Y";
            }
            else
                consignment.CG_DISABLE = ChckbxDisabl.Text = "N";
            consignment.CG_BLANK_SUBMISSION_DATE = ChckbxBlankSubDate.Text = "";
            consignment.CgAreaCode = txtAreaCod.Text;
            //consignment.CG_TRANSFER_TO = DrpdnTransfer.SelectedItem.Text;


            consignment.CgNoOfPass = Convert.ToInt32(txtNoPassport.Text);
            consignment.CgNoOfDD = Convert.ToInt32(txtNoDD.Text);
            consignment.CgEnteredBy = txtEnterdBy.Text;
            consignment.CgSentBy = txtSntName.Text;
            consignment.CgCorporate = txtCorporate.Text;
            consignment.CgMobNo = txtmob.Text;

            consignment.CG_EMAIL = txtEmail.Text;
           // Session["ObjConsinment"] = consignment;

            //int ID = consignBal.CreateConsignment(consignment);
           
            //Consignment lstConsign = new Consignment();

            List<MailRemark> lstMailRemarks = new List<MailRemark>();
            foreach (ListItem item in LstSelectedCountry.Items)
            {
                //int consignmentId = Convert.ToInt32(Session["ConsignmentId"]);
                MailRemark mailRemark = new MailRemark();
                //mailRemark.ConsignmentId = consignmentId;
                mailRemark.CountryName = item.Text;
                mailRemark.CountryId = Convert.ToInt32(item.Value);
                mailRemark.SubmissionDate = DateTime.Now;
                mailRemark.CollectionDate = DateTime.Now;
                mailRemark.CheckOnDate = DateTime.Now;
                lstMailRemarks.Add(mailRemark);

            }
            // lstMailRemark = lstMailRemarks;
            consignment.MailRemarksDetails = lstMailRemarks;
            Session["listconsign"] = consignment;

            if (Session["listconsign"] != null)
            {
                MailRemarkGridBind();
            }

            List<Pax> lstPaxDetails = new List<Pax>();
           // lstConsign.PaxDetails = lstPaxDetails;
           //Session["Pax"]=
           // ScriptManager.RegisterClientScriptBlock(BtnConsignmentSave, GetType(), "test", "alert('Consignment Add   successfully!!!')", true);
            
        }

        protected void BtnConsignmentUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ConsignmentId"]);
            ConsignmentBusinessAccess consignBal = new ConsignmentBusinessAccess();
            Consignment consignment = new Consignment();

            consignment.FkAgentId = 0;
            consignment.Country_Id = Convert.ToInt32(DrpdnVisaCountry.SelectedItem.Value);
           
            consignment.CgSubmissionDate = (txtSubmDate.Text);
            consignment.CgCheckOnDate = (txtChkDate.Text);
            consignment.CgTravelDates = (txtTravlDate.Text);
            consignment.CG_COLLECTION_DATE = (txtTravlDate.Text);
            consignment.CgGroupRep = txtGroup.Text;
            consignment.CgInstruction = TxtInstruction.Text;
            consignment.CgRemarks = txtRemark.Text;

            consignment.CG_COLLECTED = ChckbxCollctd.Text = "";
            consignment.CG_BLANK_COLLECTION_DATE = ChckbxBlnkColDate.Text = "";
            consignment.CG_DISABLE = ChckbxDisabl.Text = "";
            consignment.CG_BLANK_SUBMISSION_DATE = ChckbxBlankSubDate.Text = "";
            consignment.CgAreaCode = txtAreaCod.Text;
            //consignment.CG_TRANSFER_TO = DrpdnTransfer.SelectedItem.Text;


            consignment.CgNoOfPass = Convert.ToInt32(txtNoPassport.Text);
            consignment.CgNoOfDD = Convert.ToInt32(txtNoDD.Text);
            consignment.CgEnteredBy = txtEnterdBy.Text;
            consignment.CG_SENTBY_NAME = txtSntName.Text;
            consignment.CgCorporate = txtCorporate.Text;
            consignment.CgMobNo = txtmob.Text;

            consignment.CG_EMAIL = txtEmail.Text;

            consignBal.UpdateConsignment(consignment,id);
            ScriptManager.RegisterClientScriptBlock(BtnConsignmentUpdate, GetType(), "test", "alert('Consignment updated   successfully!!!')", true);
           

        }

        public void MailRemarkGridBind()
        {
            ConsignmentBusinessAccess consignBal = new ConsignmentBusinessAccess();
            Consignment lstcon = (Consignment)Session["listconsign"];
            if (lstcon != null && lstcon.MailRemarksDetails != null)
            {
                GridViewMailRemark.DataSource = lstcon.MailRemarksDetails;

                GridViewMailRemark.DataBind();
            }
            

        }

        protected void BtnMailremarkSave_Click(object sender, EventArgs e)
        {
           // Consignment lstcon = (Consignment)Session["listconsign"];
            
                    foreach (GridViewRow row in GridViewMailRemark.Rows )
                    {
                        MailRemark mailRemarks = new MailRemark();
                        TextBox txtremrk = (TextBox)row.FindControl("txtremarks");
                        CheckBox chbx = (CheckBox)row.FindControl("ChkboxCollected");
                           mailRemarks.ConsignmentId = "55555";

                        
                        mailRemarks.CountryId = Convert.ToInt32( Session["CountryId"]);
                        mailRemarks.SubmissionDate = DateTime.Now;
                        mailRemarks.CheckOnDate = DateTime.Now;
                        mailRemarks.CollectionDate = DateTime.Now;
                        if (chbx.Checked == true)
                        {
                            mailRemarks.CollectedFlag = 1;
                        }
                        else
                            mailRemarks.CollectedFlag = 0;
                        mailRemarks.Remarks = txtremrk.Text;
                        Session["mailRemarks"] = mailRemarks;
                        // consignBal.CreateMailRemarks(mailremarks);

                }
            
           // ScriptManager.RegisterClientScriptBlock(BtnMailremarkSave, GetType(), "test", "alert('MailRemarks saved  successfully!!!')", true);
        }
            
     
       

        public void FillDropDown()
        {
            PaxEntryBAL paxBal = new PaxEntryBAL();
            Pax pax = new Pax();
            int countryId = Convert.ToInt32(Session["CountryId"]);
            ddlCountry.DataSource = paxBal.ReadCountry(countryId);
            ddlCountry.DataTextField = "Country_Name";
            ddlCountry.DataValueField = "EmbsyId";
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
            ddlVisaType.DataTextField = "DescriptionOne";
            ddlVisaType.DataValueField = "TypeOneId";
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
            ddlnoofvisit.DataTextField = "DescriptionTwo";
            ddlnoofvisit.DataValueField = "TypeTwoId";
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
            ddlVisaDuration.DataTextField = "VisaDescription";
            ddlVisaDuration.DataValueField = "DurationId";
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
            ddlprocesstime.DataTextField = "Description";
            ddlprocesstime.DataValueField = "ProcessTimeId";
            ddlprocesstime.DataBind();

        }

        public void BindGrid()
        {
            PaxEntryBAL paxBal = new PaxEntryBAL();
            int paxId = Convert.ToInt32(Session["PaxId"]);
            int consignmentId = Convert.ToInt32(Session["ConsignmentId"]);
            //gridview_Pax.DataSource = paxBal.BindGrid(paxId, consignmentId);
           // gridview_Pax.DataBind();

        }

        protected void addpax_Click(object sender, EventArgs e)
        { 

            PaxEntryBAL paxBal = new PaxEntryBAL();
            Pax pax = new Pax();

            pax.FKConsignmentId = Convert.ToInt32(Session["ConsignmentId"]);
            pax.FkPaxId = 55; 
                //Convert.ToInt32(Session["PaxId"]);
            pax.CountryId = Convert.ToInt32(Session["CountryId"]);
            pax.VisaTypeOneId = Convert.ToInt32(ddlVisaType.SelectedItem.Value);
            pax.VisaTypeTwoId = Convert.ToInt32(ddlnoofvisit.SelectedItem.Value);
            pax.DurationId = Convert.ToInt32(ddlVisaDuration.SelectedItem.Value);
            pax.ProcessTimeid = Convert.ToInt32(ddlprocesstime.SelectedItem.Value);
            Session["ObjPaxAdditionalInfo"] = pax;
            //paxBal.CreateAdditonalPax(pax);


           // BindGrid();
            //Response.Redirect("AddConsignment.aspx");
           // ScriptManager.RegisterClientScriptBlock(addpax, GetType(), "test", "alert(' Pax Saved  successfully!!!')", true);
            DivPaxEntry.Visible = false;
            DivAdditional.Visible = false;
            DivPaxGrid.Visible = true;
        }

        protected void btnPaxEntry_Save_Click(object sender, EventArgs e)
        {

           // PaxEntryBAL paxBal = new PaxEntryBAL();
            //List<Pax> pax = new List<Pax>();
            Pax pax = new Pax();
            // foreach (ListItem item in LstSelectedCountry.Items)
           // {
           // pax.ConsignmentId = Convert.ToInt32(Session["ConsignmentId"]);
           // LblRefNo.Text = Session["ConsignmentId"].ToString();
            pax.PaxVit = txtvttNo.Text;
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

            pax.PaxOther = Txt_Others.Text;
            pax.PaxRemarks = txtPaxRemarks.Text;
            this.lstPax = new List<Pax>();
            this.lstPax.Add(pax);
           Consignment consign=(Consignment) Session["listconsign"];
           consign.PaxDetails = this.lstPax;
           Session["listconsign"] = consign;
            
            FillDropDown();
            DivPaxEntry.Visible = false;
            DivAdditional.Visible = true;
        }

        protected void btnaddPax_Click(object sender, EventArgs e)
        {
            DivPaxGrid.Visible = false;
            DivPaxEntry.Visible = true;

        }

        protected void btnPaxEntry_Update_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ViewState["PaxId"]);
            PaxEntryBAL paxBal = new PaxEntryBAL();
            Pax pax = new Pax();
           // pax.ConsignmentId = Convert.ToInt32(Session["ConsignmentId"]);
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

            consignBal.UpdatePax(pax, id);
           
            ScriptManager.RegisterClientScriptBlock(btnPaxEntry_Save, GetType(), "test", "alert(' Pax updated  successfully!!!')", true);
            FillPaxGrid();
            DivPaxEntry.Visible = false;
            DivPaxGrid.Visible = true;
        }

        public void FillPaxGrid()
        {
            
            Consignment lstcon = (Consignment)Session["listconsign"];

            int consignmentId = lstcon.ConsignmentId;
            gridFillPax.DataSource = consignBal.FillPaxGrid(consignmentId);
            gridFillPax.DataBind();

        }

        private List<MailRemark> lstMailRemark
        {
            get
            {
                return (List<MailRemark>)Session["lstMailRemark"];            
            }
            set
            {
                Session["lstMailRemark"] = value;
            }
        }
         private List<Pax> lstPax
        {
            get
            {
                return (List<Pax>)Session["lstPax"];            
            }
            set
            {
                Session["lstPax"] = value;
            }
        }

        protected void gridFillPax_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           // PaxEntryBAL paxBal=new PaxEntryBAL();
            int id = Convert.ToInt32(e.CommandArgument);
            ViewState["PaxId"] = id;
            if (e.CommandName == "cmdEdit")
            {
                DivPaxGrid.Visible = false;
                DivPaxEntry.Visible = true;
                btnPaxEntry_Update.Visible = true;
                btnPaxEntry_Save.Visible = false;
                List<Pax> lstpax = consignBal.ReadDataByPaxId(id);
                txt_paxname.Text = lstpax[0].PaxName.ToString() ;
                txt_PassportNo.Text = lstpax[0].PaxPassportNo.ToString(); ;
                //txt_dob.Text =  lstpax[0].DateOfBirth.ToString();
                //chktickets.Text = lstpax[0].PaxTicket.ToString();
               // chkMedIns.Text = lstpax[0].PaxMedInsurance.ToString();
               // chkCreditCard.Text = lstpax[0].PaxCreditCard.ToString();
               // chkcertificate.Text = lstpax[0].PaxCertificates.ToString();
               // chkItPaper.Text = lstpax[0].PaxItPaper.ToString();
               // chkDraft.Text = lstpax[0].PaxDraft.ToString();
                Txt_Others.Text = lstpax[0].PaxOther.ToString();
                txtRemark.Text = lstpax[0].PaxRemarks.ToString();
                
            }
            else if (e.CommandName == "cmdDelete")
            {
                consignBal.DeletePax(id);
                ScriptManager.RegisterClientScriptBlock(btnPaxEntry_Save, GetType(), "test", "alert(' Pax deleted  successfully!!!')", true);
            }
            FillPaxGrid();
        }

      
             protected void btnSubmit_Click(object sender, EventArgs e)
             {
                 Consignment consignment = (Consignment)Session["listconsign"];
                
                
                 int id=  consignBal.CreateConsignment(consignment);
                
                 
             }

    }
}