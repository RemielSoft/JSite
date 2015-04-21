using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    public class Holiday
    {
        public int HoliId { get; set; }

        public int CityId { get; set; }
        
        public string HoliMonth { get; set; }

        public string HoliLocation { get; set; }

        public string HoliPurpose { get; set; }

        public string HoliDetails { get; set; }

        public string HoliNotes { get; set; }

        public string rdb_mail { get; set; }

        public string rdb_website { get; set; }

        public string Country_Id { get; set; }

        public string Country_Name { get; set; }

        public string Holiday_Date { get; set; }

        public string Holiday_Day { get; set; }

        public string Holiday_Name { get; set; }

        public string Holiday_Detail { get; set; }
    }
}
