using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    /// <summary>
    ///     This is the old class for Work Permit statuses.  The sites using the Pull model use the
    ///     PermitRequestedBasedWorkPermitStatus class.
    ///     When Sarnia and Denver move to the pull model, this class should be replaced by PermitRequestBasedWorkPermitStatus
    /// </summary>
    [Serializable]
    public class WorkPermitStatus : SortableSimpleDomainObject
    {
        public static WorkPermitStatus Pending = new WorkPermitStatus(1, 2);
        public static WorkPermitStatus Approved = new WorkPermitStatus(2, 1);
        public static WorkPermitStatus Complete = new WorkPermitStatus(3, 4);
        public static WorkPermitStatus Rejected = new WorkPermitStatus(4, 5);
        public static WorkPermitStatus Issued = new WorkPermitStatus(5, 3);
        public static WorkPermitStatus Archived = new WorkPermitStatus(6, 6);

        public static readonly WorkPermitStatus[] All = {Pending, Approved, Complete, Rejected, Issued, Archived};

        internal WorkPermitStatus(long id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.WorkPermitStatus_Pending;
            }
            if (IdValue == 2)
            {
                return StringResources.WorkPermitStatus_Approved;
            }
            if (IdValue == 3)
            {
                return StringResources.WorkPermitStatus_Complete;
            }
            if (IdValue == 4)
            {
                return StringResources.WorkPermitStatus_Rejected;
            }
            if (IdValue == 5)
            {
                return StringResources.WorkPermitStatus_Issued;
            }
            if (IdValue == 6)
            {
                return StringResources.WorkPermitStatus_Archived;
            }
            return null;
        }

        public static WorkPermitStatus Get(long index)
        {
            return GetById(index, All);
        }
    }
}