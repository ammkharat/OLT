using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation.ValidationError;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public abstract class RulesBasedValidation<T> : IValidation<T>
    {
        protected List<IRule<T>> rules;
        protected IValidationIssue validationIssue;

        protected RulesBasedValidation(IValidationIssue validationIssue, params IRule<T>[] rules)
        {
            this.validationIssue = validationIssue;
            this.rules = new List<IRule<T>>(rules);
        }

        public virtual IValidationIssue ValidationIssue
        {
            get { return validationIssue; }
        }

        /// <summary>
        /// Evaluates rule(s) against an object. If Evaluate return true, then there is an error.
        /// </summary>
        /// <param name="objectToEvaluate"></param>
        /// <returns>true if there is a validation error on objectToValidate, otherwise false.</returns>
        public abstract bool Evaluate(T objectToEvaluate);
    }
}