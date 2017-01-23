using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestWebAPI_NoAuth.Repositories;
using TestWebAPI_NoAuth.Models;
using System.Threading.Tasks;

namespace TestWebAPI_NoAuth.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/opc")]
    public class OPCController : ApiController
    {
        OPCRepository _repo = new OPCRepository();

        public OPCController()
        {

        }

        [Route("add")]
        [HttpPost]
        public IHttpActionResult Add(OPCBindingModel opc)
        {
            int id = 0;

            //Use CoilCalcBindingModel as input to method to allow validaiton
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            id = _repo.AddTail(opc);

            // Need a different return than NotFound()
            if (id == 0)
                return NotFound();

            return Ok(id);
        }

        [Route("add/tail")]
        [HttpPost]
        public IHttpActionResult Tail(OPCBindingModel opc)
        {
            int id = 0;

            //Use CoilCalcBindingModel as input to method to allow validaiton
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Return the new Interval OPCID
            id = _repo.AddTail(opc);

            // Need a different return than NotFound()
            if (id == 0)
                return NotFound();

            return Ok(id);
        }
    }
}
