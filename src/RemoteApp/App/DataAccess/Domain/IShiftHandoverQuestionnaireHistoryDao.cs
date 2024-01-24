using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IShiftHandoverQuestionnaireHistoryDao : IDao
    {
        [CachedQueryHistory]
        List<ShiftHandoverQuestionnaireHistory> GetById(long id);
        
        [CachedInsertHistory]
        void Insert(ShiftHandoverQuestionnaireHistory history);
    }
}