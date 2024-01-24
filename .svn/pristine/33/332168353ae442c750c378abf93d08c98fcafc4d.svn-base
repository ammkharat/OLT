using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IActionItemDefinitionDetails : IApprovableDetails
    {
        event EventHandler ViewAssociatedLogs;

        List<Comment> Comments { set;}
        List<FunctionalLocation> FunctionalLocations { set;}
        List<TargetDefinitionDTO> TargetDefinitionDTOs { set;}

        String EditedBy { set;}
        ISchedule Schedule { set;}
        string ActionItemDefinitionName { set;}
        bool RequiresApproval { set;}
        bool Active { set;}
        bool CopyResponseToLog { set;} //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
        
        bool ResponseRequired { set; }
        bool CreateAnActionItemForEachFunctionalLocation { set; }

        bool EveryShift { set; } //RITM0265710 mangesh

        string ActionCategory { set;}
        string CustomfieldGroup { set; }
        string WorkAssignment { set; }
        string Priority { set;}
        string OperationalMode { set;}
        string Description { set;}
        long? AssociatedGn75BFormNumber { set; get; }
        void HideGn75BAssocation();
        List<DocumentLink> DocumentLinks { set; }
        bool ViewAssociatedLogsEnabled { set; }
        event Action ViewAssociatedGN75B;

        void SetDetails(ActionItemDefinition actionItem, bool isEdmontonSite);

        //mangesh - DMND0005327 - Request15
        long? AssociatedGn75BFormNumber1 { set; get; }
        long? AssociatedGn75BFormNumber2 { set; get; }
        event Action ViewAssociatedGN75B1;
        event Action ViewAssociatedGN75B2;

        //List<ImageUploader> actionItemImage { set; } //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
        //List<ImageDownloader> actionItemImage { set; } //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
        List<ImageUploader> actionItemImage { set; } //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
        ActionItemDefinition DefinitionDetailImage { set; }

        bool ImageGridVisible { set; }
        bool ImageGridLabelVisible { set; }

		// Added By Vibhor : RITM0574870 - OLT - Clone feature created for AI definitions

        event EventHandler Clone;
        bool CloneEnabled { set; }


    }
}