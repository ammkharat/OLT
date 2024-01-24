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
    public class FormGN59Test
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
        public void CloneShouldNotIncludeCertainFields()
        {
            var floc = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var someUser = UserFixture.CreateUserWithGivenId(1);
            var someOtherUser = UserFixture.CreateUserWithGivenId(2);

            Clock.Now = new DateTime(2012, 10, 2, 9, 0, 0);
            var validFromDateTime = new DateTime(2012, 10, 1);
            var validToDateTime = new DateTime(2012, 10, 2);

            var form = FormGN59Fixture.CreateForInsert(new List<FunctionalLocation> {floc}, validFromDateTime, validToDateTime, FormStatus.Approved);
            form.Id = 22;
            form.LastModifiedBy = someUser;
            form.LastModifiedDateTime = Clock.Now.AddHours(-3);
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "approver 1", someUser, new DateTime(2012, 1, 3, 13, 0, 0), null, 1));
            form.Approvals.Add(new FormApproval(null, null, "approver 2", someUser, new DateTime(2012, 1, 1, 10, 0, 0), null, 2));
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

            Assert.AreEqual(2, form.Approvals.Count);
            var unapprovedApprovals = form.Approvals.FindAll(approval => !approval.IsApproved);
            Assert.AreEqual(2, unapprovedApprovals.Count);
        }

        [Test]
        public void CreateDTOShouldMakeTheRemainingApprovalsListCorrectly()
        {
            var floc = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var someUser = UserFixture.CreateUserWithGivenId(1);

            var form = FormGN59Fixture.CreateForInsert(new List<FunctionalLocation> {floc}, new DateTime(2012, 10, 1), new DateTime(2012, 10, 2), FormStatus.Draft);
            form.Id = 22;
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "approver 1", null, null, null, 1));
            form.Approvals.Add(new FormApproval(null, null, "approver 2", someUser, new DateTime(2012, 1, 1, 10, 0, 0), null, 2));
            form.Approvals.Add(new FormApproval(null, null, "approver 3", someUser, new DateTime(2012, 1, 1, 10, 0, 0), null, 3));
            form.Approvals.Add(new FormApproval(null, null, "approver 4", null, null, null, 4));

            var formDto = (FormEdmontonDTO) form.CreateDTO();

            Assert.AreEqual(2, formDto.RemainingApprovals.Count);
            Assert.AreEqual("approver 1", formDto.RemainingApprovals[0]);
            Assert.AreEqual("approver 4", formDto.RemainingApprovals[1]);
        }

        [Test]
        public void HistorySnapshotShouldIncludeDocumentLinks()
        {
            var form = FormGN59Fixture.CreateFormWithExistingId();
            form.DocumentLinks = new List<DocumentLink> {DocumentLinkFixture.CreateNewDocumentLink()};

            var history = form.TakeSnapshot();

            Assert.AreEqual("Title for document (http:\\URL for Document)", history.DocumentLinks);
        }

        [Test]
        public void ShouldTestForWorkPermitsWithinFormStartAndEndDates()
        {
            var january4WorkPermit = WorkPermitEdmontonFixture.CreateForInsert(new DateTime(2014, 01, 04, 12, 0, 0), new DateTime(2014, 01, 04, 12, 0, 0));

            {
                var form = FormGN59Fixture.CreateForInsert(new List<FunctionalLocation>(0),
                    new DateTime(2014, 01, 01, 12, 0, 0),
                    new DateTime(2014, 01, 01, 12, 0, 0),
                    FormStatus.Approved);
                Assert.That(form.IsWorkPermitDatesWithinFormDates(january4WorkPermit), Is.False);
            }
            {
                var form = FormGN59Fixture.CreateForInsert(new List<FunctionalLocation>(0),
                    new DateTime(2014, 01, 05, 12, 0, 0),
                    new DateTime(2014, 01, 13, 12, 0, 0),
                    FormStatus.Approved);
                Assert.That(form.IsWorkPermitDatesWithinFormDates(january4WorkPermit), Is.False);
            }
            {
                var form = FormGN59Fixture.CreateForInsert(new List<FunctionalLocation>(0),
                    new DateTime(2014, 01, 01, 12, 0, 0),
                    new DateTime(2014, 01, 13, 12, 0, 0),
                    FormStatus.Approved);
                Assert.That(form.IsWorkPermitDatesWithinFormDates(january4WorkPermit), Is.True);
            }

            var january4To20WorkPermit = WorkPermitEdmontonFixture.CreateForInsert(new DateTime(2014, 01, 04, 12, 0, 0), new DateTime(2014, 01, 20, 12, 0, 0));
            {
                var form = FormGN59Fixture.CreateForInsert(new List<FunctionalLocation>(0),
                    new DateTime(2014, 01, 01, 12, 0, 0),
                    new DateTime(2014, 01, 13, 12, 0, 0),
                    FormStatus.Approved);
                Assert.That(form.IsWorkPermitDatesWithinFormDates(january4To20WorkPermit), Is.False);
            }
            {
                var form = FormGN59Fixture.CreateForInsert(new List<FunctionalLocation>(0),
                    new DateTime(2014, 01, 01, 12, 0, 0),
                    new DateTime(2014, 01, 20, 12, 0, 0),
                    FormStatus.Approved);
                Assert.That(form.IsWorkPermitDatesWithinFormDates(january4To20WorkPermit), Is.True);
            }
            {
                var january1EarlyMorningWorkPermit = WorkPermitEdmontonFixture.CreateForInsert(new DateTime(2014, 01, 01, 02, 0, 0),
                    new DateTime(2014, 01, 01, 08, 0, 0));
                var form = FormGN59Fixture.CreateForInsert(new List<FunctionalLocation>(0),
                    new DateTime(2014, 01, 01, 08, 0, 0),
                    new DateTime(2014, 01, 01, 20, 0, 0),
                    FormStatus.Approved);
                Assert.That(form.IsWorkPermitDatesWithinFormDates(january1EarlyMorningWorkPermit), Is.False);
            }
            {
                var january1EarlyMorningWorkPermit = WorkPermitEdmontonFixture.CreateForInsert(new DateTime(2014, 01, 01, 02, 0, 0),
                    new DateTime(2014, 01, 01, 08, 0, 0));
                var form = FormGN59Fixture.CreateForInsert(new List<FunctionalLocation>(0),
                    new DateTime(2014, 01, 01, 01, 0, 0),
                    new DateTime(2014, 01, 01, 08, 0, 0),
                    FormStatus.Approved);
                Assert.That(form.IsWorkPermitDatesWithinFormDates(january1EarlyMorningWorkPermit), Is.True);
            }
            {
                var january1MorningWorkPermit = WorkPermitEdmontonFixture.CreateForInsert(new DateTime(2014, 01, 01, 08, 0, 0), new DateTime(2014, 01, 01, 12, 0, 0));
                var form = FormGN59Fixture.CreateForInsert(new List<FunctionalLocation>(0),
                    new DateTime(2014, 01, 01, 08, 0, 0),
                    new DateTime(2014, 01, 01, 20, 0, 0),
                    FormStatus.Approved);
                Assert.That(form.IsWorkPermitDatesWithinFormDates(january1MorningWorkPermit), Is.True);
            }
            {
                var january1AfternoonWorkPermit = WorkPermitEdmontonFixture.CreateForInsert(new DateTime(2014, 01, 01, 12, 0, 0),
                    new DateTime(2014, 01, 01, 20, 0, 0));
                var form = FormGN59Fixture.CreateForInsert(new List<FunctionalLocation>(0),
                    new DateTime(2014, 01, 01, 08, 0, 0),
                    new DateTime(2014, 01, 01, 20, 0, 0),
                    FormStatus.Approved);
                Assert.That(form.IsWorkPermitDatesWithinFormDates(january1AfternoonWorkPermit), Is.True);
            }
            {
                var january1EveningWorkPermit = WorkPermitEdmontonFixture.CreateForInsert(new DateTime(2014, 01, 01, 20, 0, 0), new DateTime(2014, 01, 01, 23, 0, 0));
                var form = FormGN59Fixture.CreateForInsert(new List<FunctionalLocation>(0),
                    new DateTime(2014, 01, 01, 20, 0, 0),
                    new DateTime(2014, 01, 01, 23, 0, 0),
                    FormStatus.Approved);
                Assert.That(form.IsWorkPermitDatesWithinFormDates(january1EveningWorkPermit), Is.True);
            }
        }
    }
}