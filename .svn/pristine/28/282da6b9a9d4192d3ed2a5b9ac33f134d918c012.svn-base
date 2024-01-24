using System;
using Castle.DynamicProxy;
using Com.Suncor.Olt.Common.Domain;
using log4net;

namespace Com.Suncor.Olt.Remote.Caching
{
    public class CacheHistoryInsertInterceptor : ICacheInsertHistoryInterceptor
    {
        private static readonly ILog cachingLogger = LogManager.GetLogger("CachingLogger");

        private readonly ICache cache;

        public CacheHistoryInsertInterceptor(ICache cache)
        {
            this.cache = cache;
        }

        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            try
            {
                DomainObject domainObject = (DomainObject)invocation.Arguments[0];

                Type updateObjectType = invocation.Arguments[0].GetType();
                string cachingKey = CacheKeyGenerator.GenerateQueryHistoryByIdKey(updateObjectType, domainObject.IdValue);
                cachingLogger.DebugFormat("Removing {0} from the cache.", cachingKey);
                cache.Remove(cachingKey);

            }
            catch (NullReferenceException e)
            {
                cachingLogger.Error("Could not find a zero arguement in invocation?", e);
                throw;
            }
            catch (InvalidCastException e)
            {
                cachingLogger.Error(string.Format("Could not cast Arguement zero to Domain Object. Arguement type {0}", invocation.Arguments[0].GetType().Name), e);
                throw;
            }

        }
    }
}