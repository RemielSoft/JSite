using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using JSVisaTrackingWebApplication.Shared;
using System.Configuration;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using System.Drawing;

namespace JSVisaTrackingWebApplication
{
    public partial class ViewConsignmentList : BasePage
    {
        BasePage basePage = new BasePage();
        UserBAL userBal = new UserBAL();
        AgentBAL agentBal = new AgentBAL();
        VisaRequirementBusinessAccess BL = new VisaRequirementBusinessAccess();
        List<Consignment> lstConsignment;
        ConsignmentBusinessAccess consignmentBal = new ConsignmentBusinessAccess();
        string PaxName = null;
        string PaxPassportNo = null;
        int consignmentNo = 0;
        string corporatename = null;
        string deliveryStatus = "";
        public List<Consignment> _consignments
        {
            get
            {
                if (ViewState["Consignments"] != null)
                {
                    return (List<Consignment>)(ViewState["Consignments"]);
                }
                return new List<Consignment>();

            }
            set { ViewState["Consignments"] = value; }
        }





        // Int32 DaysCount = Convert.ToInt32(ConfigurationManager.AppSettings["No_Of_Days"]);
        #region proteted methods..
        protected void Page_Load(object sender, EventArgs e)
        {
            int LocId = 0;
            int userId = basePage.LoggedInUser.UserTypeId;
            FormsIdentity id = HttpContext.Current.User.Identity as FormsIdentity;
            FormsAuthenticationTicket ticket = id.Ticket;
            string userData = ticket.UserData;

            if (!IsPostBack)
            {
                btnExport.Visible = false;

                if (basePage.LoggedInUser.UserLocation != null)
                {
                    LocId = basePage.LoggedInUser.UserLocation.LocationId;
                }
                BindCountry();
                // basePage.BindDropDown(ddlcountry, "CountryName", "COUNTRY_ID", BL.ReadCountry());

                if (userId == Convert.ToInt32(UserType.Admin))
                {
                    var listAgent = agentBal.ReadAgent(null);
                    ddlAgent.DataSource = listAgent;
                    ddlAgent.DataTextField = "AgentName";
                    ddlAgent.DataValueField = "AgentId";
                    ddlAgent.DataBind();
                    ddlAgent.Items.Insert(0, new ListItem("--Select--", "0"));
                    ddlAgent.SelectedValue = "0";
                    ddlAgent.Enabled = true;
                }
                else
                {
                    var listAgent = agentBal.ReadAgent(basePage.LoggedInUser.AgentId);
                    ddlAgent.DataSource = listAgent;
                    ddlAgent.DataTextField = "AgentName";
                    ddlAgent.DataValueField = "AgentId";
                    ddlAgent.DataBind();
                    ddlAgent.SelectedValue = basePage.LoggedInUser.AgentId.ToString();
                    //  ddlAgent.Enabled = false;
                }

            }
            ddlAgent.Enabled = true;
            




        }

        public void BindCountry()
        {
            var lst = BL.ReadCountry();
            ddlcountry.DataSource = lst;
            ddlcountry.DataTextField = "CountryName";
            ddlcountry.DataValueField = "COUNTRY_ID";
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, new ListItem("--Select--", "0"));
            //ddlcountry.SelectedValue = "0";
        }
        protected void gridViewConsignment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            btnExport.Visible = false;
            gridViewConsignment.PageIndex = e.NewPageIndex;
            BindConsignmentGrid();
        }
        protected void gridViewConsignment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ConsignmentBusinessAccess consignmentBal = new ConsignmentBusinessAccess();
            if (e.CommandName == "Find")
            {
                FindRecordByPassprtNo();

            }

            // int id = Convert.ToInt32(e.CommandArgument);
            //ViewState["Id"] = id;
            //if (e.CommandName == "cmdEdit")
            //{
            //    string Id1 = "cons";
            //    Response.Redirect("AddConsignment.aspx?ConsignmentId=" + id + "&cons=" + Id1);

            //}
            //else if (e.CommandName == "cmdViewCon")
            //{
            //    string Id1 = "view";
            //    Response.Redirect("AddConsignment.aspx?ConsignmentId=" + id + "&cons=" + Id1);
            //}
            //else if (e.CommandName == "cmdEditPax")
            //{
            //    string Id1 = "pax";
            //    Response.Redirect("AddConsignment.aspx?PaxId=" + id + "&cons=" + Id1);

            //}
            //else if (e.CommandName == "cmdEditMailremark")
            //{
            //    string Id1 = "mail";
            //    Response.Redirect("AddConsignment.aspx?ConsignmentId=" + id + "&cons=" + Id1);
            //}
            //else if (e.CommandName == "cmdDelete")
            //{
            //    consignmentBal.DeleteConsignment(id);


            //}
            BindConsignmentGrid();
            // Clear();
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            int userId = basePage.LoggedInUser.UserTypeId;
            //ddlcountry.SelectedValue = 
            BindConsignmentGrid();
        }
        protected void gridViewConsignment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://www.google.com");
        }


        protected void gridViewConsignment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvChildGrid = (GridView)e.Row.FindControl("gvChildGrid");
                ConsignmentBusinessAccess conbal = new ConsignmentBusinessAccess();
                Label lblConsignmentId = (Label)e.Row.FindControl("lblConsignmentId");
                int ConsignmentId = Convert.ToInt32(lblConsignmentId.Text);

                int locationId = 0;
                if (basePage.LoggedInUser.UserLocation != null)
                {
                    locationId = basePage.LoggedInUser.UserLocation.LocationId;
                }
                int usertype = basePage.LoggedInUser.UserTypeId;
                List<Pax> lstpax = null;
                if (usertype == Convert.ToInt32(UserType.Admin) || usertype == Convert.ToInt32(UserType.SuperAdmin))
                {
                    locationId = 0;
                    lstpax = conbal.ReadDataByPaxsConsignmentId(ConsignmentId, locationId);
                }
                else
                {
                    lstpax = conbal.ReadDataByPaxsConsignmentId(ConsignmentId, locationId);
                }
                gvChildGrid.DataSource = lstpax;
                gvChildGrid.DataBind();
                // gridViewConsignment.Columns[1].Visible = false;
            }
        }

        #endregion

        public List<Consignment> readGrid()
        {
            return null;
        }

        //public override void VerifyRenderingInServerForm(Control control)
        //{
        //    //base.VerifyRenderingInServerForm(control);
        //}
        public void BindConsignmentGrid()
        {
            if (txtfrmdate.Text == "" && txttodate.Text == "" && txtConsignmentNosearch.Text == "" && drpdwnStatus.SelectedIndex == 0 && ddlAgent.SelectedValue == "0" && ddlcountry.SelectedValue == "0")
            {
                ShowMessageWithUpdatePanel("Please Select Any Option To Search.");
                btnExport.Visible = false;
            }
            else
            {
                int locationId = 0;
                if (basePage.LoggedInUser.UserLocation != null)
                {
                    locationId = basePage.LoggedInUser.UserLocation.LocationId;
                }
                int usertype = basePage.LoggedInUser.UserTypeId;

                //ResetViewState();

                // List<Consignment> lstConsignment;

                if (!string.IsNullOrEmpty(txtfrmdate.Text))
                {
                    FromDate = Convert.ToDateTime(txtfrmdate.Text);
                }
                if (!string.IsNullOrEmpty(txttodate.Text))
                {
                    ToDate = Convert.ToDateTime(txttodate.Text);
                }

                if (!string.IsNullOrEmpty(txtConsignmentNosearch.Text))
                {
                    consignmentNo = Convert.ToInt32(txtConsignmentNosearch.Text);
                }
                if (ddlcountry.SelectedValue == "0" || ddlcountry.SelectedValue == "")
                {
                    countryId = 0;
                }
                else
                {
                    countryId = Convert.ToInt32(ddlcountry.SelectedValue);
                }
                if (ddlAgent.SelectedValue == "0" || ddlAgent.SelectedValue == "")
                {
                    //agentId = Session["agentId"];
                }
                else
                {
                    agentId = Convert.ToInt32(ddlAgent.SelectedValue);
                }


                deliveryStatus = drpdwnStatus.SelectedItem.Value;
                if (deliveryStatus == "1")
                {
                    deliveryStatus = "N";

                }
                else if (deliveryStatus == "2")
                {
                    deliveryStatus = "Y";
                }
                else
                    deliveryStatus = null;
                if (ToDate < FromDate)
                {
                    ShowMessageWithUpdatePanel("From Date Must Be Less Then Todate.");
                }
                else
                {
                    string eception = "";
                    if (usertype == Convert.ToInt32(UserType.Admin))
                    {
                        // agentId = Convert.ToInt32(ddlAgent.SelectedValue);
                        locationId = 0;
                       
                        lstConsignment = consignmentBal.ReadConsignmentDataByDates(FromDate, ToDate, countryId, agentId, locationId, PaxName, PaxPassportNo, deliveryStatus, consignmentNo, corporatename, out eception);
                        if (string.IsNullOrEmpty(eception))
                        {
                            ShowMessageWithUpdatePanel("Record is too large also serch by from date and To date search");
                        }
                    }
                    else
                    {
                        lstConsignment = consignmentBal.ReadConsignmentDataByDates(FromDate, ToDate, countryId, agentId, locationId, PaxName, PaxPassportNo, deliveryStatus, consignmentNo, corporatename, out eception);
                        if (string.IsNullOrEmpty(eception))
                        {
                            ShowMessageWithUpdatePanel("Record is too large also serch by from date and To date search");
                        }
                    }
                    _consignments = lstConsignment;
                    if (_consignments.Count > 0)
                    {
                        //Session["_consignments"] = _consignments;
                       // this.EnableViewState = false;
                        gridViewConsignment.EnableViewState = false;
                        gridViewConsignment.DataSource = _consignments;
                        gridViewConsignment.DataBind();
                        txtConsignmentNosearch.Text = "";
                        gridViewConsignment.Visible = true;
                        // Clear();
                        btnExport.Visible = true;
                    }

                    else
                    {
                        btnExport.Visible = false;
                        ShowMessageWithUpdatePanel("No Record Found.");
                        gridViewConsignment.Visible = false;
                        //Clear();
                    }
                }

            }
        }
        public void ResetViewState()
        {
            FromDate = DateTime.MinValue;
            ToDate = DateTime.MinValue;
            countryId = 0;
            agentId = 0;

        }

        #region Public Properties

        public DateTime ToDate
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(ViewState["ToDate"]);
                }
                catch
                {

                    return DateTime.MinValue;
                }
            }
            set { ViewState["ToDate"] = value; }
        }
        public DateTime FromDate
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(ViewState["FromDate"]);
                }
                catch
                {

                    return DateTime.MinValue;
                }
            }
            set { ViewState["FromDate"] = value; }
        }
        public Int32 countryId
        {
            get
            {
                try
                {
                    return (Int32)ViewState["countryId"];
                }
                catch
                {

                    return 0;
                }
            }
            set { ViewState["countryId"] = value; }
        }
        public Int32 agentId
        {
            get
            {
                try
                {
                    return (Int32)Session["agentId"];
                }
                catch
                {

                    return 0;
                }
            }
            set { Session["agentId"] = value; }
        }
        #endregion


        protected void btnUserNameSubmit_Click(object sender, EventArgs e)
        {

            if (gridViewConsignment.HeaderRow != null)
            {
                TextBox txtname = (TextBox)gridViewConsignment.HeaderRow.FindControl("txtCountryName");

                lstConsignment = _consignments.Where(x => x.CountryName.ToLower() == txtname.Text.ToLower()).ToList();

                if (lstConsignment.Count > 0)
                {
                    gridViewConsignment.DataSource = lstConsignment;
                    gridViewConsignment.DataBind();
                    txtConsignmentNosearch.Text = "";
                    gridViewConsignment.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('No Record Found.');", true);

                    // ShowMessageWithUpdatePanel("No Record Found.");
                    gridViewConsignment.Visible = false;
                    Clear();
                }
            }

        }

        protected void btnUserNameSubmit_Click1(object sender, EventArgs e)
        {

        }

        protected void btnNoOfPassport_Click(object sender, EventArgs e)
        {
            if (gridViewConsignment.HeaderRow != null)
            {
                TextBox txtPassportNo = (TextBox)gridViewConsignment.HeaderRow.FindControl("txtPassportNo");

                lstConsignment = _consignments.Where(x => x.CgNoOfPass.ToString() == txtPassportNo.Text).ToList();

                if (lstConsignment.Count > 0)
                {
                    gridViewConsignment.DataSource = lstConsignment;
                    gridViewConsignment.DataBind();
                    txtConsignmentNosearch.Text = "";
                    gridViewConsignment.Visible = true;

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('No Record Found.');", true);
                    Clear();
                    // ShowMessageWithUpdatePanel("No Record Found.");
                    gridViewConsignment.Visible = false;
                }
            }

        }

        protected void btnPaxNameSubmit_Click(object sender, EventArgs e)
        {
            if (gridViewConsignment.HeaderRow != null)
            {
                TextBox txtPaxPaxName = (TextBox)gridViewConsignment.HeaderRow.FindControl("txtPaxName");

                lstConsignment = _consignments.Where(x => x.PaxPaxName.ToLower() == txtPaxPaxName.Text.ToLower()).ToList();

                if (lstConsignment.Count > 0)
                {
                    gridViewConsignment.DataSource = lstConsignment;
                    gridViewConsignment.DataBind();
                    txtConsignmentNosearch.Text = "";
                    gridViewConsignment.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('No Record Found.');", true);

                    // ShowMessageWithUpdatePanel("No Record Found.");
                    gridViewConsignment.Visible = false;
                }
            }

        }

        private void Clear()
        {
            txtfrmdate.Text = string.Empty;
            txttodate.Text = string.Empty;
            txtConsignmentNosearch.Text = string.Empty;
            ddlAgent.SelectedIndex = 0;
            ddlcountry.SelectedIndex = 0;
            //drpdwnStatus.ClearSelection();
        }

        protected void btnPassNo_Click(object sender, EventArgs e)
        {
            if (gridViewConsignment.HeaderRow != null)
            {
                TextBox txtPassportNo = (TextBox)gridViewConsignment.HeaderRow.FindControl("txtPassportNo");
                lstConsignment = _consignments.Where(x => x.pax.PaxPassportNo.ToString() == txtPassportNo.Text).ToList();
                if (lstConsignment.Count > 0)
                {
                    gridViewConsignment.DataSource = lstConsignment;
                    gridViewConsignment.DataBind();
                    txtPassportNo.Text = "";
                    gridViewConsignment.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('No Record Found.');", true);
                    Clear();
                    gridViewConsignment.Visible = false;
                }
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=Consignment.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.xls";
            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);
            HtmlTextWriter htm = new HtmlTextWriter(stringWriter);
            gridViewConsignment.AllowPaging = false;
            BindConsignmentGrid();
            //gridViewConsignment.FooterRow.HorizontalAlign = HorizontalAlign.Right;
            gridViewConsignment.RenderControl(htm);
            Response.Write(stringWriter);
            Response.End();
            btnExport.Visible = false;
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        private void FindRecordByPassprtNo()
        {
            TextBox txtPassportNo = (TextBox)gridViewConsignment.HeaderRow.FindControl("txtPassportNo");
            lstConsignment = _consignments.Where(x => x.pax.PaxPassportNo.ToString() == txtPassportNo.Text).ToList();
            if (lstConsignment.Count > 0)
            {
                gridViewConsignment.DataSource = lstConsignment;
                gridViewConsignment.DataBind();
                txtPassportNo.Text = "";
                gridViewConsignment.Visible = true;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('No Record Found.');", true);
                Clear();
                gridViewConsignment.Visible = false;
            }
        }

        protected void Button1_Command(object sender, CommandEventArgs e)
        {

        }





    }
}