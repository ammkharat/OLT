using System;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IWorkPermitLubesDetails : IDeletableDetails
    {
        bool CloneEnabled { set; }
        bool PrintEnabled { set; }
        bool PrintPreviewEnabled { set; }
        bool CloseEnabled { set; }
        bool EditButtonVisible { set; }
        bool CloseButtonVisible { set; }
        bool ViewAssociatedLogsEnabled { set; }
        void MakeAllButtonsInvisible();
        void SetDetails(WorkPermitLubes permit);

        event Action Print;
        event Action Preview;
        event Action Close;
        event Action ViewAssociatedLogs;
        event Action Clone;
    }
}
