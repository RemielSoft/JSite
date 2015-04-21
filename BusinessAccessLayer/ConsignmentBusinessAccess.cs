using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DataAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;



namespace Remielsoft.JetSave.BusinessAccessLayer
{
   public  class ConsignmentBusinessAccess:BaseBusinessAccess
    {
        private Database myDataBase;
        private ConsignmentDataAccess ConsignDal;
        public ConsignmentBusinessAccess()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            ConsignDal = new ConsignmentDataAccess(myDataBase);
        }
        #region consignment....

        public int CreateConsignment(Consignment consignment)
        {
            int Id = ConsignDal.CreateConsignment(consignment);
            foreach (AdditonalInfo item in consignment.AdditionInfoDetails)
            {
                item.consignment = new Consignment();              
                item.consignment.CG_ID = Convert.ToString(Id);               
                int paxId = ConsignDal.CreatePax(item);
                item.consignment.CG_ID = Convert.ToString(Id);
                item.pax.PaxId = paxId;
                ConsignDal.CreateAdditonalPax(item);          

            }
            return Id;
        }
        public void paxConsignment(Consignment consignment, int Id)
        {
           foreach (AdditonalInfo item in consignment.AdditionInfoDetails)
            {
                item.consignment = new Consignment();               
                item.consignment.CG_ID = Convert.ToString(Id);               
                int paxId = ConsignDal.CreatePax(item);
                item.consignment.CG_ID = Convert.ToString(Id);
                item.pax.PaxId = paxId;
                ConsignDal.CreateAdditonalPax(item);          

            }          
        }
        public String ReadDataFromPaxByPassPortNo(string passportNo)
        {
            return ConsignDal.ReadDataFromPaxByPassPortNo(passportNo);
        }
        public void UpdateConsignment(Consignment consignment, int consignmentId)
        {
            ConsignDal.UpdateConsignment(consignment, consignmentId);
        }       
        public void DeleteConsignment(int id)
        {
            ConsignDal.DeleteConsignment(id);
        }
        public void UpdateConsignmentStatus(Consignment consignment, int consignmentId)
        {
            ConsignDal.UpdateConsignmentStatus(consignment, consignmentId);
        }

        public List<Consignment> ReadDataByConsignmentId(int consignmentId, int? locationId)
        {
            return ConsignDal.ReadDataByConsignmentId(consignmentId, locationId);
        }
        public List<Consignment> ReadConsignmentDataByDates(DateTime? fromDate, DateTime? toDate, Int32 countryId, Int32 agentId, int? locationId, string paxname, string noofpassport, string deliveryStatus, Int32 consignmentNo, string corporatename, out string exception)
        {
            return ConsignDal.ReadConsignmentDataByDates(fromDate, toDate, countryId, agentId, locationId, paxname, noofpassport, deliveryStatus, consignmentNo, corporatename,out exception);
        }
        public List<Consignment> ReadConsignmentDataByCountryName(string countryName,int locationId)
        {
            return ConsignDal.ReadConsignmentDataByCountryName(countryName, locationId);
        }

        #endregion
     
        #region pax...      
       

        public void UpdatePax(Pax pax, int paxId)
        {
            ConsignDal.UpdatePax(pax, paxId);
        }
        public void DeletePax(int id, int paxId)
        {
            ConsignDal.DeletePax(id,paxId);
        }

        public List<AdditonalInfo> ReadDataByPaxConsignmentId(int id, int? LocId)
        {
            return ConsignDal.ReadDataByPaxConsignmentId(id, LocId);
        }    
        public List<Pax> ReadDataByPaxId(int id,int locationId)
        {
            return ConsignDal.ReadDataByPaxId(id, locationId);
        }
        public List<Pax> ReadDataByPaxsConsignmentId(int id, int locationId)
        {
            return ConsignDal.ReadDataByPaxsConsignmentId(id, locationId);
        }
        public void UpdateAdditionalPax(AdditonalInfo addinfo, int AddInfoId)
        {
            ConsignDal.UpdateAdditionalPax(addinfo, AddInfoId);
        }

        public List<AdditonalInfo> ReadAdditonalPaxCountry(int consignmentId)
        {
            return ConsignDal.ReadAdditonalPaxCountry(consignmentId);
        }
        public List<AdditonalInfo> ReadDataByAdditonalPaxId(int id, int? LocId)
        {
            return ConsignDal.ReadDataByAdditonalPaxId(id, LocId);
        }
        public List<AdditonalInfo> ReadDataByAdditonalPaxsId(int id, int? LocId)
        {
            return ConsignDal.ReadDataByAdditonalPaxsId(id, LocId);
        }

        public List<AdditonalInfo> ReadCountry(int country_id)
        {
            return ConsignDal.ReadCountry(country_id);
        }
        public List<AdditonalInfo> ReadVisaType(int MyEmbassyId)
        {
            return ConsignDal.ReadVisaType(MyEmbassyId);
        }
        public List<AdditonalInfo> ReadNo_Of_Visit(int MyEmbassyId, int MyVisaTypeId)
        {
            return ConsignDal.ReadNo_Of_Visit(MyEmbassyId, MyVisaTypeId);
        }
       
        public List<AdditonalInfo> ReadProcessTime(int MyVisaTypeId, int MyNoofEntry, int MyEmbassyId, int MyVisaDurationId)
        {
            return ConsignDal.ReadProcessTime(MyVisaTypeId, MyNoofEntry, MyEmbassyId, MyVisaDurationId);
        }


        #endregion


        //#region..mailremark..

        //public void CreateAnotherMailRemarks(MailRemark mailRemarks, string id)
        //{
        //    ConsignDal.CreateAnotherMailRemarks(mailRemarks, id);
        //}
        //public void updateMailRemarks(MailRemark mailRemarks, int MailId)
        //{
        //    ConsignDal.updateMailRemarks(mailRemarks, MailId);
        //}

        //public List<MailRemark> ReadDataByMailRemarkid(string mailremId, int locationId)
        //{
        //    return ConsignDal.ReadDataByMailRemarkid(mailremId, locationId);
        //}
        //public List<MailRemark> ReadAnotherMailRemarkid(int mailremId)
        //{
        //    return ConsignDal.ReadAnotherMailRemarkid(mailremId);

        //}

        //#endregion      
        
    }
}
