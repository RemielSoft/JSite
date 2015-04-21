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
    public class AdvanceSearchDataAccess : BaseDataAccess
    {
        private Database myDataBase;
        public AdvanceSearchDataAccess(Database m_database)
        {
            myDataBase = m_database;
        }

        #region BindDropDown..

        public List<AdvanceSearchDom> ReadAgentNameList()
        {

            List<AdvanceSearchDom> lstDom = new List<AdvanceSearchDom>();

            //DbCommand dbCommand = myDataBase.GetSqlStringCommand("select AGENT_ID, AGENT_NAME from AGENT");
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.LIST_AGENT);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    AdvanceSearchDom advanceDom = new AdvanceSearchDom();
                    advanceDom.AgentId = GetIntegerFromDataReader(reader, "AGENT_ID");
                    advanceDom.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
                    lstDom.Add(advanceDom);
                }
                return lstDom;
            }
        }

        public List<AdvanceSearchDom> ReadCountryNameList()
        {

            List<AdvanceSearchDom> lstDom = new List<AdvanceSearchDom>();

            DbCommand dbCommand = myDataBase.GetSqlStringCommand("select COUNTRY_ID, COUNTRY_NAME from COUNTRY order by (COUNTRY_NAME) asc");

            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    AdvanceSearchDom advanceDom = new AdvanceSearchDom();
                    advanceDom.CountryId = GetIntegerFromDataReader(reader, "COUNTRY_ID");
                    advanceDom.CountryName = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    lstDom.Add(advanceDom);
                }
                return lstDom;
            }
        }
        public List<AdvanceSearchDom> ReadAreaCodeList()
        {

            List<AdvanceSearchDom> lstDom = new List<AdvanceSearchDom>();

            DbCommand dbCommand = myDataBase.GetSqlStringCommand("select isnull(CONSIGNMENT.CG_AREACODE,0) as AreaCode from CONSIGNMENT");

            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    AdvanceSearchDom advanceDom = new AdvanceSearchDom();
                    advanceDom.AreaCode = GetStringFromDataReader(reader, "AreaCode");
                    lstDom.Add(advanceDom);
                }
                return lstDom;
            }
        }

        #endregion

        #region ReadAdvanceSearchFun..

        public List<AdvanceSearchDom> ReadAdvanceSearch(int conId, int agentId, int countryId, string agentName, string countryName,  DateTime? fromDate, DateTime? toDate, int? LocId)
        {
            List<AdvanceSearchDom> lstdom = new List<AdvanceSearchDom>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_ADVANCE_SEARCH);
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            if (conId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@in_cong_Id", DbType.Int32, conId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@in_cong_Id", DbType.Int32, DBNull.Value);
            }

            if (agentId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@in_agent_Id", DbType.Int32, agentId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@in_agent_Id", DbType.Int32, DBNull.Value);
            }

            if (countryId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@in_country_Id", DbType.Int32, countryId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@in_country_Id", DbType.Int32, DBNull.Value);
            }

            if (agentName != null)
            {
                myDataBase.AddInParameter(dbCommand, "@in_agent_name", DbType.String, agentName);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@in_agent_name", DbType.String, DBNull.Value);
            }

            if (countryName != null)
            {
                myDataBase.AddInParameter(dbCommand, "@in_country_name", DbType.String, countryName);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@in_country_name", DbType.String, DBNull.Value);
            }
          

            if (fromDate != DateTime.MinValue)
            {
                myDataBase.AddInParameter(dbCommand, "@in_from_date", DbType.DateTime, fromDate);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@in_from_date", DbType.DateTime, DBNull.Value);
            }

            if (toDate != DateTime.MinValue)
            {
                myDataBase.AddInParameter(dbCommand, "@in_to_date", DbType.DateTime, toDate);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@in_to_date", DbType.DateTime, DBNull.Value);
            }

            dbCommand.CommandTimeout = 1200;
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    AdvanceSearchDom advanceSearchDom = new AdvanceSearchDom();
                    advanceSearchDom.ConsignmentId = GetIntegerFromDataReader(reader, "ConsignmentId");
                    advanceSearchDom.AgentId = GetIntegerFromDataReader(reader, "AgentId");
                    advanceSearchDom.CountryId = GetIntegerFromDataReader(reader, "CountryId");
                    
                    advanceSearchDom.AgentName = GetStringFromDataReader(reader, "AgentName");
                    advanceSearchDom.VisaCountry = GetStringFromDataReader(reader, "VisaCountry");

                  //  advanceSearchDom.PaxName = GetStringFromDataReader(reader, "PaxName");
                   // advanceSearchDom.PPTNo = GetStringFromDataReader(reader, "PPTNo");

                    advanceSearchDom.AreaCode = GetStringFromDataReader(reader, "AreaCode");

                    advanceSearchDom.SubmissionDate = GetDateFromReader(reader, "SubDate");
                    advanceSearchDom.DeliveryDate = GetDateFromReader(reader, "DeliveryDate");

                    advanceSearchDom.DeliveryStatus = GetStringFromDataReader(reader, "DeliveryStatus");

                    advanceSearchDom.ToDate = GetDateFromReader(reader, "DeliveryDate");
                    advanceSearchDom.FromDate = GetDateFromReader(reader, "DeliveryDate");

                    advanceSearchDom.TotalVisa = GetIntegerFromDataReader(reader, "TotalPassport");
                    lstdom.Add(advanceSearchDom);
                }

            }
            return lstdom;
        }

        #endregion
    }

}
   

