using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IShiftHandoverQuestionnaireDetails : IDeletableDetails
    {
        event EventHandler MarkAsRead;
        event EventHandler Print;
        event EventHandler Preview;
        event EventHandler Email;

        event CustomFieldEntryClickHandler SummaryLogCustomFieldEntryClicked;
        event CustomFieldEntryClickHandler ShiftLogCustomFieldEntryClicked;
        event Action<ShiftHandoverQuestionnaire> DetailsMarkedAsReadByToggled;

        bool MarkAsReadEnabled { set; }
        bool PrintEnabled { set; }
        bool PreviewEnabled { set; }
        bool EmailEnabled { set; }

        string CreatedBy { set; }
        string CreatedDateTime { set; }
        List<FunctionalLocation> FunctionalLocations { set; }
        string ShiftHandoverConfigurationName { set; }
        List<ShiftHandoverAnswer> Answers { set; }
        void SetAndFormatComments(ShiftHandoverQuestionnaire handover, List<HasCommentsDTO> summaryLogComments, List<HasCommentsDTO> logComments);
        List<ItemReadBy> MarkedAsReadBy { set; }

        bool MarkAsReadVisible { set; }
        bool PrintVisible { set; }
        WorkAssignment Assignment { set; }
        void ClearComments();
        void AddSummaryLogCustomFieldEntries(List<HasCommentsDTO> summaryLogs, Dictionary<long, List<CustomField>> summaryLogIdToCustomFieldsMap);
        void HideSummaryLogCustomFieldEntries();
        void HideShiftLogCustomFieldEntries();
        void AddShiftLogCustomFieldEntries(List<HasCommentsDTO> logs, Dictionary<long, List<CustomField>> logIdToCustomFieldsMap);
        void AddCokerCardSummaries(List<CokerCardDrumEntryDTO> cokerCardSummaries);
        void MakeAllButtonsInvisible();

        void AddMarkedAsReadUser(ItemReadBy itemReadBy);
    }
}