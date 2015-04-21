using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    [Serializable]
    public class BillItem : BaseDomainObjectModel
    {
        public int BillItemId { get; set; }
        public string BillItemDescription { get; set; }
        public bool IsServiceCharge { get; set; }
        public bool IsCountryVisaFee { get; set; }
        public decimal ItemCharge { get; set; }
        public int ItemQuantity { get; set; }
        public Decimal ItemAmount { get; set; }
        public Decimal TotalAmount { get; set; }
        public int LocationId { get; set; }
        public int CountryId { get; set; }



    }
}






