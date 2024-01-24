using System;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class CustomFieldEntryHistory : DomainObject
    {
        public CustomFieldEntryHistory(long? historyId, long? id, string customFieldName, string fieldEntry)
        {
            HistoryId = historyId;
            this.id = id;
            CustomFieldName = customFieldName;
            FieldEntry = fieldEntry;
        }

        public string FieldEntry { get; private set; }

        [IgnoreDifference]
        public long? HistoryId { get; set; }

        [DifferenceLabel]
        public string CustomFieldName { get; private set; }
    }
}