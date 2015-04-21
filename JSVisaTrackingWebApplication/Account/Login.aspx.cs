using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using JSVisaTrackingWebApplication.Shared;

namespace JSVisaTrackingWebApplication.Account
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        #region Private Method

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (ValidateUser())
            {
                UserBAL userBL = new UserBAL();
                UserDom user = userBL.ReadUserByLoginId(LoginUser.UserName);
                if (user.UserTypeId == 2 || user.UserTypeId == 3)
                {
                    DateTime lastloginDate = user.LastLoginDate;
                    DateTime CurrentDate = DateTime.Today;
                    TimeSpan ts = CurrentDate.Subtract(lastloginDate);
                    int Days = Convert.ToInt32(ts.TotalDays);
                    if (Days > 10)
                    {
                        ScriptManager.RegisterClientScriptBlock(LoginUser, GetType(), "a", "alert('Your password has been expired..')", true);
                    }
                    else if (user == null)
                    {
                        LoginUser.FailureText = "User not Found..";
                        return;
                    }
                    else
                    {
                        FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, LoginUser.RememberMeSet);
                        UpdateLoginDate(DateTime.Now, user.LoginId);
                        Session["LoginUser"] = user.FullName;
                        Session["MobileNo"] = user.MobileNo;
                        Session["EmailId"] = user.EmailId;
                    }
                }
                else
                {
                    FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, LoginUser.RememberMeSet);
                    UpdateLoginDate(DateTime.Now, user.LoginId);
                    Session["LoginUser"] = user.FullName;
                    Session["MobileNo"] = user.MobileNo;
                    Session["EmailId"] = user.EmailId;
                }
            }
            else
            {
                LoginUser.FailureText = "User name or password incorrect. Please try again..";
            }
        }
        private bool ValidateUser()
        {
            UserBAL userBL = new UserBAL();
            if (userBL.ValidateUser(LoginUser.UserName, LoginUser.Password) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void UpdateLoginDate(DateTime LastLogindate, String loginId)
        {
            UserBAL userBAL = new UserBAL();
            userBAL.UpdateLastLoginDate(LastLogindate, loginId);
        }
        #endregion

        
    }
}
