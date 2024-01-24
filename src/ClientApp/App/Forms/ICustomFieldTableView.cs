using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ICustomFieldTableView : IBaseForm
    {
        event Action CloseButtonClick;
        event Action ViewLoad;
        event Action ViewShown;
        event Action RefreshClick;
        event Action ExportClick;

        string Title { set; }
        bool FixedRangeChecked { get; set; }
        bool CustomRangeChecked { get; }
        Duration SelectedFixedRangeDuration { get; set; }
        Date StartDate { get; set; }
        Date EndDate { get; set; }
        List<NonnumericCustomFieldEntryDTO> CustomFieldEntries { set; }
        string DisclaimerLabel { set; }
        void AddFixedRangeDuration(Duration duration);
        void ExportToExcel();
    }
}
