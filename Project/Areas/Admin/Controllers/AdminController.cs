using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using Project.Models;
using System.Net.Http;

namespace Project.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        //public ActionResult Index()
        //{
        //    return View();
        // }

        // GET: Admin/Admin
        [AuthenticationAdmin]
        public async Task<ActionResult> Index()
        {
           // HttpResponseMessage response = await HandleFetchAPI.getInstance().Call("/get-list-user", Response);
           // var data = response.Content.ReadAsStringAsync().Result;
            return View();
        }
    }
}