using System;
using System.Diagnostics;
using System.Reflection;
using Castle.DynamicProxy;
using log4net;

namespace Com.Suncor.Olt.Remote.Caching
{
    public class CacheQueryAllInterceptor : ICacheQueryAllInterceptor
    {
        // this is routed to the cache log.
        private static readonly ILog cachingLogger = LogManager.GetLogger("CachingLogger");

        private readonly ICache cache;

        private readonly Stopwatch stopwatch;

        public CacheQueryAllInterceptor(ICache cache)
        {
            this.cache = cache;
            stopwatch = new Stopwatch();
        }

        public void Intercept(IInvocation invocation)
        {
            MethodInfo methodInfo = invocation.Method;

            Type returnType = methodInfo.ReturnType;

            string cachingKey = CacheKeyGenerator.GenerateQueryAllCachingKey(returnType.GetGenericArguments()[0]);

            object result = cache.Get(cachingKey);

            if (result != null)
            {
                invocation.ReturnValue = result;
                // invocation.Proceed is never called.  so, no other interceptors will run after this!
            }
            else
            {
                invocation.LogAndProceed(cachingLogger, cachingKey, stopwatch);
                cache.Update(cachingKey, invocation.ReturnValue);
            }
        }
    }
}