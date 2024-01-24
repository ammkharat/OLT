using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class CokerCardConfigurationFixture
    {
        public static CokerCardConfiguration CreateForInsert(FunctionalLocation floc)
        {
            CokerCardConfiguration configuration = new CokerCardConfiguration(null, "Test Card Configuration", floc);

            CokerCardConfigurationDrum drum1 = new CokerCardConfigurationDrum(null, "DR1", 1);
            CokerCardConfigurationDrum drum2 = new CokerCardConfigurationDrum(null, "DR2", 2);
            CokerCardConfigurationDrum drum3 = new CokerCardConfigurationDrum(null, "DR3", 3);

            List<CokerCardConfigurationDrum> drums = new List<CokerCardConfigurationDrum>{drum1, drum2, drum3};
            configuration.Drums.AddRange(drums);

            CokerCardConfigurationCycleStep step1 = new CokerCardConfigurationCycleStep(null, "Step1", 1);
            CokerCardConfigurationCycleStep step2 = new CokerCardConfigurationCycleStep(null, "Step2", 2);
            CokerCardConfigurationCycleStep step3 = new CokerCardConfigurationCycleStep(null, "Step3", 3);

            List<CokerCardConfigurationCycleStep> steps = new List<CokerCardConfigurationCycleStep>{step1, step2, step3};            
            configuration.Steps.AddRange(steps);

            return configuration;
        }
    }
}
