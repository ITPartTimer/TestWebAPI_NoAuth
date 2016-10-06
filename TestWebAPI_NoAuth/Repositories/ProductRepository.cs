using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using TestWebAPI_NoAuth.Interfaces;
using TestWebAPI_NoAuth.Models;

namespace TestWebAPI_NoAuth.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductModel[] products = new ProductModel[]
        {
            new ProductModel {Id =1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new ProductModel {Id =2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new ProductModel {Id =3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        public ProductRepository()
        {
           
        }

       
        public IEnumerable<ProductModel> GetAll()
        {
            return products;
        }

        public ProductModel GetDetails(int Id)
        {
            var product = products.FirstOrDefault((p) => p.Id == Id);

            //
            // Throw a HttpResponseException in the Repository if product is not found, OR
            // Comment out.  A null prouct is returned to the controller.  The controller
            // will handle the response
            //
            //if (product == null)
            //{
            //    throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            //}

            return product;
        }
    }
}