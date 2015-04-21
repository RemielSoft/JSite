using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DataAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Remielsoft.JetSave.BusinessAccessLayer
{
    
   public  class MetaDataBal:BaseBusinessAccess
    {
       private Database myDataBase;
       private MetaDataDal metadatadal;
        public MetaDataBal()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            metadatadal = new MetaDataDal(myDataBase);
        }

        public List<MetaData> ReadMetaDataUserTask()
        {
            return metadatadal.ReadMetaDataUserTask();
        }

        public List<MetaData> ReadMetaDataComapany()
        {
            return metadatadal.ReadMetaDataCompany();
        }
        public List<MetaData> ReadMetaDataUserType()
        {
            return metadatadal.ReadMetaDataUserType();
        }
    }
}
