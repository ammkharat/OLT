using Com.Suncor.Olt.Client.Fixtures;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.DTO;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Security
{
    [TestFixture]
    public class ActionItemAuthorizationTest
    {
        private ActionItem actionItem;

        private IAuthorized authorized;

        [SetUp]
        public void Setup()
        {

            authorized = new Authorized();

            actionItem = ActionItemFixture.CreateACompleteActionItemWithFlocListAndNoId();
            
        }

        [Test]
        public void OperatorsCanViewActionItems()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForOperator();
            Assert.IsTrue(authorized.ToViewActionItems(userRoleElements));            
        }

        [Test]
        public void SupervisorsCanViewActionItems()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForSupervisor();
            Assert.IsTrue(authorized.ToViewActionItems(userRoleElements));
        }

        [Test]
        public void EngineeringSupportCanViewActionItems()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForEngineeringSupport();
            Assert.IsTrue(authorized.ToViewActionItems(userRoleElements));
        }

        [Test]
        public void PermitScreenersCanNotViewActionItems()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForPermitScreener();
            Assert.IsFalse(authorized.ToViewActionItems(userRoleElements));
        }

        [Test][Ignore]
        public void SupervisorsAndOperatorsCanRespondToActionItems()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForOperator();
            Assert.IsTrue(authorized.ToRespondActionItem(userRoleElements, new ActionItemDTO(actionItem)));
            userRoleElements = UserRoleElementsFixture.CreateRoleElementsForSupervisor();
            Assert.IsTrue(authorized.ToRespondActionItem(userRoleElements, new ActionItemDTO(actionItem)));
        }

        [Test][Ignore]
        public void EngineeringSupportCanNotRespondToActionItems()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForEngineeringSupport();
            Assert.IsFalse(authorized.ToRespondActionItem(userRoleElements, new ActionItemDTO(actionItem)));
        }

        [Test][Ignore]
        public void PermitScreenerCanNotRespondToActionItems()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForPermitScreener();
            Assert.IsFalse(authorized.ToRespondActionItem(userRoleElements, new ActionItemDTO(actionItem)));
        }

    }
}
