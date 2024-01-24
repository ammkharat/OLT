using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters
{
    public enum ShiftSummaryItemType { Log, ShiftHandoverQuestions };

    public interface IShiftSummaryItemGridDisplayAdapter
    {
        ShiftSummaryItemType ItemType { get; }
        ShiftSummaryItemSource Source { get; }
        string FunctionalLocationNames { get; }
        DateTime LoggedDateTime { get; }
        string CreatedBy { get; }
        string WorkAssignmentName { get; }
        string RecommendedForSummary { get; }
        bool IncludeInSummary { get; set; }
    }
}
