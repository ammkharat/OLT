using Com.Suncor.Olt.Common.Domain.ShiftHandover;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class ShiftHandoverAnswerReportAdapter : AbstractLocalizedReportAdapter
    {
        private readonly ShiftHandoverAnswer answer;
        private readonly string parentId;

        public ShiftHandoverAnswerReportAdapter(string parentId, ShiftHandoverAnswer answer)
        {
            this.parentId = parentId;
            this.answer = answer;
        }

        public string ParentId
        {
            get { return parentId; }
        }

        public bool Yes
        {
            get { return answer.Answer; }
        }

        public bool No
        {
            get { return !Yes; }
        }

        public string Question
        {
            get { return answer.QuestionText; }
        }

        public string Comments
        {
            get { return answer.Comments; }
        }

        public int QuestionDisplayOrder
        {
            get { return answer.QuestionDisplayOrder; }
        }

        public bool ShouldSuppressComments
        {
            get { return No; }
        }
    }
}