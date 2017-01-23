﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

    namespace TestWebAPI_NoAuth.Models
{
    public class OPCBindingModel
    {
        [Required]
        public int OPCID { get; set; }

        [Required]
        public int CatID { get; set; }

        [Required]
        public int Secs { get; set; }
    }
}