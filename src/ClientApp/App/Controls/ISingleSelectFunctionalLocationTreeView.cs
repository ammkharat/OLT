using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters;

namespace Com.Suncor.Olt.Client.Controls
{
    public interface IFunctionalLocationTreeView
    {
        FunctionalLocationMode FunctionalLocationTreeViewMode { get; set; }
        FunctionalLocationTreeNode[] RootNodeCollection { get; set; }
        void AddChildren(FunctionalLocationTreeNode parentFlocNode, List<FunctionalLocationTreeNode> nodes);
        IFunctionalLocationTreeNodeFilter NodeFilter { set; }
    }
}