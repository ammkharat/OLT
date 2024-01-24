using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation.ValidationError;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public abstract class AbstractNewWorkPermitValidator
    {
        protected readonly WorkPermit workPermit;

        protected AbstractNewWorkPermitValidator(WorkPermit workPermit)
        {
            this.workPermit = workPermit;
        }

        protected abstract List<IValidation<WorkPermit>> BuildValidationRules();

        public List<IValidationIssue> Validate()
        {
            List<IValidation<WorkPermit>> validationRules = BuildValidationRules();

            var errors = new List<IValidationIssue>();

            validationRules.FindAll(rule => rule.Evaluate(workPermit))
                .ForEach(rule => errors.Add(rule.ValidationIssue));

            return errors;
        }

        protected static RulesBasedValidation<WorkPermit> BuildRequiredForSaveValidator(string message, string viewFieldToBindErrorOnto, params Predicate<WorkPermit>[] predicates)
        {
            var rules = new List<Predicate<WorkPermit>>(predicates).ConvertAll(p => new Rule<WorkPermit>(p));
            return
                new AllTrueValidator<WorkPermit>(
                    new FieldValidationError(message, ProblemLevel.RequiredForSave, viewFieldToBindErrorOnto),
                    rules.ToArray());
        }

        protected static RulesBasedValidation<WorkPermit> BuildRequiredForApprovalValidator(string message, string viewFieldToBindErrorOnto, params Predicate<WorkPermit>[] predicates)
        {
            var rules = new List<Predicate<WorkPermit>>(predicates).ConvertAll(p => new Rule<WorkPermit>(p));
            return
                new AllTrueValidator<WorkPermit>(
                    new FieldValidationError(message, ProblemLevel.RequiredForApproval, viewFieldToBindErrorOnto),
                    rules.ToArray());
        }

        protected static RulesBasedValidation<WorkPermit> BuildRequiredForSaveValidator(string viewFieldToBindErrorOnto, params Predicate<WorkPermit>[] predicates)
        {
            return BuildRequiredForSaveValidator(StringResources.FieldEmptyError, viewFieldToBindErrorOnto, predicates);
        }

        protected static RulesBasedValidation<WorkPermit> BuildRequiredForApprovalValidator(WorkPermitSection section, params Predicate<WorkPermit>[] predicates)
        {
            var rules = new List<Predicate<WorkPermit>>(predicates).ConvertAll(p => new Rule<WorkPermit>(p));
            return
                new AllTrueValidator<WorkPermit>(
                    new SectionValidationError(section, ProblemLevel.RequiredForApproval),
                    rules.ToArray());
        }

        protected static RulesBasedValidation<WorkPermit> BuildWarningValidator(string message, string viewFieldToBindErrorOnto, params Predicate<WorkPermit>[] predicates)
        {
            List<Rule<WorkPermit>> rules = new List<Predicate<WorkPermit>>(predicates).ConvertAll(p => new Rule<WorkPermit>(p));
            return new AllTrueValidator<WorkPermit>(new FieldValidationError(message, ProblemLevel.Warning, viewFieldToBindErrorOnto), rules.ToArray());
        }

        protected static RulesBasedValidation<WorkPermit> BuildWarningValidator(WorkPermitSection section, params Predicate<WorkPermit>[] predicates)
        {
            var rules = new List<Predicate<WorkPermit>>(predicates).ConvertAll(p => new Rule<WorkPermit>(p));
            return
                new AllTrueValidator<WorkPermit>(
                    new SectionValidationError(section, ProblemLevel.Warning),
                    rules.ToArray());
        }

    }
}