using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [TestFixture]
    public class TargetThresholdsTest
    {
        [Test]
        public void ShouldEvaluateIfExceedThresholds()
        {
            // Assume just 1 sample needed to evaluate each threshold below:

            // Exceeds  Exceeds                              Actual
            // What?    By?      NTE Min  Min  Max  NTE Max  Reading
            // -------  -------  -------  ---  ---  -------  -------
            // Nothing  0        5        10   15   20       10
            // Nothing  0        5        10   15   20       13
            // Nothing  0        5        10   15   20       15
            // Nothing  0        N/A      N/A  15   N/A      14
            // Min      1        5        10   15   20       9
            // Max      1        5        10   15   20       16
            // NTE Min  1        5        10   15   20       4
            // NTE Max  1        5        10   15   20       21
            // Min      2        N/A      10   N/A  N/A      8
            // Max      2        N/A      N/A  15   N/A      17
            // NTE Min  2        5        N/A  N/A  N/A      3
            // NTE Max  2        N/A      N/A  N/A  20       22
            // Min      3        N/A      10   N/A  20       7
            // NTE Max  3        N/A      10   N/A  20       23

            TestEvaluateIfExceedThresholds(TargetThresholdExcessLevel.None, 0, 5, 10, 15, 20, 10);
            TestEvaluateIfExceedThresholds(TargetThresholdExcessLevel.None, 0, 5, 10, 15, 20, 13);
            TestEvaluateIfExceedThresholds(TargetThresholdExcessLevel.None, 0, 5, 10, 15, 20, 15);
            TestEvaluateIfExceedThresholds(TargetThresholdExcessLevel.None, 0, null, null, 15, null, 14);
            TestEvaluateIfExceedThresholds(TargetThresholdExcessLevel.StandardMin, 1, 5, 10, 15, 20, 9);
            TestEvaluateIfExceedThresholds(TargetThresholdExcessLevel.StandardMax, 1, 5, 10, 15, 20, 16);
            TestEvaluateIfExceedThresholds(TargetThresholdExcessLevel.NeverToExceedMin, 1, 5, 10, 15, 20, 4);
            TestEvaluateIfExceedThresholds(TargetThresholdExcessLevel.NeverToExceedMax, 1, 5, 10, 15, 20, 21);

            TestEvaluateIfExceedThresholds(TargetThresholdExcessLevel.StandardMin, 2, null, 10, null, null, 8);
            TestEvaluateIfExceedThresholds(TargetThresholdExcessLevel.StandardMax, 2, null, null, 15, null, 17);
            TestEvaluateIfExceedThresholds(TargetThresholdExcessLevel.NeverToExceedMin, 2, 5, null, null, null, 3);
            TestEvaluateIfExceedThresholds(TargetThresholdExcessLevel.NeverToExceedMax, 2, null, null, null, 20, 22);

            TestEvaluateIfExceedThresholds(TargetThresholdExcessLevel.StandardMin, 3, null, 10, null, 20, 7);
            TestEvaluateIfExceedThresholds(TargetThresholdExcessLevel.NeverToExceedMax, 3, null, 10, null, 20, 23);
        }

        [Test]
        public void EvaluateShouldReturnThresholdValueForNeverToExceedMin()
        {
            MinThreshold nteMinThreshold = MinThreshold.Create(10.0m, 1);
            TargetThresholds threshold = new TargetThresholds(nteMinThreshold, null, null, null);
            Assert.AreEqual(10.0m, threshold.Evaluate(3.0m).ThresholdValue);
        }

        [Test]
        public void EvaluateShouldReturnThresholdValueForNeverToExceedMax()
        {
            MaxThreshold nteMaxThreshold = MaxThreshold.Create(50.0m, 1);
            TargetThresholds threshold = new TargetThresholds(null, null, null, nteMaxThreshold);
            Assert.AreEqual(50.0m, threshold.Evaluate(53.0m).ThresholdValue);
        }

        [Test]
        public void EvaluateShouldReturnThresholdValueForStandardMin()
        {
            MinThreshold minThreshold = MinThreshold.Create(10.0m, 1);
            TargetThresholds threshold = new TargetThresholds(null, minThreshold, null, null);
            Assert.AreEqual(10.0m, threshold.Evaluate(3.0m).ThresholdValue);
        }

        [Test]
        public void EvaluateShouldReturnThresholdValueForStandardMax()
        {
            MaxThreshold maxThreshold = MaxThreshold.Create(50.0m, 1);
            TargetThresholds threshold = new TargetThresholds(null, null, maxThreshold, null);
            Assert.AreEqual(50.0m, threshold.Evaluate(53.0m).ThresholdValue);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionIfConstructThresholdWithAllNullValues()
        {
            new TargetThresholds(null, null, null, null);
        }

        [Test]
        public void ShouldGetSamplesRequiredToEvaluateTargetThresholds()
        {
            TargetThresholds thresholds = new TargetThresholds(null, new MinThreshold(2.0m, 1, null), 
                new MaxThreshold(4.0m, 2, null), new MaxThreshold(6.0m, 3, null));
            Assert.AreEqual(3, thresholds.SamplesRequiredToEvaluate, 
                "Because one of the thresholds requires 3 samples to evaluate whether it exceeds thresholds, " + 
                "overall, we need 3 samples.");
        }

        [Test]
        public void AreWithinPreApprovedLimitsShouldReturnTrueIfAllThresholdsAreWithinPreApprovedLimits()
        {
            Assert.IsTrue(CreateTargetThresholdsWithLimits(10, 20, 30, 40,
                                                           9, 19, 31, 41).AreWithinPreApprovedLimits());
        }

        [Test]
        public void AreWithinPreapprovedLimitsShouldReturnFalseIfNteMinIsNotWithinPreApprovedLimit()
        {
            Assert.IsFalse(CreateTargetThresholdsWithLimits(10, 20, 30, 40,
                                                            11, null, null, null).AreWithinPreApprovedLimits());
        }

        [Test]
        public void AreWithinPreapprovedLimitsShouldReturnFalseIfMinIsNotWithinPreApprovedLimit()
        {
            Assert.IsFalse(CreateTargetThresholdsWithLimits(10, 20, 30, 40,
                                                            null, 21, null, null).AreWithinPreApprovedLimits());
        }
        
        [Test]
        public void AreWithinPreapprovedLimitsShouldReturnFalseIfMaxIsNotWithinPreApprovedLimit()
        {
            Assert.IsFalse(CreateTargetThresholdsWithLimits(10, 20, 30, 40,
                                                            null, null, 29, null).AreWithinPreApprovedLimits());
        }

        [Test]
        public void AreWithinPreapprovedLimitsShouldReturnFalseIfNteMaxIsNotWithinPreApprovedLimit()
        {
            Assert.IsFalse(CreateTargetThresholdsWithLimits(10, 20, 30, 40,
                                                            null, null, null, 39).AreWithinPreApprovedLimits());
        }

        [Test]
        public void AreWithinPreApprovedLimitsShouldEvaluateEvenIfSomeThresholdValuesAreNull()
        {
            Assert.IsTrue(CreateTargetThresholdsWithLimits(null, null, 30, null,
                                                           9, 19, 31, 41).AreWithinPreApprovedLimits());
        }

        private void TestEvaluateIfExceedThresholds(TargetThresholdExcessLevel expectedExcessLevel,
                                                    decimal expectedGapValue,
                                                    decimal? neverToExceedMinimum,
                                                    decimal? minimum,
                                                    decimal? maximum,
                                                    decimal? neverToExceedMaximum,
                                                    decimal actualValue)
        {
            TargetThresholds threshold = new TargetThresholds(MinThreshold.Create(neverToExceedMinimum, 1),
                                                              MinThreshold.Create(minimum, 1),
                                                              MaxThreshold.Create(maximum, 1),
                                                              MaxThreshold.Create(neverToExceedMaximum, 1));
            TargetThresholdEvaluation evaluation = threshold.Evaluate(new List<decimal?>{actualValue});
            Assert.AreEqual(expectedExcessLevel, evaluation.ExcessLevel);
            Assert.AreEqual(expectedGapValue, evaluation.GapValue);
            Assert.AreEqual(actualValue, evaluation.ActualValueUsed);
        }

        private TargetThresholds CreateTargetThresholdsWithLimits(decimal? neverToExceedMinimum,
                                                                  decimal? minimum,
                                                                  decimal? maximum,
                                                                  decimal? neverToExceedMaximum,
                                                                  decimal? neverToExceedMinimumLimit,
                                                                  decimal? minimumLimit,
                                                                  decimal? maximumLimit,
                                                                  decimal? neverToExceedMaximumLimit)
        {
            return new TargetThresholds(MinThreshold.Create(neverToExceedMinimum, 1, neverToExceedMinimumLimit),
                                        MinThreshold.Create(minimum, 1, minimumLimit),
                                        MaxThreshold.Create(maximum, 1, maximumLimit),
                                        MaxThreshold.Create(neverToExceedMaximum, 1, neverToExceedMaximumLimit));
        }
    }
}
