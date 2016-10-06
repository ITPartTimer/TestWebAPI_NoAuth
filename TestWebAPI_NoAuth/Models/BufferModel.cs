using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebAPI_NoAuth.Models
{
    public class BufferModel
    {
        public string CoilNo { get; set; }
        public DateTime Recv { get; set; }
        public string Name { get; set; }
        public string Matl { get; set; }
        public string PN { get; set; }
        public string Alloy { get; set; }
        public decimal Gauge { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public int Net { get; set; }
        public int Gross { get; set; }
        public int IMPGross { get; set; }
        public string Loc { get; set; }
    }
}