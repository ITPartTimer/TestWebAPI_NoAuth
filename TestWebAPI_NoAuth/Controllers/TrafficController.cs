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
    [RoutePrefix("api/traffic")]
    public class TrafficController : ApiController
    {
        TrafficRepository _repo = new TrafficRepository();
        public TrafficController()
        {

        }

        [Route("ship/all/{d}")]
        [HttpGet]
        public HttpResponseMessage ShipApptsByDate(DateTime d)
        {
            IEnumerable<ShipApptModel> appts = this._repo.GetShipAll(d);

            if (appts == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Appts Found");

            return Request.CreateResponse<IEnumerable<ShipApptModel>>(HttpStatusCode.OK, appts);
        }

        [Route("recv/all/{d}")]
        [HttpGet]
        public HttpResponseMessage RecvApptsByDate(DateTime d)
        {
            IEnumerable<RecvApptModel> appts = this._repo.GetRecvAll(d);

            if (appts == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Appts Found");

            return Request.CreateResponse<IEnumerable<RecvApptModel>>(HttpStatusCode.OK, appts);
        }
    }
}
