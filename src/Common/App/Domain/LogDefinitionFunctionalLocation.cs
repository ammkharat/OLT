namespace Com.Suncor.Olt.Common.Domain
{
    public class LogDefinitionFunctionalLocation : DomainObject
    {
        private readonly long functionalLocationId;
        private readonly long logDefinitionId;

        public LogDefinitionFunctionalLocation(long logDefinitionId, long functionalLocationId)
        {
            this.logDefinitionId = logDefinitionId;
            this.functionalLocationId = functionalLocationId;
        }

        public long FunctionalLocationId
        {
            get { return functionalLocationId; }
        }

        public long LogDefinitionId
        {
            get { return logDefinitionId; }
        }
    }
}