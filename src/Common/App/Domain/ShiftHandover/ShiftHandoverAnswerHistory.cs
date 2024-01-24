using System;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.ShiftHandover
{
    [Serializable]
    public class ShiftHandoverAnswerHistory : DomainObject
    {
        public ShiftHandoverAnswerHistory(long id, long historyId, long questionId, string questionText, bool answer,
            string comments)
        {
            this.id = id;
            HistoryId = historyId;
            QuestionId = questionId;
            QuestionText = questionText;
            Answer = answer;
            Comments = comments;
        }

        [IgnoreDifference]
        public long QuestionId { get; private set; }

        [IgnoreDifference]
        public long HistoryId { get; set; }

        [DifferenceLabel]
        public string QuestionText { get; private set; }

        [IgnoreDifference]
        public bool Answer { get; private set; }

        public string AnswerDisplay
        {
            get
            {
                if (Answer)
                {
                    return StringResources.Yes;
                }
                return StringResources.No;
            }
        }

        public string Comments { get; private set; }
    }
}