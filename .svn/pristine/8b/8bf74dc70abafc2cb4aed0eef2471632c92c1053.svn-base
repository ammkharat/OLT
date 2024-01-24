using System.Collections.Generic;
using System.Configuration;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.PlantHistorian;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.PlantHistorian;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.PlantDataHistorian
{
    [TestFixture]
    [Category("IntegrationPlantHistorian")]
    public class PlantHistorianGatewayTest
    {
        [TearDown]
        public void TearDown()
        {
            PlantHistorianGateway.Cleanup();
        }

        [SetUp]
        public void SetUp()
        {
            PlantHistorianGateway.ResetInstanceForTesting();
        }

        [Test]
        public void ShouldReturnFalseWhenCanReadingTagFromInDenverWeKnowCannotBeRead()
        {
            var tagInfo = new TagInfo(Site.DENVER_ID, "XXXXXX", "", "", false,null);
            Assert.AreEqual(false, PlantHistorianGateway.Instance.CanReadTagValue(tagInfo));
        }

        [Test]
        public void ShouldReturnFalseWhenCanReadingTagFromInSarniaWeKnowCannotBeRead()
        {
            var tagInfo = new TagInfo(Site.SARNIA_ID, "31FC007.DAILY_AVER", "", "", false,null);
            Assert.AreEqual(false, PlantHistorianGateway.Instance.CanReadTagValue(tagInfo));
        }

        [Test]
        public void ShouldReturnFalseWhenCheckingIIfCanWriteToTagInSarniaThatIsNotAWriteTag()
        {
            var tagInfo = new TagInfo(Site.SARNIA_ID, "31FC007.PV", "", "", false,null);
            Assert.AreEqual(false, PlantHistorianGateway.Instance.CanWriteTagValue(tagInfo));
        }

        [Test]
        public void ShouldReturnFalseWhenCheckingIfCanWriteToTagInDenverThatIsNotAWriteTag()
        {
            var tagInfo = new TagInfo(Site.DENVER_ID, "19AI215", "", "", false,null);
            Assert.AreEqual(false, PlantHistorianGateway.Instance.CanWriteTagValue(tagInfo));
        }

        [Test][Ignore]
        public void ShouldReturnHasPlantHistorian()
        {
            Assert.IsTrue(PlantHistorianGateway.Instance.HasPlantHistorian(SiteFixture.Denver()));
        }

        [Test][Ignore]
        public void ShouldReturnTrueWhenCanReadingTagInDenverWeKnowCanBeRead()
        {
            var tagInfo = new TagInfo(Site.DENVER_ID, "19AI215.PTARMIN", "", "", false,2);
            Assert.AreEqual(true, PlantHistorianGateway.Instance.CanReadTagValue(tagInfo));
        }

        [Test][Ignore]
        public void ShouldReturnTrueWhenCanReadingTagInSarniaWeKnowCanBeRead()
        {
            var tagInfo = new TagInfo(Site.SARNIA_ID, "31FC007.PV", "", "", false,1);
            Assert.AreEqual(true, PlantHistorianGateway.Instance.CanReadTagValue(tagInfo));
        }

        [Test][Ignore]
        public void ShouldReturnTrueWhenCheckingIfCanWriteToTagInSarniaThatIsAWriteTag()
        {
            var tagInfo = new TagInfo(Site.SARNIA_ID, "OLTTEST.PTARGET10", "", "", false,1);
            Assert.AreEqual(true, PlantHistorianGateway.Instance.CanWriteTagValue(tagInfo));
        }

        [Test][Ignore]
        [ExpectedException(typeof (MissingPHDConnectionException))]
        public void ShouldThrowExceptionIfProviderDoesNotExist()
        {
            PlantHistorianGateway.Instance.GetTagInfoList(
                new Site(-99, "who cares", null, new List<Plant>(new[] {new Plant(9999, "whocares", Site.OILSAND_ID)}),
                    ""), "a");
        }
    }
}