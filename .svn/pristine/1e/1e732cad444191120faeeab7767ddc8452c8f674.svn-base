using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Clock = Com.Suncor.Olt.Common.Utility.Clock;
using Constant = Com.Suncor.Olt.Common.Utility.Constants;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class DirectiveLogFormPresenter : AbstractFormPresenter<IDirectiveLogFormView, Log>
    {
        private List<CustomField> customFields = new List<CustomField>();        
        private List<CustomField> customFieldsFromDb;

        private readonly ILogService service;
        private readonly ICustomFieldService customFieldService;
        private readonly ISiteConfigurationService siteConfigurationService;

        private readonly ILogCopyStrategy logCopyStrategy;
        private readonly IPlantHistorianService plantHistorianService;
        private readonly IFunctionalLocationService functionalLocationService;

        private readonly ClientBackgroundWorker backgroundWorker;
        private readonly LogTemplatePresenterHelper logTemplatePresenterHelper;

        public DirectiveLogFormPresenter(IDirectiveLogFormView view, Log editLog) : this(view, editLog, null)
        {
        }

        public DirectiveLogFormPresenter(IDirectiveLogFormView view, ILogCopyStrategy logCopyStrategy) : this(view, null, logCopyStrategy)
        {
        }

        public DirectiveLogFormPresenter(IDirectiveLogFormView view) : this(view, null, null)
        {
        }

        private DirectiveLogFormPresenter(IDirectiveLogFormView view, Log editLog, ILogCopyStrategy logCopyStrategy) : this(
            view,
            editLog,
            logCopyStrategy,
            ClientServiceRegistry.Instance.GetService<ILogService>(),        
            ClientServiceRegistry.Instance.GetService<ILogTemplateService>(),
            ClientServiceRegistry.Instance.GetService<ICustomFieldService>(),
            ClientServiceRegistry.Instance.GetService<IPlantHistorianService>(),
            ClientServiceRegistry.Instance.GetService<IFunctionalLocationService>(),
            ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>()
            )
        {            
        }

        private DirectiveLogFormPresenter(
            IDirectiveLogFormView view, 
            Log editLog, 
            ILogCopyStrategy logCopyStrategy,
            ILogService service,            
            ILogTemplateService logTemplateService,
            ICustomFieldService customFieldService,
            IPlantHistorianService plantHistorianService,
            IFunctionalLocationService functionalLocationService,
            ISiteConfigurationService siteConfigurationService)
            : base(view, editLog)
        {
            this.service = service;
            this.customFieldService = customFieldService;
            this.plantHistorianService = plantHistorianService;
            this.functionalLocationService = functionalLocationService;
            this.siteConfigurationService = siteConfigurationService;

            backgroundWorker = new ClientBackgroundWorker();

            this.logCopyStrategy = logCopyStrategy ?? new DoNothingLogCopyStrategy();

            logTemplatePresenterHelper = new LogTemplatePresenterHelper(view, logTemplateService, userContext.Assignment, LogTemplate.LogType.DailyDirective);
            view.HandleLogTemplateButtonClick += logTemplatePresenterHelper.HandleInsertTemplateButtonClick;

        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            LoadData(new List<Action> { logTemplatePresenterHelper.QueryLogTemplates, QueryCustomFields });
        }

        protected override void AfterDataLoad()
        {
            bool isEdit = IsEdit;
            view.UpdateTitleAsCreateOrEdit(isEdit, StringResources.LogFormTitleText_DirectiveEntry);
            view.LogTimeControlEnabled = false;
            
            SetupCustomFieldsVariable();

            view.ViewEditHistoryEnabled = isEdit;

            if (isEdit)
            {
                view.HideFunctionalLocationButtonsAndDisableMultipleFunctionalLocationOptions();
                UpdateViewFromEditObject();
                view.MultipleFunctionalLocationOptionsEnabled = false;
            }
            else
            {
                UpdateViewWithDefaults();
                view.Author = userContext.User != null ? userContext.User.FullNameWithUserName : string.Empty;
                view.Shift = userContext.UserShift.ShiftPattern.Name;
                view.MultipleFunctionalLocationOptionsEnabled = true;
                view.LogDateTime = Clock.Now;
            }

            logTemplatePresenterHelper.LoadLogTemplates(IsEdit);

            logCopyStrategy.Copy(view, customFields, userContext.Assignment);

            if (CustomFieldAssociatedWithPhTagExists())
            {
                view.CustomFieldPhTagAssociationControlsVisible = true;
                view.TurnOnCustomFieldPhTagHighlights(customFields.ConvertAll(field => new CustomFieldEntry(field)));
            }
            else
            {
                view.CustomFieldPhTagAssociationControlsVisible = false;
            }           
        }

        private void QueryCustomFields()
        {
            customFieldsFromDb = customFieldService.QueryOrderedFieldsByWorkAssignmentForDailyDirectives(userContext.Assignment);
        }

        private void SetupCustomFieldsVariable()
        {
            customFields = IsEdit ? new List<CustomField>(editObject.CustomFields) : customFieldsFromDb;
        }

        private bool CustomFieldAssociatedWithPhTagExists()
        {
            return customFields.Exists(field => field.TagInfo != null);
        }

        public override void HandleSaveAndCloseButtonClick(object sender, EventArgs eventArgs)
        {
            if (DirectiveUtility.ShouldShowConvertingDirectivesToNewSystemMessage(siteConfigurationService, userContext.SiteId))
            {
                DirectiveUtility.ShowConvertingDirectivesToNewSystemMessage();
                return;
            }

            if (IsEdit && service.LogIsMarkedAsRead(editObject.IdValue))
            {
                if (view.ShowLogMarkedAsReadWarning())
                {
                    base.HandleSaveAndCloseButtonClick(sender, eventArgs);
                }                
            }
            else
            {
                base.HandleSaveAndCloseButtonClick(sender, eventArgs);
            }                      
        }

        public void HandleRemoveFlocButtonClick(object sender, EventArgs e)
        {
            FunctionalLocation floc = view.SelectedFunctionalLocation;

            if (floc != null)
            {
                List<FunctionalLocation> associatedFlocs = view.FunctionalLocations;
                associatedFlocs.Remove(floc);
                var newAssociatedFlocs = new List<FunctionalLocation>(associatedFlocs);

                view.FunctionalLocations = newAssociatedFlocs;
            }
        }

        public void HandleFunctionalLocationButtonClick(object sender, EventArgs e)
        {
            List<FunctionalLocation> selectedFunctionalLocations = view.FunctionalLocations;
            DialogResultAndOutput<IList<FunctionalLocation>> result = 
                view.ShowFunctionalLocationSelector(selectedFunctionalLocations);
            
            if (result.Result == DialogResult.OK)
            {
                IList<FunctionalLocation> newFlocList = result.Output;
                view.FunctionalLocations = newFlocList == null ? new List<FunctionalLocation>() : new List<FunctionalLocation>(newFlocList);
            }
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
            editObject.DocumentLinks = view.AssociatedDocumentLinks;            
            editObject.FunctionalLocations = view.FunctionalLocations;
            editObject.LogDateTime = view.LogDateTime;
            editObject.RtfComments = view.Comments;
            editObject.PlainTextComments = view.CommentsAsPlainText;

            editObject.CustomFieldEntries.Clear();
            editObject.CustomFieldEntries.AddRange(CustomFieldPresenterHelper.GetCustomFieldEntriesFromView(editObject, view, customFields));

            editObject.CustomFields.Clear();
            editObject.CustomFields.AddRange(customFields);
        }

        private void UpdateViewFromEditObject()
        {
            view.SetupForEdit();
            view.Author = editObject.CreationUser != null ? editObject.CreationUser.FullNameWithUserName : string.Empty;
            view.Shift = editObject.CreatedShiftPattern.Name;

            view.EHSFollowUp = editObject.EnvironmentalHealthSafetyFollowUp;
            view.OperationsFollowUp = editObject.OperationsFollowUp;
            view.ProcessControlFollowUp = editObject.ProcessControlFollowUp;
            view.InspectionFollowUp = editObject.InspectionFollowUp;
            view.SupervisionFollowUp = editObject.SupervisionFollowUp;
            view.OtherFollowUp = editObject.OtherFollowUp;

            view.FunctionalLocations = editObject.FunctionalLocations;
            view.LogDateTime = editObject.LogDateTime;
            view.AssociatedDocumentLinks = editObject.DocumentLinks;
            view.SetCustomFieldEntries(editObject.CustomFieldEntries, customFields);
            view.Comments = editObject.RtfComments;
        }

        protected void UpdateViewWithDefaults()
        {
            view.FunctionalLocations = new List<FunctionalLocation>();
            
            view.AssociatedDocumentLinks = new List<DocumentLink>();
            
            if (!logCopyStrategy.IsCopying)
            {
                view.SetCustomFieldEntries(customFields.ConvertAll(field => new CustomFieldEntry(field)), customFields);
            }

            view.Comments = RichTextUtilities.ConvertTextToRTF(string.Empty);

            //ayman test document link Dec 22, 2016
            if (logCopyStrategy.IsCopying)
            {
                view.AssociatedDocumentLinks = logCopyStrategy.LogToCopy.DocumentLinks;
            }

            if (ClientSession.GetUserContext().SiteConfiguration.DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders)
            {
                List<FunctionalLocation> selectedFunctionalLocations = ClientSession.GetUserContext().RootsForSelectedFunctionalLocations;
                view.FunctionalLocations = functionalLocationService.GetDefaultFLOCs(FunctionalLocationType.Level2, selectedFunctionalLocations);
            }
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

            if (IsFunctionLocationBlank())
            {
                view.SetFunctionLocationBlankError();
                hasError = true;
            }

            if (IsLogTimeInTheFuture())
            {
                view.SetLogTimeInTheFutureError();
                hasError = true;
            }
 
            if (!IsLogTimeWithinShift())
            {                
                view.SetLogDateTimeError();
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

        public override void Insert(SaveUpdateDomainObjectContainer<Log> container)
        {
            SaveUpdateMultiDomainObjectContainer<Log> multiContainer = (SaveUpdateMultiDomainObjectContainer<Log>)container;

            foreach (Log directiveToSave in multiContainer.Items)
            {
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Insert, directiveToSave);    
            }
        }
       
        public override void Update(SaveUpdateDomainObjectContainer<Log> container)
        {                        
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, container.Item);
        }

        protected override SaveUpdateDomainObjectContainer<Log> GetPopulatedEditObjectToUpdate()
        {
            UpdateEditObjectFromView();
            return new SaveUpdateDomainObjectContainer<Log>(editObject);
        }

        protected override SaveUpdateDomainObjectContainer<Log> GetNewObjectToInsert()
        {
            List<Log> insertList = new List<Log>();

            List<CustomFieldEntry> customFieldEntries = view.CopyFromView(customFields);            
            WorkAssignment workAssignment = userContext.Assignment;
            DateTime now = Clock.Now;

            if (view.CreateALogForEachFunctionalLocation)
            {
                foreach (FunctionalLocation floc in view.FunctionalLocations)
                {
                    Log directive = CreateLogForInsert(new List<FunctionalLocation> { floc }, now, customFieldEntries, workAssignment);
                    insertList.Add(directive);
                }
            }
            else
            {
                Log directive = CreateLogForInsert(view.FunctionalLocations, now, customFieldEntries, workAssignment);
                insertList.Add(directive);                
            }

            SaveUpdateMultiDomainObjectContainer<Log> container = new SaveUpdateMultiDomainObjectContainer<Log>(insertList);

            return container;
        }

        private Log CreateLogForInsert(List<FunctionalLocation> flocListForLog, DateTime now, List<CustomFieldEntry> customFieldEntries, WorkAssignment workAssignment)
        {
            Log log = new Log(null,
                              null,
                              null,
                              DataSource.MANUAL,
                              flocListForLog,
                              view.InspectionFollowUp,
                              view.ProcessControlFollowUp,
                              view.OperationsFollowUp,
                              view.SupervisionFollowUp,
                              view.EHSFollowUp,
                              view.OtherFollowUp,
                              view.Comments,
                              view.CommentsAsPlainText,
                              view.LogDateTime,
                              userContext.UserShift.ShiftPattern,
                              userContext.User,
                              userContext.User,
                              now,
                              now,
                              false,
                              false,
                              userContext.Role,
                              view.AssociatedDocumentLinks,
                              LogType.DailyDirective,
                              false,
                              workAssignment,
                              customFieldEntries,
                              customFields);

            return log;
        }

        private bool IsLogTimeInTheFuture()
        {
            return view.LogDateTime.CompareTo(Clock.Now) > 0;
        }

        private bool IsLogTimeWithinShift()
        {
            return userContext.UserShift.ShiftPattern.IsTimeInShiftIncludingPadding(view.ActualLoggedTime);
        }

        private bool IsFunctionLocationBlank()
        {
            return view.FunctionalLocations.IsEmpty();
        }

        public void HandleViewEditHistoryButtonClick(object sender, EventArgs e)
        {
            EditLogHistoryFormPresenter presenter = new EditLogHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        public void LogDateTimeChanged(object sender, EventArgs e)
        {
            view.LogDateTime = userContext.UserShift.StartDateTimeWithPadding.RollForward(view.ActualLoggedTime);
        }

        public void LogCommentControlGuidelineLinkClick(object sender, EventArgs e)
        {
            List<LogGuideline> logGuidelines = GuidelineUtilities.GetGuidelines(ClientSession.GetUserContext().DivisionsForSelectedFunctionalLocations, service);
            view.ShowGuidelines(logGuidelines);
        }

        public void HandleFormClosed(object sender, FormClosedEventArgs e)
        {
            if (backgroundWorker != null && backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
        }

        public void HandleImportCustomFieldButtonClicked(object sender, EventArgs e)
        {
            ImportCustomFieldsPresenter importCustomFieldsPresenter = new ImportCustomFieldsPresenter(view, customFields);
            importCustomFieldsPresenter.Import(backgroundWorker, plantHistorianService);
        }

        public void HandleCustomFieldClick(CustomField customField)
        {
            if (customField == null || customField.Type == CustomFieldType.Heading ||
               customField.Type == CustomFieldType.BlankSpace) return;
            WorkAssignment workAssignment = ClientSession.GetUserContext().Assignment;
            CustomFieldPresenterMaker.Create(service, customField, workAssignment).Run(view);
        }
    }
}
