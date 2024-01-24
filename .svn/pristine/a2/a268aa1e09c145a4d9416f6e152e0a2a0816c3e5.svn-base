using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IPermitRequestLubesService
    {
        [OperationContract]
        PermitRequestLubes QueryById(long id);

        [OperationContract]
        List<NotifiedEvent> Insert(PermitRequestLubes permitRequest);

        [OperationContract]
        List<NotifiedEvent> Update(PermitRequestLubes permitRequest);

        [OperationContract]
        List<PermitRequestLubesDTO> QueryByDateRangeAndFlocs(IFlocSet flocSet, DateRange dateRange);

        [OperationContract]
        List<PermitRequestLubesDTO> QueryByCompletenessAndGroupAndDateWithinRange(
            List<PermitRequestCompletionStatus> completionStatuses, long groupId, Date date);

        [OperationContract]
        List<NotifiedEvent> Submit(Date workPermitDate, List<PermitRequestLubesDTO> dtos, User user);

        [OperationContract]
        List<NotifiedEvent> Remove(PermitRequestLubes request);
    }
}