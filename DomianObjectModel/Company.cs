using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    [Serializable]
  public  class Company:BaseDomainObjectModel
    {
      public int CompanyId { get; set; }
      public string CompanyName { get; set; }


      
//      Company_Id	int	Unchecked
//Company_Name	nvarchar(100)	Checked
//Address1	nvarchar(255)	Checked
//Address2	nvarchar(255)	Checked
//Phone1	nvarchar(20)	Checked
//Phone2	nvarchar(20)	Checked
//Fax_No	nvarchar(30)	Checked
//Email	nvarchar(100)	Checked
//City	nvarchar(20)	Checked
//State	nvarchar(20)	Checked
//Country	nvarchar(20)	Checked
//Mobile_No	nvarchar(20)	Checked
//Pin_No	nvarchar(20)	Checked
    }
}
