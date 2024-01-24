using System;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.PlantHistorian;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.PlantDataHistorian
{
    [TestFixture]
    [Ignore]
    [Category("IntegrationPlantHistorian")]
    public class Lubes_HoneywellPHDProviderTest
    {
        private IPHDProvider phdProvider;

        [SetUp]
        public void SetUp()
        {
            phdProvider = new HoneywellPHDProvider(PlantHistorianConnectionFixture.GetLubesInfo());
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

        [Test]
        public void ShouldGetTagValueFromLubes()
        {
            const string tagName = "20_lc9498";
            var requestedDateTime = new DateTime(2012, 09, 10, 22, 0, 0);
            var returnedValue =
                phdProvider.FetchPHDTagValue(PlantHistorianOrigin.Test, tagName, new[] {requestedDateTime});
            var value = returnedValue[0];
            Assert.IsNotNull(value);
            Assert.IsTrue(value.HasValue);
            var expected = -0.722m;
            Assert.That(value, Is.EqualTo(expected));
        }
    }
}