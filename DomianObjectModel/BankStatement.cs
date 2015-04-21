using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    public  class BankStatement
    {


        public string DATE { get; set; }

        public string  VouchNo { get; set; }

      

        public int Account_Code { get; set; }

        public string Account_Head { get; set; }

        public string Particulars { get; set; }

        public string Chq_No { get; set; }

        public decimal DEBITAMOUNT { get; set; }

        public string BankName { get; set; }

        public Int32 TotalDebitAmt { get; set; }

        public string CREDITAMOUNT { get; set; }

     

    
    }


}
