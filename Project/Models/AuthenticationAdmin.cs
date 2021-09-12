using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using Project.Models;

namespace Project.Models
{
    public class AuthenticationAdmin : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            HttpCookie cookie = filterContext.HttpContext.Request.Cookies.Get("token");
            if (cookie != null)
            {
                HandleFetchAPI.getInstance().token = cookie.Value;
            }
            else
            {
                string tokenURL = filterContext.HttpContext.Request.QueryString["token"];
                  if (!String.IsNullOrEmpty(tokenURL))
                 {
                     HandleFetchAPI.getInstance().token = tokenURL.ToString();
                     filterContext.HttpContext.Response.Cookies["token"].Value = tokenURL.ToString();
                     filterContext.Result = new RedirectResult("/admin");
                 }
               else
                 {
                     filterContext.Result = new RedirectResult("/admin/login");
                  }           
            }
        }

    }
}