using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data.Common;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;

namespace JSVisaTrackingWebApplication
{
    public partial class BillRegisterInfoShow : System.Web.UI.Page
    {
        #region Global Variable(s)

        Decimal totalVisa = 0;
        Decimal totalAttestation = 0;
        Decimal totalToken = 0;
        Decimal totalVfs = 0;
        Decimal totalHandling = 0;
        Decimal totalCourior = 0;
        Decimal totalDelivery = 0;
        Decimal totalConvenience = 0;
        Decimal totalUrgent = 0;
        Decimal totalDraft = 0;
        Decimal totalInsurance = 0;
        Decimal totalOther = 0;
        Decimal totalService = 0;
        Decimal totalserviceTax = 0;
        Decimal totalAmount = 0;

        //Int64 grandVisa = 0;
        //Int64 grandAttestation = 0;
        //Int64 grandToken = 0;
        //Int64 grandVfs = 0;
        //Int64 grandHandling = 0;
        //Int64 grandCourior = 0;
        //Int64 grandDelivery = 0;
        //Int64 grandConvenience = 0;
        //Int64 grandUrgent = 0;
        //Int64 grandDraft = 0;
        //Int64 grandInsurance = 0;
        //Int64 grandOther = 0;
        //Int64 grandService = 0;
        //Int64 grandserviceTax = 0;
        //Int64 grandAmount = 0;
        BillRegisterBusinessAccess billRegisterBal = new BillRegisterBusinessAccess();
        #endregion

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void gv_billRegister_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.HorizontalAlign = HorizontalAlign.Right;

                Label lbl_visacharge = (Label)e.Row.FindControl("lbl_visacharge");
                Label lbl_attestation = (Label)e.Row.FindControl("lbl_attestation");
                Label lbl_token = (Label)e.Row.FindControl("lbl_token");
                Label lbl_vfs = (Label)e.Row.FindControl("lbl_vfs");
                Label lbl_handling = (Label)e.Row.FindControl("lbl_handling");
                Label lbl_courier = (Label)e.Row.FindControl("lbl_courier");
                Label lbl_Delivery = (Label)e.Row.FindControl("lbl_Delivery");
                Label lbl_Convenience = (Label)e.Row.FindControl("lbl_Convenience");
                Label lbl_Urgent = (Label)e.Row.FindControl("lbl_Urgent");
                Label lbl_Draft = (Label)e.Row.FindControl("lbl_Draft");
                Label lbl_Insurance = (Label)e.Row.FindControl("lbl_Insurance");
                Label lbl_OtherCharges = (Label)e.Row.FindControl("lbl_OtherCharges");
                Label lbl_ServiceTax = (Label)e.Row.FindControl("lbl_ServiceTax");
                Label lbl_ServiceCharge = (Label)e.Row.FindControl("lbl_ServiceCharge");
                Label lbl_Amount = (Label)e.Row.FindControl("lbl_Amount");

                Decimal visa = Convert.ToDecimal(lbl_visacharge.Text);
                Decimal attestation = Convert.ToDecimal(lbl_attestation.Text);
                Decimal token = Convert.ToDecimal(lbl_token.Text);
                Decimal Vfs = Convert.ToDecimal(lbl_vfs.Text);
                Decimal handling = Convert.ToDecimal(lbl_handling.Text);
                Decimal courior = Convert.ToDecimal(lbl_courier.Text);
                Decimal delivery = Convert.ToDecimal(lbl_Delivery.Text);
                Decimal convenience = Convert.ToDecimal(lbl_Convenience.Text);
                Decimal urgent = Convert.ToDecimal(lbl_Urgent.Text);
                Decimal draft = Convert.ToDecimal(lbl_Draft.Text);
                Decimal insurance = Convert.ToDecimal(lbl_Insurance.Text);
                Decimal otherCh = Convert.ToDecimal(lbl_OtherCharges.Text);
                Decimal servive = Convert.ToDecimal(lbl_ServiceCharge.Text);
                Decimal serviceTax = Convert.ToDecimal(lbl_ServiceTax.Text);
                Decimal amount = Convert.ToDecimal(lbl_Amount.Text);

                totalVisa += visa;
                totalAttestation += attestation;
                totalToken += token;
                totalVfs += Vfs;
                totalHandling += handling;
                totalCourior += courior;
                totalDelivery += delivery;
                totalConvenience += convenience;
                totalUrgent += urgent;
                totalDraft += draft;
                totalInsurance += insurance;
                totalOther += otherCh;
                totalService += servive;
                totalserviceTax += serviceTax;
                totalAmount += amount;

                //for (int i = 0; i < gv_billRegister.Controls.Count; i++)
                //{
                //    grandVisa += visa;
                //    grandAttestation += attestation;
                //    grandToken += token;
                //    grandVfs += Vfs;
                //    grandHandling += handling;
                //    grandCourior += courior;
                //    grandDelivery += delivery;
                //    grandConvenience += convenience;
                //    grandUrgent += urgent;
                //    grandDraft += draft;
                //    grandInsurance += insurance;
                //    grandOther += otherCh;
                //    grandService += servive;
                //    grandserviceTax += serviceTax;
                //    grandAmount += amount;
                //}
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].ColumnSpan = 5;
                //e.Row.Cells[0].Text = "Page Total";
                e.Row.Cells[0].Font.Bold = true;
                //e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells.RemoveAt(4);
                e.Row.Cells.RemoveAt(3);
                e.Row.Cells.RemoveAt(2);
                e.Row.Cells.RemoveAt(1);

                Label lblTotalvisa = (Label)e.Row.FindControl("lblTotalvisa");
                Label lblTotalAttestation = (Label)e.Row.FindControl("lblTotalAttestation");
                Label lblTotalToken = (Label)e.Row.FindControl("lblTotalToken");
                Label lblTotalVFS = (Label)e.Row.FindControl("lblTotalVFS");
                Label lblTotalHandling = (Label)e.Row.FindControl("lblTotalHandling");
                Label lblTotalCourior = (Label)e.Row.FindControl("lblTotalCourior");
                Label lblTotalDelivery = (Label)e.Row.FindControl("lblTotalDelivery");
                Label lblTotalConvenience = (Label)e.Row.FindControl("lblTotalConvenience");
                Label lblTotalUrgent = (Label)e.Row.FindControl("lblTotalUrgent");
                Label lblTotalDraft = (Label)e.Row.FindControl("lblTotalDraft");
                Label lblTotalInsurance = (Label)e.Row.FindControl("lblTotalInsurance");
                Label lblTotalOther = (Label)e.Row.FindControl("lblTotalOther");
                Label lblTotalService = (Label)e.Row.FindControl("lblTotalService");
                Label lblTotalServiceTax = (Label)e.Row.FindControl("lblTotalServiceTax");
                Label lblTotalAmount = (Label)e.Row.FindControl("lblTotalAmount");

                //Label lblGrandvisa = (Label)e.Row.FindControl("lblGrandvisa");
                //Label lblGrandAttestation = (Label)e.Row.FindControl("lblGrandAttestation");
                //Label lblGrandToken = (Label)e.Row.FindControl("lblGrandToken");
                //Label lblGrandVFS = (Label)e.Row.FindControl("lblGrandVFS");
                //Label lblGrandHandling = (Label)e.Row.FindControl("lblGrandHandling");
                //Label lblGrandCourior = (Label)e.Row.FindControl("lblGrandCourior");
                //Label lblGrandDelivery = (Label)e.Row.FindControl("lblGrandDelivery");
                //Label lblGrandConvenience = (Label)e.Row.FindControl("lblGrandConvenience");
                //Label lblGrandUrgent = (Label)e.Row.FindControl("lblGrandUrgent");
                //Label lblGrandDraft = (Label)e.Row.FindControl("lblGrandDraft");
                //Label lblGrandInsurance = (Label)e.Row.FindControl("lblGrandInsurance");
                //Label lblGrandOther = (Label)e.Row.FindControl("lblGrandOther");
                //Label lblGrandService = (Label)e.Row.FindControl("lblGrandService");
                //Label lblGrandServiceTax = (Label)e.Row.FindControl("lblGrandServiceTax");
                //Label lblGrandAmount = (Label)e.Row.FindControl("lblGrandAmount");

                lblTotalvisa.Text = totalVisa.ToString();
                lblTotalAttestation.Text = totalAttestation.ToString();
                lblTotalToken.Text = totalToken.ToString();
                lblTotalVFS.Text = totalVfs.ToString();
                lblTotalHandling.Text = totalHandling.ToString();
                lblTotalCourior.Text = totalCourior.ToString();
                lblTotalDelivery.Text = totalDelivery.ToString();
                lblTotalConvenience.Text = totalConvenience.ToString();
                lblTotalUrgent.Text = totalUrgent.ToString();
                lblTotalDraft.Text = totalDraft.ToString();
                lblTotalInsurance.Text = totalInsurance.ToString();
                lblTotalOther.Text = totalOther.ToString();
                lblTotalService.Text = totalService.ToString();
                lblTotalServiceTax.Text = totalserviceTax.ToString();
                lblTotalAmount.Text = totalAmount.ToString();

                //lblGrandvisa.Text = grandVisa.ToString();
                //lblGrandAttestation.Text = grandAttestation.ToString();
                //lblGrandToken.Text = grandToken.ToString();
                //lblGrandVFS.Text = grandVfs.ToString();
                //lblGrandHandling.Text = grandHandling.ToString();
                //lblGrandCourior.Text = grandCourior.ToString();
                //lblGrandDelivery.Text = grandDelivery.ToString();
                //lblGrandConvenience.Text = grandConvenience.ToString();
                //lblGrandUrgent.Text = grandUrgent.ToString();
                //lblGrandDraft.Text = grandDraft.ToString();
                //lblGrandInsurance.Text = grandInsurance.ToString();
                //lblGrandOther.Text = grandOther.ToString();
                //lblGrandService.Text = grandService.ToString();
                //lblGrandServiceTax.Text = grandserviceTax.ToString();
                //lblGrandAmount.Text = grandAmount.ToString();
            }
        }

        protected void gv_billRegister_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView objGridView = (GridView)sender;
                GridViewRow objgridviewrow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell objtablecell = new TableCell();

                #region Merge cells

                AddMergedCells(objgridviewrow, objtablecell, 20, "Bill Register Report", System.Drawing.Color.White.Name);
                objGridView.Controls[0].Controls.AddAt(0, objgridviewrow);

                #endregion
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=BillRegisterInformationReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.xls";

            StringBuilder sb = new StringBuilder();
            StringWriter stringWrite = new StringWriter(sb);
            HtmlTextWriter htm = new HtmlTextWriter(stringWrite);
            gv_billRegister.AllowPaging = false;
            //grid_search.Columns.RemoveAt(8);

            BindGrid();
            gv_billRegister.HeaderRow.BackColor = System.Drawing.Color.White;
            gv_billRegister.FooterRow.BackColor = System.Drawing.Color.White;
            gv_billRegister.FooterRow.ForeColor = System.Drawing.Color.Black;

            //gvSample is Gridview server control

            gv_billRegister.RenderControl(htm);
            Response.Write(stringWrite);
            Response.End();

            btnExport.Visible = false;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // base.VerifyRenderingInServerForm(control);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("BillRegister.aspx");
        }

        #endregion

        #region Public Methods

        public void BindGrid()
        {            
            if (Request.QueryString["List"] != null)
            {
                List<Remielsoft.JetSave.DomianObjectModel.BillRegister> lst = (List<Remielsoft.JetSave.DomianObjectModel.BillRegister>)Session["List"];

                gv_billRegister.DataSource = lst;
                gv_billRegister.DataBind();
            }
        }

        public void AddMergedCells(GridViewRow objgridviewrow, TableCell objtablecell, int colspan, string celltext, string backcolor)
        {
            objtablecell = new TableCell();
            objtablecell.Text = celltext;
            objtablecell.ColumnSpan = colspan;
            objtablecell.Style.Add("background-color", backcolor);
            objtablecell.Font.Bold = true;
            objtablecell.ForeColor = System.Drawing.Color.Black;
            objtablecell.HorizontalAlign = HorizontalAlign.Center;
            objgridviewrow.Cells.Add(objtablecell);
        }

        #endregion        

        
    }
}