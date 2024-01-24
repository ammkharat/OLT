using System;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public static class UserWorkPermitDefaultTimePreferencesFixture
    {
        public static UserWorkPermitDefaultTimePreferences Create(TimeSpan preShiftPadding, 
                                                                  TimeSpan postShiftPadding)
        {
            return new UserWorkPermitDefaultTimePreferences(-99, 
                                                            preShiftPadding,
                                                            postShiftPadding);
        }
    }
}
