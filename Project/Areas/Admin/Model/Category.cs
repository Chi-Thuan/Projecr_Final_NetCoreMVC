using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Areas.Admin.Model
{
    public class Category
    {


        public string id { get; set; }


        public string name { get; set; }


        public string slug { get; set; }


        public DateTime? createAt { get; set; }


        public DateTime? modifyAt { get; set; }

        public Category(string name, string id)
        {
            this.id = id;
            this.name = name;
        }
    }
}