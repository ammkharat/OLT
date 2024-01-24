using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Services;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Utilities
{
    [TestFixture]
    public class OnPremisePersonnelAdapterTest
    {
        private List<EdmontonPerson> cardsFromSwipeCardSystem;
        private EdmontonPerson scannedInLessThan24HoursAgo;
        private EdmontonPerson scannedOutLessThan24HoursAgo;
        private EdmontonPerson scannedOutMoreThan24HoursAgo;
        private EdmontonPerson scannedInMoreThan24HoursAgo;

        private OnPremisePersonnelService service;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
            scannedInLessThan24HoursAgo = new EdmontonPerson(null, "Jim", "Dog", "111", Clock.Now.AddHours(-4), BadgeScanStatus.In);
            scannedOutLessThan24HoursAgo = new EdmontonPerson(null, "John", "Smith", "222", Clock.Now.AddHours(-2), BadgeScanStatus.Out);
            scannedOutMoreThan24HoursAgo = new EdmontonPerson(null, "Bart", "Simpson", "333", Clock.Now.AddHours(-26), BadgeScanStatus.Out);
            scannedInMoreThan24HoursAgo = new EdmontonPerson(null, "Homer", "Simpson", "444", Clock.Now.AddHours(-25), BadgeScanStatus.In);

            cardsFromSwipeCardSystem = new List<EdmontonPerson>
            {
                scannedInLessThan24HoursAgo,
                scannedOutLessThan24HoursAgo,
                scannedOutMoreThan24HoursAgo,
                scannedInMoreThan24HoursAgo,
            };

            service = new OnPremisePersonnelService(null, null);
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();    
        }

        [Ignore] [Test]
        public void ShouldGetUnKnownScanStatusForUserBeingInsertedThatIsNotInTheCardSystem()
        {
            User createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            User approvalUser = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            approvalUser.Id = 1000;

            DateTime lastModifiedDateTime = Clock.Now;
            OnPremiseContractor onPremiseContractorA = new OnPremiseContractor(100, 10, "Lisa Simpson not in Card System", string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            List<OnPremiseContractor> onPremiseContractors = new List<OnPremiseContractor>
            {
                onPremiseContractorA
            };

            var oldVersion = new OvertimeForm(10, FormStatus.Approved, lastModifiedDateTime, lastModifiedDateTime,
                createdBy, lastModifiedDateTime, onPremiseContractors, FunctionalLocationFixture.GetReal_ED1_A001_U007(), string.Empty, createdBy, lastModifiedDateTime,
                null,0);            //ayman generic forms

            OvertimeForm newVersion = oldVersion.DeepClone();

            OnPremiseContractor onPremiseContractorB = new OnPremiseContractor(101, 10, "Tommy Tom with no badge Id", string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            newVersion.OnPremiseContractors.Add(onPremiseContractorB);

            List<OnPremisePersonnel> onPremisePersonnelSupervisors = service.CreateInsertedOnPremisePersonnel(oldVersion, newVersion, cardsFromSwipeCardSystem, Clock.Now);
            Assert.That(onPremisePersonnelSupervisors, Is.Not.Null);
            Assert.That(onPremisePersonnelSupervisors.Count, Is.EqualTo(1));
            OnPremisePersonnel onPremisePersonnel = onPremisePersonnelSupervisors[0];
            Assert.That(onPremisePersonnel.CardEntryStatus, Is.EqualTo(CardEntryStatus.UnKnown));
        }

        [Ignore] [Test]
        public void ShouldGetOnSiteScanStatusForUserBeingInsertedThatLastScannedInLessThan24HoursAgo()
        {
            User createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            User approvalUser = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            approvalUser.Id = 1000;

            DateTime lastModifiedDateTime = Clock.Now;
            OnPremiseContractor onPremiseContractorA = new OnPremiseContractor(100, 10, "Lisa Simpson not in Card System", string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            List<OnPremiseContractor> onPremiseContractors = new List<OnPremiseContractor>
            {
                onPremiseContractorA
            };

            var oldVersion = new OvertimeForm(10, FormStatus.Approved, lastModifiedDateTime, lastModifiedDateTime,
                createdBy, lastModifiedDateTime, onPremiseContractors, FunctionalLocationFixture.GetReal_ED1_A001_U007(), string.Empty, createdBy, lastModifiedDateTime,
                null,0);  //ayman generic forms

            OvertimeForm newVersion = oldVersion.DeepClone();

            OnPremiseContractor onPremiseContractorB = new OnPremiseContractor(101, 10, scannedInLessThan24HoursAgo.DisplayString , string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            newVersion.OnPremiseContractors.Add(onPremiseContractorB);

            List<OnPremisePersonnel> onPremisePersonnelSupervisors = service.CreateInsertedOnPremisePersonnel(oldVersion, newVersion, cardsFromSwipeCardSystem, Clock.Now);
            Assert.That(onPremisePersonnelSupervisors, Is.Not.Null);
            Assert.That(onPremisePersonnelSupervisors.Count, Is.EqualTo(1));
            OnPremisePersonnel onPremisePersonnel = onPremisePersonnelSupervisors[0];
            Assert.That(onPremisePersonnel.CardEntryStatus, Is.EqualTo(CardEntryStatus.OnSite));
        }

        [Ignore] [Test]
        public void ShouldGetUnKnownScanStatusForUserBeingInsertedThatLastScannedInGreaterThan24HoursAgo()
        {
            User createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            User approvalUser = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            approvalUser.Id = 1000;

            DateTime lastModifiedDateTime = Clock.Now;
            OnPremiseContractor onPremiseContractorA = new OnPremiseContractor(100, 10, "Lisa Simpson not in Card System", string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            List<OnPremiseContractor> onPremiseContractors = new List<OnPremiseContractor>
            {
                onPremiseContractorA
            };

            var oldVersion = new OvertimeForm(10, FormStatus.Approved, lastModifiedDateTime, lastModifiedDateTime,
                createdBy, lastModifiedDateTime, onPremiseContractors, FunctionalLocationFixture.GetReal_ED1_A001_U007(), string.Empty, createdBy, lastModifiedDateTime,
                null,0);   //ayman generic forms

            OvertimeForm newVersion = oldVersion.DeepClone();

            OnPremiseContractor onPremiseContractorB = new OnPremiseContractor(101, 10, scannedInMoreThan24HoursAgo.DisplayString, string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            newVersion.OnPremiseContractors.Add(onPremiseContractorB);

            List<OnPremisePersonnel> onPremisePersonnelSupervisors = service.CreateInsertedOnPremisePersonnel(oldVersion, newVersion, cardsFromSwipeCardSystem, Clock.Now);
            Assert.That(onPremisePersonnelSupervisors, Is.Not.Null);
            Assert.That(onPremisePersonnelSupervisors.Count, Is.EqualTo(1));
            OnPremisePersonnel onPremisePersonnel = onPremisePersonnelSupervisors[0];
            Assert.That(onPremisePersonnel.CardEntryStatus, Is.EqualTo(CardEntryStatus.UnKnown));
        }

        [Ignore] [Test]
        public void ShouldGetOffSiteScanStatusForUserBeingInsertedThatLastScannedOutLessThan24HoursAgo()
        {
            User createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            User approvalUser = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            approvalUser.Id = 1000;

            DateTime lastModifiedDateTime = Clock.Now;
            OnPremiseContractor onPremiseContractorA = new OnPremiseContractor(100, 10, "Lisa Simpson not in Card System", string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            List<OnPremiseContractor> onPremiseContractors = new List<OnPremiseContractor>
            {
                onPremiseContractorA
            };

            var oldVersion = new OvertimeForm(10, FormStatus.Approved, lastModifiedDateTime, lastModifiedDateTime,
                createdBy, lastModifiedDateTime, onPremiseContractors, FunctionalLocationFixture.GetReal_ED1_A001_U007(), string.Empty, createdBy, lastModifiedDateTime,
                null,0);       //ayman generic forms

            OvertimeForm newVersion = oldVersion.DeepClone();

            OnPremiseContractor onPremiseContractorB = new OnPremiseContractor(101, 10, scannedOutLessThan24HoursAgo.DisplayString, string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            newVersion.OnPremiseContractors.Add(onPremiseContractorB);

            List<OnPremisePersonnel> onPremisePersonnelSupervisors = service.CreateInsertedOnPremisePersonnel(oldVersion, newVersion, cardsFromSwipeCardSystem, Clock.Now);
            Assert.That(onPremisePersonnelSupervisors, Is.Not.Null);
            Assert.That(onPremisePersonnelSupervisors.Count, Is.EqualTo(1));
            OnPremisePersonnel onPremisePersonnel = onPremisePersonnelSupervisors[0];
            Assert.That(onPremisePersonnel.CardEntryStatus, Is.EqualTo(CardEntryStatus.OffSite));
        }

        [Ignore] [Test]
        public void ShouldGetOffSiteScanStatusForUserBeingInsertedThatLastScannedOutMoreThan24HoursAgo()
        {
            User createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            User approvalUser = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            approvalUser.Id = 1000;

            DateTime lastModifiedDateTime = Clock.Now;
            OnPremiseContractor onPremiseContractorA = new OnPremiseContractor(100, 10, "Lisa Simpson not in Card System", string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            List<OnPremiseContractor> onPremiseContractors = new List<OnPremiseContractor>
            {
                onPremiseContractorA
            };

            var oldVersion = new OvertimeForm(10, FormStatus.Approved, lastModifiedDateTime, lastModifiedDateTime,
                createdBy, lastModifiedDateTime, onPremiseContractors, FunctionalLocationFixture.GetReal_ED1_A001_U007(), string.Empty, createdBy, lastModifiedDateTime,
                null,0);    //ayman generic forms

            OvertimeForm newVersion = oldVersion.DeepClone();

            OnPremiseContractor onPremiseContractorB = new OnPremiseContractor(101, 10, scannedOutMoreThan24HoursAgo.DisplayString, string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            newVersion.OnPremiseContractors.Add(onPremiseContractorB);

            List<OnPremisePersonnel> onPremisePersonnelSupervisors = service.CreateInsertedOnPremisePersonnel(oldVersion, newVersion, cardsFromSwipeCardSystem, Clock.Now);
            Assert.That(onPremisePersonnelSupervisors, Is.Not.Null);
            Assert.That(onPremisePersonnelSupervisors.Count, Is.EqualTo(1));
            OnPremisePersonnel onPremisePersonnel = onPremisePersonnelSupervisors[0];
            Assert.That(onPremisePersonnel.CardEntryStatus, Is.EqualTo(CardEntryStatus.OffSite));
        }

        [Ignore] [Test]
        public void ShouldGetOffSiteScanStatusForUserBeingUpdatedThatLastScannedOutLessThan24HoursAgo()
        {
            User createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            User approvalUser = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            approvalUser.Id = 1000;

            DateTime lastModifiedDateTime = Clock.Now;
            OnPremiseContractor onPremiseContractorA = new OnPremiseContractor(100, 10, scannedOutLessThan24HoursAgo.DisplayString, string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            List<OnPremiseContractor> onPremiseContractors = new List<OnPremiseContractor>
            {
                onPremiseContractorA
            };

            OvertimeForm oldVersion = new OvertimeForm(10, FormStatus.Approved, lastModifiedDateTime, lastModifiedDateTime,
                createdBy, lastModifiedDateTime, onPremiseContractors, FunctionalLocationFixture.GetReal_ED1_A001_U007(), string.Empty, createdBy, lastModifiedDateTime,
                null,0);      //ayman generic forms

            OvertimeForm newVersion = oldVersion.DeepClone();

            List<OnPremisePersonnel> onPremisePersonnelSupervisors = service.CreateUpdatedOnPremisePersonnel(oldVersion, newVersion, cardsFromSwipeCardSystem, Clock.Now);
            Assert.That(onPremisePersonnelSupervisors, Is.Not.Null);
            Assert.That(onPremisePersonnelSupervisors.Count, Is.EqualTo(1));
            OnPremisePersonnel onPremisePersonnel = onPremisePersonnelSupervisors[0];
            Assert.That(onPremisePersonnel.CardEntryStatus, Is.EqualTo(CardEntryStatus.OffSite));
        }

        [Ignore] [Test]
        public void ShouldGetOnSiteScanStatusForUserBeingUpdatedThatLastScannedInLessThan24HoursAgo()
        {
            User createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            User approvalUser = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            approvalUser.Id = 1000;

            DateTime lastModifiedDateTime = Clock.Now;
            OnPremiseContractor onPremiseContractorA = new OnPremiseContractor(100, 10, scannedInLessThan24HoursAgo.DisplayString, string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            List<OnPremiseContractor> onPremiseContractors = new List<OnPremiseContractor>
            {
                onPremiseContractorA
            };

            OvertimeForm oldVersion = new OvertimeForm(10, FormStatus.Approved, lastModifiedDateTime, lastModifiedDateTime,
                createdBy, lastModifiedDateTime, onPremiseContractors, FunctionalLocationFixture.GetReal_ED1_A001_U007(), string.Empty, createdBy, lastModifiedDateTime,
                null,0);    //ayman generic forms

            OvertimeForm newVersion = oldVersion.DeepClone();

            List<OnPremisePersonnel> onPremisePersonnelSupervisors = service.CreateUpdatedOnPremisePersonnel(oldVersion, newVersion, cardsFromSwipeCardSystem, Clock.Now);
            Assert.That(onPremisePersonnelSupervisors, Is.Not.Null);
            Assert.That(onPremisePersonnelSupervisors.Count, Is.EqualTo(1));
            OnPremisePersonnel onPremisePersonnel = onPremisePersonnelSupervisors[0];
            Assert.That(onPremisePersonnel.CardEntryStatus, Is.EqualTo(CardEntryStatus.OnSite));
        }

        [Ignore] [Test]
        public void ShouldCreateDeletedPersonnelWhenRemovingAnOnPremiseContractor()
        {
            User createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            User approvalUser = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            approvalUser.Id = 1000;

            DateTime lastModifiedDateTime = Clock.Now;
            OnPremiseContractor onPremiseContractorA = new OnPremiseContractor(100, 10, scannedInLessThan24HoursAgo.DisplayString, string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            List<OnPremiseContractor> onPremiseContractors = new List<OnPremiseContractor>
            {
                onPremiseContractorA
            };

            OvertimeForm oldVersion = new OvertimeForm(10, FormStatus.Approved, lastModifiedDateTime, lastModifiedDateTime,
                createdBy, lastModifiedDateTime, onPremiseContractors, FunctionalLocationFixture.GetReal_ED1_A001_U007(), string.Empty, createdBy, lastModifiedDateTime,
                null,0);    //ayman generic forms

            OvertimeForm newVersion = oldVersion.DeepClone();
            newVersion.OnPremiseContractors.Clear();

            List<OnPremisePersonnel> onPremisePersonnelSupervisors = service.CreateDeletedOnPremisePersonnel(oldVersion, newVersion);
            Assert.That(onPremisePersonnelSupervisors, Is.Not.Null);
            Assert.That(onPremisePersonnelSupervisors.Count, Is.EqualTo(1));
            OnPremisePersonnel onPremisePersonnel = onPremisePersonnelSupervisors[0];
            Assert.That(onPremisePersonnel.CardEntryStatus, Is.EqualTo(CardEntryStatus.UnKnown)); // don't really care what this is since we want to remove this user
            Assert.That(onPremisePersonnel.OnPremiseContractor.PersonnelName, Is.EqualTo(scannedInLessThan24HoursAgo.DisplayString));
        }

        [Ignore] [Test]
        public void ShouldCreatePersonnelWhenInsertingANewOvertimeForm()
        {
            User createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            User approvalUser = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            approvalUser.Id = 1000;

            DateTime lastModifiedDateTime = Clock.Now;
            OnPremiseContractor onPremiseContractorA = new OnPremiseContractor(100, 10, scannedInLessThan24HoursAgo.DisplayString, string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            OnPremiseContractor onPremiseContractorB = new OnPremiseContractor(101, 10, scannedInMoreThan24HoursAgo.DisplayString, string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            OnPremiseContractor onPremiseContractorC = new OnPremiseContractor(102, 10, scannedOutLessThan24HoursAgo.DisplayString, string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            OnPremiseContractor onPremiseContractorD = new OnPremiseContractor(103, 10, scannedOutMoreThan24HoursAgo.DisplayString, string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            OnPremiseContractor onPremiseContractorE = new OnPremiseContractor(104, 10, "Notin ScanSystem", string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            OnPremiseContractor onPremiseContractorF = new OnPremiseContractor(105, 10, "Good, Guy (#1000)", string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);

            List<OnPremiseContractor> onPremiseContractors = new List<OnPremiseContractor>
            {
                onPremiseContractorA, onPremiseContractorB, onPremiseContractorC, onPremiseContractorD, onPremiseContractorE, onPremiseContractorF
            };

            OvertimeForm form = new OvertimeForm(10, FormStatus.Approved, lastModifiedDateTime, lastModifiedDateTime,
                createdBy, lastModifiedDateTime, onPremiseContractors, FunctionalLocationFixture.GetReal_ED1_A001_U007(), string.Empty, createdBy, lastModifiedDateTime,
                null,0);   //ayman generic forms

            List<OnPremisePersonnel> onPremisePersonnelSupervisors = service.CreateInsertedOnPremisePersonnel(null, form, cardsFromSwipeCardSystem, Clock.Now);
            Assert.That(onPremisePersonnelSupervisors, Is.Not.Null);
            Assert.That(onPremisePersonnelSupervisors.Count, Is.EqualTo(6));

            OnPremisePersonnel onPremisePersonnel = onPremisePersonnelSupervisors.Find(s => s.OnPremiseContractor.IdValue == 100);
            Assert.That(onPremisePersonnel, Is.Not.Null);
            Assert.That(onPremisePersonnel.CardEntryStatus, Is.EqualTo(CardEntryStatus.OnSite));

            onPremisePersonnel = onPremisePersonnelSupervisors.Find(s => s.OnPremiseContractor.IdValue == 101);
            Assert.That(onPremisePersonnel, Is.Not.Null);
            Assert.That(onPremisePersonnel.CardEntryStatus, Is.EqualTo(CardEntryStatus.UnKnown));

            onPremisePersonnel = onPremisePersonnelSupervisors.Find(s => s.OnPremiseContractor.IdValue == 102);
            Assert.That(onPremisePersonnel, Is.Not.Null);
            Assert.That(onPremisePersonnel.CardEntryStatus, Is.EqualTo(CardEntryStatus.OffSite));

            onPremisePersonnel = onPremisePersonnelSupervisors.Find(s => s.OnPremiseContractor.IdValue == 103);
            Assert.That(onPremisePersonnel, Is.Not.Null);
            Assert.That(onPremisePersonnel.CardEntryStatus, Is.EqualTo(CardEntryStatus.OffSite));

            onPremisePersonnel = onPremisePersonnelSupervisors.Find(s => s.OnPremiseContractor.IdValue == 104);
            Assert.That(onPremisePersonnel, Is.Not.Null);
            Assert.That(onPremisePersonnel.CardEntryStatus, Is.EqualTo(CardEntryStatus.UnKnown));

            onPremisePersonnel = onPremisePersonnelSupervisors.Find(s => s.OnPremiseContractor.IdValue == 105);
            Assert.That(onPremisePersonnel, Is.Not.Null);
            Assert.That(onPremisePersonnel.CardEntryStatus, Is.EqualTo(CardEntryStatus.OffSite));
        }

        [Ignore] [Test]
        public void ShouldRemovePersonnelWhenCancellingAnOvertimeForm()
        {
            User createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            User approvalUser = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            approvalUser.Id = 1000;

            DateTime lastModifiedDateTime = Clock.Now;
            OnPremiseContractor onPremiseContractorA = new OnPremiseContractor(100, 10, scannedInLessThan24HoursAgo.DisplayString, string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            OnPremiseContractor onPremiseContractorB = new OnPremiseContractor(101, 10, scannedInMoreThan24HoursAgo.DisplayString, string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            OnPremiseContractor onPremiseContractorC = new OnPremiseContractor(102, 10, scannedOutLessThan24HoursAgo.DisplayString, string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            OnPremiseContractor onPremiseContractorD = new OnPremiseContractor(103, 10, scannedOutMoreThan24HoursAgo.DisplayString, string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            OnPremiseContractor onPremiseContractorE = new OnPremiseContractor(104, 10, "Notin ScanSystem", string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);
            OnPremiseContractor onPremiseContractorF = new OnPremiseContractor(105, 10, "Good, Guy (#1000)", string.Empty,
                lastModifiedDateTime, lastModifiedDateTime, true, true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 3);

            List<OnPremiseContractor> onPremiseContractors = new List<OnPremiseContractor>
            {
                onPremiseContractorA, onPremiseContractorB, onPremiseContractorC, onPremiseContractorD, onPremiseContractorE, onPremiseContractorF
            };

            OvertimeForm form = new OvertimeForm(10, FormStatus.Approved, lastModifiedDateTime, lastModifiedDateTime,
                createdBy, lastModifiedDateTime, onPremiseContractors, FunctionalLocationFixture.GetReal_ED1_A001_U007(), string.Empty, createdBy, lastModifiedDateTime,
                null,0);      //ayman generic forms

            List<OnPremisePersonnel> onPremisePersonnelSupervisors = service.CreateDeletedOnPremisePersonnel(form, null);
            Assert.That(onPremisePersonnelSupervisors, Is.Not.Null);
            Assert.That(onPremisePersonnelSupervisors.Count, Is.EqualTo(6));
            Assert.That(onPremisePersonnelSupervisors, Has.All.Matches<OnPremisePersonnel>(item => item.CardEntryStatus == CardEntryStatus.UnKnown));
        }
    }
}