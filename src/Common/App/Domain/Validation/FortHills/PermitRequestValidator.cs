using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Validation.FortHills
{
    public class PermitRequestValidator
    {
        private readonly PermitRequestBaseValidationAdapterFH adapter;
        private readonly DataSource dataSource;
        private bool hasErrors;
        private bool hasWarnings;

        private bool validateHasRun;

        public PermitRequestValidator(PermitRequestBaseValidationAdapterFH adapter, DataSource dataSource)
        {
            this.adapter = adapter;
            this.dataSource = dataSource;
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

        public virtual List<string> MissingImportFieldList
        {
            get { return adapter.MissingImportFieldList; }
        }

        public PermitRequestCompletionStatus CompletionStatus
        {
            get
            {
                if (IsComplete())
                {
                    return PermitRequestCompletionStatus.Complete;
                }

                if (adapter.Group != null && adapter.Group.IsTurnaround)
                {
                    return PermitRequestCompletionStatus.ForReview;
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

        private void ValidateStartAndEndTimes()
        {
            if (adapter.RequestedStartTime == null)
            {
                adapter.ActionForNoStartTime();
                SetHasError();
            }
        }

        private void ValidateStartAndEndDates()
        {
            if (adapter.RequestedStartDate == null)
            {
                adapter.ActionForNoStartDate();
                SetHasError();
            }
            if (adapter.RequestedEndDate == null)
            {
                adapter.ActionForNoEndDate();
                SetHasError();
            }
            if (adapter.RequestedStartDate != null && adapter.RequestedEndDate != null &&
                adapter.RequestedStartDate > adapter.RequestedEndDate)
            {
                adapter.ActionForStartDateAfterEndDate();
                SetHasError();
            }
        }

        public void Validate()
        {
            validateHasRun = true;

            ClearErrors();

           // ValidateStartAndEndTimes();
            ValidateStartAndEndDates();

            ValidateHasOccupation();
            ValidateHasGroup();
           // ValidateHasAreaLabelIfDataSourceIsNotSapOrMerge();

            ValidateHasFunctionalLocation();
            ValidateHasLocation();
            ValidateHasPermitType();
            ValidateHasDescription();
            //ValidateHasContractorIfContractorCheckboxIsChecked();
           // ValidateHasAreaAndPersonNotifiedIfOtherAreasAffected();
            ValidateNumberOfWorkersIsPositive();

            ValidateHasAtLeastOneSafetyRequirementIfSectionIsEnabledPartC();
            ValidateHasHazardsAndOrRequirementsIfSectionIsEnabledPartD();
            ValidateHasAtLeastOneWorkAuthorizationAndDocumentationIfSectionIsEnabledPartE();
            //ValidateHasAtLeastOneSafetyRequirementPartE();
            ValidateOtherSafetyRequirementsAreFilledInIfTheyAreChecked();
            ValidateTypeOfWorkFieldsHaveValuesIfTheyAreChecked();
            //ValidateFormInformation();
        }

        
        //private void ValidateHasAreaLabelIfDataSourceIsNotSapOrMerge()
        //{
        //    if (dataSource != DataSource.SAP && dataSource != DataSource.MERGE &&
        //        (adapter.AreaLabel == null || adapter.AreaLabel == AreaLabel.EMPTY))
        //    {
        //        adapter.ActionForNoAreaLabel();
        //        SetHasError();
        //    }
        //}

        private void ValidateNumberOfWorkersIsPositive()
        {
            if (adapter.NumberOfWorkers != null && adapter.NumberOfWorkers.Value <= 0)
            {
                adapter.ActionForNumberOfWorkersLessThanOrEqualToZero();
                SetHasError();
            }
        }

        private void ValidateHasGroup()
        {
            if (adapter.Group == null)
            {
                adapter.ActionForNoGroup();
                SetHasError();
            }
        }

        protected virtual void ValidateHasFunctionalLocation()
        {
            if (adapter.FunctionalLocation == null)
            {
                adapter.ActionForNoFunctionalLocation();
                SetHasError();
            }
        }

        protected virtual void ValidateHasPermitType()
        {
            if (adapter.WorkPermitType == null || WorkPermitType.NULL.Equals(adapter.WorkPermitType))
            {
                adapter.ActionForNoPermitType();
                SetHasError();
            }
        }

        protected virtual void ValidateHasDescription()
        {
            if (adapter.Description.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForNoDescription();
                SetHasError();
            }
        }

        //protected virtual void ValidateHasContractorIfContractorCheckboxIsChecked()
        //{
        //    if (adapter.IssuedToContractor && adapter.Company.IsNullOrEmptyOrWhitespace())
        //    {
        //        adapter.ActionForNoContractor();
        //        SetHasError();
        //    }
        //}

        //protected virtual void ValidateHasAreaAndPersonNotifiedIfOtherAreasAffected()
        //{
        //    if (!adapter.OtherAreasAndOrUnitsAffected)
        //    {
        //        return;
        //    }

        //    if (adapter.OtherAreasAndOrUnitsAffectedArea.IsNullOrEmptyOrWhitespace())
        //    {
        //        adapter.ActionForNoAreaAffected();
        //        SetHasError();
        //    }

        //    if (adapter.OtherAreasAndOrUnitsAffectedPersonNotified.IsNullOrEmptyOrWhitespace())
        //    {
        //        adapter.ActionForNoPersonNotified();
        //        SetHasError();
        //    }
        //}

        protected virtual void ValidateHasOccupation()
        {
            if (adapter.Occupation.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForNoOccupation();
                SetHasError();
            }
        }

        protected virtual void ValidateHasLocation()
        {
            if (adapter.Location.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForNoLocation();
                SetHasError();
            }
        }

        protected virtual void ValidateHasAtLeastOneWorkAuthorizationAndDocumentationIfSectionIsEnabledPartE()
        {
            if (!adapter.PartEWorkSectionNotApplicableToJob)
            {
                var values = new List<bool>
                {
                    adapter.ConfinedSpace,
                    adapter.GroundDisturbance,
                    adapter.FireProtectionAuthorization,
                    adapter.CriticalOrSeriousLifts,
                    adapter.VehicleEntry,
                    adapter.IndustrialRadiography,
                    adapter.ElectricalEncroachment,
                    adapter.MSDS,
                    adapter.ConfinedSpaceClass.HasEmptyValue(),
                    adapter.OthersPartEValue!=null,
                   
                };

                var noValueIsChecked = values.TrueForAll(value => value == false);
                if (noValueIsChecked)
                {
                    adapter.ActionForNoworkAuthorizationAndDocumentationChosen();
                    SetHasError();
                }
            }

        }

        protected virtual void ValidateHasAtLeastOneSafetyRequirementIfSectionIsEnabledPartC()
        {
            if (!adapter.PartCWorkSectionNotApplicableToJob)
            {
                var values = new List<bool>
                {
                    adapter.FlameResistantWorkWear,
                    adapter.ChemicalSuit,
                    adapter.FireWatch,
                    adapter.FireBlanket,
                    adapter.SuppliedBreathingAir,
                    adapter.AirMover,
                    adapter.PersonalFlotationDevice,
                    adapter.HearingProtection,
                    adapter.Other1Text!=null,
                    adapter.MonoGoggles,
                    adapter.ConfinedSpaceMoniter,
                    adapter.FireExtinguisher,
                    adapter.SparkContainment,
                    adapter.BottleWatch,
                    adapter.StandbyPerson,
                    adapter.WorkingAlone,
                    adapter.SafetyGloves,
                    adapter.Other2Text!=null,
                    adapter.FaceShield,
                    adapter.FallProtection,
                    adapter.ChargedFireHouse,
                    adapter.CoveredSewer,
                    adapter.AirPurifyingRespirator,
                    adapter.SingalPerson,
                    adapter.CommunicationDevice  ,
                    adapter.ReflectiveStrips  ,
                    adapter.Other3Text!=null
                };

                var noValueIsChecked = values.TrueForAll(value => value == false);
                if (noValueIsChecked)
                {
                    adapter.ActionForNoSafetyRequirementChosen();
                    SetHasError();
                }
             }
        }

        protected virtual void ValidateHasHazardsAndOrRequirementsIfSectionIsEnabledPartD()
        {
            if (!adapter.PartDWorkSectionNotApplicableToJob && adapter.HazardsAndOrRequirements.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForNoHazardsAndOrRequirements();
                SetHasError();
            }
        }

        protected virtual void ValidateOtherSafetyRequirementsAreFilledInIfTheyAreChecked()
        {
            // if (!adapter.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob)
            {
                if (!adapter.PartCWorkSectionNotApplicableToJob && adapter.Other1Selected && adapter.Other1Text.IsNullOrEmptyOrWhitespace())
                {
                    adapter.ActionForOther1SelectedWithNoValue();
                    SetHasError();
                }

                if (!adapter.PartCWorkSectionNotApplicableToJob && adapter.Other2Selected && adapter.Other2Text.IsNullOrEmptyOrWhitespace())
                {
                    adapter.ActionForOther2SelectedWithNoValue();
                    SetHasError();
                }

                if (!adapter.PartCWorkSectionNotApplicableToJob && adapter.Other3Selected && adapter.Other3Text.IsNullOrEmptyOrWhitespace())
                {
                    adapter.ActionForOther3SelectedWithNoValue();
                    SetHasError();
                }

                if (!adapter.PartEWorkSectionNotApplicableToJob && adapter.OthersPartE && adapter.OthersPartEValue.IsNullOrEmptyOrWhitespace())
                {
                    adapter.ActionForOtherPartESelectedWithNoValue();
                    SetHasError();
                }
            }
        }

       protected virtual void ValidateTypeOfWorkFieldsHaveValuesIfTheyAreChecked()
        {
            if (adapter.ConfinedSpace && adapter.ConfinedSpaceClass.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForNoConfinedSpaceClass(
                    ChooseMessageBasedOnGroup(StringResources.PermitRequestEdmonton_ConfinedSpaceLevelRequired,
                        StringResources.PermitRequestEdmonton_ConfinedSpaceLevelRequired_Turnaround));
                SetHasWarning();
            }

            //if (adapter.ConfinedSpace && adapter.ConfinedSpaceCardNumber.IsNullOrEmptyOrWhitespace())
            //{
            //    if (adapter.ConfinedSpaceClass != WorkPermitEdmonton.ConfinedSpaceLevel3)
            //    {
            //        adapter.ActionForNoConfinedSpaceCardNumber(
            //            ChooseMessageBasedOnGroup(
            //                StringResources.PermitRequestEdmonton_ConfinedSpaceCardNumberRequired,
            //                StringResources.PermitRequestEdmonton_ConfinedSpaceCardNumberRequired_Turnaround));
            //        SetHasWarning();
            //    }
            //}

            //if (adapter.RescuePlan && adapter.RescuePlanFormNumber.IsNullOrEmptyOrWhitespace())
            //{
            //    adapter.ActionForNoRescuePlanFormNumber(
            //        ChooseMessageBasedOnGroup(StringResources.PermitRequestEdmonton_RescuePlanFormNumberRequired,
            //            StringResources.PermitRequestEdmonton_RescuePlanFormNumberRequired_Turnaround));
            //    SetHasWarning();
            //}

            //if (adapter.SpecialWork && adapter.SpecialWorkType == null)
            //{
            //    adapter.ActionForNoSpecialWorkType();
            //    SetHasWarning();
            //}
            //mangesh for SpecialWork
            //if (adapter.SpecialWork)
            //{
            //    if (string.IsNullOrEmpty(adapter.SpecialWorkName) || string.IsNullOrWhiteSpace(adapter.SpecialWorkName))
            //    {
            //        adapter.ActionForNoSpecialWorkType();
            //        SetHasWarning();
            //    }
            //}
            ////mangesh for RoadAccessOnPermit
            //if (adapter.RoadAccessOnPermit && adapter.RoadAccessOnPermitType.IsNullOrEmptyOrWhitespace())
            //{
            //    adapter.ActionForNoRoadAccessOnPermitType();
            //    SetHasWarning();
            //}
        }

        protected virtual void ValidateFormInformation()
        {
            //var invalidFormValueMessage =
            //    ChooseMessageBasedOnGroup(StringResources.PermitRequestEdmonton_FormFieldMustBeApprovedOrNotApplicable,
            //        StringResources.PermitRequestEdmonton_FormFieldMustBeApprovedOrNotApplicable_Turnaround);
            /*
            if (WorkPermitSafetyFormState.Required.Equals(adapter.GN11))
            {
                adapter.ActionForInvalidGN11Value(invalidFormValueMessage);
                SetHasWarning();
            }

            if (WorkPermitSafetyFormState.Required.Equals(adapter.GN27))
            {
                adapter.ActionForInvalidGN27Value(invalidFormValueMessage);
                SetHasWarning();
            }

            if (adapter.GN59 && (adapter.FormGN59 == null || !adapter.FormGN59.IsApproved()))
            {
                adapter.ActionForNoApprovedGN59Form(
                    ChooseMessageBasedOnGroup(StringResources.PermitRequestEdmonton_ApprovedGN59Required,
                        StringResources.PermitRequestEdmonton_ApprovedGN59Required_Turnaround));
                SetHasWarning();
            }

            if (adapter.GN7 && (adapter.FormGN7 == null || !adapter.FormGN7.IsApproved()))
            {
                adapter.ActionForNoApprovedGN7Form(
                    ChooseMessageBasedOnGroup(StringResources.PermitRequestEdmonton_ApprovedGN7Required,
                        StringResources.PermitRequestEdmonton_ApprovedGN7Required_Turnaround));
                SetHasWarning();
            }

            if (adapter.GN24 && (adapter.FormGN24 == null || !adapter.FormGN24.IsApproved()))
            {
                adapter.ActionForNoApprovedGN24Form(
                    ChooseMessageBasedOnGroup(StringResources.PermitRequestEdmonton_ApprovedGN24Required,
                        StringResources.PermitRequestEdmonton_ApprovedGN24Required_Turnaround));
                SetHasWarning();
            }

            if (adapter.GN6 && (adapter.FormGN6 == null || !adapter.FormGN6.IsApproved()))
            {
                adapter.ActionForNoApprovedGN6Form(
                    ChooseMessageBasedOnGroup(StringResources.PermitRequestEdmonton_ApprovedGN6Required,
                        StringResources.PermitRequestEdmonton_ApprovedGN6Required_Turnaround));
                SetHasWarning();
            }

            if (adapter.GN75A && (adapter.FormGN75A == null || !adapter.FormGN75A.IsApproved()))
            {
                adapter.ActionForNoApprovedGN75AForm(
                    ChooseMessageBasedOnGroup(StringResources.PermitRequestEdmonton_ApprovedGN75ARequired,
                        StringResources.PermitRequestEdmonton_ApprovedGN75ARequired_Turnaround));
                SetHasWarning();
            }

            if (adapter.GN1 && (adapter.FormGN1 == null || !adapter.FormGN1.IsApproved()))
            {
                adapter.ActionForNoApprovedGN1Form(
                    ChooseMessageBasedOnGroup(StringResources.PermitRequestEdmonton_ApprovedGN1Required,
                        StringResources.PermitRequestEdmonton_ApprovedGN1Required_Turnaround));
                SetHasWarning();
            }

            //Start Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016
            if ((adapter.GN1 && (adapter.FormGN1 == null || adapter.FormGN1.TradeChecklists.Count > 0)) &&
                   (adapter.ConfinedSpaceCardNumber != null &&
                   !adapter.FormGN1.TradeChecklists.Exists(x => x.TradeChecklistInformationDisplayText == adapter.ConfinedSpaceCardNumber)))
            {
                adapter.ActionForValidTradeCheckGN1Form(StringResources.WorkPermitEdmonton_GN1NeedsValidTradeCheckList);
                SetHasWarning();
            }
            */
            //End Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016
           
        }

        private string ChooseMessageBasedOnGroup(string nonTurnaroundMessage, string turnaroundMessage)
        {
            if (adapter.Group != null && (adapter.Group.IsTurnaround))
            {
                return turnaroundMessage;
            }
            return nonTurnaroundMessage;
        }
    }
}