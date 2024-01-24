using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ISummaryLogFormView : IBaseForm, IImportCustomFieldsView, ICustomFieldValidationAction, ILogTemplateView
    {
        void SetCommentsBlankError();
        void SetFunctionLocationBlankError();
        void SetLogDateTimeError();

        Time ActualLoggedTime { get; }
        DateTime LogDateTime { get; set; }

        bool EHSFollowUp { get;set;}
        bool InspectionFollowUp { get;set;}
        bool OperationsFollowUp { get;set;}
        bool ProcessControlFollowUp { get;set;}
        bool SupervisionFollowUp { get;set;}
        bool OtherFollowUp { get;set; }

        bool ViewEditHistoryEnabled { set; }

        string RtfComments { set; get; }
        string CommentsAsPlainText { get; }
        string DorComments { set; get; }
               
        string Shift { set; }
        string Author { set; }

        string SelectLogIDsForSummaryPresenter { set; get; }//RITM0164968-  mangesh
        
        FunctionalLocation SelectedFunctionalLocation { get; }
        List<FunctionalLocation> AssociatedFunctionalLocations { get;  set; }
        
        DialogResultAndOutput<List<FunctionalLocation>> ShowFunctionalLocationSelector(
                List<FunctionalLocation> initialUserFLOCSelections);

        List<DocumentLink> AssociatedDocumentLinks { get; set; }
        
        DialogResultAndOutput<List<string>> ShowSelectLogsForSummaryForm();

        void SetCustomFieldEntries(List<CustomFieldEntry> customFieldEntries, List<CustomField> customFields);
        void ShowTooLateToSaveDialog();
        bool IsCommentEmpty { get; }
        void SetCustomFieldPhTagAssociationControlsVisible(bool hasPhdReadCustomField, bool hasPhdWriteCustomField);
        void AppendComments(List<string> comments);
        void ShowGuidelines(List<LogGuideline> logGuidelines);
        void SetLogTimeInTheFutureError();
        bool ShowLogMarkedAsReadWarning();
        void TurnOnCustomFieldPhTagHighlights(List<CustomFieldEntry> entries);
        void MakeCommentControlFillAnyVerticalSpace();

        string SetShiftSummaryLogMenuItemName { set; } //RITM0443261 : Added by AMIT {Change the name for Shift log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}
        //Mukesh for Log Image
        List<LogImage> ImageLogdetails { set; get; }
        bool setLogImage
        {

            set;
        }

    }
}