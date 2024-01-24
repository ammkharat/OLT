using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain
{
    public interface IHasCustomFieldEntries
    {
        long IdValue { get; }
        List<CustomFieldEntry> CustomFieldEntries { get; }
        List<CustomField> CustomFields { get; }
        DateTime LogDateTime { get; }
    }

    public static class IHasCustomFieldEntriesExtensions
    {
        public static bool ContainsCustomFieldEntries(this IHasCustomFieldEntries itemToInspect)
        {
            var customFieldEntries = itemToInspect.CustomFieldEntries;
            return CustomFieldEntry.HasAtLeastOneNonEmptyEntry(customFieldEntries);
        }
    }
}