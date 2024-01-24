using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Scheduled_Jobs
{
    [TestFixture]
    public class ShiftHandoverEmailJobTest
    {
        [Test]
        public void ShouldHandleVariousOtherNightShiftScenarios()
        {
            // 11pm on the 7th
            Assert.IsTrue(Scenario(new Date(2013, 10, 7), new DateTime(2013, 10, 7, 23, 0, 0), new Time(23, 0, 0),
                ShiftPatternFixture.CreateOilsandsNightShift8pmTo8am()));

            var dayShiftEndingAtMidnight = ShiftPatternFixture.CreateShiftPattern(new Time(12), new Time(0));
            Assert.IsTrue(Scenario(new Date(2013, 10, 7), new DateTime(2013, 10, 8, 0, 0, 1), new Time(0, 0, 0),
                dayShiftEndingAtMidnight));
            //Assert.IsTrue(Scenario(new Date(2013, 10, 7), new DateTime(2013, 10, 8, 0, 0, 1), new Time(23, 59, 0), dayShiftEndingAtMidnight)); This is the edge case that we don't know how to handle.
        }

        [Test]
        public void ShouldSendEmailsForTheNightShiftWhenTheTimeIsSetTo7AndTheShiftEndsAt8()
        {
            Assert.IsTrue(Scenario(new Date(2013, 10, 7), new DateTime(2013, 10, 8, 7, 6, 0), new Time(7, 6),
                ShiftPatternFixture.CreateOilsandsNightShift8pmTo8am()));
        }

        [Test]
        public void ShouldSendEmailsForTheNightShiftWhenTheTimeIsSetTo8AndTheShiftEndsAt8()
        {
            Assert.IsTrue(Scenario(new Date(2013, 10, 7), new DateTime(2013, 10, 8, 8, 0, 0), new Time(8),
                ShiftPatternFixture.CreateOilsandsNightShift8pmTo8am()));
        }

        private bool Scenario(Date expectedUserShiftStartDate, DateTime timeRightNow, Time emailSendTime,
            ShiftPattern patternForConfiguration)
        {
            Clock.Freeze();
            Clock.Now = timeRightNow; //new DateTime(2013, 10, 8, 8, 0, 0);

            // patternForConfiguration = ShiftPatternFixture.CreateOilsandsNightShmTo8amift8p();
            var emailAddresses = new List<EmailAddress> {new EmailAddress("abc@abc.zz")};
            var workAssignment =
                WorkAssignmentFixture.CreateOilsandsWorkAssignmentToBeInsertedInDatabase("Oilsands Assignment");
            workAssignment.Id = -99;
            var workAssignments = new List<WorkAssignment> {workAssignment};

            var shiftHandoverEmailConfiguration = new ShiftHandoverEmailConfiguration(patternForConfiguration,
                emailSendTime, emailAddresses, workAssignments, SiteFixture.Oilsands());
            shiftHandoverEmailConfiguration.Id = 42;

            var shiftHandoverService = MockRepository.GenerateMock<IShiftHandoverService>();
            var logService = MockRepository.GenerateStub<ILogService>();
            var summaryLogService = MockRepository.GenerateStub<ISummaryLogService>();
            var actionItemDefinitionService = MockRepository.GenerateStub<IActionItemDefinitionService>();
            var shiftPatternService = MockRepository.GenerateStub<IShiftPatternService>();
            var actionItemService = MockRepository.GenerateStub<IActionItemService>();
            var excursionResponseService = MockRepository.GenerateStub<IExcursionResponseService>();
            var flocOperationalModeService = MockRepository.GenerateStub<IFunctionalLocationOperationalModeService>();
            var cokerCardService = MockRepository.GenerateStub<ICokerCardService>();
            var siteConfigurationService = MockRepository.GenerateStub<ISiteConfigurationService>();
            var timeService = MockRepository.GenerateStub<ITimeService>();
            var lubesCsdService = MockRepository.GenerateStub<IFormEdmontonService>();

            shiftHandoverService.Stub(s => s.QueryShiftHandoverEmailConfigurationById(42))
                .Return(shiftHandoverEmailConfiguration);
            siteConfigurationService.Stub(service => service.QueryBySiteId(3))
                .Return(SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Oilsands()));

            // Today's date is the 8th, but the night shift started the day before, so the start date of the UserShift should be 7.
            shiftHandoverService.Expect(
                s =>
                    s.QueryByWorkAssignmentAndShift(Arg<long>.Is.Anything,
                        Arg<UserShift>.Matches(us => us.StartDate.Equals(expectedUserShiftStartDate))))
                .Return(new List<ShiftHandoverQuestionnaire>());

            var job = new ShiftHandoverEmailJob(
                shiftHandoverEmailConfiguration,
                shiftHandoverService,
                actionItemDefinitionService,
                shiftPatternService,
                actionItemService,
                excursionResponseService,
                lubesCsdService,
                flocOperationalModeService,
                siteConfigurationService,
                timeService);

            job.Execute();

            shiftHandoverService.VerifyAllExpectations();

            Clock.UnFreeze();

            return true;
        }
    }
}