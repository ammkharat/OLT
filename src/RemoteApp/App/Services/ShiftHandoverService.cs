using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.PriorityPage;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Common;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ShiftHandoverService : IShiftHandoverService
    {
        private readonly IShiftHandoverQuestionnaireDao questionnaireDao;
        private readonly IShiftHandoverQuestionnaireAssociationDao questionnaireAssociationDao;
        private readonly IShiftHandoverQuestionnaireDTODao questionnaireDtoDao;
        private readonly IShiftHandoverConfigurationDao configurationDao;
        private readonly IShiftHandoverEmailConfigurationDao emailConfigurationDao;
        private readonly IShiftHandoverConfigurationDTODao configurationDTODao;
        private readonly ITimeService timeService;
        private readonly IEditHistoryService editHistoryService;
        private readonly IQuestionnaireReadDao questionnaireReadDao;
        private readonly ISiteConfigurationDao siteConfigurationDao;
        private readonly ILogDTODao logDtoDao;
        private readonly ISummaryLogDao summaryLogDao;
        private readonly ICokerCardDao cokerCardDao;

        public ShiftHandoverService(
            IShiftHandoverQuestionnaireDao questionnaireDao,
            IShiftHandoverQuestionnaireAssociationDao questionnaireAssociationDao,
            IShiftHandoverQuestionnaireDTODao questionnaireDtoDao, 
            IShiftHandoverConfigurationDao configurationDao, 
            IShiftHandoverConfigurationDTODao configurationDtoDao, 
            IShiftHandoverQuestionDao questionDao, 
            ITimeService timeService,
            IEditHistoryService editHistoryService,
            IQuestionnaireReadDao questionnaireReadDao,
            ISiteConfigurationDao siteConfigurationDao,
            IShiftHandoverEmailConfigurationDao emailConfigurationDao,
            ILogDTODao logDtoDao,
            ISummaryLogDao summaryLogDao,
            ICokerCardDao cokerCardDao)
        {
            this.questionnaireDao = questionnaireDao;
            this.questionnaireAssociationDao = questionnaireAssociationDao;
            this.questionnaireDtoDao = questionnaireDtoDao;
            this.configurationDao = configurationDao;
            configurationDTODao = configurationDtoDao;
            this.timeService = timeService;
            this.editHistoryService = editHistoryService;
            this.questionnaireReadDao = questionnaireReadDao;
            this.siteConfigurationDao = siteConfigurationDao;
            this.emailConfigurationDao = emailConfigurationDao;
            this.logDtoDao = logDtoDao;
            this.summaryLogDao = summaryLogDao;
            this.cokerCardDao = cokerCardDao;
        }

        public ShiftHandoverService() : this(
            DaoRegistry.GetDao<IShiftHandoverQuestionnaireDao>(),
            DaoRegistry.GetDao<IShiftHandoverQuestionnaireAssociationDao>(),
            DaoRegistry.GetDao<IShiftHandoverQuestionnaireDTODao>(),
            DaoRegistry.GetDao<IShiftHandoverConfigurationDao>(),
            DaoRegistry.GetDao<IShiftHandoverConfigurationDTODao>(),
            DaoRegistry.GetDao<IShiftHandoverQuestionDao>(),
            new TimeService(),
            new EditHistoryService(),
            DaoRegistry.GetDao<IQuestionnaireReadDao>(),
            DaoRegistry.GetDao<ISiteConfigurationDao>(),
            DaoRegistry.GetDao<IShiftHandoverEmailConfigurationDao>(),
            DaoRegistry.GetDao<ILogDTODao>(),
            DaoRegistry.GetDao<ISummaryLogDao>(),
            DaoRegistry.GetDao<ICokerCardDao>())
        {
        }
       
        public List<ShiftHandoverConfiguration> GetAllQuestions(long workAssignmentId)
        {
            return configurationDao.QueryByWorkAssignment(workAssignmentId);
        }
       
        public ShiftHandoverQuestionnaire QueryById(long id)
        {
            return questionnaireDao.QueryById(id);
        }

        public List<ShiftHandoverQuestionnaire> QueryByUserWorkAssignmentAndShift(long userId, long? workAssignmentId, UserShift userShift)
        {
            if (!workAssignmentId.HasValue)
                return new List<ShiftHandoverQuestionnaire>(0);
            return questionnaireDao.QueryByUserWorkAssignmentAndShift(userId, workAssignmentId.Value, userShift);
        }

        public List<ShiftHandoverQuestionnaire> QueryByWorkAssignmentAndShift(long workAssignmentId, UserShift userShift)
        {
            return questionnaireDao.QueryByWorkAssignmentAndShift(workAssignmentId, userShift);
        }

        public List<ShiftHandoverQuestionnaireDTO> QueryShiftHandoverQuestionnaireDTOsByFunctionalLocation(IFlocSet flocSet, Range<Date> dateRange, long? userId, List<long> readableVisibilityGroupIds)
        {
            Site site = flocSet.Site;
            if (dateRange == null)
            {
                SiteConfiguration siteConfiguration = siteConfigurationDao.QueryBySiteId(site.IdValue);
                Date startDate = DateRangeUtilities.GetFromDateForShiftHandovers(site, siteConfiguration, timeService);
                dateRange = new Range<Date>(startDate, null);
            }

            return questionnaireDtoDao.QueryByFunctionalLocation(flocSet, new DateRange(dateRange), userId, readableVisibilityGroupIds);
        }

        public List<ShiftHandoverQuestionnaireDTO> QueryShiftHandoverQuestionnaireDTOsByFunctionalLocationAndAssignment(IFlocSet flocSet, long? workAssignmentId, Range<Date> dateRange, long? userId, List<long> readableVisibilityGroupIds)
        {
            Site site = flocSet.Site;
            if (dateRange == null)
            {
                SiteConfiguration siteConfiguration = siteConfigurationDao.QueryBySiteId(site.IdValue);
                Date startDate = DateRangeUtilities.GetFromDateForShiftHandovers(site, siteConfiguration, timeService);
                dateRange = new Range<Date>(startDate, null);
            }
            return questionnaireDtoDao.QueryByFunctionalLocationAndAssignment(flocSet, workAssignmentId, new DateRange(dateRange), userId, readableVisibilityGroupIds);
        }

        //Added for View shifthandover based on rolepermission
        public List<ShiftHandoverQuestionnaireDTO> QueryShiftHandoverQuestionnaireDTOsByFunctionalLocation(IFlocSet flocSet, Range<Date> dateRange, long? userId, List<long> readableVisibilityGroupIds,long? RoleId)
        {
            Site site = flocSet.Site;
            if (dateRange == null)
            {
                SiteConfiguration siteConfiguration = siteConfigurationDao.QueryBySiteId(site.IdValue);
                Date startDate = DateRangeUtilities.GetFromDateForShiftHandovers(site, siteConfiguration, timeService);
                dateRange = new Range<Date>(startDate, null);
            }

            return questionnaireDtoDao.QueryByFunctionalLocation(flocSet, new DateRange(dateRange), userId, readableVisibilityGroupIds, RoleId);
        }

        public List<ShiftHandoverQuestionnaireDTO> QueryShiftHandoverQuestionnaireDTOsByFunctionalLocationAndAssignment(IFlocSet flocSet, long? workAssignmentId, Range<Date> dateRange, long? userId, List<long> readableVisibilityGroupIds, long? RoleId)
        {
            Site site = flocSet.Site;
            if (dateRange == null)
            {
                SiteConfiguration siteConfiguration = siteConfigurationDao.QueryBySiteId(site.IdValue);
                Date startDate = DateRangeUtilities.GetFromDateForShiftHandovers(site, siteConfiguration, timeService);
                dateRange = new Range<Date>(startDate, null);
            }
            return questionnaireDtoDao.QueryByFunctionalLocationAndAssignment(flocSet, workAssignmentId, new DateRange(dateRange), userId, readableVisibilityGroupIds, RoleId);
        }

        //End
        public List<ShiftHandoverQuestionnaireDTO> QueryShiftHandoverQuestionnaireDTOsWithYesAnswersByFlocAndShift(RootFlocSet flocSet, UserShift userShift, List<long> readableVisibilityGroupIds)
        {
            return questionnaireDtoDao.QueryOnesWithYesAnswersByFunctionalLocationAndShift(flocSet, userShift, readableVisibilityGroupIds);
        }

        public List<ShiftHandoverQuestionnaireDTO> QueryShiftHandoverQuestionnaireDTOsWithYesAnswersByFlocAndDateRange(RootFlocSet flocSet, DateRange dateRange, List<long> readableVisibilityGroupIds)
        {
            return questionnaireDtoDao.QueryOnesWithYesAnswersByFunctionalLocationAndDateRange(flocSet, dateRange, readableVisibilityGroupIds);
        }

        public List<ShiftHandoverQuestionnairePriorityPageDTO> QueryForPriorityPageDTOs(IFlocSet flocSet, Range<Date> dateRange, bool queryByWorkAssignment, long? workAssignmentId, long? userId, List<long> readableVisibilityGroupIds,long? RoleId)
        {
            List<ShiftHandoverQuestionnaireDTO> questionnaireDtos;
            if (queryByWorkAssignment)
            {
                questionnaireDtos = QueryShiftHandoverQuestionnaireDTOsByFunctionalLocationAndAssignment(flocSet, workAssignmentId, dateRange, userId, readableVisibilityGroupIds,RoleId);
            }
            else
            {
                questionnaireDtos = QueryShiftHandoverQuestionnaireDTOsByFunctionalLocation(flocSet, dateRange, userId, readableVisibilityGroupIds,RoleId);
            }

            questionnaireDtos =
                questionnaireDtos.OrderByDescending(dto => dto.CreatedShiftStartDate)
                    .ThenByDescending(dto => dto.ShiftId)
                    .ThenBy(dto => dto.AssignmentName)
                    .ThenBy(dto => dto.CreateUserFullName).ToList();
            
            List<ShiftHandoverQuestionnairePriorityPageDTO> results = new List<ShiftHandoverQuestionnairePriorityPageDTO>();
            foreach (ShiftHandoverQuestionnaireDTO questionnaireDto in questionnaireDtos)
            {
                results.Add(new ShiftHandoverQuestionnairePriorityPageDTO(questionnaireDto, questionnaireDto.IsReadByCurrentUser.GetValueOrDefault(false)));
            }

            return results;
        }

        public List<ShiftHandoverQuestionnaireDTO> QueryPriorityDTOs(IFlocSet flocSet, long? workAssignmentId, long? userId, UserShift userShift, List<long> readableVisibilityGroupIds)
        {
            Site site = userShift.ShiftPattern.Site;
            Date currentDateAtSite = timeService.GetDate(site.TimeZone);
            Date fromDate = currentDateAtSite.SubtractDays(3);
            DateRange dateRange = new DateRange(fromDate, null);

            List<ShiftHandoverQuestionnaireDTO> shiftHandoverQuestionnaireDtos = questionnaireDtoDao.QueryByFunctionalLocationAndAssignment(flocSet, workAssignmentId, dateRange, null, readableVisibilityGroupIds);
            shiftHandoverQuestionnaireDtos.RemoveAll(dto => Equals(dto.CreateUserId, userId) || QuestionnaireCreatedInsideOfUserShift(dto, userShift));
            return shiftHandoverQuestionnaireDtos;
        }

        public List<NotifiedEvent> Insert(ShiftHandoverQuestionnaire questionnaire)
        {
            questionnaire.LastModifiedDate = questionnaire.CreateDateTime;

            questionnaireDao.Insert(questionnaire);
            CreateAssociationsToExistingLogs(questionnaire);
            CreateAssociationsToExistingSummaryLogs(questionnaire);
            editHistoryService.TakeSnapshot(questionnaire);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ShiftHandoverQuestionnaireCreate, questionnaire));
            return notifiedEvents;
        }

        private void CreateAssociationsToExistingSummaryLogs(ShiftHandoverQuestionnaire questionnaire)
        {
            questionnaireAssociationDao.InsertSummaryLogAssocications(questionnaire);
        }

        private void CreateAssociationsToExistingLogs(ShiftHandoverQuestionnaire questionnaire)
        {
            questionnaireAssociationDao.InsertLogAssocications(questionnaire);
        }

        public List<NotifiedEvent> Update(ShiftHandoverQuestionnaire questionnaire, User updateUser)
        {
            questionnaire.LastModifiedDate = timeService.GetTime(questionnaire.Shift.Site.TimeZone);

            questionnaireDao.Update(questionnaire);
            editHistoryService.TakeSnapshot(questionnaire);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ShiftHandoverQuestionnaireUpdate, questionnaire));
            return notifiedEvents;
        }

        public List<NotifiedEvent> Remove(ShiftHandoverQuestionnaire questionnaire)
        {
            questionnaireDao.Delete(questionnaire);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ShiftHandoverQuestionnaireRemove, questionnaire));
            return notifiedEvents;
        }

        public ShiftHandoverConfiguration QueryShiftHandoverConfigurationsById(long id)
        {
            return configurationDao.QueryById(id);
        }

        public List<ShiftHandoverConfigurationDTO> QueryShiftHandoverConfigurationDTOsBySite(long siteId)
        {
            return configurationDTODao.QueryBySiteId(siteId);
        }

        public ShiftHandoverConfiguration InsertShiftHandoverConfiguration(ShiftHandoverConfiguration configuration)
        {
            return configurationDao.Insert(configuration);
        }

        public void UpdateShiftHandoverConfiguration(ShiftHandoverConfiguration configuration, List<ShiftHandoverQuestion> deletedQuestions)
        {
            configurationDao.Update(configuration, deletedQuestions);
        }

        public void DeleteShiftHandoverConfiguration(long configurationId)
        {
            configurationDao.Delete(configurationId);
        }

        public bool MarkAsRead(long shiftHandoverQuestionnaireId, long userId, DateTime dateTime)
        {
            bool markAsReadWasSuccessful = true;

            ShiftHandoverQuestionnaire queriedQuestionnaire = questionnaireDao.QueryById(shiftHandoverQuestionnaireId);
            if (queriedQuestionnaire != null && questionnaireReadDao.UserMarkedAsRead(shiftHandoverQuestionnaireId, userId) == null)
            {
                questionnaireReadDao.Insert(new ItemRead<ShiftHandoverQuestionnaire>(shiftHandoverQuestionnaireId, userId, dateTime));
            }
            else
            {
                markAsReadWasSuccessful = false;
            }

            return markAsReadWasSuccessful;
        }

        public bool UserMarkedLogAsRead(long shiftHandoverQuestionnaireId, long userId)
        {
            ItemRead<ShiftHandoverQuestionnaire> userMarkedSummaryLogAsRead =
                questionnaireReadDao.UserMarkedAsRead(shiftHandoverQuestionnaireId, userId);
            return (userMarkedSummaryLogAsRead != null);
        }

        public List<ItemReadBy> UsersThatMarkedLogAsRead(long handoverQuestionnaireId)
        {
            return questionnaireReadDao.UsersThatMarkedAsRead(handoverQuestionnaireId);            
        }

        public bool ShiftHandoverIsMarkedAsRead(long handoverId)
        {
            return questionnaireReadDao.UsersThatMarkedAsRead(handoverId).Count > 0;
        }

        public bool ShiftHandoversAreMarkedAsRead(List<long> handoverQuestionnaireIds)
        {
            return handoverQuestionnaireIds.Any(handoverId => questionnaireReadDao.UsersThatMarkedAsRead(handoverId).Count > 0);
        }

        private static bool QuestionnaireCreatedInsideOfUserShift(ShiftHandoverQuestionnaireDTO dto, UserShift userShift)
        {
            return userShift.IsInUserShiftIncludingPadding(dto.ShiftId, dto.CreateDateTime);
        }

        public List<ShiftHandoverEmailConfiguration> QueryShiftHandoverEmailConfigurationsBySiteId(long siteId)
        {
            return emailConfigurationDao.QueryBySiteId(siteId);
        }

        public ShiftHandoverEmailConfiguration QueryShiftHandoverEmailConfigurationById(long configurationId)
        {
            return emailConfigurationDao.QueryById(configurationId);
        }

        //RITM0164968-  mangesh
        public ShiftHandoverQuestionnaireAssocations QueryAssocationedLogItems(long shiftHandoverQuestionnaireId, Date shiftStartDate, long shiftPatternId, long workAssignmentId, List<long> cokerCardConfigurationIds)
        {
            List<HasCommentsDTO> logs = logDtoDao.QueryByShiftHandoverQuestionnaireLogItem(shiftHandoverQuestionnaireId);
            return new ShiftHandoverQuestionnaireAssocations(logs, null, null);
        }

        public ShiftHandoverQuestionnaireAssocations QueryAssocationedItems(long shiftHandoverQuestionnaireId, Date shiftStartDate, long shiftPatternId, long workAssignmentId, List<long> cokerCardConfigurationIds,long SiteID)
        {
            List<HasCommentsDTO> logs = logDtoDao.QueryByShiftHandoverQuestionnaire(shiftHandoverQuestionnaireId,SiteID);
            List<SummaryLog> summaryLogs = summaryLogDao.QueryByShiftHandover(shiftHandoverQuestionnaireId);
            List<CokerCardDrumEntryDTO> drumEntryDTO = cokerCardDao.QueryCokerCardSummaries(
                shiftStartDate,
                shiftPatternId,
                workAssignmentId,
                cokerCardConfigurationIds);
            CokerCardInfoForShiftHandoverDTO cokerCardInfoForShiftHandoverDto = new CokerCardInfoForShiftHandoverDTO(drumEntryDTO);

            return new ShiftHandoverQuestionnaireAssocations(logs, summaryLogs.ConvertAll(sl => new HasCommentsDTO(sl)), cokerCardInfoForShiftHandoverDto);   
        }

        public List<NotifiedEvent> InsertShiftHandoverEmailConfiguration(ShiftHandoverEmailConfiguration configuration)
        {
            emailConfigurationDao.Insert(configuration);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ShiftHandoverEmailConfigurationCreate, configuration));
            return notifiedEvents;
        }

        public List<NotifiedEvent> UpdateShiftHandoverEmailConfiguration(ShiftHandoverEmailConfiguration configuration)
        {
            emailConfigurationDao.Update(configuration);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ShiftHandoverEmailConfigurationUpdate, configuration));
            return notifiedEvents;
        }

        public List<NotifiedEvent> DeleteShiftHandoverEmailConfiguration(ShiftHandoverEmailConfiguration configuration)
        {
            emailConfigurationDao.Delete(configuration);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ShiftHandoverEmailConfigurationRemove, configuration));
            return notifiedEvents;
        }

        //Mukesh-for Operator Round Messgae
        public List<ShiftLogMessage> QueryShiftLogMessage(IFlocSet Floc,long siteId)
        {
            List<ShiftLogMessage> logs = logDtoDao.QueryShiftLogMessage(Floc, siteId);
            return logs;
        }

    }

}