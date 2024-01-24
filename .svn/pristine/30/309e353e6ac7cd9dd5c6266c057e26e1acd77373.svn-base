using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Utility.Cache
{
    public class CacheValue<TItem>
    {
        private readonly TimeSpan cachePeriod;
        private readonly DateTime cachedDateTime;
        private readonly TItem item;

        public CacheValue(TItem item, TimeSpan cachePeriod)
        {
            this.cachePeriod = cachePeriod;
            this.item = item;
            cachedDateTime = DateTime.Now.GetNetworkPortable();
        }

        // Returns the Item.  If the item is too old, then we return null.
        public TItem Item
        {
            get { return item; }
        }

        public DateTime CachedDateTime
        {
            get { return cachedDateTime; }
        }

        public bool IsExpired()
        {
            return DateTime.Now.Subtract(cachedDateTime) > cachePeriod;
        }
    }
}