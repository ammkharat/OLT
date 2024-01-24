using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.Restriction
{
    [Serializable]
    public class RestrictionLocationItem : DomainObject
    {
        public RestrictionLocationItem(long id, string name, FunctionalLocation floc, long? parentItemId,
            List<RestrictionLocationItemReasonCodeAssociation> reasonCodes)
            : this(name, floc, parentItemId, reasonCodes)
        {
            this.id = id;
        }

        public RestrictionLocationItem(string name, FunctionalLocation floc, long? parentItemId,
            List<RestrictionLocationItemReasonCodeAssociation> reasonCodes)
        {
            Name = name;
            FunctionalLocation = floc;
            ReasonCodes = reasonCodes;
            ParentItemId = parentItemId;
        }

        public string Name { get; set; }
        public long? ParentItemId { get; private set; }
        public FunctionalLocation FunctionalLocation { get; set; }
        public List<RestrictionLocationItemReasonCodeAssociation> ReasonCodes { get; set; }
    }
}