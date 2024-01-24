using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IDirectiveFormView : IAddEditBaseFormView, ILogTemplateView
    {
        IMultiSelectFunctionalLocationSelectionForm FlocSelector { set; }
        DateTime ActiveFromDateTime { get; set; }
        DateTime ActiveToDateTime { get; set; }
        string Content { get; set; }
        string PlainTextContent { get; }
        List<FunctionalLocation> FunctionalLocations { get; set; }
        List<WorkAssignment> SelectedWorkAssignments { get; set; }
        List<DocumentLink> DocumentLinks { get; set; }
        FunctionalLocation SelectedFunctionalLocation { get; }
        User LastModifiedBy { set; }
        DateTime LastModifiedDateTime { set; }
        User CreatedBy { set; }
        DateTime CreatedDateTime { set; }
        bool HistoryButtonEnabled { set; }
        string ExtraInfoFromMigrationSource { set; }
        string WindowTitleText { set; }
        event Action AddFunctionalLocationButtonClicked;
        event Action RemoveFunctionalLocationButtonClicked;
        event Action AddRemoveWorkAssignmentButtonClicked;
        event Action HistoryButtonClicked;

        DialogResultAndOutput<List<FunctionalLocation>> ShowFunctionalLocationSelector(
            List<FunctionalLocation> flocSelections);

        DialogResultAndOutput<IList<WorkAssignment>> ShowWorkAssignmentSelector(List<WorkAssignment> selectedAssignments);

        void SetErrorForActiveFromMustBeBeforeActiveTo();
        void SetErrorForEmptyContent();
        void SetErrorForNoFunctionalLocationSelected();
        void HideExtraInfo();
        //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

        List<ImageUploader> ImageDirectivedetails { set; get; }
        bool setDirectiveImage
        { set; }

        bool EnableImagePanel
        {
            get;set;
        }

        bool EnableImagePanelDirective
        {
            get;
            set;
        }


        bool EnableImagePanelDirectiveTitle
        {
            get;
            set;
        }

         bool EnableAddButton { get; }
         string FilePathText { get; }
         void SetErrorForAddButton();
        
        

        //END
    }
}