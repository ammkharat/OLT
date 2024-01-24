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
    public interface IWorkPermitLubesService
    {
        [OperationContract]
        List<NotifiedEvent> Insert(WorkPermitLubes workPermit);

        [OperationContract]
        List<NotifiedEvent> Update(WorkPermitLubes workPermit);

        [OperationContract]
        List<NotifiedEvent> Remove(WorkPermitLubes workPermit);

        [OperationContract]
        List<WorkPermitLubesGroup> QueryAllGroups();

        [OperationContract]
        WorkPermitLubes QueryById(long id);

        [OperationContract]
        List<WorkPermitLubesDTO> QueryByDateRangeAndFlocs(Range<Date> dateRange, RootFlocSet rootFlocSet);

        [OperationContract]
        bool DoesPermitRequestLubesAssociationExist(List<PermitRequestLubesDTO> submittedRequests,
            Date workPermitStartDate);

        [OperationContract]
        List<NotifiedEvent> InsertWithPermitRequestLubesAssociation(WorkPermitLubes workPermit,
            PermitRequestLubes request);

        [OperationContract]
        List<NotifiedEvent> UpdateAndInsertLogs(List<WorkPermitLubes> workPermits,
            Dictionary<long, Log> permitIdToAssociatedLogMap);

        [OperationContract]
        WorkPermitLubes QueryPreviousDayIssuedPermitForSamePermitRequest(WorkPermitLubes permit);
    }
}