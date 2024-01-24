using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class PermitAssessmentAnswerReportAdapter
    {
        private readonly PermitAssessmentAnswer item;
        private readonly long parentId;

        public PermitAssessmentAnswerReportAdapter(long parentId, PermitAssessmentAnswer item)
        {
            this.parentId = parentId;
            this.item = item;
        }

        public long ParentId
        {
            get { return parentId; }
        }

        public long PermitAssessmentId
        {
            get { return item.PermitAssessmentId; }
        }

        public long SectionId
        {
            get { return item.SectionId; }
        }

        public string SectionName
        {
            get { return item.SectionName; }
        }

        public decimal SectionConfiguredPercentageWeighting
        {
            get { return item.SectionConfiguredPercentageWeighting; }
        }

        public decimal SectionScoredPercentage
        {
            get { return item.SectionScoredPercentage; }
        }

        public long QuestionId
        {
            get { return item.QuestionId; }
        }

        public int ConfiguredWeight
        {
            get { return item.ConfiguredWeight; }
        }

        public int ConfiguredMultipliedWeight
        {
            get { return PermitAssessmentAnswer.MaxWeight*item.ConfiguredWeight; }
        }

        public string QuestionText
        {
            get { return item.QuestionText; }
        }

        public int SectionDisplayOrder
        {
            get { return item.SectionDisplayOrder; }
        }

        public int DisplayOrder
        {
            get { return item.DisplayOrder; }
        }

        public int Score
        {
            get { return item.Score; }
        }

        public string Comments
        {
            get { return item.Comments; }
        }

        public int WeightedScore
        {
            get { return item.WeightedScore; }
        }
    }
}