using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IGridAndDetailsView : IBaseForm
    {
        event Action AcceptButtonClicked;

        string Title { get; set; }             //ayman Sarnia eip
        bool ButtonsVisible { set; }
        string AcceptButtonText { set; }
        IDetails Details { set; }
        Control GridAndDetails { set; }
        event Action NewButtonClicked;
    }
}
