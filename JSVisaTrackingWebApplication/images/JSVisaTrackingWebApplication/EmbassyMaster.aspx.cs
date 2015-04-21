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
        VisaRequirementBusinessAccess BL = new VisaRequirementBusinessAccess();
        EmbsyMasterBusinessAccess embsyBal = new EmbsyMasterBusinessAccess();

        #endregion

        #region Protected Function(s)

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                basepage.BindDropDown(ddl_embsycountry, "CountryName", "COUNTRY_ID", BL.ReadCountry());
            }
        }
        
        protected void btnSave_Click(object sender, EventArgs e)
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
            ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "a", "alert('Record Saved successfully...')", true);
            Reset();
            
        }       

        protected void gv_embsymaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            MasterId = 0;

            int id = Convert.ToInt32(e.CommandArgument);

            this.MasterId = id;

            if (e.CommandName == "cmdedit")
            {
                List<Embsy> lst = embsyBal.Edit1(id);

                ddl_embsycountry.SelectedValue = lst[0].CountryId.ToString();
                if (lst[0].DurationDescription.ToString() == "Y")
                {
                    rbtnlst_visadurationlist.SelectedValue = "1";
                }
                else
                {
                    rbtnlst_visadurationlist.SelectedValue = "2";
                }

                if (lst[0].ProcessTimeDesc.ToString() == "Y")
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
            ScriptManager.RegisterClientScriptBlock(btnUpdate, GetType(), "a", "alert('Record Updated successfully...')", true);
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

        #endregion

        #region Private Functions

        public void BindGrid()
        {
            List<Embsy> lst = new List<Embsy>();
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