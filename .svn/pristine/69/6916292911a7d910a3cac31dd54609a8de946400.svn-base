using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.Validation.Edmonton;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Validation.Edmonton
{
    public class PermitRequestEdmontonValidationViewAdapter : PermitRequestBaseValidationAdapter
    {
        private readonly IPermitRequestEdmontonFormView view;

        public PermitRequestEdmontonValidationViewAdapter(IPermitRequestEdmontonFormView view)
        {
            this.view = view;
        }

        public override void ClearErrors()
        {
            view.ClearErrorProviders();
        }

        public override int? NumberOfWorkers
        {
            get { return view.NumberOfWorkers; }
        }

        public override WorkPermitEdmontonGroup Group
        {
            get { return view.Group; }
        }

        public override FunctionalLocation FunctionalLocation
        {
            get { return view.FunctionalLocation; }
        }

        public override WorkPermitEdmontonType WorkPermitType
        {
            get { return view.WorkPermitType; }
        }

        public override string Description
        {
            get { return view.Description; }
        }

        public override Date RequestedEndDate
        {
            get { return view.RequestedEndDate; }
        }

        public override Time RequestedStartTimeDay
        {
            get { return view.RequestedStartTimeDay; }
        }

        public override Time RequestedStartTimeNight
        {
            get { return view.RequestedStartTimeNight; }
        }

        public override bool IssuedToContractor
        {
            get { return view.IssuedToContractor; }
        }

        public override string Company
        {
            get { return view.Company; }
        }

        public override AreaLabel AreaLabel
        {
            get { return view.AreaLabel; }
        }

        public override bool OtherAreasAndOrUnitsAffected
        {
            get { return view.OtherAreasAndOrUnitsAffected; }
        }

        public override string OtherAreasAndOrUnitsAffectedArea
        {
            get { return view.OtherAreasAndOrUnitsAffectedArea; }
        }

        public override string OtherAreasAndOrUnitsAffectedPersonNotified
        {
            get { return view.OtherAreasAndOrUnitsAffectedPersonNotified; }
        }

        public override string Occupation
        {
            get { return view.Occupation; }
        }

        public override string Location
        {
            get { return view.Location; }
        }

        public override bool GN59
        {
            get { return view.GN59; }           
        }

        public override FormGN59 FormGN59
        {
            get { return view.FormGN59; }
        }

        public override bool GN7
        {
            get { return view.GN7; }         
        }

        public override FormGN7 FormGN7
        {
            get { return view.FormGN7; }
        }

        public override bool GN24
        {
            get { return view.GN24; }
        }

        public override FormGN24 FormGN24
        {
            get { return view.FormGN24; }
        }

        public override bool GN6
        {
            get { return view.GN6; }
        }

        public override FormGN6 FormGN6
        {
            get { return view.FormGN6; }
        }

        public override bool GN75A
        {
            get { return view.GN75A; }
        }

        public override FormGN75A FormGN75A
        {
            get { return view.FormGN75A; }
        }

        public override bool GN1
        {
            get { return view.GN1; }
        }

        public override FormGN1 FormGN1
        {
            get { return view.FormGN1; }
        }

        public override WorkPermitSafetyFormState GN11
        {
            get { return view.GN11; }           
        }

        public override WorkPermitSafetyFormState GN27
        {
            get { return view.GN27; }         
        }
      
        public override bool WorkersMinimumSafetyRequirementsSectionNotApplicableToJob
        {
            get { return view.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob; }
        }

        public override bool FaceShield
        {
            get { return view.FaceShield; }
        }

        public override bool Goggles
        {
            get { return view.Goggles; }
        }

        public override bool RubberBoots
        {
            get { return view.RubberBoots; }
        }

        public override bool RubberGloves
        {
            get { return view.RubberGloves; }
        }

        public override bool RubberSuit
        {
            get { return view.RubberSuit; }
        }

        public override bool SafetyHarnessLifeline
        {
            get { return view.SafetyHarnessLifeline; }
        }

        public override bool HighVoltagePPE
        {
            get { return view.HighVoltagePPE; }
        }

        public override bool Other1Selected
        {
            get { return view.Other1; }
        }

        public override string Other1Text
        {
            get { return view.Other1Value; }
        }

        public override bool EquipmentGrounded
        {
            get { return view.EquipmentGrounded; }
        }

        public override bool FireBlanket
        {
            get { return view.FireBlanket; }
        }

        public override bool FireExtinguisher
        {
            get { return view.FireExtinguisher; }
        }

        public override bool FireMonitorManned
        {
            get { return view.FireMonitorManned; }
        }

        public override bool FireWatch
        {
            get { return view.FireWatch; }
        }

        public override bool SewersDrainsCovered
        {
            get { return view.SewersDrainsCovered; }
        }

        public override bool SteamHose
        {
            get { return view.SteamHose; }
        }

        public override bool Other2Selected
        {
            get { return view.Other2; }
        }

        public override string Other2Text
        {
            get { return view.Other2Value; }
        }

        public override bool AirPurifyingRespirator
        {
            get { return view.AirPurifyingRespirator; }            
        }

        public override bool BreathingAirApparatus
        {
            get { return view.BreathingAirApparatus; }           
        }

        public override bool DustMask
        {
            get { return view.DustMask; }           
        }

        public override bool LifeSupportSystem
        {
            get { return view.LifeSupportSystem; }           
        }

        public override bool SafetyWatch
        {
            get { return view.SafetyWatch; }            
        }

        public override bool ContinuousGasMonitor
        {
            get { return view.ContinuousGasMonitor; }           
        }

        public override bool WorkersMonitor
        {
            get { return view.WorkersMonitor; }            
        }

        public override string WorkersMonitorNumber
        {
            get { return view.WorkersMonitorNumber; }           
        }

        public override bool BumpTestMonitorPriorToUse
        {
            get { return view.BumpTestMonitorPriorToUse; }          
        }

        public override bool Other3Selected
        {
            get { return view.Other3; }
        }

        public override string Other3Text
        {
            get { return view.Other3Value; }           
        }

        public override bool AirMover
        {
            get { return view.AirMover; }            
        }

        public override bool BarriersSigns
        {
            get { return view.BarriersSigns; }           
        }

        public override bool RadioChannel
        {
            get { return view.RadioChannel; }            
        }

        public override string RadioChannelNumber
        {
            get { return view.RadioChannelNumber; }            
        }

        public override bool AirHorn
        {
            get { return view.AirHorn; }            
        }

        public override bool MechVentilationComfortOnly
        {
            get { return view.MechVentilationComfortOnly; }            
        }

        public override bool AsbestosMMCPrecautions
        {
            get { return view.AsbestosMMCPrecautions; }            
        }

        public override bool Other4Selected
        {
            get { return view.Other4; }
        }

        public override string Other4Text
        {
            get { return view.Other4Value; }            
        }

        public override void ActionForNumberOfWorkersLessThanOrEqualToZero()
        {
            view.SetErrorForNumberOfWorkersLessThanOrEqualToZero();
        }

        public override void ActionForNoGroup()
        {
            view.SetErrorForNoGroup();
        }

        public override void ActionForNoFunctionalLocation()
        {
            view.SetErrorForNoFunctionalLocation();
        }

        public override void ActionForNoAreaLabel()
        {
            view.SetErrorForNoAreaLabel();
        }

        public override void ActionForNoPermitType()
        {
            view.SetErrorForNoPermitType();
        }

        public override Date RequestedStartDate
        {
            get { return view.RequestedStartDate; }
        }

        public override void ActionForNoStartTime()
        {
            view.SetErrorForNoStartTime();
        }

        public override void ActionForNoDescription()
        {
            view.SetErrorForNoDescription();
        }

        public override void ActionForNoContractor()
        {
            view.SetErrorForNoContractor();
        }

        public override void ActionForNoAreaAffected()
        {
            view.SetErrorForNoAreaAffected();
        }

        public override void ActionForNoPersonNotified()
        {
            view.SetErrorForNoPersonNotified();
        }

        public override void ActionForNoOccupation()
        {
            view.SetErrorForNoOccupation();
        }

        public override void ActionForNoLocation()
        {
            view.SetErrorForNoLocation();
        }

        public override void ActionForNoApprovedGN59Form(string message)
        {
            view.SetErrorForNoApprovedGN59Form(message);
        }

        public override void ActionForNoApprovedGN7Form(string message)
        {
            view.SetErrorForNoApprovedGN7Form(message);
        }

        public override void ActionForNoApprovedGN6Form(string message)
        {
            view.SetErrorForNoApprovedGN6Form(message);
        }

        public override void ActionForNoApprovedGN24Form(string message)
        {
            view.SetErrorForNoApprovedGN24Form(message);
        }

        public override void ActionForNoApprovedGN75AForm(string message)
        {
            view.SetErrorForNoApprovedGN75AForm(message);
        }

        public override void ActionForNoApprovedGN1Form(string message)
        {
            view.SetErrorForNoApprovedGN1Form(message);
        }

        //Start Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016
        public override void ActionForValidTradeCheckGN1Form(string message)
        {
            view.ActionForValidTradeCheckGN1Form(message);
        }
        //End Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016

        public override void ActionForInvalidGN11Value(string message)
        {
            view.SetErrorForInvalidGN11Value(message);
        }

        public override void ActionForInvalidGN27Value(string message)
        {
            view.SetErrorForInvalidGN27Value(message);
        }

        public override void ActionForNoSafetyRequirementChosen()
        {
            view.SetErrorForNoSafetyRequirementChosen();
        }

        public override void ActionForNoConfinedSpaceClass(string message)
        {
            view.SetErrorForNoConfinedSpaceClass(message);
        }

        public override void ActionForNoConfinedSpaceCardNumber(string message)
        {
            view.SetErrorForNoConfinedSpaceCardNumber(message);
        }

        public override void ActionForNoRescuePlanFormNumber(string message)
        {
            view.SetErrorForNoRescuePlanFormNumber(message);            
        }

        public override void ActionForNoSpecialWorkType()
        {
            view.SetErrorForNoSpecialWorkType();
        }
        
        public override void ActionForNoRoadAccessOnPermitType()
        {
            view.SetErrorForNoRoadAccessOnPermit();
        }

        public override bool RoadAccessOnPermit
        {
            get { return view.RoadAccessOnPermit; }
        }

        public override string RoadAccessOnPermitType
        {
            get { return view.RoadAccessOnPermitType; }
        }

        public override void ActionForNoStartDate()
        {
            // This should never happen because the WinForm control forces you to have a value by default.
        }

        public override void ActionForNoEndDate()
        {
            // This should never happen because the WinForm control forces you to have a value by default.
        }

        public override void ActionForStartDateAfterEndDate()
        {
            view.SetErrorForStartDateTimeNotBeforeEndDateTime();
        }

        public override void ActionForOther1SelectedWithNoValue()
        {
            view.SetErrorForOther1CheckedWithNoValue();
        }

        public override void ActionForOther2SelectedWithNoValue()
        {
            view.SetErrorForOther2CheckedWithNoValue();
        }

        public override void ActionForOther3SelectedWithNoValue()
        {
            view.SetErrorForOther3CheckedWithNoValue();
        }

        public override void ActionForOther4SelectedWithNoValue()
        {
            view.SetErrorForOther4CheckedWithNoValue();
        }

        public override bool AlkylationEntry
        {
            get { return view.AlkylationEntry; }
        }

        public override string AlkylationEntryClassOfClothing
        {
            get { return view.AlkylationEntryClassOfClothing; }
        }

        public override bool FlarePitEntry
        {
            get { return view.FlarePitEntry; }
        }

        public override string FlarePitEntryType
        {
            get { return view.FlarePitEntryType; }
        }

        public override bool ConfinedSpace
        {
            get { return view.ConfinedSpace; }
        }

        public override string ConfinedSpaceClass
        {
            get { return view.ConfinedSpaceClass; }
        }

        public override string ConfinedSpaceCardNumber
        {
            get { return view.ConfinedSpaceCardNumber; }
        }

        public override bool RescuePlan
        {
            get { return view.RescuePlan; }
        }

        public override string RescuePlanFormNumber
        {
            get { return view.RescuePlanFormNumber; }
        }

        public override bool SpecialWork
        {
            get { return view.SpecialWork; }
        }

        public override EdmontonPermitSpecialWorkType SpecialWorkType
        {
            get { return view.SpecialWorkType; }
        }
        //mangesh for SpecialWork
        public override SpecialWork specialworktype
        {
            get { return view.specialworktype; }
        }

        public override string SpecialWorkName
        {
            get { return view.SpecialWorkName; }
        }
    }
}


