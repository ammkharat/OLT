using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using System.Text;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class SelectItemsForShiftSummaryPresenter : BaseFormPresenter<ISelectItemsForShiftSummaryFormView>
    {
        private readonly ILogService logService;
        private readonly IShiftHandoverService shiftHandoverService;

        private readonly Dictionary<long, Log> selectedLogsForSummaryMap = new Dictionary<long, Log>();
        private readonly Dictionary<long, ShiftHandoverQuestionnaire> selectedQuestionsForSummaryMap = new Dictionary<long, ShiftHandoverQuestionnaire>();

        public SelectItemsForShiftSummaryPresenter(ISelectItemsForShiftSummaryFormView view)
            : base(view)
        {
            logService = ClientServiceRegistry.Instance.GetService<ILogService>();
            shiftHandoverService = ClientServiceRegistry.Instance.GetService<IShiftHandoverService>();

            view.FormLoad += HandleFormLoad;
            view.AppendToCommentsButtonClicked += HandleAppendToCommentsButtonClicked;
            view.ItemSelectedForSummary += HandleItemSelectedForSummary;
            view.ItemUnselectedForSummary += HandleItemUnselectedForSummary;
            view.SelectedItemChanged += HandleSelectedItemChanged;
            view.DateRangeButtonClicked += HandleDateRangeButtonClicked;
            view.DetailsMarkedAsReadByToggled += HandleMarkedAsReadByClicked;
        }

        private void HandleMarkedAsReadByClicked(Log log)
        {
            view.MarkedAsReadByList = logService.UsersThatMarkedLogAsRead(log.IdValue);
        }

        private void HandleFormLoad()
        {
            LoadDataForCurrentShift();
        }

        public void HandleSelectedItemChanged(object item)
        {
            if (item != null)
            {
                IShiftSummaryItemGridDisplayAdapter adapter = (IShiftSummaryItemGridDisplayAdapter)item;

                if (adapter.ItemType == ShiftSummaryItemType.Log)
                {
                    LogDTOSummaryItemGridDisplayAdapter logAdapter = (LogDTOSummaryItemGridDisplayAdapter)adapter;
                    Log log = logService.QueryById(logAdapter.GetLogDTO().IdValue);

                    List<CustomField> customFields = log.CustomFields;

                    view.UseLogDetails();
                    view.SetDetails(log, customFields);
                    view.ShowDetails();
                }
                else if (adapter.ItemType == ShiftSummaryItemType.ShiftHandoverQuestions)
                {
                    ShiftHandoverQuestionsSummaryItemGridDisplayAdapter shiftHandoverQuestionsAdapter = (ShiftHandoverQuestionsSummaryItemGridDisplayAdapter)item;
                    ShiftHandoverQuestionnaire shiftHandoverQuestionnaire = shiftHandoverService.QueryById(shiftHandoverQuestionsAdapter.GetShiftHandoverQuestionnaireDTO().IdValue);

                    view.UseShiftHandoverQuestionnaireDetails();
                    view.SetDetails(shiftHandoverQuestionnaire);
                    view.ShowDetails();
                }
            }
            else
            {
                view.HideDetails();
            }
        }

        private void HandleDateRangeButtonClicked(WidgetAppearance widgetAppearance)
        {
            if (widgetAppearance == Constants.SHOW_CURRENT_WIDGET_APPEARANCE)
            {
                RefreshData(null, true);
            }
            else
            {
                DialogResultAndOutput<Range<Date>> dialogResultAndOutput = view.DisplayDateRangeDialog();
                if (dialogResultAndOutput.Result == DialogResult.OK)
                {
                    RefreshData(dialogResultAndOutput.Output, false);
                }
            }
        }

        private void RefreshData(Range<Date> dateRange, bool isCurrentlyDefault)
        {
            if (!isCurrentlyDefault)
            {
                view.ShowCurrentAppearanceForDateRangeButton();
            }
            else
            {
                view.ShowDateRangeAppearanceForDateRangeButton();
            }

            if (dateRange == null)
            {
                LoadDataForCurrentShift();
            }
            else
            {
                LoadDataForDateRange(dateRange);
            }
        }

        private void LoadDataForDateRange(Range<Date> dateRange)
        {
            UserContext userContext = ClientSession.GetUserContext();
            RootFlocSet flocSet = userContext.RootFlocSet;

            List<LogDTO> sourceLogList = logService.GetLogsForDisplay(flocSet, new DateRange(dateRange), userContext.ReadableVisibilityGroupIds);
            List<ShiftHandoverQuestionnaireDTO> sourceHandoverList = shiftHandoverService.QueryShiftHandoverQuestionnaireDTOsWithYesAnswersByFlocAndDateRange(flocSet, new DateRange(dateRange), userContext.ReadableVisibilityGroupIds);

            List<IShiftSummaryItemGridDisplayAdapter> adapterList = sourceLogList.ConvertAll(input => (IShiftSummaryItemGridDisplayAdapter)(new LogDTOSummaryItemGridDisplayAdapter(input)));
            adapterList.AddRange(sourceHandoverList.ConvertAll(input => (IShiftSummaryItemGridDisplayAdapter)(new ShiftHandoverQuestionsSummaryItemGridDisplayAdapter(input))));

            RefreshData(adapterList, dateRange);
        }

        private void LoadDataForCurrentShift()
        {
            UserContext userContext = ClientSession.GetUserContext();
            RootFlocSet flocSet = userContext.RootFlocSet;
            UserShift userShift = userContext.UserShift;

            List<LogDTO> sourceLogList = logService.QueryStandardLogsByFlocAndCurrentShift(flocSet, userShift, userContext.ReadableVisibilityGroupIds);
            List<ShiftHandoverQuestionnaireDTO> sourceHandoverList = shiftHandoverService.QueryShiftHandoverQuestionnaireDTOsWithYesAnswersByFlocAndShift(flocSet, userShift, userContext.ReadableVisibilityGroupIds);

            List<IShiftSummaryItemGridDisplayAdapter> adapterList =
                sourceLogList.ConvertAll(input => (IShiftSummaryItemGridDisplayAdapter)(new LogDTOSummaryItemGridDisplayAdapter(input)));
            adapterList.AddRange(sourceHandoverList.ConvertAll(input => (IShiftSummaryItemGridDisplayAdapter)(new ShiftHandoverQuestionsSummaryItemGridDisplayAdapter(input))));

            RefreshData(adapterList, null);
        }

        private void RefreshData(List<IShiftSummaryItemGridDisplayAdapter> adapterList, Range<Date> newDateRange)
        {
            view.HideDetails();
            view.ItemList = adapterList;

            if (newDateRange == null)
            {
                view.SetGridHeader(StringResources.ItemsForTheCurrentShift);
            }
            else
            {
                SetGridHeader(newDateRange);
            }
        }

        private void SetGridHeader(Range<Date> range)
        {
            string itemName = StringResources.Info;

            Date lowerBound = range.LowerBound;
            Date upperBound = range.UpperBound;
            if (lowerBound == upperBound)
            {
                view.SetGridHeader(string.Format(
                   StringResources.DateRangeIncludesTextForOneDay,
                   itemName + " : ",
                   lowerBound));
            }
            else
            {
                view.SetGridHeader(string.Format(
                    StringResources.DateRangeIncludesText,
                    itemName + " : ",
                    lowerBound,
                    upperBound != null ? upperBound.ToString() : StringResources.NoEnd_LowerCase));
            }
        }

        //RITM0164968-  mangesh
        public string LogIdForSummary
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                {
                    List<Log> logs = new List<Log>(selectedLogsForSummaryMap.Values);
                    logs.ForEach(log =>
                    {
                        sb.Append(log.IdValue + ",");
                    });

                }
                return Convert.ToString(sb);
            }
        }



        public List<string> LogTextForSummary
        {
            get
            {
                List<RtfChunk> allText = new List<RtfChunk>();

                {
                    List<Log> logs = new List<Log>(selectedLogsForSummaryMap.Values);
                    logs.Sort(CompareLogsByFloc);

                    logs.ForEach(log =>
                        {
                            RtfChunk rtfChunk = new RtfChunk();
                            rtfChunk.AddSubchunk(String.Format("{0} - {1}{2}", log.LogDateTime.ToLongDateAndTimeString(), log.CreationUser.FullNameWithUserName, Environment.NewLine));
                            rtfChunk.AddSubchunk(log.RtfComments);
                            allText.Add(rtfChunk);
                        });
                }

                {
                    List<ShiftHandoverQuestionnaire> questionnairesForQuestions = new List<ShiftHandoverQuestionnaire>(selectedQuestionsForSummaryMap.Values);

                    questionnairesForQuestions.ForEach(questionnaire =>
                        {
                            List<ShiftHandoverAnswer> yesAnswers = questionnaire.Answers.FindAll(answer => answer.Answer);

                            RtfChunk rtfChunk = new RtfChunk();
                            rtfChunk.AddSubchunk(String.Format("{0}{1}", questionnaire.CreateUser.FullNameWithUserName, Environment.NewLine));
                            yesAnswers.ForEach(answer => rtfChunk.AddSubchunk(String.Format("{0}. {1}{2}{3}{4}", answer.QuestionDisplayOrder + 1, answer.QuestionText, Environment.NewLine, answer.Comments, Environment.NewLine)));
                            allText.Add(rtfChunk);
                        }
                    );
                }

                List<string> textList = view.BuildCommentRichText(allText);
                return textList;
            }
        }

        private static int CompareLogsByFloc(Log log1, Log log2)
        {
            string log1FullHierarchiesString = log1.FunctionalLocations.FullHierarchyListToString(true, false);
            string log2FullHierarchiesString = log2.FunctionalLocations.FullHierarchyListToString(true, false);

            return string.CompareOrdinal(log1FullHierarchiesString, log2FullHierarchiesString);
        }

        private void HandleAppendToCommentsButtonClicked()
        {
            view.SetResultToOk();
            view.Close();
        }

        public void HandleItemSelectedForSummary(object item)
        {
            LogDTOSummaryItemGridDisplayAdapter logAdapter = item as LogDTOSummaryItemGridDisplayAdapter;
            ShiftHandoverQuestionsSummaryItemGridDisplayAdapter questionsAdapter = item as ShiftHandoverQuestionsSummaryItemGridDisplayAdapter;

            if (logAdapter != null)
            {
                Log log = logService.QueryById(logAdapter.GetLogDTO().IdValue);
                selectedLogsForSummaryMap.Add(log.IdValue, log);
            }
            else if (questionsAdapter != null)
            {
                ShiftHandoverQuestionnaire questionnaire = shiftHandoverService.QueryById(questionsAdapter.GetShiftHandoverQuestionnaireDTO().IdValue);
                selectedQuestionsForSummaryMap.Add(questionnaire.IdValue, questionnaire);
            }
        }

        public void HandleItemUnselectedForSummary(object item)
        {
            LogDTOSummaryItemGridDisplayAdapter adapter = item as LogDTOSummaryItemGridDisplayAdapter;
            ShiftHandoverQuestionsSummaryItemGridDisplayAdapter questionsAdapter = item as ShiftHandoverQuestionsSummaryItemGridDisplayAdapter;

            if (adapter != null)
            {
                Log log = logService.QueryById(adapter.GetLogDTO().IdValue);
                selectedLogsForSummaryMap.Remove(log.IdValue);
            }
            else if (questionsAdapter != null)
            {
                ShiftHandoverQuestionnaire questionnaire = shiftHandoverService.QueryById(questionsAdapter.GetShiftHandoverQuestionnaireDTO().IdValue);
                selectedQuestionsForSummaryMap.Remove(questionnaire.IdValue);
            }
        }
    }

    public class RtfChunk
    {
        readonly List<string> subchunks = new List<string>();

        public void AddSubchunk(string subchunk)
        {
            subchunks.Add(subchunk);
        }

        public bool IsEmpty()
        {
            return subchunks.TrueForAll(subchunk => subchunk.IsNullOrEmptyOrWhitespace());
        }

        public List<string> Subchunks
        {
            get { return new List<string>(subchunks); }
        }
    }
}
