using JSVisaTrackingWebApplication.Shared;
using Remielsoft.JetSave.BusinessAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSVisaTrackingWebApplication
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        BasePage basePage = new BasePage();
        UserBAL userBal = new UserBAL();
        AgentBAL agentBal = new AgentBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
            //if (basePage.LoggedInUser.UserTypeId == Convert.ToInt32(UserType.Admin) && basePage.LoggedInUser.UserTypeId == Convert.ToInt32(UserType.SuperAdmin))
            //{
            //    agentMenuSection.Visible = false;
            //    adminMenuSection.Visible = true;
            //}
            //else
            //{
            //    agentMenuSection.Visible = true;
            //    adminMenuSection.Visible = false;
            //}

            HttpCookie getcookies = Request.Cookies["myCookie"];
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            if (getcookies != null)
            {

                menulogin.Visible = true;
                LeaderBoardLogin3.Visible = false;
            }
            else
            {
                menulogin.Visible = false;
                LeaderBoardLogin3.Visible = true;
            }
            #region Assign task Admin And Agent
            if (!IsPostBack)
            {
                UserDom user = new UserDom();
                Agent agent = new Agent();
                user = userBal.ReadUserByLoginId(basePage.LoggedInUser.LoginId);


                if (basePage.LoggedInUser.UserTypeId != Convert.ToInt32(UserType.Admin) && basePage.LoggedInUser.UserTypeId != Convert.ToInt32(UserType.SuperAdmin))
                {

                    viewConsignment.Visible = false;
                    //updateConsignment.Visible = false;
                    addVisaForm.Visible = false;
                    //showvisaForm.Visible = false;
                    addVisaInfo.Visible = false;
                    viewVisaInfo.Visible = false;
                    addHoliday.Visible = false;
                    holidayList.Visible = false;
                    addAgent.Visible = false;
                    agentEditUpdate.Visible = false;
                    //listAgent.Visible = false;
                    //exportAgent.Visible = false;
                    //agentEmailList.Visible = false;
                    admin.Visible = false;
                    newsLetter.Visible = false;
                    viewnewsLetter.Visible = false;
                    invoiceList.Visible = false;
                    // printInvoice.Visible = false;
                    billRegister.Visible = false;
                    city.Visible = false;
                    agentMenuSection.Visible = false;

                    #region Task Assign
                    //for (int i = 0; i < user.UserTask.Count; i++)
                    //{
                    //    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.ViewConsignment))))
                    //    {
                    //        viewConsignment.Visible = true;
                    //    }

                    //    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.UpdateConsignmentStatus))))
                    //    {
                    //        //updateConsignment.Visible = true;
                    //    }
                    //    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.AddVisaForm))))
                    //    {
                    //        addVisaForm.Visible = true;
                    //    }

                    //    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.ViewVisaForm))))
                    //    {
                    //        showvisaForm.Visible = true;
                    //    }

                    //    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.AddVisaInfo))))
                    //    {
                    //        addVisaInfo.Visible = true;
                    //    }

                    //    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.ViewVisaInfo))))
                    //    {
                    //        viewVisaInfo.Visible = true;
                    //    }

                    //    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.AddHoliday))))
                    //    {
                    //        addHoliday.Visible = true;
                    //    }

                    //    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.ViewHoliday))))
                    //    {
                    //        holidayList.Visible = true;
                    //    }

                    //    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.AddAgent))))
                    //    {
                    //        addAgent.Visible = true;
                    //    }

                    //    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.ManageAgent))))
                    //    {
                    //        agentEditUpdate.Visible = true;
                    //    }

                    //    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.AgentList))))
                    //    {
                    //        //listAgent.Visible = true;
                    //    }
                    //    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.ExportAgent))))
                    //    {
                    //        // exportAgent.Visible = true;
                    //    }

                    //    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.AgentEmailList))))
                    //    {
                    //        // agentEmailList.Visible = true;
                    //    }

                    //    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.Admin))))
                    //    {
                    //        admin.Visible = true;
                    //    }
                    //    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.AddNewsLetter))))
                    //    {
                    //        newsLetter.Visible = true;
                    //    }
                    //    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.ViewNewsLetter))))
                    //    {
                    //        viewnewsLetter.Visible = true;
                    //    }
                    //    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.InvoiceReceiptPrinting))))
                    //    {
                    //        invoiceList.Visible = true;
                    //    }

                    //    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.InvoicePrinting))))
                    //    {
                    //        // printInvoice.Visible = true;
                    //    }

                    //    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.InvoiceReprinting))))
                    //    {
                    //        //reprintInvoice.Visible = true;
                    //    }

                    //    if (basePage.LoggedInUser.UserTask[i].MetadataUserTask.Id.Equals(Convert.ToInt32((UserTaskId.AddCity))))
                    //    {
                    //        city.Visible = true;
                    //    }
                    //}
                    #endregion
                }


                //  int agentlogin = agentBal.ValidateAgent(LoginUser.UserName, LoginUser.Password);

                if (Session["agentValidate"] != null)
                {
                    bool b = (bool)Session["agentValidate"];
                    if (b)
                    {
                        viewConsignment.Visible = true;
                        //showvisaForm.Visible = true;
                        //viewVisaInfo.Visible = false;
                        holidayList.Visible = true;
                        viewnewsLetter.Visible = true;
                        invoiceList.Visible = true;
                        billRegister.Visible = true;
                        Liagent.Visible = false;
                        viewVisaInfo.Visible = true;
                        adminMenuSection.Visible = false;
                        agentMenuSection.Visible = true;

                    }
                }
                else
                {
                    agentMenuSection.Visible = false;
                    adminMenuSection.Visible = true;
                }
            }

            #endregion
        }

        #region Private Method


        private bool ValidateAgent()
        {
            AgentBAL agentBal = new AgentBAL();
            if (agentBal.ValidateAgent(LoginUser.UserName, LoginUser.Password) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            FormsAuthentication.SignOut();
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

        protected void btnSave_Click(object sender, EventArgs e)
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
                        string role = string.Empty;
                        if (user.UserTypeId == 1)
                        {
                            role = "Admin";
                        }
                        else if (user.UserTypeId == 2)
                        {
                            role = "CompanyUser";
                        }
                        else if (user.UserTypeId == 3)
                        {
                            role = "AgentUser";
                        }
                        else if (user.UserTypeId == 4)
                        {
                            role = "SuperAdmin";
                        }

                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.FullName, DateTime.Now, DateTime.Now.AddMinutes(30), false, role);
                        string encTicket = FormsAuthentication.Encrypt(ticket);

                        HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                        Response.Cookies.Add(faCookie);
                        //HttpCookie MyCookies = new HttpCookie("myCookie");
                        //MyCookies.Values.Add("userId", user.LoginId.ToString());
                        //Response.Cookies.Add(MyCookies);
                        //Session["LoginId"] = user.LoginId;
                        //Response.Redirect("Index.aspx");
                        //FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, LoginUser.RememberMeSet);
                        //UpdateLoginDate(DateTime.Now, user.LoginId);

                    }
                }
                else
                {
                    // added by divaker
                    //if (chkRem.Checked)
                    //{
                    //    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                    //    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                    //}
                    //else
                    //{
                    //    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                    //    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

                    //}
                    //Response.Cookies["UserName"].Value = UserName.Text.Trim();
                    //Response.Cookies["Password"].Value = Password.Text.Trim();



                    string role = string.Empty;
                    if (user.UserTypeId == 1)
                    {
                        role = "Admin";
                    }
                    else if (user.UserTypeId == 2)
                    {
                        role = "CompanyUser";
                    }
                    else if (user.UserTypeId == 3)
                    {
                        role = "AgentUser";
                    }
                    else if (user.UserTypeId == 4)
                    {
                        role = "SuperAdmin";
                    }
                    // var userRoles = Roles(UserId, SFConfig.ApplicationName, SFConfig.RoleDBConnString); 
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(user.UserId, user.FullName, DateTime.Now, DateTime.Now.AddMinutes(30), false, role, FormsAuthentication.FormsCookiePath);
                    string encTicket = FormsAuthentication.Encrypt(ticket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(faCookie);

                    HttpCookie MyCookies = new HttpCookie("myCookie");
                    MyCookies.Values.Add("userId", user.LoginId.ToString());
                    Response.Cookies.Add(MyCookies);
                    //FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, LoginUser.RememberMeSet);
                    //UpdateLoginDate(DateTime.Now, user.LoginId);
                    //Session["LoginUser"] = user.FullName;
                    //Session["MobileNo"] = user.MobileNo;
                    //Session["EmailId"] = user.EmailId;
                    Session["LoginId"] = user.UserId;
                    Session["AgentId"] = null;

                    bool adminVal = ValidateUser();
                    Session["adminValidate"] = adminVal;


                    Response.Redirect("Index.aspx");
                }
            }
            else if (ValidateAgent())
            {


                Agent agent = new Agent();
                UserDom user = new UserDom();






                agent = agentBal.ReadAgentById(LoginUser.UserName);

                string role = string.Empty;

                role = "AgentUser";


                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(agent.AgentLocationId, agent.AgentName, DateTime.Now, DateTime.Now.AddMinutes(30), false, role, FormsAuthentication.FormsCookiePath);
                string encTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(faCookie);
                HttpCookie MyCookies = new HttpCookie("myCookie");
                MyCookies.Values.Add("userId", agent.AgentName.ToString());
                //  basePage.LoggedInUser.LoginId = agent.AgentLocationId.ToString();
                Session["AgentId"] = agent.AgentId;
                Response.Cookies.Add(MyCookies);
                Session["LocationId"] = agent.AgentLocationId;
                bool agentVal = ValidateAgent();
                Session["agentValidate"] = agentVal;

                Response.Redirect("Index.aspx");
            }
            else
            {
                Response.Write("<Script language='javascript'>alert('Your User Id or Password is incorrect. please try again');</script>");
            }
        }

        protected void HeadLoginStatus_LoggedOut(object sender, EventArgs e)
        {

            HttpCookie getcookies = Request.Cookies["myCookie"];
            if (getcookies != null)
            {
                getcookies.Values["userId"] = null;
                getcookies.Value = null;
                Request.Cookies["myCookie"].Expires = DateTime.Now.AddSeconds(-1d);
                Response.Cookies.Add(getcookies);
            }
            Session["LocationId"] = null;
            Session["agentValidate"] = null;
            Session["LoginId"] = null;
            Session.Clear();
            Session.Abandon();
            Response.AppendHeader("Cache-Control", "no-store");
            Response.Expires = -1500;
            Response.CacheControl = "no-cache";
            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");
            FormsAuthentication.SignOut();
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            Response.Redirect("AmexPayment.aspx");
        }
    }
}

