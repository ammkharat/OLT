using System;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ShiftHandoverQuestionsSummaryItemGridDisplayAdapter : IShiftSummaryItemGridDisplayAdapter
    {
        private readonly ShiftHandoverQuestionnaireDTO dto;

        public ShiftHandoverQuestionsSummaryItemGridDisplayAdapter(ShiftHandoverQuestionnaireDTO dto)
        {
            this.dto = dto;
        }

        public ShiftSummaryItemType ItemType { get { return ShiftSummaryItemType.ShiftHandoverQuestions; } }

        public ShiftSummaryItemSource Source
        {
            get { return ShiftSummaryItemSource.HandoverQuestions; }
        }

        public string FunctionalLocationNames
        {
            get { return dto.FunctionalLocations; }
        }

        public DateTime LoggedDateTime
        {
            get { return dto.CreateDateTime; }
        }

        public string CreatedBy
        {
            get { return dto.CreateUser; }
        }

        public string WorkAssignmentName
        {
            get { return dto.AssignmentName; }
        }

        public string RecommendedForSummary
        {
            get { return StringResources.NotApplicable; }
        }

        public bool IncludeInSummary { get; set; }

        public ShiftHandoverQuestionnaireDTO GetShiftHandoverQuestionnaireDTO()
        {
            return dto;
        }
    }
}
