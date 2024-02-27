using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    public class CustomerService : ICustomerService
    {
        [CacheAttribute(30, typeof(List<Customer>))]
        public List<Customer> AllCustomer()
        {
            var customers = new List<Customer>()
        {
            new Customer() { FirstName = "A",LastName = "D" ,PhoneNumber="+905551234567"},
             new Customer() { FirstName = "B",LastName = "E" ,PhoneNumber="+905551234568"},
              new Customer() { FirstName = "C",LastName = "F" ,PhoneNumber="+905551234569"},
        };

            return customers;
        }
    }
}
