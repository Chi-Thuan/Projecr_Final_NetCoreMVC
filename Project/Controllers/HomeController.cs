using Newtonsoft.Json;
using Project.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {

        int amount = 0;
        // GET: Home
        public ActionResult Index()
        {
            ViewData["pageIndex"] = pageNumber();
            return View();
            }
        public ActionResult Page()
        {

            var page = Request.QueryString["page"];
          

            var request = new RestRequest(Method.GET);
            var client = new RestClient("https://localhost:44308/pages/"+ page);
            client.Timeout = -1;

            var body = @"";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var rawResponse = response.Content;

            List<Product> listProducts = JsonConvert.DeserializeObject<List<Product>>(rawResponse);



            ViewData["pageIndex"] = pageNumber();
            ViewData["jpg"] = ".jpg";
            ViewData["listProduct"]=listProducts;

            return View(listProducts);
        }
        public int pageNumber()
        {
            var pageRequest = Request.QueryString["page"];
            var amountRequest = Request.QueryString["amount"];

            if (pageRequest != null && amountRequest != null)
            {
                amount = int.Parse(amountRequest);
            }

            var request = new RestRequest(Method.GET);


            var client = new RestClient("https://localhost:44308/listProduct");
            client.Timeout = -1;

            var body = @"";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var rawResponse = response.Content;

            List<Product> list = JsonConvert.DeserializeObject<List<Product>>(rawResponse);


            int pageIndex = 1;

            // int pageIndex = list.Count() / 9;
            //if (list.Count()%9 != 0)
            // {
            //     pageIndex = pageIndex + 1;
            // }

            return pageIndex;
        }


    }
}