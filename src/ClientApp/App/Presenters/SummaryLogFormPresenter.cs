using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Clock = Com.Suncor.Olt.Common.Utility.Clock;
using Constant = Com.Suncor.Olt.Common.Utility.Constants;
using System.IO;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class SummaryLogFormPresenter : AbstractFormPresenter<ISummaryLogFormView, SummaryLog>
    {
        private readonly bool onlyAllowedToEditDORComments;

        private readonly ISummaryLogService summaryLogService;
        private readonly ILogService logService;
        private readonly ICustomFieldService customFieldService;
        private List<CustomField> customFields = new List<CustomField>();

        private readonly IAuthorized authorized;
        private readonly ClientBackgroundWorker backgroundWorker;
        private readonly IPlantHistorianService plantHistorianService;
        private readonly IFunctionalLocationService functionalLocationService;
        

        private readonly LogTemplatePresenterHelper logTemplatePresenterHelper;

        private List<CustomField> customFieldsFromDb;
        private bool isCopy;

        public SummaryLogFormPresenter(ISummaryLogFormView view)
            : this(view, null, false)
        {
        }

        //Added by Aarti RITM0512605:Copy feature for Shift Summary log
        public SummaryLogFormPresenter(ISummaryLogFormView view, SummaryLog editLog)
            : this(view, editLog, false)
        {
            isCopy = editLog.copyClickedSumm;
        }

    
        public SummaryLogFormPresenter(ISummaryLogFormView view, SummaryLog editLog, bool onlyAllowedToEditDORComments) : this(
            view,
            editLog,
            onlyAllowedToEditDORComments,
            ClientServiceRegistry.Instance.GetService<ISummaryLogService>(),
            ClientServiceRegistry.Instance.GetService<ILogService>(),
            ClientServiceRegistry.Instance.GetService<ICustomFieldService>(),
            new Authorized(),
            ClientServiceRegistry.Instance.GetService<IPlantHistorianService>(),
            ClientServiceRegistry.Instance.GetService<IFunctionalLocationService>(),
            ClientServiceRegistry.Instance.GetService<ILogTemplateService>())
        {
            
        }

   
        public SummaryLogFormPresenter(
            ISummaryLogFormView view,
            SummaryLog editLog,
            bool onlyAllowedToEditDORComments,
            ISummaryLogService summaryLogService,
            ILogService logService,
            ICustomFieldService customFieldService,
            IAuthorized authorized,
            IPlantHistorianService plantHistorianService,
            IFunctionalLocationService functionalLocationService,
            ILogTemplateService logTemplateService)
            : base(view, editLog)
        {
            this.onlyAllowedToEditDORComments = onlyAllowedToEditDORComments;
            this.summaryLogService = summaryLogService;
            this.logService = logService;
            this.customFieldService = customFieldService;
            this.authorized = authorized;
            backgroundWorker = new ClientBackgroundWorker();
            this.plantHistorianService = plantHistorianService;
            this.functionalLocationService = functionalLocationService;

            logTemplatePresenterHelper = new LogTemplatePresenterHelper(view, logTemplateService, userContext.Assignment, LogTemplate.LogType.SummaryLog);
            view.HandleLogTemplateButtonClick += logTemplatePresenterHelper.HandleInsertTemplateButtonClick;
        }

       
        public void HandleFormLoad(object sender, EventArgs e)
        {
            LoadData(new List<Action>
                {
                    QueryCustomFields, logTemplatePresenterHelper.QueryLogTemplates
                });
        }

        protected override void AfterDataLoad()
        {
          bool isEdit = IsEdit;

          if (isCopy) //Added by Aarti RITM0512605:Copy feature for Shift Summary log
            {
                    view.UpdateTitleAsCreateOrEdit(false, StringResources.SummaryLogFormTitle);

            }

                else
                {
                    view.UpdateTitleAsCreateOrEdit(isEdit, StringResources.SummaryLogFormTitle);
                    view.ViewEditHistoryEnabled = isEdit;
                }
            
           
           
            
            SetupCustomFieldsVariable();
            //RITM0443261 : Added by Amit {Change the name for Shift summary log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}
            if (ClientSession.GetUserContext().Site.Id == Site.Contruction_Mgnt_ID)
            {
                view.SetShiftSummaryLogMenuItemName = StringResources.SummaryLogTabTextForConstSite;
            }

            if (isEdit || isCopy) //Added by Aarti RITM0512605:Copy feature for Shift Summary log
            {
                UpdateViewFromEditObject();
                if (isCopy)
                {
                    view.LogDateTime = Clock.Now;
                }
            }
            else
            {
                UpdateViewWithDefaults();
                view.Author = userContext.User.FullNameWithUserName;
                view.Shift = userContext.UserShift.ShiftPattern.Name;
            }

            bool hasPhdRead = CustomField.HasAtLeastOneReadFromPhdCustomField(customFields);
            bool hasPhdWrite = CustomField.HasAtLeastOneWriteToPhdCustomField(customFields);

            if (hasPhdRead || hasPhdWrite)
            {
                view.TurnOnCustomFieldPhTagHighlights(customFields.ConvertAll(field => new CustomFieldEntry(field)));
            }

            view.SetCustomFieldPhTagAssociationControlsVisible(hasPhdRead, hasPhdWrite);

            logTemplatePresenterHelper.LoadLogTemplates(IsEdit);
            view.MakeCommentControlFillAnyVerticalSpace();

            //Mukesh for Log Image
            view.setLogImage =ClientSession.GetUserContext().SiteConfiguration.EnableLogImage;

        }

        private void SetupCustomFieldsVariable()
        {
            customFields = IsEdit ? new List<CustomField>(editObject.CustomFields) : new List<CustomField>(customFieldsFromDb);
        }

        private void QueryCustomFields()
        {
            customFieldsFromDb = customFieldService.QueryOrderedFieldsByWorkAssignmentForSummaryLogs(userContext.Assignment);
        }

        private bool CustomFieldAssociatedWithPhTagExists()
        {
            return customFields.Exists(field => field.TagInfo != null);
        }

        public void HandleAddFunctionalLocationButtonClick(object sender, EventArgs e)
        {
                DialogResultAndOutput<List<FunctionalLocation>> result =
                    view.ShowFunctionalLocationSelector(view.AssociatedFunctionalLocations);
                if (result.Result == DialogResult.OK)
                {
                    IList<FunctionalLocation> newFlocList = result.Output;
                    view.AssociatedFunctionalLocations = newFlocList == null ? new List<FunctionalLocation>() : new List<FunctionalLocation>(newFlocList);
                }
        }

        public void HandleRemoveFunctionalLocationButtonClick(object sender, EventArgs e)
        {
            FunctionalLocation floc = view.SelectedFunctionalLocation;

            if (floc != null)
            {
                List<FunctionalLocation> associatedFlocs = view.AssociatedFunctionalLocations;
                associatedFlocs.Remove(floc);
                var newAssociatedFlocs = new List<FunctionalLocation>(associatedFlocs);

                view.AssociatedFunctionalLocations = newAssociatedFlocs;
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
            editObject.LogDateTime = view.LogDateTime;
            editObject.DocumentLinks = view.AssociatedDocumentLinks;                                                     
            editObject.FunctionalLocations = new List<FunctionalLocation>(view.AssociatedFunctionalLocations);
            editObject.RtfComments = view.RtfComments;
            editObject.PlainTextComments = view.CommentsAsPlainText;
            editObject.DorComments = view.DorComments;

            editObject.CustomFieldEntries.Clear();
            editObject.CustomFieldEntries.AddRange(CustomFieldPresenterHelper.GetCustomFieldEntriesFromView(editObject, view, customFields));

            editObject.CustomFields.Clear();
            editObject.CustomFields.AddRange(customFields);

            editObject.SelectLogIDsForSummaryPresenter = view.SelectLogIDsForSummaryPresenter;//RITM0164968- mangesh

            //Mukesh for Log Image

            editObject.Imagelist = UpoloadFileandUpdatePath(view.ImageLogdetails, editObject); //view.ImageLogdetails;
            //End Mukesh for Log Image
        }
       
        private void UpdateViewFromEditObject()
        {
            view.Author = userContext.User != null ? userContext.User.FullNameWithUserName : string.Empty;
            view.Shift = editObject.CreatedShiftPattern.Name;
            view.EHSFollowUp = editObject.EnvironmentalHealthSafetyFollowUp;
            view.OperationsFollowUp = editObject.OperationsFollowUp;
            view.ProcessControlFollowUp = editObject.ProcessControlFollowUp;
            view.InspectionFollowUp = editObject.InspectionFollowUp;
            view.SupervisionFollowUp = editObject.SupervisionFollowUp;
            view.OtherFollowUp = editObject.OtherFollowUp;
            view.LogDateTime = editObject.LogDateTime;            
            view.AssociatedDocumentLinks = editObject.DocumentLinks;

            List<FunctionalLocation> functionalLocations = editObject.FunctionalLocations;
            functionalLocations.SortByFullHierarchy();
            view.AssociatedFunctionalLocations = functionalLocations;
            view.RtfComments = editObject.RtfComments;
            view.RtfComments = editObject.PlainTextComments;
            view.SetCustomFieldEntries(editObject.CustomFieldEntries, customFields);

            view.RtfComments = editObject.RtfComments;
            view.DorComments = editObject.DorComments;

            //Mukesh for Log Image

            view.ImageLogdetails = editObject.Imagelist;
            //End Mukesh for Log Image
        }

        protected void UpdateViewWithDefaults()
        {           
            view.AssociatedDocumentLinks = new List<DocumentLink>();
            view.LogDateTime = Clock.Now;
            view.RtfComments = RichTextUtilities.ConvertTextToRTF(string.Empty);
            view.DorComments = string.Empty;
            view.SetCustomFieldEntries(customFields.ConvertAll(field => new CustomFieldEntry(field)), customFields);
            //Mukesh for Log Image
            List<LogImage> lst = new List<LogImage>();
            view.ImageLogdetails = lst;
            //End Mukesh for Log Image
            if (ClientSession.GetUserContext().SiteConfiguration.DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs)
            {
                List<FunctionalLocation> selectedFunctionalLocations = ClientSession.GetUserContext().RootsForSelectedFunctionalLocations;

                //ayman floc level 
                if (userContext.SiteConfiguration.ShiftLogFlocLevel > 0)
                {
                    switch (userContext.SiteConfiguration.ShiftLogFlocLevel)
                    {
                        case 1:
                            view.AssociatedFunctionalLocations =
                                functionalLocationService.GetDefaultFLOCs(FunctionalLocationType.Level1,
                                    selectedFunctionalLocations);
                            break;
                        case 2:
                            view.AssociatedFunctionalLocations =
                                functionalLocationService.GetDefaultFLOCs(FunctionalLocationType.Level2,
                                    selectedFunctionalLocations);
                            break;
                        case 3:
                            view.AssociatedFunctionalLocations =
                                functionalLocationService.GetDefaultFLOCs(FunctionalLocationType.Level3,
                                    selectedFunctionalLocations);
                            break;
                    }


                }
                else
                {
                    view.AssociatedFunctionalLocations = functionalLocationService.GetDefaultFLOCs(FunctionalLocationType.Level2, selectedFunctionalLocations);
                }
                
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

            if (!onlyAllowedToEditDORComments && !IsLogTimeWithinShift())
            {
                view.SetLogDateTimeError();
                hasError = true;
            }

            if (CustomFieldsHaveErrors())
            {
                hasError = true;
            }

            if (IsLogTimeInTheFuture())
            {
                view.SetLogTimeInTheFutureError();
                hasError = true;
            }

            return hasError;
        }

        private bool CustomFieldsHaveErrors()
        {
            List<CustomFieldEntry> customFieldEntries = new List<CustomFieldEntry>();
            if (IsEdit)
            {
                editObject.CustomFieldEntries.ForEach(entry => customFieldEntries.Add(new CustomFieldEntry(entry)));
            }
            else
            {
                customFields.ForEach(customField => customFieldEntries.Add(new CustomFieldEntry(customField)));
            }

            CustomFieldEntryValidator customFieldEntryValidator = new CustomFieldEntryValidator(view);
            customFieldEntryValidator.ValidateAndSetErrors(customFieldEntries);
            return customFieldEntryValidator.HasErrors;
        }

        private bool IsLogTimeWithinShift()
        {
            return userContext.UserShift.ShiftPattern.IsTimeInShiftIncludingPadding(view.ActualLoggedTime);
        }

        private bool IsLogTimeInTheFuture()
        {
            return DateTime.Compare(view.LogDateTime, Clock.Now) > 0;
        }

        public void HandleSaveClick(object sender, EventArgs e)
        {
            if (UnableToEditLogNorComment())
            {
                ShowTooLateToSaveDialogAndClose();
                return;
            }

            if (IsEdit && summaryLogService.LogIsMarkedAsRead(editObject.IdValue))
            {
                if (view.ShowLogMarkedAsReadWarning())
                {
                    SaveOrUpdate(false);

                  //Mukesh for Log Image
                  view.ImageLogdetails= logService.QueryById(editObject.IdValue).Imagelist;
                }
            }
            else
            {
                SaveOrUpdate(false);

                //Mukesh for Log Image
               foreach(LogImage Image in view.ImageLogdetails)
               {
                   Image.Action = "";
               }
               view.ImageLogdetails = view.ImageLogdetails;
            }                                 
        }

        public override void HandleSaveAndCloseButtonClick(object sender, EventArgs eventArgs)
        {
            
            //Aarti :RITM0512605:Copy feature for Shift Summary log
            if (isCopy)
            {
                base.HandleSaveAndCloseButtonClick(sender, eventArgs);
            }
            else
            {
                if (UnableToEditLogNorComment())
                {
                    ShowTooLateToSaveDialogAndClose();
                    return;
                }

               
                if (IsEdit && summaryLogService.LogIsMarkedAsRead(editObject.IdValue))
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
        }

        // In this case, the user must have opened the log before the cutoff time and then kept the window
        // open across the cutoff time.
        private bool UnableToEditLogNorComment()
        {
            if (editObject == null)
            {
                return false; // The rule doesn't matter for new summary logs
            }

            UserRoleElements userRoleElements = userContext.UserRoleElements;
            UserShift userShift = userContext.UserShift;
            Time dorEditCutoffTime = userContext.SiteConfiguration.DorEditCutoffTime;

            SummaryLogDTO currentDTO = new SummaryLogDTO(editObject);

            bool notAuthorizedToEditDORComments =
                !authorized.ToEditDORComments(userRoleElements, userShift, currentDTO, dorEditCutoffTime);
            bool notAuthorizedToEditSummaryLog = !authorized.ToEditSummaryLog(currentDTO, userContext);

            return notAuthorizedToEditDORComments && notAuthorizedToEditSummaryLog;
        }

        private void ShowTooLateToSaveDialogAndClose()
        {
            view.ShowTooLateToSaveDialog();
            shouldSkipConfirm = true;
            view.Close();
        }
        
        public override void Insert(SaveUpdateDomainObjectContainer<SummaryLog> itemToInsert)
        {
            SummaryLog summaryLogReturnedFromInsert = ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.SummaryLogCreate, summaryLogService.Insert, itemToInsert.Item);
            editObject = summaryLogReturnedFromInsert; // I'm not sure where this is used. I kept it this way to preserve whatever this functionality is.
        }

        public override void Update(SaveUpdateDomainObjectContainer<SummaryLog> itemToUpdate)
        {
            if (isCopy)
            {
                SummaryLog summaryLogReturnedFromInsert = ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.SummaryLogCreate, summaryLogService.Insert, itemToUpdate.Item);
                editObject = summaryLogReturnedFromInsert; // I'm not sure where this is used. I kept it this way to preserve whatever this functionality is.   
            }
            else
            {
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(summaryLogService.Update, itemToUpdate.Item);
            }
            
        }

        protected override SaveUpdateDomainObjectContainer<SummaryLog> GetNewObjectToInsert()
        {
            WorkAssignment workAssignment = ClientSession.GetUserContext().Assignment;

            List<CustomFieldEntry> customFieldEntries = view.CopyFromView(customFields);
            
            DateTime now = Clock.Now;
            SummaryLog summaryLog = new SummaryLog(
                view.AssociatedFunctionalLocations,
                view.RtfComments,
                view.CommentsAsPlainText,
                view.DorComments,
                DataSource.MANUAL,
                view.InspectionFollowUp,
                view.ProcessControlFollowUp,
                view.OperationsFollowUp,
                view.SupervisionFollowUp,
                view.EHSFollowUp,
                view.OtherFollowUp,
                view.LogDateTime,
                now,
                userContext.UserShift.ShiftPattern,
                userContext.User,
                userContext.Role,
                userContext.User,
                now,
                view.AssociatedDocumentLinks,
                workAssignment,
                customFieldEntries,
                customFields,
                null, null, false,
                view.SelectLogIDsForSummaryPresenter);

            //Mukesh for Log Image
            //log.Imagelist = view.ImageLogdetails;
            summaryLog.Imagelist = UpoloadFileandUpdatePath(view.ImageLogdetails, summaryLog);
            
            return new SaveUpdateDomainObjectContainer<SummaryLog>(summaryLog);
        }
        
        protected override SaveUpdateDomainObjectContainer<SummaryLog> GetPopulatedEditObjectToUpdate()
        {
            if (isCopy)
            {
                WorkAssignment workAssignment = ClientSession.GetUserContext().Assignment;

                List<CustomFieldEntry> customFieldEntries = view.CopyFromView(customFields);

                DateTime now = Clock.Now;
                SummaryLog summaryLog = new SummaryLog(
                    view.AssociatedFunctionalLocations,
                    view.RtfComments,
                    view.CommentsAsPlainText,
                    view.DorComments,
                    DataSource.MANUAL,
                    view.InspectionFollowUp,
                    view.ProcessControlFollowUp,
                    view.OperationsFollowUp,
                    view.SupervisionFollowUp,
                    view.EHSFollowUp,
                    view.OtherFollowUp,
                    view.LogDateTime,
                    now,
                    userContext.UserShift.ShiftPattern,
                    userContext.User,
                    userContext.Role,
                    userContext.User,
                    now,
                    view.AssociatedDocumentLinks,
                    workAssignment,
                    customFieldEntries,
                    customFields,
                    null, null, false,
                    view.SelectLogIDsForSummaryPresenter);

                //Mukesh for Log Image
                //log.Imagelist = view.ImageLogdetails;
                summaryLog.Imagelist = UpoloadFileandUpdatePath(view.ImageLogdetails, summaryLog);

                return new SaveUpdateDomainObjectContainer<SummaryLog>(summaryLog);
            }
            else
            {
                UpdateEditObjectFromView();
                return new SaveUpdateDomainObjectContainer<SummaryLog>(editObject);
                
            }
            
            
        }

        private bool IsFunctionLocationBlank()
        {
            return view.AssociatedFunctionalLocations.IsEmpty();
        }
        
        public void HandleViewEditHistoryButtonClick(object sender, EventArgs e)
        {
            EditSummaryLogHistoryFormPresenter presenter = new EditSummaryLogHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        public void SelectLogsForSummaryButtonClick(object sender, EventArgs e)
        {            
            DialogResultAndOutput<List<string>> result = view.ShowSelectLogsForSummaryForm();
            
            if (result.Result == DialogResult.OK)
            {
                view.AppendComments(result.Output);
            }
        }

        public void HandleLogDateTimeChanged(object sender, EventArgs e)
        {
            if (!onlyAllowedToEditDORComments)
            {
                view.LogDateTime = userContext.UserShift.StartDateTimeWithPadding.RollForward(view.ActualLoggedTime);
            }
        }

        public void HandleLogCommentGuidelineLinkClick(object sender, EventArgs e)
        {
            List<LogGuideline> logGuidelines = 
                GuidelineUtilities.GetGuidelines(ClientSession.GetUserContext().DivisionsForSelectedFunctionalLocations, logService);
            view.ShowGuidelines(logGuidelines);
        }

        public void HandleImportCustomFieldsButtonClick(object sender, EventArgs e)
        {
            ImportCustomFieldsPresenter importCustomFieldsPresenter = new ImportCustomFieldsPresenter(view, customFields);
            importCustomFieldsPresenter.Import(backgroundWorker, plantHistorianService);
        }

        public void HandleFormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) //ayman test crash
            {
                Application.UseWaitCursor = false;
                backgroundWorker.WorkerSupportsCancellation = true;
                backgroundWorker.CancelAsync();
               
            }
            else
            {
                if (backgroundWorker != null && backgroundWorker.IsBusy)
                {
                    backgroundWorker.CancelAsync();
                }
            }
        }

        public void HandleCustomFieldClick(CustomField customField)
        {
            if (customField == null || customField.Type == CustomFieldType.Heading ||
               customField.Type == CustomFieldType.BlankSpace) return;

            WorkAssignment workAssignment = ClientSession.GetUserContext().Assignment;
            CustomFieldPresenterMaker.Create(summaryLogService, customField, workAssignment).Run(view);
        }


        //Mukesh for Log Image
        public List<LogImage> UpoloadFileandUpdatePath(List<LogImage> lstImages, SummaryLog log)
        {
            foreach (LogImage Img in lstImages)
            {
                if (Img.Id == 0 && Img.Action != "Remove" && Img.Action != "")
                {
                    if (ClientSession.GetUserContext().SiteConfiguration.LogImagePath != null)
                    {
                        if (File.Exists(Img.ImagePath))
                        {
                            string fileName = userContext.SiteConfiguration.LogImagePath + ClientSession.GetUserContext().User.Username + "-" + Clock.Now.ToString("yyyyMMddTHHmmss") + "-" + Path.GetFileName(Img.ImagePath);
                            File.Copy(Img.ImagePath, fileName, true);
                            Img.ImagePath = fileName;
                        }
                    }

                }


            }
          
            return lstImages;
        }
    }
}