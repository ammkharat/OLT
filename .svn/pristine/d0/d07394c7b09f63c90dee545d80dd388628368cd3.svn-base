using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [TestFixture]
    public class FormGN24Test
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
            FormGN24 form = FormGN24Fixture.CreateFormWithExistingId();
            form.DocumentLinks.Clear();
            form.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink(1));
            form.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink(2));

            form.ConvertToClone(UserFixture.CreateAdmin());

            Assert.AreEqual(2, form.DocumentLinks.Count);
            Assert.IsTrue(form.DocumentLinks.TrueForAll(link => link.Id == null));
        }

        [Test]
        public void ShouldKnowWhenReapprovalIsNeeded()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            floc.Id = 22;

            User someUser = UserFixture.CreateUserWithGivenId(1);
            User someOtherUser = UserFixture.CreateUserWithGivenId(2);

            DateTime validFromDateTime = new DateTime(2012, 10, 1);
            DateTime validToDateTime = new DateTime(2012, 10, 2);

            FormGN24 form = FormGN24Fixture.CreateForInsert(new List<FunctionalLocation> { floc }, validFromDateTime, validToDateTime, FormStatus.Approved);
            form.DocumentLinks.Clear();
            form.DocumentLinks.Add(new DocumentLink("http://google.ca", "the goog"));
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "approver 1", someUser, new DateTime(2012, 1, 3, 13, 0, 0), null, 1));
            form.Approvals.Add(new FormApproval(null, null, "approver 2", someUser, new DateTime(2012, 1, 1, 10, 0, 0), null, 2));

            // change content
            {
                bool willNeedReapproval = form.WillNeedReapproval(form.PlainTextContent + "a", form.FromDateTime, form.ToDateTime, new List<FunctionalLocation> { floc }, form.DocumentLinks, form.IsTheSafeWorkPlanForPSVRemovalOrInstallation, form.IsTheSafeWorkPlanForWorkInTheAlkylationUnit, form.AlkylationClass, someOtherUser, false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change stuff but the current user is the one who approved it all in the first place
            {
                bool willNeedReapproval = form.WillNeedReapproval(form.PlainTextContent + "a", form.FromDateTime, form.ToDateTime, new List<FunctionalLocation> { floc }, form.DocumentLinks, form.IsTheSafeWorkPlanForPSVRemovalOrInstallation, form.IsTheSafeWorkPlanForWorkInTheAlkylationUnit, form.AlkylationClass, someUser, false);
                Assert.IsFalse(willNeedReapproval);
            }

            // change valid from
            {
                bool willNeedReapproval = form.WillNeedReapproval(form.PlainTextContent, form.FromDateTime.AddDays(1), form.ToDateTime, new List<FunctionalLocation> { floc }, form.DocumentLinks, form.IsTheSafeWorkPlanForPSVRemovalOrInstallation, form.IsTheSafeWorkPlanForWorkInTheAlkylationUnit, form.AlkylationClass, someOtherUser, false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change valid to
            {
                bool willNeedReapproval = form.WillNeedReapproval(form.PlainTextContent, form.FromDateTime, form.ToDateTime.AddDays(1), new List<FunctionalLocation> { floc }, form.DocumentLinks, form.IsTheSafeWorkPlanForPSVRemovalOrInstallation, form.IsTheSafeWorkPlanForWorkInTheAlkylationUnit, form.AlkylationClass, someOtherUser, false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change floc
            {
                FunctionalLocation anotherFloc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
                anotherFloc.Id = 55;

                bool willNeedReapproval = form.WillNeedReapproval(form.PlainTextContent, form.FromDateTime, form.ToDateTime, new List<FunctionalLocation> { anotherFloc }, form.DocumentLinks, form.IsTheSafeWorkPlanForPSVRemovalOrInstallation, form.IsTheSafeWorkPlanForWorkInTheAlkylationUnit, form.AlkylationClass, someOtherUser, false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change IsTheSafeWorkPlanForPSVRemovalOrInstallation answer
            {
                bool willNeedReapproval = form.WillNeedReapproval(form.PlainTextContent, form.FromDateTime, form.ToDateTime, new List<FunctionalLocation> { floc }, form.DocumentLinks, !form.IsTheSafeWorkPlanForPSVRemovalOrInstallation, form.IsTheSafeWorkPlanForWorkInTheAlkylationUnit, form.AlkylationClass, someOtherUser, false);
                Assert.IsTrue(willNeedReapproval);
            }

            // chnage the IsTheSafeWorkPlanForWorkInTheAlkylationUnit answer
            {
                bool willNeedReapproval = form.WillNeedReapproval(form.PlainTextContent, form.FromDateTime, form.ToDateTime, new List<FunctionalLocation> { floc }, form.DocumentLinks, form.IsTheSafeWorkPlanForPSVRemovalOrInstallation, !form.IsTheSafeWorkPlanForWorkInTheAlkylationUnit, form.AlkylationClass, someOtherUser, false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change the AlkylationClass answer
            {
                bool willNeedReapproval = form.WillNeedReapproval(form.PlainTextContent, form.FromDateTime, form.ToDateTime, new List<FunctionalLocation> { floc }, form.DocumentLinks, form.IsTheSafeWorkPlanForPSVRemovalOrInstallation, form.IsTheSafeWorkPlanForWorkInTheAlkylationUnit, FormGN24AlkylationClass.ClassD, someOtherUser, false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change the document links
            {
                List<DocumentLink> documentLinks = new List<DocumentLink>();
                documentLinks.Add(new DocumentLink("http://google.com", "the us goog"));
                
                bool willNeedReapproval = form.WillNeedReapproval(form.PlainTextContent, form.FromDateTime, form.ToDateTime, new List<FunctionalLocation> { floc }, documentLinks, form.IsTheSafeWorkPlanForPSVRemovalOrInstallation, form.IsTheSafeWorkPlanForWorkInTheAlkylationUnit, form.AlkylationClass, someOtherUser, false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change just the end date/time without being someone who can do that and not need reapproval
            {
                bool willNeedReapproval = form.WillNeedReapproval(form.PlainTextContent, form.FromDateTime, form.ToDateTime.AddDays(1), new List<FunctionalLocation> { floc }, form.DocumentLinks, form.IsTheSafeWorkPlanForPSVRemovalOrInstallation, form.IsTheSafeWorkPlanForWorkInTheAlkylationUnit, form.AlkylationClass, someOtherUser, false);
                Assert.IsTrue(willNeedReapproval);
            }

            // change just the end date/time as someone who can do that and not need reapproval
            {
                bool willNeedReapproval = form.WillNeedReapproval(form.PlainTextContent, form.FromDateTime, form.ToDateTime.AddDays(1), new List<FunctionalLocation> { floc }, form.DocumentLinks, form.IsTheSafeWorkPlanForPSVRemovalOrInstallation, form.IsTheSafeWorkPlanForWorkInTheAlkylationUnit, form.AlkylationClass, someOtherUser, true);
                Assert.IsFalse(willNeedReapproval);
            }

            // as someone who can change the end date without needing reapproval, change both the end date and something else
            {
                bool willNeedReapproval = form.WillNeedReapproval(form.PlainTextContent, form.FromDateTime, form.ToDateTime.AddDays(1), new List<FunctionalLocation> { floc }, form.DocumentLinks, !form.IsTheSafeWorkPlanForPSVRemovalOrInstallation, form.IsTheSafeWorkPlanForWorkInTheAlkylationUnit, form.AlkylationClass, someOtherUser, true);
                Assert.IsTrue(willNeedReapproval);
            }

            // nothing has changed
            {
                bool willNeedReapproval = form.WillNeedReapproval(form.PlainTextContent, form.FromDateTime, form.ToDateTime, new List<FunctionalLocation> { floc }, form.DocumentLinks, form.IsTheSafeWorkPlanForPSVRemovalOrInstallation, form.IsTheSafeWorkPlanForWorkInTheAlkylationUnit, form.AlkylationClass, someOtherUser, false);
                Assert.IsFalse(willNeedReapproval);
            }
        }

    }
}