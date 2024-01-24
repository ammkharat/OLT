using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [TestFixture]
    public class ThresholdTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionIfNoSamplesNeeded()
        {
            new TestThreshold(500.0m, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionIfNegativeSamplesNeeded()
        {
            new TestThreshold(500.0m, -1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionIfNoReadingsGiven()
        {
            new TestThreshold(500.0m, 1).Evaluate(new List<decimal?>());
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void ShouldThrowExceptionIfNotEnoughReadingsForRequiredNumberOfSamples()
        {
            new TestThreshold(500.0m, 3).Evaluate(new List<decimal?>(new decimal?[2]));
        }

        [Test]
        public void ShouldEvaluateSameNumberOfReadingsAsNumberOfSamplesRequired()
        {
            TestThreshold threshold = new TestThreshold(500.0m, 2);
            ThresholdEvaluation evaluation =
                    threshold.Evaluate(new List<decimal?>(new decimal?[] {1.0m, 2.0m, 3.0m}));
            Assert.AreEqual(new List<decimal>(new[] {2.0m, 3.0m}), evaluation.ThresholdGaps,
                            "Since only 2 samples are required to evaluate the threshold, " +
                            "we should only get the last 2 threshold gaps back.");
        }

        [Test]
        public void ShouldReturnZeromIfActualReadingValueIsNull()
        {
            TestThreshold threshold = new TestThreshold(500.0m, 1);
            ThresholdEvaluation evaluation = threshold.Evaluate(new List<decimal?>(new decimal?[] { null }));
            Assert.AreEqual(new TestThreshold(0.0m, 1).ThresholdValue, evaluation.ThresholdGaps[0]);
        }

        private class TestThreshold : Threshold
        {
            public TestThreshold(decimal thresholdValue, int samplesRequiredToExceedThreshold)
                    : base(thresholdValue, samplesRequiredToExceedThreshold) {}

            protected override decimal CalculateGap(decimal thresholdValue, decimal actualReading)
            {
                // For testing, just make this an identity function (return the reading):
                return actualReading;
            }

            public override bool IsWithinPreApprovedLimit()
            {
                return true;
            }
        }
    }
}