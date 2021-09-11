using Newtonsoft.Json;
using Project.Areas.Admin.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Areas.Admin.BUS
{
    public class UserBUS
    {
        public User findUser(string id)
        {
            var client = new RestClient("https://localhost:44308/get-id-user/" + id);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var body = @"";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string rawResponse = response.Content;
            User userID = JsonConvert.DeserializeObject<User>(rawResponse);
          
            return userID;
        }
    }
}