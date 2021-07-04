using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{

    public class Product
    {
        [JsonProperty(PropertyName = "id")]
        public String id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "slug")]
        public string slug { get; set; }
        [JsonProperty(PropertyName = "thumbnail")]
        public string thumnail { get; set; }
        [JsonProperty(PropertyName = "category")]
        public string category { get; set; }
        [JsonProperty(PropertyName = "sub_category")]

        public string sub_category { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string description { get; set; }
        [JsonProperty(PropertyName = "quantity")]
        public int quantity { get; set; }
        [JsonProperty(PropertyName = "price")]
        public float price { get; set; }
        [JsonProperty(PropertyName = "modifyAt")]
        public DateTime modifyAt { get; set; }
        [JsonProperty(PropertyName = "createAt")]
        public DateTime createAt { get; set; }
    
        public Product() { }

        public Product(String id, string name, string slug, string thumbnail, string category, string sub_category, string decription, int quantity, float price, DateTime modifyAt, DateTime createAt)
        {
            this.id = id;
            this.name = name;
            this.slug = slug;
            this.category = category;
            this.sub_category = sub_category;
            this.description = description;
            this.quantity = quantity;
            this.price = price;
            this.createAt = createAt;
            this.modifyAt = modifyAt;
        }
    }
}