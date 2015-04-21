using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DataAccessLayer
{
    public class DBConstant
    {

        #region Agent

        public const String CREATE_AGENT = "procInsertAgent";
        public const String READ_AGENT = "procReadAgent";
        public const String READ_AGENT_RECORD = "procSearchAgentRecord";
        public const String READ_AGENT_RECORD_BY_STATUS = "procSearchAgentRecordByEnable";
        public const String READ_AGENT_USER = "procReadAgentById";
        public const String DELETE_AGENT = "procDeleteAgent";
        public const String UPDATE_AGENT = "procUpdateAgentRecord";
        public const String LIST_AGENT = "procSelectListAgent";
        public const string SELECT_AGENTEMAIL_LIST = "select_AgentEmailList";

        public const string UPDATE_AGENT_STATUSBY_ID = "procUpdateAgentEnableStatusById";

       #endregion 

        #region  user

        public const String CREATE_USER_MASTER = "procCreateUserMaster";
        public const String CREATE_USER_TASK_MAPPING = "procCreateUserTaskMapping";
        public const String READ_USER_MASTER = "procReadUserMaster";
        public const String READ_METADATA_USER_TASK = "procReadMetadataUserTask";
        public const String EDIT_USER_MASTER = "procUpdateUserMaster";
        public const String DELETE_USER_MASTER = "procDeleteUser";
        public const String DELETE_USER_TASK = "procDeleteUserTask";
        public const String VALIDATE_AGENT_MASTER = "procValidateAgent";
        public const String VALIDATE_USER_MASTER = "procValidateUser";
        public const String READ_USERTASK_BY_USERID = "procReadUserTask";
        public const String READ_USER_BYLOGIN_ID = "procReadUserByLoginId";

        #endregion

        #region NewsLetter
        public const String CREATE_NEWSLETTER = "procCreateNewsLetter";
        public const String READ_NEWSLETTER = "procReadNewsLetter";
        public const String DELETE_NEWSLETTER = "procDeleteNewsLetter";
        public const String EDIT_NEWSLETTER = "procUpdateNewsLetter";
        public const String DELETE_NEWSLETTER_IMAGE = "procDeleteNewsLetterImage";
        public const String Read_NewsLetter_Image = "procReadNewsLetterImage";
        #endregion

        #region Visaform
        public const String DELETE_VACCINATION_VISA_FORM = "procDeleteVaccinationVisaForm";
        public const String DELETE_COVERNOTE_VISA_FORM = "procDeleteCoverNoteVisaForm";
        public const String READ_COVERNOTE_VISA_FORM = "procReadCoverNoteVisaForm";
        public const String READ_VACCINATION_VISA_FORM = "procReadVaccinationVisaForm";
        public const String CREATE_VACCINATION_VISA_FORM = "procVaccinationVisaForm";
        public const String CREATE_VISA_FORM = "procAddVisaForm";
        public const String CREATE_COVERNOTE_FORM = "procCoverNoteVisaForm";
        public const String SEARCH_VISA_FORM = "procSearchVisaForm";
        public const String DELETE_VISA_FORM = "procDeleteVisaForm";
        public const String DELETE_SCHNEGEN_VISA_FORM = "procDeleteSchnegenVisaForm";
        public const String SELECT_DELHI = "procSelectDelhiForm";
        public const String SELECT_MUMBAI = "procSelectMumbaiForm";
        public const String SELECT_CHANNAI = "procSelectChannaiForm";
        public const String SELECT_BANGALORE = "procSelectBangaloreForm";
        public const String SELECT_BY_FILTER = "procSelectFormByFilter";
        #endregion

        #region EmbassyMaster

        public const String READ_COUNTRY = "procReadCountry";
        public const String INSERT_EMBASSY_MASTER = "procInsertEmbsyMaster";
        public const String DELETE_EMBASSY_MASTER = "procDeleteEmbsyMaster";
        public const String UPDATE_EMBASSY_MASTER = "procUpdateEmbsyMaster";
        public const String READ_EMBASSY_MASTER = "procReadEmbsyMaster";
        public const String READ_EMBASSY_MASTER_BY_ID = "procReadEmbsyMasterById";
        public const String READ_EMABASSY_MASTER_BY_COUNTRY_ID = "procReadEmbsyMasterByCountryId";

        #endregion

        #region EmbassyFee

        public const String INSERT_EMBASSY_FEES = "procInsertEmbsyFeesMaster";
        public const String DELETE_EMBASSY_FEES = "procDeleteEmbassyFees";
        public const String UPDATE_EMBASSY_FEES = "procUpdateEmbassyFees";
        public const String READ_EMBASSY_FEES = "procReadEmbassyFeesMaster";
        public const String READ_EMBASSY_FEES_BY_ID = "procReadEmbassyFeeMasterById";
        public const String READ_EMBASSY_MASTER_ID = "procReadEmbMasterId";
        public const String READ_EMBASSY_FEE_BY_COUNTRY_ID = "procReadEmbassyFeeByCountryId";
        public const String READ_EMBASSY_FEE_BY_VISA_DURATION_ID = "procReadEmbassyFeeByVisaDurationId";
        public const String READ_EMBASSY_FEE_BY_VISA_TYPE_ID = "procReadEmbassyFeeByVisaTypeId";
        public const String READ_EMBASSY_FEE_BY_NO_OF_VISIT_ID = "procReadEmbassyFeeByNoOfVisitId";
        public const String READ_EMBASSY_FEE_BY_ALL = "procReadEmbassyFeeByAll";
        public const String READ_EMBASSY_FEE_COUNTRY = "procReadEmbassyFeeCountry";
        public const String READ_EMBASSY_FEE_BY_PROCESS_TIME_ID = "procReadEmbassyFeeByProcessTimeId";
        public const String UPDATE_EMBASSY_FEE_BY_ID = "procUpdateEmbassyFeesById";

        #endregion

        #region VisaTypeOne & Two VisaDuration ProcessTime Read Proc

        public const String READ_VISA_TYPE_TWO = "procReadVisaTypeTwo";

        public const String READ_VISA_DURATION = "procReadVisaDuration";

        public const String READ_PROCESS_TIME = "procReadProccessTime";


        #endregion

        #region Holidays

        public const String INSERT_HOLIDAY = "procInsertHoliday";

        public const String READ_HOLIDAY = "procRead_AllHolidayDetail";

        public const String DELETE_HOLIDAY_RECORD = "procDeleteHoliday";

        public const String READ_HOLIDAY_BY_ID = "procReadHolidayById";
       

        public const String UPDATE_HOLIDAY = "procUpdateHoliday";

        #endregion

        #region VisaInfo

        public const String INSERT_VISA_INFO = "procInsertVisaRequirement";
        public const String UPDATE_VISA_INFO = "procUpdateVisaRequirement";
        public const String DELETE_VISA_INFO = "procDeleteVisaRequirement";

        #endregion

        #region consignment

        public const String INSERT_CONSIGNMENT = "CreateConsignment";
        public const String UPDATE_CONSIGNMENT = "procUpdateConsignment";
        public const String DELETE_CONSIGNMENT = "procDeleteConsignment";
        public const String UPDATE_CONSIGNMENT_STATUS = "procUpdateConsignmentStatus";
        public const String READ_PAX_BY_CONSIGNMENTID = "procReadDataByPaxConsignmentId";
        public const String READ_CONSIGNMENT_BY_CONSIGNMENT_ID = "ReadDataByConsignmentId";
        public const String READ_CONSIGNMENT_BY_DATES_PAX_CONSIGNMENTNO = "ReadConsignmentDataByDates";
      
        
        #endregion

         #region pax...

        public const String INSERT_PAX = "procCreatePax";
        public const String UPDATE_PAX = "procUpdatePax";
        public const String DELETE_PAX = "procDeletePax";
        public const string UPDATE_MAILREMARK = "procUpdateMailRemarks";
        public const String UPDATE_ADDITIONAL_PAX = "procUpdateAddInfo";
        public const String READ_PAX_BY_CONSIGNMENT_ID = "ReadDataByMailRemarkConsignmentId";
#endregion

         #region Bill
         public const String READ_NEW_BILL_CHARGES = "ReadNewBillCharges";

         public const String READ_CONSIGNMENT_FOR_REPORT = "procReadConsignmentForPrint";
        #endregion

        #region Location_Master

         public const String READ_LOCATION_MASTER_ID = "procReadLocationMasterId";
         public const String CREATE_LOCATION = "procCreateLocation";
        
         public const String READ_LOCATION = "ProcReadLocation";
         public const String DELETE_LOCATION = "procDeleteLocation";
         public const String UPDATE_LOCATION = "procUpdateLocation";
         public const String SEARCH_LOCATION = "procLocationSearchbyCity";
         
        #endregion

         #region Country Master..
         public const String CREATE_COUNTRY = "procCreateCountry";
         public const String READ_COUNTRYMST = "ProcReadCountrymst";
         public const String DELETE_COUNTRY = "procDeleteCountry";
         public const String UPDATE_COUNTRY = "procUpdateCountry";
         #endregion

        #region Country Master..
         public const String READ_AGENTINFO = "procReadAgentInfo";
         public const String UPDATE_AGENTINFO = "procUpdateAgentInfo";
       #endregion

         #region Holiday Master..
         public const String CREATE_HOLIDAY = "procCreateHoliday";
         public const String READ_HOLIDAYINFO = "ReadHolidays";
         public const String READ_HOLIDAY_BY_YEAR_MONTH = "procReadHolidaysByYearAndMonth";
       #endregion
       

         #region City Master..
         public const String CREATE_CITY = "procCreateCity";
         public const String READ_CITY= "ProcReadCity";
         public const String DELETE_CITY = "procDeleteCity";
         public const String UPDATE_CITY = "procUpdateCity";
         #endregion


         #region ConsulateMaster..
         public const String CREATE_CONSULATE = "procCreateConsulate";
         public const String READ_CONSULATE = "procReadConsulate";
         public const String DELETE_CONSULATE = "procDeleteConsulate";
         public const String UPDATE_CONSULATE = "procUpdateConsulate";
         #endregion

         #region State Master..
         public const String CREATE_STATE = "procCreateState";
         public const String READ_STATE = "procReadState";
         public const String READ_STATE_BYCOUNTRYID = "procReadStateByCountryId";
         public const String READ_CITY_BYSTATEID = "procReadCityByStateId";
         public const String DELETE_STATE = "procDeleteState";
         public const String UPDATE_STATE = "procUpdateState";
         #endregion
         #region MISC_CHARGES
         public const string INSERT_MISCCHARGES = "procInsertMiscCharges";
         public const string DELETE_MISCCHARGES = "procDeleteMiscCharges";
         public const string UPDATE_MISCCHARES = "procUpdateMiscCharges";
         public const string READ_MISCCHARES = "procReadMiscCharges";
         #endregion

        #region InvoiceGenerate

         public const String CREATE_INVOICE = "procCreateBill";
         public const String UPDATE_INVOICE = "procUpdateBill";
         public const String CREATE_BILLDETAILS = "procCreateBillDetails";
         public const String CREATE_MODBILLDETAILS = "procCreateModBillDetails";
         public const String UPDATE_BILLDETAILS = "procUpdateBillDetails";
         public const String READ_AGENTCHARGE = "ReadAgentCharges";
         public const String READ_COUNTRYWISEAGENTCHARGE = "ReadCountryWiseAgentCharges";
         public const String READ_CURRENTSERVICECHARGE = "ReadCurrentServiceTax";
         public const String READ_NEWBILLCHARGE = "ReadNewBillCharges";
         public const String READ_NOOFPASSPORT = "ReadQuantityInvoice";
         public const String READ_SERVICECHARGE = "ReadCurrentServiceTax";
         public const String READ_QUANTITY = "ReadCurrentQuantity";
         public const String READ_BILLBY_BILLID = "procReadDataByInvoiceBillId";
         public const String READ_BILLDETAILSBY_ID = "procReadBillDetailsById";
         public const String READ_BILLBY_BILLCONSIGNMENTID = "procReadDataByInvoiceConsignmentId";
         public const String READ_BILLBY_BILLDATE = "procReadDataByInvoiceDate";
         public const String READ_CONSIGNMENTBY_CONSIGNMENTDATE = "procReadConsignmentByDate";
         public const String READ_CONSIGNMENTBY_CONSIGNMENTID_ADVANCE_SEARCH = "procReadConsignmentByIdAdvanceSearch";
         public const String READ_CONSIGNMENTBY_CONSIGNMENTID = "procReadConsignmentById";

         public const String READ_RECEITPBY_CONSIGNMENTID = "procReadReceitpByConsignmentId";
         public const String READ_RECEITPBY_AGENTNAME = "procReadReceitpByAgentName";
         public const String READ_CONSIGNMENTBY_CONSIGNMENTAGENTNAME = "procReadConsignmentByAgentName";
         public const String READ_CONSIGNMENTBY_FKCGIDADDITIONAL = "procReadDataByAdditonalPaxId";
         public const String READ_BillRePrintInvoiceBy_ConsignmentId = "procReadBillRePrintInvoiceByConsignmentId";
         public const String READ_BillRePrintInvoiceBy_BilId = "procReadBillRePrintInvoiceByBilId";
         public const String READ_BillRePrintInvoiceBy_BillType = "procReadBillRePrintInvoiceByBillType";
         public const String READ_BillRePrintInvoiceBy_AgentName = "procReadBillRePrintInvoiceByAgentName";
         public const String READ_BillRePrintInvoiceBy_BillId = "procReadBillItemPePrintInvoiceByBillId";
         public const String READ_CONSIGNMENTBY_CONSIGNMENTAGENTNAME_DATE = "procReadConsignmentByAgentNameAndDate";

        #endregion

         #region Receipt.....

         public const String CREATE_RECEIPT = "procCreateReceipt";
         public const String CREATE_RECEIPT_DETAIL = "procCreateReceiptDetails";
         public const String UPDATE_RECEIPT = "procUpdateReceipt";
         public const String READ_CREDIT_AMOUNT = "procReadCreditAmount";
         public const String READ_DEBIT_AMOUNT = "procReadDebitAmount";
         public const String READ_INVOICE_DETAIL = "procReadInvoiceDetail";
         public const String READ_RECEIPT_DETAIL = "procReadReceiptDetail";
         public const String READ_ALL_RECEIPT_DETAIL = "procReadReceitpAll";
         public const String READ_RECEIPT_BY_DATE = "procReadReceiptByDate";
         public const String READ_RECEIPT_DETAIL_BY_RCPT_NO = "procReadReceitpDetailsByRcptNo";
         public const String DELETE_RECEIPT = "procDeleteReceipt";
         public const String READ_AGENT_ADDRESS = "ReadAgentAddress";

         #endregion

         #region Report Data Export to Tally

         public const String READ_EXPORT_TO_TALLY = "usp_TallYNew";
         public const String READ_RECEIPT_FOR_TALLY = "procReadReceiptForDataExportTally";
         public const String READ_BILL_FOR_TALLY = "procReadBillForDataExportTally";
         public const String READ_DATA_EXPORT_TALLY = "procReadDataExportTally";

         #endregion

         #region AdvanceSearchReport

         public const String READ_ADVANCESEARCHREPORT = "procReadAdvanceSearchReport";
         public const String READ_ADVANCESEARCHREPORTFORANYOPTION = "procReadAdvanceSearchReportForAnyOption";

         #endregion
   

         public const String READ_ADVANCE_SEARCH = "procReadAdvanceSearch";

         public const String READ_BANKSTATEMENT_SEARCH = "procReadBankSatetment";
         public const String READ_ALLBANKSTATEMENT_SEARCH = "procReadAllBankSatetment";

   
        #region MiscellaneousReport

         public const String READ_MISCELLANEOUS_REPORT = "procReadMiscellaneousReport";
         public const String READ_MISCELLREPORTBYAGENT = "procReadMiscellaneousReportByAgent";
         public const String READ_MISCLLREPORTBYCOUNTRY = "procReadMiscellaneousReportByCountry";
         public const String READ_MISCLLREPORT_CONSOLIDATED = "procReadMiscellaneousByConsolidated";

          #endregion

         #region StatementOfAcct
         public const String READ_STATEMENTOFACCOUNT = "procReadStatementofAccount";
         #endregion

         public const String READ_AGININGANAYSIS = "procReadAginingAnays";

         public const String READ_AGININGANAYSISSEC = "procReadAginingAnaysis";

         public const String READ_AGININGANAYSISAGENTID = "procReadAginingAnaysisAgentId";

         public const String READ_AGININGANAYSISAGENTIDELSE = "procReadAginingAnaysisAgentElse";

         public const String READ_SUMMARYREPORT = "procReadSummaryReport";
         #region GroupMaster
         public const String Insert_GroupDetai = "procCreateGroupDetail";
         public const String Insert_MemberDetail = "CreateGroupMember";
         public const String Read_MemberName = "ReadGroupMember";
         public const String Read_Country = "procReadGroupCountry";
         public const String Update_Group = "procUpdateGroupMaster";
         public const String Edit_Group = "procEditGroup";
         #endregion

        #region SuperAdmin Login..
         public const String SUPERADMINLOGIN = "procLoginSuperAdmin";

        #endregion 
         public const String READ_BillBY_BILLID = "procReadBillByBillId";
         public const String READ_DATABY_BILLNO = "procReadDataByBillNO";
         public const String READ_DATABY_DATE = "procReadDataByDate";
         public const String READ_DATABY_AGENTID = "procReadDataByAgentId";
         public const String READ_BillRegisterBY_AGENTID = "procReadBillRegisterByAgentName"; 
        
    }
}
