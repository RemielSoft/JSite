using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    [Serializable]
    public class Pax:BaseDomainObjectModel
    {
        
        public Consignment Consignment { get; set; }
        public Location location { get; set; }
        public int PaxId { get; set; }

        public string PaxName { get; set; }
        public string PaxPassportNo { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string PaxTicket { get; set; }
        public string PaxTicketRemark { get; set; }

        public string PaxMedInsurance { get; set; }
        public string PaxMedInsuranceRemark { get; set; }
        public string PaxCreditCard { get; set; }
        public string PaxCreditCardRemark { get; set; }

        public string PaxCertificates { get; set; }
        public string PaxCertificatesRemark { get; set; }
        public string PaxItPaper { get; set; }
        public string PaxItPaperRemark { get; set; }
        public string PaxDraft { get; set; }
        public string PaxDraftRemark { get; set; }

        public string PaxOther { get; set; }
        public string PaxOtherRemark { get; set; }
        public string PaxRemarks { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int CountryId { get; set; }

        public string UpdatedOn { get; set; }
        public string PaxVit { get; set; }       
        public AdditonalInfo AddInfo { get; set; }
        public Pax()
        {           
            this.AdditionInfoDetails = new List<AdditonalInfo>();        
        }       
        public List<AdditonalInfo> AdditionInfoDetails
        {
            get;
            set;
        }








        public string CountryName { get; set; }
        public string DescriptionOne { get; set; }
        public string DescriptionTwo { get; set; }
        public string VisaDescription { get; set; }
        public string Description { get; set; }
        public int VisaTypeOneId { get; set; }
        public int VisaTypeTwoId { get; set; }



        //public string pax_embsy_country { get; set; }
        //public string visatype { get; set; }
        //public string no_ofvisit { get; set; }
        //public string duration { get; set; }
        //public string processtime { get; set; }

        //public string VisaDescription { get; set; }

        
    }
}
