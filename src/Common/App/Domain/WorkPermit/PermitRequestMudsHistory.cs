using System;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class PermitRequestMudsHistory : BasePermitRequestHistory
    {
        public PermitRequestMudsHistory(long id, WorkPermitMudsType workPermitType, DataSource source,
            string functionalLocations,
            Date startDate, Date endDate, string workOrderNumber,
            string operationNumber, string trade, string description, string sapDescription, string company, string company_1, string company_2, // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            string supervisor, string excavationNumber, string attributes,
            User lastImportedByUser, DateTime? lastImportedDateTime, User lastSubmittedByUser,
            DateTime? lastSubmittedDateTime, User lastModifiedBy, DateTime lastModifiedDate,
            string documentLinks, string requestedByGroup, PermitRequestCompletionStatus completionStatus,
            DateTime startDateTime, DateTime endDateTime
            ) :
                base(
                id, endDate, workOrderNumber, operationNumber, description, sapDescription, company, company_1, company_2,supervisor, // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
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
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }

        public WorkPermitMudsType WorkPermitType { get; private set; }
        public DataSource Source { get; set; }
        public string ExcavationNumber { get; private set; }
        public string FunctionalLocations { get; private set; }
        public Date StartDate { get; private set; }
        public string Trade { get; private set; }
        public string DocumentLinks { get; private set; }
        public string RequestedByGroup { get; private set; }
        public PermitRequestCompletionStatus CompletionStatus { get; private set; }

        public string Attributes { get; private set; }

        public DateTime StartDateTime { get;  set; }
        public DateTime EndDateTime { get;  set; }
    }
}