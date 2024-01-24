using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Excursions
{
    [TestFixture]
    public class ExcursionResponseTest
    {
        [Test]
        public void ShouldConstructAnExcursionResponseWithAnExcursion()
        {
            var excursion = OpmExcursionFixture.CreateForInsert();

            var newExcursionResponse = new OpmExcursionResponse(excursion);

            Assert.AreEqual(excursion.HistorianTag, newExcursionResponse.HistorianTag);
            Assert.AreEqual(excursion.Id, newExcursionResponse.OltExcursionId);
            Assert.AreEqual(excursion.OpmExcursionId, newExcursionResponse.OpmExcursionId);
            Assert.AreEqual(excursion.ToeVersion, newExcursionResponse.ToeVersion);
        }
    }
}