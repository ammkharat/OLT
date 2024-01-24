using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ITargetAlertResponseFormView : IBaseForm
    {
        event EventHandler LoadView;

        /// <summary>
        /// Fired when the user wants to search for a functional location.
        /// </summary>
        event EventHandler SearchFunctionalLocation;

        /// <summary>
        /// Fired when the user wants to clear their selected functional location.
        /// </summary>
        event EventHandler ClearFunctionalLocation;

        /// <summary>
        /// Fired when the user wants to create a response.
        /// </summary>
        event EventHandler CreateResponse;
        event EventHandler CancelResponse;
        event EventHandler OnCreateLogCheckChanged;

        string Title { set; }
        TargetGapReason[] GapReasonChoices { set; }
        TargetGapReason GapReason { get; }
        string ResponsibleFunctionalLocationText { set; }
        string Comment { get; set; }
        bool CreateLogChecked { get; set; }

        // Contextual information about the target alert we're responding to:
        DateTime CreateDateTime { get; set; }
        string ShiftPatternName { set; }
        User Author { set; }
        string TargetName { set; }
        string TargetDefinitionAuthor { set; }
        string CategoryName { set; }
        string FunctionalLocationName { set; }
        string FunctionalLocationDescription { set; }
        string MeasurementTagName { set; }
        string Description { set; get;}

        // Threshold values:
        string MeasurementTagUnit { set; }
        decimal? NeverToExceedMaximum { set; }
        decimal? MaxValue { set; }
        decimal? MinValue { set; }
        decimal? NeverToExceedMinimum { set; }
        string TargetValue { set; }

        void ShowGapReasonRequiredError();
        void ClearErrorProviders();
        void EnableMakingAnOperatingEngineerLog(bool isOperatingEngineerLogsEnabledForSite);
        bool IsLogAnOperatingEngineeringLog { get; set; }
        string OperatingEngineerLogDisplayText { set; }
        string TargetNameLabel { set; }
        string TargetSummaryLabel { set; }

        bool ShowConfirmationDialog();
        void HideDetails();
    }
}
