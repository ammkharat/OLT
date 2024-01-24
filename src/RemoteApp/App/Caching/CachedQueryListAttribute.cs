using System;

namespace Com.Suncor.Olt.Remote.Caching
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CachedQueryListAttribute : Attribute
    {
        public string CachePrefix { get; private set; }

        public CachedQueryListAttribute(string cachePrefix)
        {
            CachePrefix = cachePrefix;
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class CachedQueryAllAttribute : Attribute
    {
        
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class CachedQueryHistoryAttribute : Attribute
    {
        
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class CachedInsertHistoryAttribute : Attribute
    {
    }
}