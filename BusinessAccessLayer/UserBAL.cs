using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DataAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Transactions;

namespace Remielsoft.JetSave.BusinessAccessLayer
{
    public class UserBAL : BaseBusinessAccess
    {
        private Database myDataBase;
        private UserDAL userdal;
        public UserBAL()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            userdal = new UserDAL(myDataBase);
        }

        public int CreateUser(UserDom userdom)
        {
            int userid = 0;
            userid = userdal.CreateUser(userdom);
            return userid;
        }

        public List<UserDom> ReadUserMaster()
        {
            List<UserDom> lstdom = new List<UserDom>();
            lstdom = userdal.ReadUserMaster();
            return lstdom;
        }
        public int UpdateUserMaster(UserDom userdom)
        {
            int userid = 0;
            userid = userdal.UpdateUserMaster(userdom);
            return userid;
        }

        public void DeleteUserMaster(int userid, string modifiedby, DateTime modifieddate)
        {
            userdal.DeleteUserMaster(userid, modifiedby, modifieddate);
        }
        public UserDom ReadUserById(int userid)
        {
            UserDom userdom = new UserDom();
            userdom = userdal.ReadUserById(userid);
            return userdom;
        }

        public int ValidateUser(String loginName, String password)
        {
            Int32 userId = 0;

            try
            {
                userId = userdal.ValidateUser(loginName, password);
            }
            catch (Exception exp)
            {
                throw exp;
            }

            return userId;
        }
        public void CreateUserTask(List<UserTaskMaping> lstUsertask, int userId)
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, base.C_TRANSACTIONSCOPE_ISOLATION_LEVEL))
            {
                userdal.DeleteUserTask(userId);
                userdal.CreateUserTask(lstUsertask, userId);
                transactionScope.Complete();
            }
        }
        //public void DeleteUserTask(int taskId, string modifiedBy, DateTime modifieddate)
        //{
        //    userdal.DeleteUserTask(taskId, modifiedBy, modifieddate);
        //}
        public UserDom ReadUserByLoginId(String loginId)
        {
            UserDom user = userdal.ReadUserByLoginID(loginId);
            try
            {
                user.UserTask = userdal.ReadUserTaskByUserId(user.UserId);
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return user;
        }
        public List<UserTaskMaping> ReadUserTask(int UserID)
        {
            List<UserTaskMaping> lstTask = new List<UserTaskMaping>();
            lstTask = userdal.ReadUserTaskByUserId(UserID);
            return lstTask;
        }
        public void UpdateLastLoginDate(DateTime LastLogindate, String loginId)
        {
            userdal.UpdateLastLoginDate(LastLogindate, loginId);
        }

    }
}
