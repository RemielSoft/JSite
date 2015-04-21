using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.DataAccessLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Remielsoft.JetSave.BusinessAccessLayer
{
    public class ReceiptGenerationBusinessAccess:BaseBusinessAccess
    {
        ReceiptGenerationDataAccess RcptGenrDataAccess;
        Database myDatabase;
        public ReceiptGenerationBusinessAccess()
        {
            myDatabase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            RcptGenrDataAccess = new ReceiptGenerationDataAccess(myDatabase);
        }

        public List<Agent> ReadAgentAddress(Int32 AgentId)
        {
            return RcptGenrDataAccess.ReadAgentAddress(AgentId);
        }

        public List<Receipt> OutstandingAmount(Int32 AgentId)
        {
            return RcptGenrDataAccess.ReadOutstandingAmount(AgentId);
        }
        public List<Receipt> AdjustmentAmount(Int32 AgentId)
        {
            return RcptGenrDataAccess.AdjustmentAmount(AgentId);
        }
        public List<Receipt> BindInvoice(Int32 AgentId, int? LocId)
        {
            return RcptGenrDataAccess.BindInvoiceNo(AgentId, LocId);
        }

        public List<ReceiptDetails> ReceiptDetail(Int32 InvoiceId,int? LocId)
        {
            return RcptGenrDataAccess.ReadReceiptDetail(InvoiceId, LocId);
        }

        public int InsertReceipt(Receipt receipt, int LocId)
        {
            int RcptId = RcptGenrDataAccess.InsertReceipt(receipt, LocId);

            foreach (ReceiptDetails item in receipt.ReceiptDetail)
            {
                item.FkRcptId = RcptId;
                item.LocationId = LocId;
                RcptGenrDataAccess.InsertReceiptDetail(item);
            }
            return RcptId;
        }
        public void InsertAdustedAmount(ReceiptDetails recipt)
        {
            RcptGenrDataAccess.InsertReceiptDetail(recipt);
        
        }
        public void InsertAdustedAmount1(ReceiptDetails recipt)
        {
            RcptGenrDataAccess.InsertReceiptDetail1(recipt);

        }
        public List<Receipt> ReadRcptAll(Int32 RcptId,int? LocId)
        {
            return RcptGenrDataAccess.ReadReceitpAll(RcptId, LocId);
        }

        public List<ReceiptDetails> ReadRcptDetailsByRcptNo(Int32 RcptId)
        {
            return RcptGenrDataAccess.ReadReceitpDetailsByRcptNo(RcptId);
        }

        public void UpdateReceipt(Receipt receipt)
        {
            RcptGenrDataAccess.UpdateReceipt(receipt);
        }

        public void DeleteReceipt(Int32 RcptId)
        {
            RcptGenrDataAccess.DeleteReceipt(RcptId);
        }
        public List<ReceiptDetails> ReadTotalAdjustedAmount(Int64 RcptId)
        {
            List<ReceiptDetails> lst = new List<ReceiptDetails>();
            lst = RcptGenrDataAccess.ReadTotalAdjustedAmount(RcptId);
            return lst;
        }
        public void UpdateAdjustedReciept(Receipt receipt, Int64 reciptId)
        {
            RcptGenrDataAccess.UpdateAdjustedReciept(receipt,reciptId);
        }
    }
}
