using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Validation.Edmonton
{
    public abstract class PermitRequestBaseValidationAdapter
    {
        public abstract int? NumberOfWorkers { get; }

        public abstract WorkPermitEdmontonGroup Group { get; }

        public abstract FunctionalLocation FunctionalLocation { get; }

        public abstract WorkPermitEdmontonType WorkPermitType { get; }

        public abstract Date RequestedStartDate { get; }
        public abstract Date RequestedEndDate { get; }

        public abstract Time RequestedStartTimeDay { get; }
        public abstract Time RequestedStartTimeNight { get; }

        public abstract string Description { get; }

        public abstract bool IssuedToContractor { get; }
        public abstract string Company { get; }

        public abstract AreaLabel AreaLabel { get; }

        public abstract bool OtherAreasAndOrUnitsAffected { get; }
        public abstract string OtherAreasAndOrUnitsAffectedArea { get; }
        public abstract string OtherAreasAndOrUnitsAffectedPersonNotified { get; }

        public abstract string Occupation { get; }

        public abstract string Location { get; }

        public abstract bool GN59 { get; }
        public abstract FormGN59 FormGN59 { get; }

        public abstract bool GN7 { get; }
        public abstract FormGN7 FormGN7 { get; }

        public abstract bool GN6 { get; }
        public abstract FormGN6 FormGN6 { get; }

        public abstract bool GN24 { get; }
        public abstract FormGN24 FormGN24 { get; }

        public abstract bool GN75A { get; }
        public abstract FormGN75A FormGN75A { get; }

        public abstract bool GN1 { get; }
        public abstract FormGN1 FormGN1 { get; }

        public abstract WorkPermitSafetyFormState GN11 { get; }

        public abstract WorkPermitSafetyFormState GN27 { get; }

        public abstract bool WorkersMinimumSafetyRequirementsSectionNotApplicableToJob { get; }

        public abstract bool FaceShield { get; }
        public abstract bool Goggles { get; }
        public abstract bool RubberBoots { get; }
        public abstract bool RubberGloves { get; }
        public abstract bool RubberSuit { get; }
        public abstract bool SafetyHarnessLifeline { get; }
        public abstract bool HighVoltagePPE { get; }
        public abstract bool Other1Selected { get; }
        public abstract string Other1Text { get; }

        public abstract bool EquipmentGrounded { get; }
        public abstract bool FireBlanket { get; }
        public abstract bool FireExtinguisher { get; }
        public abstract bool FireMonitorManned { get; }
        public abstract bool FireWatch { get; }
        public abstract bool SewersDrainsCovered { get; }
        public abstract bool SteamHose { get; }
        public abstract bool Other2Selected { get; }
        public abstract string Other2Text { get; }

        public abstract bool AirPurifyingRespirator { get; }
        public abstract bool BreathingAirApparatus { get; }
        public abstract bool DustMask { get; }
        public abstract bool LifeSupportSystem { get; }
        public abstract bool SafetyWatch { get; }
        public abstract bool ContinuousGasMonitor { get; }
        public abstract bool WorkersMonitor { get; }
        public abstract string WorkersMonitorNumber { get; }
        public abstract bool BumpTestMonitorPriorToUse { get; }
        public abstract bool Other3Selected { get; }
        public abstract string Other3Text { get; }

        public abstract bool AirMover { get; }
        public abstract bool BarriersSigns { get; }
        public abstract bool RadioChannel { get; }
        public abstract string RadioChannelNumber { get; }
        public abstract bool AirHorn { get; }
        public abstract bool MechVentilationComfortOnly { get; }
        public abstract bool AsbestosMMCPrecautions { get; }
        public abstract bool Other4Selected { get; }
        public abstract string Other4Text { get; }

        public abstract bool AlkylationEntry { get; }
        public abstract string AlkylationEntryClassOfClothing { get; }

        public abstract bool FlarePitEntry { get; }
        public abstract string FlarePitEntryType { get; }

        public abstract bool ConfinedSpace { get; }
        public abstract string ConfinedSpaceClass { get; }

        public abstract string ConfinedSpaceCardNumber { get; }

        public abstract bool RescuePlan { get; }
        public abstract string RescuePlanFormNumber { get; }

        public abstract bool SpecialWork { get; }
        public abstract EdmontonPermitSpecialWorkType SpecialWorkType { get; }

        public abstract bool RoadAccessOnPermit { get; }    //mangesh for RoadAccessonPermit
        public abstract string RoadAccessOnPermitType { get; }

        public abstract SpecialWork specialworktype { get; }
        public abstract string SpecialWorkName { get; } //mangesh for SpecialWork

        public virtual List<string> MissingImportFieldList
        {
            get { throw new NotImplementedException(); }
        }

        public abstract void ClearErrors();
        public abstract void ActionForNumberOfWorkersLessThanOrEqualToZero();
        public abstract void ActionForNoGroup();
        public abstract void ActionForNoFunctionalLocation();
        public abstract void ActionForNoPermitType();
        public abstract void ActionForNoStartTime();
        public abstract void ActionForNoDescription();
        public abstract void ActionForNoContractor();
        public abstract void ActionForNoAreaLabel();
        public abstract void ActionForNoAreaAffected();
        public abstract void ActionForNoPersonNotified();
        public abstract void ActionForNoOccupation();
        public abstract void ActionForNoLocation();
        public abstract void ActionForNoApprovedGN59Form(string message);
        public abstract void ActionForNoApprovedGN7Form(string message);
        public abstract void ActionForNoApprovedGN6Form(string message);
        public abstract void ActionForNoApprovedGN24Form(string message);
        public abstract void ActionForNoApprovedGN75AForm(string message);
        public abstract void ActionForNoApprovedGN1Form(string message);
        public abstract void ActionForInvalidGN11Value(string message);
        public abstract void ActionForInvalidGN27Value(string message);
        public abstract void ActionForNoSafetyRequirementChosen();
        public abstract void ActionForOther1SelectedWithNoValue();
        public abstract void ActionForOther2SelectedWithNoValue();
        public abstract void ActionForOther3SelectedWithNoValue();
        public abstract void ActionForOther4SelectedWithNoValue();
        public abstract void ActionForNoConfinedSpaceClass(string message);
        public abstract void ActionForNoConfinedSpaceCardNumber(string message);
        public abstract void ActionForNoRescuePlanFormNumber(string message);

        public abstract void ActionForValidTradeCheckGN1Form(string message); //Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016
        public abstract void ActionForNoRoadAccessOnPermitType();    //mangesh for RoadAccessOnPermit
        public abstract void ActionForNoSpecialWorkType();

        public abstract void ActionForNoStartDate();
        public abstract void ActionForNoEndDate();
        public abstract void ActionForStartDateAfterEndDate();
    }
}