using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IFormEdmontonDetails : IDeletableDetails
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
         /*RITM0265746 - Sarnia CSD marked as read start*/
        bool MarkAsReadEnabled { set; } //mark as read button, which is placed below grid control
        bool MarkAsReadVisible { set; } //mark as read button, which is placed below grid control
        event Action MarkAsRead;
        event Action MarkedAsReadByToggled;
        List<ItemReadBy> MarkedAsReadBy { set; } //list shown in detais below grid control
        bool MarkedAsReadToggleCollaps { set; } //expand and collaps button for mark as read data 
       
        /*RITM0265746 - Sarnia CSD marked as read End*/

        //DMND0010261-SELC CSD EdmontonPipeline
        bool IsTheCSDForSCADAeDataLabel { get; set; }
    }
}