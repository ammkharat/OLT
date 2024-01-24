using System;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.Validation.Montreal
{
    public class PermitRequestMontrealValidator
    {
        private readonly PermitRequestMontrealBaseValidationAdapter adapter;
        private bool hasErrors;

        private bool validateHasRun;

        public PermitRequestMontrealValidator(PermitRequestMontrealBaseValidationAdapter adapter)
        {
            this.adapter = adapter;
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
            hasErrors = false;
            adapter.ClearErrors();
        }

        protected void SetHasError()
        {
            hasErrors = true;
        }

        public void Validate(Date todayInMontreal)
        {
            validateHasRun = true;

            ClearErrors();

            ValidateWorkPermitType();
            ValidateFunctionalLocations();
            ValidateStartAndEndDates(todayInMontreal);
            ValidateTrade();
            ValidateDescription();
            ValidateRequestedByGroup();
        }

        private void ValidateStartAndEndDates(Date todayInMontreal)
        {
            if (adapter.StartDate > adapter.EndDate)
            {
                adapter.ActionForStartDateMustBeBeforeEndDate();
                SetHasError();
            }

            if (adapter.EndDate < todayInMontreal)
            {
                adapter.ActionForEndDateMustBeOnOrAfterToday();
                SetHasError();
            }
        }

        private void ValidateRequestedByGroup()
        {
            if (adapter.RequestedByGroup == null || adapter.RequestedByGroup == WorkPermitMontrealGroup.EMPTY)
            {
                adapter.ActionForNoRequestedByGroupSelected();
                SetHasError();
            }
        }

        private void ValidateDescription()
        {
            if (adapter.Description.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForEmptyDescription();
                SetHasError();
            }
        }

        private void ValidateTrade()
        {
            if (adapter.Trade.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForNoTradeSelected();
                SetHasError();
            }
        }

        private void ValidateFunctionalLocations()
        {
            if (adapter.FunctionalLocations == null || adapter.FunctionalLocations.IsEmpty())
            {
                adapter.ActionForNoFunctionalLocationsSelected();
                SetHasError();
            }
        }

        private void ValidateWorkPermitType()
        {
            if (adapter.WorkPermitType == null || adapter.WorkPermitType == WorkPermitMontrealType.NULL)
            {
                adapter.ActionForNoWorkPermitTypeSelected();
                SetHasError();
            }
        }

        private bool IsComplete()
        {
            return !HasErrors;
        }
    }
}