using Com.Suncor.Olt.Common.Domain.WorkPermit;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class WorkPermitRespiratoryCartridgeTypeTest
    {
        [Test]
        public void ShouldReturnCartridgeTypeGivenId()
        {
            Assert.AreEqual(WorkPermitRespiratoryCartridgeType.OV_AG_HEPA, WorkPermitRespiratoryCartridgeType.Get(1));
            Assert.AreEqual(WorkPermitRespiratoryCartridgeType.OV_AG, WorkPermitRespiratoryCartridgeType.Get(2));
            Assert.AreEqual(WorkPermitRespiratoryCartridgeType.HEPA, WorkPermitRespiratoryCartridgeType.Get(3));
            Assert.AreEqual(WorkPermitRespiratoryCartridgeType.AMMONIA, WorkPermitRespiratoryCartridgeType.Get(4));
        }

        [Test]
        public void ShouldHaveANameAndAnId()
        {
            Assert.AreEqual("Ammonia", WorkPermitRespiratoryCartridgeType.AMMONIA.Name);
            Assert.AreEqual(4, WorkPermitRespiratoryCartridgeType.AMMONIA.Id);
        }
    }
}
