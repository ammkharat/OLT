using Com.Suncor.Olt.Client.Fixtures;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Security
{
    [TestFixture]
    public class TargetDefinitionAuthorizationTest
    {
        private UserRoleElements operatorMickey;
        private UserRoleElements supervisorDonald;
        private UserRoleElements engineeringSupportGoofy;

        private TargetDefinition processCategoryTarget;
        private TargetDefinition productControlCategoryTarget;
        private TargetDefinition pendingTarget;
        private TargetDefinition activeapprovedTarget;

        private IAuthorized authorized;

        [SetUp]
        public void SetUp()
        {
            authorized = new Authorized();

            operatorMickey = UserRoleElementsFixture.CreateRoleElementsForOperatingEngineer();
            supervisorDonald = UserRoleElementsFixture.CreateRoleElementsForSupervisor();
            engineeringSupportGoofy = UserRoleElementsFixture.CreateRoleElementsForEngineeringSupport();

            processCategoryTarget = TargetDefinitionFixture.CreateProcessCategoryTarget();
            productControlCategoryTarget = TargetDefinitionFixture.CreateProductControlCategoryTarget();
            pendingTarget = TargetDefinitionFixture.CreateATargetWithRecurringDailyScheduleAndPendingTargetFixture();
            activeapprovedTarget =
                TargetDefinitionFixture.CreateATargetWithRecurringDailyScheduleAndActiveTargetFixture();
        }

        // Delete Target tests

        [Test]
        public void SupervisorsCanDeleteProcessCategoryTargets()
        {
            Assert.IsTrue(
                authorized.ToDeleteTargetDefinition(supervisorDonald, new TargetDefinitionDTO(processCategoryTarget)));
        }

        [Test]
        public void SupervisorsCanDeleteProductControlCategoryTargets()
        {
            Assert.IsTrue(
                authorized.ToDeleteTargetDefinition(supervisorDonald,
                                                    new TargetDefinitionDTO(productControlCategoryTarget)));
        }

        [Test]
        public void OperatorsCanNotDeleteProcessCategoryTargets()
        {
            Assert.IsFalse(
                authorized.ToDeleteTargetDefinition(operatorMickey, new TargetDefinitionDTO(processCategoryTarget)));
        }

        [Test]
        public void OperatorsCanNotDeleteProductControlCategoryTargets()
        {
            Assert.IsFalse(
                authorized.ToDeleteTargetDefinition(operatorMickey,
                                                    new TargetDefinitionDTO(productControlCategoryTarget)));
        }

        [Test]
        public void EngineeringSupportUsersCanDeleteTargets()
        {
            Assert.IsTrue(
                authorized.ToDeleteTargetDefinition(engineeringSupportGoofy,
                                                    new TargetDefinitionDTO(processCategoryTarget)));
        }

        [Test]
        public void SupervisorsCanApprovePendingTargets()
        {
            Assert.IsTrue(authorized.ToApproveTargetDefinition(supervisorDonald, new TargetDefinitionDTO(pendingTarget)));
        }

        [Test]
        public void SupervisorsCannotApproveActiveTargets()
        {
            Assert.IsFalse(
                authorized.ToApproveTargetDefinition(supervisorDonald, new TargetDefinitionDTO(activeapprovedTarget)));
        }

        [Test]
        public void SupervisorsCannotApproveNullTargets()
        {
            Assert.IsFalse(authorized.ToApproveTargetDefinition(supervisorDonald, null));
        }

        [Test]
        public void NonSupervisorsCannotApproveTargets()
        {
            Assert.IsFalse(
                authorized.ToApproveTargetDefinition(engineeringSupportGoofy, new TargetDefinitionDTO(pendingTarget)));
            Assert.IsFalse(authorized.ToApproveTargetDefinition(operatorMickey, new TargetDefinitionDTO(pendingTarget)));
        }

        [Test]
        public void SupervisorsCanRejectPendingTargets()
        {
            Assert.IsTrue(authorized.ToRejectTargetDefinition(supervisorDonald, new TargetDefinitionDTO(pendingTarget)));
        }

        [Test]
        public void SupervisorsCannotRejectActiveTargets()
        {
            Assert.IsFalse(
                authorized.ToRejectTargetDefinition(supervisorDonald, new TargetDefinitionDTO(activeapprovedTarget)));
        }

        [Test]
        public void SupervisorsCannotRejectNullTargets()
        {
            Assert.IsFalse(authorized.ToRejectTargetDefinition(supervisorDonald, null));
        }

        [Test]
        public void NonSupervisorsCannotRejectTargets()
        {
            Assert.IsFalse(
                authorized.ToRejectTargetDefinition(engineeringSupportGoofy, new TargetDefinitionDTO(pendingTarget)));
            Assert.IsFalse(authorized.ToRejectTargetDefinition(operatorMickey, new TargetDefinitionDTO(pendingTarget)));
        }

        [Test]
        public void ToConfigurePreApprovedTargetRangesShouldReturnTrueForUserWithThatRoleElement()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateEmpty();
            userRoleElements.AddRoleElement(RoleElement.CONFIGURE_PREAPPROVED_TARGET_RANGES);
            Assert.IsTrue(authorized.ToConfigurePreApprovedTargetRanges(userRoleElements));
        }

        [Test]
        public void ToConfigurePreApprovedTargetRangesShouldReturnFalseForUserWithoutThatRoleElement()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateEmpty();
            Assert.IsFalse(authorized.ToConfigurePreApprovedTargetRanges(userRoleElements));
        }
    }
}