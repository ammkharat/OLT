using System;
using System.Reflection;
using Castle.Core.Internal;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility.Cache;
using log4net;

namespace Com.Suncor.Olt.Remote.Caching
{
    public class RelatedCacheExpireHelper
    {
        private readonly ICache cache;
        private static readonly ILog logger = LogManager.GetLogger("CachingLogger");

        public RelatedCacheExpireHelper(ICache cache)
        {
            this.cache = cache;
        }

        public void RemoveRelatedCachedLists(AbstractCacheAttribute attribute, Type updateObjectType, DomainObject domainObject)
        {
            if (attribute.HasCachedQueryAll)
            {
                RemoveQueryAllCache(updateObjectType);
            }
            if (attribute.HasCachedQueryAllBySiteId)
            {
                RemoveQueryAllBySiteIdCache(updateObjectType, domainObject);
            }
        }

        private void RemoveQueryAllCache(Type updateObjectType)
        {
            string cachingKey = CacheKeyGenerator.GenerateQueryAllCachingKey(updateObjectType);
            logger.DebugFormat("Removing {0} from cache.", cachingKey);
            cache.Remove(cachingKey);
        }

        private void RemoveQueryAllBySiteIdCache(Type updateObjectType, DomainObject domainObject)
        {
            // domain object needs to have a SiteId property in order to be able to determine the Site for clearing the QueryAllBySiteId cached List.
            Type[] interfaces = updateObjectType.GetInterfaces();
            bool hasSiteIdProperty = Array.Exists(interfaces, type => type == typeof(ICacheBySiteId));
            if (hasSiteIdProperty == false)
            {
                logger.WarnFormat("Not attempting to clear QueryAllBySiteId cache for {0} because {0} doesn't implement ICacheBySiteId.", updateObjectType.Name);
                return;
            }
            PropertyInfo propertyInfo = updateObjectType.GetProperty("SiteId");
            object key = propertyInfo.GetValue(domainObject, null);
            string cachingKey = CacheKeyGenerator.GenerateQueryAllBySiteIdCachingKey(updateObjectType, (long)key);
            logger.DebugFormat("Removing {0} from cache.", cachingKey);
            cache.Remove(cachingKey);
        }

        /// <summary>
        /// Search through this object, and find Properties marked with CachedRelationshipAttribute that tell of related items.
        /// Tell the cache to remove the newlyCachedItem when the related item is updated or removed in the cache.
        /// </summary>
        /// <example>
        /// When we add a Log to the cache, we have marked up the Work Assignment and LogDefinition properties on the Log.  
        /// This means that we want to invalidate this Log item when the Work Assignment or Log Definition related to it is updated or removed.
        /// </example>
        /// <param name="cachingKeyOfNewlyCachedItem"></param>
        /// <param name="newlyCachedItem"></param>
        public void AddRelationshipsToItemsInThisObject(string cachingKeyOfNewlyCachedItem, object newlyCachedItem)
        {
            Type type = newlyCachedItem.GetType();

            PropertyInfo[] properties =
                type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            PropertyInfo[] relationshipProperties = properties.FindAll(property => property.HasAttribute<CachedRelationshipAttribute>());
            foreach (PropertyInfo propertyInfo in relationshipProperties)
            {
                object value = propertyInfo.GetValue(newlyCachedItem, null);
                if (value == null)
                    continue;

                DomainObject domainObject = value as DomainObject;
                if (domainObject == null)
                {
                    logger.WarnFormat("Property {0} on {1} marked with CachedRelationshipAttribute isn't a Domain Object. So, we can't build the relationship key.",
                        propertyInfo.Name, type);
                    continue;
                }

                string cachingKeyForParentItem = CacheKeyGenerator.GenerateQueryByIdKey(domainObject);
                AddRelationship(cachingKeyForParentItem, cachingKeyOfNewlyCachedItem);
            }
        }

        private const string RelationshipSuffix = ":REL";

        /// <summary>
        /// Add relationships to the cache for removal. Params based on Log containing a Work Assignment
        /// </summary>
        /// <param name="cachingKeyOfParent">Key of work Assignment</param>
        /// <param name="cachingKeyItemUsingParent">Key of Log</param>
        public void AddRelationship(string cachingKeyOfParent, string cachingKeyItemUsingParent)
        {
            string key = cachingKeyOfParent + RelationshipSuffix;
            logger.DebugFormat("Adding {0} to {1} relationship", cachingKeyItemUsingParent, key);

            object result = cache.Get(key);
            if (result == null)
            {
                cache.Update(key, cachingKeyItemUsingParent);
            }
            else
            {
                cache.AppendToExistingItem(key, cachingKeyItemUsingParent);
            }
        }

        /// <summary>
        /// Removes all items from the cache who care about the current item being updated.
        /// </summary>
        /// <example>
        /// When a Work Assignment with caching Key WorkAssignment:1 is updated,
        /// We need to remove all items that care about this.  An example would be a Log that contains this Work Assignment. We want to remove the Log from the cache.
        /// </example>
        /// <param name="cachingKey"></param>
        public void RemoveItemsContainingThisOne(string cachingKey)
        {
            string relatedItemsString = cache.Get(cachingKey + RelationshipSuffix) as string;
            if (relatedItemsString == null)
            {
                return;
            }
            string[] relatedItems = relatedItemsString.Split(new[] { ',' });
            foreach (string relatedItem in relatedItems)
            {
                cache.Remove(relatedItem);
            }
            cache.Remove(relatedItemsString);
        }

    }
}