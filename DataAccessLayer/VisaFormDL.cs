using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DataAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace Remielsoft.JetSave.DataAccessLayer
{
    public class VisaFormDL : BaseDataAccess
    {
        private Database myDataBase;
        public VisaFormDL(Database m_database)
        {
            myDataBase = m_database;
        }
        public void InsertRecord(List<VisaForm> addVisaDom)
        {
            foreach (VisaForm adVisaDom in addVisaDom)
            {
                string cityCommaSep = adVisaDom.VisaCity;
                string[] city = cityCommaSep.Split(',');


                foreach (var item in city)
                {
                    if (item != "")
                    {

                        DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.CREATE_VISA_FORM);
                        // myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, adVisaDom.LocationId);
                        myDataBase.AddInParameter(dbCommand, "@Visa_City", DbType.String, item);
                        myDataBase.AddInParameter(dbCommand, "@Country_for_Visa", DbType.String, adVisaDom.CountryForVisa);
                        myDataBase.AddInParameter(dbCommand, "Visa_title", DbType.String, adVisaDom.VisaTitle);
                        myDataBase.AddInParameter(dbCommand, "@Form", DbType.String, adVisaDom.Form);
                        //myDataBase.AddInParameter(dbCommand, "@FilePath", DbType.String, adVisaDom.FilePath);
                        //myDataBase.AddInParameter(dbCommand, "@CountryId", DbType.String, adVisaDom.CountryId);
                        ////myDataBase.AddInParameter(dbCommand, "@Type", DbType.String, adVisaDom.VisaTitle);
                        myDataBase.AddInParameter(dbCommand, "@CreatedBy", DbType.String, adVisaDom.Created_By);
                        myDataBase.ExecuteNonQuery(dbCommand);
                    }

                }


            }
        }

        public void InsertVaccination(VisaForm addVisaDom)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.CREATE_VACCINATION_VISA_FORM);
            myDataBase.AddInParameter(dbCommand, "Visa_title", DbType.String, addVisaDom.VisaTitle);
            myDataBase.AddInParameter(dbCommand, "@Form", DbType.String, addVisaDom.Form);
            myDataBase.AddInParameter(dbCommand, "@CreatedBy", DbType.String, addVisaDom.Created_By);
            myDataBase.ExecuteNonQuery(dbCommand);

        }
        public void InsertCoverNote(VisaForm addVisaDom)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.CREATE_COVERNOTE_FORM);
            myDataBase.AddInParameter(dbCommand, "Visa_title", DbType.String, addVisaDom.VisaTitle);
            myDataBase.AddInParameter(dbCommand, "@Form", DbType.String, addVisaDom.Form);
            myDataBase.AddInParameter(dbCommand, "@CreatedBy", DbType.String, addVisaDom.Created_By);
            myDataBase.ExecuteNonQuery(dbCommand);

        }
        public void DeleteCoverNote(int id)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.DELETE_COVERNOTE_VISA_FORM);
            myDataBase.AddInParameter(dbCommand, "@id", DbType.Int32, id);
            myDataBase.ExecuteNonQuery(dbCommand);
        }

        public List<VisaForm> ReadCoverNote(int? id)
        {
            List<VisaForm> adlst = new List<VisaForm>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_COVERNOTE_VISA_FORM);
            myDataBase.AddInParameter(dbCommand, "@id", DbType.Int32, id);
            IDataReader reader = myDataBase.ExecuteReader(dbCommand);
            {
                while (reader.Read())
                {
                    VisaForm addVisaDom = new VisaForm();
                    addVisaDom = VaccinationFromDataReader(reader);
                    adlst.Add(addVisaDom);
                }
                return adlst;
            }
        }

        public void DeleteVaccination(int id)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.DELETE_VACCINATION_VISA_FORM);
            myDataBase.AddInParameter(dbCommand, "@id", DbType.Int32, id);
            myDataBase.ExecuteNonQuery(dbCommand);
        }


        public List<VisaForm> ReadVaccination(int? id)
        {
            List<VisaForm> adlst = new List<VisaForm>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_VACCINATION_VISA_FORM);
            myDataBase.AddInParameter(dbCommand, "@id", DbType.Int32, id);
            IDataReader reader = myDataBase.ExecuteReader(dbCommand);
            {
                while (reader.Read())
                {
                    VisaForm addVisaDom = new VisaForm();
                    addVisaDom = VaccinationFromDataReader(reader);
                    adlst.Add(addVisaDom);
                }
                return adlst;
            }
        }

        public void InsertRecordForSchnegenCountry(VisaForm addVisaDom)
        {
            //foreach (VisaForm adVisaDom in addVisaDom)
            //{
            string schnegenCountryComm = addVisaDom.CountryForVisa;
            string[] schnegen = schnegenCountryComm.Split(',');

            string cityCommaSep = addVisaDom.VisaCity;
            string[] city = cityCommaSep.Split(',');

            foreach (var item in city)
            {
                if (item != "")
                {
                    foreach (var schengenCountry in schnegen)
                    {
                        if (schengenCountry != "")
                        {
                            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.CREATE_VISA_FORM);
                            // myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, adVisaDom.LocationId);
                            myDataBase.AddInParameter(dbCommand, "@Visa_City", DbType.String, item);
                            myDataBase.AddInParameter(dbCommand, "@Country_for_Visa", DbType.String, schengenCountry);
                            myDataBase.AddInParameter(dbCommand, "Visa_title", DbType.String, addVisaDom.VisaTitle);
                            myDataBase.AddInParameter(dbCommand, "@Form", DbType.String, addVisaDom.Form);
                            //myDataBase.AddInParameter(dbCommand, "@FilePath", DbType.String, adVisaDom.FilePath);
                            //myDataBase.AddInParameter(dbCommand, "@CountryId", DbType.String, adVisaDom.CountryId);
                            ////myDataBase.AddInParameter(dbCommand, "@Type", DbType.String, adVisaDom.VisaTitle);
                            myDataBase.AddInParameter(dbCommand, "@CreatedBy", DbType.String, addVisaDom.Created_By);
                            myDataBase.ExecuteNonQuery(dbCommand);
                        }
                    }
                }




            }
        }









        public List<VisaForm> ReadDelhiForm()
        {
            List<VisaForm> adlst = new List<VisaForm>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.SELECT_DELHI);
            VisaForm addVisaDom = new VisaForm();
            IDataReader reader = myDataBase.ExecuteReader(dbCommand);
            {
                while (reader.Read())
                {
                    addVisaDom = GeneraterecordFromDataReader(reader);
                    adlst.Add(addVisaDom);
                }

                return adlst;
            }
        }
        private VisaForm GeneraterecordFromDataReader(IDataReader reader)
        {
            VisaForm addVisaDom = new VisaForm();
            addVisaDom.Id = GetIntegerFromDataReader(reader, "Id");
            addVisaDom.CountryForVisa = GetStringFromDataReader(reader, "Country_for_Visa");
            addVisaDom.VisaTitle = GetStringFromDataReader(reader, "Visa_title");
            addVisaDom.Form = GetStringFromDataReader(reader, "Form");
            return addVisaDom;


        }


        private VisaForm VaccinationFromDataReader(IDataReader reader)
        {
            VisaForm addVisaDom = new VisaForm();
            addVisaDom.Id = GetIntegerFromDataReader(reader, "Id");
            addVisaDom.VisaTitle = GetStringFromDataReader(reader, "Visa_title");
            addVisaDom.Form = GetStringFromDataReader(reader, "Path");
            return addVisaDom;
        }
        public List<VisaForm> ReadMumbaiForm()
        {
            List<VisaForm> adlst = new List<VisaForm>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.SELECT_MUMBAI);
            VisaForm addVisaDom = new VisaForm();
            IDataReader reader = myDataBase.ExecuteReader(dbCommand);
            {
                while (reader.Read())
                {
                    addVisaDom = GeneraterecordFromDataReaderm(reader);
                    adlst.Add(addVisaDom);
                }

                return adlst;
            }
        }
        private VisaForm GeneraterecordFromDataReaderm(IDataReader reader)
        {
            VisaForm addVisaDom = new VisaForm();
            addVisaDom.Id = GetIntegerFromDataReader(reader, "Id");
            addVisaDom.CountryForVisa = GetStringFromDataReader(reader, "Country_for_Visa");
            addVisaDom.VisaTitle = GetStringFromDataReader(reader, "Visa_title");
            addVisaDom.Form = GetStringFromDataReader(reader, "Form");
            return addVisaDom;


        }
        public List<VisaForm> ReadChannaiForm()
        {
            List<VisaForm> adlst = new List<VisaForm>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.SELECT_CHANNAI);
            VisaForm addVisaDom = new VisaForm();
            IDataReader reader = myDataBase.ExecuteReader(dbCommand);
            {
                while (reader.Read())
                {
                    addVisaDom = GeneraterecordFromDataReaderc(reader);
                    adlst.Add(addVisaDom);
                }

                return adlst;
            }
        }
        private VisaForm GeneraterecordFromDataReaderc(IDataReader reader)
        {
            VisaForm addVisaDom = new VisaForm();
            addVisaDom.Id = GetIntegerFromDataReader(reader, "Id");
            addVisaDom.CountryForVisa = GetStringFromDataReader(reader, "Country_for_Visa");
            addVisaDom.VisaTitle = GetStringFromDataReader(reader, "Visa_title");
            addVisaDom.Form = GetStringFromDataReader(reader, "Form");
            return addVisaDom;


        }
        public List<VisaForm> ReadBangaloreForm()
        {
            List<VisaForm> adlst = new List<VisaForm>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.SELECT_BANGALORE);
            VisaForm addVisaDom = new VisaForm();
            IDataReader reader = myDataBase.ExecuteReader(dbCommand);
            {
                while (reader.Read())
                {
                    addVisaDom = GeneraterecordFromDataReaderb(reader);
                    adlst.Add(addVisaDom);
                }

                return adlst;
            }
        }
        private VisaForm GeneraterecordFromDataReaderb(IDataReader reader)
        {
            VisaForm addVisaDom = new VisaForm();
            addVisaDom.Id = GetIntegerFromDataReader(reader, "Id");
            addVisaDom.CountryForVisa = GetStringFromDataReader(reader, "Country_for_Visa");
            addVisaDom.VisaTitle = GetStringFromDataReader(reader, "Visa_title");
            addVisaDom.Form = GetStringFromDataReader(reader, "Form");

            return addVisaDom;


        }
        public List<VisaForm> ReadForm(string str, string strCity)
        {
            List<VisaForm> adlst = new List<VisaForm>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.SELECT_BY_FILTER);
            myDataBase.AddInParameter(dbCommand, "@Visa_City", DbType.String, strCity);
            myDataBase.AddInParameter(dbCommand, "@Country_for_Visa", DbType.String, str);

            VisaForm addVisaDom = new VisaForm();
            IDataReader reader = myDataBase.ExecuteReader(dbCommand);
            {
                while (reader.Read())
                {
                    addVisaDom = GeneraterecordFromDataReadercharecter(reader);
                    adlst.Add(addVisaDom);
                }

                return adlst;
            }
        }
        private VisaForm GeneraterecordFromDataReadercharecter(IDataReader reader)
        {
            VisaForm addVisaDom = new VisaForm();
            addVisaDom.Id = GetIntegerFromDataReader(reader, "Id");
            addVisaDom.CountryForVisa = GetStringFromDataReader(reader, "Country_for_Visa");
            addVisaDom.VisaTitle = GetStringFromDataReader(reader, "Visa_title");
            addVisaDom.Form = GetStringFromDataReader(reader, "Form");

            return addVisaDom;


        }

        public List<VisaForm> ReadVisaForm()
        {
            List<VisaForm> adlst = new List<VisaForm>();
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("select * from visa_form where isdeleted=0 order by visa_title ASC");
            IDataReader reader = myDataBase.ExecuteReader(dbCommand);
            {
                while (reader.Read())
                {
                    VisaForm addVisaDom = new VisaForm();
                    addVisaDom.Id = GetIntegerFromDataReader(reader, "Id");
                    addVisaDom.CountryForVisa = GetStringFromDataReader(reader, "Country_for_Visa");
                    addVisaDom.VisaTitle = GetStringFromDataReader(reader, "Visa_title");
                    addVisaDom.Form = GetStringFromDataReader(reader, "Form");
                    adlst.Add(addVisaDom);
                }

                return adlst;
            }
        }
        public List<VisaForm> ReadVisarecord(String name)
        {
            List<VisaForm> adlst = new List<VisaForm>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.SEARCH_VISA_FORM);

            myDataBase.AddInParameter(dbCommand, "Visa_City", DbType.String, name);
            VisaForm addVisaDom = new VisaForm();
            IDataReader reader = myDataBase.ExecuteReader(dbCommand);
            {
                while (reader.Read())
                {
                    addVisaDom = GeneraterecordFromDataReaderread(reader);
                    adlst.Add(addVisaDom);
                }

                return adlst;
            }
        }
        private VisaForm GeneraterecordFromDataReaderread(IDataReader reader)
        {
            VisaForm addVisaDom = new VisaForm();
            addVisaDom.Id = GetIntegerFromDataReader(reader, "Id");
            addVisaDom.VisaCity = GetStringFromDataReader(reader, "visa_City");
            addVisaDom.CountryForVisa = GetStringFromDataReader(reader, "Country_for_Visa");
            addVisaDom.VisaTitle = GetStringFromDataReader(reader, "visa_title");
            addVisaDom.Form = GetStringFromDataReader(reader, "Form");
            return addVisaDom;
        }
        public void deleterecord(int Id)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.DELETE_VISA_FORM);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@Id", DbType.Int32, Id);
            myDataBase.ExecuteNonQuery(dbCommand);
        }

        public void deleteSchnegenRecord(string title, string countryName)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.DELETE_SCHNEGEN_VISA_FORM);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@in_title", DbType.String, title);
            myDataBase.AddInParameter(dbCommand, "@in_Country", DbType.String, countryName);
            myDataBase.ExecuteNonQuery(dbCommand);
        }



        public List<VisaForm> ReadVisaFormByCountry(string countryName, string consulate)
        {
            List<VisaForm> lstVisaForm = new List<VisaForm>();

            DbCommand dbCommand = myDataBase.GetStoredProcCommand("procReadVisaFormByCountry");
            myDataBase.AddInParameter(dbCommand, "@inCountry", DbType.String, countryName);
            if (!String.IsNullOrEmpty(consulate))
            {
                myDataBase.AddInParameter(dbCommand, "@inConsulate", DbType.String, consulate);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@inConsulate", DbType.String, DBNull.Value);
            }

            IDataReader reader = myDataBase.ExecuteReader(dbCommand);
            {
                while (reader.Read())
                {
                    VisaForm addVisaDom = new VisaForm();
                    //addVisaDom.Id = GetIntegerFromDataReader(reader, "Id");
                    //addVisaDom.CountryForVisa = GetStringFromDataReader(reader, "Country_for_Visa");
                    addVisaDom.Id = GetIntegerFromDataReader(reader, "Id");
                    addVisaDom.Form = GetStringFromDataReader(reader, "Form");
                    addVisaDom.VisaCity = GetStringFromDataReader(reader, "Visa_City");
                    addVisaDom.CountryForVisa = GetStringFromDataReader(reader, "Country_for_Visa");
                    addVisaDom.VisaTitle = GetStringFromDataReader(reader, "Visa_title");
                    lstVisaForm.Add(addVisaDom);
                }

                return lstVisaForm;
            }

        }
    }
}
