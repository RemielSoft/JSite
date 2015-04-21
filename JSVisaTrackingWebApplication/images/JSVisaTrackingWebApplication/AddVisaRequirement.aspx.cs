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
        VisaRequirementBusinessAccess bl = new VisaRequirementBusinessAccess();
        VisaRequirement visaRequirement = new VisaRequirement();
        BasePage basePage = new BasePage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                basePage.BindDropDown(ddlCountry, "CountryName", "Country_Id", bl.ReadCountry());
                basePage.BindDropDown(ddlconsulate, "consulate_name", "consulate_id", bl.ReadConsulate());
                basePage.BindDropDown(ddlVisaType, "DESCRIPTION_ONE", "TYPE_ONE_ID", bl.ReadVisaType());
               
                if (Request.QueryString["REQ_ID"] != null)
                {
                    

                    
                    Btnupdate.Visible = true;

                    int id = Convert.ToInt32(Request.QueryString["REQ_ID"]);
                    List<VisaRequirement> lst = bl.editgrid(id);

                    ddlCountry.SelectedItem.Text = lst[0].CountryName.ToString();
                    ddlVisaType.SelectedItem.Text = lst[0].VisaType.ToString();
                    ddlconsulate.SelectedItem.Text = lst[0].FkConsulate.ToString();                    
                    txtconAdd.Text = lst[0].consulate_id.ToString();
                    txtFee.Text = lst[0].Fee.ToString();
                    txtprotime.Text = lst[0].ProcessTime.ToString();
                    txtSubday.Text = lst[0].SubmissionDays.ToString();
                    txtsubtime.Text = lst[0].SubmissionTime.ToString();
                    txtcolday.Text = lst[0].CollectionDays.ToString();
                    txtcoltime.Text = lst[0].CollectionTime.ToString();
                    txtvisawrk.Text = lst[0].VisaSectionWorkingDays.ToString();
                    txtoff.Text = lst[0].VisaOff.ToString();
                    txtnormlfee.Text = lst[0].NormalFee.ToString();
                    txturgntfee.Text = lst[0].UrgentFee.ToString();
                    txtvfs.Text = lst[0].Vfs.ToString();
                    txttiming.Text = lst[0].Timings.ToString();
                    txtstufee.Text = lst[0].StudentFees.ToString();
                    txtcmmnts.Text = lst[0].Comments.ToString();
                    txtBasic.Text = lst[0].BasicRequirements.ToString();
                    TxtNote.Text = lst[0].Notes.ToString();
                    TxtMed.Text = lst[0].MedicalRequirement.ToString();
                    Txtother.Text = lst[0].OtherInfo.ToString();
                    txtIntrvw.Text = lst[0].CopyOfInterviewDate.ToString();
                    txtGenReq.Text = lst[0].GenReq.ToString();
                    txtNormlcl.Text = lst[0].NormalCollection.ToString();
                    txtmyapp.Text = lst[0].MyApplication.ToString();

                    showTable.Visible = true;
                }
                else
                {
                    showTable.Visible = false;
                }


            }
        }
        #region showbutton
        protected void BtnShow_Click(object sender, EventArgs e)
        {
            
                                       
            List<VisaRequirement> lst = new List<VisaRequirement>();

            lst = bl.show_visainfo(ddlCountry.SelectedItem.Text, ddlVisaType.SelectedItem.Text, ddlconsulate.SelectedItem.Text);
            if (lst.Count > 0)
            {
                showTable.Visible = true;
                btnSave.Visible = false;
                Btnupdate.Visible = true;
                ViewState["id"] = lst[0].ReqId;

                txtconAdd.Text = lst[0].consulate_id.ToString();
                txtFee.Text = lst[0].Fee.ToString();
                txtprotime.Text = lst[0].ProcessTime.ToString();
                txtSubday.Text = lst[0].SubmissionDays.ToString();
                txtsubtime.Text = lst[0].SubmissionTime.ToString();
                txtcolday.Text = lst[0].CollectionDays.ToString();
                txtcoltime.Text = lst[0].CollectionTime.ToString();
                txtvisawrk.Text = lst[0].VisaSectionWorkingDays.ToString();
                txtoff.Text = lst[0].VisaOff.ToString();
                txtnormlfee.Text = lst[0].NormalFee.ToString();
                txturgntfee.Text = lst[0].UrgentFee.ToString();
                txtvfs.Text = lst[0].Vfs.ToString();
                txttiming.Text = lst[0].Timings.ToString();
                txtstufee.Text = lst[0].StudentFees.ToString();
                txtcmmnts.Text = lst[0].Comments.ToString();
                txtBasic.Text = lst[0].BasicRequirements.ToString();
                TxtNote.Text = lst[0].Notes.ToString();
                TxtMed.Text = lst[0].MedicalRequirement.ToString();
                Txtother.Text = lst[0].OtherInfo.ToString();
                txtIntrvw.Text = lst[0].CopyOfInterviewDate.ToString();
                txtGenReq.Text = lst[0].GenReq.ToString();
                txtNormlcl.Text = lst[0].NormalCollection.ToString();
                txtmyapp.Text = lst[0].MyApplication.ToString();
            }
            else
            {
                showTable.Visible = true;
                Btnupdate.Visible = false;
                btnSave.Visible = true;
                clear();
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
            visaRequirement.ConAddress = txtconAdd.Text;
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
            bl.insert(visaRequirement);
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
                visaRequirement.ConAddress = txtconAdd.Text;
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
                bl.update_visainfo(visaRequirement, id);
                ScriptManager.RegisterClientScriptBlock(Btnupdate, GetType(), "a", "alert('Record Saved successfully...')", true);
                clear();
                
            }
            else
            {

                int id =Convert.ToInt32( ViewState["id"]);

                visaRequirement.CountryName = ddlCountry.SelectedItem.Text;
                visaRequirement.FkCountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
                visaRequirement.VisaType = ddlVisaType.SelectedItem.Text;
                visaRequirement.FkConsulate = ddlconsulate.SelectedItem.Text;
                visaRequirement.ConAddress = txtconAdd.Text;
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
                bl.update_visainfo(visaRequirement, id);
                ScriptManager.RegisterClientScriptBlock(Btnupdate, GetType(), "a", "alert('Record Saved successfully...')", true);
               
                clear();
                
            }

        }

        #endregion

        #region clear textbox
        public void clear()
        {
            ddlCountry.SelectedValue="0";
            ddlconsulate.SelectedValue = "0";
            ddlVisaType.SelectedValue = "0";
            txtconAdd.Text = String.Empty;
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

       

        
       
    }
}