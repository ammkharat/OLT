using System;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class UserWorkPermitDefaultTimePreferences : DomainObject
    {
        public UserWorkPermitDefaultTimePreferences()
        {
        }

        public UserWorkPermitDefaultTimePreferences(long userId) :
            this(userId, TimeSpan.Zero, TimeSpan.Zero)
        {
        }

        public UserWorkPermitDefaultTimePreferences(long userId, TimeSpan preShiftPadding, TimeSpan postShiftPadding)
        {
            UserId = userId;
            PreShiftPadding = preShiftPadding;
            PostShiftPadding = postShiftPadding;
        }

        public long UserId { get; set; }

        public TimeSpan PreShiftPadding { get; set; }

        public TimeSpan PostShiftPadding { get; set; }

        public Range<DateTime> DefaultDateTimeRange(UserShift userShift)
        {
            return new Range<DateTime>(userShift.StartDateTime.Add(PreShiftPadding),
                userShift.EndDateTime.Subtract(PostShiftPadding));
        }

        public bool ValidatePreShiftPadding()
        {
            return PreShiftPadding <= Constants.WorkPermitTimePreferenceOffsetLimit;
        }

        public bool ValidatePostShiftPadding()
        {
            return PostShiftPadding <= Constants.WorkPermitTimePreferenceOffsetLimit;
        }
    }
}