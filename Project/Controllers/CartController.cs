using Newtonsoft.Json;
using Project.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project.Controllers
{
    public class CartController : Controller
    {
        Product p= new Product();
        // GET: Cart
        //thoaianh

        public ActionResult cart()

        {
           
            var action = Request.QueryString["action"];
            var id = Request.QueryString["id"];
            var cartStatus = Request.QueryString["status"];

        
                
                if (action == null && cartStatus != null)
                {
            
                    var request = new RestRequest(Method.GET);


                    var client = new RestClient("https://localhost:44308/listProduct/" + id);

                    client.Timeout = -1;

                    var body = @"";
                    request.AddParameter("text/plain", body, ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
                    var rawResponse = response.Content;
            
                    p = JsonConvert.DeserializeObject<Product>(rawResponse);
               

                if (Session["cart"] == null )
                {
                    
                        List<ItemInCart> cart = new List<ItemInCart>();

                        cart.Add(new ItemInCart { Product = p, Quantity = 1 });
                    Session["cart"] = cart;
                    
                }
                


                else
                {
                    List<ItemInCart> cart = (List<ItemInCart>)Session["cart"];
                    int index = isExist(id);
                    if (index != -1)
                    {
                        cart[index].Quantity++;
                   
                    }
                    else
                    {
                        cart.Add(new ItemInCart { Product = p, Quantity = 1 });
                      
                    }

                    Session["cart"] = cart;

                }
                    
                }
                if (action != null && cartStatus.Equals("true"))
                {
                    if (action.Equals("Decrease"))
                    {
                     
                    List<ItemInCart> cart = (List<ItemInCart>)Session["cart"];
                        int index = isExist(id);
                        if (cart[index].Quantity > 1)
                        {
                            cart[index].Quantity--;
                        }
                        else { cart[index].Quantity = cart[index].Quantity; }
                    
                        Session["cart"] = cart;
                   
                }
                    if (action.Equals("Remove"))
                    {
                        List<ItemInCart> cart = (List<ItemInCart>)Session["cart"];
                        int index = isExist(id);
                        cart.RemoveAt(index);

                        Session["cart"] = cart;
                    }
                    if (action.Equals("Increase"))
                    {
                        List<ItemInCart> cart = (List<ItemInCart>)Session["cart"];
                        int index = isExist(id);
                        cart[index].Quantity++;
                    Session["cart"] = cart;
                  
                }
                }
            ViewData["jpg"] = ".jpg";
            return View();
        }
    
    

        private int isExist(string id)
        {
            
            List<ItemInCart> cart = (List<ItemInCart>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.id.Equals(id))
                    return i;
            return -1;
        }
        public ActionResult PaymentDetails()
        {
            List<ItemInCart> cart = (List<ItemInCart>)Session["cart"];
            return View();
        }
        public ActionResult payment()
        {
            List<ItemInCart> cart = (List<ItemInCart>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                var request = new RestRequest(Method.GET);


                var client = new RestClient("https://localhost:44308/payment/" + cart[i].Product.id + "/"+cart[i].Quantity);

                client.Timeout = -1;

                var body = @"";
                request.AddParameter("text/plain", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                var rawResponse = response.Content;

                   

            }
           
            cart.Clear();
                return Redirect("/Cart/cart");
        }
      
    }
}
