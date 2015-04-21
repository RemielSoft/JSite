using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{



    public class VisaRequirement : BaseDomainObjectModel
    {
        #region Add visa info Dom

        public int ReqId { get; set; }

        public int FkCountryId { get; set; }

        public String CountryName { get; set; }

        public int stateId { get; set; }
        public string state { get; set; }
        public String FkConsulate { get; set; }

        public String VisaType { get; set; }

        public String ConAddress { get; set; }

        public String Fee { get; set; }

        public String ProcessTime { get; set; }

        public String SubmissionDays { get; set; }

        public String SubmissionTime { get; set; }

        public String CollectionDays { get; set; }

        public String CollectionTime { get; set; }

        public String VisaSectionWorkingDays { get; set; }

        public String VisaOff { get; set; }

        public String NormalFee { get; set; }

        public String UrgentFee { get; set; }

        public String Vfs { get; set; }

        public String Timings { get; set; }

        public String StudentFees { get; set; }

        public String Comments { get; set; }

        public String BasicRequirements { get; set; }

        public String Notes { get; set; }

        public String MedicalRequirement { get; set; }

        public String OtherInfo { get; set; }

        public String CopyOfInterviewDate { get; set; }

        public String GenReq { get; set; }

        public String NormalCollection { get; set; }

        public String MyApplication { get; set; }

        #endregion

        public int COUNTRY_ID { get; set; }

        public int consulate_id { get; set; }

        public String consulate_name { get; set; }

        public int TYPE_ONE_ID { get; set; }

        public String DESCRIPTION_ONE { get; set; }

        public string Visa_title { get; set; }

        public string Visa_Form { get; set; }
        public bool IsSchengen { get; set; }

    }
}
