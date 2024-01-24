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
    public class FormGN7Test
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

            var form = FormGN7Fixture.CreateForInsert(new List<FunctionalLocation> {floc},
                validFromDateTime,
                validToDateTime,
                FormStatus.Approved);
            form.Id = 22;
            form.LastModifiedBy = someUser;
            form.LastModifiedDateTime = Clock.Now.AddHours(-3);
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

            Assert.AreEqual(2, form.Approvals.Count);
            var unapprovedApprovals = form.Approvals.FindAll(approval => !approval.IsApproved);
            Assert.AreEqual(2, unapprovedApprovals.Count);
        }

        [Test]
        public void CreateDTOShouldMakeTheRemainingApprovalsListCorrectly()
        {
            var floc = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var someUser = UserFixture.CreateUserWithGivenId(1);

            var form = FormGN7Fixture.CreateForInsert(new List<FunctionalLocation> {floc},
                new DateTime(2012, 10, 1),
                new DateTime(2012, 10, 2),
                FormStatus.Draft);
            form.Id = 22;
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "approver 1", null, null, null, 1));
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

            Assert.AreEqual(2, formDto.RemainingApprovals.Count);
            Assert.AreEqual("approver 1", formDto.RemainingApprovals[0]);
            Assert.AreEqual("approver 4", formDto.RemainingApprovals[1]);
        }

        [Test]
        public void HistorySnapshotShouldIncludeDocumentLinks()
        {
            var form = FormGN7Fixture.CreateFormWithExistingId();
            form.DocumentLinks = new List<DocumentLink> {DocumentLinkFixture.CreateNewDocumentLink()};

            var history = form.TakeSnapshot();

            Assert.AreEqual("Title for document (http:\\URL for Document)", history.DocumentLinks);
        }

        [Test]
        public void HistorySnapshotShouldIncludeUsernameAsPartOfApprovals()
        {
            var user1 = UserFixture.CreateUser("username1", "firstname1", "lastname1");
            var user2 = UserFixture.CreateUser("username2", "firstname2", "lastname2");

            var form = FormGN7Fixture.CreateFormWithExistingId();
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "Approver Name 1", user1, Clock.Now, null, 1));
            form.Approvals.Add(new FormApproval(null, null, "Approver Name 2", user2, Clock.Now, null, 2));

            var history = form.TakeSnapshot();

            Assert.AreEqual("Approver Name 1 (username1), Approver Name 2 (username2)", history.Approvals);
        }

        [Test]
        public void ShouldKnowWhenReapprovalIsNeeded()
        {
            var floc = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            floc.Id = 22;

            var someUser = UserFixture.CreateUserWithGivenId(1);
            var someOtherUser = UserFixture.CreateUserWithGivenId(2);

            var validFromDateTime = new DateTime(2012, 10, 1);
            var validToDateTime = new DateTime(2012, 10, 2);

            var form = FormGN7Fixture.CreateForInsert(new List<FunctionalLocation> {floc},
                validFromDateTime,
                validToDateTime,
                FormStatus.Approved);
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

            // change content
            {
                var willNeedReapproval = form.WillNeedReapproval(form.PlainTextContent + "a",
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    someOtherUser);
                Assert.IsTrue(willNeedReapproval);
            }

            // change stuff but the current user is the one who approved it all in the first place
            {
                var willNeedReapproval = form.WillNeedReapproval(form.PlainTextContent + "a",
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    someUser);
                Assert.IsFalse(willNeedReapproval);
            }

            // change valid from
            {
                var willNeedReapproval = form.WillNeedReapproval(form.PlainTextContent,
                    form.FromDateTime.AddDays(1),
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    someOtherUser);
                Assert.IsTrue(willNeedReapproval);
            }

            // change valid to
            {
                var willNeedReapproval = form.WillNeedReapproval(form.PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime.AddDays(1),
                    new List<FunctionalLocation> {floc},
                    someOtherUser);
                Assert.IsTrue(willNeedReapproval);
            }

            // change floc
            {
                var anotherFloc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
                anotherFloc.Id = 55;

                var willNeedReapproval = form.WillNeedReapproval(form.PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {anotherFloc},
                    someOtherUser);
                Assert.IsTrue(willNeedReapproval);
            }

            // nothing has changed
            {
                var willNeedReapproval = form.WillNeedReapproval(form.PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    someOtherUser);
                Assert.IsFalse(willNeedReapproval);
            }
        }
    }
}