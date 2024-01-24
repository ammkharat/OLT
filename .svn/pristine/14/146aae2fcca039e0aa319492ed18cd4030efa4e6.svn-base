using System.Linq;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class OpmExcursionResponseDTODaoTest : AbstractDaoTest
    {
        private IOpmExcursionDao excursionDao;
        private IOpmExcursionResponseDTODao excursionResponseDTODao;
        private IOpmExcursionResponseDao excursionResponseDao;

        [Ignore] [Test]
        public void ShouldGetByDateRangeAndFloc()
        {
            var functionalLocations = FunctionalLocationFixture.GetListWith2Units();
            var opmExcursionResponse = OpmExcursionResponseFixture.CreateForInsert();
            var opmExcursion = OpmExcursionFixture.CreateForInsert();
            opmExcursion.FunctionalLocation = functionalLocations.First().FullHierarchy;
            excursionDao.Insert(opmExcursion);
            opmExcursionResponse.OltExcursionId = opmExcursion.IdValue;
            excursionResponseDao.Insert(opmExcursionResponse);

            var dto =
                excursionResponseDTODao.QueryByDateRangeAndFlocs(
                    new DateRange(opmExcursion.StartDateTime.AddDays(-1).ToDate(),
                        opmExcursion.StartDateTime.AddDays(1).ToDate()), functionalLocations).First();

            Assert.IsNotNull(dto);
            Assert.AreEqual(opmExcursion.Id, dto.Id);
            Assert.AreEqual(opmExcursion.OpmExcursionId, dto.OpmExcursionId);
            Assert.AreEqual(opmExcursion.FunctionalLocation, dto.FunctionalLocation);
            Assert.AreEqual(opmExcursion.ToeName, dto.ToeName);
            Assert.AreEqual(opmExcursion.ToeType, dto.ToeType);
            Assert.AreEqual(opmExcursion.Status, dto.Status);
            Assert.AreEqual(opmExcursion.StartDateTime.Date, dto.StartDateTime.Date);
            Assert.AreEqual(opmExcursion.EndDateTime, dto.EndDateTime);
            Assert.AreEqual(opmExcursion.UnitOfMeasure, dto.UnitOfMeasure);
            Assert.AreEqual(opmExcursion.Peak, dto.Peak);
            Assert.AreEqual(opmExcursion.Average, dto.Average);
            Assert.AreEqual(opmExcursion.Duration, dto.Duration);
            Assert.AreEqual(opmExcursion.IlpNumber, dto.IlpNumber);
            Assert.AreEqual(opmExcursion.EngineerComments, dto.EngineerComments);
            Assert.AreEqual(opmExcursionResponse.Response, dto.OltOperatorResponse);
            Assert.AreEqual(opmExcursion.ReasonCode, dto.ReasonCode);
        }

        [Ignore] [Test]
        public void ShouldGetByDateRangeAndFlocForShiftHandover()
        {
            var functionalLocations = FunctionalLocationFixture.GetListWith2Units();
            var opmExcursionResponse = OpmExcursionResponseFixture.CreateForInsert();
            var opmExcursion = OpmExcursionFixture.CreateForInsert();
            opmExcursion.FunctionalLocation = functionalLocations.First().FullHierarchy;
            excursionDao.Insert(opmExcursion);
            opmExcursionResponse.OltExcursionId = opmExcursion.IdValue;
            excursionResponseDao.Insert(opmExcursionResponse);

            var dto =
                excursionResponseDTODao.QueryByDateRangeAndFlocsForShiftHandover(
                    opmExcursionResponse.LastModifiedDateTime.AddDays(-1),
                    opmExcursionResponse.LastModifiedDateTime.AddDays(1), functionalLocations).First();

            Assert.IsNotNull(dto);
            Assert.AreEqual(opmExcursion.Id, dto.Id);
            Assert.AreEqual(opmExcursion.OpmExcursionId, dto.OpmExcursionId);
            Assert.AreEqual(opmExcursion.FunctionalLocation, dto.FunctionalLocation);
            Assert.AreEqual(opmExcursion.ToeName, dto.ToeName);
            Assert.AreEqual(opmExcursion.ToeType, dto.ToeType);
            Assert.AreEqual(opmExcursion.Status, dto.Status);
            Assert.AreEqual(opmExcursion.StartDateTime.Date, dto.StartDateTime.Date);
            Assert.AreEqual(opmExcursion.EndDateTime, dto.EndDateTime);
            Assert.AreEqual(opmExcursion.UnitOfMeasure, dto.UnitOfMeasure);
            Assert.AreEqual(opmExcursion.Peak, dto.Peak);
            Assert.AreEqual(opmExcursion.Average, dto.Average);
            Assert.AreEqual(opmExcursion.Duration, dto.Duration);
            Assert.AreEqual(opmExcursion.IlpNumber, dto.IlpNumber);
            Assert.AreEqual(opmExcursion.EngineerComments, dto.EngineerComments);
            Assert.AreEqual(opmExcursionResponse.Response, dto.OltOperatorResponse);
            Assert.AreEqual(opmExcursion.ReasonCode, dto.ReasonCode);
        }


        protected override void TestInitialize()
        {
            excursionResponseDTODao = DaoRegistry.GetDao<IOpmExcursionResponseDTODao>();
            excursionResponseDao = DaoRegistry.GetDao<IOpmExcursionResponseDao>();
            excursionDao = DaoRegistry.GetDao<IOpmExcursionDao>();
        }

        protected override void Cleanup()
        {
        }
    }
}