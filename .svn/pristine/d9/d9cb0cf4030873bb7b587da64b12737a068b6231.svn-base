using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.PlantHistorian;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class PlantHistorianServiceTest
    {
        private IPlantHistorianService service; 
        private IPlantHistorianGateway gateway;
        private Mockery mocks;
        
        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            gateway = mocks.NewMock<IPlantHistorianGateway>();
            service = new PlantHistorianService(gateway);
        }

        [Ignore] [Test]
        public void ShouldGetTagValues()
        {
            TagInfo tagInfo = TagInfoFixture.CreateTagInfoWithId2FromDB();
            DateTime now = DateTimeFixture.DateTimeNow;
            DateTime[] requestedTimes = {now, now.AddHours(-1)};
            decimal?[] values = { 1m, 2m };
            
            Expect.Once.On(gateway).Method("ReadTagValues").With(PlantHistorianOrigin.Test, tagInfo, requestedTimes).Will(Return.Value(values));
            decimal?[] result = service.ReadTagValues(PlantHistorianOrigin.Test, tagInfo, requestedTimes);
            Assert.AreEqual(values, result);
        }

        [Ignore] [Test]
        public void ShouldGetTagInfoList()
        {
            TagInfo tagInfo = TagInfoFixture.CreateTagInfoWithId2FromDB();
            List<TagInfo> tagInfos = new List<TagInfo> {tagInfo};
            Site site = SiteFixture.Sarnia();
            Expect.Once.On(gateway).Method("GetTagInfoList").WithAnyArguments().Will(Return.Value(tagInfos));
            List<TagInfo> foundTagInfos = service.GetTagInfoList(site, "t");
            Assert.AreEqual(tagInfo, foundTagInfos[0]);
        }

        [Ignore] [Test]
        public void ShouldFilterBonusRawValuesForLabAlerts()
        {
            DateTime from = new DateTime(2010, 3, 9, 9, 13, 15);
            DateTime to = new DateTime(2010, 3, 9, 9, 42, 45);

            {
                Expect.Once.On(gateway).Method("ReadLabAlertTagValues").WithAnyArguments().Will(
                    Return.Value(GetTagValueListWithBonusValues()));

                List<TagValue> values = service.ReadLabAlertTagValues(TagInfoFixture.CreateTagInfoWithId2FromDB(), from, to);

                Assert.AreEqual(2, values.Count);
                Assert.IsTrue(values.Exists(value => value.TagName.Equals("TAG_2")));
                Assert.IsTrue(values.Exists(value => value.TagName.Equals("TAG_3")));
            }

            {
                Expect.Once.On(gateway).Method("ReadLabAlertTagValues").WithAnyArguments().Will(
                    Return.Value(GetTagValueListWithoutBonusValues()));

                List<TagValue> values = service.ReadLabAlertTagValues(TagInfoFixture.CreateTagInfoWithId2FromDB(), from, to);

                Assert.AreEqual(4, values.Count);               
            }
        }

        private static List<TagValue> GetTagValueListWithBonusValues()
        {            
            TagValue v1 = new TagValue("TAG_1", 1, new DateTime(2010, 3, 9, 9, 13, 14));
            TagValue v2 = new TagValue("TAG_2", 2, new DateTime(2010, 3, 9, 9, 15, 0));
            TagValue v3 = new TagValue("TAG_3", 3, new DateTime(2010, 3, 9, 9, 25, 14));
            TagValue v4 = new TagValue("TAG_4", 4, new DateTime(2010, 3, 9, 9, 42, 46));

            return new List<TagValue> {v1, v2, v3, v4};
        }

        private static List<TagValue> GetTagValueListWithoutBonusValues()
        {            
            TagValue v1 = new TagValue("TAG_1", 1, new DateTime(2010, 3, 9, 9, 13, 15));
            TagValue v2 = new TagValue("TAG_2", 2, new DateTime(2010, 3, 9, 9, 15, 0));
            TagValue v3 = new TagValue("TAG_3", 3, new DateTime(2010, 3, 9, 9, 25, 14));
            TagValue v4 = new TagValue("TAG_4", 4, new DateTime(2010, 3, 9, 9, 42, 45));

            return new List<TagValue> {v1, v2, v3, v4};
        }
    }
}