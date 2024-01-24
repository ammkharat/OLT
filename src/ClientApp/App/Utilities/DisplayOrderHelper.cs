using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Utilities
{
    public class DisplayOrderHelper
    {
        private static int GetDefaultDisplayOrder(bool useOneBasedIndexes = false)
        {
            return useOneBasedIndexes ? 1 : 0;
        }

        public static void SortAndResetDisplayOrder<T>(List<T> items, bool useOneBasedIndexes = false) where T : IHasDisplayOrder
        {
            SortItems(items);
            ResetDisplayValues(items, useOneBasedIndexes);
        }

        public static void ResetDisplayValues<T>(IList<T> items, bool useOneBasedIndexes = false) where T : IHasDisplayOrder
        {
            var displayValue = GetDefaultDisplayOrder(useOneBasedIndexes);
            foreach (var item in items)
            {
                item.DisplayOrder = displayValue;
                displayValue++;
            }
        }

        public static int GetHighestDisplayOrderValue<T>(List<T> items, bool useOneBasedIndexes = false) where T : IHasDisplayOrder
        {
            if (items.Count == 0)
            {
                return GetDefaultDisplayOrder(useOneBasedIndexes);
            }

            SortItems(items);
            return items[items.Count - 1].DisplayOrder;
        }

        private static void SortItems<T>(List<T> items) where T : IHasDisplayOrder
        {
            items.Sort((x, y) => x.DisplayOrder.CompareTo(y.DisplayOrder));
        }
    }
}