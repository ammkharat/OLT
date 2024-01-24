using Com.Suncor.Olt.Common.Domain.WorkPermit;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class WorkPermitFireConfinedSpaceRequirementsTest
    {
        [Test]
        public void ShouldDetermineIfHasData()
        {
            TestHasData("IsTwentyABCorDryChemicalExtinguisher", true);            
            TestHasData("IsC02Extinguisher", true);
            TestHasData("IsFireResistantTarp", true);
            TestHasData("IsSteamHose", true);
            TestHasData("IsWaterHose", true);
            TestHasData("IsSparkContainment", true);
            TestHasData("OtherDescription", TestUtil.RandomString());
            TestHasData("IsWatchmen", true);
            TestHasData("HoleWatchNumber", TestUtil.RandomString());
            TestHasData("FireWatchNumber", TestUtil.RandomString());
            TestHasData("SpotterNumber", TestUtil.RandomString());
        }

        private static void TestHasData(string propertyName, object dataValue)
        {
            var requirements = new WorkPermitFireConfinedSpaceRequirements();
            Assert.IsFalse(requirements.HasData());
            TestUtil.SetProperty(requirements, propertyName, dataValue);
            Assert.IsTrue(requirements.HasData());
        }
    }
}
