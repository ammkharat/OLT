using Com.Suncor.Olt.Client.Presenters.Validation.ValidationError;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public class AllTrueValidator<T> : RulesBasedValidation<T>
    {
        public AllTrueValidator(IValidationIssue validationIssue, params IRule<T>[] rules) : base(validationIssue, rules)
        {
        }

        public override bool Evaluate(T objectToEvaluate)
        {
            return rules.TrueForAll(rule => rule.Check(objectToEvaluate));
        }

    }

}