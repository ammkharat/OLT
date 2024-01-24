using Com.Suncor.Olt.Common.Domain.WorkPermit;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class WorkPermitToolsTest
    {
        [Test]
        public void ShouldDetermineIfHasData()
        {
            TestHasData("IsAirTools", true);
            TestHasData("IsCraneOrCarrydeck", true);
            TestHasData("IsHandTools", true);
            TestHasData("IsJackhammer", true);
            TestHasData("IsVacuumTruck", true);
            TestHasData("IsCementSaw", true);
            TestHasData("IsElectricTools", true);
            TestHasData("IsHeavyEquipment", true);
            TestHasData("IsLanda", true);
            TestHasData("IsScaffolding", true);
            TestHasData("IsVehicle", true);
            TestHasData("IsCompressor", true);
            TestHasData("IsForklift", true);
            TestHasData("IsHEPAVacuum", true);
            TestHasData("IsManlift", true);
            TestHasData("IsTamper", true);
            TestHasData("IsHotTapMachine", true);
            TestHasData("IsPortLighting", true);
            TestHasData("IsTorch", true);
            TestHasData("IsWelder", true);
            TestHasData("IsChemicals", true);
            TestHasData("OtherToolsDescription", TestUtil.RandomString());
        }

        private static void TestHasData(string propertyName, object dataValue)
        {
            WorkPermitTools tools = new WorkPermitTools();
            Assert.IsFalse(tools.HasData());
            TestUtil.SetProperty(tools, propertyName, dataValue);
            Assert.IsTrue(tools.HasData());
        }
    }
}
