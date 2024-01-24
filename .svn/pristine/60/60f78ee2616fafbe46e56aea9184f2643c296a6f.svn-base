using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class WorkPermitEdmontonServiceTest
    {
        private IWorkPermitEdmontonDao mockWorkPermitDao;

        [SetUp]
        public void SetUp()
        {
            mockWorkPermitDao = MockRepository.GenerateMock<IWorkPermitEdmontonDao>();
        }

        [Ignore] [Test]        
        public void ShouldCheckForExistingPermitsInNightShiftForThreeAm()
        {
            WorkPermitEdmontonService workPermitEdmontonService = new WorkPermitEdmontonService(mockWorkPermitDao, null, null, null, null, null, null, null, null, null, null, null, null);
            PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            permitRequest.Id = 1234;
            permitRequest.RequestedStartDate = new Date(2012, 10, 26);
            permitRequest.RequestedStartTimeDay = new Time(3);

            List<PermitRequestEdmontonDTO> requests = new List<PermitRequestEdmontonDTO> {new PermitRequestEdmontonDTO(permitRequest)};
            Date workPermitStartDate = new Date(2012, 10, 26);

            Range<DateTime> rangeOfExistingPermits = new Range<DateTime>(new DateTime(2012, 10, 25, 19, 0, 0), new DateTime(2012, 10, 26, 7, 0, 0));

            mockWorkPermitDao.Expect(dao => dao.DoesPermitRequestEdmontonAssociationExist(new List<long> {1234}, rangeOfExistingPermits)).Return(false);
            bool result = workPermitEdmontonService.DoesPermitRequestEdmontonAssociationExist(requests, workPermitStartDate);
            Assert.IsFalse(result);
        }

        [Ignore] [Test]
        public void ShouldCheckForExistingPermitsInNightShiftOnSameDayForStandardRequestOnDayAndNight()
        {
            WorkPermitEdmontonService workPermitEdmontonService = new WorkPermitEdmontonService(mockWorkPermitDao, null, null, null, null, null, null, null, null, null, null, null, null);
            PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            permitRequest.Id = 1234;
            permitRequest.RequestedStartDate = new Date(2012, 10, 31);
            permitRequest.RequestedStartTimeDay = new Time(8);
            permitRequest.RequestedStartTimeNight = new Time(20);

            List<PermitRequestEdmontonDTO> requests = new List<PermitRequestEdmontonDTO> { new PermitRequestEdmontonDTO(permitRequest) };
            Date workPermitStartDate = new Date(2012, 11, 01);

            Range<DateTime> shiftRangeForDayPermits = new Range<DateTime>(new DateTime(2012, 11, 01, 7, 0, 0), new DateTime(2012, 11, 01, 19, 0, 0));
            Range<DateTime> shiftRangeForNightPermits = new Range<DateTime>(new DateTime(2012, 11, 01, 19, 0, 0), new DateTime(2012, 11, 02, 7, 0, 0));

            mockWorkPermitDao.Expect(dao => dao.DoesPermitRequestEdmontonAssociationExist(new List<long> { 1234 }, shiftRangeForDayPermits)).Return(false);
            mockWorkPermitDao.Expect(dao => dao.DoesPermitRequestEdmontonAssociationExist(new List<long> { 1234 }, shiftRangeForNightPermits)).Return(false);
            bool result = workPermitEdmontonService.DoesPermitRequestEdmontonAssociationExist(requests, workPermitStartDate);
            Assert.IsFalse(result);
        }

        [Ignore] [Test]
        public void ShouldCheckForExistingPermitsInNightShiftOnDifferentDaysForStandardRequestOnDayAndNight()
        {
            WorkPermitEdmontonService workPermitEdmontonService = new WorkPermitEdmontonService(mockWorkPermitDao, null, null, null, null, null, null, null, null, null, null, null, null);
            PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            permitRequest.Id = 1234;
            permitRequest.RequestedStartDate = new Date(2012, 10, 31);
            permitRequest.RequestedStartTimeDay = new Time(8);
            permitRequest.RequestedStartTimeNight = new Time(1);

            List<PermitRequestEdmontonDTO> requests = new List<PermitRequestEdmontonDTO> { new PermitRequestEdmontonDTO(permitRequest) };
            Date workPermitStartDate = new Date(2012, 11, 01);

            Range<DateTime> shiftRangeForDayPermits = new Range<DateTime>(new DateTime(2012, 11, 01, 7, 0, 0), new DateTime(2012, 11, 01, 19, 0, 0));
            Range<DateTime> shiftRangeForNightPermits = new Range<DateTime>(new DateTime(2012, 10, 31, 19, 0, 0), new DateTime(2012, 11, 01, 7, 0, 0));

            mockWorkPermitDao.Expect(dao => dao.DoesPermitRequestEdmontonAssociationExist(new List<long> { 1234 }, shiftRangeForDayPermits)).Return(false);
            mockWorkPermitDao.Expect(dao => dao.DoesPermitRequestEdmontonAssociationExist(new List<long> { 1234 }, shiftRangeForNightPermits)).Return(false);
            bool result = workPermitEdmontonService.DoesPermitRequestEdmontonAssociationExist(requests, workPermitStartDate);
            Assert.IsFalse(result);
        }

    }
}