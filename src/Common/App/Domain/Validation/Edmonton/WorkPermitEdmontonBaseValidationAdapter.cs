using System;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Validation.Edmonton
{
    public abstract class WorkPermitEdmontonBaseValidationAdapter
    {
        public abstract int? NumberOfWorkers { get; }

        public abstract WorkPermitEdmontonGroup Group { get; }

        public abstract FunctionalLocation FunctionalLocation { get; }

        public abstract WorkPermitEdmontonType WorkPermitType { get; }

        public abstract string Description { get; }

        public abstract bool IssuedToContractor { get; }

        public abstract string Company { get; }

        public abstract bool OtherAreasAndOrUnitsAffected { get; }
        public abstract string OtherAreasAndOrUnitsAffectedArea { get; }
        public abstract string OtherAreasAndOrUnitsAffectedPersonNotified { get; }

        public abstract string Occupation { get; }

        public abstract string Location { get; }

        public abstract bool GN59 { get; }
        public abstract bool GN7 { get; }
        public abstract bool GN6 { get; }
        public abstract bool GN24 { get; }
        public abstract bool GN75A { get; }
        public abstract bool GN1 { get; }

        public abstract WorkPermitSafetyFormState GN11 { get; }

        public abstract WorkPermitSafetyFormState GN27 { get; }

        public abstract bool WorkersMinimumSafetyRequirementsSectionNotApplicableToJob { get; }

        public abstract FormGN59 FormGN59 { get; }
        public abstract FormGN6 FormGN6 { get; }
        public abstract FormGN7 FormGN7 { get; }
        public abstract FormGN24 FormGN24 { get; }
        public abstract FormGN75A FormGN75A { get; }
        public abstract FormGN1 FormGN1 { get; }

        public abstract bool FaceShield { get; }
        public abstract bool Goggles { get; }
        public abstract bool RubberBoots { get; }
        public abstract bool RubberGloves { get; }
        public abstract bool RubberSuit { get; }
        public abstract bool SafetyHarnessLifeline { get; }
        public abstract bool HighVoltagePPE { get; }
        public abstract bool Other1 { get; }
        public abstract string Other1Value { get; }

        public abstract bool EquipmentGrounded { get; }
        public abstract bool FireBlanket { get; }
        public abstract bool FireExtinguisher { get; }
        public abstract bool FireMonitorManned { get; }
        public abstract bool FireWatch { get; }
        public abstract bool SewersDrainsCovered { get; }
        public abstract bool SteamHose { get; }
        public abstract bool Other2 { get; }
        public abstract string Other2Value { get; }

        public abstract bool AirPurifyingRespirator { get; }
        public abstract bool BreathingAirApparatus { get; }
        public abstract bool DustMask { get; }
        public abstract bool LifeSupportSystem { get; }
        public abstract bool SafetyWatch { get; }
        public abstract bool ContinuousGasMonitor { get; }
        public abstract bool WorkersMonitor { get; }
        public abstract string WorkersMonitorNumber { get; }
        public abstract bool BumpTestMonitorPriorToUse { get; }
        public abstract bool Other3 { get; }
        public abstract string Other3Value { get; }

        public abstract bool AirMover { get; }
        public abstract bool BarriersSigns { get; }
        public abstract bool RadioChannel { get; }
        public abstract string RadioChannelNumber { get; }
        public abstract bool AirHorn { get; }
        public abstract bool MechVentilationComfortOnly { get; }
        public abstract bool AsbestosMMCPrecautions { get; }
        public abstract bool Other4 { get; }
        public abstract string Other4Value { get; }

        public abstract bool AlkylationEntry { get; }
        public abstract string AlkylationEntryClassOfClothing { get; }

        public abstract bool FlarePitEntry { get; }
        public abstract string FlarePitEntryType { get; }

        public abstract bool ConfinedSpace { get; }
        public abstract string ConfinedSpaceClass { get; }

        public abstract string ConfinedSpaceCardNumber { get; }

        public abstract bool RescuePlan { get; }
        public abstract string RescuePlanFormNumber { get; }

        public abstract bool RoadAccessOnPermit { get; }   //mangesh for RoadAccessOnPermit
        public abstract string RoadAccessOnPermitType { get; }

        public abstract bool SpecialWork { get; }
        public abstract EdmontonPermitSpecialWorkType SpecialWorkType { get; }
        public abstract SpecialWork specialworktype { get; }
        public abstract string SpecialWorkName { get; }//mangesh for SpecialWork

        public abstract YesNoNotApplicable QuestionOneResponse { get; }
        public abstract YesNoNotApplicable QuestionTwoResponse { get; }
        public abstract YesNoNotApplicable QuestionTwoAResponse { get; }
        public abstract YesNoNotApplicable QuestionTwoBResponse { get; }
        public abstract YesNoNotApplicable QuestionThreeResponse { get; }
        public abstract YesNoNotApplicable QuestionFourResponse { get; }

        public abstract bool ConfinedSpaceWorkSectionNotApplicableToJob { get; }

        public abstract string HazardsAndOrRequirements { get; }

        public abstract bool GasTestsSectionNotApplicableToJob { get; }

        public abstract string GasTestDataLine1CombustibleGas { get; }
        public abstract string GasTestDataLine1Oxygen { get; }
        public abstract string GasTestDataLine1ToxicGas { get; }
        public abstract Time GasTestDataLine1Time { get; }

        public abstract string GasTestDataLine2CombustibleGas { get; }
        public abstract string GasTestDataLine2Oxygen { get; }
        public abstract string GasTestDataLine2ToxicGas { get; }
        public abstract Time GasTestDataLine2Time { get; }

        public abstract string GasTestDataLine3CombustibleGas { get; }
        public abstract string GasTestDataLine3Oxygen { get; }
        public abstract string GasTestDataLine3ToxicGas { get; }
        public abstract Time GasTestDataLine3Time { get; }

        public abstract string GasTestDataLine4CombustibleGas { get; }
        public abstract string GasTestDataLine4Oxygen { get; }
        public abstract string GasTestDataLine4ToxicGas { get; }
        public abstract Time GasTestDataLine4Time { get; }

        public abstract string OperatorGasDetectorNumber { get; }

        public abstract bool StatusOfPipingEquipmentSectionNotApplicableToJob { get; }
        public abstract string ProductNormallyInPipingEquipment { get; }
        public abstract bool IssuedToSuncor { get; }

        public abstract DateTime RequestedStartDateTime { get; }
        public abstract DateTime ExpiryDateTime { get; }

        public abstract bool WorkerToProvideGasTestData { get; }

        public abstract string AggrementAndSignature { get; } //swapnil test

        public virtual void ClearErrors()
        {
        }

        public virtual void ActionForNumberOfWorkersLessThanOrEqualToZero()
        {
        }

        public virtual void ActionForNoGroup()
        {
        }

        public virtual void ActionForNoFunctionalLocation()
        {
        }

        public virtual void ActionForNoPermitType()
        {
        }

        public virtual void ActionForNoDescription()
        {
        }

        public virtual void ActionForNoNumeric(string name)
        {
        }


        public virtual void ActionForNoContractor()
        {
        }

        public virtual void ActionForNoAreaAffected()
        {
        }

        public virtual void ActionForNoPersonNotified()
        {
        }

        public virtual void ActionForNoOccupation()
        {
        }

        public virtual void ActionForNoLocation()
        {
        }

        public virtual void ActionForInvalidGN11Value()
        {
        }

        public virtual void ActionForInvalidGN27Value()
        {
        }

        public virtual void ActionForNoSafetyRequirementChosen()
        {
        }

        public virtual void ActionForNoApprovedGN6Form()
        {
        }

        public virtual void ActionForNoApprovedGN7Form()
        {
        }

        public virtual void ActionForNoApprovedGN59Form()
        {
        }

        public virtual void ActionForNoApprovedGN24Form()
        {
        }

        public virtual void ActionForNoApprovedGN75AForm()
        {
        }

        public virtual void ActionForNoApprovedGN1Form()
        {
        }

        public virtual void ActionForGroupMaintenance() // Swapnil Patki For DMND0005325 Point Number 9
        { 
        }

        //Start Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016
        public virtual void ActionForValidTradeCheckGN1Form() 
        {
        }
        //End Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016

        public virtual void ActionForNoClassOfClothing()
        {
        }

        public virtual void ActionForNoFlarePitEntryType()
        {
        }

        public virtual void ActionForNoConfinedSpaceClass()
        {
        }

        public virtual void ActionForNoConfinedSpaceCardNumber()
        {
        }

        public virtual void ActionForNoRescuePlanFormNumber()
        {
        }

        public virtual void ActionForNoSpecialWorkType()
        {
        }

        public virtual void ActionForNoRoadAccessOnPermitType()
        {
        }

        public virtual void ActionForOther1CheckedWithNoValue()
        {
        }

        public virtual void ActionForOther2CheckedWithNoValue()
        {
        }

        public virtual void ActionForOther3CheckedWithNoValue()
        {
        }

        public virtual void ActionForOther4CheckedWithNoValue()
        {
        }

        public virtual void ActionForNoRadioChannelNumber()
        {
        }

        public virtual void ActionForNoWorkersMonitorNumber()
        {
        }

        public virtual void ActionForQuestionOneNotSetToYes()
        {
        }

        public virtual void ActionForNoFireProtectiveMeasuresChosenButTypeIsHighEnergyHotWork()
        {
        }

        public virtual void ActionForGasTestsTableLine1IsInvalid()
        {
        }

        public virtual void ActionForGasTestsTableLine2IsInvalid()
        {
        }

        public virtual void ActionForGasTestsTableLine3IsInvalid()
        {
        }

        public virtual void ActionForGasTestsTableLine4IsInvalid()
        {
        }

        public virtual void ActionForAtLeastOneGasTestsTableLineMustBeFilledOut()
        {
        }

        public virtual void ActionForNoOperatorGasDetectorNumber()
        {
        }

        public virtual void ActionForNoProductNormallyInPipingEquipment()
        {
        }

        public virtual void ActionForStartDateTimeNotBeforeEndDateTime()
        {
        }

        public virtual void ActionForExpiryDateTimeInThePast()
        {
        }

        public virtual void ActionForNoHazardsAndOrRequirements()
        {
        }

        public virtual void ActionForNoIssuedToOptionSelected()
        {
        }

        public virtual void ActionForHazardsTooLong()
        {
        }
    }
}