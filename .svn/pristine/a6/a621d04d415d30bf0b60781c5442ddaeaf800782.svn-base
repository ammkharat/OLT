using System;
using System.Collections.Generic;
using System.Configuration;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Providers;
using Com.Suncor.Olt.Remote.Utilities;
using NMock2;
using NMock2.Matchers;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class SecurityServiceTest
    {
        private Mockery mocks;
        private IUserDao mockUserDao;
        private ISecurityService securityService;
        private const string USERNAME = "stan_schmengie";
        private readonly string PASSWORD = "happywanderers123";
        private readonly User USER = UserFixture.CreateOperator(1, USERNAME);

        private string authenticationClass;
        private ISiteDao mockSiteDao;
        private IRoleDao mockRoleDao;

        [SetUp]
        public void SetUp()
        {
            authenticationClass = ConfigurationManager.AppSettings["AuthenticationProvider"];

            mocks = new Mockery();
            mockUserDao = mocks.NewMock<IUserDao>();
            mockRoleDao = mocks.NewMock<IRoleDao>();
            mockSiteDao = mocks.NewMock<ISiteDao>();
            
            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor(mockUserDao);
            DaoRegistry.RegisterDaoFor(mockSiteDao);
            DaoRegistry.RegisterDaoFor(mockRoleDao);

            securityService = new SecurityService();
        }
        
        [TearDown]
        public void TearDown()
        {
            ConfigurationManager.AppSettings["AuthenticationProvider"] = authenticationClass;
        }

        [Ignore] [Test]
        public void ShouldReturnUserWithEmptySiteRolePlantsIfTheyDoNotHaveOltGroupsAssociatedWithThem()
        {
            List<IOltGroupMembership> noGroups = new List<IOltGroupMembership>();
            IAuthenticationProvider authProvider = mocks.NewMock<IAuthenticationProvider>();
            securityService = new SecurityService(authProvider);

            Expect.Once.On(authProvider).Method("IsValidActiveDirectoryLogon").With(USERNAME, PASSWORD).Will(Return.Value(true));
            Expect.Once.On(authProvider).Method("GetOltGroupMemberships").With(USERNAME, PASSWORD).Will(Return.Value(noGroups));

            Expect.Once.On(mockUserDao).Method("QueryByUsername").With(USERNAME).Will(Throw.Exception(new NoDataFoundException("no user, br'")));
            Expect.Once.On(mockUserDao).Method("QueryDeletedUserByUserName").With(USERNAME).Will(Return.Value(null));
            Expect.Once.On(authProvider).Method("GetUserInformation").Will(Return.Value(new UserInformation("T. Boone", "Pickens", "0009654")));

            User inserteduser = UserFixture.CreateUser(USERNAME, "T. Boone", "Pickens");
            inserteduser.Id = 123;
            Expect.Once.On(mockUserDao).Method("Insert").With(NameAndSapIdMatcher("T. Boone", "Pickens", "0009654")).Will(Return.Value(inserteduser));
            Expect.Once.On(mockUserDao).Method("Update");
            Expect.Once.On(mockUserDao).Method("QueryById").Will(Return.Value(inserteduser));

            User authenticatedUser = securityService.Authenticate(USERNAME, PASSWORD.Encrypt());
            Assert.IsNotNull(authenticatedUser);
            Assert.IsEmpty(authenticatedUser.SiteRolePlants);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldCreateTheUserIfSheDoesNotExistInDbButHasRolesAndIsInLdap()
        {
            List<IOltGroupMembership> someGroups = new List<IOltGroupMembership> { new MockGroupMembership("Sarnia", "Supervisor", 1200) };
            IAuthenticationProvider authProvider = mocks.NewMock<IAuthenticationProvider>();
            securityService = new SecurityService(authProvider);

            // pretend user is not in db
            Expect.Once.On(mockUserDao).Method("QueryByUsername").With(USERNAME).Will(Throw.Exception(new NoDataFoundException("no user, br'")));
            Expect.Once.On(mockUserDao).Method("QueryDeletedUserByUserName").With(USERNAME).Will(Return.Value(null));

            Expect.Once.On(authProvider).Method("IsValidActiveDirectoryLogon").With(USERNAME, PASSWORD).Will(Return.Value(true));
            Expect.Once.On(authProvider).Method("GetOltGroupMemberships").With(USERNAME, PASSWORD).Will(Return.Value(someGroups));            
            Stub.On(mockSiteDao).Method("QueryByActiveDirectoryKey").Will(Return.Value(SiteFixture.Sarnia()));
            Stub.On(mockRoleDao).Method("QueryByActiveDirectoryKey").Will(Return.Value(RoleFixture.CreateSupervisorRole()));
            Expect.Once.On(authProvider).Method("GetUserInformation").Will(Return.Value(new UserInformation("T. Boone", "Pickens", "0009654")));

            User inserteduser = UserFixture.CreateUser(USERNAME, "T. Boone", "Pickens");
            inserteduser.Id = 123;
            Expect.Once.On(mockUserDao).Method("Insert").With(NameAndSapIdMatcher("T. Boone", "Pickens", "0009654")).Will(Return.Value(inserteduser));
            Expect.Once.On(mockUserDao).Method("Update");
            Expect.Once.On(mockUserDao).Method("QueryById").Will(Return.Value(inserteduser));

            User authenticatedUser = securityService.Authenticate(USERNAME, PASSWORD.Encrypt());
            Assert.AreEqual(USERNAME, authenticatedUser.Username);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldUpdateTheUserIfHisNameHasChanged()
        {
            const string databaseFirstName = "Johnny";
            const string databaseLastName = "Garbanzo";
            const string activeDirectoryFirstName = "T. Boone";
            const string activeDirectoryLastName = "Pickens";

            List<IOltGroupMembership> someGroups = new List<IOltGroupMembership> { new MockGroupMembership("Sarnia", "Supervisor", 1200) };
            IAuthenticationProvider authProvider = mocks.NewMock<IAuthenticationProvider>();
            securityService = new SecurityService(authProvider);

            Expect.Once.On(mockUserDao).Method("QueryByUsername").With(USERNAME).Will(Return.Value(UserFixture.CreateUser(USERNAME, databaseFirstName, databaseLastName)));
            Expect.Once.On(authProvider).Method("IsValidActiveDirectoryLogon").With(USERNAME, PASSWORD).Will(Return.Value(true));
            Expect.Once.On(authProvider).Method("GetOltGroupMemberships").With(USERNAME, PASSWORD).Will(Return.Value(someGroups));
            Stub.On(mockSiteDao).Method("QueryByActiveDirectoryKey").Will(Return.Value(SiteFixture.Sarnia()));
            Stub.On(mockRoleDao).Method("QueryByActiveDirectoryKey").Will(Return.Value(RoleFixture.CreateSupervisorRole()));
            Expect.Once.On(authProvider).Method("GetUserInformation").Will(Return.Value(new UserInformation(activeDirectoryFirstName, activeDirectoryLastName, "sapid")));
            Expect.Once.On(mockUserDao).Method("Update").With(FirstAndLastNameMatcher(activeDirectoryFirstName, activeDirectoryLastName));

            User authenticatedUser = securityService.Authenticate(USERNAME, PASSWORD.Encrypt());
            Assert.AreEqual(USERNAME, authenticatedUser.Username);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldSetUserToUndeletedIfSheHasRolesAndIsInLdap()
        {
            List<IOltGroupMembership> someGroups = new List<IOltGroupMembership> { new MockGroupMembership("Sarnia", "Supervisor", 1200) };
            IAuthenticationProvider authProvider = mocks.NewMock<IAuthenticationProvider>();
            securityService = new SecurityService(authProvider);

            User supervisor = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();

            Expect.Once.On(authProvider).Method("IsValidActiveDirectoryLogon").With(USERNAME, PASSWORD).Will(Return.Value(true));
            Expect.Once.On(authProvider).Method("GetOltGroupMemberships").With(USERNAME, PASSWORD).Will(Return.Value(someGroups));
            Stub.On(mockSiteDao).Method("QueryByActiveDirectoryKey").Will(Return.Value(SiteFixture.Sarnia()));
            Stub.On(mockRoleDao).Method("QueryByActiveDirectoryKey").Will(Return.Value(RoleFixture.CreateSupervisorRole()));

            Expect.Once.On(mockUserDao).Method("QueryByUsername").With(USERNAME).Will(Throw.Exception(new NoDataFoundException("no user, br'")));
            Expect.Once.On(mockUserDao).Method("QueryDeletedUserByUserName").With(USERNAME).Will(Return.Value(supervisor));
            Expect.Once.On(mockUserDao).Method("UndoRemove").With(supervisor, supervisor.Id.Value);

            securityService.Authenticate(USERNAME, PASSWORD.Encrypt());            
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldReturnTheAuthenticatedUserIfAuthenticatedUsingLdapAndHasRoleGroupsAndIsFoundInTheDatabase()
        {
            List<IOltGroupMembership> someGroups = new List<IOltGroupMembership> { new MockGroupMembership("Sarnia", "Supervisor", 1200) };
            IAuthenticationProvider authProvider = mocks.NewMock<IAuthenticationProvider>();
            securityService = new SecurityService(authProvider);

            Expect.Once.On(mockUserDao).Method("QueryByUsername").With(USERNAME).Will(Return.Value(USER));
            Expect.Once.On(authProvider).Method("GetUserInformation").Will(Return.Value(new UserInformation(USER.FirstName, USER.LastName, "sapid")));
            Expect.Once.On(authProvider).Method("IsValidActiveDirectoryLogon").With(USERNAME, PASSWORD).Will(Return.Value(true));
            Expect.Once.On(authProvider).Method("GetOltGroupMemberships").With(USERNAME, PASSWORD).Will(Return.Value(someGroups));
            Stub.On(mockSiteDao).Method("QueryByActiveDirectoryKey").Will(Return.Value(SiteFixture.Sarnia()));
            Stub.On(mockRoleDao).Method("QueryByActiveDirectoryKey").Will(Return.Value(RoleFixture.CreateSupervisorRole()));

            User authenticatedUser = securityService.Authenticate(USERNAME, PASSWORD.Encrypt());
            Assert.AreSame(USER, authenticatedUser);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldReturnNullIfUserNameIsNullOrEmpty()
        {
            IAuthenticationProvider authProvider = mocks.NewMock<IAuthenticationProvider>();
            securityService = new SecurityService(authProvider);

            Assert.IsNull(securityService.Authenticate(null, null));
            Assert.IsNull(securityService.Authenticate("", null));
        }

        [Ignore] [Test]
        public void ShouldReturnNullIfLdapAuthenticationFailsForGivenUserAndPassword()
        {
            IAuthenticationProvider authProvider = mocks.NewMock<IAuthenticationProvider>();
            securityService = new SecurityService(authProvider);

            Expect.Once.On(authProvider).Method("IsValidActiveDirectoryLogon").With(USERNAME, PASSWORD).Will(
                Return.Value(false));

            User authenticatedUser = securityService.Authenticate(USERNAME, PASSWORD.Encrypt());
            Assert.IsNull(authenticatedUser);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test, ExpectedException(typeof (NullReferenceException))]
        public void ShouldThrowUpAnExceptionFromLdapAuthenticationCall()
        {
            IAuthenticationProvider authProvider = mocks.NewMock<IAuthenticationProvider>();
            securityService = new SecurityService(authProvider);

            Expect.Once.On(authProvider).Method("IsValidActiveDirectoryLogon").With(USERNAME, PASSWORD).Will(
                Throw.Exception(new NullReferenceException()));
            securityService.Authenticate(USERNAME, PASSWORD.Encrypt());

        }

        [Test, ExpectedException(typeof (NullReferenceException))]
        public void ShouldThrowUpExceptionFromQueryUserCall()
        {
            List<IOltGroupMembership> someGroups = new List<IOltGroupMembership> { new MockGroupMembership("Sarnia", "Supervisor", 1200) };
            IAuthenticationProvider authProvider = mocks.NewMock<IAuthenticationProvider>();
            securityService = new SecurityService(authProvider);

            Expect.Once.On(authProvider).Method("GetOltGroupMemberships").Will(Return.Value(someGroups));
            Stub.On(mockSiteDao).Method("QueryByActiveDirectoryKey").Will(Return.Value(SiteFixture.Sarnia()));
            Stub.On(mockRoleDao).Method("QueryByActiveDirectoryKey").Will(Return.Value(RoleFixture.CreateSupervisorRole()));

            Expect.Once.On(mockUserDao).Method("QueryByUsername").With(USERNAME).Will(
                Throw.Exception(new NullReferenceException()));
            Expect.Once.On(authProvider).Method("IsValidActiveDirectoryLogon").With(USERNAME, PASSWORD).Will(
              Return.Value(true));
            securityService.Authenticate(USERNAME, PASSWORD.Encrypt());

        }

        [Ignore] [Test]
        public void ProperConfigSettingsAreApplied()
        {
            string ldapPath = ConfigurationManager.AppSettings["LDAP_PATH"];
            string ldapUserDomain = ConfigurationManager.AppSettings["LDAP_USER_DOMAIN"];
            Assert.IsTrue(!ldapPath.IsNullOrEmptyOrWhitespace());
            Assert.IsTrue(!ldapUserDomain.IsNullOrEmptyOrWhitespace());
        }

        [Ignore] [Test]
        public void UserShouldBePopulatedWithSiteRoles()
        {
            IAuthenticationProvider authProvider = mocks.NewMock<IAuthenticationProvider>();
            securityService = new SecurityService(authProvider);

            List<IOltGroupMembership> memberships = new List<IOltGroupMembership>
                {
                    new MockGroupMembership("Sarnia", "Supervisor", 4000),
                    new MockGroupMembership("Sarnia", "Operator", 4000)
                };

            Site site = SiteFixture.Sarnia();

            Expect.Once.On(mockUserDao).Method("QueryByUsername").With(USERNAME).Will(Return.Value(USER));
            Expect.Once.On(authProvider).Method("GetUserInformation").Will(Return.Value(new UserInformation(USER.FirstName, USER.LastName, "sapid")));
            Expect.Once.On(authProvider).Method("IsValidActiveDirectoryLogon").With(USERNAME, PASSWORD).Will(Return.Value(true));
            Expect.Once.On(authProvider).Method("GetOltGroupMemberships").With(USERNAME, PASSWORD).Will(Return.Value(memberships));
            Expect.Exactly(2).On(mockSiteDao).Method("QueryByActiveDirectoryKey").With("Sarnia").Will(Return.Value(site));
            Expect.Once.On(mockRoleDao).Method("QueryByActiveDirectoryKey").With(site, "Supervisor").Will(Return.Value(RoleFixture.CreateSupervisorRole()));
            Expect.Once.On(mockRoleDao).Method("QueryByActiveDirectoryKey").With(site, "Operator").Will(Return.Value(RoleFixture.CreateOperatorRole()));

            User authenticatedUser = securityService.Authenticate(USERNAME, PASSWORD.Encrypt());

            List<SiteRolePlant> siteRolePlants = authenticatedUser.SiteRolePlants;

            Assert.AreEqual(2, siteRolePlants.Count);
            Assert.IsTrue(siteRolePlants.Exists(siteRole => siteRole.Site.Equals(site) && siteRole.Role.Equals(RoleFixture.CreateSupervisorRole())));
            Assert.IsTrue(siteRolePlants.Exists(siteRole => siteRole.Site.Equals(site) && siteRole.Role.Equals(RoleFixture.CreateOperatorRole())));
            
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldNotReturnSitePlantRolesWhereRoleIsDeleted()
        {
            Site site = SiteFixture.Sarnia();

            IAuthenticationProvider authProvider = mocks.NewMock<IAuthenticationProvider>();
            securityService = new SecurityService(authProvider);

            List<IOltGroupMembership> memberships = new List<IOltGroupMembership>
                {
                    new MockGroupMembership("Sarnia", "Supervisor", 4000),
                    new MockGroupMembership("Sarnia", "Operator", 4000)
                };

            Expect.Once.On(mockUserDao).Method("QueryByUsername").With(USERNAME).Will(Return.Value(USER));
            Expect.Once.On(authProvider).Method("GetUserInformation").Will(Return.Value(new UserInformation(USER.FirstName, USER.LastName, "sapid")));
            Expect.Once.On(authProvider).Method("IsValidActiveDirectoryLogon").With(USERNAME, PASSWORD).Will(Return.Value(true));
            Expect.Once.On(authProvider).Method("GetOltGroupMemberships").With(USERNAME, PASSWORD).Will(Return.Value(memberships));
            Expect.Exactly(2).On(mockSiteDao).Method("QueryByActiveDirectoryKey").With("Sarnia").Will(Return.Value(site));
            Expect.Once.On(mockRoleDao).Method("QueryByActiveDirectoryKey").With(site, "Supervisor").Will(Return.Value(RoleFixture.CreateSupervisorRole()));
            Expect.Once.On(mockRoleDao).Method("QueryByActiveDirectoryKey").With(site, "Operator").Will(Return.Value(null));

            User authenticatedUser = securityService.Authenticate(USERNAME, PASSWORD.Encrypt());

            List<SiteRolePlant> siteRolePlants = authenticatedUser.SiteRolePlants;

            Assert.AreEqual(1, siteRolePlants.Count);
            Assert.IsTrue(siteRolePlants.Exists(siteRole => siteRole.Site.Equals(site) && siteRole.Role.Equals(RoleFixture.CreateSupervisorRole())));
            Assert.IsFalse(siteRolePlants.Exists(siteRole => siteRole.Site.Equals(site) && siteRole.Role.Equals(RoleFixture.CreateOperatorRole())));

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldNotReturnSitePlantRoleWhereADGroupSiteAndPlantCombinationDoesNotExistInOlt()
        {
            Site site = SiteFixture.Oilsands();

            IAuthenticationProvider authProvider = mocks.NewMock<IAuthenticationProvider>();
            securityService = new SecurityService(authProvider);

            List<IOltGroupMembership> memberships = new List<IOltGroupMembership>
                {
                    new MockGroupMembership("Oilsands", "RoleA", 1200),
                    new MockGroupMembership("Oilsands", "RoleB", 9999),
                    new MockGroupMembership("Oilsands", "RoleC", 1300)
                };

            Expect.Once.On(mockUserDao).Method("QueryByUsername").With(USERNAME).Will(Return.Value(USER));
            Expect.Once.On(authProvider).Method("GetUserInformation").Will(Return.Value(new UserInformation(USER.FirstName, USER.LastName, "sapid")));
            Expect.Once.On(authProvider).Method("IsValidActiveDirectoryLogon").With(USERNAME, PASSWORD).Will(Return.Value(true));
            Expect.Once.On(authProvider).Method("GetOltGroupMemberships").With(USERNAME, PASSWORD).Will(Return.Value(memberships));
            
            Stub.On(mockSiteDao).Method("QueryByActiveDirectoryKey").Will(Return.Value(site));
            Expect.Once.On(mockRoleDao).Method("QueryByActiveDirectoryKey").With(site, "RoleA").Will(Return.Value(RoleFixture.GetRealRoleA(3)));
            Expect.Once.On(mockRoleDao).Method("QueryByActiveDirectoryKey").With(site, "RoleC").Will(Return.Value(RoleFixture.GetRealRoleB(3)));

            Expect.Never.On(mockRoleDao).Method("QueryByActiveDirectoryKey").With(site, "RoleB");

            User authenticatedUser = securityService.Authenticate(USERNAME, PASSWORD.Encrypt());
            Assert.AreEqual(authenticatedUser.SiteRolePlants.Count, 2);
            mocks.VerifyAllExpectationsHaveBeenMet();

        }

        [Ignore] [Test]
        public void ShouldNotReturnSitePlantRoleWhereADGroupSiteAndPlantCombinationDoesNotExistInOltAcrossMultipleSites()
        {
            Site sws = SiteFixture.SiteWideServices();
            Site oilsands = SiteFixture.Oilsands();

            IAuthenticationProvider authProvider = mocks.NewMock<IAuthenticationProvider>();
            securityService = new SecurityService(authProvider);

            List<IOltGroupMembership> memberships = new List<IOltGroupMembership>
                {
                    new MockGroupMembership("OilSands", "RoleA", 1060),
                    new MockGroupMembership("SiteWideServices", "RoleB", 1060),
                };

            Expect.Once.On(mockUserDao).Method("QueryByUsername").With(USERNAME).Will(Return.Value(USER));
            Expect.Once.On(authProvider).Method("GetUserInformation").Will(Return.Value(new UserInformation(USER.FirstName, USER.LastName, "sapid")));
            Expect.Once.On(authProvider).Method("IsValidActiveDirectoryLogon").With(USERNAME, PASSWORD).Will(Return.Value(true));
            Expect.Once.On(authProvider).Method("GetOltGroupMemberships").With(USERNAME, PASSWORD).Will(Return.Value(memberships));

            Stub.On(mockSiteDao).Method("QueryByActiveDirectoryKey").With("OilSands").Will(Return.Value(oilsands));
            Stub.On(mockSiteDao).Method("QueryByActiveDirectoryKey").With("SiteWideServices").Will(Return.Value(sws));

            Expect.Once.On(mockRoleDao).Method("QueryByActiveDirectoryKey").With(sws, "RoleB").Will(Return.Value(RoleFixture.GetRealRoleB(6)));
            Expect.Never.On(mockRoleDao).Method("QueryByActiveDirectoryKey").With(oilsands, "RoleA");

            User authenticatedUser = securityService.Authenticate(USERNAME, PASSWORD.Encrypt());
            Assert.AreEqual(authenticatedUser.SiteRolePlants.Count, 1);
            mocks.VerifyAllExpectationsHaveBeenMet();

        }

        private Matcher FirstAndLastNameMatcher(string firstName, string lastName)
        {
            return new AndMatcher(new OltPropertyMatcher<User>("FirstName", firstName),
                                  new OltPropertyMatcher<User>("LastName", lastName));
        }

        private Matcher NameAndSapIdMatcher(string firstName, string lastName, string sapId)
        {
            return new AndMatcher(FirstAndLastNameMatcher(firstName, lastName),
                                  new OltPropertyMatcher<User>("SAPId", sapId));
        }

        private class MockGroupMembership : IOltGroupMembership
        {
            private readonly string siteIdentifier;
            private readonly string roleIdentifier;
            private readonly long plantId;

            public MockGroupMembership(string siteIdentifier, string roleIdentifier, long plantId)
            {
                this.siteIdentifier = siteIdentifier;
                this.roleIdentifier = roleIdentifier;
                this.plantId = plantId;
            }

            public string SiteIdentifier
            {
                get { return siteIdentifier; }
            }

            public string RoleIdentifier
            {
                get { return roleIdentifier; }
            }

            public long PlantId
            {
                get { return plantId; }
            }
        }

    }
}