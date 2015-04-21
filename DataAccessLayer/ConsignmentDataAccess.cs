using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace Remielsoft.JetSave.DataAccessLayer
{
    public class ConsignmentDataAccess : BaseDataAccess
    {
        private Database myDataBase;
        public ConsignmentDataAccess(Database m_database)
        {
            myDataBase = m_database;
        }

        #region Consignment ......

        public int CreateConsignment(Consignment consignment)
        {
            int consignmentId;
            //  consignment.ConsignmentAgent = new Agent();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.INSERT_CONSIGNMENT);
            dbCommand.CommandType = CommandType.StoredProcedure;
            

            myDataBase.AddInParameter(dbCommand, "@Location_Id", DbType.String, consignment.location.Location_Id);
            myDataBase.AddInParameter(dbCommand, "@FK_AGENT_ID", DbType.Int32, consignment.ConsignmentAgent.AgentId);            
            myDataBase.AddInParameter(dbCommand, "@CG_VISACOUNTRY", DbType.Int32, consignment.CgVisaCountry);
            myDataBase.AddInParameter(dbCommand, "@CG_OTHER_COUNTRIES", DbType.String, consignment.CgOtherCountries);
            if (consignment.CgSubmissionDate == DateTime.MinValue)
            {
                myDataBase.AddInParameter(dbCommand, "@CG_SUBMISSION_DATE", DbType.DateTime, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@CG_SUBMISSION_DATE", DbType.DateTime, consignment.CgSubmissionDate);
            }
            if (consignment.CgTravelDates == null)
            {
                myDataBase.AddInParameter(dbCommand, "@CG_TRAVEL_DATES", DbType.String, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@CG_TRAVEL_DATES", DbType.String, consignment.CgTravelDates);
            }
            if (consignment.CgCheckOnDate == DateTime.MinValue)
            {
                myDataBase.AddInParameter(dbCommand, "@CG_CHECK_ON_DATE", DbType.DateTime, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@CG_CHECK_ON_DATE", DbType.DateTime, consignment.CgCheckOnDate);
            }
            if (consignment.CgDeliveryDate == DateTime.MinValue)
            {
                myDataBase.AddInParameter(dbCommand, "@CG_DELIVERYDATE", DbType.DateTime, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@CG_DELIVERYDATE", DbType.DateTime, consignment.CgDeliveryDate);
            }
            myDataBase.AddInParameter(dbCommand, "@CG_GROUPREP", DbType.String, consignment.CgGroupRep);
            myDataBase.AddInParameter(dbCommand, "@CG_INSTRUCTION", DbType.String, consignment.CgInstruction);
            myDataBase.AddInParameter(dbCommand, "@CG_REMARKS", DbType.String, consignment.CgRemarks);
            myDataBase.AddInParameter(dbCommand, "@CG_AREACODE", DbType.String, consignment.CgAreaCode);
            myDataBase.AddInParameter(dbCommand, "@CG_NOOFPASS", DbType.Int32, consignment.CgNoOfPass);
            myDataBase.AddInParameter(dbCommand, "@CG_NOOFDD", DbType.Int32, consignment.CgNoOfDD);            
            myDataBase.AddInParameter(dbCommand, "@CG_ENTEREDBY", DbType.String, consignment.CgEnteredBy);
            myDataBase.AddInParameter(dbCommand, "@CG_SENTBY  ", DbType.String, consignment.CgSentBy);
            myDataBase.AddInParameter(dbCommand, "@CG_CORPORATE", DbType.String, consignment.CgCorporate);
            myDataBase.AddInParameter(dbCommand, "@CG_MOBNO", DbType.String, consignment.CgMobNo);
            myDataBase.AddInParameter(dbCommand, "@CG_ASPEMAIL", DbType.String, consignment.CgEmail);
            myDataBase.AddInParameter(dbCommand, "@UPDATED_ON", DbType.DateTime, consignment.UpdatedOn);
            myDataBase.AddInParameter(dbCommand, "@CG_DATE", DbType.DateTime, consignment.CgDate);
            myDataBase.AddInParameter(dbCommand, "@CG_ENTRY_DATE", DbType.DateTime, consignment.CgEntryDate);          
           
            myDataBase.AddOutParameter(dbCommand, "@out_CG_ID", DbType.Int32, 10);
            myDataBase.ExecuteNonQuery(dbCommand);
            int.TryParse(myDataBase.GetParameterValue(dbCommand, "@out_CG_ID").ToString(), out consignmentId);

            return consignmentId;
        }
        public void UpdateConsignment(Consignment consignment, int consignmentId)
        {


            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_CONSIGNMENT);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@CG_ID", DbType.Int32, consignmentId);
            myDataBase.AddInParameter(dbCommand, "@CG_VISACOUNTRY", DbType.Int32, consignment.CgVisaCountry);
            myDataBase.AddInParameter(dbCommand, "@CG_OTHER_COUNTRIES", DbType.String, consignment.CgOtherCountries);
            if (consignment.CgSubmissionDate == DateTime.MinValue)
            {
                myDataBase.AddInParameter(dbCommand, "@CG_SUBMISSION_DATE", DbType.DateTime, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@CG_SUBMISSION_DATE", DbType.DateTime, consignment.CgSubmissionDate);
            }
            if (consignment.CgTravelDates == null)
            {
                myDataBase.AddInParameter(dbCommand, "@CG_TRAVEL_DATES", DbType.String, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@CG_TRAVEL_DATES", DbType.String, consignment.CgTravelDates);
            }
            if (consignment.CgCheckOnDate == DateTime.MinValue)
            {
                myDataBase.AddInParameter(dbCommand, "@CG_CHECK_ON_DATE", DbType.DateTime, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@CG_CHECK_ON_DATE", DbType.DateTime, consignment.CgCheckOnDate);
            }
            if (consignment.CgDeliveryDate == DateTime.MinValue)
            {
                myDataBase.AddInParameter(dbCommand, "@CG_DELIVERYDATE", DbType.DateTime, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@CG_DELIVERYDATE", DbType.DateTime, consignment.CgDeliveryDate);
            }
            myDataBase.AddInParameter(dbCommand, "@CG_GROUPREP", DbType.String, consignment.CgGroupRep);
            myDataBase.AddInParameter(dbCommand, "@CG_INSTRUCTION", DbType.String, consignment.CgInstruction);
            myDataBase.AddInParameter(dbCommand, "@CG_REMARKS", DbType.String, consignment.CgRemarks);
            myDataBase.AddInParameter(dbCommand, "@CG_AREACODE", DbType.String, consignment.CgAreaCode);
            myDataBase.AddInParameter(dbCommand, "@CG_NOOFPASS", DbType.Int32, consignment.CgNoOfPass);
            myDataBase.AddInParameter(dbCommand, "@CG_NOOFDD", DbType.Int32, consignment.CgNoOfDD);
            myDataBase.AddInParameter(dbCommand, "@CG_ENTEREDBY", DbType.String, consignment.CgEnteredBy);
            myDataBase.AddInParameter(dbCommand, "@CG_SENTBY  ", DbType.String, consignment.CgSentBy);
            myDataBase.AddInParameter(dbCommand, "@CG_CORPORATE", DbType.String, consignment.CgCorporate);
            myDataBase.AddInParameter(dbCommand, "@CG_MOBNO", DbType.String, consignment.CgMobNo);
            myDataBase.AddInParameter(dbCommand, "@CG_ASPEMAIL", DbType.String, consignment.CgEmail);
            myDataBase.AddInParameter(dbCommand, "@UPDATED_ON", DbType.DateTime, consignment.UpdatedOn);           
            myDataBase.ExecuteNonQuery(dbCommand);




        }
        public void DeleteConsignment(int id)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.DELETE_CONSIGNMENT);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@CG_ID", DbType.Int32, id);
            myDataBase.ExecuteNonQuery(dbCommand);
        }
        public void UpdateConsignmentStatus(Consignment consignment, int consignmentId)
        {


            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_CONSIGNMENT_STATUS);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@cg_id", DbType.Int32, consignmentId);
            myDataBase.AddInParameter(dbCommand, "@ConsignmentVisaStatus", DbType.String, consignment.ConsignmentVisaStatusId);
            myDataBase.AddInParameter(dbCommand, "@ConsignmentDocumentStatus", DbType.String, consignment.ConsignmentDocumnetStatusId);
            myDataBase.ExecuteNonQuery(dbCommand);
        }

        public List<Consignment> ReadDataByConsignmentId(int consignmentId, int? locationId)
        {
            List<Consignment> lstconsign = new List<Consignment>();

            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_CONSIGNMENT_BY_CONSIGNMENT_ID);
            myDataBase.AddInParameter(dbCommand, "@consignmentNo", DbType.Int32, consignmentId);
            if (locationId == 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, locationId);
            }
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

                while (reader.Read())
                {
                    Consignment consignment = new Consignment();

                    consignment.ConsignmentAgent = new Agent();
                    consignment.ConsignmentId = GetIntegerFromDataReader(reader, "CG_ID");
                    consignment.ConsignmentAgent.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
                    consignment.FkAgentId = GetIntegerFromDataReader(reader, "FK_AGENT_ID");
                    //consignment.ConsignmentVisaStatus = GetStringFromDataReader(reader, "Visa_Status");
                    //consignment.ConsignmentDocumentStatus = GetStringFromDataReader(reader, "Document_Status");
                    consignment.CgDeliveryStatus = GetStringFromDataReader(reader, "CG_DELIVERYSTATUS");
                    consignment.CountryName = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    consignment.CgGroupRep = GetStringFromDataReader(reader, "CG_GROUPREP");
                    consignment.CgVisaCountry = GetIntegerFromDataReader(reader, "CG_VISACOUNTRY");
                    consignment.CgOtherCountries = GetStringFromDataReader(reader, "CG_OTHER_COUNTRIES");
                    // consignment.CG_COLLECTION_DATE = GetDateFromReader(reader, "CG_COLLECTION_DATE");
                    consignment.CgTravelDates = GetStringFromDataReader(reader, "CG_TRAVEL_DATES");
                    consignment.CgEntryDate = GetDateFromReader(reader, "CG_ENTRY_DATE");
                    consignment.CgSubmissionDate = GetDateFromReader(reader, "CG_SUBMISSION_DATE");
                    if (consignment.CgSubmissionDate == DateTime.MinValue)
                    {
                        consignment.CgSubmissionDate = null;
                    }
                    consignment.CgDeliveryDate = GetDateFromReader(reader, "CG_DELIVERYDATE");
                    if (consignment.CgDeliveryDate == DateTime.MinValue)
                    {
                        consignment.CgDeliveryDate = null;
                    }
                    consignment.CgCheckOnDate = GetDateFromReader(reader, "CG_CHECK_ON_DATE");
                    if (consignment.CgCheckOnDate == DateTime.MinValue)
                    {
                        consignment.CgCheckOnDate = null;
                    }
                    consignment.CgCollected = GetStringFromDataReader(reader, "CG_DELIVERYSTATUS");
                    consignment.CgInstruction = GetStringFromDataReader(reader, "CG_INSTRUCTION");
                    consignment.CgRemarks = GetStringFromDataReader(reader, "CG_REMARKS");
                    consignment.CgRegisterNo = GetStringFromDataReader(reader, "CG_REGISTER_NO");
                    consignment.CgFinalConsNo = GetStringFromDataReader(reader, "CG_FINAL_CONSNO");
                    // consignment.CgDate= GetStringFromDataReader(reader, "CG_DATE");
                    consignment.CgAreaCode = GetStringFromDataReader(reader, "CG_AREACODE");
                    //consignment.UpdatedOn= GetStringFromDataReader(reader, "UPDATED_ON");
                    
                    consignment.CgDisable = GetIntegerFromDataReader(reader, "CG_DISABLE");
                    consignment.CgNoOfPass = GetIntegerFromDataReader(reader, "CG_NOOFPASS");
                    consignment.CgSentBy = GetStringFromDataReader(reader, "CG_SENTBY");
                    consignment.CgAdminId = GetIntegerFromDataReader(reader, "CG_ADMINID");
                    consignment.CgMobNo = GetStringFromDataReader(reader, "CG_MOBNO");
                    consignment.CgEnteredBy = GetStringFromDataReader(reader, "CG_ENTEREDBY");
                    consignment.CgCorporate = GetStringFromDataReader(reader, "CG_CORPORATE");
                    consignment.CgNoOfDD = GetIntegerFromDataReader(reader, "CG_NOOFDD");
                    consignment.CgAspMail = GetStringFromDataReader(reader, "CG_ASPEMAIL");


                    lstconsign.Add(consignment);
                }
            return lstconsign;
        }
        public List<Consignment> ReadConsignmentDataByDates(DateTime? fromDate, DateTime? toDate, Int32 countryId, Int32 agentId, int? locationId, string paxname, string noofpassport, string deliveryStatus, Int32 consignmentNo, string corporatename,out string exception)
        {
          
            List<Consignment> lstgrid = new List<Consignment>();

            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_CONSIGNMENT_BY_DATES_PAX_CONSIGNMENTNO);
            //myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, locationId);
            if (fromDate == DateTime.MinValue)
            {
                myDataBase.AddInParameter(dbCommand, "@fromDate", DbType.DateTime, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@fromDate", DbType.DateTime, fromDate);
            }
            if (toDate == DateTime.MinValue)
            {
                myDataBase.AddInParameter(dbCommand, "@toDate", DbType.DateTime, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@toDate", DbType.DateTime, toDate);
            }
            if (countryId == 0)
            {
                myDataBase.AddInParameter(dbCommand, "@countryId", DbType.String, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@countryId", DbType.String, countryId);
            }
            if (agentId == 0)
            {
                myDataBase.AddInParameter(dbCommand, "@agentId", DbType.String, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@agentId", DbType.String, agentId);
            }
            if (locationId == 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, locationId);
            }



            if (paxname == null)
            {
                myDataBase.AddInParameter(dbCommand, "@PaxName", DbType.String, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@PaxName", DbType.String, paxname);
            }



            if (noofpassport == null)
            {
                myDataBase.AddInParameter(dbCommand, "@PaxPassportNo", DbType.String, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@PaxPassportNo", DbType.String, noofpassport);
            }
            if (deliveryStatus == "")
            {
                myDataBase.AddInParameter(dbCommand, "@DeliveryStatus", DbType.String, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@DeliveryStatus", DbType.String, deliveryStatus);
            }
            if (consignmentNo == 0)
            {
                myDataBase.AddInParameter(dbCommand, "@ConsignmentNo", DbType.Int32, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@ConsignmentNo", DbType.Int32, consignmentNo);
            }
            if (corporatename == null)
            {
                myDataBase.AddInParameter(dbCommand, "@CorporateName", DbType.String, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@CorporateName", DbType.String, corporatename);
            }
            try
            {
                using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
                {

                    while (reader.Read())
                    {

                        Consignment consignment = new Consignment();
                        consignment.ConsignmentAgent = new Agent();
                        consignment.pax = new Pax();
                        consignment.CountryName = GetStringFromDataReader(reader, "COUNTRY_NAME");
                        consignment.ConsignmentId = GetIntegerFromDataReader(reader, "CG_ID");
                        consignment.CgSubmissionDate = GetDateFromReader(reader, "CG_SUBMISSION_DATE");
                        consignment.CgDate = GetDateFromReader(reader, "CG_DATE");
                        if (consignment.CgSubmissionDate == DateTime.MinValue)
                        {
                            consignment.CgSubmissionDate = null;
                        }
                        consignment.CgDeliveryDate = GetDateFromReader(reader, "CG_DELIVERYDATE");
                        if (consignment.CgDeliveryDate == DateTime.MinValue)
                        {
                            consignment.CgDeliveryDate = null;
                        }
                        consignment.CgDeliveryStatus = GetStringFromDataReader(reader, "CG_DELIVERYSTATUS");
                        consignment.CgNoOfPass = GetIntegerFromDataReader(reader, "CG_NOOFPASS");
                        consignment.PaxPaxName = GetStringFromDataReader(reader, "paxNameWithComma");
                        


                        consignment.CgRemarks = GetStringFromDataReader(reader, "CG_REMARKS");
                        consignment.CgCorporate = GetStringFromDataReader(reader, "CG_CORPORATE");
                        //consignment.ConsignmentStatusId = GetIntegerFromDataReader(reader, "ConsignmentStatusId");
                        //   consignment.ConsignmentVisaStatus = GetStringFromDataReader(reader, "Visa_Status");
                        // consignment.ConsignmentDocumentStatus = GetStringFromDataReader(reader, "Document_Status");
                        consignment.ConsignmentAgent.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
                        // consignment.pax.PaxName = GetStringFromDataReader(reader, "PAX_NAME");
                        consignment.pax.PaxPassportNo = GetStringFromDataReader(reader, "pptNoWithComma");
                       
                        lstgrid.Add(consignment);
                    }
                }
                exception = "true";
                return lstgrid;
            }
            catch(Exception)
            {
                exception = "";
                return lstgrid = null;
                
            }
            

            
        }

       
        public List<Consignment> ReadConsignmentDataByCountryName(string country_name, int locationId)
        {
            List<Consignment> lstgrid = new List<Consignment>();
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("select COUNTRY.COUNTRY_NAME,CG_ID,CG_SUBMISSION_DATE,CG_DELIVERYDATE,CG_DELIVERYSTATUS,AGENT.AGENT_NAME from CONSIGNMENT  inner join AGENT on AGENT.AGENT_ID=CONSIGNMENT.FK_AGENT_ID inner join COUNTRY on CONSIGNMENT.CG_VISACOUNTRY=COUNTRY.COUNTRY_ID where COUNTRY_NAME LIKE '" + country_name + "%' and CONSIGNMENT.IsDeleted=0 and CONSIGNMENT.LocationId='" + locationId + "' order by country_name");
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Consignment consignment = new Consignment();
                    consignment.ConsignmentAgent = new Agent();
                    consignment.CountryName = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    consignment.ConsignmentId = GetIntegerFromDataReader(reader, "CG_ID");
                    consignment.CgSubmissionDate = GetDateFromReader(reader, "CG_SUBMISSION_DATE");
                    consignment.CgDeliveryDate = GetDateFromReader(reader, "CG_DELIVERYDATE");
                    consignment.CgDeliveryStatus = GetStringFromDataReader(reader, "CG_DELIVERYSTATUS");
                    consignment.ConsignmentAgent.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");

                    lstgrid.Add(consignment);
                }
            }

            return lstgrid;
        }
      
                

       
        #endregion

        #region  pax....

        public int  CreatePax(AdditonalInfo  addInfo)
        {
            int paxId;
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.INSERT_PAX);
            dbCommand.CommandType = CommandType.StoredProcedure;

            myDataBase.AddInParameter(dbCommand, "@FK_CG_ID", DbType.Int32, addInfo.consignment.CG_ID);
            myDataBase.AddInParameter(dbCommand, "@PAX_NAME", DbType.String, addInfo.pax.PaxName);
            myDataBase.AddInParameter(dbCommand, "@PAX_PPTNO", DbType.String, addInfo.pax.PaxPassportNo);
            myDataBase.AddInParameter(dbCommand, "@PAX_TICKET", DbType.String, addInfo.pax.PaxTicket);
            myDataBase.AddInParameter(dbCommand, "@PAX_DRAFT", DbType.String, addInfo.pax.PaxDraft);
            myDataBase.AddInParameter(dbCommand, "@PAX_CERTIFICATES", DbType.String, addInfo.pax.PaxCertificates);
            myDataBase.AddInParameter(dbCommand, "@PAX_ITPAPER", DbType.String, addInfo.pax.PaxItPaper);
            myDataBase.AddInParameter(dbCommand, "@PAX_MED_INSURANCE", DbType.String,addInfo.pax.PaxMedInsurance);
            myDataBase.AddInParameter(dbCommand, "@PAX_CREDITCARD", DbType.String, addInfo.pax.PaxCreditCard);
            myDataBase.AddInParameter(dbCommand, "@PAX_OTHER", DbType.String, addInfo.pax.PaxOther);
            myDataBase.AddInParameter(dbCommand, "@PAX_REMARKS", DbType.String, addInfo.pax.PaxRemarks);
            myDataBase.AddInParameter(dbCommand, "@UPDATED_ON", DbType.String, addInfo.pax.UpdatedOn);
            myDataBase.AddInParameter(dbCommand, "@PAX_VTT", DbType.String, addInfo.pax.PaxVit);

            myDataBase.AddInParameter(dbCommand, "@PAX_TICKET_REMARK", DbType.String, addInfo.pax.PaxTicketRemark);
            myDataBase.AddInParameter(dbCommand, "@PAX_DRAFT_REMARK", DbType.String, addInfo.pax.PaxDraftRemark);
            myDataBase.AddInParameter(dbCommand, "@PAX_CERTIFICATES_REMARK", DbType.String, addInfo.pax.PaxCertificatesRemark);
            myDataBase.AddInParameter(dbCommand, "@PAX_ITPAPER_REMARK", DbType.String,addInfo.pax.PaxItPaperRemark);
            myDataBase.AddInParameter(dbCommand, "@PAX_MED_INSURANCE_REMARK", DbType.String, addInfo.pax.PaxMedInsuranceRemark);
            myDataBase.AddInParameter(dbCommand, "@PAX_CREDITCARD_REMARK", DbType.String, addInfo.pax.PaxCreditCardRemark);
            myDataBase.AddInParameter(dbCommand, "@PAX_OTHER_REMARK", DbType.String, addInfo.pax.PaxOtherRemark);

            myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, addInfo.pax.location.Location_Id);
            myDataBase.AddOutParameter(dbCommand, "@out_pax_id", DbType.Int32, 10);

            myDataBase.ExecuteNonQuery(dbCommand);
            int.TryParse(myDataBase.GetParameterValue(dbCommand, "@out_pax_id").ToString(), out paxId);
            return paxId;
        }       
        public void UpdatePax(Pax pax, int PaxId)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_PAX);
            dbCommand.CommandType = CommandType.StoredProcedure;

            myDataBase.AddInParameter(dbCommand, "@PAX_ID", DbType.Int32, PaxId);
            myDataBase.AddInParameter(dbCommand, "@PAX_NAME", DbType.String, pax.PaxName);
            myDataBase.AddInParameter(dbCommand, "@PAX_PPTNO", DbType.String, pax.PaxPassportNo);
            myDataBase.AddInParameter(dbCommand, "@PAX_TICKET", DbType.String, pax.PaxTicket);
            myDataBase.AddInParameter(dbCommand, "@PAX_DRAFT", DbType.String, pax.PaxDraft);
            myDataBase.AddInParameter(dbCommand, "@PAX_CERTIFICATES", DbType.String, pax.PaxCertificates);
            myDataBase.AddInParameter(dbCommand, "@PAX_ITPAPER", DbType.String, pax.PaxItPaper);
            myDataBase.AddInParameter(dbCommand, "@PAX_MED_INSURANCE", DbType.String, pax.PaxMedInsurance);
            myDataBase.AddInParameter(dbCommand, "@PAX_CREDITCARD", DbType.String, pax.PaxCreditCard);
            myDataBase.AddInParameter(dbCommand, "@PAX_OTHER", DbType.String, pax.PaxOther);
            myDataBase.AddInParameter(dbCommand, "@PAX_REMARKS", DbType.String, pax.PaxRemarks);
            myDataBase.AddInParameter(dbCommand, "@UPDATED_ON", DbType.String, pax.UpdatedOn);
            myDataBase.AddInParameter(dbCommand, "@PAX_VTT", DbType.String, pax.PaxVit);

            myDataBase.AddInParameter(dbCommand, "@PAX_TICKET_REMARK", DbType.String, pax.PaxTicketRemark);
            myDataBase.AddInParameter(dbCommand, "@PAX_DRAFT_REMARK", DbType.String, pax.PaxDraftRemark);
            myDataBase.AddInParameter(dbCommand, "@PAX_CERTIFICATES_REMARK", DbType.String, pax.PaxCertificatesRemark);
            myDataBase.AddInParameter(dbCommand, "@PAX_ITPAPER_REMARK", DbType.String, pax.PaxItPaperRemark);
            myDataBase.AddInParameter(dbCommand, "@PAX_MED_INSURANCE_REMARK", DbType.String, pax.PaxMedInsuranceRemark);
            myDataBase.AddInParameter(dbCommand, "@PAX_CREDITCARD_REMARK", DbType.String, pax.PaxCreditCardRemark);
            myDataBase.AddInParameter(dbCommand, "@PAX_OTHER_REMARK", DbType.String, pax.PaxOtherRemark);
            myDataBase.ExecuteNonQuery(dbCommand);

        }
        public void DeletePax(int id,int paxId)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.DELETE_PAX);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@PAX_ID", DbType.Int32, paxId);
            myDataBase.AddInParameter(dbCommand, "@InfoId", DbType.Int32, id);
            myDataBase.ExecuteNonQuery(dbCommand);
        }
        public String ReadDataFromPaxByPassPortNo(string passportNo)
        {
            string passPrtNo = null;
            DbCommand dbCommand = myDataBase.GetStoredProcCommand("procReadPaxDataByPassportNo");            
            myDataBase.AddInParameter(dbCommand, "@In_PassportNo", DbType.String, passportNo);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    passPrtNo = GetStringFromDataReader(reader, "Pax_name");
                }
            }
            return passPrtNo;
        }



        public List<AdditonalInfo> ReadDataByPaxConsignmentId(int id, int? LocId)
        {
            List<AdditonalInfo> lstpax = new List<AdditonalInfo>();

            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_PAX_BY_CONSIGNMENTID);
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            myDataBase.AddInParameter(dbCommand, "@FK_CG_ID", DbType.Int32, id);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

                while (reader.Read())
                {
                    AdditonalInfo addInfo = new AdditonalInfo();
                    addInfo.pax = new Pax();
                    addInfo.consignment = new Consignment();
                    addInfo.consignment.ConsignmentId = id;
                    addInfo.pax.PaxId = GetIntegerFromDataReader(reader, "PAX_ID");
                    addInfo.pax.PaxName = GetStringFromDataReader(reader, "PAX_NAME");
                    addInfo.pax.PaxPassportNo = GetStringFromDataReader(reader, "PAX_PPTNO");
                    addInfo.pax.PaxVit = GetStringFromDataReader(reader, "PAX_VTT");
                    //pax.DateOfBirth = GetDateFromReader(reader, "");
                    addInfo.pax.PaxTicket = GetStringFromDataReader(reader, "PAX_TICKET");
                    addInfo.pax.PaxTicketRemark = GetStringFromDataReader(reader, "PAX_TICKET_REMARK");
                    addInfo.pax.PaxDraft = GetStringFromDataReader(reader, "PAX_DRAFT");
                    addInfo.pax.PaxDraftRemark = GetStringFromDataReader(reader, "PAX_DRAFT_REMARK");
                    addInfo.pax.PaxCertificates = GetStringFromDataReader(reader, "PAX_CERTIFICATES");
                    addInfo.pax.PaxCertificatesRemark = GetStringFromDataReader(reader, "PAX_CERTIFICATES_REMARK");
                    addInfo.pax.PaxItPaper = GetStringFromDataReader(reader, "PAX_ITPAPER");
                    addInfo.pax.PaxItPaperRemark = GetStringFromDataReader(reader, "PAX_ITPAPER_REMARK");
                    addInfo.pax.PaxMedInsurance = GetStringFromDataReader(reader, "PAX_MED_INSURANCE");
                    addInfo.pax.PaxMedInsuranceRemark = GetStringFromDataReader(reader, "PAX_MED_INSURANCE_REMARK");
                    addInfo.pax.PaxCreditCard = GetStringFromDataReader(reader, "PAX_CREDITCARD");
                    addInfo.pax.PaxCreditCardRemark = GetStringFromDataReader(reader, "PAX_CREDITCARD_REMARK");
                    addInfo.pax.PaxOther = GetStringFromDataReader(reader, "PAX_OTHER");
                    addInfo.pax.PaxOtherRemark = GetStringFromDataReader(reader, "PAX_OTHER_REMARK");
                    addInfo.pax.PaxRemarks = GetStringFromDataReader(reader, "PAX_REMARKS");
                    addInfo.CountryId = GetIntegerFromDataReader(reader, "COUNTRY_ID");
                    addInfo.CountryName = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    addInfo.VisaTypeOneId = GetIntegerFromDataReader(reader, "VISA_TYPE_ONE_ID");
                    addInfo.DescriptionOne = GetStringFromDataReader(reader, "DESCRIPTION_ONE");
                    addInfo.DescriptionTwo = GetStringFromDataReader(reader, "DESCRIPTION_TWO");
                    addInfo.GroupId = GetIntegerFromDataReader(reader, "IS_GROUP_ID");
                    addInfo.GroupName = GetStringFromDataReader(reader, "Group_Name");
                    addInfo.AddinfoId = GetIntegerFromDataReader(reader, "INFO_ID");
                    addInfo.VisaTypeTwoId = GetIntegerFromDataReader(reader, "PROCESS_TIME_ID");
                    addInfo.Description = GetStringFromDataReader(reader, "DESCRIPTION");

                    lstpax.Add(addInfo);
                }
            return lstpax;

        }      
        public List<Pax> ReadDataByPaxId(int id, int locationId)
        {
            List<Pax> lstpax = new List<Pax>();

            DbCommand dbCommand = myDataBase.GetSqlStringCommand("select * from pax where PAX_ID=" + id + " and pax.LocationId='" + locationId + "' and IsDeleted=0");
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

                while (reader.Read())
                {
                    Pax pax = new Pax();

                    pax.PaxId = GetIntegerFromDataReader(reader, "PAX_ID");
                    pax.PaxName = GetStringFromDataReader(reader, "PAX_NAME");
                    pax.PaxPassportNo = GetStringFromDataReader(reader, "PAX_PPTNO");
                    pax.PaxVit = GetStringFromDataReader(reader, "PAX_VTT");
                    //pax.DateOfBirth = GetDateFromReader(reader, "");
                    pax.PaxTicket = GetStringFromDataReader(reader, "PAX_TICKET");
                    pax.PaxDraft = GetStringFromDataReader(reader, "PAX_DRAFT");
                    pax.PaxCertificates = GetStringFromDataReader(reader, "PAX_CERTIFICATES");
                    pax.PaxItPaper = GetStringFromDataReader(reader, "PAX_ITPAPER");
                    pax.PaxMedInsurance = GetStringFromDataReader(reader, "PAX_MED_INSURANCE");
                    pax.PaxCreditCard = GetStringFromDataReader(reader, "PAX_CREDITCARD");
                    pax.PaxOther = GetStringFromDataReader(reader, "PAX_OTHER");
                    pax.PaxRemarks = GetStringFromDataReader(reader, "PAX_REMARKS");

                    lstpax.Add(pax);
                }
            return lstpax;

        }
        public List<Pax> ReadDataByPaxsConsignmentId(int id, int locationId)
        {
            List<Pax> lstpax = new List<Pax>();

            DbCommand dbCommand = myDataBase.GetSqlStringCommand("select * from pax where FK_CG_ID=" + id + " and isdeleted=0 ");
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

                while (reader.Read())
                {
                    Pax pax = new Pax();

                    pax.PaxId = GetIntegerFromDataReader(reader, "PAX_ID");
                    pax.PaxName = GetStringFromDataReader(reader, "PAX_NAME");
                    pax.PaxPassportNo = GetStringFromDataReader(reader, "PAX_PPTNO");
                    pax.PaxVit = GetStringFromDataReader(reader, "PAX_VTT");
                    //pax.DateOfBirth = GetDateFromReader(reader, "");
                    pax.PaxTicket = GetStringFromDataReader(reader, "PAX_TICKET");
                    pax.PaxDraft = GetStringFromDataReader(reader, "PAX_DRAFT");
                    pax.PaxCertificates = GetStringFromDataReader(reader, "PAX_CERTIFICATES");
                    pax.PaxItPaper = GetStringFromDataReader(reader, "PAX_ITPAPER");
                    pax.PaxMedInsurance = GetStringFromDataReader(reader, "PAX_MED_INSURANCE");
                    pax.PaxCreditCard = GetStringFromDataReader(reader, "PAX_CREDITCARD");
                    pax.PaxOther = GetStringFromDataReader(reader, "PAX_OTHER");
                    pax.PaxRemarks = GetStringFromDataReader(reader, "PAX_REMARKS");

                    lstpax.Add(pax);
                }
            return lstpax;

        }
        public void CreateAdditonalPax(AdditonalInfo additionalInfo)
        {

            DbCommand dbCommand = myDataBase.GetStoredProcCommand("procCreateAdditionalPax");
            dbCommand.CommandType = CommandType.StoredProcedure;


            myDataBase.AddInParameter(dbCommand, "@FK_CG_ID", DbType.String, additionalInfo.consignment.CG_ID);
            myDataBase.AddInParameter(dbCommand, "@COUNTRY_ID", DbType.String, additionalInfo.CountryId);
            myDataBase.AddInParameter(dbCommand, "@FK_PAX_ID", DbType.String, additionalInfo.pax.PaxId);
            myDataBase.AddInParameter(dbCommand, "@VISA_TYPE_ONE_ID", DbType.String, additionalInfo.VisaTypeOneId);
            myDataBase.AddInParameter(dbCommand, "@VISA_TYPE_TWO_ID", DbType.String, additionalInfo.VisaTypeTwoId);
            myDataBase.AddInParameter(dbCommand, "@IS_GROUP_ID", DbType.String, additionalInfo.GroupId);
            myDataBase.AddInParameter(dbCommand, "@Group_Name", DbType.String, additionalInfo.GroupName);
            myDataBase.AddInParameter(dbCommand, "@PROCESS_TIME_ID", DbType.Int32, additionalInfo.ProcessTimeId);
            myDataBase.AddInParameter(dbCommand, "@locationId", DbType.Int32, additionalInfo.location.Location_Id);

            myDataBase.ExecuteNonQuery(dbCommand);
        }
        public void UpdateAdditionalPax(AdditonalInfo addinfo, int AddInfoId)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_ADDITIONAL_PAX);
            dbCommand.CommandType = CommandType.StoredProcedure;

            myDataBase.AddInParameter(dbCommand, "@Info_ID", DbType.Int32, AddInfoId);
            myDataBase.AddInParameter(dbCommand, "@VISA_TYPE_ONE_ID", DbType.Int32, addinfo.VisaTypeOneId);
            myDataBase.AddInParameter(dbCommand, "@VISA_TYPE_TWO_ID", DbType.Int32, addinfo.VisaTypeTwoId);
            myDataBase.AddInParameter(dbCommand, "@IS_GROUP_ID", DbType.Int32, addinfo.GroupId);
            myDataBase.AddInParameter(dbCommand, "@Group_Name", DbType.String, addinfo.GroupName);
            myDataBase.AddInParameter(dbCommand, "@PROCESS_TIME_ID", DbType.Int32, addinfo.ProcessTimeId);
            myDataBase.AddInParameter(dbCommand, "@COUNTRY_ID", DbType.Int32, addinfo.CountryId);

            myDataBase.ExecuteNonQuery(dbCommand);

        }
        public List<AdditonalInfo> ReadAdditonalPaxCountry(int consignmentId)
        {
            List<AdditonalInfo> lstAddPax = new List<AdditonalInfo>();
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("select distinct COUNTRY.COUNTRY_NAME,country.COUNTRY_ID from ADDINFO inner join COUNTRY on COUNTRY.COUNTRY_ID=ADDINFO.COUNTRY_ID where FK_CG_ID='" + consignmentId + "' ");
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

                while (reader.Read())
                {
                    AdditonalInfo addPax = new AdditonalInfo();

                    addPax.CountryId = GetIntegerFromDataReader(reader, "COUNTRY_ID");
                    addPax.CountryName = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    lstAddPax.Add(addPax);
                }
            return lstAddPax;
        }
        public List<AdditonalInfo> ReadDataByAdditonalPaxId(int id, int? LocId)
        {
            List<AdditonalInfo> lstaddtionalPax = new List<AdditonalInfo>();

            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_CONSIGNMENTBY_FKCGIDADDITIONAL);
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            myDataBase.AddInParameter(dbCommand, "@FK_CG_ID", DbType.Int32, id);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

                while (reader.Read())
                {
                    AdditonalInfo addpax = new AdditonalInfo();
                    addpax.CountryId = GetIntegerFromDataReader(reader, "COUNTRY_ID");
                    addpax.VisaTypeOneId = GetIntegerFromDataReader(reader, "VISA_TYPE_ONE_ID");
                    addpax.VisaTypeTwoId = GetIntegerFromDataReader(reader, "VISA_TYPE_TWO_ID");
                    addpax.ProcessTimeId = GetIntegerFromDataReader(reader, "PROCESS_TIME_ID");
                    addpax.GroupId = GetIntegerFromDataReader(reader, "DURATION_ID");
                    lstaddtionalPax.Add(addpax);
                }
            return lstaddtionalPax;
        }
        public List<AdditonalInfo> ReadDataByAdditonalPaxsId(int id, int? LocId)
        {
            List<AdditonalInfo> lstaddtionalPax = new List<AdditonalInfo>();

            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_CONSIGNMENTBY_FKCGIDADDITIONAL);
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            myDataBase.AddInParameter(dbCommand, "@FK_CG_ID", DbType.Int32, id);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

                while (reader.Read())
                {
                    AdditonalInfo pax = new AdditonalInfo();
                    pax.CountryId = GetIntegerFromDataReader(reader, "COUNTRY_ID");
                    pax.VisaTypeOneId = GetIntegerFromDataReader(reader, "VISA_TYPE_ONE_ID");
                    pax.VisaTypeTwoId = GetIntegerFromDataReader(reader, "VISA_TYPE_TWO_ID");
                    pax.ProcessTimeId = GetIntegerFromDataReader(reader, "PROCESS_TIME_ID");
                    pax.GroupId = GetIntegerFromDataReader(reader, "DURATION_ID");
                    lstaddtionalPax.Add(pax);
                }
            return lstaddtionalPax;
        }
      
        public List<AdditonalInfo> ReadCountry(int country_id)
        {

            List<AdditonalInfo> lstcountry = new List<AdditonalInfo>();
            AdditonalInfo addPax = null;
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("SELECT COUNTRY.COUNTRY_NAME,COUNTRY.COUNTRY_ID FROM   COUNTRY where COUNTRY.COUNTRY_ID =" + country_id + "");
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    addPax = CountryFromDataReader(reader);
                    lstcountry.Add(addPax);
                }
            }
            return lstcountry;

        }
        private AdditonalInfo CountryFromDataReader(IDataReader reader)
        {
            AdditonalInfo addPax = new AdditonalInfo();

            addPax.CountryName = GetStringFromDataReader(reader, "COUNTRY_NAME");
            addPax.CountryId = GetIntegerFromDataReader(reader, "COUNTRY_ID");

            return addPax;
        }
        public List<AdditonalInfo> ReadVisaType(int MyEmbassyId)
        {

            List<AdditonalInfo> lstcountry = new List<AdditonalInfo>();
            AdditonalInfo addPax = null;           
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("Select distinct TYPE_ONE_ID,DESCRIPTION_ONE from EMBASSY_FEES_MASTER,EMB_MASTER,VISA_TYPE_ONE where EMB_MASTER_ID = EMBS_ID AND EMBS_COUNTRY_ID=" + MyEmbassyId + " AND VISA_TYPE_ONE_ID=TYPE_ONE_ID");
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    addPax = VisaTypeFromDataReader(reader);
                    lstcountry.Add(addPax);
                }
            }
            return lstcountry;

        }
        private AdditonalInfo VisaTypeFromDataReader(IDataReader reader)
        {
            AdditonalInfo addPax = new AdditonalInfo();


            addPax.DescriptionOne = GetStringFromDataReader(reader, "DESCRIPTION_ONE");
            addPax.VisaTypeOneId = GetIntegerFromDataReader(reader, "TYPE_ONE_ID");

            return addPax;
        }
        public List<AdditonalInfo> ReadNo_Of_Visit(int MyEmbassyId, int MyVisaTypeId)
        {

            List<AdditonalInfo> lstcountry = new List<AdditonalInfo>();
            AdditonalInfo addPax = null;           
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("Select distinct TYPE_TWO_ID,DESCRIPTION_TWO from EMBASSY_FEES_MASTER,EMB_MASTER,VISA_TYPE_TWO where EMB_MASTER_ID = EMBS_ID AND EMBS_COUNTRY_ID=" + MyEmbassyId + " AND VISA_TYPE_ONE_ID= " + MyVisaTypeId + " AND VISA_TYPE_TWO_ID=TYPE_TWO_ID ");
                     
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    addPax = No_Of_VisitFromDataReader(reader);
                    lstcountry.Add(addPax);
                }
            }
            return lstcountry;

        }
        private AdditonalInfo No_Of_VisitFromDataReader(IDataReader reader)
        {
            AdditonalInfo addPax = new AdditonalInfo();

            addPax.DescriptionTwo = GetStringFromDataReader(reader, "DESCRIPTION_TWO");
            addPax.VisaTypeTwoId = GetIntegerFromDataReader(reader, "TYPE_TWO_ID");

            return addPax;
        }
       
        
        public List<AdditonalInfo> ReadProcessTime(int MyVisaTypeId, int MyNoofEntry, int MyEmbassyId, int MyVisaDurationId)
        {
            List<AdditonalInfo> lstcountry = new List<AdditonalInfo>();
            AdditonalInfo addPax = null;            
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("Select distinct PROCESSTIME_ID,DESCRIPTION from EMBASSY_FEES_MASTER,EMB_MASTER,VISA_PROCESSTIME where EMB_MASTER_ID = EMBS_ID AND EMBS_COUNTRY_ID= " + MyEmbassyId + " AND VISA_TYPE_ONE_ID=  " + MyVisaTypeId + " AND VISA_TYPE_TWO_ID= " + MyNoofEntry + " AND VISA_DURATION= " + MyVisaDurationId + " AND PROCESS_TIME = PROCESSTIME_ID");
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    addPax = ProcessTime_FromDataReader(reader);
                    lstcountry.Add(addPax);
                }
            }
            return lstcountry;

        }
        private AdditonalInfo ProcessTime_FromDataReader(IDataReader reader)
        {
            AdditonalInfo addPax = new AdditonalInfo();
            addPax.Description = GetStringFromDataReader(reader, "DESCRIPTION");
            addPax.ProcessTimeId = GetIntegerFromDataReader(reader, "PROCESSTIME_ID");
            return addPax;
        }


        #endregion

        //#region mailremark....

        //public void CreateMailRemarks(MailRemark mailRemarks)
        //{
        
        //    DbCommand dbCommand = myDataBase.GetStoredProcCommand("procInsertMailremarks");
        //    dbCommand.CommandType = CommandType.StoredProcedure;

        //    myDataBase.AddInParameter(dbCommand, "@CG_ID", DbType.String, mailRemarks.ConsignmentId);
        //    myDataBase.AddInParameter(dbCommand, "@COUNTRY_ID", DbType.Int32, mailRemarks.CountryId);
        //    myDataBase.AddInParameter(dbCommand, "@SUBMISSION_DATE", DbType.DateTime, mailRemarks.SubmissionDate);
        //    myDataBase.AddInParameter(dbCommand, "@COLLECTION_DATE", DbType.DateTime, mailRemarks.CollectionDate);
        //    myDataBase.AddInParameter(dbCommand, "@CHECK_ON_DATE", DbType.DateTime, mailRemarks.CheckOnDate);
        //    myDataBase.AddInParameter(dbCommand, "@Collected_Flag", DbType.Int32, mailRemarks.CollectedFlag);
        //    myDataBase.AddInParameter(dbCommand, "@REMARKS", DbType.String, mailRemarks.Remarks);
        //    myDataBase.AddInParameter(dbCommand, "@locationId", DbType.String, mailRemarks.location.Location_Id);
        //    myDataBase.ExecuteNonQuery(dbCommand);


        //}      
        //public void updateMailRemarks(MailRemark mailRemarks, int MailId)
        //{
        //    DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_MAILREMARK);
        //    dbCommand.CommandType = CommandType.StoredProcedure;
        //    myDataBase.AddInParameter(dbCommand, "@id", DbType.Int32, MailId);
        //    myDataBase.AddInParameter(dbCommand, "@SUBMISSION_DATE", DbType.DateTime, mailRemarks.SubmissionDate);
        //    myDataBase.AddInParameter(dbCommand, "@CHECK_ON_DATE", DbType.DateTime, mailRemarks.CheckOnDate);
        //    myDataBase.AddInParameter(dbCommand, "@COLLECTION_DATE", DbType.DateTime, mailRemarks.CollectionDate);
        //    myDataBase.AddInParameter(dbCommand, "@Collected_Flag", DbType.String, mailRemarks.CollectedFlag);
        //    myDataBase.AddInParameter(dbCommand, "@REMARKS", DbType.String, mailRemarks.Remarks);
           
        //    myDataBase.ExecuteNonQuery(dbCommand);

        //}
        //public void CreateAnotherMailRemarks(MailRemark mailRemarks, String id)
        //{
           
        //    DbCommand dbCommand = myDataBase.GetStoredProcCommand("procInsertMailremarks");
        //    dbCommand.CommandType = CommandType.StoredProcedure;

        //    myDataBase.AddInParameter(dbCommand, "@CG_ID", DbType.String, id);
        //    myDataBase.AddInParameter(dbCommand, "@COUNTRY_ID", DbType.Int32, mailRemarks.CountryId);
        //    myDataBase.AddInParameter(dbCommand, "@SUBMISSION_DATE", DbType.DateTime, mailRemarks.SubmissionDate);
        //    myDataBase.AddInParameter(dbCommand, "@COLLECTION_DATE", DbType.DateTime, mailRemarks.CollectionDate);
        //    myDataBase.AddInParameter(dbCommand, "@CHECK_ON_DATE", DbType.DateTime, mailRemarks.CheckOnDate);
        //    myDataBase.AddInParameter(dbCommand, "@Collected_Flag", DbType.Int32, mailRemarks.CollectedFlag);
        //    myDataBase.AddInParameter(dbCommand, "@REMARKS", DbType.String, mailRemarks.Remarks);
        //    myDataBase.AddInParameter(dbCommand, "@locationId", DbType.String, mailRemarks.location.Location_Id);
        //    myDataBase.ExecuteNonQuery(dbCommand);


        //}

        //public List<MailRemark> ReadDataByMailRemarkid(string mailremId,int locationId)
        //{
        //    List<MailRemark> lstMailremrk = new List<MailRemark>();
        //    DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_PAX_BY_CONSIGNMENT_ID);
        //    if (locationId != 0)
        //    {
        //        myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, locationId);
        //    }
        //    else
        //    {
        //        myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
        //    }
        //    myDataBase.AddInParameter(dbCommand, "@CG_ID", DbType.Int32, mailremId);
        //    using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
        //        while (reader.Read())
        //        {
        //            MailRemark mailremark = new MailRemark();

        //            mailremark.MailId = GetIntegerFromDataReader(reader, "id");
        //            mailremark.ConsignmentId = GetStringFromDataReader(reader, "CG_ID");
        //            mailremark.CountryId = GetIntegerFromDataReader(reader, "COUNTRY_ID");
        //            mailremark.CountryName = GetStringFromDataReader(reader, "COUNTRY_NAME");
        //            mailremark.CollectionDate = GetDateFromReader(reader, "COLLECTION_DATE");
        //            mailremark.CheckOnDate = GetDateFromReader(reader, "CHECK_ON_DATE");
        //            mailremark.SubmissionDate = GetDateFromReader(reader, "SUBMISSION_DATE");
        //            mailremark.CollectedFlag = GetIntegerFromDataReader(reader, "Collected_Flag");
        //            mailremark.Remarks = GetStringFromDataReader(reader, "REMARKS");
        //            lstMailremrk.Add(mailremark);
        //        }
        //    return lstMailremrk;

        //}
        //public List<MailRemark> ReadAnotherMailRemarkid(int mailremId)
        //{
        //    List<MailRemark> lstMailremrk = new List<MailRemark>();
        //    DbCommand dbCommand = myDataBase.GetSqlStringCommand("select  distinct country_name,c.COUNTRY_ID from MAIL_CON_REMARKS m inner join country c on c.COUNTRY_ID=m.COUNTRY_ID    where m.CG_ID=" + mailremId + " and m.IsDeleted=0 ");
        //    using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

        //        while (reader.Read())
        //        {
        //            MailRemark mailremark = new MailRemark();

        //            mailremark.CountryId = GetIntegerFromDataReader(reader, "COUNTRY_ID");
        //            mailremark.CountryName = GetStringFromDataReader(reader, "COUNTRY_NAME");
        //            lstMailremrk.Add(mailremark);
        //        }
        //    return lstMailremrk;
        //}

        //#endregion





    }

}