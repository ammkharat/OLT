using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class QuestionnaireSectionQuestionDao : AbstractManagedDao, IQuestionnaireSectionQuestionDao
    {
        private const string QUERY_BY_QUESTIONNAIRE_CONFIGURATION_ID =
            "QueryQuestionnaireSectionQuestionsByQuestionnaireConfigurationId";

        private const string DELETE_QUESTIONS_BY_QUESTIONNAIRE_CONFIGURATION_ID =
            "DeleteQuestionsByQuestionnaireConfigurationId";

        private const string INSERT = "InsertQuestionnaireSectionQuestion";


        public Question Insert(Question question)
        {
            var command = ManagedCommand;

            var idParameter = command.AddIdOutputParameter();
            command.Insert(question, AddInsertParameters, INSERT);
            question.Id = (long?) idParameter.Value;

            return question;
        }

        public void DeleteAllQuestionnaireConfigurationQuestions(long questionnaireConfigurationId)
        {
            var command = ManagedCommand;
            command.AddParameter("@QuestionnaireConfigurationId", questionnaireConfigurationId);
            command.ExecuteNonQuery(DELETE_QUESTIONS_BY_QUESTIONNAIRE_CONFIGURATION_ID);
        }

        public List<Question> QueryByQuestionnaireConfigurationId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@QuestionnaireConfigurationId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_QUESTIONNAIRE_CONFIGURATION_ID);
        }


        private static void AddInsertParameters(Question question, SqlCommand command)
        {
            command.AddParameter("@QuestionnaireConfigurationId", question.QuestionnaireConfigurationId);
            command.AddParameter("@QuestionnaireSectionId", question.QuestionnaireSectionId);
            command.AddParameter("@DisplayOrder", question.DisplayOrder);
            command.AddParameter("@Weight", question.Weight);
            command.AddParameter("@QuestionText", question.QuestionText);
        }

        private static Question PopulateInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("Id");
            var questionnaireSectionId = reader.Get<long>("QuestionnaireSectionId");
            var questionnaireConfigurationId = reader.Get<long>("QuestionnaireConfigurationId");
            var displayOrder = reader.Get<int>("DisplayOrder");
            var questionText = reader.Get<string>("QuestionText");
            var weight = reader.Get<int>("Weight");

            return new Question(id, questionnaireSectionId, questionnaireConfigurationId, displayOrder, weight,
                questionText);
        }
    }
}