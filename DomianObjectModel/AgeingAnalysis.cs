using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    public class AgeingAnalysis
    {
        public int AgeingId { get; set; }
        
        public Int32 AgentId { get; set; }
        
        public String AgentName { get; set; }

        public Decimal TotalBillAmt { get; set; }

        public Decimal TotalRcptAmt { get; set; }

        public DateTime BillStartDate { get; set; }

        public DateTime BillLastDate { get; set; }

        public DateTime ReceiptStartDate { get; set; }

        public DateTime ReceiptLastDate { get; set; }

        public Decimal ReceiptAmount { get; set; }

        public Decimal UnallocatedAmount { get; set; }

        public Int32 NumDays { get; set; }

        public Decimal UnadjAmt { get; set; }

        public String Ageingdays { get; set; }

        public Decimal Balance { get; set; }
    }
}
