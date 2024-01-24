using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class FunctionalLocationIsSelectedByUserFilter : IFunctionalLocationTreeNodeFilter
    {
        private readonly FunctionalLocationType highestType;
        private readonly List<FunctionalLocation> userFlocs;

        public FunctionalLocationIsSelectedByUserFilter() : this(FunctionalLocationType.Level1)
        {
        }

        public FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType highestType) : this(highestType, ClientSession.GetUserContext().RootsForSelectedFunctionalLocations)
        {
        }

        public FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType highestType, List<FunctionalLocation> userFlocs)
        {
            this.highestType = highestType;
            this.userFlocs = userFlocs;
        }

        public FunctionalLocationTreeNode[] Filter(FunctionalLocationTreeNode[] originalList)
        {
            return Filter(new List<FunctionalLocationTreeNode>(originalList)).ToArray();
        }

        public List<FunctionalLocationTreeNode> Filter(List<FunctionalLocationTreeNode> originalList)
        {
            return originalList.FindAll(node => Include(node, userFlocs));
        }

        private bool Include(FunctionalLocationTreeNode node, List<FunctionalLocation> rootsForSelectedFunctionalLocations)
        {
            FunctionalLocation functionalLocation = node.Tag;

            if (functionalLocation.Type < highestType)
            {
                node.IsUserSelectable = false;
                return true;
            }

            if (rootsForSelectedFunctionalLocations.ExistsById(functionalLocation) || rootsForSelectedFunctionalLocations.Exists(functionalLocation.IsChildOf))
            {
                return true;
            }
            if (rootsForSelectedFunctionalLocations.Exists(functionalLocation.IsParentOf))
            {
                node.IsUserSelectable = false;
                return true;
            }
            return false;
        }
    }
}