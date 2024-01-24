using System.Collections.Generic;
using System.Configuration;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Remote.Utilities;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Providers
{
    [TestFixture]
    [Category("Integration")]
    public class LdapAuthenticationProviderTest
    {
        private readonly string LDAP_PATH = ConfigurationManager.AppSettings["LDAP_PATH"];
        private readonly string LDAP_USER_DOMAIN = ConfigurationManager.AppSettings["LDAP_USER_DOMAIN"];

        private const string TEST_USER = "OLTUSER1";
        private const string TEST_USER_PASSWORD = "olt05T$T";

        private LdapAuthenticationProvider ldapAuthenticationProvider;

        [SetUp]
        public void LdapInitialize()
        {
            ldapAuthenticationProvider = new LdapAuthenticationProvider();

        }

        [Ignore] [Test]
        public void HasConfigurationSettingsConfiguredTest()
        {
            Assert.IsTrue(!LDAP_PATH.IsNullOrEmptyOrWhitespace());
            Assert.IsTrue(!LDAP_USER_DOMAIN.IsNullOrEmptyOrWhitespace());
        }

        [Ignore] [Test]
        public void ShouldNotLoginNonExistentUser()
        {
            ConfigurationManager.AppSettings["LDAP_USER_DOMAIN"] = "network.dev";
            ldapAuthenticationProvider = new LdapAuthenticationProvider();
            Assert.IsFalse(ldapAuthenticationProvider.IsValidActiveDirectoryLogon("baduser", "badpassword"));
        }

        [Ignore] [Test]
        public void ShouldNotLoginUserWithBadPassword()
        {
            ConfigurationManager.AppSettings["LDAP_USER_DOMAIN"] = "network.dev";
            ldapAuthenticationProvider = new LdapAuthenticationProvider();
            Assert.IsFalse(ldapAuthenticationProvider.IsValidActiveDirectoryLogon(TEST_USER, "badpassword"));
        }

        [Ignore] [Test]
        public void ShouldLoginUserNoAuthentication()
        {
            ConfigurationManager.AppSettings["LDAP_USER_DOMAIN"] = "network.dev";
            ldapAuthenticationProvider = new LdapAuthenticationProvider();
            Assert.IsTrue(ldapAuthenticationProvider.IsValidActiveDirectoryLogon(TEST_USER, TEST_USER_PASSWORD));
        }

        [Ignore] [Test]
        public void ShouldAuthenticateDevAndDev()
        {
            ConfigurationManager.AppSettings["LDAP_USER_DOMAIN"] = "network.dev";
            ldapAuthenticationProvider = new LdapAuthenticationProvider();
            Assert.IsTrue(ldapAuthenticationProvider.IsValidActiveDirectoryLogon(TEST_USER, TEST_USER_PASSWORD));
        }

        [Ignore] [Test]
        public void ShouldAuthenticateQutAndDev()
        {
            ConfigurationManager.AppSettings["LDAP_USER_DOMAIN"] = "network.dev";
            ldapAuthenticationProvider = new LdapAuthenticationProvider();
            Assert.IsTrue(ldapAuthenticationProvider.IsValidActiveDirectoryLogon(TEST_USER, TEST_USER_PASSWORD));
        }

        [Ignore] [Test]
        public void ShouldNotAuthenticateLanAndDev()
        {
            ConfigurationManager.AppSettings["LDAP_USER_DOMAIN"] = "network.dev";
            ConfigurationManager.AppSettings["LDAP_PATH"] = "LDAP://network.lan";

            ldapAuthenticationProvider = new LdapAuthenticationProvider();
            Assert.IsFalse(ldapAuthenticationProvider.IsValidActiveDirectoryLogon(TEST_USER, TEST_USER_PASSWORD));
        }

        [Ignore] [Test]
        public void ShouldAuthenticateDevAndQA()
        {
            ConfigurationManager.AppSettings["LDAP_USER_DOMAIN"] = "network.qut";
            ConfigurationManager.AppSettings["LDAP_PATH"] = "LDAP://network.dev";
            ldapAuthenticationProvider = new LdapAuthenticationProvider();

            Assert.IsTrue(ldapAuthenticationProvider.IsValidActiveDirectoryLogon(TEST_USER, TEST_USER_PASSWORD));
        }

        [Ignore] [Test]
        public void ShouldAuthenticateQAAndQA()
        {
            ConfigurationManager.AppSettings["LDAP_USER_DOMAIN"] = "network.qut";
            ConfigurationManager.AppSettings["LDAP_PATH"] = "LDAP://network.qut";
            ldapAuthenticationProvider = new LdapAuthenticationProvider();

            Assert.IsTrue(ldapAuthenticationProvider.IsValidActiveDirectoryLogon(TEST_USER, TEST_USER_PASSWORD));
        }

        [Ignore] [Test]
        public void ShouldAuthenticateLanAndQA()
        {
            ConfigurationManager.AppSettings["LDAP_USER_DOMAIN"] = "network.qut";
            ConfigurationManager.AppSettings["LDAP_PATH"] = "LDAP://network.lan";
            ldapAuthenticationProvider = new LdapAuthenticationProvider();

            Assert.IsFalse(ldapAuthenticationProvider.IsValidActiveDirectoryLogon(TEST_USER, TEST_USER_PASSWORD));
        }

        [Ignore] [Test]
        public void ShouldAuthenticateLanAndQASecurely()
        {
            ConfigurationManager.AppSettings["LDAP_USER_DOMAIN"] = "network.qut";
            ConfigurationManager.AppSettings["LDAP_PATH"] = "LDAP://network.lan";
            ldapAuthenticationProvider = new LdapAuthenticationProvider();

            Assert.IsFalse(ldapAuthenticationProvider.IsValidActiveDirectoryLogon(TEST_USER, TEST_USER_PASSWORD));
        }

        [Ignore] [Test]
        public void ShouldAuthenticateTrn()
        {
            ConfigurationManager.AppSettings["LDAP_USER_DOMAIN"] = "network.trn";
            ConfigurationManager.AppSettings["LDAP_PATH"] = "LDAP://network.trn";
            ldapAuthenticationProvider = new LdapAuthenticationProvider();

            Assert.IsFalse(ldapAuthenticationProvider.IsValidActiveDirectoryLogon("Train001", "Trnabc123"));
        }

        [Ignore] [Test]
        public void ShouldLoginAllTestUsers()
        {
            ConfigurationManager.AppSettings["LDAP_USER_DOMAIN"] = "network.dev";
            ConfigurationManager.AppSettings["LDAP_PATH"] = "LDAP://network.dev";
            ldapAuthenticationProvider = new LdapAuthenticationProvider();

            Assert.IsTrue(ldapAuthenticationProvider.IsValidActiveDirectoryLogon(TEST_USER, TEST_USER_PASSWORD));
            Assert.IsTrue(ldapAuthenticationProvider.IsValidActiveDirectoryLogon("OLTUSER2", TEST_USER_PASSWORD));
            Assert.IsTrue(ldapAuthenticationProvider.IsValidActiveDirectoryLogon("oltuser3", TEST_USER_PASSWORD));
            Assert.IsTrue(ldapAuthenticationProvider.IsValidActiveDirectoryLogon("OLTUSER4", TEST_USER_PASSWORD));
            Assert.IsTrue(ldapAuthenticationProvider.IsValidActiveDirectoryLogon("OLTUSER5", TEST_USER_PASSWORD));
            Assert.IsTrue(ldapAuthenticationProvider.IsValidActiveDirectoryLogon("OLTUSER6", TEST_USER_PASSWORD));
            Assert.IsTrue(ldapAuthenticationProvider.IsValidActiveDirectoryLogon("OLTUSER7", TEST_USER_PASSWORD));
            Assert.IsTrue(ldapAuthenticationProvider.IsValidActiveDirectoryLogon("OLTUSER8", TEST_USER_PASSWORD));
            Assert.IsTrue(ldapAuthenticationProvider.IsValidActiveDirectoryLogon("OLTUSER9", TEST_USER_PASSWORD));
            Assert.IsTrue(ldapAuthenticationProvider.IsValidActiveDirectoryLogon("OLTUSER10", TEST_USER_PASSWORD));
            Assert.IsTrue(ldapAuthenticationProvider.IsValidActiveDirectoryLogon("OLTUSER11", TEST_USER_PASSWORD));
            Assert.IsTrue(ldapAuthenticationProvider.IsValidActiveDirectoryLogon("OLTUSER12", TEST_USER_PASSWORD));
            Assert.IsTrue(ldapAuthenticationProvider.IsValidActiveDirectoryLogon("OLTUSER13", TEST_USER_PASSWORD));
            Assert.IsTrue(ldapAuthenticationProvider.IsValidActiveDirectoryLogon("OLTUSER14", TEST_USER_PASSWORD));
            Assert.IsTrue(ldapAuthenticationProvider.IsValidActiveDirectoryLogon("oltuser15", TEST_USER_PASSWORD));
        }

        [Ignore] [Test]
        public void ShouldHaveAPath()
        {
            ConfigurationManager.AppSettings["LDAP_PATH"] = "LDAP://network.dev";
            LdapAuthenticationProvider provider = new LdapAuthenticationProvider();
            Assert.IsTrue(provider.HasPath());
        }

        [Ignore] [Test]
        public void ShouldFindMemberships()
        {
            ConfigurationManager.AppSettings["LDAP_USER_DOMAIN"] = "network.dev";
            ConfigurationManager.AppSettings["LDAP_PATH"] = "LDAP://network.dev";
            ldapAuthenticationProvider = new LdapAuthenticationProvider();
            List<IOltGroupMembership> oltGroupMemberships = ldapAuthenticationProvider.GetOltGroupMemberships(TEST_USER, TEST_USER_PASSWORD);
            Assert.IsTrue(oltGroupMemberships.Count >= 7);
            Assert.True(oltGroupMemberships.Exists(membership => membership.SiteIdentifier == "Sarnia" && membership.RoleIdentifier == "Supervisor"));
        }

        [Ignore] [Test]
        public void ShouldGetFirstAndLastName()
        {
            ConfigurationManager.AppSettings["LDAP_USER_DOMAIN"] = "network.dev";
            ConfigurationManager.AppSettings["LDAP_PATH"] = "LDAP://network.dev";
            ldapAuthenticationProvider = new LdapAuthenticationProvider();

            UserInformation userInformation = ldapAuthenticationProvider.GetUserInformation(TEST_USER, TEST_USER_PASSWORD);

            Assert.AreEqual("Test Id", userInformation.FirstName);
            Assert.AreEqual("Oltuser1", userInformation.LastName);
        }

        //[Ignore] [Test] ("Need to fill in network.lan username and password to run")]
        //public void ShouldGetNameWithApostrophe()
        //{
        //    ConfigurationManager.AppSettings["LDAP_USER_DOMAIN"] = "network.lan";
        //    ConfigurationManager.AppSettings["LDAP_PATH"] = "LDAP://network.lan";
        //    ldapAuthenticationProvider = new LdapAuthenticationProvider();

        //    UserInformation userInformation = ldapAuthenticationProvider.GetUserInformation("fill in", "fill in", "joconnor");

        //    Assert.AreEqual("John", userInformation.FirstName);
        //    Assert.AreEqual("O'connor", userInformation.LastName);            
        //}

        [Ignore] [Test]
        public void ShouldBeAbleToSearchByLastname()
        {
            ConfigurationManager.AppSettings["LDAP_USER_DOMAIN"] = "network.lan";
            ConfigurationManager.AppSettings["LDAP_PATH"] = "LDAP://network.lan";

            ldapAuthenticationProvider = new LdapAuthenticationProvider();
            List<LdapAddressSearchResult> result = ldapAuthenticationProvider.SearchForUserOrGroup("Smith");
            Assert.That(result.Count, Is.GreaterThan(0));
        }

        [Ignore] [Test]
        public void ShouldBeAbleToSearchByGroupName()
        {
            ConfigurationManager.AppSettings["LDAP_USER_DOMAIN"] = "network.lan";
            ConfigurationManager.AppSettings["LDAP_PATH"] = "LDAP://network.lan";

            ldapAuthenticationProvider = new LdapAuthenticationProvider();
            List<LdapAddressSearchResult> result = ldapAuthenticationProvider.SearchForUserOrGroup("OSG-");
            Assert.That(result.Count, Is.GreaterThan(0));
        }

    }
}