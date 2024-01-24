using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IDirectiveLogFormView : ILogCopyFormView, IImportCustomFieldsView, ICustomFieldValidationAction, ILogTemplateView
    {
        void SetCommentsBlankError();
        void SetFunctionLocationBlankError();

        bool EHSFollowUp { get;set;}
        bool InspectionFollowUp { get;set;}
        bool OperationsFollowUp { get;set;}
        bool ProcessControlFollowUp { get;set;}
        bool SupervisionFollowUp { get;set;}
        bool OtherFollowUp { get;set; }

        bool ViewEditHistoryEnabled { set; }

        string Shift { set; }
        string Author { set; }        

        bool MultipleFunctionalLocationOptionsEnabled { set; }
                
        string CommentsAsPlainText { get; }
        bool LogTimeControlEnabled { get; set; }

        FunctionalLocation SelectedFunctionalLocation { get;}
       
        DialogResultAndOutput<IList<FunctionalLocation>> ShowFunctionalLocationSelector(List<FunctionalLocation> initialUserFLOCSelection);

        List<DocumentLink> AssociatedDocumentLinks { get; set; }

        void SetupForEdit();

        Time ActualLoggedTime { get; }
        DateTime LogDateTime { get; set; }

        void SetLogTimeInTheFutureError();
        void SetLogDateTimeError();

        void HideFunctionalLocationButtonsAndDisableMultipleFunctionalLocationOptions();

        bool IsCommentEmpty { get; }

        void ShowGuidelines(List<LogGuideline> guidelines);
        bool ShowLogMarkedAsReadWarning();

        void TurnOnCustomFieldPhTagHighlights(List<CustomFieldEntry> entries);
        bool CustomFieldPhTagAssociationControlsVisible { set; }
    }
}
