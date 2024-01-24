using System;

namespace Com.Suncor.Olt.Common.Domain.Restriction
{
    [Serializable]
    public class DeviationAlertResponseHistory : DomainObjectHistorySnapshot
    {
        public DeviationAlertResponseHistory(
            long id,
            string reasonCodes,
            string comments,
            User lastModifiedBy,
            DateTime lastModifiedDate)
            : base(id, lastModifiedBy, lastModifiedDate)
        {
            ReasonCodes = reasonCodes;
            Comments = comments;
        }

        public string ReasonCodes { get; private set; }
        public string Comments { get; private set; }
    }
}