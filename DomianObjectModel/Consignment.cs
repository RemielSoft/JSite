using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    [Serializable]
    public class Consignment
    {

        public Consignment()
        {
            this.AdditionInfoDetails = new List<AdditonalInfo>();
            this.PaxDetails = new List<Pax>();

        }

        public Agent ConsignmentAgent { get; set; }
        public int FkAgentId { get; set; }
        public int ConsignmentId { get; set; }
        public string CgGroupRep { get; set; }
        public string CountryName { get; set; }


        public string PaxPaxName { get; set; }

        public string PaxNoOfPass { get; set; }



        public int CgVisaCountry { get; set; }
        public string CgOtherCountries { get; set; }
        public string CgTravelDates { get; set; }
        public DateTime CgEntryDate { get; set; }
        public DateTime? CgSubmissionDate { get; set; }
        public DateTime? CgDeliveryDate { get; set; }
        public string CgDeliveryStatus { get; set; }
        public string CgInstruction { get; set; }
        public string CgRemarks { get; set; }
        public string CgRegisterNo { get; set; }
        public string CgFinalConsNo { get; set; }        //
        public DateTime CgDate { get; set; }
        public string CgAreaCode { get; set; }        //
        public DateTime UpdatedOn { get; set; }        //
        public DateTime? CgCheckOnDate { get; set; }
        public int CgDisable { get; set; }
        public int CgNoOfPass { get; set; }
        public string CgSentBy { get; set; }
        public int CgAdminId { get; set; }
        public string CgMobNo { get; set; }
        public string CgEnteredBy { get; set; }
        public string CgCorporate { get; set; }
        public int CgNoOfDD { get; set; }
        public string CgAspMail { get; set; }

        //..............................................//
        public int Country_Id { get; set; }
        public string Location_Id { get; set; }
        public string POE_Req { get; set; }
        public int Company_Id { get; set; }
        public string CG_ID { get; set; }



        public string CgEmail { get; set; }
        public DateTime CgCollectionDate { get; set; }
        public string CgCollected { get; set; }
        public string CgBlankCollectionDate { get; set; }
        public string CgBlankSubmissionDate { get; set; }

        public List<AdditonalInfo> AdditionInfoDetails
        {
            get;
            set;
        }
        public List<Pax> PaxDetails
        {
            get;
            set;
        }
        public Location location { get; set; }
        public Pax pax { get; set; }
        public int MailId { get; set; }
        public int ConsignmentVisaStatusId { get; set; }
        public string ConsignmentVisaStatus { get; set; }
        public int ConsignmentDocumnetStatusId { get; set; }
        public string ConsignmentDocumentStatus { get; set; }

    }
}
