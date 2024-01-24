using Com.Suncor.Olt.Client.Presenters.Validation.ValidationError;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public interface IValidation<T>
    {
        bool Evaluate(T workPermit);
        IValidationIssue ValidationIssue { get; }
    }
}