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
using Project.Model;

namespace Project.Areas.Admin.Controllers
{
   
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        [AuthenticationAdmin]
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage response = await HandleFetchAPI.getInstance().Call("/get-list-user", Response);
            var data = response.Content.ReadAsStringAsync().Result;
            return View();
        }
    }
}