using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class QuestionnaireConfigurationService : IQuestionnaireConfigurationService
    {
        private readonly IQuestionnaireConfigurationDao questionnaireConfigurationDao;

        public QuestionnaireConfigurationService()
        {
            questionnaireConfigurationDao = DaoRegistry.GetDao<IQuestionnaireConfigurationDao>();
        }

        public QuestionnaireConfiguration QueryQuestionnaireConfigurationById(long questionnaireConfigurationId)
        {
            return questionnaireConfigurationDao.GetQuestionnaireConfigurationById(questionnaireConfigurationId);
        }

        public QuestionnaireConfiguration InsertQuestionnaireConfiguration(
            QuestionnaireConfiguration questionnaireConfiguration)
        {
            return questionnaireConfigurationDao.Insert(questionnaireConfiguration);
        }

        public void UpdateQuestionnaireConfiguration(QuestionnaireConfiguration questionnaireConfiguration)
        {
            questionnaireConfigurationDao.Update(questionnaireConfiguration);
        }

        public void DeleteQuestionnaireConfiguration(long questionnaireConfigurationId)
        {
            questionnaireConfigurationDao.DeleteQuestionnaireConfiguration(questionnaireConfigurationId);
        }

        public List<QuestionnaireConfigurationDTO> QueryQuestionnaireConfigurationDtosBySiteId(long siteId)
        {
            return questionnaireConfigurationDao.GetQuestionnaireConfigurationDtosBySiteId(siteId);
        }
    }
}