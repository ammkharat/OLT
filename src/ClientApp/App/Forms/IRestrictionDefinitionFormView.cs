using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IRestrictionDefinitionFormView: IBaseForm
    {
        string Name { get;set; }
        string Description { get; set;}

        string HourFrequency { get; set; } //DMND0010124 mangesh

        FunctionalLocation FunctionalLocation { get; set; }
        TagInfo MeasurementTagInfo { get; set; }
        int? ProductionTargetValue { get; set; }
        TagInfo ProductionTargetTagInfo { get; set; }
        bool IsActive { get; set; }
        User Author { set; }
        DateTime CreateDateTime { set; }

        bool IsProductionTargetTypeValue { set; }
        string MeasurementTagValue { set; }
        bool RefreshMeasurmentTagValueEnabled { set; }
        string ProductionTargetTagValue { set; }
        bool RefreshProductionTargetTagValueEnabled { set; }

        bool IsActiveCheckBoxEnabled { set; }
        bool ViewEditHistoryEnabled { set; }
        bool HideDeviationAlerts { get; set; }
        //Added by Mukesh for RITM0219490
        int? ToleranceValue { get; set; }
        //End
        void ClearErrorProviders();
        void ShowNameIsEmptyError();
        void ShowDescriptionIsEmptyError();
        //void ShowHourFrequencyIsEmptyError();  //DMND0010124 mangesh
        void ShowNoFunctionalLocationsSelectedError();
        void ShowNoMeasurementTagInfoSelectedError();
        void ShowNoProductionTargetValueError();
        void ShowNoProductionTargetTagInfoError();
        void ShowNameError(string message);

        DialogResultAndOutput<FunctionalLocation> ShowFunctionalLocationSelector();
        DialogResultAndOutput<TagInfo> ShowTagSelector();

        void DisableControlsForBackgroundWorker();
        void EnableControlsForBackgroundWorker();        
    }
}