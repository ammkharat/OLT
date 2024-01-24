using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class PermitRequestCompletionStatus : SortableSimpleDomainObject
    {
        public static PermitRequestCompletionStatus Complete = new PermitRequestCompletionStatus(1, 1);
        public static PermitRequestCompletionStatus Incomplete = new PermitRequestCompletionStatus(2, 2);
        public static PermitRequestCompletionStatus ForReview = new PermitRequestCompletionStatus(3, 3);
        public static PermitRequestCompletionStatus Expired = new PermitRequestCompletionStatus(4, 4);

        private static readonly PermitRequestCompletionStatus[] all = {Complete, Incomplete, ForReview, Expired};

        private PermitRequestCompletionStatus(long id, int sortOrder)
            : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.PermitRequestCompletionStatus_Complete;
            }
            if (IdValue == 2)
            {
                return StringResources.PermitRequestCompletionStatus_Incomplete;
            }
            if (IdValue == 3)
            {
                return StringResources.PermitRequestCompletionStatus_ForReview;
            }
            if (IdValue == 4)
            {
                return StringResources.PermitRequestCompletionStatus_Expired;
            }

            return null;
        }

        public static PermitRequestCompletionStatus Get(long id)
        {
            return GetById(id, all);
        }
    }
}