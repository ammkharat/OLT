using System;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IConfinedSpaceDetails : IDeletableDetails
    {
        event EventHandler Clone;
        event EventHandler Print;
        event EventHandler PrintPreview;

        void SetDetails(ConfinedSpace confinedSpace);
        bool PrintEnabled { set; }
        bool PrintPreviewEnabled { set; }
        bool CloneEnabled { set; }

        void MakeAllButtonsInvisible();
        bool RangeVisible { set; }
        bool HistoryVisible { set; }
    }
}