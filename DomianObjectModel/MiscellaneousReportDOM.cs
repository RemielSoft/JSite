using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    public class MiscellaneousReportDOM
    {
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ServiceCharge { get; set; }
        public decimal ServiceTax { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string EmailId { get; set; }
        public string City { get; set; }
        public DateTime? BillDate { get; set; }

       
    }
}
