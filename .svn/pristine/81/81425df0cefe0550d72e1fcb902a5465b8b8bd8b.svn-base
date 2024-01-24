using System;
using System.Collections.Generic;
using System.Globalization;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.PlantHistorian;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.PlantDataHistorian
{
    // TODO: Ignore the tests until OLTDEV001 PI server is rectified.
    [TestFixture]
    [Category("IntegrationPlantHistorian")]
    public class Denver_OSIPIPHDProviderTest
    {
        private const string DenverReadTag = "OLTTEST.PTARGET";
        private const string DenverWriteTag = "OLTTEST.PTARGET1";
        private const string DenverDigitalStateTag = "CDM158";

        private OSIPIPHDProvider provider;

        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
            if (provider != null)
            {
                provider.Dispose();
            }
        }

        [Test]
        [Ignore]
        public void GetTagInfoListShouldRetrieveTagsByPrefix()
        {
            provider = new OSIPIPHDProvider(PlantHistorianConnectionFixture.GetDenverInfo());

            char[] alphanumericAlphabet =
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };
            var tags = new List<TagInfo>();
            foreach (var c1 in alphanumericAlphabet)
            {
                tags.AddRange(provider.GetTagInfoList(c1.ToString(CultureInfo.InvariantCulture)));
            }
            Assert.IsTrue(tags.Count > 0);
        }

        [Test][Ignore]
        public void ShouldBeAbleToWriteToOltTestTag()
        {
            provider = new OSIPIPHDProvider(PlantHistorianConnectionFixture.GetDenverInfo());
            var canWritePHDTagValue =
                provider.CanWritePHDTagValue(TagInfoFixture.CreateMockTagForDenver(1, "OLTTEST.PTARGET5"));
            Assert.That(canWritePHDTagValue, Is.True);
        }

        [Test]
        public void ShouldFindServer()
        {
            provider = new OSIPIPHDProvider(PlantHistorianConnectionFixture.GetDenverInfo());
            Assert.That(provider, Is.Not.Null);
        }

        [Test][Ignore]
        public void ShouldGetPlantHistorianValueForTagValueTimeStampedExactlyOnTheRequestedTime()
        {
            provider = new OSIPIPHDProvider(PlantHistorianConnectionFixture.GetDenverInfo());

            var requestedTime = new DateTime(2006, 06, 18, 8, 0, 0);
            var results = provider.FetchPHDTagValue(PlantHistorianOrigin.Test, "OLTTEST.PTARGET3", new[] {requestedTime});
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Length == 1);
            Assert.AreEqual(91.11m, results[0]);
        }

        [Ignore] 
        [Test]
        public void ShouldGetPlantHistorianValueForTagValueTimeStampedPreviousToTheRequestedTime()
        {
            provider = new OSIPIPHDProvider(PlantHistorianConnectionFixture.GetDenverInfo());

            var requestedTime = new DateTime(2006, 06, 18, 8, 1, 0);
            var results = provider.FetchPHDTagValue(PlantHistorianOrigin.Test, "OLTTEST.PTARGET4", new[] {requestedTime});
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Length == 1);
            Assert.AreEqual(23000.00m, results[0]);
        }

        [Test]
        public void ShouldNotBeAbleToWriteToANonTestTag()
        {
            provider = new OSIPIPHDProvider(PlantHistorianConnectionFixture.GetDenverInfo());
            var canWritePHDTagValue = provider.CanWritePHDTagValue(TagInfoFixture.CreateMockTagForDenver(1, "sattest"));
            Assert.That(canWritePHDTagValue, Is.False);
        }

        [Test]
        [Ignore]
        public void ShouldQueryTagsByDescriptor()
        {
            provider = new OSIPIPHDProvider(PlantHistorianConnectionFixture.GetDenverInfo());

            var tags =
                provider.QueryTags(SiteFixture.Denver(), "Descriptor", "TestTag for manual data");
            var fetchedTag = tags.Find(tag => tag.Name == "TestTag1");
            Assert.IsNotNull(fetchedTag, "Could not find TestTag1 by Descriptor.");
        }

        [Test]
        [Ignore]
        public void ShouldQueryTagsByDescriptorWithWildCard()
        {
            provider = new OSIPIPHDProvider(PlantHistorianConnectionFixture.GetDenverInfo());

            var tags = provider.QueryTags(SiteFixture.Denver(), "Descriptor", "TestTag for");
            var fetchedTag = tags.Find(tag => tag.Name == "TestTag1");
            Assert.IsNotNull(fetchedTag, "Could not find TestTag1 by Descriptor.");
        }

        [Test]
        [Ignore]
        public void ShouldQueryTagsByTagName()
        {
            provider = new OSIPIPHDProvider(PlantHistorianConnectionFixture.GetDenverInfo());

            var tags = provider.QueryTags(SiteFixture.Denver(), "Tag", "TestTag1");
            var fetchedTag = tags.Find(tag => tag.Name == "TestTag1");
            Assert.IsNotNull(fetchedTag, "Could not find TestTag1");
        }

        [Test]
        [Ignore]
        public void ShouldQueryTagsByTagNameWithWildCard()
        {
            provider = new OSIPIPHDProvider(PlantHistorianConnectionFixture.GetDenverInfo());

            var tags = provider.QueryTags(SiteFixture.Denver(), "Tag", "T");
            var fetchedTag = tags.Find(tag => tag.Name == "TestTag1");
            Assert.IsNotNull(fetchedTag, "Could not find TestTag1");
            fetchedTag = tags.Find(tag => tag.Name == "TestPoint1");
            Assert.IsNotNull(fetchedTag, "Could not find TestPoint1");
            fetchedTag = tags.Find(tag => tag.Name == "TestPoint2");
            Assert.IsNotNull(fetchedTag, "Could not find TestPoint2");
        }

        [Test]
        [Ignore]
        public void ShouldQueryTagsByUnits()
        {
            provider = new OSIPIPHDProvider(PlantHistorianConnectionFixture.GetDenverInfo());

            var tags = provider.QueryTags(SiteFixture.Denver(), "engunits", "MyUnits");
            var fetchedTag = tags.Find(tag => tag.Name == "TestTag1");
            Assert.IsNotNull(fetchedTag, "Could not find TestTag1 by Units.");
        }

        [Test]
        [Ignore]
        public void ShouldQueryTagsByUnitsWithWildCard()
        {
            provider = new OSIPIPHDProvider(PlantHistorianConnectionFixture.GetDenverInfo());

            var tags = provider.QueryTags(SiteFixture.Denver(), "engunits", "my");
            var fetchedTag = tags.Find(tag => tag.Units == "MyUnits");
            Assert.IsNotNull(fetchedTag, "Could not find TestTag1 by Units.");
        }

        [Test][Ignore]
        public void ShouldReturnCurrentValuesIfRequestedValueArePostCurrentTime()
        {
            provider = new OSIPIPHDProvider(PlantHistorianConnectionFixture.GetDenverInfo());

            var now = DateTimeFixture.DateTimeNow;
            var requestedFutureTime = now.AddDays(1);
            var currentResults = provider.FetchPHDTagValue(PlantHistorianOrigin.Test, DenverReadTag, new[] {now});
            var nowValue = currentResults[0];
            var futureResults = provider.FetchPHDTagValue(PlantHistorianOrigin.Test, DenverReadTag,
                new[] {requestedFutureTime});
            var futureValue = futureResults[0];
            Assert.AreEqual(nowValue, futureValue);
        }

        [Test][Ignore]
        public void ShouldReturnMultipleValuesForEachRequestedDateTime()
        {
            provider = new OSIPIPHDProvider(PlantHistorianConnectionFixture.GetDenverInfo());

            var requestedTime1 = new DateTime(2014, 01, 1, 8, 0, 1);
            var requestedTime2 = new DateTime(2014, 02, 1, 8, 0, 1);
            var requestedTime3 = new DateTime(2014, 03, 1, 8, 0, 1);
            DateTime[] requestedTimes = {requestedTime1, requestedTime2, requestedTime3};
            var results = provider.FetchPHDTagValue(PlantHistorianOrigin.Test, "01CRUDEIN_API.AO", requestedTimes);
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Length == 3);
            Assert.AreEqual(49.91m, results[0]);
            Assert.AreEqual(47.71m, results[1]);
            Assert.AreEqual(49.4m, results[2]);
        }

        [Test][Ignore]
        public void ShouldReturnNullForTagsThatHaveADigitalState()
        {
            provider = new OSIPIPHDProvider(PlantHistorianConnectionFixture.GetDenverInfo());

            var requestedTime = new DateTime(2006, 06, 17, 2, 39, 14);
            var tagValue = provider.FetchPHDTagValue(PlantHistorianOrigin.Test, DenverDigitalStateTag,
                new[] {requestedTime});
            Assert.That(tagValue.Length, Is.EqualTo(1));
            Assert.That(tagValue[0], Is.Null);
        }

        [Test]
        [ExpectedException(typeof (InvalidPlantHistorianServerException))]
        public void ShouldThrowExceptionIfIsServerNameIsEmptyString()
        {
            var osiPiConnectionInfo = PlantHistorianConnectionFixture.GetDenverInfo();
            osiPiConnectionInfo.Server = string.Empty;
            provider = new OSIPIPHDProvider(osiPiConnectionInfo);
        }

        [Test]
        [ExpectedException(typeof (InvalidPlantHistorianServerException))]
        public void ShouldThrowExceptionIfIsServerNameIsNotFound()
        {
            var osiPiConnectionInfo = PlantHistorianConnectionFixture.GetDenverInfo();
            osiPiConnectionInfo.Server = "NO_Server_By_this_name__";
            provider = new OSIPIPHDProvider(osiPiConnectionInfo);
            provider.FetchPHDTagValue(PlantHistorianOrigin.Test, "OLTTEST.PTARGET", new[] {DateTimeFixture.DateTimeNow});
        }

        [Test]
        [ExpectedException(typeof (InvalidPlantHistorianServerException))]
        public void ShouldThrowExceptionIfIsServerNameIsNull()
        {
            var osiPiConnectionInfo = PlantHistorianConnectionFixture.GetDenverInfo();
            osiPiConnectionInfo.Server = null;
            provider = new OSIPIPHDProvider(osiPiConnectionInfo);
        }

        [Test][Ignore]
        [ExpectedException(typeof (TagDoesNotExistExpection))]
        public void ShouldThrowExceptionIfTagNameDoenNotExist()
        {
            provider = new OSIPIPHDProvider(PlantHistorianConnectionFixture.GetDenverInfo());

            var requestedTime = new DateTime(2006, 06, 18, 7, 59, 0);
            provider.FetchPHDTagValue(PlantHistorianOrigin.Test, "This_Tag_Name_Does_Not_Exist", new[] {requestedTime});
        }

        [Test][Ignore]
        [ExpectedException(typeof (TagDoesNotExistExpection))]
        public void ShouldThrowExceptionIfTryingToUpdateAValueForATagThatDoesNotExist()
        {
            provider = new OSIPIPHDProvider(PlantHistorianConnectionFixture.GetDenverInfo());

            var tag = TagInfoFixture.CreateMockTagForDenver(1, "This_Tag_should_not_Exist");
            provider.UpdatePHDTagValue(tag, 111.111m, DateTimeFixture.DateTimeNow);
        }

        [Test][Ignore]
        public void ShouldUpdateTagNameValue()
        {
            provider = new OSIPIPHDProvider(PlantHistorianConnectionFixture.GetDenverInfo());

            var tag = TagInfoFixture.CreateMockTagForDenver(1, DenverWriteTag);
            var now = DateTimeFixture.DateTimeNow;
            var originalValues = provider.FetchPHDTagValue(PlantHistorianOrigin.Test, DenverWriteTag, new[] {now});
            var writeValue = (originalValues[0] >= 100 ? 1 : originalValues[0] + 1);

            var nowPlusOneMinute = now.AddMinutes(1);
            provider.UpdatePHDTagValue(tag, writeValue.Value, nowPlusOneMinute);

            var results = provider.FetchPHDTagValue(PlantHistorianOrigin.Test, DenverWriteTag, new[] {nowPlusOneMinute});
            Assert.AreEqual(1, results.Length);
            Assert.AreEqual(writeValue, results[0]);
        }
    }
}