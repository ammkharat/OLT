using System;
using Castle.Core.Internal;
using Castle.DynamicProxy;
using Com.Suncor.Olt.Common.Domain;
using log4net;

namespace Com.Suncor.Olt.Remote.Caching
{
    public class CacheRemoveInterceptor : ICacheRemoveInterceptor 
    {
        private static readonly ILog logger = LogManager.GetLogger("CachingLogger");

        private readonly ICache cache;
        private readonly RelatedCacheExpireHelper cachedRelationshipHelper;

        public CacheRemoveInterceptor(ICache cache)
        {
            this.cache = cache;
            cachedRelationshipHelper = new RelatedCacheExpireHelper(cache);
        }

        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            object argument = invocation.Arguments[0];

            try
            {
                DomainObject domainObject = (DomainObject) argument;
                string cachingKey;

                // Schedule Dao uses this because it is returning an Interface
                if (invocation.Method.DeclaringType.HasAttribute<CachePrefixAttribute>())
                {
                    CachePrefixAttribute cachePrefixAttribute = invocation.Method.DeclaringType.GetAttribute<CachePrefixAttribute>();
                    string cachePrefix = cachePrefixAttribute.CachePrefix;
                    cachingKey = CacheKeyGenerator.GenerateQueryByIdKey(cachePrefix, domainObject.IdValue);
                }
                else
                {
                    cachingKey = CacheKeyGenerator.GenerateQueryByIdKey(domainObject);
                }

                cache.Remove(cachingKey);
                cachedRelationshipHelper.RemoveItemsContainingThisOne(cachingKey);
            
                CachedRemoveAttribute attribute = invocation.Method.GetAttribute<CachedRemoveAttribute>();
                Type updateObjectType = argument.GetType();
                cachedRelationshipHelper.RemoveRelatedCachedLists(attribute, updateObjectType, domainObject);
            }
            catch (NullReferenceException e)
            {
                logger.Error("Could not find a zero arguement in invocation?", e);
                throw;
            }
            catch (InvalidCastException e)
            {
                logger.Error(string.Format("Could not cast Arguement zero to Domain Object. Arguement type {0}", argument.GetType().Name), e);
                throw;
            }
        }
    }
}