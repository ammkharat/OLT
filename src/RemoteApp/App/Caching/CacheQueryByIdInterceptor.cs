using System;
using System.Diagnostics;
using System.Reflection;
using Castle.Core.Internal;
using Castle.DynamicProxy;
using log4net;

namespace Com.Suncor.Olt.Remote.Caching
{
    public class CacheQueryByIdInterceptor : ICacheQueryByIdInterceptor
    {
        // this is routed to the cache log.
        private static readonly ILog cachingLogger = LogManager.GetLogger("CachingLogger");

        private readonly ICache cache;
        private readonly RelatedCacheExpireHelper cachedRelationshipHelper;

        private readonly Stopwatch stopwatch;

        public CacheQueryByIdInterceptor(ICache cache)
        {
            this.cache = cache;
            cachedRelationshipHelper = new RelatedCacheExpireHelper(cache);
            stopwatch = new Stopwatch();
        }

        public void Intercept(IInvocation invocation)
        {
            MethodInfo methodInfo = invocation.Method;

            // Query By Id caching requires that the Arg[0] be a long!
            long key = (long)invocation.Arguments[0];

            Type returnType = methodInfo.ReturnType;

            string cachingKey;
            // Schedule Dao uses this because it is returning an Interface
            if (returnType.IsInterface && invocation.Method.DeclaringType.HasAttribute<CachePrefixAttribute>())
            {
                CachePrefixAttribute cachePrefixAttribute = invocation.Method.DeclaringType.GetAttribute<CachePrefixAttribute>();
                string cachePrefix = cachePrefixAttribute.CachePrefix;
                cachingKey = CacheKeyGenerator.GenerateQueryByIdKey(cachePrefix, key);
            }
            else
            {
                cachingKey = CacheKeyGenerator.GenerateQueryByIdKey(returnType, key);
            }

            object result = cache.Get(cachingKey);

            if (result != null)
            {
                invocation.ReturnValue = result;
                // invocation.Proceed is never called.  so, no other interceptors will run after this!
            }
            else
            {
                invocation.LogAndProceed(cachingLogger, cachingKey, stopwatch);
                object objectToCache = invocation.ReturnValue;
                cache.Update(cachingKey, objectToCache);
                if (objectToCache != null)
                {
                    cachedRelationshipHelper.AddRelationshipsToItemsInThisObject(cachingKey, objectToCache);
                }
            }
        }
    }
}