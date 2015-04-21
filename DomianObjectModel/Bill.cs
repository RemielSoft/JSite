using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    [Serializable]
    public class Bill : BaseDomainObjectModel
    {

        public int ConsignmentId { get; set; }
        public Consignment BillConsignment { get; set; }

        public int BillId { get; set; }
        public int LocationId { get; set; }
        public DateTime BillDate { get; set; }
        public String BillType { get; set; }
        public String Paxs { get; set; }
        public String IsCancelled { get; set; }
        public String IsPrinted { get; set; }
        public Decimal TotalAmount { get; set; }
        public List<BillItem> NewBillItemDetails { get; set; }
        public List<BillItem> BillItemDetails { get; set; }
        public LocationMaster BillLocation { get; set; }


        public Bill()
        {
            this.NewBillItemDetails = new List<BillItem>();
            this.BillLocation = new LocationMaster();
        }


        public decimal ServiceCharge { get; set; }
        public decimal ServiceTax { get; set; }

        public Agent AgentDetails { get; set; }
        public Embsy EmbassyMasterDetails { get; set; }
        public BillItem BillItemDetail { get; set; }
        public Decimal ItemAmount { get; set; }

        public Pax PaxDetails { get; set; }
        public Miscellaneous MiscellaneousDetails { get; set; }
        public int count { get; set; }
        public int Version { get; set; }


    }
}
