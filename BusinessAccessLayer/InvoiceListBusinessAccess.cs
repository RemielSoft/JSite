using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DataAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;



namespace Remielsoft.JetSave.BusinessAccessLayer
{
    public class InvoiceListBusinessAccess : BaseBusinessAccess
    {
        private Database myDataBase;
        private InvoiceListDataAccess invoiceListDal;

        public InvoiceListBusinessAccess()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            invoiceListDal = new InvoiceListDataAccess(myDataBase);
        }


        public List<Bill> ReadDataByInvoiceConsignmentId(int consignmentId, int? LocId)
        {
            return invoiceListDal.ReadDataByInvoiceConsignmentId(consignmentId,LocId);
        }

        public List<Bill> ReadDataByInvoiceBillId(int billId, int? LocId)
        {
            return invoiceListDal.ReadDataByInvoiceBillId(billId,LocId);
        }

        public List<Bill> ReadDataByReceiptId(int receiptId,int? LocId)
        {
            return invoiceListDal.ReadDataByReceiptId(receiptId, LocId);
        }

        public List<Bill> ReadDataByReceiptDates(DateTime fromDate, DateTime toDate, int? LocId)
        {
            return invoiceListDal.ReadDataByReceiptDates(fromDate, toDate,LocId);
        }

        public List<Bill> ReadDataByInvoiceDates(DateTime fromDate, DateTime toDate, int? LocId)
        {
            return invoiceListDal.ReadDataByInvoiceDates(fromDate, toDate,LocId);
        }

    }
}
