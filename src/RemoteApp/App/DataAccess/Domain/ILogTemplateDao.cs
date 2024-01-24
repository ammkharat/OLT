using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    // #3003 - in order to cache effectively, the QuerybyWorkAssignmentId needs to be cached.
    public interface ILogTemplateDao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        LogTemplate Insert(LogTemplate logTemplate);
        [CachedQueryById]
        LogTemplate QueryById(long id);
        // Not caching because it's only used in the admin screens.
        List<LogTemplate> QueryBySiteId(long siteId);
        [CachedInsertOrUpdate(false, false)]
        void Update(LogTemplate logTemplate);
        [CachedRemove(false, false)]
        void Delete(LogTemplate logTemplate);
        List<LogTemplate> QueryLogTemplatesSetAsAutoInsertForTheseAssignments(List<WorkAssignment> workAssignments);
    }
}