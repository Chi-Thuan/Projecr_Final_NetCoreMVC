using Newtonsoft.Json;
using Project.Areas.Admin.BUS;
using Project.Areas.Admin.Model;
using RestSharp;
using SlugGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> listProduct { set; get; }

        // GET: Admin/Product
        public List<Product> getAPIListProductByNumberPage(int page)
        {
            var client = new RestClient("https://localhost:44308/listProductPage/" + page);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var body = @"";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string rawResponse = response.Content;
            List<Product> list = JsonConvert.DeserializeObject<List<Product>>(rawResponse);
            return list;
        }

        public ActionResult ListProduct(int page)
        {
            List<Product> list = new List<Product>();
            list = getAPIListProductByNumberPage(page);
            listProduct = list;
            ViewBag.listProduct = listProduct;
            return View();
        }
        public ActionResult CreateProduct()
        {
            setCategoryViewBag();

            return View();
        }

        public void setCategoryViewBag(string selectedId = null)
        {
            var client = new RestClient("https://localhost:44308/get-list-category");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var body = @"";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string rawResponse = response.Content;
            List<Category> listCategory = JsonConvert.DeserializeObject<List<Category>>(rawResponse);
            ViewBag.list = new SelectList(listCategory, "id", "name", selectedId);
        }


        [HttpPost]
        public ActionResult AddProduct()
        {
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;
                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("/Content/img/"), fname);
                        file.SaveAs(fname);
                    }
                    // Returns message that successfully uploaded  
                    return RedirectToAction("ListProduct", "Product", new { @page = 1 });
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }

        }

        public ActionResult UpdateProduct(string id)
        {
            Product productUpdate = listProduct.Find(index => index.id.Equals(id));
            setCategoryViewBag(productUpdate.category);
            ViewBag.product = productUpdate;
            return View();
        }
    }
}