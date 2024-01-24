using System;
using Com.Suncor.Olt.Common.Utility.Cache;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class SiteCommunication : ModifiableDomainObject, ICacheBySiteId
    {
        public SiteCommunication(long? id, long siteId, string sitename, string message, DateTime startDateTime, DateTime endDateTime,         //ayman site communication
            User createdByUser, DateTime createdDateTime) : base(createdByUser, createdDateTime)
        {
            this.id = id;
            SiteId = siteId;
            SiteName = sitename;            //ayman site communication
            Message = message;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            CreatedByUser = createdByUser;
            CreatedDateTime = createdDateTime;
        }

        public string Message { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public User CreatedByUser { get; private set; }

        public DateTime CreatedDateTime { get; private set; }
        public long SiteId { get; private set; }

        public string SiteName { get; set; }           //ayman site communication
    }
}