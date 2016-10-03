using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestWebAPI_NoAuth.Interfaces;
using TestWebAPI_NoAuth.Repositories;
using TestWebAPI_NoAuth.Models;

namespace TestWebAPI_NoAuth.Controllers
{
    [RoutePrefix("api/const/product")]
    public class ProductController : ApiController
    {
        ProductRepository _repository = new ProductRepository();

        public ProductController()
        {

        }

        [Route("all")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            IEnumerable<ProductModel> products = this._repository.GetAll();

            if (products == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            // Try using an factory returned model
            return Request.CreateResponse<IEnumerable<ProductModel>>(HttpStatusCode.OK, products);
        }

        [Route("details/{Id}")]
        [HttpGet]
        public HttpResponseMessage GetById(int Id)
        {
            ProductModel product = this._repository.GetDetails(Id);

            if (product == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            // Try using an factory returned model.  Not sure if this works.
            return Request.CreateResponse(HttpStatusCode.OK, product);
        }
    }
}
