using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ITargetDefinitionDao : IDao
    {
        SchedulingList<TargetDefinition, OLTException> QueryAllAvailableForScheduling(List<long> siteIds);
        [CachedQueryById]
        TargetDefinition QueryById(long id);
        
        TargetDefinition QueryByScheduleId(long? scheduleId);
        
        [CachedInsertOrUpdate(false, false)]
        TargetDefinition Insert(TargetDefinition target);
        
        [CachedRemove(false, false)]
        void Remove(TargetDefinition target);
        
        [CachedInsertOrUpdate(false, false)]
        void Update(TargetDefinition target);
        
        [CachedInsertOrUpdate(false, false)]
        void UpdateStatus(TargetDefinition targetDefinition);
        
        [CachedInsertOrUpdate(false, false)]
        void WriteTagValues(TargetDefinition targetDefinition);
        
        [CachedInsertOrUpdate(false, false)]
        void UpdateAfterUnableToAccessTags(TargetDefinition definition);

        int GetCount(string name, long siteId);
        
        List<TargetDefinition> QueryByName(long siteId, string name);
        IEnumerable<long> QueryAssociatedTargets(long parentTargetId);
        List<TargetDefinition> QueryActiveByName(long siteId, string name);
        int QueryLinkedActionItemDefinitionCount(long? id);
        List<string> QueryParentTargets(long childTargetId);
        List<TargetDefinition> QueryTargetDefinitionAlreadyUsingTag(long? targetDefinitionId, TagDirection direction, long tagId);
        
        List<TargetDefinition> QueryTargetDefinitionsWithInvalidTag(TagInfo tag);
        List<TargetDefinition> QueryTargetDefinitionsWithValidTag(TagInfo tag);
        List<TargetDefinition> QueryByScheduleIds(IList<long> schedules);
    }
}