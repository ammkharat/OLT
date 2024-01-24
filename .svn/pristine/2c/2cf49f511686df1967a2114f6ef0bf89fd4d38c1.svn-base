using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class UserFixture
    {
        private static readonly DateTime SOME_ARBITRARY_DATE_TIME = new DateTime(2006, 05, 16, 16, 54, 00);

        public static User CreatePermitScreener(long id, string username, Site site)
        {
            return CreatePermitScreener(id, username, new List<Site>(new[] {site}));
        }

        private static User CreatePermitScreener(long id, string username, List<Site> sites)
        {
            var goofy = new User(id,
                                  username,
                                  "Goofy",
                                  "Guy",
                                  sites.ConvertAll(site => new SiteRolePlant(site, RoleFixture.CreateOperatorRole(), site.Plants[0].IdValue)),
                                  "42", null,
                                  null,
                                  null,
                                  SOME_ARBITRARY_DATE_TIME);
            return goofy;
        }

        public static User CreateDBInsertableUser()
        {
            var user = new User("testuser", "firstname", "lastname",
                                new List<SiteRolePlant> { new SiteRolePlant(SiteFixture.Sarnia(), RoleFixture.CreateOperatorRole(), PlantFixture.SarniaPlant.IdValue) },
                                 "99556677", null,
                                 null,
                                 null,
                                 SOME_ARBITRARY_DATE_TIME);
            return user;
        }

        public static User CreateDBInsertableUserForUpgrading()
        {
            var user = new User("testuser", "firstname", "lastname",
                                new List<SiteRolePlant> { new SiteRolePlant(SiteFixture.Oilsands(), RoleFixture.CreateOperatorRole(), PlantFixture.OilsandsUpgradingPlant.IdValue) },
                                 "99556677", null,
                                 null,
                                 null,
                                 SOME_ARBITRARY_DATE_TIME);
            return user;
        }

        public static User CreateUser()
        {
            return CreateUserWithPlant(PlantFixture.SarniaPlant.IdValue);
        }

        public static User CreateUser(Site site)
        {
            var user = new User("ufixtur", "User", "Fixture",
                                new List<SiteRolePlant> { new SiteRolePlant(site, RoleFixture.CreateOperatorRole(), site.Plants[0].IdValue) },
                                "42", null, null,
                                null, 
                                SOME_ARBITRARY_DATE_TIME);
            return user;
        }

        public static User CreateUserWithPlant(long plantId)
        {
            return CreateUserWithPlants(new List<long> { plantId });
        }

        public static User CreateUserWithPlants(List<long> plantIds)
        {
            return CreateUserWithPlantsAndRole(plantIds, RoleFixture.CreateOperatorRole());
        }

        public static User CreateUserWithPlantsAndRole(List<long> plantIds, Role role)
        {
            List<SiteRolePlant> siteRolePlants = plantIds.ConvertAll(plantId => new SiteRolePlant(SiteFixture.Sarnia(), role, plantId));

            UserWorkPermitDefaultTimePreferences timePreferences = UserWorkPermitDefaultTimePreferencesFixture.Create(TimeSpan.Zero, TimeSpan.Zero);
            var user = new User("ufixtur", "User", "Fixture",
                                siteRolePlants,
                                "42", null,
                                null, timePreferences,
                                SOME_ARBITRARY_DATE_TIME);
            return user;            
        }

        public static User CreateUserWithGivenId(long? id)
        {
            User user = CreateUser();
            user.Id = id;
            return user;
        }

        public static User CreateUser(string username, string firstname, string lastname)
        {
            var user = new User(username, firstname, lastname,
                    new List<SiteRolePlant> { new SiteRolePlant(SiteFixture.Sarnia(), RoleFixture.CreateOperatorRole(), PlantFixture.SarniaPlant.IdValue) },
                    "42", null, null,
                    null,
                    SOME_ARBITRARY_DATE_TIME);
            return user;
        }

        public static User CreateSupervisor()
        {
            return CreateSupervisor(1, "stan");
        }

        public static User CreateSupervisor(Site site)
        {
            return CreateSupervisor(1, "stan", site);
        }                
        
        public static string CreateRandomUserName()
        {
            return Guid.NewGuid().ToString().Substring(0, 24);
        }
        
         public static User CreateSupervisor(long id, string username)
         {
             return CreateSupervisor(id, username, SiteFixture.Oilsands());
         }
        
        public static User CreateSupervisor(long id, string username, Site site)
        {
            UserWorkPermitDefaultTimePreferences timePreferences = UserWorkPermitDefaultTimePreferencesFixture.Create(TimeSpan.Zero, TimeSpan.Zero);
            var stan = new User(id, username, "Stan", "Schmengie",
                                new List<SiteRolePlant> { new SiteRolePlant(site, RoleFixture.CreateSupervisorRole(), site.Plants[0].IdValue) },
                                 "42", null, 
                                 null, timePreferences,
                                 SOME_ARBITRARY_DATE_TIME);

            return stan;
        }

        public static User CreateEngineeringSupport(Site site)
        {
            return new User(2, "george", "George", "of the Jungle",
                                        new List<SiteRolePlant> { new SiteRolePlant(site, RoleFixture.CreateOperatorRole(), site.Plants[0].IdValue) },
                                        "42", null,
                                        null, null,
                                        SOME_ARBITRARY_DATE_TIME);            
        }
        public static User CreateEngineeringSupport()
        {
            return CreateEngineeringSupport(SiteFixture.SiteWideServices());
        }

        public static User CreateNonOperationsPermitIssuer()
        {
            return new User(16, "oltuser16", "Santa's Little", "Helper", 
                new List<SiteRolePlant> { new SiteRolePlant(SiteFixture.Sarnia(), RoleFixture.CreateOperatorRole(), PlantFixture.SarniaPlant.IdValue) },
                "16000000", null,
                null, null,
                SOME_ARBITRARY_DATE_TIME);
        }

        public static User CreateOperatingEngineer()
        {
            Site site = SiteFixture.SiteWideServices();
            return new User("username", "Mickey", "Mouse",
                new List<SiteRolePlant> { new SiteRolePlant(site, RoleFixture.CreateOperatingEngineerRole(), site.Plants[0].IdValue) },
                "42", null, null, null,
                SOME_ARBITRARY_DATE_TIME);
        }
        
        public static User CreateOperator(long id, string username)
        {
            Site site = SiteFixture.SiteWideServices();
            return new User(id, username, "Mickey", "Mouse",
                new List<SiteRolePlant> { new SiteRolePlant(site, RoleFixture.CreateOperatorRole(), site.Plants[0].IdValue) },
                "42", null,null, null,
                SOME_ARBITRARY_DATE_TIME);
        }

        public static User CreateOperator()
        {
            return CreateOperator(111, "Fake Operator");
        }

        public static User CreateOperatorMickeyInFortMcMurrySite()
        {
            return CreateOperator(1, "mm");
        }

        public static User CreateOperatorGoofyInFortMcMurrySite()
        {
            Site site = SiteFixture.SiteWideServices();
            var goofy = new User(2, "talkyDog", "Goofy", "Dog",
                new List<SiteRolePlant> { new SiteRolePlant(site, RoleFixture.CreateOperatorRole(), site.Plants[0].IdValue) },
                "42", null, null, null,
                SOME_ARBITRARY_DATE_TIME);

            return goofy;
        }

        public static User CreateOperatorOltUser1InFortMcMurrySite()
        {
            Site site = SiteFixture.SiteWideServices();
            var mickey = new User(3, "oltuser1", "testing", "oltuser1",
                new List<SiteRolePlant> { new SiteRolePlant(site, RoleFixture.CreateOperatorRole(), site.Plants[0].IdValue) },
                "42", null, null, null,
                SOME_ARBITRARY_DATE_TIME);
            return mickey;
        }

        public static User CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB()
        {
            var mickey = new User(1, "oltuser1", "Homer", "Simpson",
                new List<SiteRolePlant> { new SiteRolePlant(SiteFixture.Sarnia(), RoleFixture.CreateSupervisorRole(), PlantFixture.SarniaPlant.IdValue) },
                "42", null, null, null,
                SOME_ARBITRARY_DATE_TIME);
            return mickey;
        }

        public static User CreateUserWithRoles(List<Role> roles)
        {
            List<SiteRolePlant> siteRolePlants =
                roles.ConvertAll(role => new SiteRolePlant(SiteFixture.Sarnia(), role, PlantFixture.SarniaPlant.IdValue));

            return new User("oltuser1", "Homer", "Simpson",
                siteRolePlants,
                "42", null, null, null,
                SOME_ARBITRARY_DATE_TIME);
        }

        public static User CreateSAPUser()
        {
            List<SiteRolePlant> siteRolePlants = new List<SiteRolePlant>
                {
                    new SiteRolePlant(SiteFixture.Sarnia(), RoleFixture.CreateOperatorRole(), PlantFixture.SarniaPlant.IdValue),
                    new SiteRolePlant(SiteFixture.Denver(), RoleFixture.CreateOperatorRole(), SiteFixture.Denver().Plants[0].IdValue)
                };
            return new User(0, null, "SAP", "User", 
                            siteRolePlants, 
                            "Z", null, null, null,
                            SOME_ARBITRARY_DATE_TIME);
        }

        public static User CreateAdmin()
        {
            return new User(
                                4,
                                "oltuser4",
                                "Ralph",
                                "Wiggum",
                                new List<SiteRolePlant> { new SiteRolePlant(SiteFixture.Sarnia(), RoleFixture.CreateAdministratorRole(), PlantFixture.SarniaPlant.IdValue) },
                                "04000000", null,
                                null,
                                null,
                                SOME_ARBITRARY_DATE_TIME
                            );
        }
        
        public static User CreateSarniaUserWithUserPrintPreference()
        {
            return new User(1, "HelloJoe", "Stan", "Schmengie",
                new List<SiteRolePlant> { new SiteRolePlant(SiteFixture.Sarnia(), RoleFixture.CreateOperatorRole(), PlantFixture.SarniaPlant.IdValue) },
                "42", null,
                UserPrintPreferenceFixture.CreateWorkPermitPrintPreference(1),
                null,
                SOME_ARBITRARY_DATE_TIME);

        }

        public static User CreateOilSandsUserWithUserPrintPreference()
        {
            return new User(1, "HelloJoe", "Stan", "Schmengie",
                new List<SiteRolePlant> { new SiteRolePlant(SiteFixture.Oilsands(), RoleFixture.CreateOperatorRole(), PlantFixture.OilsandsPlants()[0].IdValue) },
                "42", null,
                UserPrintPreferenceFixture.CreateWorkPermitPrintPreference(1),
                null,
                SOME_ARBITRARY_DATE_TIME);
        }

        public static User CreateOilSandsUserWithUserPrintPreference(string printerName, int numCopies, bool showDialog, bool showShiftHandoverAlertdialog, bool showSoundAlertforActionItemDirectiveTargets)
        {
            return new User(1, "HelloJoe", "Stan", "Schmengie",
                new List<SiteRolePlant> { new SiteRolePlant(SiteFixture.Oilsands(), RoleFixture.CreateOperatorRole(), PlantFixture.OilsandsPlants()[0].IdValue) },
                "42", null,
                UserPrintPreferenceFixture.CreateWorkPermitPrintPreference(1, printerName, numCopies, 3, showDialog, showShiftHandoverAlertdialog, showSoundAlertforActionItemDirectiveTargets),
                null,
                SOME_ARBITRARY_DATE_TIME);
        }

        public static User CreateUserWithWorkPermitDefaultTimePreferences(string userName)
        {
            return new User(1, userName, "Stan", "Schmengie",
                new List<SiteRolePlant> { new SiteRolePlant(SiteFixture.Oilsands(), RoleFixture.CreateOperatorRole(), PlantFixture.OilsandsPlants()[0].IdValue) },
                "42", null,
                null,
                new UserWorkPermitDefaultTimePreferences(1),
                SOME_ARBITRARY_DATE_TIME);
            
        }

        public static User CreateUserWithWorkPermitDefaultTimePreferences()
        {
            return CreateUserWithWorkPermitDefaultTimePreferences("HelloJoe");
        }

        public static User CreateRemoteAppUser()
        {
            return new User(456, "systemuser", "System", "User",
                new List<SiteRolePlant> { new SiteRolePlant(SiteFixture.Oilsands(), RoleFixture.CreateOperatorRole(), PlantFixture.OilsandsPlants()[0].IdValue) },
                "42", null,
                null,
                new UserWorkPermitDefaultTimePreferences(1),
                SOME_ARBITRARY_DATE_TIME);
        }

        public static User CreateUserWithAutoApproveActionItemDefinitionPermission()
        {
            return CreateSupervisor();
        }

        public static User CreateUserWhoCanNotAutoApproveActionItemDefinitio()
        {
            return CreateEngineeringSupport();
        }        
    }

}
