using System;
using System.Collections.Generic;
using System.Globalization;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class ShiftHandoverQuestionnaireReportAdapter : AbstractLocalizedReportAdapter, IReportAdapter
    {
        private readonly List<ActionItemReportAdapter> actionItemReportAdapters;
        private readonly List<CsdReportAdapter> csdReportAdapters;
        private readonly List<EventExcursionReportAdapter> eventExcursionReportAdapters;
        private readonly List<CokerCardDrumEntryDTO> drumEntries;
        private readonly List<HasCommentsDTO> logs;
        private readonly ShiftHandoverQuestionnaire questionnaire;
        private readonly List<HasCommentsDTO> summaryLogs;

        public ShiftHandoverQuestionnaireReportAdapter(ShiftHandoverQuestionnaire questionnaire,
            ShiftHandoverQuestionnaireAssocations associatedItems, List<ActionItemReportAdapter> actionItemAdapters,
            List<CsdReportAdapter> csdAdapters,List<EventExcursionReportAdapter> eventExcursionReportAdapters )
        {
            this.questionnaire = questionnaire;
            logs = associatedItems.Logs;
            summaryLogs = associatedItems.SummaryLogs;
            drumEntries = associatedItems.CokerCard.DrumEntryDtos;
            actionItemReportAdapters = actionItemAdapters ?? new List<ActionItemReportAdapter>();
            csdReportAdapters = csdAdapters ?? new List<CsdReportAdapter>();
            this.eventExcursionReportAdapters = eventExcursionReportAdapters ?? new List<EventExcursionReportAdapter>();

            Label_Title = StringResources.ReportLabel_Title_ShiftHandover;
        }

        public string Id
        {
            get { return questionnaire.IdValue.ToString(CultureInfo.InvariantCulture); }
        }

        public bool SuppressComments
        {
            get { return logs.Count == 0 && summaryLogs.Count == 0; }
        }

        public bool SuppressCustomFields
        {
            get
            {
                return !logs.Exists(obj => obj.ContainsCustomFieldEntries()) &&
                       !summaryLogs.Exists(obj => obj.ContainsCustomFieldEntries());
            }
        }

        public bool SuppressActionItemSubreport
        {
            get { return actionItemReportAdapters.Count == 0; }
        }

        public bool SuppressCsdSubreport
        {
            get { return csdReportAdapters.Count == 0; }
        }
        
        public bool SuppressEventExcursionsSubreport
        {
            get { return eventExcursionReportAdapters.Count == 0; }
        }

        public bool SupressCokerCardSubreport
        {
            get { return drumEntries.Count == 0; }
        }

        public string CreatedByName
        {
            get { return questionnaire.CreateUser.FullNameWithUserName; }
        }

        public string CreatedDateTime
        {
            get { return questionnaire.CreateDateTime.ToLongDateAndTimeString(); }
        }

        public string Shift
        {
            get { return questionnaire.ShiftDisplayName; }
        }

        public string WorkAssignment
        {
            get
            {
                return questionnaire.Assignment != null
                    ? questionnaire.Assignment.Name
                    : Common.Domain.WorkAssignment.NoneWorkAssignment.Name;
            }
        }

        public IEnumerable<ShiftHandoverAnswerReportAdapter> AnswerReportAdapters
        {
            get
            {
                return questionnaire.SortedAnswers.ConvertAll(
                    answer => new ShiftHandoverAnswerReportAdapter(Id.ToString(CultureInfo.InvariantCulture), answer));
            }
        }

        public IEnumerable<ActionItemReportAdapter> ActionItemReportReportAdapters
        {
            get { return actionItemReportAdapters ?? new List<ActionItemReportAdapter>(0); }
        }

        public IEnumerable<CsdReportAdapter> CsdReportReportAdapters
        {
            get { return csdReportAdapters ?? new List<CsdReportAdapter>(0); }
        }
        
        public IEnumerable<EventExcursionReportAdapter> EventExcursionReportAdapters
        {
            get { return eventExcursionReportAdapters ?? new List<EventExcursionReportAdapter>(0); }
        }

        public IEnumerable<CommentsReportAdapter> CommentsReportAdapters
        {
            get
            {
                var adapters = new List<CommentsReportAdapter>();
                adapters.AddRange(CommentsReportAdapter.GetAdapters(
                    questionnaire, logs, StringResources.ReportLabel_ShiftLogs,
                    HasEitherLogsOrSummaryLogsButNotBoth(), SameUserCreatedHandoverAndLogs()));
                adapters.AddRange(CommentsReportAdapter.GetAdapters(
                    questionnaire, summaryLogs, StringResources.ReportLabel_SummaryLogs,
                    HasEitherLogsOrSummaryLogsButNotBoth(), SameUserCreatedHandoverAndLogs()));

                if (adapters.Count == 0)
                {
                    // Add a dummy one to make suppress logic in the subreport and page count work.
                    // Rely on SuppressComments to suppress the entire section and hide this
                    // dummy record.
                    adapters.Add(new CommentsReportAdapter(
                        questionnaire.IdValue.ToString(CultureInfo.InvariantCulture), string.Empty, new DateTime(),
                        string.Empty, string.Empty,
                        string.Empty, true, true));
                }

                return adapters;
            }
        }

        public IEnumerable<CustomFieldsReportAdapter> CustomFieldsReportAdapters
        {
            get
            {
                var sameUserCreatedHandoverAndAllLogs = SameUserCreatedHandoverAndLogs();
                var adapters = new List<CustomFieldsReportAdapter>();
                adapters.AddRange(CustomFieldsReportAdapter.GetCustomFields(questionnaire.IdValue, logs,
                    StringResources.ReportLabel_ShiftLogs,
                    HasEitherLogsOrSummaryLogsButNotBoth(), sameUserCreatedHandoverAndAllLogs));
                adapters.AddRange(CustomFieldsReportAdapter.GetCustomFields(questionnaire.IdValue, summaryLogs,
                    StringResources.ReportLabel_SummaryLogs,
                    HasEitherLogsOrSummaryLogsButNotBoth(), sameUserCreatedHandoverAndAllLogs));

                if (adapters.Count == 0)
                {
                    // Add a dummy one to make suppress logic in the subreport and page count work.
                    // Rely on SuppressCustomFields to suppress the entire section and hide this
                    // dummy record.
                    adapters.Add(new CustomFieldsReportAdapter(
                        questionnaire.IdValue.ToString(CultureInfo.InvariantCulture), string.Empty, string.Empty,
                        new DateTime(), string.Empty, new List<CustomFieldEntry>(),
                        string.Empty, true, true));
                }

                return adapters;
            }
        }

        public IEnumerable<CokerCardReportAdapter> CokerCardReportAdapters
        {
            get { return CokerCardReportAdapter.GetDrumEntries(questionnaire.IdValue, drumEntries); }
        }

        private bool HasEitherLogsOrSummaryLogsButNotBoth()
        {
            return logs.Count == 0 || summaryLogs.Count == 0;
        }

        private bool SameUserCreatedHandoverAndLogs()
        {
            if (logs.Exists(obj => obj.CreationUserId != questionnaire.CreateUser.Id))
            {
                return false;
            }
            if (summaryLogs.Exists(obj => obj.CreationUserId != questionnaire.CreateUser.Id))
            {
                return false;
            }
            return true;
        }
    }
}