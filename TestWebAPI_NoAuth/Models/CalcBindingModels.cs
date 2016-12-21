using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestWebAPI_NoAuth.Models
{
    public class CoilCalcBindingModel
    {
        [Required]
        public string Matl { get; set; }

        [Required]
        [Range(0, 1, ErrorMessage ="Gauge out of range")]
        public double Gauge { get; set; }

        [Required]
        [Range(0, 72, ErrorMessage ="Width out of range")]
        public double Width { get; set; }

        [Required]
        [Range(0, 60000, ErrorMessage ="Net out of range")]
        public int Net { get; set; }

        [Required]
        public double CutWidth { get; set; }

        [Required]
        public int CutID { get; set; }

        [Required]
        public double CutCore { get; set; }
    }

    public class SheetCalcBindingModel
    {

    }
}
