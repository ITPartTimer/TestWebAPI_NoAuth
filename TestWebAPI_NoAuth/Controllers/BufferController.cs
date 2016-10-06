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
    [RoutePrefix("api/buffer")]
    public class BufferController : ApiController
    {
        BufferRepository _repo = new BufferRepository();

        public BufferController()
        {

        }

        [Route("all")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            IEnumerable<BufferModel> buffer = this._repo.GetAll();

            if (buffer == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "No items in Buffer");

            return Request.CreateResponse<IEnumerable<BufferModel>>(HttpStatusCode.OK, buffer);
        }

        [Route("coil/{coilNo}")]
        [HttpGet]
        public HttpResponseMessage GetCoilNo(string coilNo)
        {
            BufferModel c = this._repo.GetCoilNo(coilNo);

            if (c == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Item not in buffer");

            return Request.CreateResponse(HttpStatusCode.OK, c);
        }
    }
}
