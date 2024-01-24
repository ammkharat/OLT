using System;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IFormMontrealCsdDetails : IDeletableDetails
    {
        bool CloneEnabled { set; }
        bool CloseEnabled { set; }
        bool PrintEnabled { set; }
        bool PrintPreviewEnabled { set; }
        bool RangeVisible { set; }
        bool EditVisible { set; }
        bool EmailEnabled { set; }
        bool PrintButtonVisible { set; }
        bool CloseButtonVisible { set; }
        event Action Clone;
        event Func<bool> Cancel;
        event Func<bool> Close;
        event EventHandler Print;
        event Action PrintPreview;
        event Action Email;
        void MakeAllButtonsInvisible();
    }
}