using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Validation.Lubes
{
    public class WorkPermitLubesValidator
    {
        private readonly WorkPermitLubesBaseValidationAdapter adapter;
        private readonly LabelAttributes attributesForHazardLabel;
        private readonly LabelAttributes attributesForTaskDescriptionLabel;
        private bool hasErrors;
        private bool hasWarnings;

        public WorkPermitLubesValidator(WorkPermitLubesBaseValidationAdapter adapter,
            LabelAttributes attributesForTaskDescriptionLabel, LabelAttributes attributesForHazardLabel)
        {
            this.adapter = adapter;
            this.attributesForTaskDescriptionLabel = attributesForTaskDescriptionLabel;
            this.attributesForHazardLabel = attributesForHazardLabel;
        }

        public bool HasErrors
        {
            get { return hasErrors; }
        }

        public bool HasWarnings
        {
            get { return hasWarnings; }
        }

        protected void SetHasError()
        {
            hasErrors = true;
        }

        protected void SetHasWarning()
        {
            hasWarnings = true;
        }

        protected void ClearErrors()
        {
            adapter.ClearErrors();
            hasErrors = false;
            hasWarnings = false;
        }

        public void ValidateAndSetErrors(DateTime nowInLubes, int preShiftPaddingInMinutes,
            int postShiftPaddingInMinutes)
        {
            ClearErrors();

            ValidateNumberOfWorkers();
            ValidateHasFunctionalLocation();
            ValidateHasTrade();
            ValidateHasLocation();
            ValidateHasPermitType();
            ValidateIssuedToSection();
            ValidateHasDescription();
            ValidateHasOtherHazards();
            ValidateStartAndExpireDateTimes(nowInLubes, preShiftPaddingInMinutes, postShiftPaddingInMinutes);
            ValidateHasRequestedByGroup();
            ValidateHasAreaAndPersonNotifiedIfOtherAreasAffected();
            ValidateTypeOfWorkFieldsHaveValuesIfTheyAreChecked();
            ValidateFormRequirementsSection();
            ValidateHasAtLeastOneSpecificRequirementIfSectionIsEnabled();
            ValidateSpecificRequirementsAreFilledInIfTheyAreChecked();
            ValidateWorkPreparationSectionIfItIsEnabled();
            ValidateAtmosphericGasTestRequired();
            ValidateHazardsFitsPrintout();
            ValidateTaskDescriptionFitsPrintout();
            ValidateGasDetectorBumpTested();
        }

        private void ValidateGasDetectorBumpTested()
        {
            if (adapter.AtmosphericGasTestRequired && !adapter.GasDetectorBumpTested)
            {
                adapter.ActionForGasDetectorBumpTestedMustBeChecked();
                SetHasWarning();
            }
        }

        private void ValidateWorkPreparationSectionIfItIsEnabled()
        {
            if (!adapter.WorkPreparationsCompletedSectionNotApplicableToJob)
            {
                if (adapter.ProductNormallyInPipingEquipment.IsNullOrEmptyOrWhitespace())
                {
                    adapter.ActionForNoProductNormallyInPipingEquipment();
                    SetHasWarning();
                }

                if (adapter.EnergyControlPlan.IsNullOrEmptyOrWhitespace())
                {
                    adapter.ActionForNoEnergyControlPlan();
                    SetHasWarning();
                }

                if (adapter.LockBoxNumber.IsNullOrEmptyOrWhitespace())
                {
                    adapter.ActionForNoLockBoxNumber();
                    SetHasWarning();
                }
            }
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

            if (WorkPermitSafetyFormState.Required.Equals(adapter.EnergyControlPlanFormRequirement))
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

        private void ValidateNumberOfWorkers()
        {
            if (adapter.NumberOfWorkers != null && adapter.NumberOfWorkers.Value <= 0)
            {
                adapter.ActionForNumberOfWorkersLessThanOrEqualToZero();
                SetHasError();
            }
            else if (adapter.NumberOfWorkers == null)
            {
                adapter.ActionForNoNumberOfWorkers();
                SetHasWarning();
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

        private void ValidateHasOtherHazards()
        {
            if (adapter.OtherHazards.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForNoOtherHazards();
                SetHasWarning();
            }
        }

        private void ValidateIssuedToSection()
        {
            if (!adapter.IssuedToSuncor && !adapter.IssuedToContractor)
            {
                adapter.ActionForNoIssuedTo();
                SetHasWarning();
            }
            else if (adapter.IssuedToContractor && adapter.Contractor.IsNullOrEmptyOrWhitespace())
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

        private void ValidateTaskDescriptionFitsPrintout()
        {
            if (
                !DevExpressMeasurementUtility.StringWillFitIntoField(attributesForTaskDescriptionLabel,
                    adapter.Description))
            {
                adapter.ActionForTaskDescriptionDoesNotFitPrintout();
            }
        }

        private void ValidateHazardsFitsPrintout()
        {
            if (!DevExpressMeasurementUtility.StringWillFitIntoField(attributesForHazardLabel, adapter.OtherHazards))
            {
                adapter.ActionForHazardsDoesNotFitPrintout();
            }
        }

        private void ValidateStartAndExpireDateTimes(DateTime nowInLubes, int preShiftPaddingInMinutes,
            int postShiftPaddingInMinutes)
        {
            var startDateTime = adapter.StartDateTime;
            var expireDateTime = adapter.ExpireDateTime;

            if (WorkPermitLubes.StartAndExpireDateTimesDoNotFallWithinTheSameShiftOrTheShiftIsInThePast(nowInLubes,
                startDateTime, expireDateTime, preShiftPaddingInMinutes, postShiftPaddingInMinutes))
            {
                adapter.ActionForStartAndEndNotWithinCurrentShiftOrFutureShift();
                SetHasWarning();
            }

            if (startDateTime > expireDateTime)
            {
                adapter.ActionForStartDateTimeNotBeforeEndDateTime();
                SetHasError();
            }

            if (expireDateTime < nowInLubes)
            {
                adapter.ActionForExpireDateTimeInThePast();
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
            if (adapter.ConfinedSpace && adapter.ConfinedSpaceClass.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForNoConfinedSpaceClass();
                SetHasWarning();
            }

            if (adapter.SpecialWork && adapter.SpecialWorkType == null)
            {
                adapter.ActionForNoSpecialWorkType();
                SetHasError();
            }
        }

        private void ValidateAtmosphericGasTestRequired()
        {
            if ((adapter.ConfinedSpace || WorkPermitLubesType.HOT_WORK.Equals(adapter.WorkPermitType)) &&
                !adapter.AtmosphericGasTestRequired)
            {
                adapter.ActionForAtmosphericGasTestRequiredMustBeChecked();
                SetHasError();
            }
        }
    }
}