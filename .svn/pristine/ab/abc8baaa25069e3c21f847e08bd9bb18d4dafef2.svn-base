using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class LogHistory : DomainObjectHistorySnapshot
    {
        public LogHistory(long id, string functionalLocations, bool inspectionFollowUp, bool processControlFollowUp,
            bool operationsFollowUp, bool supervisionFollowUp, bool environmentalHealthSafetyFollowUp,
            bool otherFollowUp,
            User lastModifiedBy, DateTime lastModifiedDate, bool isOperatingEngineerLog,
            string documentLinks, bool recommendForShiftSummary, string plainTextComments,
            DateTime? actualLoggedDateTime, List<CustomFieldEntryHistory> customFieldEntryHistories)
            : base(id, lastModifiedBy, lastModifiedDate)
        {
            this.id = id;
            FunctionalLocations = functionalLocations;
            InspectionFollowUp = inspectionFollowUp;
            ProcessControlFollowUp = processControlFollowUp;
            OperationsFollowUp = operationsFollowUp;
            SupervisionFollowUp = supervisionFollowUp;
            EnvironmentalHealthSafetyFollowUp = environmentalHealthSafetyFollowUp;
            OtherFollowUp = otherFollowUp;
            PlainTextComments = plainTextComments;
            IsOperatingEngineerLog = isOperatingEngineerLog;
            DocumentLinks = documentLinks;
            RecommendForShiftSummary = recommendForShiftSummary;
            ActualLoggedDateTime = actualLoggedDateTime;
            CustomFieldEntryHistories = customFieldEntryHistories ?? new List<CustomFieldEntryHistory>();
        }

        public DateTime? ActualLoggedDateTime { get; private set; }

        public string FunctionalLocations { get; private set; }

        public bool InspectionFollowUp { get; private set; }

        public bool ProcessControlFollowUp { get; private set; }

        public bool OperationsFollowUp { get; private set; }

        public bool SupervisionFollowUp { get; private set; }

        public bool EnvironmentalHealthSafetyFollowUp { get; private set; }

        public bool OtherFollowUp { get; private set; }

        public bool IsOperatingEngineerLog { get; private set; }

        public string DocumentLinks { get; private set; }

        public bool RecommendForShiftSummary { get; private set; }

        public string PlainTextComments { get; private set; }

        public List<CustomFieldEntryHistory> CustomFieldEntryHistories { get; private set; }
    }
}