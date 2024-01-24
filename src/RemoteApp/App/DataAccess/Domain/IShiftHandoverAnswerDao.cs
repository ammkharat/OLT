using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IShiftHandoverAnswerDao : IDao
    {
        List<ShiftHandoverAnswer> QueryByQuestionnaireId(long id);
        ShiftHandoverAnswer Insert(ShiftHandoverAnswer shiftHandoverAnswer, long questionnaireId);
        void Update(ShiftHandoverAnswer answer);
        List<ShiftHandoverAnswerDTO> QueryByParentFlocListAndMarkedAsRead(DateTime from, DateTime to, IFlocSet flocSet, bool showFlexibleShiftHandOverDataOnly);
    }
}
