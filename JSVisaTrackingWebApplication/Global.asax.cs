using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace JSVisaTrackingWebApplication
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

        }

        void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.User == null)
            {
                return;
            }
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
               
                if (HttpContext.Current.User.Identity is FormsIdentity)
                {
                    FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                    FormsAuthenticationTicket ticket = (id.Ticket);
                    if (!FormsAuthentication.CookiesSupported)
                    {
                        //If cookie is not supported for forms authentication, then the
                        //authentication ticket is stored in the URL, which is encrypted.
                        //So, decrypt it
                        ticket = FormsAuthentication.Decrypt(id.Ticket.Name);
                    }
                    // Get the stored user-data, in this case, user roles
                    if (!string.IsNullOrEmpty(ticket.UserData))
                    {
                        string userData = ticket.UserData;
                        string[] roles = userData.Split(',');
                        //Roles were put in the UserData property in the authentication ticket
                        //while creating it
                        HttpContext.Current.User =
                          new System.Security.Principal.GenericPrincipal(id, roles);
                    }
                }
            }

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            //HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            //if (cookie != null)
            //{
            //    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            //}
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
