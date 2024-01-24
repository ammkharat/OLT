using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class MultiSelectFunctionalLocationTreeViewPresenter : AbstractFunctionalLocationTreeViewPresenter
    {
        private readonly IMultiSelectFunctionalLocationTreeView view;
        private SelectedFunctionalLocations userSelectedFlocs;
        private bool isManuallyChangingUserSelectedFlocList;

        public MultiSelectFunctionalLocationTreeViewPresenter(IMultiSelectFunctionalLocationTreeView view) : base(view)
        {
            userSelectedFlocs = new SelectedFunctionalLocations();
            isManuallyChangingUserSelectedFlocList = false;
            this.view = view;
        }

        public IList<FunctionalLocation> UserSelectedFLOCList
        {
            get { return userSelectedFlocs.ToReadOnlyList; }
            set
            {
                IList<FunctionalLocation> initialSelectedFlocs = value;
                WalkNodesAndAddMissingFunctionalLocations(view.RootNodeCollection, initialSelectedFlocs);
                SetUserSelectedFlocList(initialSelectedFlocs);
            }
        }

        private void SetUserSelectedFlocList(IList<FunctionalLocation> newFlocList)
        {
            isManuallyChangingUserSelectedFlocList = true;
            ClearSelectedNodes();
            
            userSelectedFlocs = new SelectedFunctionalLocations(newFlocList);
            view.SetNodeStateToChecked(newFlocList);

            isManuallyChangingUserSelectedFlocList = false;
        }

        private void ClearSelectedNodes()
        {
            view.SetNodeStateToUnchecked(userSelectedFlocs.ToReadOnlyList);
        }

        public void HandleFunctionalLocationSelected(object sender, TreeViewEventArgs e)
        {
            var selectedTreeNode = e.Node as FunctionalLocationTreeNode;
            if (selectedTreeNode == null || isManuallyChangingUserSelectedFlocList) return;

            FunctionalLocation selectedFloc = selectedTreeNode.Tag;

            if (view.IsChecked(selectedTreeNode) && !userSelectedFlocs.Has(selectedFloc))
            {
                userSelectedFlocs.AddSelectedFunctionalLocation(selectedFloc);
            }
            else if (view.IsUnchecked(selectedTreeNode))
            {
                userSelectedFlocs.RemoveSelectedFunctionalLocation(selectedFloc);
            }
        }
    }
}