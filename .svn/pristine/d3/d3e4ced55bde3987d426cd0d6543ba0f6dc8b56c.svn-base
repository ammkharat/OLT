using System;
using Com.Suncor.Olt.Common.Annotations;

namespace Com.Suncor.Olt.Common.Domain.Restriction
{
    [Serializable]
    public class RestrictionLocationItemReasonCodeAssociation
    {
        public const string ComboBoxDisplayMember = "RestrictionReasonCodeName";

        public RestrictionLocationItemReasonCodeAssociation(RestrictionReasonCode restrictionReasonCode, int? limit)
        {
            RestrictionReasonCode = restrictionReasonCode;
            Limit = limit;
        }

        public RestrictionReasonCode RestrictionReasonCode { get; private set; }
        public int? Limit { get; set; }

        [UsedImplicitly]
        public string RestrictionReasonCodeName
        {
            get { return RestrictionReasonCode.Name; }
        }

        public long RestrictionReasonCodeId
        {
            get { return RestrictionReasonCode.IdValue; }
        }
    }
}