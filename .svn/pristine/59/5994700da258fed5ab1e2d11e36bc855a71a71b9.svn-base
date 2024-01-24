using System;

namespace Com.Suncor.Olt.Common.Domain.Restriction
{
    [Serializable]
    public class RestrictionReasonCode : DomainObject
    {
        public RestrictionReasonCode(string name, User lastModifiedBy, DateTime lastModifiedDate, long siteid)    // ayman restriction reason codes
        {
            Name = name;
            LastModifiedBy = lastModifiedBy;
            LastModifiedDate = lastModifiedDate;
            SiteID = siteid;                              //ayman restriction reason codes
        }

        public string Name { get; set; }
        public User LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public long SiteID { get; set; }          //ayman restriction reason codes

        public bool Deleted { get; set; }
    }
}