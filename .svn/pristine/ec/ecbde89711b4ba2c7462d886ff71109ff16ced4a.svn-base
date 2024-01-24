using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ILogFormView : ILogCopyFormView, IImportCustomFieldsView, ILogValidationAction, ILogTemplateView
    {
        bool EHSFollowUp { get;set;}
        bool InspectionFollowUp { get;set;}
        bool OperationsFollowUp { get;set;}
        bool ProcessControlFollowUp { get;set;}
        bool SupervisionFollowUp { get;set;}
        bool OtherFollowUp { get;set; }

        bool IsOperatingEngineerLog { get;set; }
        bool ViewEditHistoryEnabled { set; }
        bool SelectLogsForSummaryButtonEnabled { set; }

        string Shift { set; }
        string Author { set; }
        string SetShiftLogMenuItemName { set; } //RITM0443261 : Added by Vibhor {Change the name for Shift log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}

        bool MultipleFunctionalLocationOptionsEnabled { set; }
                
        string CommentsAsPlainText { get; }
        bool LogTimeControlEnabled { get; set; }

        FunctionalLocation SelectedFunctionalLocation { get;}
       
        DialogResultAndOutput<IList<FunctionalLocation>> ShowFunctionalLocationSelector(
            List<FunctionalLocation> initialUserFLOCSelection, FunctionalLocationType selectionFLOCLevel);

        List<DocumentLink> AssociatedDocumentLinks { get; set; }

        void SetupForEdit();

        string OperatingEngineerLogDisplayName { set;}
        void HideOperatingEngineerCheckBox();        

        bool RecommendForShiftSummary { get; set; }
        void HideFunctionalLocationButtonsAndDisableMultipleFunctionalLocationOptions();

        DialogResultAndOutput<List<string>> ShowSelectLogsForSummaryForm();
        void AppendComments(List<string> textToAppend);

        void ShowGuidelines(List<LogGuideline> guidelines);

        bool ShowLogMarkedAsReadWarning();

        void HideFollowupFlags();
        void HideMultipleFunctionalLocationOptions();
        bool ExpandAdditionalDetails { set; }
        new DateTime LogDateTime { get; set; }

        void SetCustomFieldPhTagAssociationControlsVisible(bool hasPhdReadCustomField, bool hasPhdWriteCustomField);
        void TurnOnCustomFieldPhTagHighlights(List<CustomFieldEntry> entries);
        new void SetCustomFieldEntries(List<CustomFieldEntry> customFieldEntries, List<CustomField> customFields);

        //Mukesh for Log Image
         List<LogImage> ImageLogdetails { set; get; }
          bool setLogImage
         {

             set;
         }

    }
}