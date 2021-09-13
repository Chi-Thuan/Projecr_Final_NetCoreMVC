using Newtonsoft.Json;
using Project.Areas.Admin.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Project.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var client = new RestClient("https://localhost:44308/listCategory");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var body = @"";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string rawResponse = response.Content;
            List<Category> listCategory = JsonConvert.DeserializeObject<List<Category>>(rawResponse);
            ViewBag.listCategory = listCategory;
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(string categoryName)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44308/");
                var response = client.PostAsJsonAsync("create-category", categoryName).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                    Json("Thao tác thất bại");
            }
            return RedirectToAction("Index");
        }
    }
}