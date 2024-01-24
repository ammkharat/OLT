using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class RoleFixture
    {
        private static IRoleFixtureDataProvider dataProvider = new MadeUpRoleFixtureDataProvider();

        public static void SetDataProvider(IRoleFixtureDataProvider provider)
        {
            dataProvider = provider;
        }

        public static void UseFakeDataProvider()
        {
            dataProvider = new MadeUpRoleFixtureDataProvider();
        }

        public static Role CreateRole()
        {
            return new Role(-1, "Some Role", "SomeRole", false, false, false, false, false, null, Site.OILSAND_ID);
        }

        public static Role CreateAdministratorRole()
        {
            return new Role(-2, "Administrator", "admin", true, false, false, false, false, "admin", Site.OILSAND_ID);
        }

        public static Role CreateRestrictionReportingAdminRole()
        {
            return new Role(-3, "Some Role", "SomeRole", true, false, false, false, false, null, Site.OILSAND_ID);
        }

        public static Role CreateReadOnlyRole()
        {
            return new Role(-4, "Some Role", "SomeRole", false, true, false, false, false, null, Site.OILSAND_ID);
        }

        public static Role CreateNonOperationsPermitIssuerRole()
        {
            return new Role(-5, "Some Role", "SomeRole", false, false, false, true, false, null, Site.DENVER_ID);
        }

        public static Role CreateEngineeringSupportRole()
        {
            return new Role(-6, "Some Role", "SomeRole", false, false, false, false, false, null, Site.EDMONTON_ID);
        }

        public static Role CreatePermitScreenerRole()
        {
            return new Role(-7, "Some Role", "SomeRole", false, false, false, false, false, null, Site.SARNIA_ID);
        }

        public static Role CreateOperatingEngineerRole()
        {
            return new Role(-8, "Some Role", "SomeRole", false, false, false, false, false, null, Site.MONTREAL_ID);
        }

        public static Role CreateSupervisorRole()
        {
            return new Role(-9, "Supervisor", "Supervisor", false, false, false, false, false, "super", Site.SARNIA_ID);
        }

        public static Role CreateOperatorRole()
        {
            return new Role(-10, "Operator", "Operator", false, false, false, false, false, "oper", Site.SARNIA_ID);
        }

        public static Role GetRealRoleA(long siteId)
        {
            return dataProvider.GetBySite(siteId)[0];
        }

        public static Role GetRealRole(long siteId, string name)
        {
            return dataProvider.GetBySite(siteId).Find(r => string.Equals(name, r.Name));
        }

        public static Role GetRealRoleB(long siteId)
        {
            return dataProvider.GetBySite(siteId)[1];
        }

        public interface IRoleFixtureDataProvider
        {
            List<Role> GetBySite(long siteId);
        }

        private class MadeUpRoleFixtureDataProvider : IRoleFixtureDataProvider
        {
            public List<Role> GetBySite(long siteId)
            {
                List<Role> roles = new List<Role>();
                for (int i = 0; i < 10; i++ )
                {
                    string name = "role" + i;
                    roles.Add(new Role(-1 - i, name, name, false, false, false, false, false, null, siteId));
                }
                return roles;
            }
        }
    }

}