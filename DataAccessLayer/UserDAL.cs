using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace Remielsoft.JetSave.DataAccessLayer
{
    public class UserDAL : BaseDataAccess
    {

        private Database myDataBase;
        public UserDAL(Database m_database)
        {
            myDataBase = m_database;
        }
        public int CreateUser(UserDom userdom)
        {
            int UserId;
            String sqlCommand = DBConstant.CREATE_USER_MASTER;
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(sqlCommand);
            myDataBase.AddInParameter(dbCommand, "@First_Name", DbType.String, userdom.FirstName);
            myDataBase.AddInParameter(dbCommand, "@Last_Name", DbType.String, userdom.LastName);
            myDataBase.AddInParameter(dbCommand, "@Middle_Name", DbType.String, userdom.MiddleName);
            myDataBase.AddInParameter(dbCommand, "@Login_Id", DbType.String, userdom.LoginId);
            myDataBase.AddInParameter(dbCommand, "@Password", DbType.String, userdom.Password);
            myDataBase.AddInParameter(dbCommand, "@Email_Id", DbType.String, userdom.EmailId);
            myDataBase.AddInParameter(dbCommand, "@Gender", DbType.String, userdom.Gender);
            myDataBase.AddInParameter(dbCommand, "@Phone", DbType.String, userdom.PhoneNo);
            myDataBase.AddInParameter(dbCommand, "@Mobile", DbType.String, userdom.MobileNo);

            if (userdom.DateOfBirth == DateTime.MinValue)
            {
                myDataBase.AddInParameter(dbCommand, "@DOB", DbType.DateTime, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbCommand, "@DOB", DbType.DateTime, userdom.DateOfBirth);
            }
            myDataBase.AddInParameter(dbCommand, "@MaritalStatus", DbType.String, userdom.MaritalStatus);
            myDataBase.AddInParameter(dbCommand, "@EmpCode", DbType.String, userdom.EmpCode);
            myDataBase.AddInParameter(dbCommand, "@OfficeExtNo", DbType.String, userdom.OfficeExtentionNo);
            myDataBase.AddInParameter(dbCommand, "@Location_Id", DbType.Int32, userdom.UserLocation.LocationId);
            myDataBase.AddInParameter(dbCommand, "@Address", DbType.String, userdom.Address);
            myDataBase.AddInParameter(dbCommand, "@UserTypeId", DbType.Int32, userdom.UserTypeId);
            myDataBase.AddInParameter(dbCommand, "@CreatedBy", DbType.String, userdom.Created_By);
            myDataBase.AddOutParameter(dbCommand, "@out_userId ", DbType.Int32, 10);
            myDataBase.ExecuteNonQuery(dbCommand);
            int.TryParse(myDataBase.GetParameterValue(dbCommand, "@out_userId ").ToString(), out UserId);
            return UserId;
        }

        public void DeleteUserTask(int taskId)
        {
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.DELETE_USER_TASK);
            myDataBase.AddInParameter(dbcommand, "@Task_Id", DbType.Int32, taskId);
            //myDataBase.AddInParameter(dbcommand, "@Modified_By", DbType.String, modifiedBy);
            //myDataBase.AddInParameter(dbcommand, "@Modified_Date", DbType.DateTime, modifieddate);
            myDataBase.ExecuteNonQuery(dbcommand);
        }
        public void CreateUserTask(List<UserTaskMaping> lstUsertask, int userId)
        {
            foreach (UserTaskMaping item in lstUsertask)
            {
                DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.CREATE_USER_TASK_MAPPING);
                myDataBase.AddInParameter(dbCommand, "@in_UserId", DbType.Int32, userId);
                myDataBase.AddInParameter(dbCommand, "@in_UserTask_Id", DbType.Int32, item.UserTaskMappingId);
                myDataBase.AddInParameter(dbCommand, "@in_Description", DbType.String, item.Description);
                myDataBase.AddInParameter(dbCommand, "@in_CreatedBy", DbType.String, item.Created_By);
                myDataBase.ExecuteNonQuery(dbCommand);
            }
        }

        public List<UserDom> ReadUserMaster()
        {
            List<UserDom> lstdom = new List<UserDom>();
            UserDom userdom = null;
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_USER_MASTER);
            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    userdom = GetUserDetailFromDataReader(reader);
                    lstdom.Add(userdom);
                }
            }
            return lstdom;
        }

        public UserDom ReadUserById(int userId)
        {
            UserDom userdom = new UserDom();
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(DBConstant.READ_USER_MASTER);
            myDataBase.AddInParameter(dbCommand, "@UserId", DbType.Int32, userId);

            using (IDataReader reader = myDataBase.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    userdom = GetUserDetailFromDataReader(reader);
                }
            }
            return userdom;
        }

        private UserDom GetUserDetailFromDataReader(IDataReader reader)
        {

            UserDom userdom = new UserDom();
            userdom.UserId = GetIntegerFromDataReader(reader, "User_Id");
            userdom.FirstName = GetStringFromDataReader(reader, "First_Name");
            userdom.MiddleName = GetStringFromDataReader(reader, "Middle_Name");
            userdom.LastName = GetStringFromDataReader(reader, "Last_Name");
            userdom.LoginId = GetStringFromDataReader(reader, "Login_Id");
            userdom.Password = GetStringFromDataReader(reader, "Password");
            userdom.EmailId = GetStringFromDataReader(reader, "Email_Id");
            userdom.PhoneNo = GetStringFromDataReader(reader, "Phone");
            userdom.MobileNo = GetStringFromDataReader(reader, "Mobile");
            userdom.DateOfBirth = GetDateFromReader(reader, "DOB");
            userdom.MaritalStatus = GetStringFromDataReader(reader, "Marital_Status");
            userdom.Gender = GetStringFromDataReader(reader, "Gender");
            userdom.EmpCode = GetStringFromDataReader(reader, "EmpCode");
            //userdom.UserTypeId = new MetaData();
            userdom.UserTypeId = GetIntegerFromDataReader(reader, "UserTypeId");
            userdom.UserLocation = new LocationMaster();
            userdom.UserLocation.LocationId = GetIntegerFromDataReader(reader, "Location_Id");
            //userdom.UserLocation.City = GetStringFromDataReader(reader, "Location_Name");
            userdom.Address = GetStringFromDataReader(reader, "Address");
            userdom.OfficeExtentionNo = GetStringFromDataReader(reader, "OfficeExtentionNo");
            userdom.Created_By = GetStringFromDataReader(reader, "Created_By");
            userdom.Created_Date = GetDateFromReader(reader, "Created_Date");
            userdom.Modified_By = GetStringFromDataReader(reader, "Modified_By");
            userdom.Modified_Date = GetDateFromReader(reader, "Modified_Date");
            userdom.LastLoginDate = GetDateFromReader(reader, "LastLogin_Date");
            return userdom;
        }

        public int UpdateUserMaster(UserDom userdom)
        {
            int userId = 0;
            string sqlcommand = DBConstant.EDIT_USER_MASTER;
            // String sqlcommand = DBContact.Update_User_Master;
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(sqlcommand);
            myDataBase.AddInParameter(dbcommand, "@User_Id", DbType.String, userdom.UserId);
            myDataBase.AddInParameter(dbcommand, "@First_Name", DbType.String, userdom.FirstName);
            myDataBase.AddInParameter(dbcommand, "@Last_Name", DbType.String, userdom.LastName);
            myDataBase.AddInParameter(dbcommand, "@Middle_Name", DbType.String, userdom.MiddleName);
            myDataBase.AddInParameter(dbcommand, "@Login_Id", DbType.String, userdom.LoginId);
            myDataBase.AddInParameter(dbcommand, "@Password", DbType.String, userdom.Password);
            myDataBase.AddInParameter(dbcommand, "@Email_Id", DbType.String, userdom.EmailId);
            myDataBase.AddInParameter(dbcommand, "@Gender", DbType.String, userdom.Gender);
            myDataBase.AddInParameter(dbcommand, "@Phone", DbType.String, userdom.PhoneNo);
            myDataBase.AddInParameter(dbcommand, "@Mobile", DbType.String, userdom.MobileNo);

            if (userdom.DateOfBirth == DateTime.MinValue)
            {
                myDataBase.AddInParameter(dbcommand, "@DOB", DbType.DateTime, DBNull.Value);
            }
            else
            {
                myDataBase.AddInParameter(dbcommand, "@DOB", DbType.DateTime, userdom.DateOfBirth);
            }
            myDataBase.AddInParameter(dbcommand, "@MaritalStatus", DbType.String, userdom.MaritalStatus);
            myDataBase.AddInParameter(dbcommand, "@EmpCode", DbType.String, userdom.EmpCode);
            myDataBase.AddInParameter(dbcommand, "@OfficeExtNo", DbType.String, userdom.OfficeExtentionNo);
            myDataBase.AddInParameter(dbcommand, "@Location_Id", DbType.Int32, userdom.UserLocation.LocationId);
            myDataBase.AddInParameter(dbcommand, "@Address", DbType.String, userdom.Address);
            // myDataBase.AddInParameter(dbcommand, "@Created_By", DbType.String, userdom..Created_By);
            myDataBase.AddInParameter(dbcommand, "@Modified_by", DbType.String, userdom.Modified_By);
            myDataBase.AddInParameter(dbcommand, "@Modified_date", DbType.DateTime, userdom.Modified_Date);
            myDataBase.AddOutParameter(dbcommand, "@out_User_Id ", DbType.Int32, 10);
            myDataBase.ExecuteNonQuery(dbcommand);
            int.TryParse(myDataBase.GetParameterValue(dbcommand, "@out_User_Id ").ToString(), out userId);
            return userId;
        }

        public void DeleteUserMaster(int userid, string modifiedBy, DateTime modifieddate)
        {
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.DELETE_USER_MASTER);
            myDataBase.AddInParameter(dbcommand, "@User_Id", DbType.Int32, userid);
            myDataBase.AddInParameter(dbcommand, "@Modified_By", DbType.String, modifiedBy);
            myDataBase.AddInParameter(dbcommand, "@Modified_Date", DbType.DateTime, modifieddate);
            myDataBase.ExecuteNonQuery(dbcommand);
        }

        public int ValidateUser(String loginId, String password)
        {
            int userId;

            String sqlCommand = DBConstant.VALIDATE_USER_MASTER;
            DbCommand dbCommand = myDataBase.GetStoredProcCommand(sqlCommand);

            myDataBase.AddInParameter(dbCommand, "@in_LoginId", DbType.String, loginId);
            myDataBase.AddInParameter(dbCommand, "in_Password", DbType.String, password);
            myDataBase.AddOutParameter(dbCommand, "@out_userId", DbType.Int32, 10);
            myDataBase.ExecuteNonQuery(dbCommand);
            int.TryParse(myDataBase.GetParameterValue(dbCommand, "@out_userId").ToString(), out userId);

            return userId;
        }

        public UserDom ReadUserByLoginID(String loginId)
        {
            UserDom users = new UserDom();
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.READ_USER_BYLOGIN_ID);
            myDataBase.AddInParameter(dbcommand, "@in_LoginId", DbType.String, loginId);
            using (IDataReader reader = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader.Read())
                {
                    users = GetUserDetailFromDataReader(reader);
                }
            }
            return users;
        }

        public List<UserTaskMaping> ReadUserTaskByUserId(Int32 userId)
        {
            List<UserTaskMaping> lstUserTask = new List<UserTaskMaping>();
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.READ_USERTASK_BY_USERID);
            myDataBase.AddInParameter(dbcommand, "@in_UserId", DbType.Int32, userId);
            using (IDataReader reader = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader.Read())
                {
                    UserTaskMaping userTaskMap = new UserTaskMaping();
                    userTaskMap.MetadataUserTask = new MetaData();
                    userTaskMap.MetadataUserTask.Id = GetIntegerFromDataReader(reader, "MetaDataUserTask_Id");
                    userTaskMap.UserTaskMappingId = GetIntegerFromDataReader(reader, "User_Id");
                    userTaskMap.Description = GetStringFromDataReader(reader, "Description");
                    userTaskMap.Created_By = GetStringFromDataReader(reader, "Created_By");
                    userTaskMap.Created_Date = GetDateFromReader(reader, "Created_Date");
                    userTaskMap.Description = GetStringFromDataReader(reader, "Description");
                    lstUserTask.Add(userTaskMap);
                }
                return lstUserTask;
            }
        }

        public void UpdateLastLoginDate(DateTime LastLogindate, String loginId)
        {
            string sqlquery = "Update master_user set LastLogin_Date='" + LastLogindate + "' where Login_Id='" + loginId + "' and IsDeleted=0";
            DbCommand dbCommand = myDataBase.GetSqlStringCommand(sqlquery);
            myDataBase.ExecuteNonQuery(dbCommand);
        }
    }
}

