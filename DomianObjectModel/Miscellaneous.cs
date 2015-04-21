using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Remielsoft.JetSave.DomianObjectModel
{
    [Serializable]
  public   class Miscellaneous
    {
        public int Id { get; set; }


        public string Description{ get; set; }

        public Decimal Amount { get; set; }

        public string Per_consignment { get; set; }

        public string Mandatory { get; set; }

        public string ServiceCharges { get; set; }
        public string ServiceTax { get; set; }

        // for Invoice
        public int Quantity { get; set; }

        public decimal Charge { get; set; }
    }
} 
