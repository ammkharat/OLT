using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class CustomFieldPresenterMaker
    {
        public static IRunnablePresenter Create(INumericAndNonnumericCustomFieldEntryListService service, CustomField customField, WorkAssignment workAssignment)
        {
            return Create(service, customField, workAssignment.IdValue, workAssignment.Name);
        }

        private static IRunnablePresenter Create(INumericAndNonnumericCustomFieldEntryListService service, CustomField customField, long workAssignmentId, string workAssignmentName)
        {
            if (customField.Type == CustomFieldType.NumericValue)
            {
                return new CustomFieldTrendPresenter(service, customField, workAssignmentId, workAssignmentName);
            }
            else
            {
                return new CustomFieldTablePresenter(customField, workAssignmentId, workAssignmentName, service);
            }

        }

        public static IRunnablePresenter Create(INumericAndNonnumericCustomFieldEntryListService service, CustomFieldEntry customFieldEntry, WorkAssignment workAssignment)
        {
            return Create(service, customFieldEntry, workAssignment.IdValue, workAssignment.Name);
        }

        public static IRunnablePresenter Create(INumericAndNonnumericCustomFieldEntryListService service, CustomFieldEntry customFieldEntry, long workAssignmentId, string workAssignmentName)
        {
            if (customFieldEntry.Type == CustomFieldType.NumericValue)
            {
                return new CustomFieldTrendPresenter(service, customFieldEntry, workAssignmentId, workAssignmentName);
            }
            else
            {
                return new CustomFieldTablePresenter(customFieldEntry, workAssignmentId, workAssignmentName, service);
            }
        }
    }
}
