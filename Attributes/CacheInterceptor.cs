using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    public class CacheInterceptor : IInterceptor
    {
        ICacheService _cacheService;
        public CacheInterceptor(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        public void Intercept(IInvocation invocation)
        {
            var methodInfo = invocation.MethodInvocationTarget;
            var attr = methodInfo.GetCustomAttributes(typeof(CacheAttribute), false).FirstOrDefault() as CacheAttribute;
            var key = $"customers";
            if (attr is not null)
            {

                var getCacheMethod = typeof(ICacheService).GetMethod( nameof(ICacheService.GetCache))?.MakeGenericMethod(attr.Type);
                var cachedValue = getCacheMethod?.Invoke(_cacheService, new object[] { key });
                if (cachedValue is not null)
                {
                    invocation.ReturnValue = Convert.ChangeType(cachedValue, methodInfo.ReturnType);
                    return;
                }
                invocation.Proceed();
                var setCacheMethod = typeof(ICacheService).GetMethod(nameof(ICacheService.SetCache))?.MakeGenericMethod(attr.Type);
                setCacheMethod?.Invoke(_cacheService, new object[] { key, invocation.ReturnValue, DateTimeOffset.Now.AddMinutes(attr.Duration) });
            }
        }
    }
}
