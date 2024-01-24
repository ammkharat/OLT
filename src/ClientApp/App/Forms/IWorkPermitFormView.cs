using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IWorkPermitFormView : IBaseForm
    {
        void SetEnableOnWorkPermitSection(WorkPermitSection type, bool access);
        void InitializeStandardGasTestElementInfoList(List<GasTestElementInfo> list);
        bool EquipmentConditionPurgedMethodTextBoxEnabled { set; }
        List<CraftOrTrade> CraftOrTrades { get; set; }
        IList<AcidClothingType> AcidClothingTypes { set; }
        List<Contractor> Contractors { set; }
        bool ViewEditHistoryEnabled { set; }
        List<IGasTestElementDetails> GasTestElementDetailsList { get; }
        bool GasTestEventsEnabled { set; }
        bool IsConfinedSpaceEntry { get; }
        bool IsVehicleEntry { get; }
        bool IsBurnOrOpenFlame { get; }
        bool IsExcavation { get; }
        bool IsAsbestos { get; }
        bool IsRadiationRadiography { get; }
        bool ControlRoomsHasBeenContactedGroupBox { get; set; }// RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia  
        
        bool IsFreshAir { get; } // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia  
        
        bool IsHazardousEnergyIsolationChecked { get; set; }    // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        bool JobWorksiteIsPermitReceiverFieldNObutton { get; set; }    // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        bool JobWorksiteIsPermitReceiverFieldOrEquipmentOrientationNotApplicable { get; set; }    // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        bool AsbestosHazardsConsideredYesRadioButtonChecked { get; set; }    // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        bool IsAsbestosHazardPanel { get; set; }    // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        bool EquipmentIsHazardousEnergyIsolationRequiredNotApplicable { get; set; }    // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia

//DMND0010814 / RITM0422801 : Added By Vibhor - Sarnia SWP New Changes
        bool FireIsTwentyABCorDryChemicalExtinguisher { get; set; }   
        bool JobWorksiteIsSewerIsolationMethodSealedOrCovered { get; set; }  
        bool JobWorksiteIsSewerIsolationMethodNotApplicable { get; set; }

        //bool PermitReceiverOrientationCommentsPanelVisiblity
        //{
        //    get; 
        //    set;
        //}
        
         
        

        
//END
        
        
         

        User Author { set; }
        bool EnableCraftOrTradeRadio { set; }
        bool ToggleInputBoxEnabled { set; }
        FunctionalLocation FunctionalLocation { get; set; }
        bool RespiratoryIsHalfFaceRespirator { get; }
        bool RespiratoryIsFullFaceRespirator { get; }
        bool RespiratoryCartridgeTypeTextBoxEnabled { get; set; }
        WorkPermitType WorkPermitType { get; set;  }

        void ExpandOrCollapseGroups(bool b);
        FunctionalLocation ShowFunctionalLocationSelector();

        void ValidateFullyFailedMessage();
        void ValidatePassedButCannotApproveMessage();
        void ValidateFullySucceededMessage();

        void SetContractorFieldsToDefaultState();

        void SetError(string controlName, ProblemLevel level, string message);

        void IndicateProblemOnSection(WorkPermitSection section, ProblemLevel level);
        void ClearErrorProviders();
        void ShowImmediateAreaGasTestResultOutOfRangeWarning(GasTestElementInfo gasTestElementInfo);
        void ShowConfinedSpaceGasTestResultOutOfRangeWarning(GasTestElementInfo gasTestElementInfo);
        void ShowSystemEntryGasTestResultOutOfRangeWarning(GasTestElementInfo info);

        void RegisterUIEventHandlers<T>(WorkPermitFormPresenter<T> presenter) where T : IWorkPermitFormView;

        void SetInitialFocus();

        bool HasWorkAssignmentFunctionality { get; }
        WorkAssignment WorkAssignment { get; set; }
        List<WorkAssignment> WorkAssignmentSelectionList { set; }

        bool StartTimeNotApplicable { set; }
    }
}
