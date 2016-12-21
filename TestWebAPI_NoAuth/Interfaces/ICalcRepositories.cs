using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI_NoAuth.Models;

namespace TestWebAPI_NoAuth.Interfaces
{
    interface ICoilCalcRepository
    {
        IEnumerable<CoilCalcModel> Get(CoilCalcBindingModel calcInput);
    }

    interface ISheetCalcRepository
    {

    }
}
