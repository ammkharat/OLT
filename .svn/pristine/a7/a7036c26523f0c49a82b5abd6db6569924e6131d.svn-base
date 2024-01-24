namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    public interface IHasPermitKey
    {
        string WorkOrderNumber { get; }
        string OperationNumber { get; }
        string SubOperationNumber { get; }

        bool MatchesByPermitKey(IHasPermitKey item);
    }
}