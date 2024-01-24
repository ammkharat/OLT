using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [TestFixture]
    public class TargetThresholdEvaluationTest
    {
        [Test]
        public void ShouldCalculateLosses()
        {
            TargetThresholdEvaluation thresholdEvaluation =
                new TargetThresholdEvaluation(TargetThresholdExcessLevel.StandardMax, 48.9m, 50.0m, 1.1m);

            decimal gapUnitValue = 5.0m;
            Assert.AreEqual(5.5m, thresholdEvaluation.CalculateLosses(gapUnitValue));
        }

        [Test]
        public void NeverToExceedLimitExceededShouldReturnTrueIfNteMaxExceeded()
        {
            TargetThresholdEvaluation evaluation = 
                new TargetThresholdEvaluation(TargetThresholdExcessLevel.NeverToExceedMax, 48.9m, 50.0m, 1.0m);
            Assert.IsTrue(evaluation.NeverToExceedLimitExceeded);
        }

        [Test]
        public void NeverToExceedLimitExceededShouldReturnTrueIfNteMinExceeded()
        {
            TargetThresholdEvaluation evaluation =
                new TargetThresholdEvaluation(TargetThresholdExcessLevel.NeverToExceedMin, 48.9m, 50.0m, 1.0m);
            Assert.IsTrue(evaluation.NeverToExceedLimitExceeded);
        }

        [Test]
        public void NeverToExceedLimitExceededShouldReturnFalseIfNteMinOrMaxNotExceeded()
        {
            TargetThresholdEvaluation evaluation = new TargetThresholdEvaluation(50.0m);
            Assert.IsFalse(evaluation.NeverToExceedLimitExceeded);
        }

        [Test]
        public void AnyLimitExceededShouldReturnTrueIfStandardMaxExceeded()
        {
            TargetThresholdEvaluation evaluation =
                new TargetThresholdEvaluation(TargetThresholdExcessLevel.StandardMax, 49.0m, 50.0m, 1.0m);
            Assert.IsTrue(evaluation.AnyLimitExceeded);
        }

        [Test]
        public void AnyLimitExceededShouldReturnFalseIfNoLimitExceeded()
        {
            TargetThresholdEvaluation evaluation = new TargetThresholdEvaluation(50.0m);
            Assert.IsFalse(evaluation.AnyLimitExceeded);
        }
    }
}
