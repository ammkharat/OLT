using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ISelectFunctionalLocationSelectionForm
    {
        DialogResult ShowDialog(IWin32Window owner);

        bool AreSelectedFunctionalLocationsValid { get; }
        void SetFunctionalLocationErrorMessage();
        void SetFunctionalLocationErrorMessage(string message);
        void LaunchFunctionalLocationSelectionRequiredMessage();
        void CloseForm(DialogResult result);
    }
}