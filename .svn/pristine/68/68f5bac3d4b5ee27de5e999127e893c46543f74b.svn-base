using System;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.PlantHistorian;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.PlantDataHistorian
{
    [TestFixture]
    [Category("IntegrationPlantHistorian")]
    public class Montreal_HoneywellPHDProviderTest
    {
        private IPHDProvider phdProvider;

        [SetUp]
        public void SetUp()
        {
            phdProvider = new HoneywellPHDProvider(PlantHistorianConnectionFixture.GetMontrealInfo());
        }

        [TearDown]
        public void TearDown()
        {
            if (phdProvider != null)
            {
                phdProvider.Dispose();
            }
        }

        [Test]
        [Ignore]
        public void GetPHDTagsShouldRetrieveTagsByPrefix_Short()
        {
            const string prefix = "s";
            var tags = phdProvider.GetTagInfoList(prefix);
            Assert.IsTrue(tags.Count > 0);
            Console.WriteLine("Total count: " + tags.Count);
            foreach (var tag in tags)
            {
                var name = tag.Name.ToLower();
                Assert.IsTrue(name.StartsWith(prefix.ToLower()), name);
            }
        }

        [Test][Ignore]
        public void ShouldGetTagValueFromMontreal()
        {
            const string tagName = "46FI4601";
            var requestedDateTime = new DateTime(2012, 08, 13, 10, 0, 0);
            var returnedValue =
                phdProvider.FetchPHDTagValue(PlantHistorianOrigin.Test, tagName, new[] {requestedDateTime});
            Assert.IsNotNull(returnedValue[0]);
        }

        [Test][Ignore]
        public void ShouldGetTagValueFromMontreal1()
        {
            const string tagName = "46FI4601";
            var requestedDateTime = new DateTime(2013, 07, 17, 0, 5, 0);
            var returnedValue =
                phdProvider.FetchPHDTagValue(PlantHistorianOrigin.Test, tagName, new[] {requestedDateTime});
            Assert.IsNotNull(returnedValue[0]);
        }
    }
}