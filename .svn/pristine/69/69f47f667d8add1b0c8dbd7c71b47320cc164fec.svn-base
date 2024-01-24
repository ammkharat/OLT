using System;
using System.Diagnostics;
using System.Reflection;
using Castle.DynamicProxy;
using log4net;

namespace Com.Suncor.Olt.Remote.Caching
{
    public class CacheHistoryInterceptor : ICacheHistoryInterceptor
    {
        private readonly ICache cache;

        private readonly Stopwatch stopwatch;
        // this is routed to the cache log.
        private static readonly ILog cachingLogger = LogManager.GetLogger("CachingLogger");

        public CacheHistoryInterceptor(ICache cache)
        {
            this.cache = cache;
            stopwatch = new Stopwatch();
        }

        public void Intercept(IInvocation invocation)
        {
            MethodInfo methodInfo = invocation.Method;

            // Query History By Id caching requires that the Arg[0] be a long!
            long key = (long)invocation.Arguments[0];

            Type returnType = methodInfo.ReturnType;
            
            string cachingKey = CacheKeyGenerator.GenerateQueryHistoryByIdKey(returnType.GetGenericArguments()[0], key);

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