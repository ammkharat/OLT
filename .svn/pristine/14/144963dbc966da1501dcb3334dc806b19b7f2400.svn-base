using System;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Utility.Cache;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class SpecialWork : DomainObject//, ICacheBySiteId
    {
        //public static readonly SpecialWork EMPTY = new SpecialWork(string.Empty, null);

        public static readonly SpecialWork EMPTY =
            new SpecialWork(new long?(), string.Empty, null);

        public SpecialWork()
        {
        }

        public SpecialWork(string companyName, Site site) : this(null, companyName, site)
        {
        }

        public SpecialWork(long? id, string companyName, Site site)
        {
            this.id = id;
            CompanyName = companyName;
            Site = site;
        }

        public string CompanyName { get; set; }

        public Site Site { get; set; }

        [IgnoreToString]
        public long SiteId
        {
            get { return Site.IdValue; }
        }

        public override string ToString()
        {
            return CompanyName;
        }
    }
}