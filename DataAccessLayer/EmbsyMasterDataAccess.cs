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
    public class EmbsyMasterDataAccess:BaseDataAccess
    {
        private Database myDataBase;
        public EmbsyMasterDataAccess(Database m_database)
        {
            myDataBase = m_database;
        }

        #region Embassy Master Insert

        public void Insert(Embsy embsy)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.INSERT_EMBASSY_MASTER);
            dbCommand.CommandType = CommandType.StoredProcedure;
            
            myDataBase.AddInParameter(dbCommand, "@Country", DbType.Int32, embsy.Country);
            myDataBase.AddInParameter(dbCommand, "@VisaDurationStatus", DbType.String, embsy.DurationDescription);
            myDataBase.AddInParameter(dbCommand, "@ProcessTimeStatus", DbType.String, embsy.ProcessTimeDesc);
            myDataBase.AddInParameter(dbCommand, "@Vfs_Bls_Fee", DbType.Decimal, embsy.VfsBlsFee);
            myDataBase.AddInParameter(dbCommand, "@TokenFee", DbType.Decimal, embsy.TokenFee);
            myDataBase.AddInParameter(dbCommand, "@AttastationFee", DbType.Decimal, embsy.AttastationFee);
            myDataBase.AddInParameter(dbCommand, "@HandlingCharge", DbType.Decimal, embsy.HandlingFee);            
            
            myDataBase.ExecuteNonQuery(dbCommand);
        }

        #endregion

        #region Grid Bind

        public List<Embsy> GridBind()
        {
            List<Embsy> lst = new List<Embsy>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_EMBASSY_MASTER);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Embsy embsy = new Embsy();

                    embsy.EmbsyMasterId = GetIntegerFromDataReader(reader, "EMBS_ID");
                    embsy.Country = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    embsy.DurationDescription = GetStringFromDataReader(reader, "EMB_VISADURATION_STATUS");
                    embsy.ProcessTimeDesc = GetStringFromDataReader(reader, "EMB_PROCESSTIME_STATUS");
                    embsy.VfsBlsFee = GetDecimalFromDataReader(reader, "Vfs_Bls_Charges");
                    embsy.TokenFee = GetDecimalFromDataReader(reader, "Token_Charges");
                    embsy.AttastationFee = GetDecimalFromDataReader(reader, "Attestation_Charges");
                    embsy.HandlingFee = GetDecimalFromDataReader(reader, "Handling_Charges");

                    lst.Add(embsy);
                }
            }
            return lst;
        }

        public List<Embsy> ReadEmbassyMasterByCountryId(Int32 CountryId)
        {
            List<Embsy> lst = new List<Embsy>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_EMABASSY_MASTER_BY_COUNTRY_ID);
            myDataBase.AddInParameter(dbCommand, "@CountryId", DbType.Int32, CountryId);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Embsy embsy = new Embsy();

                    embsy.EmbsyMasterId = GetIntegerFromDataReader(reader, "EMBS_ID");
                    embsy.Country = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    embsy.DurationDescription = GetStringFromDataReader(reader, "EMB_VISADURATION_STATUS");
                    embsy.ProcessTimeDesc = GetStringFromDataReader(reader, "EMB_PROCESSTIME_STATUS");
                    embsy.VfsBlsFee = GetDecimalFromDataReader(reader, "Vfs_Bls_Charges");
                    embsy.TokenFee = GetDecimalFromDataReader(reader, "Token_Charges");
                    embsy.AttastationFee = GetDecimalFromDataReader(reader, "Attestation_Charges");
                    embsy.HandlingFee = GetDecimalFromDataReader(reader, "Handling_Charges");

                    lst.Add(embsy);
                }
            }
            return lst;
        }
        #endregion

        #region Edit,Delete GridView

        public List<Embsy> Edit(int id)
        {
            List<Embsy> lst = new List<Embsy>();

            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_EMBASSY_MASTER_BY_ID);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@id", DbType.Int32, id);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))

                while (reader.Read())
                {
                    Embsy embsy = new Embsy();

                    embsy.EmbsyMasterId = GetIntegerFromDataReader(reader, "EMBS_ID");
                    embsy.Country = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    embsy.CountryId = GetIntegerFromDataReader(reader, "COUNTRY_ID");
                    embsy.DurationDescription = GetStringFromDataReader(reader, "EMB_VISADURATION_STATUS");
                    embsy.ProcessTimeDesc = GetStringFromDataReader(reader, "EMB_PROCESSTIME_STATUS");
                    embsy.VfsBlsFee = GetDecimalFromDataReader(reader, "Vfs_Bls_Charges");
                    embsy.TokenFee = GetDecimalFromDataReader(reader, "Token_Charges");
                    embsy.AttastationFee = GetDecimalFromDataReader(reader, "Attestation_Charges");
                    embsy.HandlingFee = GetDecimalFromDataReader(reader, "Handling_Charges");

                    lst.Add(embsy);
                }
            return lst;
        }

        #endregion

        #region Embassy Master Update

        public void Update(Embsy embsy)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_EMBASSY_MASTER);
            dbCommand.CommandType = CommandType.StoredProcedure;

            myDataBase.AddInParameter(dbCommand, "@id", DbType.Int32, embsy.EmbsyMasterId);
            myDataBase.AddInParameter(dbCommand, "@Country", DbType.Int32, embsy.Country);
            myDataBase.AddInParameter(dbCommand, "@VisaDurationStatus", DbType.String, embsy.DurationDescription);
            myDataBase.AddInParameter(dbCommand, "@ProcessTimeStatus", DbType.String, embsy.ProcessTimeDesc);
            myDataBase.AddInParameter(dbCommand, "@Vfs_Bls_Fee", DbType.Decimal, embsy.VfsBlsFee);
            myDataBase.AddInParameter(dbCommand, "@TokenFee", DbType.Decimal, embsy.TokenFee);
            myDataBase.AddInParameter(dbCommand, "@AttastationFee", DbType.Decimal, embsy.AttastationFee);
            myDataBase.AddInParameter(dbCommand, "@HandlingCharge", DbType.Decimal, embsy.HandlingFee);

            myDataBase.ExecuteNonQuery(dbCommand);
        }

        #endregion

        #region Embassy Master Delete

        public void Delete(int id)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.DELETE_EMBASSY_MASTER);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@id", DbType.Int32, id);
            myDataBase.ExecuteNonQuery(dbCommand);
        }

        #endregion

        #region Read Country

        public List<Embsy> ReadCountry()
        {
            List<Embsy> lstCountry = new List<Embsy>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_COUNTRY);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Embsy embasy = new Embsy();
                    embasy.CountryId = GetIntegerFromDataReader(reader, "COUNTRY_ID");
                    embasy.Country = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    lstCountry.Add(embasy);
                }
            }
            return lstCountry;
        }

        #endregion
    }
}
