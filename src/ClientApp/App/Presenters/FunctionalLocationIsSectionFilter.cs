using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class FunctionalLocationIsSectionFilter : IFunctionalLocationTreeNodeFilter
    {
        public FunctionalLocationTreeNode[] Filter(FunctionalLocationTreeNode[] originalList)
        {
            return Filter(new List<FunctionalLocationTreeNode>(originalList)).ToArray();
        }

        public List<FunctionalLocationTreeNode> Filter(List<FunctionalLocationTreeNode> originalList)
        {
            return originalList.FindAll(Include);
        }

        private static bool Include(FunctionalLocationTreeNode node)
        {
            FunctionalLocation functionalLocation = node.Tag;
            if (functionalLocation.Type == FunctionalLocationType.Level1)
            {
                node.IsUserSelectable = false;
                return true;
            }
            if (functionalLocation.Type == FunctionalLocationType.Level2)
            {
                node.IsUserSelectable = true;
                return true;
            }
            return false;
        }
    }
}