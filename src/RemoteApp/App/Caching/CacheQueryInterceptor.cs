using System.Diagnostics;
using System.Reflection;
using Castle.Core.Internal;
using Castle.DynamicProxy;
using log4net;

namespace Com.Suncor.Olt.Remote.Caching
{
    public class CacheQueryInterceptor : ICacheQueryInterceptor
    {
        // this is routed to the cache log.
        private static readonly ILog cachingLogger = LogManager.GetLogger("CachingLogger");

        private readonly ICache cache;

        private readonly Stopwatch stopwatch;

        public CacheQueryInterceptor(ICache cache)
        {
            this.cache = cache;
            stopwatch = new Stopwatch();
        }

        public void Intercept(IInvocation invocation)
        {
            MethodInfo methodInfo = invocation.Method;
            CachedQueryAttribute cachedQueryAttribute = methodInfo.GetAttribute<CachedQueryAttribute>();

            string cachingKey = CacheKeyGenerator.GenerateQueryKey(cachedQueryAttribute.CachePrefix, invocation.Arguments);

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