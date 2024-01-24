using System;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public interface IPage
    {
        event EventHandler Disposed;
        bool IsDisposed { get; }
        void Dispose();

        event EventHandler VisibleChanged;
        bool Visible { get; }

        object Invoke(Delegate deleg, params object[] args);

        Form ParentForm { get; }

        bool InvokeRequired { get; }
    }
}