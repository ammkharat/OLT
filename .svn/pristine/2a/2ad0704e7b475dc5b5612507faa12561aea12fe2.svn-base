using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IShiftHandoverQuestionnaireDao : IDao
    {
        [CachedQueryById]
        ShiftHandoverQuestionnaire QueryById(long id);
        List<ShiftHandoverQuestionnaire> QueryByUserWorkAssignmentAndShift(long userId, long workAssignmentId, UserShift userShift);
        List<ShiftHandoverQuestionnaire> QueryByWorkAssignmentAndShift(long workAssignmentId, UserShift userShift);
        
        [CachedInsertOrUpdate(false, false)]
        void Insert(ShiftHandoverQuestionnaire questionnaire);
        
        [CachedInsertOrUpdate(false, false)]
        void Update(ShiftHandoverQuestionnaire questionnaire);
        
        [CachedRemove(false, false)]
        void Delete(ShiftHandoverQuestionnaire questionnaire);
        
        List<ShiftHandoverQuestionnaire> QueryByFunctionalLocationAndDateRangeAndAssignment(
            IFlocSet flocSet,
            DateTime fromDate,
            DateTime toDate,
            List<WorkAssignment> workAssignments,
            bool includeNullWorkAssignment);

        List<ShiftHandoverQuestionnaire> QueryByFunctionalLocationAndDateRangeAndAssignment(
           IFlocSet flocSet,
           DateTime fromDate,
           DateTime toDate,
           List<WorkAssignment> workAssignments,
           bool includeNullWorkAssignment, bool showFlexibleShiftHandoverData);

    }
}
