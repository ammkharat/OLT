using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Validation.Edmonton
{
    public class PermitRequestEdmontonValidationDomainAdapter : PermitRequestBaseValidationAdapter
    {
        private readonly List<string> missingFields = new List<string>();
        private readonly PermitRequestEdmonton permitRequest;

        public PermitRequestEdmontonValidationDomainAdapter(PermitRequestEdmonton permitRequest)
        {
            this.permitRequest = permitRequest;
        }

        public override List<string> MissingImportFieldList
        {
            get { return new List<string>(missingFields); }
        }

        public override int? NumberOfWorkers
        {
            get { return permitRequest.NumberOfWorkers; }
        }

        public override WorkPermitEdmontonGroup Group
        {
            get { return permitRequest.Group; }
        }

        public override FunctionalLocation FunctionalLocation
        {
            get { return permitRequest.FunctionalLocation; }
        }

        public override WorkPermitEdmontonType WorkPermitType
        {
            get { return permitRequest.WorkPermitType; }
        }

        public override Date RequestedStartDate
        {
            get { return permitRequest.RequestedStartDate; }
        }

        public override Date RequestedEndDate
        {
            get { return permitRequest.EndDate; }
        }

        public override Time RequestedStartTimeDay
        {
            get { return permitRequest.RequestedStartTimeDay; }
        }

        public override Time RequestedStartTimeNight
        {
            get { return permitRequest.RequestedStartTimeNight; }
        }

        public override string Description
        {
            get { return permitRequest.Description; }
        }

        public override bool IssuedToContractor
        {
            get { return permitRequest.Company != null; }
        }

        public override string Company
        {
            get { return permitRequest.Company; }
        }

        public override AreaLabel AreaLabel
        {
            get { return permitRequest.AreaLabel; }
        }

        public override bool OtherAreasAndOrUnitsAffected
        {
            get
            {
                return permitRequest.OtherAreasAndOrUnitsAffectedArea != null ||
                       permitRequest.OtherAreasAndOrUnitsAffectedPersonNotified != null;
            }
        }

        public override string OtherAreasAndOrUnitsAffectedArea
        {
            get { return permitRequest.OtherAreasAndOrUnitsAffectedArea; }
        }

        public override string OtherAreasAndOrUnitsAffectedPersonNotified
        {
            get { return permitRequest.OtherAreasAndOrUnitsAffectedPersonNotified; }
        }

        public override string Occupation
        {
            get { return permitRequest.Occupation; }
        }

        public override string Location
        {
            get { return permitRequest.Location; }
        }

        public override bool GN59
        {
            get { return permitRequest.GN59; }
        }

        public override FormGN59 FormGN59
        {
            get { return permitRequest.FormGN59; }
        }

        public override bool GN6
        {
            get { return permitRequest.GN6; }
        }

        public override FormGN6 FormGN6
        {
            get { return permitRequest.FormGN6; }
        }

        public override bool GN7
        {
            get { return permitRequest.GN7; }
        }

        public override FormGN7 FormGN7
        {
            get { return permitRequest.FormGN7; }
        }

        public override bool GN24
        {
            get { return permitRequest.GN24; }
        }

        public override FormGN24 FormGN24
        {
            get { return permitRequest.FormGN24; }
        }

        public override bool GN75A
        {
            get { return permitRequest.GN75A; }
        }

        public override FormGN75A FormGN75A
        {
            get { return permitRequest.FormGN75A; }
        }

        public override bool GN1
        {
            get { return permitRequest.GN1; }
        }

        public override FormGN1 FormGN1
        {
            get { return permitRequest.FormGN1; }
        }

        public override WorkPermitSafetyFormState GN11
        {
            get { return permitRequest.GN11; }
        }

        public override WorkPermitSafetyFormState GN27
        {
            get { return permitRequest.GN27; }
        }

        public override bool WorkersMinimumSafetyRequirementsSectionNotApplicableToJob
        {
            get { return permitRequest.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob; }
        }

        public override bool FaceShield
        {
            get { return permitRequest.FaceShield; }
        }

        public override bool Goggles
        {
            get { return permitRequest.Goggles; }
        }

        public override bool RubberBoots
        {
            get { return permitRequest.RubberBoots; }
        }

        public override bool RubberGloves
        {
            get { return permitRequest.RubberGloves; }
        }

        public override bool RubberSuit
        {
            get { return permitRequest.RubberSuit; }
        }

        public override bool SafetyHarnessLifeline
        {
            get { return permitRequest.SafetyHarnessLifeline; }
        }

        public override bool HighVoltagePPE
        {
            get { return permitRequest.HighVoltagePPE; }
        }

        public override bool Other1Selected
        {
            get { return !permitRequest.Other1.IsNullOrEmptyOrWhitespace(); }
        }

        public override string Other1Text
        {
            get { return permitRequest.Other1; }
        }

        public override bool EquipmentGrounded
        {
            get { return permitRequest.EquipmentGrounded; }
        }

        public override bool FireBlanket
        {
            get { return permitRequest.FireBlanket; }
        }

        public override bool FireExtinguisher
        {
            get { return permitRequest.FireExtinguisher; }
        }

        public override bool FireMonitorManned
        {
            get { return permitRequest.FireMonitorManned; }
        }

        public override bool FireWatch
        {
            get { return permitRequest.FireWatch; }
        }

        public override bool SewersDrainsCovered
        {
            get { return permitRequest.SewersDrainsCovered; }
        }

        public override bool SteamHose
        {
            get { return permitRequest.SteamHose; }
        }

        public override bool Other2Selected
        {
            get { return !permitRequest.Other2.IsNullOrEmptyOrWhitespace(); }
        }

        public override string Other2Text
        {
            get { return permitRequest.Other2; }
        }

        public override bool AirPurifyingRespirator
        {
            get { return permitRequest.AirPurifyingRespirator; }
        }

        public override bool BreathingAirApparatus
        {
            get { return permitRequest.BreathingAirApparatus; }
        }

        public override bool DustMask
        {
            get { return permitRequest.DustMask; }
        }

        public override bool LifeSupportSystem
        {
            get { return permitRequest.LifeSupportSystem; }
        }

        public override bool SafetyWatch
        {
            get { return permitRequest.SafetyWatch; }
        }

        public override bool ContinuousGasMonitor
        {
            get { return permitRequest.ContinuousGasMonitor; }
        }

        public override bool WorkersMonitor
        {
            get { return permitRequest.WorkersMonitor; }
        }

        public override string WorkersMonitorNumber
        {
            get { return permitRequest.WorkersMonitorNumber; }
        }

        public override bool BumpTestMonitorPriorToUse
        {
            get { return permitRequest.BumpTestMonitorPriorToUse; }
        }

        public override bool Other3Selected
        {
            get { return !permitRequest.Other3.IsNullOrEmptyOrWhitespace(); }
        }

        public override string Other3Text
        {
            get { return permitRequest.Other3; }
        }

        public override bool AirMover
        {
            get { return permitRequest.AirMover; }
        }

        public override bool BarriersSigns
        {
            get { return permitRequest.BarriersSigns; }
        }

        public override bool RadioChannel
        {
            get { return permitRequest.RadioChannel; }
        }

        public override string RadioChannelNumber
        {
            get { return permitRequest.RadioChannelNumber; }
        }

        public override bool AirHorn
        {
            get { return permitRequest.AirHorn; }
        }

        public override bool MechVentilationComfortOnly
        {
            get { return permitRequest.MechVentilationComfortOnly; }
        }

        public override bool AsbestosMMCPrecautions
        {
            get { return permitRequest.AsbestosMMCPrecautions; }
        }

        public override bool Other4Selected
        {
            get { return !permitRequest.Other4.IsNullOrEmptyOrWhitespace(); }
        }

        public override string Other4Text
        {
            get { return permitRequest.Other4; }
        }

        public override bool AlkylationEntry
        {
            get { return permitRequest.AlkylationEntry; }
        }

        public override string AlkylationEntryClassOfClothing
        {
            get { return permitRequest.AlkylationEntryClassOfClothing; }
        }

        public override bool FlarePitEntry
        {
            get { return permitRequest.FlarePitEntry; }
        }

        public override string FlarePitEntryType
        {
            get { return permitRequest.FlarePitEntryType; }
        }

        public override bool ConfinedSpace
        {
            get { return permitRequest.ConfinedSpace; }
        }

        public override string ConfinedSpaceClass
        {
            get { return permitRequest.ConfinedSpaceClass; }
        }

        public override string ConfinedSpaceCardNumber
        {
            get { return permitRequest.ConfinedSpaceCardNumber; }
        }

        public override bool RescuePlan
        {
            get { return permitRequest.RescuePlan; }
        }

        public override string RescuePlanFormNumber
        {
            get { return permitRequest.RescuePlanFormNumber; }
        }

        public override bool SpecialWork
        {
            get { return permitRequest.SpecialWork; }
        }

        public override EdmontonPermitSpecialWorkType SpecialWorkType
        {
            get { return permitRequest.SpecialWorkType; }
        }

        //mangesh for SpecialWork
        public override SpecialWork specialworktype
        {
            get { return permitRequest.specialworktype; }
        }

        public override string SpecialWorkName
        {
            get { return permitRequest.SpecialWorkName; }
        }
        //----

        //mangesh for RoadAccess
        public override bool RoadAccessOnPermit
        {
            get { return permitRequest.RoadAccessOnPermit; }
        }

        public override string RoadAccessOnPermitType
        {
            get { return permitRequest.RoadAccessOnPermitType; }
        }
        //--

        public override void ClearErrors()
        {
            missingFields.Clear();
        }

        public override void ActionForNumberOfWorkersLessThanOrEqualToZero()
        {
            ; // field not imported
        }

        public override void ActionForNoGroup()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_Group);
        }

        public override void ActionForNoFunctionalLocation()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_FunctionalLocation);
        }

        public override void ActionForNoPermitType()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_WorkPermitType);
        }

        public override void ActionForNoStartTime()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_StartTime);
        }

        public override void ActionForNoDescription()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_Description);
        }

        public override void ActionForNoContractor()
        {
            // field not imported
        }

        public override void ActionForNoAreaAffected()
        {
            // field not imported
        }

        public override void ActionForNoPersonNotified()
        {
            // field not imported
        }

        public override void ActionForNoOccupation()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_Occupation);
        }

        public override void ActionForNoLocation()
        {
            // field not imported - if there is a floc, then we have this field
        }

        public override void ActionForNoApprovedGN59Form(string message)
        {
            // field optional or not imported
        }

        public override void ActionForNoApprovedGN6Form(string message)
        {
            // field optional or not imported
        }

        public override void ActionForNoApprovedGN24Form(string message)
        {
            // field optional or not imported
        }

        public override void ActionForNoApprovedGN75AForm(string message)
        {
            // field optional or not imported
        }

        public override void ActionForNoApprovedGN1Form(string message)
        {
            // field optional or not imported
        }

        public override void ActionForValidTradeCheckGN1Form(string message) //Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016
        {
            // field optional or not imported
        }

        public override void ActionForNoApprovedGN7Form(string message)
        {
            // field optional or not imported
        }

        public override void ActionForInvalidGN11Value(string message)
        {
            // field optional or not imported
        }

        public override void ActionForInvalidGN27Value(string message)
        {
            // field optional or not imported
        }

        public override void ActionForNoAreaLabel()
        {
            // field optional or not imported
        }

        public override void ActionForNoSafetyRequirementChosen()
        {
            // field optional or not imported
        }

        public override void ActionForOther1SelectedWithNoValue()
        {
            // field optional or not imported
        }

        public override void ActionForOther2SelectedWithNoValue()
        {
            // field optional or not imported
        }

        public override void ActionForOther3SelectedWithNoValue()
        {
            // field optional or not imported
        }

        public override void ActionForOther4SelectedWithNoValue()
        {
            // field optional or not imported
        }

        public override void ActionForNoConfinedSpaceClass(string message)
        {
            // field optional or not imported
        }

        public override void ActionForNoConfinedSpaceCardNumber(string message)
        {
            // field optional or not imported
        }

        public override void ActionForNoRescuePlanFormNumber(string message)
        {
            // field optional or not imported
        }

        public override void ActionForNoSpecialWorkType()
        {
            // field optional or not imported
        }

        public override void ActionForNoRoadAccessOnPermitType()
        {
            
        }

        public override void ActionForNoStartDate()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_StartDate);
        }

        public override void ActionForNoEndDate()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_EndDate);
        }

        public override void ActionForStartDateAfterEndDate()
        {
            // should be validated by something else since this adapter just sets the list of missing fields.
        }
    }
}