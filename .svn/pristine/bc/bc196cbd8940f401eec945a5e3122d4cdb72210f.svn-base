using System;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class ApprovalShouldBeEnabledBehaviourTest
    {

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void TenDaysBehaviour()
        {
            Clock.Now = new DateTime(2012, 10, 12, 13, 0, 0);

            ApprovalShouldBeEnabledBehaviour behaviour = ApprovalShouldBeEnabledBehaviour.TenDayValidity;

            FormOP14 form = FormOP14Fixture.CreateFormWithExistingId();

            // valid from and valid to are over ten days apart
            {
                form.FromDateTime = new DateTime(2012, 10, 13, 11, 0, 0);
                form.ToDateTime = new DateTime(2012, 10, 23, 11, 0, 1);

                Assert.IsTrue(behaviour.ShouldBeEnabled(form, Clock.Now));
            }

            // valid from and valid to are not over ten days apart
            {
                form.FromDateTime = new DateTime(2012, 10, 13, 11, 0, 0);
                form.ToDateTime = new DateTime(2012, 10, 23, 10, 59, 0);

                Assert.IsFalse(behaviour.ShouldBeEnabled(form, Clock.Now));
            }

            // the current datetime is more than 10 days past the valid from datetime
            {
                form.FromDateTime = new DateTime(2012, 10, 1, 11, 0, 0);
                form.ToDateTime = new DateTime(2012, 10, 5, 11, 0, 0);

                Assert.IsTrue(behaviour.ShouldBeEnabled(form, Clock.Now));
            }

            // the current datetime is less than 10 days past the valid from datetime
            {
                form.FromDateTime = new DateTime(2012, 10, 2, 13, 0, 1);
                form.ToDateTime = new DateTime(2012, 10, 5, 11, 0, 0);

                Assert.IsFalse(behaviour.ShouldBeEnabled(form, Clock.Now));
            }

        }
    }
}
