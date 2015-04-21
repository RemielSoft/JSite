using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.Text;


namespace JSVisaTrackingWebApplication.Shared
{
    public class BasePage : Page
    {
        public UserDom LoggedInUser
        {
            get
            {
                if (HttpContext.Current.Session["UserDetails"]==null ||
                    CurrentUserName.ToUpper() != ((UserDom)HttpContext.Current.Session["UserDetails"]).LoginId
                    )
                {
                    String CurrentUser = this.CurrentUserName;
                    string userId = this.CurrentUserId;
                    UserDom user = new UserDom();
                    try
                    {
                        user = ReadUserByLoginId(userId);
                        if (Session["AgentId"] != null)
                        {
                            user.AgentId = Convert.ToInt32(Session["AgentId"].ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        throw exp;
                    }
                    HttpContext.Current.Session["UserDetails"] = user;
                }

               

                return (UserDom)HttpContext.Current.Session["UserDetails"];
            }
        }


        public String CurrentUserId
        {
            get
            {
                HttpCookie objHTTPCk = HttpContext.Current.Request.Cookies.Get("myCookie");
                String userId = "";
                if (objHTTPCk != null && objHTTPCk.Value != null)
                {
                    userId = objHTTPCk["userId"];
                }
                return userId;
            }
        }

        public String CurrentUserName
        {
            get
            {
                String currentUser = Page.User.Identity.Name;
                if (currentUser.IndexOf('\\') > -1)
                {
                    currentUser = currentUser.Substring(currentUser.IndexOf('\\') + 1, currentUser.Length - currentUser.IndexOf('\\') - 1);
                }
                return currentUser;
            }
        }

        private UserDom ReadUserByLoginId(string loginId)
        {
            UserBAL userBal = new UserBAL();
            UserDom user=userBal.ReadUserByLoginId(loginId);
            return user;
        }

        public void BindDropDown(DropDownList ddl, string dataTextField, string dataValueField, object dataSource)
        {
            ddl.Items.Clear();
            ddl.DataSource = dataSource;
            ddl.DataTextField = dataTextField;
            ddl.DataValueField = dataValueField;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select--", "0"));
            ddl.SelectedValue = "0";
        }

        public void BindDropDownData(DropDownList ddl, string dataTextField, string dataValueField, object dataSource)
        {

            ddl.DataSource = dataSource;
            ddl.DataTextField = dataTextField;
            ddl.DataValueField = dataValueField;
            ddl.DataBind();
        }
        public void ShowMessage(string message)
        {
            String cleanMessage = message.Replace("'", "\\'");
            string script = "<script type=\"text/javascript\">alert('" + cleanMessage + "');</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", script);
        }

        /// <summary>
        /// Message Box for Controls[Manveer,14.03.2013]
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ctl"></param>
        public void Alert(string msg, Control ctl)
        {
            ScriptManager.RegisterStartupScript(ctl, Type.GetType("System.String"), "myscript", "alert('" + msg + "');", true);
        }

        /// <summary>
        /// Message Box for particular Page.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ctl"></param>
        /// <param name="pageName"></param>
        public void Alert(string msg, Control ctl, string pageName)
        {
            ScriptManager.RegisterStartupScript(ctl, Type.GetType("System.String"), "myscript", "alert('" + msg + "');window.location ='" + pageName + "'", true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ctl"></param>
        /// <param name="res"></param>
        bool track = false;
        public bool Confirm(string msg, Control ctl)
        {
            if (!track)
            {
                ScriptManager.RegisterStartupScript(ctl, Type.GetType("System.String"), "myscript", "var res = confirm('" + msg + "')", true);
                track = true;
            }
            else
            {
                track = false;
            }
            return track;
        }

        public void ShowMessageWithUpdatePanel(String message)
        {
            String cleanMessage = message.Replace("'", "\\'");
            String script = "alert('" + cleanMessage + "');";
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "alert", script, true);

        }



    }
}