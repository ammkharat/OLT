using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Excursions
{
    [TestFixture]
    public class OpmExcursionTest
    {
        [Test]
        public void ShouldCreateExcursionResponseDtoFromExcursion()
        {
            var excursion = OpmExcursionFixture.CreateForInsert();
            var newExcursionResponse = new OpmExcursionResponse(excursion)
            {
                LastModifiedBy =  UserFixture.CreateSupervisor(),
                LastModifiedDateTime = Clock.Now
            };
            excursion.OpmExcursionResponse = newExcursionResponse;

            var excursionResponseDto = excursion.CreateExcursionResponseDTO();

            Assert.AreEqual(excursionResponseDto.Average, excursion.Average);
            Assert.AreEqual(excursionResponseDto.Duration, excursion.Duration);
            Assert.AreEqual(excursionResponseDto.EndDateTime, excursion.EndDateTime);
            Assert.AreEqual(excursionResponseDto.EngineerComments, excursion.EngineerComments);
            Assert.AreEqual(excursionResponseDto.FunctionalLocation, excursion.FunctionalLocation);
            Assert.AreEqual(excursionResponseDto.Id, excursion.Id);
            Assert.AreEqual(excursionResponseDto.IlpNumber, excursion.IlpNumber);
            Assert.AreEqual(excursionResponseDto.OltOperatorResponse, excursion.OpmExcursionResponse.Response);
            Assert.AreEqual(excursionResponseDto.Peak, excursion.Peak);
            Assert.AreEqual(excursionResponseDto.ReasonCode, excursion.ReasonCode);
            Assert.AreEqual(excursionResponseDto.ResponseLastUpdatedBy, excursion.OpmExcursionResponse.LastModifiedBy.FullNameWithUserName);
            Assert.AreEqual(excursionResponseDto.ResponseLastUpdatedDateTime,
                excursion.OpmExcursionResponse.LastModifiedDateTime);
            Assert.AreEqual(excursionResponseDto.StartDateTime, excursion.StartDateTime);
            Assert.AreEqual(excursionResponseDto.Status, excursion.Status);
            Assert.AreEqual(excursionResponseDto.ToeLimitValue, excursion.ToeLimitValue);
            Assert.AreEqual(excursionResponseDto.ToeName, excursion.ToeName);
            Assert.AreEqual(excursionResponseDto.ToeType, excursion.ToeType);
            Assert.AreEqual(excursionResponseDto.UnitOfMeasure, excursion.UnitOfMeasure);
        }


        [Test]
        public void ShouldCreateExcursionResponseDtoFromNewExcursionResponse()
        {
            var excursion = OpmExcursionFixture.CreateForInsert();
            var newExcursionResponse = new OpmExcursionResponse(excursion);
            excursion.OpmExcursionResponse = newExcursionResponse;

            var excursionResponseDto = excursion.CreateExcursionResponseDTO();

            Assert.AreEqual(excursionResponseDto.Average, excursion.Average);
            Assert.AreEqual(excursionResponseDto.Duration, excursion.Duration);
            Assert.AreEqual(excursionResponseDto.EndDateTime, excursion.EndDateTime);
            Assert.AreEqual(excursionResponseDto.EngineerComments, excursion.EngineerComments);
            Assert.AreEqual(excursionResponseDto.FunctionalLocation, excursion.FunctionalLocation);
            Assert.AreEqual(excursionResponseDto.Id, excursion.Id);
            Assert.AreEqual(excursionResponseDto.IlpNumber, excursion.IlpNumber);
            Assert.AreEqual(excursionResponseDto.OltOperatorResponse, excursion.OpmExcursionResponse.Response);
            Assert.AreEqual(excursionResponseDto.Peak, excursion.Peak);
            Assert.AreEqual(excursionResponseDto.ReasonCode, excursion.ReasonCode);
            Assert.IsNull(excursionResponseDto.ResponseLastUpdatedBy);
            Assert.AreEqual(excursionResponseDto.StartDateTime, excursion.StartDateTime);
            Assert.AreEqual(excursionResponseDto.Status, excursion.Status);
            Assert.AreEqual(excursionResponseDto.ToeLimitValue, excursion.ToeLimitValue);
            Assert.AreEqual(excursionResponseDto.ToeName, excursion.ToeName);
            Assert.AreEqual(excursionResponseDto.ToeType, excursion.ToeType);
            Assert.AreEqual(excursionResponseDto.UnitOfMeasure, excursion.UnitOfMeasure);
        }
    }
}