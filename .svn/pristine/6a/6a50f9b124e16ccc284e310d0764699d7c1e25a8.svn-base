using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Controls
{
    public class MultiSelectFunctionalLocationTreeView : OltTriStateTreeView, IMultiSelectFunctionalLocationTreeView
    {
        private readonly MultiSelectFunctionalLocationTreeViewPresenter presenter;
        private readonly FunctionalLocationTreeViewNodeLookup functionalLocationTreeViewNodeLookup;
        private IFunctionalLocationTreeNodeFilter nodeFilter;

        public MultiSelectFunctionalLocationTreeView()
        {
            HideSelection = false;
            functionalLocationTreeViewNodeLookup = new FunctionalLocationTreeViewNodeLookup();
            presenter = new MultiSelectFunctionalLocationTreeViewPresenter(this);
            AfterCheck += presenter.HandleFunctionalLocationSelected;
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

        public bool IsSelectedValid
        {
            get
            {
                IList<FunctionalLocation> userCheckedFunctionalLocations = UserCheckedFunctionalLocations;
                return userCheckedFunctionalLocations.TrueForAll(floc =>
                                                                     {
                                                                         if (!functionalLocationTreeViewNodeLookup.Contains(floc))
                                                                         {
                                                                             return true;
                                                                         }
                                                                         FunctionalLocationTreeNode node =
                                                                             functionalLocationTreeViewNodeLookup.Get(
                                                                                 floc);
                                                                         return node.IsUserSelectable;
                                                                     });
            }
        }

        public void SetNodeStateToChecked(IEnumerable<FunctionalLocation> flocs)
        {
            SetNodeState(flocs, CheckState.Checked);
        }

        public void SetNodeStateToUnchecked(IEnumerable<FunctionalLocation> flocs)
        {
            SetNodeState(flocs, CheckState.Unchecked);
        }

        private void SetNodeState(IEnumerable<FunctionalLocation> flocs, CheckState checkState)
        {
            BeginUpdate();

            foreach (FunctionalLocation floc in flocs)
            {
                SetNodeState(floc, checkState, false);   // we wrap this whole loop in BeginUpdate/EndUpdate, so pass in false so that we don't do it for each node
            }

            EndUpdate();
        }

        private void SetNodeState(FunctionalLocation floc, CheckState checkState, bool doDisablingAndEnablingOfTreeView)
        {
            if (!functionalLocationTreeViewNodeLookup.Contains(floc))
            {
                return;
            }
            FunctionalLocationTreeNode node = functionalLocationTreeViewNodeLookup.Get(floc);

            if (GetChecked(node) == CheckState.Unchecked && checkState == CheckState.Checked)
                ChangeNodeStateFromUncheckedToChecked(node, doDisablingAndEnablingOfTreeView);
            if (GetChecked(node) == CheckState.Checked && checkState == CheckState.Unchecked)
                ChangeNodeStateFromCheckedToUnchecked(node, doDisablingAndEnablingOfTreeView);
        }

        private void ChangeNodeStateFromUncheckedToChecked(TreeNode node, bool doDisablingAndEnablingOfTreeView)
        {
            var flocNode = (FunctionalLocationTreeNode) node;
            CheckState currentState = GetChecked(node);
            if (currentState == CheckState.Unchecked)
            {
                ChangeNodeState(node, doDisablingAndEnablingOfTreeView);
                TreeUtils.ExpandTreeToNode(flocNode);
            }
        }

        private void ChangeNodeStateFromCheckedToUnchecked(TreeNode node, bool doDisablingAndEnablingOfTreeView)
        {
            CheckState currentState = GetChecked(node);
            if (currentState == CheckState.Checked)
            {
                ChangeNodeState(node, doDisablingAndEnablingOfTreeView);
            }                
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IList<FunctionalLocation> UserCheckedFunctionalLocations
        {
            get { return presenter.UserSelectedFLOCList; }
            set { presenter.UserSelectedFLOCList = value; }
        }

        public List<FunctionalLocation> AllCheckedFunctionalLocations
        {            
            get
            {
                return GetAllCheckedFunctionalLocations(Nodes);
            }
        }

        public FunctionalLocationMode FunctionalLocationTreeViewMode { set; get; }

        private List<FunctionalLocation> GetAllCheckedFunctionalLocations(TreeNodeCollection nodes)
        {
            var result = new List<FunctionalLocation>();
            foreach (FunctionalLocationTreeNode childNode in nodes)
            {
                if (!childNode.IsPlaceholder)
                {
                    result.AddRange(GetChecked(childNode) == CheckState.Checked
                        ? childNode.GetChildrenDataInDepthFirst()
                        : GetAllCheckedFunctionalLocations(childNode.Nodes));                    
                }
            }

            return result;
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

            // In the case where the children are not loaded, we need to ensure that they are checked if the parent is checked.
            if (GetChecked(parentFlocNode) != CheckState.Unchecked)
            {
                nodes.ForEach(SetToGreyChecked);
            }
            EndUpdate();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public FunctionalLocation SelectedFunctionalLocationNode
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
            presenter.AddMissingFunctionalLocations(floc);
            return functionalLocationTreeViewNodeLookup.Contains(floc);
        }

        public bool CanCheckFunctionalLocation(FunctionalLocation floc)
        {
            if (!CanSelectFunctionalLocation(floc))
            {
                return false;
            }

            FunctionalLocationTreeNode node = functionalLocationTreeViewNodeLookup.Get(floc);
            return node != null && node.IsUserSelectable;
        }

        public void Initialize(IFunctionalLocationLookup flocLookup)
        {
            presenter.LoadRootFunctionalLocations(flocLookup);
        }
    }
}