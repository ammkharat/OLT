using System;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.DataAccess;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ActionItemResponseFormPresenter : AbstractRespondFormPresenter
    {
        private readonly IActionItemService actionItemService;
        private readonly ILogService logService;
        private readonly ActionItem respondTo;
        private ActionItemStatus originalStatus;
        private readonly IPlantHistorianService plantHistorianService;                  //ayman custom fields DMND0010030
        private List<CustomField> customFieldsFromDb;                                   //ayman custom fields DMND0010030
        private readonly ICustomFieldService customFieldService;                        //ayman custom fields DMND0010030                       
        private List<CustomField> customFields = new List<CustomField>();              //ayman custom fields DMND0010030
        private List<CustomFieldEntry> customFieldEntries = new List<CustomFieldEntry>();              //ayman custom fields DMND0010030
        private readonly ClientBackgroundWorker backgroundWorker;                      //ayman custom fields DMND0010030
        private readonly IReportPrintManager<ActionItem> reportPrintManager;                   //ayman action item email
        private List<ActionItemResponseForm.entriesText> entriesTextsForTracker = new List<ActionItemResponseForm.entriesText>();
        private List<ActionItemResponseTracker> TrackerDataForGrid = new List<ActionItemResponseTracker>();
        private readonly IWorkPermitMudsService mudsService;


        public ActionItemResponseFormPresenter(IRespondFormView view, ActionItem respondTo) : this(
            view,
            respondTo,
            ClientServiceRegistry.Instance.GetService<IActionItemService>(),
            ClientServiceRegistry.Instance.GetService<ILogService>(),
            ClientServiceRegistry.Instance.GetService<IPlantHistorianService>(),            //ayman custom fields DMND0010030
            ClientServiceRegistry.Instance.GetService<ICustomFieldService>(),               //ayman custom fields DMND0010030
            ClientServiceRegistry.Instance.GetService<IWorkPermitMudsService>()             //Added by ppanigrahi
            )            
        {
        }

        public ActionItemResponseFormPresenter(
            IRespondFormView view,
            ActionItem respondTo,
            IActionItemService actionItemService,
            ILogService logService,
            IPlantHistorianService plantHistorianService,            //ayman custom fields DMND0010030
            ICustomFieldService customFieldService,IWorkPermitMudsService mudsService)                  //ayman custom fields DMND0010030
        {
            View = view;
            this.respondTo = respondTo;
            this.plantHistorianService = plantHistorianService;               //ayman custom fields DMND0010030
            this.customFieldService = customFieldService;                     //ayman custom fields DMND0010030  
            this.mudsService = mudsService;  
            backgroundWorker = new ClientBackgroundWorker();                 //ayman custom fields DMND0010030
            CaptureOriginalStatus(respondTo);

            List<CustomFieldEntry> customFieldEntries = new List<CustomFieldEntry>();    //ayman custom fields DMND0010030

            PrintActions<ActionItem, ActionItemReport, ActionItemMainReportAdapter> printActions = new ActionItemPrintActions();           //ayman action item email

            this.actionItemService = actionItemService;
            this.logService = logService;

            reportPrintManager = new ReportPrintManager<ActionItem, ActionItemReport, ActionItemMainReportAdapter>(printActions);          //ayman action item email
        }

        private void CaptureOriginalStatus(ActionItem actionItem)
        {
            originalStatus = actionItem.Status;
        }


        //ayman custom fields DMND0010030
        public void QueryCustomFields(long actionitemId)
        {
            customFieldsFromDb = customFieldService.QueryOrderedFieldsForActionItems(actionitemId);

            if (customFieldsFromDb == null || customFieldsFromDb.Count == 0)
                view.EnableCustomFieldsLabel(false);
        }

        private void SetupCustomFieldsVariable()
        {
            customFields = customFieldsFromDb;
        }

        private bool CustomFieldAssociatedWithPhTagExists()
        {
            return customFields.Exists(field => field.TagInfo != null);
        }


        private List<Dictionary<long,string>> CheckLastReading(long actionitemdefinitoinid)
            {
                return customFieldService.GetLastReading(actionitemdefinitoinid);
            }

        public override void HandleFormLoad(object sender, EventArgs e)
        {
            base.HandleFormLoad(sender, e);
            IActionItemResponseFormView formView = FormView;

            QueryCustomFields(respondTo.IdValue);               //ayman custom fields DMND0010030

            SetupCustomFieldsVariable();       //ayman custom fields DMND0010030

//Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
            if (respondTo.CreatedByActionItemDefinition.CopyResponseToLog)
            {
                formView.CreateLogChecked = true;
            }
            else
            {
                formView.CreateLogChecked = false;
            }

            formView.ActionItemName = respondTo.Name;
            formView.Category = respondTo.CategoryName;
            formView.FunctionalLocations = respondTo.FunctionalLocations;
            formView.DetailComments = CreateLogMessage(true);

            SiteConfiguration siteConfiguration = userContext.SiteConfiguration;

            if(!siteConfiguration.CreateOperatingEngineerLogs)
            {
                formView.HideOperatingEngineerLogCheckbox();
            }
            else
            {
                formView.EnableOperatingEngineerLogCheckbox(true);    
            }
            
            formView.OperatingEngineerLogDisplayText = siteConfiguration.OperatingEngineerLogDisplayName;

            formView.IsLogAnOperatingEngineeringLog = false;

            if (siteConfiguration.RequireLogForActionItemResponse)
            {
                formView.CreateLogVisible = false;
            }

            if(!siteConfiguration.DisplayActionItemCommentOnly)
            {
                formView.HideCommentOnlyCheckbox();
            }

            var hasPhdRead = CustomField.HasAtLeastOneReadFromPhdCustomField(customFields);
            var hasPhdWrite = CustomField.HasAtLeastOneWriteToPhdCustomField(customFields);

            if (hasPhdRead || hasPhdWrite)
            {
                //view.TurnOnCustomFieldPhTagHighlights(customFields.ConvertAll(field => new CustomFieldEntry(field)),respondTo.CreatedByActionItemDefinition.Reading);
            }

            
            NonEmptyCustomFieldWithAssociatedPhTagExists();
            view.SetCustomFieldPhTagAssociationControlsVisible(hasPhdRead, hasPhdWrite);
            view.SetCustomFieldEntries(customFields.ConvertAll(field => new CustomFieldEntry(field)), customFields,respondTo);
         

            // ayman action item reading
            List<ActionItemResponseTracker> AITrackerForGrid = customFieldService.QueryForActionItemResponseTracker(respondTo.CreatedByActionItemDefinition.IdValue, respondTo.IdValue);
            if(AITrackerForGrid.Count == 0)
            {
              List<Dictionary<long,string>> lastreading =  CheckLastReading(respondTo.CreatedByActionItemDefinition.IdValue);

                AITrackerForGrid = GetTrackersFromEntries(customFields.ConvertAll(field => new CustomFieldEntry(field)),lastreading);
            }

            

            TrackerDataForGrid = AITrackerForGrid;
            if (respondTo.CreatedByActionItemDefinition.Reading)
            {
                if (AITrackerForGrid.Count > 0)
                {
                    view.TrackerList =  AITrackerForGrid;
                }
                else
                {
                    view.EnableTableLayoutPanel(false);
                }
            }
            else
            {
                if (customFields.Count > 0)
                {
                    view.EnableTableLayoutPanel(true);
                    view.EnableCustomFieldControl(true);
                }
                else
                {
                    view.EnableTableLayoutPanel(false);
                    view.EnableCustomFieldControl(false);
                }
            }

            if (respondTo.CreatedByActionItemDefinition.Reading)
            {
                formView.EnableCustomFieldControl(false);
                formView.EnableCustomFieldAreaGroupBox(AITrackerForGrid.Count > 0);
            }
            else
            {
                formView.EnableCustomFieldControl(true);
                formView.EnableCustomFieldAreaGroupBox(false);
            }


            if (respondTo.CreatedByActionItemDefinition.AutoPopulate)
            {
                FormView.CallImportCustomFields();
            }

        }

        public void HandleCustomFieldClick(CustomField customField)
        {
            if (customField == null || customField.Type == CustomFieldType.Heading ||
                customField.Type == CustomFieldType.BlankSpace) return;
            var workAssignment = ClientSession.GetUserContext().Assignment;
            CustomFieldPresenterMaker.Create(logService, customField, workAssignment).Run(view);
        }

        //Added by Mukesh for Trend .
        public void HandleCustomFieldClick(long customFieldId)
        {
            
            if (respondTo.CustomFields.Exists(C => C.Id == customFieldId))
            {
                List<CustomField> lstcustomField = respondTo.CustomFields.Where(C => C.Id == customFieldId).ToList();
                CustomField customField = lstcustomField[0];
                if (customField == null || customField.Type == CustomFieldType.Heading ||
                    customField.Type == CustomFieldType.BlankSpace) return;
                var workAssignment = ClientSession.GetUserContext().Assignment;
                CustomFieldPresenterMaker.Create(logService, customField, workAssignment).Run(view);
            }
        }
        public override void HandleCreateLogCheckedChanged(object sender, EventArgs e)
        {
            createLogs = !createLogs;

            IActionItemResponseFormView formView = FormView;
            SiteConfiguration siteConfiguration = userContext.SiteConfiguration;
            if (createLogs)
            {
                formView.EnableLogCreatedWithComments();
                formView.EnableOperatingEngineerLogCheckbox(siteConfiguration.CreateOperatingEngineerLogs);
                formView.OperatingEngineerLogDisplayText = siteConfiguration.OperatingEngineerLogDisplayName;
            }
            else
            {
                view.DisableLogCreatedWithComments();
                formView.EnableOperatingEngineerLogCheckbox(siteConfiguration.CreateOperatingEngineerLogs);
                formView.OperatingEngineerLogDisplayText = siteConfiguration.OperatingEngineerLogDisplayName;
            }

            // Added by Vibhor DMND0010736  : OLT - Adding Pictures on Action item Response
            if (view.CreateLogChecked == false)  
            {
                view.EnableActionItemImagePanel = false;
            }
            else
            {
                view.EnableActionItemImagePanel = true;
            }
            //END
        }

        //ayman custom fields DMND0010030

        private bool NonEmptyCustomFieldWithAssociatedPhTagExists()
        {
            List<CustomFieldEntry> customFieldEntries = customFields.ConvertAll(field => new CustomFieldEntry(field));
            customFieldEntries.ForEach(entry => entry.SetValue(view.GetCustomFieldEntryText(entry)));

            return customFieldEntries.Exists(entry => entry.PhdLinkType == CustomFieldPhdLinkType.Read && !entry.FieldEntryForDisplay.IsNullOrEmptyOrWhitespace());
        }

        public void HandleImportCustomFieldButtonClicked(object sender, EventArgs e)
        {
            bool aFieldWillBeOverWritten = NonEmptyCustomFieldWithAssociatedPhTagExists();
            if (aFieldWillBeOverWritten)
            {
                DialogResult dialogResult = OltMessageBox.ShowCustomYesNo((Form)view, StringResources.CustomFieldsWillBeOverwrittenWarning, StringResources.CustomFieldsWillBeOverwrittenWarningTitle, MessageBoxIcon.Warning, StringResources.Yes, StringResources.No);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            List<CustomField> importableCustomFields = customFields.FindAll(field => field.PhdLinkType == CustomFieldPhdLinkType.Read && field.TagInfo != null);
            List<TagInfo> tagInfos = importableCustomFields.ConvertAll(field => field.TagInfo);

            CustomFieldTagValueReader tagValueReader = new CustomFieldTagValueReader(backgroundWorker, plantHistorianService, view.DisableControls, view.EnableControls, DoneImportingCustomFieldsData);
            tagValueReader.Run(tagInfos);

        }



        private void DoneImportingCustomFieldsData(Dictionary<long, object> results)
        {
            List<CustomField> importableCustomFields = customFields.FindAll(field => field.TagInfo != null);
            List<CustomFieldEntry> fieldEntries = customFields.ConvertAll(field => new CustomFieldEntry(field));
            // TrackerDataForGrid = customFieldService.QueryForActionItemResponseTracker(respondTo.IdValue);
            if (TrackerDataForGrid == null || TrackerDataForGrid.Count == 0)
            {

            }
                foreach (KeyValuePair<long, object> keyValuePair in results)
                {
                long tagInfoId = keyValuePair.Key;
                //decimal? value = keyValuePair.Value;
                object value = keyValuePair.Value;


                //ayman pi average

                List<CustomField> customFieldsForTag = importableCustomFields.FindAll(field => field.PhdLinkType == CustomFieldPhdLinkType.Read && field.TagInfo.IdValue == tagInfoId);
                foreach (CustomField customField in customFieldsForTag)
                {
                    CustomFieldEntry customFieldEntry = fieldEntries.Find(entry => entry.CustomFieldName == customField.Name);

                    if (customField.TagInfo.Deleted)
                    {
                        view.SetCustomFieldEntryText(customFieldEntry, StringResources.CustomFieldTagHasBeenDeleted);
                    }
                    //else if (value.HasValue)
                    else if (value != null)
                    {
                        view.SetCustomFieldEntryText(customFieldEntry, value.ToString());
                    }
                    else
                    {
                        view.SetCustomFieldEntryText(customFieldEntry, StringResources.Unavailable);
                    }
              //     entriesTextsForTracker.Add(view.GetEntriesTextForTracker());
                }
            }

            List<ActionItemResponseForm.entriesText> entriesTexts = view.GetEntriesTextForTracker();
            SetCustomFieldEntryTextForReading(entriesTexts, TrackerDataForGrid);
            if(TrackerDataForGrid.Count > 0)
            {
                view.TrackerList = TrackerDataForGrid;
            }
        }

        //ayman action item reading
        public List<ActionItemResponseTracker> GetTrackersFromEntries(List<CustomFieldEntry> entries,List<Dictionary<long,string>> lastreading)
        {
            List<ActionItemResponseTracker> AllTrackers = new List<ActionItemResponseTracker>();
            List<ActionItemResponseForm.entriesText> entriesTexts = view.GetEntriesTextForTracker();
            var vals = new List<string>();
            foreach (CustomFieldEntry entry in entries)
            {
                if(entry.DropDownValues != null && entry.DropDownValues.Count > 0)
                {
                    vals = entry.DropDownValues.ConvertAll(fld => fld.Value);
                }
                    ActionItemResponseTracker trckr = new ActionItemResponseTracker(respondTo.CreatedByActionItemDefinition.IdValue, respondTo.IdValue, entry.CustomFieldId.Value, entry.CustomFieldName, entry.DisplayOrder, (byte)entry.Type.Id, null, null, null, (byte)entry.PhdLinkType, 0, entry.FieldEntry, vals, null);
                    AllTrackers.Insert(0,trckr);
            }

            if (lastreading.Count > 0)
            {
                for (int i = 0; i <= AllTrackers.Count - 1; i++)
                {

                    long customfiledid = AllTrackers[i].CustomFieldId;
                    string result = "";
                    if (lastreading[i].TryGetValue(AllTrackers[i].CustomFieldId, out result))   //lastreading[i].ContainsKey(customfiledid))
                    {
                        AllTrackers[i].DisplayField = result;

                        // Dictionary<long, string> val = lastreading[i];
                        // //AllTrackers[i].DisplayField = val.Keys["DisplayField"];
                        //// AllTrackers[i].DisplayField;
                    }

                }
            }

                AllTrackers.Sort(fld => fld.DisplayOrder);

            TrackerDataForGrid = AllTrackers;

            view.SetCustomFieldEntryTextForReading(AllTrackers);

            return AllTrackers;
        }


        //public CustomFieldEntry AddEntryTextToTracker(CustomFieldEntry entry)
        //{
        //    entriesText myentry = new entriesText();
        //    myentry.entry = entry;
        //    entriesTextsForTracker.Add(myentry);
        //}

        //ayman action item reading
        public void SetCustomFieldEntryTextForReading(List<ActionItemResponseForm.entriesText> entries,List<ActionItemResponseTracker> trckrdata)
        {
            entries = entries.Distinct().ToList();
            foreach(ActionItemResponseForm.entriesText entry in entries)
            {
                ActionItemResponseTracker trckr = trckrdata.Find(fld => fld.CustomFieldId == entry.entry.CustomFieldId && fld.CustomFieldName == entry.entry.CustomFieldName);

                if(trckr != null)
                {
                    trckr.FieldEntry = entry.text;
                }
            }
            TrackerDataForGrid = trckrdata;
        }
            //if (trckrdata.Contains(entry.CustomFieldId.Value))
            //{
            //    fieldIdToControlMap[entry.CustomFieldId.Value].Text = text;
            //    Regex rgx = new Regex(@"^[a-zA-Z]");   // to fix the crash ... ayman
            //    if (!rgx.IsMatch(text))
            //    {
            //        if (entry.GreaterThanValue != null && entry.GreaterThanValue >= Convert.ToDecimal(text))
            //        {
            //            fieldIdToControlMap[entry.CustomFieldId.Value].ForeColor = Color.Red;
            //        }

            //        if (entry.LessThanValue != null && entry.LessThanValue <= Convert.ToDecimal(text))
            //        {
            //            fieldIdToControlMap[entry.CustomFieldId.Value].ForeColor = Color.Red;
            //        }

            //        if (entry.MaxValueofRange != null && entry.MinValueofRange != null
            //            && entry.MinValueofRange > Convert.ToDecimal(text) ||
            //            entry.MaxValueofRange < Convert.ToDecimal(text))
            //        {
            //            fieldIdToControlMap[entry.CustomFieldId.Value].ForeColor = Color.Red;
            //        }
            //    }
            //}
        



        public void HandleCommentOnlyCheckedChanged(object sender, EventArgs e)
        {
            IActionItemResponseFormView formView = FormView;

            SiteConfiguration siteConfiguration = userContext.SiteConfiguration;

            if (formView.CommentOnly)
            {
                // Create log should be forced to true and then disabled:
                formView.CreateLogChecked = true;
                formView.CreateLogEnabled = false;

                formView.EnableOperatingEngineerLogCheckbox(false);

                // Comments box has to be enabled:
                formView.EnableLogCreatedWithComments();

                // Reset status and lock the dropdown:
                formView.SelectedActionItemStatus = originalStatus;
                formView.DisableReasonCodeDropDown();
            }
            else
            {
                formView.EnableReasonCodeDropDown();
                formView.CreateLogEnabled = true;

                formView.EnableOperatingEngineerLogCheckbox(siteConfiguration.CreateOperatingEngineerLogs);
            }
                                    
            formView.OperatingEngineerLogDisplayText = siteConfiguration.OperatingEngineerLogDisplayName;
        }

        private IActionItemResponseFormView FormView
        {
            get { return ((IActionItemResponseFormView)View); }
        }

        //ayman action item reading
        private List<ActionItemResponseTracker> GetCustomFieldEntriesForTracker(IEnumerable<CustomField> customfields)
        {
            return view.GetCustomFieldEntryTextForTracker(customfields);
        }

        //ayman custom fields DMND0010030
        private List<CustomFieldEntry> GetCustomFieldEntries(IEnumerable<CustomField> customfields)
        {
            List<CustomFieldEntry> editedCustomFieldEntries = new List<CustomFieldEntry>();

            foreach (CustomField customField in customFields)
            {
                string customFieldEntryText = view.GetCustomFieldEntryText(customField.IdValue); //view.GetCustomFieldEntryText(customField.IdValue,respondTo.CreatedByActionItemDefinition.Reading);
                if (!customFieldEntryText.IsNullOrEmptyOrWhitespace())
                {
                    CustomFieldEntry customFieldEntry = customFieldEntries.Find(entry => entry.CustomFieldId == customField.IdValue);

                    if (customFieldEntry != null)
                    {
                        customFieldEntry.SetValue(customFieldEntryText);
                        editedCustomFieldEntries.Add(customFieldEntry);
                    }
                    else
                    {
                        CustomFieldEntry brandNewEntry = new CustomFieldEntry(customField);
                        brandNewEntry.SetValue(customFieldEntryText);
                        editedCustomFieldEntries.Add(brandNewEntry);
                    }
                }
            }
            return editedCustomFieldEntries;
        }

        public List<CustomFieldEntry> GetEntriesFromTracker(List<ActionItemResponseTracker> trackers)
        {
            List<CustomFieldEntry> myentries = new List<CustomFieldEntry>();
            List<CustomFieldDropDownValue> dropDownValues = new List<CustomFieldDropDownValue>();
            foreach (ActionItemResponseTracker trckr in trackers)
            {
                if(trckr.DropDownValues.Count > 0)
                {
                   dropDownValues = null;
                   dropDownValues = actionItemService.QueryCustomFieldDropDownValues(trckr.CustomFieldId);
                }
                CustomFieldEntry entry = new CustomFieldEntry(null, trckr.CustomFieldId, trckr.CustomFieldName, trckr.FieldEntry, trckr.NumericFieldEntry, trckr.NewValue, trckr.DisplayOrder,trckr.Type, trckr.PhdLinkType,dropDownValues);
                
                myentries.Add(entry);
            }
            return myentries;
        }

        protected override bool SaveWithLog()
        {
            //ayman action item reading
            if (respondTo.CreatedByActionItemDefinition.Reading)
            {
                List<CustomFieldEntry> cfentries = new List<CustomFieldEntry>();
                var result = GetCustomFieldEntriesForTracker(customFields);
                result.Sort(fld => fld.DisplayOrder);
                respondTo.CustomFieldEntries = GetEntriesFromTracker(result);
                respondTo.CustomFields = customFields;
                respondTo.Trackers = result;
            }
            else
            {
                respondTo.CustomFieldEntries = GetCustomFieldEntries(customFields);
            }
            respondTo.Comment = FormView.Comment;                  //ayman action item email

           

           
            
            IActionItemResponseFormView formView = FormView;

            formView.ClearErrors();

            if (formView.CommentOnly && formView.Comment.IsNullOrEmptyOrWhitespace())
            {
                formView.ShowCommentOnlyError();
                
                return false;
            }
            ActionItemStatus actionStatus = formView.SelectedStatus as ActionItemStatus;
            if ((respondTo.CreatedByActionItemDefinition.workpermitId != null) && (actionStatus==ActionItemStatus.Complete))
            {
                
                long Id = respondTo.CreatedByActionItemDefinition.workpermitId ?? 0;
                if (Id != 0)
                {
                    WorkPermitMuds workpermit = mudsService.QueryById(Id);
                    workpermit.ActionItemCloseById = ClientSession.GetUserContext().User.IdValue;
                    workpermit.ActionItemCloseDateTime = Clock.Now;
                    ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(mudsService.Update,
                        workpermit);
                }

            }
            SiteConfiguration siteConfiguration = userContext.SiteConfiguration;

            if (siteConfiguration.RequireLogForActionItemResponse && formView.Comment.IsNullOrEmptyOrWhitespace() &&
                (ActionItemStatus.Incomplete == formView.SelectedActionItemStatus ||
                ActionItemStatus.Current == formView.SelectedActionItemStatus ||
                ActionItemStatus.CannotComplete == formView.SelectedActionItemStatus))
            {
                formView.ShowCommentRequiredError();
                return false;
            }

            if (formView.EnableAddButton && formView.FilePathText != string.Empty)
            {
                formView.SetErrorForAddButton();
                return false;
            }

            User currentUser = userContext.User;
            DateTime now = Clock.Now;
            
            if (formView.CommentOnly)
            {
                //only inserting the log, not changing anything on the action item.
                string logMessage = BuildLogMessageCommentOnly();

                Log logOnly = new Log(null,
                                      null,
                                      null,
                                      DataSource.ACTION_ITEM,
                                      respondTo.FunctionalLocations,
                                      false, false, false, false, false, false,
                                      logMessage,                                       
                                      logMessage,                                       
                                      now,
                                      userContext.UserShift.ShiftPattern,
                                      currentUser,
                                      currentUser,
                                      now,
                                      now,
                                      false,
                                      formView.IsLogAnOperatingEngineeringLog,
                                      userContext.Role,
                                      LogType.Standard,
                                      userContext.Assignment);

                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(logService.InsertForActionItem, logOnly, respondTo);
            }
            else
            {
                respondTo.LastModifiedBy = currentUser;
                respondTo.LastModifiedDate = now;



                ActionItemStatus newStatus = formView.SelectedStatus as ActionItemStatus;
                respondTo.SetStatus(newStatus, userContext.User, Clock.Now);

                //ayman action item email
                if (respondTo.StatusModification != null)
                {
                    if (respondTo.Status != respondTo.StatusModification.PreviousStatus && respondTo.CreatedByActionItemDefinition.SendEmail)
                    {
                        var toRecipients = respondTo.CreatedByActionItemDefinition.SendEmailTo.ToSemiColonSeparatedString(); //respondTo.CreatedByActionItemDefinition.LastModifiedBy.Username;
                        reportPrintManager.Email(respondTo, "OLT-" + formView.SelectedStatus + " Action-" + respondTo.Name, "", toRecipients);
                    }
                }

                respondTo.Imagelist_Response = formView.ActionItemResponseImageLogdetails;   // Added by Vibhor DMND0010736  : OLT - Adding Pictures on Action item Response

                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                    actionItemService.Update,
                    respondTo, 
                    BuildLogMessageWithStatusChange(), 
                    userContext.UserShift.ShiftPattern,
                    formView.IsLogAnOperatingEngineeringLog, 
                    userContext.Assignment,
                    userContext.Role);
            }

            return true;
        }

        //ayman action item email
        private static void ShowEmail(string subject, string body, string toRecipients, string ccRecipients)
        {
            var emailPresenter = new EmailPresenter();
            emailPresenter.Email(subject, body, false, toRecipients, ccRecipients);
        }


        protected override bool SaveWithoutLog()
        { 
// Added by Vibhor : INC0540499 - OLT : Responding a Action item response for Readings not retaining the values
            if (respondTo.CreatedByActionItemDefinition.Reading)
            {
                List<CustomFieldEntry> cfentries = new List<CustomFieldEntry>();
                var result = GetCustomFieldEntriesForTracker(customFields);
                result.Sort(fld => fld.DisplayOrder);
                respondTo.CustomFieldEntries = GetEntriesFromTracker(result);
                respondTo.CustomFields = customFields;
                respondTo.Trackers = result;
               
            }
            else
            {
                respondTo.CustomFieldEntries = GetCustomFieldEntries(customFields);
            }
            IActionItemResponseFormView formView = FormView;
            if (formView.CommentOnly && (formView.Comment.IsNullOrEmptyOrWhitespace()))
            {
                formView.ShowCommentOnlyError();
                return false;
            }
            ActionItemStatus newStatus = formView.SelectedStatus as ActionItemStatus;
            respondTo.SetStatus(newStatus, ClientSession.GetUserContext().User, Clock.Now);
            respondTo.Comment = FormView.Comment;                              //ayman action item email
            if ((respondTo.CreatedByActionItemDefinition.workpermitId != null) && (newStatus == ActionItemStatus.Complete))
            {

                long Id = respondTo.CreatedByActionItemDefinition.workpermitId ?? 0;
                if (Id != 0)
                {
                    WorkPermitMuds workpermit = mudsService.QueryById(Id);
                    workpermit.ActionItemCloseById = ClientSession.GetUserContext().User.IdValue;
                    workpermit.ActionItemCloseDateTime = Clock.Now;
                    ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(mudsService.Update,
                        workpermit);
                }

            }
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(actionItemService.Update, respondTo);
            return true;
        }      

        private string BuildLogMessageWithStatusChange()
        {
            return CreateLogMessage(true);
        }

        private string CreateLogMessage(bool includeStatus)
        {
            StringBuilder sb = new StringBuilder();

            string nameLine = string.Format("{0}: {1}", StringResources.ActionItemResponse_ActionItemName, respondTo.Name);
            sb.AppendLine(nameLine);
           
            if (includeStatus)
            {
                string statusLine = string.Format("{0}: {1}", StringResources.ActionItemResponse_Status, respondTo.Status);
                sb.AppendLine(statusLine);
            }
            
            if (!FormView.Comment.IsNullOrEmptyOrWhitespace())
            {
                string commentsLine = string.Format("{0}: {1}", StringResources.ActionItemResponse_Comments, FormView.Comment);
                sb.AppendLine(commentsLine);
            }

            string descriptionLine = string.Format("{0}: {1}", StringResources.ActionItemResponse_ActionItemDescription, respondTo.Description);
            sb.AppendLine(descriptionLine);                        

            return sb.ToString();
        }

        private string BuildLogMessageCommentOnly()
        {
            return CreateLogMessage(false);           
        }

        // Added by Vibhor OLT - Adding Pictures on Action item Response

        public List<LogImage> UpoloadFileandUpdatePath(List<LogImage> lstImages)
        {
            foreach (LogImage Img in lstImages)
            {
                if (Img.Id == 0 && Img.Action != "Remove")
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