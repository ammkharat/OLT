using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IQuestionnaireSectionQuestionDao : IDao
    {
        List<Question> QueryByQuestionnaireConfigurationId(long id);
        Question Insert(Question question);
        void DeleteAllQuestionnaireConfigurationQuestions(long questionnaireConfigurationId);
    }
}