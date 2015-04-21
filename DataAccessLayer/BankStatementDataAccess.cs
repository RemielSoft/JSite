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
    public class BankStatementDataAccess:BaseDataAccess
    {
        private Database myDataBase;
        Int32 TotalDebitAmount = 0;

        public BankStatementDataAccess(Database m_database)
        {
            myDataBase = m_database;
        }
        public List<BankStatement>readdBankSatetment(DateTime fromDate,DateTime toDate,string bankName,int? LocId)
        {
            List<BankStatement> lst = new List<BankStatement>();

            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.READ_BANKSTATEMENT_SEARCH);

            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbcommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbcommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            myDataBase.AddInParameter(dbcommand, "@in_from_date", DbType.DateTime, fromDate);
            myDataBase.AddInParameter(dbcommand, "@in_to_date", DbType.DateTime, toDate);
            myDataBase.AddInParameter(dbcommand, "@in_bankName", DbType.String, bankName);
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    BankStatement bankstatement = new BankStatement();
                    bankstatement.DATE = GetStringFromDataReader(reader1, "DATE");
                    bankstatement.VouchNo = GetStringFromDataReader(reader1, "Vouch. No.");
                    bankstatement.Account_Code = GetIntegerFromDataReader(reader1, "A/c Code");
                    bankstatement.Account_Head = GetStringFromDataReader(reader1, "Account - Head");
                    bankstatement.Particulars = GetStringFromDataReader(reader1, "Particulars");
                    bankstatement.Chq_No = GetStringFromDataReader(reader1, "Chq-No.");
                    bankstatement.DEBITAMOUNT = GetIntegerFromDataReader(reader1, "DEBIT AMOUNT");
                    bankstatement.BankName = GetStringFromDataReader(reader1, "Bank Name");
                    TotalDebitAmount = Convert.ToInt32(TotalDebitAmount) + Convert.ToInt32(bankstatement.DEBITAMOUNT);
                    bankstatement.TotalDebitAmt = TotalDebitAmount;
                    
                    lst.Add(bankstatement);

                }
            }
            return lst;

    }
        public List<BankStatement> readBankall(DateTime fromDate, DateTime toDate,int? LocId)
        {
            List<BankStatement> lst = new List<BankStatement>();

            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.READ_ALLBANKSTATEMENT_SEARCH);

            if (LocId != 0)
            {
                myDataBase.AddInParameter(dbcommand, "@LocationId", DbType.Int32, LocId);
            }
            else
            {
                myDataBase.AddInParameter(dbcommand, "@LocationId", DbType.Int32, DBNull.Value);
            }
            myDataBase.AddInParameter(dbcommand, "@in_from_date", DbType.DateTime, fromDate);
            myDataBase.AddInParameter(dbcommand, "@in_to_date", DbType.DateTime, toDate);
           
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    BankStatement bankstatement = new BankStatement();
                    bankstatement.DATE = GetStringFromDataReader(reader1, "DATE");
                    bankstatement.VouchNo = GetStringFromDataReader(reader1, "voch.No");
                    bankstatement.Account_Code = GetIntegerFromDataReader(reader1, "A/C Code");
                    bankstatement.Account_Head = GetStringFromDataReader(reader1, "Account_Head");
                    bankstatement.Particulars = GetStringFromDataReader(reader1, "Particulars");
                    bankstatement.Chq_No = GetStringFromDataReader(reader1, "Chq-No.");
                    bankstatement.DEBITAMOUNT = GetIntegerFromDataReader(reader1, "DEBIT AMOUNT");
                    bankstatement.BankName = GetStringFromDataReader(reader1, "Bank Name");
                    bankstatement.CREDITAMOUNT = GetStringFromDataReader(reader1, "Credit Amount");
                    
                    TotalDebitAmount = Convert.ToInt32(TotalDebitAmount) + Convert.ToInt32(bankstatement.DEBITAMOUNT);
                    bankstatement.TotalDebitAmt = TotalDebitAmount;

                    lst.Add(bankstatement);

                }
            }
            return lst;

        }

    }
}
