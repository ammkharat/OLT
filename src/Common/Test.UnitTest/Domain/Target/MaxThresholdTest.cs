using System.Collections.Generic;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [TestFixture]
    public class MaxThresholdTest
    {
        [Test]
        public void ShouldEvaluateIfExceedCeilingThreshold()
        {
            // Threshold  Samples                     Gap from
            // Value      Needed   Readings  Exceed?  Threshold
            // 500        1        501       Yes      1
            // 500        1        500       No       0
            // 500        1        499       No       0
            // 500        2        501, 502  Yes      1, 2
            // 500        2        503, 502  Yes      3, 2
            // 500        2        501, 500  No       1, 0
            AssertExceedThreshold(500.0m, 1, new[] { 501.0m }, true, new[] { 1.0m });
            AssertExceedThreshold(500.0m, 1, new[] { 500.0m }, false, new[] { 0.0m });
            AssertExceedThreshold(500.0m, 1, new[] { 499.0m }, false, new[] { 0.0m });
            AssertExceedThreshold(500.0m, 2, new[] { 501.0m, 502.0m }, true, new[] { 1.0m, 2.0m });
            AssertExceedThreshold(500.0m, 2, new[] { 503.0m, 502.0m }, true, new[] { 3.0m, 2.0m });
            AssertExceedThreshold(500.0m, 2, new[] { 501.0m, 500.0m }, false, new[] { 1.0m, 0.0m });
        }

        private static void AssertExceedThreshold(decimal thresholdValue, 
                                           int samplesNeededToExceed,
                                           IEnumerable<decimal> actualReadings, 
                                           bool expectedToExceed, 
                                           IEnumerable<decimal> expectedThresholdGaps)
        {
            var threshold = new MaxThreshold(thresholdValue, samplesNeededToExceed, null);

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
            Assert.IsTrue(new MaxThreshold(10.0m, 1, null).IsWithinPreApprovedLimit());
        }

        [Test]
        public void IsWithinPreApprovedLimitShouldReturnTrueIfValueIsEqualToPreApprovedLimit()
        {
            Assert.IsTrue(new MaxThreshold(10.0m, 1, 10.0m).IsWithinPreApprovedLimit());
        }

        [Test]
        public void IsWithinPreApprovedLimitShouldReturnTrueIfValueIsLessThanPreApprovedLimit()
        {
            Assert.IsTrue(new MaxThreshold(9.0m, 1, 10.0m).IsWithinPreApprovedLimit());
        }

        [Test]
        public void IsWithinPreApprovedLimitShouldReturnFalseIfValueIsGreaterThanPreApprovedLimit()
        {
            Assert.IsFalse(new MaxThreshold(11.0m, 1, 10.0m).IsWithinPreApprovedLimit());
        }
    }
}