using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Utilities
{
    [TestFixture]
    public class LdapGroupMembershipTest
    {
        [Ignore] [Test]
        [Category("Integration")]
        public void ShouldParseGroupMembershipStringIntoPlantSiteAndRole()
        {
            LdapGroupMembership ldapGroupMembership = new LdapGroupMembership("CN=OLT-OilSands-1200-Supervisor,OU=Users and Groups,DC=network,DC=dev");
            Assert.AreEqual(1200, ldapGroupMembership.PlantId);
            Assert.AreEqual("OilSands", ldapGroupMembership.SiteIdentifier);
            Assert.AreEqual("Supervisor", ldapGroupMembership.RoleIdentifier);
        }
    }
}
