using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Validation.Lubes;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IWorkPermitLubesView : IAddEditBaseFormView
    {
        event Action SaveAndIssue;
        event Action FormLoad;
        event Action FormIsClosing;
        event Action FunctionalLocationBrowse;
        event Action ValidateForm;
        event Action ViewConfiguredDocumentLink;
        event Action ConfinedSpaceCheckedChanged;
        event Action PermitTypeChanged;
        event Action ViewHistory;

        FunctionalLocation ShowSecondLevelOrLowerFunctionalLocationSelector();
        void PopulateFunctionalLocationSelector(List<FunctionalLocation> functionalLocations);

        List<CraftOrTrade> CraftOrTrades { set; }
        List<Contractor> Contractors { set; }
        List<ConfiguredDocumentLink> ConfiguredDocumentLinks { set; }
        List<WorkPermitLubesGroup> RequestedByGroups { set; }
        List<string> SpecialWorkTypes { set; }
        void DisableConfiguredDocumentLinks();

        User LastModifiedBy { set; }
        DateTime LastModifiedDateTime { set; }

        bool IssuedToSuncor { get; set; }
        bool IssuedToCompany { get; set; }
        string Company { get; set; }
        string Trade { get; set; }
        int? NumberOfWorkers { get; set; }
        WorkPermitLubesGroup RequestedByGroup { get; set; }
        WorkPermitLubesType WorkPermitType { get; set; }
        bool IsVehicleEntry { get; set; }
        FunctionalLocation FunctionalLocation { get; set; }
        new string Location { get; set; }
        List<DocumentLink> DocumentLinks { get; set; }
        string WorkOrderNumber { get; set; }
        string OperationNumber { get; set; }
        string SubOperationNumber { get; set; }
        DateTime StartDateTime { get; set; }
        DateTime ExpireDateTime { get; set; }
        bool ConfinedSpace { get; set; }
        string ConfinedSpaceClass { get; set; }
        bool RescuePlan { get; set; }
        bool ConfinedSpaceSafetyWatchCheckList { get; set; }
        bool SpecialWork { get; set; }
        string SpecialWorkType { get; set; }
        bool HazardousWorkApproverAdvised { get; set; }
        bool AdditionalFollowupRequired { get; set; }
        WorkPermitSafetyFormState HighEnergy { get; set; }
        WorkPermitSafetyFormState CriticalLift { get; set; }
        WorkPermitSafetyFormState Excavation { get; set; }
        WorkPermitSafetyFormState EnergyControlPlanFormRequirement { get; set; }
        WorkPermitSafetyFormState EquivalencyProc { get; set; }
        WorkPermitSafetyFormState TestPneumatic { get; set; }
        WorkPermitSafetyFormState LiveFlareWork { get; set; }
        WorkPermitSafetyFormState EntryAndControlPlan { get; set; }
        WorkPermitSafetyFormState EnergizedElectrical { get; set; }

        List<WorkPermitSafetyFormState> HighEnergyValues { set; }
        List<WorkPermitSafetyFormState> CriticalLiftValues { set; }
        List<WorkPermitSafetyFormState> ExcavationValues { set; }
        List<WorkPermitSafetyFormState> EnergyControlPlanValues { set; }
        List<WorkPermitSafetyFormState> EquivalencyProcValues { set; }
        List<WorkPermitSafetyFormState> TestPneumaticValues { set; }
        List<WorkPermitSafetyFormState> LiveFlareWorkValues { set; }
        List<WorkPermitSafetyFormState> EntryAndControlPlanValues { set; }
        List<WorkPermitSafetyFormState> EnergizedElectricalValues { set; }

        string TaskDescription { get; set; }

        bool HazardHydrocarbonGas { get; set; }
        bool HazardHydrocarbonLiquid { get; set; }
        bool HazardHydrogenSulphide { get; set; }
        bool HazardInertGasAtmosphere { get; set; }
        bool HazardOxygenDeficiency { get; set; }
        bool HazardRadioactiveSources { get; set; }
        bool HazardUndergroundOverheadHazards { get; set; }
        bool HazardDesignatedSubstance { get; set; }

        string OtherHazardsAndOrRequirements { get; set; }

        string OtherAreasAndOrUnitsAffectedArea { get; }
        string OtherAreasAndOrUnitsAffectedPersonNotified { get; }
        bool OtherAreasAndOrUnitsAffected { get; }

        string ProductNormallyInPipingEquipment { get; set; }
        YesNoNotApplicable DepressuredDrained { get; set; }
        YesNoNotApplicable WaterWashed { get; set; }
        YesNoNotApplicable Steamed { get; set; }
        YesNoNotApplicable Purged { get; set; }
        YesNoNotApplicable Disconnected { get; set; }
        YesNoNotApplicable DepressuredAndVented { get; set; }
        YesNoNotApplicable Ventilated { get; set; }
        YesNoNotApplicable Blanked { get; set; }
        YesNoNotApplicable DrainsCovered { get; set; }
        YesNoNotApplicable AreaBarricaded { get; set; }
        YesNoNotApplicable EnergySourcesLockedOutTaggedOut { get; set; }
        string EnergyControlPlan { get; set; }
        string LockBoxNumber { get; set; }
        string OtherPreparations { get; set; }

        bool SpecificRequirementsSectionNotApplicableToJob { get; set; }

        bool AttendedAtAllTimes { get; set; }
        bool EyeProtection { get; set; }
        bool FallProtectionEquipment { get; set; }
        bool FullBodyHarnessRetrieval { get; set; }
        bool HearingProtection { get; set; }
        bool ProtectiveClothing { get; set; }
        bool Other1Checked { get; set; }
        string Other1Value { get; set; }

        bool EquipmentBondedGrounded { get; set; }
        bool FireBlanket { get; set; }
        bool FireFightingEquipment { get; set; }
        bool FireWatch { get; set; }
        bool HydrantPermit { get; set; }
        bool WaterHose { get; set; }
        bool SteamHose { get; set; }
        bool Other2Checked { get; set; }
        string Other2Value { get; set; }

        bool AirMover { get; set; }
        bool ContinuousGasMonitor { get; set; }
        bool DrowningProtection { get; set; }
        bool RespiratoryProtection { get; set; }
        bool Other3Checked { get; set; }
        string Other3Value { get; set; }

        bool AdditionalLighting { get; set; }
        bool DesignateHotOrColdCutChecked { get; set; }
        string DesignateHotOrColdCutValue { get; set; }
        bool HoistingEquipment { get; set; }
        bool Ladder { get; set; }
        bool MotorizedEquipment { get; set; }
        bool Scaffold { get; set; }
        bool ReferToTipsProcedure { get; set; }

        bool GasDetectorBumpTested { get; set; }
        bool AtmosphericGasTestRequired { get; set; }
        
        string PermitNumber { set; }
        bool HistoryButtonEnabled { set; }
        bool WorkOrderNumberReadOnly { set; }
        bool OperationNumberReadOnly { set; }
        bool SubOperationNumberReadOnly { set; }

        ConfiguredDocumentLink SelectedConfiguredDocumentLink { get; }
        bool WorkPreparationsCompletedSectionNotApplicableToJob { get; set; }
        bool WorkPreparationsCompletedSectionNotApplicableToJobEnabled { set; }
        YesNoNotApplicable ChemicallyWashed { get; set; }

        void SetOtherAreasAndOrUnitsAffected(bool otherAreasAndOrUnitsAffected, string area, string personNotified);
        void PopulateWorkPreparationsComboBoxes(List<YesNoNotApplicable> values);
        
        void ShowHasValidationWarningsAndErrorsMessageBox();
        void ShowHasValidationErrorsMessageBox();
        DialogResult ShowWarnings(WorkPermitLubesOtherWarnings otherWarnings, bool hasValidationWarnings);
        void ShowIsValidMessageBox();
        void ShowHasValidationWarningsMessageBox();

        void SetErrorForNumberOfWorkersLessThanOrEqualToZero();
        void SetWarningForNoNumberOfWorkers();
        void SetErrorForNoTrade();
        void SetErrorForNoLocation();
        void SetErrorForNoFunctionalLocation();
        void SetErrorForNoContractor();
        void SetErrorForNoIssuedTo();
        void SetErrorForNoDescription();
        void SetErrorForNoPermitType();
        void SetErrorForStartDateTimeNotBeforeEndDateTime();
        void SetErrorForExpireDateTimeInThePast();
        void SetErrorForNoRequestedByGroup();
        void SetErrorForNoAreaAffected();
        void SetErrorForNoPersonNotified();
        void SetErrorForNoConfinedSpaceClass();
        void SetErrorForNoSpecialWorkType();
        void SetErrorForInvalidHighEnergyValue();
        void SetErrorForInvalidCriticalLiftValue();
        void SetErrorForInvalidExcavationValue();
        void SetErrorForInvalidEnergyControlPlanValue();
        void SetErrorForInvalidEquivalencyProcValue();
        void SetErrorForInvalidTestPneumaticValue();
        void SetErrorForInvalidLiveFlareWorkValue();
        void SetErrorForInvalidEntryAndControlPlanValue();
        void SetErrorForInvalidEnergizedElectricalValue();
        void SetErrorForNoOtherHazards();
        void SetErrorForDesignateHotOrColdCutCheckedWithNoValue();
        void SetErrorForOther1CheckedWithNoValue();
        void SetErrorForOther2CheckedWithNoValue();
        void SetErrorForOther3CheckedWithNoValue();
        void SetErrorForSpecificRequirementsSectionEnabledButNothingChecked();
        void SetErrorForAtmosphericGasTestRequiredMustBeCheckedIfHotOrConfinedSpace();
        void SetErrorForNoProductNormallyInPipingEquipment();
        void SetErrorForNoEnergyControlPlan();
        void SetErrorForNoLockBoxNumber();

        void OpenFileOrDirectoryOrWebsite(string link);
        bool IsTheUserWantingToSelectAMoreSpecificFunctionalLocation();
        void TurnOnAutosetIndicatorsForDateTimes();
        void DisableSaveAndIssueButton();
        bool AtmosphericGasTestRequiredEnabled { set; }

        void SetWarningForTaskDescriptionDoesNotFitPrintout();
        void SetWarningForHazardsDoesNotFitPrintout();
        void SetWarningForStartAndEndNotWithinCurrentShiftOrFutureShift();
        void SetWarningForGasDetectorBumpTestedRequired();
    }
}
