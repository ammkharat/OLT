using System;
using System.Drawing;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IForm : IWin32Window
    {
        event EventHandler Load;
        event EventHandler Disposed;
        event FormClosingEventHandler FormClosing;

        int Height { get; set; }
        int Width { get; set; }
        Point Location { get; set; }

        DialogResult DialogResult { get;  set; }

        DialogResult ShowDialog(IWin32Window form);
        void Dispose();

        void Close();
    }
}