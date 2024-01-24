using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [TestFixture]
    public class TargetDefinitionStatusTest
    {
        [Test]
        public void ShouldNotBeAbleToAddNewTargetStatusToAll()
        {
            Assert.IsTrue(TargetDefinitionStatus.All.IsFixedSize);

        }

        [Test]
        public void ShouldBeAppovedWhenStatusIsActive()
        {
            TargetDefinitionStatus targetStatus = TargetDefinitionStatus.Approved;
            Assert.IsTrue(targetStatus.IsApproved);
        }

        [Test]
        public void ShouldNotBeAppovedWhenStatusIsPending()
        {
            TargetDefinitionStatus targetStatus = TargetDefinitionStatus.Pending;
            Assert.IsFalse(targetStatus.IsApproved);
        }

        [Test]
        public void ShouldGetApprovedWhenRequiresApprovalIsFalse()
        {
            TargetDefinitionStatus expected = TargetDefinitionStatus.Approved;
            TargetDefinitionStatus actual = TargetDefinitionStatus.GetStatusBasedOnRequiresApproval(false);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldGetPendingWhenRequiresApprovalIsTrue()
        {
            TargetDefinitionStatus expected = TargetDefinitionStatus.Pending;
            TargetDefinitionStatus actual = TargetDefinitionStatus.GetStatusBasedOnRequiresApproval(true);
            Assert.AreEqual(expected, actual);
        }
    }
}
