using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DataAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Remielsoft.JetSave.BusinessAccessLayer
{
    public class GenerateInvoiceBAL : BaseBusinessAccess
    {
        private GenerateInvoiceDAL generateInvoiceDal;

        private Database myDataBase;

        public GenerateInvoiceBAL()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            generateInvoiceDal = new GenerateInvoiceDAL(myDataBase);
        }

        #region Read Invoice Details

        public List<BillItem> ReadInvoiceDetals(List<AdditonalInfo> lstpax, Int32 AgentId)
        {
            Bill billDOM = new Bill();
            List<BillItem> lstBillItem = new List<BillItem>();
            List<BillItem> lstBillItemCommonChnagres = new List<BillItem>();
            List<BillItem> lstBillItemCommonCountryCharges = new List<BillItem>();
            List<BillItem> lstBillItem1 = new List<BillItem>();
            int count = lstpax.Count - 1;
            Dictionary<int, int> uniqueCountryId = new Dictionary<int, int>();
            Dictionary<int, int> unqCountryId = new Dictionary<int, int>();
            int a = 0;
            lstBillItemCommonChnagres = generateInvoiceDal.ReadInvoiceDetails(0, 0, AgentId, 0);
            for (int i = 0; i < lstpax.Count; i++)
            {
                int visaTypeOneId = lstpax[i].VisaTypeOneId;
                int visaTypeTwoId = lstpax[i].VisaTypeTwoId;
                int CountryId = lstpax[i].CountryId;
                if (uniqueCountryId.ContainsKey(CountryId))
                {
                    //lstBillItem = generateInvoiceDal.ReadInvoiceDetails(visaTypeOneId, visaTypeTwoId, AgentId, CountryId);
                }
                else
                {
                    lstBillItem = generateInvoiceDal.ReadInvoiceDetails(visaTypeOneId, visaTypeTwoId, AgentId, CountryId);
                    lstBillItemCommonCountryCharges = generateInvoiceDal.ReadInvoiceDetails(-1, -1, AgentId, CountryId);
                    lstBillItem.AddRange(lstBillItemCommonCountryCharges);
                    uniqueCountryId.Add(CountryId, 0);
                    if (lstBillItem.Count > 0)
                    {
                        lstBillItem1.AddRange(lstBillItem);
                    }
                }

            }
            if (lstBillItemCommonChnagres.Count > 0)
            {
                lstBillItem1.AddRange(lstBillItemCommonChnagres);
            }
            return lstBillItem1;
        }
        #endregion

        #region Read Service Tax

        public List<Bill> ReadServiceTax()
        {
            List<Bill> lstServiceTax = new List<Bill>();
            lstServiceTax = generateInvoiceDal.ReadServiceTax();
            return lstServiceTax;

        }

        #endregion
        #region Read Version Number

        public List<Bill> ReadVersionNumber(int no)
        {
            List<Bill> lst = new List<Bill>();
            lst = generateInvoiceDal.ReadVersionNumber(no);
            return lst;

        }

        #endregion

        #region Login SuperAdmin

        public int LoginWithSuperAdmin(string UserName, string password)
        {
            int RtValues = generateInvoiceDal.LoginWithSuperAdmin(UserName, password);
            return RtValues;
        }

        #endregion

        #region Read  Email For Preview Invoice

        public List<Bill> ReadPreviewEmailShow(int LocId)
        {
            List<Bill> lstEmail = new List<Bill>();
            lstEmail = generateInvoiceDal.ReadPreviewEmailShow(LocId);
            return lstEmail;

        }

        #endregion

        #region Read Service Charge

        public List<Bill> ReadServiceCharge()
        {
            List<Bill> lstServiceCharge = new List<Bill>();
            lstServiceCharge = generateInvoiceDal.ReadServiceCharge();
            return lstServiceCharge;

        }

        #endregion

        #region Read Micellaneous Charge

        public List<Miscellaneous> ReadMicCharge(string description)
        {
            List<Miscellaneous> lstMicCharge = new List<Miscellaneous>();
            return lstMicCharge = generateInvoiceDal.ReadMicCharges(description);
        }

        #endregion

        #region Generate Invoice

        public int CreateInvoice(Bill billDOM)
        {
            int LoCation = billDOM.LocationId;
            int billId = generateInvoiceDal.CreateInvoice(billDOM);
            foreach (BillItem billDetails in billDOM.BillItemDetails)
            {
                billDetails.BillItemId = billId;
                billDetails.LocationId = LoCation;
                generateInvoiceDal.CreateBillDetails(billDetails);

            }

            return billId;
        }

        #endregion

        #region Update Invoice

        public void UpdateInvoice(Bill billDOM, int version, int billid)
        {
            int i = 0;
            generateInvoiceDal.UpdateInvoice(billDOM, version, billid);
            List<BillItem> lst = generateInvoiceDal.ReadBillIDBill(billid, 0);

            foreach (BillItem billDetails in billDOM.BillItemDetails)
            {
                if (i<lst.Count)
                {
                    int id = Convert.ToInt32(lst[i].BillItemId);
                    generateInvoiceDal.UpdateBillDetails(billDetails, version, billid, id);
                }
                else
                {
                    generateInvoiceDal.CreateModBillDetails(billDetails, billid,version);
                }
                i++;
            }

        }

        #endregion

        #region Read Bill Id By ConsignmentId
        public List<Bill> ReadBillIdByConsignmentId(int id, string VisaType)
        {
            List<Bill> lstBill = new List<Bill>();
            lstBill = generateInvoiceDal.ReadBillIdByConsignmentId(id, VisaType);
            return lstBill;
        }
        #endregion

        #region Read Bill Item for RePrinting

        public List<BillItem> ReadBillItemRePrintInvoice(int billid, int? LocId, int? version)
        {
            List<BillItem> lstBillItem = new List<BillItem>();
            lstBillItem = generateInvoiceDal.ReadBillItemPePrintInvoice(billid, LocId, version);
            return lstBillItem;
        }

        #endregion

        #region Read Bill Charge for Reprinting

        public List<Bill> ReadBillRePrintInvoice(string InvoiceType, int? LocId)
        {
            List<Bill> lstBill = new List<Bill>();
            lstBill = generateInvoiceDal.ReadBillRePrintInvoice(InvoiceType, LocId);
            return lstBill;
        }

        #endregion

        #region Read Bill Charge for Reprinting By ConsignmentId

        public List<Bill> ReadBillRePrintInvoiceByConsignmentId(int ConsignmentId, int? LocId)
        {
            List<Bill> lstBill = new List<Bill>();
            lstBill = generateInvoiceDal.ReadBillRePrintInvoiceByConsignmentId(ConsignmentId, LocId);
            return lstBill;
        }


        public List<Bill> ReadBillRePrintInvoiceByBilId(int Billid, int? LocId,int version)
        {
            List<Bill> lstBill = new List<Bill>();
            lstBill = generateInvoiceDal.ReadBillRePrintInvoiceByBilId(Billid, LocId, version);
            return lstBill;
        }


        public List<Bill> ReadCountCGIDBill(int CgId)
        {
            List<Bill> lstBill = new List<Bill>();
            lstBill = generateInvoiceDal.ReadCountCGIDBill(CgId);
            return lstBill;
        }

        #endregion

        #region Read Bill Charge for Reprinting By Agent Name

        public List<Bill> ReadBillRePrintInvoiceByAgentName(string agentName, int? LocId)
        {
            List<Bill> lstBill = new List<Bill>();
            lstBill = generateInvoiceDal.ReadBillRePrintInvoiceByAgentName(agentName, LocId);
            return lstBill;
        }

        #endregion

        #region Read Consignment Details By Date For Print Invoice

        public List<Bill> ReadConsignmentDetailsByDate(DateTime FromDate, DateTime ToDate, int? LocId)
        {
            List<Bill> lstBill = new List<Bill>();
            lstBill = generateInvoiceDal.ReadConsignmentDetailsByDate(FromDate, ToDate, LocId);
            return lstBill;
        }

        #endregion

        #region Read Consignment Details By ConsignmentId For Print Invoice

        public List<Bill> ReadConsignmentDetailsById(int id, int? LocId)
        {
            List<Bill> lstBill = new List<Bill>();
            lstBill = generateInvoiceDal.ReadConsignmentDetailsById(id, LocId);
            return lstBill;
        }

        public List<Bill> ReadReceiptBYConsignment(int consignmentNo, int? LocId)
        {
            return generateInvoiceDal.ReadReceiptBYConsignment(consignmentNo, LocId);
        }

        public List<Bill> ReadReceiptBYAgentName(string agentName, int? LocId)
        {
            return generateInvoiceDal.ReadReceiptBYAgentName(agentName, LocId);
        }
        public List<Bill> ReadConsignmentByIdAdvanceSearch(int consignmentId, int? locationId)
        {

            List<Bill> lstBill = new List<Bill>();
            lstBill = generateInvoiceDal.ReadConsignmentByIdAdvanceSearch(consignmentId, locationId);
            return lstBill;
        }
        #endregion

        #region Read Consignment Details By AgentName For Print Invoice

        public List<Bill> ReadConsignmentDetailsByAgentName(string agentName, int? LocId)
        {
            List<Bill> lstBill = new List<Bill>();
            lstBill = generateInvoiceDal.ReadConsignmentDetailsByAgentName(agentName, LocId);
            return lstBill;
        }

        public List<Bill> ReadConsignmentDetailsByAgentNameAndDate(string agentName,DateTime FromDate, DateTime ToDate)
        {
            List<Bill> lstBill = new List<Bill>();
            lstBill = generateInvoiceDal.ReadConsignmentDetailsByAgentNameAndDate(agentName, FromDate, ToDate);
            return lstBill;
        }


        #endregion

        #region Read Invoice No By ConsignmentId for print Invoice

        public List<Bill> ReadMaxBillIdForPrint()
        {
            List<Bill> lstBill = new List<Bill>();
            lstBill = generateInvoiceDal.ReadMaxBillIdForPrint();
            return lstBill;
        }

        #endregion
    }

}
