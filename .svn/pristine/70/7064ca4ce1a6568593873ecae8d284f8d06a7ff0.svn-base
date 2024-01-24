using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Utility
{
    /// <summary>
    ///     Given a set of elements, find All possible combinations of these elements that meet
    ///     a given criteria, within the combination size constraint. For example, given a set of 17 numbers,
    ///     this can be used to find All combinations that add up to 32. But brute-forcing through All
    ///     combinations of 17 numbers will take forever, so we can limit combinations to be at most 3 numbers
    ///     to limit the number of combinations checked.
    /// </summary>
    public class CombinationFinder<T>
    {
        public delegate bool CriteriaMatcher(Combination<T> combination);

        private readonly List<T> elements;
        private readonly CriteriaMatcher matchesCriteria;
        private readonly int maxCombinationSize;

        public CombinationFinder(IEnumerable<T> elements, CriteriaMatcher matchesCriteria, int maxCombinationSize) :
            this(new List<T>(elements), matchesCriteria, maxCombinationSize)
        {
        }

        public CombinationFinder(List<T> elements, CriteriaMatcher matchesCriteria, int maxCombinationSize)
        {
            this.elements = elements;
            this.matchesCriteria = matchesCriteria;
            this.maxCombinationSize = maxCombinationSize;
        }

        public List<Combination<T>> FindAll()
        {
            return FindAll(new Combination<T>());
        }

        private List<Combination<T>> FindAll(Combination<T> baseCombination)
        {
            var matchingCombinations = new List<Combination<T>>();

            if (baseCombination.Size >= maxCombinationSize)
            {
                return matchingCombinations;
            }

            for (var i = 0; i < elements.Count; i++)
            {
                var candidate = baseCombination.ShallowClone();
                candidate.Add(elements[i]);

                if (matchesCriteria(candidate))
                {
                    matchingCombinations.Add(candidate);
                }

                // Recursively find more combinations using this candidate as the base combination to start from:
                var remainingElements = elements.SubListFromIndexToEnd(i + 1);
                var recursiveFinder =
                    new CombinationFinder<T>(remainingElements, matchesCriteria, maxCombinationSize);
                matchingCombinations.AddRange(recursiveFinder.FindAll(candidate));
            }

            return matchingCombinations;
        }
    }
}