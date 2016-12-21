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
    [AllowAnonymous]
    [RoutePrefix("api/calc")]
    public class CalcController : ApiController
    {
        CoilCalcRepository _repo = new CoilCalcRepository();

        public CalcController()
        {

        }

        [Route("coil")]
        [HttpPost]
        public IHttpActionResult Get(CoilCalcBindingModel calcInput)
        {
            //Use CoilCalcBindingModel as input to method to allow validaiton
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<CoilCalcModel> brks = this._repo.Get(calcInput);

            if (brks == null)
                return NotFound();

            return Ok(brks);
        }


    }
}
