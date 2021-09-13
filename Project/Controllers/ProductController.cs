using Newtonsoft.Json;
using Project.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Project.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(String id)
        {

            var request = new RestRequest(Method.GET);
            var client = new RestClient("https://localhost:44308/listProduct/" + id);

            client.Timeout = -1;

            var body = @"";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var rawResponse = response.Content;

            Product p = JsonConvert.DeserializeObject<Product>(rawResponse);

            string categoryName = "Unknown";
            foreach (Category category in listCategory())
            {
                if (p.category.Equals(category.id))
                {
                    categoryName = category.name;
                    ViewData["categoryName"] = categoryName;
                }
            }

            ViewData["imagePath"] = "https://localhost:44342/Style/default/img/images/" + p.slug + ".jpg";
            ViewData.Model = p;
            ViewData.Model = p;
            return View(p);
        }

        public ActionResult Category()
        {

            string categoryName = Request.QueryString["categoryName"];

            var request = new RestRequest(Method.GET);

            //name==null hien thi laptop loai dell
            if (categoryName == null) { categoryName = "6607bf03-c946-4009-948f-ce53188ccfb8"; }

            var client = new RestClient("https://localhost:44308/findCategory/" + categoryName);
            client.Timeout = -1;

            var body = @"";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var rawResponse = response.Content;

            List<Product> list = JsonConvert.DeserializeObject<List<Product>>(rawResponse);
            


            ViewData["listCategoryName"] = listCategory();
            ViewData["list"] = list;
            ViewData["jpg"] = ".jpg";
            return View(list);

        }
        public List<Category> listCategory()
        {
            var request = new RestRequest(Method.GET);


            var client = new RestClient("https://localhost:44308/listCategory");
            client.Timeout = -1;
            var body = @"";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var rawResponse = response.Content;

            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(rawResponse);


            return categories;
        }


    }
}