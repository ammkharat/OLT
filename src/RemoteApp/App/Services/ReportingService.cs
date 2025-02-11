using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Analytics;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using log4net;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ReportingService : IReportingService
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<ReportingService>();

        private readonly ICustomFieldTrendReportDTODao customFieldTrendReportDtoDao;
        private readonly IDetailedLogReportDTODao detailedLogReportDtoDao;
        private readonly IDeviationAlertReportDTODao deviationAlertReportDtoDao;

        private readonly IDirectiveDTODao directiveDtoDao;
        private readonly IEventDao eventDao;
        private readonly IFormOilsandsTrainingReportDTODao formOilsandsTrainingReportDtoDao;
        private readonly ILogDTODao logDtoDao;

        private readonly IPlantHistorianService plantHistorianService;
        private readonly IShiftHandoverQuestionnaireDao questionnaireDao;
        private readonly IShiftHandoverQuestionnaireDTODao questionnaireDtoDao;
        private readonly ISafeWorkPermitAssessmentReportDTODao safeWorkPermitAssessmentReportDTODao;
        private readonly ISummaryLogDTODao summaryLogDtoDao;

        private readonly IActionItemDao actionItemDao;             //ayman action item reading

        private readonly ITargetAlertDao targetAlertDao;
        private readonly ITargetAlertDTODao targetAlertDtoDao;

        private readonly ITargetAlertResponseDao targetAlertResponseDao;

        private readonly IFormOP14Dao formOp14Dao;

        public ReportingService()
            : this(new PlantHistorianService(),
                DaoRegistry.GetDao<ILogDTODao>(),
                DaoRegistry.GetDao<ISummaryLogDTODao>(),
                DaoRegistry.GetDao<IActionItemDao>(),
                DaoRegistry.GetDao<IDetailedLogReportDTODao>(),
                DaoRegistry.GetDao<IShiftHandoverQuestionnaireDTODao>(),
                DaoRegistry.GetDao<ITargetAlertDao>(),
                DaoRegistry.GetDao<ITargetAlertDTODao>(),
                DaoRegistry.GetDao<ISafeWorkPermitAssessmentReportDTODao>(),
                DaoRegistry.GetDao<ITargetAlertResponseDao>(),
                DaoRegistry.GetDao<IDeviationAlertReportDTODao>(),
                DaoRegistry.GetDao<IShiftHandoverQuestionnaireDao>(),
                DaoRegistry.GetDao<ICustomFieldTrendReportDTODao>(),
                DaoRegistry.GetDao<IFormOilsandsTrainingReportDTODao>(),
                DaoRegistry.GetDao<IEventDao>(),
                DaoRegistry.GetDao<IDirectiveDTODao>(),
                DaoRegistry.GetDao<IFormOP14Dao>())
        {
        }

        public ReportingService(IPlantHistorianService plantHistorianService,
            ILogDTODao logDtoDao,
            ISummaryLogDTODao summaryLogDtoDao,
            IActionItemDao actionItemDao,
            IDetailedLogReportDTODao detailedLogReportDtoDao,
            IShiftHandoverQuestionnaireDTODao questionnaireDtoDao,
            ITargetAlertDao targetAlertDao,
            ITargetAlertDTODao targetAlertDtoDao,
            ISafeWorkPermitAssessmentReportDTODao safeWorkPermitAssessmentReportDTO,
            ITargetAlertResponseDao targetAlertResponseDao,
            IDeviationAlertReportDTODao deviationAlertReportDtoDao,
            IShiftHandoverQuestionnaireDao questionnaireDao,
            ICustomFieldTrendReportDTODao customFieldTrendReportDtoDao,
            IFormOilsandsTrainingReportDTODao formOilsandsTrainingReportDtoDao,
            IEventDao eventDao,
            IDirectiveDTODao directiveDtoDao, IFormOP14Dao formOp14Dao)
        {
            this.logDtoDao = logDtoDao;
            this.summaryLogDtoDao = summaryLogDtoDao;

            this.actionItemDao = actionItemDao;

            this.detailedLogReportDtoDao = detailedLogReportDtoDao;
            this.questionnaireDtoDao = questionnaireDtoDao;
            this.questionnaireDao = questionnaireDao;

            this.plantHistorianService = plantHistorianService;
            this.targetAlertDao = targetAlertDao;
            this.targetAlertDtoDao = targetAlertDtoDao;
            safeWorkPermitAssessmentReportDTODao = safeWorkPermitAssessmentReportDTO;
            this.targetAlertResponseDao = targetAlertResponseDao;
            this.deviationAlertReportDtoDao = deviationAlertReportDtoDao;
            this.customFieldTrendReportDtoDao = customFieldTrendReportDtoDao;
            this.formOilsandsTrainingReportDtoDao = formOilsandsTrainingReportDtoDao;
            this.eventDao = eventDao;
            this.directiveDtoDao = directiveDtoDao;
            this.formOp14Dao = formOp14Dao;
        }


        public DailyShiftLogReportDTO GetDailyShiftLogReportData(IFlocSet flocSet, List<UserShift> userShiftList,
            TagInfoGroup tagInfoGroup)
        {
            var logs = GetDailyShiftLogReportData(flocSet, userShiftList, false);
            var tagInfoReportDetails = GetTagInfoReportData(tagInfoGroup,
                PlantHistorianOrigin.ReportingService_GetDailyShiftLogData);

            return new DailyShiftLogReportDTO(logs, tagInfoReportDetails);
        }

        public List<DetailedLogReportDTO> GetDetailedLogReportData(
            UserShift startUserShift,
            UserShift endUserShift,
            IFlocSet flocSet,
            List<WorkAssignment> workAssignments,
            bool includeNullWorkAssignment)
        {
            var dtos = new List<DetailedLogReportDTO>();
            dtos.AddRange(detailedLogReportDtoDao.QueryForLogs(
                startUserShift,
                endUserShift,
                flocSet,
                workAssignments,
                includeNullWorkAssignment));
            dtos.AddRange(detailedLogReportDtoDao.QueryForSummaryLogs(
                startUserShift,
                endUserShift,
                flocSet,
                workAssignments,
                includeNullWorkAssignment));
            return dtos;
        }

        public List<TargetAlertExcelReportDTO> GetTargetAlertReportData(IFlocSet flocSet, DateRange dateRange)
        {
            return targetAlertDtoDao.QueryForExcelReport(flocSet, TargetAlertStatus.All, dateRange);
        }

        public List<TargetAlertReportDetailDTO> GetDailyShiftAlertReportData(IFlocSet flocSet,
            List<UserShift> userShifts)
        {
            var targetAlertReportDetails = new List<TargetAlertReportDetailDTO>();

            foreach (var userShift in userShifts)
            {
                var alerts = targetAlertDao.QueryByFunctionalLocationsAndUserShift(flocSet, userShift);

                foreach (var alert in alerts)
                {
                    var responses = targetAlertResponseDao.QueryByTargetAlert(alert);
                    targetAlertReportDetails.Add(CreateTargetAlertReportDetail(alert, responses, userShift));
                }
            }

            return targetAlertReportDetails;
        }

        public DailyShiftLogReportDTO GetOperatingEngineerShiftLogReportDataForDevEx(IFlocSet flocSet,
            List<UserShift> userShiftList, TagInfoGroup tagInfoGroup)
        {
            var logs = GetDailyShiftLogReportData(flocSet, userShiftList, true);
            var tagInfoReportDetails = GetTagInfoReportData(tagInfoGroup,
                PlantHistorianOrigin.ReportingService_GetOperatingEngineerShiftLogDataForDevEx);

            return new DailyShiftLogReportDTO(logs, tagInfoReportDetails);
        }

        public OperatingEngineerLogReportDTO GetOperatingEngineerShiftLogReportData(Site site,
            IFlocSet flocSet,
            List<UserShift> userShifts,
            TagInfoGroup tagInfoGroup)
        {
            GuardAgainstNoSite(site);
            GuardAgainstNoFunctionalLocations(flocSet.FunctionalLocations);
            GuardAgainstNoUserShifts(userShifts);

            var logs = new List<LogReportDTO>();
            userShifts.ForEach(
                userShift =>
                    logs.AddRange(logDtoDao.QueryForLogReportDTO(flocSet, userShift, true)));

            var workAssignmentReportDetails =
                new List<WorkAssignmentReportDetail>(0);
            var tagInfoReportDetails = GetTagInfoReportData(tagInfoGroup,
                PlantHistorianOrigin.ReportingService_GetOperatingEngineerShiftLogData);

            return new OperatingEngineerLogReportDTO(logs, workAssignmentReportDetails, tagInfoReportDetails);
        }

        public List<ShiftGapReasonReportDTO> GetShiftGapReasonReportData(List<ShiftPattern> selectedShiftPatterns,
            IFlocSet flocSet,
            Date startDate,
            Date endDate)
        {
            var reportDtos = new List<ShiftGapReasonReportDTO>();
            selectedShiftPatterns.ForEach(
                selectedShiftPattern => reportDtos.AddRange(GetShiftGapReasonReportData(selectedShiftPattern,
                    flocSet,
                    startDate,
                    endDate)));
            return reportDtos;
        }

        public List<DeviationAlertReportDTO> GetRestrictionReportData(
            Date startDate, Date endDate, IFlocSet flocSet)
        {
            return deviationAlertReportDtoDao.QueryByDateRangeAndParentFunctionalLocation(
                startDate, endDate, flocSet);
        }

        public MarkedAsReadReportDTO GetMarkedAsReadReportData(
            Site site, Date from, Date to, IFlocSet flocSet,
            bool includeLogs, bool includeSummaryogs, bool includeDirectiveLogs, bool includeShiftHandovers,
            bool includeDirectives, bool includeDirectivesFlexiShiftDataonly)
        {
            var dto = new MarkedAsReadReportDTO();

            GetLogs(from, to, flocSet.FunctionalLocations, dto, includeLogs, includeDirectiveLogs);
            if (includeSummaryogs)
            {
                GetShiftSummaryLogs(from, to, flocSet, dto);
            }
            if (includeShiftHandovers)
            {
                GetShiftHandovers(site, from, to, flocSet.FunctionalLocations, dto, false);
            }
            if (includeDirectives)
            {
                GetDirectives(from, to, flocSet.FunctionalLocations, dto);
            }
            if (includeDirectivesFlexiShiftDataonly)
            {
                GetShiftHandovers(site, from, to, flocSet.FunctionalLocations, dto, true);
            }
            /*added condution includeDirectivesFlexiShiftDataonly will include data for flexi shift handover */ 
            return dto;
        }
        public MarkedAsNotReadReportDTO GetMarkedAsNotReadReportData (Site site, Date fromDate, Date toDate, IFlocSet flocSet, bool includeDirectiveLogs,
                                                                                         bool  includeShiftHandovers, bool includeDirectives)
        {
            var dto=new MarkedAsNotReadReportDTO();
            if (includeShiftHandovers)
            {
                GetShiftHandOversNotRead(site, fromDate, toDate, flocSet.FunctionalLocations, dto);
            }
            if (includeDirectives)
            {
               GetDirectivesNotRead(fromDate, toDate, flocSet.FunctionalLocations, dto);
            }


            return dto;
        }
       
        //public MarkedAsNotReadReportDTO GetMarkedAsNotReadReportData(
        //   Site site, Date from, Date to, IFlocSet flocSet,
        //   bool includeLogs, bool includeSummaryogs, bool includeDirectiveLogs, bool includeShiftHandovers,
        //   bool includeDirectives, bool includeDirectivesFlexiShiftDataonly)
        //{
        //    var dto = new MarkedAsNotReadReportDTO();

        //    GetLogs(from, to, flocSet.FunctionalLocations, dto, includeLogs, includeDirectiveLogs);
        //    //if (includeSummaryogs)
        //    //{
        //    //    GetShiftSummaryLogs(from, to, flocSet, dto);
        //    //}
        //    if (includeShiftHandovers)
        //    {
        //        GetShiftHandovers(site, from, to, flocSet.FunctionalLocations, dto, false);
        //    }
        //    if (includeDirectives)
        //    {
        //        GetDirectives(from, to, flocSet.FunctionalLocations, dto);
        //    }
        //    if (includeDirectivesFlexiShiftDataonly)
        //    {
        //        GetShiftHandovers(site, from, to, flocSet.FunctionalLocations, dto, true);
        //    }
        //    /*added condution includeDirectivesFlexiShiftDataonly will include data for flexi shift handover */
        //    return dto;
        //}

        public List<ShiftHandoverQuestionnaire> GetDailyShiftHandoverReportData(
            UserShift startUserShift,
            UserShift endUserShift,
            IFlocSet flocSet,
            List<WorkAssignment> workAssignments,
            bool includeNullWorkAssignment)
        {
            if (flocSet.FunctionalLocations.Count == 0)
            {
                return new List<ShiftHandoverQuestionnaire>();
            }

            var startDateTimeWithPadding = startUserShift.StartDateTimeWithPadding;
            var endDateTimeWithPadding = endUserShift.EndDateTimeWithPadding;

            var questionnaires = questionnaireDao.QueryByFunctionalLocationAndDateRangeAndAssignment(
                flocSet,
                startDateTimeWithPadding,
                endDateTimeWithPadding,
                workAssignments,
                includeNullWorkAssignment);

            questionnaires.RemoveAll(questionnaire =>
            {
                var questionnaireUserShift = new UserShift(questionnaire.Shift, questionnaire.CreateDateTime);
                return questionnaireUserShift.StartDateTime < startUserShift.StartDateTime ||
                       questionnaireUserShift.EndDateTime > endUserShift.EndDateTime;
            });

            return questionnaires;
        }

        /*Flexi shift handover RITM0185797 */
         public List<ShiftHandoverQuestionnaire> GetDailyShiftHandoverReportData(
            UserShift startUserShift,
            UserShift endUserShift,
            IFlocSet flocSet,
            List<WorkAssignment> workAssignments,
            bool includeNullWorkAssignment, bool showFlexibleShiftHandoverData)
        {
            if (flocSet.FunctionalLocations.Count == 0)
            {
                return new List<ShiftHandoverQuestionnaire>();
            }

            var startDateTimeWithPadding = startUserShift.StartDateTimeWithPadding;
            var endDateTimeWithPadding = endUserShift.EndDateTimeWithPadding;

            var questionnaires = questionnaireDao.QueryByFunctionalLocationAndDateRangeAndAssignment(
                flocSet,
                startDateTimeWithPadding,
                endDateTimeWithPadding,
                workAssignments,
                includeNullWorkAssignment, showFlexibleShiftHandoverData);
            
            //questionnaires.RemoveAll(questionnaire =>
            //{
            //    var questionnaireUserShift = new UserShift(questionnaire.Shift, questionnaire.CreateDateTime);
            //    return questionnaireUserShift.StartDateTime < startUserShift.StartDateTime ||
            //           questionnaireUserShift.EndDateTime > endUserShift.EndDateTime;
            //});
            
            return questionnaires;
        }
        

        public List<CustomFieldTrendReportDTO> GetCustomFieldTrendReportData(RootFlocSet rootFlocSet,
            UserShift startUserShift, UserShift endUserShift, List<WorkAssignment> workAssignments,
            bool includeNullAssignment, bool includeLogs, bool includeDirectives, bool includeSummaryLogs)
        {
            var startDateTimeWithPadding = startUserShift.StartDateTimeWithPadding;
            var endDateTimeWithPadding = endUserShift.EndDateTimeWithPadding;

            var dtos = new List<CustomFieldTrendReportDTO>();

            if (includeLogs)
            {
                var logDtos = customFieldTrendReportDtoDao.QueryCustomFieldTrendReportDataForLogs(rootFlocSet,
                    startDateTimeWithPadding, endDateTimeWithPadding, workAssignments, includeNullAssignment,
                    LogType.Standard);
                SortCustomFieldTrendReportDtos(logDtos);
                dtos.AddRange(logDtos);
            }

            if (includeDirectives)
            {
                var directiveDtos = customFieldTrendReportDtoDao.QueryCustomFieldTrendReportDataForLogs(rootFlocSet,
                    startDateTimeWithPadding, endDateTimeWithPadding, workAssignments, includeNullAssignment,
                    LogType.DailyDirective);
                SortCustomFieldTrendReportDtos(directiveDtos);
                dtos.AddRange(directiveDtos);
            }

            if (includeSummaryLogs)
            {
                var summaryLogDtos =
                    customFieldTrendReportDtoDao.QueryCustomFieldTrendReportDataForSummaryLogs(rootFlocSet,
                        startDateTimeWithPadding, endDateTimeWithPadding, workAssignments, includeNullAssignment);
                SortCustomFieldTrendReportDtos(summaryLogDtos);
                dtos.AddRange(summaryLogDtos);
            }

            return CustomFieldTrendReportDTO.StandardizeCustomFields(CustomFieldTrendReportDTO.RemoveEmpties(dtos));
        }

        //ayman action item reading
        public List<TrackerReport> GetReadingTrackers(long AidId,DateTime startdate,DateTime endDate )
        {
            List<TrackerReport> list = actionItemDao.QueryTrackersByAidId(AidId, startdate, endDate);
            return list;
        }

        private List<LogReportDTO> GetDailyShiftLogReportData(IFlocSet flocSet, List<UserShift> userShiftList,
            bool onlyReturnLogsFlaggedAsOperatingEngineerLog)
        {
            GuardAgainstNoFunctionalLocations(flocSet.FunctionalLocations);
            GuardAgainstNoUserShifts(userShiftList);

            var list = new List<LogReportDTO>();
            foreach (var currentShift in userShiftList)
            {
                list.AddRange(logDtoDao.QueryForLogReportDTO(flocSet, currentShift,
                    onlyReturnLogsFlaggedAsOperatingEngineerLog));
            }
            return list;
        }

        public List<SafeWorkPermitAssessmentReportDTO> GetSafeWorkPermitAssessmentReportDtos(IFlocSet flocSet,
            DateRange dateRange)
        {
            return safeWorkPermitAssessmentReportDTODao.QuerySafeWorkPermitAssessmentReportDTODao(flocSet, dateRange);
        }

        private static TargetAlertReportDetailDTO CreateTargetAlertReportDetail(TargetAlert alert,
            ICollection<TargetAlertResponse> responses,
            UserShift userShift)
        {
            return new TargetAlertReportDetailDTO(alert.IdValue,
                alert.TargetName,
                alert.FunctionalLocation,
                alert.Status,
                alert.CreatedDateTime,
                alert.LastModifiedDateTime,
                userShift,
                alert.Tag,
                alert.GetTargetThresholdEvaluationForOriginalExceedingValue(),
                alert.ActualValue.GetValueOrDefault(),
                alert.AcknowledgedUser,
                alert.AcknowledgedDateTime,
                CreateTargetAlertResponseReportDetails(responses));
        }

        private static List<TargetAlertResponseReportDetailDTO> CreateTargetAlertResponseReportDetails(
            ICollection<TargetAlertResponse> responses)
        {
            var dtos = new List<TargetAlertResponseReportDetailDTO>(responses.Count);

            foreach (var response in responses)
            {
                var comment = response.ResponseComment;
                dtos.Add(new TargetAlertResponseReportDetailDTO(comment.CreatedBy, comment.CreatedDate, comment.Text,
                    response.GapReason));
            }
            return dtos;
        }

        private List<TagInfoReportDetail> GetTagInfoReportData(TagInfoGroup tagInfoGroup, PlantHistorianOrigin origin)
        {
            var tagDetailList = new List<TagInfoReportDetail>();

            if (tagInfoGroup != null)
            {
                foreach (var tagInfo in tagInfoGroup.TagInfoList)
                {
                    var canRead = plantHistorianService.CanReadTagValue(tagInfo);
                    decimal? tagValue = null;
                    if (canRead)
                    {
                        var value = plantHistorianService.ReadTagValues(origin, tagInfo);
                        tagValue = value[0];
                    }
                    tagDetailList.Add(new TagInfoReportDetail(tagInfo.Name, tagInfo.Description, tagInfo.Units, tagValue));
                }
            }
            return tagDetailList;
        }

        private List<ShiftGapReasonReportDTO> GetShiftGapReasonReportData(ShiftPattern selectedShiftPattern,
            IFlocSet flocSet,
            Date startDate,
            Date endDate)
        {
            var startUserShift = new UserShift(selectedShiftPattern, startDate);
            var endUserShift = new UserShift(selectedShiftPattern, endDate);
            return targetAlertResponseDao.QueryGapReasonsByShiftAndDateRange(flocSet,
                selectedShiftPattern,
                startUserShift.StartDateTime,
                endUserShift.EndDateTime);
        }

        private static void GuardAgainstNoSite(Site site)
        {
            if (site == null)
            {
                throw new NoDataFoundException("No Site provided.");
            }
        }

        private static void GuardAgainstNoFunctionalLocations(ICollection selectedFunctionalLocations)
        {
            if (selectedFunctionalLocations.IsEmpty())
            {
                throw new NoDataFoundException("No Functional Location provided.");
            }
        }

        private static void GuardAgainstNoUserShifts(ICollection userShiftList)
        {
            if (userShiftList.IsEmpty())
            {
                throw new NoDataFoundException("No User Shifts provided");
            }
        }

        public List<FormOilsandsTrainingReportDTO> GetFormOilsandsTrainingReportData(RootFlocSet rootFlocSet,
            UserShift startUserShift, UserShift endUserShift, List<WorkAssignment> workAssignments)
        {
            return formOilsandsTrainingReportDtoDao.QueryFormOilsandsTrainingReportData(rootFlocSet,
                startUserShift.StartDateTime, endUserShift.EndDateTime, workAssignments);
        }

        private void SortCustomFieldTrendReportDtos(List<CustomFieldTrendReportDTO> dtos)
        {
            dtos.Sort(dto => dto.LogDateTime);
        }

        private void GetLogs(
            Date logCreatedFrom, Date logCreatedTo,
            IList<FunctionalLocation> functionalLocations,
            MarkedAsReadReportDTO reportDto,
            bool includeLogs, bool includeDirectives)
        {
            var dtos = logDtoDao.QueryDTOByParentFlocListAndMarkedAsRead(
                logCreatedFrom.CreateDateTime(Time.START_OF_DAY),
                logCreatedTo.CreateDateTime(Time.START_OF_DAY).AddDays(1),
                functionalLocations);
            foreach (var dto in dtos)
            {
                if (dto.LogType == MarkedAsReadReportLogDTO.STANDARD_LOG_TYPE_TEXT)
                {
                    if (includeLogs)
                    {
                        reportDto.Logs.Add(dto);
                    }
                }
                else if (dto.LogType == MarkedAsReadReportLogDTO.DAILY_DIRECTIVE_LOG_TYPE_TEXT)
                {
                    if (includeDirectives)
                    {
                        reportDto.DirectiveLogs.Add(dto);
                    }
                }
                else
                {
                    logger.Warn("Unknown log type encountered: " + dto.LogType);
                }
            }
        }

        private void GetShiftSummaryLogs(
            Date logCreatedFrom, Date logCreatedTo,
            IFlocSet flocSet,
            MarkedAsReadReportDTO reportDto)
        {
            var dtos = summaryLogDtoDao.QueryDTOByParentFlocListAndMarkedAsRead(
                logCreatedFrom.CreateDateTime(Time.START_OF_DAY),
                logCreatedTo.CreateDateTime(Time.START_OF_DAY).AddDays(1),
                flocSet);
            reportDto.SummaryLogs.AddRange(dtos);
        }

        private void GetShiftHandovers(
            Site site, Date from, Date to,
            IList<FunctionalLocation> functionalLocations,
            MarkedAsReadReportDTO reportDto, bool showFlexiShiftDataonly)
        {
            var questionnaires = questionnaireDtoDao.QueryByParentFlocListAndMarkedAsRead(
                site,
                from.CreateDateTime(Time.START_OF_DAY),
                to.CreateDateTime(Time.START_OF_DAY).AddDays(1),
                new RootFlocSet(new List<FunctionalLocation>(functionalLocations)), showFlexiShiftDataonly);
            reportDto.ShiftHandoverQuestionnaires.AddRange(questionnaires);
        }
        //Added by ppanigrahi
        private void GetShiftHandOversNotRead(Site site, Date from, Date to,
            IList<FunctionalLocation> functionalLocations,
            MarkedAsNotReadReportDTO reportDto)
        {
            var questionnaires = questionnaireDtoDao.QueryByParentFlocListAndMarkedAsNotRead(site, from.CreateDateTime(Time.START_OF_DAY), to.CreateDateTime(Time.START_OF_DAY).AddDays(1),
                new RootFlocSet(new List<FunctionalLocation>(functionalLocations)));
            reportDto.ShiftHandoverQuestionnaires.AddRange(questionnaires);
        }

        private void GetDirectives(Date from, Date to, List<FunctionalLocation> functionalLocations,
            MarkedAsReadReportDTO reportDto)
        {
            var fromDateTime = @from.ToDateTimeAtStartOfDay();
            var toDateTime = to.ToDateTimeAtEndOfDay();

            var directives = directiveDtoDao.QueryByParentFlocListAndMarkedAsRead(fromDateTime, toDateTime,
                new RootFlocSet(functionalLocations));
            reportDto.Directives.AddRange(directives);
        }
        //Added by ppanigrahi

        private void GetDirectivesNotRead(Date from, Date to, List<FunctionalLocation> functionalLocations,
            MarkedAsNotReadReportDTO reportDto)
        {
            var fromDateTime = @from.ToDateTimeAtStartOfDay();
            var toDateTime = to.ToDateTimeAtEndOfDay();
            var directives = directiveDtoDao.QueryByParentFlocListAndMarkedAsNotRead(fromDateTime, toDateTime,
               new RootFlocSet(functionalLocations));
             reportDto.Directives.AddRange(directives);

            
        }

        

        public List<Event> GetAnalyticsExcelExportData(DateTime fromDateTime, DateTime toDateTime,
            List<string> eventNames)
        {
            return eventDao.QueryByDateRangeAndEventNames(fromDateTime, toDateTime, eventNames);
        }

        public List<CSDMarkAsReadReportItem> GetFormOP14MarkedAsReadReport(Date fromDate, Date toDate, long siteId)
        {
            DateRange dateRange = new DateRange(fromDate, toDate);
            return formOp14Dao.GetFormOP14MarkedAsReadReport(dateRange, siteId);
        }
    }
}