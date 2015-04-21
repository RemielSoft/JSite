using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace Remielsoft.JetSave.DataAccessLayer
{
    public class EmbsyFeeDataAccess:BaseDataAccess
    {        
        private Database myDataBase;
        public EmbsyFeeDataAccess(Database m_database)
        {
            myDataBase = m_database;
        }

        #region Bind DropDownList NO. OF VISIT OR VISA TYPE TWO

        public List<Embsy> BindDropDownNoOfVisit()
        {
            List<Embsy> lstEmbsy = new List<Embsy>();
            Embsy embsy = new Embsy();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_VISA_TYPE_TWO);
            dbCommand.CommandType = CommandType.StoredProcedure;
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    embsy = GenerateApplicationUserFromDataReader(reader);
                    lstEmbsy.Add(embsy);
                }
            }
            return lstEmbsy;
        }

       

        private Embsy GenerateApplicationUserFromDataReader(IDataReader reader)
        {
            Embsy embsy = new Embsy();
            embsy.VisaTypeTwoId = GetIntegerFromDataReader(reader, "TYPE_TWO_ID");
            embsy.NoOfVisit = GetStringFromDataReader(reader, "DESCRIPTION_TWO");            
            return embsy;
        }
        #endregion

        #region BindDropDown Visa Duration

        public List<Embsy> BindDdlVisaDuration()
        {
            List<Embsy> lst = new List<Embsy>();
            
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_VISA_DURATION);
            dbCommand.CommandType=CommandType.StoredProcedure;
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Embsy embsy = new Embsy();
                    embsy.DurationDescription = GetStringFromDataReader(reader, "VISA_DESCRIPTION");
                    embsy.VisaDurationId = GetIntegerFromDataReader(reader, "DURATION_ID");
                    lst.Add(embsy);
                }
            }
            return lst;
        }
        #endregion

        #region ReadEmbassyFeesCountry

        public List<Embsy> ReadEmbassyFeesCountry()
        {
            List<Embsy> lstCountry = new List<Embsy>();

            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_EMBASSY_FEE_COUNTRY);
            dbCommand.CommandType = CommandType.StoredProcedure;
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Embsy embsy = new Embsy();
                    embsy.CountryId = GetIntegerFromDataReader(reader, "COUNTRY_ID");
                    embsy.Country = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    lstCountry.Add(embsy);
                }
            }
            return lstCountry;
        }
        #endregion

        #region BindDropDown Process Time

        public List<Embsy> BindDdlProcessTime()
        {
            List<Embsy> lst = new List<Embsy>();

            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_PROCESS_TIME);
            dbCommand.CommandType = CommandType.StoredProcedure;
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Embsy embsy = new Embsy();
                    embsy.ProcessTimeDesc = GetStringFromDataReader(reader, "DESCRIPTION");
                    embsy.ProcessTimeId = GetIntegerFromDataReader(reader, "PROCESSTIME_ID");
                    lst.Add(embsy);
                }
            }
            return lst;
        }
        #endregion

        #region ddl_no_ofvisit selectedIndexChange change the Fees Value

        //public List<Embsy> ddl_select_change(string novisit)
        //{
        //    List<Embsy> lst = new List<Embsy>();
        //    Embsy embsy = new Embsy();
        //    DbCommand dbCommand = myDataBase.GetSqlStringCommand("select fees from demo_visaselect where no_ofvisit='"+ novisit +"'");
        //    using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
        //    {
        //        while (reader.Read())
        //        {                    
        //            embsy.Fees = GetIntegerFromDataReader(reader, "fees");
        //            lst.Add(embsy);
        //        }
        //    }
        //    return lst;
        //}
        #endregion

        #region ReadEmbsyMasterId

        public List<Embsy> GetId(int countryId)
        {
            List<Embsy> lst = new List<Embsy>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_EMBASSY_MASTER_ID);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@COUNTRY_ID", DbType.Int32, countryId);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Embsy embsy = new Embsy();
                    embsy.EmbsyMasterId = GetIntegerFromDataReader(reader, "Emb_Master_Id");
                    lst.Add(embsy);
                }
            }
            return lst;
        }
        #endregion

        #region Insert the table

        public void InsertFees(Embsy embsy, int masterid)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.INSERT_EMBASSY_FEES);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@EMB_MASTER_ID", DbType.Int32, masterid);
            myDataBase.AddInParameter(dbCommand, "@VISA_TYPE_ONE_ID", DbType.String, embsy.VisaType);
            myDataBase.AddInParameter(dbCommand, "@VISA_TYPE_TWO_ID", DbType.String, embsy.NoOfVisit);
            myDataBase.AddInParameter(dbCommand, "@VISA_FEES", DbType.Decimal, embsy.Fees);
            myDataBase.AddInParameter(dbCommand, "@VISA_DURATION", DbType.String, embsy.DurationDescription);
            myDataBase.AddInParameter(dbCommand, "@PROCESS_TIME", DbType.String, embsy.ProcessTimeDesc);
            myDataBase.ExecuteNonQuery(dbCommand);
        }
        #endregion

        #region Bind Grid

        public List<Embsy> Gridbind()
        {
            List<Embsy> lst = new List<Embsy>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_EMBASSY_FEES);
            dbCommand.CommandType = CommandType.StoredProcedure;
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Embsy embsy = new Embsy();
                    embsy.EmbsyMasterId = GetIntegerFromDataReader(reader, "EMB_FEES_ID");
                    embsy.Country = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    embsy.VisaType = GetStringFromDataReader(reader, "DESCRIPTION_ONE");
                    embsy.NoOfVisit = GetStringFromDataReader(reader, "DESCRIPTION_TWO");
                    embsy.Fees = GetIntegerFromDataReader(reader, "VISA_FEES");
                    embsy.DurationDescription = GetStringFromDataReader(reader, "VISA_DESCRIPTION");
                    embsy.ProcessTimeDesc = GetStringFromDataReader(reader, "DESCRIPTION");
                    lst.Add(embsy);
                }
            }
            return lst;
        }
        #endregion

        #region Row Command Edit Grid

        public List<Embsy> Edit(int id)
        {
            List<Embsy> lst = new List<Embsy>();

            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_EMBASSY_FEES_BY_ID);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@EMBS_FEE_ID", DbType.Int32, id);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

                while (reader.Read())
                {
                    Embsy embsy = new Embsy();
                    embsy.Country = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    embsy.VisaType = GetStringFromDataReader(reader, "DESCRIPTION_ONE");
                    embsy.NoOfVisit = GetStringFromDataReader(reader, "DESCRIPTION_TWO");
                    embsy.Fees = GetIntegerFromDataReader(reader, "VISA_FEES");
                    embsy.DurationDescription = GetStringFromDataReader(reader, "VISA_DESCRIPTION");
                    embsy.ProcessTimeDesc = GetStringFromDataReader(reader, "DESCRIPTION");
                    embsy.CountryId = GetIntegerFromDataReader(reader, "COUNTRY_ID");
                    embsy.VisaTypeOneId = GetIntegerFromDataReader(reader, "TYPE_ONE_ID");
                    embsy.VisaTypeTwoId = GetIntegerFromDataReader(reader, "TYPE_TWO_ID");
                    embsy.VisaDurationId = GetIntegerFromDataReader(reader, "DURATION_ID");
                    embsy.ProcessTimeId = GetIntegerFromDataReader(reader, "PROCESSTIME_ID");
                    lst.Add(embsy);
                }
            return lst;
        }
        #endregion

        #region Button Update

        public void Update(int id, Embsy embsy)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_EMBASSY_FEES);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@EMB_FEE_ID", DbType.Int32, id);
            myDataBase.AddInParameter(dbCommand, "@EMB_MASTER_ID", DbType.Int32, embsy.EmbsyMasterId);
            myDataBase.AddInParameter(dbCommand, "@VISA_TYPE_ONE_ID", DbType.Int32, embsy.VisaType);
            myDataBase.AddInParameter(dbCommand, "@VISA_TYPE_TWO_ID", DbType.Int32, embsy.NoOfVisit);
            myDataBase.AddInParameter(dbCommand, "@VISA_FEES", DbType.Decimal, embsy.Fees);
            myDataBase.AddInParameter(dbCommand, "@VISA_DURATION", DbType.Int32, embsy.DurationDescription);
            myDataBase.AddInParameter(dbCommand, "@PROCESS_TIME", DbType.Int32, embsy.ProcessTimeDesc);
            myDataBase.ExecuteNonQuery(dbCommand);
        }
        #endregion

        #region GridViewRowUpdation

        public void UpdateFees(int id, Decimal Fees)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_EMBASSY_FEE_BY_ID);
            myDataBase.AddInParameter(dbCommand, "@EMB_FEE_ID", DbType.Int32, id);
            myDataBase.AddInParameter(dbCommand, "@VISA_FEES", DbType.Decimal, Fees);
            myDataBase.ExecuteNonQuery(dbCommand);
        }

        #endregion

        #region Delete

        public void Delete(int id)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.DELETE_EMBASSY_FEES);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@EMBS_FEE_ID", DbType.Int32, id);
            myDataBase.ExecuteNonQuery(dbCommand);
        }
        #endregion

        #region Bind Grid By Country Id

        public List<Embsy> GridbindByCountryId(Int32 CountryId)
        {
            List<Embsy> lst = new List<Embsy>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_EMBASSY_FEE_BY_COUNTRY_ID);            
            myDataBase.AddInParameter(dbCommand, "@CountryId", DbType.Int32, CountryId);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Embsy embsy = new Embsy();
                    embsy.EmbsyMasterId = GetIntegerFromDataReader(reader, "EMB_FEES_ID");
                    embsy.Country = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    embsy.VisaType = GetStringFromDataReader(reader, "DESCRIPTION_ONE");
                    embsy.NoOfVisit = GetStringFromDataReader(reader, "DESCRIPTION_TWO");
                    embsy.Fees = GetIntegerFromDataReader(reader, "VISA_FEES");
                    embsy.DurationDescription = GetStringFromDataReader(reader, "VISA_DESCRIPTION");
                    embsy.ProcessTimeDesc = GetStringFromDataReader(reader, "DESCRIPTION");
                    lst.Add(embsy);
                }
            }
            return lst;
        }
        #endregion

        #region BIND GRID BY VISA_TYPE_ID

        public List<Embsy> GridbindByVisaTypeId(Int32 VisaTypeId)
        {
            List<Embsy> lst = new List<Embsy>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_EMBASSY_FEE_BY_VISA_TYPE_ID);
            myDataBase.AddInParameter(dbCommand, "@VisaTypeId", DbType.Int32, VisaTypeId);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Embsy embsy = new Embsy();
                    embsy.EmbsyMasterId = GetIntegerFromDataReader(reader, "EMB_FEES_ID");
                    embsy.Country = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    embsy.VisaType = GetStringFromDataReader(reader, "DESCRIPTION_ONE");
                    embsy.NoOfVisit = GetStringFromDataReader(reader, "DESCRIPTION_TWO");
                    embsy.Fees = GetIntegerFromDataReader(reader, "VISA_FEES");
                    embsy.DurationDescription = GetStringFromDataReader(reader, "VISA_DESCRIPTION");
                    embsy.ProcessTimeDesc = GetStringFromDataReader(reader, "DESCRIPTION");
                    lst.Add(embsy);
                }
            }
            return lst;
        }
        #endregion

        #region BIND GRID BY VISA_DURATION_ID

        public List<Embsy> GridbindByVisaDurationId(Int32 VisaDurationId)
        {
            List<Embsy> lst = new List<Embsy>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_EMBASSY_FEE_BY_VISA_DURATION_ID);
            myDataBase.AddInParameter(dbCommand, "@VisaDurationId", DbType.Int32, VisaDurationId);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Embsy embsy = new Embsy();
                    embsy.EmbsyMasterId = GetIntegerFromDataReader(reader, "EMB_FEES_ID");
                    embsy.Country = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    embsy.VisaType = GetStringFromDataReader(reader, "DESCRIPTION_ONE");
                    embsy.NoOfVisit = GetStringFromDataReader(reader, "DESCRIPTION_TWO");
                    embsy.Fees = GetIntegerFromDataReader(reader, "VISA_FEES");
                    embsy.DurationDescription = GetStringFromDataReader(reader, "VISA_DESCRIPTION");
                    embsy.ProcessTimeDesc = GetStringFromDataReader(reader, "DESCRIPTION");
                    lst.Add(embsy);
                }
            }
            return lst;
        }
        #endregion

        #region BIND GRID BY NO_OF_VISIT_ID

        public List<Embsy> GridbindByNoOfVisitId(Int32 NoOfVisitId)
        {
            List<Embsy> lst = new List<Embsy>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_EMBASSY_FEE_BY_NO_OF_VISIT_ID);
            myDataBase.AddInParameter(dbCommand, "@NoOfVisitId", DbType.Int32, NoOfVisitId);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Embsy embsy = new Embsy();
                    embsy.EmbsyMasterId = GetIntegerFromDataReader(reader, "EMB_FEES_ID");
                    embsy.Country = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    embsy.VisaType = GetStringFromDataReader(reader, "DESCRIPTION_ONE");
                    embsy.NoOfVisit = GetStringFromDataReader(reader, "DESCRIPTION_TWO");
                    embsy.Fees = GetIntegerFromDataReader(reader, "VISA_FEES");
                    embsy.DurationDescription = GetStringFromDataReader(reader, "VISA_DESCRIPTION");
                    embsy.ProcessTimeDesc = GetStringFromDataReader(reader, "DESCRIPTION");
                    lst.Add(embsy);
                }
            }
            return lst;
        }
        #endregion

        #region BIND GRID BY PROCESS TIME ID

        public List<Embsy> GridbindByProcessTimeId(Int32 ProcessTimeId)
        {
            List<Embsy> lst = new List<Embsy>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_EMBASSY_FEE_BY_PROCESS_TIME_ID);
            myDataBase.AddInParameter(dbCommand, "@ProcessTimeId", DbType.Int32, ProcessTimeId);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Embsy embsy = new Embsy();
                    embsy.EmbsyMasterId = GetIntegerFromDataReader(reader, "EMB_FEES_ID");
                    embsy.Country = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    embsy.VisaType = GetStringFromDataReader(reader, "DESCRIPTION_ONE");
                    embsy.NoOfVisit = GetStringFromDataReader(reader, "DESCRIPTION_TWO");
                    embsy.Fees = GetIntegerFromDataReader(reader, "VISA_FEES");
                    embsy.DurationDescription = GetStringFromDataReader(reader, "VISA_DESCRIPTION");
                    embsy.ProcessTimeDesc = GetStringFromDataReader(reader, "DESCRIPTION");
                    lst.Add(embsy);
                }
            }
            return lst;
        }
        #endregion

        #region BIND GRID BY ALL

        public List<Embsy> GridbindByAll(Int32 CountryId, Int32 VisaTypeId, Int32 VisaDurationId, Int32 NoOfVisitId, Int32 ProcessTimeId)
        {
            List<Embsy> lst = new List<Embsy>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_EMBASSY_FEE_BY_ALL);
            myDataBase.AddInParameter(dbCommand, "@CountryId", DbType.Int32, CountryId);
            myDataBase.AddInParameter(dbCommand, "@VisaTypeId", DbType.Int32, VisaTypeId);
            myDataBase.AddInParameter(dbCommand, "@visaDurationId", DbType.Int32, VisaDurationId);
            myDataBase.AddInParameter(dbCommand, "@NoOfVisitId", DbType.Int32, NoOfVisitId);
            myDataBase.AddInParameter(dbCommand, "@ProcessTimeId", DbType.Int32, ProcessTimeId);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Embsy embsy = new Embsy();
                    embsy.EmbsyMasterId = GetIntegerFromDataReader(reader, "EMB_FEES_ID");
                    embsy.Country = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    embsy.VisaType = GetStringFromDataReader(reader, "DESCRIPTION_ONE");
                    embsy.NoOfVisit = GetStringFromDataReader(reader, "DESCRIPTION_TWO");
                    embsy.Fees = GetIntegerFromDataReader(reader, "VISA_FEES");
                    embsy.DurationDescription = GetStringFromDataReader(reader, "VISA_DESCRIPTION");
                    embsy.ProcessTimeDesc = GetStringFromDataReader(reader, "DESCRIPTION");
                    lst.Add(embsy);
                }
            }
            return lst;
        }
        #endregion
    }
}
