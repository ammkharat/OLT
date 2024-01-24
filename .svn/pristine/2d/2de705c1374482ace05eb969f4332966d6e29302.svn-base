using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ILogDefinitionFormView : IBaseForm, ICustomFieldValidationAction, ICustomFieldsView, ILogTemplateView
    {
        void SetCommentsBlankError();

        User Author { set; }
        DateTime LastModifiedDateTime { set; }
        bool EHSFollowUp { get;set;}
        bool InspectionFollowUp { get;set;}
        bool OperationsFollowUp { get;set;}
        bool ProcessControlFollowUp { get;set;}
        bool SupervisionFollowUp { get;set;}
        bool OtherFollowUp { get;set;}
        bool IsOperatingEngineerLog { get; set; }
        string Title { set; }
        bool ViewEditHistoryEnabled { set; }

        List<FunctionalLocation> FunctionalLocationData { get; set; }
        bool CreateALogForEachFunctionalLocation { get; set; }

        string Comments { set; get; }        
        string CommentsAsPlainText { get; }        

        List<ScheduleType> ScheduleTypes { set;}
        ISchedule Schedule { get; set;}

        List<DocumentLink> AssociatedDocumentLinks { get; set; }

        bool HasScheduleError { get; }

        void RepeatingLogCannotBeAtASecondLevelFloc();
        
        void SetCustomFieldEntries(List<CustomFieldEntry> customFieldEntries, List<CustomField> customFields);
        string GetCustomFieldEntryText(CustomFieldEntry entry);

        bool IsCommentEmpty { get; }
        bool MultipleFunctionalLocationOptionsEnabled { set; }
        FunctionalLocation SelectedFunctionalLocation { get; }
        string OperatingEngineerLogDisplayName { set; }
        bool ExpandAdditionalDetails { set; }
        bool OptionsSectionHidden { set; }
        bool IsInactiveCheckboxHidden { set; }
        bool IsOperatingEngineerLogCheckboxEnabled { set; }
        bool IsOperatingEngineerLogCheckboxHidden { set; }
        bool IsInactive { get; set; }
        void ShowGuidelines(List<LogGuideline> logGuidelines);

        void HideFollowupFlags();
        void HideMultipleFunctionalLocationOptions();
        void TurnOffCustomFieldPhTagHighlights();
        void HideFunctionalLocationButtonsAndDisableMultipleFunctionalLocationOptions();
        DialogResultAndOutput<IList<FunctionalLocation>> ShowFunctionalLocationSelector(List<FunctionalLocation> initialUserFLOCSelection, FunctionalLocationType selectionFLOCLevel);
        void SetFunctionalLocationsEmptyError();
    }
}