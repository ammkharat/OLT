using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
    [Serializable]
    public class DetailedLogReportDTO : DomainObject
    {
        public DetailedLogReportDTO(
            long id, long shiftId, string shiftName, DateTime shiftStartDateTime, DateTime shiftEndDateTime,
            string lastModifiedByUser, DateTime logDateTime,
            string workAssignment,
            bool? recommendForSummary,
            bool inspectionFollowUp, bool processControlFollowUp, bool operationsFollowUp,
            bool supervisionFollowUp, bool environmentalHealthSafetyFollowUp, bool otherFollowUp,
            List<string> functionalLocationNames,
            List<FunctionalLocationSegmentDTO> functionalLocationSegmentDtos,
            List<DocumentLinkDTO> documentLinks,
            List<CustomFieldEntry> customFieldEntries,
            string plainTextComments,
            string rtfComments, string color)
        {
            this.id = id;

            ShiftId = shiftId;
            ShiftName = shiftName;
            ShiftStartDateTime = shiftStartDateTime;
            ShiftEndDateTime = shiftEndDateTime;

            LogDateTime = logDateTime;
            LastModifiedByUser = lastModifiedByUser;
            WorkAssignment = workAssignment;
            RecommendForSummary = recommendForSummary.HasValue && recommendForSummary.Value;

            PlainTextComments = plainTextComments;
            RtfComments = rtfComments;

            InspectionFollowUp = inspectionFollowUp;
            ProcessControlFollowUp = processControlFollowUp;
            OperationsFollowUp = operationsFollowUp;
            SupervisionFollowUp = supervisionFollowUp;
            EnvironmentalHealthSafetyFollowUp = environmentalHealthSafetyFollowUp;
            OtherFollowUp = otherFollowUp;

            FunctionalLocationNames = functionalLocationNames ?? new List<string>();
            FunctionalLocationNames.Sort();
            FunctionalLocationSegmentDtos = functionalLocationSegmentDtos ?? new List<FunctionalLocationSegmentDTO>();

            CustomFieldEntries = customFieldEntries ?? new List<CustomFieldEntry>();
            DocumentLinks = documentLinks ?? new List<DocumentLinkDTO>();
            
            Color = color;

        }
        public string Color { get; private set; }

        public long ShiftId { get; private set; }
        public string ShiftName { get; private set; }
        public DateTime ShiftStartDateTime { get; private set; }
        public DateTime ShiftEndDateTime { get; private set; }

        public string ShiftDisplayName
        {
            get { return UserShift.CreateShiftDisplayName(ShiftStartDateTime, ShiftName); }
        }

        public DateTime LogDateTime { get; private set; }
        public string LastModifiedByUser { get; private set; }
        public string WorkAssignment { get; private set; }
        public bool RecommendForSummary { get; private set; }

        public bool InspectionFollowUp { get; private set; }
        public bool ProcessControlFollowUp { get; private set; }
        public bool OperationsFollowUp { get; private set; }
        public bool SupervisionFollowUp { get; private set; }
        public bool EnvironmentalHealthSafetyFollowUp { get; private set; }
        public bool OtherFollowUp { get; private set; }

        public string PlainTextComments { get; private set; }
        public string RtfComments { get; private set; }

        public List<string> FunctionalLocationNames { get; private set; }

        public List<FunctionalLocationSegmentDTO> FunctionalLocationSegmentDtos { get; private set; }

        public List<CustomFieldEntry> CustomFieldEntries { get; set; }
        public List<DocumentLinkDTO> DocumentLinks { get; private set; }

        public void AddFunctionalLocation(string functionalLocationName)
        {
            FunctionalLocationNames.AddAndSort(functionalLocationName);
        }

        public void AddSegmentDto(FunctionalLocationSegmentDTO segmentDto)
        {
            if (!FunctionalLocationSegmentDtos.Exists(obj =>
                obj.Division == segmentDto.Division &&
                obj.Section == segmentDto.Section &&
                obj.Unit == segmentDto.Unit))
            {
                FunctionalLocationSegmentDtos.Add(segmentDto);
            }
        }

        public void AddCustomFieldEntry(CustomFieldEntry customFieldEntry)
        {
            if (customFieldEntry != null && !HasCustomFieldEntryAlready(customFieldEntry))
            {
                CustomFieldEntries.Add(customFieldEntry);
            }
        }

        private bool HasCustomFieldEntryAlready(CustomFieldEntry customFieldEntry)
        {
            return CustomFieldEntries.Exists(e => e.Id == customFieldEntry.Id);
        }

        public void AddDocumentLinkDto(DocumentLinkDTO documentLinkDto)
        {
            if (!DocumentLinks.Exists(obj =>
                obj.Title == documentLinkDto.Title &&
                obj.Url == documentLinkDto.Url))
            {
                DocumentLinks.Add(documentLinkDto);
            }
        }
    }
}