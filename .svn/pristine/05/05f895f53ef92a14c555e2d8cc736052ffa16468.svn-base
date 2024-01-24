using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IWorkAssignmentDao : IDao
    {
        [CachedQueryById]
        WorkAssignment QueryById(long id);

        [CachedQueryById]
        WorkAssignment QueryByIdWithoutCache(long id);

        [CachedInsertOrUpdate(true, false)]
        WorkAssignment Insert(WorkAssignment workAssignment);
        
        [CachedQueryBySiteId]   //ayman restriction
        List<WorkAssignment> QueryBySiteId(long siteId);

        List<WorkAssignment> TemplateCategoriesQueryBySiteId(long siteId);

        List<WorkAssignment> PermitRequestTemplateCategoriesQueryBySiteId(long siteId);
        

        
        
        List<WorkAssignment> QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant(IFlocSet flocSet);

        [CachedInsertOrUpdate(true, false)]
        void UpdateFunctionalLocations(WorkAssignment workAssignment);

        void UpdateFunctionalLocationsForWorkPermitAutoAssignment(AssignmentFlocConfiguration configuration);
        
        [CachedInsertOrUpdate(true, false)]
        void Update(WorkAssignment workAssignment);
        
        [CachedRemove(true, false)]
        void Remove(WorkAssignment workAssignment);
        
        void UpdateFunctionalLocationsForWorkPermits(AssignmentFlocConfiguration configuration);
        
        List<WorkAssignment> QueryByShiftHandoverEmailConfigurationId(long shiftHandoverEmailConfigurationId);

        List<WorkAssignment> QueryByDirectiveId(long directiveId);

        List<WorkAssignment> QueryByPriorityPageSectionConfigurationId(long directiveId);

        List<WorkAssignment> QueryByRestrictionLocation(long restrictionLocationId,long siteid);     //ayman restriction
        void UpdateFunctionalLocationsForRestrictions(AssignmentFlocConfiguration configuration);
    }
}