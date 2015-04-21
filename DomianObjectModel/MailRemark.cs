using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    [Serializable]
   public  class MailRemark:BaseDomainObjectModel
    {
        public string ConsignmentId { get; set; }
        public string CountryName { get; set; }
        public int MailId { get; set; }
        public int CountryId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public DateTime CheckOnDate { get; set; }
        public DateTime CollectionDate { get; set; }
        public string Remarks { get; set; }
        public int CollectedFlag { get; set; }
        public Location location { get; set; }
    }
}
