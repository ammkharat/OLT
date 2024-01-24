using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ITargetAssociationSelectionView
    {
        string SearchText { get; }
        List<TargetDefinitionDTO> Targets { set; }
        List<TargetDefinitionDTO> SelectedTargets { get; }
        List<TargetDefinitionDTO> AssociatedTargets { get; set; }
        List<TargetDefinitionDTO> SelectedAssociatedTargets { get; }

        bool RemoveButtonEnabled { set; }

        bool AddButtonEnabled { set; }

        DialogResult ShowDialog(IWin32Window owner);
        void CloseForm();

        void SetError(string errorMessage);
    }
}