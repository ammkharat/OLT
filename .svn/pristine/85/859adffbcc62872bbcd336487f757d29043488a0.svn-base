using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IShiftHandoverQuestionDao : IDao
    {
        ShiftHandoverQuestion QueryById(long id);
        List<ShiftHandoverQuestion> QueryByConfigurationId(long id);
        ShiftHandoverQuestion Insert(ShiftHandoverQuestion shiftHandoverQuestion);
        void Delete(ShiftHandoverQuestion shiftHandoverQuestion);
        void UpdateAsOlderVersion(ShiftHandoverQuestion question);
    }
}