using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    [Serializable]
    public class Agent:BaseDomainObjectModel
    {
        public int AgentId { get; set; }

        public int AgentLocationId { get; set; }

        public string AgentUserName { get; set; }

        public string AgentPassword { get; set; }

        public string AgentCPerson { get; set; }

        public string AgentName { get; set; }

        public string AgentAddress { get; set; }

        public string AgentCity { get; set; }

        public int AgentCityId { get; set; }
        public int AgentStateId { get; set; }
        public int AgentCountryId { get; set; }
        public string AgentCityName { get; set; }
        public string AgentStateName { get; set; }
        public string AgentCountryName { get; set; }

        public string AgentPin { get; set; }

        public string AgentEmail { get; set; }

        public string AgentPhone { get; set; }

        public string AgentFax { get; set; }

        public string AgentEnable { get; set; }

        public int AgentPrority { get; set; }

        public decimal AgentSCharge { get; set; }

        public decimal AgentCCharge { get; set; }

        public string TallyAcName { get; set; }

        public decimal AgentDDCharge { get; set; }

        public decimal OpeningBalance { get; set; }

        public String Created_By { get; set; }
    }
}
