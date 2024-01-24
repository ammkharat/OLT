using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IQuestionnaireConfigurationService
    {
        [OperationContract]
        QuestionnaireConfiguration QueryQuestionnaireConfigurationById(long questionnaireConfigurationId);

        [OperationContract]
        QuestionnaireConfiguration InsertQuestionnaireConfiguration(
            QuestionnaireConfiguration questionnaireConfiguration);

        [OperationContract]
        void UpdateQuestionnaireConfiguration(QuestionnaireConfiguration questionnaireConfiguration);

        [OperationContract]
        void DeleteQuestionnaireConfiguration(long questionnaireConfigurationId);

        [OperationContract]
        List<QuestionnaireConfigurationDTO> QueryQuestionnaireConfigurationDtosBySiteId(long siteId);
    }
}