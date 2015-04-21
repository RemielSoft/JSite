using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Remielsoft.JetSave.DomianObjectModel
{
    [Serializable]
    public class Embsy
    {
        
        //Embassy Fees Master//

        //public int Id { get; set; }

        public string Country { get; set; }

        public Int32 CountryId { get; set; }

        public string VisaType { get; set; }

        public int VisaTypeOneId { get; set; }

        public string NoOfVisit { get; set; }

        public int VisaTypeTwoId { get; set; }
        
        public Decimal Fees { get; set; }

        public int VisaDurationId { get; set; }

        public string DurationDescription { get; set; }

        public string ProcessTimeDesc { get; set; }

        public int ProcessTimeId { get; set; }

        public Int32 EmbsyMasterId { get; set; }


        //Embassy Master//

        public Decimal TokenFee { get; set; }

        public Decimal HandlingFee { get; set; }

        public Decimal VfsBlsFee { get; set; }

        public Decimal AttastationFee { get; set; }
                
    }
}
