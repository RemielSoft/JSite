using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
   public class AdvanceSearchDom
    {
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int ConsignmentId { get; set; }
        public string VisaCountry { get; set; }
        public string PaxName { get; set; }
        public string PPTNo { get; set; }
        public string AreaCode { get; set; }
        public DateTime SubmissionDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryStatus { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? FromDate { get; set; }
        public Int64 TotalVisa { get; set; }
        public int IsDeleted { get; set; }
        public DateTime Created_Date { get; set; }
        public string Created_By { get; set; }
        public string Modified_By { get; set; }
        public DateTime Modified_Date { get; set; }
    }
}
