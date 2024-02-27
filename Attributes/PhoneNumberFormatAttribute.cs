using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Attributes
{

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class PhoneNumberFormatAttribute : ValidationAttribute
    {


        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null || String.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(ErrorMessage = "Phone Number is required");


            string pattern = @"^\+[1-9]\d{1,14}$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(value.ToString()))
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage = "Phone Number is not valid");
        }

    }
}
