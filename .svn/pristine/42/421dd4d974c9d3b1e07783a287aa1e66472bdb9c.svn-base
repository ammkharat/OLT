using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class RestrictionReasonCodeFixture
    {
        public static RestrictionReasonCode GetRestrictionReasonCodeThatIsInDb()
        {
            RestrictionReasonCode code = new RestrictionReasonCode("abc", UserFixture.CreateUserWithGivenId(1), DateTimeFixture.DateTimeNow,0) {Id = 600};   //ayman restriction reason codes
            return code;
        }

        public static RestrictionReasonCode GetRestrictionReasonCode(long id, string name)
        {
            RestrictionReasonCode code = new RestrictionReasonCode(name, UserFixture.CreateUserWithGivenId(1), DateTimeFixture.DateTimeNow, 0) { Id = id };      //ayman restriction reason codes
            return code;
        }
    }
}