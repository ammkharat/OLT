using System;

namespace Com.Suncor.Olt.Remote.Caching
{
    /// <summary>
    /// Marks a Dao method as Cacheable with a certain amount of time until expiry
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CachedQueryAttribute : Attribute
    {
        public string CachePrefix { get; private set; }

        public CachedQueryAttribute(string cachePrefix)
        {
            CachePrefix = cachePrefix;
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class CachedQueryByIdAttribute : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Method)]
    public class CachedQueryGN75BSarniaByIdAttribute : Attribute
    {

    }


    //ayman generic forms
    [AttributeUsage(AttributeTargets.Method)]
    public class CachedQueryByIdAndSiteIdAttribute : Attribute
    {

    }


    //ayman Sarnia eip DMND0008992
    [AttributeUsage(AttributeTargets.Method)]
    public class CachedQueryTemplateByIdAndSiteIdAttribute : Attribute
    {

    }

    //ayman Sarnia eip DMND0008992
    [AttributeUsage(AttributeTargets.Method)]
    public class CachedQuerySarniaFormByIdAndSiteIdAttribute : Attribute
    {
        
    }

    //ayman Sarnia eip DMND0008992
    [AttributeUsage(AttributeTargets.Method)]
    public class CachedQueryApprovedTemplateByIdAndSiteIdAttribute : Attribute
    {

    }


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class CachePrefixAttribute : Attribute
    {
        public string CachePrefix { get; private set; }

        public CachePrefixAttribute(string cachePrefix)
        {
            CachePrefix = cachePrefix;
        }
    }
}