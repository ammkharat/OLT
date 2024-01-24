using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class DirectiveHistory : DomainObjectHistorySnapshot
    {
        public DirectiveHistory(long id, string functionalLocations, string workAssignments, string documentLinks,
            DateTime activeFromDateTime, DateTime activeToDateTime,
            string plainTextContent, User lastModifiedBy, DateTime lastModifiedDate)
            : base(id, lastModifiedBy, lastModifiedDate)
        {
            FunctionalLocations = functionalLocations;
            WorkAssignments = workAssignments;
            DocumentLinks = documentLinks;
            ActiveFromDateTime = activeFromDateTime;
            ActiveToDateTime = activeToDateTime;
            PlainTextContent = plainTextContent;
        }

        public string FunctionalLocations { get; private set; }

        public string WorkAssignments { get; private set; }

        public string DocumentLinks { get; private set; }

        public DateTime ActiveFromDateTime { get; private set; }
        public DateTime ActiveToDateTime { get; private set; }

        public string PlainTextContent { get; private set; }
    }
}