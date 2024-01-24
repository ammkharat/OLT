using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class QuestionnaireConfigurationFixture
    {
        private static long configId = 1;

        public static QuestionnaireConfiguration Create(long siteId, string type, string name)
        {
            var sections = new List<QuestionnaireSection>
            {
                QuestionnaireSectionFixture.Create(25, "Section 4", 4),
                QuestionnaireSectionFixture.Create(25, "Section 1", 1),
                QuestionnaireSectionFixture.Create(25, "Section 3", 3),
                QuestionnaireSectionFixture.Create(25, "Section 2", 2),
            };

            var configuration =
                new QuestionnaireConfiguration(configId++, siteId,
                    QuestionnaireConfiguration.NewVersionNumber, type, name, sections);

            QuestionnaireConfigurationHelper.UpdateSectionsPercentageWeighting(sections);

            return configuration;
        }
    }
}