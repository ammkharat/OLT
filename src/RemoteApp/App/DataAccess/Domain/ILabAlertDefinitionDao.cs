using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ILabAlertDefinitionDao : IDao
    {
        [CachedQueryById]
        LabAlertDefinition QueryById(long id);
        LabAlertDefinition QueryByScheduleId(long scheduleId);        
        List<LabAlertDefinition> QueryByName(long siteId, string name);
        List<LabAlertDefinition> QueryLabAlertDefinitionsWithInvalidTag(TagInfo tag);
        List<LabAlertDefinition> QueryLabAlertDefinitionsWithValidTag(TagInfo tag);
        SchedulingList<LabAlertDefinition, OLTException> QueryAllAvailableForScheduling();

        [CachedInsertOrUpdate(false, false)]
        LabAlertDefinition Insert(LabAlertDefinition restrictionDefinition);
        [CachedInsertOrUpdate(false, false)]
        void Update(LabAlertDefinition restrictionDefinition);
        [CachedRemove(false, false)]
        void Remove(LabAlertDefinition restrictionDefinition);
    }
}