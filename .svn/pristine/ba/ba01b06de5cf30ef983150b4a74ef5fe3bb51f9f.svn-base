using System;
using System.Collections.Generic;
using Castle.Core.Internal;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Validation
{
    public class ShiftHandoverQuestionnaireValidator
    {
        private readonly IShiftHandoverQuestionnaireValidationAction action;
        private bool hasErrors;

        public ShiftHandoverQuestionnaireValidator(IShiftHandoverQuestionnaireValidationAction action)
        {
            this.action = action;
        }

        public bool HasErrors
        {
            get { return hasErrors; }
        }

        protected void ClearErrors()
        {
            action.ClearShiftQuestionnaireErrorProviders();
            hasErrors = false;
        }

        public void ValidateAndSetErrors(List<ShiftHandoverAnswer> answers)
        {
            ClearErrors();

            if (IsFunctionLocationBlank())
            {
                action.SetFunctionLocationBlankError();
                hasErrors = true;
            }

            bool hasAnswerErrors = ValidateAnswers(answers);
          
            hasErrors = hasErrors || hasAnswerErrors;
        }

        /*amit shukla Flexi shift handover RITM0185797 */

        public bool ValidateFlexiShiftHandoverDates(DateTime StartDate, DateTime EndDate )
        {
            if ((EndDate.ToDate() - StartDate.ToDate()).TotalDays > 15)
            {
                hasErrors = true;
                action.SetFlexibleShiftDateError(String.Format(StringResources.MaximumXDaysAllowed, "15"));
            }
            else if (StartDate.ToDate() > EndDate.ToDate())
            {
                action.SetFlexibleShiftDateError(StringResources.EndDateBeforeStartDate);
                hasErrors = true;
            }
            else if (StartDate.ToDate() > Clock.Now.ToDate())
            {
                action.SetFlexibleShiftDateError(StringResources.StartDateTimeCannotBeInTheFuture);
                hasErrors = true;
            }
            else if (EndDate.ToDate() < Clock.Now.ToDate())
            {
                action.SetFlexibleShiftDateError(StringResources.Enddatecannotbeapastdate);
                hasErrors = true;
            }
            return hasErrors;
        }

        /**/

        private bool ValidateAnswers(IEnumerable<ShiftHandoverAnswer> answers)
        {
            bool hasAnswerErrors = false;
            foreach (ShiftHandoverAnswer answer in answers)
            {
                if (!action.HasAnsweredYesNo(answer))
                {
                    action.SetYesNoError(answer);
                    hasAnswerErrors = true;
                }
                if (action.YesNoAnswer(answer).HasTrueValue() && action.GetAnswerComments(answer).IsNullOrEmptyOrWhitespace() && action.GetAnswerCommentEnabled(answer))//Added by ppanigrahi
                {
                    
                    action.SetAnswerCommentsError(answer);
                    hasAnswerErrors = true;
                }
                //Added by ppanigrahi
                if (action.YesNoAnswer(answer).HasFalseValue() && action.GetAnswerComments(answer).IsNullOrEmptyOrWhitespace() && action.GetAnswerCommentEnabled(answer))
                {

                    action.SetAnswerCommentsError(answer);
                    hasAnswerErrors = true;
                }
                
               

            }
            return hasAnswerErrors;
        }

      

        private bool IsFunctionLocationBlank()
        {
            List<FunctionalLocation> flocs = action.FunctionalLocations;
            return (flocs == null || flocs.Count == 0);
        }

    }
}
