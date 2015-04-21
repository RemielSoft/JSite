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
using JSVisaTrackingWebApplication.Shared;

namespace JSVisaTrackingWebApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        #region Global Variable..
        AgentBAL adAgentBal = new AgentBAL();
        Agent adAgentDom = new Agent();
        BasePage basePage = new BasePage();
        UserBAL userBal = new UserBAL();
        LocationBusinessAccess locationBusinessAccess = new LocationBusinessAccess();
        VisaRequirementBusinessAccess advs = new VisaRequirementBusinessAccess();
        #endregion

        #region Protected Method..
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountry();
            }            
        }
        public void BindCountry()
        {
            var lst = advs.ReadCountry();
            ddlCountry.DataSource = lst;
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataValueField = "COUNTRY_ID";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        protected void btn_addagent_Click(object sender, EventArgs e)
        {
            adAgentDom.AgentLocationId = basePage.LoggedInUser.UserLocation.LocationId;
            adAgentDom.AgentCityId = Convert.ToInt32(ddlCity.SelectedValue);
            adAgentDom.AgentStateId = Convert.ToInt32(ddlState.SelectedValue);
            adAgentDom.AgentCountryId = Convert.ToInt32(ddlCountry.SelectedValue);
            adAgentDom.AgentUserName = txt_agusername.Text;
            adAgentDom.AgentPassword = txt_agpassword.Text;
            adAgentDom.AgentPrority = Convert.ToInt32(txt_agproperty.Text);
            adAgentDom.AgentCPerson = txt_contect.Text;
            adAgentDom.AgentName = txt_agcompanyname.Text;
            adAgentDom.TallyAcName = txt_tally.Text;
            adAgentDom.AgentAddress = txt_agaddress.Text;
            adAgentDom.AgentCity = ddlCity.SelectedItem.Text;
            adAgentDom.AgentPin = txt_agpin.Text;
            adAgentDom.AgentEmail = txt_email.Text;
            adAgentDom.AgentPhone = txt_agphone.Text;
            adAgentDom.AgentFax = txt_fax.Text;
            adAgentDom.AgentSCharge = decimal.Parse(txt_agservice.Text, CultureInfo.InvariantCulture.NumberFormat);
            adAgentDom.AgentCCharge = decimal.Parse(txt_Courier.Text, CultureInfo.InvariantCulture.NumberFormat);
            adAgentDom.AgentDDCharge = decimal.Parse(txt_agDraft.Text, CultureInfo.InvariantCulture.NumberFormat);
            if (txt_agOpening.Text == "")
            {
                txt_agOpening.Text = Convert.ToString(0);
            }

            adAgentDom.OpeningBalance = decimal.Parse(txt_agOpening.Text, CultureInfo.InvariantCulture.NumberFormat);
            if (chbox_enable.Checked == true)
            {
                adAgentDom.AgentEnable = "Y";
            }
            else
            {
                adAgentDom.AgentEnable = "N";
            }
            adAgentDom.Created_By = basePage.LoggedInUser.LoginId;
            adAgentBal.InsertAgentDetail(adAgentDom);
            ScriptManager.RegisterClientScriptBlock(btn_addagent, GetType(), "a", "alert('Agent Added Successfully.')", true);
            clearall();
        }        
       
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            clearall();
        }

        
        #endregion

        #region Public Method..
        
        public void clearall()
        {
            txt_agusername.Text = string.Empty;
            //txt_agpassword.Text = string.Empty;
            txt_agproperty.Text = string.Empty;
            txt_contect.Text = string.Empty;
            txt_agcompanyname.Text = string.Empty;
            txt_tally.Text = string.Empty;
            txt_agaddress.Text = string.Empty;
            ddlCity.SelectedIndex = 0;
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
        #endregion

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindState();
        }

        public void BindState()
        {
            int countryId = Convert.ToInt32(ddlCountry.SelectedValue);
            var lst = advs.ReadStateByCountryID(countryId);
            ddlState.DataSource = lst;
            ddlState.DataTextField = "state";
            ddlState.DataValueField = "stateId";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void BindCity()
        {
            int stateId = Convert.ToInt32(ddlState.SelectedValue);
            var lst = advs.ReadCityByStateID(stateId);
            ddlCity.DataSource = lst;
            ddlCity.DataTextField = "consulate_name";
            ddlCity.DataValueField = "consulate_id";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();
        }
    }
}