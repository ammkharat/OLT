using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IFormOilsandsTrainingView : IAddEditBaseFormView
    {
        event Action AddFunctionalLocationButtonClicked;
        event Action RemoveFunctionalLocationButtonClicked;
        event Action FormLoad;
        event Action<FormApproval> ApprovalSelected;
        event Action<FormApproval> ApprovalUnselected;
        event Action SaveAndEmailButtonClicked;
        event Action AddTrainingBlockClicked;
        event Action RemoveTrainingBlockClicked;
        event Action HistoryClicked;

        List<FunctionalLocation> FunctionalLocations { set; get; }
        FunctionalLocation SelectedFunctionalLocation { get; }
        List<FormApproval> Approvals { set; get; }
        User CreatedByUser { set; }
        DateTime CreatedDateTime { set; }
        User LastModifiedByUser { set; }
        DateTime LastModifiedDateTime { set; }
        List<ShiftPattern> ShiftPatterns { set; }
        List<TrainingBlock> TrainingBlocks { set; }
        bool RemoveButtonEnabled { set; }
        List<OilsandsTrainingItemDisplayAdapter> TrainingItems { get; set; }
        bool ApprovalsEnabled { set; }
        bool HistoryButtonEnabled { set; }
        DialogResultAndOutput<List<FunctionalLocation>> ShowFunctionalLocationSelector(List<FunctionalLocation> initialUserFLOCSelections);
        void SetErrorForNoFunctionalLocationSelected();
        DialogResult ShowFormWillNeedReapprovalQuestion();
        void AddTrainingItem(OilsandsTrainingItemDisplayAdapter trainingItem);
        void RemoveSelectedTrainingItem();
        void ShowUnableToRemoveFunctionalLocationMessage(List<string> trainingBlockNames);
        void MakeTrainingGridValidationIconsShowOrDisappear();
        IFunctionalLocationValidator FlocValidator { set; }
        ShiftPattern Shift { get; set; }
        Date TrainingDate { get; set; }
        string GeneralComments { get; set; }
        void SetErrorForTrainingDateCannotBeInTheFuture();
        void SetErrorForDuplicateTrainingDateAndShift(string message);
        void SetErrorForNoGeneralComments();
        DialogResult ShowWarnings(List<string> warnings);
    }
}
