namespace Com.Suncor.Olt.Common.Domain
{
    public class UserLoginHistoryFunctionalLocation
    {
        private readonly long functionalLocationId;

        public UserLoginHistoryFunctionalLocation(long functionalLocationId)
        {
            this.functionalLocationId = functionalLocationId;
        }

        public long FunctionalLocationId
        {
            get { return functionalLocationId; }
        }
    }
}