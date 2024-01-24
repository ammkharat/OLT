using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IActionItemDefinitionDao : IDao
    {
        //[CachedQueryById] // Commented by Vibhor //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
        ActionItemDefinition QueryById(long id);
        
        int GetCountOfSAPSourced(string name, long siteId);
        
        [CachedRemoveAttribute(false, false)]
        void Remove(ActionItemDefinition actionItemDefinition);
        
        [CachedInsertOrUpdate(false, false)]
        void Update(ActionItemDefinition actionItemDefinition);

        [CachedInsertOrUpdate(false, false)]
        void Insert(ActionItemDefinition actionItemDefinition);

        [CachedInsertOrUpdate(false, false)]
        void InsertWithCustomFieldGroupID(ActionItemDefinition actionItemDefinition,CustomFieldGroup customFieldGroupId);   //ayman custom fields DMND0010030

        List<ActionItemDefinition> QueryAllAvailableForScheduling();

        List<string> QueryActionItemDefSendEmailToByActionItemDefinitionId(long id);            //ayman action item email

        object QueryActionItemDefAutoPopulateByActionItemDefinitionId(long actionItemDefID);     //ayman action item reading
        object QueryActionItemDefReadingByActionItemDefinitionId(long actionItemDefID);     //ayman action item reading
        List<ActionItemDefinition> QueryReadingDefinitionsBySite(long Siteid,Date startdate,Date enddate);              //ayman action item reading


        // #3003 (caching) - this could be cached if we had a better way of saying that the ActionItemDefinition should be cleared when cooresponding ActionItemDefinition is updated or removed. This might be a manual caching scenario.
        ActionItemDefinition QueryBySapOperationId(long sapOperationId);

        List<ActionItemDefinition> QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations(WorkAssignment assignment, IFlocSet flocSet, DateTime todaysDate, List<long> readableVisibilityGroupIds);
        List<ActionItemDefinition> QueryActiveDtosByParentFunctionalLocations(IFlocSet flocSet, DateTime todaysDate, List<long> readableVisibilityGroupIds);

        int QueryCountByGN75BId(long gn75AId);

        List<ActionItemDefinition> QueryFutureActionItemDefinitions(RootFlocSet rootFlocSet, DateTime beginDateTime, DateTime endDateTime, List<long> readableVisibilityGroupIds);
    }
}
