using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public class LogTemplateValidator
    {
        private readonly ILogTemplateValidationAction action;
        private readonly List<LogTemplate> logTemplatesForSite;
        private bool hasErrors;

        public LogTemplateValidator(ILogTemplateValidationAction action, List<LogTemplate> logTemplatesForSite)
        {
            this.action = action;
            this.logTemplatesForSite = logTemplatesForSite;
            hasErrors = false;
        }

        public bool HasErrors
        {
            get { return hasErrors; }
        }

        public void ValidateAndSetErrors(LogTemplate logTemplate)
        {
            action.ClearAllErrors();

            ValidateHasAssociatedWorkAssignment(logTemplate);
            ValidateHasName(logTemplate);
            ValidateNameIsUnique(logTemplate);
        }        

        private void ValidateNameIsUnique(LogTemplate logTemplate)
        {
            List<LogTemplate> candidates = 
                logTemplatesForSite.FindAll(template => template.SharesWorkAssignmentWith(logTemplate));

            if (candidates.Exists(candidate => candidate.Name.ToLower() == logTemplate.Name.ToLower() && candidate.Id != logTemplate.Id))
            {
                action.SetErrorForDuplicateName();
                hasErrors = true;
            }
        }

        private void ValidateHasName(LogTemplate logTemplate)
        {
            if (logTemplate.Name == null || logTemplate.Name.Trim() == string.Empty)
            {
                action.SetErrorForNoNameProvided();
                hasErrors = true;
            }
        }

        private void ValidateHasAssociatedWorkAssignment(LogTemplate logTemplate)
        {
            if (logTemplate.WorkAssignments.Count == 0)
            {
                action.SetErrorForNoAssociatedWorkAssignments();
                hasErrors = true;
            }
        }
    }
}
