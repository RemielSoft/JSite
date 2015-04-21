using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    public  class StatementOfAccDom
    {
        public string  Narration { get; set; }
        public string Particular { get; set; }
        public string DocDate { get; set; }
        public decimal CrAmount { get; set; }
        public decimal DrAmount { get; set; }
        public decimal TotalAmmount { get; set; }
        public string AgentName  { get; set; }
        public string AgentAddress { get; set; }
        public string InvoiceType { get; set; }
        public Decimal Balance { get; set; }
        public decimal BalanceOpening { get; set; }
        public int AgentId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

    }
}
