using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ICustomFieldsView
    {
        string GetCustomFieldEntryText(CustomFieldEntry entry);
        void SetCustomFieldEntryText(CustomFieldEntry entry, String text);
    }


    public static class CustomFieldsViewExtensions
    {
        public static List<CustomFieldEntry> CopyFromView(this ICustomFieldsView view, List<CustomField> customFields)
        {
            List<CustomFieldEntry> entries = customFields.ConvertAll(cf => new CustomFieldEntry(cf));
            entries.ForEach(entry => entry.SetValue(view.GetCustomFieldEntryText(entry)));
            entries.RemoveAll(entry => entry.FieldEntryForDisplay.IsNullOrEmptyOrWhitespace());

            return entries;
        }
    }

}