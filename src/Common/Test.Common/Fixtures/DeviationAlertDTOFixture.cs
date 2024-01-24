using System;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class DeviationAlertDTOFixture
    {
        public static DeviationAlertDTO Create(DateTime startTime)
        {
            return Create(DeviationAlertStatus.RequiresResponse, startTime);
        }

        public static DeviationAlertDTO Create(DeviationAlertStatus status, DateTime startTime)
        {
            return Create(status, startTime, startTime.AddHours(1));
        }

        public static DeviationAlertDTO Create(DeviationAlertStatus status, DateTime startTime, DateTime endTime)
        {
            return new DeviationAlertDTO(
                1,
                "name",
                "description",
                null,
                null,
                startTime,
                endTime,
                "floc",
                null, null, null, null,
                1, 
                status,
                status == DeviationAlertStatus.Responded,
                1, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow);
        }
    }
}
