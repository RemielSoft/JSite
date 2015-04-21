using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.Globalization;
using System.Web.Configuration;
using System.Configuration;
namespace JSVisaTrackingWebApplication
{

    public partial class Miscelllaneous_charges : System.Web.UI.Page
    {
        MiscellaneousBusinessAccess miscellaneousBusiness = new MiscellaneousBusinessAccess();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindggrd();
                lblm.Visible = false;
                

            }
        }
      
        protected void BtnAdd_Click(object sender, EventArgs e)
        {

           
                Miscellaneous miscellaneousDomain = new Miscellaneous();
                miscellaneousDomain.Description = Server.HtmlEncode(txtDescription.Text);
                miscellaneousDomain.Amount = Convert.ToDecimal(txtAmount.Text);
                miscellaneousDomain.Per_consignment = (drpvisa.SelectedValue).ToString();
                miscellaneousDomain.Mandatory = CheckMandatory.Text;
               
                int serviceqwe = 0;
                               
                if (Rbtnservice.SelectedValue == "")
                {
                    
                    miscellaneousDomain.ServiceTax = "False";
                    miscellaneousDomain.ServiceCharges = "False";
                    miscellaneousBusiness.insert(miscellaneousDomain);
                    Bindggrd();
                    Response.Write("<Script Language=javascript>alert('Record Saved Successfully.');</Script>");
                    empty();


                }
                else
                {
                    
                    List<Miscellaneous> lstmislnous = miscellaneousBusiness.ReadMislenousByServiceTax();
                    if (lstmislnous.Count != 0)
                    {
                        for (int i = 0; i < lstmislnous.Count; i++)
                        {
                            if (Rbtnservice.SelectedItem.Value == "1")
                            {
                                if (lstmislnous[i].ServiceTax == "True")
                                {
                                    serviceqwe = 1;
                                    miscellaneousDomain.ServiceTax = "False";
                                    Response.Write("<Script Language=javascript>alert('Service tax already added.');</Script>");
                                    break;
                                }
                                else
                                    miscellaneousDomain.ServiceTax = "True";

                            }
                            else
                                miscellaneousDomain.ServiceTax = "False";

                        }
                    }
                    else
                    {
                        if (Rbtnservice.SelectedItem.Value == "1")
                        {
                            miscellaneousDomain.ServiceTax = "True";
                        }
                        else
                        {
                            miscellaneousDomain.ServiceTax = "False";
                        }


                    }
                    
                    List<Miscellaneous> lstmislnousServicCharges = miscellaneousBusiness.Readmisenousservicecharges();                    
                    if (lstmislnousServicCharges.Count != 0)
                    {
                        for (int i = 0; i < lstmislnousServicCharges.Count; i++)
                            if (Rbtnservice.SelectedItem.Value == "2")
                            {

                                if (lstmislnousServicCharges[i].ServiceCharges == "True")
                                {

                                    serviceqwe = 1;
                                    miscellaneousDomain.ServiceCharges = "False";
                                    Response.Write("<Script Language=javascript>alert('Service charge already added.');</Script>");
                                    break;
                                }
                                else
                                {
                                    miscellaneousDomain.ServiceCharges = "True";
                                }

                            }
                            else
                            {
                                miscellaneousDomain.ServiceCharges = "False";
                            }
                    }
                    else
                    {
                        if (Rbtnservice.SelectedItem.Value == "2")
                        {
                            miscellaneousDomain.ServiceCharges = "True";
                        }
                        else
                        {
                            miscellaneousDomain.ServiceCharges = "False";
                        }


                    }

                    if (serviceqwe == 1)
                    {
                        empty();
                    }
                    else
                    {

                        miscellaneousBusiness.insert(miscellaneousDomain);
                        Bindggrd();
                        Response.Write("<Script Language=javascript>alert('Record Saved Successfully.');</Script>");
                        empty();
                    }


                }

               
                
            
        }
        public void Bindggrd()
        {
            
            Grdm.DataSource = miscellaneousBusiness.Bind();
            Grdm.DataBind();
        }

        protected void Grdm_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            int Id = Convert.ToInt32(e.CommandArgument);
            ViewState["Id"] = Id;
            if (e.CommandName == "cmdedit")
               
            {
                List<Miscellaneous> lstR = miscellaneousBusiness.ReadId(Id);
                txtDescription.Text = lstR[0].Description;
                txtAmount.Text = Convert.ToString( lstR[0].Amount);
                drpvisa.Text = lstR[0].Per_consignment;
                if (lstR[0].Mandatory.ToString() == "True")
                {
                    CheckMandatory.Checked = true;
                }
                else
                    CheckMandatory.Checked = false;

                if (lstR[0].ServiceTax == "True")
                {
                    Rbtnservice.SelectedValue = "1";
                    txtAmount.Enabled = false;
                    txtDescription.Enabled = false;
                    drpvisa.Enabled = false;
                    Rbtnservice.Enabled = false;
                   
                    
                    
                }


                else if (lstR[0].ServiceCharges == "True")
                {
                    Rbtnservice.SelectedValue = "2";
                    txtAmount.Enabled = false;
                    txtDescription.Enabled = false;
                    drpvisa.Enabled = false;
                    Rbtnservice.Enabled = false;
                }
                else
                {
                    Rbtnservice.ClearSelection();
                    txtAmount.Enabled = true; ;
                    txtDescription.Enabled = true;
                    drpvisa.Enabled = true;
                    Rbtnservice.Enabled = true;
                }
                btnupdate.Visible = true;
                BtnAdd.Visible = false;
               

            }
            if (e.CommandName == "cmddelete")
            {
                miscellaneousBusiness.dellete(Id);
                Response.Write("<Script Language=javascript>alert('Record Deleted Successfully.');</Script>");


                btnupdate.Visible = false; ; ;
                BtnAdd.Visible = true;
                empty();

                Bindggrd();
            }

        }

        public void empty()
        {
            txtAmount.Text = "";
            txtDescription.Text = "";
            drpvisa.SelectedValue = "--Select--";
            CheckMandatory.Checked = false;
            Rbtnservice.ClearSelection();
            txtAmount.Enabled = true; ;
            txtDescription.Enabled = true;
            drpvisa.Enabled = true;
            Rbtnservice.Enabled = true;


        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {

            int Id = Convert.ToInt32(ViewState["Id"]);
            Miscellaneous Miscellaneousupdate = new Miscellaneous();
            List<Miscellaneous> lstR = miscellaneousBusiness.ReadId(Id);
            if (lstR[0].ServiceCharges == "True" || lstR[0].ServiceTax == "True")
            {
                Miscellaneousupdate.ServiceCharges = lstR[0].ServiceCharges;
                Miscellaneousupdate.ServiceTax = lstR[0].ServiceTax;
                Miscellaneousupdate.Description = lstR[0].Description;
                Miscellaneousupdate.Amount = lstR[0].Amount;
                Miscellaneousupdate.Per_consignment = lstR[0].Per_consignment;
                Miscellaneousupdate.Mandatory = lstR[0].Mandatory;               
                

            }
            else
            {
                Miscellaneousupdate.Description = txtDescription.Text;
                Miscellaneousupdate.Amount = Convert.ToDecimal(txtAmount.Text);
                Miscellaneousupdate.Per_consignment = drpvisa.SelectedValue.ToString();
                Miscellaneousupdate.Mandatory = CheckMandatory.Checked.ToString();
                List<Miscellaneous> lstmislnousServicCharges = miscellaneousBusiness.Readmisenousservicecharges();
                if (Rbtnservice.SelectedValue == "")
                {
                    Miscellaneousupdate.ServiceTax = "False";
                    Miscellaneousupdate.ServiceCharges = "False";
                    Response.Write("<Script Language=javascript>alert('Record Update Successfully.');</Script>");
                }
                else
                {
                    List<Miscellaneous> lstmislnous = miscellaneousBusiness.ReadMislenousByServiceTax();
                    if (lstmislnous.Count != 0)
                    {
                        for (int i = 0; i < lstmislnous.Count; i++)
                        {

                            if (Rbtnservice.SelectedItem.Value == "1")
                            {

                                if (lstmislnous[i].ServiceTax == "True")
                                {
                                    Miscellaneousupdate.ServiceTax = "False";
                                    Response.Write("<Script Language=javascript>alert('Service Tax already added.');</Script>");
                                                                          
                                    break;
                                     
                                }
                                else
                                    Miscellaneousupdate.ServiceTax = "True";
                               
                                
                            }
                            else
                                Miscellaneousupdate.ServiceTax = "False";
                        }
                        
                    }
                           

                    if (lstmislnousServicCharges.Count != 0)
                    {
                        for (int i = 0; i < lstmislnousServicCharges.Count; i++)
                        {
                            if (Rbtnservice.SelectedItem.Value == "2")
                            {


                                if (lstmislnousServicCharges[i].ServiceCharges == "True")
                                {

                                    Miscellaneousupdate.ServiceCharges = "False";

                                    Response.Write("<Script Language=javascript>alert('Service charge already added.');</Script>");
                                 

                                    break;
                                    

                                }
                                else
                                    Miscellaneousupdate.ServiceCharges = "True";
                               
                               
                            }


                            else
                            {

                                Miscellaneousupdate.ServiceCharges = "False";
                            }
                        }
                     
                    }
                    if (Miscellaneousupdate.ServiceCharges == "True")
                    {
                        Response.Write("<Script Language=javascript>alert('Record Update Successfully.');</Script>");
                    }
                    if (Miscellaneousupdate.ServiceTax == "True")
                    {
                        Response.Write("<Script Language=javascript>alert('Record Update Successfully.');</Script>");
                    }

                }

              
            }

            
            miscellaneousBusiness.update1(Id, Miscellaneousupdate);
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

        protected void btnc_Click(object sender, EventArgs e)
        {
            btnupdate.Visible = false;
            BtnAdd.Visible = true;
            empty();

        }

        
    }


}
