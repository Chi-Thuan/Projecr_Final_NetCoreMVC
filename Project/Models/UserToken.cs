using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class UserToken
    {
        public string id { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public int role { get; set; }

        public override string ToString()
        {
            return "Person: " + id + " " + fullname + " " + email + " " + role;
        }
    }
}