using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Areas.Admin.Controllers
{
    public class CreateProductController : Controller
    {
        // GET: Admin/CreateProduct
        [AuthenticationAdmin]
        public ActionResult Index()
        {
            return View();
        }
    }
}