using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DataAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Remielsoft.JetSave.BusinessAccessLayer
{
   
   public class MiscellaneousBusinessAccess:BaseBusinessAccess
    {
       
        private Database myDataBase;
        private MiscellaneousDataAccess miscellaneousData;
       
        public MiscellaneousBusinessAccess()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            miscellaneousData = new MiscellaneousDataAccess(myDataBase);
           
        }
        #region InsertMiscCharges
        public void insert(Miscellaneous miscellaneous)
        {
            miscellaneousData.insertcharges(miscellaneous);
        }
        #endregion


        #region MiscCharges Bind GridView
        public List<Miscellaneous> Bind()
        {
            List<Miscellaneous> lst = new List<Miscellaneous>();
            lst = miscellaneousData.bindgried();
            return lst;

        }
        #endregion

        #region Edit MiscCharges
        public List<Miscellaneous> ReadId(int Id)
        {
            List<Miscellaneous> lstread = new List<Miscellaneous>();
            lstread = miscellaneousData.Readbyid(Id);
            return lstread;
        }
        #endregion

        #region Delete MiscCharges
        public void dellete(int Id)
       {
           miscellaneousData.Delete(Id);
       }
        #endregion

        #region Update MiscCharges
        public void update1(int Id ,Miscellaneous Misc)
       {
           miscellaneousData.update(Id,Misc);
       }
        #endregion
        //public List<MislaDom> serch(string Description)
       //{
       //    List<MislaDom> ll = new List<MislaDom>();
       //    return ll= MislaDal_ob.search(Description);
       //}

       //public decimal ReadServiceTax()
       //{

       //    return 0m;
       //}
        #region ReadMislenousByServiceTax
        public List<Miscellaneous> ReadMislenousByServiceTax()
        {
            return miscellaneousData.ReadMislenousByServiceTax();
        }
        #endregion

        #region Readmisenousservicecharges
        public List<Miscellaneous> Readmisenousservicecharges()
        {
            return miscellaneousData.ReadMislenousByServicecharges();
        }
        #endregion


        #region MiscDescription Bind On DropDown
        public List<Miscellaneous> ReadMicDescription()
        {
            List<Miscellaneous> lst = new List<Miscellaneous>();
            lst = miscellaneousData.ReadMicDescription();
            return lst;

        }
        #endregion

      
    }

           
        
}
