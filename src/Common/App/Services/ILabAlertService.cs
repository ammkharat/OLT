using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface ILabAlertService
    {
        [OperationContract]
        bool EvaluateDefinition(LabAlertDefinition definition, DateTime? intendedScheduleExecutionTime);

        [OperationContract]
        List<NotifiedEvent> UpdateStatusAndResponses(LabAlert labAlert, Log logForResponse);

        [OperationContract]
        LabAlert QueryById(long id);

        [OperationContract]
        List<LabAlertDTO> QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(
            IFlocSet flocSet, Range<Date> dateRange, List<LabAlertStatus> statuses);

        [OperationContract]
        void InsertLabAlert(LabAlert labAlert);
    }
}