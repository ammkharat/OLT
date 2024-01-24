using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class CokerCardService : ICokerCardService
    {
        private readonly IShiftPatternService shiftPatternService;
        private readonly IEditHistoryService editHistoryService;

        private readonly ICokerCardDao cokerCardDao;
        private readonly ICokerCardDTODao cokerCardDTODao;
        private readonly ICokerCardConfigurationDao cokerCardConfigurationDao;
        private readonly ICokerCardCycleStepEntryDTODao cycleStepDTODao;

        public CokerCardService()
        {
            shiftPatternService = new ShiftPatternService();
            editHistoryService = new EditHistoryService();

            cokerCardDao = DaoRegistry.GetDao<ICokerCardDao>();
            cokerCardDTODao = DaoRegistry.GetDao<ICokerCardDTODao>();
            cokerCardConfigurationDao = DaoRegistry.GetDao<ICokerCardConfigurationDao>();
            cycleStepDTODao = DaoRegistry.GetDao<ICokerCardCycleStepEntryDTODao>();
        }

        public CokerCard QueryById(long id)
        {
            return cokerCardDao.QueryById(id);
        }

        public List<CokerCardDTO> QueryByExactFlocMatch(
            ExactFlocSet flocSet, Range<Date> dateRange)
        {
            return cokerCardDTODao.QueryByExactFlocMatch(
                flocSet, new DateRange(dateRange));
        }

        public List<NotifiedEvent> Insert(CokerCard cokerCard, List<CokerCardCycleStepEntry> previousEntries)
        {
            CokerCard newCokerCard = cokerCardDao.Insert(cokerCard, previousEntries);

            editHistoryService.TakeSnapshot(cokerCard, previousEntries);

            NotifiedEvent notifiedEvent = ServiceUtility.PushEventIntoQueue(ApplicationEvent.CokerCardCreate, newCokerCard);
            return new List<NotifiedEvent>{notifiedEvent};
        }

        public List<NotifiedEvent> Update(CokerCard cokerCard, List<CokerCardCycleStepEntry> previousEntries)
        {
            cokerCardDao.Update(cokerCard, previousEntries);

            editHistoryService.TakeSnapshot(cokerCard, previousEntries);

            NotifiedEvent notifiedEvent = ServiceUtility.PushEventIntoQueue(ApplicationEvent.CokerCardUpdate, cokerCard);
            return new List<NotifiedEvent> { notifiedEvent };
        }

        public List<NotifiedEvent> Remove(CokerCard cokerCardToRemove)
        {            
            if (cokerCardToRemove == null)
            {
                return new List<NotifiedEvent>();
            }

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            List<ShiftPattern> allShiftsForSite = shiftPatternService.QueryBySite(cokerCardToRemove.FunctionalLocation.Site);

            cokerCardDao.Remove(cokerCardToRemove);

            UserShift userShiftForCardToRemove = new UserShift(cokerCardToRemove.Shift, cokerCardToRemove.ShiftStartDate);

            CokerCard immediatelyPreviousCokerCard = QueryCokerCardByConfigurationAndShift(
                cokerCardToRemove.ConfigurationId,
                userShiftForCardToRemove.ChoosePreviousShift(allShiftsForSite));

            if (immediatelyPreviousCokerCard != null)
            {
                bool theCardChanged = false;

                foreach (CokerCardCycleStepEntry entryFromPreviousCard in immediatelyPreviousCokerCard.CycleStepEntries)
                {
                    if (entryFromPreviousCard.EndEntry != null)
                    {
                        bool entryFallsIntoCurrentShift = entryFromPreviousCard.EndEntry.IsSameShift(userShiftForCardToRemove);

                        if (entryFallsIntoCurrentShift)
                        {
                            entryFromPreviousCard.EndEntry = null;
                            theCardChanged = true;
                        }
                    }
                }

                if (theCardChanged)
                {
                    cokerCardDao.Update(immediatelyPreviousCokerCard, new List<CokerCardCycleStepEntry>());
                    NotifiedEvent notifiedEventForPreviousCardUpdate =
                            ServiceUtility.PushEventIntoQueue(ApplicationEvent.CokerCardUpdate, immediatelyPreviousCokerCard);
                    notifiedEvents.Add(notifiedEventForPreviousCardUpdate);
                }                
            }

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.CokerCardRemove, cokerCardToRemove));

            return notifiedEvents;
        }

        public List<CokerCardConfiguration> QueryCokerCardConfigurationsByExactFlocMatch(ExactFlocSet flocSet)
        {
            return cokerCardConfigurationDao.QueryCokerCardConfigurationsByExactFlocMatch(flocSet);
        }

        public List<CokerCardConfiguration> QueryCokerCardConfigurationsBySite(Site site)
        {
            if (site == null)
            {
                return new List<CokerCardConfiguration>();
            }

            return cokerCardConfigurationDao.QueryCokerCardConfigurationsBySite(site.IdValue);
        }

        public List<string> QueryCokerCardConfigurationNameBySite(Site site)
        {
            if (site == null)
            {
                return new List<string>();
            }

            return cokerCardConfigurationDao.QueryDistinctCokerCardConfigurationNamesBySite(site);
        }

        public List<long> QueryCokerCardConfigurationByWorkAssignment(WorkAssignment workAssignment)
        {
            return cokerCardConfigurationDao.QueryCokerCardConfigurationByWorkAssignment(workAssignment);
        }

        public CokerCardConfiguration QueryCokerCardConfigurationById(long id)
        {
            return cokerCardConfigurationDao.QueryById(id);
        }

        public CokerCardConfiguration QueryCokerCardConfigurationByIdWithCaching(long id)
        {
            return cokerCardConfigurationDao.QueryByIdWithCaching(id);
        }

        public CokerCard QueryCokerCardByConfigurationAndShift(long configurationId, UserShift userShift)
        {
            CokerCard cokerCard = cokerCardDao.QueryByConfigurationAndShift(configurationId, userShift);
            return cokerCard;
        }

        public List<CokerCardCycleStepEntryDTO> QueryCycleStepDTOsByConfigurationIdsAndDateRange(string configurationName, Date startOfRange, Date endOfRange)
        {
            List<long> cokerCardConfigurationIds = cokerCardConfigurationDao.QueryCokerCardConfigurationByName(configurationName);

            if (configurationName == null)
            {
                return new List<CokerCardCycleStepEntryDTO>();
            }

            return cycleStepDTODao.QueryByConfigurationIdsAndDateRange(cokerCardConfigurationIds, startOfRange, endOfRange);
        }

        public CokerCardInfoForShiftHandoverDTO QueryCokerCardInfoForShiftHandover(Date shiftStartDate, long shiftPatternId, long workAssignmentId, List<long> cokerCardConfigurationIds)
        {
            List<CokerCardDrumEntryDTO> drumEntryDTO = cokerCardDao.QueryCokerCardSummaries(
                shiftStartDate, 
                shiftPatternId, 
                workAssignmentId,
                cokerCardConfigurationIds);
            return new CokerCardInfoForShiftHandoverDTO(drumEntryDTO);
        }

        public void InsertCokerCardConfiguration(CokerCardConfiguration cokerCardConfiguration)
        {
            cokerCardConfigurationDao.Insert(cokerCardConfiguration);
        }

        public void RemoveCokerCardConfiguration(CokerCardConfiguration cokerCardConfiguration)
        {
            cokerCardConfigurationDao.Remove(cokerCardConfiguration);
        }

        public void UpdateCokerCardConfiguration(CokerCardConfiguration cokerCardConfiguration)
        {
            cokerCardConfigurationDao.Update(cokerCardConfiguration);
        }

        public void ReplaceCokerCardConfiguration(CokerCardConfiguration oldConfiguration, CokerCardConfiguration configurationToInsert)
        {
            cokerCardConfigurationDao.Remove(oldConfiguration);
            cokerCardConfigurationDao.Insert(configurationToInsert);
        }
    }
}
