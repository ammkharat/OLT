using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [Serializable]
    public class TargetDefinitionStatus : SortableSimpleDomainObject
    {
        public static TargetDefinitionStatus Pending = new TargetDefinitionStatus(1, 2);
        public static TargetDefinitionStatus Approved = new TargetDefinitionStatus(2, 1);
        public static TargetDefinitionStatus Rejected = new TargetDefinitionStatus(4, 3);
        public static TargetDefinitionStatus InvalidTag = new TargetDefinitionStatus(5, 4);

        private static readonly TargetDefinitionStatus[] all = {Pending, Approved, Rejected, InvalidTag};

        private TargetDefinitionStatus(long id, int sortOrder) : base(id, sortOrder)
        {
        }

        public static TargetDefinitionStatus[] All
        {
            get { return all; }
        }

        public bool IsApproved
        {
            get { return Equals(Approved); }
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.TargetDefinitionStatus_Pending;
            }
            if (IdValue == 2)
            {
                return StringResources.TargetDefinitionStatus_Approved;
            }
            if (IdValue == 4)
            {
                return StringResources.TargetDefinitionStatus_Rejected;
            }
            if (IdValue == 5)
            {
                return StringResources.TargetDefinitionStatus_InvalidTag;
            }
            return null;
        }

        public static TargetDefinitionStatus GetStatusBasedOnRequiresApproval(bool requiresApproval)
        {
            return requiresApproval ? Pending : Approved;
        }

        public static TargetDefinitionStatus Get(long index)
        {
            return GetById(index, all);
        }
    }
}