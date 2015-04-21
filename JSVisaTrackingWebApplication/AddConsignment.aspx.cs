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
using System.Data;


namespace JSVisaTrackingWebApplication
{
    public partial class AddConsignment : BasePage
    {
        #region Global var...

        VisaRequirementBusinessAccess visaReqBal = new VisaRequirementBusinessAccess();
        LocationBusinessAccess locationBAL = new LocationBusinessAccess();
        ConsignmentBusinessAccess consignBal = new ConsignmentBusinessAccess();
        GroupMasterBusinessAccess groupMasterBal = new GroupMasterBusinessAccess();
        GenerateInvoiceBAL generateBAL = new GenerateInvoiceBAL();
        List<Bill> lstBill = new List<Bill>();
        Int32 consignmentId = 0;


        #endregion

        #region Protected methods.......

        protected void Page_Load(object sender, EventArgs e)
        {
            Wizard1.PreRender += new EventHandler(Wizard1_PreRender);
            if (!IsPostBack)
            {
                if (Request.QueryString["AgentID"] != null)
                {
                    string strAgent = Request.QueryString["AgentName"].Replace('!', '&');
                    LblAgentName.Text = strAgent;
                    LblpaxAgent.Text = strAgent;
                }
                BindDropDown(DrpdnVisaCountry, "CountryName", "COUNTRY_ID", visaReqBal.ReadCountry());
                BindDropDown(ddlGroup, "GroupName", "GroupId", groupMasterBal.BindGroupName());
                ddlGroup.Enabled = false;
                txtEnterdBy.Text = LoggedInUser.FullName;
                txtSntName.Text = LoggedInUser.FullName;
                txtmob.Text = LoggedInUser.MobileNo;
                txtEmail.Text = LoggedInUser.EmailId;
                BindCountryList();
                ddlVisaType.Enabled = false;
                ddlnoofvisit.Enabled = false;
                btnPaxEntry_Update.Visible = false;
                Button BtnConsignmentUpdate = (Button)Wizard1.FindControl("StartNavigationTemplateContainerID").FindControl("BtnConsignmentUpdate");
                BtnConsignmentUpdate.Visible = false;
                Button btnConsignmentSave = (Button)Wizard1.FindControl("StartNavigationTemplateContainerID").FindControl("btnConsignmentSave");
                btnConsignmentSave.Visible = true;
                //Button btnPaxEntry_Save = (Button)Wizard1.FindControl("FinishNavigationTemplateContainerID").FindControl("btnPaxEntry_Save");
                //btnPaxEntry_Save.Visible = false;
                //Button btnFinish = (Button)Wizard1.FindControl("FinishNavigationTemplateContainerID").FindControl("btnFinish");
                //btnFinish.Visible = false;

                #region  View Consignment....

                if (Request.QueryString["ConsignmentId"] != null && Request.QueryString["cons"] == "view")
                {
                    ViewConsignment();
                }

                #endregion

                #region  Edit Consignment....
                if (Request.QueryString["ConsignmentId"] != null && Request.QueryString["consignment"] == "EditConsignment")
                {
                    EditConsignment();
                }

                if (Request.QueryString["ConsignmentId"] != null && Request.QueryString["consignment"] == "EditAdvanceConsignment")
                {
                    int locationId = LoggedInUser.UserLocation.LocationId;
                    int userId = LoggedInUser.UserTypeId;
                    int id = Convert.ToInt32(Request.QueryString["ConsignmentId"]);
                    GenerateInvoiceBAL generateBAL = new GenerateInvoiceBAL();
                    List<Bill> lstBill;
                    if (userId == Convert.ToInt32(UserType.Admin))
                    {
                        locationId = 0;
                        lstBill = generateBAL.ReadConsignmentByIdAdvanceSearch(id, locationId);
                    }
                    else
                    {
                        lstBill = generateBAL.ReadConsignmentByIdAdvanceSearch(id, locationId);
                    }
                    //if (lstBill.Count > 0)
                    //{
                    EditConsignment();
                    //}
                    //else
                    //{
                    //    ViewConsignment();
                    //}
                }

                #endregion

            }

        }
        protected void Wizard1_PreRender(object sender, EventArgs e)
        {
            Repeater SideBarList = Wizard1.FindControl("HeaderContainer").FindControl("SideBarList") as Repeater;
            SideBarList.DataSource = Wizard1.WizardSteps;
            SideBarList.DataBind();


        }
        protected string GetClassForWizardStep(object wizardStep)
        {
            WizardStep step = wizardStep as WizardStep;
            if (step == null)
            {
                return "";
            }
            int stepIndex = Wizard1.WizardSteps.IndexOf(step);
            if (stepIndex < Wizard1.ActiveStepIndex)
            {
                return "prevStep";
            }
            else if (stepIndex > Wizard1.ActiveStepIndex)
            {
                return "nextStep";
            }
            else
            {
                return "currentStep";
            }

        }
        protected void Step_Click(object sender, EventArgs e)
        {
            LinkButton btnStep = (LinkButton)sender;
            string id = btnStep.Text;

            if (btnStep.CssClass == "prevStep" || btnStep.CssClass == "currentStep" || btnStep.CssClass == "nextStep")
            {
                switch (id)
                {
                    case "Consignment": Wizard1.MoveTo(Wizard1.WizardSteps[0]); break;
                    //case "Mail Remarks": Wizard1.MoveTo(Wizard1.WizardSteps[1]); break;
                    case "PAX Details": Wizard1.MoveTo(Wizard1.WizardSteps[1]); break;
                    default: Wizard1.MoveTo(Wizard1.WizardSteps[0]); break;
                }
            }
        }


        #region country List...

        protected void BtnMveCountryRht_Click(object sender, EventArgs e)
        {

            Consignment consignment = new Consignment();
            if (Session["CommaSeperatorCountry"] != null)
            {
                consignment.CountryName = LstCountry.SelectedItem.ToString();
                consignment.Country_Id = Convert.ToInt32(LstCountry.SelectedItem.Value);
                string name = LstCountry.SelectedItem.ToString();
                ListItem item1 = LstSelectedCountry.Items.FindByText(name);
                if (item1 == null)
                {
                    LstSelectedCountry.Items.Add(new ListItem(consignment.CountryName, consignment.Country_Id.ToString()));
                    DrpdnVisaCountry.Items.Add(new ListItem(consignment.CountryName, consignment.Country_Id.ToString()));
                }
                else
                {
                }
                Session.Remove("CommaSeperatorCountry");
            }
            else
            {
                if (LstCountry.SelectedItem != null)
                {
                    consignment.CountryName = LstCountry.SelectedItem.ToString();
                    consignment.Country_Id = Convert.ToInt32(LstCountry.SelectedItem.Value);
                    string name = LstCountry.SelectedItem.ToString();
                    ListItem item1 = LstSelectedCountry.Items.FindByText(name);
                    if (item1 == null)
                    {
                        LstSelectedCountry.Items.Add(new ListItem(consignment.CountryName, consignment.Country_Id.ToString()));
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(BtnMveCountryRht, GetType(), "test", "alert('Please Select Any Country ')", true);
                }
            }
        }
        protected void BtnMveCountryLft_Click(object sender, EventArgs e)
        {
            if (Session["CommaSeperatorCountry"] != null)
            {
                string id = LstSelectedCountry.SelectedItem.ToString();
                LstSelectedCountry.Items.Remove(new ListItem(id));
            }
            else
            {
                if (LstSelectedCountry.SelectedItem != null)
                {
                    Consignment consignment = new Consignment();
                    consignment.CountryName = LstSelectedCountry.SelectedItem.ToString();
                    consignment.Country_Id = Convert.ToInt32(LstSelectedCountry.SelectedItem.Value);
                    LstSelectedCountry.Items.Remove(new ListItem(consignment.CountryName, consignment.Country_Id.ToString()));
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(BtnMveCountryRht, GetType(), "test", "alert('Please Select Any selected Country ')", true);
                }
            }
        }

        #endregion

        #region  consignment....

        protected void btnConsignmentSave_Click(object sender, EventArgs e)
        {
            CreateConsignment(1);
        }
        protected void Wizard1_NextButtonClick(object sender, System.Web.UI.WebControls.WizardNavigationEventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ConsignmentId"]);
            if (id > 0)
            {
                No_Of_Passport = Convert.ToInt32(txtNoPassport.Text);
                PaxCountry();
            }
            else if (cg_id == 0)
            {
                CreateConsignment(2);
                if (Session["Consignment"] == null)
                {
                    e.Cancel = true;
                }
                PaxCountry();
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ConsignmentClear();
        }
        protected void BtnConsignmentUpdate_Click(object sender, EventArgs e)
        {
            UpdateConsignment();
        }
        protected void previous_button(object sender, System.Web.UI.WebControls.WizardNavigationEventArgs e)
        {
            clear();
            if (cg_id > 0)
            {
                txtConsignNo.Text = cg_id.ToString();
            }
        }

        #endregion

        #region fill Pax Dropdowns.....

        protected void ChckBxGrp_CheckedChanged(object sender, EventArgs e)
        {
            if (ChckBxGrp.Checked == true)
            {
                ddlGroup.Enabled = true;
            }
            else
            {
                ddlGroup.Enabled = false;
            }
        }
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadVisaType();
        }
        protected void ddlVisaType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadNo_OfVisit();
        }


        #endregion

        #region  pax and additional pax information

        protected void txtPassport_textChanged(object sender, EventArgs e)
        {
            string passportNo = txt_PassportNo.Text;
            string PassportName = consignBal.ReadDataFromPaxByPassPortNo(passportNo);
            if (PassportName != null)
            {
                clear();
                txt_paxname.Text = PassportName;
                txt_paxname.Enabled = false;
                txt_PassportNo.Text = passportNo;
            }
            else
            {
                txt_paxname.Enabled = true;
                txt_paxname.Text = string.Empty;
                clear();
                txt_PassportNo.Text = passportNo;
            }
        }
        protected void BtnAdditionalPax_Save_Click(object sender, EventArgs e)
        {
            Button btnPaxEntry_Save = (Button)Wizard1.FindControl("FinishNavigationTemplateContainerID").FindControl("btnPaxEntry_Save");
            btnPaxEntry_Save.Visible = true;
            int id = Convert.ToInt32(Request.QueryString["ConsignmentId"]);
            if (id > 0)
            {
                List<Pax> lst_Pax = consignBal.ReadDataByPaxsConsignmentId(id, LoggedInUser.Location_Id);
                var lst1 = lst_Pax.Where(a => a.CountryId == Convert.ToInt32(ddlCountry.SelectedValue) && a.PaxPassportNo == txt_PassportNo.Text);
                if (lst1.Count() < 1)
                {
                    var lst = lst_Pax.Select(a => new { a.PaxPassportNo }).Distinct();
                    No_Of_Pax = lst.Count();
                    if (No_Of_Pax < No_Of_Passport)
                    {
                        AdditonalInfo addPax = InsertPax();
                        if (paxAdditional != null)
                        {
                            Temp = Temp + 1;
                            addPax.TempIndex = Temp;
                            paxAdditional.Add(addPax);
                            consignmentEditpax.Add(addPax);
                        }
                        else
                        {
                            addPax.TempIndex = Temp;
                            ConsignmentDetails = new Consignment();
                            paxAdditional = new List<AdditonalInfo>();
                            paxAdditional.Add(addPax);
                            ConsignmentDetails.AdditionInfoDetails = paxAdditional;
                            consignmentEditpax.Add(addPax);
                        }
                        FillPaxGrid();
                    }
                    else
                    {
                        ShowMessageWithUpdatePanel("You Can not add More pax. Pax can not be greater then No. Of Passport");
                    }
                }
                else
                {
                    ShowMessageWithUpdatePanel("Country For This Passport No. is Already taken");
                }
            }
            else
            {
                var lst2 = new List<AdditonalInfo>();
                if (Session["Consignment_Pax"] != null)
                {
                    List<AdditonalInfo> lst1 = (List<AdditonalInfo>)Session["Consignment_Pax"];
                    lst2 = lst1.Where(a => a.CountryId == Convert.ToInt32(ddlCountry.SelectedValue) && a.pax.PaxPassportNo == txt_PassportNo.Text).ToList();
                    var lst = lst1.Select(a => new { a.pax.PaxPassportNo }).Distinct();
                    No_Of_Pax = lst.Count();
                }
                else if (paxAdditional != null)
                {
                    //List<AdditonalInfo> lst1 = (List<AdditonalInfo>)Session["Consignment_Pax"];
                    lst2 = paxAdditional.Where(a => a.CountryId == Convert.ToInt32(ddlCountry.SelectedValue) && a.pax.PaxPassportNo == txt_PassportNo.Text).ToList();
                    var lst = paxAdditional.Select(a => new { a.pax.PaxPassportNo }).Distinct();
                    No_Of_Pax = lst.Count();
                }
                if (lst2.Count < 1)
                {
                    if (No_Of_Pax < No_Of_Passport)
                    {
                        AdditonalInfo addPax = InsertPax();
                        if (cg_id <= 0)
                        {
                            if (paxAdditional != null)
                            {
                                paxAdditional.Add(addPax);
                                ConsignmentDetails.AdditionInfoDetails = paxAdditional;
                                consignmentEditpax.Add(addPax);
                            }
                            else
                            {
                                ConsignmentDetails = new Consignment();
                                consignmentEditpax = new List<AdditonalInfo>();
                                paxAdditional = new List<AdditonalInfo>();
                                paxAdditional.Add(addPax);
                                ConsignmentDetails.AdditionInfoDetails = paxAdditional;
                                consignmentEditpax.Add(addPax);
                            }
                        }
                        else
                        {
                            if (paxAdditional != null)
                            {
                                Temp = Temp + 1;
                                addPax.TempIndex = Temp;
                                paxAdditional.Add(addPax);
                                ConsignmentDetails.AdditionInfoDetails = paxAdditional;
                                consignmentEditpax.Add(addPax);
                            }
                            else
                            {
                                addPax.TempIndex = Temp;
                                ConsignmentDetails = new Consignment();
                                if (consignmentEditpax == null)
                                {
                                    consignmentEditpax = new List<AdditonalInfo>();
                                }
                                paxAdditional = new List<AdditonalInfo>();
                                paxAdditional.Add(addPax);
                                ConsignmentDetails.AdditionInfoDetails = paxAdditional;
                                consignmentEditpax.Add(addPax);
                            }
                        }
                        FillPaxGrid();
                        ddlCountry.ClearSelection();
                        ddlnoofvisit.Items.Clear();
                        ddlVisaType.Items.Clear();
                    }
                    else
                    {
                        ShowMessageWithUpdatePanel("You Can not add More pax. Pax can not be greater then No. Of Passport");
                    }

                }
                else
                {
                    ShowMessageWithUpdatePanel("Country For This Passport No. is Already taken");
                }
            }
            
            // clear();

        }
        protected void btnPaxEntry_Save_Click(object sender, EventArgs e)
        {
            if (paxAdditional != null)
            {
                int id = Convert.ToInt32(Request.QueryString["ConsignmentId"]);
                Session.Remove("consignmentEditpax");
                if (id > 0)
                {
                    UpdateConsignment();
                    ConsignmentDetails = new Consignment();
                    ConsignmentDetails.AdditionInfoDetails = paxAdditional;
                    consignBal.paxConsignment(ConsignmentDetails, id);
                    consignmentEditpax = consignBal.ReadDataByPaxConsignmentId(id, LoggedInUser.Location_Id);
                }
                else
                {
                    if (cg_id == 0)
                    {
                        Consignment consignment = (Consignment)Session["Consignment"];
                        consignment.AdditionInfoDetails = paxAdditional;
                        cg_id = consignBal.CreateConsignment(consignment);
                        consignmentEditpax = consignBal.ReadDataByPaxConsignmentId(cg_id, LoggedInUser.Location_Id);
                        Session.Remove("ConsignmentDetails");
                        Session.Remove("Consignment");
                        txtConsignemntNo.Text = cg_id.ToString();
                    }
                    else
                    {
                        Consignment consignment = new Consignment();
                        consignment.AdditionInfoDetails = paxAdditional;
                        consignBal.paxConsignment(consignment, cg_id);
                        consignmentEditpax = consignBal.ReadDataByPaxConsignmentId(cg_id, LoggedInUser.Location_Id);
                    }                    
                }
                Session["Consignment_Pax"] = paxAdditional;
                Session.Remove("paxAdditional");
                FillPaxGrid();
                clear();
                BtnAdditionalPax.Visible = true;
                btnPaxEntry_Update.Visible = false;
                ShowMessageWithUpdatePanel("Consignment Saved Successfully");
            }
            else
            {
                ShowMessageWithUpdatePanel("Please Add Pax Details");
            }

        }
        protected void btnPaxEntry_Update_Click(object sender, EventArgs e)
        {
            UpdateConsignment();
            int id = Convert.ToInt32(ViewState["paxId"]);
            int addInfoId = Convert.ToInt32(ViewState["AddinfoId"]);
            int consignmentId = Convert.ToInt32(ViewState["ConsignmentId"]);
            int index = Convert.ToInt32(ViewState["index"]);
            if (consignmentId > 0)
            {
                Pax pax = new Pax();
                pax.PaxName = txt_paxname.Text;
                pax.PaxVit = txtvttNo.Text;
                pax.PaxPassportNo = txt_PassportNo.Text;
                if (chktickets.Checked == true)
                {
                    pax.PaxTicket = "Y";
                }
                else
                    pax.PaxTicket = "N";

                if (chkMedIns.Checked == true)
                {
                    pax.PaxMedInsurance = "Y";
                }
                else
                    pax.PaxMedInsurance = "N";

                if (chkCreditCard.Checked == true)
                {
                    pax.PaxCreditCard = "Y";
                }
                else
                    pax.PaxCreditCard = "N";

                if (chkcertificate.Checked == true)
                {
                    pax.PaxCertificates = "Y";
                }
                else
                    pax.PaxCertificates = "N";

                if (chkItPaper.Checked == true)
                {
                    pax.PaxItPaper = "Y";
                }
                else
                    pax.PaxItPaper = "N";

                if (chkDraft.Checked == true)
                {
                    pax.PaxDraft = "Y";
                }
                else
                    pax.PaxDraft = "N";
                if (chckOther.Checked == true)
                {
                    pax.PaxOther = "Y";
                }
                else
                    pax.PaxOther = "N";
                pax.PaxTicketRemark = TxtTicketRemark.Text;
                pax.PaxMedInsuranceRemark = txtMedRemark.Text;
                pax.PaxCreditCardRemark = txtCreditRemarks.Text;
                pax.PaxCertificatesRemark = txtCertificateRemark.Text;
                pax.PaxDraftRemark = txtDraftRemark.Text;
                pax.PaxItPaperRemark = TxtITRemark.Text;
                pax.PaxRemarks = txtPaxRemarks.Text;

                consignBal.UpdatePax(pax, id);

                AdditonalInfo addInfo = new AdditonalInfo();
                if (Convert.ToInt32(ddlCountry.SelectedItem.Value) > 0)
                {
                    addInfo.CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
                }

                if (ddlVisaType.SelectedItem != null)
                {
                    addInfo.VisaTypeOneId = Convert.ToInt32(ddlVisaType.SelectedItem.Value);
                }
                if (ddlnoofvisit.SelectedItem != null)
                {
                    addInfo.VisaTypeTwoId = Convert.ToInt32(ddlnoofvisit.SelectedItem.Value);
                }
                if (rbtProcessTime.SelectedItem != null)
                {
                    addInfo.ProcessTimeId = Convert.ToInt32(rbtProcessTime.SelectedItem.Value);
                }
                if (ChckBxGrp.Checked == true)
                {
                    addInfo.GroupId = Convert.ToInt32(ddlGroup.SelectedItem.Value);
                    addInfo.GroupName = ddlGroup.SelectedItem.Text;
                }

                consignBal.UpdateAdditionalPax(addInfo, addInfoId);
                updateConsignmentList(index);

            }
            else
            {
                updateConsignmentList(index);
            }
            btnPaxEntry_Update.Visible = false;
            BtnAdditionalPax.Visible = true;
            clear();
            ShowMessage("Consignment Updated Successfully");
        }
        protected void gridFillPax_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            BtnAdditionalPax.Visible = false;
            btnPaxEntry_Update.Visible = true;
            string str = e.CommandArgument.ToString();
            string[] str1 = str.Split(',');
            int index = Convert.ToInt32(str1[0]);
            ViewState["index"] = index;
            if (e.CommandName == "cmdEdit")
            {
                List<AdditonalInfo> lstPax = consignmentEditpax;
                ViewState["ConsignmentId"] = lstPax[index].consignment.ConsignmentId;
                ViewState["AddinfoId"] = lstPax[index].AddinfoId;
                ViewState["paxId"] = lstPax[index].pax.PaxId;

                if (lstPax != null)
                {

                    txtvttNo.Text = Convert.ToString(lstPax[index].pax.PaxVit);
                    txt_paxname.Text = lstPax[index].pax.PaxName;
                    txt_PassportNo.Text = lstPax[index].pax.PaxPassportNo;
                    if (lstPax[index].pax.PaxTicket == "Y")
                    {
                        chktickets.Checked = true;
                    }
                    else
                        chktickets.Checked = false;
                    if (lstPax[index].pax.PaxMedInsurance == "Y")
                    {
                        chkMedIns.Checked = true;

                    }
                    else
                        chkMedIns.Checked = false;
                    if (lstPax[index].pax.PaxCreditCard == "Y")
                    {
                        chkCreditCard.Checked = true;
                    }
                    else
                        chkCreditCard.Checked = false;
                    if (lstPax[index].pax.PaxCertificates == "Y")
                    {
                        chkcertificate.Checked = true;
                    }
                    else
                        chkcertificate.Checked = false;
                    if (lstPax[index].pax.PaxItPaper == "Y")
                    {
                        chkItPaper.Checked = true;
                    }
                    else
                        chkItPaper.Checked = false;
                    if (lstPax[index].pax.PaxDraft == "Y")
                    {
                        chkDraft.Checked = true;
                    }
                    else
                        chkDraft.Checked = false;
                    if (lstPax[index].pax.PaxOther == "Y")
                    {
                        chckOther.Checked = true;
                    }
                    else
                    {
                        chckOther.Checked = false;
                    }
                    TxtTicketRemark.Text = lstPax[index].pax.PaxTicketRemark;
                    txtMedRemark.Text = lstPax[index].pax.PaxMedInsuranceRemark;
                    txtCreditRemarks.Text = lstPax[index].pax.PaxCreditCardRemark;
                    txtCertificateRemark.Text = lstPax[index].pax.PaxCertificatesRemark;
                    txtDraftRemark.Text = lstPax[index].pax.PaxDraftRemark;
                    TxtITRemark.Text = lstPax[index].pax.PaxItPaperRemark;
                    txtPaxRemarks.Text = lstPax[index].pax.PaxRemarks;
                    ddlCountry.SelectedValue = lstPax[index].CountryId.ToString();
                    ReadVisaType();
                    ddlVisaType.SelectedValue = lstPax[index].VisaTypeOneId.ToString();
                    ReadNo_OfVisit();
                    rbtProcessTime.SelectedValue = lstPax[index].VisaTypeTwoId.ToString();
                    if (lstPax[index].GroupId == 0)
                    {
                        ddlGroup.Enabled = false;
                    }
                    else
                    {
                        ChckBxGrp.Checked = true;
                        ddlGroup.Enabled = true;
                        ddlGroup.SelectedValue = lstPax[index].GroupId.ToString();
                    }
                }

            }
            else if (e.CommandName == "cmdDelete")
            {
                int consignmentId = Convert.ToInt32(str1[1]);
                int addInfo_id = Convert.ToInt32(str1[2]);
                int pax_id = Convert.ToInt32(str1[3]);

                if (addInfo_id > 0)
                {
                    ConsignmentBusinessAccess conBal = new ConsignmentBusinessAccess();
                    conBal.DeletePax(addInfo_id, pax_id);
                    List<Pax> lst_Pax = consignBal.ReadDataByPaxsConsignmentId(consignmentId, LoggedInUser.Location_Id);
                    No_Of_Pax = lst_Pax.Count;
                    if (consignmentEditpax != null)
                    {
                        consignmentEditpax.RemoveAt(index);
                    }
                }
                else
                {
                    int countAddPaxList = paxAdditional.Count;
                    if (consignmentEditpax.Count == countAddPaxList)
                    {
                        consignmentEditpax.RemoveAt(index);
                        paxAdditional.RemoveAt(index);
                    }
                    else
                    {
                        int i = consignmentEditpax[index].TempIndex;
                        consignmentEditpax.RemoveAt(index);
                        paxAdditional.RemoveAll(a => a.TempIndex == i);
                    }
                }
            }
            FillPaxGrid();
        }
        protected void gridFillPax_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void BtnCancelPax_Click(object sender, EventArgs e)
        {
            clear();
        }

        #endregion

        #region finish.....button to Redirect to Invoice Page data

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            int id1 = Convert.ToInt32(Request.QueryString["ConsignmentId"]);

            if (id1 > 0)
            {
               //Response.Redirect("EditDeleteConsignment.aspx");
                No_Of_Passport = Convert.ToInt32(txtNoPassport.Text);
                Session["quantity"] = No_Of_Passport;
                string AgentName = LblAgentName.Text;
                int AgentId = Convert.ToInt32(ViewState["agentId"]);
                Session["AgentName"] = AgentName;
                Session["AgentId"] = AgentId;
                consignmentEditpax = consignBal.ReadDataByPaxConsignmentId(id1, LoggedInUser.Location_Id);
                lstBill = generateBAL.ReadBillRePrintInvoiceByConsignmentId(id1, 0);
                if (lstBill.Count > 0)
                {
                    Session["version"] = lstBill[0].Version;
                }
                Response.Redirect("GenerateInvoiceForm.aspx?CG_Id=" + id1);
            }
            else
            {
                if (Session["Consignment_Pax"] == null)
                {
                    e.Cancel = true;
                    ScriptManager.RegisterClientScriptBlock(BtnMveCountryLft, GetType(), "test", "alert(' Please Add  Pax Details!!!')", true);
                }
                else
                {
                    if (cg_id > 0)
                    {
                        string AgentName = Request.QueryString["AgentName"].Replace('!', '&');
                        int AgentId = Convert.ToInt32(Request.QueryString["AgentID"]);
                        Session["AgentName"] = AgentName;
                        Session["AgentId"] = AgentId;
                        consignmentEditpax = consignBal.ReadDataByPaxConsignmentId(cg_id, LoggedInUser.Location_Id);
                        Response.Redirect("GenerateInvoiceForm.aspx?CG_Id=" + cg_id);
                    }

                }
            }
        }

        #endregion

        #endregion

        #region Private methods..

        private AdditonalInfo InsertPax()
        {
            AdditonalInfo addPax = new AdditonalInfo();
            addPax.pax = new Pax();
            addPax.consignment = new Consignment();
            addPax.consignment.ConsignmentId = 0;
            addPax.pax.PaxVit = txtvttNo.Text;
            addPax.pax.PaxName = txt_paxname.Text;
            addPax.pax.PaxPassportNo = txt_PassportNo.Text;
            addPax.pax.PaxTicketRemark = TxtTicketRemark.Text;
            addPax.pax.PaxMedInsuranceRemark = txtMedRemark.Text;
            addPax.pax.PaxCreditCardRemark = txtCreditRemarks.Text;
            addPax.pax.PaxCertificatesRemark = txtCertificateRemark.Text;
            addPax.pax.PaxDraftRemark = txtDraftRemark.Text;
            addPax.pax.PaxItPaperRemark = TxtITRemark.Text;

            if (chktickets.Checked == true)
            {
                addPax.pax.PaxTicket = "Y";
            }
            else
                addPax.pax.PaxTicket = "N";

            if (chkMedIns.Checked == true)
            {
                addPax.pax.PaxMedInsurance = "Y";
            }
            else
                addPax.pax.PaxMedInsurance = "N";
            if (chkCreditCard.Checked == true)
            {
                addPax.pax.PaxCreditCard = "Y";
            }
            else
                addPax.pax.PaxCreditCard = "N";
            if (chkcertificate.Checked == true)
            {
                addPax.pax.PaxCertificates = "Y";
            }
            else
                addPax.pax.PaxCertificates = "N";
            if (chkItPaper.Checked == true)
            {
                addPax.pax.PaxItPaper = "Y";
            }
            else
                addPax.pax.PaxItPaper = "N";
            if (chkDraft.Checked == true)
            {
                addPax.pax.PaxDraft = "Y";
            }
            else
                addPax.pax.PaxDraft = "N";
            if (chckOther.Checked == true)
            {
                addPax.pax.PaxOther = "Y";
            }
            else
                addPax.pax.PaxOther = "N";
            addPax.pax.PaxOtherRemark = Txt_Others.Text;
            addPax.pax.PaxRemarks = txtPaxRemarks.Text;
            addPax.pax.location = new Remielsoft.JetSave.DomianObjectModel.Location();
            addPax.pax.location.Location_Id = LoggedInUser.Location_Id;
            addPax.location = new Remielsoft.JetSave.DomianObjectModel.Location();
            addPax.location.Location_Id = LoggedInUser.UserLocation.LocationId;
            addPax.CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
            addPax.CountryName = ddlCountry.SelectedItem.Text;
            addPax.VisaTypeOneId = Convert.ToInt32(ddlVisaType.SelectedItem.Value);
            addPax.DescriptionOne = ddlVisaType.SelectedItem.Text;
            addPax.VisaTypeTwoId = Convert.ToInt32(ddlnoofvisit.SelectedItem.Value);
            addPax.DescriptionTwo = ddlnoofvisit.SelectedItem.Text;
            if (ChckBxGrp.Checked == true)
            {
                addPax.GroupId = Convert.ToInt32(ddlGroup.SelectedItem.Value);
                addPax.GroupName = ddlGroup.SelectedItem.Text;
            }
            else
            {
                addPax.GroupId = 0;
                addPax.GroupName = "";
            }
            addPax.ProcessTimeId = Convert.ToInt32(rbtProcessTime.SelectedValue);
            addPax.Description = rbtProcessTime.SelectedItem.Text;
            return addPax;
        }
        private void CreateConsignment(int i)
        {
            if ((string.IsNullOrEmpty(txtSubmDate.Text) && string.IsNullOrEmpty(txtTravlDate.Text) && string.IsNullOrEmpty(txtChkDate.Text) && string.IsNullOrEmpty(txtColDate.Text)) && (string.IsNullOrEmpty(txtRemark.Text)))
            {
                ShowMessageWithUpdatePanel("Remark is Mandatory");
            }
            else
            {
                ConsignmentBusinessAccess consignBal = new ConsignmentBusinessAccess();
                Consignment consignment = new Consignment();
                string othrCountry = null;
                consignment.ConsignmentAgent = new Agent();
                consignment.location = new Remielsoft.JetSave.DomianObjectModel.Location();
                consignment.location.Location_Id = LoggedInUser.UserLocation.LocationId;
                consignment.ConsignmentAgent.AgentId = Convert.ToInt32(Request.QueryString["AgentID"]);
                consignment.CgVisaCountry = Convert.ToInt32(DrpdnVisaCountry.SelectedItem.Value);
                foreach (ListItem item in LstSelectedCountry.Items)
                {
                    othrCountry += item.Text + ",";
                }
                consignment.CgOtherCountries = othrCountry;
                if (!string.IsNullOrEmpty(txtSubmDate.Text))
                {
                    consignment.CgSubmissionDate = Convert.ToDateTime(txtSubmDate.Text);
                }

                if (!string.IsNullOrEmpty(txtTravlDate.Text))
                {
                    consignment.CgTravelDates = txtTravlDate.Text;
                }
                if (!string.IsNullOrEmpty(txtChkDate.Text))
                {
                    consignment.CgCheckOnDate = Convert.ToDateTime(txtChkDate.Text);
                }

                if (!string.IsNullOrEmpty(txtColDate.Text))
                {
                    consignment.CgDeliveryDate = Convert.ToDateTime(txtColDate.Text);
                }
                consignment.CgGroupRep = txtGroup.Text;
                consignment.CgInstruction = TxtInstruction.Text;
                consignment.CgRemarks = txtRemark.Text;
                consignment.CgAreaCode = txtAreaCod.Text;
                consignment.CgNoOfPass = Convert.ToInt32(txtNoPassport.Text);
                Session["quantity"] = Convert.ToInt32(txtNoPassport.Text);
                if (!string.IsNullOrEmpty(txtNoDD.Text))
                {
                    consignment.CgNoOfDD = Convert.ToInt32(txtNoDD.Text);
                }
                else
                {
                    consignment.CgNoOfDD = 0;
                }
                consignment.CgEnteredBy = txtEnterdBy.Text;
                consignment.CgSentBy = txtSntName.Text;
                consignment.CgCorporate = txtCorporate.Text;
                consignment.CgMobNo = txtmob.Text;
                consignment.CgEmail = txtEmail.Text;
                consignment.UpdatedOn = DateTime.Now;
                consignment.CgDate = DateTime.Now;
                consignment.CgEntryDate = DateTime.Now;
                No_Of_Passport = Convert.ToInt32(txtNoPassport.Text);
                if (i == 1)
                {
                    cg_id = consignBal.CreateConsignment(consignment);
                    txtConsignemntNo.Text = cg_id.ToString();
                    Button btnConsignmentSave = (Button)Wizard1.FindControl("StartNavigationTemplateContainerID").FindControl("btnConsignmentSave");
                    btnConsignmentSave.Visible = false;
                    Button BtnConsignmentUpdate = (Button)Wizard1.FindControl("StartNavigationTemplateContainerID").FindControl("BtnConsignmentUpdate");
                    BtnConsignmentUpdate.Visible = true;
                    txtConsignNo.Text = cg_id.ToString();
                    ShowMessageWithUpdatePanel("Consignment Saved Successfully");
                }

                Session["Consignment"] = consignment;
                PaxCountry();
            }
        }
        private void UpdateConsignment()
        {

            int id = Convert.ToInt32(Request.QueryString["ConsignmentId"]);

            ConsignmentBusinessAccess consignBal = new ConsignmentBusinessAccess();
            Consignment consignment = new Consignment();
            consignment.CgVisaCountry = Convert.ToInt32(DrpdnVisaCountry.SelectedItem.Value);
            string othrCountry = null;
            consignment.CgVisaCountry = Convert.ToInt32(DrpdnVisaCountry.SelectedItem.Value);
            foreach (ListItem item in LstSelectedCountry.Items)
            {
                othrCountry += item.Text + ",";
            }
            consignment.CgOtherCountries = othrCountry;
            if (!string.IsNullOrEmpty(txtSubmDate.Text))
            {
                consignment.CgSubmissionDate = Convert.ToDateTime(txtSubmDate.Text);
            }

            if (!string.IsNullOrEmpty(txtTravlDate.Text))
            {
                consignment.CgTravelDates = txtTravlDate.Text;
            }
            if (!string.IsNullOrEmpty(txtChkDate.Text))
            {
                consignment.CgCheckOnDate = Convert.ToDateTime(txtChkDate.Text);
            }

            if (!string.IsNullOrEmpty(txtColDate.Text))
            {
                consignment.CgDeliveryDate = Convert.ToDateTime(txtColDate.Text);
            }
            consignment.CgGroupRep = txtGroup.Text;
            consignment.CgInstruction = TxtInstruction.Text;
            consignment.CgRemarks = txtRemark.Text;
            consignment.CgAreaCode = txtAreaCod.Text;
            consignment.CgNoOfPass = Convert.ToInt32(txtNoPassport.Text);
            if (!string.IsNullOrEmpty(txtNoDD.Text))
            {
                consignment.CgNoOfDD = Convert.ToInt32(txtNoDD.Text);
            }
            else
            {
                consignment.CgNoOfDD = 0;
            }
            consignment.CgEnteredBy = txtEnterdBy.Text;
            consignment.CgSentBy = txtSntName.Text;
            consignment.CgCorporate = txtCorporate.Text;
            consignment.CgMobNo = txtmob.Text;
            consignment.CgEmail = txtEmail.Text;
            consignment.UpdatedOn = DateTime.Now;
            No_Of_Passport = Convert.ToInt32(txtNoPassport.Text);
            if (id > 0)
            {
                consignBal.UpdateConsignment(consignment, id);
                int locationId = LoggedInUser.Location_Id;
                List<Pax> lst_Pax = consignBal.ReadDataByPaxsConsignmentId(id, locationId);
                No_Of_Pax = lst_Pax.Count;
            }
            else
            {
                consignBal.UpdateConsignment(consignment, cg_id);
            }
            //ShowMessageWithUpdatePanel("Consignment updated   successfully.");
        }
        private void updateConsignmentList(int index)
        {
            List<AdditonalInfo> lstPax = consignmentEditpax;

            lstPax[index].pax.PaxName = txt_paxname.Text;
            lstPax[index].pax.PaxPassportNo = txt_PassportNo.Text;
            lstPax[index].pax.PaxVit = txtvttNo.Text;
            if (chktickets.Checked == true)
            {
                lstPax[index].pax.PaxTicket = "Y";
            }
            else
                lstPax[index].pax.PaxTicket = "N";
            if (chkMedIns.Checked == true)
            {
                lstPax[index].pax.PaxMedInsurance = "Y";

            }
            else
                lstPax[index].pax.PaxMedInsurance = "N";
            if (chkCreditCard.Checked == true)
            {
                lstPax[index].pax.PaxCreditCard = "Y";
            }
            else
                lstPax[index].pax.PaxCreditCard = "N";
            if (chkcertificate.Checked == true)
            {
                lstPax[index].pax.PaxCertificates = "Y";
            }
            else
                lstPax[index].pax.PaxCertificates = "N";
            if (chkItPaper.Checked == true)
            {
                lstPax[index].pax.PaxItPaper = "Y";
            }
            else
                lstPax[index].pax.PaxItPaper = "N";
            if (chkDraft.Checked == true)
            {
                lstPax[index].pax.PaxDraft = "Y";
            }
            else
                lstPax[index].pax.PaxDraft = "N";
            if (chckOther.Checked == true)
            {
                lstPax[index].pax.PaxOther = "Y";
            }
            else
                lstPax[index].pax.PaxOther = "N";
            lstPax[index].pax.PaxTicketRemark = TxtTicketRemark.Text;
            lstPax[index].pax.PaxMedInsuranceRemark = txtMedRemark.Text;
            lstPax[index].pax.PaxCreditCardRemark = txtCreditRemarks.Text;
            lstPax[index].pax.PaxCertificatesRemark = txtCertificateRemark.Text;
            lstPax[index].pax.PaxDraftRemark = txtDraftRemark.Text;
            lstPax[index].pax.PaxItPaperRemark = TxtITRemark.Text;
            lstPax[index].pax.PaxRemarks = txtPaxRemarks.Text;
            lstPax[index].CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
            lstPax[index].VisaTypeOneId = Convert.ToInt32(ddlVisaType.SelectedValue);
            lstPax[index].CountryName = ddlCountry.SelectedItem.Text;
            lstPax[index].VisaTypeOneId = Convert.ToInt32(ddlVisaType.SelectedItem.Value);
            lstPax[index].DescriptionOne = ddlVisaType.SelectedItem.Text;
            lstPax[index].VisaTypeTwoId = Convert.ToInt32(ddlnoofvisit.SelectedItem.Value);
            lstPax[index].DescriptionTwo = ddlnoofvisit.SelectedItem.Text;
            if (ChckBxGrp.Checked == true)
            {
                lstPax[index].GroupId = Convert.ToInt32(ddlGroup.SelectedItem.Value);
                lstPax[index].GroupName = ddlGroup.SelectedItem.Text;
            }
            else
            {
                lstPax[index].GroupId = 0;
                lstPax[index].GroupName = "";
            }
            lstPax[index].ProcessTimeId = Convert.ToInt32(rbtProcessTime.SelectedValue);
            lstPax[index].Description = rbtProcessTime.SelectedItem.Text;
            consignmentEditpax = lstPax;
            FillPaxGrid();
            if (lstPax[index].AddinfoId > 0)
            {
                clear();
            }

        }
        private void PaxCountry()
        {
            Consignment con = new Consignment();
            CountryConsignment = new List<Consignment>();
            con.Country_Id = Convert.ToInt32(DrpdnVisaCountry.SelectedItem.Value);
            con.CountryName = DrpdnVisaCountry.SelectedItem.Text;
            CountryConsignment.Add(con);
            for (int i = 0; i < LstSelectedCountry.Items.Count; i++)
            {
                Consignment consign = new Consignment();
                consign.Country_Id = Convert.ToInt32(LstSelectedCountry.Items[i].Value);
                consign.CountryName = LstSelectedCountry.Items[i].Text;
                CountryConsignment.Add(consign);
            }
            BindPaxCountry();
        }
        private void BindPaxCountry()
        {
            var lstCountry = CountryConsignment.Select(a => new { a.CountryName, a.Country_Id }).Distinct();
            ddlCountry.DataSource = lstCountry;
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataValueField = "Country_Id";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        private void ReadVisaType()
        {
            ddlVisaType.Enabled = true;
            int countryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
            List<AdditonalInfo> lstaddPax = consignBal.ReadVisaType(countryId);
            if (lstaddPax.Count > 0)
            {
                ddlVisaType.DataSource = lstaddPax;
                ddlVisaType.DataTextField = "DescriptionOne";
                ddlVisaType.DataValueField = "VisaTypeOneId";
                ddlVisaType.DataBind();
                ddlVisaType.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlVisaType.SelectedValue = "0";
            }
            else
            {
                ShowMessageWithUpdatePanel("No Record Found");
            }
        }
        private void ReadNo_OfVisit()
        {
            ddlnoofvisit.Enabled = true;
            int MyEmbassyId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
            int MyVisaTypeId = Convert.ToInt32(ddlVisaType.SelectedItem.Value);
            ddlnoofvisit.DataSource = consignBal.ReadNo_Of_Visit(MyEmbassyId, MyVisaTypeId);
            ddlnoofvisit.DataTextField = "DescriptionTwo";
            ddlnoofvisit.DataValueField = "VisaTypeTwoId";
            ddlnoofvisit.DataBind();
        }
        private void EditConsignment()
        {
            int locationId = LoggedInUser.UserLocation.LocationId;
            int userId = LoggedInUser.UserTypeId;
            int id = Convert.ToInt32(Request.QueryString["ConsignmentId"]);
            txtConsignNo.Text = id.ToString();
            txtConsignemntNo.Text = id.ToString();
            ConsignmentBusinessAccess consignBal = new ConsignmentBusinessAccess();
            Button btnCancel = (Button)Wizard1.FindControl("StartNavigationTemplateContainerID").FindControl("btnCancel");
            btnCancel.Visible = false;
            Button StepPreviousButton = (Button)Wizard1.FindControl("FinishNavigationTemplateContainerID").FindControl("StepPreviousButton");
            StepPreviousButton.Visible = true;
            Button StepFinishButton = (Button)Wizard1.FindControl("FinishNavigationTemplateContainerID").FindControl("btnFinish");
            StepFinishButton.Visible = true;
            Button btnPaxEntry_Save = (Button)Wizard1.FindControl("FinishNavigationTemplateContainerID").FindControl("btnPaxEntry_Save");
            btnPaxEntry_Save.Visible = false;
            Button btnConsignmentSave = (Button)Wizard1.FindControl("StartNavigationTemplateContainerID").FindControl("btnConsignmentSave");
            btnConsignmentSave.Visible = false;
            Button BtnConsignmentUpdate = (Button)Wizard1.FindControl("StartNavigationTemplateContainerID").FindControl("BtnConsignmentUpdate");
            BtnConsignmentUpdate.Visible = true;
            List<Consignment> lstconsignment = new List<Consignment>();
            if (userId == Convert.ToInt32(UserType.Admin) || userId == Convert.ToInt32(UserType.SuperAdmin))
            {
                locationId = 0;
                lstconsignment = consignBal.ReadDataByConsignmentId(id, locationId);
            }
            else
            {
                lstconsignment = consignBal.ReadDataByConsignmentId(id, locationId);
            }
            LblAgentName.Text = lstconsignment[0].ConsignmentAgent.AgentName.ToString();
            int agentId = lstconsignment[0].FkAgentId;
            ViewState["agentId"] = agentId;
            LblpaxAgent.Text = lstconsignment[0].ConsignmentAgent.AgentName.ToString();
            DrpdnVisaCountry.SelectedValue = lstconsignment[0].CgVisaCountry.ToString();
           
            string col1Value = lstconsignment[0].CgOtherCountries;
            string[] result = null;
            if (col1Value != null)
            {
                string str = col1Value.TrimEnd(',');
                result = str.Split(',');
            }
            List<Consignment> lstcon = new List<Consignment>();

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < LstCountry.Items.Count; j++)
                {
                    Consignment con = new Consignment();
                    if (result[i] == LstCountry.Items[j].Text)
                    {
                        con.Country_Id = Convert.ToInt32(LstCountry.Items[j].Value);
                        con.CountryName = LstCountry.Items[j].Text;
                        lstcon.Add(con);
                        break;
                    }
                }
            }
            LstSelectedCountry.DataSource = lstcon;
            LstSelectedCountry.DataTextField = "CountryName";
            LstSelectedCountry.DataValueField = "Country_Id";
            LstSelectedCountry.DataBind();
            txtSubmDate.Text = String.Format("{0:MM/dd/yyyy}", lstconsignment[0].CgSubmissionDate);
            txtChkDate.Text = String.Format("{0:MM/dd/yyyy}", lstconsignment[0].CgCheckOnDate);
            txtTravlDate.Text = String.Format("{0:MM/dd/yyyy}", lstconsignment[0].CgTravelDates);
            txtColDate.Text = String.Format("{0:MM/dd/yyyy}", lstconsignment[0].CgTravelDates);
            txtGroup.Text = lstconsignment[0].CgGroupRep.ToString();
            TxtInstruction.Text = lstconsignment[0].CgInstruction.ToString();
            txtRemark.Text = lstconsignment[0].CgRemarks.ToString();
            txtAreaCod.Text = lstconsignment[0].CgAreaCode;
            txtNoPassport.Text = lstconsignment[0].CgNoOfPass.ToString();
            txtNoDD.Text = lstconsignment[0].CgNoOfDD.ToString();
            txtEnterdBy.Text = lstconsignment[0].CgEnteredBy;
            txtSntName.Text = lstconsignment[0].CgSentBy;
            txtCorporate.Text = lstconsignment[0].CgCorporate;
            txtmob.Text = lstconsignment[0].CgMobNo;
            txtEmail.Text = lstconsignment[0].CgAspMail;
            No_Of_Passport = Convert.ToInt32(txtNoPassport.Text);
            
            List<Pax> lst_Pax = consignBal.ReadDataByPaxsConsignmentId(id, locationId);
            No_Of_Pax = lst_Pax.Count;
            consignmentEditpax = consignBal.ReadDataByPaxConsignmentId(id, locationId);
            ddlVisaType.Enabled = true;
            ddlnoofvisit.Enabled = true;
            gridFillPax.DataSource = consignmentEditpax;
            gridFillPax.DataBind();

        }
        private void ViewConsignment()
        {
            DrpdnVisaCountry.Enabled = false;
            TxtInstruction.Enabled = false;
            txtRemark.Enabled = false;
            ConsignReadOnly();
            BtnMveCountryLft.Enabled = false;
            BtnMveCountryRht.Enabled = false;
            ConsignmentBusinessAccess consignBal = new ConsignmentBusinessAccess();
            Button btnCancel = (Button)Wizard1.FindControl("StartNavigationTemplateContainerID").FindControl("btnCancel");
            btnCancel.Visible = false;
            Button StepPreviousButton = (Button)Wizard1.FindControl("FinishNavigationTemplateContainerID").FindControl("StepPreviousButton");
            StepPreviousButton.Visible = true;
            Button StepFinishButton = (Button)Wizard1.FindControl("FinishNavigationTemplateContainerID").FindControl("btnFinish");
            StepFinishButton.Visible = false;
            Button btnPaxEntry_Save = (Button)Wizard1.FindControl("FinishNavigationTemplateContainerID").FindControl("btnPaxEntry_Save");
            btnPaxEntry_Save.Visible = false;
            Button btnConsignmentSave = (Button)Wizard1.FindControl("StartNavigationTemplateContainerID").FindControl("btnConsignmentSave");
            btnConsignmentSave.Visible = false;
            Button BtnConsignmentUpdate = (Button)Wizard1.FindControl("StartNavigationTemplateContainerID").FindControl("BtnConsignmentUpdate");
            BtnConsignmentUpdate.Visible = false;
            Button StepFinishButton1 = (Button)Wizard1.FindControl("FinishNavigationTemplateContainerID").FindControl("BtnCancelPax");
            StepFinishButton1.Visible = false;

            int id = Convert.ToInt32(Request.QueryString["ConsignmentId"]);
            txtConsignNo.Text = id.ToString();
            txtConsignemntNo.Text = id.ToString();
            List<Consignment> lstconsignment = new List<Consignment>();
            int locationId = LoggedInUser.UserLocation.LocationId;
            int userId = LoggedInUser.UserTypeId;
            if (userId == Convert.ToInt32(UserType.Admin) || userId == Convert.ToInt32(UserType.SuperAdmin))
            {
                locationId = 0;
                lstconsignment = consignBal.ReadDataByConsignmentId(id, locationId);
            }

            else
            {
                lstconsignment = consignBal.ReadDataByConsignmentId(id, locationId);
            }
            LblAgentName.Text = lstconsignment[0].ConsignmentAgent.AgentName.ToString();
            DrpdnVisaCountry.SelectedValue = lstconsignment[0].CgVisaCountry.ToString();
            string col1Value = lstconsignment[0].CgOtherCountries;
            string[] result = null;
            if (col1Value != null)
            {
                string str = col1Value.TrimEnd(',');

                result = str.Split(',');
            }
            List<Consignment> lstcon = new List<Consignment>();
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < LstCountry.Items.Count; j++)
                {
                    Consignment con = new Consignment();
                    if (result[i] == LstCountry.Items[j].Text)
                    {
                        con.Country_Id = Convert.ToInt32(LstCountry.Items[j].Value);
                        con.CountryName = LstCountry.Items[j].Text;
                        lstcon.Add(con);
                        break;
                    }
                }
            }
            LstSelectedCountry.DataSource = lstcon;
            LstSelectedCountry.DataTextField = "CountryName";
            LstSelectedCountry.DataValueField = "Country_Id";
            LstSelectedCountry.DataBind();
            txtSubmDate.Text = String.Format("{0:MM/dd/yyyy}", lstconsignment[0].CgSubmissionDate);
            txtChkDate.Text = String.Format("{0:MM/dd/yyyy}", lstconsignment[0].CgCheckOnDate);
            txtTravlDate.Text = String.Format("{0:MM/dd/yyyy}", lstconsignment[0].CgTravelDates);
            txtColDate.Text = String.Format("{0:MM/dd/yyyy}", lstconsignment[0].CgTravelDates);
            txtGroup.Text = lstconsignment[0].CgGroupRep.ToString();
            TxtInstruction.Text = lstconsignment[0].CgInstruction.ToString();
            txtRemark.Text = lstconsignment[0].CgRemarks.ToString();
            txtAreaCod.Text = lstconsignment[0].CgAreaCode;
            txtNoPassport.Text = lstconsignment[0].CgNoOfPass.ToString();
            txtNoDD.Text = lstconsignment[0].CgNoOfDD.ToString();
            txtEnterdBy.Text = lstconsignment[0].CgEnteredBy;
            txtSntName.Text = lstconsignment[0].CgSentBy;
            txtCorporate.Text = lstconsignment[0].CgCorporate;
            txtmob.Text = lstconsignment[0].CgMobNo;
            txtEmail.Text = lstconsignment[0].CgAspMail;
            paxTable.Visible = false;
            Panel1.Visible = false;
            List<AdditonalInfo> lstpax = consignBal.ReadDataByPaxConsignmentId(id, locationId);
            gridFillPax.DataSource = lstpax;
            gridFillPax.DataBind();

            foreach (DataControlField col in gridFillPax.Columns)
            {
                if (col.HeaderText == "Action")
                {
                    col.Visible = false;
                }
            }


        }
        private void BindCountryList()
        {
            LstCountry.DataSource = visaReqBal.ReadCountry();
            LstCountry.DataTextField = "CountryName";
            LstCountry.DataValueField = "COUNTRY_ID";
            LstCountry.DataBind();

        }
        private void ConsignmentClear()
        {
            txtSubmDate.Text = "";
            txtTravlDate.Text = "";
            txtChkDate.Text = "";
            txtColDate.Text = "";
            txtGroup.Text = "";
            TxtInstruction.Text = "";
            txtRemark.Text = "";
            txtAreaCod.Text = "";
            txtNoDD.Text = "";
            txtNoPassport.Text = "";
            txtEnterdBy.Text = "";
            txtSntName.Text = "";
            txtCorporate.Text = "";
            txtmob.Text = "";
            txtEmail.Text = "";
            LstSelectedCountry.Items.Clear();
            DrpdnVisaCountry.ClearSelection();

        }
        private void ConsignReadOnly()
        {
            txtSubmDate.ReadOnly = true;
            txtTravlDate.ReadOnly = true;
            txtChkDate.ReadOnly = true;
            txtColDate.ReadOnly = true;
            txtGroup.ReadOnly = true;
            TxtInstruction.ReadOnly = true;
            txtRemark.ReadOnly = true;
            txtAreaCod.ReadOnly = true;
            txtNoDD.ReadOnly = true;
            txtNoPassport.ReadOnly = true;
            txtEnterdBy.ReadOnly = true;
            txtSntName.ReadOnly = true;
            txtCorporate.ReadOnly = true;
            txtmob.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtPaxRemarks.ReadOnly = true;
            txt_paxname.ReadOnly = true;
            txt_PassportNo.ReadOnly = true;
            txtvttNo.ReadOnly = true;
            ddlCountry.ClearSelection();
            chkcertificate.Enabled = false;
            chkCreditCard.Enabled = false;
            chkDraft.Enabled = false;
            chkItPaper.Enabled = false;
            chkMedIns.Enabled = false;
            chktickets.Enabled = false;
            Txt_Others.ReadOnly = true;

        }
        private void FillPaxGrid()
        {

            if (consignmentEditpax != null)
            {
                gridFillPax.DataSource = consignmentEditpax;
                gridFillPax.DataBind();
            }
            else
            {
                int locationId = LoggedInUser.UserLocation.LocationId;
                int userId = LoggedInUser.UserTypeId;
                int id = Convert.ToInt32(Request.QueryString["ConsignmentId"]);
                List<AdditonalInfo> lstpax = null;
                if (userId == Convert.ToInt32(UserType.Admin) || userId == Convert.ToInt32(UserType.SuperAdmin))
                {
                    locationId = 0;
                    lstpax = consignBal.ReadDataByPaxConsignmentId(id, locationId);
                }
                else
                {
                    lstpax = consignBal.ReadDataByPaxConsignmentId(id, locationId);
                }
                gridFillPax.DataSource = lstpax;
                gridFillPax.DataBind();
            }
        }
        private void clear()
        {
            txt_paxname.Text = string.Empty;
            txt_PassportNo.Text = string.Empty;
            txtvttNo.Text = string.Empty;
            ddlCountry.ClearSelection();
            ddlnoofvisit.Items.Clear();
            ddlVisaType.Items.Clear();
            chkcertificate.Checked = false;
            chkCreditCard.Checked = false;
            chkDraft.Checked = false;
            chkItPaper.Checked = false;
            chkMedIns.Checked = false;
            chktickets.Checked = false;
            Txt_Others.Text = string.Empty;
            txtPaxRemarks.Text = string.Empty;
            txtDraftRemark.Text = string.Empty;
            txtCreditRemarks.Text = string.Empty;
            TxtITRemark.Text = string.Empty;
            txtMedRemark.Text = string.Empty;
            TxtTicketRemark.Text = string.Empty;
            txtCertificateRemark.Text = string.Empty;
            ChckBxGrp.Checked = false;
            ddlGroup.Enabled = false;
            chckOther.Checked = false;

        }

        #endregion

        #region Public Properties..

        public List<Consignment> CountryConsignment
        {
            get
            {
                return (List<Consignment>)Session["CountryConsignment"];
            }
            set
            {
                Session["CountryConsignment"] = value;
            }
        }
        public Consignment ConsignmentDetails
        {
            get
            {
                return (Consignment)Session["ConsignmentDetails"];
            }
            set
            {
                Session["ConsignmentDetails"] = value;
            }
        }
        public List<AdditonalInfo> paxAdditional
        {
            get
            {
                return (List<AdditonalInfo>)Session["paxAdditional"];
            }
            set
            {
                Session["paxAdditional"] = value;
            }
        }
        public List<AdditonalInfo> consignmentEditpax
        {
            get
            {
                return (List<AdditonalInfo>)Session["consignmentEditpax"];
            }
            set
            {
                Session["consignmentEditpax"] = value;
            }
        }
        public Int32 cg_id
        {
            get
            {
                try
                {
                    return (Int32)ViewState["cg_id"];
                }
                catch
                {

                    return 0;
                }
            }
            set { ViewState["cg_id"] = value; }
        }
        public Int32 Temp
        {
            get
            {
                try
                {
                    return (Int32)ViewState["Temp"];
                }
                catch
                {

                    return 0;
                }
            }
            set { ViewState["Temp"] = value; }
        }
        public Int32 No_Of_Passport
        {
            get
            {
                try
                {
                    return (Int32)ViewState["No_Of_Passport"];
                }
                catch
                {

                    return 0;
                }
            }
            set { ViewState["No_Of_Passport"] = value; }
        }
        public Int32 No_Of_Pax
        {
            get
            {
                try
                {
                    return (Int32)ViewState["No_Of_Pax"];
                }
                catch
                {

                    return 0;
                }
            }
            set { ViewState["No_Of_Pax"] = value; }
        }

        #endregion
    }
}