using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IActionItemDefinitionFormView : IBaseForm, ICustomFieldsView           //ayman custom fields DMND0010030
    {
        DialogResult ShowFunctionalLocationSelector(List<FunctionalLocation> initialFlocSelection);
        DialogResult ShowTargetSelector();

        DialogResult ShowEmailToSelector(List<string> emails);                  //ayman action item email

        User Author { set; }
        DateTime CreateDateTime { get; set; }
        string Description { get; set;}
        string ActionItemDefinitionName { get;set;}
        ISchedule Schedule { get;set;}
        BusinessCategory Category { get;set;}
        CustomFieldGroup Customfieldgroup { get; set; }                //ayman custom fields DMND0010030
        List<string> SendEmailTo { get; set; }                //ayman custom fields DMND0010030
        bool SendEmailChecked { get; set; }                //ayman action item email

        void SendEmailControlEnabled(bool value);
        Priority Priority { get;set;}
        OperationalMode OperationalMode { get;set;}
        WorkAssignment Assignment { get; set; }

        bool RequiresApproval { get;set;}
        bool RequiresApprovalCheckBoxEnabled { set;}
        bool CreateAnActionItemForEachFunctionalLocation { get; set; }

        bool IsActiveCheckBoxEnabled { set;}
        bool IsActive { get; set; }

        bool CopyResponseToLog { get; set; } //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
        



        bool ViewEditHistoryEnabled { set; }

        bool ResponseRequired { get;set;}
        FunctionalLocation SelectedFunctionalLocation { get;}
        TargetDefinitionDTO SelectedTargetDefinitionDto { get;}
        DataSource Source { get;set;}

        IList<FunctionalLocation> UserSelectedFunctionalLocations { get; }
        List<FunctionalLocation> AssociatedFunctionalLocations { set; get; }
        List<TargetDefinitionDTO> UserSelectedTargetDefinitionDto { get;}
        List<string> UserSelectedEmailToRecipients { get; }  //ayman action item email
        List<TargetDefinitionDTO> AssociatedTargetDefinitionDto { set; get; }
        List<string> EmailToRecipients { set; get; }          //ayman action item email
        
        bool SendEmail { set; get; }
        bool AutoPopulate { set; get; }                      //ayman action item reading
        bool Reading { set; get; }                           //ayman action item reading
        bool CustomFieldComboHasValue();                     //ayman action item reading
        void EnableAutoPopulate(bool val);            //ayman action item reading
        void EnableReading(bool val);            //ayman action item reading

        List<DocumentLink> AssociatedDocumentLinks {set;get;}
        List<BusinessCategory> Categories { set; get; }
        List<CustomFieldGroup> CustomfieldGroups { set; get; }                       //ayman custom fields DMND0010030
        CustomFieldGroup selectedCustomfieldgroup { get; }
        List<WorkAssignment> WorkAssignments { set; }
        IList<OperationalMode> OperationalModes { set;}
        List<ScheduleType> ScheduleTypes { set;}

        void ClearErrorProviders();
        void ShowDescriptionIsEmptyError();
        void ShowNameIsNotUniqueError();
        void ShowNameIsEmptyError();
        void ShowNoFunctionalLocationsSelectedError();
        void ShowCategoryNotSelectedError();

        void ShowWarningMailingListExists();

        bool HasScheduleError {get;}
        
        List<Priority> Priorities { set; }

        bool NameChangeRequiresReApproval { set; }
        bool CategoryChangeRequiresReApproval { set; }
        bool OperationalModeChangeRequiresReApproval { set; }
        bool PriorityChangeRequiresReApproval { set; }
        bool DescriptionChangeRequiresReApproval { set; }
        bool DocumentLinksChangeRequiresReApproval { set; }
        bool FunctionalLocationsChangeRequiresReApproval { set; }
        bool TargetDependenciesChangeRequiresReApproval { set; }
        bool ScheduleChangeRequiresReApproval { set; }
        bool RequiresResponseWhenTriggeredChangeRequiresReApproval { set; }
        bool AssignmentChangeRequiresReApproval { set; }
        bool ActionItemGenerationModeChangeRequiresReApproval { set; }

        bool ShouldClearCurrentActionItemsForDefinitionUpdate { get; }

        void DisableBusinessCategoryComboBox();
        void DisableCustomFieldsComboBox();            //ayman custom fields DMND0010030
        void HideGn75BAssocationBox();
        long? FormGn75BId { get; set; }
        bool OperationalModeIsEnabled { set; }
        void TurnOnAutosetIndicatorsForDateTimes();

        //mangesh - DMND0005327 Request 15
        void DisplayDuplicateGN75BMessage(string message);
        long? FormGn75BId1 { get; set; }
        long? FormGn75BId2 { get; set; }

        //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

        List<ImageUploader> ImageActionItemDefdetails { set; get; }
        bool setActionItemDefImage
        {   set;}

        int oltCmbImageTypeValue
        {   set;}


        void SetErrorForAddButton();
        
         bool EnableAddButton { get; }
         string FilePathText { get; }

        bool EnableActionItemImagePanel { set; }
        
        //END
    }
}
