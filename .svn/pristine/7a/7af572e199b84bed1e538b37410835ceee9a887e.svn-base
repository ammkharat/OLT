using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class GasTestElementTest
    {
        [Test]
        public void ShouldDetermineIfHasData()
        {
            GasTestElement element = GasTestElementWithNoData();
            element.ImmediateAreaTestRequired = true;
            Assert.IsTrue(element.HasData());

            element = GasTestElementWithNoData();
            element.ImmediateAreaTestResult = TestUtil.RandomDoubleNumber();
            Assert.IsTrue(element.HasData());

            element = GasTestElementWithNoData();
            element.ImmediateAreaTestRequired = true;
            Assert.IsTrue(element.HasData());

            element = GasTestElementWithNoData();
            element.ConfinedSpaceTestResult = TestUtil.RandomDoubleNumber();
            Assert.IsTrue(element.HasData());

            element = GasTestElementWithNoData();
            element.ConfinedSpaceTestRequired = true;
            Assert.IsTrue(element.HasData());

            element = GasTestElementWithNoData();
            Assert.IsFalse(element.HasData());            
        }

        [Test]
        public void ShouldHaveDataIfNonStandardElementHasData()
        {
            GasTestElement element = GasTestElementWithNoData();

            GasTestElementInfo nonStandardElementInfo =
                GasTestElementInfo.CreateOtherGasTestElementInfo(SiteFixture.Sarnia());
            nonStandardElementInfo.Id = -278934;
            element.ElementInfo = nonStandardElementInfo;

            Assert.IsFalse(element.HasData(), "Should have no data if attached element info has no data.");

            nonStandardElementInfo.Name = TestUtil.RandomString();
            Assert.IsTrue(element.HasData(), "Should have data if attached element info has data.");
        }

        [Test]
        public void ShouldNotHaveDataIfStandardElementHasData()
        {
            GasTestElement element = GasTestElementWithNoData();
            GasTestElementInfo standardInfo = GasTestElementInfoFixture.GetStandardInfoForSite(SiteFixture.Sarnia());
            element.ElementInfo = standardInfo;
            Assert.IsFalse(element.HasData(),
                           "Even though element info has data, because it's standard, it shouldn't be factored into the evaluation.");
        }

        private GasTestElement GasTestElementWithNoData()
        {
            GasTestElement element = new GasTestElement();
            Assert.IsFalse(element.HasData());
            return element;
        }
    }
}