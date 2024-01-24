using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class GasTestElementResultDTOConverter
    {
        public List<GasTestElementResultDTO> ConvertAll(WorkPermit permit)
        {
            List<GasTestElement> elements = permit.GasTests.Elements;
            elements.Sort(new GasTestElementComparer());
            
            List<GasTestElementResultDTO> results =
                elements.ConvertAll(element => Convert(element, permit));
            return results;
        }

        public GasTestElementResultDTO Convert(GasTestElement element, WorkPermit permit)
        {
            return new GasTestElementResultDTO(element.ElementInfo.Name,
                new GasTestElementLimitFormatter().ToLimitWithUnits(element, permit),
                element.ImmediateAreaTestRequired, element.ImmediateAreaTestResult, element.ConfinedSpaceTestResult, element.SystemEntryTestResult);
        }

        /// <summary>
        /// Sorts gas test elements first by standard (standards come before others), then
        /// by display order.
        /// </summary>
        private class GasTestElementComparer : IComparer<GasTestElement>
        {
            public int Compare(GasTestElement left, GasTestElement right)
            {
                int isStandardComparison =
                    CompareByIsStandard(left.ElementInfo.IsStandard, right.ElementInfo.IsStandard);

                if (isStandardComparison != 0)
                {
                    return isStandardComparison;
                }

                return left.ElementInfo.DisplayOrder.CompareTo(right.ElementInfo.DisplayOrder);
            }

            private static int CompareByIsStandard(bool leftIsStandard, bool rightIsStandard)
            {
                if (leftIsStandard == rightIsStandard)
                {
                    return 0;
                }

                return leftIsStandard ? -1 : 1;
            }
        }
    }
}
