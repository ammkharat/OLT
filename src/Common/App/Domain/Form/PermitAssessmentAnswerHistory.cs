using System;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class PermitAssessmentAnswerHistory : DomainObject
    {
        public PermitAssessmentAnswerHistory(long id, long historyId, long answerId, string questionText, int score,
            decimal sectionScoredPercentage, string comments)
        {
            this.id = id;
            HistoryId = historyId;
            AnswerId = answerId;
            QuestionText = questionText;
            Score = score;
            SectionScoredPercentage = sectionScoredPercentage;
            Comments = comments;
        }

        [IgnoreDifference]
        public long HistoryId { get; set; }

        [IgnoreDifference]
        public long AnswerId { get; private set; }

        [DifferenceLabel]
        public string QuestionText { get; private set; }

        public decimal SectionScoredPercentage { get; private set; }

        public int Score { get; private set; }

        public string Comments { get; private set; }
    }
}