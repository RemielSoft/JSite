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
    public class MetaDataDal:BaseDataAccess
    {
        private Database myDataBase;
        public MetaDataDal(Database m_database)
        {
            myDataBase = m_database;
        }

        public List<MetaData> ReadMetaDataUserType()
        {
            List<MetaData> lsttype = new List<MetaData>();
            DbCommand dbcommand = myDataBase.GetSqlStringCommand("select User_Type_Id,User_Type_Name from MetaData_UserType");
            using (IDataReader reader = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader.Read())
                {
                    MetaData metadata = new MetaData();
                    metadata.Id = GetIntegerFromDataReader(reader, "User_Type_Id");
                    metadata.Name = GetStringFromDataReader(reader, "User_Type_Name");
                    lsttype.Add(metadata);
                }
                
            }
            return lsttype;
        }

        public List<MetaData>  ReadMetaDataCompany()
        {
            List<MetaData> lsttype = new List<MetaData>();
            DbCommand dbcommand = myDataBase.GetSqlStringCommand("select Company_Id,Company_Name from Company_Metadata");
            using (IDataReader reader = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader.Read())
                {
                    MetaData metadata = new MetaData();
                    metadata.Id = GetIntegerFromDataReader(reader, "Company_Id");
                    metadata.Name = GetStringFromDataReader(reader, "Company_Name");
                    lsttype.Add(metadata);
                }
            }
            return lsttype;
        }

        public List<MetaData> ReadMetaDataUserTask()
        {
            List<MetaData> lsttype = new List<MetaData>();
            DbCommand dbcommand = myDataBase.GetSqlStringCommand(DBConstant.READ_METADATA_USER_TASK);
            using (IDataReader reader = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader.Read())
                {
                    MetaData metadata = new MetaData();
                    metadata.Id = GetIntegerFromDataReader(reader, "UserTask_Id");
                    metadata.Name = GetStringFromDataReader(reader, "Task_Name");
                    lsttype.Add(metadata);
                }

            }
            return lsttype;
        }
    }
}
