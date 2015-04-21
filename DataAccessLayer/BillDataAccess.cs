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
    public class BillDataAccess : BaseDataAccess
    {
        private Database myDataBase;
        public BillDataAccess(Database m_database)
        {
            myDataBase = m_database;
        }
        public List<BillItem> ReadBillItems(int agentId, int countryId, int visaOneId, int visaTwoId)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_NEW_BILL_CHARGES);
            dbCommand.CommandType = CommandType.StoredProcedure;
            List<BillItem> lstBill = new List<BillItem>();
            myDataBase.AddInParameter(dbCommand, "@VisaTypeOneId", DbType.Int32, visaOneId);
            myDataBase.AddInParameter(dbCommand, "@VisaTypeTwoId", DbType.Int32, visaTwoId);
            myDataBase.AddInParameter(dbCommand, "@CountryId", DbType.Int32, countryId);
            myDataBase.AddInParameter(dbCommand, "@agentId", DbType.Int32, agentId);


            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    BillItem billItem = new BillItem();


                    billItem.BillItemDescription = GetStringFromDataReader(reader, "DESCRIPTION");
                    billItem.ItemCharge = GetDecimalFromDataReader(reader, "CHARGE");
                    

                    lstBill.Add(billItem);
                }
                return lstBill;
            }
        }
    }
}