using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface ILabAlertDefinitionService
    {
        [OperationContract]
        LabAlertDefinition QueryById(long id);

        [OperationContract]
        LabAlertDefinition QueryByScheduleId(long scheduleId);

        [OperationContract]
        List<LabAlertDefinitionDTO> QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(IFlocSet flocSet,
            Range<Date> dateRange);

        [OperationContract]
        SchedulingList<LabAlertDefinition, OLTException> QueryAllAvailableForScheduling();

        [OperationContract]
        List<NotifiedEvent> Insert(LabAlertDefinition restrictionDefinition);

        [OperationContract]
        List<NotifiedEvent> Update(LabAlertDefinition restrictionDefinition);

        [OperationContract]
        List<NotifiedEvent> Remove(LabAlertDefinition restrictionDefinition);

        [OperationContract]
        void UpdateStatusForValidTag(TagInfo tag, Site site);

        [OperationContract]
        void UpdateStatusForInvalidTag(TagInfo tag, Site site);

        [OperationContract]
        Error IsValidName(string name, Site site, LabAlertDefinition restrictionDefinition);
    }
}