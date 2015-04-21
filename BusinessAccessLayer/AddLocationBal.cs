using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DataAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Remielsoft.JetSave.BusinessAccessLayer
{
  public class AddLocationBal:BaseBusinessAccess
    {
       private Database myDataBase;
        private LocationDal addlocationbal;
        public AddLocationBal()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            addlocationbal = new LocationDal(myDataBase);
        }

        public List<Location> ReadLocation()
        {
            return null;  
                //addlocationbal.ReadLocation();null
        }

    }
}
