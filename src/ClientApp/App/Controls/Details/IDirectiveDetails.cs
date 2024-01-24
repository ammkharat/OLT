using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IDirectiveDetails : IDeletableDetails
    {
        event EventHandler Expire;
        event EventHandler Clone;
        event EventHandler Print;
        event EventHandler Preview;
        event Action<Directive> MarkedAsReadByToggled;
        event Action MarkAsRead;
        event Action MarkAsNotRead;//Added by ppanigrahi


        bool PrintEnabled { set; }
        bool PrintPreviewEnabled { set; }
        bool ExpireEnabled { set; }
        bool CloneEnabled { set; }
        List<ItemReadBy> MarkedAsReadBy { set; }
        List<ItemReadBy> MarkedAsReadByUser { get; set; }
        bool MarkAsReadEnabled { set; }
        bool MarkAsReadVisible { set; }
        bool PrintButtonVisible { set; }
        bool MarkAsNotReadEnabled { set; }
        bool MarkAsNotReadVisible { set; } 




        void SetDetails(Directive directive);
        void MakeAllButtonsInvisible();
        List<ImageUploader> directiveImage { set; } //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

        bool EnableDetailImagePanel //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
        {
            get;set;
        }
        
        
    }
}