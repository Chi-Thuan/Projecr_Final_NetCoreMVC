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
using System.Text.RegularExpressions;

namespace Project.Models
{
    public class AuthenticationAdmin : AuthorizeAttribute
    {
        string role;

        public AuthenticationAdmin(string role = "ADMIN")
        {
            this.role = role;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            Debug.WriteLine("OnAuthorization");
            HttpCookie cookie = filterContext.HttpContext.Request.Cookies.Get("token");
            if (cookie != null)
            {
                Debug.WriteLine("have token in cookie");
                HandleFetchAPI.getInstance().token = cookie.Value;
                TokenManager.userLogin = TokenManager.ValidateToken(cookie.Value);
                if (this.role == "ADMIN")
                {
                    if (TokenManager.userLogin.role != 0) {
                        filterContext.Result = new RedirectResult("/admin/login");
                    }
                }
                Debug.WriteLine("token : ");
                Debug.WriteLine(cookie.Value);
                Debug.WriteLine("userlogin : ");
                Debug.WriteLine(TokenManager.userLogin);
            }
            else
            {
                Debug.WriteLine("not have token in cookie");
                string tokenURL = filterContext.HttpContext.Request.QueryString["token"];
                if (!String.IsNullOrEmpty(tokenURL))
                {
                    HandleFetchAPI.getInstance().token = tokenURL.ToString();
                    filterContext.HttpContext.Response.Cookies["token"].Value = tokenURL.ToString();
                    TokenManager.userLogin = TokenManager.ValidateToken(tokenURL.ToString());
                    if (this.role == "ADMIN")
                    {
                        filterContext.Result = new RedirectResult("/admin");
                    }
                    else {
                        var url = filterContext.HttpContext.Request.Url;
                        var uri = new Uri(url.ToString());
                        string path = uri.GetLeftPart(UriPartial.Path);
                        filterContext.Result = new RedirectResult(path);
                    }

                    Debug.WriteLine("token : ");
                    Debug.WriteLine(tokenURL.ToString());
                    Debug.WriteLine("userlogin : ");
                    Debug.WriteLine(TokenManager.userLogin);
                }
                else
                {
                    TokenManager.userLogin = null;
                    if (this.role == "ADMIN")
                    {
                        filterContext.Result = new RedirectResult("/admin/login");
                    }

                }

               
            }
           
            
        }

    }
}