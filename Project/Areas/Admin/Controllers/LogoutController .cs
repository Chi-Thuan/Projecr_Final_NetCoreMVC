using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace Project.Areas.Admin.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Admin/Login
        public void Index()
        {
            if (Request.Cookies["token"] != null) {
                Response.Cookies["token"].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Redirect("/admin/login");
        }
    }
}