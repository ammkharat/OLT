using System;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class PlantHistorianServiceClientTest
    {
        private IPlantHistorianService service;


        [SetUp]
        public void SetUp()
        {
            service = GenericServiceRegistry.Instance.GetService<IPlantHistorianService>();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test][Ignore]
        public void ShouldReadDeviationTag()
        {
            var tagInfo = TagInfoFixture.GetWorkingRestrictionDefinitionTargetTagInfoForOilsands();

            var from = new DateTime(2010, 6, 14, 14, 0, 0);
            var to = new DateTime(2010, 6, 14, 15, 0, 0);

            var readRestrictionDeviationTagValue = service.ReadRestrictionDeviationTagValue(tagInfo, from, to);

            Assert.IsNotNull(readRestrictionDeviationTagValue);
        }
    }
}