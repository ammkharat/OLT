using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    public class LubesAlarmDisableFormHistory : BaseFormHistory
    {
        public LubesAlarmDisableFormHistory(long id,
            FormStatus formStatus,
            string functionalLocation,
            string location,
            string plainTextContent,
            DateTime validFromDateTime,
            DateTime validToDateTime,
            string approvals,
            User lastModifiedBy,
            DateTime lastModifiedDateTime,
            DateTime? approvedDateTime,
            DateTime? closedDateTime,
            string alarm,
            string criticality,
            string sapNotification,
            string documentLinks)
            : base(id, formStatus, validFromDateTime, validToDateTime, lastModifiedBy, lastModifiedDateTime)
        {
            FunctionalLocation = functionalLocation;
            Location = location;
            PlainTextContent = plainTextContent;
            ApprovedDateTime = approvedDateTime;
            ClosedDateTime = closedDateTime;
            Alarm = alarm;
            Criticality = criticality;
            SapNotification = sapNotification;
            DocumentLinks = documentLinks;
            Approvals = approvals;
        }

        public string FunctionalLocation { get; set; }
        public string Location { get; set; }
        public string PlainTextContent { get; private set; }
        public DateTime? ApprovedDateTime { get; private set; }
        public DateTime? ClosedDateTime { get; private set; }
        public string Alarm { get; private set; }
        public string Criticality { get; private set; }
        public string SapNotification { get; private set; }
        public string DocumentLinks { get; private set; }
        public string Approvals { get; set; }
    }
}