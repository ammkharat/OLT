using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class ActionItemDefinitionStatus : SortableSimpleDomainObject
    {
        public static readonly ActionItemDefinitionStatus Pending = new ActionItemDefinitionStatus(0, 2);
        public static readonly ActionItemDefinitionStatus Rejected = new ActionItemDefinitionStatus(2, 3);
        public static readonly ActionItemDefinitionStatus Approved = new ActionItemDefinitionStatus(1, 1);

        public static readonly ActionItemDefinitionStatus[] All = {Pending, Rejected, Approved};

        private ActionItemDefinitionStatus(long id, int sortOrder) : base(id, sortOrder)
        {
        }

        public bool IsApproved
        {
            get { return Equals(Approved); }
        }

        public override string GetName()
        {
            if (IdValue == 0)
            {
                return StringResources.ActionItemDefinitionStatus_Pending;
            }
            if (IdValue == 2)
            {
                return StringResources.ActionItemDefinitionStatus_Rejected;
            }
            if (IdValue == 1)
            {
                return StringResources.ActionItemDefinitionStatus_Approved;
            }
            return null;
        }

        public static ActionItemDefinitionStatus GetById(long id)
        {
            return GetById(id, All);
        }

        public static ActionItemDefinitionStatus GetStatusBasedOnRequiresApproval(bool approvalIsRequired)
        {
            return approvalIsRequired ? Pending : Approved;
        }
    }
}