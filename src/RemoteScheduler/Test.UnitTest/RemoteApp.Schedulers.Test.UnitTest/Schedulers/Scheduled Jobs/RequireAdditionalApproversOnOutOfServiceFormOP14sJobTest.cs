using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Scheduled_Jobs
{
    [TestFixture]
    public class RequireAdditionalApproversOnOutOfServiceFormOP14sJobTest
    {
        private IFormEdmontonService mockFormService;
        private ISiteService mockSiteService;
        private ITimeService mockTimeService;
        private IUserService mockUserService;

        [SetUp]
        public void Setup()
        {
            mockFormService = MockRepository.GenerateMock<IFormEdmontonService>();
            mockTimeService = MockRepository.GenerateStub<ITimeService>();
            mockSiteService = MockRepository.GenerateStub<ISiteService>();
            mockUserService = MockRepository.GenerateStub<IUserService>();

            Clock.Freeze();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldPutFormsInDraftModeWhenTheyHaveBecomeOutOfService()
        {
            Clock.Now = new DateTime(2012, 10, 13, 16, 0, 0);

            var systemUser = UserFixture.CreateUserWithGivenId(1);

            var job = new RequireAdditionalApproversOnOutOfServiceFormOP14sJob(
                RecurringDailyScheduleFixture.CreateEvery1DaysFrom5PMTo6PMWithyNoEndDateStarting2006June15(),
                mockFormService,
                mockTimeService,
                mockSiteService,
                mockUserService);

            mockTimeService.Stub(m => m.GetTime(null)).IgnoreArguments().Return(Clock.Now);
            mockUserService.Stub(m => m.GetRemoteAppUser()).Return(systemUser);
            mockSiteService.Stub(m => m.QueryById(Site.EDMONTON_ID)).Return(SiteFixture.Edmonton());


            // this form should be updated because 'now - ValidFromDateTime' > 10 days and there are approvals that are disabled but should now become enabled
            var formOne = FormOP14Fixture.CreateFormWithExistingId();
            formOne.FormStatus = FormStatus.Approved;
            formOne.ApprovedDateTime = new DateTime(2012, 10, 1, 13, 0, 0);
            formOne.FromDateTime = new DateTime(2012, 10, 1, 16, 0, 0);
            formOne.ToDateTime = new DateTime(2012, 10, 5, 16, 0, 0);
            formOne.IsTheCSDForAPressureSafetyValve = false;
            formOne.Approvals.Clear();
            formOne.Approvals.Add(new FormApproval(null, formOne.Id, "approvertitle1", null, null, null, 1,
                ApprovalShouldBeEnabledBehaviour.TenDayValidity, false));
            formOne.Approvals.Add(new FormApproval(null, formOne.Id, "approvertitle2", null, null, null, 2,
                ApprovalShouldBeEnabledBehaviour.TenDayValidity, false));
            formOne.Approvals.Add(new FormApproval(null, formOne.Id, "approvertitle3", null, null, null, 3,
                ApprovalShouldBeEnabledBehaviour.OP14PressureSafetyValve, false));

            // this next form should not get updated because its approvals are already enabled when appropriate
            var formTwo = FormOP14Fixture.CreateAnotherFormWithExistingId();
            formTwo.FormStatus = FormStatus.Approved;
            formTwo.ApprovedDateTime = new DateTime(2012, 10, 1, 13, 0, 0);
            formTwo.FromDateTime = new DateTime(2012, 10, 1, 16, 0, 0);
            formTwo.ToDateTime = new DateTime(2012, 10, 14, 16, 0, 0);
            formTwo.IsTheCSDForAPressureSafetyValve = false;
            formTwo.Approvals.Clear();
            formTwo.Approvals.Add(new FormApproval(null, formTwo.Id, "approvertitle1", systemUser,
                new DateTime(2012, 10, 1, 16, 0, 0), null, 1, ApprovalShouldBeEnabledBehaviour.TenDayValidity, true));
            formTwo.Approvals.Add(new FormApproval(null, formTwo.Id, "approvertitle2", systemUser,
                new DateTime(2012, 10, 1, 16, 0, 0), null, 2, ApprovalShouldBeEnabledBehaviour.TenDayValidity, true));
            formTwo.Approvals.Add(new FormApproval(null, formTwo.Id, "approvertitle3", null, null, null, 3,
                ApprovalShouldBeEnabledBehaviour.OP14PressureSafetyValve, false));

            mockFormService.Stub(m => m.QueryAllFormOP14sThatAreApprovedAndAreMoreThan10DaysOutOfService(Clock.Now))
                .Return(new List<FormOP14> {formOne, formTwo});

            mockFormService.Expect(m => m.UpdateOP14(formOne)).Return(null).Repeat.Once();
            mockFormService.Expect(m => m.UpdateOP14(formTwo)).Return(null).Repeat.Never();

            job.Execute();
            mockFormService.VerifyAllExpectations();

            Assert.AreEqual(FormStatus.Draft, formOne.FormStatus);
            Assert.IsNull(formOne.ApprovedDateTime);

            Assert.AreEqual(FormStatus.Approved, formTwo.FormStatus);
            Assert.IsNotNull(formTwo.ApprovedDateTime);
        }
    }
}