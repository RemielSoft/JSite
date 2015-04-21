using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
namespace Remielsoft.JetSave.BusinessAccessLayer
{
   public class BaseBusinessAccess
    {
       protected const String C_ConnectionString = "myConnectionString";

        public TransactionOptions C_TRANSACTIONSCOPE_ISOLATION_LEVEL = new TransactionOptions();

        public BaseBusinessAccess()
        {
            C_TRANSACTIONSCOPE_ISOLATION_LEVEL.IsolationLevel = IsolationLevel.ReadCommitted;
        }
    }
}
