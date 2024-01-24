using System;
using Com.Suncor.Olt.Common.Utility.Cache;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class Plant : DomainObject, ICacheBySiteId
    {
        private readonly string name;

        public Plant(long id, string name, long siteId)
        {
            SiteId = siteId;
            this.id = id;
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public long SiteId { get; private set; }
    }
}