using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DataAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Remielsoft.JetSave.BusinessAccessLayer
{
    public class LocationBusinessAccess : BaseBusinessAccess
    {
        private Database myDataBase;
        private LocationDal locationdal;
        public LocationBusinessAccess()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            locationdal = new LocationDal(myDataBase);
        }
        #region Location insert
        public void insertLocation(LocationMaster location)
        {
            locationdal.InsertLocation(location);
        }
        #endregion

        #region Country insert
        public void insertCountry(LocationMaster location)
        {
            locationdal.InsertCountry(location);
        }
        #endregion


        #region City insert
        public void insertCity(LocationMaster location)
        {
            locationdal.InsertCity(location);
        }
        #endregion

        #region Location Bind

        public List<LocationMaster> ReadLocation(int? LocationId)
        {
            return locationdal.ReadLocation(LocationId);
        }
        #endregion

        #region Country Read..

        public List<LocationMaster> ReadCountry(int? id)
        {
            return locationdal.ReadCountry(id);
        }
        #endregion

        #region City Read..

        public List<LocationMaster> ReadCity(int? id)
        {
            return locationdal.ReadCity(id);
        }
        #endregion

        #region location Edit
        public List<LocationMaster> ReadLocationbyID(int LocationId)
        {
            return locationdal.ReadLocationbyId(LocationId);
        }
        #endregion


        #region Location Update
        public void LocationUpdate(int Id, LocationMaster locationmasterUpdate)
        {
            locationdal.Update(Id, locationmasterUpdate);
        }
        #endregion

        #region Country Update
        public void CountryUpdate(int Id, LocationMaster locationmasterUpdate)
        {
            locationdal.UpdateCountry(Id, locationmasterUpdate);
        }
        #endregion

        #region City Update
        public void CityUpdate(int Id, LocationMaster locationmasterUpdate)
        {
            locationdal.UpdateCity(Id, locationmasterUpdate);
        }
        #endregion

        #region Consulate CRUD
        public void UpdateConsulate(int Id, LocationMaster locationmasterUpdate)
        {
            locationdal.UpdateConsulate(Id, locationmasterUpdate);
        }
        public List<LocationMaster> ReadConsulate(int? id)
        {
            return locationdal.ReadConsulate(id);
        }
        public void insertConsulate(LocationMaster location)
        {
            locationdal.InsertConsulate(location);
        }
        public void DeleteConsulate(int Id, String moifiedBy, DateTime modifieddate)
        {
            locationdal.DeleteConsulate(Id, moifiedBy, modifieddate);
        }
        #endregion



        #region State CRUD
        public void UpdateState(int Id, LocationMaster locationmasterUpdate)
        {
            locationdal.UpdateState(Id, locationmasterUpdate);
        }
        public List<LocationMaster> ReadState(int? id)
        {
            return locationdal.ReadState(id);
        }
        public List<LocationMaster> ReadStateByCountryID(int id)
        {
            return locationdal.ReadStateByCountryID(id);
        }
        public void insertState(LocationMaster location)
        {
            locationdal.InsertState(location);
        }
        public void DeleteState(int Id, String moifiedBy, DateTime modifieddate)
        {
            locationdal.DeleteState(Id, moifiedBy, modifieddate);
        }
        #endregion



        #region location Delete
        public void DeleteLocation(int locationId, String moifiedBy, DateTime modifieddate)
        {
            locationdal.DeleteLocation(locationId, moifiedBy, modifieddate);
        }
        #endregion

        #region Country Delete
        public void DeleteCountry(int locationId, String moifiedBy, DateTime modifieddate)
        {
            locationdal.DeleteCountry(locationId, moifiedBy, modifieddate);
        }
        #endregion

        #region City Delete
        public void DeleteCity(int locationId, String moifiedBy, DateTime modifieddate)
        {
            locationdal.DeleteCity(locationId, moifiedBy, modifieddate);
        }
        #endregion
        #region search

        public List<LocationMaster> searchCity(string City)
        {
            return locationdal.Search(City);
        }
        #endregion
        public List<LocationMaster> Readcityddl()
        {
            return locationdal.Readcity();
        }

    }
}
