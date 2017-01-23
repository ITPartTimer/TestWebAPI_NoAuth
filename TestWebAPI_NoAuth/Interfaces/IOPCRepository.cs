using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI_NoAuth.Models;

namespace TestWebAPI_NoAuth.Interfaces
{
    interface IOPCRepository
    {
        int Add(OPCBindingModel opc);
        int AddTail(OPCBindingModel opc);
        
        // Add IEnumerable to return a list of OPC records for a ProRpt
    }
}
