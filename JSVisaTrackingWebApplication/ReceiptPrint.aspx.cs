using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.Common;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using JSVisaTrackingWebApplication.Shared;


namespace JSVisaTrackingWebApplication
{
    public partial class ReceiptPrint : System.Web.UI.Page
    {
        BasePage basePage = new BasePage();
        GenerateInvoiceBAL generateInvoiceBal = new GenerateInvoiceBAL();
        Int64 Total = 0;
        Decimal TotalAmount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Bill> lstBillD = new List<Bill>();
            int LocId = basePage.LoggedInUser.UserLocation.LocationId;
            int userId = basePage.LoggedInUser.UserTypeId;
            if (userId == Convert.ToInt32(UserType.Admin))
            {
                LocId = 0;
                lstBillD = generateInvoiceBal.ReadPreviewEmailShow(LocId);
            }
            else
            {
                lstBillD = generateInvoiceBal.ReadPreviewEmailShow(LocId);
            }
            //lstBillD = generateInvoiceBal.ReadPreviewEmailShow(LocId);
            lblemailAddress.Text = lstBillD[0].AgentDetails.AgentEmail;
            lblfaxNumber.Text = lstBillD[0].AgentDetails.AgentFax;
            lblPhoneNumber.Text = lstBillD[0].AgentDetails.AgentPhone;

            if (Request.QueryString["receiptId"] != null)
            {

                Receipt receipt1 = (Receipt)Session["NewlstReceipt"];
                lblReceiptNo.Text = Request.QueryString["receiptId"].ToString();
                BindPrintGrid();
            }

            else if (Request.QueryString["receiptAdvance"] != null)
            {
                if (Convert.ToInt32(Session["Flag"]) == 1)
                {
                    List<Receipt> receipt1 = (List<Receipt>)Session["NewlstReceipt"];
                    lblDuplicate.Visible = true;
                }
                else
                {
                    Receipt receipt1 = (Receipt)Session["NewlstReceipt"];
                    lblDuplicate.Visible = false;
                }
                lblReceiptNo.Text = Session["RcptId"].ToString();
                BindPrintGrid2();
            }

            else if (Request.QueryString["receiptUpdate"] != null)
            {

                Receipt receipt1 = (Receipt)Session["NewlstReceipt"];
                lblReceiptNo.Text = receipt1.RcptNo.ToString()+" Update";
                BindPrintGrid3();
            }

            else if (Request.QueryString["RcptId"] != null)
            {
                int flag = Convert.ToInt32(Session["Flag"]);
                if (flag==1)
                {
                    lblDuplicate.Visible = true;
                }
                else
                {
                    lblDuplicate.Visible = false;
                }
                List<Receipt> lstRcpt = (List<Receipt>)Session["lstRcpt"];
                BindPrintGrid1();                
            }
            else
            {
                BindPrintGrid();                
            }            
        }

        public void BindPrintGrid()
        {

            Receipt receipt1 = (Receipt)Session["NewlstReceipt"];
            lblAccountName.Text = Session["agentName"].ToString();

            if (receipt1.PaymentMode == "CR")
            {
                lblPaymentMode.Text = " Cash";
            }
            else
            {
                lblPaymentMode.Text = " Cheqe/DD No. " + receipt1.ChequeNo + " " + receipt1.IssuingBank + " " + receipt1.IssuingDate;
            }

            lblAccountCode.Text = receipt1.agent.AgentId.ToString();
            lblDate.Text = receipt1.RcptDate.ToString();
            lblagntname.Text = Session["agentName"].ToString();

            List<ReceiptDetails> lst = receipt1.ReceiptDetail;
            gvPreviewReceipt.DataSource = lst;
            gvPreviewReceipt.DataBind();

            for (int i = 0; i < lst.Count; i++)
            {
                Total += Convert.ToInt64(lst[i].AdjustedAmount);
            }
            lbltotalAdjustedAmt.Text = Total.ToString();
            LbltotalAmt.Text = Total.ToString();
            Int64 NumVal = Total;
            LbltotalAmt.Text = Rupees(NumVal);
        }

        public void BindPrintGrid1()
        {

            List<Receipt> lstRcpt = (List<Receipt>)Session["lstRcpt"];

            if (lstRcpt[0].PaymentMode == "CR")
            {
                lblPaymentMode.Text = " Cash";
            }
            else
            {
                lblPaymentMode.Text = " Cheqe/DD No. " + lstRcpt[0].ChequeNo + " " + lstRcpt[0].IssuingBank + " " + lstRcpt[0].IssuingDate;
            }

            lblAccountCode.Text = lstRcpt[0].agent.AgentId.ToString();
            lblDate.Text = lstRcpt[0].RcptDate.ToString();
            lblagntname.Text = lstRcpt[0].agent.AgentName;
            lblAccountName.Text = lstRcpt[0].agent.AgentName;
            lblReceiptNo.Text = lstRcpt[0].RcptNo.ToString();

            List<ReceiptDetails> lst = (List<ReceiptDetails>)Session["NewlstRcptDetails"];
            gvPreviewReceipt.DataSource = lst;
            gvPreviewReceipt.DataBind();

            for (int i = 0; i < lst.Count; i++)
            {
                Total += Convert.ToInt64(lst[i].AdjustedAmount);
            }
            lbltotalAdjustedAmt.Text = Total.ToString();
            LbltotalAmt.Text = Total.ToString();
            Int64 NumVal = Total;
            LbltotalAmt.Text = Rupees(NumVal);
        }

        public void BindPrintGrid2()
        {
            if (Convert.ToInt32(Session["Flag"]) == 1)
            {
                List<Receipt> receipt1 = (List<Receipt>)Session["NewlstReceipt"];

                lblAccountName.Text = Session["agentName"].ToString();

                if (receipt1[0].PaymentMode == "CR")
                {
                    lblPaymentMode.Text = " Cash";
                }
                else
                {
                    lblPaymentMode.Text = " Cheqe/DD No. " + receipt1[0].ChequeNo + " " + receipt1[0].IssuingBank + " " + receipt1[0].IssuingDate;
                }

                lblAccountCode.Text = receipt1[0].agent.AgentId.ToString();
                lblDate.Text = receipt1[0].RcptDate.ToString();
                lblagntname.Text = Session["agentName"].ToString();

                Total = Convert.ToInt64(receipt1[0].RcptAmount);
                lbltotalAdjustedAmt.Text = Total.ToString() +" Advance (i.e. Not Paid Against Any Invoice No.).";
            }
            else
            {
                Receipt receipt1 = (Receipt)Session["NewlstReceipt"];

                lblAccountName.Text = Session["agentName"].ToString();

                if (receipt1.PaymentMode == "CR")
                {
                    lblPaymentMode.Text = " Cash";
                }
                else
                {
                    lblPaymentMode.Text = " Cheqe/DD No. " + receipt1.ChequeNo + " " + receipt1.IssuingBank + " " + receipt1.IssuingDate;
                }

                lblAccountCode.Text = receipt1.agent.AgentId.ToString();
                lblDate.Text = receipt1.RcptDate.ToString();
                lblagntname.Text = Session["agentName"].ToString();

                Total = Convert.ToInt64(receipt1.RcptAmount);
                
                lbltotalAdjustedAmt.Text = Total.ToString();
            }

            
            LbltotalAmt.Text = Total.ToString();

            Int64 NumVal = Total;
            LbltotalAmt.Text = Rupees(NumVal);
        }

        public void BindPrintGrid3()
        {

            Receipt receipt1 = (Receipt)Session["NewlstReceipt"];
            lblAccountName.Text = receipt1.agent.AgentName;

            if (receipt1.PaymentMode == "CR")
            {
                lblPaymentMode.Text = " Cash";
            }
            else
            {
                lblPaymentMode.Text = " Cheqe/DD No. " + receipt1.ChequeNo + " " + receipt1.IssuingBank + " " + receipt1.IssuingDate;
            }

            lblAccountCode.Text = receipt1.agent.AgentId.ToString();
            lblDate.Text = receipt1.RcptDate.ToString();
            lblagntname.Text = receipt1.agent.AgentName;

            Total = Convert.ToInt64(receipt1.RcptAmount);

            lbltotalAdjustedAmt.Text = Total.ToString();
            LbltotalAmt.Text = Total.ToString();

            Int64 NumVal = Total;
            LbltotalAmt.Text = Rupees(NumVal);
        }

        public string Rupees(Int64 rup)
        {
            string result = "";
            Int64 res;
            if ((rup / 10000000) > 0)
            {
                res = rup / 10000000;
                rup = rup % 10000000;
                result = result + ' ' + RupeesToWords(res) + " Crore";
            }
            if ((rup / 100000) > 0)
            {
                res = rup / 100000;
                rup = rup % 100000;
                result = result + ' ' + RupeesToWords(res) + " Lack";
            }
            if ((rup / 1000) > 0)
            {
                res = rup / 1000;
                rup = rup % 1000;
                result = result + ' ' + RupeesToWords(res) + " Thousand";
            }
            if ((rup / 100) > 0)
            {
                res = rup / 100;
                rup = rup % 100;
                result = result + ' ' + RupeesToWords(res) + " Hundred";
            }
            if ((rup % 10) >= 0)
            {
                res = rup % 100;
                result = result + " " + RupeesToWords(res);
            }
            result = result + ' ' + "Rupees ";
            return result;
        }

        public string RupeesToWords(Int64 rup)
        {
            string result = "";
            if ((rup >= 1) && (rup <= 10))
            {
                if ((rup % 10) == 1) result = "One";
                if ((rup % 10) == 2) result = "Two";
                if ((rup % 10) == 3) result = "Three";
                if ((rup % 10) == 4) result = "Four";
                if ((rup % 10) == 5) result = "Five";
                if ((rup % 10) == 6) result = "Six";
                if ((rup % 10) == 7) result = "Seven";
                if ((rup % 10) == 8) result = "Eight";
                if ((rup % 10) == 9) result = "Nine";
                if ((rup % 10) == 0) result = "Ten";
            }
            if (rup > 9 && rup < 20)
            {
                if (rup == 11) result = "Eleven";
                if (rup == 12) result = "Twelve";
                if (rup == 13) result = "Thirteen";
                if (rup == 14) result = "Forteen";
                if (rup == 15) result = "Fifteen";
                if (rup == 16) result = "Sixteen";
                if (rup == 17) result = "Seventeen";
                if (rup == 18) result = "Eighteen";
                if (rup == 19) result = "Nineteen";
            }
            if (rup > 20 && (rup / 10) == 2 && (rup % 10) == 0) result = "Twenty";
            if (rup > 20 && (rup / 10) == 3 && (rup % 10) == 0) result = "Thirty";
            if (rup > 20 && (rup / 10) == 4 && (rup % 10) == 0) result = "Forty";
            if (rup > 20 && (rup / 10) == 5 && (rup % 10) == 0) result = "Fifty";
            if (rup > 20 && (rup / 10) == 6 && (rup % 10) == 0) result = "Sixty";
            if (rup > 20 && (rup / 10) == 7 && (rup % 10) == 0) result = "Seventy";
            if (rup > 20 && (rup / 10) == 8 && (rup % 10) == 0) result = "Eighty";
            if (rup > 20 && (rup / 10) == 9 && (rup % 10) == 0) result = "Ninty";

            if (rup > 20 && (rup / 10) == 2 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Twenty One";
                if ((rup % 10) == 2) result = "Twenty Two";
                if ((rup % 10) == 3) result = "Twenty Three";
                if ((rup % 10) == 4) result = "Twenty Four";
                if ((rup % 10) == 5) result = "Twenty Five";
                if ((rup % 10) == 6) result = "Twenty Six";
                if ((rup % 10) == 7) result = "Twenty Seven";
                if ((rup % 10) == 8) result = "Twenty Eight";
                if ((rup % 10) == 9) result = "Twenty Nine";
            }
            if (rup > 20 && (rup / 10) == 3 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Thirty One";
                if ((rup % 10) == 2) result = "Thirty Two";
                if ((rup % 10) == 3) result = "Thirty Three";
                if ((rup % 10) == 4) result = "Thirty Four";
                if ((rup % 10) == 5) result = "Thirty Five";
                if ((rup % 10) == 6) result = "Thirty Six";
                if ((rup % 10) == 7) result = "Thirty Seven";
                if ((rup % 10) == 8) result = "Thirty Eight";
                if ((rup % 10) == 9) result = "Thirty Nine";
            }
            if (rup > 20 && (rup / 10) == 4 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Forty One";
                if ((rup % 10) == 2) result = "Forty Two";
                if ((rup % 10) == 3) result = "Forty Three";
                if ((rup % 10) == 4) result = "Forty Four";
                if ((rup % 10) == 5) result = "Forty Five";
                if ((rup % 10) == 6) result = "Forty Six";
                if ((rup % 10) == 7) result = "Forty Seven";
                if ((rup % 10) == 8) result = "Forty Eight";
                if ((rup % 10) == 9) result = "Forty Nine";
            }
            if (rup > 20 && (rup / 10) == 5 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Fifty One";
                if ((rup % 10) == 2) result = "Fifty Two";
                if ((rup % 10) == 3) result = "Fifty Three";
                if ((rup % 10) == 4) result = "Fifty Four";
                if ((rup % 10) == 5) result = "Fifty Five";
                if ((rup % 10) == 6) result = "Fifty Six";
                if ((rup % 10) == 7) result = "Fifty Seven";
                if ((rup % 10) == 8) result = "Fifty Eight";
                if ((rup % 10) == 9) result = "Fifty Nine";
            }
            if (rup > 20 && (rup / 10) == 6 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Sixty One";
                if ((rup % 10) == 2) result = "Sixty Two";
                if ((rup % 10) == 3) result = "Sixty Three";
                if ((rup % 10) == 4) result = "Sixty Four";
                if ((rup % 10) == 5) result = "Sixty Five";
                if ((rup % 10) == 6) result = "Sixty Six";
                if ((rup % 10) == 7) result = "Sixty Seven";
                if ((rup % 10) == 8) result = "Sixty Eight";
                if ((rup % 10) == 9) result = "Sixty Nine";
            }
            if (rup > 20 && (rup / 10) == 7 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Seventy One";
                if ((rup % 10) == 2) result = "Seventy Two";
                if ((rup % 10) == 3) result = "Seventy Three";
                if ((rup % 10) == 4) result = "Seventy Four";
                if ((rup % 10) == 5) result = "Seventy Five";
                if ((rup % 10) == 6) result = "Seventy Six";
                if ((rup % 10) == 7) result = "Seventy Seven";
                if ((rup % 10) == 8) result = "Seventy Eight";
                if ((rup % 10) == 9) result = "Seventy Nine";
            }
            if (rup > 20 && (rup / 10) == 8 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Eighty One";
                if ((rup % 10) == 2) result = "Eighty Two";
                if ((rup % 10) == 3) result = "Eighty Three";
                if ((rup % 10) == 4) result = "Eighty Four";
                if ((rup % 10) == 5) result = "Eighty Five";
                if ((rup % 10) == 6) result = "Eighty Six";
                if ((rup % 10) == 7) result = "Eighty Seven";
                if ((rup % 10) == 8) result = "Eighty Eight";
                if ((rup % 10) == 9) result = "Eighty Nine";
            }
            if (rup > 20 && (rup / 10) == 9 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Ninty One";
                if ((rup % 10) == 2) result = "Ninty Two";
                if ((rup % 10) == 3) result = "Ninty Three";
                if ((rup % 10) == 4) result = "Ninty Four";
                if ((rup % 10) == 5) result = "Ninty Five";
                if ((rup % 10) == 6) result = "Ninty Six";
                if ((rup % 10) == 7) result = "Ninty Seven";
                if ((rup % 10) == 8) result = "Ninty Eight";
                if ((rup % 10) == 9) result = "Ninty Nine";
            }
            return result;
        }

        protected void ImgbtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            //ImgbtnPrint.Attributes.Add("onclick", "window.print();");
        }

        protected void gvPreviewReceipt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblamt = (Label)e.Row.FindControl("lblamt");

                Decimal Amount = Convert.ToDecimal(lblamt.Text);

                TotalAmount += Amount;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //e.Row.Cells[0].Font.Bold = true;                
                Label lblTotalAmt = (Label)e.Row.FindControl("lblTotalAmt");

                lblTotalAmt.Text = TotalAmount.ToString();

                Session["TotalAmountt"] = lblTotalAmt.Text;
            }
        }
    }
}