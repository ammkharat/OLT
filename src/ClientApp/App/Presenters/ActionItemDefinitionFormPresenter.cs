using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Services;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using Constant = Com.Suncor.Olt.Common.Utility.Constants;
using System.IO;


namespace Com.Suncor.Olt.Client.Presenters
{

    #region DO NOT "REFACTOR" THIS CLASS, THIS IS THE GOLD STANDARD STRUCTURE FOR PRESENTERS -- Please Discuss with Ka-Wai

    public class ActionItemDefinitionFormPresenter :
        AbstractFormPresenter<IActionItemDefinitionFormView, ActionItemDefinition>
    {
        private static readonly ScheduleType[] allowedActionitemSchedules
            =
        {
            ScheduleType.Single, ScheduleType.Continuous, ScheduleType.Daily,
            ScheduleType.Weekly, ScheduleType.MonthlyDayOfMonth, ScheduleType.MonthlyDayOfWeek,
            
        };

        private readonly IActionItemService actionItemService;
        private readonly Authorized authorized = new Authorized();
        private readonly IBusinessCategoryService businessCategoryService;
        private readonly ICustomFieldService customFieldsService;                  //ayman custom fields DMND0010030
        private readonly IFormEdmontonService formService;
        private readonly IReportPrintManager<FormGN75B> reportPrintManager;
        private readonly IActionItemDefinitionService service;
        private readonly IUserService userService;
        private readonly IWorkAssignmentService workAssignmentService;
        private List<WorkAssignment> assignments;
        private List<BusinessCategory> categories;
        private List<CustomFieldGroup> customfieldgroups;                        //ayman custom fields DMND0010030
        private bool sendemail;                                  //ayman action item email
        private bool autopopulate;                            //ayman action item reading
        private List<string> emailtorecipients;                  //ayman action item email
        private ActionItemDefinition defaultActionItemDefinition;
        private bool shouldClearCurrentActionItemsOnUpdate;

        private List<string> emails;                             //ayman action item email

        public ActionItemDefinitionFormPresenter(IActionItemDefinitionFormView view)
            : this(view, null)
        {
        }

        public ActionItemDefinitionFormPresenter(
            IActionItemDefinitionFormView view,
            ActionItemDefinition editActionItemDefinition)
            : this(
                view,
                editActionItemDefinition,
                ClientServiceRegistry.Instance.GetService<IActionItemDefinitionService>(),
                ClientServiceRegistry.Instance.GetService<IBusinessCategoryService>(),
                ClientServiceRegistry.Instance.GetService<ICustomFieldService>(),                //ayman custom fields DMND0010030
                ClientServiceRegistry.Instance.GetService<IWorkAssignmentService>(),
                ClientServiceRegistry.Instance.GetService<IActionItemService>(),
                ClientServiceRegistry.Instance.GetService<IFormEdmontonService>(),
                ClientServiceRegistry.Instance.GetService<IUserService>())
           
        {
        }

        public ActionItemDefinitionFormPresenter(
            IActionItemDefinitionFormView view,
            ActionItemDefinition editActionItemDefinition,
            IActionItemDefinitionService service,
            IBusinessCategoryService businessCategoryService,
            ICustomFieldService custFieldService,                         //ayman custom fields DMND0010030
            IWorkAssignmentService workAssignmentService,
            IActionItemService actionItemService,
            IFormEdmontonService formService,
            IUserService userService)

            : base(view, editActionItemDefinition)
        {
            this.userService = userService;
            this.service = service;
            this.businessCategoryService = businessCategoryService;
            this.customFieldsService = custFieldService;                     //ayman custom fields DMND0010030
            this.workAssignmentService = workAssignmentService;
            this.actionItemService = actionItemService;
            this.formService = formService;
            defaultActionItemDefinition = GetDefaultActionItemDefinitionValue();

            if (editActionItemDefinition != null)
            emails = editActionItemDefinition.SendEmailTo; // new List<string>();                                          //ayman action item email

            PrintActions<FormGN75B, FormGN75BReport, FormGN75BReportAdapter> printActions =
                new EdmontonGN75BFormPrintActions(formService);
            reportPrintManager = new ReportPrintManager<FormGN75B, FormGN75BReport, FormGN75BReportAdapter>(printActions);
        }

        public void SetDefaultActionItemDefinitionData(ActionItemDefinition newDefaultActionItemDefinition)
        {
            defaultActionItemDefinition = newDefaultActionItemDefinition;

// Added By Vibhor : RITM0574870 - OLT - Clone feature created for AI definitions

            if (newDefaultActionItemDefinition.Isclone == true)
            {
                defaultActionItemDefinition.Schedule = null;
            }
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            view.EnableReading(false);
            view.EnableAutoPopulate(false);

            LoadData(new List<Action> {QueryCustomFields, QueryBusinessCategories, QueryWorkAssignments, QuerySendEmail });           //ayman custom fields DMND0010030
        }



        protected override void AfterDataLoad()
        {
           if(view.UserSelectedEmailToRecipients.Count > 0)
            {
                view.ShowWarningMailingListExists();
            }

            var userRoleElements = userContext.UserRoleElements;

            if (categories == null || categories.Count == 0)            
            {
                view.DisableBusinessCategoryComboBox();
            }

            //ayman custom fields DMND0010030
            if(customfieldgroups == null || customfieldgroups.Count == 1)
            {
                view.DisableCustomFieldsComboBox();
            }

            view.OperationalModeIsEnabled = userRoleElements.AuthorizedTo(RoleElement.SET_OPERATIONAL_MODES);
            view.WorkAssignments = assignments;
            view.Categories = categories;
            view.CustomfieldGroups = customfieldgroups;                            //ayman custom fields DMND0010030
            view.OperationalModes = OperationalMode.AllList;
            view.ScheduleTypes = new List<ScheduleType>(allowedActionitemSchedules);
            view.RequiresApprovalCheckBoxEnabled =
                authorized.ToToggleApprovalRequiredForActionItemDefinition(userRoleElements);
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.ActionItemDefinitionFormTitle);
            view.ViewEditHistoryEnabled = IsEdit;
            view.Priorities = new List<Priority>(ActionItemDefinition.Priorities);
            view.SendEmail = sendemail;
            view.EmailToRecipients = emailtorecipients;
            if (!userContext.IsEdmontonSite)
            {
                view.HideGn75BAssocationBox();
            }

            if (IsEdit)
            {
                UpdateViewFromEditObject();

                if (authorized.ToAutoApproveActionItemDefinition(userRoleElements) == false)
                {
                    var siteConfig = userContext.SiteConfiguration;
                    var aidConfig =
                        siteConfig.ActionItemDefinitionAutoReApprovalConfiguration;
                    view.NameChangeRequiresReApproval = aidConfig.NameChange;
                    view.CategoryChangeRequiresReApproval = aidConfig.CategoryChange;
                    view.OperationalModeChangeRequiresReApproval = aidConfig.OperationalModeChange;
                    view.PriorityChangeRequiresReApproval = aidConfig.PriorityChange;
                    view.DescriptionChangeRequiresReApproval = aidConfig.DescriptionChange;
                    view.DocumentLinksChangeRequiresReApproval = aidConfig.DocumentLinksChange;
                    view.FunctionalLocationsChangeRequiresReApproval = aidConfig.FunctionalLocationsChange;
                    view.TargetDependenciesChangeRequiresReApproval = aidConfig.TargetDependenciesChange;
                    view.ScheduleChangeRequiresReApproval = aidConfig.ScheduleChange;
                    view.RequiresResponseWhenTriggeredChangeRequiresReApproval =
                        aidConfig.RequiresResponseWhenTriggeredChange;
                    view.AssignmentChangeRequiresReApproval = aidConfig.AssignmentChange;
                    view.ActionItemGenerationModeChangeRequiresReApproval = aidConfig.ActionItemGenerationModeChange;
                }
            }
            else
            {
                UpdateViewWithDefaults();
            }
        }

        private void QueryBusinessCategories()
        {
            categories =
                businessCategoryService.QueryUniqueCategoriesByFunctionalLocationList(
                    userContext.DivisionsForSelectedFunctionalLocations);
        }

        //ayman custom fields DMND0010030
        private void QueryCustomFields()
        {
            customfieldgroups = customFieldsService.QueryBySite(userContext.Site);
            customfieldgroups.RemoveAll(fld => !fld.AppliesToActionItems);
            customfieldgroups.Add(new CustomFieldGroup(null, null, null, null, null, false, false, false, true));
            customfieldgroups.Sort(fld => fld.Name);
        }

        //ayman action item email
        private void QueryMailingList(long actionitemdefId)
        {
            emailtorecipients = service.QueryMailingList(actionitemdefId);
        }

        private void QuerySendEmail()
        {
            if(editObject != null)
            sendemail = editObject.SendEmail;
        }

        private void QueryWorkAssignments()
        {

            assignments =
                workAssignmentService.QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant(
                    userContext.RootFlocSet);

            if (IsEdit && editObject.Assignment != null && !assignments.ExistsById(editObject.Assignment))
            {
                assignments.Add(editObject.Assignment);
            }


            //ayman visibility group
            if (userContext.WriteableVisibilityGroupIds != null)
           assignments = assignments.FindAll(
           assignment =>
           assignment.WriteWorkAssignmentVisibilityGroups.Exists(
               wavg => wavg.VisibilityGroupId.IsOneOf(userContext.WriteableVisibilityGroupIds))); //userContext.ReadableVisibilityGroupIds.Contains(wavg.VisibilityGroupId)));

            //assignments.RemoveAll(
            //    assignment =>
            //        !assignment.WriteWorkAssignmentVisibilityGroups.Exists(
            //            wavg => wavg.VisibilityGroupId.IsOneOf(userContext.ReadableVisibilityGroupIds))); //userContext.ReadableVisibilityGroupIds.Contains(wavg.VisibilityGroupId)));

  
            assignments.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.CurrentCulture));
            assignments.Insert(0, WorkAssignment.NoneWorkAssignment);
        }

        protected override SaveUpdateDomainObjectContainer<ActionItemDefinition> GetPopulatedEditObjectToUpdate()
        { 
            UpdateEditActionItemDefinitionFromView();
            return new SaveUpdateDomainObjectContainer<ActionItemDefinition>(editObject);
        }

        private void UpdateEditActionItemDefinitionFromView()
        {
            editObject.Name = view.ActionItemDefinitionName;
            editObject.FunctionalLocations = view.AssociatedFunctionalLocations;
            editObject.Category = view.Category;
            editObject.Customfieldgroup = view.Customfieldgroup;     //ayman custom fields DMND0010030
            editObject.SendEmailTo = view.SendEmailTo;                   //ayman custom fields DMND0010030
            editObject.SendEmail = view.SendEmail;                   //ayman action item email
            editObject.AutoPopulate = view.AutoPopulate;             //ayman action item reading
            editObject.Reading = view.Reading;
            editObject.OperationalMode = view.OperationalMode;
            editObject.Description = view.Description;
            editObject.Active = view.IsActive;

            editObject.CopyResponseToLog = view.CopyResponseToLog; //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades

            editObject.RequiresApproval = view.RequiresApproval;
            editObject.Priority = view.Priority;

            editObject.ResponseRequired = view.ResponseRequired;
            editObject.Schedule = view.Schedule;
            editObject.TargetDefinitionDTOs = view.AssociatedTargetDefinitionDto;
            editObject.DocumentLinks = view.AssociatedDocumentLinks;
            editObject.LastModifiedBy = userContext.User;
            editObject.LastModifiedDate = view.CreateDateTime;
            editObject.Source = view.Source;
            editObject.Assignment = view.Assignment;
            editObject.CreateAnActionItemForEachFunctionalLocation = view.CreateAnActionItemForEachFunctionalLocation;
            editObject.AssociatedFormGN75BId = view.FormGn75BId;

            //mangesh- DMND0005327 - Request 15
            editObject.AssociatedFormGN75BId1 = view.FormGn75BId1;
            editObject.AssociatedFormGN75BId2 = view.FormGn75BId2;


            //Changes for SNOW Incident # INC0027574  On 19Aug2016 by Dharmesh_s
            //var authorizedToReApprove = authorized.ToAutoApproveActionItemDefinition(userContext.UserRoleElements); // commented by Dharmesh on 19Aug2016
            var authorizedToToggleApproval = authorized.ToToggleApprovalRequiredForActionItemDefinition(userContext.UserRoleElements);
            //Changes for SNOW Incident # INC0027574  On 19Aug2016 by Dharmesh_e
            var siteConfiguration = userContext.SiteConfiguration;
            var autoReApprovalConfig =
                siteConfiguration.ActionItemDefinitionAutoReApprovalConfiguration;

            var beforeChanges = service.QueryById(editObject.IdValue);
            //Changes for SNOW Incident # INC0027574  On 19Aug2016 by Dharmesh_s
            //editObject.UpdateStatusAfterChanges(authorizedToReApprove, autoReApprovalConfig, beforeChanges); // commented by Dharmesh on 19Aug2016
            editObject.UpdateStatusAfterChanges(authorizedToToggleApproval, autoReApprovalConfig, beforeChanges);
            //Changes for SNOW Incident # INC0027574  On 19Aug2016 by Dharmesh_e

            //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
            editObject.Imagelist = UpoloadFileandUpdatePath(view.ImageActionItemDefdetails, editObject); //view.ImageLogdetails;
        }

        private void PopulateView
            (
            DateTime createDateTime,
            string actionItemDefinitionName,
            string description,
            OperationalMode operationalMode,
            Priority priority,
            bool requiresApproval,
            bool isActive,
            bool copyResponseLog, //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
            List<FunctionalLocation> associatedFunctionalLocations,
            ISchedule schedule,
            bool responseRequired,
            List<TargetDefinitionDTO> associatedTargetDefinitionDtos,
            List<DocumentLink> associatedDocumentLinks,
            User author,
            DataSource source,
            BusinessCategory businessCategory,
            CustomFieldGroup customfieldgroup,     //ayman custom fields DMND0010030
            List<string> sendemailTo,                        //ayman custom fields DMND0010030
            bool sendemail,
            bool autopopulate,                              //ayman action item reading
            bool reading,                              //ayman action item reading
            WorkAssignment workAssignment,
            bool createAnActionItemForEachFunctionalLocation,
            long? formGn75B
            )
        {
            view.Author = author;
            view.CreateDateTime = createDateTime;
            view.ActionItemDefinitionName = actionItemDefinitionName;
            view.Description = description;

            view.OperationalMode = operationalMode;
            view.Priority = priority;
            view.RequiresApproval = requiresApproval;
            view.IsActive = isActive;
            view.CopyResponseToLog = copyResponseLog; //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
            view.AssociatedFunctionalLocations = associatedFunctionalLocations;
            view.Schedule = schedule;
            view.ResponseRequired = responseRequired;
            view.AssociatedTargetDefinitionDto = associatedTargetDefinitionDtos;
            view.AssociatedDocumentLinks = associatedDocumentLinks;
            view.Source = source;
            view.Assignment = workAssignment;
            view.Customfieldgroup = customfieldgroup;              //ayman custom fields DMND0010030
            view.SendEmailTo = sendemailTo;                            //ayman custom fields DMND0010030
            view.SendEmail = sendemail;                             //ayman action item email
            view.AutoPopulate = autopopulate;                       //ayman action item reading
            view.Reading = reading;                       //ayman action item reading
            view.CreateAnActionItemForEachFunctionalLocation = createAnActionItemForEachFunctionalLocation;

            view.FormGn75BId = formGn75B;

            EnableDisableActiveCheckBox(requiresApproval);
            SetBusinessCategory(businessCategory);
            SetCustomFieldGroup(customfieldgroup);           //ayman custom fields DMND0010030

        }

        //mangesh - DMND0005327 - Request 15 (added formGn75B1 and formGn75B2)
        private void PopulateView
            (
            DateTime createDateTime,
            string actionItemDefinitionName,
            string description,
            OperationalMode operationalMode,
            Priority priority,
            bool requiresApproval,
            bool isActive,
            bool copyResponseLog, //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
            List<FunctionalLocation> associatedFunctionalLocations,
            ISchedule schedule,
            bool responseRequired,
            List<TargetDefinitionDTO> associatedTargetDefinitionDtos,
            List<DocumentLink> associatedDocumentLinks,
            User author,
            DataSource source,
            BusinessCategory businessCategory,
            WorkAssignment workAssignment,
            bool createAnActionItemForEachFunctionalLocation,
            long? formGn75B,
            long? formGn75B1,
            long? formGn75B2
            )
        {
            view.Author = author;
            view.CreateDateTime = createDateTime;
            view.ActionItemDefinitionName = actionItemDefinitionName;
            view.Description = description;

            view.OperationalMode = operationalMode;
            view.Priority = priority;
            view.RequiresApproval = requiresApproval;
            view.IsActive = isActive;
            view.CopyResponseToLog = copyResponseLog; //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
            view.AssociatedFunctionalLocations = associatedFunctionalLocations;
            view.Schedule = schedule;
            view.ResponseRequired = responseRequired;
            view.AssociatedTargetDefinitionDto = associatedTargetDefinitionDtos;
            view.AssociatedDocumentLinks = associatedDocumentLinks;
            view.Source = source;
            view.Assignment = workAssignment;

            view.CreateAnActionItemForEachFunctionalLocation = createAnActionItemForEachFunctionalLocation;

            view.FormGn75BId = formGn75B;
            view.FormGn75BId1 = formGn75B1;
            view.FormGn75BId2 = formGn75B2;

            EnableDisableActiveCheckBox(requiresApproval);
            SetBusinessCategory(businessCategory);
        }

        private void UpdateViewWithDefaults()
        {
            SetLastUsedWorkAssignmentForSitesThatRemember();

            PopulateView
                (
                    defaultActionItemDefinition.LastModifiedDate,
                    defaultActionItemDefinition.Name,
                    defaultActionItemDefinition.Description,
                    defaultActionItemDefinition.OperationalMode,
                    defaultActionItemDefinition.Priority,
                    defaultActionItemDefinition.RequiresApproval,
                    defaultActionItemDefinition.Active,
                    defaultActionItemDefinition.CopyResponseToLog, //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
                    defaultActionItemDefinition.FunctionalLocations,
                    defaultActionItemDefinition.Schedule,
                    defaultActionItemDefinition.ResponseRequired,
                    defaultActionItemDefinition.TargetDefinitionDTOs,
                    defaultActionItemDefinition.DocumentLinks,
                    defaultActionItemDefinition.LastModifiedBy,
                    defaultActionItemDefinition.Source,
                    defaultActionItemDefinition.Category,
             //       defaultActionItemDefinition.Customfieldgroup,
                    defaultActionItemDefinition.Assignment,
                    defaultActionItemDefinition.CreateAnActionItemForEachFunctionalLocation,
                    defaultActionItemDefinition.AssociatedFormGN75BId,

                    defaultActionItemDefinition.AssociatedFormGN75BId1, //mangesh - DMND0005327 - Request 15
                    defaultActionItemDefinition.AssociatedFormGN75BId2
                );

            //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

            if (ClientSession.GetUserContext().SiteConfiguration.EnableActionItemImage)
            {
                view.setActionItemDefImage = true;//.SiteConfiguration.EnableLogImage;
                List<ImageUploader> lst = new List<ImageUploader>();
                view.ImageActionItemDefdetails = lst;
                view.EnableActionItemImagePanel = true;
            }
            else
            {
                view.EnableActionItemImagePanel = false;
            }

            view.CopyResponseToLog = true; //INC0558851:Action Item Definitions - Copy Response to Log:Aarti

            //if (ClientSession.GetUserContext().SiteConfiguration.RequireLogForActionItemResponse)
            //{
            //    view.CopyResponseToLog = true;
            //  //  defaultActionItemDefinition.CopyResponseToLog.c

            //    //copyResponsetoLog.Checked = true;
            //   // CopyResponseToLogVisible = false;
            //}
            //else
            //{
            //    view.CopyResponseToLog = true;
            //    //copyResponsetoLog.Checked = value;
            //   // CopyResponseToLogVisible = true;
            //}
        }

        private void SetLastUsedWorkAssignmentForSitesThatRemember()
        {
            var siteConfig = userContext.SiteConfiguration;
            if (siteConfig.RememberActionItemWorkAssignment)
            {
                var actionItemDefinitionLastUsedWorkAssignmentId =
                    userContext.User.UserPreferences.ActionItemDefinitionLastUsedWorkAssignmentId;
                if (actionItemDefinitionLastUsedWorkAssignmentId.HasValue && actionItemDefinitionLastUsedWorkAssignmentId.Value != 0)
                {
                    view.TurnOnAutosetIndicatorsForDateTimes();
                    var workAssignment =
                        workAssignmentService.QueryById(actionItemDefinitionLastUsedWorkAssignmentId.Value);
                    defaultActionItemDefinition.Assignment = workAssignment;
                }
            }
        }

        private void SetBusinessCategory(BusinessCategory businessCategory)
        {
            if (businessCategory != null && !categories.ExistsById(businessCategory))
            {
                businessCategory = null;
            }

            view.Category = businessCategory;
        }

        //ayman custom fields DMND0010030
        private void SetCustomFieldGroup(CustomFieldGroup customfieldGroup)
        {
            if (customfieldGroup != null && !customfieldgroups.ExistsById(customfieldGroup))
            {
                customfieldGroup = null;
            }

            view.Customfieldgroup = customfieldGroup;
        }

        private void UpdateViewFromEditObject()
        {
            PopulateView
                (
                    editObject.LastModifiedDate,
                    editObject.Name,
                    editObject.Description,
                    editObject.OperationalMode,
                    editObject.Priority,
                    editObject.RequiresApproval,
                    editObject.Active,
                    editObject.CopyResponseToLog, //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
                    editObject.FunctionalLocations,
                    editObject.Schedule,
                    editObject.ResponseRequired,
                    editObject.TargetDefinitionDTOs,
                    editObject.DocumentLinks,
                    editObject.LastModifiedBy,
                    editObject.Source,
                    editObject.Category,
                    editObject.Customfieldgroup,
                    editObject.SendEmailTo,
                    editObject.SendEmail,
                    editObject.AutoPopulate,                //ayman action item reading
                    editObject.Reading,
                    editObject.Assignment,
                    editObject.CreateAnActionItemForEachFunctionalLocation,
                    editObject.AssociatedFormGN75BId

                );

            view.oltCmbImageTypeValue = 0;
            //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
            if (ClientSession.GetUserContext().SiteConfiguration.EnableActionItemImage)
            {


                if (editObject.Source == DataSource.MANUAL)
                {
                    view.ImageActionItemDefdetails = editObject.Imagelist;
                    view.setActionItemDefImage = true; //userContext.SiteConfiguration.EnableLogImage;
                    view.EnableActionItemImagePanel = true;
                }
                else
                {
                    view.setActionItemDefImage = false;
                }
            }
            else
            {
                view.EnableActionItemImagePanel = false;
            }

        }

        public void HandleRemoveTargetButtonClick(object sender, EventArgs e)
        {
            var dto = view.SelectedTargetDefinitionDto;

            if (dto != null)
            {
                var associationedTargetDefinitionDtos = view.AssociatedTargetDefinitionDto;
                associationedTargetDefinitionDtos.Remove(dto);
                var newAssociatedTargetDefinitionDtos =
                    new List<TargetDefinitionDTO>(associationedTargetDefinitionDtos);
                view.AssociatedTargetDefinitionDto = newAssociatedTargetDefinitionDtos;
            }
        }

        public void HandleRemoveFlocButtonClick(object sender, EventArgs e)
        {
            var floc = view.SelectedFunctionalLocation;

            if (floc != null)
            {
                var associatedFlocs = view.AssociatedFunctionalLocations;
                associatedFlocs.Remove(floc);
                var newAssociatedFlocs =
                    new List<FunctionalLocation>(associatedFlocs);

                view.AssociatedFunctionalLocations = newAssociatedFlocs;
            }
        }

        public void HandleSelectFormGn75BButtonClicked(object sender, EventArgs eventArgs)
        {
            //var details = new FormEdmontonGN75BDetails();

            //var formPage =
            //    new FormPage<FormEdmontonGN75BDTO, FormEdmontonGN75BDetails>(new FormEdmontonGN75BGridRenderer(),
            //        details);
            //var presenter = new SelectFormGN75BFormPresenter(formPage);
            //// this has to be here because something in the Form Page or Presenter is setting RangeVisible to true. 
            //// So set to false afterwards.
            //details.RangeVisible = false;

            //var formId = view.FormGn75BId;

            //var dialogResultAndOutput = presenter.Run(view, formId);

            //if (dialogResultAndOutput.Result == DialogResult.OK)
            //{
            //    var formDto = dialogResultAndOutput.Output;
            //    view.FormGn75BId = formDto.Id;
            //}

            //DMND0005327 - Request 15
            //mangesh- comment above code and added below
            //as three buttons using same function

            var details = new FormEdmontonGN75BDetails("Form #","Location");     //ayman Sarnia eip

            var formPage =
                new FormPage<FormEdmontonGN75BDTO, FormEdmontonGN75BDetails>(new FormEdmontonGN75BGridRenderer(),
                    details);
            var presenter = new SelectFormGN75BFormPresenter(formPage);
            // this has to be here because something in the Form Page or Presenter is setting RangeVisible to true. 
            // So set to false afterwards.
            details.RangeVisible = false;

            Button button = (Button)sender;
            switch (button.Name)
            {
                case "selectFormGN75BButton":
                    var formId = view.FormGn75BId;
                    var dialogResultAndOutput = presenter.Run(view, formId);
                    if (dialogResultAndOutput.Result == DialogResult.OK)
                    {
                        var formDto = dialogResultAndOutput.Output;
                        view.FormGn75BId = formDto.Id;
                        if ((view.FormGn75BId == view.FormGn75BId1) || (view.FormGn75BId == view.FormGn75BId2))
                        {
                            DuplicateFormGN75B(Convert.ToString(formDto.Id));
                            view.FormGn75BId = null;
                        }
                    }
                    break;

                case "selectFormGN75BButton1":
                    var formId1 = view.FormGn75BId1;
                    var dialogResultAndOutput1 = presenter.Run(view, formId1);
                    if (dialogResultAndOutput1.Result == DialogResult.OK)
                    {
                        var formDto1 = dialogResultAndOutput1.Output;
                        view.FormGn75BId1 = formDto1.Id;
                        if ((view.FormGn75BId1 == view.FormGn75BId) || (view.FormGn75BId1 == view.FormGn75BId2))
                        {
                            DuplicateFormGN75B(Convert.ToString(formDto1.Id));
                            view.FormGn75BId1 = null;
                        }
                    }
                    break;

                case "selectFormGN75BButton2":
                    var formId2 = view.FormGn75BId2;
                    var dialogResultAndOutput2 = presenter.Run(view, formId2);
                    if (dialogResultAndOutput2.Result == DialogResult.OK)
                    {
                        var formDto2 = dialogResultAndOutput2.Output;
                        view.FormGn75BId2 = formDto2.Id;
                        if ((view.FormGn75BId2 == view.FormGn75BId) || (view.FormGn75BId2 == view.FormGn75BId1))
                        {
                            DuplicateFormGN75B(Convert.ToString(formDto2.Id));
                            view.FormGn75BId2 = null;
                        }
                    }
                    break;
            }
        }

        private void DuplicateFormGN75B(string value)
        {
            view.DisplayDuplicateGN75BMessage(value);
        }

        public void HandleFunctionalLocationButtonClick(object sender, EventArgs e)
        {
            var currentFlocSelection = view.AssociatedFunctionalLocations;
            var result = view.ShowFunctionalLocationSelector(currentFlocSelection);
            if (result == DialogResult.OK)
            {
                var newFlocSelection = view.UserSelectedFunctionalLocations;
                view.AssociatedFunctionalLocations = newFlocSelection == null
                    ? new List<FunctionalLocation>()
                    : new List<FunctionalLocation>(newFlocSelection);
            }
        }

        public void HandleViewEditHistoryButtonClicked(object sender, EventArgs e)
        {
            var presenter =
                new EditActionItemDefinitionHistoryFormPresenter(editObject);
            presenter.Run(view);
        }


        //ayman action item reading
        public void HandleCustomFieldComboBoxSelectedChanged(object sender, EventArgs e)
        {
            if(view.CustomFieldComboHasValue())
            {
                view.EnableAutoPopulate(true);
                view.EnableReading(true);
            }
            else
            {
                view.AutoPopulate = false;
                view.Reading = false;
                view.EnableAutoPopulate(false);
                view.EnableReading(false);
            }
        }

        public void HandleRequiresApprovalCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            EnableDisableActiveCheckBox(view.RequiresApproval);
        }

        private void EnableDisableActiveCheckBox(bool requiresApproval)
        {
            if (requiresApproval)
            {
                view.IsActive = false;
                view.IsActiveCheckBoxEnabled = false;
            }
            else
            {
                view.IsActiveCheckBoxEnabled = true;
            }
        }

        //ayman action item email
        public void HandleEmailToClicked(object sender, EventArgs e)
        {
                var result = view.ShowEmailToSelector(view.UserSelectedEmailToRecipients);
                if (result == DialogResult.OK)
                {
                    view.EmailToRecipients = view.UserSelectedEmailToRecipients;
                }
        }

        public void HandleLinkTargetDefinitionButtonClick(object sender, EventArgs e)
        {
            var result = view.ShowTargetSelector();
            if (result == DialogResult.OK)
            {
                view.AssociatedTargetDefinitionDto = view.UserSelectedTargetDefinitionDto;
            }
        }

        private ActionItemDefinition GetDefaultActionItemDefinitionValue()
        {
            var siteConfig = userContext.SiteConfiguration;

            var requiresApprovalByDefault = siteConfig.ActionItemRequiresApprovalDefaultValue;
            var responseRequired = siteConfig.ActionItemRequiresResponseDefaultValue;

            var lastModifiedDate = Clock.Now;
            var name = string.Empty;
            var description = string.Empty;
            var operationalMode = OperationalMode.Normal;
            var active = false;
            var functionalLocations = new List<FunctionalLocation>();
            const ISchedule schedule = null;
            var targetDefinitionDtos = new List<TargetDefinitionDTO>();
            var documentLinks = new List<DocumentLink>();
            var lastModifiedBy = userContext.User;
            var source = DataSource.MANUAL;
            ActionItemDefinitionStatus status = null;

            if (!requiresApprovalByDefault)
            {
                status = ActionItemDefinitionStatus.Approved;
                active = true;
            }

            var defaultDefinition = new ActionItemDefinition(name,
                null,
                status,
                schedule,
                description,
                source,
                requiresApprovalByDefault,
                active,

                responseRequired,
                lastModifiedBy,
                lastModifiedDate,
                lastModifiedBy,
                lastModifiedDate,
                functionalLocations,
                targetDefinitionDtos,
                documentLinks,
                operationalMode,
                null,
                false,
                null,null,null,false,false,false,null);            //ayman visibility groups       //ayman custom fields DMND0010030
            if (requiresApprovalByDefault)
            {
                defaultDefinition.WaitForApproval();
            }

            return defaultDefinition;
        }


        public void HandleViewGn75BButtonClicked(object sender, EventArgs e)
        {
            //var formGn75BId = view.FormGn75BId;
            //if (!formGn75BId.HasValue)
            //    return;

            //var formGn75B = formService.QueryFormGN75BById(formGn75BId.Value);
            //reportPrintManager.PreviewReport(formGn75B);

            //mangesh comment above code and put a new code for DMND0005327 - Request15
            Button b = (Button)sender;
            switch (b.Name)
            {
                case "viewGN75BFormButton":
                    var formGn75BId = view.FormGn75BId;
                    if (!formGn75BId.HasValue)
                        return;

                    var formGn75B = formService.QueryFormGN75BById(formGn75BId.Value);
                    reportPrintManager.PreviewReport(formGn75B);
                    break;

                case "viewGN75BFormButton1":
                    var formGn75BId1 = view.FormGn75BId1;
                    if (!formGn75BId1.HasValue)
                        return;

                    var formGn75B1 = formService.QueryFormGN75BById(formGn75BId1.Value);
                    reportPrintManager.PreviewReport(formGn75B1);
                    break;

                case "viewGN75BFormButton2":
                    var formGn75BId2 = view.FormGn75BId2;
                    if (!formGn75BId2.HasValue)
                        return;

                    var formGn75B2 = formService.QueryFormGN75BById(formGn75BId2.Value);
                    reportPrintManager.PreviewReport(formGn75B2);
                    break;
            }
        }

        public void HandleRemoveGn75BButtonClicked(object sender, EventArgs e)
        {
            //view.FormGn75BId = null;


            //mangesh DMND0005327 - Request15
            Button b = (Button)sender;
            switch (b.Name)
            {
                case "removeFormGN75BButton":
                    view.FormGn75BId = null;
                    break;

                case "removeFormGN75BButton1":
                    view.FormGn75BId1 = null;
                    break;

                case "removeFormGN75BButton2":
                    view.FormGn75BId2 = null;
                    break;
            }
        }

        #region Implementing Abstract Presenter methods

        public override bool ValidateViewHasError()
        {
            view.ClearErrorProviders();

            var hasError = false;

            //if(view.SendEmailTo.Count > 0)
            //{
            //    view.ShowWarningMailingListExists();
            //}

            if (view.Categories.Count > 0 && view.Category == null)
            {
                view.ShowCategoryNotSelectedError();
                hasError = true;
            }

            if (view.Description.IsNullOrEmptyOrWhitespace())
            {
                view.ShowDescriptionIsEmptyError();
                hasError = true;
            }

            if (view.ActionItemDefinitionName.IsNullOrEmptyOrWhitespace())
            {
                view.ShowNameIsEmptyError();
                hasError = true;
            }

            if (!(view.AssociatedFunctionalLocations != null &&
                  view.AssociatedFunctionalLocations.Count > 0))
            {
                view.ShowNoFunctionalLocationsSelectedError();
                hasError = true;
            }

            var userSiteId = userContext.SiteId;

            var count = service.GetCountOfSAPSourced(view.ActionItemDefinitionName, userSiteId);

            if ((editObject == null && count > 0) ||
                (editObject != null && view.ActionItemDefinitionName != editObject.Name && count > 0))
            {
                view.ShowNameIsNotUniqueError();
                hasError = true;
            }

            if (view.HasScheduleError)
            {
                hasError = true;
            }

            if (view.EnableAddButton && view.FilePathText != string.Empty)
            {
                view.SetErrorForAddButton();
                hasError = true;
            }

            return hasError;
        }

        public override void Insert(SaveUpdateDomainObjectContainer<ActionItemDefinition> itemToInsert)
        {
            var siteConfig = userContext.SiteConfiguration;
            if (siteConfig.RememberActionItemWorkAssignment && itemToInsert.Item != null)
            {
                userContext.User.UserPreferences.ActionItemDefinitionLastUsedWorkAssignmentId =
                    itemToInsert.Item.Assignment != null && itemToInsert.Item.Assignment.Id.HasValue
                        ? itemToInsert.Item.Assignment.IdValue
                        : 0;
                userService.UpdateUserPreferences(userContext.User);
            }
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Insert,itemToInsert.Item);

        }

        protected override SaveUpdateDomainObjectContainer<ActionItemDefinition> GetNewObjectToInsert()
        {
            //List<CustomFieldEntry> customFieldEntries = view.CopyFromView(customFields);

            var now = Clock.Now;
            var actionItemDefinition =
                new ActionItemDefinition(view.ActionItemDefinitionName,
                    view.Category,
                    ActionItemDefinitionStatus.GetStatusBasedOnRequiresApproval(view.RequiresApproval),
                    view.Schedule,
                    view.Description.TrimOrEmpty(),
                    view.Source,
                    view.RequiresApproval,
                    view.IsActive,
                    view.CopyResponseToLog, //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
                    view.ResponseRequired,
                    userContext.User,
                    now,
                    userContext.User,
                    now,
                    view.AssociatedFunctionalLocations,
                    view.AssociatedTargetDefinitionDto,
                    view.AssociatedDocumentLinks,
                    view.OperationalMode,
                    view.Assignment,
                    view.CreateAnActionItemForEachFunctionalLocation,
                    view.FormGn75BId,
                    view.FormGn75BId1,
                    view.FormGn75BId2,
                    ClientSession.GetUserContext().Assignment == null ? ClientSession.GetUserContext().ReadableVisibilityGroupIds.BuildCommaSeparatedList() : ClientSession.GetUserContext().Assignment.WriteWorkAssignmentVisibilityGroups.ConvertAll(a => a.VisibilityGroupId).ToArray().BuildCommaSeparatedList(),
                    view.Customfieldgroup,view.SendEmail,view.AutoPopulate,view.Reading,view.EmailToRecipients, false){ Priority = view.Priority }; //mangesh - DMDN0005327- Request 15 (added FormGn75BId1 and FormGn75BId2)    //ayman visibility groups
            //customFieldEntries,customFields

//RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
            actionItemDefinition.Imagelist = UpoloadFileandUpdatePath(view.ImageActionItemDefdetails, actionItemDefinition);

            return new SaveUpdateDomainObjectContainer<ActionItemDefinition>(actionItemDefinition);
        }

     protected override void DoPreSaveOrUpdateWorkBeforeShowingWaitForm(
            SaveUpdateDomainObjectContainer<ActionItemDefinition> container)
        {
            base.DoPreSaveOrUpdateWorkBeforeShowingWaitForm(container);

            var actionItemDefinition = container.Item;

         //Email Issue--Aarti
            //if(actionItemDefinition.SendEmail && actionItemDefinition.SendEmailTo.Count == 0)
            //{
            //    actionItemDefinition.SendEmailTo.Add(actionItemDefinition.LastModifiedBy.Username);
            //}

            if (IsEdit)
            {
                shouldClearCurrentActionItemsOnUpdate = false;

                if (actionItemDefinition.IsApproved && actionItemDefinition.Active &&
                    actionItemService.CurrentActionItemsExistForActionItemDefinition(actionItemDefinition, Clock.Now))
                {
                    shouldClearCurrentActionItemsOnUpdate = view.ShouldClearCurrentActionItemsForDefinitionUpdate;
                }
            }
        }

        public override void Update(SaveUpdateDomainObjectContainer<ActionItemDefinition> container)
        {
            var actionItemDefinition = container.Item;

            if (shouldClearCurrentActionItemsOnUpdate)
            {
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                    service.UpdateAndClearCurrentActionItems,
                    actionItemDefinition);
            }
            else
            {
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update,
                    actionItemDefinition);
            }
        }

        #endregion

        //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

        public List<ImageUploader> UpoloadFileandUpdatePath(List<ImageUploader> lstImages, ActionItemDefinition log)
        {
            foreach (ImageUploader Img in lstImages)
            {
                if (Img.Id == 0 && Img.Action != "Remove")
                {
                    if (ClientSession.GetUserContext().SiteConfiguration.LogImagePath != null)
                    {
                        if (File.Exists(Img.ImagePath))
                        {
                            string fileName = userContext.SiteConfiguration.LogImagePath + "\\" +  ClientSession.GetUserContext().User.Username + "-" + Clock.Now.ToString("yyyyMMddTHHmmss") + "-" + Path.GetFileName(Img.ImagePath);
                            
                            File.Copy(Img.ImagePath, fileName, true);
                            Img.ImagePath = fileName;
                        }
                    }

                }


            }
            return lstImages;
        }
    }

    #endregion
}