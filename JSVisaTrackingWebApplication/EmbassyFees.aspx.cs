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
    public partial class EmbassyFees : System.Web.UI.Page
    {
        #region Global Variable(s)

        EmbsyFeeBusinessAccess embsyFeeBusinessAccess = new EmbsyFeeBusinessAccess();
        VisaRequirementBusinessAccess BL = new VisaRequirementBusinessAccess();
        EmbsyMasterBusinessAccess embsyBal = new EmbsyMasterBusinessAccess();
        BasePage basepage;

        #endregion

        #region Protected Function(s)

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                basepage = new BasePage();

                basepage.BindDropDown(ddl_no_ofvisit, "NoOfVisit", "VisaTypeTwoId", embsyFeeBusinessAccess.Read());
                basepage.BindDropDown(ddl_visaduration, "DurationDescription", "VisaDurationId", embsyFeeBusinessAccess.BindVisaDuraion());
                basepage.BindDropDown(ddl_processtime, "ProcessTimeDesc", "ProcessTimeId", embsyFeeBusinessAccess.BindProcessTime());
                basepage.BindDropDown(ddl_embsycountry, "Country", "CountryId", embsyFeeBusinessAccess.ReadEmbassyFeesCountry());
                basepage.BindDropDown(ddlCountry, "Country", "CountryId", embsyBal.ReadCountry());
                basepage.BindDropDown(ddl_visatype, "DESCRIPTION_ONE", "TYPE_ONE_ID", BL.ReadVisaType());
                BindGrid();
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            EmbFeeSummary.ValidationGroup = "a";

            Embsy embsy = new Embsy();
            GetMasterId2();
            int masterid = Convert.ToInt32(ViewState["masterid"]);
            //embsyFeeBusinessAccess.GetId1(countryname);
            embsy.VisaType = ddl_visatype.SelectedItem.Value;
            embsy.NoOfVisit = ddl_no_ofvisit.SelectedItem.Value;
            embsy.Fees = Convert.ToDecimal(txt_fees.Text);
            embsy.DurationDescription = ddl_visaduration.SelectedItem.Value;
            embsy.ProcessTimeDesc = ddl_processtime.SelectedItem.Value;
            embsyFeeBusinessAccess.InsertEmbsyFee(embsy, masterid);

            ScriptManager.RegisterClientScriptBlock(btn_save, GetType(), "a", "alert('Record Saved Successfully.')", true);

            BindGrid();
            reset();

        }

        protected void gv_embsyfees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            ViewState["Id"] = id;
            if (e.CommandName == "cmdedit")
            {
                btn_save.Visible = false;
                btn_update.Visible = true;
                ddlCountry.SelectedValue = "0";

                List<Embsy> lst = embsyFeeBusinessAccess.Edit1(id);


                ddl_embsycountry.SelectedValue = lst[0].CountryId.ToString();
                ddl_visatype.SelectedValue = lst[0].VisaTypeOneId.ToString();
                ddl_no_ofvisit.SelectedValue = lst[0].VisaTypeTwoId.ToString();
                txt_fees.Text = lst[0].Fees.ToString();
                ddl_visaduration.SelectedValue = lst[0].VisaDurationId.ToString();
                ddl_processtime.SelectedValue = lst[0].ProcessTimeId.ToString();
            }
            else if (e.CommandName == "cmddel")
            {
                embsyFeeBusinessAccess.Delete1(id);
                ScriptManager.RegisterClientScriptBlock(this.Page, GetType(), "a", "alert('Record Deleted Successfully.')", true);
                reset();
            }
            BindGrid();
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(ViewState["Id"]);
            Embsy embsy = new Embsy();
            GetMasterId2();
            embsy.EmbsyMasterId = Convert.ToInt32(ViewState["masterid"]);
            embsy.VisaType = ddl_visatype.SelectedItem.Value;
            embsy.NoOfVisit = ddl_no_ofvisit.SelectedItem.Value;
            embsy.Fees = Convert.ToDecimal(txt_fees.Text);
            embsy.DurationDescription = ddl_visaduration.SelectedItem.Value;
            embsy.ProcessTimeDesc = ddl_processtime.SelectedItem.Value;
            embsyFeeBusinessAccess.Update1(Id, embsy);
            BindGrid();

            ScriptManager.RegisterClientScriptBlock(btn_update, GetType(), "a", "alert('Record Updated Successfully.')", true);

            btn_save.Visible = true;
            btn_update.Visible = false;
            reset();
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            reset();
        }

        protected void gv_embsyfees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_embsyfees.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        #endregion

        #region Private Method(s)

        public void BindGrid()
        {
            List<Embsy> lst = new List<Embsy>();
            lst = embsyFeeBusinessAccess.GridBind1();
            if (lst.Count > 0)
            {
                gv_embsyfees.DataSource = lst;
                gv_embsyfees.DataBind();
            }
        }

        public void reset()
        {
            ddlCountry.SelectedValue = "0";
            ddl_embsycountry.SelectedValue = "0";
            ddl_no_ofvisit.SelectedValue = "0";
            ddl_processtime.SelectedValue = "0";
            ddl_visaduration.SelectedValue = "0";
            ddl_visatype.SelectedValue = "0";
            txt_fees.Text = string.Empty;
            btn_save.Visible = true;
            btn_update.Visible = false;
        }

        #region ReadEmbsyMasterId
        public void GetMasterId2()
        {
            Int32 countryid = Convert.ToInt32(ddl_embsycountry.SelectedItem.Value);
            // ViewState["masterid"] = embsyFeeBusinessAccess.GetId1(country);
            List<Embsy> lst = new List<Embsy>();
            lst = embsyFeeBusinessAccess.GetId1(countryid);
            Int32 id = lst[0].EmbsyMasterId;
            ViewState["masterid"] = id;
        }
        #endregion

        protected void lknbtnSearch_Click(object sender, EventArgs e)
        {
            EmbFeeSummary.ValidationGroup = "search";

            Int32 CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
            List<Embsy> lst = new List<Embsy>();
            lst = embsyFeeBusinessAccess.BindGridByCountryId(CountryId);
            if (lst.Count > 0)
            {
                gv_embsyfees.DataSource = lst;
                gv_embsyfees.DataBind();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(lknbtnSearch, GetType(), "a", "alert('No Record Of This Country.')", true);
            }
            reset();
        }

        #region ddl_no_ofvisit selectedIndexChange change the Fees Value

        //protected void ddl_no_ofvisit_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    List<Embsy> demodom = new List<Embsy>();
        //    string novisit = ddl_no_ofvisit.SelectedItem.Text;
        //    demodom = embsyFeebal.ddl_select_change1(novisit);
        //    txt_fees.Text = demodom[0].Fees.ToString();
        //}

        #endregion

        #endregion
    }
}