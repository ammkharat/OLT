using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Domain.Validation.Lubes
{
    public abstract class PermitRequestLubesBaseValidationAdapter
    {
        public abstract int? NumberOfWorkers { get; }

        public abstract FunctionalLocation FunctionalLocation { get; }

        public abstract WorkPermitLubesType WorkPermitType { get; }

        public abstract Date RequestedStartDate { get; }
        public abstract Time RequestedStartTimeDay { get; }
        public abstract Time RequestedStartTimeNight { get; }
        public abstract Date RequestedEndDate { get; }

        public abstract string WorkOrderNumber { get; }

        public abstract string OperationNumber { get; }

        public abstract string SubOperationNumber { get; }

        public abstract string Description { get; }

        public abstract bool IssuedToContractor { get; }
        public abstract string Company { get; }

        public abstract string Trade { get; }

        public abstract string Location { get; }

        public abstract bool OtherAreasAndOrUnitsAffected { get; }
        public abstract string OtherAreasAndOrUnitsAffectedArea { get; }
        public abstract string OtherAreasAndOrUnitsAffectedPersonNotified { get; }

        public abstract WorkPermitLubesGroup RequestedByGroup { get; }

        public abstract bool SpecialWork { get; }
        public abstract string SpecialWorkType { get; }

        public abstract WorkPermitSafetyFormState HighEnergy { get; }

        public abstract WorkPermitSafetyFormState CriticalLift { get; }

        public abstract WorkPermitSafetyFormState Excavation { get; }

        public abstract WorkPermitSafetyFormState EnergyControlPlan { get; }

        public abstract WorkPermitSafetyFormState EquivalencyProc { get; }

        public abstract WorkPermitSafetyFormState TestPneumatic { get; }

        public abstract WorkPermitSafetyFormState LiveFlareWork { get; }

        public abstract WorkPermitSafetyFormState EntryAndControlPlan { get; }

        public abstract WorkPermitSafetyFormState EnergizedElectrical { get; }

        public abstract bool SpecificRequirementsSectionNotApplicableToJob { get; }

        public abstract bool AttendedAtAllTimes { get; }
        public abstract bool EyeProtection { get; }
        public abstract bool FallProtectionEquipment { get; }
        public abstract bool FullBodyHarnessRetrieval { get; }
        public abstract bool HearingProtection { get; }
        public abstract bool ProtectiveClothing { get; }
        public abstract bool Other1Checked { get; }
        public abstract string Other1Value { get; }

        public abstract bool EquipmentBondedGrounded { get; }
        public abstract bool FireBlanket { get; }
        public abstract bool FireFightingEquipment { get; }
        public abstract bool FireWatch { get; }
        public abstract bool HydrantPermit { get; }
        public abstract bool WaterHose { get; }
        public abstract bool SteamHose { get; }
        public abstract bool Other2Checked { get; }
        public abstract string Other2Value { get; }

        public abstract bool AirMover { get; }
        public abstract bool ContinuousGasMonitor { get; }
        public abstract bool DrowningProtection { get; }
        public abstract bool RespiratoryProtection { get; }
        public abstract bool Other3Checked { get; }
        public abstract string Other3Value { get; }

        public abstract bool AdditionalLighting { get; }
        public abstract bool DesignateHotOrColdCutChecked { get; }
        public abstract string DesignateHotOrColdCutValue { get; }
        public abstract bool HoistingEquipment { get; }
        public abstract bool Ladder { get; }
        public abstract bool MotorizedEquipment { get; }
        public abstract bool Scaffold { get; }
        public abstract bool ReferToTipsProcedure { get; }

        public virtual List<string> MissingImportFieldList
        {
            get { throw new NotImplementedException(); }
        }

        public abstract void ClearErrors();
        public abstract void ActionForNumberOfWorkersLessThanOrEqualToZero();
        public abstract void ActionForNoFunctionalLocation();
        public abstract void ActionForNoPermitType();

        public virtual void ActionForNoRequestedStartDate()
        {
        }

        public virtual void ActionForNoRequestedEndDate()
        {
        }

        public virtual void ActionForStartDateNotBeforeEndDate()
        {
        }

        public virtual void ActionForEndDateInThePast()
        {
        }

        public virtual void ActionForNoStartTime()
        {
        }

        public virtual void ActionForNoWorkOrderNumber()
        {
        }

        public virtual void ActionForNoOperationNumber()
        {
        }

        public virtual void ActionForNoSubOperationNumber()
        {
        }

        public abstract void ActionForNoDescription();
        public abstract void ActionForNoContractor();
        public abstract void ActionForNoTrade();

        public virtual void ActionForNoLocation()
        {
        }

        public virtual void ActionForNoAreaAffected()
        {
        }

        public virtual void ActionForNoPersonNotified()
        {
        }

        public virtual void ActionForNoRequestedByGroup()
        {
        }

        public virtual void ActionForNoSpecialWorkType()
        {
        }

        public virtual void ActionForInvalidHighEnergyValue()
        {
        }

        public virtual void ActionForInvalidCriticalLiftValue()
        {
        }

        public virtual void ActionForInvalidExcavationValue()
        {
        }

        public virtual void ActionForInvalidEnergyControlPlanValue()
        {
        }

        public virtual void ActionForInvalidEquivalencyProcValue()
        {
        }

        public virtual void ActionForInvalidTestPneumaticValue()
        {
        }

        public virtual void ActionForInvalidLiveFlareWorkValue()
        {
        }

        public virtual void ActionForInvalidEntryAndControlPlanValue()
        {
        }

        public virtual void ActionForInvalidEnergizedElectricalValue()
        {
        }

        public virtual void ActionForSpecificRequirementsSectionEnabledButNothingChecked()
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

        public virtual void ActionForDesignateHotOrColdCutCheckedWithNoValue()
        {
        }
    }
}