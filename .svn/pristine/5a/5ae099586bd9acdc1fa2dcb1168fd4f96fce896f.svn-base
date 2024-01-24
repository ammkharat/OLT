using System;
using Com.Suncor.Olt.Client.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Security
{
    [TestFixture]
    public class GasTestElementInfoAuthorizationTest
    {
        private IAuthorized authorized;

        [SetUp]
        public void SetUp()
        {
            authorized = new Authorized();
            Clock.Freeze();
            Clock.Now = new DateTime(Clock.DateNow.Year, Clock.DateNow.Month, Clock.DateNow.Day, 11, 0, 0);

            authorized = new Authorized();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void OnlyAdminCanConfigureGasTestLimits()
        {
            Assert.IsTrue(authorized.ToConfigureGasTestElementLimits(UserRoleElementsFixture.CreateRoleElementsForAdmin()));

            Assert.IsFalse(authorized.ToConfigureGasTestElementLimits(UserRoleElementsFixture.CreateRoleElementsForOperator()));
            Assert.IsFalse(authorized.ToConfigureGasTestElementLimits(UserRoleElementsFixture.CreateRoleElementsForSupervisor()));
            Assert.IsFalse(authorized.ToConfigureGasTestElementLimits(UserRoleElementsFixture.CreateRoleElementsForEngineeringSupport()));
            Assert.IsFalse(authorized.ToConfigureGasTestElementLimits(UserRoleElementsFixture.CreateRoleElementsForPermitScreener()));
        }
    }
}
