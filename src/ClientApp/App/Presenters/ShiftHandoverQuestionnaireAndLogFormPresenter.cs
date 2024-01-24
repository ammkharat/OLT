using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Client.Validation;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ShiftHandoverQuestionnaireAndLogFormPresenter : AddEditBaseFormPresenter<IShiftHandoverQuestionnaireAndLogFormView, ShiftHandoverQuestionnaire>
    {
        private readonly IShiftHandoverService handoverService;
        private readonly ILogService logService;
        private readonly ISummaryLogService summaryLogService;
        private readonly ICustomFieldService customFieldService;
        private readonly IFunctionalLocationService functionalLocationService;
        private readonly ICokerCardService cokerCardService;
        private readonly IPlantHistorianService plantHistorianService;
        private readonly IFormEdmontonService formService;//Added by ppanigrahi

        private List<CustomField> customFields = new List<CustomField>();
        private List<CustomField> customFieldsFromDb;
        private List<ShiftHandoverConfiguration> allConfigurations;
        private readonly FunctionalLocationType flocSelectionLevel;
        private Log logEditObject;
        private SummaryLog summaryLogEditObject;
        private readonly ClientBackgroundWorker backgroundWorker;
        private readonly Mode mode;
        private readonly LogTemplatePresenterHelper logTemplateHelper;
        private enum Mode
        {
            Log,
            SummaryLog
        };

        public ShiftHandoverQuestionnaireAndLogFormPresenter(IShiftHandoverQuestionnaireAndLogFormView view, ShiftHandoverQuestionnaire editObject)
            : base(view, editObject ?? ShiftHandoverQuestionnaireFormPresenter.CreateDefault(new List<FunctionalLocation>(), ShiftHandoverQuestionnaireFormPresenter.GetRelevantCokerCardConfigurations()))
        {
            Authorized authorized = new Authorized();
            bool authorizedToCreateSummaryLogs = authorized.ToCreateSummaryLogs(ClientSession.GetUserContext().UserRoleElements);
            if (IsEdit)
            {
                mode = editObject.SummaryLogId != null ? Mode.SummaryLog : Mode.Log;
            }
            else
            {
                mode = authorizedToCreateSummaryLogs ? Mode.SummaryLog : Mode.Log;   
            }

            ClientServiceRegistry clientServiceRegistry = ClientServiceRegistry.Instance;
            handoverService = clientServiceRegistry.GetService<IShiftHandoverService>();
            formService = clientServiceRegistry.GetService<IFormEdmontonService>();
            
            customFieldService = clientServiceRegistry.GetService<ICustomFieldService>();
            logService = clientServiceRegistry.GetService<ILogService>();
            functionalLocationService = clientServiceRegistry.GetService<IFunctionalLocationService>();
            summaryLogService = clientServiceRegistry.GetService<ISummaryLogService>();
            cokerCardService = clientServiceRegistry.GetService<ICokerCardService>();
            plantHistorianService = clientServiceRegistry.GetService<IPlantHistorianService>();

            ILogTemplateService logTemplateService = clientServiceRegistry.GetService<ILogTemplateService>();
            logTemplateHelper =
                new LogTemplatePresenterHelper(view, logTemplateService, userContext.Assignment, mode == Mode.Log ? LogTemplate.LogType.Standard : LogTemplate.LogType.SummaryLog);
            view.HandoverTypeChanged += HandleHandoverTypeChanged;
            view.FormLoad += HandleFormLoad;
            view.CustomFieldClicked += HandleCustomFieldClicked;
            view.AddFunctionalLocation += HandleAddFunctionalLocation;
            view.RemoveFunctionalLocation += HandleRemoveFunctionalLocation;
            view.Cancel += HandleCancel;
            view.SelectInfoForSummary += HandleSelectInfoForSummary;
            view.LogGuidelineClick += HandleLogGuidelineClick;
            view.Save += HandleSave;
            view.ActualLoggedTimeValueChanged += HandleActualLoggedTimeValueChanged;
            view.HandleLogTemplateButtonClick += logTemplateHelper.HandleInsertTemplateButtonClick;
            view.ImportCustomFields += HandleImportCustomFields;

            /**/
            view.Flexishifthandovercheck += HandleFlexishifthandovercheck;
            /**/

            flocSelectionLevel = (mode == Mode.SummaryLog || userContext.SiteConfiguration.AllowStandardLogAtSecondLevelFunctionalLocation) ? FunctionalLocationType.Level2 : FunctionalLocationType.Level3;
            backgroundWorker = new ClientBackgroundWorker();
        }

      

        public static DialogResult DisplayShiftHandoverDoesNotExistMessageAndAskUserIfTheyWantToCreateAComboHandoverAndLog(IMainForm mainForm)
        {
            return OltMessageBox.Show((Form)mainForm, StringResources.ShiftHandoverDoesNotAlreadyExist, StringResources.ShiftHandoverDoesNotAlreadyExistTitle, MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Asterisk);
        }

        private void HandleImportCustomFields()
        {
            ImportCustomFieldsPresenter importCustomFieldsPresenter = new ImportCustomFieldsPresenter(view, customFields);
            importCustomFieldsPresenter.Import(backgroundWorker, plantHistorianService);
        }

        private void HandleActualLoggedTimeValueChanged()
        {
            view.LogDateTime = userContext.UserShift.StartDateTimeWithPadding.RollForward(view.ActualLoggedTime);
        }

        private void HandleSave()
        {
            HandleSaveAndCloseButtonClicked(null, null);
        }

        protected override void HandleSaveAndCloseButtonClicked(object sender, EventArgs eventArgs)
        {
            IDictionary<int, string> dict = new Dictionary<int, string>();
            for (int i = 0; i < editObject.Answers.Count; i++)
            {
                dict.Add(i, editObject.Answers[i].Comments);
            }
            
            if (IsEdit && handoverService.ShiftHandoverIsMarkedAsRead(editObject.IdValue))
            {
                if (view.ShowHandoverMarkedAsReadWarning())
                {
                    base.HandleSaveAndCloseButtonClicked(sender, eventArgs);
                }
            }
            else
            {
                base.HandleSaveAndCloseButtonClicked(sender, eventArgs);
            }
            //Added by ppanigrahi.
            for (int i = 0; i < editObject.Answers.Count; i++)
            {
                bool YesNo = Convert.ToBoolean((view.YesNoAnswer(editObject.Answers[i])));
                bool compare;

                if (YesNo)
                {

                    string Yes = "Yes";

                    compare = Yes.Equals(editObject.Answers[i].YesNo);
                }
                else
                {
                    string No = "No";
                    compare = No.Equals(editObject.Answers[i].YesNo);
                }
               
                bool sameString = string.Equals(editObject.Answers[i].Comments, dict[dict.Keys.ElementAt(i)]);
                bool mailSend;
                if (IsEdit && sameString)
                {
                    mailSend = false;


                }
                else
                {
                    mailSend = true;
                }

                if (!string.IsNullOrEmpty(editObject.Answers[i].EmailList) && compare && !ValidateViewHasError() && mailSend)
                {
                    

                    var smtpServer = EmailSettings.SMTPServerURL;
                    var port = EmailSettings.SMTPServerPort;
                    var fromEmailAddress = EmailSettings.FromEmailAddress;

                    var mailSender = new SMTPMailSender(smtpServer, port, new EmailAddress(fromEmailAddress));
                    var subjectText = "Answer for the  question-" + editObject.Answers[i].QuestionText;
                    var messageBodyText = "<tr>" + "<td><b>Shift Name:</b></td>" + "<td>" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp&nbsp;&nbsp;" + editObject.Shift.Name + "</td>" + "</tr>" + "</br>" +
                        "<tr>" + "<td><b>Response By:</b></td>" + "<td>" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp&nbsp;&nbsp;" + ClientSession.GetUserContext().User.FullName + "</td>" + "</tr>" + "</br>" +
                        "<tr>" + "<td><b>Response Date:</b></td>" + "<td>" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp&nbsp;" + DateTime.Now.GetNetworkPortable().BuildDateTimeWithNoSecondsOrMilliseconds() + "</td>" + "</tr>" + "</br>" +
                        "<tr>" + "<td><b>Role:</b></td>" + "<td>" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp&nbsp;" + ClientSession.GetUserContext().Role.Name + "</td>" + "</tr>" + "</br>" +
                        "<tr>" + "<td><b>Work Assignment:</b></td>" + "<td>" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;" + ClientSession.GetUserContext().Assignment.DisplayName + "</td>" + "</tr>" + "</br></br>" +
                        "<tr>" + "<td><b>Question:</b></td>" + "<td>" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp&nbsp;&nbsp;" + editObject.Answers[i].QuestionText + "</td>" + "</tr>" + "</br>" +
                        "<tr>" + "<td><b>Comment:</b></td>" + "<td>" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp&nbsp;" + editObject.Answers[i].Comments + "</td>" + "</tr>";
                    
                    //</td>"Response By</td>"+"<td>Response Date</td>"+"<td>Question</th>"+"<td>Coment</td>"
                    //  "Shift Name : " + editObject.Shift.Name + Environment.NewLine +"Response By :" + 
                    //  .GetUserContext().User.FullName + Environment.NewLine +"Response Date Time: "+ DateTime.Now.GetNetworkPortable().ToDate() + Environment.NewLine +"Question :" +editObject.Answers[i].QuestionText + Environment.NewLine +"Comments to the Question :"+ editObject.Answers[i].Comments;
                    mailSender.SendEmail(fromEmailAddress, editObject.Answers[i].EmailList, messageBodyText, subjectText);

                }
                if (view.ActiveCsdChecked)
                {
                    if (userContext.IsSarniaSite || userContext.IsEdmontonSite || userContext.IsSelcSite)
                    {
                        List<FormEdmontonOP14DTO> dtos;
                        if (
                            userContext.SiteConfiguration.FormsFlocSetType.Equals(FunctionalLocationSetType.WorkPermit) &&
                            userContext.HasFlocsForWorkPermits)
                        {
                            dtos =
                                formService.QueryFormOP14sThatAreApprovedByFunctionalLocations(
                                    userContext.RootFlocSetForWorkPermits,
                                    Clock.Now.SubtractDays(1));
                        }
                        else
                        {
                            dtos =
                                formService.QueryFormOP14sThatAreApprovedByFunctionalLocations(
                                    userContext.RootFlocSet,
                                    Clock.Now.SubtractDays(1));
                        }
                        List<FormEdmontonOP14DTO> matchdtos = new List<FormEdmontonOP14DTO>();
                        List<CsdLogMessage> lst = new List<CsdLogMessage>();
                        //  List<CsdLogMessage> lstCsdLogMessages = new List<CsdLogMessage>();
                        //foreach (FormEdmontonOP14DTO dto in dtos)
                        //{

                        //    if ((Clock.Now < dto.ValidFrom.AddDays(3) || dto.RemainingApprovals.Count == 0) && dto.Status == FormStatus.Approved)
                        //    {
                        //       matchdtos.Add(dto);
                        //    }

                        //    if (dto.RemainingApprovals.Any(apr => apr.ToString().ToLower().Equals("operations manager")) && (Clock.Now < dto.ValidFrom.AddDays(3)) && dto.Status == FormStatus.Approved)
                        //    {
                        //        matchdtos.Add(dto);
                        //    }
                        //    if (dto.RemainingApprovals.Any(apr => apr.ToString().Contains("> 30")) && (Clock.Now < dto.ValidFrom.AddDays(29) && Clock.Now <= dto.ValidTo) && dto.Status == FormStatus.Approved)
                        //    {
                        //        matchdtos.Add(dto); 
                        //    } 
                        //}
                        foreach (FormEdmontonOP14DTO dto in dtos)
                        {
                            CsdLogMessage slm = new CsdLogMessage();
                            slm.Source = null;
                            slm.FormNo = dto.FormNumber;
                            slm.Staus = Convert.ToString(dto.Status);
                            slm.Floc = dto.FunctionalLocationNames;
                            slm.Message = dto.CriticalSystemDefeated;
                            slm.MessageTimeStamp = dto.CreatedDateTime;
                            //slm.UserName = dto.CreatedByFullNameWithUserName;
                            slm.Id = dto.Id;
                            // slm.ShiftLogMessageStagingId=dto.
                            lst.Add(slm);

                        }
                        string lstcsdLogMessages = this.GetTableRtfForCsd(lst);
                        this.CreateLogforActiveCsd(GetDefaultFlocs(), lstcsdLogMessages);

                    }
                    if (userContext.IsMontrealSite)
                    {
                        List<MontrealCsdDTO> dtos;
                        List<CsdLogMessage> lst = new List<CsdLogMessage>();
                        dtos = formService.QueryMontrealCsdsThatAreApprovedByFunctionalLocations(
                            userContext.RootFlocSet,
                            Clock.Now.SubtractDays(1));
                        foreach (MontrealCsdDTO dto in dtos)
                        {
                            if (dto.Status != FormStatus.Closed)
                            {
                                CsdLogMessage slm = new CsdLogMessage();
                                slm.Source = null;
                                slm.FormNo = dto.FormNumber;
                                slm.Staus = Convert.ToString(dto.Status);
                                slm.Floc = dto.FunctionalLocationNames;
                                slm.Message = dto.CriticalSystemDefeated;
                                slm.MessageTimeStamp = dto.CreatedDateTime;
                                //slm.UserName = dto.CreatedByFullNameWithUserName;
                                slm.Id = dto.Id;
                                // slm.ShiftLogMessageStagingId=dto.
                                lst.Add(slm);
                            }

                        }
                        string lstcsdLogMessages = this.GetTableRtfForCsd(lst);
                        this.CreateLogforActiveCsd(GetDefaultFlocs(), lstcsdLogMessages);

                    }
                }
            }
        }

        private void HandleLogGuidelineClick()
        {
            List<LogGuideline> logGuidelines = GuidelineUtilities.GetGuidelines(ClientSession.GetUserContext().DivisionsForSelectedFunctionalLocations, logService);
            view.ShowGuidelines(logGuidelines);
        }

        private void HandleSelectInfoForSummary()
        {
            DialogResultAndOutput<List<string>> result = view.ShowSelectInfoForSummaryForm();

            if (result.Result == DialogResult.OK)
            {
                view.AppendComments(result.Output);
            }
        }

        private void HandleCancel()
        {
            view.Close();
        }

        private void HandleRemoveFunctionalLocation()
        {
            FunctionalLocation floc = view.SelectedFunctionalLocation;

            if (floc != null)
            {
                List<FunctionalLocation> originalList = new List<FunctionalLocation>(view.FunctionalLocations);
                List<FunctionalLocation> associatedFlocs = view.FunctionalLocations;
                associatedFlocs.Remove(floc);
                List<FunctionalLocation> newAssociatedFlocs = new List<FunctionalLocation>(associatedFlocs);

                view.FunctionalLocations = newAssociatedFlocs;
                UpdateLogCommentsInView(originalList, view.FunctionalLocations);
            }
        }

        private void HandleAddFunctionalLocation()
        {
            List<FunctionalLocation> originalList = new List<FunctionalLocation>(view.FunctionalLocations);
            List<FunctionalLocation> selectedFunctionalLocations = view.FunctionalLocations;
            DialogResultAndOutput<IList<FunctionalLocation>> result = view.ShowFunctionalLocationSelector(selectedFunctionalLocations, flocSelectionLevel);

            if (result.Result == DialogResult.OK)
            {
                IList<FunctionalLocation> newFlocList = result.Output;
                view.FunctionalLocations = newFlocList == null ? new List<FunctionalLocation>() : new List<FunctionalLocation>(newFlocList);
                UpdateLogCommentsInView(originalList, view.FunctionalLocations);
            }
        }

        private void DoForLogMode(Action thingToDo) 
        {
            if (mode == Mode.Log)
            {
                thingToDo();
            }
        }

        private void DoForSummaryLogMode(Action thingToDo)
        {
            if (mode == Mode.SummaryLog)
            {
                thingToDo();
            }
        }

        private void HandleFormLoad()
        {
            if (userContext.IsEdmontonSite || userContext.IsSelcSite || userContext.IsSarniaSite ||
                userContext.IsMontrealSite)
            {
                view.ActiveCsdCheckBoxVisible = true;
            }
            LoadData(new List<Action> { logTemplateHelper.QueryLogTemplates, QueryCustomFields, QueryAllQuestions });
        }

        protected override void AfterDataLoad()
        {
            view.EnableDisableFlexShiftHandoverbyrole(ClientSession.GetUserContext().UserRoleElements);

            view.enableSelectShiftLogMessages = ClientSession.GetUserContext().SiteConfiguration.EnableRoundInfo;//Added by Mukesh for Operator round tool.
            view.EnableActiveCsdCheckBox(ClientSession.GetUserContext().UserRoleElements);//Added by ppanigrahi
            
            if (IsEdit)
            {
                view.EnableDisableFlexShiftHandover(false);
                DoForLogMode(() =>
                {
                    logEditObject = logService.QueryById(editObject.LogId.Value);
                    if (logEditObject.Deleted)
                    {
                        logEditObject = CreateDefaultLog(Clock.Now);
                    }
                });

                DoForSummaryLogMode(() =>
                {
                    summaryLogEditObject = summaryLogService.QueryById(editObject.SummaryLogId.Value);
                    if (summaryLogEditObject.Deleted)
                    {
                        summaryLogEditObject = CreateDefaultSummaryLog(Clock.Now);
                    }
                });
            }
            else
            {
                view.EnableDisableVisiblityFlexShiftHandover(ClientSession.GetUserContext().UserRoleElements);
                DateTime now = Clock.Now;
                DoForLogMode(() => { logEditObject = CreateDefaultLog(now); });
                DoForSummaryLogMode(() => { summaryLogEditObject = CreateDefaultSummaryLog(now); });
            }

            SetupCustomFieldsVariable();            

            SiteConfiguration siteConfiguration = userContext.SiteConfiguration;

            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.ShiftHandoverAndLogFormTitle);
            view.ExpandAdditionalDetails = siteConfiguration.ShowAdditionalDetailsOnLogFormByDefault;

            if (!siteConfiguration.CreateOperatingEngineerLogs)
            {
                view.HideOperatingEngineerCheckBox();
            }

            view.OperatingEngineerLogDisplayName = siteConfiguration.OperatingEngineerLogDisplayName;

            if (IsEdit)
            {
                view.SetReadOnlyConfiguration(editObject.ShiftHandoverConfigurationName);
                view.MakeFunctionalLocationsReadOnly();
            }
            else
            {
                List<ShiftHandoverConfiguration> configurations = allConfigurations;

                if (configurations.Count == 0)
                {
                    view.ShowNoConfigurationMessageBox();
                    shouldSkipConfirm = true;
                    view.Close();
                }

                view.Configurations = configurations;

                view.Author = userContext.User.FullNameWithUserName;
                view.Shift = userContext.UserShift.ShiftPattern.Name;
                view.LogDateTime = Clock.Now;
                
            }

            UpdateViewFromEditObjects();

            bool hasPhdRead = CustomField.HasAtLeastOneReadFromPhdCustomField(customFields);
            bool hasPhdWrite = CustomField.HasAtLeastOneWriteToPhdCustomField(customFields);

            if (hasPhdRead || hasPhdWrite)
            {
                view.TurnOnCustomFieldPhTagHighlights(customFields.ConvertAll(field => new CustomFieldEntry(field)));
            }

            view.SetCustomFieldPhTagAssociationControlsVisible(hasPhdRead, hasPhdWrite);

            DoForSummaryLogMode(view.HideOptionsSection);

            logTemplateHelper.LoadLogTemplates(IsEdit);

            view.SetTooltipOnExistingLogsSection(StringResources.HandoverLogComboExistingLogsTooltip);

            //Mukesh for Log Image
            view.setLogImage = ClientSession.GetUserContext().SiteConfiguration.EnableLogImage;
        }

        private void QueryAllQuestions()
        {
            allConfigurations = handoverService.GetAllQuestions(userContext.Assignment.IdValue);
        }

        private void QueryCustomFields()
        {
            DoForLogMode(() => { customFieldsFromDb = customFieldService.QueryOrderedFieldsByWorkAssignmentForLogs(userContext.Assignment); });
            DoForSummaryLogMode(() => { customFieldsFromDb = customFieldService.QueryOrderedFieldsByWorkAssignmentForSummaryLogs(userContext.Assignment); });
        }

        private SummaryLog CreateDefaultSummaryLog(DateTime now)
        {
            return new SummaryLog(
                GetDefaultFlocs(),
                null,
                null,
                string.Empty,
                DataSource.HANDOVER,
                false,
                false,
                false,
                false,
                false,
                false,
                now,
                now,
                userContext.UserShift.ShiftPattern,
                userContext.User,
                userContext.Role,
                userContext.User,
                now,
                new List<DocumentLink>(),
                userContext.Assignment,
                new List<CustomFieldEntry>(),
                customFields, 
                null, null, false);
        }

        private Log CreateDefaultLog(DateTime now)
        {
            return new Log(null,
                           null,
                           null,
                           DataSource.HANDOVER,
                           GetDefaultFlocs(),
                           false,
                           false,
                           false,
                           false,
                           false,
                           false,
                           null,
                           null,
                           now,
                           userContext.UserShift.ShiftPattern,
                           userContext.User,
                           userContext.User,
                           now,
                           now,
                           false,
                           false,
                           userContext.Role,
                           new List<DocumentLink>(), 
                           LogType.Standard,
                           false,
                           userContext.Assignment,
                           new List<CustomFieldEntry>(),
                           customFields);
        }

        private List<FunctionalLocation> GetDefaultFlocs()
        {
            return LogFormPresenterHelper.GetDefaultFlocs(functionalLocationService, flocSelectionLevel);
        }

        private void HandleCustomFieldClicked(CustomField customField)
        {
            if (customField == null || customField.Type == CustomFieldType.Heading ||
               customField.Type == CustomFieldType.BlankSpace) return;
            WorkAssignment workAssignment = ClientSession.GetUserContext().Assignment;
            CustomFieldPresenterMaker.Create(logService, customField, workAssignment).Run(view);
        }

        private void SetupCustomFieldsVariable()
        {

            //customFields = IsEdit ? new List<CustomField>(editObject.CustomFields) : customFieldsFromDb;
            if (IsEdit)
            {
                DoForLogMode(() =>
                {
                    customFields = new List<CustomField>(logEditObject.CustomFields);
                });
                DoForSummaryLogMode(() =>
                {
                    customFields = new List<CustomField>(summaryLogEditObject.CustomFields);
                });
            }
            else
            {
                customFields = new List<CustomField>(customFieldsFromDb);
            }
        }

        private void UpdateEditObjectsFromView()
        {
            if (!IsEdit)
            {
                editObject.ShiftHandoverConfigurationName = view.SelectedConfiguration == null ? "" : view.SelectedConfiguration.Name;
                /*flexi shifthandover with log*/
                editObject.IsFlexible = view.IsFlexishifthandoverWithLog;
                editObject.FlexiShiftStartDate = view.FlexiShiftStartDate;
                editObject.FlexiShiftEndDate = view.FlexiShiftEndDate;
                /**/
            }
            editObject.LastModifiedDate = Clock.Now;
            editObject.FunctionalLocations.Clear();
            editObject.FunctionalLocations.AddRange(view.FunctionalLocations);
            //if (view.IsFlexishifthandoverWithLog)
            //{
            //    editObject.FlexiShiftStartDate = view.FlexiShiftStartDate;
            //    editObject.FlexiShiftEndDate = view.FlexiShiftEndDate;
            //}
            foreach (ShiftHandoverAnswer answer in editObject.Answers)
            {
                answer.Comments = view.GetAnswerComments(answer);
                answer.Answer = view.YesNoAnswer(answer).GetValueOrDefault(false);
            }

            DoForLogMode(UpdateLogFromView);
            DoForSummaryLogMode(UpdateSummaryLogFromView);
        }

        private void UpdateSummaryLogFromView()
        {
            summaryLogEditObject.LastModifiedBy = userContext.User;
            summaryLogEditObject.DocumentLinks = view.DocumentLinks;
            summaryLogEditObject.FunctionalLocations = view.FunctionalLocations;
            summaryLogEditObject.LogDateTime = view.LogDateTime;
            summaryLogEditObject.RtfComments = view.Comments;
            summaryLogEditObject.PlainTextComments = view.CommentsAsPlainText;

            summaryLogEditObject.CustomFieldEntries.Clear();
            summaryLogEditObject.CustomFieldEntries.AddRange(CustomFieldPresenterHelper.GetCustomFieldEntriesFromView(summaryLogEditObject, view, customFields));

            summaryLogEditObject.CustomFields.Clear();
            summaryLogEditObject.CustomFields.AddRange(customFields);

            //Mukesh for Log Image
            if (view.ImageLogdetails != null)
            {
                foreach (LogImage Img in view.ImageLogdetails)
                {
                    Img.RecordType = LogImage.RecordTypes.Summary;
                }
                summaryLogEditObject.Imagelist = view.ImageLogdetails;
            }

        }

        private void UpdateLogFromView()
        {
            logEditObject.LastModifiedBy = userContext.User;
            logEditObject.IsOperatingEngineerLog = view.IsOperatingEngineerLog;
            logEditObject.DocumentLinks = view.DocumentLinks;
            logEditObject.RecommendForShiftSummary = view.RecommendForShiftSummary;
            logEditObject.FunctionalLocations = view.FunctionalLocations;
            logEditObject.LogDateTime = view.LogDateTime;
            logEditObject.RtfComments = view.Comments;
            logEditObject.PlainTextComments = view.CommentsAsPlainText;

            logEditObject.CustomFieldEntries.Clear();
            logEditObject.CustomFieldEntries.AddRange(CustomFieldPresenterHelper.GetCustomFieldEntriesFromView(logEditObject, view, customFields));

            logEditObject.CustomFields.Clear();
            logEditObject.CustomFields.AddRange(customFields);

            //Mukesh for Log Image
            if (view.ImageLogdetails != null)
            {
                foreach (LogImage Img in view.ImageLogdetails)
                {
                    Img.RecordType = LogImage.RecordTypes.Log;
                }
                logEditObject.Imagelist = view.ImageLogdetails;
            }

        }

        private void UpdateViewFromEditObjects()
        {
            UpdateAnswersToView();

            DoForLogMode(UpdateViewFromLog);
            DoForSummaryLogMode(UpdateViewFromSummaryLog);

            UpdateLogCommentsInView();
            UpdateCokerCardSummaries();
            /*Flexi shift handover with log if user clicks on edit for flexi shift handover record it should show F for shift in edit window*/
            view.Shift = (editObject.IsFlexible) ? "  F" : editObject.Shift.Name;
            
           

        }


        private void UpdateViewFromSummaryLog()
        {
            view.Author = summaryLogEditObject.CreationUser != null ? summaryLogEditObject.CreationUser.FullNameWithUserName : string.Empty;
            view.Shift = summaryLogEditObject.CreatedShiftPattern.Name;

            view.FunctionalLocations = summaryLogEditObject.FunctionalLocations;
            view.LogDateTime = summaryLogEditObject.LogDateTime;
            view.DocumentLinks = summaryLogEditObject.DocumentLinks;
            view.SetCustomFieldEntries(summaryLogEditObject.CustomFieldEntries, customFields);
            view.Comments = summaryLogEditObject.RtfComments ?? RichTextUtilities.ConvertTextToRTF(string.Empty);

             //Mukesh for Log Image
            view.ImageLogdetails=summaryLogEditObject.Imagelist??new List<LogImage>();
        }

        private void UpdateViewFromLog()
        {
            view.Author = logEditObject.CreationUser != null ? logEditObject.CreationUser.FullNameWithUserName : string.Empty;
            view.Shift = logEditObject.CreatedShiftPattern.Name;

            view.FunctionalLocations = logEditObject.FunctionalLocations;
            view.LogDateTime = logEditObject.LogDateTime;
            view.IsOperatingEngineerLog = logEditObject.IsOperatingEngineerLog;
            view.DocumentLinks = logEditObject.DocumentLinks;
            view.RecommendForShiftSummary = logEditObject.RecommendForShiftSummary;
            view.SetCustomFieldEntries(logEditObject.CustomFieldEntries, customFields);
            view.Comments = logEditObject.RtfComments ?? RichTextUtilities.ConvertTextToRTF(string.Empty);

            //Mukesh for Log Image
            view.ImageLogdetails = logEditObject.Imagelist ?? new List<LogImage>();
        }

        private void UpdateCokerCardSummaries()
        {
            if (editObject.Assignment != null)
            {
                CokerCardInfoForShiftHandoverDTO cokerCardInfoForShiftHandoverDTO
                    = cokerCardService.QueryCokerCardInfoForShiftHandover(
                        editObject.CreatedShiftStartDate,
                        editObject.Shift.IdValue,
                        editObject.Assignment.IdValue,
                        editObject.RelevantCokerCardConfigurations);

                view.AddCokerCardSummaries(cokerCardInfoForShiftHandoverDTO.DrumEntryDtos);
            }
        }

        private void UpdateLogCommentsInView()
        {
            List<HasCommentsDTO> logs = ShiftHandoverQuestionnaireFormPresenter.GetLogs(logService, view.FunctionalLocations, editObject);
            logs.RemoveAll(log => log.Id == editObject.LogId);

            if (!userContext.SiteConfiguration.EnableLogsFromOtherUsers) //RITM0377367 Logs from Other Users should be visible in shift handover--Aarti
            {
                logs = logs.Where(x => x.CreationUserId == ClientSession.GetUserContext().User.Id.Value).ToList();//INC0349663 Operator Log Tool (OLT) - shift logs from other users been carried as part of ot
            }

            List<SummaryLog> summaryLogs = ShiftHandoverQuestionnaireFormPresenter.GetSummaryLogs(summaryLogService, view.FunctionalLocations, editObject);
            summaryLogs.RemoveAll(summaryLog => summaryLog.Id == editObject.SummaryLogId);
            List<HasCommentsDTO> summaryLogDtos = summaryLogs.ConvertAll(sl => new HasCommentsDTO(sl));

            view.SetAndFormatComments(editObject, summaryLogDtos, logs);
        }

        private void UpdateLogCommentsInView(List<FunctionalLocation> originalList, List<FunctionalLocation> newList)
        {
            if (!originalList.AreSameById(newList))
            {
                UpdateLogCommentsInView();
            }
        }

        private void UpdateAnswersToView()
        {
            view.Answers = editObject.SortedAnswers;
            /**/
            view.IsFlexishifthandoverWithLog = editObject.IsFlexible;
            if (editObject.IsFlexible)
            {
                view.FlexiShiftEndDate = editObject.FlexiShiftEndDate;
                view.FlexiShiftStartDate = editObject.FlexiShiftStartDate;
                //view.IsFlexishifthandoverWithLog
            }
            /**/
            foreach (ShiftHandoverAnswer answer in editObject.Answers)
            {
                ShiftHandoverQuestion question = FindQuestion(answer.ShiftHandoverQuestionId);
                if (question != null)
                {
                    view.SetHelpText(question);
                }
            }
        }

        private ShiftHandoverQuestion FindQuestion(long shiftHandoverQuestionId)
        {
            // #3114 - allConfigurations contains the questions already. use it instead of this query?
            foreach (ShiftHandoverConfiguration item in allConfigurations)
            {
                ShiftHandoverQuestion shiftHandoverQuestion = item.Questions.Find(q => q.Id == shiftHandoverQuestionId);
                if (shiftHandoverQuestion != null)
                {
                    return shiftHandoverQuestion;
                }
            }
            return null;
        }

        private bool HandleHandoverTypeChanged()
        {
            if ((!HasEnteredAnswers() || view.ConfirmDeleteExistingAnswers()))
            {
                PopulateAnswersBasedOnSelectedConfiguration();
                UpdateAnswersToView();
                return true;
            }
            view.RevertToLastSelectedConfiguration();

            return false;
        }

        private void PopulateAnswersBasedOnSelectedConfiguration()
        {
            if (view.SelectedConfiguration != null)
            {
                editObject.Answers.Clear();
                foreach (ShiftHandoverQuestion question in view.SelectedConfiguration.Questions)
                {
                    //YesNoValue and EmailList is added by ppanigrahi
                    editObject.Answers.Add(new ShiftHandoverAnswer(
                        null,
                        false,
                        null,
                        question.Text,
                        question.YesNoValue,
                        question.EmailList,
                        question.DisplayOrder,
                        question.IdValue));
                }
            }
        }

        private bool HasEnteredAnswers()
        {
            if (editObject.Answers.Count == 0)
            {
                return false;
            }

            return editObject.Answers.TrueForAll(answer => view.GetAnswerComments(answer).HasValue()) &&
                   editObject.Answers.TrueForAll(answer => view.HasAnsweredYesNo(answer));
        }

        protected override void Insert()
        {
            UpdateEditObjectsFromView();

            DoForLogMode(() =>
                {
                    Log log = ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.LogCreate, logService.Insert, logEditObject);
                    editObject.LogId = log.IdValue;
                });

            DoForSummaryLogMode(() =>
                {
                    SummaryLog summaryLog = ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.SummaryLogCreate, summaryLogService.Insert, summaryLogEditObject);
                    editObject.SummaryLogId = summaryLog.IdValue;
                });

            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(handoverService.Insert, editObject);
            NewHandoverWithLogCreated = true;


            //Insert operator round Log
            if (view.OpeartorRoundLogText != null && view.OpeartorRoundLogText != "")
            {
                ShiftLogMessagesPresenter objShiftLogMessagesPresenter = new ShiftLogMessagesPresenter();
                objShiftLogMessagesPresenter.CreateLogforRound(GetDefaultFlocs(), view.OpeartorRoundLogText);
            }
        }

        public bool NewHandoverWithLogCreated
        {
            get; private set;
        }

        protected override void Update()
        {
            UpdateEditObjectsFromView();

            DoForLogMode(() =>
                {
                    if (logEditObject.IsInDatabase())
                    {
                        ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(logService.Update, logEditObject);
                    }
                    else
                    {
                        Log log = ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.LogCreate, logService.Insert, logEditObject);
                        editObject.LogId = log.IdValue;
                    }
                });

            DoForSummaryLogMode(() =>
                {
                    if (summaryLogEditObject.IsInDatabase())
                    {
                        ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(summaryLogService.Update, summaryLogEditObject);
                    }
                    else
                    {
                        SummaryLog summaryLog = ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.SummaryLogCreate, summaryLogService.Insert, summaryLogEditObject);
                        editObject.SummaryLogId = summaryLog.IdValue;
                    }
                });

            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(handoverService.Update, editObject, userContext.User);


            //Insert operator round Log
            if (view.OpeartorRoundLogText != null && view.OpeartorRoundLogText != "")
            {
                ShiftLogMessagesPresenter objShiftLogMessagesPresenter = new ShiftLogMessagesPresenter();
                objShiftLogMessagesPresenter.CreateLogforRound(GetDefaultFlocs(), view.OpeartorRoundLogText);
            }
        }
        

        protected override bool ValidateViewHasError()
        {
            ((IAddEditBaseFormView)view).ClearErrorProviders();

            ShiftHandoverQuestionnaireValidator questionnaireValidator = new ShiftHandoverQuestionnaireValidator(view);
            questionnaireValidator.ValidateAndSetErrors(editObject.Answers);
            // if user has access to flexishifthandover and if flexishifthandover check box is checked performthe validation
            if (view.FlextShiftHandoverStatus(ClientSession.GetUserContext().UserRoleElements) && view.IsFlexishifthandoverWithLog)
            questionnaireValidator.ValidateFlexiShiftHandoverDates(view.FlexiShiftStartDate, view.FlexiShiftEndDate);

            bool hasQuestionnaireError = questionnaireValidator.HasErrors;

            List<CustomFieldEntry> customFieldEntries = customFields.ConvertAll(field => new CustomFieldEntry(field));
            LogValidator logValidator = new LogValidator(view, ClientSession.GetUserContext());
            logValidator.ValidateAndSetErrors(customFieldEntries);
            bool hasLogError = logValidator.HasErrors;

            return hasQuestionnaireError || hasLogError;
        }

        /**/
        void HandleFlexishifthandovercheck(bool val)
        {
            if (!IsEdit)
            {
                view.ViewFlexiShiftStartDate = val;
                view.ViewFlexiShiftEndDate = val;
                view.IsFlexishifthandoverWithLog = val;
                view.Shift = (view.IsFlexishifthandoverWithLog) ? "  F" : editObject.Shift.Name;
            }
        }

        /**/
        //Added by ppanigrahi
        public void CreateLogforActiveCsd(List<FunctionalLocation> FN, string logMessage)
        {
            UserContext userContext = ClientSession.GetUserContext();
            Log logonly = new Log(null,
                                      null,
                                      null,
                                      DataSource.ACTIVE_CSD,
                                      FN,
                                      false, false, false, false, false, false,
                                      logMessage,
                                      "",
                                      DateTime.Now,
                                      userContext.UserShift.ShiftPattern,
                                      userContext.User,
                                      userContext.User,
                                        DateTime.Now,
                                        DateTime.Now,
                                      false,
                                      false,
                                      userContext.Role,
                                      LogType.Standard,
                                      userContext.Assignment);
            ClientServiceRegistry clientServiceRegistry = ClientServiceRegistry.Instance;
            ILogService logservice = clientServiceRegistry.GetService<ILogService>();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.LogCreate, logservice.Insert, logonly);
        }
        public String GetTableRtfForCsd(List<CsdLogMessage> lst)
          {


            StringBuilder tableRtf = new StringBuilder();


            tableRtf.Append(@"{\rtf1\fbidis\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Arial;}}");

            //tableRtf.Append(@"{\rtf1");

            tableRtf.Append(@"\trowd\trgaph300");
            tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx10200" + @"\b \fs20" + StringResources.ActivCSD + @" \fs20 \b0 " + @"\intbl\clmrg\cell\row");


            //Table Logic started

            tableRtf.Append(@"\trowd\trgaph300");
            tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx2000" + "  " + @"\b\fs20" + StringResources.FormIdandStatus + @" \fs20 \b0 ");
            tableRtf.Append(@"\intbl\cell");

            tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx4500" + " " + @"\b" + StringResources.FL + @" \b0 ");
            tableRtf.Append(@"\intbl\cell");

            //tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx5000" + " " + @"\b Source \b0 ");
            // tableRtf.Append(@"\intbl\cell");

            tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx10200");
            tableRtf.Append("   " + @"\b" + StringResources.CSDText + @"\b0 " + @"\intbl\clmrg\cell\row");
            int j = 0;
            foreach (CsdLogMessage message in lst)
            {

                tableRtf.Append(@"\trowd");
                tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx2000" + "  " + message.FormNo + "-" + message.Staus);
                tableRtf.Append(@"\intbl\cell");

                tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx4500" + " " + message.Floc);
                tableRtf.Append(@"\intbl\cell");

                // tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx5000" + " " + Message.Source);
                //tableRtf.Append(@"\intbl\cell");

                tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx10200");
                tableRtf.Append("   " + message.Message + @"\intbl\clmrg\cell\row");



            }


            tableRtf.Append(@"\pard");
            tableRtf.Append(@"}");

            return tableRtf.ToString();

        }

       
    }
}