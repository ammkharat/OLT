using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Client.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using System.Linq;
using System.IO;
namespace Com.Suncor.Olt.Client.Presenters
{
    public class LogFormPresenter : AbstractFormPresenter<ILogFormView, Log>
    {
        private readonly IAuthorized authorized;
        private readonly ClientBackgroundWorker backgroundWorker;
        private readonly ICustomFieldService customFieldService;

        private readonly FunctionalLocationType flocSelectionLevel;
        private readonly IFunctionalLocationService functionalLocationService;
        private readonly ILogCopyStrategy logCopyStrategy;

        private readonly LogTemplatePresenterHelper logTemplatePresenterHelper;
        private readonly IPlantHistorianService plantHistorianService;
        private readonly ILogService service;
        private List<CustomField> customFields = new List<CustomField>();
        private List<CustomField> customFieldsFromDb;

        public LogFormPresenter(ILogFormView view) : this(view, null, null)
        {
        }

        public LogFormPresenter(ILogFormView view, Log editLog)
            : this(view, editLog, null)
        {
        }

        public LogFormPresenter(ILogFormView view, ILogCopyStrategy logCopyStrategy)
            : this(view, null, logCopyStrategy)
        {
        }
 
        private LogFormPresenter(ILogFormView view, Log editLog, ILogCopyStrategy logCopyStrategy)
            : this(
                view,
                editLog,
                logCopyStrategy,
                ClientServiceRegistry.Instance.GetService<ILogService>(),
                ClientServiceRegistry.Instance.GetService<ILogTemplateService>(),
                ClientServiceRegistry.Instance.GetService<ICustomFieldService>(),
                ClientServiceRegistry.Instance.GetService<IPlantHistorianService>(),
                ClientServiceRegistry.Instance.GetService<IFunctionalLocationService>())
        {
        }

        public LogFormPresenter(
            ILogFormView view,
            Log editLog,
            ILogCopyStrategy logCopyStrategy,
            ILogService service,
            ILogTemplateService logTemplateService,
            ICustomFieldService customFieldService,
            IPlantHistorianService plantHistorianService,
            IFunctionalLocationService functionalLocationService)
            : base(view, editLog)
        {
            this.service = service;
            this.plantHistorianService = plantHistorianService;
            this.functionalLocationService = functionalLocationService;
            this.customFieldService = customFieldService;
            authorized = new Authorized();

            this.logCopyStrategy = logCopyStrategy ?? new DoNothingLogCopyStrategy();

            backgroundWorker = new ClientBackgroundWorker();


            //ayman floc level from sitconf
            var siteConfigurationService = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();
            var siteConf = siteConfigurationService.QueryBySiteId(ClientSession.GetUserContext().SiteId);
            var itemFlocSelectionLevel = siteConf.ShiftLogFlocLevel;

            if (itemFlocSelectionLevel == 0)
            {
                flocSelectionLevel = userContext.SiteConfiguration.AllowStandardLogAtSecondLevelFunctionalLocation
                    ? FunctionalLocationType.Level2
                    : FunctionalLocationType.Level3;
            }
            else
            {

                if (ClientSession.GetUserContext().SiteConfiguration.ShiftLogFlocLevel == 1)
                    flocSelectionLevel = FunctionalLocationType.Level1;
                else if (ClientSession.GetUserContext().SiteConfiguration.ShiftLogFlocLevel == 2)
                    flocSelectionLevel = FunctionalLocationType.Level2;
                else if (ClientSession.GetUserContext().SiteConfiguration.ShiftLogFlocLevel == 3)
                    flocSelectionLevel = FunctionalLocationType.Level3;
            }


            logTemplatePresenterHelper = new LogTemplatePresenterHelper(view, logTemplateService, userContext.Assignment,
                LogTemplate.LogType.Standard);
            view.HandleLogTemplateButtonClick += logTemplatePresenterHelper.HandleInsertTemplateButtonClick;
        }

        public void HandleLoadPage(object sender, EventArgs e)
        {
            LoadData(new List<Action> {logTemplatePresenterHelper.QueryLogTemplates, QueryCustomFields});
        }

        protected override void AfterDataLoad()
        {
            var siteConfiguration = userContext.SiteConfiguration;

            var isEdit = IsEdit;

            SetupCustomFieldsVariable();

            view.UpdateTitleAsCreateOrEdit(isEdit, StringResources.LogFormTitleText_LogEntry);
            view.LogTimeControlEnabled = true;
            
            if (!siteConfiguration.ShowFollowupOnLogForm)
            {
                view.HideFollowupFlags();
            }
            if (!siteConfiguration.AllowCreateALogForEachSelectedFlocOnLogForm)
            {
                view.HideMultipleFunctionalLocationOptions();
            }

            view.ViewEditHistoryEnabled = isEdit;
            view.ExpandAdditionalDetails = siteConfiguration.ShowAdditionalDetailsOnLogFormByDefault;
            view.SelectLogsForSummaryButtonEnabled = authorized.ToAddShiftInformation(userContext.UserRoleElements);


            if (!siteConfiguration.CreateOperatingEngineerLogs)
            {
                view.HideOperatingEngineerCheckBox();
            }

            view.OperatingEngineerLogDisplayName = siteConfiguration.OperatingEngineerLogDisplayName;

            if (isEdit)
            {
                view.HideFunctionalLocationButtonsAndDisableMultipleFunctionalLocationOptions();
                UpdateViewFromEditObject();
                view.MultipleFunctionalLocationOptionsEnabled = false;
                //RITM0443261 : Added by Vibhor {Change the name for Shift log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}
                if (ClientSession.GetUserContext().Site.Id == Site.Contruction_Mgnt_ID)
                {
                    view.SetShiftLogMenuItemName = StringResources.LogSectionNavigationTextForConstructionSiteEditMode;
                }
                else
                {
                    view.SetShiftLogMenuItemName = StringResources.LogSectionNavigationText;
                }
                //END
            }
            else
            {
                
                UpdateViewWithDefaults();
                //Dharmesh -- Start -- 6Jul2017 for INC0165740 (OLT - Clone / Copy issues with Logs and Work permits)
                //ayman lst minute fix
                if (this.logCopyStrategy.IsCopying)
                {
                    view.AssociatedDocumentLinks = this.logCopyStrategy.LogToCopy.DocumentLinks;
                }
                //Dharmesh end 6Jul2017
                view.Author = userContext.User != null ? userContext.User.FullNameWithUserName : string.Empty;
                view.Shift = userContext.UserShift.ShiftPattern.Name;
                view.MultipleFunctionalLocationOptionsEnabled = true;
                view.LogDateTime = Clock.Now;
                //RITM0443261 : Added by Vibhor {Change the name for Shift log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}
                if (ClientSession.GetUserContext().Site.Id == Site.Contruction_Mgnt_ID)
                {
                    view.SetShiftLogMenuItemName = StringResources.LogSectionNavigationTextForConstructionSite;
                }
                else
                {
                    view.SetShiftLogMenuItemName = StringResources.LogSectionNavigationText;
                }
                
                //END

             
            }

            logTemplatePresenterHelper.LoadLogTemplates(IsEdit);

            logCopyStrategy.Copy(view, customFields, userContext.Assignment);

            var hasPhdRead = CustomField.HasAtLeastOneReadFromPhdCustomField(customFields);
            var hasPhdWrite = CustomField.HasAtLeastOneWriteToPhdCustomField(customFields);

            if (hasPhdRead || hasPhdWrite)
            {
                view.TurnOnCustomFieldPhTagHighlights(customFields.ConvertAll(field => new CustomFieldEntry(field)));
            }

            view.SetCustomFieldPhTagAssociationControlsVisible(hasPhdRead, hasPhdWrite);

          
        
        }

        private void QueryCustomFields()
        {
            customFieldsFromDb = customFieldService.QueryOrderedFieldsByWorkAssignmentForLogs(userContext.Assignment);
        }

        private void SetupCustomFieldsVariable()
        {
            customFields = IsEdit ? new List<CustomField>(editObject.CustomFields) : customFieldsFromDb;
        }

        public override void HandleSaveAndCloseButtonClick(object sender, EventArgs eventArgs)
        {
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
            var floc = view.SelectedFunctionalLocation;

            if (floc != null)
            {
                var associatedFlocs = ((ILogCopyFormView) view).FunctionalLocations;
                associatedFlocs.Remove(floc);
                var newAssociatedFlocs = new List<FunctionalLocation>(associatedFlocs);

                ((ILogCopyFormView) view).FunctionalLocations = newAssociatedFlocs;
            }
        }

        public void HandleFunctionalLocationButtonClick(object sender, EventArgs e)
        {
            var selectedFunctionalLocations = ((ILogCopyFormView) view).FunctionalLocations;
            var result =
                view.ShowFunctionalLocationSelector(selectedFunctionalLocations, flocSelectionLevel);

            if (result.Result == DialogResult.OK)
            {
                var newFlocList = result.Output;
                ((ILogCopyFormView) view).FunctionalLocations = newFlocList == null
                    ? new List<FunctionalLocation>()
                    : new List<FunctionalLocation>(newFlocList);
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
            editObject.IsOperatingEngineerLog = view.IsOperatingEngineerLog;
            editObject.DocumentLinks = view.AssociatedDocumentLinks;
            editObject.RecommendForShiftSummary = view.RecommendForShiftSummary;
            editObject.FunctionalLocations = ((ILogCopyFormView) view).FunctionalLocations;
            editObject.LogDateTime = view.LogDateTime;
            editObject.RtfComments = view.Comments;
            editObject.PlainTextComments = view.CommentsAsPlainText;

            editObject.CustomFieldEntries.Clear();
            editObject.CustomFieldEntries.AddRange(CustomFieldPresenterHelper.GetCustomFieldEntriesFromView(editObject,
                view, customFields));

            editObject.CustomFields.Clear();
            editObject.CustomFields.AddRange(customFields);

            // By Vibhor : RITM0272920
            editObject.isAdminRole = ClientSession.GetUserContext().UserRoleElements.Role.IsAdministratorRole;

            //END


            //Mukesh for Log Image

            editObject.Imagelist = UpoloadFileandUpdatePath(view.ImageLogdetails, editObject); //view.ImageLogdetails;
            //End Mukesh for Log Image

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

            ((ILogCopyFormView) view).FunctionalLocations = editObject.FunctionalLocations;
            view.LogDateTime = editObject.LogDateTime;
            view.IsOperatingEngineerLog = editObject.IsOperatingEngineerLog;
            view.AssociatedDocumentLinks = editObject.DocumentLinks;
            view.RecommendForShiftSummary = editObject.RecommendForShiftSummary;
            view.SetCustomFieldEntries(editObject.CustomFieldEntries, customFields);
            view.Comments = editObject.RtfComments;

            //Mukesh for Log Image
            if(editObject.Source==DataSource.MANUAL)
            {
                view.ImageLogdetails = editObject.Imagelist;
                view.setLogImage =userContext.SiteConfiguration.EnableLogImage;
            }
            else
            {
                view.setLogImage = false;
            }
           
            //End Mukesh for Log Image
            
        }

        private void UpdateViewWithDefaults()
        {
            ((ILogCopyFormView) view).FunctionalLocations = GetDefaultFlocs(functionalLocationService,
                flocSelectionLevel);

            view.IsOperatingEngineerLog = false;

            view.AssociatedDocumentLinks = new List<DocumentLink>();

            if (!logCopyStrategy.IsCopying)
            {
                view.SetCustomFieldEntries(customFields.ConvertAll(field => new CustomFieldEntry(field)), customFields);
            }

            view.Comments = RichTextUtilities.ConvertTextToRTF(string.Empty);

            //Mukesh for Log Image
            view.setLogImage = userContext.SiteConfiguration.EnableLogImage;
            List<LogImage> lst = new List<LogImage>();
            view.ImageLogdetails = lst;

        }

        private static List<FunctionalLocation> GetDefaultFlocs(IFunctionalLocationService functionalLocationService,
            FunctionalLocationType flocSelectionLevel)
        {
            var siteConfiguration = ClientSession.GetUserContext().SiteConfiguration;
            if (siteConfiguration.DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs)
            {
                return LogFormPresenterHelper.GetDefaultFlocs(functionalLocationService, flocSelectionLevel);
            }

            return new List<FunctionalLocation>();
        }

        public override bool ValidateViewHasError()
        {
            var customFieldEntries = customFields.ConvertAll(field => new CustomFieldEntry(field));
            var validator = new LogValidator(view, ClientSession.GetUserContext());
            validator.ValidateAndSetErrors(customFieldEntries);
            return validator.HasErrors;
        }

        public override void Insert(SaveUpdateDomainObjectContainer<Log> container)
        {
            var multiContainer = (SaveUpdateMultiDomainObjectContainer<Log>) container;

            foreach (var log in multiContainer.Items)
            {
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Insert, log);
            }
        }

        public override void Update(SaveUpdateDomainObjectContainer<Log> container)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, container.Item);
        }

        protected override SaveUpdateDomainObjectContainer<Log> GetNewObjectToInsert()
        {
            var insertList = new List<Log>();

            var customFieldEntries = view.CopyFromView(customFields);
            var workAssignment = userContext.Assignment;
            var now = Clock.Now;

            if (view.CreateALogForEachFunctionalLocation)
            {
                foreach (var floc in ((ILogCopyFormView) view).FunctionalLocations)
                {
                    var logForInsert = CreateLogForInsert(new List<FunctionalLocation> {floc}, customFieldEntries,
                        workAssignment, now);
                    insertList.Add(logForInsert);
                }
            }
            else
            {
                var logForInsert = CreateLogForInsert(((ILogCopyFormView) view).FunctionalLocations, customFieldEntries,
                    workAssignment, now);
                insertList.Add(logForInsert);
            }

            return new SaveUpdateMultiDomainObjectContainer<Log>(insertList);
        }

        protected override SaveUpdateDomainObjectContainer<Log> GetPopulatedEditObjectToUpdate()
        {            
            UpdateEditObjectFromView();
            return new SaveUpdateDomainObjectContainer<Log>(editObject);
        }

        private Log CreateLogForInsert(List<FunctionalLocation> functionalLocations,
            List<CustomFieldEntry> customFieldEntries, WorkAssignment workAssignment, DateTime now)
        {
            var log = new Log(null,
                null,
                null,
                DataSource.MANUAL,
                functionalLocations,
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
                view.IsOperatingEngineerLog,
                userContext.Role,
                view.AssociatedDocumentLinks,
                LogType.Standard,
                view.RecommendForShiftSummary,
                workAssignment,
                customFieldEntries,
                customFields);


             //Mukesh for Log Image
            //log.Imagelist = view.ImageLogdetails;
            log.Imagelist = UpoloadFileandUpdatePath(view.ImageLogdetails, log);
            return log;
        }
        //Mukesh for Log Image
        public List<LogImage> UpoloadFileandUpdatePath(List<LogImage> lstImages,Log log)
        {
            foreach (LogImage Img in lstImages)
            {
                if (Img.Id == 0 && Img.Action != "Remove")
                {
                    if (ClientSession.GetUserContext().SiteConfiguration.LogImagePath != null)
                    {
                        if(File.Exists(Img.ImagePath))
                        {
                         string fileName=userContext.SiteConfiguration.LogImagePath + ClientSession.GetUserContext().User.Username + "-" + Clock.Now.ToString("yyyyMMddTHHmmss") + "-" + Path.GetFileName(Img.ImagePath);
                         File.Copy(Img.ImagePath, fileName, true);
                         Img.ImagePath = fileName;
                        }
                    }

                }
               
              
            }
            return lstImages;
        }
        public void HandleViewEditHistoryButtonClick(object sender, EventArgs e)
        {
            var presenter = new EditLogHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        public void LogDateTimeChanged(object sender, EventArgs e)
        {
            view.LogDateTime = userContext.UserShift.StartDateTimeWithPadding.RollForward(view.ActualLoggedTime);
        }

        public void SelectLogsForSummaryButton_Click(object sender, EventArgs e)
        {
            var result = view.ShowSelectLogsForSummaryForm();

            if (result.Result == DialogResult.OK)
            {
                view.AppendComments(result.Output);
            }
        }

        public void LogCommentControlGuidelineLinkClick(object sender, EventArgs e)
        {
            var logGuidelines =
                GuidelineUtilities.GetGuidelines(
                    ClientSession.GetUserContext().DivisionsForSelectedFunctionalLocations, service);
            view.ShowGuidelines(logGuidelines);
        }

        public void HandleFormClosed(object sender, FormClosedEventArgs e)
        {
            if (backgroundWorker != null && backgroundWorker.IsBusy)
            {
                //Mingle #3050 by mangesh
                backgroundWorker.WorkerSupportsCancellation = true; 
                backgroundWorker.WorkerReportsProgress = true;
                //-- End
                backgroundWorker.CancelAsync();
            }
        }
        
        public void HandleImportCustomFieldButtonClick(object sender, EventArgs e)
        {
            var importCustomFieldsPresenter = new ImportCustomFieldsPresenter(view, customFields);
            importCustomFieldsPresenter.Import(backgroundWorker, plantHistorianService);
        }

        public void HandleCustomFieldClick(CustomField customField)
        {
            if (customField == null || customField.Type == CustomFieldType.Heading ||
                customField.Type == CustomFieldType.BlankSpace) return;
            var workAssignment = ClientSession.GetUserContext().Assignment;
            CustomFieldPresenterMaker.Create(service, customField, workAssignment).Run(view);
        }

        // By Vibhor : RITM0272920
        public void actualLoggedTime_Leave(object sender, EventArgs e)
        {
            if (IsEdit)
            {

                Time Logtime = view.ActualLoggedTime;
                IShiftPatternService shiftPatternService = ClientServiceRegistry.Instance.GetService<IShiftPatternService>();
                IEnumerable<ShiftPattern> allShifts = shiftPatternService.QueryBySite(userContext.Site).Where(S => (S.StartTime < S.EndTime && (S.StartTime <= Logtime && S.EndTime > Logtime)) || (S.StartTime > S.EndTime && (S.StartTime <= Logtime || S.EndTime > Logtime)));
                view.Shift = allShifts.First().Name;
                editObject.CreatedShiftPattern = allShifts.First();
            }

        }
        //END

    }
}