using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class DeviationAlertResponseFixture
    {
        public static DeviationAlertResponse CreateResponseWithId1FromDB()
        {
            DeviationAlertResponse response = new DeviationAlertResponse("Test comments", UserFixture.CreateUserWithGivenId(1), DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow) { Id = 1 };
            return response;
        }

        public static DeviationAlertResponse CreateNewResponse()
        {
            DeviationAlertResponse response = new DeviationAlertResponse("Test comments", UserFixture.CreateUserWithGivenId(1), DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow);
            return response;
        }
    }
}