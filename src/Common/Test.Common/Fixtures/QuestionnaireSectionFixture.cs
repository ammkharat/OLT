using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class QuestionnaireSectionFixture
    {
        public static QuestionnaireSection Create(decimal percentageWeighting, string name, int displayOrder)
        {
            var section = new QuestionnaireSection(displayOrder, 0, displayOrder, percentageWeighting, name,
                new List<Question>
                {
                    QuestionFixture.Create(10, "Question 2", 2),
                    QuestionFixture.Create(10, "Question 1", 1),
                });

            return section;
        }
    }
}