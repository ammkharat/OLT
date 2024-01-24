using System.Collections.Generic;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [TestFixture]
    public class MinThresholdTest
    {
        [Test]
        public void ShouldEvaluateIfExceedFloorThreshold()
        {
            // Threshold  Samples                     Gap from
            // Value      Needed   Readings  Exceed?  Threshold
            // 500        1        499       Yes      1
            // 500        1        500       No       0
            // 500        1        501       No       0
            // 500        2        499, 498  Yes      1, 2
            // 500        2        497, 498  Yes      3, 2
            // 500        2        499, 500  No       1, 0
            AssertExceedThreshold(500.0m, 1, new[] {499.0m}, true, new[] {1.0m});
            AssertExceedThreshold(500.0m, 1, new[] {500.0m}, false, new[] {0.0m});
            AssertExceedThreshold(500.0m, 1, new[] {501.0m}, false, new[] {0.0m});
            AssertExceedThreshold(500.0m, 2, new[] {499.0m, 498.0m}, true, new[] {1.0m, 2.0m});
            AssertExceedThreshold(500.0m, 2, new[] {497.0m, 498.0m}, true, new[] {3.0m, 2.0m});
            AssertExceedThreshold(500.0m, 2, new[] {499.0m, 500.0m}, false, new[] {1.0m, 0.0m});
        }

        private void AssertExceedThreshold(decimal thresholdValue, 
                                           int samplesNeededToExceed,
                                           decimal[] actualReadings, 
                                           bool expectedToExceed, 
                                           decimal[] expectedThresholdGaps)
        {
            MinThreshold threshold = new MinThreshold(thresholdValue, samplesNeededToExceed, null);

            List<decimal?> converted =
                new List<decimal>(actualReadings)
                    .ConvertAll<decimal?>(value => value);

            // Execute:
            ThresholdEvaluation evaluation = threshold.Evaluate(new List<decimal?>(converted));

            Assert.AreEqual(expectedToExceed, evaluation.ExceededThreshold);
            Assert.AreEqual(new List<decimal>(expectedThresholdGaps), evaluation.ThresholdGaps);
        }

        [Test]
        public void IsWithinPreApprovedLimitShouldReturnTrueIfNoPreApprovedLimit()
        {
            Assert.IsTrue(new MinThreshold(10.0m, 1, null).IsWithinPreApprovedLimit());
        }

        [Test]
        public void IsWithinPreApprovedLimitShouldReturnTrueIfValueIsEqualToPreApprovedLimit()
        {
            Assert.IsTrue(new MinThreshold(10.0m, 1, 10.0m).IsWithinPreApprovedLimit());
        }

        [Test]
        public void IsWithinPreApprovedLimitShouldReturnTrueIfValueIsGreaterThanPreApprovedLimit()
        {
            Assert.IsTrue(new MinThreshold(11.0m, 1, 10.0m).IsWithinPreApprovedLimit());
        }

        [Test]
        public void IsWithinPreApprovedLimitShouldReturnFalseIfValueIsLessThanPreApprovedLimit()
        {
            Assert.IsFalse(new MinThreshold(9.0m, 1, 10.0m).IsWithinPreApprovedLimit());
        }
    }
}
