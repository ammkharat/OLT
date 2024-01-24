using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class FunctionalLocationIsOrIsAncestorOfOrIsDescendantOfFlocSelectedByUserFilter : IFunctionalLocationTreeNodeFilter
    {
        public FunctionalLocationTreeNode[] Filter(FunctionalLocationTreeNode[] originalList)
        {
            return Filter(new List<FunctionalLocationTreeNode>(originalList)).ToArray();
        }

        public List<FunctionalLocationTreeNode> Filter(List<FunctionalLocationTreeNode> originalList)
        {
            List<FunctionalLocation> rootsForSelectedFunctionalLocations =
                ClientSession.GetUserContext().RootsForSelectedFunctionalLocations;

            return originalList.FindAll(node => Include(node, rootsForSelectedFunctionalLocations));
        }

        private static bool Include(FunctionalLocationTreeNode node, List<FunctionalLocation> rootsForSelectedUnitLevelFunctionalLocations)
        {
            FunctionalLocation nodeFloc = node.Tag;
            if (rootsForSelectedUnitLevelFunctionalLocations.Exists(nodeFloc.IsOrIsAncestorOfOrIsDescendantOf))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}