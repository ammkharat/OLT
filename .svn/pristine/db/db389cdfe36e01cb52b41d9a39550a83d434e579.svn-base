using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IPermitAssessmentAnswerDao : IDao
    {
        List<PermitAssessmentAnswer> QueryByPermitAssessmentId(long id);
        PermitAssessmentAnswer Insert(PermitAssessmentAnswer permitAssessmentAnswer, long permitAssessmentId);
        void Update(PermitAssessmentAnswer answer);
    }
}