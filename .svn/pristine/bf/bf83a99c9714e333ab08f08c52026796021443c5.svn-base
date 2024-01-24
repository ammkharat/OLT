using Com.Suncor.Olt.Client.Fixtures;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Security
{
    [TestFixture]
    public class ActionItemDefinitionAuthorizationTest
    {
        private ActionItemDefinitionDTO actionItemDefinition;
        private ActionItemDefinitionDTO pendingProcessCategoryActionItem;
        private ActionItemDefinitionDTO approvedProcessCategoryActionItem;


        private IAuthorized authorized;

        [SetUp]
        public void Setup()
        {
            authorized = new Authorized();

            actionItemDefinition =
                new ActionItemDefinitionDTO(
                    ActionItemDefinitionFixture.CreateProcessCategoryActionItemDefinitionFortMcMurrayWithNoID());
            pendingProcessCategoryActionItem =
                new ActionItemDefinitionDTO(
                    ActionItemDefinitionFixture.CreatePendingProcessActionItemDefinitionForMcMurrayWithActionItemId(1));
            approvedProcessCategoryActionItem =
                new ActionItemDefinitionDTO(
                    ActionItemDefinitionFixture.CreateApprovedProcessActionItemDefinitionForMcMurrayWithActionItemId(1));
        }


        // Delete Action Item Definition tests ****************

        [Test]
        public void SupervisorsCanDeleteActionItemDefinitions()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForSupervisor();
            Assert.IsTrue(authorized.ToDeleteActionItemDefinitions(userRoleElements, actionItemDefinition));
        }

        [Test]
        public void EngineeringSupportCanDeleteActionItemDefinitions()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForEngineeringSupport();
            Assert.IsTrue(authorized.ToDeleteActionItemDefinitions(userRoleElements, actionItemDefinition));
        }

        #region Edit Action Item Definitions

        [Test]
        public void SupervisorsCanEditActionItemDefinitions()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForSupervisor();
            Assert.IsTrue(authorized.ToEditActionItemDefinition(userRoleElements, actionItemDefinition));

            Assert.IsTrue(authorized.ToEditActionItemDefinition(userRoleElements, pendingProcessCategoryActionItem));

            Assert.IsTrue(authorized.ToEditActionItemDefinition(userRoleElements, approvedProcessCategoryActionItem));
        }

        [Test]
        public void OperatorCanNotEditActionItemDefinitions()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForOperator();
            Assert.IsFalse(authorized.ToEditActionItemDefinition(userRoleElements, actionItemDefinition));
            Assert.IsFalse(authorized.ToEditActionItemDefinition(userRoleElements, pendingProcessCategoryActionItem));
            Assert.IsFalse(authorized.ToEditActionItemDefinition(userRoleElements, approvedProcessCategoryActionItem));
        }

        [Test]
        public void EngineeringSupportCanEditActionItemDefinitions()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForEngineeringSupport();
            Assert.IsTrue(authorized.ToEditActionItemDefinition(userRoleElements, actionItemDefinition));
            Assert.IsTrue(
                authorized.ToEditActionItemDefinition(userRoleElements, pendingProcessCategoryActionItem));
            Assert.IsTrue(
                authorized.ToEditActionItemDefinition(userRoleElements, approvedProcessCategoryActionItem));
        }

        #endregion

        //Approve Tests
        [Test]
        public void SupervisorsCanApprovePendingActionItems()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForSupervisor();
            Assert.IsTrue(authorized.ToApproveActionItemDefinitions(userRoleElements, pendingProcessCategoryActionItem));
        }

        [Test]
        public void SupervisorsCannotApproveActiveActionItems()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForSupervisor();
            Assert.IsFalse(
                authorized.ToApproveActionItemDefinitions(userRoleElements, approvedProcessCategoryActionItem));
        }

        [Test]
        public void SupervisorsCannotApproveNullActionItems()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForSupervisor();
            Assert.IsFalse(authorized.ToApproveActionItemDefinitions(userRoleElements, null as ActionItemDefinitionDTO));
        }

        [Test]
        public void NonSupervisorsCannotApproveActionItems()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForEngineeringSupport();
            Assert.IsFalse(
                authorized.ToApproveActionItemDefinitions(userRoleElements, pendingProcessCategoryActionItem));
        }


        //Reject Tests
        [Test]
        public void SupervisorsCanRejectPendingActionItems()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForSupervisor();
            Assert.IsTrue(authorized.ToRejectActionItemDefinitions(userRoleElements, pendingProcessCategoryActionItem));
        }

        [Test]
        public void SupervisorsCannotRejectActiveActionItems()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForSupervisor();
            Assert.IsFalse(authorized.ToRejectActionItemDefinitions(userRoleElements, approvedProcessCategoryActionItem));
        }

        [Test]
        public void SupervisorsCannotRejectNullActionItems()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForSupervisor();
            Assert.IsFalse(authorized.ToRejectActionItemDefinitions(userRoleElements, null as ActionItemDefinitionDTO));
        }

        [Test]
        public void NonSupervisorsCannotRejectActionItems()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForEngineeringSupport();
            Assert.IsFalse(
                authorized.ToRejectActionItemDefinitions(userRoleElements, pendingProcessCategoryActionItem));

            userRoleElements = UserRoleElementsFixture.CreateRoleElementsForOperator();
            Assert.IsFalse(authorized.ToRejectActionItemDefinitions(userRoleElements, pendingProcessCategoryActionItem));
        }

        #region Comment Permissions

        [Test]
        public void SupervisorAndOperatorAndEngineeringSupportCanCommentAllActionItemDefinition()
        {
            ActionItemDefinitionDTO dto;

            BusinessCategory category = BusinessCategoryFixture.GetProductionCategory();

            dto = ActionItemDefinitionDTOFixture.CreateActionItemDefinitionDTO(category);

            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForSupervisor();
            Assert.IsTrue(authorized.ToCommentActionItemDefinition(userRoleElements, dto));
            userRoleElements = UserRoleElementsFixture.CreateRoleElementsForOperator();
            Assert.IsTrue(authorized.ToCommentActionItemDefinition(userRoleElements, dto));
            userRoleElements = UserRoleElementsFixture.CreateRoleElementsForEngineeringSupport();
            Assert.IsTrue(authorized.ToCommentActionItemDefinition(userRoleElements, dto));            
        }

        [Test]
        public void PermitScreenerCanNOTCommentAnyActionItemDefinition()
        {
            ActionItemDefinitionDTO dto;

            BusinessCategory category = BusinessCategoryFixture.GetEnvironmentalSafetyCategory();

            dto = ActionItemDefinitionDTOFixture.CreateActionItemDefinitionDTO(category);
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForPermitScreener();
            Assert.IsFalse(authorized.ToCommentActionItemDefinition(userRoleElements, dto));            
        }

        #endregion
    }
}