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
    [RoutePrefix("api/opc")]
    public class OPCController : ApiController
    {
        OPCRepository _repo = new OPCRepository();

        public OPCController()
        {

        }

        //Need async methods for api/opc/add and api/opc/add/tail
    }
}
