using System;
using Com.Suncor.Olt.Common.Utility.Cache;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class PermitAttribute : DomainObject, ICacheBySiteId
    {
        public PermitAttribute(long id, string name, string sapCode, long siteId)
        {
            Id = id;
            Name = name;
            SapCode = sapCode;
            SiteId = siteId;
        }

        public string Name { get; private set; }
        public string SapCode { get; private set; }
        public long SiteId { get; private set; }
    }
}