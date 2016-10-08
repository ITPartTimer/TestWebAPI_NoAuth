using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI_NoAuth.Models;

namespace TestWebAPI_NoAuth.Interfaces
{
    interface ITrafficRepository
    {
        IEnumerable<ShipApptModel> GetShipAll(DateTime d);
        IEnumerable<RecvApptModel> GetRecvAll(DateTime d);
    }
}
