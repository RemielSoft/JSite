using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DataAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Remielsoft.JetSave.BusinessAccessLayer
{
    public class VisaFormBL : BaseBusinessAccess
    {
        private Database myDataBase;
        private VisaFormDL addVisaFormDal;
        public VisaFormBL()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            addVisaFormDal = new VisaFormDL(myDataBase);
        }
        public void Insertrecord(List<VisaForm> addvisadom)
        {
            addVisaFormDal.InsertRecord(addvisadom);
        }
        public void InsertVaccination(VisaForm addvisadom)
        {
            addVisaFormDal.InsertVaccination(addvisadom);
        }

        public void InsertCoverNote(VisaForm addvisadom)
        {
            addVisaFormDal.InsertCoverNote(addvisadom);
        }
        public void DeleteCoverNote(int id)
        {
            addVisaFormDal.DeleteCoverNote(id);
        }
        public List<VisaForm> ReadCoverNote(int? id)
        {
            return addVisaFormDal.ReadCoverNote(id);
        }
        public void DeleteVaccination(int id)
        {
            addVisaFormDal.DeleteVaccination(id);
        }
        public List<VisaForm> ReadVaccination(int? id)
        {
           return addVisaFormDal.ReadVaccination(id);
        }

        public void InsertRecordForSchnegenCountry(VisaForm addvisadom)
        {
            addVisaFormDal.InsertRecordForSchnegenCountry(addvisadom);
        }

        public List<VisaForm> ReadDelhiForm()
        {
            List<VisaForm> adlst = new List<VisaForm>();
            adlst = addVisaFormDal.ReadDelhiForm();
            return adlst;
        }
        public List<VisaForm> ReadMumbaiForm()
        {
            List<VisaForm> adlst = new List<VisaForm>();
            adlst = addVisaFormDal.ReadMumbaiForm();
            return adlst;
        }

        

        public List<VisaForm> ReadChannaiForm()
        {
            List<VisaForm> adlst = new List<VisaForm>();
            adlst = addVisaFormDal.ReadChannaiForm();
            return adlst;
        }
        public List<VisaForm> ReadBangaloreForm()
        {
            List<VisaForm> adlst = new List<VisaForm>();
            adlst = addVisaFormDal.ReadBangaloreForm();
            return adlst;
        }
        public List<VisaForm> ReadForm(string str, string strCity)
        {
            List<VisaForm> lst = new List<VisaForm>();
            lst = addVisaFormDal.ReadForm(str, strCity);
            return lst;
        }
        public List<VisaForm> ReadVisaForm()
        {
            List<VisaForm> lst = new List<VisaForm>();
            lst = addVisaFormDal.ReadVisaForm();
            return lst;
        }
        public List<VisaForm> ReadVisarecord(String name)
        {
            List<VisaForm> adlst = new List<VisaForm>();
            adlst = addVisaFormDal.ReadVisarecord(name);
            return adlst;
        }
        
        public void deleterecord(int Id)
        {
            addVisaFormDal.deleterecord(Id);

        }
        public void deleteSchnegenRecord(string title,string countryName)
        {
            addVisaFormDal.deleteSchnegenRecord(title,countryName);

        }

        public List<VisaForm> ReadVisaFormByCountry(string CName,string consulate)
        {
            List<VisaForm> lstVisa = new List<VisaForm>();
            lstVisa = addVisaFormDal.ReadVisaFormByCountry(CName, consulate);
            return lstVisa;
        }


       
    }
}
