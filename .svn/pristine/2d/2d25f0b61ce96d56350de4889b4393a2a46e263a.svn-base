using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class QuestionnaireSectionDao : AbstractManagedDao, IQuestionnaireSectionDao
    {
        private const string INSERT = "InsertQuestionnaireSection";
        private const string DELETE_QUESTIONNAIRE_SECTIONS_BY_QUESTIONNAIRE_CONFIGURATION_ID = "DeleteQuestionnaireSectionsByQuestionnaireConfigurationId";

        public const string QUERY_BY_QUESTIONNAIRE_CONFIGURATION_ID =
            "QueryQuestionnaireSectionsByQuestionnaireConfigurationId";

        public QuestionnaireSection Insert(QuestionnaireSection questionnaireSection)
        {
            var command = ManagedCommand;
            var idParameter = command.AddIdOutputParameter();
            command.Insert(questionnaireSection, AddInsertParameters, INSERT);
            questionnaireSection.Id = (long?) idParameter.Value;
            return questionnaireSection;
        }

        public void DeleteAllQuestionnaireSections(long questionnaireConfigurationId)
        {
            var command = ManagedCommand;
            command.AddParameter("@QuestionnaireConfigurationId", questionnaireConfigurationId);
            command.ExecuteNonQuery(DELETE_QUESTIONNAIRE_SECTIONS_BY_QUESTIONNAIRE_CONFIGURATION_ID);
        }

        public List<QuestionnaireSection> QuerySectionsByQuestionnaireConfigurationId(
            long questionnaireConfigurationId)
        {
            var command = ManagedCommand;

            command.AddParameter("@QuestionnaireConfigurationId", questionnaireConfigurationId);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_QUESTIONNAIRE_CONFIGURATION_ID);
        }

        private static QuestionnaireSection PopulateInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("Id");
            var questionnaireConfigurationId = reader.Get<long>("QuestionnaireConfigurationId");
            var displayOrder = reader.Get<int>("DisplayOrder");
            var name = reader.Get<string>("Name");
            var percentageWeighting = reader.Get<decimal>("PercentageWeighting");
            var questionnaireSection = new QuestionnaireSection(id, questionnaireConfigurationId, displayOrder,
                percentageWeighting, name);
            return questionnaireSection;
        }


        private static void AddInsertParameters(QuestionnaireSection questionnaireSection,
            SqlCommand command)
        {
            command.AddParameter("@Name", questionnaireSection.Name);
            command.AddParameter("@QuestionnaireConfigurationId", questionnaireSection.QuestionnaireConfigurationId);
            command.AddParameter("@DisplayOrder", questionnaireSection.DisplayOrder);
            command.AddParameter("@PercentageWeighting", questionnaireSection.PercentageWeighting);
        }
    }
}