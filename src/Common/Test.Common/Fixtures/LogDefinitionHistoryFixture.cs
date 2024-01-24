using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public static class LogDefinitionHistoryFixture
    {
        public static LogDefinitionHistory Create(LogDefinition definition, DateTime lastModifiedDateTime)
        {
            return
                new LogDefinitionHistory(definition.IdValue, lastModifiedDateTime, definition.LastModifiedBy,
                                         "Schedule",
                                         definition.FunctionalLocationsAsCommaSeparatedString, "http://suncor/livelink/word.doc",
                                         true, false, true, false, true, false,
                                         false,
                                         "Comments",
                                         definition.Active, 
                                         new List<CustomFieldEntryHistory> { new CustomFieldEntryHistory(100, 200, "Name", "Entry") });
        }

        public static LogDefinitionHistory Create(LogDefinition definition, DateTime lastModifiedDateTime, string documentLinks)
        {
            return
                new LogDefinitionHistory(definition.IdValue, lastModifiedDateTime, definition.LastModifiedBy,
                                         "Schedule",
                                         definition.FunctionalLocationsAsCommaSeparatedString, documentLinks,
                                         true, false, true, false, true, false,
                                         false,
                                         "Comments",
                                         true,
                                         new List<CustomFieldEntryHistory> { new CustomFieldEntryHistory(100, 200, "Name", "Entry") });
        }
    }
}