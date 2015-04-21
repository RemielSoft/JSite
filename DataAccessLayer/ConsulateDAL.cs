using Microsoft.Practices.EnterpriseLibrary.Data;
using Remielsoft.JetSave.DomianObjectModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DataAccessLayer
{
    public class ConsulateDAL : BaseDataAccess
    {
        private Database myDataBase;
        public ConsulateDAL(Database m_database)
        {
            myDataBase = m_database;
        }
        public List<Consulate> ReadConsulate()
        {
           
            List<Consulate> lstConsulate = new List<Consulate>();
            DbCommand dbcommand = myDataBase.GetSqlStringCommand("Select consulate_id,consulate_name from Consulate");

            using (IDataReader reader = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader.Read())
                {
                    Consulate consulate = new Consulate();
                    consulate.consulateName = GetStringFromDataReader(reader, "consulate_name");
                    consulate.consulateId = GetIntegerFromDataReader(reader, "consulate_id");
                    lstConsulate.Add(consulate);
                }
                return lstConsulate;
            }
        }
    }
}
