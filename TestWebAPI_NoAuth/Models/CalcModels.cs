using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebAPI_NoAuth.Models
{
    public class CoilCalcModel
    {
        public int BrkNo { get; set; }
        public double CutOD { get; set; }
        public double CutRise { get; set; }
        public int CutLbs { get; set; }
        public int CutFt { get; set; }
    }

    public class SheetCalcModel
    {

    }
}
