using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Remielsoft.JetSave.DataAccessLayer
{
    public class GroupMasterDataAccess:BaseDataAccess
    {
        private Database myDataBase;
      
        public GroupMasterDataAccess(Database m_database)
        {
            myDataBase = m_database;
        }
        #region group
        public List<GroupMasterData> InsertGroupDetail(GroupMasterData groupmaster)
        {
            int GroupId;
            int success;

            List<GroupMasterData> lst=new List<GroupMasterData>();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.Insert_GroupDetai);
            myDataBase.AddInParameter(dbCommand,"@_inGroupName",DbType.String ,groupmaster.GroupName);
            myDataBase.AddInParameter(dbCommand, "@_inGroupArea", DbType.String, groupmaster.GroupArea);
                        
            myDataBase.AddOutParameter(dbCommand, "@GroupId", DbType.Int32, 20);
            myDataBase.AddOutParameter(dbCommand, "@Success", DbType.Int32, 10);
            myDataBase.ExecuteNonQuery(dbCommand);
            int.TryParse(myDataBase.GetParameterValue(dbCommand, "@Success").ToString(), out success);
            int.TryParse(myDataBase.GetParameterValue(dbCommand, "@GroupId").ToString(), out GroupId);

            groupmaster.Success = success;
            groupmaster.GroupId = GroupId;

            lst.Add(groupmaster);
            return lst;
        }

        public void InsertGroupToCountry(GroupMasterData groupMaster)
        {
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("insert into Group_to_country(FK_Group_ID,Country_ID) values(" + groupMaster.GroupId.ToString() + "," + groupMaster.CountryId.ToString() + ")");
            myDataBase.ExecuteNonQuery(dbCommand);


        }
        #endregion

        #region member
        public List<GroupMasterData> ReadGroupMaster()
        {
            List<GroupMasterData> lst = new List<GroupMasterData>();

            // DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.LIST_AGENT);
            DbCommand dbcommand = myDataBase.GetSqlStringCommand("select * from Group_Master");
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    GroupMasterData groupmaster = new GroupMasterData();
                    groupmaster.GroupId = GetIntegerFromDataReader(reader1,"Group_ID");
                    groupmaster.GroupName = GetStringFromDataReader(reader1, "Group_Name");
                    lst.Add(groupmaster);
                    

                }
            }
            return lst;

        }

        #endregion

        #region insertmember

        public void insertMember(GroupMember groupMember)
        {
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.Insert_MemberDetail);
            myDataBase.AddInParameter(dbCommand, "@GroupId", DbType.Int32, groupMember.groupName);
            myDataBase.AddInParameter(dbCommand, "@MemberName", DbType.String, groupMember.MemberName);
            myDataBase.ExecuteNonQuery(dbCommand);

        }
        #endregion

        public List<GroupMember> bindgroupmember(int Id)
        {

            List<GroupMember> lstmember = new List<GroupMember>();
            DbCommand dbcommand = myDataBase.GetSqlStringCommand("select * from Group_Member where FK_Group_ID = '"+Id+"'");
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    GroupMember groupmember = new GroupMember();
                    groupmember.groupName = GetIntegerFromDataReader(reader1, "ID");
                    groupmember.groupmember = GetStringFromDataReader(reader1, "Member_Name");
                    lstmember.Add(groupmember);


                }
            }
            return lstmember;

        }
        #region readgroupmember
        public List<GroupMember> ReadMember(string Name)
        {
            List<GroupMember> lst = new List<GroupMember>();

            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.Read_MemberName);
            myDataBase.AddInParameter(dbcommand, "@Name", DbType.String, Name);
            //DbCommand dbcommand = myDataBase.GetSqlStringCommand("select * from Group_Master");
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    GroupMember groupmembername = new GroupMember();
                    groupmembername.groupMasterData = new GroupMasterData();
                    groupmembername.groupMasterData.GroupName = GetStringFromDataReader(reader1, "Group_Name");
                    //groupmembername.groupName = GetIntegerFromDataReader(reader1, "FK_Group_ID");
                    groupmembername.MemberName = GetStringFromDataReader(reader1, "Member_Name");
                    lst.Add(groupmembername);


                }
            }
            return lst;

        }
        #endregion 


       #region readgroupcountry
        public List<GroupMasterData> ReadCountry(int id)
        {
            List<GroupMasterData> lst = new List<GroupMasterData>();

            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.Read_Country);
            myDataBase.AddInParameter(dbcommand, "@Id", DbType.String, id);
            //DbCommand dbcommand = myDataBase.GetSqlStringCommand("select * from Group_Master");
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    GroupMasterData masterdata = new GroupMasterData();
                    masterdata.GroupName = GetStringFromDataReader(reader1, "Group_Name");
                    masterdata.GroupId = GetIntegerFromDataReader(reader1, "FK_Group_ID");
                    masterdata.CountryId = GetIntegerFromDataReader(reader1, "country_ID");
                    masterdata.CountryName = GetStringFromDataReader(reader1, "COUNTRY_NAME");
                    lst.Add(masterdata);


                }
            }
            return lst;

        }
#endregion 

        
        public List<GroupMasterData> ReadCounryIdByID(int id)
        {
            List<GroupMasterData> lst = new List<GroupMasterData>();

            DbCommand dbcommand = myDataBase.GetSqlStringCommand("select * from Group_to_country where FK_Group_ID='"+id+"'");
            //myDataBase.AddInParameter(dbcommand, "@Id", DbType.String, id);
            //DbCommand dbcommand = myDataBase.GetSqlStringCommand("select * from Group_Master");
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    GroupMasterData masterdata = new GroupMasterData();

                    masterdata.GroupId = GetIntegerFromDataReader(reader1, "FK_Group_ID");
                    masterdata.CountryId = GetIntegerFromDataReader(reader1, "country_ID");
                   
                    lst.Add(masterdata);


                }
            }
            return lst;

        }


        #region edit group
        public List<GroupMasterData> editgroup(int id)
        {
            List<GroupMasterData> lst = new List<GroupMasterData>();

            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.Edit_Group);
            myDataBase.AddInParameter(dbcommand, "@Id", DbType.String, id);
            //DbCommand dbcommand = myDataBase.GetSqlStringCommand("select * from Group_Master where Group_ID ='"+id+"' ");
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    GroupMasterData Editmasterdata = new GroupMasterData();
                    Editmasterdata.GroupName = GetStringFromDataReader(reader1, "Group_Name");
                    Editmasterdata.GroupId = GetIntegerFromDataReader(reader1, "Group_ID");
                    Editmasterdata.GroupArea = GetStringFromDataReader(reader1, "Group_Area");
                    
                    lst.Add(Editmasterdata);


                }
            }
            return lst;

        }
        #endregion 

        #region updategroup
        public void UpdateGroup(int id, GroupMasterData Updategroupmaster)
        {
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.Update_Group);
            myDataBase.AddInParameter(dbcommand, "@Id", DbType.Int32, id);
            myDataBase.AddInParameter(dbcommand, "@GroupName", DbType.String, Updategroupmaster.GroupName);
            myDataBase.AddInParameter(dbcommand, "@grouparea", DbType.String, Updategroupmaster.GroupArea);
            myDataBase.ExecuteNonQuery(dbcommand);
        }
        #endregion

        #region editmember
        public List<GroupMember> editmember(int id)
        {
            List<GroupMember> lst = new List<GroupMember>();

            // DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.Edit_Group);
            //myDataBase.AddInParameter(dbcommand, "@Id", DbType.String, id);
            DbCommand dbcommand = myDataBase.GetSqlStringCommand("select * from Group_Member where ID ='" + id + "' ");
            using (IDataReader reader1 = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader1.Read())
                {
                    GroupMember Editmemberdata = new GroupMember();
                    Editmemberdata.groupMasterData = new GroupMasterData(); 
                    Editmemberdata.MemberName = GetStringFromDataReader(reader1, "Member_Name");
                    //Editmemberdata.groupMasterData.GroupId = GetIntegerFromDataReader(reader1, "ID");
                    Editmemberdata.groupName = GetIntegerFromDataReader(reader1, "ID");
                    
                    
                    lst.Add(Editmemberdata);


                }
            }
            return lst;
        }
                  
       #endregion

        public void UpdateGroupCountry(GroupMasterData updategroup,int id)
        {
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("update Group_to_country set FK_Group_ID='"+updategroup.GroupId+"',Country_ID='"+updategroup.CountryId+"' where FK_Group_ID='"+id+"'");
            myDataBase.ExecuteNonQuery(dbCommand);


        }

        public void deleteGroupCountry( int id)
        {
            DbCommand dbCommand = myDataBase.GetSqlStringCommand("delete from Group_to_country where FK_Group_ID='" + id + "'");
            myDataBase.ExecuteNonQuery(dbCommand);


        }

        public void UpdateMember(int id, GroupMember groupmemberupdate)
        {
           
            DbCommand dbcommand = myDataBase.GetSqlStringCommand("update Group_member set FK_Group_ID='" + groupmemberupdate.groupName + "',Member_Name='" + groupmemberupdate.MemberName + "' where ID='" + id + "' ");
            
            myDataBase.ExecuteNonQuery(dbcommand);
        }
    }
}
