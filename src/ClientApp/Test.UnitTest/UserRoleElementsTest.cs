using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Fixtures;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client
{
    [TestFixture]
    public class UserRoleElementsTest
    {
        private RoleElement roleElement;

        [SetUp]
        public void SetUp()
        {
            roleElement = RoleElementFixture.CreateApproveActionRole();
        }

        [Test]
        public void shouldReturnTrueIfUserHasGivenRole()
        {
            RoleElement approveActionRole = RoleElementFixture.CreateApproveActionRole();
            UserRoleElements userRoleElements = new UserRoleElements(RoleFixture.CreateOperatorRole(), new List<RoleElement> {approveActionRole});

            Assert.IsTrue(userRoleElements.AuthorizedTo(RoleElementFixture.CreateApproveActionRole()));
        }

        [Test]
        public void shouldReturnFalseIfUserDoesNotHaveGivenRole()
        {
            Assert.IsFalse(new UserRoleElements(RoleFixture.CreateOperatorRole(), new List<RoleElement>()).AuthorizedTo(roleElement));
        }

        [Test]
        public void ShouldReturnFalseIfPositionDoesNotHaveRole()
        {
            UserRoleElements userRoleElements = new UserRoleElements(RoleFixture.CreateOperatorRole(), new List<RoleElement>());
            Assert.IsFalse(userRoleElements.HasRoleElement(roleElement));
        }

        #region Who can do what with Work Permit
        [Test]
        public void OperatorHasCloneWorkPermitWithNoRestrictionButNotCloneWithSomeRestriction()
        {
            UserRoleElements roleElementsForOperator = UserRoleElementsFixture.CreateRoleElementsForOperator();
            Assert.IsTrue(roleElementsForOperator.HasRoleElement(RoleElement.CLONE_PERMIT_WITH_NO_RESTRICTION));
            Assert.IsFalse(roleElementsForOperator.HasRoleElement(RoleElement.CLONE_PERMIT_WITH_SOME_RESTRICTIONS));
        }

        [Test]
        public void SupervisorHasCloneWorkPermitWithNoRestrictionButNotCloneWithSomeRestriction()
        {
            UserRoleElements roleElementsForSupervisor = UserRoleElementsFixture.CreateRoleElementsForSupervisor();
            Assert.IsTrue(roleElementsForSupervisor.HasRoleElement(RoleElement.CLONE_PERMIT_WITH_NO_RESTRICTION));
            Assert.IsFalse(roleElementsForSupervisor.HasRoleElement(RoleElement.CLONE_PERMIT_WITH_SOME_RESTRICTIONS));
        }

        [Test]
        public void PermitScreenerHasCloneWorkPermitWithSomeRestrictionsRoleButNotCloneWithNoRestriction()
        {
            UserRoleElements roleElementsForPermitScreener = UserRoleElementsFixture.CreateRoleElementsForPermitScreener();

            Assert.IsTrue(roleElementsForPermitScreener.HasRoleElement(RoleElement.CLONE_PERMIT_WITH_SOME_RESTRICTIONS));
            Assert.IsFalse(roleElementsForPermitScreener.HasRoleElement(RoleElement.CLONE_PERMIT_WITH_NO_RESTRICTION));
        }

        #endregion

        #region Tests for Valid roles that do not violate each other.

        [Test]
        [ExpectedException(typeof (ApplicationException))]
        public void ThrowExceptionOnAddingClonePermitWithSomeRestrictionIfWithNoRestrictionExists()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateEmpty();
            userRoleElements.AddRoleElement(RoleElement.UPDATE_PERMIT_NO_RESTRICTIONS);
            userRoleElements.AddRoleElement(RoleElement.UPDATE_PERMIT_WITH_RESTRICTED_PERMIT_UPDATING);
        }

        [Test]
        [ExpectedException(typeof (ApplicationException))]
        public void ThrowExceptionOnAddingClonePermitWithNoRestrictionIfWithSomeRestrictionsExists()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateEmpty();
            userRoleElements.AddRoleElement(RoleElement.UPDATE_PERMIT_WITH_RESTRICTED_PERMIT_UPDATING);
            userRoleElements.AddRoleElement(RoleElement.UPDATE_PERMIT_NO_RESTRICTIONS);
        }

        [Test]
        [ExpectedException(typeof (ApplicationException))]
        public void CloneWorkPermitRoleMustBeAddedBeforeAddingCloneAllWorkSectionsRole()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateEmpty();
            userRoleElements.AddRoleElement(RoleElement.CLONE_PERMIT_WITH_NO_RESTRICTION);
            userRoleElements.AddRoleElement(RoleElement.CLONE_PERMIT_WITH_SOME_RESTRICTIONS);
        }

        #endregion        

    }
}