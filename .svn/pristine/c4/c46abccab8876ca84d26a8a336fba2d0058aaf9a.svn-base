using System.Collections.Generic;
using System.Linq;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    public class QuestionnaireConfigurationHelper
    {
        public static decimal RecalculatePercentageWeighting(QuestionnaireConfiguration config,
            QuestionnaireSection section)
        {
            var totalWeightOfAllSectionsExceptThisOne = config.TotalWeightOfAllQuestions(section);
            var totalWeightOfQuestionsInThisSection = section.TotalWeightOfAllQuestions();

            var percentageWeighting = (totalWeightOfQuestionsInThisSection/
                                       (decimal)
                                           (totalWeightOfAllSectionsExceptThisOne + totalWeightOfQuestionsInThisSection))*
                                      100;

            return percentageWeighting;
        }

        public static void UpdateSectionsPercentageWeighting(IEnumerable<QuestionnaireSection> sections)
        {
            int totalWeightOfAllSections = sections.Sum(section => section.TotalWeightOfAllQuestions());

            foreach (var section in sections)
            {
                int totalWeightOfQuestionsInThisSection = section.TotalWeightOfAllQuestions();

                var percentageWeighting = (totalWeightOfQuestionsInThisSection / (decimal) (totalWeightOfAllSections)) * 100;

                section.PercentageWeighting = percentageWeighting;
            }
        }
    }
}