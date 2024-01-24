using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Client.Forms;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IActionItemDetails : IRespondableDetails
    {        
        event EventHandler ViewAssociatedLogs;
        event EventHandler PrintPreview;
        event EventHandler Print;
        event CustomFieldEntryClickHandler CustomFieldEntryClicked;

        bool ViewAssociatedLogsEnabled { set; }
        bool GoToDefinitionVisible { set; }
        List<ImageUploader> actionItemImage { set; } //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

        bool RespondVisible { set; }
        bool PrintEnabled { set; }
        bool PrintPreviewEnabled { set; }

        void MakeAllButtonsInvisible();

        long? AssociatedGn75BFormNumber { get; }
        event Action ViewAssociatedGN75B;

        void SetDetails(ActionItem actionItem, bool isEdmontonSite, bool HideCustomFields);     //ayman fix customfields

        //IMainForm MainParentForm { get; }

        //mangesh- DMND0005327 Request 15
        long? AssociatedGn75BFormNumber1 { get; }
        event Action ViewAssociatedGN75B1;
        long? AssociatedGn75BFormNumber2 { get; }
        event Action ViewAssociatedGN75B2;
        event Action EditAssociatedGN75B;
        event Action EditAssociatedGN75B1;
        event Action EditAssociatedGN75B2;
    }
    
    public interface IActionItemActions
    {
        event EventHandler Respond;
        bool RespondEnabled { set; }
    }
}
