using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Remielsoft.JetSave.DataAccessLayer
{
    public class HolidayDataAccess : BaseDataAccess
    {
        private Database myDataBase;
        public HolidayDataAccess(Database m_database)
        {
            myDataBase = m_database;
        }

        #region Country Holiday Insert

        public void Insert(Holiday holiday)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.INSERT_HOLIDAY);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@HOLI_PURPOSE", DbType.String, holiday.HoliPurpose);
            myDataBase.AddInParameter(dbCommand, "@HOLI_MONTH", DbType.String, holiday.HoliMonth);
            myDataBase.AddInParameter(dbCommand, "@LOCATION_ID", DbType.String, holiday.HoliLocation);
            myDataBase.AddInParameter(dbCommand, "@HOLI_DETAIL", DbType.String, holiday.HoliDetails);
            myDataBase.AddInParameter(dbCommand, "@HOLI_NOTES", DbType.String, holiday.HoliNotes);
            myDataBase.ExecuteNonQuery(dbCommand);
        }

        #endregion


        #region Country Holiday Insert New
        public void InsertHoliday(Holiday holiday)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.CREATE_HOLIDAY);
            myDataBase.AddInParameter(dbCommand, "@in_CountryID", DbType.String, holiday.Country_Name);
            myDataBase.AddInParameter(dbCommand, "@in_HolidayDate", DbType.String, holiday.Holiday_Date);
            myDataBase.AddInParameter(dbCommand, "@in_NameofHoliday", DbType.String, holiday.Holiday_Name);
            myDataBase.AddInParameter(dbCommand, "@in_HolidayDetail", DbType.String, holiday.HoliDetails);
            //myDataBase.AddInParameter(dbCommand, "@in_HolidayDay", DbType.String, holiday.Holiday_Day);
            //myDataBase.AddInParameter(dbCommand, "@in_.Created_By", DbType.String, holiday.);
            //myDataBase.AddInParameter(dbCommand, "@in_CreatedDate", DbType.DateTime, holiday.);
            myDataBase.ExecuteNonQuery(dbCommand);
        }
        #endregion

        #region HOliday Read..
        public List<Holiday> ReadHoliday(int? id)
        {
            List<Holiday> lst = new List<Holiday>();
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.READ_HOLIDAYINFO);
            // myDataBase.AddInParameter(dbcommand, "@in_HolidayDate", DbType.String, DBNull.Value);
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    Holiday holidayMaster = new Holiday();
                    holidayMaster.Holiday_Name = GetStringFromDataReader(reader1, "Name_of_the_Holiday");
                    holidayMaster.Holiday_Detail = GetStringFromDataReader(reader1, "Holiday_Detail");
                    holidayMaster.Holiday_Date = GetStringFromDataReader(reader1, "holidaysDate");
                    string countryName = Convert.ToString(reader1["COUNTRY_Id"]);
                    if (countryName == "")
                    {
                        holidayMaster.Country_Name = GetStringFromDataReader(reader1, "Holiday_Detail");
                    }
                    else
                    {
                        holidayMaster.Country_Name = GetStringFromDataReader(reader1, "COUNTRY_Id");
                    }

                    holidayMaster.Holiday_Day = GetStringFromDataReader(reader1, "Days");
                    lst.Add(holidayMaster);

                }
            }
            return lst;
        }
        #endregion

        #region Country Holiday Update Grid

        public void Update(int id, Holiday holiday)
        {
            //Holiday holiday = new Holiday();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_HOLIDAY);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@Holi_id", DbType.Int32, id);
            myDataBase.AddInParameter(dbCommand, "@HOLI_PURPOSE", DbType.String, holiday.HoliPurpose);
            myDataBase.AddInParameter(dbCommand, "@HOLI_MONTH", DbType.String, holiday.HoliMonth);
            myDataBase.AddInParameter(dbCommand, "@LOCATION_ID", DbType.String, holiday.HoliLocation);
            myDataBase.AddInParameter(dbCommand, "@HOLI_DETAIL", DbType.String, holiday.HoliDetails);
            myDataBase.AddInParameter(dbCommand, "@HOLI_NOTES", DbType.String, holiday.HoliNotes);
            myDataBase.ExecuteNonQuery(dbCommand);
        }
        #endregion


        #region HolidayList Bind Gridview HolidayDetail

        public List<Holiday> BindGridview(string location, string rbtType)
        {

            List<Holiday> lst = new List<Holiday>();

            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_HOLIDAY);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@Location", DbType.String, location);
            myDataBase.AddInParameter(dbCommand, "@RadioButton", DbType.String, rbtType);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Holiday holiDay = new Holiday();
                    holiDay.HoliId = GetIntegerFromDataReader(reader, "HOLI_ID");
                    holiDay.HoliMonth = GetStringFromDataReader(reader, "HOLI_MONTH");
                    holiDay.HoliDetails = GetStringFromDataReader(reader, "HOLI_DETAIL");
                    holiDay.HoliNotes = GetStringFromDataReader(reader, "HOLI_NOTES");
                    holiDay.HoliPurpose = GetStringFromDataReader(reader, "HOLI_PURPOSE");
                    lst.Add(holiDay);
                }
            }
            return lst;
        }
        #endregion

        #region HolidayList Edit,Delete,RowCommand

        public List<Holiday> Edit(int id)
        {

            List<Holiday> lst = new List<Holiday>();

            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_HOLIDAY_BY_ID);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@Holi_id", DbType.String, id);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    Holiday holiDay = new Holiday();
                    holiDay.HoliMonth = GetStringFromDataReader(reader, "HOLI_MONTH");
                    holiDay.HoliDetails = GetStringFromDataReader(reader, "HOLI_DETAIL");
                    holiDay.HoliNotes = GetStringFromDataReader(reader, "HOLI_NOTES");
                    holiDay.HoliLocation = GetStringFromDataReader(reader, "LOCATION_ID");
                    holiDay.HoliPurpose = GetStringFromDataReader(reader, "HOLI_PURPOSE");
                    holiDay.HoliId = GetIntegerFromDataReader(reader, "HOLI_ID");
                    holiDay.CityId = GetIntegerFromDataReader(reader, "CityId");
                    if (holiDay.CityId == int.MinValue)
                    {
                        holiDay.CityId = 0;
                    }
                    lst.Add(holiDay);
                }
            }
            return lst;
        }
        #endregion


        #region ReadLoacationMasterId Bind DropDown Location

        public List<LocationMaster> ReadLocationMasterId()
        {
            List<LocationMaster> lstLocation = new List<LocationMaster>();

            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_LOCATION_MASTER_ID);
            dbCommand.CommandType = CommandType.StoredProcedure;
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    LocationMaster locationMaster = new LocationMaster();
                    locationMaster.LocationId = GetIntegerFromDataReader(reader, "Location_MainId");
                    locationMaster.LocationName = GetStringFromDataReader(reader, "Location_Id");
                    lstLocation.Add(locationMaster);
                }
            }
            return lstLocation;
        }
        #endregion

        #region Holiday Record Delete

        public void Delete(int id)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.DELETE_HOLIDAY_RECORD);
            dbCommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbCommand, "@Holi_id", DbType.Int32, id);
            myDataBase.ExecuteNonQuery(dbCommand);

        }
        #endregion

        ////////////////////////////////////

        ////////////////////////////////////

        #region CountryBind For Hoiday
        public List<Holiday> HolidayCountryBind()
        {
            List<Holiday> lst = new List<Holiday>();

            // DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.LIST_AGENT); SELECT distinct COUNTRY.COUNTRY_NAME,country.COUNTRY_ID FROM  EMB_MASTER INNER JOIN   COUNTRY ON EMB_MASTER.EMBS_COUNTRY_ID = COUNTRY.COUNTRY_ID order by COUNTRY.COUNTRY_NAME asc"
            DbCommand dbcommand = myDataBase.GetSqlStringCommand("Select COUNTRY_ID,COUNTRY_NAME from Country Where IsDeleted=0 order by Country_Name");
            // DbCommand dbcommand = myDataBase.GetSqlStringCommand("SELECT distinct COUNTRY.Country_name,country.country_id FROM  EMB_MASTER INNER JOIN   COUNTRY ON EMB_MASTER.EMBS_COUNTRY_ID = COUNTRY.COUNTRY_ID order by COUNTRY.COUNTRY_NAME asc");
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    Holiday holidayMaster = new Holiday();
                    // holidayMaster.Country_Id = GetStringFromDataReader(reader1, "Country_id");
                    holidayMaster.Country_Name = GetStringFromDataReader(reader1, "Country_name");
                    lst.Add(holidayMaster);

                }
            }
            return lst;

        }


        public List<Holiday> ReadHolidaysByMonthYear(int year, int month)
        {
            List<Holiday> lstHolidays = new List<Holiday>();
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.READ_HOLIDAY_BY_YEAR_MONTH);
            myDataBase.AddInParameter(dbcommand, "@inYear", DbType.String, year);
            myDataBase.AddInParameter(dbcommand, "@inMonth", DbType.String, month);
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    Holiday holidayMaster = new Holiday();
                    holidayMaster.Holiday_Detail = GetStringFromDataReader(reader1, "Holiday_Detail");
                    holidayMaster.Holiday_Date = GetStringFromDataReader(reader1, "HolidayDate");
                    holidayMaster.Holiday_Name = GetStringFromDataReader(reader1, "Name_of_the_Holiday");
                    holidayMaster.Holiday_Day = GetStringFromDataReader(reader1, "Day");
                    holidayMaster.Country_Name = GetStringFromDataReader(reader1, "COUNTRY_ID");
                    lstHolidays.Add(holidayMaster);
                }
            }
            return lstHolidays;

        }

        #endregion

    }
}
