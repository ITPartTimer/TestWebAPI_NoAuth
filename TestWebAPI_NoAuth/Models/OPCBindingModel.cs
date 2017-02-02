using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using FluentValidation;

namespace TestWebAPI_NoAuth.Models
{
    [Validator(typeof(OPCValidator))]
    public class OPCBindingModel
    {
        public int OPCID { get; set; }
        public int CC { get; set; }
        public string Cat { get; set; }
        public int Secs { get; set; }
    }

    public class OPCValidator : AbstractValidator<OPCBindingModel>
    {
        public OPCValidator()
        {
            RuleFor(x => x.OPCID).NotEmpty().WithMessage("OPCID Empty");

            RuleFor(x => x.CC).NotEmpty().WithMessage("CC Empty")
                                    .Must(validCC).WithMessage("CC not in list");

            RuleFor(x => x.Cat).NotEmpty().WithMessage("Cat Empty");

            RuleFor(x => x.Secs).NotEmpty().WithMessage("Secs empty");
                                   
        }

        private bool IsInteger(int theValue)
        {
            // Test to make sure a value is integer
            // Not implemented
            return true;
        }

        private bool validCC(int theValue)
        {
            // Make sure CC is in the list of cost centers
            List<int> cc = new List<int> {10,30,60,70,90,80};

            if (cc.Contains(theValue))
                return true;
            else
                return false;
        }
    }
}