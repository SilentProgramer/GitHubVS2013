using MVCSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCSample.Controllers
{
    //visit the following link to read on routing in web api : http://www.asp.net/web-api/overview/web-api-routing-and-actions/routing-in-aspnet-web-api
    public class ProductsController : ApiController  //routing for Api controllers is defined in WebApiConfig.cs in App_Start (and not in RouteConfig)
    {
        Product[] products = new Product[] 
        { 
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
        };

        public IEnumerable<Product> GetAllProducts()  //POSTMAN: url to invoke this method : {domain}/api/Products/
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id) //POSTMAN: url to invoke this method : {domain}/api/Products/1
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
