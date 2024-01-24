using System;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Validation.Edmonton
{
    public class WorkPermitEdmontonValidationDomainAdapter : WorkPermitEdmontonBaseValidationAdapter
    {
        private readonly WorkPermitEdmonton permit;

        public WorkPermitEdmontonValidationDomainAdapter(WorkPermitEdmonton permit)
        {
            this.permit = permit;
        }

        public override int? NumberOfWorkers
        {
            get { return permit.NumberOfWorkers; }
        }

        public override WorkPermitEdmontonGroup Group
        {
            get { return permit.Group; }
        }

        public override FunctionalLocation FunctionalLocation
        {
            get { return permit.FunctionalLocation; }
        }

        public override WorkPermitEdmontonType WorkPermitType
        {
            get { return permit.WorkPermitType; }
        }

        public override string Description
        {
            get { return permit.TaskDescription; }
        }

        public override bool IssuedToContractor
        {
            get { return permit.IssuedToCompany; }
        }

        public override string Company
        {
            get { return permit.Company; }
        }

        public override bool OtherAreasAndOrUnitsAffected
        {
            get { return permit.OtherAreasAndOrUnitsAffected; }
        }

        public override string OtherAreasAndOrUnitsAffectedArea
        {
            get { return permit.OtherAreasAndOrUnitsAffectedArea; }
        }

        public override string OtherAreasAndOrUnitsAffectedPersonNotified
        {
            get { return permit.OtherAreasAndOrUnitsAffectedPersonNotified; }
        }

        public override string Occupation
        {
            get { return permit.Occupation; }
        }

        public override string Location
        {
            get { return permit.Location; }
        }

        public override bool GN59
        {
            get { return permit.GN59; }
        }

        public override bool GN6
        {
            get { return permit.GN6; }
        }

        public override bool GN7
        {
            get { return permit.GN7; }
        }

        public override bool GN24
        {
            get { return permit.GN24; }
        }

        public override bool GN75A
        {
            get { return permit.GN75A; }
        }

        public override bool GN1
        {
            get { return permit.GN1; }
        }

        public override WorkPermitSafetyFormState GN11
        {
            get { return permit.GN11; }
        }

        public override WorkPermitSafetyFormState GN27
        {
            get { return permit.GN27; }
        }

        public override bool WorkersMinimumSafetyRequirementsSectionNotApplicableToJob
        {
            get { return permit.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob; }
        }

        public override FormGN59 FormGN59
        {
            get { return permit.FormGN59; }
        }

        public override FormGN6 FormGN6
        {
            get { return permit.FormGN6; }
        }

        public override FormGN7 FormGN7
        {
            get { return permit.FormGN7; }
        }

        public override FormGN24 FormGN24
        {
            get { return permit.FormGN24; }
        }

        public override FormGN75A FormGN75A
        {
            get { return permit.FormGN75A; }
        }

        public override FormGN1 FormGN1
        {
            get { return permit.FormGN1; }
        }

        public override bool FaceShield
        {
            get { return permit.FaceShield; }
        }

        public override bool Goggles
        {
            get { return permit.Goggles; }
        }

        public override bool RubberBoots
        {
            get { return permit.RubberBoots; }
        }

        public override bool RubberGloves
        {
            get { return permit.RubberGloves; }
        }

        public override bool RubberSuit
        {
            get { return permit.RubberSuit; }
        }

        public override bool SafetyHarnessLifeline
        {
            get { return permit.SafetyHarnessLifeline; }
        }

        public override bool HighVoltagePPE
        {
            get { return permit.HighVoltagePPE; }
        }

        public override bool Other1
        {
            get { return permit.Other1Checked; }
        }

        public override string Other1Value
        {
            get { return permit.Other1; }
        }

        public override bool EquipmentGrounded
        {
            get { return permit.EquipmentGrounded; }
        }

        public override bool FireBlanket
        {
            get { return permit.FireBlanket; }
        }

        public override bool FireExtinguisher
        {
            get { return permit.FireExtinguisher; }
        }

        public override bool FireMonitorManned
        {
            get { return permit.FireMonitorManned; }
        }

        public override bool FireWatch
        {
            get { return permit.FireWatch; }
        }

        public override bool SewersDrainsCovered
        {
            get { return permit.SewersDrainsCovered; }
        }

        public override bool SteamHose
        {
            get { return permit.SteamHose; }
        }

        public override bool Other2
        {
            get { return permit.Other2Checked; }
        }

        public override string Other2Value
        {
            get { return permit.Other2; }
        }

        public override bool AirPurifyingRespirator
        {
            get { return permit.AirPurifyingRespirator; }
        }

        public override bool BreathingAirApparatus
        {
            get { return permit.BreathingAirApparatus; }
        }

        public override bool DustMask
        {
            get { return permit.DustMask; }
        }

        public override bool LifeSupportSystem
        {
            get { return permit.LifeSupportSystem; }
        }

        public override bool SafetyWatch
        {
            get { return permit.SafetyWatch; }
        }

        public override bool ContinuousGasMonitor
        {
            get { return permit.ContinuousGasMonitor; }
        }

        public override bool WorkersMonitor
        {
            get { return permit.WorkersMonitor; }
        }

        public override string WorkersMonitorNumber
        {
            get { return permit.WorkersMonitorNumber; }
        }

        public override bool BumpTestMonitorPriorToUse
        {
            get { return permit.BumpTestMonitorPriorToUse; }
        }

        public override bool Other3
        {
            get { return permit.Other3Checked; }
        }

        public override string Other3Value
        {
            get { return permit.Other3; }
        }

        public override bool AirMover
        {
            get { return permit.AirMover; }
        }

        public override bool BarriersSigns
        {
            get { return permit.BarriersSigns; }
        }

        public override bool RadioChannel
        {
            get { return permit.RadioChannel; }
        }

        public override string RadioChannelNumber
        {
            get { return permit.RadioChannelNumber; }
        }

        public override bool AirHorn
        {
            get { return permit.AirHorn; }
        }

        public override bool MechVentilationComfortOnly
        {
            get { return permit.MechVentilationComfortOnly; }
        }

        public override bool AsbestosMMCPrecautions
        {
            get { return permit.AsbestosMMCPrecautions; }
        }

        public override bool Other4
        {
            get { return permit.Other4Checked; }
        }

        public override string Other4Value
        {
            get { return permit.Other4; }
        }

        public override bool AlkylationEntry
        {
            get { return permit.AlkylationEntry; }
        }

        public override string AlkylationEntryClassOfClothing
        {
            get { return permit.AlkylationEntryClassOfClothing; }
        }

        public override bool FlarePitEntry
        {
            get { return permit.FlarePitEntry; }
        }

        public override string FlarePitEntryType
        {
            get { return permit.FlarePitEntryType; }
        }

        public override bool ConfinedSpace
        {
            get { return permit.ConfinedSpace; }
        }

        public override string ConfinedSpaceClass
        {
            get { return permit.ConfinedSpaceClass; }
        }

        public override string ConfinedSpaceCardNumber
        {
            get { return permit.ConfinedSpaceCardNumber; }
        }

        public override bool RescuePlan
        {
            get { return permit.RescuePlan; }
        }

        public override string RescuePlanFormNumber
        {
            get { return permit.RescuePlanFormNumber; }
        }

        public override bool SpecialWork
        {
            get { return permit.SpecialWork; }
        }

        public override EdmontonPermitSpecialWorkType SpecialWorkType
        {
            get { return permit.SpecialWorkType; }
        }

        //mangesh for SpecialWork
        public override SpecialWork specialworktype
        {
            get { return permit.specialworktype; }
        }

        public override string SpecialWorkName
        {
            get { return permit.SpecialWorkName; }
        }
        //--
        // mangesh for RoadAccess
        public override bool RoadAccessOnPermit
        {
            get { return permit.RoadAccessOnPermit; }
        }

        public override string RoadAccessOnPermitType
        {
            get { return permit.RoadAccessOnPermitType; }
        }
        //-
        public override YesNoNotApplicable QuestionOneResponse
        {
            get { return permit.QuestionOneResponse; }
        }

        public override YesNoNotApplicable QuestionTwoResponse
        {
            get { return permit.QuestionTwoResponse; }
        }

        public override YesNoNotApplicable QuestionTwoAResponse
        {
            get { return permit.QuestionTwoAResponse; }
        }

        public override YesNoNotApplicable QuestionTwoBResponse
        {
            get { return permit.QuestionTwoBResponse; }
        }

        public override YesNoNotApplicable QuestionThreeResponse
        {
            get { return permit.QuestionThreeResponse; }
        }

        public override YesNoNotApplicable QuestionFourResponse
        {
            get { return permit.QuestionFourResponse; }
        }

        public override bool ConfinedSpaceWorkSectionNotApplicableToJob
        {
            get { return permit.ConfinedSpaceWorkSectionNotApplicableToJob; }
        }

        public override string HazardsAndOrRequirements
        {
            get { return permit.HazardsAndOrRequirements; }
        }

        public override bool GasTestsSectionNotApplicableToJob
        {
            get { return permit.GasTestsSectionNotApplicableToJob; }
        }

        public override string GasTestDataLine1CombustibleGas
        {
            get { return permit.GasTestDataLine1CombustibleGas; }
        }

        public override string GasTestDataLine1Oxygen
        {
            get { return permit.GasTestDataLine1Oxygen; }
        }

        public override string GasTestDataLine1ToxicGas
        {
            get { return permit.GasTestDataLine1ToxicGas; }
        }

        public override Time GasTestDataLine1Time
        {
            get { return permit.GasTestDataLine1Time; }
        }

        public override string GasTestDataLine2CombustibleGas
        {
            get { return permit.GasTestDataLine2CombustibleGas; }
        }

        public override string GasTestDataLine2Oxygen
        {
            get { return permit.GasTestDataLine2Oxygen; }
        }

        public override string GasTestDataLine2ToxicGas
        {
            get { return permit.GasTestDataLine2ToxicGas; }
        }

        public override Time GasTestDataLine2Time
        {
            get { return permit.GasTestDataLine2Time; }
        }

        public override string GasTestDataLine3CombustibleGas
        {
            get { return permit.GasTestDataLine3CombustibleGas; }
        }

        public override string GasTestDataLine3Oxygen
        {
            get { return permit.GasTestDataLine3Oxygen; }
        }

        public override string GasTestDataLine3ToxicGas
        {
            get { return permit.GasTestDataLine3ToxicGas; }
        }

        public override Time GasTestDataLine3Time
        {
            get { return permit.GasTestDataLine3Time; }
        }

        public override string GasTestDataLine4CombustibleGas
        {
            get { return permit.GasTestDataLine4CombustibleGas; }
        }

        public override string GasTestDataLine4Oxygen
        {
            get { return permit.GasTestDataLine4Oxygen; }
        }

        public override string GasTestDataLine4ToxicGas
        {
            get { return permit.GasTestDataLine4ToxicGas; }
        }

        public override Time GasTestDataLine4Time
        {
            get { return permit.GasTestDataLine4Time; }
        }

        public override string OperatorGasDetectorNumber
        {
            get { return permit.OperatorGasDetectorNumber; }
        }

        public override bool StatusOfPipingEquipmentSectionNotApplicableToJob
        {
            get { return permit.StatusOfPipingEquipmentSectionNotApplicableToJob; }
        }

        public override string ProductNormallyInPipingEquipment
        {
            get { return permit.ProductNormallyInPipingEquipment; }
        }

        public override bool IssuedToSuncor
        {
            get { return permit.IssuedToSuncor; }
        }

        public override DateTime RequestedStartDateTime
        {
            get { return permit.RequestedStartDateTime; }
        }

        public override DateTime ExpiryDateTime
        {
            get { return permit.ExpiredDateTime; }
        }

        public override bool WorkerToProvideGasTestData
        {
            get { return permit.WorkerToProvideGasTestData; }
        }

        public override string AggrementAndSignature //swapnil test
        {
            get { return permit.ShiftSupervisor; }
        }
    }
}