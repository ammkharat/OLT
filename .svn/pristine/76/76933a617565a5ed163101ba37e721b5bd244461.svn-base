using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IQuestionnaireSectionDao : IDao
    {
        QuestionnaireSection Insert(QuestionnaireSection questionnaireSection);
        void DeleteAllQuestionnaireSections(long questionnaireConfigurationId);
        List<QuestionnaireSection> QuerySectionsByQuestionnaireConfigurationId(long questionnaireConfiguraitonId);
    }
}