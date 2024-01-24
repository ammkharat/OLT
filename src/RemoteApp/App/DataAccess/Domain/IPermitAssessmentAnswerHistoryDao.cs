using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IPermitAssessmentAnswerHistoryDao : IDao
    {
        List<PermitAssessmentAnswerHistory> GetByHistoryId(long id);
        void Insert(PermitAssessmentAnswerHistory history);
    }
}