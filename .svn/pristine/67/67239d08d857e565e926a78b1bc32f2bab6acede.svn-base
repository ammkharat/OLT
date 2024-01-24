using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class PermitAssessmentAnswer : DomainObject
    {
        public const int MaxWeight = 5;

        public PermitAssessmentAnswer()
        {
        }

        public PermitAssessmentAnswer(long? id, int configuredWeight, string questionText, long sectionId,
            string sectionName,
            decimal sectionConfiguredPercentageWeighting, int sectionDisplayOrder,
            int questionDisplayOrder, long questionId,
            string comments = null)
        {
            this.id = id;
            SectionId = sectionId;
            SectionName = sectionName;
            SectionConfiguredPercentageWeighting = sectionConfiguredPercentageWeighting;
            ConfiguredWeight = configuredWeight;
            QuestionText = questionText;
            QuestionId = questionId;
            SectionDisplayOrder = sectionDisplayOrder;
            DisplayOrder = questionDisplayOrder;
            Comments = comments;
        }

        public long PermitAssessmentId { get; set; }

        public long SectionId { get; private set; }

        public string SectionName { get; private set; }

        public decimal SectionConfiguredPercentageWeighting { get; private set; }

        public decimal SectionScoredPercentage { get; set; }

        public long QuestionId { get; private set; }

        public int ConfiguredWeight { get; private set; }

        public string QuestionText { get; private set; }

        public int SectionDisplayOrder { get; set; }

        public int DisplayOrder { get; set; }

        public int Score { get; set; }

        public string Comments { get; set; }

        public int WeightedScore
        {
            get { return Score*ConfiguredWeight; }
        }

        public PermitAssessmentAnswerHistory TakeSnapshot()
        {
            return new PermitAssessmentAnswerHistory(PermitAssessmentId, 0, IdValue, QuestionText, Score, SectionScoredPercentage,
                Comments);
        }
    }
}