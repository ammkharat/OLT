using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class AdminOltSourcedFunctionalLocationsFilter : IFunctionalLocationTreeNodeFilter
    {
        public FunctionalLocationTreeNode[] Filter(FunctionalLocationTreeNode[] originalList)
        {
            foreach (FunctionalLocationTreeNode node in originalList)
            {
                node.SetUserSelectableBasedOnSource();
            }
            return originalList;
        }

        public List<FunctionalLocationTreeNode> Filter(List<FunctionalLocationTreeNode> originalList)
        {
            foreach (FunctionalLocationTreeNode node in originalList)
            {
                node.SetUserSelectableBasedOnSource();
            }
            return originalList;
        }
    }
}