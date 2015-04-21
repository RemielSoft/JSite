using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.Globalization;
namespace JSVisaTrackingWebApplication
{
    public partial class Misla_charges : System.Web.UI.Page
    {
        MislaBal obbal = new MislaBal();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindggrd();
                btns.Visible = true;
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            MislaDom obdom = new MislaDom();
            obdom.Description = txtDescription.Text;
            obdom.Amount = float.Parse(txtAmount.Text, CultureInfo.InvariantCulture.NumberFormat);
            obdom.Per_consignment = (drpvisa.SelectedValue).ToString();
            obdom.ServiceTax = CheckService.Checked.ToString();
            obdom.Mandatory = CheckMandatory.Checked.ToString();
            obbal.insert(obdom);
            Bindggrd();
            empty();

        }
        public void Bindggrd()
        {
            Grdm.DataSource = obbal.Bind();
            Grdm.DataBind();
        }

        protected void Grdm_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            btnupdate.Visible = true;
            BtnAdd.Visible = false;
            int Id = Convert.ToInt32(e.CommandArgument);
            ViewState["Id"] = Id;
            if (e.CommandName == "cmdedit")
            {
                List<MislaDom> lstR = obbal.ReadId(Id);
                txtDescription.Text = lstR[0].Description.ToString();
                txtAmount.Text = lstR[0].Amount.ToString();
                drpvisa.Text = lstR[0].Per_consignment.ToString();
                // CheckService.
                if (lstR[0].Mandatory.ToString() == "True")
                {

                    CheckMandatory.Checked = true;
                }
                else
                    CheckMandatory.Checked = false;
                if (lstR[0].ServiceTax.ToString() == "True")
                {

                    CheckService.Checked = true;

                }
                else
                    CheckService.Checked = false;
            }
                if (e.CommandName == "cmddelete")
                {
                    obbal.dellete(Id);
                    Bindggrd();
                }

            }
        
        public void empty()
        {
            txtAmount.Text = "";
            txtDescription.Text = "";
            drpvisa.SelectedValue = "--Select--";
            CheckMandatory.Checked = false;
            CheckService.Checked = false;

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(ViewState["Id"]);
            MislaDom obdomupdate = new MislaDom();
            //obdomupdate.Id = Id;
            obdomupdate.Description = txtDescription.Text;
            obdomupdate.Amount = float.Parse(txtAmount.Text, CultureInfo.InvariantCulture.NumberFormat);
            obdomupdate.Per_consignment = drpvisa.SelectedValue.ToString();
            obdomupdate.ServiceTax = CheckService.Checked.ToString();
            obdomupdate.Mandatory = CheckMandatory.Checked.ToString();
            obbal.update1(Id, obdomupdate);
            Bindggrd();
            empty();
            BtnAdd.Visible = true;
            btnupdate.Visible = false;

        }

        protected void Grdm_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grdm.PageIndex = e.NewPageIndex;
            Bindggrd();
        }

        protected void btns_Click(object sender, EventArgs e)
        {
            List<MislaDom> ll = new List<MislaDom>();
            ///String Description=txtsearch.Text;
            ll = obbal.serch(txtsearch.Text);
            txtDescription.Text = ll[0].Description;
            txtAmount.Text = ll[0].Amount.ToString();
            search();
        }
        public void search()
        {
            Grdm.DataSource = obbal.serch(txtsearch.Text);
            Grdm.DataBind();
        }
       
    }
}