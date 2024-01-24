using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class PermitAssessmentAnswerDao : AbstractManagedDao, IPermitAssessmentAnswerDao
    {
        private const string QUERY_BY_PERMIT_ASSESSMENT_ID = "QueryPermitAssessmentAnswersByPermitAssessmentId";
        private const string INSERT = "InsertPermitAssessmentAnswer";
        private const string UPDATE = "UpdatePermitAssessmentAnswer";
        private readonly IShiftHandoverQuestionDao questionDao;

        public PermitAssessmentAnswerDao()
        {
            questionDao = DaoRegistry.GetDao<IShiftHandoverQuestionDao>();
        }

        public List<PermitAssessmentAnswer> QueryByPermitAssessmentId(long permitAssessmentId)
        {
            var command = ManagedCommand;
            command.AddParameter("@PermitAssessmentId", permitAssessmentId);

            var answers = command.QueryForListResult(PopulateInstance, QUERY_BY_PERMIT_ASSESSMENT_ID);

            return answers;
        }

        public PermitAssessmentAnswer Insert(PermitAssessmentAnswer permitAssessmentAnswer, long permitAssessmentId)
        {
            var command = ManagedCommand;
            var idParameter = command.AddIdOutputParameter();
            command.AddParameter("@PermitAssessmentId", permitAssessmentId);
            command.Insert(permitAssessmentAnswer, AddInsertParameters, INSERT);
            permitAssessmentAnswer.Id = (long?) idParameter.Value;
            return permitAssessmentAnswer;
        }

        public void Update(PermitAssessmentAnswer permitAssessmentAnswer)
        {
            var command = ManagedCommand;
            command.Update(permitAssessmentAnswer, AddUpdateParameters, UPDATE);
        }

        private static void AddInsertParameters(PermitAssessmentAnswer permitAssessmentAnswer, SqlCommand command)
        {
            command.AddParameter("@SectionId", permitAssessmentAnswer.SectionId);
            command.AddParameter("@SectionName", permitAssessmentAnswer.SectionName);
            command.AddParameter("@SectionConfiguredPercentageWeighting",
                permitAssessmentAnswer.SectionConfiguredPercentageWeighting);
            command.AddParameter("@QuestionId", permitAssessmentAnswer.QuestionId);
            command.AddParameter("@ConfiguredWeight", permitAssessmentAnswer.ConfiguredWeight);
            command.AddParameter("@QuestionText", permitAssessmentAnswer.QuestionText);
            command.AddParameter("@SectionDisplayOrder", permitAssessmentAnswer.SectionDisplayOrder);
            command.AddParameter("@DisplayOrder", permitAssessmentAnswer.DisplayOrder);
            SetCommonAttributes(permitAssessmentAnswer, command);
        }

        private static void AddUpdateParameters(PermitAssessmentAnswer permitAssessmentAnswer, SqlCommand command)
        {
            command.AddParameter("@Id", permitAssessmentAnswer.Id);
            SetCommonAttributes(permitAssessmentAnswer, command);
        }

        private static void SetCommonAttributes(PermitAssessmentAnswer permitAssessmentAnswer, SqlCommand command)
        {
            command.AddParameter("@SectionScoredPercentage", permitAssessmentAnswer.SectionScoredPercentage);
            command.AddParameter("@Score", permitAssessmentAnswer.Score);
            command.AddParameter("@Comments", permitAssessmentAnswer.Comments);
        }

        private PermitAssessmentAnswer PopulateInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("Id");
            var permitAssessmentId = reader.Get<long>("PermitAssessmentId");
            var sectionId = reader.Get<long>("SectionId");
            var sectionName = reader.Get<string>("SectionName");
            var sectionConfiguredPercentageWeighting = reader.Get<decimal>("SectionConfiguredPercentageWeighting");
            var sectionScoredPercentage = reader.Get<decimal>("SectionScoredPercentage");
            var questionId = reader.Get<long>("QuestionId");
            var configuredWeight = reader.Get<int>("ConfiguredWeight");
            var questionText = reader.Get<string>("QuestionText");
            var sectionDisplayOrder = reader.Get<int>("SectionDisplayOrder");
            var displayOrder = reader.Get<int>("displayOrder");
            var score = reader.Get<int>("Score");
            var comments = reader.Get<string>("Comments");

            var permitAssessmentAnswer =
                new PermitAssessmentAnswer(id, configuredWeight, questionText, sectionId, sectionName,
                    sectionConfiguredPercentageWeighting, sectionDisplayOrder, displayOrder, questionId, comments)
                {
                    PermitAssessmentId = permitAssessmentId,
                    SectionScoredPercentage = sectionScoredPercentage,
                    Score = score
                };

            return permitAssessmentAnswer;
        }
    }
}