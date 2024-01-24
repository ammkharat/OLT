using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class ActionItemDefinitionStatusFixture
    {
        public static List<ActionItemDefinitionStatus> ActionItemDefinitionStatusList()
        {
            List<ActionItemDefinitionStatus> actionItems =
                new List<ActionItemDefinitionStatus>(ActionItemDefinitionStatus.All);

            return actionItems;
        }

        public static ActionItemDefinitionStatus Pending()
        {
            return ActionItemDefinitionStatus.Pending;
        }

        public static ActionItemDefinitionStatus Rejected()
        {
            return ActionItemDefinitionStatus.Rejected;
        }

        public static ActionItemDefinitionStatus Approved()
        {
            return ActionItemDefinitionStatus.Approved;
        }
    }
}