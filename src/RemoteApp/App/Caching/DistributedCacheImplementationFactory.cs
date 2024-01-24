using System.Configuration;
using Com.Suncor.Olt.Remote.Caching.Couchbase;

namespace Com.Suncor.Olt.Remote.Caching
{
    public class DistributedCacheImplementationFactory
    {
        private static readonly object couchbaseConfigurationSection = ConfigurationManager.GetSection("couchbase");

        public bool IsDistributedCache
        {
            get { return couchbaseConfigurationSection != null; }
        }

        public ICache GetCache()
        {
            if (couchbaseConfigurationSection != null)
            {
                return CouchbaseCache.Instance;
            }
            return null;
        }
    }
}