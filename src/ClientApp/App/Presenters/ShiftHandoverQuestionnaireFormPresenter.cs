using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Client.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Constant = Com.Suncor.Olt.Common.Utility.Constants;
using System.Drawing;
using System.Text;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ShiftHandoverQuestionnaireFormPresenter :
        AbstractFormPresenter<IShiftHandoverQuestionnaireFormView, ShiftHandoverQuestionnaire>
    {
        private readonly IShiftHandoverService service;
        private readonly ISummaryLogService summaryLogService;
        private readonly ILogService logService;
        private readonly ICokerCardService cokerCardService;
        private readonly IFormEdmontonService formService;
        private UserShift objUsershift;

        private List<ShiftHandoverConfiguration> allConfigurations;
        private List<EmailAddress> emailAddresses;

        public ShiftHandoverQuestionnaireFormPresenter(IShiftHandoverQuestionnaireFormView view,
            ShiftHandoverQuestionnaire questionnaire)
            : base(view, questionnaire ?? CreateDefault(GetDefaultFlocs(), GetRelevantCokerCardConfigurations()))
        {
            service = ClientServiceRegistry.Instance.GetService<IShiftHandoverService>();
            summaryLogService = ClientServiceRegistry.Instance.GetService<ISummaryLogService>();
            logService = ClientServiceRegistry.Instance.GetService<ILogService>();
            cokerCardService = ClientServiceRegistry.Instance.GetService<ICokerCardService>();
            formService = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();
        }

        public static void CheckForExistingQuestionnaireBeforeOpeningForm(IMainForm view)
        {
            IShiftHandoverService shiftHandoverService =
                ClientServiceRegistry.Instance.GetService<IShiftHandoverService>();
            List<ShiftHandoverQuestionnaire> existingQuestionnaires = shiftHandoverService
                .QueryByUserWorkAssignmentAndShift(
                    ClientSession.GetUserContext().User.IdValue,
                    ClientSession.GetUserContext().WorkAssignmentId,
                    ClientSession.GetUserContext().UserShift);

            if (existingQuestionnaires.Count == 0)
            {
                ShowForm(view, null);
            }
            else
            {
                DialogResult result = DisplayShiftHandoverExistsMessageAndAskUserIfExistingShouldBeEdited(view);
                if (result == DialogResult.No)
                {
                    ShowForm(view, null);
                }
                else if (result == DialogResult.Yes)
                {
                    existingQuestionnaires.Sort((x, y) => DateTime.Compare(y.CreateDateTime, x.CreateDateTime));
                    ShiftHandoverQuestionnaire questionnaireToEdit = existingQuestionnaires[0];
                    view.SelectSectionAndItem(
                        SectionKey.ShiftHandoverSection,
                        new ShiftHandoverQuestionnaireDTO(questionnaireToEdit),
                        true);
                    ShowForm(view, questionnaireToEdit);
                }
                else
                {
                    // cancel, do nothing
                }
            }
        }

        public static bool ShowForm(IWin32Window owner, ShiftHandoverQuestionnaire questionnaire)
        {
            UserContext userContext = ClientSession.GetUserContext();
            SiteConfiguration siteConfiguration = userContext.SiteConfiguration;

            bool newHandoverWithLogCreated = false;

            if (siteConfiguration.AllowCombinedShiftHandoverAndLog &&
                (questionnaire == null || questionnaire.HasAssociatedLogOrSummaryLog))
            {
                ShiftHandoverQuestionnaireAndLogFormPresenter presenter =
                    new ShiftHandoverQuestionnaireAndLogFormPresenter(new ShiftHandoverQuestionnaireAndLogForm(),
                        questionnaire);
                presenter.Run(owner);
                newHandoverWithLogCreated = presenter.NewHandoverWithLogCreated;
            }
            else
            {
                Form newForm = new ShiftHandoverQuestionnaireForm(questionnaire);
                newForm.ShowDialog(owner);
                newForm.Dispose();
            }
            return newHandoverWithLogCreated;
        }

        private static DialogResult DisplayShiftHandoverExistsMessageAndAskUserIfExistingShouldBeEdited(IMainForm form)
        {
            DialogResult result = OltMessageBox.ShowCustomYesNo(
                (Form) form,
                StringResources.ShiftHandoverAlreadyExists,
                StringResources.ShiftHandoverAlreadyExistsTitle,
                MessageBoxIcon.Asterisk,
                StringResources.EditExistingShiftHandover,
                StringResources.CreateNewShiftHandover);
            return result;
        }

        private static List<FunctionalLocation> GetDefaultFlocs()
        {
            return ClientSession.GetUserContext().RootsForSelectedFunctionalLocationsLevelFromSiteConfig;         // ayman shift hand over floc level
        }

        public static List<long> GetRelevantCokerCardConfigurations()
        {
            if (ClientSession.GetUserContext().Assignment != null)
            {
                ICokerCardService service = ClientServiceRegistry.Instance.GetService<ICokerCardService>();
                return service.QueryCokerCardConfigurationByWorkAssignment(ClientSession.GetUserContext().Assignment);
            }
            return new List<long>();
        }

        private void QueryAllQuestions()
        {
            var workAssignment = ClientSession.GetUserContext().Assignment;
            allConfigurations = workAssignment != null
                ? service.GetAllQuestions(workAssignment.IdValue)
                : new List<ShiftHandoverConfiguration>();
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            if (userContext.IsEdmontonSite || userContext.IsSelcSite || userContext.IsSarniaSite ||
                userContext.IsMontrealSite)
            {
                view.ActiveCsdCheckBoxVisible = true;
            }
            LoadData(new List<Action> {QueryAllQuestions});
        }

        protected override void AfterDataLoad()
        {
            view.EnableDisableFlexShiftHandover(ClientSession.GetUserContext().UserRoleElements);
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.ShiftHandoverFormTitle);
            view.ViewEditHistoryEnabled = IsEdit;
            view.enableSelectShiftLogMessages = ClientSession.GetUserContext().SiteConfiguration.EnableRoundInfo;//Added by Mukesh for Operator round tool.
            view.EnableActiveCsdCheckBox(ClientSession.GetUserContext().UserRoleElements);
            if (IsEdit)
            {
                view.SetReadOnlyConfiguration(editObject.ShiftHandoverConfigurationName);
                view.MakeFunctionalLocationsReadOnly();
            }
            else
            {
                view.EnableDisableVisiblityFlexShiftHandover(ClientSession.GetUserContext().UserRoleElements);
                List<ShiftHandoverConfiguration> configurations = allConfigurations;

                if (configurations.Count == 0)
                {
                    view.ShowNoConfigurationMessageBox();
                    shouldSkipConfirm = true;
                    view.Close();
                }

                view.Configurations = configurations;
            }

            UpdateViewFromEditObject();
        }

        public static ShiftHandoverQuestionnaire CreateDefault(
            IEnumerable<FunctionalLocation> defaultFlocs,
            List<long> relevantCokerCardConfigurations)
        {
            ShiftHandoverQuestionnaire questionnaire = new ShiftHandoverQuestionnaire(
                null,
                null,
                ClientSession.GetUserContext().UserShift.ShiftPattern,
                ClientSession.GetUserContext().Assignment,
                ClientSession.GetUserContext().User,
                Clock.Now,
                defaultFlocs,
                new List<ShiftHandoverAnswer>(),
                relevantCokerCardConfigurations
                , Clock.Now, Clock.Now, false
                );

            return questionnaire;
        }

        private void UpdateViewFromEditObject()
        {
            /* amit Shukla */
            /*Flexi Shift handover RITM0185797 */
            if (IsEdit)
            {
                view.IsFlexible = editObject.IsFlexible;
                view.FlexiShiftStartDate = editObject.FlexiShiftStartDate;
                view.FlexiShiftEndDate = editObject.FlexiShiftEndDate;
            }
            else { 
            view.IsFlexible = false;
            view.FlexiShiftStartDate = Clock.Now;
            view.FlexiShiftEndDate = Clock.Now;
            }
            view.Shift = editObject.Shift.Name;
            view.Author = editObject.CreateUser;
            view.CreateDateTime = editObject.CreateDateTime;
            view.FunctionalLocations = new List<FunctionalLocation>(editObject.FunctionalLocations);
            UpdateAnswersToView();
            UpdateLogCommentsInView();
            UpdateCokerCardSummaries();
        }

        private void UpdateAnswersToView()
        {
            view.Answers = editObject.SortedAnswers;
            foreach (ShiftHandoverAnswer answer in editObject.Answers)
            {
                ShiftHandoverQuestion question = FindQuestion(answer.ShiftHandoverQuestionId);
                if (question != null)
                {
                    view.SetHelpText(question);
                    view.SetYesNo(question);//Added by ppanigrahi
                    view.SetEmailList(question);//Added ppanigrahi
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

        private void PopulateFromView()
        {
            if (!IsEdit)
            {
                editObject.ShiftHandoverConfigurationName = view.SelectedConfiguration == null
                    ? ""
                    : view.SelectedConfiguration.Name;
            }
            editObject.LastModifiedDate = Clock.Now;
            /*amit shukla RITM0185797 Flexi shift handover */
            editObject.IsFlexible = view.IsFlexible;
            if (view.IsFlexible)
            {
                editObject.FlexiShiftStartDate = view.FlexiShiftStartDate;
                editObject.FlexiShiftEndDate = view.FlexiShiftEndDate;
            }
            //else
            //{
            //    editObject.FlexiShiftStartDate = DateTime.MinValue;
            //    editObject.FlexiShiftEndDate = DateTime.MinValue;
            //}

            /**/
            UpdateEditObjectWithFunctionalLocationsFromView();

            foreach (ShiftHandoverAnswer answer in editObject.Answers)
            {
                answer.Comments = view.GetAnswerComments(answer);
                answer.Answer = view.YesNoAnswer(answer).GetValueOrDefault(false);
            }

        }

        private void UpdateEditObjectWithFunctionalLocationsFromView()
        {
            editObject.FunctionalLocations.Clear();
            editObject.FunctionalLocations.AddRange(view.FunctionalLocations);
        }

        public void HandleViewEditHistoryButtonClick(object sender, EventArgs e)
        {
            EditShiftHandoverQuestionnaireHistoryFormPresenter presenter =
                new EditShiftHandoverQuestionnaireHistoryFormPresenter(editObject);
            presenter.Run(view);
        }


        public override void Insert(SaveUpdateDomainObjectContainer<ShiftHandoverQuestionnaire> container)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Insert, container.Item);
            //Insert operator round Log
            if (view.OpeartorRoundLogText != null && view.OpeartorRoundLogText != "")
            {
                ShiftLogMessagesPresenter objShiftLogMessagesPresenter = new ShiftLogMessagesPresenter();
                objShiftLogMessagesPresenter.CreateLogforRound(GetDefaultFlocs(), view.OpeartorRoundLogText);
            }
        }

        public override void Update(SaveUpdateDomainObjectContainer<ShiftHandoverQuestionnaire> container)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, editObject,
                userContext.User);
            //Insert operator round Log
            if (view.OpeartorRoundLogText != null && view.OpeartorRoundLogText != "")
            {
                ShiftLogMessagesPresenter objShiftLogMessagesPresenter = new ShiftLogMessagesPresenter();
                objShiftLogMessagesPresenter.CreateLogforRound(GetDefaultFlocs(), view.OpeartorRoundLogText);
            }
        }

        protected override SaveUpdateDomainObjectContainer<ShiftHandoverQuestionnaire> GetNewObjectToInsert()
        {
            PopulateFromView();
            return new SaveUpdateDomainObjectContainer<ShiftHandoverQuestionnaire>(editObject);
        }

        protected override SaveUpdateDomainObjectContainer<ShiftHandoverQuestionnaire> GetPopulatedEditObjectToUpdate()
        {
            PopulateFromView();
            return new SaveUpdateDomainObjectContainer<ShiftHandoverQuestionnaire>(editObject);
        }

        public override void HandleSaveAndCloseButtonClick(object sender, EventArgs eventArgs)
        {
            IDictionary<int, string> dict = new Dictionary<int, string>();
           
            for (int i = 0; i < editObject.Answers.Count; i++)
            {
                dict.Add(i,editObject.Answers[i].Comments);
            }
            if (IsEdit && service.ShiftHandoverIsMarkedAsRead(editObject.IdValue))
            {
                if (view.ShowHandoverMarkedAsReadWarning())
                {
                    base.HandleSaveAndCloseButtonClick(sender, eventArgs);
                }
            }
            else
            {
                base.HandleSaveAndCloseButtonClick(sender, eventArgs);
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
                    var subjectText = "OLT:Answer for the  question-" + editObject.Answers[i].QuestionText;
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
                    mailSender.SendEmail(fromEmailAddress,editObject.Answers[i].EmailList, messageBodyText, subjectText);
                     
                }
            }
            if (view.ActiveCsdChecked)
            {
                if (userContext.IsSarniaSite || userContext.IsEdmontonSite || userContext.IsSelcSite)
                {
                    List<FormEdmontonOP14DTO> dtos;
                    if (userContext.SiteConfiguration.FormsFlocSetType.Equals(FunctionalLocationSetType.WorkPermit) &&
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
                    this.CreateLogforActiveCsd(GetDefaultFlocs(),lstcsdLogMessages);

                }
                if (userContext.IsMontrealSite)
                {
                    List<MontrealCsdDTO> dtos;
                    List<CsdLogMessage> lst = new List<CsdLogMessage>();
                    dtos = formService.QueryMontrealCsdsThatAreApprovedByFunctionalLocations(userContext.RootFlocSet,
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

        public override bool ValidateViewHasError()
        {

            ShiftHandoverQuestionnaireValidator validator = new ShiftHandoverQuestionnaireValidator(view);
            
            validator.ValidateAndSetErrors(editObject.Answers);

            if (view.FlextShiftHandoverStatus(ClientSession.GetUserContext().UserRoleElements) && view.IsFlexible)
                validator.ValidateFlexiShiftHandoverDates(view.FlexiShiftStartDate, view.FlexiShiftEndDate);

            return validator.HasErrors;
        }

        public void HandleFunctionalLocationButtonClick(object sender, EventArgs e)
        {
            List<FunctionalLocation> originalList = new List<FunctionalLocation>(view.FunctionalLocations);
            List<FunctionalLocation> selectedFunctionalLocations = view.FunctionalLocations;
            DialogResultAndOutput<IList<FunctionalLocation>> result =
                view.ShowFunctionalLocationSelector(selectedFunctionalLocations);

            if (result.Result == DialogResult.OK)
            {
                IList<FunctionalLocation> newFlocList = result.Output;
                view.FunctionalLocations = newFlocList == null
                    ? new List<FunctionalLocation>()
                    : new List<FunctionalLocation>(newFlocList);
                UpdateEditObjectWithFunctionalLocationsFromView();
                UpdateLogCommentsInView(originalList, view.FunctionalLocations);
            }
        }

        public void HandleFlexibleShiftHandoverCheckChange(object sender, EventArgs e)
        {
            //if (!IsEdit)  //INC0464537 : Commented by Vibhor to apply fix for INC0464537
            //{
                view.ViewFlexiShiftStartDate = (sender as CheckBox).Checked;
                view.ViewFlexiShiftEndDate = (sender as CheckBox).Checked;
                view.IsFlexible = (sender as CheckBox).Checked;
                view.Shift  = (view.IsFlexible)?"  F":editObject.Shift.Name;
                
           // }
        }

        public void HandleRemoveFunctionalLocationButtonClick(object sender, EventArgs e)
        {
            FunctionalLocation floc = view.SelectedFunctionalLocation;

            if (floc != null)
            {
                List<FunctionalLocation> originalList = new List<FunctionalLocation>(view.FunctionalLocations);
                List<FunctionalLocation> associatedFlocs = view.FunctionalLocations;
                associatedFlocs.Remove(floc);
                List<FunctionalLocation> newAssociatedFlocs = new List<FunctionalLocation>(associatedFlocs);

                view.FunctionalLocations = newAssociatedFlocs;
                UpdateEditObjectWithFunctionalLocationsFromView();
                UpdateLogCommentsInView(originalList, view.FunctionalLocations);
            }
        }

        public bool HandoverType_SelectedChanged()
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
                    //YesNoValue is added by ppanigrahi
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

        private void UpdateLogCommentsInView(List<FunctionalLocation> originalList, List<FunctionalLocation> newList)
        {
            if (!originalList.AreSameById(newList))
            {
                UpdateLogCommentsInView();
            }
        }

        private void UpdateLogCommentsInView()
        {
            if (!userContext.SiteConfiguration.EnableLogsFromOtherUsers)
            {
                 List<HasCommentsDTO> logs = GetLogs().Where(x => x.CreationUserId == ClientSession.GetUserContext().User.Id.Value).ToList(); //INC0349663 Operator Log Tool (OLT) - shift logs from other users been carried as part of ot
                 List<SummaryLog> summaryLogs = GetSummaryLogs();
                 List<HasCommentsDTO> summaryLogDtos = summaryLogs.ConvertAll(sl => new HasCommentsDTO(sl));
                 view.SetAndFormatComments(editObject, summaryLogDtos, logs);
               
            }
            //RITM0377367 Logs from Other Users should be visible in shift handover--Aarti
            else
            {
                List<HasCommentsDTO> logs = GetLogs(); 
                List<SummaryLog> summaryLogs = GetSummaryLogs();
                List<HasCommentsDTO> summaryLogDtos = summaryLogs.ConvertAll(sl => new HasCommentsDTO(sl));
                view.SetAndFormatComments(editObject, summaryLogDtos, logs);
            }
            
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

        private List<HasCommentsDTO> GetLogs()
        {
            return GetLogs(logService, view.FunctionalLocations, editObject);
        }

        public static List<HasCommentsDTO> GetLogs(ILogService logService, List<FunctionalLocation> functionalLocations,
            ShiftHandoverQuestionnaire questionnaire)
        {
            if (functionalLocations.Count > 0 && questionnaire.Assignment != null)
            {
                // amit shukla Flexi shift handover
                if (questionnaire.IsFlexible)
                {
                    return logService.QueryLogsByParentFunctionalLocationDateRangeShiftAndWorkAssignmentAndCurrentShift(
                                        questionnaire.FlexiShiftStartDate.Date.Add(questionnaire.CreatedShiftStartDateWithPadding.TimeOfDay),
                                        questionnaire.FlexiShiftEndDate.Date.Add(questionnaire.CreatedShiftEndDateWithPadding.TimeOfDay),
                                        new RootFlocSet(functionalLocations),
                                        questionnaire.Shift.IdValue,
                                        questionnaire.Assignment.Id,
                                        questionnaire.CreateUser.IdValue,true);
                }
                return logService.QueryLogsByParentFunctionalLocationDateRangeShiftAndWorkAssignmentAndCurrentShift(
                    questionnaire.CreatedShiftStartDateWithPadding,
                    questionnaire.CreatedShiftEndDateWithPadding,
                    new RootFlocSet(functionalLocations),
                    questionnaire.Shift.IdValue,
                    questionnaire.Assignment.Id,
                    questionnaire.CreateUser.IdValue);
            }
            return new List<HasCommentsDTO>();
        }

        private List<SummaryLog> GetSummaryLogs()
        {
            return GetSummaryLogs(summaryLogService, view.FunctionalLocations, editObject);
        }
        public void HandleActiveCsdLogCheck(object sender, EventArgs e)
        {

        }

        public static List<SummaryLog> GetSummaryLogs(ISummaryLogService summaryLogService,
            List<FunctionalLocation> functionalLocations, ShiftHandoverQuestionnaire questionnaire)
        {
            if (functionalLocations.Count > 0 && questionnaire.Assignment != null)
            {
                // amit shukla Flexi shift handover RITM0185797
                if (questionnaire.IsFlexible)
                {
                    return summaryLogService.QueryShiftSummaryLogsByFunctionalLocationDateRangeShiftAndWorkAssignment(
                    questionnaire.CreatedShiftStartDateWithPadding,
                    questionnaire.CreatedShiftEndDateWithPadding,
                    new RootFlocSet(functionalLocations),
                    questionnaire.Shift.IdValue,
                    questionnaire.Assignment.Id,
                    questionnaire.CreateUser.IdValue,true);
                }
                return summaryLogService.QueryShiftSummaryLogsByFunctionalLocationDateRangeShiftAndWorkAssignment(
                    questionnaire.CreatedShiftStartDateWithPadding,
                    questionnaire.CreatedShiftEndDateWithPadding,
                    new RootFlocSet(functionalLocations),
                    questionnaire.Shift.IdValue,
                    questionnaire.Assignment.Id,
                    questionnaire.CreateUser.IdValue);
            }
            return new List<SummaryLog>();
        }

        public void HanleChkActiveCSDLogChecked(object sender, EventArgs args)
        {
            ShiftLogMessagesPresenter objShiftLogMessagesPresenter = new ShiftLogMessagesPresenter();
            List<ShiftLogMessage> lstMessage = objShiftLogMessagesPresenter.Getdata();

        }
        public void CreateLogforActiveCsd(List<FunctionalLocation> FN, string logMessage)
        {
            UserContext userContext = ClientSession.GetUserContext();
           Log logonly =new Log(null,
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
            tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx10200" + @"\b \fs20"+StringResources.ActivCSD+@" \fs20 \b0 " + @"\intbl\clmrg\cell\row");


            //Table Logic started

            tableRtf.Append(@"\trowd\trgaph300");
            tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx2000" + "  " + @"\b\fs20" + StringResources.FormIdandStatus+ @" \fs20 \b0 ");
            tableRtf.Append(@"\intbl\cell");

          //  tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx4500" + " " + @"\b0" + StringResources.FL + @" \b0 ");
            tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx4500" +@"\b\fs20"+StringResources.FL + @"\fs20\b0");
            tableRtf.Append(@"\intbl\cell");

            //tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx5000" + " " + @"\b Source \b0 ");
            // tableRtf.Append(@"\intbl\cell");

            tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx10200");
            //tableRtf.Append("   " + @"\b" + StringResources.CSDText + @"\b0 " + @"\intbl\clmrg\cell\row");
            tableRtf.Append(@"\b\fs20" + StringResources.CSDText + @"\fs20\b0" + @"\intbl\clmrg\cell\row");
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