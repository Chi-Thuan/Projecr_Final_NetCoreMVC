using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Areas.Admin.Controllers
{
    public class UpdateProductController : Controller
    {
        // GET: Admin/UpdateProduct
        public ActionResult Index(string id)
        {
            return View(id);
        }
    }
}