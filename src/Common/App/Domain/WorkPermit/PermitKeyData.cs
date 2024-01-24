using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class PermitKeyData : IHasPermitKey
    {
        public PermitKeyData(string workOrderNumber, string operationNumber, string subOperationNumber)
        {
            WorkOrderNumber = workOrderNumber;
            OperationNumber = operationNumber;
            SubOperationNumber = subOperationNumber;
        }

        public PermitKeyData(IHasPermitKey item)
        {
            WorkOrderNumber = item.WorkOrderNumber;
            OperationNumber = item.OperationNumber;
            SubOperationNumber = item.SubOperationNumber;
        }

        public string WorkOrderNumber { get; private set; }
        public string OperationNumber { get; private set; }
        public string SubOperationNumber { get; private set; }

        public bool MatchesByPermitKey(IHasPermitKey item)
        {
            return MatchesByPermitKey(this, item);
        }

        public static bool MatchesByPermitKey(IHasPermitKey a, IHasPermitKey b)
        {
            if (a == null || b == null)
            {
                return false;
            }

            var aWorkOrderNumber = a.WorkOrderNumber.EmptyToNull();
            var bWorkOrderNumber = b.WorkOrderNumber.EmptyToNull();

            var aOperationNumber = a.OperationNumber.EmptyToNull();
            var bOperationNumber = b.OperationNumber.EmptyToNull();

            var aSubOperationNumber = a.SubOperationNumber.EmptyToNull();
            var bSubOperationNumber = b.SubOperationNumber.EmptyToNull();

            return aWorkOrderNumber == bWorkOrderNumber && aOperationNumber == bOperationNumber &&
                   aSubOperationNumber == bSubOperationNumber;
        }

        public bool Equals(PermitKeyData other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.WorkOrderNumber, WorkOrderNumber) && Equals(other.OperationNumber, OperationNumber) &&
                   Equals(other.SubOperationNumber, SubOperationNumber);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (PermitKeyData)) return false;
            return Equals((PermitKeyData) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = (WorkOrderNumber != null ? WorkOrderNumber.GetHashCode() : 0);
                result = (result*397) ^ (OperationNumber != null ? OperationNumber.GetHashCode() : 0);
                result = (result*397) ^ (SubOperationNumber != null ? SubOperationNumber.GetHashCode() : 0);
                return result;
            }
        }
    }
}