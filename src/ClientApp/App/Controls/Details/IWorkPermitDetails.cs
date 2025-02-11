using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IWorkPermitDetails : IApprovableDetails
    {
        event EventHandler Copy;
        event EventHandler Clone;
        event EventHandler Print;
        event EventHandler PrintPreview;
        event EventHandler CloseWorkPermit;

        event EventHandler RefreshAll;
        event EventHandler SetFilter;
        //Added by ppanigrahi
        event EventHandler Extension;
        event EventHandler Revalidation;

        List<AcidClothingType> SpecialProtectiveClothingTypeAcidClothingTypeChoices { set; }

        List<GasTestElementResultDTO> GasTestElementResults { set; }
        void SetRequiredSpecialPrecautionsComments();
        List<DocumentLink> DocumentLinks { set;}

        User Author { set; }
        User Approver { set; }
        User LastModifier { set; }
        bool RefreshAllEnabled { set;}

        Version WorkPermitVersion { set; }
        IWorkPermitDetails BindingTarget { get; }

        bool CloseEnabled { set; }
        bool CopyEnabled { set; }
        bool CloneEnabled { set; }
        bool PrintEnabled { set; }
        bool PrintPreviewEnabled { set; }
        //Added by ppanigrahi
        bool ExtensionEnable { set; }
        bool RevalidationButtonEnable { set; }
        bool ToolStripEnabled {set; }

        ToolStripButton SaveGridLayoutButton { get; } // This is because the subclasses of this interface don't implement AbstractDetails like all the other details.

        // DMND0010609-OLT - Edmonton Work permit Scan
        bool ViewAttachEnabled { set; }
        event EventHandler ViewAttachment;
        bool ViewScanEnabled { set; }
        void MakeSeachWindowRequiredButtonsvisibleonly();
			//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        bool MarkTemplateEnabled { set; }
        bool UnMarkTemplateEnabled { set; }
        
        event EventHandler MarkAsTemplate;
        event EventHandler UnMarkTemplate;

        bool DeleteVisible { set; }
        bool editVisible { set; }
        bool closeButtonVisible { set; }
        bool printButtonVisible { set; }
        bool printPreviewButtonVisible { set; }
        bool editHistoryButtonVisible { set; }

        bool approveButtonVisible { set; }
        bool ScanbuttonButtonVisible { get; set; }
        bool rejectButtonVisible { set; }
        bool commentButtonVisible { set; }
        bool copyButtonVisible { set; }
        bool ExtensionButtonVisible { set; }
        bool revalidationButtonVisible { set; }
        bool viewAttachementbuttonVisible { set; }
        
    }
}
