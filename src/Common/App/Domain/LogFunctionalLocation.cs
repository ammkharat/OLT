namespace Com.Suncor.Olt.Common.Domain
{
    public class LogFunctionalLocation : DomainObject
    {
        private readonly long functionalLocationId;
        private readonly long logId;

        public LogFunctionalLocation(long logId, long functionalLocationId)
        {
            this.logId = logId;
            this.functionalLocationId = functionalLocationId;
        }

        public long FunctionalLocationId
        {
            get { return functionalLocationId; }
        }

        public long LogId
        {
            get { return logId; }
        }
    }
}