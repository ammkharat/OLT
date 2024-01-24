using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigureDefaultFlocsForDailyAssignmentView : IBaseForm
    {
        List<WorkAssignment> WorkAssignmentList { set; }
        IList<FunctionalLocation> SelectedAssignmentDefaultFunctionalLocations { set; get; }

        bool FunctionalLocationSelectionEnabled { set; }
        FunctionalLocationMode FunctionalLocationMode { set; }

        void ClearFunctionalLocations();
        void SelectFirstWorkAssignment();
    }
}
