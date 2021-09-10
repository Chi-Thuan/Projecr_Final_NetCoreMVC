using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Category
    {

        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }

        [JsonProperty(PropertyName = "slug")]
        public string slug { get; set; }

        [JsonProperty(PropertyName = "sub_category")]
        public string sub_category { get; set; }

        public DateTime? createAt { get; set; }

         public DateTime? modifyAt { get; set; }

        public Category() { }

        public Category(String id, string name, string slug , string sub_category, DateTime createAt, DateTime modifyAt)
        {
            this.id = id;
            this.name = name;
            this.slug = slug;
            this.createAt = createAt;
            this.modifyAt = modifyAt;
        }
    }
   
}