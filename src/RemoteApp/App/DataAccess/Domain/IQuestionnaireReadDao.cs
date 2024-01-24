using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IQuestionnaireReadDao : IDao
    {
        ItemRead<ShiftHandoverQuestionnaire> UserMarkedAsRead(long shiftHandoverQuestionnaireId, long userId);
        void Insert(ItemRead<ShiftHandoverQuestionnaire> itemRead);
        List<ItemReadBy> UsersThatMarkedAsRead(long questionnaireId);
    }
}