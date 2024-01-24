using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    public class FlattenedCustomFieldEntryHistory : DomainObject
    {
        private const string Delimiter = "/-^%/";

        public FlattenedCustomFieldEntryHistory(long? historyId, List<CustomFieldEntryHistory> entryHistories)
            : this(historyId, "")
        {
            var entryHistoryStrings = new List<string>();

            foreach (var customFieldEntryHistory in entryHistories)
            {
                entryHistoryStrings.Add(String.Format("^ID:{0}^CUSTOMFIELDNAME:{1}^FIELDENTRY:{2}",
                    customFieldEntryHistory.Id, customFieldEntryHistory.CustomFieldName,
                    customFieldEntryHistory.FieldEntry));
            }

            FlattenedEntryHistories = entryHistoryStrings.Join(Delimiter);
        }

        public FlattenedCustomFieldEntryHistory(long? historyId, string flattenedEntryHistories)
        {
            FlattenedEntryHistories = flattenedEntryHistories;
            HistoryId = historyId;
        }

        public long? HistoryId { get; private set; }

        public string FlattenedEntryHistories { get; private set; }

        public List<CustomFieldEntryHistory> EntryHistories
        {
            get
            {
                var customFieldEntryHistories = new List<CustomFieldEntryHistory>();

                var customFieldHistoryEntryStrings = FlattenedEntryHistories.Split(new[] {Delimiter},
                    StringSplitOptions.None);

                foreach (var customFieldHistoryEntryString in customFieldHistoryEntryStrings)
                {
                    var match = Regex.Match(customFieldHistoryEntryString,
                        @"\^ID:(.*)\^CUSTOMFIELDNAME:(.*)\^FIELDENTRY:(.*)");

                    var idGroup = match.Groups[1];
                    var idValue = idGroup.Value;

                    var customFieldNameGroup = match.Groups[2];
                    var customFieldName = customFieldNameGroup.Value;

                    var fieldEntryGroup = match.Groups[3];
                    var fieldEntry = fieldEntryGroup.Value.EmptyToNull();

                    long? id = null;
                    if (!idValue.IsNullOrEmptyOrWhitespace())
                    {
                        id = long.Parse(idValue);
                    }

                    var customFieldEntryHistory = new CustomFieldEntryHistory(HistoryId, id, customFieldName, fieldEntry);
                    customFieldEntryHistories.Add(customFieldEntryHistory);
                }


                return customFieldEntryHistories;
            }
        }
    }
}