using System;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IWorkPermitFortHillsDetails : IDeletableDetails
    {
        event EventHandler CloseWorkPermit;
        event EventHandler Clone;
        event EventHandler Extension;
        event EventHandler Revalidation;
        event EventHandler ViewAssociatedLogs;
        event EventHandler Merge;
        event EventHandler Print;
        event EventHandler PrintPreview;        

        bool CloseEnabled { set; }
        bool CloneEnabled { set; }
        bool PrintEnabled { set; }
        bool PrintPreviewEnabled { set; }
        bool ViewAssociatedLogsEnabled { set; }
        bool MergeEnabled { set; }
        void SetDetails(WorkPermitFortHills permit);
        void MakeAllButtonsInvisible();
        bool EditButtonVisible { set; }
        bool CloseButtonVisible { set; }
        bool ViewAssociatedLogsVisible { set; }
        bool ExtensionEnable { set; }
        bool RevalidationButtonEnable { set; }
    }
}
