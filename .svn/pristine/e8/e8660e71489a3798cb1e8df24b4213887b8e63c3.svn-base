using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Restriction
{
    [TestFixture]
    public class DeviationAlertTest
    {
        [Test]
        public void ShouldCalculateDeviationValue()
        {
            DeviationAlert dto = new DeviationAlert(
                RestrictionDefinitionFixture.CreateDefinition(), null, null, null, null, null, 35, 52, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow, null, null, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow);
            Assert.AreEqual(17, dto.DeviationValue);

            dto = new DeviationAlert(
                RestrictionDefinitionFixture.CreateDefinition(), null, null, null, null, null, null, 52, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow, null, null, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow);
            Assert.AreEqual(52, dto.DeviationValue);

            dto = new DeviationAlert(
                RestrictionDefinitionFixture.CreateDefinition(), null, null, null, null, null, null, null, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow, null, null, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow);
            Assert.AreEqual(0, dto.DeviationValue);

            dto = new DeviationAlert(
                RestrictionDefinitionFixture.CreateDefinition(), null, null, null, null, null, 35, null, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow, null, null, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow);
            Assert.AreEqual(-35, dto.DeviationValue);
        }

    }
}