using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ISelectItemsForShiftSummaryFormView : IBaseForm
    {
        List<IShiftSummaryItemGridDisplayAdapter> ItemList { set; }
        List<ItemReadBy> MarkedAsReadByList { set; }
        void SetDetails(Log item, List<CustomField> customFields);
        void SetDetails(ShiftHandoverQuestionnaire item);                

        void SetResultToOk();
        void HideDetails();
        void ShowDetails();
        List<string> BuildCommentRichText(List<RtfChunk> rtfCommentChunks);

        void UseLogDetails();
        void UseShiftHandoverQuestionnaireDetails();
        event Action FormLoad;
        event Action AppendToCommentsButtonClicked;
        event Action<object> SelectedItemChanged;
        event Action<object> ItemSelectedForSummary;
        event Action<object> ItemUnselectedForSummary;
        event Action<WidgetAppearance> DateRangeButtonClicked;
        event Action<Log> DetailsMarkedAsReadByToggled;
        DialogResultAndOutput<Range<Date>> DisplayDateRangeDialog();
        void ShowCurrentAppearanceForDateRangeButton();
        void ShowDateRangeAppearanceForDateRangeButton();
        void SetGridHeader(string title);
    }
}
