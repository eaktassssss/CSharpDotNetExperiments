using Attributes;
using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System.ComponentModel.DataAnnotations;

internal class Program
{
    public static void Main(string[] args)
    {

        #region Redis,AOP Interceptor,AutoFac
        Bootstrapper bootstrapper = new Bootstrapper();
        IContainer container = bootstrapper.ContainerBuilder();
        ICustomerService customerService = container.Resolve<ICustomerService>();
        customerService.AllCustomer();
        #endregion


        #region Phone Number Format Attribute
        try
        {
            Customer customer = new Customer();
            customer.FirstName = "Test";
            customer.LastName = "Test";
            customer.PhoneNumber = "+905551234567";
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(customer, new ValidationContext(customer), results, true);
            if (!isValid)
            {
                foreach (ValidationResult result in results)
                    Console.WriteLine($"{result.ErrorMessage}");
            }
            else
                Console.WriteLine("Phone Number is valid");

            Console.ReadLine();

        }
        catch (ValidationException ex)
        {
            throw new ValidationException(ex.Message);
        }
        #endregion
        Console.ReadLine();
    }
}