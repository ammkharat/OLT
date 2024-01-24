using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Validation.Edmonton;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IWorkPermitEdmontonView : IWorkPermitEdmontonSharedView
    {
        event Action FunctionalLocationBrowseClicked;
        event Action FormLoad;
        event Action SaveAndIssueButtonClicked;
        event Action PrintPreferencesButtonClicked;
        event Action ValidateButtonClicked;
        event Action ViewConfiguredDocumentLinkClicked;
        event Action GroupChanged;
        event Action ExpireTimeChangedByUser;
        

        bool ContinuousGasMonitorChecked { get; set; } //Mingle#4001, added on April 1, by mangesh
        new bool IssuedToContractor { get; set; }

        bool WorkOrderNumberReadOnly { set; }
        bool OperationNumberReadOnly { set; }
        bool SubOperationNumberReadOnly { set; }

        FunctionalLocation ShowSecondLevelOrLowerFunctionalLocationSelector();
        DateTime RequestedStartDateTime { get; set; }        
        DateTime ExpiryDateTime { get; set; }

        string PermitNumber { get; set; }
        string ClonedFormDetailEdmonton { get; set; } // Added by Vibhor : DMND0011077 - Work Permit Clone History

        bool DurationPermit { get; set; }
        List<WorkPermitEdmontonType> AllPermitTypes { set; }
        List<Contractor> AllCompanies { set; }
        List<WorkPermitEdmontonGroup> AllGroups { set; }
        List<CraftOrTrade> AllCraftOrTrades { set; }
        List<CraftOrTrade> AllRoadAccessOnPermitType { set; }
        List<SpecialWork> AllSpecialWorkType { set; get; }
        SpecialWork specialworktype { set; get; }//mangesh for SpecialWork
        string SpecialWorkName { get; set; }

        void SetOtherAreasAndOrUnitsAffected(bool otherAreasAndOrUnitsAffected, string otherAreasAndOrUnitsAffectedArea, string otherAreasAndOrUnitsAffectedPersonNotified);
                                         
        string ProductNormallyInPipingEquipment { get; set; }
        YesNoNotApplicable IsolationValvesLocked { get; set; }                
        YesNoNotApplicable DepressuredDrained { get; set; }
        YesNoNotApplicable Ventilated { get; set; }
        YesNoNotApplicable Purged { get; set; }
        YesNoNotApplicable BlindedAndTagged { get; set; }
        YesNoNotApplicable DoubleBlockAndBleed { get; set; }
        YesNoNotApplicable ElectricalLockout { get; set; }
        YesNoNotApplicable MechanicalLockout { get; set; }
        YesNoNotApplicable BlindSchematicAvailable { get; set; }
        string ZeroEnergyFormNumber { get; set; }
        string LockBoxNumber { get; set; }
        bool JobsiteEquipmentInspected { get; set; }
        string OperatorGasDetectorNumber { get; set; }

        YesNoNotApplicable QuestionOneResponse { get; set; }
        YesNoNotApplicable QuestionTwoResponse { get; set; }
        YesNoNotApplicable QuestionTwoAResponse { get; set; }
        YesNoNotApplicable QuestionTwoBResponse { get; set; }
        YesNoNotApplicable QuestionThreeResponse { get; set; }
        YesNoNotApplicable QuestionFourResponse { get; set; }

        string GasTestDataLine1CombustibleGas { get; set; }
        string GasTestDataLine1Oxygen { get; set; }
        string GasTestDataLine1ToxicGas { get; set; }
        Time GasTestDataLine1Time { get; set; }

        string GasTestDataLine2CombustibleGas { get; set; }
        string GasTestDataLine2Oxygen { get; set; }
        string GasTestDataLine2ToxicGas { get; set; }
        Time GasTestDataLine2Time { get; set; }

        string GasTestDataLine3CombustibleGas { get; set; }
        string GasTestDataLine3Oxygen { get; set; }
        string GasTestDataLine3ToxicGas { get; set; }
        Time GasTestDataLine3Time { get; set; }

        string GasTestDataLine4CombustibleGas { get; set; }
        string GasTestDataLine4Oxygen { get; set; }
        string GasTestDataLine4ToxicGas { get; set; }
        Time GasTestDataLine4Time { get; set; }
            
        bool StatusOfPipingEquipmentSectionNotApplicableToJob { get; set; }
        bool ConfinedSpaceWorkSectionNotApplicableToJob { get; set; }
        bool GasTestsSectionNotApplicableToJob { get; set; }
        bool WorkerToProvideGasTestData { get; set; }
        bool WorkerToProvideGasTestDataEnabled { get; set; }

        void ShowIsValidMessageBox();
        void ShowHasValidationErrorsMessageBox();
        void ShowHasValidationWarningsMessageBox();
        void ShowHasValidationWarningsAndErrorsMessageBox();

        void SetErrorForNoProductNormallyInPipingEquipment();
        void SetErrorForAtLeastOneGasTestsTableLineMustBeFilledOut();
        void SetErrorForGasTestsTableLine1IsInvalid();
        void SetErrorForGasTestsTableLine2IsInvalid();
        void SetErrorForGasTestsTableLine3IsInvalid();
        void SetErrorForGasTestsTableLine4IsInvalid();
        void SetErrorForNoOperatorGasDetectorNumber();
        void SetErrorForExpiryDateTimeInThePast();
        void SetErrorForNoIssuedToOptionSelected();
        void SetErrorForNoHazardsAndOrRequirements();
        void SetErrorForNoFireProtectiveMeasuresChosenButTypeIsHighEnergyHotWork();
        void SetErrorForQuestionOneNotSetToYes();

        void SetErrorForNoWorkersMonitorNumber();
        void SetErrorForNoRadioChannelNumber();

        void SetErrorForHazardsTooLong();

        void SetErrorForNoApprovedGN59Form();
        void SetErrorForNoApprovedGN6Form();
        void SetErrorForNoApprovedGN7Form();
        void SetErrorForNoApprovedGN24Form();
        void SetErrorForNoApprovedGN75AForm();
        void SetErrorForNoApprovedGN1Form();
        void ActionForValidTradeCheckGN1Form(); //Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016
        void ActionForGroupMaintenance(); // Swapnil Patki For DMND0005325 Point Number 9

        void SetErrorForNoConfinedSpaceCardNumber();
        void SetErrorForNoConfinedSpaceClass();
        void SetErrorForNoRescuePlanFormNumber();
        void SetErrorForInvalidGN11Value();
        void SetErrorForInvalidGN27Value();

        string oltlabel43 { get; set; } //Minlge Story #4002, Change By : Swapnil, Changed On : 30 Mar 2016

        //Changes for SNOW Incident # INC0025434 On 18Aug2016 by Dharmesh_s
        bool IsEdit { get; set; }
        bool IsClone { get; set; }
        //Changes for SNOW Incident # INC0025434 On 18Aug2016 by Dharmesh_e


        bool RadioChannelChecked { get; set; }
        bool RadioChannelEnabled { get; set; }
        bool SafetyWatchEnabled { get; set; }
        bool BarriersSignsEnabled { get; set; }
        bool ContinuousGasMonitorEnabled { get; set; }
        bool GasTestsSectionNotApplicableToJobEnabled { get; set; }
        bool WorkersMinimumSafetyRequirementsSectionNotApplicableToJobEnabled { get; set; }
        bool WorkersMonitorEnabled { get; set; }
        bool BumpTestMonitorPriorToUseEnabled { get; set; }
        bool ConfinedSpaceWorkSectionNotApplicableToJobEnabled { get; set; }
        bool RescuePlanEnabled { get; set; }
        bool BreathingAirApparatusEnabled { get; set; }
        bool StatusOfPipingEquipmentSectionNotApplicableToJobEnabled { get; set; }
        bool AirHornEnabled { get; set; }

        void ForceExecutionOfBusinessLogic(PermitRequestBasedWorkPermitStatus status);
        DialogResult ShowWarnings(WorkPermitEdmontonOtherWarnings otherWarnings, bool validationWarning);
        void ShowFlocNeedsToBeSelectedMessage();
        bool AllowEventsToOverrideUserSelectedCheckboxes { set; }
        List<DocumentLink> DocumentLinks { get; set; }
        void DisableConfiguredDocumentLinks();
        List<ConfiguredDocumentLink> ConfiguredDocumentLinks { set; }
        ConfiguredDocumentLink SelectedConfiguredDocumentLink { get; }
        bool ZeroEnergyFormNumberEnabled { get; set; }
        bool UseCurrentWorkPermitNumberEnabled { get; set; }
        bool UseCurrentPermitNumberForZeroEnergyFormNumber { get; set; }
        void OpenFileOrDirectoryOrWebsite(string path);

        string PermitAcceptor { get; set; }        
        string ShiftSupervisor { get; set; }
        List<string> ShiftSupervisorSelectionList { set; }
        List<Priority> Priorities { set; }
        Priority Priority { get; set; }
        List<string> AllAffectedAreas { set; }
        bool SaveAndIssueButtonEnabled { set; }

        void TurnOnAutosetIndicatorsForDateTimes();
        void ClearAutosetIndicatorsForDateTimes();

        void DisplayInvalidPrintMessage(string message);
        void DisplayErrorMessageDialog(string message, string title);
        void PopulateFunctionalLocationSelector(List<FunctionalLocation> functionalLocations);
    }
}