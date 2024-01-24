using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class SecurityServiceTest
    {
        private ISecurityService securityService;

        [SetUp]
        public void SetUp()
        {
            securityService = GenericServiceRegistry.Instance.GetService<ISecurityService>();
        }

        [Test][Ignore]
        public void ShouldValidateUserThatIsInLdap()
        {
            const string username = "oltuser1";
            const string password = "olt05T$T";
            var user = securityService.Authenticate(username, password.Encrypt());
            Assert.AreEqual(username, user.Username);
            Assert.IsNotEmpty(user.SiteRolePlants);
            Assert.IsNotNull(user.WorkPermitDefaultTimePreferences);
            Assert.IsNotNull(user.WorkPermitPrintPreference);
        }
    }
}