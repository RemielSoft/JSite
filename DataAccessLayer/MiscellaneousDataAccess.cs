using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;


namespace Remielsoft.JetSave.DataAccessLayer
{
    public class MiscellaneousDataAccess:BaseDataAccess
    {
        private Database myDataBase;
        public  MiscellaneousDataAccess(Database m_database)
        {
            myDataBase = m_database;
        }
         #region InsertMiscCharges
        public void insertcharges(Miscellaneous miscellaneous)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.INSERT_MISCCHARGES);
            myDataBase.AddInParameter(dbCommand, "@Description", DbType.String, miscellaneous.Description);
            myDataBase.AddInParameter(dbCommand, "@Amount", DbType.Decimal, miscellaneous.Amount);            
            myDataBase.AddInParameter(dbCommand, "@Per_consignment ", DbType.String, miscellaneous.Per_consignment);
            myDataBase.AddInParameter(dbCommand, "@Mandatory", DbType.String, miscellaneous.Mandatory);
            myDataBase.AddInParameter(dbCommand, "@ServiceTax", DbType.String, miscellaneous.ServiceTax);
            myDataBase.AddInParameter(dbCommand, "@serviceCharges", DbType.String, miscellaneous.ServiceCharges);
            myDataBase.ExecuteNonQuery(dbCommand);
         }
#endregion

        #region MiscCharges Bind GridView
        public List<Miscellaneous> bindgried()
        {
            List<Miscellaneous> lst = new List<Miscellaneous>();

            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.READ_MISCCHARES);
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    Miscellaneous miscellaneousbind = new Miscellaneous();
                    miscellaneousbind.Id = GetIntegerFromDataReader(reader1, "MISC_ID");
                    miscellaneousbind.Description = GetStringFromDataReader(reader1, "MISC_DESCRIPTION");
                    miscellaneousbind.Amount = GetDecimalFromDataReader(reader1, "MISC_AMOUNT");                    
                    miscellaneousbind.Per_consignment = GetStringFromDataReader(reader1, "APPLICABLE");
                    if (miscellaneousbind.Per_consignment == "v")
                    {
                        miscellaneousbind.Per_consignment = "visa";
                    }
                    else
                    {
                        miscellaneousbind.Per_consignment = "Consignment";
                    }
                    miscellaneousbind.Mandatory = GetStringFromDataReader(reader1, "MISC_Mandatory");
                    miscellaneousbind.ServiceTax = GetStringFromDataReader(reader1, "MISC_SERVICETAX");
                    miscellaneousbind.ServiceCharges = GetStringFromDataReader(reader1, "MISC_SERVICECHARGES");

                    lst.Add(miscellaneousbind);
                   
                }
            }
            return lst;
       
        }
        #endregion

        #region Edit MiscCharges
        public List<Miscellaneous> Readbyid( int Id)
        {
            List<Miscellaneous> listread = new List<Miscellaneous>();
            DbCommand dbcommand = myDataBase.GetSqlStringCommand("select MISC_ID,MISC_DESCRIPTION,MISC_AMOUNT,APPLICABLE,MISC_Mandatory,MISC_SERVICETAX , MISC_SERVICECHARGES from MISC_CHARGES where MISC_ID=" + Id + "");
            using (IDataReader reader2 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader2.Read())
                {
                    Miscellaneous Readob = new Miscellaneous();
                    Readob.Id = Id;
                    Readob.Description = GetStringFromDataReader(reader2, "MISC_DESCRIPTION");
                    Readob.Amount = GetDecimalFromDataReader(reader2, "MISC_AMOUNT");
                    Readob.Per_consignment = GetStringFromDataReader(reader2, "APPLICABLE");
                    Readob.Mandatory = GetStringFromDataReader(reader2, "MISC_Mandatory");
                    Readob.ServiceTax = GetStringFromDataReader(reader2, "MISC_SERVICETAX");
                    Readob.ServiceCharges = GetStringFromDataReader(reader2, "MISC_SERVICECHARGES");
                    listread.Add(Readob);
                }
            }
            return listread;
        }
#endregion 

        #region Delete MiscCharges 
        public void Delete(int Id)
        {
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.DELETE_MISCCHARGES);
            myDataBase.AddInParameter(dbcommand, "@Id", DbType.Int32,Id);
            myDataBase.ExecuteNonQuery(dbcommand);
 
        }

        #endregion

        #region Update MiscCharges
        public void update(int Id,Miscellaneous miscupdate)
        {

            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.UPDATE_MISCCHARES);
            myDataBase.AddInParameter(dbcommand, "@Id", DbType.Int32, Id);
            myDataBase.AddInParameter(dbcommand,"@Description",DbType.String, miscupdate.Description);
            myDataBase.AddInParameter(dbcommand, "@Amount", DbType.Decimal, miscupdate.Amount);
            myDataBase.AddInParameter(dbcommand, "@Per_consignment ", DbType.String, miscupdate.Per_consignment);
            myDataBase.AddInParameter(dbcommand, "@Mandatory", DbType.String, miscupdate.Mandatory);
            myDataBase.AddInParameter(dbcommand, "@ServiceTax", DbType.String, miscupdate.ServiceTax);
            myDataBase.AddInParameter(dbcommand, "@ServiceCharges", DbType.String, miscupdate.ServiceCharges);
            myDataBase.ExecuteNonQuery(dbcommand);

        }

        #endregion

        #region MiscDescription Bind On DropDown

        public List<Miscellaneous> ReadMicDescription()
        {
            List<Miscellaneous> lst = new List<Miscellaneous>();
            DbCommand dbcommand = myDataBase.GetSqlStringCommand("select MISC_ID,MISC_DESCRIPTION from MISC_CHARGES where MISC_SERVICETAX='False' and MISC_SERVICECHARGES='False'  order by MISC_ID asc");
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    Miscellaneous miscellaneousDomain = new Miscellaneous();
                    miscellaneousDomain.Id = GetIntegerFromDataReader(reader1, "MISC_ID");
                    miscellaneousDomain.Description = GetStringFromDataReader(reader1, "MISC_DESCRIPTION");
                    lst.Add(miscellaneousDomain);
                }
            }
            return lst;

        }
        #endregion
        
        
        public List<Miscellaneous> ReadMislenousByServiceTax()
        {
            List<Miscellaneous> listread = new List<Miscellaneous>();
            DbCommand dbcommand = myDataBase.GetSqlStringCommand("select MISC_SERVICETAX  from MISC_CHARGES  ");
            using (IDataReader reader2 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader2.Read())
                {
                    Miscellaneous Readob = new Miscellaneous();

                    Readob.ServiceTax = GetStringFromDataReader(reader2, "MISC_SERVICETAX");
                    listread.Add(Readob);
                }
            }
            return listread;
        }

        public List<Miscellaneous> ReadMislenousByServicecharges()
        {
            List<Miscellaneous> listreadservicecharges = new List<Miscellaneous>();
            DbCommand dbcommand = myDataBase.GetSqlStringCommand("select MISC_SERVICECHARGES from MISC_CHARGES  ");
            using (IDataReader reader2 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader2.Read())
                {
                    Miscellaneous Readservicecharges = new Miscellaneous();

                    Readservicecharges.ServiceCharges = GetStringFromDataReader(reader2, "MISC_SERVICECHARGES");
                    listreadservicecharges.Add(Readservicecharges);
                }
            }
            return listreadservicecharges;
        }
        
        
    }
}
