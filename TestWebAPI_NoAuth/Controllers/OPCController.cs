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

            // Use OPCBindingModel to validate
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Exception will be thrown by SQL if a ROLLBACK TRAN
            // happens or the output parameter value = 0
            try
            {
                modeID = _repo.Add(opc);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }              

            return Ok(modeID);
        }

        [Route("add/tail")]
        [HttpPost]
        public IHttpActionResult AddTail(OPCBindingModel opc)
        {
            int newID = 0;

            //Use OPCBindingModel to validate
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Exception will be thrown by SQL if a ROLLBACK TRAN
            // happens or the output parameter value = 0
            try
            {
                newID = _repo.AddTail(opc);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(newID);
        }
    }
}
