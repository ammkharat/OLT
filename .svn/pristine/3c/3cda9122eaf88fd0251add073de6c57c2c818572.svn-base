using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IActionItemDao : IDao
    {
        ActionItem QueryById(long id);
        bool QueryReadingByAIDId(long actionItemDefinitoinId);            //ayman action item reading
        List<TrackerReport> QueryTrackersByAidId(long aidid, DateTime startDate, DateTime Enddate);  //ayman action item reading
        void Insert(ActionItem actionItem);
        void Update(ActionItem actionItem);

        // #3003 - Could have this Dao method get the list if items that are being updated, and call update on each Action Iteminstead. That was we can cache this.
        void UpdateAllResponseNotRequiredActionItemsWhenShiftEndHasPassed(ActionItemStatus newStatus, Site site,
                                                                          DateTime currentDateTimeAtSite,
                                                                          User user);
        
        List<ActionItem> QueryAllActionItemsNeedingAttention(List<FunctionalLocation> functionalLocations);
        
        void Remove(ActionItem actionItem);
        
        List<ActionItem> QueryCurrentActionItemsForActionItemDefinition(ActionItemDefinition actionItemDefinition, DateTime currentTimeAtSite);
        List<ActionItem> QueryUnrespondedToActionItemsByDefinitionId(long id);
    }
}