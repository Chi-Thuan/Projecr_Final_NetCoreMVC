using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Areas.Admin.Controllers
{
    public class CreateSubCategoryController : Controller
    {
        // GET: Admin/CreateSubCategory
        [AuthenticationAdmin]
        public ActionResult Index()
        {
            return View();
        }
    }
}