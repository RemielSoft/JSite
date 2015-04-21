using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    public class BillRegister : BaseDomainObjectModel
    {
        public String Date { get; set; }
        public Int64 BillNo { get; set; }
        public String PaxName { get; set; }
        public String PartyName { get; set; }
        public String VisaCountry { get; set; }
        public Decimal Visa { get; set; }
        public Decimal Attestation { get; set; }
        public Decimal Token { get; set; }
        public Decimal Vfs { get; set; }
        public Decimal Handling { get; set; }
        public Decimal Courior { get; set; }
        public Decimal Delivery { get; set; }
        public Decimal Convenience { get; set; }
        public Decimal Urgent { get; set; }
        public Decimal Draft { get; set; }
        public Decimal Insurance { get; set; }
        public Decimal OtherCharge { get; set; }
        public Decimal ServiceCharge { get; set; }
        public Decimal ServiceTax { get; set; }
        public Decimal Amount { get; set; }

        public Consignment RegisterConsignment { get; set; }
        public Bill RegisterBill { get; set; }
    }
}
