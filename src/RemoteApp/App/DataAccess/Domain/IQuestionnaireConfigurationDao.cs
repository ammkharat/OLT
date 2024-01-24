using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IQuestionnaireConfigurationDao : IDao
    {
        QuestionnaireConfiguration Insert(QuestionnaireConfiguration questionnaireConfiguration);
        void Update(QuestionnaireConfiguration questionnaireConfiguration);
        void DeleteQuestionnaireConfiguration(long questionnaireConfigurationId);
        QuestionnaireConfiguration GetQuestionnaireConfigurationById(long questionnaireConfigurationId);
        List<QuestionnaireConfigurationDTO> GetQuestionnaireConfigurationDtosBySiteId(long siteId);
    }
}