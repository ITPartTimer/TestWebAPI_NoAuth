using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

    namespace TestWebAPI_NoAuth.Models
{
    public class OPCBindingModel
    {
        // Could use FluentValidator for numeric validation.
        // Decided to use ComponentModel RegularExpression, since
        // Fluent would be overkill
        // ^(0|[1-9][0-9]*)$
        // [RegularExpression(@"^\d+$")]
        // [RegularExpression("([1-9][0-9]*)")] for 1-inf

        [Required(ErrorMessage = "OPCID missing")]
        public int OPCID { get; set; }

        [Required(ErrorMessage = "CC missing")]
        public int CC { get; set; }

        [Required(ErrorMessage = "Cat missing")]
        public string Cat { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Secs not integer")]
        public int Secs { get; set; }
    }
}