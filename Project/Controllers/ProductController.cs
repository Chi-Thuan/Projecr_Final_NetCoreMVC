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

            ViewData["imagePath"] = "https://localhost:44342/Style/default/img/images/" + p.slug + ".jpg";

            ViewData.Model = p;




            return View(p);
        }




    }  
}