using Com.Suncor.Olt.Client.Presenters.Validation.ValidationError;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public class AnyTrueValidator<T> : RulesBasedValidation<T>
    {
        public AnyTrueValidator(IValidationIssue validationIssue, params IRule<T>[] rules) : base(validationIssue, rules)
        {
        }

        public override bool Evaluate(T objectToEvaludate)
        {
            return rules.Exists(rule => rule.Check(objectToEvaludate));
        }
    }
}