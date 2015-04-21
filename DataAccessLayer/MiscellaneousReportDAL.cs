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
    public class MiscellaneousReportDAL : BaseDataAccess
    {
        private Database myDataBase;
        public MiscellaneousReportDAL(Database m_database)
        {
            myDataBase = m_database;
        }

        public List<MiscellaneousReportDOM> ReadAgentName()
        {
            List<MiscellaneousReportDOM> lstAgentName = new List<MiscellaneousReportDOM>();
            DbCommand dbcommand = myDataBase.GetSqlStringCommand("select * from AGENT order by AGENT_NAME asc ");
            using (IDataReader reader = myDataBase.ExecuteReader(dbcommand))
            {

                while (reader.Read())
                {
                    MiscellaneousReportDOM agentName = new MiscellaneousReportDOM();
                    agentName.AgentId = GetIntegerFromDataReader(reader, "AGENT_ID");
                    agentName.AgentName = GetStringFromDataReader(reader, "AGENT_NAME");
                    lstAgentName.Add(agentName);
                }
            }
            return lstAgentName;
        }

        public List<MiscellaneousReportDOM> ReadCountryName()
        {
            List<MiscellaneousReportDOM> lstcountryname = new List<MiscellaneousReportDOM>();
            DbCommand dbcommand = myDataBase.GetSqlStringCommand("select * from COUNTRY order by COUNTRY_NAME asc ");
            using (IDataReader reader = myDataBase.ExecuteReader(dbcommand))
            {

                while (reader.Read())
                {
                    MiscellaneousReportDOM miscelCountryName = new MiscellaneousReportDOM();
                    miscelCountryName.CountryId = GetIntegerFromDataReader(reader, "COUNTRY_ID");
                    miscelCountryName.CountryName = GetStringFromDataReader(reader, "COUNTRY_NAME");
                    lstcountryname.Add(miscelCountryName);
                }
            }
            return lstcountryname;

        }
      

        public List<MiscellaneousReportDOM> ReadMiscellaneousReport(DateTime? fromDate, DateTime? toDate, string agentName, string countryName, int? LocId)
        {
            List<MiscellaneousReportDOM> lstMisceReportCountry = new List<MiscellaneousReportDOM>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_MISCELLANEOUS_REPORT);
            if (fromDate == DateTime.MinValue)
            {
                myDataBase.AddInParameter(dbCommand, "@in_from_date",DbType.DateTime,DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@in_from_date", DbType.DateTime, fromDate);
            }

            if (toDate == DateTime.MinValue)
            {
                myDataBase.AddInParameter(dbCommand, "@in_to_date", DbType.DateTime, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@in_to_date", DbType.DateTime, toDate);
            }
            if (agentName!=null)
            {
                myDataBase.AddInParameter(dbCommand, "@in_agent_name", DbType.String,agentName);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@in_agent_name", DbType.String, DBNull.Value);
            }
            if (countryName!=null)
            {
                myDataBase.AddInParameter(dbCommand, "@in_country_name", DbType.String, countryName);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@in_country_name", DbType.String, DBNull.Value);
            }
            
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            dbCommand.CommandTimeout = 1200;
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    MiscellaneousReportDOM mislaniousReportDom = new MiscellaneousReportDOM();
                   // mislaniousReportDom.BillDate = GetDateFromReader(reader, "BillDate");
                    //mislaniousReportDom.ToDate = GetDateFromReader(reader, "BillDate");
                    mislaniousReportDom.AgentName = GetStringFromDataReader(reader, "AgentName");
                    //mislaniousReportDom.EmailId = GetStringFromDataReader(reader, "EmailId");
                    //mislaniousReportDom.City = GetStringFromDataReader(reader, "CityName");
                    mislaniousReportDom.CountryName = GetStringFromDataReader(reader, "CountryName");
                    mislaniousReportDom.TotalAmount = GetDecimalFromDataReader(reader, "TotalAmount");
                    mislaniousReportDom.ServiceCharge = GetDecimalFromDataReader(reader, "ServiceCharge");
                    mislaniousReportDom.ServiceTax = GetDecimalFromDataReader(reader, "ServiceTax");
                    lstMisceReportCountry.Add(mislaniousReportDom);
                }
            }
            return lstMisceReportCountry;
        }

        public List<MiscellaneousReportDOM> ReadMiscellReportByAgent(string agentName, int? LocId)
        {
            List<MiscellaneousReportDOM> lstMisceReportCountry = new List<MiscellaneousReportDOM>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_MISCELLREPORTBYAGENT);
            if (agentName != null)
            {
                myDataBase.AddInParameter(dbCommand, "@in_agent_name", DbType.String, agentName);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@in_agent_name", DbType.String, DBNull.Value);
            }
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
             using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    MiscellaneousReportDOM mislaniousReportDom = new MiscellaneousReportDOM();
                    mislaniousReportDom.AgentName = GetStringFromDataReader(reader, "AgentName");
                    mislaniousReportDom.TotalAmount = GetDecimalFromDataReader(reader, "TotalAmount");
                    mislaniousReportDom.ServiceCharge = GetDecimalFromDataReader(reader, "ServiceCharge");
                    mislaniousReportDom.ServiceTax = GetDecimalFromDataReader(reader, "ServiceTax");
                    lstMisceReportCountry.Add(mislaniousReportDom);
                }
            }
             return lstMisceReportCountry;
        }

        public List<MiscellaneousReportDOM> ReadMiscellReportByCountry(string countryName, int? LocId)
        {
            List<MiscellaneousReportDOM> lstMisceReportCountry = new List<MiscellaneousReportDOM>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_MISCLLREPORTBYCOUNTRY);
            if (countryName != null)
            {
                myDataBase.AddInParameter(dbCommand, "@in_country_name", DbType.String, countryName);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@in_country_name", DbType.String, DBNull.Value);
            }
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    MiscellaneousReportDOM mislaniousReportDom = new MiscellaneousReportDOM();
                    mislaniousReportDom.CountryName = GetStringFromDataReader(reader, "CountryName");
                    mislaniousReportDom.TotalAmount = GetDecimalFromDataReader(reader, "TotalAmount");
                    mislaniousReportDom.ServiceCharge = GetDecimalFromDataReader(reader, "ServiceCharge");
                    mislaniousReportDom.ServiceTax = GetDecimalFromDataReader(reader, "ServiceTax");
                    lstMisceReportCountry.Add(mislaniousReportDom);
                }
            }
            return lstMisceReportCountry;
        }

        public List<MiscellaneousReportDOM> ReadMiscellaneousReportByConsolidated(DateTime? fromDate,DateTime? toDate,string countryName, int? LocId)
        {
            List<MiscellaneousReportDOM> lstMcsedom = new List<MiscellaneousReportDOM>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_MISCLLREPORT_CONSOLIDATED);

            if (fromDate == DateTime.MinValue)
            {
                myDataBase.AddInParameter(dbCommand, "@in_from_Date", DbType.DateTime, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@in_from_Date", DbType.DateTime, fromDate);
            }
            if (toDate == DateTime.MinValue)
            {
                myDataBase.AddInParameter(dbCommand, "@in_to_Date", DbType.DateTime, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@in_to_Date", DbType.DateTime, toDate);
            }

            if (countryName != null)
            {
                myDataBase.AddInParameter(dbCommand, "@in_country_name", DbType.String, countryName);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@in_country_name", DbType.String, DBNull.Value);
            }
            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@LocationId", DbType.Int32, DBNull.Value);
            }

            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    MiscellaneousReportDOM micslaReport = new MiscellaneousReportDOM();
                    micslaReport.CountryName = GetStringFromDataReader(reader, "CountryName");
                    micslaReport.TotalAmount = GetDecimalFromDataReader(reader, "TotalAmount");
                    micslaReport.ServiceCharge = GetDecimalFromDataReader(reader, "ServiceCharge");
                    micslaReport.ServiceTax = GetDecimalFromDataReader(reader, "ServiceTax");
                    lstMcsedom.Add(micslaReport);
                }
                        
            }
            return lstMcsedom;
        }
    }
}
