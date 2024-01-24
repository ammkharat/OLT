using System;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class WorkPermitLubesTest
    {
        [SetUp]
        public void Setup()
        {
            Clock.Freeze();
        }

        [TearDown]
        public void Teardown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void BuildPermitToSubmitShouldSetAdditionalFollowupRequiredIfHydrantPermitOrConfinedSpaceAreChecked()
        {
            PermitRequestLubes request = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(-1, "Group", 1));
            request.DocumentLinks.Clear();
            request.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink(1));
            request.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink(2));

            DateTime now = Clock.Now;
            User user = UserFixture.CreateUser();

            {
                request.HydrantPermit = false;
                request.ConfinedSpace = false;

                WorkPermitLubes workPermit = new WorkPermitLubes(now, user);
                workPermit.BuildPermitToSubmit(request, user, now, new Date(now), now);

                Assert.IsFalse(workPermit.AdditionalFollowupRequired);
            }

            {
                request.HydrantPermit = true;
                request.ConfinedSpace = false;

                WorkPermitLubes workPermit = new WorkPermitLubes(now, user);
                workPermit.BuildPermitToSubmit(request, user, now, new Date(now), now);

                Assert.IsTrue(workPermit.AdditionalFollowupRequired);
            }

            {
                request.HydrantPermit = false;
                request.ConfinedSpace = true;

                WorkPermitLubes workPermit = new WorkPermitLubes(now, user);
                workPermit.BuildPermitToSubmit(request, user, now, new Date(now), now);

                Assert.IsTrue(workPermit.AdditionalFollowupRequired);
            }
        }

        [Test]
        public void BuildPermitToSubmitShouldSetAtmosphericGasTestRequiredToTrueIfTypeIsHotOrConfinedSpaceIsSelected()
        {
            PermitRequestLubes request = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(-1, "Group", 1));

            DateTime now = Clock.Now;
            User user = UserFixture.CreateUser();

            {
                request.WorkPermitType = WorkPermitLubesType.HAZARDOUS_COLD_WORK;
                request.ConfinedSpace = false;

                WorkPermitLubes workPermit = new WorkPermitLubes(now, user);
                workPermit.BuildPermitToSubmit(request, user, now, new Date(now), now);

                Assert.IsFalse(workPermit.AtmosphericGasTestRequired);
            }

            {
                request.WorkPermitType = WorkPermitLubesType.HOT_WORK;
                request.ConfinedSpace = false;

                WorkPermitLubes workPermit = new WorkPermitLubes(now, user);
                workPermit.BuildPermitToSubmit(request, user, now, new Date(now), now);

                Assert.IsTrue(workPermit.AtmosphericGasTestRequired);
            }

            {
                request.WorkPermitType = WorkPermitLubesType.HAZARDOUS_COLD_WORK;
                request.ConfinedSpace = true;

                WorkPermitLubes workPermit = new WorkPermitLubes(now, user);
                workPermit.BuildPermitToSubmit(request, user, now, new Date(now), now);

                Assert.IsTrue(workPermit.AtmosphericGasTestRequired);
            }
        }

        [Test]
        public void ShouldDetermineIfIsDay()
        {
            Assert.IsTrue(WorkPermitLubes.IsDayShift(new Time(5, 30)));
            Assert.IsTrue(WorkPermitLubes.IsDayShift(new Time(17, 29, 59)));

            Assert.IsFalse(WorkPermitLubes.IsDayShift(new Time(17, 30)));
            Assert.IsFalse(WorkPermitLubes.IsDayShift(new Time(5, 29, 59)));
        }

        [Test]
        public void PermitCreatedFromRequestShouldHaveAStartDateTimeComprisedOfTheDateFromTheUserSpecifiedDateAndTheTimeFromThePermitStartDateTime()
        {
            WorkPermitLubesGroup group = new WorkPermitLubesGroup(0, "Group1", 0);
            PermitRequestLubes permitRequest = PermitRequestLubesFixture.CreateForInsert(group);
            WorkPermitLubes workPermitLubes = WorkPermitLubesFixture.CreateForInsert(group);

            Date userSpecifiedDate = new Date(2012, 12, 2);
            DateTime permitStartDateTime = new DateTime(2012, 11, 29, 13, 0, 0);
            workPermitLubes.BuildPermitToSubmit(permitRequest, UserFixture.CreateUser(), Clock.Now, userSpecifiedDate, permitStartDateTime);

            Assert.AreEqual(userSpecifiedDate.CreateDateTime(permitStartDateTime.ToTime()), workPermitLubes.StartDateTime);
        }

        [Test]
        public void PermitCreatedFromRequestShouldHaveAnExpireDateBasedOnTheEndOfTheShiftAndATimeSetTo430()
        {
            Clock.Now = new DateTime(2012, 11, 28, 5, 0, 0);

            WorkPermitLubesGroup group = new WorkPermitLubesGroup(0, "Group1", 0);
            PermitRequestLubes permitRequest = PermitRequestLubesFixture.CreateForInsert(group);
            WorkPermitLubes workPermitLubes = WorkPermitLubesFixture.CreateForInsert(group);

            {
                Date userSpecifiedDate = new Date(2012, 12, 2);
                DateTime permitStartDateTime = new DateTime(2012, 11, 29, 20, 0, 0);
                workPermitLubes.BuildPermitToSubmit(permitRequest, UserFixture.CreateUser(), Clock.Now, userSpecifiedDate, permitStartDateTime);

                Assert.AreEqual(new DateTime(2012, 12, 3, 4, 30, 0), workPermitLubes.ExpireDateTime);                
            }

            {
                Date userSpecifiedDate = new Date(2012, 12, 2);
                DateTime permitStartDateTime = new DateTime(2012, 11, 29, 13, 0, 0);
                workPermitLubes.BuildPermitToSubmit(permitRequest, UserFixture.CreateUser(), Clock.Now, userSpecifiedDate, permitStartDateTime);

                Assert.AreEqual(new DateTime(2012, 12, 2, 16, 30, 0), workPermitLubes.ExpireDateTime);
            }
        }

        [Test]
        public void CloningShouldNotCopyOverCertainProperties()
        {
            DateTime now = new DateTime(2013, 5, 14, 13, 50, 0);
            User user = UserFixture.CreateOperatingEngineer();

            WorkPermitLubes permit = WorkPermitLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "hi", 1));

            permit.Id = 1;
            permit.PermitNumber = 123;
            permit.IssuedDateTime = new DateTime(2012, 1, 2);
            permit.IssuedBy = user;
            permit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Complete;
            permit.LastModifiedBy = UserFixture.CreateOperator();
            permit.DataSource = DataSource.MANUAL;
            permit.StartDateTime = new DateTime(2012, 1, 2);
            permit.ExpireDateTime = new DateTime(2012, 1, 2);
            
            permit.HighEnergy = WorkPermitSafetyFormState.Approved;
            permit.CriticalLift = WorkPermitSafetyFormState.NotApplicable;
            permit.Excavation = WorkPermitSafetyFormState.Required;
            permit.EnergyControlPlanFormRequirement = WorkPermitSafetyFormState.Approved;
            permit.EquivalencyProc = WorkPermitSafetyFormState.NotApplicable;
            permit.TestPneumatic = WorkPermitSafetyFormState.Required;
            permit.LiveFlareWork = WorkPermitSafetyFormState.Approved;
            permit.EntryAndControlPlan = WorkPermitSafetyFormState.NotApplicable;
            permit.EnergizedElectrical = WorkPermitSafetyFormState.Approved;

            permit.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink(1));

            permit.ConvertToClone(now, user);

            Assert.IsNull(permit.Id);
            Assert.IsNull(permit.PermitNumber);
            Assert.AreEqual(PermitRequestBasedWorkPermitStatus.Complete, permit.WorkPermitStatus);
            Assert.AreEqual(user.FullNameWithUserName, permit.CreatedBy.FullNameWithUserName);
            Assert.AreEqual(user.FullNameWithUserName, permit.LastModifiedBy.FullNameWithUserName);
            Assert.AreEqual(now, permit.CreatedDateTime);
            Assert.AreEqual(now, permit.LastModifiedDateTime);
            Assert.IsNull(permit.IssuedDateTime);
            Assert.IsNull(permit.IssuedBy);
            Assert.AreEqual(DataSource.CLONE, permit.DataSource);
            Assert.AreEqual(now, permit.StartDateTime);
            Assert.AreEqual(new DateTime(2013, 5, 14, 16, 30, 0), permit.ExpireDateTime);
            Assert.AreEqual(1, permit.DocumentLinks.Count);

            Assert.AreEqual(WorkPermitSafetyFormState.Required, permit.HighEnergy);
            Assert.AreEqual(WorkPermitSafetyFormState.NotApplicable, permit.CriticalLift);
            Assert.AreEqual(WorkPermitSafetyFormState.Required, permit.Excavation);
            Assert.AreEqual(WorkPermitSafetyFormState.Required, permit.EnergyControlPlanFormRequirement);
            Assert.AreEqual(WorkPermitSafetyFormState.NotApplicable, permit.EquivalencyProc);
            Assert.AreEqual(WorkPermitSafetyFormState.Required, permit.TestPneumatic);
            Assert.AreEqual(WorkPermitSafetyFormState.Required, permit.LiveFlareWork);
            Assert.AreEqual(WorkPermitSafetyFormState.NotApplicable, permit.EntryAndControlPlan);
            Assert.AreEqual(WorkPermitSafetyFormState.Required, permit.EnergizedElectrical);
        }

        [Test]
        public void CloningShouldSetExpiredTimeToFourThirtyAmIfItIsTheNightShift()
        {
            DateTime now = new DateTime(2013, 5, 14, 22, 59, 0);
            User user = UserFixture.CreateOperatingEngineer();

            WorkPermitLubes permit = WorkPermitLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "hi", 1));
            permit.ExpireDateTime = new DateTime(2012, 1, 2);

            permit.ConvertToClone(now, user);

            Assert.AreEqual(new DateTime(2013, 5, 15, 4, 30, 0), permit.ExpireDateTime);            
        }

        [Test]
        public void CloningShouldSetPermitRequestRelatedPropertiesToNull()
        {
            DateTime now = new DateTime(2013, 5, 14, 22, 59, 0);
            User user = UserFixture.CreateOperatingEngineer();

            WorkPermitLubes permit = WorkPermitLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "hi", 1));
            permit.PermitRequestSubmittedByUser = user;
            permit.PermitRequestCreatedByUser = user;
            permit.PermitRequestDataSource = DataSource.SAP;

            permit.ConvertToClone(now, user);

            Assert.IsNull(permit.PermitRequestSubmittedByUser);
            Assert.IsNull(permit.PermitRequestCreatedByUser);
            Assert.IsNull(permit.PermitRequestDataSource);
        }

        [Test]
        public void CloningShouldSetNewVersionToTheCurrentVersion()
        {
            DateTime now = new DateTime(2013, 5, 14, 22, 59, 0);
            User user = UserFixture.CreateOperatingEngineer();

            WorkPermitLubes permit = WorkPermitLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "hi", 1));
            permit.PermitRequestSubmittedByUser = user;
            permit.PermitRequestCreatedByUser = user;
            permit.PermitRequestDataSource = DataSource.SAP;

            permit.ConvertToClone(now, user);

            Assert.AreEqual(Common.Utility.Constants.CURRENT_VERSION, permit.Version);
        }

        [Test]
        public void CopyingShouldNotCopyTheIssuedByAndSubmittedByProperties()
        {
            User user1 = UserFixture.CreateUserWithGivenId(1);
            User user2 = UserFixture.CreateUserWithGivenId(2);

            WorkPermitLubes permit = WorkPermitLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "hi", 1));
            permit.IssuedDateTime = Clock.Now;
            permit.IssuedBy = UserFixture.CreateUser();
            permit.PermitRequestSubmittedByUser = user1;

            WorkPermitLubes nextDayPermit = WorkPermitLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "hi", 1));
            nextDayPermit.PermitRequestSubmittedByUser = user2;
            permit.CopyContentsIntoNextDayPermit(ref nextDayPermit);

            Assert.IsNull(nextDayPermit.IssuedBy);
            Assert.IsNull(nextDayPermit.IssuedDateTime);
            Assert.AreEqual(user2.Id, nextDayPermit.PermitRequestSubmittedByUser.Id);
        }

        [Test]
        public void CopyingShouldNotCopyTheStartAndEndDateTimes()
        {
            DateTime startDateTimeOfNextDayPermit = new DateTime(2013, 9, 6, 12, 0, 0);
            DateTime endDateTimeOfNextDayPermit = new DateTime(2013, 9, 6, 17, 0, 0);

            WorkPermitLubes permit = WorkPermitLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "hi", 1));
            permit.StartDateTime = new DateTime(2013, 9, 5, 13, 59, 0);
            permit.ExpireDateTime = new DateTime(2013, 9, 5, 18, 52, 0);

            WorkPermitLubes nextDayPermit = WorkPermitLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "hi", 1));
            nextDayPermit.StartDateTime = startDateTimeOfNextDayPermit;
            nextDayPermit.ExpireDateTime = endDateTimeOfNextDayPermit;
            
            permit.CopyContentsIntoNextDayPermit(ref nextDayPermit);

            Assert.AreEqual(startDateTimeOfNextDayPermit, nextDayPermit.StartDateTime);
            Assert.AreEqual(endDateTimeOfNextDayPermit, nextDayPermit.ExpireDateTime);
        }

        [Test]
        public void CopyingShouldCreateAVersionWithTheCurrentVersion()
        {
        
            WorkPermitLubes permit = WorkPermitLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "hi", 1));
            permit.StartDateTime = new DateTime(2013, 9, 5, 13, 59, 0);
            permit.ExpireDateTime = new DateTime(2013, 9, 5, 18, 52, 0);

            WorkPermitLubes nextDayPermit = WorkPermitLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "hi", 1));
            
            permit.CopyContentsIntoNextDayPermit(ref nextDayPermit);

            Assert.AreEqual(nextDayPermit.Version, Common.Utility.Constants.CURRENT_VERSION);
        }

        [Test]
        public void CopyingShouldCopyTheWorkOrderAndOpAndSubOpNumbers()
        {
            WorkPermitLubes permit = WorkPermitLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "hi", 1));
            permit.WorkOrderNumber = "wo#";
            permit.OperationNumber = "op#";
            permit.SubOperationNumber = "so#";            

            WorkPermitLubes nextDayPermit = WorkPermitLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "hi", 1));
            nextDayPermit.WorkOrderNumber = "n1";
            permit.OperationNumber = "n2";
            permit.SubOperationNumber = "n3";

            permit.CopyContentsIntoNextDayPermit(ref nextDayPermit);

            Assert.AreEqual(permit.WorkOrderNumber, nextDayPermit.WorkOrderNumber);
            Assert.AreEqual(permit.OperationNumber, nextDayPermit.OperationNumber);
            Assert.AreEqual(permit.SubOperationNumber, nextDayPermit.SubOperationNumber);
        }
    }
}
