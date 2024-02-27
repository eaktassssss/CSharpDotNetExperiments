using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    public class Bootstrapper
    {
        public IContainer ContainerBuilder()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CacheService>().As<ICacheService>();


            builder.RegisterType<CacheInterceptor>();


            builder.RegisterType<CustomerService>()
                .As<ICustomerService>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(CacheInterceptor));
            var container = builder.Build();
            return container;
        }
    }
}
