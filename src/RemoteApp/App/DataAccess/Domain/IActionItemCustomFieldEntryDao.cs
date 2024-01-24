using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IActionItemCustomFieldEntryDao : IDao
    {
        CustomFieldEntry Insert(CustomFieldEntry fieldEntry, long actionitemId);
        CustomFieldEntry InsertTracker(CustomFieldEntry fieldEntry, long actionitemId, long batchnumber); //ayman action item reading
        long GetTrackerLastBatchNumber();       //ayman action item reading
        List<CustomFieldEntry> QueryByActionItemId(long actionitemId);
        void Update(CustomFieldEntry entry);
//        List<NumericCustomFieldEntryDTO> QueryNumericCustomFieldEntriesForActionItems(long customFieldId, long workAssignmentId, Site site, DateRange dateRange);
//        List<NonnumericCustomFieldEntryDTO> QueryNonnumericCustomFieldEntriesForActionItems(long customFieldId, long workAssignmentId, Site site, DateRange dateRange);
        void DeleteThoseNoLongerAssociatedToEntity(long entityId, List<CustomFieldEntry> customFieldEntries);
    }
}
