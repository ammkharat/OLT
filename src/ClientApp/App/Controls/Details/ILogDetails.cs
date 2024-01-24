using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface ILogDetails : IDeletableDetails, IThreadedItemDetails
    {
        event EventHandler Reply;
        event EventHandler Copy;
        event EventHandler ViewThread;
        event EventHandler MarkAsRead;
        event EventHandler Print;
        event EventHandler Preview;
        event DomainEventHandler<LogDTO> SelectedThreadItemChanged;
        event CustomFieldEntryClickHandler CustomFieldEntryClicked;
        event Action<Log> DetailsMarkedAsReadByExpand;

        bool ReplyEnabled { set; }
        bool CopyEnabled { set; }
        bool ViewThreadEnabled { set; }
        bool MarkAsReadEnabled { set; }
        bool ParentIsMissingMessageEnabled { set; }
        bool PrintEnabled { set; }
        bool PreviewEnabled { set; }

        void MakeAllButtonsInvisible();
        bool MarkAsReadVisible { set; }
        bool PrintVisible { set; }

        bool ShowTreePanel { get; set; }

        List<ItemReadBy> MarkedAsReadBy { set; }
        
        void SetDetails(Log item, List<CustomField> customFields);
        void AddMarkedAsReadUser(ItemReadBy itemReadBy);

        // Added by Mukesh for RITM0218684
        event EventHandler Email;
        bool EmailEnabled { set; }
    }
}