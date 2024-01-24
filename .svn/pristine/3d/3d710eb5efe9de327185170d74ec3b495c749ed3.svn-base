using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class ActionItemStatusModification
    {
        public ActionItemStatusModification(ActionItemStatus previousStatus, User modifiedUser,
            DateTime modifiedDateTime)
        {
            PreviousStatus = previousStatus;
            ModifiedUser = modifiedUser;
            ModifiedDateTime = modifiedDateTime;
        }

        public ActionItemStatus PreviousStatus { get; private set; }

        public User ModifiedUser { get; private set; }

        public DateTime ModifiedDateTime { get; private set; }
    }
}