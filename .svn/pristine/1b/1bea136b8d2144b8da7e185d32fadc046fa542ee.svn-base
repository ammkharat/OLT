using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class CustomFieldPresenterHelper
    {
        public static IEnumerable<CustomFieldEntry> GetCustomFieldEntriesFromView(IHasCustomFieldEntries editObject, ICustomFieldValidationAction view, IEnumerable<CustomField> customFields)
        {
            List<CustomFieldEntry> editedCustomFieldEntries = new List<CustomFieldEntry>();

            foreach (CustomField customField in customFields)
            {
                string customFieldEntryText = view.GetCustomFieldEntryText(customField.IdValue);

                if (!customFieldEntryText.IsNullOrEmptyOrWhitespace())
                {
                    CustomFieldEntry customFieldEntry = editObject.CustomFieldEntries.Find(entry => entry.CustomFieldId == customField.IdValue);

                    if (customFieldEntry != null)
                    {
                        customFieldEntry.SetValue(customFieldEntryText);
                        editedCustomFieldEntries.Add(customFieldEntry);
                    }
                    else
                    {
                        CustomFieldEntry brandNewEntry = new CustomFieldEntry(customField);
                        brandNewEntry.SetValue(customFieldEntryText);
                        editedCustomFieldEntries.Add(brandNewEntry);
                    }
                }
            }

            return editedCustomFieldEntries;
        }
    }
}