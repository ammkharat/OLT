using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface ICokerCardService
    {
        [OperationContract]
        CokerCard QueryById(long id);

        [OperationContract]
        List<CokerCardDTO> QueryByExactFlocMatch(
            ExactFlocSet flocSet, Range<Date> dateRange);

        [OperationContract]
        List<NotifiedEvent> Insert(CokerCard cokerCard, List<CokerCardCycleStepEntry> previousEntries);

        [OperationContract]
        List<NotifiedEvent> Update(CokerCard cokerCard, List<CokerCardCycleStepEntry> previousEntries);

        [OperationContract]
        List<NotifiedEvent> Remove(CokerCard cokerCard);

        [OperationContract]
        List<CokerCardConfiguration> QueryCokerCardConfigurationsByExactFlocMatch(ExactFlocSet flocSet);

        [OperationContract]
        List<CokerCardConfiguration> QueryCokerCardConfigurationsBySite(Site site);

        [OperationContract]
        List<string> QueryCokerCardConfigurationNameBySite(Site site);

        [OperationContract]
        List<long> QueryCokerCardConfigurationByWorkAssignment(WorkAssignment workAssignment);

        [OperationContract]
        CokerCardConfiguration QueryCokerCardConfigurationById(long id);

        [OperationContract]
        CokerCardConfiguration QueryCokerCardConfigurationByIdWithCaching(long id);

        [OperationContract]
        CokerCard QueryCokerCardByConfigurationAndShift(long configurationId, UserShift userShift);

        [OperationContract]
        List<CokerCardCycleStepEntryDTO> QueryCycleStepDTOsByConfigurationIdsAndDateRange(string configurationName,
            Date startOfRange, Date endOfRange);

        [OperationContract]
        CokerCardInfoForShiftHandoverDTO QueryCokerCardInfoForShiftHandover(Date shiftStartDate, long shiftPatternId,
            long workAssignmentId, List<long> cokerCardConfigurationIds);

        [OperationContract]
        void InsertCokerCardConfiguration(CokerCardConfiguration cokerCardConfiguration);

        [OperationContract]
        void RemoveCokerCardConfiguration(CokerCardConfiguration cokerCardConfigurationId);

        [OperationContract]
        void UpdateCokerCardConfiguration(CokerCardConfiguration cokerCardConfiguration);

        [OperationContract]
        void ReplaceCokerCardConfiguration(CokerCardConfiguration oldConfiguration,
            CokerCardConfiguration configurationToInsert);
    }
}