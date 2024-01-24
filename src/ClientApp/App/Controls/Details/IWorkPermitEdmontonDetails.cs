using System;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IWorkPermitEdmontonDetails : IDeletableDetails
    {
        event EventHandler CloseWorkPermit;
        event EventHandler Clone;
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
        void SetDetails(WorkPermitEdmonton permit);
        void MakeAllButtonsInvisible();
        bool EditButtonVisible { set; }
        bool CloseButtonVisible { set; }

        // DMND0010609-OLT - Edmonton Work permit Scan
        bool ViewAttachEnabled { set; }
        event EventHandler ViewAttachment;
         bool ViewScanEnabled { set; }
         void MakeSeachWindowRequiredButtonsvisibleonly();
		//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
         event EventHandler MarkAsTemplate;
         event EventHandler UnMarkTemplate;
         bool MarkTemplateEnabled { set; }
         bool UnMarkTemplateEnabled { set; }

         bool DeleteVisible { set; }
         bool editVisible { set; }
         bool closeButtonVisible { set; }
         bool printButtonVisible { set; }
        bool printPreviewButtonVisible { set; }
        bool mergeButtonVisible { set; }
        bool viewAssociatedLogsButtonVisible { set; }

        bool historyButtonVisible { set; }
        bool viewAttachementbuttonVisible { set; }
        bool ScanbuttonVisible { set; }

        event EventHandler RefreshAll;
        event EventHandler EditTemplate;

        bool editTemplateVisible { set; }

        


        


    }
}
