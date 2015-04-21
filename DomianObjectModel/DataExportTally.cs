using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    public class DataExportTally
    {
        //FROM RECEIPT AND BILL

        public String FirstBlock
        {
            get
            {
                if (this.isReciptData)
                {
                    string strMySecondValue = ReturnRightPadding("", 3) + ReturnRightPadding((receipt.RcptNo.ToString() + "/" + agent.AgentId.ToString()), 15);
                    return ReturnLeftPadding(SrNo.ToString(), 6) + ReturnRightPadding((DateString(receipt.RcptDate) + "RCPT" + receipt.RcptType).ToString() + strMySecondValue, 32);
                    //dbo.fnPadLeft(' ',6,convert(varchar,Serial))
                    //DBO.FNPADRIGHT(' ',17,dbo.fnDateString(RCPT_DATE)+'RCPT'+RCPT_TYPE)+ DBO.fnpadRight(' ',15,(CONVERT(VARCHAR,RCPT_ID)+'/'+convert(varchar,FK_AGENT_ID))) as FirstBlock ,
                }
                else
                {
                    return ReturnLeftPadding(SrNo.ToString(), 6) + ReturnRightPadding(((bill.BillDate) + "SALE" + bill.BillId + "/" + agent.AgentId).ToString(), 32);
                    //DBO.FNPADRIGHT(' ',32,dbo.fnDateString(BILL.BILL_DATE)+'SALE'+CONVERT(VARCHAR,BILL.BILL_ID)+'/'+convert(varchar,Agent.Agent_Id) )as FirstBlock,
                }                
            }
        }
        
        public String SecondBlock
        {
            get
            {
                if (isReciptData)
                {
                    //string mySecRcptValue = ReturnPadding((receipt.RcptNo.ToString() + "/" + agent.AgentId.ToString()), 5);
                    return ReturnRightPadding(receipt.RcptType.ToString(), 5) + ReturnRightPadding((receipt.RcptNo.ToString() + "/" + agent.AgentId.ToString()), 15);
                    //dbo.fnPadRight(' ',5,RCPT_TYPE)+ DBO.fnpadRight(' ',15,(CONVERT(VARCHAR,RCPT_ID)+'/'+convert(varchar,FK_AGENT_ID)))  as secBlock,
                }
                else
                {
                    return ReturnRightPadding((bill.BillId + "/" + agent.AgentId).ToString(), 20);
                    //dbo.fnPadRight(' ',20,(CONVERT(VARCHAR,BILL.BILL_ID)+'/'+convert(varchar,Agent.Agent_Id))) as secBlock,
                }
            }
        }
        
        public String SecBlankBlock
        {
            get
            {
                if (isReciptData)
                {
                    return ReturnLeftPadding("", 20);
                    //dbo.fnPadRight(' ',20,'') as BlanksecBlock,             
                }
                else
                {
                    return ReturnLeftPadding("", 20);
                    //dbo.fnPadRight(' ',20,'') as BlanksecBlock           
                }
            }
        }
        
        public String PartyName
        {
            get
            {
                if (isReciptData)
                {
                    return ReturnRightPadding((agent.TallyAcName.ToUpper()), 30);
                    //dbo.fnPadRight(' ',30,upper(substring(AGENT.TALLY_ACNAME,0,30)))as partyname
                }
                else
                {
                    return ReturnRightPadding((agent.TallyAcName.ToUpper()), 30);
                    //dbo.fnPadRight(' ',30,upper(substring(AGENT.TALLY_ACNAME,0,30)))as partyname
                }                
            }
        }
        
        public String PartyName2
        {
            get
            {
                if (isReciptData)
                {
                    return ReturnRightPadding(receipt.CreditAccount.ToUpper(), 30);
                    //dbo.fnPadRight(' ',30, ACCOUNT)as partyname2,
                }
                else
                {
                    return ReturnRightPadding("SALES VISA", 30);
                    //dbo.fnPadRight(' ',30,'SALES VISA')as partyname2,
                }
            }
        }
        
        public String PartyName3
        {
            get
            {
                if (isReciptData)
                {
                    return ReturnRightPadding("VISA FEE", 30);
                    //dbo.fnPadRight(' ',30,'VISA FEE')as partyname3,
                }
                else
                {
                    return ReturnRightPadding("VISA FEE", 30);
                    //dbo.fnPadRight(' ',30,'VISA FEE')as partyname3,
                }
            }
        }
        
        public String PartyName4
        {
            get
            {
                if (isReciptData)
                {
                    return ReturnRightPadding("SERVICE CHARGE", 30);
                    //dbo.fnPadRight(' ',30,'SERVICE CHARGE')as partyname4,
                }
                else
                {
                    return ReturnRightPadding("SERVICE CHARGE", 30);
                    //dbo.fnPadRight(' ',30,'SERVICE CHARGE')as partyname4,
                }
            }
        }
        
        public String PartyName5
        {
            get
            {
                if (isReciptData)
                {
                    return ReturnRightPadding("SERVICE TAX", 30);
                    //dbo.fnPadRight(' ',30,'SERVICE TAX')as partyname5,  
                }
                else
                {
                    return ReturnRightPadding("SERVICE TAX", 30);
                    //dbo.fnPadRight(' ',30,'SERVICE TAX')as partyname5,
                }
            }
        }
        
        public String DrAmt
        {
            get
            {
                if (isReciptData)
                {
                    return ReturnLeftPadding(("-" + (Math.Round(Convert.ToDecimal(receipt.RcptAmount), 2))).ToString(), 15);
                    //dbo.fnPadLeft(' ',15,'-'+convert(varchar,Convert(Decimal(11,2),RCPT_AMOUNT)))as drAmt, 
                }
                else
                {
                    return ReturnLeftPadding((Math.Round(Convert.ToDecimal(bill.TotalAmount), 2)).ToString(), 15);                    
                    //dbo.fnPadLeft(' ',15,convert(varchar,Convert(Decimal(11,2),dbo.fnTotalAmount(BILL.BILL_ID)+ BILL.ServiceCharge + (Bill.ServiceCharge*Bill.ServiceTax)/100)))as drAmt,

                }
            }
        }
        
        public String CrAmt
        {
            get
            {
                if (isReciptData)
                {
                    return ReturnLeftPadding((Math.Round(Convert.ToDecimal(receipt.RcptAmount), 2)).ToString(), 15);
                    //dbo.fnPadLeft(' ',15,convert(varchar,Convert(Decimal(11,2),RCPT_AMOUNT)))as CrAmt,
                }
                else
                {
                    return ReturnLeftPadding("-" + (Math.Round(Convert.ToDecimal(bill.TotalAmount), 2)).ToString(), 15);
                    //return ReturnLength("-" + Math.Round(Convert.ToDecimal((bill.TotalAmount + bill.ServiceCharge + (bill.ServiceCharge * bill.ServiceTax / 100))),2).ToString(), 15);
                    //dbo.fnPadLeft(' ',15,'-'+convert(varchar,Convert(Decimal(11,2),dbo.fnTotalAmountWithAll(BILL.BILL_ID))))as CrAmt,
                }
            }
        }
        
        public String FeeAmt
        {
            get
            {
                if (isReciptData)
                {
                    return ReturnRightPadding("", 15);
                    //dbo.fnPadLeft(' ',15,'')as feeAmt,
                }
                else
                {
                    return ReturnRightPadding((Math.Round(Convert.ToDecimal(bill.TotalAmount), 2)).ToString(), 15);
                    //dbo.fnPadLeft(' ',15,convert(varchar,Convert(Decimal(11,2),dbo.fnTotalAmount(BILL.BILL_ID))))as feeAmt,
                }
            }
        }
        
        public String ServiceAmt
        {
            get
            {
                if (isReciptData)
                {

                    return ReturnRightPadding("", 15);
                    //dbo.fnPadLeft(' ',15,'')as serviceAmt,
                }
                else
                {
                    return ReturnRightPadding((Math.Round(Convert.ToDecimal(bill.ServiceCharge), 2)).ToString(), 15);
                    //dbo.fnPadLeft(' ',15,convert(varchar,Convert(Decimal(11,2),Bill.ServiceCharge)))as serviceAmt,
                }
            }
        }
        
        public String ServiceTaxAmt
        {
            get
            {
                if (isReciptData)
                {
                    return ReturnRightPadding("", 15);
                    //dbo.fnPadLeft(' ',15,'')as serviceTaxAmt,
                }
                else
                {
                    return ReturnRightPadding((Math.Round(Convert.ToDecimal((bill.ServiceCharge * bill.ServiceTax) / 100), 2)).ToString(), 15);
                    //dbo.fnPadLeft(' ',15,convert(varchar,Convert(Decimal(11,2),(Bill.ServiceCharge*Bill.ServiceTax)/100)))as serviceTaxAmt,
                }
            }
        }
        
        public String Ref
        {
            get
            {
                if (isReciptData)
                {
                    return ReturnRightPadding("", 52);
                    //dbo.fnPadLeft(' ',52,'')as Ref,
                }
                else
                {
                    return ReturnRightPadding("", 45) + ReturnLeftPadding("NEW REF", 7);
                    //dbo.fnPadLeft(' ',52,'NEW REF')as Ref,
                }
            }
        }
        
        public String BlankRef
        {
            get
            {
                if (isReciptData)
                {
                    return ReturnRightPadding("", 52);
                    //dbo.fnPadLeft(' ',52,'')as BlankRef,   
                }
                else
                {
                    return ReturnRightPadding("", 52);
                    //dbo.fnPadLeft(' ',52,'')as BlankRef,
                }
            }
        }
        
        public String Inv
        {
            get
            {
                if (isReciptData)
                {
                    return ReturnLeftPadding(receipt.RcptType, 5) + ReturnLeftPadding((receipt.RcptNo.ToString()), 8);
                    //dbo.fnPadLeft(' ',5,RCPT_TYPE)+dbo.fnPadLeft(' ',8,(CONVERT(VARCHAR,RCPT_ID)))as Inv,      
                }
                else
                {
                    return ReturnLeftPadding(bill.BillId.ToString(), 13);
                    //dbo.fnPadLeft(' ',13,(CONVERT(VARCHAR,BILL.BILL_ID)))as Inv,
                }
            }
        }
        
        public String CrAmt2 
        {
            get
            {
                if (isReciptData)
                {
                    return ReturnLeftPadding("", 29);
                    //dbo.fnPadLeft(' ',29,'')as CrAmt2,  
                }
                else
                {
                    return ReturnLeftPadding(("-" + Math.Round(Convert.ToDecimal(bill.TotalAmount), 2).ToString()), 29);
                    //return ReturnLength(("-" + Math.Round(Convert.ToDecimal(bill.TotalAmount + bill.ServiceCharge + (bill.ServiceCharge*bill.ServiceTax/100)),2).ToString()), 29);
                    //dbo.fnPadLeft(' ',29,'-'+convert(varchar,Convert(Decimal(11,2),dbo.fnTotalAmountWithAll(BILL.BILL_ID))))as CrAmt2,              
                }
            }
        }
        
        public String Narr
        {
            get
            {
                if (isReciptData)
                {
                    return ReturnRightPadding(receipt.Remarks.ToUpper(), 150) + ReturnLeftPadding("", 35);
                    //dbo.fnPadRight(' ',150,REMARKS) +DBO.FNPADRIGHT(' ',35,'') as Narr
                }
                else
                {
                    return ReturnRightPadding((consingment.pax.PaxName + "/" + consingment.CgNoOfPass.ToString() + "/" + consingment.ConsignmentId.ToString()), 150) + ReturnLeftPadding("", 35);
                    //dbo.fnPadRight(' ',150,substring(BILL.PAXS,0,50)+'/'+convert(varchar,consignment.CG_NOOFPASS)+'/'+convert(varchar,CONSIGNMENT.CG_ID))+DBO.FNPADRIGHT(' ',35,'') as Narr
                }                
            }
        }
        
        public String BlankNarr
        {
            get
            {
                if (isReciptData)
                {
                    return ReturnLeftPadding("", 29) + ReturnRightPadding(receipt.Remarks.ToUpper(), 150) + ReturnRightPadding("", 35);
                    //dbo.fnPadLeft(' ',29,'')+ dbo.fnPadRight(' ',150,REMARKS) +DBO.FNPADRIGHT(' ',35,'') as BlankNarr
                }
                else
                {
                    return ReturnRightPadding("", 214);
                    //dbo.fnPadRight(' ',179,'')+DBO.FNPADRIGHT(' ',35,'')as BlankNarr
                }
            }
        }
        
        public String SORTBYTYPE
        {
            get
            {
                if (isReciptData)
                {
                    return ReturnLeftPadding("RCPT~", 0);
                    //'RCPT~' as SORTBYTYPE,
                }
                else
                {
                    return ReturnLeftPadding("Sale", 0);
                    //'Sale' as SORTBYTYPE
                }
            }
        }
        
        public String SORTBYID
        {
            get
            {
                if (isReciptData)
                {
                    return ReturnLeftPadding(receipt.RcptNo.ToString(), 0);
                }
                else
                {
                    return ReturnLeftPadding(bill.BillId.ToString(), 0);
                }
            }
        }

        public Int32 SrNo { get; set; }

        public Receipt receipt { get; set; }
        
        public Agent agent { get; set; }
        
        public Consignment consingment { get; set; }
        
        public Bill bill { get; set; }
        
        public bool isReciptData { get; set; }

        private void AddComma(string item, StringBuilder strb)
        {

            strb.Append(item.Replace(',', ' '));

        }

        private string ReturnRightPadding(string strActual, int end)
        {

            StringBuilder paddingString = new StringBuilder();

            for (int i = strActual.Length; i < end; i++)
            {
                paddingString.Append(" ");
            }

            return string.Concat(strActual, paddingString);
        }

        private string ReturnLeftPadding(string strActual, int end)
        {

            StringBuilder paddingString = new StringBuilder();

            for (int i = strActual.Length; i < end; i++)
            {
                paddingString.Append(" ");
            }

            return string.Concat(paddingString, strActual);
        }        

        private string DateString(DateTime dateActual)
        {

            int day = dateActual.Day;
            int month = dateActual.Month;
            int year = dateActual.Year;

            StringBuilder finalOutPut = new StringBuilder();

            finalOutPut.Append(year.ToString());
            if (month.ToString().Length < 2)
            {
                finalOutPut.Append("0" + month.ToString());
            }
            else
            {
                finalOutPut.Append(month.ToString());
            }
            if (day.ToString().Length < 2)
            {
                finalOutPut.Append("0" + day.ToString());
            }
            else
            {
                finalOutPut.Append(day.ToString());
            }

            return finalOutPut.ToString();
        }        
    }
}
