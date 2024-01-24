using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Controls
{
    public class SingleSelectFunctionalLocationTreeView : OltTreeView, IFunctionalLocationTreeView
    {
        private readonly SingleSelectFunctionalLocationTreeViewPresenter presenter;
        private readonly FunctionalLocationTreeViewNodeLookup functionalLocationTreeViewNodeLookup;
        private IFunctionalLocationTreeNodeFilter nodeFilter;

        public SingleSelectFunctionalLocationTreeView()
        {
            HideSelection = false;
            presenter = new SingleSelectFunctionalLocationTreeViewPresenter(this);
            functionalLocationTreeViewNodeLookup = new FunctionalLocationTreeViewNodeLookup();
            BeforeExpand += presenter.LoadRealChildrenBeforeExpansion;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IFunctionalLocationTreeNodeFilter NodeFilter
        {
            set { nodeFilter = value; }
        }

        public FunctionalLocationTreeNode[] RootNodeCollection
        {
            set
            {
                FunctionalLocationTreeNode[] nodes = value;
                if (nodeFilter != null)
                {
                    nodes = nodeFilter.Filter(value);
                }

                BeginUpdate();

                Nodes.Clear();
                Nodes.AddRange(nodes);
                functionalLocationTreeViewNodeLookup.Initialize(nodes);

                EndUpdate();
            }

            get
            {
                var array = new FunctionalLocationTreeNode[Nodes.Count];
                Nodes.CopyTo(array, 0);
                return array;
            }
        }

        public void AddChildren(FunctionalLocationTreeNode parentFlocNode, List<FunctionalLocationTreeNode> originalNodes)
        {
            List<FunctionalLocationTreeNode> nodes = originalNodes;
            if (nodeFilter != null)
            {
                nodes = nodeFilter.Filter(originalNodes);
            }

            if (nodes.Count == 0)
            {
                return;
            }

            functionalLocationTreeViewNodeLookup.AddNodesToDictionary(nodes.ToArray());

            BeginUpdate();
            parentFlocNode.Nodes.Clear();
            parentFlocNode.Nodes.AddRange(nodes.ToArray());
            EndUpdate();
        }

        public List<FunctionalLocation> SiblingsOfSelectedFunctionalLocation
        {
            get
            {
                List<FunctionalLocation> result = new List<FunctionalLocation>();

                FunctionalLocationTreeNode selectedNode = SelectedNode as FunctionalLocationTreeNode;

                if (selectedNode != null && selectedNode.Parent != null)
                {
                    TreeNodeCollection siblings = selectedNode.Parent.Nodes;
                    foreach (TreeNode node in siblings)
                    {
                        FunctionalLocationTreeNode functionalLocationTreeNode = node as FunctionalLocationTreeNode;
                        if (!functionalLocationTreeNode.Equals(selectedNode))
                        {
                            result.Add(functionalLocationTreeNode.Tag);
                        }
                    }
                }
                else if (selectedNode != null)
                {
                    FunctionalLocationTreeNode[] functionalLocationTreeNodes = RootNodeCollection;
                    FunctionalLocation objectToBeCompared = SelectedFunctionalLocation;
                    functionalLocationTreeNodes.FindAll(node => node.Tag.Equals(objectToBeCompared));
                }
                return result;
            }
        }

        public List<FunctionalLocation> ChildrenOfSelectedFunctionalLocation
        {
            get
            {
                List<FunctionalLocation> result = new List<FunctionalLocation>();
                if (SelectedNode != null)
                {
                    TreeNodeCollection childrenOfSelectedFunctionalLocation = SelectedNode.Nodes;
                    foreach (TreeNode node in childrenOfSelectedFunctionalLocation)
                    {
                        FunctionalLocationTreeNode functionalLocationTreeNode = node as FunctionalLocationTreeNode;
                        result.Add(functionalLocationTreeNode.Tag);
                    }
                }
                return result;
            }
        }

        public FunctionalLocation ParentOfSelectedFunctionalLocation
        {
            get
            {
                FunctionalLocation result = null;
                if (SelectedNode != null)
                {
                    FunctionalLocationTreeNode parentNode = SelectedNode.Parent as FunctionalLocationTreeNode;
                    if (parentNode != null)
                        result = parentNode.Tag;
                }
                return result;
            }
        }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get
            {
                FunctionalLocation result = null;
                var node = SelectedNode as FunctionalLocationTreeNode;
                if (node != null)
                {
                    result = node.Tag;
                }
                return result;
            }
            set
            {
                // Note: this setter will only work if the FLOCs are already loaded into the tree.
                if (value == null)
                {
                    return;
                }

                FunctionalLocationTreeNode node = null;
                if (functionalLocationTreeViewNodeLookup.Contains(value))
                {
                    node = functionalLocationTreeViewNodeLookup.Get(value);
                }

                if (node != null)
                {
                    SelectedNode = node;
                }              
            }
        }

        public bool CanSelectFunctionalLocation(FunctionalLocation floc)
        {
            return functionalLocationTreeViewNodeLookup.Contains(floc);
        }

        public FunctionalLocationMode FunctionalLocationTreeViewMode { set; get; }

        public bool IsSelectedValid
        {
            get
            {
                FunctionalLocationTreeNode treeNode = SelectedNode as FunctionalLocationTreeNode;
                return treeNode != null && treeNode.IsUserSelectable;
            }
        }

        public void RemoveSelectedItem()
        {
            TreeNode oldItem = SelectedNode;
            if (oldItem == null)
                return;

            functionalLocationTreeViewNodeLookup.RemoveNodesFromDictionary(new[] { oldItem as FunctionalLocationTreeNode });

            BeginUpdate();
            int indexOfOldNode = oldItem.Index;

            TreeNode parentNode = oldItem.Parent;
            if (parentNode == null)
                return;

            parentNode.Nodes.RemoveAt(indexOfOldNode);

            EndUpdate();
        }

        public void UpdateSelectedItem(FunctionalLocation functionalLocation)
        {
            TreeNode oldItem = SelectedNode;
            if (oldItem == null)
                return;

            BeginUpdate();

            oldItem.Tag = functionalLocation;
            oldItem.Text = functionalLocation.FullHierarchyWithDescription;
            EndUpdate();
        }

        public void AddNewFunctionalLocation(FunctionalLocation insertedFunctionalLocation)
        {
            FunctionalLocationTreeNode superiorFlocNode = SelectedNode as FunctionalLocationTreeNode;
            
            // the only thing there right now is the placeholder. so leave it, and when the user expands the node, the new one should show up.
            if (superiorFlocNode == null || superiorFlocNode.HasPlaceholder)
                return;

            
            TreeNodeCollection siblingNodes = SelectedNode.Nodes;
            List<FunctionalLocationTreeNode> flocTreeNodes = siblingNodes.ConvertAll<FunctionalLocationTreeNode, TreeNode>(node => node as FunctionalLocationTreeNode);
            // need to remove the nodes before they get added again.
            functionalLocationTreeViewNodeLookup.RemoveNodesFromDictionary(flocTreeNodes.ToArray());

            FunctionalLocationTreeNode functionalLocationTreeNode = new FunctionalLocationTreeNode(insertedFunctionalLocation, false);
            functionalLocationTreeNode.SetUserSelectableBasedOnSource();

            flocTreeNodes.Add(functionalLocationTreeNode);
            flocTreeNodes.Sort((a, b) =>
            {
                FunctionalLocation flocA = a.Tag;
                FunctionalLocation flocB = b.Tag;
                return string.Compare(flocA.FullHierarchy, flocB.FullHierarchy, StringComparison.CurrentCulture);
            });

            AddChildren(superiorFlocNode, flocTreeNodes);
        }

        public void AddMissingFunctionalLocations(FunctionalLocation floc)
        {
            presenter.AddMissingFunctionalLocations(floc);
        }

        public void LoadRootFunctionalLocations(IFunctionalLocationLookup flocLookup)
        {
            presenter.LoadRootFunctionalLocations(flocLookup);
        }
    }
}