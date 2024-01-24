using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Validation
{
    public class LogValidator
    {
        private readonly ILogValidationAction action;
        private readonly UserContext userContext;
        private bool hasErrors;

        public LogValidator(ILogValidationAction action, UserContext userContext)
        {
            this.action = action;
            this.userContext = userContext;
        }

        public bool HasErrors
        {
            get { return hasErrors; }
        }

        protected void ClearErrors()
        {
            action.ClearLogValidationErrorProviders();
            hasErrors = false;
        }

        public void ValidateAndSetErrors(List<CustomFieldEntry> customFieldEntries)
        {
            ClearErrors();

            if (action.IsCommentEmpty)
            {
                action.SetCommentsBlankError();
                hasErrors = true;
            }

            if (IsFunctionLocationBlank())
            {
                action.SetFunctionLocationBlankError();
                hasErrors = true;
            }

            if (IsLogTimeInTheFuture())
            {
                action.SetLogTimeInTheFutureError();
                hasErrors = true;
            }
            // By Vibhor : RITM0272920            

            if (!IsLogTimeWithinShift() && !ClientSession.GetUserContext().UserRoleElements.Role.IsAdministratorRole)
            {
                action.SetLogDateTimeError();
                hasErrors = true;
            }
            //END
            if (CustomFieldsHaveErrors(customFieldEntries))
            {
                hasErrors = true;
            }
        }

        private bool CustomFieldsHaveErrors(List<CustomFieldEntry> customFieldEntries)
        {
            CustomFieldEntryValidator customFieldEntryValidator = new CustomFieldEntryValidator(action);
            customFieldEntryValidator.ValidateAndSetErrors(customFieldEntries);
            return customFieldEntryValidator.HasErrors;
        }

        private bool IsLogTimeInTheFuture()
        {
            return action.LogDateTime.CompareTo(Clock.Now) > 0;
        }

        private bool IsLogTimeWithinShift()
        {
            return userContext.UserShift.ShiftPattern.IsTimeInShiftIncludingPadding(action.ActualLoggedTime);
        }

        private bool IsFunctionLocationBlank()
        {
            return action.FunctionalLocations.IsEmpty();
        }

    }
}
