using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.Web.Configuration;
using JSVisaTrackingWebApplication.Shared;

namespace JSVisaTrackingWebApplication
{
    public partial class UserTaskMapping : System.Web.UI.Page
    {
        MetaDataBal metadataBAL = new MetaDataBal();
        UserBAL userBal = new UserBAL();
        int UserId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["UserId"] != null)
                {
                    UserId = Convert.ToInt32(Request.QueryString["UserId"]);
                    SerchData(UserId);
                }

                //BindCheckBoxList();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //BasePage basepage=new BasePage();
            //List<UserTaskMaping> lst = new List<UserTaskMaping>();
            //lst = userBal.ReadUserTask(UserId);
            //BindCheckBoxList();
            //foreach (ListItem item in chbxUserTask.Items)
            //{
            //    foreach (UserTaskMaping pop in lst)
            //    {
            //        if (Convert.ToInt32(item.Value) == pop.MetadataUserTask.Id)
            //        {
            //            item.Selected = true;
            //            userBal.DeleteUserTask(UserId,basepage.LoggedInUser.LoginId,DateTime.Now);
            //        }
            //    }
            //}
            UserDom user = new UserDom();
            user.UserId = Convert.ToInt32(hdfldUserId.Value);
            user.UserTask = new List<UserTaskMaping>();
            foreach (ListItem item in chbxUserTask.Items)
            {
                if (item.Selected == true)
                {
                    UserTaskMaping usertaskMap = new UserTaskMaping();
                    usertaskMap.UserTaskMappingId = Convert.ToInt32(item.Value);
                    usertaskMap.Description = item.Text;
                    usertaskMap.Created_By = "Admin";
                    usertaskMap.Created_Date = DateTime.Now;
                    user.UserTask.Add(usertaskMap);
                }
            }
            userBal.CreateUserTask(user.UserTask, user.UserId);
            ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "a", "alert('User Task Mapping Updated successfully...')", true);
            chbxUserTask.Enabled = false;
            Response.Redirect("UserMaster.aspx");
        }

        private void SerchData(int UserId)
        {
            UserBAL userBal = new UserBAL();
            UserDom user = new UserDom();
            user = userBal.ReadUserById(UserId);
            lblUserName.Text = user.FirstName + " " + user.MiddleName + " " + user.LastName;
            hdfldUserId.Value = user.UserId.ToString();
            List<UserTaskMaping> lst = new List<UserTaskMaping>();
            lst = userBal.ReadUserTask(UserId);
            BindCheckBoxList();
            //foreach (ListItem item in chbxUserTask.Items)
            //{
            //    item.Selected = false;
            //}

            foreach (ListItem item in chbxUserTask.Items)
            {
                foreach (UserTaskMaping pop in lst)
                {
                    if (Convert.ToInt32(item.Value) == pop.MetadataUserTask.Id)
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        public void BindCheckBoxList()
        {
            List<MetaData> lst = new List<MetaData>();
            lst = metadataBAL.ReadMetaDataUserTask();
            chbxUserTask.DataSource = lst;
            chbxUserTask.DataTextField = "Name";
            chbxUserTask.DataValueField = "Id";
            chbxUserTask.DataBind();
        }

    }
}