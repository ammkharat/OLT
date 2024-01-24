using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class LocationItemTreeItem
    {
        private const long FakeRootId = -1;
        private readonly string fakeRootName;

        public static LocationItemTreeItem CreateFakeRoot(string rootName)
        {
            return new LocationItemTreeItem(rootName);
        }

        public LocationItemTreeItem(RestrictionLocationItem restrictionLocationItem)
        {
            RestrictionLocationItem = restrictionLocationItem;
        }

        private LocationItemTreeItem(string rootName)
        {
            RestrictionLocationItem = null;
            fakeRootName = rootName;
        }

        public FunctionalLocation FunctionalLocation
        {
            get { return IsFakeRoot ? null : RestrictionLocationItem.FunctionalLocation; }
        }

        public string Name
        {
            get { return IsFakeRoot ? fakeRootName : RestrictionLocationItem.Name; }
        }

        public bool HasReasonCodes
        {
            get { return !RestrictionLocationItem.ReasonCodes.IsEmpty(); }
        }

        public List<RestrictionLocationItemReasonCodeAssociation> ReasonCodes
        {
            get { return IsFakeRoot ? new List<RestrictionLocationItemReasonCodeAssociation>(0) : RestrictionLocationItem.ReasonCodes; }
            set
            {
                if (IsFakeRoot)
                    return;
                RestrictionLocationItem.ReasonCodes = value;
            }
        }

        internal bool IsFakeRoot
        {
            get { return RestrictionLocationItem == null; }
        }

        public long Id
        {
            get {
                return IsFakeRoot ? FakeRootId : RestrictionLocationItem.IdValue;
            }
        }

        public long ParentId
        {
            get { return IsFakeRoot || !RestrictionLocationItem.ParentItemId.HasValue ? FakeRootId : RestrictionLocationItem.ParentItemId.Value; }
        }

        internal RestrictionLocationItem RestrictionLocationItem { private set; get; }
    }
}