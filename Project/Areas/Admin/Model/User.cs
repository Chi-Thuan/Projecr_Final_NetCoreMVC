using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Areas.Admin.Model
{
    public class User
    {
        public string id { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string googleID { get; set; }
        public string facebookID { get; set; }
        public int role { get; set; }
        public DateTime? createAt { get; set; }

        public DateTime? modifyAt { get; set; }


    }
}