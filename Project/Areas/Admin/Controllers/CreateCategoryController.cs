using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Areas.Admin.Controllers
{
    public class CreateCategoryController : Controller
    {
        // GET: Admin/CreateCategory
        //[AuthenticationAdmin]
        public ActionResult Index()
        {
            return View();
        }
    }
}