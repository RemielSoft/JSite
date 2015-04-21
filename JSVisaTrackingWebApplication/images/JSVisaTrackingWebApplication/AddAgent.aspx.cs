using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.Web.Services;
using System.Globalization;

namespace JSVisaTrackingWebApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        AgentBAL adAgentBal = new AgentBAL();
        Agent adAgentDom = new Agent();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_addagent_Click(object sender, EventArgs e)
        {
            
            //adAgentDom.AgentId = Convert.ToInt32(txt_agid.Text);
            adAgentDom.AgentUserName = txt_agusername.Text;
            adAgentDom.AgentPassword = txt_agpassword.Text;
            adAgentDom.AgentPrority = Convert.ToInt32(txt_agproperty.Text);
            adAgentDom.AgentCPerson = txt_contect.Text;
            adAgentDom.AgentName = txt_agcompanyname.Text;
            adAgentDom.TallyAcName = txt_tally.Text;
            adAgentDom.AgentAddress = txt_agaddress.Text;
            adAgentDom.AgentCity = txt_agcity.Text;
            adAgentDom.AgentPin = txt_agpin.Text;
            adAgentDom.AgentEmail = txt_email.Text;
            adAgentDom.AgentPhone = txt_agphone.Text;
            adAgentDom.AgentFax = txt_fax.Text;
            adAgentDom.AgentSCharge = decimal.Parse(txt_agservice.Text, CultureInfo.InvariantCulture.NumberFormat);
            adAgentDom.AgentCCharge = decimal.Parse(txt_Courier.Text, CultureInfo.InvariantCulture.NumberFormat);
            adAgentDom.AgentDDCharge = decimal.Parse(txt_agDraft.Text, CultureInfo.InvariantCulture.NumberFormat);
            adAgentDom.OpeningBalance = decimal.Parse(txt_agOpening.Text, CultureInfo.InvariantCulture.NumberFormat);
            if (chbox_enable.Checked == true)
            {
                adAgentDom.AgentEnable = "Active";
            }
            else
            {
                adAgentDom.AgentEnable = "Deactive";
            }
            adAgentBal.InsertAgentDetail(adAgentDom);
            ScriptManager.RegisterClientScriptBlock(btn_addagent, GetType(), "a", "alert('Record Save successfully...')", true);
            clearall();

        }
        
        public void clearall()
        {
           // txt_agid.Text = string.Empty;
            txt_agusername.Text = string.Empty;
            txt_agpassword.Text = string.Empty;
            txt_agproperty.Text = string.Empty;
            txt_contect.Text = string.Empty;
            txt_agcompanyname.Text = string.Empty;
            txt_tally.Text = string.Empty;
            txt_agaddress.Text = string.Empty;
            txt_agcity.Text = string.Empty;
            txt_agpin.Text = string.Empty;
            txt_email.Text = string.Empty;
            txt_agphone.Text = string.Empty;
            txt_fax.Text = string.Empty;
            txt_agservice.Text = string.Empty;
            txt_Courier.Text = string.Empty;
            txt_agDraft.Text = string.Empty;
            txt_agOpening.Text = string.Empty;
            chbox_enable.Checked = false;

        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            clearall();
        }
    }
}