using System.Collections.Generic;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    [TestFixture]
    public class AllTrueValidationTest
    {
        [Test]
        public void ShouldReturnTrueIfAllRulesEvaluateToTrue()
        {
            var rules = new List<IRule<int>>
                            {
                                new Rule<int>(i => i == 5),
                                new Rule<int>(i => i > 4)
                            };
            var validator = new AllTrueValidator<int>(null, rules.ToArray());
            Assert.IsTrue(validator.Evaluate(5));
        }

        [Test]
        public void ShouldReturnFalseIfAtLeastOneRuleEvaluateToFalse()
        {
            var rules = new List<IRule<int>>
                            {
                                new Rule<int>(i => i == 5),
                                new Rule<int>(i => i < 10),
                                new Rule<int>(i => i < 5)
                            };
            var validator = new AllTrueValidator<int>(null, rules.ToArray());
            Assert.IsFalse(validator.Evaluate(5));
        }

    }
}