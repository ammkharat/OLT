using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ISapWorkOrderOperationDao : IDao
    {
        SapWorkOrderOperation Insert(SapWorkOrderOperation operation);
        SapWorkOrderOperation FindByKeys(string workOrderNumber, string operationNumber, string subOperation, SapOperationType sapOperationType);
    }
}