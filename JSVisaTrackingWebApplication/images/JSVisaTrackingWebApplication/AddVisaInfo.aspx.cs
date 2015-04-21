using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.Data.SqlClient;
using System.Data;
namespace JSVisaTrackingWebApplication
{
    public partial class AddVisaInfo : System.Web.UI.Page
    {
        AddVisaInfoBAL bl = new AddVisaInfoBAL();
        AddVisaInfoDOM ob = new AddVisaInfoDOM();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                country();
                consulate();
                visatype();
                if (Request.QueryString["REQ_ID"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["REQ_ID"]);
                    List<AddVisaInfoDOM> lst = bl.editgrid(id);
                    ddlCountry.SelectedItem.Text = lst[0].COUNTRY_NAME.ToString();
                    ddlVisaType.SelectedItem.Text = lst[0].VISA_TYPE.ToString();
                    ddlconsulate.SelectedItem.Text = lst[0].FK_CONSULATE.ToString();
                    txtconAdd.Text = lst[0].CON_ADDRESS.ToString();
                    txtFee.Text = lst[0].FEE;
                    txtprotime.Text = lst[0].PROCESS_TIME.ToString();
                    txtSubday.Text = lst[0].SUBMISSION_DAYS.ToString();
                    txtsubtime.Text = lst[0].SUBMISSION_TIME.ToString();
                    txtcolday.Text = lst[0].COLLECTION_DAYS.ToString();
                    txtcoltime.Text = lst[0].COLLECTION_TIME.ToString();
                    TxtMed.InnerText = lst[0].MEDICAL_REQUIREMENT.ToString();
                    TxtNote.InnerText = lst[0].NOTES.ToString();
                }
                
                
            }
           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            ob.COUNTRY_NAME = ddlCountry.SelectedItem.Text;
            ob.FK_COUNTRY_ID= Convert.ToInt32( ddlCountry.SelectedItem.Value);
            ob.VISA_TYPE = ddlVisaType.SelectedItem.Text;
            ob.FK_CONSULATE = ddlconsulate.SelectedItem.Text;
            ob.CON_ADDRESS = txtconAdd.Text;
            ob.FEE = txtFee.Text;
            ob.PROCESS_TIME = txtprotime.Text;
            ob.SUBMISSION_DAYS = txtSubday.Text;
            ob.SUBMISSION_TIME = txtsubtime.Text;
            ob.COLLECTION_DAYS = txtcolday.Text;
            ob.COLLECTION_TIME = txtcoltime.Text;
            ob.BASIC_REQUIREMENT = txtBasic.InnerText;
            ob.NOTES = ( TxtNote.InnerText);
            ob.MEDICAL_REQUIREMENT = TxtMed.InnerText;
            bl.insert(ob);
               

        }
        public void country()
        {
            ddlCountry.DataSource = bl.ReadCountry();
            ddlCountry.DataTextField = "Country_Name";
            ddlCountry.DataValueField = "Country_Id";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        public void consulate()
        {

            ddlconsulate.DataSource = bl.ReadConsulate();
            ddlconsulate.DataTextField = "consulate_name";
            ddlconsulate.DataValueField = "consulate_Id";
            ddlconsulate.DataBind();
            ddlconsulate.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        public void visatype()
        {
            ddlVisaType.DataSource = bl.ReadVisaType();
            ddlVisaType.DataTextField = "DESCRIPTION_ONE";
            ddlVisaType.DataValueField = "TYPE_ONE_ID";
            ddlVisaType.DataBind();
            ddlVisaType.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void BtnShow_Click(object sender, EventArgs e)
        {
            List<AddVisaInfoDOM> lst = new List<AddVisaInfoDOM>();
            
            lst = bl.show_visainfo(ddlCountry.SelectedItem.Text, ddlVisaType.SelectedItem.Text, ddlconsulate.SelectedItem.Text);
            if (lst.Count>0)
            {
                txtconAdd.Text = lst[0].consulate_id.ToString();
                txtFee.Text = lst[0].FEE.ToString();
                txtprotime.Text = lst[0].PROCESS_TIME.ToString();
                txtSubday.Text = lst[0].SUBMISSION_DAYS.ToString();
                txtsubtime.Text = lst[0].SUBMISSION_TIME.ToString();
                txtcolday.Text = lst[0].COLLECTION_DAYS.ToString();
                txtcoltime.Text = lst[0].COLLECTION_TIME.ToString();
                txtBasic.InnerText = lst[0].BASIC_REQUIREMENT.ToString();
                TxtNote.InnerText = lst[0].NOTES.ToString();
                TxtMed.InnerText = lst[0].MEDICAL_REQUIREMENT.ToString();
            }
            else
            {
                txtconAdd.Text = String.Empty;
                txtFee.Text = String.Empty;
                txtprotime.Text = String.Empty;
                txtSubday.Text = String.Empty;
                txtsubtime.Text = String.Empty;
                txtcolday.Text = String.Empty;
                txtcoltime.Text = String.Empty;
                txtBasic.InnerText = String.Empty;
                TxtNote.InnerText = String.Empty;
                TxtMed.InnerText = String.Empty;
            }
            
        }
        //public void grid()
        //{
        //    int id = Convert.ToInt32( Session["id"]);
            //List<AddVisaInfoDOM> lst = bl.editgrid(id);
            //ddlCountry.SelectedItem.Text = lst[0].COUNTRY_NAME.ToString();
            //ddlVisaType.SelectedItem.Text = lst[0].VISA_TYPE.ToString();
            //ddlconsulate.SelectedItem.Text = lst[0].consulate_name.ToString();
            //txtconAdd.Text = lst[0].CON_ADDRESS.ToString();
            //txtFee.Text = lst[0].FEE;
            //txtprotime.Text = lst[0].PROCESS_TIME.ToString();
            //txtSubday.Text = lst[0].SUBMISSION_DAYS.ToString();
            //txtsubtime.Text = lst[0].SUBMISSION_TIME.ToString();
            //txtcolday.Text = lst[0].COLLECTION_DAYS.ToString();
            //txtcoltime.Text = lst[0].COLLECTION_TIME.ToString();
            //TxtMed.InnerText = lst[0].MEDICAL_REQUIREMENT.ToString();
            //TxtNote.InnerText = lst[0].NOTES.ToString();
            
            
        //}
       
     
        
        
       


        
    }
}