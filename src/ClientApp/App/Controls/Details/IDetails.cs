using System;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IDetails
    {
        event EventHandler ExportAll;
        event Action ToggleShow;
        event Action SaveGridLayout; 

        DockStyle Dock { get; set; }
        void Show();
        void Hide();
        bool Enabled { get; set; }
        void CallDefaultButton();
        WidgetAppearance ShowButtonAppearance { get; set; }
        
        bool EnableLayoutIsActiveIndicator { set; }
    }
}