using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.Analytics
{
    [Serializable]
    public class Event : DomainObject
    {
        private readonly DateTime dateTime;
        private readonly string name;
        private readonly List<Property> properties;
        private readonly long? siteId;
        private readonly long userId;

        public Event(long? id, long userId, long? siteId, string name, DateTime dateTime, List<Property> properties)
        {
            this.id = id;
            this.userId = userId;
            this.siteId = siteId;
            this.name = name;
            this.dateTime = dateTime;
            this.properties = properties;
        }

        public List<Property> Properties
        {
            get { return properties; }
        }

        public long UserId
        {
            get { return userId; }
        }

        public long? SiteId
        {
            get { return siteId; }
        }

        public string Name
        {
            get { return name; }
        }

        public DateTime DateTime
        {
            get { return dateTime; }
        }
    }
}