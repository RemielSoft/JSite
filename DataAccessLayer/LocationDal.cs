using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace Remielsoft.JetSave.DataAccessLayer
{
    public class LocationDal : BaseDataAccess
    {
        private Database myDataBase;
        public LocationDal(Database m_database)
        {
            myDataBase = m_database;
        }
        #region Location Insert
        public void InsertLocation(LocationMaster location)
        {

            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.CREATE_LOCATION);
            myDataBase.AddInParameter(dbCommand, "@in_CityId", DbType.String, location.CityId);
            myDataBase.AddInParameter(dbCommand, "@in_companyName", DbType.String, location.CompanyName);
            myDataBase.AddInParameter(dbCommand, "@in_LocationTitle", DbType.String, location.LocationTitle);
            myDataBase.AddInParameter(dbCommand, "@in_City", DbType.String, location.City);
            myDataBase.AddInParameter(dbCommand, "@in_LocationAddress", DbType.String, location.LocationAddress);
            myDataBase.AddInParameter(dbCommand, "@in_CreatedBy", DbType.String, location.Created_By);
            myDataBase.ExecuteNonQuery(dbCommand);
        }
        #endregion


        #region Country Insert
        public void InsertCountry(LocationMaster location)
        {

            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.CREATE_COUNTRY);
            myDataBase.AddInParameter(dbCommand, "@in_LocationTitle", DbType.String, location.LocationTitle);
            myDataBase.AddInParameter(dbCommand, "@in_Country", DbType.String, location.Country);
            myDataBase.AddInParameter(dbCommand, "@in_CreatedBy", DbType.String, location.Created_By);
            myDataBase.AddInParameter(dbCommand, "@in_CreatedDate", DbType.DateTime, location.Created_Date);
            myDataBase.ExecuteNonQuery(dbCommand);
        }
        #endregion

        #region City Insert
        public void InsertCity(LocationMaster location)
        {

            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.CREATE_CITY);
            myDataBase.AddInParameter(dbCommand, "@in_stateId", DbType.String, location.stateId);
            myDataBase.AddInParameter(dbCommand, "@in_City", DbType.String, location.City);
            myDataBase.AddInParameter(dbCommand, "@in_CreatedBy", DbType.String, location.Created_By);
            myDataBase.AddInParameter(dbCommand, "@in_CreatedDate", DbType.DateTime, location.Created_Date);
            myDataBase.ExecuteNonQuery(dbCommand);
        }
        #endregion

        #region Consulate Master
        public void InsertConsulate(LocationMaster location)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.CREATE_CONSULATE);
           // myDataBase.AddInParameter(dbCommand, "@in_LocationTitle", DbType.String, location.LocationTitle);
            myDataBase.AddInParameter(dbCommand, "@in_City", DbType.String, location.City);
            myDataBase.AddInParameter(dbCommand, "@in_CreatedBy", DbType.String, location.Created_By);
            myDataBase.AddInParameter(dbCommand, "@in_CreatedDate", DbType.DateTime, location.Created_Date);
            myDataBase.ExecuteNonQuery(dbCommand);
        }

        public void DeleteConsulate(int id, String moifiedBy, DateTime modifieddate)
        {
            DbCommand dbcommand = myDataBase.GetSqlStringCommand(DBConstant.DELETE_CONSULATE);
            dbcommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbcommand, "@LocationId", DbType.Int32, id);
            myDataBase.AddInParameter(dbcommand, "@ModifiedBy", DbType.String, moifiedBy);
            myDataBase.AddInParameter(dbcommand, "@ModifiedDate", DbType.DateTime, modifieddate);
            myDataBase.ExecuteNonQuery(dbcommand);
        }
        public void UpdateConsulate(int Id, LocationMaster locationmasterUpdate)
        {
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_CONSULATE);
            dbcommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbcommand, "@in_LocationId", DbType.Int32, Id);
            myDataBase.AddInParameter(dbcommand, "@in_City ", DbType.String, locationmasterUpdate.City);
            myDataBase.AddInParameter(dbcommand, "@in_ModifiedBy", DbType.String, locationmasterUpdate.Modified_By);
            myDataBase.ExecuteNonQuery(dbcommand);
        }
        public List<LocationMaster> ReadConsulate(int? id)
        {
            List<LocationMaster> lst = new List<LocationMaster>();
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.READ_CONSULATE);
            myDataBase.AddInParameter(dbcommand, "@in_CityId", DbType.Int32, id);
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    LocationMaster locationMaster = new LocationMaster();
                    locationMaster.CityId = GetIntegerFromDataReader(reader1, "Consulate_Id");
                    locationMaster.City = GetStringFromDataReader(reader1, "consulate_name");
                    locationMaster.Created_By = GetStringFromDataReader(reader1, "Created_By");
                    locationMaster.Created_Date = GetDateFromReader(reader1, "Created_Date");
                    locationMaster.Modified_By = GetStringFromDataReader(reader1, "Modified_By");
                    locationMaster.Modified_Date = GetDateFromReader(reader1, "Modified_Date");
                    lst.Add(locationMaster);
                }
            }
            return lst;
        }
        #endregion





        #region State Master
        public void InsertState(LocationMaster location)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.CREATE_STATE);
            myDataBase.AddInParameter(dbCommand, "@in_State", DbType.String, location.stateName);
            myDataBase.AddInParameter(dbCommand, "@in_CountryId", DbType.Int32, location.CountryId);
            myDataBase.AddInParameter(dbCommand, "@in_CreatedBy", DbType.String, location.Created_By);
            myDataBase.AddInParameter(dbCommand, "@in_CreatedDate", DbType.DateTime, location.Created_Date);
            myDataBase.ExecuteNonQuery(dbCommand);
        }

        public void DeleteState(int id, String moifiedBy, DateTime modifieddate)
        {
            DbCommand dbcommand = myDataBase.GetSqlStringCommand(DBConstant.DELETE_STATE);
            dbcommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbcommand, "@stateId", DbType.Int32, id);
            myDataBase.AddInParameter(dbcommand, "@ModifiedBy", DbType.String, moifiedBy);
            myDataBase.AddInParameter(dbcommand, "@ModifiedDate", DbType.DateTime, modifieddate);
            myDataBase.ExecuteNonQuery(dbcommand);
        }
        public void UpdateState(int Id, LocationMaster locationmasterUpdate)
        {

            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_STATE);
            dbcommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbcommand, "@in_stateId", DbType.Int32, Id);
            myDataBase.AddInParameter(dbcommand, "@in_countryId ", DbType.Int32, locationmasterUpdate.CountryId);
            myDataBase.AddInParameter(dbcommand, "@in_state", DbType.String, locationmasterUpdate.stateName);
            myDataBase.ExecuteNonQuery(dbcommand);
        }
        public List<LocationMaster> ReadState(int? id)
        {
            List<LocationMaster> lst = new List<LocationMaster>();
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.READ_STATE);
            myDataBase.AddInParameter(dbcommand, "@in_stateId", DbType.Int32, id);
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                { 
                    LocationMaster locationMaster = new LocationMaster();
                    locationMaster.stateId = GetIntegerFromDataReader(reader1, "state_id");
                    locationMaster.CountryId = GetIntegerFromDataReader(reader1, "country_id");
                    locationMaster.Country = GetStringFromDataReader(reader1, "COUNTRY_NAME");
                    locationMaster.stateName = GetStringFromDataReader(reader1, "state_name");
                    locationMaster.Created_By = GetStringFromDataReader(reader1, "Created_By");
                    locationMaster.Created_Date = GetDateFromReader(reader1, "Created_Date");
                    locationMaster.Modified_By = GetStringFromDataReader(reader1, "Modified_By");
                    locationMaster.Modified_Date = GetDateFromReader(reader1, "Modified_Date");
                    lst.Add(locationMaster);
                }
            }
            return lst;
        }

        public List<LocationMaster> ReadStateByCountryID(int id)
        {
            List<LocationMaster> lst = new List<LocationMaster>();
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.READ_STATE_BYCOUNTRYID);
            myDataBase.AddInParameter(dbcommand, "@in_countryId", DbType.Int32, id);
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    LocationMaster locationMaster = new LocationMaster();
                    locationMaster.stateId = GetIntegerFromDataReader(reader1, "state_id");
                    locationMaster.CountryId = GetIntegerFromDataReader(reader1, "country_id");
                    locationMaster.Country = GetStringFromDataReader(reader1, "COUNTRY_NAME");
                    locationMaster.stateName = GetStringFromDataReader(reader1, "state_name");
                    locationMaster.Created_By = GetStringFromDataReader(reader1, "Created_By");
                    locationMaster.Created_Date = GetDateFromReader(reader1, "Created_Date");
                    locationMaster.Modified_By = GetStringFromDataReader(reader1, "Modified_By");
                    locationMaster.Modified_Date = GetDateFromReader(reader1, "Modified_Date");
                    lst.Add(locationMaster);
                }
            }
            return lst;
        }
        #endregion
        #region Location BindGried
        public List<LocationMaster> ReadLocation(int? LocationId)
        {
            List<LocationMaster> lst = new List<LocationMaster>();
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.READ_LOCATION);
            myDataBase.AddInParameter(dbcommand, "@in_LocationId", DbType.Int32, LocationId);
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    LocationMaster locationMaster = new LocationMaster();
                    locationMaster.LocationId = GetIntegerFromDataReader(reader1, "LocationId");
                    locationMaster.CityId = GetIntegerFromDataReader(reader1, "CityId");
                    locationMaster.LocationTitle = GetStringFromDataReader(reader1, "LocationTitle");
                    locationMaster.City = GetStringFromDataReader(reader1, "City");
                    locationMaster.CompanyName = GetStringFromDataReader(reader1, "CompanyName");
                    locationMaster.LocationAddress = GetStringFromDataReader(reader1, "LocationAddress");
                    locationMaster.Created_By = GetStringFromDataReader(reader1, "Created_By");
                    locationMaster.Created_Date = GetDateFromReader(reader1, "Created_Date");
                    locationMaster.Modified_By = GetStringFromDataReader(reader1, "Modified_By");
                    //locationMaster.Modified_Date = GetDateFromReader(reader1, "ModifiedDate");
                    lst.Add(locationMaster);

                }
            }
            return lst;

        }
        #endregion

        #region Country Read..
        public List<LocationMaster> ReadCountry(int? id)
        {
            List<LocationMaster> lst = new List<LocationMaster>();
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.READ_COUNTRYMST);
            myDataBase.AddInParameter(dbcommand, "@in_CountryId", DbType.Int32, id);
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    LocationMaster locationMaster = new LocationMaster();
                    locationMaster.CountryId = GetIntegerFromDataReader(reader1, "CountryId");
                    locationMaster.LocationTitle = GetStringFromDataReader(reader1, "DesCription");
                    locationMaster.Country = GetStringFromDataReader(reader1, "CountryName");
                    locationMaster.Created_By = GetStringFromDataReader(reader1, "Created_By");
                    locationMaster.Created_Date = GetDateFromReader(reader1, "Created_Date");

                    locationMaster.Modified_By = GetStringFromDataReader(reader1, "Modified_By");

                    locationMaster.Modified_Date = GetDateFromReader(reader1, "Modified_Date");
                    lst.Add(locationMaster);

                }
            }
            return lst;
        }
        #endregion


        #region City Read..
        public List<LocationMaster> ReadCity(int? id)
        {
            List<LocationMaster> lst = new List<LocationMaster>();
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.READ_CITY);
            myDataBase.AddInParameter(dbcommand, "@in_CityId", DbType.Int32, id);
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    LocationMaster locationMaster = new LocationMaster();
                    locationMaster.CityId = GetIntegerFromDataReader(reader1, "CityId");
                    locationMaster.LocationTitle = GetStringFromDataReader(reader1, "DesCription");
                    locationMaster.City = GetStringFromDataReader(reader1, "CityName");
                    locationMaster.Country = GetStringFromDataReader(reader1, "COUNTRY_NAME");
                    locationMaster.CountryId = GetIntegerFromDataReader(reader1, "COUNTRY_ID");
                    locationMaster.stateName = GetStringFromDataReader(reader1, "state_name");
                    locationMaster.stateId = GetIntegerFromDataReader(reader1, "state_id");
                    locationMaster.Created_By = GetStringFromDataReader(reader1, "Created_By");
                    locationMaster.Created_Date = GetDateFromReader(reader1, "Created_Date");
                    locationMaster.Modified_By = GetStringFromDataReader(reader1, "Modified_By");
                    locationMaster.Modified_Date = GetDateFromReader(reader1, "Modified_Date");
                    lst.Add(locationMaster);

                }
            }
            return lst;
        }
        #endregion



        #region Location Edit
        public List<LocationMaster> ReadLocationbyId(int LocationId)
        {
            List<LocationMaster> listread = new List<LocationMaster>();
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.READ_LOCATION);
            // DbCommand dbcommand = myDataBase.GetSqlStringCommand("select * from Location where LocationId='" + LocationId + "' ");
            myDataBase.AddInParameter(dbcommand, "@in_LocationId", DbType.Int32, LocationId);
            using (IDataReader reader2 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader2.Read())
                {
                    LocationMaster Readob = new LocationMaster();
                    Readob.LocationId = GetIntegerFromDataReader(reader2, "LocationId");
                    Readob.CityId = GetIntegerFromDataReader(reader2, "CityId");
                    Readob.CompanyName = GetStringFromDataReader(reader2, "CompanyName");
                    Readob.City = GetStringFromDataReader(reader2, "City");
                    Readob.LocationTitle = GetStringFromDataReader(reader2, "LocationTitle");
                    Readob.LocationAddress = GetStringFromDataReader(reader2, "LocationAddress");
                    Readob.Created_By = GetStringFromDataReader(reader2, "Created_By");
                    Readob.Created_Date = GetDateFromReader(reader2, "Created_Date");
                    Readob.Modified_By = GetStringFromDataReader(reader2, "Modified_By");
                    //Readob.Modified_Date = GetDateFromReader(reader2, "ModifiedDate");

                    listread.Add(Readob);
                }
            }
            return listread;
        }
        #endregion


        #region Location Update
        public void Update(int Id, LocationMaster locationmasterUpdate)
        {

            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_LOCATION);
            dbcommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbcommand, "@in_LocationId", DbType.Int32, Id);
            myDataBase.AddInParameter(dbcommand, "@in_CityId", DbType.Int32, locationmasterUpdate.CityId);
            myDataBase.AddInParameter(dbcommand, "@in_CompanyName", DbType.String, locationmasterUpdate.CompanyName);
            myDataBase.AddInParameter(dbcommand, "@in_LocationTitle", DbType.String, locationmasterUpdate.LocationTitle);
            myDataBase.AddInParameter(dbcommand, "@in_City ", DbType.String, locationmasterUpdate.City);
            myDataBase.AddInParameter(dbcommand, "@in_LocationAddress", DbType.String, locationmasterUpdate.LocationAddress);
            myDataBase.AddInParameter(dbcommand, "@in_ModifiedBy", DbType.String, locationmasterUpdate.Modified_By);
            myDataBase.AddInParameter(dbcommand, "@in_ModifieDate", DbType.DateTime, locationmasterUpdate.Modified_Date);
            myDataBase.ExecuteNonQuery(dbcommand);

        }
        #endregion

        #region Country Update
        public void UpdateCountry(int Id, LocationMaster locationmasterUpdate)
        {

            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_COUNTRY);
            dbcommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbcommand, "@in_LocationId", DbType.Int32, Id);
            myDataBase.AddInParameter(dbcommand, "@in_LocationTitle", DbType.String, locationmasterUpdate.LocationTitle);
            myDataBase.AddInParameter(dbcommand, "@in_Country ", DbType.String, locationmasterUpdate.Country);
            myDataBase.AddInParameter(dbcommand, "@in_ModifiedBy", DbType.String, locationmasterUpdate.Modified_By);
            myDataBase.AddInParameter(dbcommand, "@in_ModifiedDate", DbType.DateTime, locationmasterUpdate.Modified_Date);
            myDataBase.ExecuteNonQuery(dbcommand);

        }
        #endregion

        #region City Update
        public void UpdateCity(int Id, LocationMaster locationmasterUpdate)
        {

            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_CITY);
            dbcommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbcommand, "@in_LocationId", DbType.Int32, Id);
            myDataBase.AddInParameter(dbcommand, "@in_stateId", DbType.String, locationmasterUpdate.stateId);
            myDataBase.AddInParameter(dbcommand, "@in_City ", DbType.String, locationmasterUpdate.City);
            myDataBase.AddInParameter(dbcommand, "@in_ModifiedBy", DbType.String, locationmasterUpdate.Modified_By);
            myDataBase.AddInParameter(dbcommand, "@in_ModifiedDate", DbType.DateTime, locationmasterUpdate.Modified_Date);
            myDataBase.ExecuteNonQuery(dbcommand);

        }
        #endregion

        #region Location Delete
        public void DeleteLocation(int locationId, String moifiedBy, DateTime modifieddate)
        {


            DbCommand dbcommand = myDataBase.GetSqlStringCommand(DBConstant.DELETE_LOCATION);
            dbcommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbcommand, "@LocationId", DbType.Int32, locationId);
            myDataBase.AddInParameter(dbcommand, "@ModifiedBy", DbType.String, moifiedBy);
            myDataBase.AddInParameter(dbcommand, "@ModifiedDate", DbType.DateTime, modifieddate);
            myDataBase.ExecuteNonQuery(dbcommand);
        }

        #endregion

        #region Country Delete
        public void DeleteCountry(int locationId, String moifiedBy, DateTime modifieddate)
        {


            DbCommand dbcommand = myDataBase.GetSqlStringCommand(DBConstant.DELETE_COUNTRY);
            dbcommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbcommand, "@LocationId", DbType.Int32, locationId);
            myDataBase.AddInParameter(dbcommand, "@ModifiedBy", DbType.String, moifiedBy);
            myDataBase.AddInParameter(dbcommand, "@ModifiedDate", DbType.DateTime, modifieddate);
            myDataBase.ExecuteNonQuery(dbcommand);
        }

        #endregion


        #region City Delete
        public void DeleteCity(int locationId, String moifiedBy, DateTime modifieddate)
        {


            DbCommand dbcommand = myDataBase.GetSqlStringCommand(DBConstant.DELETE_CITY);
            dbcommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbcommand, "@LocationId", DbType.Int32, locationId);
            myDataBase.AddInParameter(dbcommand, "@ModifiedBy", DbType.String, moifiedBy);
            myDataBase.AddInParameter(dbcommand, "@ModifiedDate", DbType.DateTime, modifieddate);
            myDataBase.ExecuteNonQuery(dbcommand);
        }

        #endregion

        #region Search By City
        public List<LocationMaster> Search(string city)
        {
            List<LocationMaster> lstsearch = new List<LocationMaster>();
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.SEARCH_LOCATION);
            // DbCommand dbcommand = myDataBase.GetSqlStringCommand("select * from Location  where City ='" + city + "'");
            myDataBase.AddInParameter(dbcommand, "@city", DbType.String, city);

            using (IDataReader readersearch = myDataBase.ExecuteReader(dbcommand))
            {
                while (readersearch.Read())
                {
                    LocationMaster locationMaster = new LocationMaster();
                    locationMaster.LocationId = GetIntegerFromDataReader(readersearch, "LocationId");
                    locationMaster.CityId = GetIntegerFromDataReader(readersearch, "CityId");
                    locationMaster.LocationTitle = GetStringFromDataReader(readersearch, "LocationTitle");
                    locationMaster.City = GetStringFromDataReader(readersearch, "City");
                    locationMaster.CompanyName = GetStringFromDataReader(readersearch, "CompanyName");
                    locationMaster.LocationAddress = GetStringFromDataReader(readersearch, "LocationAddress");
                    locationMaster.Created_By = GetStringFromDataReader(readersearch, "Created_By");
                    locationMaster.Created_Date = GetDateFromReader(readersearch, "Created_Date");
                    locationMaster.Modified_By = GetStringFromDataReader(readersearch, "Modified_By");
                    //locationMaster.Modified_Date = GetDateFromReader(reader1, "ModifiedDate");
                    lstsearch.Add(locationMaster);

                }
            }
            return lstsearch;


        }
        #endregion

        #region CountryBind
        public List<LocationMaster> Readcountry()
        {
            List<LocationMaster> lst = new List<LocationMaster>();

            // DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.LIST_AGENT);
            DbCommand dbcommand = myDataBase.GetSqlStringCommand("select CountryId,Country from Country");
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    LocationMaster locationMaster = new LocationMaster();
                    locationMaster.CountryId = GetIntegerFromDataReader(reader1, "CountryId");
                    locationMaster.Country = GetStringFromDataReader(reader1, "Country");
                    lst.Add(locationMaster);

                }
            }
            return lst;

        }
        #endregion

        #region CityBind
        public List<LocationMaster> Readcity()
        {
            List<LocationMaster> lst = new List<LocationMaster>();

            // DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.LIST_AGENT);
            DbCommand dbcommand = myDataBase.GetSqlStringCommand("select Id,City from Bill_EmailId");
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    LocationMaster locationMaster = new LocationMaster();
                    locationMaster.CityId = GetIntegerFromDataReader(reader1, "Id");
                    locationMaster.City = GetStringFromDataReader(reader1, "City");
                    lst.Add(locationMaster);

                }
            }
            return lst;

        }
        #endregion


        //public List<LocationMaster> ReadLocationMasterId()
        //{
        //    List<LocationMaster> lstLocation = new List<LocationMaster>();
        //    LocationMaster locationMaster = new LocationMaster();
        //    DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_LOCATION_MASTER_ID);
        //    dbCommand.CommandType = CommandType.StoredProcedure;
        //    using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
        //    {
        //        while (reader.Read())
        //        {
        //            locationMaster.LocationId = GetIntegerFromDataReader(reader, "Location_MainId");
        //            locationMaster.LocationName = GetStringFromDataReader(reader, "Location_Id");
        //            lstLocation.Add(locationMaster);
        //        }
        //    }
        //    return lstLocation;

        //}
        //private LocationMaster LocationFromDataReader(IDataReader reader)
        //{
        //    LocationMaster loc = new LocationMaster();

        //    loc.Location_Name = GetStringFromDataReader(reader, "Location_Name");
        //    loc.Location_Id = GetIntegerFromDataReader(reader, "Location_Id");

        //    return loc;
        //}

    }
}
