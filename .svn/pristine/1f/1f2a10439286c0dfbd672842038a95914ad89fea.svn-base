using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IMultiSelectFunctionalLocationTreeView : IFunctionalLocationTreeView
    {
        void SetNodeStateToChecked(IEnumerable<FunctionalLocation> flocs);
        void SetNodeStateToUnchecked(IEnumerable<FunctionalLocation> flocs);
        bool IsSelectedValid { get; }
        bool IsChecked(TreeNode treeNode);
        bool IsUnchecked(TreeNode treeNode);
    }
}
