using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.Common;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Web.Configuration;
using JSVisaTrackingWebApplication.Shared;

namespace JSVisaTrackingWebApplication
{
    public partial class EmbassyMaster1 : System.Web.UI.Page
    {
        #region Global Variable(s)

        BasePage basepage = new BasePage();        
        EmbsyMasterBusinessAccess embsyBal = new EmbsyMasterBusinessAccess();

        #endregion

        #region Protected Function(s)

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                basepage.BindDropDown(ddl_embsycountry, "Country", "CountryId", embsyBal.ReadCountry());
                basepage.BindDropDown(ddlCountry, "Country", "CountryId", embsyBal.ReadCountry());
                //Reset();
            }
        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            EmbMasterSummary.ValidationGroup = "a";

            String Country = "";
            List <Embsy> lstEmbassy = embsyBal.Gridbind();
            for (int i = 0; i < lstEmbassy.Count; i++)
            {
                if (ddl_embsycountry.SelectedItem.Text == lstEmbassy[i].Country)
                {
                    Country = lstEmbassy[i].Country;
                    break;
                }
            }

            if (ddl_embsycountry.SelectedItem.Text == Country)
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "a", "alert('Embassy Country Is Already Exist.')", true);
            }
            else
            {
                Embsy embsy = new Embsy();

                embsy.Country = ddl_embsycountry.SelectedItem.Value;
                if (rbtnlst_visadurationlist.SelectedValue == "1")
                {
                    embsy.DurationDescription = "Y";
                }
                else
                {
                    embsy.DurationDescription = "N";
                }

                if (rdblst_processtime.SelectedValue == "1")
                {
                    embsy.ProcessTimeDesc = "Y";
                }
                else
                {
                    embsy.ProcessTimeDesc = "N";
                }
                embsy.VfsBlsFee = Convert.ToDecimal(txt_vfs_bls.Text);
                embsy.TokenFee = Convert.ToDecimal(txt_tokenfee.Text);
                embsy.AttastationFee = Convert.ToDecimal(txt_attentfee.Text);
                embsy.HandlingFee = Convert.ToDecimal(txt_handlingfee.Text);
                embsyBal.Insert1(embsy);
                BindGrid();
                ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "a", "alert('Record Saved Successfully.')", true);
            }
            Reset();
        }       

        protected void gv_embsymaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            MasterId = 0;
            int id = Convert.ToInt32(e.CommandArgument);

            this.MasterId = id;

            if (e.CommandName == "cmdedit")
            {
                ddlCountry.SelectedValue = "0";
                List<Embsy> lst = embsyBal.Edit1(id);

                ddl_embsycountry.SelectedValue = lst[0].CountryId.ToString();
                ddl_embsycountry.Enabled = false;

                if (lst[0].DurationDescription.ToString() == "Y" || lst[0].DurationDescription.ToString() == "y")
                {
                    rbtnlst_visadurationlist.SelectedValue = "1";
                }
                else
                {
                    rbtnlst_visadurationlist.SelectedValue = "2";
                }

                if (lst[0].ProcessTimeDesc.ToString() == "Y" || lst[0].ProcessTimeDesc.ToString() == "y")
                {
                    rdblst_processtime.SelectedValue = "1";
                }
                else
                {
                    rdblst_processtime.SelectedValue = "2";
                }
                
                txt_vfs_bls.Text = lst[0].VfsBlsFee.ToString();
                txt_tokenfee.Text = lst[0].TokenFee.ToString();
                txt_attentfee.Text = lst[0].AttastationFee.ToString();
                txt_handlingfee.Text = lst[0].HandlingFee.ToString();

                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }
            else if (e.CommandName == "cmddel")
            {
                embsyBal.Delete1(id);
                ScriptManager.RegisterClientScriptBlock(this.Page, GetType(), "a", "alert('Record Deleted Successfully.')", true);
                Reset();
            }

            BindGrid();
        }
        
        protected void btnUpdate_Click1(object sender, EventArgs e)
        {           
            //int id = Convert.ToInt32(ViewState["id"]);

            Embsy embsy = new Embsy();
            embsy.EmbsyMasterId = this.MasterId;
            embsy.Country = ddl_embsycountry.SelectedValue;

            if (rbtnlst_visadurationlist.SelectedValue == "1")
            {
                embsy.DurationDescription = "Y";
            }
            else
            {
                embsy.DurationDescription = "N";
            }

            if (rdblst_processtime.SelectedValue == "1")
            {
                embsy.ProcessTimeDesc = "Y";
            }
            else
            {
                embsy.ProcessTimeDesc = "N";
            }            
            embsy.VfsBlsFee = Convert.ToDecimal(txt_vfs_bls.Text);
            embsy.TokenFee = Convert.ToDecimal(txt_tokenfee.Text);
            embsy.AttastationFee = Convert.ToDecimal(txt_attentfee.Text);
            embsy.HandlingFee = Convert.ToDecimal(txt_handlingfee.Text);
            embsyBal.Update1(embsy);
            BindGrid();
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            ddl_embsycountry.Enabled = true;
            ScriptManager.RegisterClientScriptBlock(btnUpdate, GetType(), "a", "alert('Record Updated Successfully.')", true);
            Reset();
        }       
                      
        protected void gv_embsymaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_embsymaster.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            Reset();
        }

        protected void rbtnlst_visadurationlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtnlst_visadurationlist.SelectedValue == "1")
            {
                rdblst_processtime.SelectedValue = "1";
            }
            else if (rbtnlst_visadurationlist.SelectedValue == "2")
            {
                rdblst_processtime.SelectedValue = "2";
            }
        }

        protected void rdblst_processtime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdblst_processtime.SelectedValue == "1")
            {
                rbtnlst_visadurationlist.SelectedValue = "1";
            }
            else if (rdblst_processtime.SelectedValue == "2")
            {
                rbtnlst_visadurationlist.SelectedValue = "2";
            }
        }

        protected void lknbtnSearch_Click(object sender, EventArgs e)
        {
            EmbMasterSummary.ValidationGroup = "search";
            Int32 CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
            List<Embsy> lst = new List<Embsy>();
            lst = embsyBal.ReadEmbassyMasterByCountryId(CountryId);
            if (lst.Count > 0)
            {
                gv_embsymaster.DataSource = lst;
                gv_embsymaster.DataBind();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(lknbtnSearch, GetType(), "a", "alert('No Record Of This Country.')", true);                
            }
            Reset();
        }

        #endregion

        #region Private Functions

        public void BindGrid()
        {
            List<Embsy> lst = new List<Embsy>();
            Session["ListEmbassy"] = lst;
            lst = embsyBal.Gridbind();
            if (lst.Count > 0)
            {
                gv_embsymaster.DataSource = lst;
                gv_embsymaster.DataBind();
            }
        }       

        public void Reset()
        {
            ddl_embsycountry.SelectedValue = "0";
            rdblst_processtime.SelectedValue = "1";
            rbtnlst_visadurationlist.SelectedValue = "1";
            txt_tokenfee.Text = string.Empty;
            txt_handlingfee.Text = string.Empty;
            txt_vfs_bls.Text = string.Empty;
            txt_attentfee.Text = string.Empty;
            ddl_embsycountry.Enabled = true;
            ddlCountry.SelectedValue = "0";
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }

        #endregion

        #region Public Properties
        
        public int MasterId
        {
            get
            {
                return Convert.ToInt32(ViewState["id"]);
            }
            set
            {
                ViewState["id"] = value;
            }
        }
        #endregion
        
    }
}