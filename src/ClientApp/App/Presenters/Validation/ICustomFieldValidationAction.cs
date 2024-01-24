using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public interface ICustomFieldValidationAction
    {
        void SetCustomFieldMustContainANumberError(CustomFieldEntry entry);
        void SetCustomFieldMustContainANumberWithCorrectNumberOfDigitsError(CustomFieldEntry entry);
        void ClearErrorProviders();

        string GetCustomFieldEntryText(CustomFieldEntry entry);
        string GetCustomFieldEntryText(long customFieldId);
    }
}
