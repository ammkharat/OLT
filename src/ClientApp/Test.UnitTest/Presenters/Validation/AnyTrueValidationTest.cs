using System.Collections.Generic;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    [TestFixture]
    public class AnyTrueValidationTest
    {
        [Test]
        public void ShouldReturnTrueIfAnyRulePasses()
        {
            var rules = new List<IRule<int>>
                                         {
                                            new Rule<int>(i => i == 5),
                                            new Rule<int>(i => i < 5)
                                         };
            var validator = new AnyTrueValidator<int>(null, rules.ToArray());
            Assert.IsTrue(validator.Evaluate(5));
        }

        [Test]
        public void ShouldReturnFalseIfNoRulesEvaluateToTrue()
        {
            var rules = new List<IRule<int>>
                                         {
                                            new Rule<int>(i => i == 4),
                                            new Rule<int>(i => i > 10),
                                            new Rule<int>(i => i < 5)
                                         };
            var validator = new AnyTrueValidator<int>(null, rules.ToArray());
            Assert.IsFalse(validator.Evaluate(5));
        }
    }
}
