using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Presenters
{
    public interface IRunnablePresenter
    {
        DialogResult Run(IWin32Window parent);
    }
}
