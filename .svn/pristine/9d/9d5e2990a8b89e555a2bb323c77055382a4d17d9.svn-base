using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface ISummaryLogDetails : IDeletableDetails, IThreadedItemDetails
    {
        event EventHandler MarkAsRead;       
        event EventHandler Print;
        event EventHandler Preview;
        event EventHandler Reply;
        event EventHandler ViewThread;
        event EventHandler Copy;

        event CustomFieldEntryClickHandler CustomFieldEntryClicked;
        event Action<SummaryLog> DetailsMarkedAsReadByToggled;


        void Clear();
        bool CancelEnabled { set; }
        bool MarkAsReadEnabled { set; }
        bool PrintEnabled { set; }
        bool PreviewEnabled { set; }

        void SetDetails(SummaryLog item, List<CustomField> customFields);

        bool ShowTreePanel { set; get; }
        bool ParentIsMissingMessageEnabled { set; }
        bool ReplyEnabled { set; }
        bool ViewThreadEnabled { set; }
        event DomainEventHandler<SummaryLogDTO> SelectedThreadItemChanged;

        List<ItemReadBy> MarkedAsReadBy { set; }

        // Added by Mukesh for RITM0218684
         event EventHandler Email;
         bool EmailEnabled { set; }
         //Amit Shukla disable copy button if no record selected 
         bool CopyButtonEnabled { set; }
    }
}
