using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]    
    public class WorkPermitLubesDaoTest : AbstractDaoTest
    {
        private IWorkPermitLubesDao permitDao;
        private IPermitRequestLubesDao permitRequestDao;
        private IWorkPermitLubesDTODao dtoDao;
        private IWorkPermitLubesGroupDao groupDao;

        protected override void TestInitialize()
        {
            permitDao = DaoRegistry.GetDao<IWorkPermitLubesDao>();
            permitRequestDao = DaoRegistry.GetDao<IPermitRequestLubesDao>();
            dtoDao = DaoRegistry.GetDao<IWorkPermitLubesDTODao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitLubesGroupDao>();
        }

        protected override void Cleanup()
        {
            
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            List<WorkPermitLubesGroup> workPermitLubesGroups = groupDao.QueryAll();

            WorkPermitLubes permit = WorkPermitLubesFixture.CreateForInsert(workPermitLubesGroups[0]);
            
            permit.DocumentLinks.Add(new DocumentLink("http://hello.ca", "This is a website"));
            permit.DocumentLinks.Add(new DocumentLink("http://cnn.com", "News"));

            permitDao.Insert(permit, null);
            Assert.That(permit.Id, Is.GreaterThan(0));

            WorkPermitLubes requeriedPermit = permitDao.QueryById(permit.IdValue);

            AssertPermitFieldValues(permit, requeriedPermit);
            Assert.AreEqual(2, permit.DocumentLinks.Count);
            Assert.IsTrue(permit.DocumentLinks.Exists(dl => dl.Url == "http://hello.ca" && dl.Title == "This is a website"));
            Assert.IsTrue(permit.DocumentLinks.Exists(dl => dl.Url == "http://cnn.com" && dl.Title == "News"));
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {            
            List<WorkPermitLubesGroup> workPermitLubesGroups = groupDao.QueryAll();

            WorkPermitLubes permit = WorkPermitLubesFixture.CreateForInsert(workPermitLubesGroups[0]);
            permit.DocumentLinks.Add(new DocumentLink("http://hello.ca", "This is a website"));
            permit.DocumentLinks.Add(new DocumentLink("http://cnn.com", "News"));

            permitDao.Insert(permit, null);

            WorkPermitLubes permitToUpdate = permitDao.QueryById(permit.IdValue);

            Assert.IsNull(permitToUpdate.IssuedDateTime);

            {
                DateTime later = new DateTime(2012, 2, 16, 9, 0, 0);
                User updatedBy = UserFixture.CreateUserWithGivenId(1);
                FunctionalLocation newFloc = FunctionalLocationFixture.GetReal_ED1_A001_U008();

                UpdateSomeValues(permitToUpdate, updatedBy, later, workPermitLubesGroups[1], newFloc);

                permitDao.Update(permitToUpdate);

                WorkPermitLubes requeriedPermit = permitDao.QueryById(permitToUpdate.IdValue);
                AssertPermitFieldValues(permitToUpdate, requeriedPermit);
                Assert.AreEqual(1, requeriedPermit.DocumentLinks.Count);
                Assert.IsNotNull(requeriedPermit.IssuedDateTime);
                Assert.AreEqual(later, requeriedPermit.IssuedDateTime);
                Assert.IsTrue(requeriedPermit.DocumentLinks.Exists(dl => dl.Title == "New title" && dl.Url == "http://new.com"));
            }            
        }

        [Ignore] [Test]
        public void ShouldRemove()
        {
            List<WorkPermitLubesGroup> workPermitLubesGroups = groupDao.QueryAll();

            WorkPermitLubes permit = WorkPermitLubesFixture.CreateForInsert(workPermitLubesGroups[0]);
            WorkPermitLubes permitFromInsert = permitDao.Insert(permit, null);

            Range<Date> range = new Range<Date>(permit.StartDateTime.ToDate(), permit.StartDateTime.ToDate());

            {
                List<WorkPermitLubesDTO> result = dtoDao.QueryByDateRangeAndFlocs(range, new RootFlocSet(new List<FunctionalLocation> {permit.FunctionalLocation}));
                Assert.IsTrue(result.Exists(dto => dto.IdValue == permitFromInsert.IdValue));                
            }

            permitDao.Remove(permitFromInsert);

            {                
                List<WorkPermitLubesDTO> result = dtoDao.QueryByDateRangeAndFlocs(range, new RootFlocSet(new List<FunctionalLocation> { permit.FunctionalLocation }));
                Assert.IsFalse(result.Exists(dto => dto.IdValue == permitFromInsert.IdValue));                
            }
        }

        [Ignore] [Test]
        public void ShouldKnowIfPermitRequestLubesAssociationExists()
        {
            List<WorkPermitLubesGroup> groups = groupDao.QueryAll();
            WorkPermitLubesGroup group = groups[0];

            PermitRequestLubes permitRequestAssociated = PermitRequestLubesFixture.CreateForInsert(group);
            PermitRequestLubes permitRequestAssociatedFromDb = permitRequestDao.Insert(permitRequestAssociated);

            PermitRequestLubes permitRequestUnassociated = PermitRequestLubesFixture.CreateForInsert(group);
            PermitRequestLubes permitRequestUnassociatedFromDb = permitRequestDao.Insert(permitRequestUnassociated);

            WorkPermitLubes workPermitWithAssociation = WorkPermitLubesFixture.CreateForInsert(group);
            workPermitWithAssociation.IssuedDateTime = workPermitWithAssociation.StartDateTime;
            permitDao.Insert(workPermitWithAssociation, permitRequestAssociatedFromDb.Id);

            DateTime issuedDateTimeForPermit = workPermitWithAssociation.IssuedDateTime.Value;

            Range<DateTime> workPermitIssuedRange = new Range<DateTime>(issuedDateTimeForPermit.AddHours(-1), issuedDateTimeForPermit.AddHours(1));
            Assert.True(permitDao.DoesPermitRequestLubesAssociationExist(new List<long> { new PermitRequestLubesDTO(permitRequestAssociatedFromDb).IdValue }, workPermitIssuedRange));
            Assert.False(permitDao.DoesPermitRequestLubesAssociationExist(new List<long> { new PermitRequestLubesDTO(permitRequestUnassociatedFromDb).IdValue }, workPermitIssuedRange));

            workPermitIssuedRange = new Range<DateTime>(issuedDateTimeForPermit.AddDays(1), issuedDateTimeForPermit.AddDays(2));
            Assert.False(permitDao.DoesPermitRequestLubesAssociationExist(new List<long> { new PermitRequestLubesDTO(permitRequestAssociatedFromDb).IdValue }, workPermitIssuedRange));
        }

        [Ignore] [Test]
        public void ShouldKnowIfPermitRequestLubesAssociationExistsWhenPermitIsIssuedBeforeStartDate()
        {
            List<WorkPermitLubesGroup> groups = groupDao.QueryAll();
            WorkPermitLubesGroup group = groups[0];

            PermitRequestLubes permitRequestAssociated = PermitRequestLubesFixture.CreateForInsert(group);
            permitRequestAssociated.RequestedStartDate = new Date(2013, 9, 11);
            permitRequestAssociated.RequestedStartTimeDay = new Time(8, 0, 0);
            permitRequestDao.Insert(permitRequestAssociated);

            WorkPermitLubes workPermitWithAssociation = WorkPermitLubesFixture.CreateForInsert(group);
            workPermitWithAssociation.StartDateTime = new DateTime(2013, 9, 11, 8, 0, 0);
            workPermitWithAssociation.ExpireDateTime = new DateTime(2013, 9, 11, 15, 0, 0);
            permitDao.Insert(workPermitWithAssociation, permitRequestAssociated.Id);
            
            // insert doesn't set issueddatetime so we have to update to set it
            workPermitWithAssociation.IssuedDateTime = new DateTime(2013, 9, 10, 8, 0, 0);   // issued a day before the start and expire date
            permitDao.Update(workPermitWithAssociation);

            UserShift userShift = WorkPermitLubes.UserShift(new DateTime(2013, 9, 11, 8, 0, 0));
            bool doesPermitRequestLubesAssociationExist = permitDao.DoesPermitRequestLubesAssociationExist(new List<long> { permitRequestAssociated.IdValue }, userShift.DateTimeRangeWithoutPadding);
            Assert.IsTrue(doesPermitRequestLubesAssociationExist);
        }

        [Ignore] [Test]
        public void ShouldFindPermitFromPreviousDateAssociatedToSamePermitRequest()
        {
            List<WorkPermitLubesGroup> groups = groupDao.QueryAll();
            WorkPermitLubesGroup group = groups[0];

            PermitRequestLubes permitRequest = PermitRequestLubesFixture.CreateForInsert(group);
            permitRequestDao.Insert(permitRequest);

            WorkPermitLubes previousPermit = WorkPermitLubesFixture.CreateForInsert(group);
            previousPermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Issued;
            previousPermit.IssuedDateTime = new DateTime(2013, 5, 6);
            WorkPermitLubes insertedPreviousPermit = permitDao.Insert(previousPermit, permitRequest.Id);
            permitDao.Update(insertedPreviousPermit);

            WorkPermitLubes currentPermit = WorkPermitLubesFixture.CreateForInsert(group);
            currentPermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Pending;
            currentPermit.IssuedDateTime = previousPermit.IssuedDateTime.Value.AddHours(1); // make sure the second permit's issued date/time is after the first one.

            WorkPermitLubes insertedCurrentPermit = permitDao.Insert(currentPermit, permitRequest.Id);

            WorkPermitLubes previousDayIssuedPermitForSamePermitRequest = permitDao.QueryPreviousDayIssuedPermitForSamePermitRequest(insertedCurrentPermit);

            Assert.That(previousDayIssuedPermitForSamePermitRequest, Is.Not.Null);
            Assert.That(previousDayIssuedPermitForSamePermitRequest.IdValue, Is.EqualTo(insertedPreviousPermit.IdValue));
        }

        [Ignore] [Test]
        public void ShouldFindPermitFromPreviousDateAssociatedToSamePermitRequest_ButOnlyIfThePreviousPermitHasBeenIssued()
        {
            List<WorkPermitLubesGroup> groups = groupDao.QueryAll();
            WorkPermitLubesGroup group = groups[0];

            PermitRequestLubes permitRequest = PermitRequestLubesFixture.CreateForInsert(group);
            permitRequestDao.Insert(permitRequest);

            // no show that was never issued.
            WorkPermitLubes previousPermit = WorkPermitLubesFixture.CreateForInsert(group);
            previousPermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.NoShow;
            previousPermit.IssuedDateTime = null;

            permitDao.Insert(previousPermit, permitRequest.Id);

            WorkPermitLubes currentPermit = WorkPermitLubesFixture.CreateForInsert(group);
            currentPermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Pending;
            permitDao.Insert(currentPermit, permitRequest.Id);

            WorkPermitLubes previousDayIssuedPermitForSamePermitRequest = permitDao.QueryPreviousDayIssuedPermitForSamePermitRequest(currentPermit);

            Assert.That(previousDayIssuedPermitForSamePermitRequest, Is.Null);
        }

        [Ignore] [Test]
        public void ShouldFetchDataSourceFromAssociatedPermitRequest()
        {
            List<WorkPermitLubesGroup> groups = groupDao.QueryAll();
            WorkPermitLubesGroup group = groups[0];

            PermitRequestLubes permitRequest = PermitRequestLubesFixture.CreateForInsert(group, DataSource.SAP);
            permitRequestDao.Insert(permitRequest);

            WorkPermitLubes workPermitWithAssociation = WorkPermitLubesFixture.CreateForInsert(group);
            workPermitWithAssociation.IssuedDateTime = workPermitWithAssociation.StartDateTime;
            permitDao.Insert(workPermitWithAssociation, permitRequest.Id);

            WorkPermitLubes requeriedPermit = permitDao.QueryById(workPermitWithAssociation.IdValue);
            Assert.AreEqual(DataSource.SAP, requeriedPermit.PermitRequestDataSource);
        }

        private void UpdateSomeValues(WorkPermitLubes permit, User createdBy, DateTime now, WorkPermitLubesGroup group, FunctionalLocation floc)
        {
            permit.LastModifiedBy = createdBy;
            permit.LastModifiedDateTime = now;
            permit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Merged;
            //permit.DataSource = DataSource.TARGET; // doesn't update

            permit.IssuedDateTime = now;
            permit.IssuedBy = createdBy;

            permit.IssuedToSuncor = false;
            permit.IssuedToCompany = false;
            permit.Company = "company 2";

            permit.Trade = "trade 2";
            permit.NumberOfWorkers = 4;
            permit.RequestedByGroup = group;
            permit.WorkPermitType = WorkPermitLubesType.HOT_WORK;
            permit.FunctionalLocation = floc;
            permit.Location = "location 2";

            permit.DocumentLinks.Clear();
            permit.DocumentLinks.Add(new DocumentLink("http://new.com", "New title"));
            
            permit.WorkOrderNumber = "33ABC";
            permit.OperationNumber = "4411";
            permit.SubOperationNumber = "5522";

            permit.StartDateTime = now;
            permit.ExpireDateTime = now.AddHours(8);

            permit.ConfinedSpace = false;
            permit.ConfinedSpaceClass = "csc2";
            permit.RescuePlan = false;
            permit.ConfinedSpaceSafetyWatchChecklist = false;
            permit.SpecialWork = false;
            permit.SpecialWorkType = "special 2";
            permit.HazardousWorkApproverAdvised = false;
            permit.AdditionalFollowupRequired = false;

            permit.HighEnergy = WorkPermitSafetyFormState.NotApplicable;
            permit.CriticalLift = WorkPermitSafetyFormState.NotApplicable;
            permit.Excavation = WorkPermitSafetyFormState.NotApplicable;
            permit.EnergyControlPlanFormRequirement = WorkPermitSafetyFormState.NotApplicable;
            permit.EquivalencyProc = WorkPermitSafetyFormState.NotApplicable;
            permit.TestPneumatic = WorkPermitSafetyFormState.NotApplicable;
            permit.LiveFlareWork = WorkPermitSafetyFormState.NotApplicable;
            permit.EntryAndControlPlan = WorkPermitSafetyFormState.NotApplicable;
            permit.EnergizedElectrical = WorkPermitSafetyFormState.NotApplicable;

            permit.TaskDescription = "New Desc";

            permit.HazardHydrocarbonGas = false;
            permit.HazardHydrocarbonLiquid = false;
            permit.HazardHydrogenSulphide = false;
            permit.HazardInertGasAtmosphere = false;
            permit.HazardOxygenDeficiency = false;
            permit.HazardRadioactiveSources = false;
            permit.HazardUndergroundOverheadHazards = false;
            permit.HazardDesignatedSubstance = false;

            permit.OtherHazardsAndOrRequirements = "other haz 2";

            permit.OtherAreasAndOrUnitsAffected = false;
            permit.OtherAreasAndOrUnitsAffectedArea = "area 2";
            permit.OtherAreasAndOrUnitsAffectedPersonNotified = "pnot 2";

            permit.ProductNormallyInPipingEquipment = "wat 2";

            permit.DepressuredDrained = YesNoNotApplicable.NO;
            permit.WaterWashed = YesNoNotApplicable.NO;
            permit.ChemicallyWashed = YesNoNotApplicable.NO;
            permit.Steamed = YesNoNotApplicable.NO;
            permit.Purged = YesNoNotApplicable.NO;
            permit.Disconnected = YesNoNotApplicable.NO;

            permit.DepressuredAndVented = YesNoNotApplicable.NO;
            permit.Ventilated = YesNoNotApplicable.NO;
            permit.Blanked = YesNoNotApplicable.NO;
            permit.DrainsCovered = YesNoNotApplicable.NO;
            permit.AreaBarricaded = YesNoNotApplicable.NO;

            permit.EnergySourcesLockedOutTaggedOut = YesNoNotApplicable.NO;
            permit.EnergyControlPlan = "ecp 2";
            permit.LockBoxNumber = "lbn 2";
            permit.OtherPreparations = "othprep 2";

            permit.SpecificRequirementsSectionNotApplicableToJob = false;

            permit.AttendedAtAllTimes = false;
            permit.EyeProtection = false;
            permit.FallProtectionEquipment = false;
            permit.FullBodyHarnessRetrieval = false;
            permit.HearingProtection = false;
            permit.ProtectiveClothing = false;
            permit.Other1Checked = false;
            permit.Other1Value = "oth1";

            permit.EquipmentBondedGrounded = false;
            permit.FireBlanket = false;
            permit.FireFightingEquipment = false;
            permit.FireWatch = false;
            permit.HydrantPermit = false;
            permit.WaterHose = false;
            permit.SteamHose = false;
            permit.Other2Checked = false;
            permit.Other2Value = "oth22";

            permit.AirMover = false;
            permit.ContinuousGasMonitor = false;
            permit.DrowningProtection = false;
            permit.RespiratoryProtection = false;
            permit.Other3Checked = false;
            permit.Other3Value = "oth32";

            permit.AdditionalLighting = false;
            permit.DesignateHotOrColdCutChecked = false;
            permit.DesignateHotOrColdCutValue = "desig2";
            permit.HoistingEquipment = false;
            permit.Ladder = false;
            permit.MotorizedEquipment = false;
            permit.Scaffold = false;
            permit.ReferToTipsProcedure = false;

            permit.GasDetectorBumpTested = false;
            permit.AtmosphericGasTestRequired = false;

            permit.UsePreviousPermitAnswered = true;
        }

        private void AssertPermitFieldValues(WorkPermitLubes permit, WorkPermitLubes requeriedPermit)
        {
            Assert.That(permit.LastModifiedDateTime, Is.EqualTo(requeriedPermit.LastModifiedDateTime).Within(TimeSpan.FromSeconds(1)));
            Assert.AreEqual(permit.LastModifiedBy.IdValue, requeriedPermit.LastModifiedBy.IdValue);

            Assert.AreEqual(permit.DataSource, requeriedPermit.DataSource);
            Assert.AreEqual(permit.WorkPermitStatus, requeriedPermit.WorkPermitStatus);

            Assert.AreEqual(permit.IssuedToSuncor, requeriedPermit.IssuedToSuncor);
            Assert.AreEqual(permit.IssuedToCompany, requeriedPermit.IssuedToCompany);
            Assert.AreEqual(permit.Company, requeriedPermit.Company);

            if (permit.IssuedBy == null)
            {
                Assert.IsNull(requeriedPermit.IssuedBy);
            }
            else
            {
                Assert.AreEqual(permit.IssuedBy.IdValue, requeriedPermit.IssuedBy.IdValue);
            }

            Assert.AreEqual(permit.IssuedDateTime, requeriedPermit.IssuedDateTime);

            if (permit.PermitRequestSubmittedByUser == null)
            {
                Assert.IsNull(requeriedPermit.PermitRequestSubmittedByUser);
            }
            else
            {
                Assert.AreEqual(permit.PermitRequestSubmittedByUser.IdValue, requeriedPermit.PermitRequestSubmittedByUser.IdValue);
            }

            Assert.AreEqual(permit.Version, requeriedPermit.Version);
            Assert.AreEqual(permit.Trade, requeriedPermit.Trade);
            Assert.AreEqual(permit.NumberOfWorkers, requeriedPermit.NumberOfWorkers);
            Assert.AreEqual(permit.RequestedByGroup.IdValue, requeriedPermit.RequestedByGroup.IdValue);
            Assert.AreEqual(permit.WorkPermitType, requeriedPermit.WorkPermitType);
            Assert.AreEqual(permit.IsVehicleEntry, requeriedPermit.IsVehicleEntry);

            Assert.AreEqual(permit.FunctionalLocation, requeriedPermit.FunctionalLocation);
            Assert.AreEqual(permit.Location, requeriedPermit.Location);

            Assert.AreEqual(permit.WorkOrderNumber, requeriedPermit.WorkOrderNumber);
            Assert.AreEqual(permit.OperationNumber, requeriedPermit.OperationNumber);
            Assert.AreEqual(permit.SubOperationNumber, requeriedPermit.SubOperationNumber);

            Assert.That(permit.StartDateTime, Is.EqualTo(requeriedPermit.StartDateTime).Within(TimeSpan.FromSeconds(1)));
            Assert.That(permit.ExpireDateTime, Is.EqualTo(requeriedPermit.ExpireDateTime).Within(TimeSpan.FromSeconds(1)));

            Assert.AreEqual(permit.ConfinedSpace, requeriedPermit.ConfinedSpace);
            Assert.AreEqual(permit.ConfinedSpaceClass, requeriedPermit.ConfinedSpaceClass);
            Assert.AreEqual(permit.RescuePlan, requeriedPermit.RescuePlan);
            Assert.AreEqual(permit.ConfinedSpaceSafetyWatchChecklist, requeriedPermit.ConfinedSpaceSafetyWatchChecklist);
            Assert.AreEqual(permit.SpecialWork, requeriedPermit.SpecialWork);
            Assert.AreEqual(permit.SpecialWorkType, requeriedPermit.SpecialWorkType);
            Assert.AreEqual(permit.HazardousWorkApproverAdvised, requeriedPermit.HazardousWorkApproverAdvised);
            Assert.AreEqual(permit.AdditionalFollowupRequired, requeriedPermit.AdditionalFollowupRequired);

            Assert.AreEqual(permit.HighEnergy, requeriedPermit.HighEnergy);
            Assert.AreEqual(permit.CriticalLift, requeriedPermit.CriticalLift);
            Assert.AreEqual(permit.Excavation, requeriedPermit.Excavation);
            Assert.AreEqual(permit.EnergyControlPlanFormRequirement, requeriedPermit.EnergyControlPlanFormRequirement);
            Assert.AreEqual(permit.EquivalencyProc, requeriedPermit.EquivalencyProc);
            Assert.AreEqual(permit.TestPneumatic, requeriedPermit.TestPneumatic);
            Assert.AreEqual(permit.LiveFlareWork, requeriedPermit.LiveFlareWork);
            Assert.AreEqual(permit.EntryAndControlPlan, requeriedPermit.EntryAndControlPlan);
            Assert.AreEqual(permit.EnergizedElectrical, requeriedPermit.EnergizedElectrical);

            Assert.AreEqual(permit.HazardHydrocarbonGas, requeriedPermit.HazardHydrocarbonGas);
            Assert.AreEqual(permit.HazardHydrocarbonLiquid, requeriedPermit.HazardHydrocarbonLiquid);
            Assert.AreEqual(permit.HazardHydrogenSulphide, requeriedPermit.HazardHydrogenSulphide);
            Assert.AreEqual(permit.HazardInertGasAtmosphere, requeriedPermit.HazardInertGasAtmosphere);
            Assert.AreEqual(permit.HazardOxygenDeficiency, requeriedPermit.HazardOxygenDeficiency);
            Assert.AreEqual(permit.HazardRadioactiveSources, requeriedPermit.HazardRadioactiveSources);
            Assert.AreEqual(permit.HazardUndergroundOverheadHazards, requeriedPermit.HazardUndergroundOverheadHazards);
            Assert.AreEqual(permit.HazardDesignatedSubstance, requeriedPermit.HazardDesignatedSubstance);

            Assert.AreEqual(permit.OtherHazardsAndOrRequirements, requeriedPermit.OtherHazardsAndOrRequirements);

            Assert.AreEqual(permit.OtherAreasAndOrUnitsAffected, requeriedPermit.OtherAreasAndOrUnitsAffected);
            Assert.AreEqual(permit.OtherAreasAndOrUnitsAffectedArea, requeriedPermit.OtherAreasAndOrUnitsAffectedArea);
            Assert.AreEqual(permit.OtherAreasAndOrUnitsAffectedPersonNotified, requeriedPermit.OtherAreasAndOrUnitsAffectedPersonNotified);

            Assert.AreEqual(permit.ProductNormallyInPipingEquipment, requeriedPermit.ProductNormallyInPipingEquipment);

            Assert.AreEqual(permit.DepressuredDrained, requeriedPermit.DepressuredDrained);
            Assert.AreEqual(permit.WaterWashed, requeriedPermit.WaterWashed);
            Assert.AreEqual(permit.ChemicallyWashed, requeriedPermit.ChemicallyWashed);
            Assert.AreEqual(permit.Steamed, requeriedPermit.Steamed);
            Assert.AreEqual(permit.Purged, requeriedPermit.Purged);
            Assert.AreEqual(permit.Disconnected, requeriedPermit.Disconnected);

            Assert.AreEqual(permit.DepressuredAndVented, requeriedPermit.DepressuredAndVented);
            Assert.AreEqual(permit.Ventilated, requeriedPermit.Ventilated);
            Assert.AreEqual(permit.Blanked, requeriedPermit.Blanked);
            Assert.AreEqual(permit.DrainsCovered, requeriedPermit.DrainsCovered);
            Assert.AreEqual(permit.AreaBarricaded, requeriedPermit.AreaBarricaded);

            Assert.AreEqual(permit.EnergySourcesLockedOutTaggedOut, requeriedPermit.EnergySourcesLockedOutTaggedOut);
            Assert.AreEqual(permit.EnergyControlPlan, requeriedPermit.EnergyControlPlan);
            Assert.AreEqual(permit.LockBoxNumber, requeriedPermit.LockBoxNumber);
            Assert.AreEqual(permit.OtherPreparations, requeriedPermit.OtherPreparations);

            Assert.AreEqual(permit.SpecificRequirementsSectionNotApplicableToJob, requeriedPermit.SpecificRequirementsSectionNotApplicableToJob);

            Assert.AreEqual(permit.AttendedAtAllTimes, requeriedPermit.AttendedAtAllTimes);
            Assert.AreEqual(permit.EyeProtection, requeriedPermit.EyeProtection);
            Assert.AreEqual(permit.FallProtectionEquipment, requeriedPermit.FallProtectionEquipment);
            Assert.AreEqual(permit.FullBodyHarnessRetrieval, requeriedPermit.FullBodyHarnessRetrieval);
            Assert.AreEqual(permit.HearingProtection, requeriedPermit.HearingProtection);
            Assert.AreEqual(permit.ProtectiveClothing, requeriedPermit.ProtectiveClothing);
            Assert.AreEqual(permit.Other1Checked, requeriedPermit.Other1Checked);
            Assert.AreEqual(permit.Other1Value, requeriedPermit.Other1Value);

            Assert.AreEqual(permit.EquipmentBondedGrounded, requeriedPermit.EquipmentBondedGrounded);
            Assert.AreEqual(permit.FireBlanket, requeriedPermit.FireBlanket);
            Assert.AreEqual(permit.FireFightingEquipment, requeriedPermit.FireFightingEquipment);
            Assert.AreEqual(permit.FireWatch, requeriedPermit.FireWatch);
            Assert.AreEqual(permit.HydrantPermit, requeriedPermit.HydrantPermit);
            Assert.AreEqual(permit.WaterHose, requeriedPermit.WaterHose);
            Assert.AreEqual(permit.SteamHose, requeriedPermit.SteamHose);
            Assert.AreEqual(permit.Other2Checked, requeriedPermit.Other2Checked);
            Assert.AreEqual(permit.Other2Value, requeriedPermit.Other2Value);

            Assert.AreEqual(permit.AirMover, requeriedPermit.AirMover);
            Assert.AreEqual(permit.ContinuousGasMonitor, requeriedPermit.ContinuousGasMonitor);
            Assert.AreEqual(permit.DrowningProtection, requeriedPermit.DrowningProtection);
            Assert.AreEqual(permit.RespiratoryProtection, requeriedPermit.RespiratoryProtection);
            Assert.AreEqual(permit.Other3Checked, requeriedPermit.Other3Checked);
            Assert.AreEqual(permit.Other3Value, requeriedPermit.Other3Value);

            Assert.AreEqual(permit.AdditionalLighting, requeriedPermit.AdditionalLighting);
            Assert.AreEqual(permit.DesignateHotOrColdCutChecked, requeriedPermit.DesignateHotOrColdCutChecked);
            Assert.AreEqual(permit.DesignateHotOrColdCutValue, requeriedPermit.DesignateHotOrColdCutValue);
            Assert.AreEqual(permit.HoistingEquipment, requeriedPermit.HoistingEquipment);
            Assert.AreEqual(permit.Ladder, requeriedPermit.Ladder);
            Assert.AreEqual(permit.MotorizedEquipment, requeriedPermit.MotorizedEquipment);
            Assert.AreEqual(permit.Scaffold, requeriedPermit.Scaffold);
            Assert.AreEqual(permit.ReferToTipsProcedure, requeriedPermit.ReferToTipsProcedure);

            Assert.AreEqual(permit.GasDetectorBumpTested, requeriedPermit.GasDetectorBumpTested);
            Assert.AreEqual(permit.AtmosphericGasTestRequired, requeriedPermit.AtmosphericGasTestRequired);

            Assert.AreEqual(permit.UsePreviousPermitAnswered, requeriedPermit.UsePreviousPermitAnswered);
        }

    }
}
