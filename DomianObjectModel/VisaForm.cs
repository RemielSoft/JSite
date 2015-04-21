using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    [Serializable]
    public class VisaForm :BaseDomainObjectModel
    {
        
        public int Id { get; set; }
        public string VisaCity { get; set; }
        public string CountryForVisa { get; set; }
        public string VisaTitle { get; set; }
        public string Form { get; set; }
        public string Created_By { get; set; }
        public int LocationId { get; set; }


        /// <summary>
        /// Added by Divaker ..
        /// </summary>
        public string FilePath { get; set; }
        public int CountryId { get; set; }
        public string Type { get; set; }

    }
}
