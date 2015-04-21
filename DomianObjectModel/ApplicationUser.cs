using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
   public class ApplicationUser
    {

       public ApplicationUser()
       {
           this.UserLocation = new LocationMaster();
       }
       public int UserId { get; set; }

        public string UserName { get; set; }

        public LocationMaster UserLocation { get; set; }
    }
}
