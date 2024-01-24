using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [TestFixture]
    public class FormOP14Test
    {
        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void AllApprovalsAreInShouldIgnoreDisabledOnes()
        {
            var someUser = UserFixture.CreateUserWithGivenId(1);

            var form = FormOP14Fixture.CreateFormWithExistingId();

            {
                form.Approvals.Clear();
                form.Approvals.Add(new FormApproval(null,
                    null,
                    "approver 1",
                    someUser,
                    new DateTime(2012, 1, 3, 13, 0, 0),
                    null,
                    1,
                    ApprovalShouldBeEnabledBehaviour.Always,
                    true));
                form.Approvals.Add(new FormApproval(null,
                    null,
                    "approver 2",
                    null,
                    null,
                    null,
                    2,
                    ApprovalShouldBeEnabledBehaviour.TenDayValidity,
                    false));

                Assert.IsTrue(form.AllApprovalsAreIn());
            }

            {
                form.Approvals.Clear();
                form.Approvals.Add(new FormApproval(null,
                    null,
                    "approver 1",
                    someUser,
                    new DateTime(2012, 1, 3, 13, 0, 0),
                    null,
                    1,
                    ApprovalShouldBeEnabledBehaviour.Always,
                    true));
                form.Approvals.Add(new FormApproval(null,
                    null,
                    "approver 2",
                    null,
                    null,
                    null,
                    2,
                    ApprovalShouldBeEnabledBehaviour.TenDayValidity,
                    true));

                Assert.IsFalse(form.AllApprovalsAreIn());
            }
        }

        [Test]
        public void CloneShouldNotIncludeCertainFields()
        {
            var floc = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var someUser = UserFixture.CreateUserWithGivenId(1);
            var someOtherUser = UserFixture.CreateUserWithGivenId(2);

            Clock.Now = new DateTime(2012, 10, 2, 9, 0, 0);
            var validFromDateTime = new DateTime(2012, 10, 1);
            var validToDateTime = new DateTime(2012, 10, 2);

            var form = FormOP14Fixture.CreateForInsert(new List<FunctionalLocation> {floc},
                validFromDateTime,
                validToDateTime,
                FormStatus.Approved);
            form.Id = 22;
            form.LastModifiedBy = someUser;
            form.LastModifiedDateTime = Clock.Now.AddHours(-3);
            form.IsTheCSDForAPressureSafetyValve = true;
            form.Department = FormOP14Department.Operations;
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null,
                null,
                "approver 1",
                someUser,
                new DateTime(2012, 1, 3, 13, 0, 0),
                null,
                1));
            form.Approvals.Add(new FormApproval(null,
                null,
                "approver 2",
                someUser,
                new DateTime(2012, 1, 1, 10, 0, 0),
                null,
                2));
            form.DocumentLinks = new List<DocumentLink> {DocumentLinkFixture.CreateNewDocumentLink()};

            Clock.Now = Clock.Now.AddHours(1);
            form.ConvertToClone(someOtherUser);

            Assert.IsNull(form.ApprovedDateTime);
            Assert.IsNull(form.ClosedDateTime);
            Assert.IsNull(form.Id);
            Assert.AreEqual(someOtherUser.Id, form.LastModifiedBy.Id);
            Assert.AreEqual(Clock.Now, form.LastModifiedDateTime);
            Assert.AreEqual(Clock.Now, form.CreatedDateTime);
            Assert.AreEqual(someOtherUser.Id, form.CreatedBy.Id);

            Assert.AreEqual("Title for document (http:\\URL for Document)", form.DocumentLinks.First().TitleWithUrl);

            Assert.AreEqual(Clock.Now, form.FromDateTime);
            var expectedToDateTime = new Date(Clock.Now).CreateDateTime(WorkPermitEdmonton.NightShiftStartTime);
            Assert.AreEqual(expectedToDateTime, form.ToDateTime);

            Assert.AreEqual(FormStatus.Draft, form.FormStatus);
            Assert.AreEqual(FormOP14Department.Operations, form.Department);
            Assert.AreEqual(true, form.IsTheCSDForAPressureSafetyValve);

            Assert.AreEqual(2, form.Approvals.Count);
            var unapprovedApprovals = form.Approvals.FindAll(approval => !approval.IsApproved);
            Assert.AreEqual(2, unapprovedApprovals.Count);
        }

        [Test]
        public void CreateDTOShouldNotIncludeDisabledApprovalsInRemainingApprovalsList()
        {
            var floc = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var someUser = UserFixture.CreateUserWithGivenId(1);

            var form = FormGN7Fixture.CreateForInsert(new List<FunctionalLocation> {floc},
                new DateTime(2012, 10, 1),
                new DateTime(2012, 10, 2),
                FormStatus.Draft);
            form.Id = 22;
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null,
                null,
                "approver 1",
                null,
                null,
                null,
                1,
                ApprovalShouldBeEnabledBehaviour.OP14PressureSafetyValve,
                false));
            form.Approvals.Add(new FormApproval(null,
                null,
                "approver 2",
                someUser,
                new DateTime(2012, 1, 1, 10, 0, 0),
                null,
                2));
            form.Approvals.Add(new FormApproval(null,
                null,
                "approver 3",
                someUser,
                new DateTime(2012, 1, 1, 10, 0, 0),
                null,
                3));
            form.Approvals.Add(new FormApproval(null, null, "approver 4", null, null, null, 4));

            var formDto = (FormEdmontonDTO) form.CreateDTO();

            Assert.AreEqual(1, formDto.RemainingApprovals.Count);
            Assert.AreEqual("approver 4", formDto.RemainingApprovals[0]);
        }

        [Test]
        public void HistorySnapshotShouldIncludeDocumentLinks()
        {
            var form = FormOP14Fixture.CreateFormWithExistingId();
            form.DocumentLinks = new List<DocumentLink> {DocumentLinkFixture.CreateNewDocumentLink()};

            var history = form.TakeSnapshot();

            Assert.AreEqual("Title for document (http:\\URL for Document)", history.DocumentLinks);
        }

        [Test]
        public void ShouldIndicateWhenDoesNotItRequiresApprovalBecauseBackInServiceDateIsInPast()
        {
            var form = FormOP14Fixture.CreateFormWithExistingId();

            form.ToDateTime = Clock.Now.AddHours(-1);

            Assert.IsFalse(form.IsActiveAndRequiresApproval(Clock.Now));
        }

        [Test]
        public void ShouldIndicateWhenDoesNotItRequiresApprovalBecauseSystemDefeatedDateIsInFuture()
        {
            var form = FormOP14Fixture.CreateFormWithExistingId();

            form.FromDateTime = Clock.Now.AddDays(10);
            form.ToDateTime = Clock.Now.AddDays(20);

            Assert.IsFalse(form.IsActiveAndRequiresApproval(Clock.Now));
        }

        [Test]
        public void ShouldIndicateWhenItDoesNotRequiresApprovalBecauseStatusIsNotDraft()
        {
            var form = FormOP14Fixture.CreateFormWithExistingId();

            form.FormStatus = FormStatus.Approved;

            Assert.IsFalse(form.IsActiveAndRequiresApproval(Clock.Now));
        }

        [Test][Ignore]
        public void ShouldIndicateWhenItRequiresApproval()
        {
            var form = FormOP14Fixture.CreateFormWithExistingId();

            Assert.IsTrue(form.IsActiveAndRequiresApproval(Clock.Now));
        }

        [Test]
        public void ShouldNotNeedReapprovalIfAllApprovalsAreByCurrentUserEvenIfDepartmentHasChanged()
        {
            var currentUser = UserFixture.CreateUserWithGivenId(1);
            var otherUser = UserFixture.CreateUserWithGivenId(2);

            var form = FormOP14Fixture.CreateFormWithExistingId();
            form.Department = FormOP14Department.Operations;
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "approvertitle1", currentUser, DateTime.Now, null, 1));
            form.Approvals.Add(new FormApproval(null, null, "approvertitle2", currentUser, DateTime.Now, null, 2));

            // form should not need reapproval for the changed department because the only approvals are by the user making the change
            {
                Assert.IsFalse(form.WillNeedReapproval(form.Content,
                    form.FromDateTime,
                    form.ToDateTime,
                    form.FunctionalLocations,
                    currentUser,
                    FormOP14Department.Maintenance,
                    form.IsTheCSDForAPressureSafetyValve,
                    form.CriticalSystemDefeated));
            }

            // add another approver that isn't the current user and ensure that the form will need reapproval for the changed department
            {
                form.Approvals.Add(new FormApproval(null, null, "approvertitle3", otherUser, DateTime.Now, null, 3));
                Assert.IsTrue(form.WillNeedReapproval(form.Content,
                    form.FromDateTime,
                    form.ToDateTime,
                    form.FunctionalLocations,
                    currentUser,
                    FormOP14Department.Maintenance,
                    form.IsTheCSDForAPressureSafetyValve,
                    form.CriticalSystemDefeated));
            }
        }
    }
}