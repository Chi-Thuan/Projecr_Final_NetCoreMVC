using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            if (Request.Cookies["token"] != null)
            {
                Response.Cookies["token"].Expires = DateTime.Now.AddDays(-1);
            }
            return View();
        }
    }
}