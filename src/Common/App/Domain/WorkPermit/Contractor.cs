using System;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Utility.Cache;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class Contractor : DomainObject, ICacheBySiteId
    {
        public static readonly Contractor EMPTY = new Contractor(string.Empty, null);

        public Contractor()
        {
        }

        public Contractor(string companyName, Site site) : this(null, companyName, site)
        {
        }

        public Contractor(long? id, string companyName, Site site)
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