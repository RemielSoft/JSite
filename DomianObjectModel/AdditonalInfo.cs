using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    [Serializable]
   public  class AdditonalInfo
   {
       public int AddinfoId { get; set; }
        public int VisaTypeOneId { get; set; }
        public int VisaTypeTwoId { get; set; }
        public int GroupId{ get; set; }
        public int ProcessTimeId { get; set; }
        public int CountryId { get; set; }
        public string DescriptionOne { get; set; }
        public string DescriptionTwo { get; set; }
        public string GroupName { get; set; }
        public string CountryName { get; set; }
        public string  Description { get; set; }
        public Pax pax { get; set; }
        public Consignment consignment { get; set; }
        public Location location { get; set; }
        //public string PaxPassportNo { get; set; }
        //public string PaxName { get; set; }
        public int TempIndex { get; set; }
   }
}
