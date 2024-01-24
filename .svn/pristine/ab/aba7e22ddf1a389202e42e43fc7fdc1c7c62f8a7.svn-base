using System;
using System.Diagnostics;
using System.Text;
using Couchbase;
using Enyim.Caching.Memcached;
using log4net;

namespace Com.Suncor.Olt.Remote.Caching.Couchbase
{
    public class CouchbaseCache : ICache
    {
        // this is routed to the cache log.
        private static readonly ILog cachingLogger = LogManager.GetLogger("CachingLogger");

        private static readonly TimeSpan ValidFor = new TimeSpan(0, 30, 0);//RITM0387759-chnaged for 30 min to 5 min.



        private readonly CouchbaseClient couchbaseClient;
        private readonly Stopwatch stopwatch;

        private static readonly CouchbaseCache instance = new CouchbaseCache();

        private CouchbaseCache()
        {
            couchbaseClient = new CouchbaseClient();
            stopwatch = new Stopwatch();
        }

        public static CouchbaseCache Instance
        {
            get { return instance; }
        }

        public object Get(string cachingKey)
        {
            if (cachingLogger.IsDebugEnabled)
            {
                stopwatch.Reset();
                stopwatch.Start();
            }

            object result = couchbaseClient.Get(cachingKey);

            if (result != null && cachingLogger.IsDebugEnabled)
            {
                stopwatch.Stop();
                cachingLogger.DebugFormat("Pulling {0} from cache took {1}ms.", cachingKey, stopwatch.ElapsedMilliseconds);
                stopwatch.Reset();
            }

            return result;
        }

        private static readonly Func<string, byte[]> stringtoBytes = s => Encoding.Default.GetBytes("," + s);

        public void AppendToExistingItem(string key, string cachingKeyItemUsingParent)
        {
            byte[] bytes = stringtoBytes(cachingKeyItemUsingParent);
            couchbaseClient.Append(key, new ArraySegment<byte>(bytes));
        }

        public void Remove(string cachingKey)
        {
            couchbaseClient.Remove(cachingKey);            
        }

        public void Update(string cachingKey, object objectToAddOrUpdate)
        {
            cachingLogger.DebugFormat("Updating {0} in cache after Insert, Update or Query from DB.", cachingKey);
            couchbaseClient.Store(StoreMode.Set, cachingKey, objectToAddOrUpdate, ValidFor);
        }
    }
}