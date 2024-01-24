using System;

namespace Com.Suncor.Olt.Remote.Caching
{
    /// <summary>
    /// Marks a Dao method as needing to update the cache after the method invocation
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CachedInsertOrUpdateAttribute : AbstractCacheAttribute
    {
        public CachedInsertOrUpdateAttribute(bool hasCachedQueryAllBySiteId, bool hasCachedQueryAll)
            : base(hasCachedQueryAllBySiteId, hasCachedQueryAll)
        {
        }
    }

    public abstract class AbstractCacheAttribute : Attribute
    {
        public bool HasCachedQueryAllBySiteId { get; private set; }
        public bool HasCachedQueryAll { get; private set; }

        protected AbstractCacheAttribute(bool hasCachedQueryAllBySiteId, bool hasCachedQueryAll)
        {
            HasCachedQueryAllBySiteId = hasCachedQueryAllBySiteId;
            HasCachedQueryAll = hasCachedQueryAll;
        }
    }
}