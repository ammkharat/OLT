using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IPermitRequestEdmontonDao : IPermitRequestDao<PermitRequestEdmonton>
    {
        List<PermitRequestEdmonton> QueryByFormGN59Id(long id);
        List<PermitRequestEdmonton> QueryByFormGN6Id(long id);
        List<PermitRequestEdmonton> QueryByFormGN7Id(long id);
        List<PermitRequestEdmonton> QueryByFormGN24Id(long id);
        List<PermitRequestEdmonton> QueryByFormGN75AId(long id);
        List<PermitRequestEdmonton> QueryByFormGN1Id(long id);

        List<PermitRequestEdmonton> QueryByWorkOrderNumberAndSAPWorkCentre(string workOrderNumber, string sapWorkCentre);
        PermitRequestEdmonton QueryEdmontonPermitRequestByWorkOrderNumberAndOperationAndSource(string workOrderNumber, string operationNumber, string subOperationNumber, DataSource dataSource);
    }
}