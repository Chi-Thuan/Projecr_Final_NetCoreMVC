using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Project.Models
{
    public class FetchAPI
    {
        public string token = "";
        public async Task<HttpResponseMessage> Call(string endPoint = "", HttpResponseBase Response = null, string BASE_URL = "https://localhost:44308")
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(BASE_URL);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.token);
            HttpResponseMessage response = await httpClient.GetAsync(endPoint);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                Response.Redirect("/admin/login");
            }
            return response;
        }
    }

    public class HandleFetchAPI
    {
        private static FetchAPI instance;
        private HandleFetchAPI() { }
        public static FetchAPI getInstance()
        {
            if (instance == null)
            {
                instance = new FetchAPI();
            }
            return instance;
        }
    }

}