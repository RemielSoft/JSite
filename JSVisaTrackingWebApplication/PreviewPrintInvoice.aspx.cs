using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using JSVisaTrackingWebApplication.Shared;

namespace JSVisaTrackingWebApplication
{
    public partial class PreviewPrintInvoice : System.Web.UI.Page
    {
        GenerateInvoiceBAL generateInvoiceBal = new GenerateInvoiceBAL();
        ConsignmentBusinessAccess consignmentBal = new ConsignmentBusinessAccess();
        List<AdditonalInfo> lstCon = new List<AdditonalInfo>();
        List<Consignment> lstConn = new List<Consignment>();
        BasePage basePage = new BasePage();
        protected void Page_Load(object sender, EventArgs e)
        {
            //grdInvoice.Visible = true;
            PreviewInvoice();
        }
        public void PreviewInvoice()
        {
            List<Bill> lstBillD = new List<Bill>();
            List<BillItem> lstBillItem = new List<BillItem>();
            int id = Convert.ToInt32(Request.QueryString["CG_Id"]);
            if (id == 0)
            {
                id = Convert.ToInt32(Session["ConsignmentId"]);
            }
            int billId = Convert.ToInt32(Session["billId"]);
            int LocId = 0;
            if (basePage.LoggedInUser.UserLocation != null)
            {
                LocId = basePage.LoggedInUser.UserLocation.LocationId;
            }
            int userId = basePage.LoggedInUser.UserTypeId;
            if (userId == Convert.ToInt32(UserType.Admin) || userId == Convert.ToInt32(UserType.SuperAdmin))
            {
                int Locid = 62;
                lstBillD = generateInvoiceBal.ReadPreviewEmailShow(Locid);
            }
            else
            {
                lstBillD = generateInvoiceBal.ReadPreviewEmailShow(LocId);
            }
            int flagg = Convert.ToInt32(Session["flag"]);
            // lblAddressInvoice.Text = lstBillD[0].AgentDetails.AgentAddress;
            // lblemailAddress.Text = lstBillD[0].AgentDetails.AgentEmail;
            lblfaxNumber.Text = lstBillD[0].AgentDetails.AgentFax;
            lblPhoneNumber.Text = lstBillD[0].AgentDetails.AgentPhone;
            string AgentName = Convert.ToString(Session["AgentName"]);
            string AgentAddress = Convert.ToString(Session["AgentAddress"]);
            string AgentPhone = Convert.ToString(Session["AgentPhone"]);
            Bill billDOM = (Bill)Session["billDOM"];
            string visatype = billDOM.BillType;
            lstBillD = generateInvoiceBal.ReadBillIdByConsignmentId(id, visatype);
            if (billDOM.BillId != 0 && flagg == 2)
            {
                lblCopy.Text = "Duplicate Copy";
                lblInvoiceNo.Text = "DEL" + Convert.ToString(billDOM.BillId);
            }
            else if (lstBillD.Count == 0)
            {
                GenerateInvoiceBAL generateBal = new GenerateInvoiceBAL();
                List<Bill> lstBill = new List<Bill>();
                lstBill = generateBal.ReadMaxBillIdForPrint();
                lblInvoiceNo.Text = "DEL" + Convert.ToString(lstBill[0].BillId + 1);
                ImgbtnPrint.Visible = false;
            }
            else if (flagg == 1)
            {
                ImgbtnPrint.Visible = true;
            }
            else
            {
                lblInvoiceNo.Text = "DEL" + Convert.ToString(lstBillD[0].BillId);
            }
            if (userId == Convert.ToInt32(UserType.Admin) || userId == Convert.ToInt32(UserType.SuperAdmin))
            {
                lstCon = consignmentBal.ReadDataByPaxConsignmentId(id, 0);
                lstConn = consignmentBal.ReadDataByConsignmentId(id, 0);
            }
            else
            {
                lstCon = consignmentBal.ReadDataByPaxConsignmentId(id, LocId);
                lstConn = consignmentBal.ReadDataByConsignmentId(id, LocId);
            }
            var lst = lstCon.Select(a => new { a.pax.PaxName }).Distinct().ToList();
            if (lst.Count != 0)
            {
                string str = "";

                for (int i = 0; i < lstCon.Count; i++)
                {

                    if (str == "")
                    {
                        str = lstCon[i].pax.PaxName;
                    }
                    else
                    {
                        str += "," + lstCon[i].pax.PaxName;
                    }

                }

                //lblCorporatepax.Text = str.ToString();
                lblpax.Text = str;

                lblCorpName.Text = lstConn[0].CgCorporate;
            }
            lblRef.Text = "DEL" + Convert.ToString(id);
            lblserviceCharge.Text = Convert.ToString(billDOM.ServiceCharge);
            int servicecharge = Convert.ToInt32(billDOM.ServiceCharge);
            lblserviceTax.Text = Convert.ToString(Math.Round(billDOM.ServiceTax, 2));
            decimal totalAmounts = decimal.Zero;
            foreach (BillItem billItem in billDOM.BillItemDetails)
            {
                billItem.BillItemDescription = billItem.BillItemDescription;
                billItem.ItemCharge = billItem.ItemCharge;
                billItem.ItemQuantity = billItem.ItemQuantity;
                billItem.ItemAmount = billItem.ItemAmount;
                totalAmounts = totalAmounts + billItem.ItemAmount;
                lstBillItem.Add(billItem);
            }
            double taxAmount = 00.00;
            if (servicecharge == 0)
            {
                // lblServicetaxCharge.Text = "12.36" + "%";
                //double tax = 12.36;
                //double amount = Convert.ToDouble(totalAmounts);

                //lblServicetaxCharge.Text = "(" + Convert.ToString(Math.Round((amount * tax) / 100, 2)) + "%" + ")";
               // lblServicetaxCharge.Text = "0";
            }
            else
            {
                double tax = 12.36;
                //double amount =Convert.ToDouble(totalAmounts);
                // lblServicetaxCharge.Text = "(" + Convert.ToString(Math.Round((billDOM.ServiceTax * 100) / servicecharge, 2)) + "%" + ")";
                var taxs = Convert.ToString(Math.Round((servicecharge * tax) / 100));
                //lblServicetaxCharge.Text = taxs;
                taxAmount = taxAmount + Convert.ToDouble(taxs);
                lblserviceTax.Text =Convert.ToString(taxAmount);
            }



            lblCorpName.Text = lstConn[0].CgCorporate;
            //lbltotalAmt.Text = Convert.ToString(Math.Round(billDOM.TotalAmount, 2));
            lbltotalAmt.Text = Convert.ToString(totalAmounts);
            lblNetAmt.Text = Convert.ToString(Math.Round((totalAmounts + billDOM.ServiceCharge +Convert.ToDecimal(taxAmount)))) +".00";
            lblpax.Text = Convert.ToString(billDOM.Paxs);
            lblDate.Text = Convert.ToString(billDOM.BillDate);
            lblName.Text = Convert.ToString(AgentName);
            lblAddress.Text = Convert.ToString(AgentAddress);
            lblPhone.Text = Convert.ToString(AgentPhone);
            billDOM.BillConsignment = new Consignment();



            gvPreviewInvoice.DataSource = lstBillItem;
            gvPreviewInvoice.DataBind();
            Decimal Total = Convert.ToDecimal(lblNetAmt.Text);
            Int64 NumVal = (Int64)Total;
            lblAmountNet.Text = Rupees(NumVal);
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
            result = result + ' ' + " Rupees ";
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
            //printOption.Visible = false;
            //ImgbtnPrint.Attributes.Add("onclick", "window.print();");
        }
    }
}