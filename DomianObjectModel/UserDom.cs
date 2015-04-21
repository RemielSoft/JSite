using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    public class UserDom : BaseDomainObjectModel
    {
        public int UserId { get; set; }
        public string LoginId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public String FullName 
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }

        }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public int Location_Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MaritalStatus { get; set; }
        public string EmpCode { get; set; }
        public string OfficeExtentionNo { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string Isdeleted { get; set; }
        public LocationMaster UserLocation { get; set; }
        public List<UserTaskMaping> UserTask { get; set; }
        public MetaData MetaData { get; set; }
        public int UserTypeId { get; set; }
        public DateTime LastLoginDate { get; set; }

        public int AgentId { get; set; }
    }
}
