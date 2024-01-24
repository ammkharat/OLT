using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls.Reporting
{
    public interface IDailyShiftLogReportParametersControl : IReportParametersControl
    {
        List<ShiftPattern> AvailableShiftPatterns { set; }
        List<TagInfoGroup> AvailableTagInfoGroups { set; }

        List<ShiftPattern> SelectedShiftPatterns { get; }
        TagInfoGroup SelectedTagInfoGroup { get; }
        Date SelectedDate { get;}
    }
}