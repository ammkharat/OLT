using System;

namespace Com.Suncor.Olt.Remote.Caching
{
    /// <summary>
    /// Marks a Dao method as needing to remove the item from the cache after the method invocation
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CachedRemoveAttribute : AbstractCacheAttribute
    {
        public CachedRemoveAttribute(bool hasCachedQueryAllBySiteId, bool hasCachedQueryAll)
            : base(hasCachedQueryAllBySiteId, hasCachedQueryAll)
        {
        }
        
    }
}