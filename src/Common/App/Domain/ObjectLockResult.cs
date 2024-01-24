using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class ObjectLockResult
    {
        private readonly long lockedByUserId;
        private readonly string lockedByUserName;
        private readonly DateTime lockedOnDateTime;
        private readonly bool succeeded;

        public ObjectLockResult(bool succeeded, long lockedByUserId, string lockedByUserName, DateTime lockedOnDateTime)
        {
            this.succeeded = succeeded;
            this.lockedByUserId = lockedByUserId;
            this.lockedByUserName = lockedByUserName;
            this.lockedOnDateTime = lockedOnDateTime;
        }

        public ObjectLockResult(bool succeeded, long lockedByUserId, DateTime lockedOnDateTime)
        {
            this.succeeded = succeeded;
            this.lockedByUserId = lockedByUserId;
            this.lockedOnDateTime = lockedOnDateTime;
        }

        public bool Succeeded
        {
            get { return succeeded; }
        }

        public long LockedByUserId
        {
            get { return lockedByUserId; }
        }

        public string LockedByUserName
        {
            get { return lockedByUserName; }
        }

        public DateTime LockedOnDateTime
        {
            get { return lockedOnDateTime; }
        }
    }
}