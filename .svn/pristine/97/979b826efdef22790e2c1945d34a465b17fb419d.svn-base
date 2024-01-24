using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class SummaryLogHistory : DomainObjectHistorySnapshot
    {
        public SummaryLogHistory(long id, string functionalLocationList, bool inspectionFollowUp,
            bool processControlFollowUp, bool operationsFollowUp, bool supervisionFollowUp,
            bool environmentalHealthSafetyFollowUp, bool otherFollowUp, DateTime logDateTime, User lastModifiedBy,
            DateTime lastModifiedDate, string documentLinks, string plainTextComments, string dorComments,
            List<CustomFieldEntryHistory> customFieldEntryHistories)
            : base(id, lastModifiedBy, lastModifiedDate)
        {
            FunctionalLocations = functionalLocationList;
            InspectionFollowUp = inspectionFollowUp;
            ProcessControlFollowUp = processControlFollowUp;
            OperationsFollowUp = operationsFollowUp;
            SupervisionFollowUp = supervisionFollowUp;
            EnvironmentalHealthSafetyFollowUp = environmentalHealthSafetyFollowUp;
            OtherFollowUp = otherFollowUp;
            LogDateTime = logDateTime;
            DocumentLinks = documentLinks;
            PlainTextComments = plainTextComments;
            DorComments = dorComments;
            CustomFieldEntryHistories = customFieldEntryHistories;
        }

        public string FunctionalLocations { get; private set; }

        public bool InspectionFollowUp { get; private set; }

        public bool ProcessControlFollowUp { get; private set; }

        public bool OperationsFollowUp { get; private set; }

        public bool SupervisionFollowUp { get; private set; }

        public bool EnvironmentalHealthSafetyFollowUp { get; private set; }

        public bool OtherFollowUp { get; private set; }

        public DateTime LogDateTime { get; private set; }

        public string DocumentLinks { get; private set; }

        public string PlainTextComments { get; private set; }

        public string DorComments { get; private set; }

        public List<CustomFieldEntryHistory> CustomFieldEntryHistories { get; private set; }
    }
}