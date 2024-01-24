using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
    [Serializable]
    public class TargetAlertReportDetailDTO : DomainObject
    {
        private readonly DateTime? acknowledgedDateTime;
        private readonly User acknowledgedUser;
        private readonly DateTime createdDateTime;
        private readonly FunctionalLocation functionalLocation;
        private readonly DateTime lastModifiedDateTime;
        private readonly decimal mostRecentActualValue;
        private readonly string name;

        private readonly List<TargetAlertResponseReportDetailDTO> responses;
        private readonly TargetAlertStatus status;
        private readonly TagInfo tagInfo;
        private readonly TargetThresholdEvaluation thresholdEvaluation;
        private readonly UserShift userShift;

        public TargetAlertReportDetailDTO(long id, string name, FunctionalLocation functionalLocation,
            TargetAlertStatus status, DateTime createdDateTime, DateTime lastModifiedDateTime, UserShift userShift,
            TagInfo tagInfo, TargetThresholdEvaluation thresholdEvaluation, decimal mostRecentActualValue,
            User acknowledgedUser, DateTime? acknowledgedDateTime, List<TargetAlertResponseReportDetailDTO> responses)
        {
            this.id = id;
            this.name = name;
            this.functionalLocation = functionalLocation;
            this.status = status;
            this.createdDateTime = createdDateTime;
            this.lastModifiedDateTime = lastModifiedDateTime;
            this.userShift = userShift;
            this.tagInfo = tagInfo;
            this.thresholdEvaluation = thresholdEvaluation;
            this.mostRecentActualValue = mostRecentActualValue;
            this.acknowledgedUser = acknowledgedUser;
            this.acknowledgedDateTime = acknowledgedDateTime;
            this.responses = responses;
        }

        public string Name
        {
            get { return name; }
        }

        public FunctionalLocation FunctionalLocation
        {
            get { return functionalLocation; }
        }

        public TargetAlertStatus Status
        {
            get { return status; }
        }

        public DateTime CreatedDateTime
        {
            get { return createdDateTime; }
        }

        public DateTime LastModifiedDateTime
        {
            get { return lastModifiedDateTime; }
        }

        public UserShift UserShift
        {
            get { return userShift; }
        }

        public TagInfo TagInfo
        {
            get { return tagInfo; }
        }

        public TargetThresholdEvaluation ThresholdEvaluation
        {
            get { return thresholdEvaluation; }
        }

        public User AcknowledgedUser
        {
            get { return acknowledgedUser; }
        }

        public DateTime? AcknowledgedDateTime
        {
            get { return acknowledgedDateTime; }
        }

        public List<TargetAlertResponseReportDetailDTO> Responses
        {
            get { return responses; }
        }

        public decimal MostRecentActualValue
        {
            get { return mostRecentActualValue; }
        }
    }
}