using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitLockOutMethodType : SortableSimpleDomainObject
    {
        public static WorkPermitLockOutMethodType INDIVIDUAL_BY_WORKER = new WorkPermitLockOutMethodType(1, 1);
        public static WorkPermitLockOutMethodType INDIVIDUAL_BY_OPERATIONS = new WorkPermitLockOutMethodType(2, 2);
        public static WorkPermitLockOutMethodType COMPLEX_GROUP = new WorkPermitLockOutMethodType(3, 3);

        private static readonly WorkPermitLockOutMethodType[] All =
        {
            INDIVIDUAL_BY_WORKER, INDIVIDUAL_BY_OPERATIONS,
            COMPLEX_GROUP
        };

        private WorkPermitLockOutMethodType(long id, int sortOrder)
            : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.WorkPermitLockOutMethodType_IndividualByWorker;
            }
            if (IdValue == 2)
            {
                return StringResources.WorkPermitLockOutMethodType_IndividualByOperations;
            }
            if (IdValue == 3)
            {
                return StringResources.WorkPermitLockOutMethodType_ComplexGroup;
            }
            return null;
        }

        public static WorkPermitLockOutMethodType Get(long index)
        {
            return GetById(index, All);
        }
    }
}