using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DataAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Remielsoft.JetSave.BusinessAccessLayer
{
    public class GroupMasterBusinessAccess:BaseBusinessAccess
    {
        private Database myDataBase;
        private GroupMasterDataAccess Groupmasterdata;

        public GroupMasterBusinessAccess()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            Groupmasterdata = new GroupMasterDataAccess(myDataBase);
        }
        public List<GroupMasterData> insertgroup(GroupMasterData groupmaster)
        {
            
            return Groupmasterdata.InsertGroupDetail(groupmaster);            
        }

        public void InsertGroupCountry(GroupMasterData Groupmaster)
        {
            Groupmasterdata.InsertGroupToCountry(Groupmaster);
        }
        public List<GroupMasterData> BindGroupName()
        {
            return Groupmasterdata.ReadGroupMaster();
        }
        public void insertMember(GroupMember groupmember1)
        {
            Groupmasterdata.insertMember(groupmember1);
        }
        public List<GroupMember> bindmember(int Id)
        {
            return Groupmasterdata.bindgroupmember(Id);
        }
        public List<GroupMember> memberName(string Name)
        {
            return Groupmasterdata.ReadMember(Name);
        }
        public List<GroupMasterData> country(int Id)
        {
            return Groupmasterdata.ReadCountry(Id);
        }

        public List<GroupMasterData> ReadCounryIdByID(int Id)
        {
            return Groupmasterdata.ReadCounryIdByID(Id);
        }


        public List<GroupMasterData> editGroup1(int Id)
        {
            return Groupmasterdata.editgroup(Id);
        }
        public void updategroup1(int Id, GroupMasterData updategroup)
        {
             Groupmasterdata.UpdateGroup(Id,updategroup);
        }
        public void deletegroup1(int Id)
        {
            Groupmasterdata.deleteGroupCountry(Id);
        }
        public List<GroupMember> editmember1(int Id)
        {
            return Groupmasterdata.editmember(Id);
        }
        public void UpdateGroupCountry(GroupMasterData groupmaster,int id)
        {
            Groupmasterdata.UpdateGroupCountry(groupmaster, id);
        }
        public void UpdateGroupmember1( int id,GroupMember groupmem)
        {
            Groupmasterdata.UpdateMember(id, groupmem);
        }



    }
}
