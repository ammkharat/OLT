﻿using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Validation.Lubes;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Validation.Lubes
{
    public class WorkPermitLubesValidationViewAdapter : WorkPermitLubesBaseValidationAdapter
    {
        private readonly IWorkPermitLubesView view;

        public WorkPermitLubesValidationViewAdapter(IWorkPermitLubesView view)
        {
            this.view = view;
        }

        public override void ClearErrors() { view.ClearErrorProviders(); }

        public override int? NumberOfWorkers
        {
            get { return view.NumberOfWorkers; }
        }

        public override FunctionalLocation FunctionalLocation
        {
            get { return view.FunctionalLocation; }
        }

        public override WorkPermitLubesType WorkPermitType
        {
            get { return view.WorkPermitType; }
        }

        public override string Description
        {
            get { return view.TaskDescription; }
        }

        public override bool IssuedToContractor
        {
            get { return view.IssuedToCompany; }
        }

        public override bool IssuedToSuncor
        {
            get { return view.IssuedToSuncor; }
        }

        public override string OtherHazards
        {
            get { return view.OtherHazardsAndOrRequirements; }
        }

        public override void ActionForNoOtherHazards()
        {
            view.SetErrorForNoOtherHazards();
        }

        public override string Contractor
        {
            get { return view.Company; }
        }

        public override string Location
        {
            get { return view.Location; }
        }

        public override string Trade
        {
            get { return view.Trade; }
        }

        public override DateTime StartDateTime { get { return view.StartDateTime; } }
        public override DateTime ExpireDateTime { get { return view.ExpireDateTime; } }

        public override void ActionForNoNumberOfWorkers()
        {
            view.SetWarningForNoNumberOfWorkers();
        }

        public override void ActionForNumberOfWorkersLessThanOrEqualToZero()
        {
            view.SetErrorForNumberOfWorkersLessThanOrEqualToZero();
        }

        public override void ActionForStartAndEndNotWithinCurrentShiftOrFutureShift()
        {
            view.SetWarningForStartAndEndNotWithinCurrentShiftOrFutureShift();
        }

        public override void ActionForStartDateTimeNotBeforeEndDateTime()
        {
            view.SetErrorForStartDateTimeNotBeforeEndDateTime();
        }

        public override void ActionForExpireDateTimeInThePast()
        {
            view.SetErrorForExpireDateTimeInThePast();
        }

        public override void ActionForNoTrade()
        {
            view.SetErrorForNoTrade();
        }

        public override void ActionForNoLocation()
        {
            view.SetErrorForNoLocation();
        }

        public override void ActionForNoFunctionalLocation()
        {
            view.SetErrorForNoFunctionalLocation();
        }

        public override void ActionForNoContractor()
        {
            view.SetErrorForNoContractor();
        }

        public override void ActionForNoIssuedTo()
        {
            view.SetErrorForNoIssuedTo();
        }

        public override void ActionForNoDescription()
        {
            view.SetErrorForNoDescription();
        }

        public override void ActionForNoPermitType()
        {
            view.SetErrorForNoPermitType();
        }

        public override WorkPermitLubesGroup RequestedByGroup
        {
            get { return view.RequestedByGroup; }
        }

        public override void ActionForNoRequestedByGroup()
        {
            view.SetErrorForNoRequestedByGroup();
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

        public override void ActionForNoAreaAffected()
        {
            view.SetErrorForNoAreaAffected();
        }

        public override void ActionForNoPersonNotified()
        {
            view.SetErrorForNoPersonNotified();
        }

        public override bool ConfinedSpace
        {
            get { return view.ConfinedSpace; }
        }

        public override string ConfinedSpaceClass
        {
            get { return view.ConfinedSpaceClass; }
        }

        public override void ActionForNoConfinedSpaceClass()
        {
            view.SetErrorForNoConfinedSpaceClass();
        }

        public override bool SpecialWork
        {
            get { return view.SpecialWork; }
        }

        public override string SpecialWorkType
        {
            get { return view.SpecialWorkType; }
        }

        public override void ActionForNoSpecialWorkType()
        {
            view.SetErrorForNoSpecialWorkType();
        }

        public override WorkPermitSafetyFormState HighEnergy
        {
            get { return view.HighEnergy; }
        }

        public override void ActionForInvalidHighEnergyValue()
        {
            view.SetErrorForInvalidHighEnergyValue();
        }

        public override WorkPermitSafetyFormState CriticalLift
        {
            get { return view.CriticalLift; }
        }

        public override void ActionForInvalidCriticalLiftValue()
        {
            view.SetErrorForInvalidCriticalLiftValue();
        }

        public override WorkPermitSafetyFormState Excavation
        {
            get { return view.Excavation; }
        }

        public override void ActionForInvalidExcavationValue()
        {
            view.SetErrorForInvalidExcavationValue();
        }

        public override WorkPermitSafetyFormState EnergyControlPlanFormRequirement
        {
            get { return view.EnergyControlPlanFormRequirement; }
        }

        public override void ActionForInvalidEnergyControlPlanValue()
        {
            view.SetErrorForInvalidEnergyControlPlanValue();
        }

        public override WorkPermitSafetyFormState EquivalencyProc
        {
            get { return view.EquivalencyProc; }
        }

        public override void ActionForInvalidEquivalencyProcValue()
        {
            view.SetErrorForInvalidEquivalencyProcValue();
        }

        public override WorkPermitSafetyFormState TestPneumatic
        {
            get { return view.TestPneumatic; }
        }

        public override void ActionForInvalidTestPneumaticValue()
        {
            view.SetErrorForInvalidTestPneumaticValue();
        }

        public override WorkPermitSafetyFormState LiveFlareWork
        {
            get { return view.LiveFlareWork; }
        }

        public override void ActionForInvalidLiveFlareWorkValue()
        {
            view.SetErrorForInvalidLiveFlareWorkValue();
        }

        public override WorkPermitSafetyFormState EntryAndControlPlan
        {
            get { return view.EntryAndControlPlan; }
        }

        public override void ActionForInvalidEntryAndControlPlanValue()
        {
            view.SetErrorForInvalidEntryAndControlPlanValue();
        }

        public override WorkPermitSafetyFormState EnergizedElectrical
        {
            get { return view.EnergizedElectrical; }
        }

        public override void ActionForInvalidEnergizedElectricalValue()
        {
            view.SetErrorForInvalidEnergizedElectricalValue();
        }

        public override bool SpecificRequirementsSectionNotApplicableToJob
        {
            get { return view.SpecificRequirementsSectionNotApplicableToJob; }
        }

        public override bool AttendedAtAllTimes
        {
            get { return view.AttendedAtAllTimes; }
        }

        public override bool EyeProtection
        {
            get { return view.EyeProtection; }
        }

        public override bool FallProtectionEquipment
        {
            get { return view.FallProtectionEquipment; }
        }

        public override bool FullBodyHarnessRetrieval
        {
            get { return view.FullBodyHarnessRetrieval; }
        }

        public override bool HearingProtection
        {
            get { return view.HearingProtection; }
        }

        public override bool ProtectiveClothing
        {
            get { return view.ProtectiveClothing; }
        }

        public override bool Other1Checked
        {
            get { return view.Other1Checked; }
        }

        public override string Other1Value
        {
            get { return view.Other1Value; }
        }

        public override bool EquipmentBondedGrounded
        {
            get { return view.EquipmentBondedGrounded; }
        }

        public override bool FireBlanket
        {
            get { return view.FireBlanket; }
        }

        public override bool FireFightingEquipment
        {
            get { return view.FireFightingEquipment; }
        }

        public override bool FireWatch
        {
            get { return view.FireWatch; }
        }

        public override bool HydrantPermit
        {
            get { return view.HydrantPermit; }
        }

        public override bool WaterHose
        {
            get { return view.WaterHose; }
        }

        public override bool SteamHose
        {
            get { return view.SteamHose; }
        }

        public override bool Other2Checked
        {
            get { return view.Other2Checked; }
        }

        public override string Other2Value
        {
            get { return view.Other2Value; }
        }

        public override bool AirMover
        {
            get { return view.AirMover; }
        }

        public override bool ContinuousGasMonitor
        {
            get { return view.ContinuousGasMonitor; }
        }

        public override bool DrowningProtection
        {
            get { return view.DrowningProtection; }
        }

        public override bool RespiratoryProtection
        {
            get { return view.RespiratoryProtection; }
        }

        public override bool Other3Checked
        {
            get { return view.Other3Checked; }
        }

        public override string Other3Value
        {
            get { return view.Other3Value; }
        }

        public override bool AdditionalLighting
        {
            get { return view.AdditionalLighting; }
        }

        public override bool DesignateHotOrColdCutChecked
        {
            get { return view.DesignateHotOrColdCutChecked; }
        }

        public override string DesignateHotOrColdCutValue
        {
            get { return view.DesignateHotOrColdCutValue; }
        }

        public override bool HoistingEquipment
        {
            get { return view.HoistingEquipment; }
        }

        public override bool Ladder
        {
            get { return view.Ladder; }
        }

        public override bool MotorizedEquipment
        {
            get { return view.MotorizedEquipment; }
        }

        public override bool Scaffold
        {
            get { return view.Scaffold; }
        }

        public override bool ReferToTipsProcedure
        {
            get { return view.ReferToTipsProcedure; }
        }

        public override void ActionForDesignateHotOrColdCutCheckedWithNoValue()
        {
            view.SetErrorForDesignateHotOrColdCutCheckedWithNoValue();
        }

        public override bool WorkPreparationsCompletedSectionNotApplicableToJob
        {
            get { return view.WorkPreparationsCompletedSectionNotApplicableToJob; }
        }

        public override string ProductNormallyInPipingEquipment
        {
            get { return view.ProductNormallyInPipingEquipment; }
        }

        public override void ActionForNoProductNormallyInPipingEquipment()
        {
            view.SetErrorForNoProductNormallyInPipingEquipment();
        }

        public override string EnergyControlPlan
        {
            get { return view.EnergyControlPlan; }
        }

        public override void ActionForNoEnergyControlPlan()
        {
            view.SetErrorForNoEnergyControlPlan();
        }

        public override string LockBoxNumber
        {
            get { return view.LockBoxNumber; }
        }

        public override void ActionForNoLockBoxNumber()
        {
            view.SetErrorForNoLockBoxNumber();
        }

        public override string OtherPreparations
        {
            get { return view.OtherPreparations; }
        }

        public override void ActionForOther1CheckedWithNoValue()
        {
            view.SetErrorForOther1CheckedWithNoValue();
        }

        public override void ActionForOther2CheckedWithNoValue()
        {
            view.SetErrorForOther2CheckedWithNoValue();
        }

        public override void ActionForOther3CheckedWithNoValue()
        {
            view.SetErrorForOther3CheckedWithNoValue();
        }

        public override void ActionForSpecificRequirementsSectionEnabledButNothingChecked()
        {
            view.SetErrorForSpecificRequirementsSectionEnabledButNothingChecked();
        }

        public override bool AtmosphericGasTestRequired
        {
            get { return view.AtmosphericGasTestRequired; }
        }

        public override void ActionForAtmosphericGasTestRequiredMustBeChecked()
        {
            view.SetErrorForAtmosphericGasTestRequiredMustBeCheckedIfHotOrConfinedSpace();
        }

        public override void ActionForHazardsDoesNotFitPrintout()
        {
            view.SetWarningForHazardsDoesNotFitPrintout();
        }

        public override void ActionForTaskDescriptionDoesNotFitPrintout()
        {
            view.SetWarningForTaskDescriptionDoesNotFitPrintout();
        }

        public override bool GasDetectorBumpTested
        {
            get { return view.GasDetectorBumpTested; }
        }

        public override void ActionForGasDetectorBumpTestedMustBeChecked()
        {
            view.SetWarningForGasDetectorBumpTestedRequired();
        }
    }
}