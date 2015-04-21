using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using JSVisaTrackingWebApplication.Shared;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;

namespace JSVisaTrackingWebApplication
{
    public partial class Default : System.Web.UI.MasterPage
    {
        BasePage basePage = new BasePage();
        UserBAL userBal = new UserBAL();
        protected void Page_Load(object sender, EventArgs e)
        {

            LblLoginUser.Text = basePage.LoggedInUser.FullName;
            if (!IsPostBack)
            {
                UserDom user = new UserDom();
                user = userBal.ReadUserByLoginId(basePage.LoggedInUser.LoginId);

                if (basePage.LoggedInUser.UserTypeId != Convert.ToInt32(UserType.Admin) && basePage.LoggedInUser.UserTypeId != Convert.ToInt32(UserType.SuperAdmin))
                {
                    agentlist.Visible = false;
                    viewConsignment.Visible = false;
                    updateConsignment.Visible = false;
                    embassyFee.Visible = false;
                    embassyMaster.Visible = false;
                    searchEmbassyFee.Visible = false;
                    miscellaneous.Visible = false;
                    addVisaForm.Visible = false;
                    showvisaForm.Visible = false;
                    addVisaInfo.Visible = false;
                    viewVisaInfo.Visible = false;
                    addHoliday.Visible = false;
                    holidayList.Visible = false;
                    addAgent.Visible = false;
                    agentEditUpdate.Visible = false;
                    listAgent.Visible = false;
                    exportAgent.Visible = false;
                    agentEmailList.Visible = false;
                    admin.Visible = false;
                    advanceSearchReport.Visible = false;
                    receiptGen.Visible = false;
                    editReceipt.Visible = false;
                    dataExportTally.Visible = false;
                    newsLetter.Visible = false;
                    viewnewsLetter.Visible = false;
                    invoiceList.Visible = false;
                    printInvoice.Visible = false;
                    reprintInvoice.Visible = false;
                    billRegister.Visible = false;
                    statementOfAccnt.Visible = false;
                    bankStatement.Visible = false;
                    agingAnalysis.Visible = false;
                    summaryReport.Visible = false;
                    miscellaneousReport.Visible = false;
                    EditDeleteConsignment.Visible = false;
                    city.Visible = false;
                    for (int i = 0; i < user.UserTask.Count; i++)
                    {


                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.AddConsignment))))
                        {
                            agentlist.Visible = true;
                        }
                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.ViewConsignment))))
                        {
                            viewConsignment.Visible = true;
                        }
                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.EditConsignment))))
                        {
                            EditDeleteConsignment.Visible = true;
                        }
                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.DeleteConsignment))))
                        {
                            EditDeleteConsignment.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.UpdateConsignmentStatus))))
                        {
                            updateConsignment.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.EmbassyFeeMaster))))
                        {
                            embassyFee.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.EmbassyMaster))))
                        {
                            embassyMaster.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.SearchEmbassyFee))))
                        {
                            searchEmbassyFee.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.MiscellaneousCharges))))
                        {
                            miscellaneous.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.AddVisaForm))))
                        {
                            addVisaForm.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.ViewVisaForm))))
                        {
                            showvisaForm.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.AddVisaInfo))))
                        {
                            addVisaInfo.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.ViewVisaInfo))))
                        {
                            viewVisaInfo.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.AddHoliday))))
                        {
                            addHoliday.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.ViewHoliday))))
                        {
                            holidayList.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.AddAgent))))
                        {
                            addAgent.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.ManageAgent))))
                        {
                            agentEditUpdate.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.AgentList))))
                        {
                            listAgent.Visible = true;
                        }
                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.ExportAgent))))
                        {
                            exportAgent.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.AgentEmailList))))
                        {
                            agentEmailList.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.Admin))))
                        {
                            admin.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.AdvanceSearch))))
                        {
                            advanceSearchReport.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.ReceiptGeneration))))
                        {
                            receiptGen.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.EditReceipt))))
                        {
                            editReceipt.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.ExportDataToTally))))
                        {
                            dataExportTally.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.AddNewsLetter))))
                        {
                            newsLetter.Visible = true;
                        }
                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.ViewNewsLetter))))
                        {
                            viewnewsLetter.Visible = true;
                        }
                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.InvoiceReceiptPrinting))))
                        {
                            invoiceList.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.InvoicePrinting))))
                        {
                            printInvoice.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.InvoiceReprinting))))
                        {
                            reprintInvoice.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.BillRegister))))
                        {
                            billRegister.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.StatementOfAccount))))
                        {
                            statementOfAccnt.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.BankStatement))))
                        {
                            bankStatement.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.AgingAnalysis))))
                        {
                            agingAnalysis.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.SummaryReport))))
                        {
                            summaryReport.Visible = true;
                        }

                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.MiscellaneousReport))))
                        {
                            miscellaneousReport.Visible = true;
                        }
                        if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.AddCity))))
                        {
                            city.Visible = true;
                        }

                    }

                }

            }

        }
        protected void lnkLogout_Click(object sender, EventArgs e)
        {

            FormsAuthentication.SignOut();

            Response.Redirect("~/Account/Login.aspx");

        }
    }
}