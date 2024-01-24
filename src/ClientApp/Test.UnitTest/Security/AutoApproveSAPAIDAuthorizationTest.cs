using Com.Suncor.Olt.Client.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Security
{
    [TestFixture]
    public class AutoApproveSAPAIDAuthorizationTest
    {
        IAuthorized authorized;

        [SetUp]
        public void SetUp()
        {
            authorized = new Authorized();
        }

        [Test]
        public void ShouldAllowAdminAndSupervisorToConfigureAutoApproveSAPAID()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForAdmin();
            Assert.IsTrue(authorized.ToConfigureAutoApproveSAPActionItemDefinition(userRoleElements));
            userRoleElements = UserRoleElementsFixture.CreateRoleElementsForSupervisor();
            Assert.IsTrue(authorized.ToConfigureAutoApproveSAPActionItemDefinition(userRoleElements));
        }

        [Test]
        public void ShouldNotAllowNonAdminNonSuperVisorToConfigureAutoApproveSAPAID()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForOperator();
            Assert.IsFalse(authorized.ToConfigureAutoApproveSAPActionItemDefinition(userRoleElements));
            userRoleElements = UserRoleElementsFixture.CreateRoleElementsForEngineeringSupport();
            Assert.IsFalse(authorized.ToConfigureAutoApproveSAPActionItemDefinition(userRoleElements));
            userRoleElements = UserRoleElementsFixture.CreateRoleElementsForPermitScreener();
            Assert.IsFalse(authorized.ToConfigureAutoApproveSAPActionItemDefinition(userRoleElements));
        }
    }
}
