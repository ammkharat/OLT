using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class ActionItemStatusFixture
    {
        public static List<ActionItemStatus> ActionItemStatusList()
        {
            return new List<ActionItemStatus>(ActionItemStatus.AvailableForCurrentView);
        }

        public static ActionItemStatus Incomplete()
        {
            return ActionItemStatus.Incomplete;
        }

        public static ActionItemStatus Complete()
        {
            return ActionItemStatus.Complete;
        }

        public static ActionItemStatus Pending()
        {
            return ActionItemStatus.Current;
        }
    }
}