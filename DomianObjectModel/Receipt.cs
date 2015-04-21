using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    public class Receipt
    {
        public Receipt()
        {
            this.AgentList = new List<Agent>();
            this.ReceiptDetail = new List<ReceiptDetails>();
            
        }

        public Int32 InvoiceNo { get; set; }

        public Decimal TotalCreditAmount { get; set; }

        public Decimal TotalDebitAmount { get; set; }

        public Decimal OutstandingAmount { get; set; }

        public String AgentAddress { get; set; }

        public String RcptType { get; set; }

        public String PaymentMode { get; set; }
               
        public Decimal TotalAdjustedAmount { get; set; }

        public Agent agent { get; set; }

        public List<Agent> AgentList { get; set; }
                
        public Int64 RcptNo { get; set; }

      

        public String Remarks { get; set; }

        public DateTime RcptDate { get; set; }

        public Decimal RcptAmount { get; set; }

        public String CreditAccount { get; set; }

        public String ChequeNo { get; set; }

        public String IssuingBank { get; set; }

        public DateTime IssuingDate { get; set; }

        public String Narration { get; set; }

        public List<ReceiptDetails> ReceiptDetail { get; set; }

        public ReceiptDetails rcptDetails { get; set; }

        public Decimal AdvAdj { get; set; }

        public String RcptNoAdvAdj { get; set; }
    }
}
