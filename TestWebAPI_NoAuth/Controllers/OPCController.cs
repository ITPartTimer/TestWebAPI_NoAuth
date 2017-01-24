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
            int modeID = 0;

            //Use CoilCalcBindingModel as input to method to allow validaiton
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            modeID = _repo.Add(opc);

            // Need a different return than NotFound()
            if (modeID == 0)
                return NotFound();

            return Ok(modeID);
        }

        [Route("add/tail")]
        [HttpPost]
        public IHttpActionResult AddTail(OPCBindingModel opc)
        {
            int newID = 0;

            //Use CoilCalcBindingModel as input to method to allow validaiton
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Return the new Interval OPCID
            newID = _repo.AddTail(opc);

            // Need a different return than NotFound()
            if (newID == 0)
                return NotFound();

            return Ok(newID);
        }
    }
}
