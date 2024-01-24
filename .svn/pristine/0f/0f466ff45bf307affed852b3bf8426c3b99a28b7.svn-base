using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.Validation.Lubes
{
    public class PermitRequestLubesValidator
    {
        private readonly PermitRequestLubesBaseValidationAdapter adapter;
        private bool hasErrors;
        private bool hasWarnings;

        private bool validateHasRun;

        public PermitRequestLubesValidator(PermitRequestLubesBaseValidationAdapter adapter)
        {
            this.adapter = adapter;
        }

        public List<string> MissingImportFieldList
        {
            get { return adapter.MissingImportFieldList; }
        }

        public bool HasErrors
        {
            get
            {
                if (!validateHasRun)
                {
                    throw new InvalidOperationException("Validation has not been executed.");
                }

                return hasErrors;
            }
        }

        public bool HasWarnings
        {
            get
            {
                if (!validateHasRun)
                {
                    throw new InvalidOperationException("Validation has not been executed.");
                }

                return hasWarnings;
            }
        }

        public PermitRequestCompletionStatus CompletionStatus
        {
            get
            {
                if (IsComplete())
                {
                    return PermitRequestCompletionStatus.Complete;
                }

                return PermitRequestCompletionStatus.Incomplete;
            }
        }

        protected void ClearErrors()
        {
            hasWarnings = false;
            hasErrors = false;
            adapter.ClearErrors();
        }

        protected void SetHasWarning()
        {
            hasWarnings = true;
        }

        protected void SetHasError()
        {
            hasErrors = true;
        }

        private bool IsComplete()
        {
            return !HasErrors && !HasWarnings;
        }

        public void Validate(DateTime nowInLubes)
        {
            validateHasRun = true;

            ClearErrors();

            ValidateHasTrade();
            ValidateHasFunctionalLocation();
            ValidateHasPermitType();
            ValidateHasDescription();
            ValidateHasContractorIfContractorCheckboxIsChecked();
            ValidateNumberOfWorkersIsPositive();
            ValidateHasLocation();
            ValidateHasRequestedByGroup();
            ValidateHasAreaAndPersonNotifiedIfOtherAreasAffected();
            ValidateTypeOfWorkFieldsHaveValuesIfTheyAreChecked();
            ValidateFormRequirementsSection();
            ValidateSpecificRequirementsAreFilledInIfTheyAreChecked();
            ValidateHasAtLeastOneSpecificRequirementIfSectionIsEnabled();
            ValidateStartAndEndDates(nowInLubes);
        }

        private void ValidateSpecificRequirementsAreFilledInIfTheyAreChecked()
        {
            if (!adapter.SpecificRequirementsSectionNotApplicableToJob)
            {
                if (adapter.Other1Checked && adapter.Other1Value.IsNullOrEmptyOrWhitespace())
                {
                    adapter.ActionForOther1CheckedWithNoValue();
                    SetHasError();
                }

                if (adapter.Other2Checked && adapter.Other2Value.IsNullOrEmptyOrWhitespace())
                {
                    adapter.ActionForOther2CheckedWithNoValue();
                    SetHasError();
                }

                if (adapter.Other3Checked && adapter.Other3Value.IsNullOrEmptyOrWhitespace())
                {
                    adapter.ActionForOther3CheckedWithNoValue();
                    SetHasError();
                }

                if (adapter.DesignateHotOrColdCutChecked &&
                    adapter.DesignateHotOrColdCutValue.IsNullOrEmptyOrWhitespace())
                {
                    adapter.ActionForDesignateHotOrColdCutCheckedWithNoValue();
                    SetHasWarning();
                }
            }
        }

        private void ValidateHasAtLeastOneSpecificRequirementIfSectionIsEnabled()
        {
            if (!adapter.SpecificRequirementsSectionNotApplicableToJob)
            {
                var values = new List<bool>
                {
                    adapter.AttendedAtAllTimes,
                    adapter.EyeProtection,
                    adapter.FallProtectionEquipment,
                    adapter.FullBodyHarnessRetrieval,
                    adapter.HearingProtection,
                    adapter.ProtectiveClothing,
                    adapter.Other1Checked,
                    adapter.EquipmentBondedGrounded,
                    adapter.FireBlanket,
                    adapter.FireFightingEquipment,
                    adapter.FireWatch,
                    adapter.HydrantPermit,
                    adapter.WaterHose,
                    adapter.SteamHose,
                    adapter.Other2Checked,
                    adapter.AirMover,
                    adapter.ContinuousGasMonitor,
                    adapter.DrowningProtection,
                    adapter.RespiratoryProtection,
                    adapter.Other3Checked,
                    adapter.AdditionalLighting,
                    adapter.DesignateHotOrColdCutChecked,
                    adapter.HoistingEquipment,
                    adapter.Ladder,
                    adapter.MotorizedEquipment,
                    adapter.Scaffold,
                    adapter.ReferToTipsProcedure
                };

                var noValueIsChecked = values.TrueForAll(value => value == false);
                if (noValueIsChecked)
                {
                    adapter.ActionForSpecificRequirementsSectionEnabledButNothingChecked();
                    SetHasWarning();
                }
            }
        }

        private void ValidateFormRequirementsSection()
        {
            if (WorkPermitSafetyFormState.Required.Equals(adapter.HighEnergy))
            {
                adapter.ActionForInvalidHighEnergyValue();
                SetHasWarning();
            }

            if (WorkPermitSafetyFormState.Required.Equals(adapter.CriticalLift))
            {
                adapter.ActionForInvalidCriticalLiftValue();
                SetHasWarning();
            }

            if (WorkPermitSafetyFormState.Required.Equals(adapter.Excavation))
            {
                adapter.ActionForInvalidExcavationValue();
                SetHasWarning();
            }

            if (WorkPermitSafetyFormState.Required.Equals(adapter.EnergyControlPlan))
            {
                adapter.ActionForInvalidEnergyControlPlanValue();
                SetHasWarning();
            }

            if (WorkPermitSafetyFormState.Required.Equals(adapter.EquivalencyProc))
            {
                adapter.ActionForInvalidEquivalencyProcValue();
                SetHasWarning();
            }

            if (WorkPermitSafetyFormState.Required.Equals(adapter.TestPneumatic))
            {
                adapter.ActionForInvalidTestPneumaticValue();
                SetHasWarning();
            }

            if (WorkPermitSafetyFormState.Required.Equals(adapter.LiveFlareWork))
            {
                adapter.ActionForInvalidLiveFlareWorkValue();
                SetHasWarning();
            }

            if (WorkPermitSafetyFormState.Required.Equals(adapter.EntryAndControlPlan))
            {
                adapter.ActionForInvalidEntryAndControlPlanValue();
                SetHasWarning();
            }

            if (WorkPermitSafetyFormState.Required.Equals(adapter.EnergizedElectrical))
            {
                adapter.ActionForInvalidEnergizedElectricalValue();
                SetHasWarning();
            }
        }

        private void ValidateNumberOfWorkersIsPositive()
        {
            if (adapter.NumberOfWorkers != null && adapter.NumberOfWorkers.Value <= 0)
            {
                adapter.ActionForNumberOfWorkersLessThanOrEqualToZero();
                SetHasError();
            }
        }

        private void ValidateHasRequestedByGroup()
        {
            if (adapter.RequestedByGroup == null)
            {
                adapter.ActionForNoRequestedByGroup();
                SetHasError();
            }
        }

        private void ValidateHasFunctionalLocation()
        {
            if (adapter.FunctionalLocation == null)
            {
                adapter.ActionForNoFunctionalLocation();
                SetHasError();
            }
        }

        private void ValidateHasPermitType()
        {
            if (adapter.WorkPermitType == null || WorkPermitType.NULL.Equals(adapter.WorkPermitType))
            {
                adapter.ActionForNoPermitType();
                SetHasError();
            }
        }

        private void ValidateHasDescription()
        {
            if (adapter.Description.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForNoDescription();
                SetHasError();
            }
        }

        private void ValidateHasContractorIfContractorCheckboxIsChecked()
        {
            if (adapter.IssuedToContractor && adapter.Company.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForNoContractor();
                SetHasWarning();
            }
        }

        private void ValidateHasTrade()
        {
            if (adapter.Trade.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForNoTrade();
                SetHasError();
            }
        }

        private void ValidateHasLocation()
        {
            if (adapter.Location.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForNoLocation();
                SetHasError();
            }
        }

        private void ValidateHasAreaAndPersonNotifiedIfOtherAreasAffected()
        {
            if (!adapter.OtherAreasAndOrUnitsAffected)
            {
                return;
            }

            if (adapter.OtherAreasAndOrUnitsAffectedArea.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForNoAreaAffected();
                SetHasError();
            }

            if (adapter.OtherAreasAndOrUnitsAffectedPersonNotified.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForNoPersonNotified();
                SetHasError();
            }
        }

        private void ValidateTypeOfWorkFieldsHaveValuesIfTheyAreChecked()
        {
            if (adapter.SpecialWork && adapter.SpecialWorkType == null)
            {
                adapter.ActionForNoSpecialWorkType();
                SetHasError();
            }
        }

        private void ValidateStartAndEndDates(DateTime nowInLubes)
        {
            var startDate = adapter.RequestedStartDate;
            var endDate = adapter.RequestedEndDate;

            if (startDate == null)
            {
                adapter.ActionForNoRequestedStartDate();
                SetHasError();
            }

            if (endDate == null)
            {
                adapter.ActionForNoRequestedEndDate();
                SetHasError();
            }

            if (startDate != null && endDate != null)
            {
                if (startDate > endDate)
                {
                    adapter.ActionForStartDateNotBeforeEndDate();
                    SetHasError();
                }

                if (endDate < nowInLubes.ToDate())
                {
                    adapter.ActionForEndDateInThePast();
                    SetHasError();
                }
            }

            if (adapter.RequestedStartTimeDay == null && adapter.RequestedStartTimeNight == null)
            {
                adapter.ActionForNoStartTime();
                SetHasError();
            }
        }
    }
}