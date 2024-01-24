using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class ActionItemDefinitionStatusTest
    {
        
        [Test]
        public void TheValueOfPendingStatusShouldBeZero()
        {
            Assert.IsTrue(0 == ActionItemDefinitionStatus.Pending.Value);
        }

        [Test]
        public void ToStringofPendingStatusShouldBePending()
        {
            Assert.AreEqual("Pending", ActionItemDefinitionStatus.Pending.ToString());
        }


        [Test]
        public void ShouldGetPendingStatusByUsingIdZero()
        {
            Assert.AreEqual(ActionItemDefinitionStatus.Pending, ActionItemDefinitionStatus.GetById(0));
        }

        [Test]
        public void ShouldNotBeAbleToAddNewactionItemDefinitionStatusToAll()
        {
            Assert.IsTrue(ActionItemDefinitionStatus.All.IsFixedSize);

        }


        [Test]
        public void ShouldBeAppovedWhenStatusIsActive()
        {
            ActionItemDefinitionStatus actionItemDefinitionStatus = ActionItemDefinitionStatus.Approved;
            Assert.IsTrue(actionItemDefinitionStatus.IsApproved);
        }

        [Test]
        public void ShouldNotBeAppovedWhenStatusIsPending()
        {
            ActionItemDefinitionStatus actionItemDefinitionStatus = ActionItemDefinitionStatus.Pending;
            Assert.IsFalse(actionItemDefinitionStatus.IsApproved);
        }


        [Test]
        public void ShouldGetPendingStatusWhenActionitemRequiresApproval()
        {
            Assert.AreEqual(ActionItemDefinitionStatus.Pending,ActionItemDefinitionStatus.GetStatusBasedOnRequiresApproval(true));
        }

       
        [Test]
        public void ShouldGetApprovedStatusWhenActionitemDoesNotRequireApproval()
        {
            Assert.AreEqual(ActionItemDefinitionStatus.Approved, ActionItemDefinitionStatus.GetStatusBasedOnRequiresApproval(false));
        }
  
    }
}
