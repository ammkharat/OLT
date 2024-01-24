using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;
using UserFixture = Com.Suncor.Olt.Client.Fixtures.UserFixture;

namespace Com.Suncor.Olt.Client.Security
{
    [TestFixture]
    public class ReadOnlyRoleCheckerTest
    {
        [Test]
        public void ShouldNotConvertToReadOnlyIfRoleIsNull()
        {
            Assert.IsFalse(ReadOnlyRoleChecker.ShouldBeConvertedToReadOnlyRole(
                UserFixture.CreateUserWithPlant(1, ClientSession.GetUserContext()), null, null, new List<FunctionalLocation>()));
        }

        [Test]
        public void ShouldNotConvertToReadOnlyIfRoleIsReadOnly()
        {
            Assert.IsFalse(ReadOnlyRoleChecker.ShouldBeConvertedToReadOnlyRole(
                UserFixture.CreateUserWithPlant(1, ClientSession.GetUserContext()), RoleFixture.CreateReadOnlyRole(), null, new List<FunctionalLocation>()));            
        }

        [Test]
        public void ShouldNotConvertToReadOnlyIfRoleIsAdministrator()
        {
            Assert.IsFalse(ReadOnlyRoleChecker.ShouldBeConvertedToReadOnlyRole(
                UserFixture.CreateUserWithPlant(1, ClientSession.GetUserContext()), RoleFixture.CreateAdministratorRole(), null, new List<FunctionalLocation>()));            
        }

        [Test]
        public void ShouldNotConvertToReadOnlyIfRoleIsRestrictionReportingAdmin()
        {
            Assert.IsFalse(ReadOnlyRoleChecker.ShouldBeConvertedToReadOnlyRole(
                UserFixture.CreateUserWithPlant(1, ClientSession.GetUserContext()), RoleFixture.CreateRestrictionReportingAdminRole(), null, new List<FunctionalLocation>()));            
        }

        [Test]
        public void ShouldCheckConvertToReadOnlyIfWorkAssignmentIsNotNull()
        {
            const long plantId = 12345;
            const int notPlantId = 123;
            const long otherPlantId = 56789;

            {
                WorkAssignment workAssignment = WorkAssignmentFixture.CreateConsoleOperator();
                workAssignment.FunctionalLocations.Clear();

                List<FunctionalLocation> flocs = new List<FunctionalLocation>();

                Assert.IsFalse(ReadOnlyRoleChecker.ShouldBeConvertedToReadOnlyRole(
                    UserFixture.CreateUserWithPlant(plantId, ClientSession.GetUserContext()), RoleFixture.CreateOperatorRole(), workAssignment, flocs));
            }
            {
                WorkAssignment workAssignment = WorkAssignmentFixture.CreateConsoleOperator();
                workAssignment.FunctionalLocations.Clear();

                List<FunctionalLocation> flocs = new List<FunctionalLocation>();
                flocs.Add(FunctionalLocationFixture.CreateNewWithPlantId(1, plantId));

                Assert.IsFalse(ReadOnlyRoleChecker.ShouldBeConvertedToReadOnlyRole(
                    UserFixture.CreateUserWithPlant(plantId, ClientSession.GetUserContext()), RoleFixture.CreateOperatorRole(), workAssignment, flocs));
            }
            {
                WorkAssignment workAssignment = WorkAssignmentFixture.CreateConsoleOperator();
                workAssignment.FunctionalLocations.Clear();
                workAssignment.FunctionalLocations.Add(FunctionalLocationFixture.CreateNewWithPlantId(1, plantId));

                List<FunctionalLocation> flocs = new List<FunctionalLocation>();
                flocs.Add(FunctionalLocationFixture.CreateNewWithPlantId(1, plantId));

                Assert.IsFalse(ReadOnlyRoleChecker.ShouldBeConvertedToReadOnlyRole(
                    UserFixture.CreateUserWithPlant(plantId, ClientSession.GetUserContext()), RoleFixture.CreateOperatorRole(), workAssignment, flocs));
            }
            {
                WorkAssignment workAssignment = WorkAssignmentFixture.CreateConsoleOperator();
                workAssignment.FunctionalLocations.Clear();
                workAssignment.FunctionalLocations.Add(FunctionalLocationFixture.CreateNewWithPlantId(1, plantId, "A-B"));

                List<FunctionalLocation> flocs = new List<FunctionalLocation>();
                flocs.Add(FunctionalLocationFixture.CreateNewWithPlantId(2, plantId, "A-B-C"));

                Assert.IsFalse(ReadOnlyRoleChecker.ShouldBeConvertedToReadOnlyRole(
                    UserFixture.CreateUserWithPlant(plantId, ClientSession.GetUserContext()), RoleFixture.CreateOperatorRole(), workAssignment, flocs));
            }
            {
                WorkAssignment workAssignment = WorkAssignmentFixture.CreateConsoleOperator();
                workAssignment.FunctionalLocations.Clear();
                workAssignment.FunctionalLocations.Add(FunctionalLocationFixture.CreateNewWithPlantId(1, plantId, "A-B-C"));

                List<FunctionalLocation> flocs = new List<FunctionalLocation>();
                flocs.Add(FunctionalLocationFixture.CreateNewWithPlantId(2, plantId, "A-B"));

                Assert.IsFalse(ReadOnlyRoleChecker.ShouldBeConvertedToReadOnlyRole(
                    UserFixture.CreateUserWithPlant(plantId, ClientSession.GetUserContext()), RoleFixture.CreateOperatorRole(), workAssignment, flocs));
            }
            {
                WorkAssignment workAssignment = WorkAssignmentFixture.CreateConsoleOperator();
                workAssignment.FunctionalLocations.Clear();
                workAssignment.FunctionalLocations.Add(FunctionalLocationFixture.CreateNewWithPlantId(1, notPlantId));

                List<FunctionalLocation> flocs = new List<FunctionalLocation>();
                flocs.Add(FunctionalLocationFixture.CreateNewWithPlantId(1, notPlantId));

                Assert.IsTrue(ReadOnlyRoleChecker.ShouldBeConvertedToReadOnlyRole(
                    UserFixture.CreateUserWithPlant(plantId, ClientSession.GetUserContext()), RoleFixture.CreateOperatorRole(), workAssignment, flocs));
            }
            {
                WorkAssignment workAssignment = WorkAssignmentFixture.CreateConsoleOperator();
                workAssignment.FunctionalLocations.Clear();

                List<FunctionalLocation> flocs = new List<FunctionalLocation>();
                flocs.Add(FunctionalLocationFixture.CreateNewWithPlantId(1, notPlantId));

                Assert.IsTrue(ReadOnlyRoleChecker.ShouldBeConvertedToReadOnlyRole(
                    UserFixture.CreateUserWithPlant(plantId, ClientSession.GetUserContext()), RoleFixture.CreateOperatorRole(), workAssignment, flocs));
            }
            {
                WorkAssignment workAssignment = WorkAssignmentFixture.CreateConsoleOperator();
                workAssignment.FunctionalLocations.Clear();
                workAssignment.FunctionalLocations.Add(FunctionalLocationFixture.CreateNewWithPlantId(1, notPlantId, "A-B"));

                List<FunctionalLocation> flocs = new List<FunctionalLocation>();
                flocs.Add(FunctionalLocationFixture.CreateNewWithPlantId(2, notPlantId, "A-B-C"));

                Assert.IsTrue(ReadOnlyRoleChecker.ShouldBeConvertedToReadOnlyRole(
                    UserFixture.CreateUserWithPlant(plantId, ClientSession.GetUserContext()), RoleFixture.CreateOperatorRole(), workAssignment, flocs));
            }
            {
                WorkAssignment workAssignment = WorkAssignmentFixture.CreateConsoleOperator();
                workAssignment.FunctionalLocations.Clear();
                workAssignment.FunctionalLocations.Add(FunctionalLocationFixture.CreateNewWithPlantId(1, notPlantId, "A-B-C"));

                List<FunctionalLocation> flocs = new List<FunctionalLocation>();
                flocs.Add(FunctionalLocationFixture.CreateNewWithPlantId(2, notPlantId, "A-B"));

                Assert.IsTrue(ReadOnlyRoleChecker.ShouldBeConvertedToReadOnlyRole(
                    UserFixture.CreateUserWithPlant(plantId, ClientSession.GetUserContext()), RoleFixture.CreateOperatorRole(), workAssignment, flocs));
            }

            // case: selected floc(s) are all in at least one of the user plants
            {
                WorkAssignment workAssignment = WorkAssignmentFixture.CreateConsoleOperator();
                workAssignment.FunctionalLocations.Clear();
                workAssignment.FunctionalLocations.Add(FunctionalLocationFixture.CreateNewWithPlantId(1, plantId, "A-B-C"));

                List<FunctionalLocation> flocs = new List<FunctionalLocation>();
                flocs.Add(FunctionalLocationFixture.CreateNewWithPlantId(2, plantId, "A-B"));

                Assert.IsFalse(ReadOnlyRoleChecker.ShouldBeConvertedToReadOnlyRole(
                    UserFixture.CreateUserWithPlants(new List<long> { plantId, otherPlantId }, ClientSession.GetUserContext()), RoleFixture.CreateOperatorRole(), workAssignment, flocs));
            }

            // case: user selects role 'operating engineer' but the plantId of the selected flocs are only available for the 'operator' role
            {
                WorkAssignment workAssignment = WorkAssignmentFixture.CreateConsoleOperator();
                workAssignment.FunctionalLocations.Clear();
                workAssignment.FunctionalLocations.Add(FunctionalLocationFixture.CreateNewWithPlantId(1, plantId, "A-B-C"));

                List<FunctionalLocation> flocs = new List<FunctionalLocation>();
                flocs.Add(FunctionalLocationFixture.CreateNewWithPlantId(2, plantId, "A-B"));

                UserContext userContext = ClientSession.GetUserContext();
                User user = UserFixture.CreateUserWithPlant(plantId, userContext);
                user.SiteRolePlants = new List<SiteRolePlant>
                                          {
                                              new SiteRolePlant(userContext.Site, RoleFixture.CreateOperatorRole(), plantId),
                                              new SiteRolePlant(userContext.Site, RoleFixture.CreateOperatingEngineerRole(), otherPlantId)
                                          };

                Assert.IsTrue(ReadOnlyRoleChecker.ShouldBeConvertedToReadOnlyRole(
                    user, RoleFixture.CreateOperatingEngineerRole(), workAssignment, flocs));
            }

        }

        [Test]
        public void ShouldCheckConvertToReadOnlyIfWorkAssignmentIsNull()
        {
            const long plantId = 12345;
            const int notPlantId = 123;

            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation>();
                Assert.IsFalse(ReadOnlyRoleChecker.ShouldBeConvertedToReadOnlyRole(
                    UserFixture.CreateUserWithPlant(plantId, ClientSession.GetUserContext()), RoleFixture.CreateOperatorRole(), null, flocs));
            }
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation>();
                flocs.Add(FunctionalLocationFixture.CreateNewWithPlantId(plantId));
                Assert.IsFalse(ReadOnlyRoleChecker.ShouldBeConvertedToReadOnlyRole(
                    UserFixture.CreateUserWithPlant(plantId, ClientSession.GetUserContext()), RoleFixture.CreateOperatorRole(), null, flocs));
            }
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation>();
                flocs.Add(FunctionalLocationFixture.CreateNewWithPlantId(notPlantId));
                Assert.IsTrue(ReadOnlyRoleChecker.ShouldBeConvertedToReadOnlyRole(
                    UserFixture.CreateUserWithPlant(plantId, ClientSession.GetUserContext()), RoleFixture.CreateOperatorRole(), null, flocs));
            }
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation>();
                flocs.Add(FunctionalLocationFixture.CreateNewWithPlantId(plantId));
                flocs.Add(FunctionalLocationFixture.CreateNewWithPlantId(notPlantId));
                Assert.IsTrue(ReadOnlyRoleChecker.ShouldBeConvertedToReadOnlyRole(
                    UserFixture.CreateUserWithPlant(plantId, ClientSession.GetUserContext()), RoleFixture.CreateOperatorRole(), null, flocs));
            }

        }

        [Test]
        public void ShouldNotConvertToReadOnlyIfUserIsSwitchingBackFromReadOnlyToTheirOriginalRole()
        {
            const long plantId = 12345;

            WorkAssignment workAssignment = WorkAssignmentFixture.CreateConsoleOperator();
            Role originalRole = workAssignment.Role;
            workAssignment.FunctionalLocations.Clear();
            workAssignment.FunctionalLocations.Add(FunctionalLocationFixture.CreateNewWithPlantId(1, plantId, "A-B-C"));

            User user = UserFixture.CreateUserWithPlantsAndRole(new List<long> { plantId }, originalRole, ClientSession.GetUserContext());
            Role readOnlyRole = RoleFixture.CreateReadOnlyRole();

            List<FunctionalLocation> flocs = new List<FunctionalLocation>();
            flocs.Add(FunctionalLocationFixture.CreateNewWithPlantId(2, plantId, "A-B"));

            Assert.IsFalse(ReadOnlyRoleChecker.ShouldBeConvertedToReadOnlyRole(user, readOnlyRole, workAssignment, flocs));
        }

    }
}
