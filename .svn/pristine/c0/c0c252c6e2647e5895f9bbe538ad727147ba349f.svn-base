using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class DomainObjectChangeSet : DomainObject
    {
        private readonly DateTime changeDateTime;
        private readonly List<PropertyChange> propertyChanges;
        private readonly String userName;

        public DomainObjectChangeSet(DateTime changeDateTime, string userName)
            : this(changeDateTime, userName, new List<PropertyChange>())
        {
        }

        public DomainObjectChangeSet(DateTime changeDateTime, string userName, List<PropertyChange> propertyChanges)
        {
            this.changeDateTime = changeDateTime;
            this.userName = userName;
            this.propertyChanges = propertyChanges;
        }

        public DateTime ChangeDateTime
        {
            get { return changeDateTime; }
        }

        public string UserName
        {
            get { return userName; }
        }

        public List<PropertyChange> PropertyChanges
        {
            get { return propertyChanges; }
        }
    }
}