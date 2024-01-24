using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IActionItemRespondFormView
    {
        ActionItemDefinitionStatus SelectedStatus { get;}
        string Comment { get;}
        DialogResult ShowDialog(IWin32Window owner);
    }
}
