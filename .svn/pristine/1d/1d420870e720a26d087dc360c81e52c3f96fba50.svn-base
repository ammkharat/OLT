using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [TestFixture]
    public class OvertimeFormTest
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
            var userInitiationgTheClone = UserFixture.CreateUserWithGivenId(2);
            var createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            var approvalUser = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            approvalUser.Id = 1000;
            var lastModifiedDateTime = new DateTime(2009, 3, 3, 4, 2, 0);
            var originalToDateTime = new DateTime(2009, 3, 5, 4, 2, 0);
            var originalFromDateTime = new DateTime(2009, 3, 10, 4, 2, 0);
            var onPremiseContractors = new List<OnPremiseContractor>
            {
                new OnPremiseContractor(100,
                    10,
                    "Mike",
                    "Edmonton",
                    originalToDateTime,
                    originalFromDateTime,
                    true,
                    true,
                    "403 222 4444",
                    "12",
                    "heres a description",
                    "Joe Contracting Inc",
                    "ABC WO223",
                    4)
            };
            var form = new OvertimeForm(10,
                FormStatus.Approved,
                originalToDateTime,
                originalFromDateTime,
                createdBy,
                lastModifiedDateTime,
                onPremiseContractors,
                FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                "the trade",
                createdBy,
                lastModifiedDateTime,
                null,0)              //ayman generic forms
            {
                DocumentLinks = new List<DocumentLink> {DocumentLinkFixture.CreateNewDocumentLink(10)}
            };
            form.Approvals.First().ApprovalDateTime = Clock.Now;
            form.Approvals.First().ApprovedByUser = createdBy;

            form.Id = 22;
            form.LastModifiedBy = createdBy;
            form.LastModifiedDateTime = Clock.Now.AddHours(-3);
            form.DocumentLinks = new List<DocumentLink> {DocumentLinkFixture.CreateNewDocumentLink()};

            Clock.Now = Clock.Now.AddHours(1);
            form.ConvertToClone(userInitiationgTheClone);

            Console.WriteLine(form.OnPremiseContractors.First().Id);

            Assert.IsFalse(form.DocumentLinks.Any(link => link.Id != null));
            Assert.IsFalse(form.OnPremiseContractors.Any(onPremiseContractor => onPremiseContractor.Id != null));
            Assert.IsNull(form.ApprovedDateTime);
            Assert.IsNull(form.ClosedDateTime);
            Assert.IsNull(form.Id);
            Assert.AreEqual(userInitiationgTheClone.Id, form.LastModifiedBy.Id);
            Assert.AreEqual(Clock.Now, form.LastModifiedDateTime);
            Assert.AreEqual(Clock.Now, form.CreatedDateTime);
            Assert.AreEqual(userInitiationgTheClone.Id, form.CreatedBy.Id);
            Assert.AreEqual("Title for document (http:\\URL for Document)", form.DocumentLinks.First().TitleWithUrl);
            Assert.AreEqual(originalFromDateTime, form.ToDateTime);
            Assert.AreEqual(originalToDateTime, form.FromDateTime);
            Assert.AreEqual(FormStatus.Draft, form.FormStatus);
            Assert.AreEqual(1, form.AllApprovals.Count(approval => !approval.IsApproved));
            Assert.IsNull(form.Approvals.First().ApprovedByUser);
            Assert.IsNull(form.Approvals.First().ApprovalDateTime);
        }

        [Test]
        public void ShouldCancel()
        {
            var createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            var approvalUser = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            approvalUser.Id = 1000;
            var lastModifiedDateTime = new DateTime(2009, 3, 3, 4, 2, 0);
            var onPremiseContractors = new List<OnPremiseContractor>
            {
                new OnPremiseContractor(100,
                    10,
                    "Mike",
                    "Edmonton",
                    lastModifiedDateTime,
                    lastModifiedDateTime,
                    true,
                    true,
                    "403 222 4444",
                    "12",
                    "heres a description",
                    "Joe Contracting Inc",
                    "ABC WO223",
                    4)
            };
            var originalForm = new OvertimeForm(10,
                FormStatus.Draft,
                lastModifiedDateTime,
                lastModifiedDateTime,
                createdBy,
                lastModifiedDateTime,
                onPremiseContractors,
                FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                "the trade",
                createdBy,
                lastModifiedDateTime,
                null,0) {DocumentLinks = new List<DocumentLink> {DocumentLinkFixture.CreateNewDocumentLink(10)}};              //ayman generic forms

            originalForm.MarkAsClosed(Clock.Now, createdBy);

            Assert.AreEqual(Clock.Now, originalForm.CancelledDateTime);
            Assert.AreEqual(FormStatus.Cancelled, originalForm.FormStatus);
            Assert.IsNull(originalForm.ApprovedDateTime);
        }

        [Test]
        public void ShouldCreateASnapshotForHistory()
        {
            var createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            var approvalUser = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            approvalUser.Id = 1000;
            var lastModifiedDateTime = new DateTime(2009, 3, 3, 4, 2, 0);
            var onPremiseContractors = new List<OnPremiseContractor>
            {
                new OnPremiseContractor(100,
                    10,
                    "Mike",
                    "Edmonton",
                    lastModifiedDateTime,
                    lastModifiedDateTime,
                    true,
                    true,
                    "403 222 4444",
                    "12",
                    "heres a description",
                    "Joe Contracting Inc",
                    "ABC WO223",
                    4)
            };
            var originalForm = new OvertimeForm(10,
                FormStatus.Approved,
                lastModifiedDateTime,
                lastModifiedDateTime,
                createdBy,
                lastModifiedDateTime,
                onPremiseContractors,
                FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                "the trade",
                createdBy,
                lastModifiedDateTime,
                null,0) {DocumentLinks = new List<DocumentLink> {DocumentLinkFixture.CreateNewDocumentLink(10)}};    //ayman generic forms
            originalForm.Approvals.Add(new FormApproval(4, 10, "Only Approver", approvalUser, lastModifiedDateTime, null, 1));

            var formOvertimeFormHistory = originalForm.TakeSnapshot();

            Assert.AreEqual(
                "Person: Mike Primary Location: Edmonton Start: Tuesday, March 03, 2009 4:02 AM End: Tuesday, March 03, 2009 4:02 AM Shifts: Day/Night Phone: 403 222 4444 Radio: 12 Description: heres a description Company: Joe Contracting Inc WO#/PO#: ABC WO223 OT Hrs: 4.00",
                formOvertimeFormHistory.OnSitePersonnel);
            Assert.AreEqual(FunctionalLocationFixture.GetReal_ED1_A001_U007().FullHierarchy,
                formOvertimeFormHistory.FunctionalLocation);
            Assert.AreEqual("the trade", formOvertimeFormHistory.TradeOccupation);
            Assert.AreEqual("Title for document (http:\\URL for Document)", formOvertimeFormHistory.DocumentLinks);
            Assert.AreEqual("Only Approver (stan)", formOvertimeFormHistory.Approvals);
        }

        [Test]
        public void ShouldNotRequireReapprovalWhenAPersonnelIsDeletedByApprovalUser()
        {
            var createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            var approvalUser = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            approvalUser.Id = 1000;

            var lastModifiedDateTime = Clock.Now;

            var onPremiseContractors = new List<OnPremiseContractor>
            {
                new OnPremiseContractor(100,
                    10,
                    "Mike",
                    string.Empty,
                    lastModifiedDateTime,
                    lastModifiedDateTime,
                    true,
                    true,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    3),
                new OnPremiseContractor(101,
                    10,
                    "Dustin",
                    string.Empty,
                    lastModifiedDateTime,
                    lastModifiedDateTime,
                    false,
                    true,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    34)
            };

            var originalForm = new OvertimeForm(10,
                FormStatus.Approved,
                lastModifiedDateTime,
                lastModifiedDateTime,
                createdBy,
                lastModifiedDateTime,
                onPremiseContractors,
                FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                string.Empty,
                createdBy,
                lastModifiedDateTime,
                null,0);           //ayman generic forms

            originalForm.Approvals.Add(new FormApproval(4, 10, "Only Approver", approvalUser, lastModifiedDateTime, "SomeAssignmentName", 1));

            var changedForm = originalForm.DeepClone();

            changedForm.LastModifiedBy = approvalUser;
            changedForm.OnPremiseContractors.RemoveAt(0);
            Assert.IsFalse(changedForm.WillNeedReapproval(originalForm));
        }

        [Test]
        public void ShouldNotRequireReapprovalWhenEditUserIsTheApprovalUser()
        {
            var createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            var approvalUser = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            approvalUser.Id = 1000;

            var lastModifiedDateTime = Clock.Now;
            var onPremiseContractor = new OnPremiseContractor(100,
                10,
                string.Empty,
                string.Empty,
                lastModifiedDateTime,
                lastModifiedDateTime,
                true,
                true,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                3);
            var originalForm = new OvertimeForm(10,
                FormStatus.Approved,
                lastModifiedDateTime,
                lastModifiedDateTime,
                createdBy,
                lastModifiedDateTime,
                new List<OnPremiseContractor>
                {
                    onPremiseContractor
                },
                FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                string.Empty,
                createdBy,
                lastModifiedDateTime,
                null,0);    //ayman generic forms
 
            originalForm.Approvals.Add(new FormApproval(4, 10, "Only Approver", approvalUser, lastModifiedDateTime, null, 1));

            var changedForm = originalForm.DeepClone();
            changedForm.Trade = "Some new trade";
            changedForm.LastModifiedBy = approvalUser;

            var willNeedReapproval = changedForm.WillNeedReapproval(originalForm);
            Assert.IsFalse(willNeedReapproval);
        }

        [Test]
        public void ShouldNotRequireReapprovalWhenNewPersonnelIsAddedByApprovalUser()
        {
            var createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            var approvalUser = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            approvalUser.Id = 1000;

            var lastModifiedDateTime = Clock.Now;

            var onPremiseContractors = new List<OnPremiseContractor>
            {
                new OnPremiseContractor(100,
                    10,
                    "Mike",
                    string.Empty,
                    lastModifiedDateTime,
                    lastModifiedDateTime,
                    true,
                    true,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    3)
            };

            var originalForm = new OvertimeForm(10,
                FormStatus.Approved,
                lastModifiedDateTime,
                lastModifiedDateTime,
                createdBy,
                lastModifiedDateTime,
                onPremiseContractors,
                FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                string.Empty,
                createdBy,
                lastModifiedDateTime,
                null,0);         //ayman generic forms

            originalForm.Approvals.Add(new FormApproval(4, 10, "Only Approver", approvalUser, lastModifiedDateTime, "WorkAssName", 1));

            var changedForm = originalForm.DeepClone();

            changedForm.LastModifiedBy = approvalUser;
            changedForm.OnPremiseContractors.Add(new OnPremiseContractor(101,
                10,
                "Dustin",
                string.Empty,
                lastModifiedDateTime,
                lastModifiedDateTime,
                false,
                true,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                34)
                );

            Assert.IsFalse(changedForm.WillNeedReapproval(originalForm));
        }

        [Test]
        public void ShouldNotRequireReapprovalWhenNothingIsChanged()
        {
            var createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            var approvalUser = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            approvalUser.Id = 1000;

            var lastModifiedDateTime = Clock.Now;
            var onPremiseContractor = new OnPremiseContractor(100,
                10,
                string.Empty,
                string.Empty,
                lastModifiedDateTime,
                lastModifiedDateTime,
                true,
                true,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                3);

            var originalForm = new OvertimeForm(10,
                FormStatus.Approved,
                lastModifiedDateTime,
                lastModifiedDateTime,
                createdBy,
                lastModifiedDateTime,
                new List<OnPremiseContractor>
                {
                    onPremiseContractor
                },
                FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                string.Empty,
                createdBy,
                lastModifiedDateTime,
                null,0);     //ayman generic forms
  
            originalForm.Approvals.Add(new FormApproval(4, 10, "Only Approver", approvalUser, lastModifiedDateTime, "WorkAssName", 1));

            var changedForm = originalForm.DeepClone();
            var lastModifiedBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            lastModifiedBy.Id = 200;
            changedForm.LastModifiedBy = lastModifiedBy;

            Assert.IsFalse(changedForm.WillNeedReapproval(originalForm));
        }

        [Test]
        public void ShouldNotRequreReapprovalWhenOnlyNonRequiredFieldsAreChanged()
        {
            var createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            var approvalUser = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            approvalUser.Id = 1000;

            var lastModifiedDateTime = Clock.Now;
            var onPremiseContractor = new OnPremiseContractor(100,
                10,
                string.Empty,
                string.Empty,
                lastModifiedDateTime,
                lastModifiedDateTime,
                true,
                true,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                3);
            var originalForm = new OvertimeForm(10,
                FormStatus.Approved,
                lastModifiedDateTime,
                lastModifiedDateTime,
                createdBy,
                lastModifiedDateTime,
                new List<OnPremiseContractor>
                {
                    onPremiseContractor
                },
                FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                string.Empty,
                createdBy,
                lastModifiedDateTime,
                null,0);            //ayman generic forms

            originalForm.Approvals.Add(new FormApproval(4, 10, "Only Approver", approvalUser, lastModifiedDateTime, "workAssName", 1));

            var changedForm = originalForm.DeepClone();
            var lastModifiedBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            lastModifiedBy.Id = 200;
            changedForm.LastModifiedBy = lastModifiedBy;
            changedForm.OnPremiseContractors[0].PhoneNumber = "403-555-1212";
            changedForm.OnPremiseContractors[0].WorkOrderNumber = "4545##";

            Assert.IsFalse(changedForm.WillNeedReapproval(originalForm));
        }

        [Test]
        public void ShouldRequireReapprovalWhenAPersonnelIsDeletedByDifferentUser()
        {
            var createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            var approvalUser = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            approvalUser.Id = 1000;

            var lastModifiedDateTime = Clock.Now;

            var onPremiseContractors = new List<OnPremiseContractor>
            {
                new OnPremiseContractor(100,
                    10,
                    "Mike",
                    string.Empty,
                    lastModifiedDateTime,
                    lastModifiedDateTime,
                    true,
                    true,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    3),
                new OnPremiseContractor(101,
                    10,
                    "Dustin",
                    string.Empty,
                    lastModifiedDateTime,
                    lastModifiedDateTime,
                    false,
                    true,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    34)
            };

            var originalForm = new OvertimeForm(10,
                FormStatus.Approved,
                lastModifiedDateTime,
                lastModifiedDateTime,
                createdBy,
                lastModifiedDateTime,
                onPremiseContractors,
                FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                string.Empty,
                createdBy,
                lastModifiedDateTime,
                null,0);              //ayman generic forms

            originalForm.Approvals.Add(new FormApproval(4, 10, "Only Approver", approvalUser, lastModifiedDateTime, "workassname", 1));

            var changedForm = originalForm.DeepClone();
            var lastModifiedBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            lastModifiedBy.Id = 200;

            changedForm.LastModifiedBy = lastModifiedBy;
            changedForm.OnPremiseContractors.RemoveAt(0);
            Assert.IsTrue(changedForm.WillNeedReapproval(originalForm));
        }

        [Test]
        public void ShouldRequireReapprovalWhenNewPersonnelIsAddedByDifferentUser()
        {
            var createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            var approvalUser = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            approvalUser.Id = 1000;

            var lastModifiedDateTime = Clock.Now;

            var onPremiseContractors = new List<OnPremiseContractor>
            {
                new OnPremiseContractor(100,
                    10,
                    "Mike",
                    string.Empty,
                    lastModifiedDateTime,
                    lastModifiedDateTime,
                    true,
                    true,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    3)
            };

            var originalForm = new OvertimeForm(10,
                FormStatus.Approved,
                lastModifiedDateTime,
                lastModifiedDateTime,
                createdBy,
                lastModifiedDateTime,
                onPremiseContractors,
                FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                string.Empty,
                createdBy,
                lastModifiedDateTime,
                null,0);               //ayman generic forms

            originalForm.Approvals.Add(new FormApproval(4, 10, "Only Approver", approvalUser, lastModifiedDateTime, "workassname", 1));

            var changedForm = originalForm.DeepClone();
            var lastModifiedBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            lastModifiedBy.Id = 200;

            changedForm.LastModifiedBy = lastModifiedBy;
            changedForm.OnPremiseContractors.Add(new OnPremiseContractor(null,
                10,
                "Dustin",
                string.Empty,
                lastModifiedDateTime,
                lastModifiedDateTime,
                false,
                true,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                34)
                );

            Assert.IsTrue(changedForm.WillNeedReapproval(originalForm));
        }
    }
}