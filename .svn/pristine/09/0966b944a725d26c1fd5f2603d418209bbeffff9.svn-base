using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class GasTestElementResultDTOConverterTest
    {
        [Test]
        public void ConvertShouldConvertGasTestElementToDTO()
        {
            GasTestElement element = GasTestElementFixture.CreateGasTestElementWithStandardElementInfo();
            WorkPermit permit = WorkPermitFixture.CreateWorkPermit();

            GasTestElementResultDTO dto = new GasTestElementResultDTOConverter().Convert(element, permit);
            
            Assert.AreEqual(element.ElementInfo.Name, dto.Name);
            Assert.AreEqual(new GasTestElementLimitFormatter().ToLimitWithUnits(element, permit), dto.Limit);
            Assert.AreEqual(element.ImmediateAreaTestResult, dto.FirstTestResult);
            Assert.AreEqual(element.ConfinedSpaceTestResult, dto.ConfinedSpaceTestResult);
        }
    }
}
