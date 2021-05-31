using System;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            Console.Write("xi chao moi ngoiw nha");
            return View();
        }

        [Route("/details?name={xinchao}")]
        [HttpGet]
        public ActionResult Details()
        {

            Console.WriteLine("xi chao moi ngoiw nha");

            return View();
        }
    }
}