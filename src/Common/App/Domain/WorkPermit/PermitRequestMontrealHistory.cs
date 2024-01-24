using System;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class PermitRequestMontrealHistory : BasePermitRequestHistory
    {
        public PermitRequestMontrealHistory(long id, WorkPermitMontrealType workPermitType, DataSource source,
            string functionalLocations,
            Date startDate, Date endDate, string workOrderNumber,
            string operationNumber, string trade, string description, string sapDescription, string company,
            string supervisor, string excavationNumber, string attributes,
            User lastImportedByUser, DateTime? lastImportedDateTime, User lastSubmittedByUser,
            DateTime? lastSubmittedDateTime, User lastModifiedBy, DateTime lastModifiedDate,
            string documentLinks, string requestedByGroup, PermitRequestCompletionStatus completionStatus) :
                base(
                id, endDate, workOrderNumber, operationNumber, description, sapDescription, company, supervisor,
                lastImportedByUser,
                lastImportedDateTime, lastSubmittedByUser, lastSubmittedDateTime, lastModifiedBy, lastModifiedDate)
        {
            WorkPermitType = workPermitType;
            Source = source;
            ExcavationNumber = excavationNumber;
            FunctionalLocations = functionalLocations;
            StartDate = startDate;
            Attributes = attributes;
            Trade = trade;
            DocumentLinks = documentLinks;
            RequestedByGroup = requestedByGroup;
            CompletionStatus = completionStatus;
        }

        public WorkPermitMontrealType WorkPermitType { get; private set; }
        public DataSource Source { get; set; }
        public string ExcavationNumber { get; private set; }
        public string FunctionalLocations { get; private set; }
        public Date StartDate { get; private set; }
        public string Trade { get; private set; }
        public string DocumentLinks { get; private set; }
        public string RequestedByGroup { get; private set; }
        public PermitRequestCompletionStatus CompletionStatus { get; private set; }

        public string Attributes { get; private set; }
    }
}