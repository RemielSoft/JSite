using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    [Serializable]
    public class Location :BaseDomainObjectModel
    {
        public Company CompanyDetail { get; set; }
        public string City { get; set; }
        public int LocationId { get; set; }

        public string LocationName { get; set; }
        public int Location_Id { get; set; }

        //This property needs to be removed form this class
        public string Location_Name { get; set; }
    }
}
