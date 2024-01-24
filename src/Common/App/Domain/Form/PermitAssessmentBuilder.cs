using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    public class PermitAssessmentBuilder
    {
        public static PermitAssessment Build(QuestionnaireConfiguration configuration, User user,
            long creationUserShiftPatternId,
            DateTime permitStartDateTime, DateTime permitExpiredDateTime, DateTime permitCreatedDateTime)
        {
            var answers = BuildAnswers(configuration);

            var assessment =
                new PermitAssessment(null,
                    permitStartDateTime,
                    permitExpiredDateTime,
                    FormStatus.Draft,
                    user,
                    permitCreatedDateTime,
                    creationUserShiftPatternId,
                    user,
                    permitCreatedDateTime,
                    configuration,
                    answers);

            assessment.OilsandsWorkPermitType = OilsandsWorkPermitType.BlanketCold;
            assessment.PermitNumber = "Permit #";
            assessment.Trade = "Trade";

            assessment.RefreshAnswersAndTotals();

            return assessment;
        }

        public static IEnumerable<PermitAssessmentAnswer> BuildAnswers(QuestionnaireConfiguration configuration)
        {
            var answers = new List<PermitAssessmentAnswer>();

            foreach (var section in configuration.QuestionnaireSections)
            {
                foreach (var question in section.Questions)
                {
                    var answer = new PermitAssessmentAnswer(null, question.Weight, question.QuestionText,
                        section.IdValue, section.Name,
                        section.PercentageWeighting, section.DisplayOrder, question.DisplayOrder, question.IdValue);

                    answers.Add(answer);
                }
            }

            var sortedList =
                answers.OrderBy(answer => answer.SectionDisplayOrder).ThenBy(answer => answer.DisplayOrder).ToList();

            return sortedList;
        }
    }
}