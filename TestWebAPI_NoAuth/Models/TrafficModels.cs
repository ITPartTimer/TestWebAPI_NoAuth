using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebAPI_NoAuth.Models
{
    public class ShipApptModel
    {
        public int ApptID { get; set; }
        public string SlotTime { get; set; }
        public DateTime ApptDate { get; set; }
        public string Customer { get; set; }
        public string Carrier { get; set; }
        public string notes { get; set; }
    }

    public class RecvApptModel
    {
        public int ApptID { get; set; }
        public string SlotTime { get; set; }
        public DateTime ApptDate { get; set; }
        public string Customer { get; set; }
        public string Carrier { get; set; }
        public string notes { get; set; }
    }
}