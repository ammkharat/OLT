using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ISummaryLogCustomFieldEntryDao : IDao
    {
        CustomFieldEntry Insert(CustomFieldEntry fieldEntry, long summaryLogId);
        List<CustomFieldEntry> QueryBySummaryLogId(long summaryLogId);
        void Update(CustomFieldEntry entry);
        List<NumericCustomFieldEntryDTO> QueryNumericCustomFieldEntriesForLogs(long customFieldId, long workAssignmentId, Site site, DateRange dateRange);
        List<NonnumericCustomFieldEntryDTO> QueryNonnumericCustomFieldEntriesForLogs(long customFieldId, long workAssignmentId, Site site, DateRange dateRange);
        void DeleteThoseNoLongerAssociatedToEntity(long entityId, List<CustomFieldEntry> customFieldEntries);
    }
}
