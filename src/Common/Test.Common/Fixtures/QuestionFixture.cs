using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class QuestionFixture
    {
        private static long questionId = 1;

        public static Question Create(int weight, string questionText, int displayOrder)
        {
            return new Question(questionId++, 0, 0, displayOrder, weight, questionText);
        }
    }
}