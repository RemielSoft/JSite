using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.DataAccessLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace Remielsoft.JetSave.BusinessAccessLayer
{
   public  class BillBusinessAccess:BaseBusinessAccess
    {
        private Database myDataBase;
        private BillDataAccess billDataAccess;
        public BillBusinessAccess()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            billDataAccess = new BillDataAccess(myDataBase);
        }
       public List<BillItem> ReadBillItems(int agentId, int countryId, int visaOneId, int visaTwoId)
       {
           

           return billDataAccess.ReadBillItems(agentId, countryId, visaOneId, visaTwoId);
       }
       public Bill ReadBillByNewConsignmentId(int consignmentId,Consignment consignment)
       {
           Bill returnBill = new Bill();
           

           //BILL_ID	not required in new bill
//BILL_DATE	current data and time
//BILL_TYPE	by default it will normal bill type
//FK_CG_ID	from the method parameter
//PAXS	from consignment object from parameter
//ISCANCELLED	by default it is false
           //ISPRINTED	by default it is false

//ServiceCharge	numeric(18, 2)	Checked
           returnBill.NewBillItemDetails = this.ReadBillItems(consignment.FkAgentId, consignment.Country_Id, consignment.PaxDetails[0].VisaTypeOneId, consignment.PaxDetails[0].VisaTypeTwoId);
           for (int i = 0; i < returnBill.NewBillItemDetails.Count; i++)
           {
               if (returnBill.NewBillItemDetails[i].BillItemDescription.ToUpper().Equals("Service Charges"))
               {
                   returnBill.ServiceCharge = returnBill.NewBillItemDetails[i].ItemCharge;
               }
           }
           MiscellaneousBusinessAccess misBal = new MiscellaneousBusinessAccess();
           //returnBill.ServiceTax = misBal.ReadServiceTax();
           return null;
//TotalAmt	initially 0
//ServiceTax	float	Checked
       }
    }
}
