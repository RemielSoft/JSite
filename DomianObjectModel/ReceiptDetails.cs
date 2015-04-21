using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    public class ReceiptDetails
    {
        public Int32 InvoiceNo { get; set; }

        public DateTime InvoiceDate { get; set; }

        public Decimal InvoiceAmount { get; set; }

        public Decimal AdjustedAmount { get; set; }

        public Decimal TotalAdjustedAmount { get; set; }

        public Int64 FkRcptId { get; set; }

        public Decimal UnAdjustedAmt { get; set; }

        public Int32 LocationId { get; set; }
    }
}
