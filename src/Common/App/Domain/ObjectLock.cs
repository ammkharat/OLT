using System;

namespace Com.Suncor.Olt.Common.Domain
{
    public class ObjectLock
    {
        private readonly string lockedByGuid;
        private readonly long lockedByUserId;
        private readonly DateTime lockedOnDateTime;
        private readonly string objectIdentifier;

        public ObjectLock(string objectIdentifier, long lockedByUserId, DateTime lockedOnDateTime, string lockedByGuid)
        {
            this.objectIdentifier = objectIdentifier;
            this.lockedByUserId = lockedByUserId;
            this.lockedOnDateTime = lockedOnDateTime;
            this.lockedByGuid = lockedByGuid;
        }

        public string ObjectIdentifier
        {
            get { return objectIdentifier; }
        }

        public long LockedByUserId
        {
            get { return lockedByUserId; }
        }

        public DateTime LockedOnDateTime
        {
            get { return lockedOnDateTime; }
        }

        public string LockedByGuid
        {
            get { return lockedByGuid; }
        }
    }
}