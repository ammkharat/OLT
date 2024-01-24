using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Clock = Com.Suncor.Olt.Common.Utility.Clock;
using Constant = Com.Suncor.Olt.Common.Utility.Constants;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class LogDefinitionFormPresenter : AbstractFormPresenter<ILogDefinitionFormView, LogDefinition>
    {
        private readonly static ScheduleType[] ALLOWED_LOGITEM_SCHEDULES
            = { ScheduleType.Daily, ScheduleType.Weekly, ScheduleType.MonthlyDayOfMonth, ScheduleType.MonthlyDayOfWeek };

        public static readonly string EDIT_LOG_DEFINITION_TITLE = StringResources.LogDefinitionEditPageTitle;
        public static readonly string CREATE_LOG_DEFINITION_TITLE = StringResources.LogDefinitionCreatePageTitle;
        public static readonly string EDIT_STANDING_ORDER_TITLE = StringResources.StandingOrderEditPageTitle;
        public static readonly string CREATE_STANDING_ORDER_TITLE = StringResources.StandingOrderCreatePageTitle;

        private readonly IAuthorized authorized;
        private readonly ILogDefinitionService service;        
        private readonly ILogService logService;
        private readonly ICustomFieldService customFieldService;
        private readonly IFunctionalLocationService functionalLocationService;
        private readonly ISiteConfigurationService siteConfigurationService;

        private List<CustomField> customFields = new List<CustomField>();
        private readonly bool isRepeatingLog;  // as opposed to standing order

        private readonly LogTemplatePresenterHelper logTemplatePresenterHelper;

        public LogDefinitionFormPresenter(ILogDefinitionFormView view, LogDefinition editLog, bool isRepeatingLog) : this(
            view, 
            editLog,
            ClientServiceRegistry.Instance.GetService<ILogDefinitionService>(),
            ClientServiceRegistry.Instance.GetService<ILogService>(),
            ClientServiceRegistry.Instance.GetService<ICustomFieldService>(),
            ClientServiceRegistry.Instance.GetService<ILogTemplateService>(),
            ClientServiceRegistry.Instance.GetService<IFunctionalLocationService>(),
            ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>(),
            isRepeatingLog)
        {
        }

        public LogDefinitionFormPresenter(
            ILogDefinitionFormView view, 
            LogDefinition editLog,
            ILogDefinitionService service,
            ILogService logService,
            ICustomFieldService customFieldService,
            ILogTemplateService logTemplateService,
            IFunctionalLocationService functionalLocationService,
            ISiteConfigurationService siteConfigurationService,
            bool isRepeatingLog) : base(view, editLog)
        {
            authorized = new Authorized();
            this.service = service;
            this.logService = logService;
            this.customFieldService = customFieldService;
            this.functionalLocationService = functionalLocationService;
            this.siteConfigurationService = siteConfigurationService;

            this.isRepeatingLog = isRepeatingLog;
            LogTemplate.LogType logType = isRepeatingLog ? LogTemplate.LogType.Standard : LogTemplate.LogType.DailyDirective;
            logTemplatePresenterHelper = new LogTemplatePresenterHelper(view, logTemplateService, userContext.Assignment, logType);
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            LoadData(new List<Action> { LoadCustomFieldsFromDatabase, logTemplatePresenterHelper.QueryLogTemplates});
        }

        protected override void AfterDataLoad()
        {
            SiteConfiguration siteConfiguration = userContext.SiteConfiguration;
            view.ScheduleTypes = new List<ScheduleType>(ALLOWED_LOGITEM_SCHEDULES);

            if (!siteConfiguration.ShowFollowupOnLogForm)
            {
                view.HideFollowupFlags();
            }

            if (!siteConfiguration.AllowCreateALogForEachSelectedFlocOnLogForm)
            {
                view.HideMultipleFunctionalLocationOptions();
            }

            view.ViewEditHistoryEnabled = IsEdit;
            view.ExpandAdditionalDetails = siteConfiguration.ShowAdditionalDetailsOnLogFormByDefault;

            view.OperatingEngineerLogDisplayName = siteConfiguration.OperatingEngineerLogDisplayName;

            if (IsEdit)
            {
                view.HideFunctionalLocationButtonsAndDisableMultipleFunctionalLocationOptions();
                UpdateViewFromEditObject();
                view.MultipleFunctionalLocationOptionsEnabled = false;
            }
            else
            {
                UpdateViewWithDefaults();
                view.Title = isRepeatingLog ? CREATE_LOG_DEFINITION_TITLE : CREATE_STANDING_ORDER_TITLE;
                view.Author = userContext.User;
                view.MultipleFunctionalLocationOptionsEnabled = true;
                view.LastModifiedDateTime = Clock.Now;

                if (isRepeatingLog && authorized.ToEditLogDefinitionsFlaggedAsOperatingEngineerLog(userContext.UserRoleElements))
                {
                    view.IsOperatingEngineerLog = true;
                }
            }

            if (isRepeatingLog && siteConfiguration.CreateOperatingEngineerLogs)
            {
                view.OptionsSectionHidden = false;
                view.IsInactiveCheckboxHidden = true;
                view.IsOperatingEngineerLogCheckboxHidden = false;
            }
            else if (isRepeatingLog && !siteConfiguration.CreateOperatingEngineerLogs)
            {
                view.OptionsSectionHidden = true;
                view.IsOperatingEngineerLog = false;
            }

            if (!isRepeatingLog)
            {
                view.OptionsSectionHidden = false;
                view.IsOperatingEngineerLogCheckboxEnabled = false;
                view.IsInactiveCheckboxHidden = false;
                view.IsOperatingEngineerLogCheckboxHidden = true;
            }

            logTemplatePresenterHelper.LoadLogTemplates(IsEdit);

            view.TurnOffCustomFieldPhTagHighlights();
        }

        private void LoadCustomFieldsFromDatabase()
        {
            if (IsEdit)
            {
                customFields = new List<CustomField>(editObject.CustomFields);
            }
            else
            {
                customFields = isRepeatingLog
                                   ? customFieldService.QueryOrderedFieldsByWorkAssignmentForLogs(userContext.Assignment)
                                   : customFieldService.QueryOrderedFieldsByWorkAssignmentForDailyDirectives(userContext.Assignment);
            }
        }

        protected void UpdateViewWithDefaults()
        {
            if (ClientSession.GetUserContext().SiteConfiguration.DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders)
            {
                List<FunctionalLocation> selectedFunctionalLocations = ClientSession.GetUserContext().RootsForSelectedFunctionalLocations;
                const FunctionalLocationType flocSelectionLevel = FunctionalLocationType.Level3;
                view.FunctionalLocationData = functionalLocationService.GetDefaultFLOCs(flocSelectionLevel, selectedFunctionalLocations);               
            }
            else
            {
                view.FunctionalLocationData = new List<FunctionalLocation>();
            }
                                           
            view.AssociatedDocumentLinks = new List<DocumentLink>();
            view.SetCustomFieldEntries(customFields.ConvertAll(field => new CustomFieldEntry(field)), customFields);
            view.Comments = RichTextUtilities.ConvertTextToRTF(string.Empty);
            view.IsOperatingEngineerLog = false;
            view.IsInactive = false;
        }

        private void UpdateViewFromEditObject()
        {
            view.Title = editObject.LogType == LogType.Standard ? EDIT_LOG_DEFINITION_TITLE : EDIT_STANDING_ORDER_TITLE;

            if (editObject.LogType == LogType.Standard)
            {
                SiteConfiguration siteConfiguration = ClientSession.GetUserContext().SiteConfiguration;

                if (!siteConfiguration.ShowFollowupOnLogForm)
                {
                    view.HideFollowupFlags();
                }

                if (!siteConfiguration.AllowCreateALogForEachSelectedFlocOnLogForm)
                {
                    view.HideMultipleFunctionalLocationOptions();
                }

                view.IsOperatingEngineerLogCheckboxEnabled = false;
            }

            view.EHSFollowUp = editObject.EnvironmentalHealthSafetyFollowUp;
            view.OperationsFollowUp = editObject.OperationsFollowUp;
            view.ProcessControlFollowUp = editObject.ProcessControlFollowUp;
            view.InspectionFollowUp = editObject.InspectionFollowUp;
            view.SupervisionFollowUp = editObject.SupervisionFollowUp;
            view.OtherFollowUp = editObject.OtherFollowUp;
            view.FunctionalLocationData = editObject.FunctionalLocations;
            view.CreateALogForEachFunctionalLocation = editObject.CreateALogForEachFunctionalLocation;
            view.Author = editObject.CreatedBy;
            view.Schedule = editObject.Schedule;
            view.AssociatedDocumentLinks = editObject.DocumentLinks;
            view.Comments = editObject.RtfComments;              
            view.SetCustomFieldEntries(editObject.CustomFieldEntries, customFields);
            view.IsOperatingEngineerLog = editObject.IsOperatingEngineerLog;
            view.LastModifiedDateTime = editObject.LastModifiedDate;
            view.IsInactive = !editObject.Active;
        }

        public override bool ValidateViewHasError()
        {
            view.ClearErrorProviders();

            bool hasError = false;

            if (view.IsCommentEmpty)
            {
                view.SetCommentsBlankError();
                hasError = true;
            }

            if (view.HasScheduleError)
            {
                hasError = true;
            }

            if (view.FunctionalLocationData.IsEmpty())
            {
                view.SetFunctionalLocationsEmptyError();
                hasError = true;
            }
            
            if (isRepeatingLog && view.FunctionalLocationData.Exists(obj => obj.Type == FunctionalLocationType.Level1 || obj.Type == FunctionalLocationType.Level2))
            {
                view.RepeatingLogCannotBeAtASecondLevelFloc();
                hasError = true;
            }

            if (CustomFieldsHaveErrors())
            {
                hasError = true;
            }

            return hasError;
        }

        private bool CustomFieldsHaveErrors()
        {
            List<CustomFieldEntry> customFieldEntries = customFields.ConvertAll(field => new CustomFieldEntry(field));
            CustomFieldEntryValidator customFieldEntryValidator = new CustomFieldEntryValidator(view);
            customFieldEntryValidator.ValidateAndSetErrors(customFieldEntries);
            return customFieldEntryValidator.HasErrors;
        }

        public override void Insert(SaveUpdateDomainObjectContainer<LogDefinition> container)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Insert, container.Item);
        }

        public override void Update(SaveUpdateDomainObjectContainer<LogDefinition> container)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, container.Item);
        }

        protected override SaveUpdateDomainObjectContainer<LogDefinition> GetNewObjectToInsert()
        {
            DateTime now = Clock.Now;

            List<CustomFieldEntry> customFieldEntries = view.CopyFromView(customFields);

            LogDefinition logDefinition = new LogDefinition(
                view.Schedule,
                view.FunctionalLocationData,
                view.InspectionFollowUp,
                view.ProcessControlFollowUp,
                view.OperationsFollowUp,
                view.SupervisionFollowUp,
                view.EHSFollowUp,
                view.OtherFollowUp,
                view.IsOperatingEngineerLog,
                userContext.Role,
                now,
                userContext.User,
                userContext.User,
                now,
                view.AssociatedDocumentLinks,
                view.Comments,
                view.CommentsAsPlainText,
                isRepeatingLog ? LogType.Standard : LogType.DailyDirective,
                userContext.Assignment,
                view.CreateALogForEachFunctionalLocation,
                customFieldEntries,
                customFields,
                !view.IsInactive);

            return new SaveUpdateDomainObjectContainer<LogDefinition>(logDefinition);
        }

        protected override SaveUpdateDomainObjectContainer<LogDefinition> GetPopulatedEditObjectToUpdate()
        {
            UpdateEditObjectFromView();
            return new SaveUpdateDomainObjectContainer<LogDefinition>(editObject);
        }
        
        private void UpdateEditObjectFromView()
        {
            editObject.InspectionFollowUp = view.InspectionFollowUp;
            editObject.OperationsFollowUp = view.OperationsFollowUp;
            editObject.ProcessControlFollowUp = view.ProcessControlFollowUp;
            editObject.SupervisionFollowUp = view.SupervisionFollowUp;
            editObject.EnvironmentalHealthSafetyFollowUp = view.EHSFollowUp;
            editObject.OtherFollowUp = view.OtherFollowUp;
            editObject.LastModifiedBy = userContext.User;
            editObject.LastModifiedDate = Clock.Now;
            editObject.Schedule = view.Schedule;
            editObject.DocumentLinks = view.AssociatedDocumentLinks;
            editObject.RtfComments = view.Comments;
            editObject.PlainTextComments = view.CommentsAsPlainText;
            editObject.IsOperatingEngineerLog = view.IsOperatingEngineerLog;
            editObject.Active = !view.IsInactive;

            editObject.CustomFieldEntries.Clear();
            editObject.CustomFieldEntries.AddRange(CustomFieldPresenterHelper.GetCustomFieldEntriesFromView(editObject, view, customFields));
        }
       
        public void HandleViewEditHistoryButtonClicked(object sender, EventArgs e)
        {
            EditLogDefinitionHistoryFormPresenter presenter = new EditLogDefinitionHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        public void HandleLogCommentGuidelineLinkClick(object sender, EventArgs e)
        {
            List<LogGuideline> logGuidelines = GuidelineUtilities.GetGuidelines(
                ClientSession.GetUserContext().DivisionsForSelectedFunctionalLocations, logService);
            view.ShowGuidelines(logGuidelines);

        }

        public void HandleRemoveFlocButton_Clicked(object sender, EventArgs e)
        {
            FunctionalLocation floc = view.SelectedFunctionalLocation;

            if (floc != null)
            {
                List<FunctionalLocation> associatedFlocs = view.FunctionalLocationData;
                associatedFlocs.Remove(floc);
                var newAssociatedFlocs = new List<FunctionalLocation>(associatedFlocs);

                view.FunctionalLocationData = newAssociatedFlocs;
            }
        }

        public void HandleFunctionalLocationButtonClick(object sender, EventArgs e)
        {
            List<FunctionalLocation> selectedFunctionalLocations = view.FunctionalLocationData;
            DialogResultAndOutput<IList<FunctionalLocation>> result =
                view.ShowFunctionalLocationSelector(selectedFunctionalLocations, FunctionalLocationType.Level3);

            if (result.Result == DialogResult.OK)
            {
                IList<FunctionalLocation> newFlocList = result.Output;
                view.FunctionalLocationData = newFlocList == null ? new List<FunctionalLocation>() : new List<FunctionalLocation>(newFlocList);
            }
        }
      
        public void HandleCustomFieldClick(CustomField customField)
        {
            if (customField == null || customField.Type == CustomFieldType.Heading ||
               customField.Type == CustomFieldType.BlankSpace) return;

            WorkAssignment workAssignment = ClientSession.GetUserContext().Assignment;
            IRunnablePresenter presenter = CustomFieldPresenterMaker.Create(service, customField, workAssignment);
            presenter.Run(view);
        }

        public override void HandleSaveAndCloseButtonClick(object sender, EventArgs eventArgs)
        {
            if (!isRepeatingLog && DirectiveUtility.ShouldShowConvertingDirectivesToNewSystemMessage(siteConfigurationService, userContext.SiteId))
            {
                DirectiveUtility.ShowConvertingDirectivesToNewSystemMessage();
                return;
            }

            base.HandleSaveAndCloseButtonClick(sender, eventArgs);
        }
    }
}