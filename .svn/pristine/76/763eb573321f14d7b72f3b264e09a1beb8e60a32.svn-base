using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IFormOilsandsService
    {
        [OperationContract]
        List<FormOilsandsTrainingDTO> QueryFormOilsandsTrainingsByFunctionalLocationsAndDateRange(IFlocSet flocSet,
            DateRange dateRange);

        [OperationContract]
        List<NotifiedEvent> InsertFormOilsandsTraining(FormOilsandsTraining form);

        [OperationContract]
        List<NotifiedEvent> UpdateFormOilsandsTraining(FormOilsandsTraining form);

        //ayman generic forms
        [OperationContract]
        FormOilsandsTraining QueryFormOilsandsTrainingByIdAndSiteId(long id,long siteid);

        [OperationContract]
        FormOilsandsTraining QueryFormOilsandsTrainingById(long id);

        [OperationContract]
        List<NotifiedEvent> RemoveFormOilsandsTraining(FormOilsandsTraining form);

        [OperationContract]
        long? QueryDateShiftAndAssignmentDuplicatesOnOtherFormOilsandTrainings(long? formId, Date trainingDate,
            ShiftPattern shiftPattern, WorkAssignment workAssignment, User currentUser);

        [OperationContract]
        List<FormOilsandsPriorityPageDTO> QueryAllOilsandsFormsRequiringApprovalByFunctionalLocationsAndDateRange(
            IFlocSet flocSet, DateRange dateRange);

        [OperationContract]
        List<FormOilsandsTraining> QueryFormOilsandsTrainingsByDatesAndUsersAndWorkAssignments(DateRange range,
            List<long> userIdList, List<long> workAssignmentIdList);
    }
}