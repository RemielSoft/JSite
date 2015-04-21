using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.DataAccessLayer;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Remielsoft.JetSave.BusinessAccessLayer
{
    public class HolidayBusinessAccess : BaseBusinessAccess
    {
        private Database myDatabase;
        private HolidayDataAccess holidayDataAccess;

        public HolidayBusinessAccess()
        {
            myDatabase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            holidayDataAccess = new HolidayDataAccess(myDatabase);
        }

        #region Country Holiday Insert

        public void insert_holiday(Holiday holiday)
        {
            holidayDataAccess.Insert(holiday);
        }

        #endregion


        #region Country Holiday Insert New
        public void InsertHolidayAdd(Holiday holiday)
        {
            holidayDataAccess.InsertHoliday(holiday);
        }
        #endregion

        #region Country Holiday Read New
        public List<Holiday> ReadHoliday(int? id)
        {
            List<Holiday> lstHoliday = holidayDataAccess.ReadHoliday(id);
            return lstHoliday;
        }
        #endregion


        #region Country Update Holiday

        public void Update1(int id, Holiday holiday)
        {
            holidayDataAccess.Update(id, holiday);
        }
        #endregion

        #region HolidayList Bind Gridview By Location
        public List<Holiday> BindGridview1(string location, string rbtType)
        {
            List<Holiday> lst = new List<Holiday>();
            lst = holidayDataAccess.BindGridview(location, rbtType);
            return lst;
        }

        #endregion

        #region HolidayList Edit,Delete Rowcommand

        public List<Holiday> Edit1(int id)
        {
            List<Holiday> lst = new List<Holiday>();
            lst = holidayDataAccess.Edit(id);
            return lst;
        }
        #endregion

        #region Bind DropDown Loction

        public List<LocationMaster> BindDdlLocation()
        {
            List<LocationMaster> lst = new List<LocationMaster>();
            lst = holidayDataAccess.ReadLocationMasterId();
            return lst;
        }
        #endregion

        #region Holiday Country Bind...

        public List<Holiday> HolidayCountryBindddl()
        {
            return holidayDataAccess.HolidayCountryBind();
        }
        #endregion

        #region Holiday Record Delete

        public void Delete1(int id)
        {
            holidayDataAccess.Delete(id);
        }

        #endregion


        public List<Holiday> ReadHolidaysByMonthYear(int year, int month)
        {
            List<Holiday> lstHoliday = new List<Holiday>();
            lstHoliday = holidayDataAccess.ReadHolidaysByMonthYear(year, month);
            return lstHoliday;
        }
    }
}
