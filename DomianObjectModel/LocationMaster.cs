using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    [Serializable]
    public class LocationMaster : BaseDomainObjectModel
    {

        public int LocationId { get; set; }

        public int CityId { get; set; }

        public string LocationTitle { get; set; }

        public string City { get; set; }

        public int stateId { get; set; }

        public string stateName { get; set; }

        public string LocationAddress { get; set; }

        public string CompanyName { get; set; }


        public int CountryId { get; set; }


        public string Country { get; set; }



        //public Company CompanyDetail { get; set; }
        //public string City { get; set; }
        //public int LocationId { get; set; }

        public string LocationName { get; set; }
        // public int Location_Id { get; set; }

        ////This property needs to be removed form this class
        //public string Location_Name { get; set; }
    }
}
