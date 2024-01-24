using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IRestrictionDefinitionDao : IDao
    {
        [CachedQueryById]
        RestrictionDefinition QueryById(long id);
        
        List<RestrictionDefinition> QueryByName(long siteId, string name);
        List<RestrictionDefinition> QueryRestrictionDefinitionsWithInvalidTag(TagInfo tag);
        List<RestrictionDefinition> QueryRestrictionDefinitionsWithValidTag(TagInfo tag);
        SchedulingList<RestrictionDefinition, OLTException> QueryAllAvailableForScheduling();

        [CachedInsertOrUpdate(false, false)]
        RestrictionDefinition Insert(RestrictionDefinition restrictionDefinition);
        [CachedInsertOrUpdate(false, false)]
        void Update(RestrictionDefinition restrictionDefinition);
        [CachedInsertOrUpdate(false, false)]
        void UpdateLastInvokedDateTime(RestrictionDefinition definition);
        [CachedRemove(false, false)]
        void Remove(RestrictionDefinition restrictionDefinition);
    }
}