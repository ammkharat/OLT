using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    public class PermitRequestLubesDaoTest : AbstractDaoTest
    {
        private IPermitRequestLubesDao permitRequestDao;
        private IPermitRequestLubesDTODao dtoDao;
        private IWorkPermitLubesGroupDao groupDao;

        protected override void TestInitialize()
        {
            permitRequestDao = DaoRegistry.GetDao<IPermitRequestLubesDao>();
            dtoDao = DaoRegistry.GetDao<IPermitRequestLubesDTODao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitLubesGroupDao>();
        }

        protected override void Cleanup()
        {
            
        }

        [Ignore] [Test]
        public void ShouldInsertAndQueryById()
        {
            List<WorkPermitLubesGroup> workPermitLubesGroups = groupDao.QueryAll();

            PermitRequestLubes permitRequest = PermitRequestLubesFixture.CreateForInsert(workPermitLubesGroups[0]);
            permitRequest.WorkPermitType = WorkPermitLubesType.HOT_WORK;
            permitRequest.IsVehicleEntry = true;

            permitRequest.DocumentLinks.Add(new DocumentLink("http://hello.ca", "This is a website"));
            permitRequest.DocumentLinks.Add(new DocumentLink("http://cnn.com", "News"));

            permitRequestDao.Insert(permitRequest);
            Assert.That(permitRequest.Id, Is.GreaterThan(0));

            PermitRequestLubes requeriedPermitRequest = permitRequestDao.QueryById(permitRequest.IdValue);

            AssertPermitFieldValues(permitRequest, requeriedPermitRequest);
            Assert.AreEqual(2, permitRequest.DocumentLinks.Count);
            
            Assert.IsTrue(requeriedPermitRequest.DocumentLinks.Exists(dl => dl.Url == "http://hello.ca" && dl.Title == "This is a website"));
            Assert.IsTrue(requeriedPermitRequest.DocumentLinks.Exists(dl => dl.Url == "http://cnn.com" && dl.Title == "News"));
        }

        [Ignore] [Test]
        public void ShouldQueryByWorkOrderNumberOpNumberSubOpNumber()
        {
            List<WorkPermitLubesGroup> workPermitLubesGroups = groupDao.QueryAll();
            PermitRequestLubes permitRequest = PermitRequestLubesFixture.CreateForInsert(workPermitLubesGroups[0], DataSource.SAP);

            permitRequest.ClearWorkOrderSources();
            permitRequest.AddWorkOrderSource("424242", "1234", "7890");
       
            PermitRequestLubes resultFromInsert = permitRequestDao.Insert(permitRequest);

            List<PermitRequestLubes> results = permitRequestDao.QueryByWorkOrderNumberAndOperationAndSource("424242", "1234", "7890", DataSource.SAP);
            Assert.IsTrue(results.Exists(r => r.Id == resultFromInsert.Id));
        }

        [Ignore] [Test]        
        public void QueryPermitRequestLubesByDateRangeAndDataSource()
        {
            List<WorkPermitLubesGroup> workPermitLubesGroups = groupDao.QueryAll();
            PermitRequestLubes permitRequest = PermitRequestLubesFixture.CreateForInsert(workPermitLubesGroups[0], DataSource.SAP);
            permitRequestDao.Insert(permitRequest);
            
            List<PermitRequestLubes> result = permitRequestDao.QueryByDateRangeAndDataSource(permitRequest.RequestedStartDate, permitRequest.EndDate, DataSource.SAP);

            Assert.IsTrue(result.Exists(r => r.Id == permitRequest.Id));
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {
            List<WorkPermitLubesGroup> workPermitLubesGroups = groupDao.QueryAll();

            PermitRequestLubes permitRequest = PermitRequestLubesFixture.CreateForInsert(workPermitLubesGroups[0]);
            permitRequest.DocumentLinks.Add(new DocumentLink("http://hello.ca", "This is a website"));
            permitRequest.DocumentLinks.Add(new DocumentLink("http://cnn.com", "News"));

            permitRequestDao.Insert(permitRequest);

            PermitRequestLubes permitRequestToUpdate = permitRequestDao.QueryById(permitRequest.IdValue);
            
            {
                DateTime later = new DateTime(2012, 2, 16, 9, 0, 0);
                User updatedBy = UserFixture.CreateUserWithGivenId(1);
                FunctionalLocation newFloc = FunctionalLocationFixture.GetReal_ED1_A001_U008();

                UpdateSomeValues(permitRequestToUpdate, updatedBy, later, workPermitLubesGroups[1], newFloc);

                permitRequestDao.Update(permitRequestToUpdate);

                PermitRequestLubes requeriedPermitRequest = permitRequestDao.QueryById(permitRequestToUpdate.IdValue);
                AssertPermitFieldValues(permitRequestToUpdate, requeriedPermitRequest);
                
                Assert.AreEqual(1, requeriedPermitRequest.DocumentLinks.Count);                
                Assert.IsTrue(requeriedPermitRequest.DocumentLinks.Exists(dl => dl.Title == "New title" && dl.Url == "http://new.com"));
            }            
            
        }

        [Ignore] [Test]
        public void ShouldRemove()
        {
            List<WorkPermitLubesGroup> workPermitLubesGroups = groupDao.QueryAll();

            PermitRequestLubes permit = PermitRequestLubesFixture.CreateForInsert(workPermitLubesGroups[0]);
            PermitRequestLubes requestFromInsert = permitRequestDao.Insert(permit);

            DateRange range = new DateRange(permit.RequestedStartDate, permit.RequestedStartDate);

            {
                List<PermitRequestLubesDTO> result = dtoDao.QueryByDateRangeAndFlocs(new RootFlocSet(new List<FunctionalLocation> {permit.FunctionalLocation}), range);
                Assert.IsTrue(result.Exists(dto => dto.IdValue == requestFromInsert.IdValue));
            }

            permitRequestDao.Remove(requestFromInsert);

            {
                List<PermitRequestLubesDTO> result = dtoDao.QueryByDateRangeAndFlocs(new RootFlocSet(new List<FunctionalLocation> { permit.FunctionalLocation }), range);
                Assert.IsFalse(result.Exists(dto => dto.IdValue == requestFromInsert.IdValue));
            }
        }

        private void UpdateSomeValues(PermitRequestLubes permitRequest, User updatedBy, DateTime later, WorkPermitLubesGroup group, FunctionalLocation newFloc)
        {
            permitRequest.DocumentLinks.Clear();
            permitRequest.DocumentLinks.Add(new DocumentLink("http://new.com", "New title"));

            permitRequest.CompletionStatus = PermitRequestCompletionStatus.Incomplete;
            permitRequest.IssuedToSuncor = !permitRequest.IssuedToSuncor;
            permitRequest.IssuedToCompany = !permitRequest.IssuedToCompany;
            permitRequest.Trade = "Trade2";
            permitRequest.SAPWorkCentre = "DEF456";
            permitRequest.NumberOfWorkers = 43;
            permitRequest.RequestedByGroup = group;
            permitRequest.WorkPermitType = WorkPermitLubesType.HOT_WORK;
            permitRequest.IsVehicleEntry = true;
            permitRequest.FunctionalLocation = newFloc;
            permitRequest.Location = "Location2";
            permitRequest.ConfinedSpace = !permitRequest.ConfinedSpace;
            permitRequest.ConfinedSpaceClass = "CS class2";
            permitRequest.RescuePlan = !permitRequest.RescuePlan;
            permitRequest.ConfinedSpaceSafetyWatchChecklist = !permitRequest.ConfinedSpaceSafetyWatchChecklist;
            permitRequest.SpecialWork = !permitRequest.SpecialWork;
            permitRequest.SpecialWorkType = "SW Type2";
            permitRequest.RequestedStartDate = new Date(later);
            permitRequest.RequestedStartTimeDay = new Time(later);
            permitRequest.RequestedStartTimeNight = new Time(later);
  
            permitRequest.ClearWorkOrderSources();
            permitRequest.AddWorkOrderSource("123456", "1112", "2223");

            permitRequest.HighEnergy = WorkPermitSafetyFormState.Required;
            permitRequest.CriticalLift = WorkPermitSafetyFormState.NotApplicable;
            permitRequest.Excavation = WorkPermitSafetyFormState.Required;
            permitRequest.EnergyControlPlan = WorkPermitSafetyFormState.Approved;
            permitRequest.EquivalencyProc = WorkPermitSafetyFormState.NotApplicable;
            permitRequest.TestPneumatic = WorkPermitSafetyFormState.Required;
            permitRequest.LiveFlareWork = WorkPermitSafetyFormState.Approved;
            permitRequest.EntryAndControlPlan = WorkPermitSafetyFormState.NotApplicable;
            permitRequest.EnergizedElectrical = WorkPermitSafetyFormState.NotApplicable;
            permitRequest.HazardHydrocarbonGas = !permitRequest.HazardHydrocarbonGas;
            permitRequest.HazardHydrocarbonLiquid = !permitRequest.HazardHydrocarbonLiquid;
            permitRequest.HazardHydrogenSulphide = !permitRequest.HazardHydrogenSulphide;
            permitRequest.HazardInertGasAtmosphere = !permitRequest.HazardInertGasAtmosphere;
            permitRequest.HazardOxygenDeficiency = !permitRequest.HazardOxygenDeficiency;
            permitRequest.HazardRadioactiveSources = !permitRequest.HazardRadioactiveSources;
            permitRequest.HazardUndergroundOverheadHazards = !permitRequest.HazardUndergroundOverheadHazards;
            permitRequest.HazardDesignatedSubstance = !permitRequest.HazardDesignatedSubstance;
            permitRequest.OtherHazardsAndOrRequirements = "Other hazards2";
            permitRequest.OtherAreasAndOrUnitsAffected = !permitRequest.OtherAreasAndOrUnitsAffected;
            permitRequest.OtherAreasAndOrUnitsAffectedArea = "affected area2";
            permitRequest.OtherAreasAndOrUnitsAffectedPersonNotified = "person notified2";
            permitRequest.SpecificRequirementsSectionNotApplicableToJob = !permitRequest.SpecificRequirementsSectionNotApplicableToJob;
            permitRequest.AttendedAtAllTimes = !permitRequest.AttendedAtAllTimes;
            permitRequest.EyeProtection = !permitRequest.EyeProtection;
            permitRequest.FallProtectionEquipment = !permitRequest.FallProtectionEquipment;
            permitRequest.FullBodyHarnessRetrieval = !permitRequest.FullBodyHarnessRetrieval;
            permitRequest.HearingProtection = !permitRequest.HearingProtection;
            permitRequest.ProtectiveClothing = !permitRequest.ProtectiveClothing;
            permitRequest.Other1Checked = !permitRequest.Other1Checked;
            permitRequest.Other1Value = "other 1 val2";
            permitRequest.EquipmentBondedGrounded = !permitRequest.EquipmentBondedGrounded;
            permitRequest.FireBlanket = !permitRequest.FireBlanket;
            permitRequest.FireFightingEquipment = !permitRequest.FireFightingEquipment;
            permitRequest.FireWatch = !permitRequest.FireWatch;
            permitRequest.HydrantPermit = !permitRequest.HydrantPermit;
            permitRequest.WaterHose = !permitRequest.WaterHose;
            permitRequest.SteamHose = !permitRequest.SteamHose;
            permitRequest.Other2Checked = !permitRequest.Other2Checked;
            permitRequest.Other2Value = "Other 2 val2";
            permitRequest.AirMover = !permitRequest.AirMover;
            permitRequest.ContinuousGasMonitor = !permitRequest.ContinuousGasMonitor;
            permitRequest.DrowningProtection = !permitRequest.DrowningProtection;
            permitRequest.RespiratoryProtection = !permitRequest.RespiratoryProtection;
            permitRequest.Other3Checked = !permitRequest.Other3Checked;
            permitRequest.Other3Value = "other 3 val2";
            permitRequest.AdditionalLighting = !permitRequest.AdditionalLighting;
            permitRequest.DesignateHotOrColdCutChecked = !permitRequest.DesignateHotOrColdCutChecked;
            permitRequest.DesignateHotOrColdCutValue = "dhocc2";
            permitRequest.HoistingEquipment = !permitRequest.HoistingEquipment;
            permitRequest.Ladder = !permitRequest.Ladder;
            permitRequest.MotorizedEquipment = !permitRequest.MotorizedEquipment;
            permitRequest.Scaffold = !permitRequest.Scaffold;
            permitRequest.ReferToTipsProcedure = !permitRequest.ReferToTipsProcedure;
            permitRequest.GasDetectorBumpTested = !permitRequest.GasDetectorBumpTested;
        }

        public void AssertPermitFieldValues(PermitRequestLubes permitRequest, PermitRequestLubes requeriedPermitRequest)
        {
            Assert.AreEqual(permitRequest.Company, requeriedPermitRequest.Company);
            Assert.AreEqual(permitRequest.DataSource, requeriedPermitRequest.DataSource);
            Assert.AreEqual(permitRequest.CompletionStatus, requeriedPermitRequest.CompletionStatus);
            Assert.AreEqual(permitRequest.IssuedToSuncor, requeriedPermitRequest.IssuedToSuncor);
            Assert.AreEqual(permitRequest.IssuedToCompany, requeriedPermitRequest.IssuedToCompany);
            Assert.AreEqual(permitRequest.Trade, requeriedPermitRequest.Trade);
            Assert.AreEqual(permitRequest.SAPWorkCentre, requeriedPermitRequest.SAPWorkCentre);
            Assert.AreEqual(permitRequest.NumberOfWorkers, requeriedPermitRequest.NumberOfWorkers);
            Assert.AreEqual(permitRequest.RequestedByGroup, requeriedPermitRequest.RequestedByGroup);
            Assert.AreEqual(permitRequest.WorkPermitType, requeriedPermitRequest.WorkPermitType);
            Assert.AreEqual(permitRequest.IsVehicleEntry, requeriedPermitRequest.IsVehicleEntry);
            Assert.AreEqual(permitRequest.FunctionalLocation, requeriedPermitRequest.FunctionalLocation);
            Assert.AreEqual(permitRequest.Location, requeriedPermitRequest.Location);
            Assert.AreEqual(permitRequest.Description, requeriedPermitRequest.Description);
            Assert.AreEqual(permitRequest.SapDescription, requeriedPermitRequest.SapDescription);            
            Assert.AreEqual(permitRequest.ConfinedSpace, requeriedPermitRequest.ConfinedSpace);
            Assert.AreEqual(permitRequest.ConfinedSpaceClass, requeriedPermitRequest.ConfinedSpaceClass);
            Assert.AreEqual(permitRequest.RescuePlan, requeriedPermitRequest.RescuePlan);
            Assert.AreEqual(permitRequest.ConfinedSpaceSafetyWatchChecklist, requeriedPermitRequest.ConfinedSpaceSafetyWatchChecklist);
            Assert.AreEqual(permitRequest.SpecialWork, requeriedPermitRequest.SpecialWork);
            Assert.AreEqual(permitRequest.SpecialWorkType, requeriedPermitRequest.SpecialWorkType);
            Assert.AreEqual(permitRequest.RequestedStartDate, requeriedPermitRequest.RequestedStartDate);
            Assert.AreEqual(permitRequest.RequestedStartTimeDay, requeriedPermitRequest.RequestedStartTimeDay);
            Assert.AreEqual(permitRequest.RequestedStartTimeNight, requeriedPermitRequest.RequestedStartTimeNight);
            Assert.AreEqual(permitRequest.EndDate, requeriedPermitRequest.EndDate);

            Assert.AreEqual(1, requeriedPermitRequest.WorkOrderSourceList.Count);
            Assert.AreEqual(permitRequest.WorkOrderSourceList[0], requeriedPermitRequest.WorkOrderSourceList[0]);

            Assert.AreEqual(permitRequest.HighEnergy, requeriedPermitRequest.HighEnergy);
            Assert.AreEqual(permitRequest.CriticalLift, requeriedPermitRequest.CriticalLift);
            Assert.AreEqual(permitRequest.Excavation, requeriedPermitRequest.Excavation);
            Assert.AreEqual(permitRequest.EnergyControlPlan, requeriedPermitRequest.EnergyControlPlan);
            Assert.AreEqual(permitRequest.EquivalencyProc, requeriedPermitRequest.EquivalencyProc);
            Assert.AreEqual(permitRequest.TestPneumatic, requeriedPermitRequest.TestPneumatic);
            Assert.AreEqual(permitRequest.LiveFlareWork, requeriedPermitRequest.LiveFlareWork);
            Assert.AreEqual(permitRequest.EntryAndControlPlan, requeriedPermitRequest.EntryAndControlPlan);
            Assert.AreEqual(permitRequest.EnergizedElectrical, requeriedPermitRequest.EnergizedElectrical);
            Assert.AreEqual(permitRequest.HazardHydrocarbonGas, requeriedPermitRequest.HazardHydrocarbonGas);
            Assert.AreEqual(permitRequest.HazardHydrocarbonLiquid, requeriedPermitRequest.HazardHydrocarbonLiquid);
            Assert.AreEqual(permitRequest.HazardHydrogenSulphide, requeriedPermitRequest.HazardHydrogenSulphide);
            Assert.AreEqual(permitRequest.HazardInertGasAtmosphere, requeriedPermitRequest.HazardInertGasAtmosphere);
            Assert.AreEqual(permitRequest.HazardOxygenDeficiency, requeriedPermitRequest.HazardOxygenDeficiency);
            Assert.AreEqual(permitRequest.HazardRadioactiveSources, requeriedPermitRequest.HazardRadioactiveSources);
            Assert.AreEqual(permitRequest.HazardUndergroundOverheadHazards, requeriedPermitRequest.HazardUndergroundOverheadHazards);
            Assert.AreEqual(permitRequest.HazardDesignatedSubstance, requeriedPermitRequest.HazardDesignatedSubstance);
            Assert.AreEqual(permitRequest.OtherHazardsAndOrRequirements, requeriedPermitRequest.OtherHazardsAndOrRequirements);
            Assert.AreEqual(permitRequest.OtherAreasAndOrUnitsAffected, requeriedPermitRequest.OtherAreasAndOrUnitsAffected);
            Assert.AreEqual(permitRequest.OtherAreasAndOrUnitsAffectedArea, requeriedPermitRequest.OtherAreasAndOrUnitsAffectedArea);
            Assert.AreEqual(permitRequest.OtherAreasAndOrUnitsAffectedPersonNotified, requeriedPermitRequest.OtherAreasAndOrUnitsAffectedPersonNotified);
            Assert.AreEqual(permitRequest.SpecificRequirementsSectionNotApplicableToJob, requeriedPermitRequest.SpecificRequirementsSectionNotApplicableToJob);
            Assert.AreEqual(permitRequest.AttendedAtAllTimes, requeriedPermitRequest.AttendedAtAllTimes);
            Assert.AreEqual(permitRequest.EyeProtection, requeriedPermitRequest.EyeProtection);
            Assert.AreEqual(permitRequest.FallProtectionEquipment, requeriedPermitRequest.FallProtectionEquipment);
            Assert.AreEqual(permitRequest.FullBodyHarnessRetrieval, requeriedPermitRequest.FullBodyHarnessRetrieval);
            Assert.AreEqual(permitRequest.HearingProtection, requeriedPermitRequest.HearingProtection);
            Assert.AreEqual(permitRequest.ProtectiveClothing, requeriedPermitRequest.ProtectiveClothing);
            Assert.AreEqual(permitRequest.Other1Checked, requeriedPermitRequest.Other1Checked);
            Assert.AreEqual(permitRequest.Other1Value, requeriedPermitRequest.Other1Value);
            Assert.AreEqual(permitRequest.EquipmentBondedGrounded, requeriedPermitRequest.EquipmentBondedGrounded);
            Assert.AreEqual(permitRequest.FireBlanket, requeriedPermitRequest.FireBlanket);
            Assert.AreEqual(permitRequest.FireFightingEquipment, requeriedPermitRequest.FireFightingEquipment);
            Assert.AreEqual(permitRequest.FireWatch, requeriedPermitRequest.FireWatch);
            Assert.AreEqual(permitRequest.HydrantPermit, requeriedPermitRequest.HydrantPermit);
            Assert.AreEqual(permitRequest.WaterHose, requeriedPermitRequest.WaterHose);
            Assert.AreEqual(permitRequest.SteamHose, requeriedPermitRequest.SteamHose);
            Assert.AreEqual(permitRequest.Other2Checked, requeriedPermitRequest.Other2Checked);
            Assert.AreEqual(permitRequest.Other2Value, requeriedPermitRequest.Other2Value);
            Assert.AreEqual(permitRequest.AirMover, requeriedPermitRequest.AirMover);
            Assert.AreEqual(permitRequest.ContinuousGasMonitor, requeriedPermitRequest.ContinuousGasMonitor);
            Assert.AreEqual(permitRequest.DrowningProtection, requeriedPermitRequest.DrowningProtection);
            Assert.AreEqual(permitRequest.RespiratoryProtection, requeriedPermitRequest.RespiratoryProtection);
            Assert.AreEqual(permitRequest.Other3Checked, requeriedPermitRequest.Other3Checked);
            Assert.AreEqual(permitRequest.Other3Value, requeriedPermitRequest.Other3Value);
            Assert.AreEqual(permitRequest.AdditionalLighting, requeriedPermitRequest.AdditionalLighting);
            Assert.AreEqual(permitRequest.DesignateHotOrColdCutChecked, requeriedPermitRequest.DesignateHotOrColdCutChecked);
            Assert.AreEqual(permitRequest.DesignateHotOrColdCutValue, requeriedPermitRequest.DesignateHotOrColdCutValue);
            Assert.AreEqual(permitRequest.HoistingEquipment, requeriedPermitRequest.HoistingEquipment);
            Assert.AreEqual(permitRequest.Ladder, requeriedPermitRequest.Ladder);
            Assert.AreEqual(permitRequest.MotorizedEquipment, requeriedPermitRequest.MotorizedEquipment);
            Assert.AreEqual(permitRequest.Scaffold, requeriedPermitRequest.Scaffold);
            Assert.AreEqual(permitRequest.ReferToTipsProcedure, requeriedPermitRequest.ReferToTipsProcedure);
            Assert.AreEqual(permitRequest.GasDetectorBumpTested, requeriedPermitRequest.GasDetectorBumpTested);
            Assert.AreEqual(permitRequest.LastImportedByUser.IdValue, requeriedPermitRequest.LastImportedByUser.IdValue);
            Assert.AreEqual(permitRequest.LastImportedDateTime, requeriedPermitRequest.LastImportedDateTime);
            Assert.AreEqual(permitRequest.LastSubmittedByUser.IdValue, requeriedPermitRequest.LastSubmittedByUser.IdValue);
            Assert.AreEqual(permitRequest.LastSubmittedDateTime, requeriedPermitRequest.LastSubmittedDateTime);
            Assert.AreEqual(permitRequest.CreatedBy.IdValue, requeriedPermitRequest.CreatedBy.IdValue);
            Assert.AreEqual(permitRequest.CreatedDateTime, requeriedPermitRequest.CreatedDateTime);
            Assert.AreEqual(permitRequest.LastModifiedBy.IdValue, requeriedPermitRequest.LastModifiedBy.IdValue);
            Assert.AreEqual(permitRequest.LastModifiedDateTime, requeriedPermitRequest.LastModifiedDateTime);
            Assert.AreEqual(permitRequest.CreatedByRole.IdValue, requeriedPermitRequest.CreatedByRole.IdValue);
        }
    }
}
