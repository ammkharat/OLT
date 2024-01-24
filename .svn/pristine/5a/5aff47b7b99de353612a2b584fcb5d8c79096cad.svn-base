using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class QuestionnaireConfigurationDao : AbstractManagedDao, IQuestionnaireConfigurationDao
    {
        private const string INSERT = "InsertQuestionnaireConfiguration";
        private const string DELETE_QUESTIONNAIRE_CONFIGURATION_BY_ID = "DeleteQuestionnaireConfigurationById";
        private const string QUERY_BY_ID = "QueryQuestionnaireConfigurationById";
        private const string QUERY_BY_SITE = "QueryQuestionnaireConfigurationDtosBySiteId";
        private const string UPDATE = "UpdateQuestionnaireConfiguration";
        private readonly IQuestionnaireSectionQuestionDao questionDao;
        private readonly IQuestionnaireSectionDao sectionDao;

        public QuestionnaireConfigurationDao()
        {
            questionDao = DaoRegistry.GetDao<IQuestionnaireSectionQuestionDao>();
            sectionDao = DaoRegistry.GetDao<IQuestionnaireSectionDao>();
        }

        public QuestionnaireConfiguration Insert(QuestionnaireConfiguration questionnaireConfiguration)
        {
            var command = ManagedCommand;
            var idParameter = command.AddIdOutputParameter();
            command.Insert(questionnaireConfiguration, AddInsertParameters, INSERT);
            questionnaireConfiguration.Id = (long?) idParameter.Value;

            foreach (var questionSection in questionnaireConfiguration.QuestionnaireSections)
            {
                questionSection.QuestionnaireConfigurationId = questionnaireConfiguration.IdValue;
                sectionDao.Insert(questionSection);
                foreach (var question in questionSection.Questions)
                {
                    question.QuestionnaireConfigurationId = questionnaireConfiguration.IdValue;
                    question.QuestionnaireSectionId = questionSection.IdValue;
                    questionDao.Insert(question);
                }
            }
            return questionnaireConfiguration;
        }

        public QuestionnaireConfiguration GetQuestionnaireConfigurationById(long questionnaireConfigurationId)
        {
            var command = ManagedCommand;
            return command.QueryById(questionnaireConfigurationId, PopulateInstance, QUERY_BY_ID);
        }

        public List<QuestionnaireConfigurationDTO> GetQuestionnaireConfigurationDtosBySiteId(long siteId)
        {
            var command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return command.QueryForListResult(PopulateInstanceDto, QUERY_BY_SITE);
        }

        public void Update(QuestionnaireConfiguration questionnaireConfiguration)
        {
            questionDao.DeleteAllQuestionnaireConfigurationQuestions(questionnaireConfiguration.IdValue);
            sectionDao.DeleteAllQuestionnaireSections(questionnaireConfiguration.IdValue);
            var command = ManagedCommand;

            command.Update(questionnaireConfiguration, AddUpdateParameters, UPDATE);

            foreach (var questionSection in questionnaireConfiguration.QuestionnaireSections)
            {
                questionSection.QuestionnaireConfigurationId = questionnaireConfiguration.IdValue;
                sectionDao.Insert(questionSection);
                foreach (var question in questionSection.Questions)
                {
                    question.QuestionnaireConfigurationId = questionnaireConfiguration.IdValue;
                    question.QuestionnaireSectionId = questionSection.IdValue;
                    questionDao.Insert(question);
                }
            }
        }

        public void DeleteQuestionnaireConfiguration(long questionnaireConfigurationId)
        {
            questionDao.DeleteAllQuestionnaireConfigurationQuestions(questionnaireConfigurationId);
            sectionDao.DeleteAllQuestionnaireSections(questionnaireConfigurationId);
            var command = ManagedCommand;
            command.AddParameter("@QuestionnaireConfigurationId", questionnaireConfigurationId);
            command.ExecuteNonQuery(DELETE_QUESTIONNAIRE_CONFIGURATION_BY_ID);
        }

        private static void AddUpdateParameters(QuestionnaireConfiguration configuration, SqlCommand command)
        {
            command.AddParameter("@Id", configuration.Id);
            command.AddParameter("@Version", configuration.Version + 1);
            command.AddParameter("@Name", configuration.Name);
        }

        private QuestionnaireConfigurationDTO PopulateInstanceDto(SqlDataReader reader)
        {
            var id = reader.Get<long>("Id");
            var name = reader.Get<string>("Name");
            var type = reader.Get<string>("Type");
            var version = reader.Get<int>("Version");

            return new QuestionnaireConfigurationDTO(id, type, name, version);
        }

        private QuestionnaireConfiguration PopulateInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("Id");
            var siteId = reader.Get<long>("SiteId");
            var name = reader.Get<string>("Name");
            var type = reader.Get<string>("Type");
            var version = reader.Get<int>("Version");

            var questionnaireConfiguration = new QuestionnaireConfiguration(id, siteId, version, type, name)
            {
                QuestionnaireSections = sectionDao.QuerySectionsByQuestionnaireConfigurationId(id)
            };

            var allQuestions = questionDao.QueryByQuestionnaireConfigurationId(questionnaireConfiguration.IdValue);

            foreach (var section in questionnaireConfiguration.QuestionnaireSections)
            {
                section.Questions =
                    allQuestions.Where(question => question.QuestionnaireSectionId == section.IdValue).ToList();
            }

            return questionnaireConfiguration;
        }

        private static void AddInsertParameters(QuestionnaireConfiguration questionnaireConfiguration,
            SqlCommand command)
        {
            command.AddParameter("@SiteId", questionnaireConfiguration.SiteId);
            command.AddParameter("@Version", questionnaireConfiguration.Version);
            command.AddParameter("@Name", questionnaireConfiguration.Name);
            command.AddParameter("@Type", questionnaireConfiguration.Type);
        }
    }
}