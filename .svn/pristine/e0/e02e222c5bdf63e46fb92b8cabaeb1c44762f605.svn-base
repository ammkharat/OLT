using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class LogDefinitionHistory : DomainObjectHistorySnapshot
    {
        public LogDefinitionHistory(long id, DateTime lastModifiedDate, User lastModifiedBy,
            string schedule, string functionalLocations, string documentLinks,
            bool inspectionFollowUp, bool processControlFollowUp, bool operationsFollowUp,
            bool supervisionFollowUp, bool environmentalHealthSafetyFollowUp, bool otherFollowUp,
            bool deleted,
            string plainTextComments,
            bool active,
            List<CustomFieldEntryHistory> customFieldEntries) : base(id, lastModifiedBy, lastModifiedDate)
        {
            PlainTextComments = plainTextComments;
            Active = active;
            CustomFieldEntries = customFieldEntries ?? new List<CustomFieldEntryHistory>();
            Schedule = schedule;
            FunctionalLocations = functionalLocations;
            DocumentLinks = documentLinks;
            InspectionFollowUp = inspectionFollowUp;
            ProcessControlFollowUp = processControlFollowUp;
            OperationsFollowUp = operationsFollowUp;
            SupervisionFollowUp = supervisionFollowUp;
            EnvironmentalHealthSafetyFollowUp = environmentalHealthSafetyFollowUp;
            OtherFollowUp = otherFollowUp;
            Deleted = deleted;
        }

        public string PlainTextComments { get; private set; }

        public bool Active { get; private set; }

        public List<CustomFieldEntryHistory> CustomFieldEntries { get; private set; }

        public string Schedule { get; private set; }

        public string FunctionalLocations { get; private set; }

        public string DocumentLinks { get; private set; }

        public bool InspectionFollowUp { get; private set; }

        public bool ProcessControlFollowUp { get; private set; }

        public bool OperationsFollowUp { get; private set; }

        public bool SupervisionFollowUp { get; private set; }

        public bool EnvironmentalHealthSafetyFollowUp { get; private set; }

        public bool OtherFollowUp { get; private set; }

        public bool Deleted { get; private set; }
    }
}