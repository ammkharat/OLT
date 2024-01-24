using System.Collections.Generic;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [TestFixture]
    public class ThresholdEvaluationTest
    {
        [Test]
        public void ShouldEvaluateExceededThresholdToTrueIfAllGapsArePositive()
        {
            List<decimal> gaps = new List<decimal>(new[] { 0.0m, 0.0m });
            Assert.IsFalse(new ThresholdEvaluation(gaps).ExceededThreshold);

            gaps = new List<decimal>(new[] { 0.0m, 10.0m });
            Assert.IsFalse(new ThresholdEvaluation(gaps).ExceededThreshold);

            gaps = new List<decimal>(new[] { 0.1m, 10.0m });
            Assert.IsTrue(new ThresholdEvaluation(gaps).ExceededThreshold);
        }
    }
}
