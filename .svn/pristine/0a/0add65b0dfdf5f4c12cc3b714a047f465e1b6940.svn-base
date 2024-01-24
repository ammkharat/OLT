using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [TestFixture]
    public class FormGN6Test
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
        public void CloningShouldCloneTheDocumentLinksButNullOutTheIds()
        {
            var form = FormGN6Fixture.CreateFormWithExistingId();
            form.DocumentLinks.Clear();
            form.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink(1));
            form.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink(2));

            form.ConvertToClone(UserFixture.CreateAdmin());

            Assert.AreEqual(2, form.DocumentLinks.Count);
            Assert.IsTrue(form.DocumentLinks.TrueForAll(link => link.Id == null));
        }

        [Test]
        public void ShouldKnowWhenElectricalReapprovalIsNeeded()
        {
            var floc = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            floc.Id = 22;

            var someUser = UserFixture.CreateUserWithGivenId(1);
            var someOtherUser = UserFixture.CreateUserWithGivenId(2);

            var validFromDateTime = new DateTime(2012, 10, 1);
            var validToDateTime = new DateTime(2012, 10, 2);

            var form = FormGN6Fixture.CreateForInsert(new List<FunctionalLocation> {floc}, validFromDateTime, validToDateTime, FormStatus.Approved);
            form.Approvals.ForEach(approval => approval.ApprovedByUser = someUser);

            // section 3 changed
            {
                var willNeedReapproval = form.WillNeedElectricalReapproval(form.Section3NotApplicableToJob, form.Section3PlainTextContent + "a", someOtherUser);
                Assert.IsTrue(willNeedReapproval);
            }

            // section 3 changed but by the user who approved it in the first place
            {
                var willNeedReapproval = form.WillNeedElectricalReapproval(!form.Section3NotApplicableToJob, form.Section3PlainTextContent + "a", someUser);
                Assert.IsFalse(willNeedReapproval);
            }

            // section 3 didn't change
            {
                var willNeedReapproval = form.WillNeedElectricalReapproval(form.Section3NotApplicableToJob, form.Section3PlainTextContent, someOtherUser);
                Assert.IsFalse(willNeedReapproval);
            }
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

            var form = FormGN6Fixture.CreateForInsert(new List<FunctionalLocation> {floc}, validFromDateTime, validToDateTime, FormStatus.Approved);
            form.DocumentLinks.Clear();
            form.DocumentLinks.Add(new DocumentLink("http://google.ca", "the goog"));
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "approver 1", someUser, new DateTime(2012, 1, 3, 13, 0, 0), null, 1));
            form.Approvals.Add(new FormApproval(null, null, "approver 2", someUser, new DateTime(2012, 1, 1, 10, 0, 0), null, 2));

            // change job description
            {
                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription + "a",
                    form.ReasonForCriticalLift,
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    form.DocumentLinks,
                    someOtherUser,
                    false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change stuff but the current user is the one who approved it all in the first place
            {
                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription + "a",
                    form.ReasonForCriticalLift,
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    form.DocumentLinks,
                    someUser,
                    false);
                Assert.IsFalse(willNeedReapproval);
            }

            // change reason for critical lift
            {
                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription,
                    form.ReasonForCriticalLift + "a",
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    form.DocumentLinks,
                    someOtherUser,
                    false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change section 1 not applicable
            {
                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription,
                    form.ReasonForCriticalLift,
                    !form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    form.DocumentLinks,
                    someOtherUser,
                    false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change section 1 content
            {
                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription,
                    form.ReasonForCriticalLift,
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent + "a",
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    form.DocumentLinks,
                    someOtherUser,
                    false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change section 2 not applicable
            {
                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription,
                    form.ReasonForCriticalLift,
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    !form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    form.DocumentLinks,
                    someOtherUser,
                    false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change section 2 content
            {
                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription,
                    form.ReasonForCriticalLift,
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent + "a",
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    form.DocumentLinks,
                    someOtherUser,
                    false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change section 3 not applicable
            {
                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription,
                    form.ReasonForCriticalLift,
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    !form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    form.DocumentLinks,
                    someOtherUser,
                    false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change section 3 content
            {
                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription,
                    form.ReasonForCriticalLift,
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent + "a",
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    form.DocumentLinks,
                    someOtherUser,
                    false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change section 4 not applicable
            {
                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription,
                    form.ReasonForCriticalLift,
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    !form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    form.DocumentLinks,
                    someOtherUser,
                    false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change section 4 content
            {
                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription,
                    form.ReasonForCriticalLift,
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent + "a",
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    form.DocumentLinks,
                    someOtherUser,
                    false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change section 5 not applicable
            {
                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription,
                    form.ReasonForCriticalLift,
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    !form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    form.DocumentLinks,
                    someOtherUser,
                    false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change section 5 content
            {
                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription,
                    form.ReasonForCriticalLift,
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent + "a",
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    form.DocumentLinks,
                    someOtherUser,
                    false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change section 6 not applicable
            {
                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription,
                    form.ReasonForCriticalLift,
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    !form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    form.DocumentLinks,
                    someOtherUser,
                    false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change section 6 content
            {
                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription,
                    form.ReasonForCriticalLift,
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent + "a",
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    form.DocumentLinks,
                    someOtherUser,
                    false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change valid from
            {
                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription,
                    form.ReasonForCriticalLift,
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime.AddDays(-1),
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    form.DocumentLinks,
                    someOtherUser,
                    false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change valid to
            {
                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription,
                    form.ReasonForCriticalLift,
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime.AddDays(1),
                    new List<FunctionalLocation> {floc},
                    form.DocumentLinks,
                    someOtherUser,
                    false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change floc
            {
                var anotherFloc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
                anotherFloc.Id = 55;

                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription,
                    form.ReasonForCriticalLift,
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {anotherFloc},
                    form.DocumentLinks,
                    someOtherUser,
                    false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change the document links
            {
                var documentLinks = new List<DocumentLink>();
                documentLinks.Add(new DocumentLink("http://google.com", "the us goog"));

                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription,
                    form.ReasonForCriticalLift,
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    documentLinks,
                    someOtherUser,
                    false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change just the end date/time without being someone who can do that and not need reapproval
            {
                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription,
                    form.ReasonForCriticalLift,
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime.AddDays(1),
                    new List<FunctionalLocation> {floc},
                    form.DocumentLinks,
                    someOtherUser,
                    false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change just the end date/time as someone who can do that and not need reapproval
            {
                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription,
                    form.ReasonForCriticalLift,
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime.AddDays(1),
                    new List<FunctionalLocation> {floc},
                    form.DocumentLinks,
                    someOtherUser,
                    true);
                Assert.IsFalse(willNeedReapproval);
            }

            // as someone who can change the end date without needing reapproval, change both the end date and something else
            {
                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription + "a",
                    form.ReasonForCriticalLift,
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime.AddDays(1),
                    new List<FunctionalLocation> {floc},
                    form.DocumentLinks,
                    someOtherUser,
                    true);
                Assert.IsTrue(willNeedReapproval);
            }

            // nothing has changed
            {
                var willNeedReapproval = form.WillNeedReapproval(form.JobDescription,
                    form.ReasonForCriticalLift,
                    form.Section1NotApplicableToJob,
                    form.Section1PlainTextContent,
                    form.Section2NotApplicableToJob,
                    form.Section2PlainTextContent,
                    form.Section3NotApplicableToJob,
                    form.Section3PlainTextContent,
                    form.Section4NotApplicableToJob,
                    form.Section4PlainTextContent,
                    form.Section5NotApplicableToJob,
                    form.Section5PlainTextContent,
                    form.Section6NotApplicableToJob,
                    form.Section6PlainTextContent,
                    form.FromDateTime,
                    form.ToDateTime,
                    new List<FunctionalLocation> {floc},
                    form.DocumentLinks,
                    someOtherUser,
                    false);
                Assert.IsFalse(willNeedReapproval);
            }
        }
    }
}