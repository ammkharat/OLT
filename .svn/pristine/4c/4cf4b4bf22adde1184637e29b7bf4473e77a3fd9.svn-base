using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public interface IWorkPermitFilterSelectorPresenter
    {
        void HandleSelectButtonClick(object sender, EventArgs e);
        void HandleFormLoad(object sender, EventArgs e);
        void SetCustomDateRange();
        void SetDateRangeBackFromToday();
        void HandleCancelButtonClick(object sender, EventArgs e);
        void HandleFixedRangeSelected(object sender, EventArgs e);
        void HandleCustomRangeSelected(object sender, EventArgs e);
        Range<Date> DateRange { get; }
        List<WorkPermitStatus> SelectedStatuses { get; }
        bool DisplaySelector();
    }
}