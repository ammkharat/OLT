using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface ILogDefinitionService : INumericAndNonnumericCustomFieldEntryListService
    {
        [OperationContract]
        LogDefinition QueryById(long id);

        [OperationContract]
        List<LogDefinition> QueryAllForScheduling();

        [OperationContract]
        List<LogDefinitionDTO> QueryDtoByFunctionalLocationsAndLogType(IFlocSet flocSet, LogType logType,
            List<long> readableVisibilityGroupIds);

        [OperationContract]
        List<LogDefinitionDTO> QueryDtoByUserRootFlocsAndLogType(IFlocSet flocSet, LogType logType,
            List<long> readableVisibilityGroupIds);

        [OperationContract]
        List<NotifiedEvent> Insert(LogDefinition logDefinition);

        [OperationContract]
        List<NotifiedEvent> Update(LogDefinition logDefinition);

        [OperationContract]
        List<NotifiedEvent> Cancel(LogDefinition logDefinition, DateTime endDateTime);

        [OperationContract]
        LogDefinition QueryByScheduleId(long scheduleId);
    }
}