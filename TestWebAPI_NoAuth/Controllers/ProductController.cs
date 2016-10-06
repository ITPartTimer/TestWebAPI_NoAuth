using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestWebAPI_NoAuth.Repositories;
using TestWebAPI_NoAuth.Models;

namespace TestWebAPI_NoAuth.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        // Not using dependancy injection at this time

        ProductRepository _repository = new ProductRepository();

        public ProductController()
        {

        }

        //
        // Controllers using HttpResponseMessage
        //
        [Route("resp/all")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            IEnumerable<ProductModel> products = this._repository.GetAll();

            if (products == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            // Try using an factory returned model
            return Request.CreateResponse<IEnumerable<ProductModel>>(HttpStatusCode.OK, products);
        }

        [Route("resp/details/{Id}")]
        [HttpGet]
        public HttpResponseMessage GetById(int Id)
        {
            ProductModel product = this._repository.GetDetails(Id);
            
            //
            // If null product is handled in the repo, the NotFound will be returned as 
            // an HttpResponseExceptoin.  Not text will be provided.  If handled here, you
            // can add a message to the NotFound Response
            //
            if (product == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Product not found");

            // Try using an factory returned model.  Not sure if this works.
            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        //
        // Controllers using IHttpActionResult
        //
        [Route("action/all")]
        [HttpGet]
        public IHttpActionResult GetAll_Action()
        {
            IEnumerable<ProductModel> products = this._repository.GetAll();

            if (products == null)
                return NotFound();

            // Try using an factory returned model
            return Ok <IEnumerable<ProductModel>> (products);
        }

        [Route("action/details/{Id}")]
        [HttpGet]
        public IHttpActionResult GetById_Action(int Id)
        {
            ProductModel product = this._repository.GetDetails(Id);

            if (product == null)
                return NotFound();

            return Ok<ProductModel>(product);
        }
    }
}
