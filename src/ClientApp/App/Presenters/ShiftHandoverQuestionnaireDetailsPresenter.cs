using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ShiftHandoverQuestionnaireDetailsPresenter
    {
        private readonly IShiftHandoverQuestionnaireDetails view;
        private readonly ShiftHandoverQuestionnaire questionnaire;
        private readonly IShiftHandoverService shiftHandoverService;

        private List<HasCommentsDTO> logs = new List<HasCommentsDTO>();
        private List<HasCommentsDTO> logsaddedbysummarylog = new List<HasCommentsDTO>();//RITM0164968 mangesh
        private List<HasCommentsDTO> summaryLogs = new List<HasCommentsDTO>();
        private readonly Dictionary<long, List<CustomField>> summaryLogIdToCustomFieldsMap = new Dictionary<long, List<CustomField>>();
        private readonly Dictionary<long, List<CustomField>> logIdToCustomFieldsMap = new Dictionary<long, List<CustomField>>();
        private CokerCardInfoForShiftHandoverDTO cokerCardInfoForShiftHandoverDto = new CokerCardInfoForShiftHandoverDTO(new List<CokerCardDrumEntryDTO>());

        public ShiftHandoverQuestionnaireDetailsPresenter(IShiftHandoverQuestionnaireDetails view, ShiftHandoverQuestionnaire questionnaire)
            : this(
            view, 
            questionnaire,
            ClientServiceRegistry.Instance.GetService<IShiftHandoverService>())
        {
        }

        private ShiftHandoverQuestionnaireDetailsPresenter(IShiftHandoverQuestionnaireDetails view, ShiftHandoverQuestionnaire questionnaire,
                                                           IShiftHandoverService shiftHandoverService)
        {
            this.view = view;
            this.questionnaire = questionnaire;
            this.shiftHandoverService = shiftHandoverService;

            GetAssociatedItemsFromDatabase();
            summaryLogIdToCustomFieldsMap = BuildSummaryLogToCustomFieldsMap(summaryLogs);
            //logIdToCustomFieldsMap = BuildLogToCustomFieldsMap(logs);

            //RITM0164968 mangesh- comment above line and added below lines
            if (ClientSession.GetUserContext().SiteConfiguration.AllowCustomFieldsToBePartOfAddShiftInfo)
            {
                GetLogItems();
                logsaddedbysummarylog.AddRange(logs);
                logIdToCustomFieldsMap = BuildLogToCustomFieldsMap(logsaddedbysummarylog);
            }
            else
            {
                logIdToCustomFieldsMap = BuildLogToCustomFieldsMap(logs);
            }
        }

        private void GetLogItems()
        {
            ShiftHandoverQuestionnaireAssocations items = shiftHandoverService.QueryAssocationedLogItems(questionnaire.IdValue, questionnaire.CreatedShiftStartDate,
                                                                             questionnaire.Shift.IdValue,
                                                                             questionnaire.Assignment.IdValue,
                                                                             questionnaire.RelevantCokerCardConfigurations);
            if (!ClientSession.GetUserContext().SiteConfiguration.EnableLogsFromOtherUsers)
            { 
            logsaddedbysummarylog = items.Logs.Where(x => x.CreationUserId == Questionnaire.CreateUser.IdValue).ToList(); //INC0349663 Operator Log Tool (OLT) - shift logs from other users been carried as part of ot;
            }
            else
            {
                logsaddedbysummarylog = items.Logs; ////RITM0377367 Logs from Other Users should be visible in shift handover--Aartis
            }
            

        }

        private void GetAssociatedItemsFromDatabase()
        {
            ShiftHandoverQuestionnaireAssocations items = shiftHandoverService.QueryAssocationedItems(questionnaire.IdValue, questionnaire.CreatedShiftStartDate,
                                                                             questionnaire.Shift.IdValue,
                                                                             questionnaire.Assignment.IdValue,
                                                                             questionnaire.RelevantCokerCardConfigurations,
                                                                             ClientSession.GetUserContext().Site.Id.Value);
            if (!ClientSession.GetUserContext().SiteConfiguration.EnableLogsFromOtherUsers)
            {
                logs = items.Logs.Where(x => x.CreationUserId == Questionnaire.CreateUser.IdValue).ToList();
                    //INC0349663 Operator Log Tool (OLT) - shift logs from other users been carried as part of ot
                summaryLogs =items.SummaryLogs.Where(x => x.CreationUserId == Questionnaire.CreateUser.IdValue).ToList();
                    //INC0349663 Operator Log Tool (OLT) - shift logs from other users been carried as part of ot;
            }
            //RITM0377367 Logs from Other Users should be visible in shift handover--Aarti
            else
            {
                logs = items.Logs; 
                summaryLogs = items.SummaryLogs; 
            }
           
            cokerCardInfoForShiftHandoverDto = items.CokerCard;
        }

       
        public ShiftHandoverQuestionnaire Questionnaire
        {
            get { return questionnaire; }
        }

        public void LoadView()
        {
            if (questionnaire == null)
            {
                PopulateEmptyView();
            }
            else
            {
                MapToView();
            }
        }

        private void MapToView()
        {
            view.CreatedBy = questionnaire.CreateUser.FullNameWithUserName;
            view.CreatedDateTime = questionnaire.CreateDateTime.ToLongDateAndTimeString();

            view.FunctionalLocations = questionnaire.FunctionalLocations;
            view.ShiftHandoverConfigurationName = questionnaire.ShiftHandoverConfigurationName;
            view.Assignment = questionnaire.Assignment;

            MapLogsAndSummaryLogsToView();

            MapCokerCardSummariesToView();

            MapSummaryLogCustomFieldEntriesToView();
            MapLogCustomFieldEntriesToView();

            view.Answers = questionnaire.SortedAnswers;
        }

        private void MapCokerCardSummariesToView()
        {
            view.AddCokerCardSummaries(cokerCardInfoForShiftHandoverDto.DrumEntryDtos);
        }

        private void MapSummaryLogCustomFieldEntriesToView()
        {
            List<long> idsForSummaryLogsWithCustomFields = summaryLogIdToCustomFieldsMap.FindAll(pair => !pair.Value.IsEmpty()).ConvertAll(pair => pair.Key);
            List<HasCommentsDTO> summaryLogsWithCustomFields = summaryLogs.FindAll(log => idsForSummaryLogsWithCustomFields.Contains(log.IdValue));

            
            if (summaryLogsWithCustomFields.Exists(summaryLog => summaryLog.ContainsCustomFieldEntries()))
            {
                view.AddSummaryLogCustomFieldEntries(summaryLogsWithCustomFields, summaryLogIdToCustomFieldsMap);
            }
            else
            {
                view.HideSummaryLogCustomFieldEntries();
            }
        }


        private void MapLogCustomFieldEntriesToView()
        {
            //RITM0164968 mangesh
            //if (ClientSession.GetUserContext().SiteConfiguration.AllowCustomFieldsToBePartOfAddShiftInfo)
            //{
            //     logs = logsaddedbysummarylog;  previous code
            //}
            List<long> idsForLogsWithCustomFields = logIdToCustomFieldsMap.FindAll(pair => !pair.Value.IsEmpty()).ConvertAll(pair => pair.Key);
            //RITM0164968 mangesh - Modified by Amit
            List<HasCommentsDTO> logsWithCustomFields =
                ClientSession.GetUserContext().SiteConfiguration.AllowCustomFieldsToBePartOfAddShiftInfo
                    ? logsaddedbysummarylog.FindAll(log => idsForLogsWithCustomFields.Contains(log.IdValue))
                    : logs.FindAll(log => idsForLogsWithCustomFields.Contains(log.IdValue));

            if (logsWithCustomFields.Exists(log => log.ContainsCustomFieldEntries()))
            {
                view.AddShiftLogCustomFieldEntries(logsWithCustomFields, logIdToCustomFieldsMap);
            }
            else
            {
                view.HideShiftLogCustomFieldEntries();
            }
        }

        private void MapLogsAndSummaryLogsToView()
        {
            view.SetAndFormatComments(questionnaire, summaryLogs, logs);                 
        }

        private Dictionary<long, List<CustomField>> BuildLogToCustomFieldsMap(IEnumerable<HasCommentsDTO> logs)
        {
            Dictionary<long, List<CustomField>> logIdToCustomFieldLists = new Dictionary<long, List<CustomField>>();
            foreach (HasCommentsDTO log in logs)
            {
                if (!logIdToCustomFieldLists.ContainsKey(log.IdValue)) { 
                List<CustomField> customFields = log.CustomFields;
                logIdToCustomFieldLists.Add(log.IdValue, customFields);
                }
            }

            return logIdToCustomFieldLists;
        }

        private Dictionary<long, List<CustomField>> BuildSummaryLogToCustomFieldsMap(IEnumerable<HasCommentsDTO> summaryLogs)
        {
            Dictionary<long, List<CustomField>> summaryLogIdToCustomFieldLists = new Dictionary<long, List<CustomField>>();
            foreach (HasCommentsDTO summaryLog in summaryLogs)
            {
                summaryLogIdToCustomFieldLists.Add(summaryLog.IdValue, summaryLog.CustomFields);
            }

            return summaryLogIdToCustomFieldLists;
        }

        private void PopulateEmptyView()
        {
            view.CreatedBy = string.Empty;
            view.CreatedDateTime = string.Empty;
            view.FunctionalLocations = new List<FunctionalLocation>();
            view.Assignment = null;

            view.ShiftHandoverConfigurationName = String.Empty;
            view.Answers = new List<ShiftHandoverAnswer>();
            view.ClearComments();

            view.MarkedAsReadBy = new List<ItemReadBy>();
        }

        public bool ShouldUpdateCurrentQuestionnaireOnCokerCardChange(CokerCard cokerCard)
        {
            bool isSameShift = questionnaire.Shift.Id == cokerCard.Shift.Id &&
                               questionnaire.CreatedShiftStartDate == cokerCard.ShiftStartDate;

            if (isSameShift)
            {
                if (cokerCard.WorkAssignment != null && questionnaire.Assignment.Id == cokerCard.WorkAssignment.Id)
                {
                    return true;
                }
                if (questionnaire.RelevantCokerCardConfigurations.Exists(
                    relevantConfigurationId => relevantConfigurationId == cokerCard.ConfigurationId))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

