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
    public class VisaRequirementDataAccess : BaseDataAccess
    {
        private Database myDataBase;
        public VisaRequirementDataAccess(Database m_database)
        {
            myDataBase = m_database;
        }

        #region visa information insert

        public void CreateVisaRequirement(VisaRequirement visaRequirement)
        {

            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.INSERT_VISA_INFO);
            dbCommand.CommandType = CommandType.StoredProcedure;

            myDataBase.AddInParameter(dbCommand, "@FK_COUNTRY_ID", DbType.Int32, visaRequirement.FkCountryId);
            myDataBase.AddInParameter(dbCommand, "@COUNTRY_NAME", DbType.String, visaRequirement.CountryName);
            myDataBase.AddInParameter(dbCommand, "@FK_CONSULATE", DbType.String, visaRequirement.FkConsulate);
            myDataBase.AddInParameter(dbCommand, "@VISA_TYPE", DbType.String, visaRequirement.VisaType);
            myDataBase.AddInParameter(dbCommand, "@CON_ADDRESS", DbType.String, visaRequirement.ConAddress);
            myDataBase.AddInParameter(dbCommand, "@FEE", DbType.String, visaRequirement.Fee);
            myDataBase.AddInParameter(dbCommand, "@PROCESS_TIME", DbType.String, visaRequirement.ProcessTime);
            myDataBase.AddInParameter(dbCommand, "@SUBMISSION_DAYS", DbType.String, visaRequirement.SubmissionDays);
            myDataBase.AddInParameter(dbCommand, "@SUBMISSION_TIME", DbType.String, visaRequirement.SubmissionTime);
            myDataBase.AddInParameter(dbCommand, "@COLLECTION_DAYS", DbType.String, visaRequirement.CollectionDays);
            myDataBase.AddInParameter(dbCommand, "@COLLECTION_TIME", DbType.String, visaRequirement.CollectionTime);
            myDataBase.AddInParameter(dbCommand, "@VISA_SECTION_WORKING_DAYS", DbType.String, visaRequirement.VisaSectionWorkingDays);
            myDataBase.AddInParameter(dbCommand, "@Visa_OFF", DbType.String, visaRequirement.VisaOff);
            myDataBase.AddInParameter(dbCommand, "@Normal_Fee", DbType.String, visaRequirement.NormalFee);
            myDataBase.AddInParameter(dbCommand, "@Urgent_Fee", DbType.String, visaRequirement.UrgentFee);
            myDataBase.AddInParameter(dbCommand, "@VFS", DbType.String, visaRequirement.Vfs);
            myDataBase.AddInParameter(dbCommand, "@TIMINGS", DbType.String, visaRequirement.Timings);
            myDataBase.AddInParameter(dbCommand, "@Student_Fees", DbType.String, visaRequirement.StudentFees);
            myDataBase.AddInParameter(dbCommand, "@Comments", DbType.String, visaRequirement.Comments);
            myDataBase.AddInParameter(dbCommand, "@BASIC_REQUIREMENT", DbType.String, visaRequirement.BasicRequirements);
            myDataBase.AddInParameter(dbCommand, "@NOTES", DbType.String, visaRequirement.Notes);
            myDataBase.AddInParameter(dbCommand, "@MEDICAL_REQUIREMENT", DbType.String, visaRequirement.MedicalRequirement);
            // myDataBase.AddInParameter(dbCommand, "@OTHER_INFO", DbType.String, visaRequirement.OtherInfo);
            myDataBase.AddInParameter(dbCommand, "@Copy_Of_Interview_date", DbType.String, visaRequirement.CopyOfInterviewDate);
            myDataBase.AddInParameter(dbCommand, "@Gen_Req", DbType.String, visaRequirement.GenReq);
            myDataBase.AddInParameter(dbCommand, "@NORMAL_COLLECTION", DbType.String, visaRequirement.NormalCollection);
            myDataBase.AddInParameter(dbCommand, "@My_Application", DbType.String, visaRequirement.MyApplication);

            myDataBase.ExecuteNonQuery(dbCommand);

        }

        #endregion

        #region update visa info
        public void UpdateVisaRequirement(VisaRequirement visaRequirement, int req_id)
        {

            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_VISA_INFO);
            dbCommand.CommandType = CommandType.StoredProcedure;

            myDataBase.AddInParameter(dbCommand, "@REQ_ID", DbType.Int32, req_id);
            myDataBase.AddInParameter(dbCommand, "@FK_COUNTRY_ID", DbType.Int32, visaRequirement.FkCountryId);
            myDataBase.AddInParameter(dbCommand, "@COUNTRY_NAME", DbType.String, visaRequirement.CountryName);
            myDataBase.AddInParameter(dbCommand, "@FK_CONSULATE", DbType.String, visaRequirement.FkConsulate);
            myDataBase.AddInParameter(dbCommand, "@VISA_TYPE", DbType.String, visaRequirement.VisaType);
            myDataBase.AddInParameter(dbCommand, "@CON_ADDRESS", DbType.String, visaRequirement.ConAddress);
            myDataBase.AddInParameter(dbCommand, "@FEE", DbType.String, visaRequirement.Fee);
            myDataBase.AddInParameter(dbCommand, "@PROCESS_TIME", DbType.String, visaRequirement.ProcessTime);
            myDataBase.AddInParameter(dbCommand, "@SUBMISSION_DAYS", DbType.String, visaRequirement.SubmissionDays);
            myDataBase.AddInParameter(dbCommand, "@SUBMISSION_TIME", DbType.String, visaRequirement.SubmissionTime);
            myDataBase.AddInParameter(dbCommand, "@COLLECTION_DAYS", DbType.String, visaRequirement.CollectionDays);
            myDataBase.AddInParameter(dbCommand, "@COLLECTION_TIME", DbType.String, visaRequirement.CollectionTime);
            myDataBase.AddInParameter(dbCommand, "@VISA_SECTION_WORKING_DAYS", DbType.String, visaRequirement.VisaSectionWorkingDays);
            myDataBase.AddInParameter(dbCommand, "@Visa_OFF", DbType.String, visaRequirement.VisaOff);
            myDataBase.AddInParameter(dbCommand, "@Normal_Fee", DbType.String, visaRequirement.NormalFee);
            myDataBase.AddInParameter(dbCommand, "@Urgent_Fee", DbType.String, visaRequirement.UrgentFee);
            myDataBase.AddInParameter(dbCommand, "@VFS", DbType.String, visaRequirement.Vfs);
            myDataBase.AddInParameter(dbCommand, "@TIMINGS", DbType.String, visaRequirement.Timings);
            myDataBase.AddInParameter(dbCommand, "@Student_Fees", DbType.String, visaRequirement.StudentFees);
            myDataBase.AddInParameter(dbCommand, "@Comments", DbType.String, visaRequirement.Comments);
            myDataBase.AddInParameter(dbCommand, "@BASIC_REQUIREMENT", DbType.String, visaRequirement.BasicRequirements);
            myDataBase.AddInParameter(dbCommand, "@NOTES", DbType.String, visaRequirement.Notes);
            myDataBase.AddInParameter(dbCommand, "@MEDICAL_REQUIREMENT", DbType.String, visaRequirement.MedicalRequirement);
            myDataBase.AddInParameter(dbCommand, "@SPECIAL_INS", DbType.String, visaRequirement.OtherInfo);
            myDataBase.AddInParameter(dbCommand, "@Copy_Of_Interview_date", DbType.String, visaRequirement.CopyOfInterviewDate);
            myDataBase.AddInParameter(dbCommand, "@Gen_Req", DbType.String, visaRequirement.GenReq);
            myDataBase.AddInParameter(dbCommand, "@NORMAL_COLLECTION", DbType.String, visaRequirement.NormalCollection);
            myDataBase.AddInParameter(dbCommand, "@My_Application", DbType.String, visaRequirement.MyApplication);

            myDataBase.ExecuteNonQuery(dbCommand);

        }

        #endregion

        #region delete visa info
        public void DeleteVisaRequirement(int id)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.DELETE_VISA_INFO);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@REQ_ID", DbType.Int32, id);
            myDataBase.ExecuteNonQuery(dbCommand);
        }
        #endregion

        #region show visainfo on the basis of dropdown

        public List<VisaRequirement> ShowVisaRequirement(string CountryName, string VisaType, string Consulate)
        {
            // DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.SEARCH_VISA_FORM);
            DbCommand dbCommand = myDataBase.GetStoredProcCommand("procShowVisaInfo");
            dbCommand.CommandType = CommandType.StoredProcedure;

            VisaRequirement visaRequirement = new VisaRequirement();
            if (CountryName == " ")
            {
                myDataBase.AddInParameter(dbCommand, "@country_name", DbType.String, DBNull.Value);
            }
            else
                myDataBase.AddInParameter(dbCommand, "@country_name", DbType.String, CountryName);
            if (VisaType == " ")
            {
                myDataBase.AddInParameter(dbCommand, "@VISA_TYPE", DbType.String, DBNull.Value);
            }
            else
                myDataBase.AddInParameter(dbCommand, "@VISA_TYPE", DbType.String, VisaType);
            if (Consulate == " ")
            {
                myDataBase.AddInParameter(dbCommand, "@FK_CONSULATE", DbType.String, DBNull.Value);
            }
            else
                myDataBase.AddInParameter(dbCommand, "@FK_CONSULATE", DbType.String, Consulate);

            List<VisaRequirement> lstshow = new List<VisaRequirement>();
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    visaRequirement = showvisaFromDataReader(reader);
                    lstshow.Add(visaRequirement);
                }
            }
            return lstshow;

        }
        private VisaRequirement showvisaFromDataReader(IDataReader reader)
        {
            VisaRequirement visaRequirement = new VisaRequirement();

            visaRequirement.ReqId = GetIntegerFromDataReader(reader, "REQ_ID");
            visaRequirement.ConAddress = GetStringFromDataReader(reader, "CON_ADDRESS");
            visaRequirement.CountryName = GetStringFromDataReader(reader, "Country_Name");
            visaRequirement.VisaType = GetStringFromDataReader(reader, "Visa_Type");
            visaRequirement.Fee = GetStringFromDataReader(reader, "FEE");
            visaRequirement.ProcessTime = GetStringFromDataReader(reader, "PROCESS_TIME");
            visaRequirement.SubmissionDays = GetStringFromDataReader(reader, "SUBMISSION_DAYS");
            visaRequirement.SubmissionTime = GetStringFromDataReader(reader, "SUBMISSION_TIME");
            visaRequirement.CollectionDays = GetStringFromDataReader(reader, "COLLECTION_DAYS");
            visaRequirement.CollectionTime = GetStringFromDataReader(reader, "COLLECTION_TIME");
            visaRequirement.VisaSectionWorkingDays = GetStringFromDataReader(reader, "VISA_SECTION_WORKING_DAYS");
            visaRequirement.VisaOff = GetStringFromDataReader(reader, "Visa_OFF");
            visaRequirement.NormalFee = GetStringFromDataReader(reader, "Normal_Fee");
            visaRequirement.UrgentFee = GetStringFromDataReader(reader, "Urgent_Fee");
            visaRequirement.Vfs = GetStringFromDataReader(reader, "VFS");
            visaRequirement.Timings = GetStringFromDataReader(reader, "TIMINGS");
            visaRequirement.StudentFees = GetStringFromDataReader(reader, "Student_Fees");
            visaRequirement.Comments = GetStringFromDataReader(reader, "Comments");
            visaRequirement.BasicRequirements = GetStringFromDataReader(reader, "BASIC_REQUIREMENT");
            visaRequirement.Notes = GetStringFromDataReader(reader, "NOTES");
            visaRequirement.MedicalRequirement = GetStringFromDataReader(reader, "MEDICAL_REQUIREMENT");
            visaRequirement.OtherInfo = GetStringFromDataReader(reader, "SPECIAL_INS");
            visaRequirement.CopyOfInterviewDate = GetStringFromDataReader(reader, "Copy_Of_Interview_date");
            visaRequirement.GenReq = GetStringFromDataReader(reader, "Gen_Req");
            visaRequirement.NormalCollection = GetStringFromDataReader(reader, "NORMAL_COLLECTION");
            visaRequirement.MyApplication = GetStringFromDataReader(reader, "My_Application");
            // added by Divaker Singh....
           // visaRequirement.Visa_title = GetStringFromDataReader(reader, "Visa_title");
           // visaRequirement.Visa_Form = GetStringFromDataReader(reader, "Form");
            visaRequirement.Visa_Form = GetStringFromDataReader(reader, "visaPath");
            visaRequirement.Visa_title = GetStringFromDataReader(reader, "visaTitle");


            return visaRequirement;
        }

        #endregion

        #region bind grid

        public List<VisaRequirement> ReadVisaRequirement()
        {
            List<VisaRequirement> lstgrid = new List<VisaRequirement>();
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("select * from VISA_REQUIREMENT1 where IsDeleted=0");
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    VisaRequirement visaRequirement = new VisaRequirement();

                    visaRequirement.ReqId = GetIntegerFromDataReader(reader, "REQ_ID");
                    visaRequirement.CountryName = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    visaRequirement.FkConsulate = GetStringFromDataReader(reader, "FK_CONSULATE");
                    visaRequirement.VisaType = GetStringFromDataReader(reader, "VISA_TYPE");
                    visaRequirement.ConAddress = GetStringFromDataReader(reader, "CON_ADDRESS");
                    visaRequirement.Fee = GetStringFromDataReader(reader, "FEE");
                    visaRequirement.ProcessTime = GetStringFromDataReader(reader, "PROCESS_TIME");
                    visaRequirement.SubmissionDays = GetStringFromDataReader(reader, "SUBMISSION_DAYS");
                    visaRequirement.SubmissionTime = GetStringFromDataReader(reader, "SUBMISSION_TIME");
                    visaRequirement.CollectionDays = GetStringFromDataReader(reader, "COLLECTION_DAYS");
                    visaRequirement.CollectionTime = GetStringFromDataReader(reader, "COLLECTION_TIME");
                    visaRequirement.VisaSectionWorkingDays = GetStringFromDataReader(reader, "VISA_SECTION_WORKING_DAYS");
                    visaRequirement.VisaOff = GetStringFromDataReader(reader, "Visa_OFF");
                    visaRequirement.NormalFee = GetStringFromDataReader(reader, "Normal_Fee");
                    visaRequirement.UrgentFee = GetStringFromDataReader(reader, "Urgent_Fee");
                    visaRequirement.Vfs = GetStringFromDataReader(reader, "VFS");
                    visaRequirement.Timings = GetStringFromDataReader(reader, "TIMINGS");
                    visaRequirement.StudentFees = GetStringFromDataReader(reader, "Student_Fees");
                    visaRequirement.Comments = GetStringFromDataReader(reader, "Comments");
                    visaRequirement.BasicRequirements = GetStringFromDataReader(reader, "BASIC_REQUIREMENT");
                    visaRequirement.Notes = GetStringFromDataReader(reader, "NOTES");
                    visaRequirement.MedicalRequirement = GetStringFromDataReader(reader, "MEDICAL_REQUIREMENT");
                    // visaRequirement.OtherInfo = GetStringFromDataReader(reader, "OTHER_INFO");
                    visaRequirement.CopyOfInterviewDate = GetStringFromDataReader(reader, "Copy_Of_Interview_date");
                    visaRequirement.GenReq = GetStringFromDataReader(reader, "Gen_Req");
                    visaRequirement.NormalCollection = GetStringFromDataReader(reader, "NORMAL_COLLECTION");
                    visaRequirement.MyApplication = GetStringFromDataReader(reader, "My_Application");

                    lstgrid.Add(visaRequirement);
                }
            }

            return lstgrid;
        }
        #endregion

        #region edit visa info

        public List<VisaRequirement> ReadVisaRequirementByReqId(int id)
        {
            List<VisaRequirement> lstgrid = new List<VisaRequirement>();

            DbCommand dbCommand = myDataBase.GetSqlStringCommand("select * from VISA_REQUIREMENT1 where REQ_ID=" + id + " and IsDeleted=0 ");
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

                while (reader.Read())
                {
                    VisaRequirement visaRequirement = new VisaRequirement();

                    visaRequirement.ReqId = GetIntegerFromDataReader(reader, "REQ_ID");
                    visaRequirement.CountryName = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    visaRequirement.FkConsulate = GetStringFromDataReader(reader, "FK_CONSULATE");
                    visaRequirement.VisaType = GetStringFromDataReader(reader, "VISA_TYPE");
                    visaRequirement.ConAddress = GetStringFromDataReader(reader, "CON_ADDRESS");
                    visaRequirement.Fee = GetStringFromDataReader(reader, "FEE");
                    visaRequirement.ProcessTime = GetStringFromDataReader(reader, "PROCESS_TIME");
                    visaRequirement.SubmissionDays = GetStringFromDataReader(reader, "SUBMISSION_DAYS");
                    visaRequirement.SubmissionTime = GetStringFromDataReader(reader, "SUBMISSION_TIME");
                    visaRequirement.CollectionDays = GetStringFromDataReader(reader, "COLLECTION_DAYS");
                    visaRequirement.CollectionTime = GetStringFromDataReader(reader, "COLLECTION_TIME");
                    visaRequirement.VisaSectionWorkingDays = GetStringFromDataReader(reader, "VISA_SECTION_WORKING_DAYS");
                    visaRequirement.VisaOff = GetStringFromDataReader(reader, "Visa_OFF");
                    visaRequirement.NormalFee = GetStringFromDataReader(reader, "Normal_Fee");
                    visaRequirement.UrgentFee = GetStringFromDataReader(reader, "Urgent_Fee");
                    visaRequirement.Vfs = GetStringFromDataReader(reader, "VFS");
                    visaRequirement.Timings = GetStringFromDataReader(reader, "TIMINGS");
                    visaRequirement.StudentFees = GetStringFromDataReader(reader, "Student_Fees");
                    visaRequirement.Comments = GetStringFromDataReader(reader, "Comments");
                    visaRequirement.BasicRequirements = GetStringFromDataReader(reader, "BASIC_REQUIREMENT");
                    visaRequirement.Notes = GetStringFromDataReader(reader, "NOTES");
                    visaRequirement.MedicalRequirement = GetStringFromDataReader(reader, "MEDICAL_REQUIREMENT");
                    // visaRequirement.OtherInfo = GetStringFromDataReader(reader, "OTHER_INFO");
                    visaRequirement.CopyOfInterviewDate = GetStringFromDataReader(reader, "Copy_Of_Interview_date");
                    visaRequirement.GenReq = GetStringFromDataReader(reader, "Gen_Req");
                    visaRequirement.NormalCollection = GetStringFromDataReader(reader, "NORMAL_COLLECTION");
                    visaRequirement.MyApplication = GetStringFromDataReader(reader, "My_Application");

                    lstgrid.Add(visaRequirement);
                }
            return lstgrid;
        }
        #endregion

        #region search in gridview on the basis of country

        public List<VisaRequirement> ReadVisaRequirementByCountryName(string country_name)
        {
            List<VisaRequirement> lstgrid = new List<VisaRequirement>();
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("select * from VISA_REQUIREMENT1 where COUNTRY_NAME LIKE '" + country_name + "%' and IsDeleted=0 order by country_name ");
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    VisaRequirement visaRequirement = new VisaRequirement();

                    visaRequirement.ReqId = GetIntegerFromDataReader(reader, "REQ_ID");
                    visaRequirement.CountryName = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    visaRequirement.FkConsulate = GetStringFromDataReader(reader, "FK_CONSULATE");
                    visaRequirement.VisaType = GetStringFromDataReader(reader, "VISA_TYPE");
                    visaRequirement.ConAddress = GetStringFromDataReader(reader, "CON_ADDRESS");
                    visaRequirement.Fee = GetStringFromDataReader(reader, "FEE");
                    visaRequirement.ProcessTime = GetStringFromDataReader(reader, "PROCESS_TIME");
                    visaRequirement.SubmissionDays = GetStringFromDataReader(reader, "SUBMISSION_DAYS");
                    visaRequirement.SubmissionTime = GetStringFromDataReader(reader, "SUBMISSION_TIME");
                    visaRequirement.CollectionDays = GetStringFromDataReader(reader, "COLLECTION_DAYS");
                    visaRequirement.CollectionTime = GetStringFromDataReader(reader, "COLLECTION_TIME");
                    visaRequirement.VisaSectionWorkingDays = GetStringFromDataReader(reader, "VISA_SECTION_WORKING_DAYS");
                    visaRequirement.VisaOff = GetStringFromDataReader(reader, "Visa_OFF");
                    visaRequirement.NormalFee = GetStringFromDataReader(reader, "Normal_Fee");
                    visaRequirement.UrgentFee = GetStringFromDataReader(reader, "Urgent_Fee");
                    visaRequirement.Vfs = GetStringFromDataReader(reader, "VFS");
                    visaRequirement.Timings = GetStringFromDataReader(reader, "TIMINGS");
                    visaRequirement.StudentFees = GetStringFromDataReader(reader, "Student_Fees");
                    visaRequirement.Comments = GetStringFromDataReader(reader, "Comments");
                    visaRequirement.BasicRequirements = GetStringFromDataReader(reader, "BASIC_REQUIREMENT");
                    visaRequirement.Notes = GetStringFromDataReader(reader, "NOTES");
                    visaRequirement.MedicalRequirement = GetStringFromDataReader(reader, "MEDICAL_REQUIREMENT");
                    // visaRequirement.OtherInfo = GetStringFromDataReader(reader, "OTHER_INFO");
                    visaRequirement.CopyOfInterviewDate = GetStringFromDataReader(reader, "Copy_Of_Interview_date");
                    visaRequirement.GenReq = GetStringFromDataReader(reader, "Gen_Req");
                    visaRequirement.NormalCollection = GetStringFromDataReader(reader, "NORMAL_COLLECTION");
                    visaRequirement.MyApplication = GetStringFromDataReader(reader, "My_Application");

                    lstgrid.Add(visaRequirement);
                }
            }

            return lstgrid;
        }

        #endregion

        #region dropdown list country

        public List<VisaRequirement> ReadCountry()
        {

            List<VisaRequirement> lstcountry = new List<VisaRequirement>();
            VisaRequirement visaRequirement = null;
            //DbCommand dbCommand = myDataBase.GetSqlStringCommand("SELECT distinct COUNTRY.COUNTRY_NAME,country.COUNTRY_ID FROM  EMB_MASTER INNER JOIN   COUNTRY ON EMB_MASTER.EMBS_COUNTRY_ID = COUNTRY.COUNTRY_ID order by COUNTRY.COUNTRY_NAME asc");
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("Select COUNTRY_ID,COUNTRY_NAME from Country Where IsDeleted=0 order by Country_Name");
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    visaRequirement = CountryFromDataReader(reader);
                    lstcountry.Add(visaRequirement);
                }
            }
            return lstcountry;

        }


        public List<VisaRequirement> ReadAllState()
        {

            List<VisaRequirement> lst = new List<VisaRequirement>();
            VisaRequirement visaRequirement = null;
            //DbCommand dbCommand = myDataBase.GetSqlStringCommand("SELECT distinct COUNTRY.COUNTRY_NAME,country.COUNTRY_ID FROM  EMB_MASTER INNER JOIN   COUNTRY ON EMB_MASTER.EMBS_COUNTRY_ID = COUNTRY.COUNTRY_ID order by COUNTRY.COUNTRY_NAME asc");
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("Select state_id,state_name from State Where IsDeleted=0 order by state_name");
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    visaRequirement = new VisaRequirement();
                    visaRequirement.stateId = GetIntegerFromDataReader(reader, "state_id");
                    visaRequirement.state = GetStringFromDataReader(reader, "state_name");
                    lst.Add(visaRequirement);
                }
            }
            return lst;

        }
        public List<VisaRequirement> ReadStateByCountryID(int id)
        {
            List<VisaRequirement> lst = new List<VisaRequirement>();
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.READ_STATE_BYCOUNTRYID);
            myDataBase.AddInParameter(dbcommand, "@in_countryId", DbType.Int32, id);
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    VisaRequirement locationMaster = new VisaRequirement();
                    locationMaster.stateId = GetIntegerFromDataReader(reader1, "state_id");
                    locationMaster.state = GetStringFromDataReader(reader1, "state_name");
                    locationMaster.Created_By = GetStringFromDataReader(reader1, "Created_By");
                    locationMaster.Created_Date = GetDateFromReader(reader1, "Created_Date");
                    locationMaster.Modified_By = GetStringFromDataReader(reader1, "Modified_By");
                    locationMaster.Modified_Date = GetDateFromReader(reader1, "Modified_Date");
                    lst.Add(locationMaster);
                }
            }
            return lst;
        }


        public List<VisaRequirement> ReadCityByStateID(int id)
        {
            List<VisaRequirement> lst = new List<VisaRequirement>();
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.READ_CITY_BYSTATEID);
            myDataBase.AddInParameter(dbcommand, "@in_stateId", DbType.Int32, id);
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    VisaRequirement locationMaster = new VisaRequirement();
                    locationMaster.consulate_id = GetIntegerFromDataReader(reader1, "CityId");
                    locationMaster.consulate_name = GetStringFromDataReader(reader1, "CityName");
                   
                    lst.Add(locationMaster);
                }
            }
            return lst;
        }
        
        public List<VisaRequirement> ReadSchengenCountry(int? id)
        {
            List<VisaRequirement> lstSchengen = new List<VisaRequirement>();
            VisaRequirement visaRequirement = null;
            DbCommand dbCommand = myDataBase.GetStoredProcCommand("procReadSchengenCountry");
            dbCommand.CommandType = CommandType.StoredProcedure;

            if (id == null)
            {
                myDataBase.AddInParameter(dbCommand, "@in_CountryId", DbType.Int32, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@in_CountryId", DbType.Int32, id);
            }
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    visaRequirement = CountryFromDataReader(reader);
                    lstSchengen.Add(visaRequirement);
                }
            }
            return lstSchengen;

        }

         public List<VisaForm> ReadSchengenForm(int? id)
        {
            List<VisaForm> lstSchengen = new List<VisaForm>();
            VisaForm visaRequirement = null;
            DbCommand dbCommand = myDataBase.GetStoredProcCommand("procReadSchengenVisaForm");
            dbCommand.CommandType = CommandType.StoredProcedure;

            if (id == null)
            {
                myDataBase.AddInParameter(dbCommand, "@in_CountryId", DbType.Int32, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@in_CountryId", DbType.Int32, id);
            }
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                  //  VisaForm visaForm = new VisaForm();
                    visaRequirement = new VisaForm();

                    visaRequirement.Form = Convert.ToString(reader["Form"]);
                    visaRequirement.CountryForVisa = Convert.ToString(reader["COUNTRY_NAME"]);
                    visaRequirement.VisaTitle = Convert.ToString(reader["Visa_title"]);
                    visaRequirement.CountryId = Convert.ToInt32(reader["COUNTRY_ID"]);
                    lstSchengen.Add(visaRequirement);
                }
            }
            return lstSchengen;

        }






        private VisaRequirement CountryFromDataReader(IDataReader reader)
        {
            VisaRequirement country = new VisaRequirement();

            country.CountryName = GetStringFromDataReader(reader, "COUNTRY_NAME");
            country.COUNTRY_ID = GetIntegerFromDataReader(reader, "COUNTRY_ID");
            //country.IsSchengen = GetBooleanFromDataReader(reader, "ISSCHENGEN");
            return country;
        }

        #endregion




        #region dropdown Consulate

        public List<VisaRequirement> ReadConsulate()
        {

            List<VisaRequirement> lstConsulate = new List<VisaRequirement>();
            VisaRequirement visaRequirement = null;
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.READ_CONSULATE);
            myDataBase.AddInParameter(dbcommand, "@in_CityId", DbType.Int32, DBNull.Value);
            using (IDataReader reader = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader.Read())
                {
                    visaRequirement = ConsulateFromDataReader(reader);
                    lstConsulate.Add(visaRequirement);
                }
            }
            return lstConsulate;

        }
        private VisaRequirement ConsulateFromDataReader(IDataReader reader)
        {
            VisaRequirement Consulate = new VisaRequirement();
            Consulate.consulate_name = GetStringFromDataReader(reader, "consulate_name");
            Consulate.consulate_id = GetIntegerFromDataReader(reader, "Consulate_Id");
            return Consulate;
        }

        #endregion

        #region dropdown visatype

        public List<VisaRequirement> ReadVisaType()
        {

            List<VisaRequirement> lstVisaType = new List<VisaRequirement>();
            VisaRequirement visaRequirement = null;
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("Select * from VISA_TYPE_ONE Where IsDeleted=0");
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    visaRequirement = VisaTypeFromDataReader(reader);
                    lstVisaType.Add(visaRequirement);
                }
            }
            return lstVisaType;

        }
        private VisaRequirement VisaTypeFromDataReader(IDataReader reader)
        {
            VisaRequirement VisaType = new VisaRequirement();
            VisaType.DESCRIPTION_ONE = GetStringFromDataReader(reader, "DESCRIPTION_ONE");
            VisaType.TYPE_ONE_ID = GetIntegerFromDataReader(reader, "TYPE_ONE_ID");
            return VisaType;
        }





        public List<VisaRequirement> ReadVisaTypeOne(int? visaId)
        {
            List<VisaRequirement> lstVisaType = new List<VisaRequirement>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand("procReadVisaType");
            if (visaId != null)
            {
                myDataBase.AddInParameter(dbCommand, "@in_VisaTypeId", DbType.Int32, visaId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@in_VisaTypeId", DbType.Int32, DBNull.Value);
            }

            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    VisaRequirement visaRequirement = new VisaRequirement();
                    visaRequirement.TYPE_ONE_ID = GetIntegerFromDataReader(reader, "Type_One_Id");
                    visaRequirement.DESCRIPTION_ONE = GetStringFromDataReader(reader, "DESCRIPTION_ONE");
                    lstVisaType.Add(visaRequirement);
                }
            }
            return lstVisaType;
        }

        public int CreateVisaTypeOne(VisaRequirement visaReguirement)
        {

            DbCommand dbCommand = myDataBase.GetStoredProcCommand("procCreateVisaType");
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@in_VisaType", DbType.String, visaReguirement.DESCRIPTION_ONE);
            myDataBase.AddInParameter(dbCommand, "@in_CreatedBy", DbType.String, visaReguirement.Created_By);
            myDataBase.AddOutParameter(dbCommand, "@out_Id", DbType.Int32, 10);
            myDataBase.ExecuteNonQuery(dbCommand);
            var id = dbCommand.Parameters["@out_Id"].Value;
            int status = Convert.ToInt32(id);
            return status;
        }


        public void UpdateVisaTypeOne(VisaRequirement visaReguirement)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand("procUpdateVisaType");
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@in_VisaTypeId", DbType.Int32, visaReguirement.TYPE_ONE_ID);
            myDataBase.AddInParameter(dbCommand, "@in_VisaType", DbType.String, visaReguirement.DESCRIPTION_ONE);
            myDataBase.AddInParameter(dbCommand, "@in_ModifiedBy", DbType.String, visaReguirement.Modified_By);
            myDataBase.ExecuteNonQuery(dbCommand);
        }


        public void DeleteVisaTypeOne(int id)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand("procDeleteVisaType");
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@in_VisaTypeId", DbType.Int32, id);
            myDataBase.ExecuteNonQuery(dbCommand);
        }
        #endregion


    }
}
