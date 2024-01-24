using System;
using System.Collections.Generic;
using System.Threading;
using Com.Suncor.Olt.Common.Exceptions;

namespace Com.Suncor.Olt.Common.Utility.Cache
{
    // TODO: (Troy) make TKey be limited to something that we can compare. For this one, it's long.
    public class ExpiringCache<TKey, TValue> : IExpiringCache where TValue : class
    {
        private readonly Dictionary<TKey, CacheValue<TValue>> cache;
        private readonly ReaderWriterLock locker;
        private readonly TimeSpan timeToCacheIndividualItems;

        public ExpiringCache(TimeSpan cachePeriod) : this(cachePeriod, EqualityComparer<TKey>.Default)
        {
        }

        public ExpiringCache(TimeSpan cachePeriod, IEqualityComparer<TKey> comparer)
        {
            if (TimeSpan.Zero >= cachePeriod)
            {
                throw new OLTException("Cache timeout cannot be zero or less. Argument passed: " +
                                       cachePeriod);
            }
            timeToCacheIndividualItems = cachePeriod;

            cache = new Dictionary<TKey, CacheValue<TValue>>(comparer);
            locker = new ReaderWriterLock();
        }

        public object this[object key]
        {
            get { return Get((TKey) key); }
            set { Add((TKey) key, (TValue) value); }
        }

        /// <summary>
        ///     Gets the item from the Cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns>the item or default(TValue) if it is not in the cache or has expired from the cache.</returns>
        public TValue Get(TKey key)
        {
            try
            {
                CacheValue<TValue> result;

                locker.AcquireReaderLock(-1);
                if (cache.TryGetValue(key, out result) && !result.IsExpired())
                {
                    return result.Item;
                }
                else if (result != null)
                {
                    // item was found, but is expired.
                    var writerLock = locker.UpgradeToWriterLock(-1);
                    cache.Remove(key);
                    locker.DowngradeFromWriterLock(ref writerLock);
                }
                return default(TValue);
            }
            finally
            {
                if (locker.IsReaderLockHeld)
                    locker.ReleaseReaderLock();
                else
                    locker.ReleaseWriterLock();
            }
        }

        public void Remove(TKey key)
        {
            try
            {
                locker.AcquireWriterLock(-1);
                cache.Remove(key);
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }

        public void Add(TKey key, TValue value)
        {
            try
            {
                locker.AcquireWriterLock(-1);
                cache.Remove(key);
                cache.Add(key, new CacheValue<TValue>(value, timeToCacheIndividualItems));
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }
    }
}