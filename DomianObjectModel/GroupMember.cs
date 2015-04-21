using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
   public class GroupMember
    {
       //public GroupMember()
       //{
       //    groupMasterData = new GroupMasterData();
       //}
        public string groupmember { get; set; }

        public int groupName { get; set; }

        public string MemberName { get; set; }

        public GroupMasterData groupMasterData { get; set; }
    }
}
