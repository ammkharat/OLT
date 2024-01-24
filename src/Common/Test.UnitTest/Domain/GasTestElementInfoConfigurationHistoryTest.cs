using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class GasTestElementInfoConfigurationHistoryTest
    {
        [Test]
        public void EqualsShouldReturnTrue()
        {
            GasTestElementInfoConfigurationHistory gasTestElementInfoConfigurationHistory =
                GasTestElementInfoConfigurationHistoryFixture.CreateGasTestElementInfoHistory();
            Assert.AreEqual(gasTestElementInfoConfigurationHistory, gasTestElementInfoConfigurationHistory);
        }

        [Test]
        public void TwoEquivalentObjectsShouldBeEqual()
        {
            GasTestElementInfoConfigurationHistory gasTestElementInfoConfigurationHistory =
                GasTestElementInfoConfigurationHistoryFixture.CreateGasTestElementInfoHistory();
            GasTestElementInfoConfigurationHistory gasTestElementInfoHistory2 =
                GasTestElementInfoConfigurationHistoryFixture.CreateGasTestElementInfoHistory();            

            Assert.AreEqual(gasTestElementInfoConfigurationHistory, gasTestElementInfoHistory2);
        }

        [Test]
        public void TwoDifferentObjectsShouldNotBeEqual()
        {
            GasTestElementInfoConfigurationHistory gasTestElementInfoConfigurationHistory =
                GasTestElementInfoConfigurationHistoryFixture.CreateGasTestElementInfoHistory();
            
            GasTestElementInfoConfigurationHistory gasTestElementInfoConfigurationHistory2 =
                GasTestElementInfoConfigurationHistoryFixture.CreateGasTestElementInfoHistory();
            gasTestElementInfoConfigurationHistory2.InertCSELimit = "800";

            Assert.AreNotEqual(gasTestElementInfoConfigurationHistory, gasTestElementInfoConfigurationHistory2);

        }
    }
}
