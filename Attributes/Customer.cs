using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [PhoneNumberFormatAttribute]
        public string PhoneNumber { get; set; }

        
    }
}
