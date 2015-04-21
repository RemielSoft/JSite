using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.DataAccessLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Remielsoft.JetSave.BusinessAccessLayer
{
    public class BillRegisterBusinessAccess:BaseBusinessAccess
    {
        #region Global Variables

        private BillRegisterDataAccess billRegisterDAL;

        private Database myDataBase;
        
        #endregion

        #region Public Methods

        public BillRegisterBusinessAccess()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            billRegisterDAL = new BillRegisterDataAccess(myDataBase);
        }

        public List<BillRegister> BillRegisterInfoFromBillNo(int fromBill, int toBill, int AgentId, int? LocId)
        {
            List<BillRegister> lst = new List<BillRegister>();
            lst = billRegisterDAL.ReadBillRegisterInformationFromBillNo(fromBill, toBill, AgentId, LocId);
            return lst;
        }

        public List<BillRegister> BillRegisterInfoByDate(DateTime? fromDate, DateTime? toDate, int AgentId, int? LocId)
        {
            List<BillRegister> lst = new List<BillRegister>();
            lst = billRegisterDAL.ReadBillRegisterInformationByDate(fromDate, toDate, AgentId, LocId);
            return lst;
        }

        public List<BillRegister> BillRegisterByDate(DateTime? fromDate, DateTime? toDate, int AgentId, int? LocId)
        {
            List<BillRegister> lst = new List<BillRegister>();
            lst = billRegisterDAL.BillRegisterByDate(fromDate, toDate, AgentId, LocId);
            return lst;
        }
        public List<BillRegister> BillRegisterByAgentName(DateTime? fromDate, DateTime? toDate, int AgentId, int? LocId)
        {
            List<BillRegister> lst = new List<BillRegister>();
            lst = billRegisterDAL.BillRegisterByDate(fromDate, toDate, AgentId, LocId);
            return lst;
        }
        public List<BillRegister> ReadBillRegisterBYFromBillNo(int fromBill, int toBill, int AgentId, int? LocId)
        {
            List<BillRegister> lst = new List<BillRegister>();
            lst = billRegisterDAL.ReadBillRegisterBYFromBillNo(fromBill, toBill, AgentId, LocId);
            return lst;
        }

        #endregion
    }
}
