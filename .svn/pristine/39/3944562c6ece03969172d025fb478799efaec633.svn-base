using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using WorkPermitDO = Com.Suncor.Olt.Common.Domain.WorkPermit.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class WorkPermitTest
    {
        [SetUp]
        public void SetUp()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldBeSerializable()
        {
            Assert.IsTrue(typeof(WorkPermitDO).IsSerializable);
        }

        [Test]
        public void ShouldBeDerivedFromDomainObject()
        {
            Assert.AreEqual(typeof(DomainObject), typeof(WorkPermitDO).BaseType);
        }

        [Test]
        public void ShouldBeAbleToSetDifferentPiecesOfWorkPermit()
        {
            WorkPermitDO workPermit = WorkPermitFixture.CreateWorkPermit();
            Assert.IsNotNull(workPermit.RadiationInformation);
            Assert.IsNotNull(workPermit.RespiratoryProtectionRequirements);
            Assert.IsNotNull(workPermit.FireConfinedSpaceRequirements);
            Assert.IsNotNull(workPermit.Tools);
            Assert.IsNotNull(workPermit.JobWorksitePreparation);
            Assert.IsNotNull(workPermit.AdditionItemsRequired);
            Assert.IsNotNull(workPermit.EquipmentPreparationCondition);
            Assert.IsNotNull(workPermit.SpecialProtectionRequirements);
        }

        [Test]
        public void ShouldCopyNotificationAndAuthorizationToAnotherWorkPermit()
        {
            var original = new WorkPermitDO(SiteFixture.Sarnia())
                               {
                                   IsCoauthorizationRequired = true,
                                   CoauthorizationDescription = TestUtil.RandomString()                                   
                               };

            var another = new WorkPermitDO(SiteFixture.Sarnia());
            original.CopyNotificationAuthorizationTo(another);

            Assert.AreEqual(original.IsCoauthorizationRequired, another.IsCoauthorizationRequired);
            Assert.AreEqual(original.CoauthorizationDescription, another.CoauthorizationDescription);
        }

        [Test]
        public void ShouldDetermineIfSpecialPrecautionsOrConsiderationsHasData()
        {
            var permit = new WorkPermitDO(SiteFixture.Sarnia());
            Assert.IsFalse(permit.SpecialPrecautionsOrConsiderationsHasData());
            permit.SpecialPrecautionsOrConsiderations = TestUtil.RandomString();
            Assert.IsTrue(permit.SpecialPrecautionsOrConsiderationsHasData());
        }

        [Test]
        public void ShouldDetermineIfNotificationAuthorizationHasData()
        {
            var permit = new WorkPermitDO(SiteFixture.Sarnia());
            Assert.IsFalse(permit.NotificationAuthorizationHasData());
            permit.CoauthorizationDescription = TestUtil.RandomString();
            Assert.IsTrue(permit.NotificationAuthorizationHasData());
        }

        [Test]
        public void ShouldHaveDataIfAnySectionHasData()
        {
            WorkPermitDO permit = WorkPermitWithNoData();
            permit.Tools.IsAirTools = true;
            Assert.IsTrue(permit.HasData());

            permit = WorkPermitWithNoData();
            permit.EquipmentPreparationCondition.ConditionPurgedDescription = TestUtil.RandomString();
            Assert.IsTrue(permit.HasData());

            permit = WorkPermitWithNoData();
            permit.FireConfinedSpaceRequirements.IsC02Extinguisher = true;
            Assert.IsTrue(permit.HasData());

            permit = WorkPermitWithNoData();
            permit.RespiratoryProtectionRequirements.IsAirCartorAirLine = true;
            Assert.IsTrue(permit.HasData());

            permit = WorkPermitWithNoData();
            permit.SpecialProtectionRequirements.IsEyeOrFaceProtectionGoggles = true;
            Assert.IsTrue(permit.HasData());

            permit = WorkPermitWithNoData();
            permit.SpecialPrecautionsOrConsiderations = TestUtil.RandomString();
            Assert.IsTrue(permit.HasData());

            permit = WorkPermitWithNoData();
            permit.GasTests.ConstantMonitoringRequired = true;
            Assert.IsTrue(permit.HasData());

            permit = WorkPermitWithNoData();
            permit.CoauthorizationDescription = TestUtil.RandomString();
            Assert.IsTrue(permit.HasData());
        }

        [Test]
        public void ShouldSetApprovedByOnCreatingApprovedWorkPermit()
        {
            WorkPermitDO permit = WorkPermitFixture.CreateWorkPermit(WorkPermitStatus.Approved);
            Assert.IsNotNull(permit.ApprovedBy);
        }

        [Test]
        public void ShouldEvaluateIfPermitIsOperations()
        {
            Assert.IsFalse(CreateWorkPermit(false).IsOperations);
            Assert.IsTrue(CreateWorkPermit(true).IsOperations);
        }

        [Test]
        public void ShouldSetNullToApprovedByOnChangingStatusToPendingOrRejected()
        {
            User approvedBy = UserFixture.CreateSupervisor();

            foreach (WorkPermitStatus status in WorkPermitStatus.All)
            {
                WorkPermitDO approvedPermit = WorkPermitFixture.CreateWorkPermit(WorkPermitStatus.Approved);
                Assert.IsNotNull(approvedPermit.ApprovedBy);

                approvedPermit.SetWorkPermitStatusAndApprover(status, approvedBy);
                if (status == WorkPermitStatus.Pending || status == WorkPermitStatus.Rejected)
                    Assert.IsNull(approvedPermit.ApprovedBy);
                else
                    Assert.IsNotNull(approvedPermit.ApprovedBy);
            }
        }

        [Test]
        public void ShouldBeAbleToTellIfAWorkPermitIsEffectiveInsideAShift()
        {
            var sixAM = new Time(6, 0, 0);
            var sixPM = new Time(18, 0, 0);

            ShiftPattern shiftPattern = ShiftPatternFixture.CreateShiftPattern(sixAM, sixPM);
            var userShift = new UserShift(shiftPattern, new DateTime(2005, 5, 15, 11, 0, 0));

            WorkPermitDO workPermit = WorkPermitFixture.CreateWorkPermit();
            workPermit.Specifics.StartDateTime = new DateTime(2005, 3, 15, 14, 0, 0);
            workPermit.Specifics.EndDateTime = new DateTime(2005, 12, 15);

            Assert.IsTrue(workPermit.IsEffectiveInUserShift(userShift));
        }

        // This is for historical reasons - there was a misunderstanding about how Work Permit start/end dates work.
        [Test]
        public void ShouldBeAbleToTellIfAWorkPermitIsEffectiveInsideAShiftEvenIfTheShiftTimeIsOutsideTheStartEndTimes()
        {
            var sixAM = new Time(6, 0, 0);
            var sixPM = new Time(18, 0, 0);

            ShiftPattern shiftPattern = ShiftPatternFixture.CreateShiftPattern(sixAM, sixPM);
            var userShift = new UserShift(shiftPattern, new DateTime(2005, 5, 15, 11, 0, 0));

            WorkPermitDO workPermit = WorkPermitFixture.CreateWorkPermit();
            workPermit.Specifics.StartDateTime = new DateTime(2005, 3, 15, 5, 0, 0);
            workPermit.Specifics.EndDateTime = new DateTime(2005, 12, 15, 5, 30, 0);

            Assert.IsTrue(workPermit.IsEffectiveInUserShift(userShift));
        }

        [Test]
        public void ShouldBeAbleToTellIfAWorkPermitIsNotEffectiveInsideAShift()
        {
            var sixAM = new Time(6, 0, 0);
            var sixPM = new Time(18, 0, 0);

            ShiftPattern shiftPattern = ShiftPatternFixture.CreateShiftPattern(sixAM, sixPM);
            var userShift = new UserShift(shiftPattern, new DateTime(2005, 2, 15, 11, 0, 0));

            WorkPermitDO workPermit = WorkPermitFixture.CreateWorkPermit();
            workPermit.Specifics.StartDateTime = new DateTime(2005, 3, 15, 14, 0, 0);
            workPermit.Specifics.EndDateTime = new DateTime(2005, 12, 15);

            Assert.IsFalse(workPermit.IsEffectiveInUserShift(userShift));
        }

        [Test]
        public void ShouldBeAbleToCompareTwoWorkPermitsWithEqualOperator()
        {
            Clock.Freeze();

            WorkPermitDO workPermit1 = WorkPermitFixture.CreateABigManualWorkPermitWithNoID(Clock.Now);
            WorkPermitDO workPermit2 = WorkPermitFixture.CreateABigManualWorkPermitWithNoID(Clock.Now);

            workPermit1.GasTests = WorkPermitGasTestsFixture.CreateWorkPermitGasTestsWith2EmptyElements();
            workPermit2.GasTests = WorkPermitGasTestsFixture.CreateWorkPermitGasTestsWith2EmptyElements();

            // just making sure
            Assert.AreNotSame(workPermit1, workPermit2);

            Assert.AreEqual(workPermit1, workPermit2);
        }

        [Test]
        public void ShouldEvaluateIfPermitHasEditableStatus()
        {
            Assert.IsTrue(CreateWorkPermit(WorkPermitStatus.Pending).HasEditableStatus());
            Assert.IsTrue(CreateWorkPermit(WorkPermitStatus.Rejected).HasEditableStatus());
            Assert.IsFalse(CreateWorkPermit(WorkPermitStatus.Approved).HasEditableStatus());
            Assert.IsFalse(CreateWorkPermit(WorkPermitStatus.Issued).HasEditableStatus());
            Assert.IsFalse(CreateWorkPermit(WorkPermitStatus.Complete).HasEditableStatus());
        }

        [Test]
        public void DescriptionShouldBuildStringOfSpecificWorkPermitInformation()
        {
            WorkPermitDO workPermit = WorkPermitFixture.CreateWorkPermit();
            WorkPermitSpecifics specifics = workPermit.Specifics;
            workPermit.PermitNumber = "WP-Test";
            
            Assert.IsTrue(workPermit.Description().Contains(workPermit.PermitNumber));
            Assert.IsTrue(workPermit.Description().Contains(workPermit.WorkPermitType.Name));
            Assert.IsTrue(workPermit.Description().Contains(specifics.WorkOrderNumber));
            Assert.IsTrue(workPermit.Description().Contains(specifics.FunctionalLocationName));
            Assert.IsTrue(workPermit.Description().Contains(specifics.CraftOrTradeName));
            Assert.IsTrue(workPermit.Description().Contains(specifics.WorkOrderDescription));
            Assert.IsTrue(workPermit.Description().Contains(specifics.JobStepDescription));
        }

        [Test]
        public void InitializeWithSensibleDefaultsShouldSetPermitStartAndEndDateTimesAccordingToPreferencesForDenver()
        {
            DateTime now = new DateTime(2006, 7, 24, 00, 17, 00);

            User user = UserFixture.CreateUser(SiteFixture.Denver());
            WorkPermitDO workPermit = WorkPermitFixture.CreateWorkPermit(user, true);
            user.WorkPermitDefaultTimePreferences =
                UserWorkPermitDefaultTimePreferencesFixture.Create(new TimeSpan(02, 00, 00), 
                                                                   new TimeSpan(01, 00, 00));

            UserShift userShift = UserShiftFixture.CreateUserShift(new Time(18, 00), new Time(06, 00), now);
            workPermit.InitializeWithSensibleDefaults(CraftOrTradeFixture.CreateCraftOrTradeWelder(),
                                                      user, true, now, SiteConfigurationFixture.CreateSiteConfiguration(), userShift, SiteSpecificHandlerFactory.GetDateTimeHandler(SiteFixture.Denver()));

            Assert.AreEqual(new DateTime(2006, 7, 24, 20, 00, 00), workPermit.StartDateTime);
            Assert.AreEqual(new DateTime(2006, 7, 25, 05, 00, 00), workPermit.EndDateTime);
        }

        [Test]
        public void InitializeWithSensibleDefaultsShouldSetPermitStartDateTimeToNow()
        {
            DateTime now = new DateTime(2006, 7, 24, 00, 17, 00);
        
            User user = UserFixture.CreateUser(SiteFixture.Sarnia());
            WorkPermitDO workPermit = WorkPermitFixture.CreateWorkPermit(user, true);
            user.WorkPermitDefaultTimePreferences =
                UserWorkPermitDefaultTimePreferencesFixture.Create(new TimeSpan(02, 00, 00),
                                                                   new TimeSpan(01, 00, 00));

            UserShift userShift = UserShiftFixture.CreateUserShift(new Time(18, 00), new Time(06, 00), now);
            workPermit.InitializeWithSensibleDefaults(CraftOrTradeFixture.CreateCraftOrTradeWelder(),
                                                      user, true, now, SiteConfigurationFixture.CreateSiteConfiguration(), userShift, SiteSpecificHandlerFactory.GetDateTimeHandler(SiteFixture.Sarnia()));

            Assert.AreEqual(new DateTime(2006, 7, 24, 00, 17, 00), workPermit.StartDateTime);
            Assert.AreEqual(new DateTime(2006, 7, 25, 05, 00, 00), workPermit.EndDateTime);
        
        }


        [Test]
        public void InitializeWithSensibleDefaultsShouldSetNotApplicablePropertiesToFalseInSections()
        {
            TestInitializeWithSensibleDefaultsShouldSetNotApplicablePropertiesInSections(false);
        }

        [Test]
        public void InitializeWithSensibleDefaultsShouldSetNotApplicablePropertiesToTrueInSections()
        {
            TestInitializeWithSensibleDefaultsShouldSetNotApplicablePropertiesInSections(true);
        }

        private static void TestInitializeWithSensibleDefaultsShouldSetNotApplicablePropertiesInSections(bool workPermitNotApplicableAutoSelected)
        {
            SiteConfiguration siteConfiguration = 
                SiteConfigurationFixture.CreateWorkPermitNotApplicableAutoSelected(workPermitNotApplicableAutoSelected);

            WorkPermitDO workPermit = WorkPermitFixture.CreateWorkPermit();
            User user = UserFixture.CreateUser();
            workPermit.InitializeWithSensibleDefaults(CraftOrTradeFixture.CreateCraftOrTradeWelder(),
                                                      user, true, DateTimeFixture.DateTimeNow, siteConfiguration, null, SiteSpecificHandlerFactory.GetDateTimeHandler(user.AvailableSites[0]));
            
            // Since each section has already been individually tested for initializing with the site configuration,
            // here, we just sample one N/A property from each section to test that the site configuration was passed on:
            Assert.AreEqual(workPermitNotApplicableAutoSelected, workPermit.Specifics.Communication.IsWorkPermitCommunicationNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, workPermit.EquipmentPreparationCondition.IsElectricalIsolationMethodNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, workPermit.JobWorksitePreparation.IsBondingOrGroundingRequiredNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, workPermit.RadiationInformation.IsSealedSourceIsolationNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, workPermit.RespiratoryProtectionRequirements.IsNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, workPermit.SpecialProtectionRequirements.IsEyeOrFaceProtectionNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, workPermit.FireConfinedSpaceRequirements.IsNotApplicable);
        }

        [Test]
        public void InitializeWithSensibleDefaultsShouldSetPermitTypeOptionsToNullIfNotAutoSelected()
        {
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateWorkPermitOptionAutoSelected(false);
            WorkPermitDO workPermit = WorkPermitFixture.CreateWorkPermit();
            User user = UserFixture.CreateUser();
            workPermit.InitializeWithSensibleDefaults(CraftOrTradeFixture.CreateCraftOrTradeWelder(),
                                                      user, true, DateTimeFixture.DateTimeNow, siteConfiguration, null, SiteSpecificHandlerFactory.GetDateTimeHandler(user.AvailableSites[0]));
            
            Assert.IsNull(workPermit.WorkPermitType);
            Assert.IsNull(workPermit.WorkPermitTypeClassification);
        }
        
        [Test]
        public void ShouldReturnCloneOfDocumentLinksWithoutIds()
        {
            WorkPermitDO workPermit = WorkPermitFixture.CreateValidWorkPermit(1);
            workPermit.DocumentLinks = DocumentLinkFixture.CreateDocumentLinkListWithIds(2);
            List<DocumentLink> clonedLinks = workPermit.CloneDocumentLinksWithoutIds();
            Assert.AreEqual(workPermit.DocumentLinks[0].Title, clonedLinks[0].Title);
            Assert.AreEqual(workPermit.DocumentLinks[0].TitleWithUrl, clonedLinks[0].TitleWithUrl);
            Assert.AreEqual(null, clonedLinks[0].Id);
        }

        private static WorkPermitDO WorkPermitWithNoData()
        {
            var permit = new WorkPermitDO(SiteFixture.Sarnia());
            Assert.IsFalse(permit.HasData());
            return permit;
        }

        private static WorkPermitDO CreateWorkPermit(bool isOperations)
        {
            WorkPermitDO permit = WorkPermitFixture.CreateWorkPermit();
            permit.SetCreatedBy(permit.CreatedBy, isOperations);
            return permit;
        }

        private static WorkPermitDO CreateWorkPermit(WorkPermitStatus status)
        {
            return WorkPermitFixture.CreateWorkPermit(status);
        }
    }
}
