using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;

namespace Com.Suncor.Olt.Client.Fixtures
{
    public class UserFixture
    {
        public static void CreateSupervisor(UserContext userContext)
        {
            User supervisor = Common.Fixtures.UserFixture.CreateSupervisor();
            userContext.User = supervisor;
            userContext.SetRole(RoleFixture.CreateSupervisorRole(), UserRoleElementsFixture.CreateRoleElementsForSupervisor(), new List<RoleDisplayConfiguration>(), new List<RolePermission>());
        }

        public static void CreateEngineeringSupport(UserContext userContext)
        {
            User user = Common.Fixtures.UserFixture.CreateEngineeringSupport();
            userContext.User = user;
            userContext.SetRole(RoleFixture.CreateEngineeringSupportRole(), UserRoleElementsFixture.CreateRoleElementsForEngineeringSupport(), new List<RoleDisplayConfiguration>(), new List<RolePermission>());
        }

        public static User CreateOperator(UserContext userContext)
        {
            return CreateOperator(111, "Fake Operator", userContext);
        }

        public static User CreateOperator(long id, string username, UserContext userContext)
        {
            User user = Common.Fixtures.UserFixture.CreateOperator(id, username);
            userContext.User = user;
            userContext.SetRole(RoleFixture.CreateOperatorRole(), UserRoleElementsFixture.CreateRoleElementsForOperator(), new List<RoleDisplayConfiguration>(), new List<RolePermission>());

            return user;
        }

        public static void CreateOperatorOltUser1InFortMcMurrySite(UserContext userContext)
        {
            userContext.User = Common.Fixtures.UserFixture.CreateOperatorOltUser1InFortMcMurrySite();
            userContext.SetRole(RoleFixture.CreateOperatorRole(), UserRoleElementsFixture.CreateRoleElementsForOperator(), new List<RoleDisplayConfiguration>(), new List<RolePermission>());

        }

        public static void CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(UserContext userContext)
        {
            userContext.User = Common.Fixtures.UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            userContext.SetRole(RoleFixture.CreateSupervisorRole(), UserRoleElementsFixture.CreateRoleElementsForSupervisor(), new List<RoleDisplayConfiguration>(), new List<RolePermission>());
        }

        public static User CreateUserWithPlantsAndRole(List<long> plantIds, Role role, UserContext userContext)
        {
            userContext.User = Common.Fixtures.UserFixture.CreateUserWithPlantsAndRole(plantIds, role);
            userContext.PlantIds = plantIds;
            return userContext.User;
        }

        public static User CreateUserWithPlant(long plantId, UserContext userContext)
        {
            return CreateUserWithPlants(new List<long> { plantId }, userContext);
        }

        public static User CreateUserWithPlants(List<long> plantIds, UserContext userContext)
        {
            userContext.User = Common.Fixtures.UserFixture.CreateUserWithPlants(plantIds);
            userContext.PlantIds = plantIds;
            return userContext.User;
        }
    }
}
