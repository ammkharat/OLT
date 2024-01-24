using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    public class DirectiveStatus : SortableSimpleDomainObject
    {
        public static readonly DirectiveStatus Active = new DirectiveStatus(1, 0);
        public static readonly DirectiveStatus Future = new DirectiveStatus(2, 1);
        public static readonly DirectiveStatus Expired = new DirectiveStatus(3, 2);

        public DirectiveStatus(long id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            if (id == Active.IdValue) return StringResources.DirectiveStatus_Active;
            if (id == Future.IdValue) return StringResources.DirectiveStatus_Future;
            if (id == Expired.IdValue) return StringResources.DirectiveStatus_Expired;

            throw new NotImplementedException("Please implement GetName() for all ids in DirectiveStatus.");
        }
    }
}