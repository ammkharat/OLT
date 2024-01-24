using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class SapWorkOrderOperation : DomainObject
    {
        private readonly string operationNumber;
        private readonly SapOperationType sapOperationType;
        private readonly string subOperation;
        private readonly string workOrderNumber;

        public SapWorkOrderOperation(long? id, string workOrderNumber, string operationNumber, string subOperation,
            SapOperationType sapOperationType)
        {
            if (workOrderNumber == null)
            {
                throw new NullReferenceException(
                    "The Work Order Number should not be null. It is part of a primary key for this entity");
            }

            if (operationNumber == null)
            {
                throw new NullReferenceException(
                    "The Operation Number should not be null. It is part of a primary key for this entity");
            }

            this.id = id;
            this.workOrderNumber = workOrderNumber;
            this.operationNumber = operationNumber;
            this.subOperation = subOperation.EmptyToNull();
            this.sapOperationType = sapOperationType;
        }

        public string WorkOrderNumber
        {
            get { return workOrderNumber; }
        }

        public string OperationNumber
        {
            get { return operationNumber; }
        }

        public string SubOperation
        {
            get { return subOperation; }
        }

        public SapOperationType SapOperationType
        {
            get { return sapOperationType; }
        }
    }
}