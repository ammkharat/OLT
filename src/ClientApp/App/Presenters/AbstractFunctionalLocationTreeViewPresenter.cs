using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Presenters
{
    public abstract class AbstractFunctionalLocationTreeViewPresenter
    {
        private readonly IFunctionalLocationTreeView view;
        private bool flocSelectionLoaded;
        private IFunctionalLocationLookup flocLookup;
        private readonly UserContext userContext;

        protected AbstractFunctionalLocationTreeViewPresenter(IFunctionalLocationTreeView view)
        {
            this.view = view;
            userContext = ClientSession.GetUserContext();
        }

        public void LoadRootFunctionalLocations(IFunctionalLocationLookup functionalLocationLookup)
        {
            if (flocSelectionLoaded) return;

            flocLookup = functionalLocationLookup;

            if (view.FunctionalLocationTreeViewMode != null)
            {
                view.FunctionalLocationTreeViewMode.DispatchBasedOnMode(userContext.SiteConfiguration,
                AddDivisionNodes,
                AddUnitAndBelowNodes,
                AddSectionAndBelowNodes,
                AddDivisionNodes,
                AddDivisionNodes,
                AddDivisionNodes,
                AddDivisionNodes);
            }

            flocSelectionLoaded = true;
        }

        private void AddUnitAndBelowNodes()
        {
            Site site = userContext.Site;
            List<FunctionalLocationInfo> flocInfos = flocLookup.GetUnitsFor(site.IdValue);
                        
            List<FunctionalLocationTreeNode> nodesToAdd = FunctionalLocationTreeNode.Convert(flocInfos, view.FunctionalLocationTreeViewMode);
            view.RootNodeCollection = nodesToAdd.ToArray();
        }

        private void AddSectionAndBelowNodes()
        {
            Site site = userContext.Site;
            List<FunctionalLocationInfo> firstLevelFlocs = flocLookup.GetChildrenFor(site.IdValue);

            List<FunctionalLocationInfo> secondLevelFlocs = new List<FunctionalLocationInfo>();
            foreach (FunctionalLocationInfo firstLevelFloc in firstLevelFlocs)
            {
                secondLevelFlocs.AddRange(flocLookup.GetChildrenFor(firstLevelFloc.Floc));
            }

            view.RootNodeCollection = FunctionalLocationTreeNode.Convert(secondLevelFlocs, view.FunctionalLocationTreeViewMode).ToArray();
        }

        /// <summary>
        /// Before expanding a node, we need to remove the dummy node used to create the expansion '+' and add
        /// the real child nodes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LoadRealChildrenBeforeExpansion(object sender, TreeViewCancelEventArgs e)
        {
            var nodeToExpand = (FunctionalLocationTreeNode)e.Node;
            List<FunctionalLocationTreeNode> childrenNodes = GetChildren(nodeToExpand);
            if (childrenNodes.Count != 0)
            {
                view.AddChildren(nodeToExpand, childrenNodes);
            }
        }

        private List<FunctionalLocationTreeNode> GetChildren(FunctionalLocationTreeNode parentFlocNode)
        {
            var newChildrenNodes = new List<FunctionalLocationTreeNode>();
            FunctionalLocation parentFloc = parentFlocNode.Tag;
            FunctionalLocationType childFlocType = parentFloc.Type + 1;
            FunctionalLocationMode mode = view.FunctionalLocationTreeViewMode;

            if (parentFlocNode.HasPlaceholder && mode.IsAllowed(childFlocType))
            {
                List<FunctionalLocationInfo> childrenFlocs = flocLookup.GetChildrenFor(parentFloc);
                foreach (FunctionalLocationInfo childFloc in childrenFlocs)
                {
                    bool shouldAddPlaceHolder = childFloc.HasChildren && mode.IsAllowed(childFloc.Floc.Type + 1);
                    var node = new FunctionalLocationTreeNode(childFloc.Floc, shouldAddPlaceHolder);
                    newChildrenNodes.Add(node);
                }
            }
            return newChildrenNodes;
        }


        private void AddDivisionNodes()
        {
            // Show All mode:
            Site site = userContext.Site;
            List<FunctionalLocationInfo> flocs = flocLookup.GetChildrenFor(site.IdValue);

            if(site.IdValue == 18)    // Ayman US Pipeline
            {
                flocs.RemoveAll(f => f.Floc.FullHierarchy == "USP");
            }

            if(site.IdValue == 19)    // Ayman Tera Nova
            {
                flocs.RemoveAll(f => f.Floc.FullHierarchy == "TN1");
            }

            view.RootNodeCollection = FunctionalLocationTreeNode.Convert(flocs, view.FunctionalLocationTreeViewMode).ToArray();
        }

        /// <summary>
        /// Takes a list of FunctionalLocationNodes and decides if we need to add additional Child Nodes because there are flocs that need to be pre-selected.
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="initialSelectedFlocs"></param>
        protected void WalkNodesAndAddMissingFunctionalLocations(IEnumerable<FunctionalLocationTreeNode> nodes, IList<FunctionalLocation> initialSelectedFlocs)
        {
            foreach (FunctionalLocationTreeNode currentNode in nodes)
            {
                FunctionalLocation flocForCurrentNode = currentNode.Tag;

                if (initialSelectedFlocs.Exists(flocForCurrentNode.IsParentOf))
                {
                    List<FunctionalLocationTreeNode> childNodes = GetChildren(currentNode);
                    if (childNodes.Count != 0)
                    {
                        view.AddChildren(currentNode, childNodes);
                    }
                    if (currentNode.Nodes.Count > 0)
                    {
                        WalkNodesAndAddMissingFunctionalLocations(currentNode.ChildFunctionalLocationTreeNodes, initialSelectedFlocs);
                    }
                }
            }
        }

        public void AddMissingFunctionalLocations(FunctionalLocation floc)
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc };
            WalkNodesAndAddMissingFunctionalLocations(view.RootNodeCollection, flocs);
        }
    }
}