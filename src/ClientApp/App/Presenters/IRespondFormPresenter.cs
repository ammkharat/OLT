using System;
using Com.Suncor.Olt.Client.Forms;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Presenters
{
    public interface IRespondFormPresenter
    {
        void HandleFormLoad(object sender, EventArgs args);
        void HandleSubmitButtonClick(object sender, EventArgs args);
        void HandleCreateLogCheckedChanged(object sender, EventArgs args);
        void HandleCancelButtonClick(object sender, EventArgs args);
        void HandleFormClosing(object sender, FormClosingEventArgs eventArgs);
        IRespondFormView View { get;   set; }
    }
}
