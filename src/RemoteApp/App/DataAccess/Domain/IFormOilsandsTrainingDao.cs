using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    // Caching Notes - there is a Training items dao, but because it's only called by this dao we are safe to cache at this level.
    public interface IFormOilsandsTrainingDao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        FormOilsandsTraining Insert(FormOilsandsTraining form);
        
        //ayman generic forms
        [CachedQueryByIdAndSiteId]
        FormOilsandsTraining QueryByIdAndSiteId(long id,long siteid);

        [CachedQueryById]
        FormOilsandsTraining QueryById(long id);
        [CachedInsertOrUpdate(false, false)]
        void Update(FormOilsandsTraining form);
        [CachedRemove(false, false)]
        void Remove(FormOilsandsTraining form);
        long? QueryTrainingDateAndShiftAndAssignmentDuplicatesOnOtherForms(long? formId, Date trainingDate, ShiftPattern shiftPattern, WorkAssignment workAssignment, User currentUser);
        List<FormOilsandsTraining> QueryByDateAndUsersAndWorkAssignments(DateRange range, List<long> userIdList, List<long> workAssignmentIdList);
    }
}
