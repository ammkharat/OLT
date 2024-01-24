using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IRestrictionFlocsFormView : IBaseForm
    {
        event Action SaveClicked;
        event Action FormLoad;
        event Action<AssignmentFlocConfiguration> WorkAssignmentAreaSelected;
        event Action CancelClicked;
        event Action ClearClicked;
        event Action CopyLoginFlocsClicked;

        List<AssignmentFlocConfiguration> ConfigurationList { set; }
        IList<FunctionalLocation> SelectedAssignmentDefaultFunctionalLocations { set; get; }

        bool FunctionalLocationSelectionEnabled { set; }
        string Title { set; }
        bool CopyLoginFlocsButtonVisible { set; }

        void ClearFunctionalLocations();
        void SelectFirstWorkAssignment();
        DialogResult ShowYesNoWarningBox(string title, string message);
        void ShowInfoMessageBox(string title, string message);
    }
}
