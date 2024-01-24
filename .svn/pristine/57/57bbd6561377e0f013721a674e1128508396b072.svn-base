using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface ILogDefinitionDetails : IDeletableDetails
    {
        bool DeleteEnabled { set; }

        event EventHandler Delete;
        event CustomFieldEntryClickHandler CustomFieldEntryClicked;

        string CreationDateTime { set; }
        string Comments { set; }
        List<FunctionalLocation> FunctionalLocations { set; }
        void SetCustomFieldEntries(List<CustomFieldEntry> customFieldEntries, List<CustomField> customFields);
        bool CreateALogForEachFunctionalLocation { set; }

        bool ProcessControl { set; }
        bool Operations { set; }
        bool Inspection { set; }
        bool Supervision { set; }
        bool EnvironmentalHealthAndSafety { set; }
        bool OtherFollowUp { set; }

        bool IsOperatingEngineerLog { set; }
        string OperatingEngineerLogDisplayText { set; }

        string RecurrenceStartDate { set; }
        string RecurrenceEndDate { set; }
        string RaiseStartTime { set; }
        string RecurrencePattern { set; }

        List<DocumentLink> DocumentLinks { set; }

        string WorkAssignment { set; }

        bool OptionsVisible { set; }
        bool CustomFieldsPanelVisible { set; }
        bool FollowupPanelVisible { set; }
        bool MultipleFlocOptionsVisible { set; }
    }
}
