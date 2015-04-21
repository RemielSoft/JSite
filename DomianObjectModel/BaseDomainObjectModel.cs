using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    [Serializable]
   public class BaseDomainObjectModel
    {
        public String Created_By { get; set; }

        public DateTime Created_Date { get; set; }

        public String Modified_By { get; set; }

        public DateTime Modified_Date { get; set; }
    }
}
