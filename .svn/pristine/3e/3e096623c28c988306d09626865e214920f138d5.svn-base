using System.Collections.Generic;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class CombinationFinderTest
    {
        [Test]
        public void ShouldFindCombinationsSatisfyingSomeCondition()
        {
            // Given the numbers 1, 2, 3, 4, 5,
            // what are All the combinations that add up to 5?
            AssertMatchingCombinations(new[] { 1, 4 }, new[] { 2, 3 }, new[] { 5 },
                new[] { 1, 2, 3, 4, 5 }, AddTo5);
        }
        
        [Test]
        public void ShouldFindCombinationsSatisfyingSomeConditionWithinSizeConstraint()
        {
            // Given the numbers 1, 2, 3, 4, 5, 6,
            // what are All the combinations that add up to 6,
            // with the constraint that combinations be 2 numbers or less?
            //     1, 2, 3  NO
            //     1, 5     YES
            //     2, 4     YES
            //     6        YES
            AssertMatchingCombinations(new[] { 1, 5 }, new[] { 2, 4 }, new[] { 6 }, 
                new[] { 1, 2, 3, 4, 5, 6 }, AddTo6, 2);
        }
        
        private bool AddTo5(Combination<int> combination)
        {
            return AddToN(combination, 5);
        }

        private bool AddTo6(Combination<int> combination)
        {
            return AddToN(combination, 6);
        }

        private bool AddToN(Combination<int> combination, int desiredTotal)
        {
            int total = 0;

            foreach (int element in combination.Elements)
            {
                total += element;
            }

            return total == desiredTotal;
        }

        private void AssertMatchingCombinations(int[] expectedCombination1, int[] expectedCombination2, 
                                                int[] expectedCombination3, int[] elements,
                                                CombinationFinder<int>.CriteriaMatcher matchesCriteria)
        {
            AssertMatchingCombinations(expectedCombination1, expectedCombination2, expectedCombination3, 
                                       elements, matchesCriteria, int.MaxValue);
        }

        private void AssertMatchingCombinations(int[] expectedCombination1, int[] expectedCombination2, 
                                                int[] expectedCombination3, int[] elements, 
                                                CombinationFinder<int>.CriteriaMatcher matchesCriteria, 
                                                int maxCombinationSize)
        {
            List<Combination<int>> actualCombinations = 
                new CombinationFinder<int>(elements, matchesCriteria, maxCombinationSize).FindAll();
            Assert.AreEqual(3, actualCombinations.Count);
            
            Assert.AreEqual(new Combination<int>(expectedCombination1), actualCombinations[0]);
            Assert.AreEqual(new Combination<int>(expectedCombination2), actualCombinations[1]);
            Assert.AreEqual(new Combination<int>(expectedCombination3), actualCombinations[2]);
        }
    }
}
