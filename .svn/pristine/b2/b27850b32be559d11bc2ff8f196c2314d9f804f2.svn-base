using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class LogGuideline : DomainObject
    {
        public LogGuideline(FunctionalLocation functionalLocation, string text)
        {
            FunctionalLocation = functionalLocation;
            Text = text;
        }

        public LogGuideline(long id, FunctionalLocation functionalLocation, string text)
            : this(functionalLocation, text)
        {
            Id = id;
        }

        public FunctionalLocation FunctionalLocation { get; private set; }
        public string Text { get; set; }
    }
}