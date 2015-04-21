using JSVisaTrackingWebApplication.Shared;
using Remielsoft.JetSave.BusinessAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace JSVisaTrackingWebApplication
{
    public partial class VisaInformation : System.Web.UI.Page
    {
        VisaFormBL visaBal = new VisaFormBL();
        VisaRequirementBusinessAccess visaReqBal = new VisaRequirementBusinessAccess();
        VisaRequirement visaRequirement = new VisaRequirement();
        BasePage basePage = new BasePage();
        public string p;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                noRecordFound.Visible = false;
                recordFound.Visible = false;
                basePage.BindDropDown(ddlCountry, "CountryName", "Country_Id", visaReqBal.ReadCountry());
                basePage.BindDropDown(ddlconsulate, "consulate_name", "consulate_id", visaReqBal.ReadConsulate());
                ddlconsulate.SelectedIndex = 1;
                basePage.BindDropDown(ddlVisaType, "DESCRIPTION_ONE", "TYPE_ONE_ID", visaReqBal.ReadVisaType());
                ddlVisaType.SelectedIndex = 2;
                if (Request.QueryString["REQ_ID"] != null && Request.QueryString["Viewid"] == "")
                {

                    int id = Convert.ToInt32(Request.QueryString["REQ_ID"]);
                    List<VisaRequirement> lstVisaRequirement = visaReqBal.ReadVisaRequirementByReqId(id);

                    ddlCountry.SelectedItem.Text = lstVisaRequirement[0].CountryName.ToString();
                    ddlVisaType.SelectedItem.Text = lstVisaRequirement[0].VisaType.ToString();
                    ddlconsulate.SelectedItem.Text = lstVisaRequirement[0].FkConsulate.ToString();
                }
                else if (Request.QueryString["REQ_ID"] != null && Request.QueryString["Viewid"] == "2")
                {
                    int id = Convert.ToInt32(Request.QueryString["REQ_ID"]);
                    List<VisaRequirement> lstVisaRequirement = visaReqBal.ReadVisaRequirementByReqId(id);
                    ddlCountry.SelectedItem.Text = lstVisaRequirement[0].CountryName.ToString();
                    ddlVisaType.SelectedItem.Text = lstVisaRequirement[0].VisaType.ToString();
                    ddlconsulate.SelectedItem.Text = lstVisaRequirement[0].FkConsulate.ToString();
                }
                else
                {
                    //showTable.Visible = false;
                }
            }
        }

        protected void BtnShow_Click(object sender, EventArgs e)
        {

            List<VisaRequirement> lstVisaRequirement = new List<VisaRequirement>();

            lstVisaRequirement = visaReqBal.ShowVisaRequirement(ddlCountry.SelectedItem.Text, ddlVisaType.SelectedItem.Text, ddlconsulate.SelectedItem.Text);
            if (lstVisaRequirement.Count > 0)
            {

                ViewState["id"] = lstVisaRequirement[0].ReqId;
                string add = lstVisaRequirement[0].ConAddress;
                string[] address = add.Split('&');
                string stradderess = "<ul>{0}</ul>";
                StringBuilder strBuilders = new StringBuilder();
                foreach (var items in address)
                {
                    strBuilders.Append(items + "</br>");
                }
                lblAddress.Text = string.Format(stradderess, strBuilders.ToString());
                string fee = lstVisaRequirement[0].Fee;
                string[] fees = fee.Split('&');
                string strfee = "<ul>{0}</ul>";
                StringBuilder strFeeBuilders = new StringBuilder();
                foreach (var f in fees)
                {
                    strFeeBuilders.Append(f + "</br>");
                }
                lblFees.Text = string.Format(strfee, strFeeBuilders.ToString());
                lblProcess.Text = lstVisaRequirement[0].ProcessTime;
                if (lstVisaRequirement[0].OtherInfo == "")
                {
                    impoInfo.Visible = false;
                }
                else
                {
                    lblotherinfo.Text = lstVisaRequirement[0].OtherInfo;
                }
                if (lstVisaRequirement[0].SubmissionDays == "")
                {
                    subDate.Visible = false;
                }
                else
                {
                    lblSubmission.Text = lstVisaRequirement[0].SubmissionDays;
                }

                if (lstVisaRequirement[0].SubmissionTime == "")
                {
                    subTime.Visible = false;
                }
                else
                {
                    lblSubmissionTime.Text = lstVisaRequirement[0].SubmissionTime;
                }
                if (lstVisaRequirement[0].CollectionDays == "")
                {
                    CollDay.Visible = false;
                }
                else
                {
                    lblCollectionDay.Text = lstVisaRequirement[0].CollectionDays;
                }
                if (lstVisaRequirement[0].CollectionTime == "")
                {
                    CollTime.Visible = false;
                }
                else
                {
                    lblCollectiontime.Text = lstVisaRequirement[0].CollectionTime;
                }
                // lblWorkingDay.Text = lstVisaRequirement[0].VisaSectionWorkingDays;
                if (lstVisaRequirement[0].Comments != null && lstVisaRequirement[0].Comments == "")
                {
                    lblcomments.Text = Convert.ToString(lstVisaRequirement[0].Comments.ToUpper());
                }
                else
                {
                    lblcomments.Text = Convert.ToString(lstVisaRequirement[0].Comments);
                }
                string basicRequirement = lstVisaRequirement[0].BasicRequirements;
                string[] arr = basicRequirement.Split('&');
                string strBasicFormt = "<ul>{0}</ul>";
                StringBuilder strBuilder = new StringBuilder();
                foreach (var item in arr)
                {
                    strBuilder.Append("<li>" + item + "</li></br>");
                }
                lblbasicreq.Text = string.Format(strBasicFormt, strBuilder.ToString());

                if (lstVisaRequirement[0].MedicalRequirement == "")
                {
                    medicalInfo.Visible = false;
                }
                else
                {
                    lblmedicalreq.Text = lstVisaRequirement[0].MedicalRequirement;
                }
                if (lstVisaRequirement[0].Notes == "")
                {
                    notes.Visible = false;
                }
                else
                {
                    string notes = lstVisaRequirement[0].Notes;
                    string[] not = notes.Split('&');

                    string strNotes = "<ul>{0}</ul>";
                    StringBuilder strBuildernot = new StringBuilder();
                    foreach (var itemss in not)
                    {
                        strBuildernot.Append("<li>" + itemss + "</li></br>");
                    }
                    lblnotes.Text = string.Format(strNotes, strBuildernot.ToString());
                }
                //  string temp;
                lblLocaVisa.Text = lstVisaRequirement[0].CountryName.ToUpper() + "-" + lstVisaRequirement[0].VisaType.ToUpper();
                StringBuilder sb = new StringBuilder();
                string form = lstVisaRequirement[0].Visa_Form;
                string formpath = lstVisaRequirement[0].Visa_title;
                string[] commaPath = formpath.Split(',');
                string[] commaForm = form.Split(',');
                foreach (var comma in commaForm)
                {
                    foreach (var fromTitle in commaPath)
                    {
                        sb.Append("<a style='color:blue;' target='_blank' href='" + comma + "'>" + fromTitle + "<a>,</br>"); 
                    }
                }









                // formPath.Replace(",", "," + Environment.NewLine);
               // string[] strPath = formPath.Split(',');
                //foreach (var item in lstVisaRequirement)
                //{
                //    sb.Append("<a style='color:blue;' target='_blank' href='" + item.Visa_Form + "'>" + item.Visa_title + "<a>,</br>");
                //}
                visaFormContainer.InnerHtml = sb.ToString();
                noRecordFound.Visible = false;
                recordFound.Visible = true;
            }
            else
            {
                noRecordFound.Visible = true;
                recordFound.Visible = false;
            }
        }
        protected void lnkButtonView_Click(object sender, EventArgs e)
        {

            //read country  visa form list
            var lstVisa = visaBal.ReadVisaFormByCountry(ddlCountry.SelectedItem.Text,null);
            if (lstVisa != null && lstVisa.Count > 0)
            {
                foreach (var item in lstVisa)
                {
                    p = item.Form;
                    string path = Server.MapPath(p);
                    WebClient client = new WebClient();
                    if (File.Exists(path))
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "page_index_script", "openPDF();", true);
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No Visa Form Attached');", true);
            }
        }
    }
}