using Project.Areas.Admin.BUS;
using Project.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UpdateUser(string id)
        {
            UserBUS userBUS = new UserBUS();
            User user = new User();
            user = userBUS.findUser(id);
            return View();
        }
    }
}