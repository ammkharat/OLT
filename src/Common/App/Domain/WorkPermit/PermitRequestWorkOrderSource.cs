using System;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class PermitRequestWorkOrderSource : DomainObject, IHasPermitKey
    {
        public PermitRequestWorkOrderSource(string workOrderNumber, string operationNumber, string subOperationNumber)
        {
            WorkOrderNumber = workOrderNumber;
            OperationNumber = operationNumber;
            SubOperationNumber = subOperationNumber;
        }

        public string WorkOrderNumber { get; private set; }
        public string OperationNumber { get; private set; }
        public string SubOperationNumber { get; private set; }

        public bool MatchesByPermitKey(IHasPermitKey item)
        {
            return PermitKeyData.MatchesByPermitKey(this, item);
        }

        public bool Matches(string workOrderNumber, string operationNumber, string subOperationNumber)
        {
            return WorkOrderNumber == workOrderNumber && OperationNumber == operationNumber &&
                   SubOperationNumber == subOperationNumber;
        }

        public bool Equals(PermitRequestWorkOrderSource other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.WorkOrderNumber, WorkOrderNumber) &&
                   Equals(other.OperationNumber, OperationNumber) &&
                   Equals(other.SubOperationNumber, SubOperationNumber);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as PermitRequestWorkOrderSource);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = base.GetHashCode();
                result = (result*397) ^ (WorkOrderNumber != null ? WorkOrderNumber.GetHashCode() : 0);
                result = (result*397) ^ (OperationNumber != null ? OperationNumber.GetHashCode() : 0);
                result = (result*397) ^ (SubOperationNumber != null ? SubOperationNumber.GetHashCode() : 0);
                return result;
            }
        }
    }
}