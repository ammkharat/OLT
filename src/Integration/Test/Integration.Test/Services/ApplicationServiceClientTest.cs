using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class ApplicationServiceClientTest
    {
        private IApplicationService service;

        [SetUp]
        public void SetUp()
        {
            service = GenericServiceRegistry.Instance.GetService<IApplicationService>();
            Clock.Freeze();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test][Ignore]
        public void ShouldGetHelpURL()
        {
            var helpUrl = service.GetHelpURL();
            Assert.IsNotNullOrEmpty(helpUrl);

            var looksLikeAURL = helpUrl.ToUpper().Contains("HTTP");
            Assert.IsTrue(looksLikeAURL);
        }
    }
}