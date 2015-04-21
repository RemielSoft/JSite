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
    public partial class Test1 : System.Web.UI.Page
    {
        VisaRequirementBusinessAccess visaReqBal = new VisaRequirementBusinessAccess();
        VisaRequirement visaRequirement = new VisaRequirement();
        BasePage basePage = new BasePage();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                basePage.BindDropDown(ddlCountry, "CountryName", "Country_Id", visaReqBal.ReadCountry());
                basePage.BindDropDown(ddlconsulate, "consulate_name", "consulate_id", visaReqBal.ReadConsulate());
                basePage.BindDropDown(ddlVisaType, "DESCRIPTION_ONE", "TYPE_ONE_ID", visaReqBal.ReadVisaType());
                ddlconsulate.SelectedIndex = 1;
                ddlVisaType.SelectedIndex = 2;
                if (Request.QueryString["REQ_ID"] != null && Request.QueryString["Viewid"] == "")
                {
                    
                    
                    Btnupdate.Visible = true;
                    btnSave.Visible = false;

                    int id = Convert.ToInt32(Request.QueryString["REQ_ID"]);
                    List<VisaRequirement> lstVisaRequirement = visaReqBal.ReadVisaRequirementByReqId(id);

                    ddlCountry.SelectedItem.Text = lstVisaRequirement[0].CountryName.ToString();
                    ddlVisaType.SelectedItem.Text = lstVisaRequirement[0].VisaType.ToString();
                    ddlconsulate.SelectedItem.Text = lstVisaRequirement[0].FkConsulate.ToString();
                    txtAddress.Text = lstVisaRequirement[0].ConAddress.ToString();
                    txtFee.Text = lstVisaRequirement[0].Fee.ToString();
                    txtprotime.Text = lstVisaRequirement[0].ProcessTime;
                    
                    txtSubday.Text = lstVisaRequirement[0].SubmissionDays;
                    txtsubtime.Text = lstVisaRequirement[0].SubmissionTime;
                    txtcolday.Text = lstVisaRequirement[0].CollectionDays;
                    txtcoltime.Text = lstVisaRequirement[0].CollectionTime;
                    txtvisawrk.Text = lstVisaRequirement[0].VisaSectionWorkingDays;
                    txtoff.Text = lstVisaRequirement[0].VisaOff;
                    txtnormlfee.Text = lstVisaRequirement[0].NormalFee;
                    txturgntfee.Text = lstVisaRequirement[0].UrgentFee;
                    txtvfs.Text = lstVisaRequirement[0].Vfs;
                    txttiming.Text = lstVisaRequirement[0].Timings;
                    txtstufee.Text = lstVisaRequirement[0].StudentFees;
                    txtcmmnts.Text = lstVisaRequirement[0].Comments;
                    txtBasic.Text = lstVisaRequirement[0].BasicRequirements;
                    TxtNote.Text = lstVisaRequirement[0].Notes;
                    TxtMed.Text = lstVisaRequirement[0].MedicalRequirement;
                    Txtother.Text = lstVisaRequirement[0].OtherInfo.ToString();
                    txtIntrvw.Text = lstVisaRequirement[0].CopyOfInterviewDate;
                    txtGenReq.Text = lstVisaRequirement[0].GenReq;
                    txtNormlcl.Text = lstVisaRequirement[0].NormalCollection;
                    txtmyapp.Text = lstVisaRequirement[0].MyApplication;
                    
                  showTable.Visible = true;
                 
                }
                else if (Request.QueryString["REQ_ID"] != null && Request.QueryString["Viewid"] == "2")
                {


                    Btnupdate.Visible = false;
                    btnSave.Visible = false;

                    int id = Convert.ToInt32(Request.QueryString["REQ_ID"]);
                    List<VisaRequirement> lstVisaRequirement = visaReqBal.ReadVisaRequirementByReqId(id);

                    ddlCountry.SelectedItem.Text = lstVisaRequirement[0].CountryName.ToString();
                    ddlVisaType.SelectedItem.Text = lstVisaRequirement[0].VisaType.ToString();
                    ddlconsulate.SelectedItem.Text = lstVisaRequirement[0].FkConsulate.ToString();
                    txtAddress.Text = lstVisaRequirement[0].ConAddress.ToString();
                    txtFee.Text = lstVisaRequirement[0].Fee.ToString();
                    txtprotime.Text = lstVisaRequirement[0].ProcessTime;
                    txtSubday.Text = lstVisaRequirement[0].SubmissionDays;
                    txtsubtime.Text = lstVisaRequirement[0].SubmissionTime;
                    txtcolday.Text = lstVisaRequirement[0].CollectionDays;
                    txtcoltime.Text = lstVisaRequirement[0].CollectionTime;
                    txtvisawrk.Text = lstVisaRequirement[0].VisaSectionWorkingDays;
                    txtoff.Text = lstVisaRequirement[0].VisaOff;
                    txtnormlfee.Text = lstVisaRequirement[0].NormalFee;
                    txturgntfee.Text = lstVisaRequirement[0].UrgentFee;
                    txtvfs.Text = lstVisaRequirement[0].Vfs;
                    txttiming.Text = lstVisaRequirement[0].Timings;
                    //txtstufee.Text = lst[0].StudentFees.ToString();
                    txtcmmnts.Text = lstVisaRequirement[0].Comments;
                    txtBasic.Text = lstVisaRequirement[0].BasicRequirements;
                    TxtNote.Text = lstVisaRequirement[0].Notes;
                    TxtMed.Text = lstVisaRequirement[0].MedicalRequirement;
                    Txtother.Text = lstVisaRequirement[0].OtherInfo.ToString();
                    txtIntrvw.Text = lstVisaRequirement[0].CopyOfInterviewDate;
                    txtGenReq.Text = lstVisaRequirement[0].GenReq;
                    txtNormlcl.Text = lstVisaRequirement[0].NormalCollection;
                    txtmyapp.Text = lstVisaRequirement[0].MyApplication;
                    TextBoxPropertyReadOnly();
                  showTable.Visible = true;
                }
                else
                {
                    showTable.Visible = false;
                }

                lblNormalFee.Visible = false;
                txtnormlfee.Visible = false;
                txturgntfee.Visible = false;
                txtvfs.Visible = false;
                txttiming.Visible = false;
                lbltiming.Visible = false;
                lblurgentfee.Visible = false;
                lblvfs.Visible = false;
                txtstufee.Visible = false;
                lblstudentfee.Visible = false;
                lblcoid.Visible = false;
                lblgr.Visible = false;
                lblnc.Visible = false;
                lblmyapp.Visible = false;
                txtIntrvw.Visible = false;
                txtGenReq.Visible = false;
                 txtNormlcl.Visible=false;
                 txtmyapp.Visible=false;
                 txtoff.Visible = false;
                 lbloff.Visible = false;
                 txtvisawrk.Visible = false;
                 lblvisawrk.Visible = false;

            }
        }

        public void TextBoxPropertyReadOnly()
        {

            //ddlCountry.SelectedItem.Text = lst[0].CountryName.ToString();
           // ddlVisaType.SelectedItem.Text = lst[0].VisaType.ToString();
           // ddlconsulate.SelectedItem.Text = lst[0].FkConsulate.ToString();
            //txtconAdd.ReadOnly = true;
            txtFee.ReadOnly = true;
            txtprotime.ReadOnly = true;
            txtSubday.ReadOnly = true;
            txtsubtime.ReadOnly = true;
            txtcolday.ReadOnly = true;
            txtcoltime.ReadOnly = true;
            txtvisawrk.ReadOnly = true;
            txtoff.ReadOnly = true;
            txtnormlfee.ReadOnly = true;
            txturgntfee.ReadOnly = true;
            txtvfs.ReadOnly = true;
            txttiming.ReadOnly = true;
            txtstufee.ReadOnly = true;
            txtcmmnts.ReadOnly = true;
            txtBasic.ReadOnly = true;
            TxtNote.ReadOnly = true;
            TxtMed.ReadOnly = true;
            Txtother.ReadOnly = true;
            txtIntrvw.ReadOnly = true;
            txtGenReq.ReadOnly = true;
            txtNormlcl.ReadOnly = true;
            txtmyapp.ReadOnly = true;


        }
        #region showbutton
        protected void BtnShow_Click(object sender, EventArgs e)
        {


            List<VisaRequirement> lstVisaRequirement = new List<VisaRequirement>();

            lstVisaRequirement = visaReqBal.ShowVisaRequirement(ddlCountry.SelectedItem.Text, ddlVisaType.SelectedItem.Text, ddlconsulate.SelectedItem.Text);
            if (lstVisaRequirement.Count > 0)
            {
            showTable.Visible = true;
                btnSave.Visible = false;
                Btnupdate.Visible = true;
                ViewState["id"] = lstVisaRequirement[0].ReqId;

                //txtconAdd.Text = lst[0].consulate_id.ToString();
                txtFee.Text = lstVisaRequirement[0].Fee;
                txtAddress.Text = lstVisaRequirement[0].ConAddress;
                txtprotime.Text = lstVisaRequirement[0].ProcessTime;
                txtSubday.Text = lstVisaRequirement[0].SubmissionDays;
                txtsubtime.Text = lstVisaRequirement[0].SubmissionTime;
                txtcolday.Text = lstVisaRequirement[0].CollectionDays;
                txtcoltime.Text = lstVisaRequirement[0].CollectionTime;
                txtvisawrk.Text = lstVisaRequirement[0].VisaSectionWorkingDays;
                txtoff.Text = lstVisaRequirement[0].VisaOff;
                txtnormlfee.Text = lstVisaRequirement[0].NormalFee;
                txturgntfee.Text = lstVisaRequirement[0].UrgentFee;
                txtvfs.Text = lstVisaRequirement[0].Vfs;
                txttiming.Text = lstVisaRequirement[0].Timings;
                txtstufee.Text = lstVisaRequirement[0].StudentFees;
                txtcmmnts.Text = lstVisaRequirement[0].Comments;
                txtBasic.Text = lstVisaRequirement[0].BasicRequirements;
                TxtNote.Text = lstVisaRequirement[0].Notes;
                TxtMed.Text = lstVisaRequirement[0].MedicalRequirement;
                Txtother.Text = Convert.ToString(lstVisaRequirement[0].OtherInfo);
                txtIntrvw.Text = lstVisaRequirement[0].CopyOfInterviewDate;
                txtGenReq.Text = lstVisaRequirement[0].GenReq;
                txtNormlcl.Text = lstVisaRequirement[0].NormalCollection;
                txtmyapp.Text = lstVisaRequirement[0].MyApplication;
            }
            else
            {
                
               showTable.Visible = true;
                Btnupdate.Visible = false;
                btnSave.Visible = true;
                
            }

        }
        #endregion

        #region save button
        protected void btnSave_Click(object sender, EventArgs e)
        {
            visaRequirement.CountryName = ddlCountry.SelectedItem.Text;
            visaRequirement.FkCountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
            visaRequirement.VisaType = ddlVisaType.SelectedItem.Text;
            visaRequirement.FkConsulate = ddlconsulate.SelectedItem.Text;
            visaRequirement.ConAddress = txtAddress.Text;
            visaRequirement.Fee = txtFee.Text;
            visaRequirement.ProcessTime = txtprotime.Text;
            visaRequirement.SubmissionDays = txtSubday.Text;
            visaRequirement.SubmissionTime = txtsubtime.Text;
            visaRequirement.CollectionDays = txtcolday.Text;
            visaRequirement.CollectionTime = txtcoltime.Text;
            visaRequirement.VisaSectionWorkingDays = txtvisawrk.Text;
            visaRequirement.VisaOff = txtoff.Text;
            visaRequirement.NormalFee = txtnormlfee.Text;
            visaRequirement.UrgentFee = txturgntfee.Text;
            visaRequirement.Vfs = txtvfs.Text;
            visaRequirement.Timings = txttiming.Text;
            visaRequirement.StudentFees = txtstufee.Text;
            visaRequirement.Comments = txtcmmnts.Text;
            visaRequirement.BasicRequirements = txtBasic.Text;
            visaRequirement.Notes = TxtNote.Text;
            visaRequirement.MedicalRequirement = TxtMed.Text;
            visaRequirement.OtherInfo = Txtother.Text;
            visaRequirement.CopyOfInterviewDate = txtIntrvw.Text;
            visaRequirement.GenReq = txtGenReq.Text;
            visaRequirement.NormalCollection = txtNormlcl.Text;
            visaRequirement.MyApplication = txtmyapp.Text;
            visaReqBal.CreateVisaRequirement(visaRequirement);
            ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "a", "alert('Record Saved successfully...')", true);
            clear();


        }
        #endregion

        #region button update......

        protected void Btnupdate_Click(object sender, EventArgs e)
        {
            
            if (Request.QueryString["REQ_ID"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["REQ_ID"]);

                visaRequirement.CountryName = ddlCountry.SelectedItem.Text;
                visaRequirement.FkCountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
                visaRequirement.VisaType = ddlVisaType.SelectedItem.Text;
                visaRequirement.FkConsulate = ddlconsulate.SelectedItem.Text;
                visaRequirement.ConAddress = txtAddress.Text;
                visaRequirement.Fee = txtFee.Text;
                visaRequirement.ProcessTime = txtprotime.Text;
                visaRequirement.SubmissionDays = txtSubday.Text;
                visaRequirement.SubmissionTime = txtsubtime.Text;
                visaRequirement.CollectionDays = txtcolday.Text;
                visaRequirement.CollectionTime = txtcoltime.Text;
                visaRequirement.VisaSectionWorkingDays = txtvisawrk.Text;
                visaRequirement.VisaOff = txtoff.Text;
                visaRequirement.NormalFee = txtnormlfee.Text;
                visaRequirement.UrgentFee = txturgntfee.Text;
                visaRequirement.Vfs = txtvfs.Text;
                visaRequirement.Timings = txttiming.Text;
                visaRequirement.StudentFees = txtstufee.Text;
                visaRequirement.Comments = txtcmmnts.Text;
                visaRequirement.BasicRequirements = txtBasic.Text;
                visaRequirement.Notes = TxtNote.Text;
                visaRequirement.MedicalRequirement = TxtMed.Text;
                visaRequirement.OtherInfo = Txtother.Text;
                visaRequirement.CopyOfInterviewDate = txtIntrvw.Text;
                visaRequirement.GenReq = txtGenReq.Text;
                visaRequirement.NormalCollection = txtNormlcl.Text;
                visaRequirement.MyApplication = txtmyapp.Text;
                visaReqBal.UpdateVisaRequirement(visaRequirement, id);
                clear();
               showTable.Visible = false;
                Response.Redirect("ViewVisaInformation.aspx");
                ScriptManager.RegisterClientScriptBlock(Btnupdate, GetType(), "a", "alert('Record Update successfully...')", true);
                
            }
            else
            {

                int id = Convert.ToInt32(ViewState["id"]);

                visaRequirement.CountryName = ddlCountry.SelectedItem.Text;
                visaRequirement.FkCountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
                visaRequirement.VisaType = ddlVisaType.SelectedItem.Text;
                visaRequirement.FkConsulate = ddlconsulate.SelectedItem.Text;
                visaRequirement.ConAddress = txtAddress.Text;
                visaRequirement.Fee = txtFee.Text;
                visaRequirement.ProcessTime = txtprotime.Text;
                visaRequirement.SubmissionDays = txtSubday.Text;
                visaRequirement.SubmissionTime = txtsubtime.Text;
                visaRequirement.CollectionDays = txtcolday.Text;
                visaRequirement.CollectionTime = txtcoltime.Text;
                visaRequirement.VisaSectionWorkingDays = txtvisawrk.Text;
                visaRequirement.VisaOff = txtoff.Text;
                visaRequirement.NormalFee = txtnormlfee.Text;
                visaRequirement.UrgentFee = txturgntfee.Text;
                visaRequirement.Vfs = txtvfs.Text;
                visaRequirement.Timings = txttiming.Text;
                visaRequirement.StudentFees = txtstufee.Text;
                visaRequirement.Comments = txtcmmnts.Text;
                visaRequirement.BasicRequirements = txtBasic.Text;
                visaRequirement.Notes = TxtNote.Text;
                visaRequirement.MedicalRequirement = TxtMed.Text;
                visaRequirement.OtherInfo = Txtother.Text;
                visaRequirement.CopyOfInterviewDate = txtIntrvw.Text;
                visaRequirement.GenReq = txtGenReq.Text;
                visaRequirement.NormalCollection = txtNormlcl.Text;
                visaRequirement.MyApplication = txtmyapp.Text;
                visaReqBal.UpdateVisaRequirement(visaRequirement, id);
                ScriptManager.RegisterClientScriptBlock(Btnupdate, GetType(), "a", "alert('Record Update successfully...')", true);
               
                clear();
                showTable.Visible = false;
                ddlconsulate.SelectedIndex = 3;
                ddlVisaType.SelectedIndex = 1;
            }

        }

        #endregion

        #region clear textbox
        public void clear()
        {
            ddlCountry.SelectedValue = "0";
            ddlconsulate.SelectedValue = "0";
            ddlVisaType.SelectedValue = "0";
            txtAddress.Text = String.Empty;
            txtFee.Text = String.Empty;
            txtprotime.Text = String.Empty;
            txtSubday.Text = String.Empty;
            txtsubtime.Text = String.Empty;
            txtcolday.Text = String.Empty;
            txtcoltime.Text = String.Empty;
            txtvisawrk.Text = String.Empty;
            txtoff.Text = String.Empty;
            txtnormlfee.Text = String.Empty;
            txturgntfee.Text = String.Empty;
            txtvfs.Text = String.Empty;
            txttiming.Text = String.Empty;
            txtstufee.Text = String.Empty;
            txtcmmnts.Text = String.Empty;
            txtBasic.Text = String.Empty;
            TxtNote.Text = String.Empty;
            TxtMed.Text = String.Empty;
            Txtother.Text = String.Empty;
            txtIntrvw.Text = String.Empty;
            txtGenReq.Text = String.Empty;
            txtNormlcl.Text = String.Empty;
            txtmyapp.Text = String.Empty;
        }
        #endregion

        protected void btnAddVisaForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddVisaForm.aspx");
        }





    }
}