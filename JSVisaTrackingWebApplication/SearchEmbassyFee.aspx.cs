using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.BusinessAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using System.Data;
using System.Data.SqlClient;
using JSVisaTrackingWebApplication.Shared;

namespace JSVisaTrackingWebApplication
{
    public partial class SearchEmbassyFee : System.Web.UI.Page
    {
        #region Global Variable(s)

        EmbsyFeeBusinessAccess embsyFeeBusinessAccess = new EmbsyFeeBusinessAccess();
        VisaRequirementBusinessAccess BL = new VisaRequirementBusinessAccess();
        EmbsyMasterBusinessAccess embsyBal = new EmbsyMasterBusinessAccess();
        BasePage basepage;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                basepage = new BasePage();

                basepage.BindDropDown(ddlCountryAll, "Country", "CountryId", embsyBal.ReadCountry());
                basepage.BindDropDown(ddlNoOfVisitAll, "NoOfVisit", "VisaTypeTwoId", embsyFeeBusinessAccess.Read());
                basepage.BindDropDown(ddlVisaDurationAll, "DurationDescription", "VisaDurationId", embsyFeeBusinessAccess.BindVisaDuraion());
                basepage.BindDropDown(ddlVisaTypeAll, "DESCRIPTION_ONE", "TYPE_ONE_ID", BL.ReadVisaType());
                basepage.BindDropDown(ddlProcessTimeAll, "ProcessTimeDesc", "ProcessTimeId", embsyFeeBusinessAccess.BindProcessTime());

                basepage.BindDropDown(ddlCountry, "Country", "CountryId", embsyBal.ReadCountry());
                basepage.BindDropDown(ddlNoOfVisit, "NoOfVisit", "VisaTypeTwoId", embsyFeeBusinessAccess.Read());
                basepage.BindDropDown(ddlVisaDuration, "DurationDescription", "VisaDurationId", embsyFeeBusinessAccess.BindVisaDuraion());
                basepage.BindDropDown(ddlVisaType, "DESCRIPTION_ONE", "TYPE_ONE_ID", BL.ReadVisaType());
                basepage.BindDropDown(ddlProcessTime, "ProcessTimeDesc", "ProcessTimeId", embsyFeeBusinessAccess.BindProcessTime());
                SelectRadioButton();
            }
        }       

        protected void rbtnlstSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectRadioButton();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void GVEmbassyFeesSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {            
            GVEmbassyFeesSearch.PageIndex = e.NewPageIndex;
            BindGrid();
        }        

        protected void GVEmbassyFeesSearch_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVEmbassyFeesSearch.EditIndex = e.NewEditIndex;            
            BindGrid();
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void GVEmbassyFeesSearch_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtFees = (TextBox)GVEmbassyFeesSearch.Rows[e.RowIndex].FindControl("txtFees");
            Int32 Id = Convert.ToInt32(GVEmbassyFeesSearch.DataKeys[e.RowIndex].Value.ToString());

            Decimal Fees = Convert.ToDecimal(txtFees.Text);
            embsyFeeBusinessAccess.UpdateFees(Id, Fees);
            GVEmbassyFeesSearch.EditIndex = -1;
            BindGrid();

        }

        protected void GVEmbassyFeesSearch_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVEmbassyFeesSearch.EditIndex = -1;
            BindGrid();
        }

        public void BindGrid()
        {
            if (rbtnlstSearch.SelectedValue == "0")
            {
                Int32 CountryId = Convert.ToInt32(ddlCountryAll.SelectedItem.Value);
                Int32 VisaTypeId = Convert.ToInt32(ddlVisaTypeAll.SelectedItem.Value);
                Int32 VisaDurationId = Convert.ToInt32(ddlVisaDurationAll.SelectedItem.Value);
                Int32 NoOfVisitId = Convert.ToInt32(ddlNoOfVisitAll.SelectedItem.Value);
                Int32 ProcessTimeId = Convert.ToInt32(ddlProcessTimeAll.SelectedItem.Value);
                List<Embsy> lst = new List<Embsy>();
                lst = embsyFeeBusinessAccess.BindGridByAll(CountryId, VisaTypeId, VisaDurationId, NoOfVisitId, ProcessTimeId);
                if (lst.Count > 0)
                {
                    GVEmbassyFeesSearch.DataSource = lst;
                    GVEmbassyFeesSearch.DataBind();                    
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "a", "alert('There Is No Record Of This Search Criteria.')", true);                    
                }
                Reset();
            }

            else if (rbtnlstSearch.SelectedValue == "1")
            {
                Int32 CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
                List<Embsy> lst = new List<Embsy>();
                lst = embsyFeeBusinessAccess.BindGridByCountryId(CountryId);
                if (lst.Count > 0)
                {
                    GVEmbassyFeesSearch.DataSource = lst;
                    GVEmbassyFeesSearch.DataBind();                    
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "a", "alert('There Is No Record Of This Country.')", true);                    
                }
                Reset();
            }

            else if (rbtnlstSearch.SelectedValue == "2")
            {
                Int32 VisaTypeId = Convert.ToInt32(ddlVisaType.SelectedItem.Value);
                List<Embsy> lst = new List<Embsy>();
                lst = embsyFeeBusinessAccess.BindGridByVisaTypeId(VisaTypeId);
                if (lst.Count > 0)
                {
                    GVEmbassyFeesSearch.DataSource = lst;
                    GVEmbassyFeesSearch.DataBind();                    
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "a", "alert('There Is No Record By This Visa Type'.')", true);                    
                }
                Reset();
            }

            else if (rbtnlstSearch.SelectedValue == "3")
            {
                Int32 VisaDurationId = Convert.ToInt32(ddlVisaDuration.SelectedItem.Value);
                List<Embsy> lst = new List<Embsy>();
                lst = embsyFeeBusinessAccess.BindGridByVisaDurationId(VisaDurationId);
                if (lst.Count > 0)
                {
                    GVEmbassyFeesSearch.DataSource = lst;
                    GVEmbassyFeesSearch.DataBind();                    
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "a", "alert('There Is No Record By This Visa Duration.')", true);                    
                }
                Reset();
            }

            else if (rbtnlstSearch.SelectedValue == "4")
            {
                Int32 NoOfVisitId = Convert.ToInt32(ddlNoOfVisit.SelectedItem.Value);
                List<Embsy> lst = new List<Embsy>();
                lst = embsyFeeBusinessAccess.BindGridByNoOfVisitId(NoOfVisitId);
                if (lst.Count > 0)
                {
                    GVEmbassyFeesSearch.DataSource = lst;
                    GVEmbassyFeesSearch.DataBind();                    
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "a", "alert('There Is No Record By This No. Of Visit.')", true);                   
                }
                Reset();
            }

            else if (rbtnlstSearch.SelectedValue == "5")
            {
                Int32 ProcessTimeId = Convert.ToInt32(ddlProcessTime.SelectedItem.Value);
                List<Embsy> lst = new List<Embsy>();
                lst = embsyFeeBusinessAccess.BindGridByProcessTimeId(ProcessTimeId);
                if (lst.Count > 0)
                {
                    GVEmbassyFeesSearch.DataSource = lst;
                    GVEmbassyFeesSearch.DataBind();                    
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(btnSearch, GetType(), "a", "alert('There Is No Record By This No. Of Visit.')", true);                    
                }
                Reset();
            }
        }

        public void SelectRadioButton()
        {
            if (rbtnlstSearch.SelectedValue == "0")
            {
                ddlCountryAll.SelectedValue = "0";
                ddlNoOfVisitAll.SelectedValue = "0";
                ddlVisaDurationAll.SelectedValue = "0";
                ddlVisaTypeAll.SelectedValue = "0";
                ddlProcessTimeAll.SelectedValue = "0";

                ddlCountry.SelectedValue = "0";
                ddlNoOfVisit.SelectedValue = "0";
                ddlVisaDuration.SelectedValue = "0";
                ddlVisaType.SelectedValue = "0";
                ddlProcessTime.SelectedValue = "0";
                tblAll.Visible = true;
                tblCountryBase.Visible = false;
                tblVisaTypeBase.Visible = false;
                tblVisaDurationBase.Visible = false;
                tblNoOfVisitBase.Visible = false;
                tblProcessTime.Visible = false;
                btnSearch.ValidationGroup = "a";
                Summary.ValidationGroup = "a";
            }

            else if (rbtnlstSearch.SelectedValue == "1")
            {
                ddlCountryAll.SelectedValue = "0";
                ddlNoOfVisitAll.SelectedValue = "0";
                ddlVisaDurationAll.SelectedValue = "0";
                ddlVisaTypeAll.SelectedValue = "0";
                ddlProcessTimeAll.SelectedValue = "0";

                ddlCountry.SelectedValue = "0";
                ddlNoOfVisit.SelectedValue = "0";
                ddlVisaDuration.SelectedValue = "0";
                ddlVisaType.SelectedValue = "0";
                ddlProcessTime.SelectedValue = "0";
                tblAll.Visible = false;
                tblCountryBase.Visible = true;
                tblVisaTypeBase.Visible = false;
                tblVisaDurationBase.Visible = false;
                tblNoOfVisitBase.Visible = false;
                tblProcessTime.Visible = false;
                btnSearch.ValidationGroup = "b";
                //Summary.ValidationGroup = "b";

            }
            else if (rbtnlstSearch.SelectedValue == "2")
            {
                ddlCountryAll.SelectedValue = "0";
                ddlNoOfVisitAll.SelectedValue = "0";
                ddlVisaDurationAll.SelectedValue = "0";
                ddlVisaTypeAll.SelectedValue = "0";
                ddlProcessTimeAll.SelectedValue = "0";

                ddlCountry.SelectedValue = "0";
                ddlNoOfVisit.SelectedValue = "0";
                ddlVisaDuration.SelectedValue = "0";
                ddlVisaType.SelectedValue = "0";
                ddlProcessTime.SelectedValue = "0";
                tblAll.Visible = false;
                tblCountryBase.Visible = false;
                tblVisaTypeBase.Visible = true;
                tblVisaDurationBase.Visible = false;
                tblNoOfVisitBase.Visible = false;
                tblProcessTime.Visible = false;
                btnSearch.ValidationGroup = "c";
                //Summary.ValidationGroup = "c";
            }
            else if (rbtnlstSearch.SelectedValue == "3")
            {
                ddlCountryAll.SelectedValue = "0";
                ddlNoOfVisitAll.SelectedValue = "0";
                ddlVisaDurationAll.SelectedValue = "0";
                ddlVisaTypeAll.SelectedValue = "0";
                ddlProcessTimeAll.SelectedValue = "0";

                ddlCountry.SelectedValue = "0";
                ddlNoOfVisit.SelectedValue = "0";
                ddlVisaDuration.SelectedValue = "0";
                ddlVisaType.SelectedValue = "0";
                ddlProcessTime.SelectedValue = "0";
                tblAll.Visible = false;
                tblCountryBase.Visible = false;
                tblVisaTypeBase.Visible = false;
                tblVisaDurationBase.Visible = true;
                tblNoOfVisitBase.Visible = false;
                tblProcessTime.Visible = false;
                btnSearch.ValidationGroup = "d";
                //Summary.ValidationGroup = "d";
            }
            else if (rbtnlstSearch.SelectedValue == "4")
            {
                ddlCountryAll.SelectedValue = "0";
                ddlNoOfVisitAll.SelectedValue = "0";
                ddlVisaDurationAll.SelectedValue = "0";
                ddlVisaTypeAll.SelectedValue = "0";
                ddlProcessTimeAll.SelectedValue = "0";

                ddlCountry.SelectedValue = "0";
                ddlNoOfVisit.SelectedValue = "0";
                ddlVisaDuration.SelectedValue = "0";
                ddlVisaType.SelectedValue = "0";
                ddlProcessTime.SelectedValue = "0";
                tblAll.Visible = false;
                tblCountryBase.Visible = false;
                tblVisaTypeBase.Visible = false;
                tblVisaDurationBase.Visible = false;
                tblNoOfVisitBase.Visible = true;
                tblProcessTime.Visible = false;
                btnSearch.ValidationGroup = "e";
                //Summary.ValidationGroup = "e";
            }

            else if (rbtnlstSearch.SelectedValue == "5")
            {
                ddlCountryAll.SelectedValue = "0";
                ddlNoOfVisitAll.SelectedValue = "0";
                ddlVisaDurationAll.SelectedValue = "0";
                ddlVisaTypeAll.SelectedValue = "0";
                ddlProcessTimeAll.SelectedValue = "0";

                ddlCountry.SelectedValue = "0";
                ddlNoOfVisit.SelectedValue = "0";
                ddlVisaDuration.SelectedValue = "0";
                ddlVisaType.SelectedValue = "0";
                ddlProcessTime.SelectedValue = "0";
                tblAll.Visible = false;
                tblCountryBase.Visible = false;
                tblVisaTypeBase.Visible = false;
                tblVisaDurationBase.Visible = false;
                tblNoOfVisitBase.Visible = false;
                tblProcessTime.Visible = true;
                btnSearch.ValidationGroup = "f";
                //Summary.ValidationGroup = "f";                
            }
        }

        public void Reset()
        {
            ddlCountry.SelectedValue = "0";
            ddlCountryAll.SelectedValue = "0";
            ddlNoOfVisit.SelectedValue = "0";
            ddlNoOfVisitAll.SelectedValue = "0";
            ddlProcessTime.SelectedValue = "0";
            ddlProcessTimeAll.SelectedValue = "0";
            ddlVisaDuration.SelectedValue = "0";
            ddlVisaDurationAll.SelectedValue = "0";
            ddlVisaType.SelectedValue = "0";
            ddlVisaTypeAll.SelectedValue = "0";           
        }
    }
}