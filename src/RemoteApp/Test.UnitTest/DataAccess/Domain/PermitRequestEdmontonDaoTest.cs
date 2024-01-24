using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class PermitRequestEdmontonDaoTest : AbstractDaoTest
    {
        private IPermitRequestEdmontonDao dao;
        private FunctionalLocation flocForTesting;
        private IWorkPermitEdmontonGroupDao groupDao;

        private IFormGN75ADao formGN75ADao;
        private IFormGN1Dao formGN1Dao;

        private User sapUser;
        private WorkPermitEdmontonGroup group;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IPermitRequestEdmontonDao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitEdmontonGroupDao>();
            formGN75ADao = DaoRegistry.GetDao<IFormGN75ADao>();
            formGN1Dao = DaoRegistry.GetDao<IFormGN1Dao>();

            flocForTesting = FunctionalLocationFixture.GetReal("MT1-A001-IFST");
            group = groupDao.Insert(new WorkPermitEdmontonGroup(99, "Some Group asdfa", new List<long> { 1 }, 0, false));
            sapUser = UserFixture.CreateSAPUser();
        }

        protected override void Cleanup()
        {
        }

        private PermitRequestEdmonton CreateForInsert()
        {
            return PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, flocForTesting, group);
        }

        private PermitRequestEdmonton CreateForInsert(bool includeAWorkOrderSource)
        {
            return PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, flocForTesting, group, includeAWorkOrderSource);
        }

        private PermitRequestEdmonton CreateForInsert(DataSource dataSource)
        {
            return PermitRequestEdmontonFixture.CreateForInsert(dataSource, flocForTesting, group);
        }

        private PermitRequestEdmontonSAPImportData CreateRawImportDataForInsert(User createdBy)
        {
            return PermitRequestEdmontonSAPImportDataFixture.CreateForInsert(flocForTesting, group, createdBy);
        }
       
        [Ignore] [Test]
        public void ShouldInsertRawImportDataAsPermitRequest()
        {            
            PermitRequestEdmontonSAPImportData rawData = CreateRawImportDataForInsert(sapUser);
            rawData.SetCreatedInfo(sapUser, new DateTime(2013, 1, 23));
            rawData.CompletionStatus = PermitRequestCompletionStatus.Incomplete;
            PermitRequestEdmonton saved = dao.Insert(rawData);

            PermitRequestEdmonton requeried = dao.QueryById(saved.IdValue);

            AssertPermitRequestAgainstOriginal(requeried, rawData, true);
        }
        
        [Ignore] [Test] 
        public void ShouldInsert()
        {            
            PermitRequestEdmonton original = CreateForInsert(true);

            FormGN75A formGn75A = FormGN75AFixture.CreateForInsert(original.FunctionalLocation, original.RequestedStartDate.CreateDateTime(Time.NOON), original.EndDate.ToDateTimeAtEndOfDay(), FormStatus.Approved);
            formGN75ADao.Insert(formGn75A);
            original.FormGN75A = formGn75A;
            original.GN75A = true;

            FormGN1 formGN1 = FormGN1Fixture.CreateForInsert(original.FunctionalLocation, original.RequestedStartDate.CreateDateTime(Time.NOON), original.EndDate.ToDateTimeAtEndOfDay(), FormStatus.Approved);
            formGN1Dao.Insert(formGN1);
            original.FormGN1 = formGN1;
            original.GN1 = true;
            original.FormGN1TradeChecklistId = formGN1.TradeChecklists[0].Id;
            original.FormGN1TradeChecklistDisplayNumber = "ABC123";

            PermitRequestEdmonton saved = dao.Insert(original);

            PermitRequestEdmonton requeried = dao.QueryById(saved.IdValue);

            AssertPermitRequestAgainstOriginal(requeried, original);
        }

        private static void AssertPermitRequestAgainstOriginal(PermitRequestEdmonton requeried, PermitRequestEdmonton original)
        {
            AssertPermitRequestAgainstOriginal(requeried, original, false);
        }

        private static void AssertPermitRequestAgainstOriginal(PermitRequestEdmonton requeried, PermitRequestEdmonton original, bool isRawData)
        {
            Assert.AreEqual(original.CompletionStatus, requeried.CompletionStatus);
            Assert.AreEqual(original.EndDate, requeried.EndDate);
            Assert.AreEqual(original.Priority, requeried.Priority);
            
            Assert.AreEqual(original.WorkOrderSourceList.Count, requeried.WorkOrderSourceList.Count);
            Assert.AreEqual(1, original.WorkOrderSourceList.Count);
            Assert.AreEqual(original.WorkOrderSourceList[0], requeried.WorkOrderSourceList[0]);

            Assert.AreEqual(original.WorkOrderNumber, requeried.WorkOrderNumber);
            Assert.AreEqual(original.SAPWorkCentre, requeried.SAPWorkCentre);

            Assert.AreEqual(original.Description, requeried.Description);
            Assert.AreEqual(original.Company, requeried.Company);

            Assert.AreEqual(original.DataSource, requeried.DataSource);
            Assert.AreEqual(original.LastImportedByUser.IdValue, requeried.LastImportedByUser.IdValue);            
            Assert.That(original.LastImportedDateTime, Is.EqualTo(requeried.LastImportedDateTime).Within(TimeSpan.FromSeconds(1)));

            bool areEqual = (original.LastSubmittedByUser == null && requeried.LastSubmittedByUser == null) ||
                            (original.LastSubmittedByUser.IdValue == requeried.LastSubmittedByUser.IdValue);
            Assert.IsTrue(areEqual);

            bool areaLabelsAreEqual = (original.AreaLabel == null && requeried.AreaLabel == null) ||
                                      (original.AreaLabel.IdValue == requeried.AreaLabel.IdValue);
            Assert.IsTrue(areaLabelsAreEqual);

            Assert.AreEqual(original.LastSubmittedDateTime, requeried.LastSubmittedDateTime);
            Assert.AreEqual(original.CreatedBy.IdValue, requeried.CreatedBy.IdValue);
            
            Assert.That(original.CreatedDateTime, Is.EqualTo(requeried.CreatedDateTime).Within(TimeSpan.FromSeconds(1)));

            Assert.AreEqual(original.LastModifiedBy.IdValue, requeried.LastModifiedBy.IdValue);            
            Assert.That(original.LastModifiedDateTime, Is.EqualTo(requeried.LastModifiedDateTime).Within(TimeSpan.FromSeconds(1)));

            Assert.AreEqual(original.IssuedToSuncor, requeried.IssuedToSuncor);
            Assert.AreEqual(original.Occupation, requeried.Occupation);
            Assert.AreEqual(original.NumberOfWorkers, requeried.NumberOfWorkers);
            Assert.AreEqual(original.WorkPermitType, requeried.WorkPermitType);
            Assert.AreEqual(original.FunctionalLocation, requeried.FunctionalLocation);
            Assert.AreEqual(original.Location, requeried.Location);

            Assert.AreEqual(original.AlkylationEntryClassOfClothing, requeried.AlkylationEntryClassOfClothing);
            Assert.AreEqual(original.FlarePitEntryType, requeried.FlarePitEntryType);
            Assert.AreEqual(original.ConfinedSpaceCardNumber, requeried.ConfinedSpaceCardNumber);
            Assert.AreEqual(original.ConfinedSpaceClass, requeried.ConfinedSpaceClass);
            Assert.AreEqual(original.RescuePlanFormNumber, requeried.RescuePlanFormNumber);
            Assert.AreEqual(original.VehicleEntryTotal, requeried.VehicleEntryTotal);
            Assert.AreEqual(original.VehicleEntryType, requeried.VehicleEntryType);
            Assert.AreEqual(original.SpecialWorkFormNumber, requeried.SpecialWorkFormNumber);
            Assert.AreEqual(original.SpecialWorkType, requeried.SpecialWorkType);

            Assert.AreEqual(original.AlkylationEntry, requeried.AlkylationEntry);
            Assert.AreEqual(original.FlarePitEntry, requeried.FlarePitEntry);
            Assert.AreEqual(original.ConfinedSpace, requeried.ConfinedSpace);

            Assert.AreEqual(original.RescuePlan, requeried.RescuePlan);
            Assert.AreEqual(original.VehicleEntry, requeried.VehicleEntry);
            Assert.AreEqual(original.SpecialWork, requeried.SpecialWork);

            if (!isRawData)
            {
                Assert.AreEqual(original.FormGN59.Id, requeried.FormGN59.Id);
                Assert.AreEqual(original.FormGN7.Id, requeried.FormGN7.Id);
                Assert.AreEqual(original.FormGN24.Id, requeried.FormGN24.Id);
                Assert.AreEqual(original.FormGN6.Id, requeried.FormGN6.Id);
                Assert.AreEqual(original.FormGN75A.Id, requeried.FormGN75A.Id);
                Assert.AreEqual(original.FormGN1.Id, requeried.FormGN1.Id);
                Assert.IsTrue(original.GN1);
                Assert.AreEqual(original.FormGN1TradeChecklistId, requeried.FormGN1TradeChecklistId);
                Assert.AreEqual(original.FormGN1TradeChecklistDisplayNumber, requeried.FormGN1TradeChecklistDisplayNumber);
            }

            Assert.AreEqual(original.GN6, requeried.GN6);
            Assert.AreEqual(original.GN11, requeried.GN11);
            Assert.AreEqual(original.GN6_Deprecated, requeried.GN6_Deprecated);
            Assert.AreEqual(original.GN24_Deprecated, requeried.GN24_Deprecated);

            Assert.AreEqual(original.GN27, requeried.GN27);
            Assert.AreEqual(original.GN75_Deprecated, requeried.GN75_Deprecated);

            Assert.AreEqual(original.RequestedStartDate, requeried.RequestedStartDate);
            Assert.AreEqual(original.RequestedStartTimeDay, requeried.RequestedStartTimeDay);
            Assert.AreEqual(original.RequestedStartTimeNight, requeried.RequestedStartTimeNight);
            Assert.AreEqual(original.HazardsAndOrRequirements, requeried.HazardsAndOrRequirements);
            Assert.AreEqual(original.OtherAreasAndOrUnitsAffectedArea, requeried.OtherAreasAndOrUnitsAffectedArea);
            Assert.AreEqual(original.OtherAreasAndOrUnitsAffectedPersonNotified,
                            requeried.OtherAreasAndOrUnitsAffectedPersonNotified);

            Assert.AreEqual(original.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob,
                            requeried.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);

            Assert.AreEqual(original.FaceShield, requeried.FaceShield);
            Assert.AreEqual(original.Goggles, requeried.Goggles);
            Assert.AreEqual(original.RubberBoots, requeried.RubberBoots);
            Assert.AreEqual(original.RubberGloves, requeried.RubberGloves);
            Assert.AreEqual(original.RubberSuit, requeried.RubberSuit);
            Assert.AreEqual(original.SafetyHarnessLifeline, requeried.SafetyHarnessLifeline);
            Assert.AreEqual(original.HighVoltagePPE, requeried.HighVoltagePPE);
            Assert.AreEqual(original.Other1, requeried.Other1);

            Assert.AreEqual(original.EquipmentGrounded, requeried.EquipmentGrounded);
            Assert.AreEqual(original.FireBlanket, requeried.FireBlanket);
            Assert.AreEqual(original.FireExtinguisher, requeried.FireExtinguisher);
            Assert.AreEqual(original.FireMonitorManned, requeried.FireMonitorManned);
            Assert.AreEqual(original.FireWatch, requeried.FireWatch);
            Assert.AreEqual(original.SewersDrainsCovered, requeried.SewersDrainsCovered);
            Assert.AreEqual(original.SteamHose, requeried.SteamHose);
            Assert.AreEqual(original.Other2, requeried.Other2);

            Assert.AreEqual(original.AirPurifyingRespirator, requeried.AirPurifyingRespirator);
            Assert.AreEqual(original.BreathingAirApparatus, requeried.BreathingAirApparatus);
            Assert.AreEqual(original.DustMask, requeried.DustMask);
            Assert.AreEqual(original.LifeSupportSystem, requeried.LifeSupportSystem);
            Assert.AreEqual(original.SafetyWatch, requeried.SafetyWatch);
            Assert.AreEqual(original.ContinuousGasMonitor, requeried.ContinuousGasMonitor);
            Assert.AreEqual(original.WorkersMonitorNumber, requeried.WorkersMonitorNumber);
            Assert.AreEqual(original.BumpTestMonitorPriorToUse, requeried.BumpTestMonitorPriorToUse);
            Assert.AreEqual(original.Other3, requeried.Other3);

            Assert.AreEqual(original.AirMover, requeried.AirMover);
            Assert.AreEqual(original.BarriersSigns, requeried.BarriersSigns);
            Assert.AreEqual(original.RadioChannelNumber, requeried.RadioChannelNumber);
            Assert.AreEqual(original.AirHorn, requeried.AirHorn);
            Assert.AreEqual(original.MechVentilationComfortOnly, requeried.MechVentilationComfortOnly);
            Assert.AreEqual(original.AsbestosMMCPrecautions, requeried.AsbestosMMCPrecautions);
            Assert.AreEqual(original.Other4, requeried.Other4);

            if (!isRawData)
            {
                Assert.AreEqual(original.DoNotMerge, requeried.DoNotMerge);
            }
        }
       
        [Ignore] [Test]
        public void ShouldInsertRawDataObjectsAsRealPermitRequests()
        {
            
        }
      
        [Ignore] [Test]
        public void ShouldInsertNullFields()
        {
            PermitRequestEdmonton request = CreateForInsert(false);           
            request.Company = null;            
            request.LastImportedByUser = null;
            request.LastImportedDateTime = null;
            request.LastSubmittedByUser = null;
            request.LastSubmittedDateTime = null;
            request.SapDescription = null;
            request.SpecialWorkType = null;

            request.RequestedStartTimeDay = null;
            request.RequestedStartTimeNight = null;

            PermitRequestEdmonton saved = dao.Insert(request);

            PermitRequestEdmonton requeried = dao.QueryById(saved.IdValue);
            Assert.IsNotNull(requeried);

            Assert.IsEmpty(requeried.WorkOrderSourceList);         
            Assert.IsNull(requeried.Company);            
            Assert.IsNull(requeried.LastImportedByUser);
            Assert.IsNull(requeried.LastImportedDateTime);
            Assert.IsNull(requeried.LastSubmittedByUser);
            Assert.IsNull(requeried.LastSubmittedDateTime);
            Assert.IsNull(requeried.SapDescription);
            Assert.IsNull(requeried.SpecialWorkType);
        }
       
        [Ignore] [Test]
        public void ShouldUpdate()
        {
            PermitRequestEdmonton request = CreateForInsert();

            CreateAndInsertGN75AFormAndAddToPermitRequest(request);
            CreateAndInsertGN1FormAndAddToPermitRequest(request);

            request.LastModifiedBy = UserFixture.CreateEngineeringSupport();
            request.LastModifiedDateTime = new DateTime(2001, 1, 20);
            request.CompletionStatus = PermitRequestCompletionStatus.Incomplete;
            request.ClearWorkOrderSources();
            request.AddWorkOrderSource("heyo", "waka", "moo");
            request.Priority = Priority.Elevated;
            request = dao.Insert(request);
            long id = request.IdValue;

            PermitRequestEdmonton original;

            {
                FunctionalLocation newFloc = FunctionalLocationFixture.GetReal("ED1-A001-U069-SEG-PHTPL0003");
                User newUser = UserFixture.CreateOperatorOltUser1InFortMcMurrySite();
                
                original = dao.QueryById(id);
                Assert.IsNotNull(original);
                Assert.IsFalse(original.IsModified);
                Assert.AreNotEqual(newUser.IdValue, original.LastImportedByUser);

                List<PermitRequestWorkOrderSource> sourceList = original.WorkOrderSourceList;
                Assert.AreEqual(1, sourceList.Count);
                
                original.CompletionStatus = PermitRequestCompletionStatus.Complete;
                original.Priority = Priority.High;

                original.EndDate = new Date(1903, 4, 5);
                original.ClearWorkOrderSources();
                original.AddWorkOrderSource("123erasdf", "lolz", "poop");
                original.AddWorkOrderSource("123erasdf", "lolz", "wat");
                Assert.AreEqual(2, original.WorkOrderSourceList.Count);
                
                original.Description = "asdfasfasvasdfasdfddddddddd";
                original.SapDescription = "1345345wsdvgx2345rwefz";

                original.Company = "aacompanagtasyd";

                original.LastImportedByUser = newUser;
                original.LastImportedDateTime = new DateTime(2002, 5, 4, 3, 2, 1);

                original.LastSubmittedByUser = newUser;
                original.LastSubmittedDateTime = new DateTime(1975, 3, 9);

                original.LastModifiedBy = newUser;
                original.LastModifiedDateTime = new DateTime(2013, 4, 4, 4, 4, 4);

                original.WorkPermitType = WorkPermitEdmontonType.COLD_WORK;
                
                original.FunctionalLocation = newFloc;
                original.AreaLabel = null;
                                
                original.RequestedStartDate = new Date(2012, 2, 2);
                original.RequestedStartTimeDay = new Time(1, 4, 3);
                original.RequestedStartTimeNight = new Time(9, 5, 6);

                original.IssuedToSuncor = !original.IssuedToSuncor;
                original.Company = "companasddgfy";
                original.Occupation = "occupsdfaation";
                original.NumberOfWorkers = 3452;
                original.Location = "locatdfdasdon";

                original.AlkylationEntryClassOfClothing = "Class ofllj Clothing";
                original.ConfinedSpaceCardNumber = "CardkjkjNum";
                original.ConfinedSpaceClass = "Clkjkjass";
                original.SpecialWorkFormNumber = "SkjkjWFN";
                original.SpecialWorkType = EdmontonPermitSpecialWorkType.PowderActuatedTool;
                original.VehicleEntryTotal = 43;
                original.VehicleEntryType = "VkjET";
                original.RescuePlanFormNumber = "RPFNjkj";
                original.FormGN59 = FormGN59Fixture.CreateAnotherFormWithExistingId();
                original.FormGN6 = FormGN6Fixture.CreateAnotherFormWithExistingId();
                original.FormGN7 = FormGN7Fixture.CreateAnotherFormWithExistingId();
                original.FormGN24 = FormGN24Fixture.CreateAnotherFormWithExistingId();
                CreateAndInsertGN75AFormAndAddToPermitRequest(request);
                CreateAndInsertGN1FormAndAddToPermitRequest(request);

                original.GN6_Deprecated = WorkPermitSafetyFormState.Approved;
                original.GN11 = WorkPermitSafetyFormState.NotApplicable;
                original.GN24_Deprecated = WorkPermitSafetyFormState.Required;

                original.GN27 = WorkPermitSafetyFormState.Approved;
                original.GN75_Deprecated = WorkPermitSafetyFormState.Required;

                original.HazardsAndOrRequirements = "dapp12222";

                original.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = false;
                original.FaceShield = false;
                original.Goggles = false;
                original.RubberBoots = false;
                original.RubberGloves = false;
                original.RubberSuit = false;
                original.SafetyHarnessLifeline = false;
                original.HighVoltagePPE = false;
                original.Other1 = "other1value";
                original.EquipmentGrounded = false;
                original.FireBlanket = false;
                original.FireExtinguisher = false;
                original.FireMonitorManned = false;
                original.FireWatch = false;
                original.SewersDrainsCovered = false;
                original.SteamHose = false;
                original.Other2 = "other2value";
                original.AirPurifyingRespirator = false;
                original.BreathingAirApparatus = false;
                original.DustMask = false;
                original.LifeSupportSystem = false;
                original.SafetyWatch = false;
                original.ContinuousGasMonitor = false;                
                original.WorkersMonitorNumber = "NEW WMNV";
                original.BumpTestMonitorPriorToUse = false;
                original.Other3 = "other3value";
                original.AirMover = false;
                original.BarriersSigns = false;                
                original.RadioChannelNumber = "NEW RCN";
                original.AirHorn = false;
                original.MechVentilationComfortOnly = false;
                original.AsbestosMMCPrecautions = false;
                original.Other4 = "Other4value";

                dao.Update(original);
            }
            {
                PermitRequestEdmonton requeried = dao.QueryById(id);
                Assert.IsNotNull(requeried);

                Assert.AreEqual(original.CompletionStatus, requeried.CompletionStatus);
                Assert.AreEqual(original.Priority, requeried.Priority);

                Assert.AreEqual(original.EndDate, requeried.EndDate);
                
                Assert.AreEqual(2, requeried.WorkOrderSourceList.Count);
                Assert.IsTrue(requeried.WorkOrderSourceList.Exists(j => j.Matches("123erasdf", "lolz", "poop")));

                Assert.AreEqual(original.WorkOrderNumber, requeried.WorkOrderNumber);

                Assert.AreEqual(original.Description, requeried.Description);
                Assert.AreEqual(original.Company, requeried.Company);                

                Assert.AreEqual(original.DataSource, requeried.DataSource);
                Assert.AreEqual(original.LastImportedByUser.IdValue, requeried.LastImportedByUser.IdValue);
                Assert.AreEqual(original.LastImportedDateTime, requeried.LastImportedDateTime);
                Assert.AreEqual(original.LastSubmittedByUser.IdValue, requeried.LastSubmittedByUser.IdValue);

                Assert.AreEqual(original.LastSubmittedDateTime, requeried.LastSubmittedDateTime);
                Assert.AreEqual(original.CreatedBy.IdValue, requeried.CreatedBy.IdValue);
                Assert.AreEqual(original.CreatedDateTime, requeried.CreatedDateTime);
                Assert.AreEqual(original.LastModifiedBy.IdValue, requeried.LastModifiedBy.IdValue);
                Assert.AreEqual(original.LastModifiedDateTime, requeried.LastModifiedDateTime);

                Assert.AreEqual(original.IssuedToSuncor, requeried.IssuedToSuncor);
                Assert.AreEqual(original.Occupation, requeried.Occupation);
                Assert.AreEqual(original.NumberOfWorkers, requeried.NumberOfWorkers);
                Assert.AreEqual(original.WorkPermitType, requeried.WorkPermitType);                
                Assert.AreEqual(original.FunctionalLocation, requeried.FunctionalLocation);
                Assert.AreEqual(original.Location, requeried.Location);

                Assert.AreEqual(original.AlkylationEntryClassOfClothing, requeried.AlkylationEntryClassOfClothing);
                Assert.AreEqual(original.FlarePitEntryType, requeried.FlarePitEntryType);
                Assert.AreEqual(original.ConfinedSpaceCardNumber, requeried.ConfinedSpaceCardNumber);
                Assert.AreEqual(original.ConfinedSpaceClass, requeried.ConfinedSpaceClass);
                Assert.AreEqual(original.RescuePlanFormNumber, requeried.RescuePlanFormNumber);
                Assert.AreEqual(original.VehicleEntryTotal, requeried.VehicleEntryTotal);
                Assert.AreEqual(original.VehicleEntryType, requeried.VehicleEntryType);
                Assert.AreEqual(original.SpecialWorkFormNumber, requeried.SpecialWorkFormNumber);
                Assert.AreEqual(original.SpecialWorkType, requeried.SpecialWorkType);
                Assert.AreEqual(original.FormGN59.Id, requeried.FormGN59.Id);
                Assert.AreEqual(original.FormGN7.Id, requeried.FormGN7.Id);
                Assert.AreEqual(original.FormGN6.Id, requeried.FormGN6.Id);
                Assert.AreEqual(original.FormGN75A.Id, requeried.FormGN75A.Id);
                Assert.AreEqual(original.FormGN1.Id, requeried.FormGN1.Id);
                Assert.AreEqual(original.FormGN1TradeChecklistId, requeried.FormGN1TradeChecklistId);

                Assert.AreEqual(original.GN6_Deprecated, requeried.GN6_Deprecated);
                Assert.AreEqual(original.GN11, requeried.GN11);
                Assert.AreEqual(original.GN24_Deprecated, requeried.GN24_Deprecated);

                Assert.AreEqual(original.GN27, requeried.GN27);
                Assert.AreEqual(original.GN75_Deprecated, requeried.GN75_Deprecated);

                Assert.AreEqual(original.RequestedStartDate, requeried.RequestedStartDate);
                Assert.AreEqual(original.RequestedStartTimeDay, requeried.RequestedStartTimeDay);
                Assert.AreEqual(original.RequestedStartTimeNight, requeried.RequestedStartTimeNight);
                Assert.AreEqual(original.HazardsAndOrRequirements, requeried.HazardsAndOrRequirements);
                Assert.AreEqual(original.OtherAreasAndOrUnitsAffectedArea, requeried.OtherAreasAndOrUnitsAffectedArea);
                Assert.AreEqual(original.OtherAreasAndOrUnitsAffectedPersonNotified, requeried.OtherAreasAndOrUnitsAffectedPersonNotified);

                Assert.AreEqual(original.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob, requeried.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);

                Assert.AreEqual(original.FaceShield, requeried.FaceShield);
                Assert.AreEqual(original.Goggles, requeried.Goggles);
                Assert.AreEqual(original.RubberBoots, requeried.RubberBoots);
                Assert.AreEqual(original.RubberGloves, requeried.RubberGloves);
                Assert.AreEqual(original.RubberSuit, requeried.RubberSuit);
                Assert.AreEqual(original.SafetyHarnessLifeline, requeried.SafetyHarnessLifeline);
                Assert.AreEqual(original.HighVoltagePPE, requeried.HighVoltagePPE);
                Assert.AreEqual(original.Other1, requeried.Other1);

                Assert.AreEqual(original.EquipmentGrounded, requeried.EquipmentGrounded);
                Assert.AreEqual(original.FireBlanket, requeried.FireBlanket);
                Assert.AreEqual(original.FireExtinguisher, requeried.FireExtinguisher);
                Assert.AreEqual(original.FireMonitorManned, requeried.FireMonitorManned);
                Assert.AreEqual(original.FireWatch, requeried.FireWatch);
                Assert.AreEqual(original.SewersDrainsCovered, requeried.SewersDrainsCovered);
                Assert.AreEqual(original.SteamHose, requeried.SteamHose);
                Assert.AreEqual(original.Other2, requeried.Other2);


                Assert.AreEqual(original.AirPurifyingRespirator, requeried.AirPurifyingRespirator);
                Assert.AreEqual(original.BreathingAirApparatus, requeried.BreathingAirApparatus);
                Assert.AreEqual(original.DustMask, requeried.DustMask);
                Assert.AreEqual(original.LifeSupportSystem, requeried.LifeSupportSystem);
                Assert.AreEqual(original.SafetyWatch, requeried.SafetyWatch);
                Assert.AreEqual(original.ContinuousGasMonitor, requeried.ContinuousGasMonitor);
                Assert.AreEqual(original.WorkersMonitorNumber, requeried.WorkersMonitorNumber);
                Assert.AreEqual(original.BumpTestMonitorPriorToUse, requeried.BumpTestMonitorPriorToUse);
                Assert.AreEqual(original.Other3, requeried.Other3);

                Assert.AreEqual(original.AirMover, requeried.AirMover);
                Assert.AreEqual(original.BarriersSigns, requeried.BarriersSigns);                
                Assert.AreEqual(original.RadioChannelNumber, requeried.RadioChannelNumber);
                Assert.AreEqual(original.AirHorn, requeried.AirHorn);
                Assert.AreEqual(original.MechVentilationComfortOnly, requeried.MechVentilationComfortOnly);
                Assert.AreEqual(original.AsbestosMMCPrecautions, requeried.AsbestosMMCPrecautions);
                Assert.AreEqual(original.Other4, requeried.Other4);
            }
        }

        private void CreateAndInsertGN75AFormAndAddToPermitRequest(PermitRequestEdmonton request)
        {
            FormGN75A formGn75A = FormGN75AFixture.CreateForInsert(request.FunctionalLocation,
                                                                   request.RequestedStartDate.CreateDateTime(Time.NOON),
                                                                   request.EndDate.ToDateTimeAtEndOfDay(), FormStatus.Approved);
            formGN75ADao.Insert(formGn75A);
            request.FormGN75A = formGn75A;
            request.GN75A = true;
        }

        private void CreateAndInsertGN1FormAndAddToPermitRequest(PermitRequestEdmonton request)
        {
            FormGN1 formGN1 = FormGN1Fixture.CreateForInsert(request.FunctionalLocation,
                                                                   request.RequestedStartDate.CreateDateTime(Time.NOON),
                                                                   request.EndDate.ToDateTimeAtEndOfDay(), FormStatus.Approved);
            formGN1Dao.Insert(formGN1);
            request.FormGN1 = formGN1;
            request.GN1 = true;
            request.FormGN1TradeChecklistId = formGN1.TradeChecklists[0].Id;
            request.FormGN1TradeChecklistDisplayNumber = "TESTING123";
        }
      
        [Ignore] [Test]
        public void ShouldRemove()
        {
            PermitRequestEdmonton request = CreateForInsert();
            request.LastModifiedBy = UserFixture.CreateEngineeringSupport();
            request.LastModifiedDateTime = new DateTime(2001, 1, 20);
            request = dao.Insert(request);
            long id = request.IdValue;

            {
                PermitRequestEdmonton requeried = dao.QueryById(id);
                Assert.IsNotNull(requeried);

                requeried.LastModifiedBy = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
                requeried.LastModifiedDateTime = new DateTime(2001, 5, 12);

                dao.Remove(requeried);
            }
            {
                PermitRequestEdmonton requeried = dao.QueryById(id);
                Assert.IsNotNull(requeried);

                Assert.AreEqual(UserFixture.CreateOperatorGoofyInFortMcMurrySite().Id, requeried.LastModifiedBy.Id);
                Assert.AreEqual(new DateTime(2001, 5, 12), requeried.LastModifiedDateTime);
            }
        }      
      
        [Ignore] [Test]
        public void ShouldQueryByWorkOrderNumberAndOperationAndSubOperationAndSource()
        {
            PermitRequestEdmonton permitRequest = CreateForInsert(DataSource.SAP);
            permitRequest.ClearWorkOrderSources();
            permitRequest.AddWorkOrderSource("67", "42", "99");
            dao.Insert(permitRequest);

            List<PermitRequestEdmonton> result = dao.QueryByWorkOrderNumberAndOperationAndSource("67", "42", "99", DataSource.SAP);

            Assert.IsTrue(result.Count > 0);

            bool found = result.Exists(
                pr =>
                pr.DataSource.IdValue == DataSource.SAP.IdValue &&
                pr.WorkOrderSourceList.Exists(wos => wos.Matches("67", "42", "99")));

            Assert.IsTrue(found);
        }
       
        [Ignore] [Test]
        public void ShouldQueryByWorkOrderNumberAndOperationAndSource_NullOperationNumber()
        {
            PermitRequestEdmonton permitRequest = CreateForInsert(DataSource.SAP);
            permitRequest.ClearWorkOrderSources();
            permitRequest.AddWorkOrderSource("67", null, null);
            dao.Insert(permitRequest);

            permitRequest = CreateForInsert(DataSource.SAP);
            permitRequest.ClearWorkOrderSources();
            permitRequest.AddWorkOrderSource("67", "12", "98");
            dao.Insert(permitRequest);

            List<PermitRequestEdmonton> result = dao.QueryByWorkOrderNumberAndOperationAndSource("67", null, null, DataSource.SAP);

            Assert.IsTrue(result.Count > 0);
 
            bool withNullOperationNumberFound = result.Exists(
                pr => pr.WorkOrderSourceList.Exists(wos => wos.Matches("67", null, null)) &&
                pr.DataSource.IdValue == DataSource.SAP.IdValue);

            bool withNonNullOperationNumberFound = result.Exists(
                pr =>
                pr.DataSource.IdValue == DataSource.SAP.IdValue &&
                pr.WorkOrderSourceList.Exists(wos => wos.Matches("67", "12", "98")));

            Assert.IsTrue(withNullOperationNumberFound);
            Assert.IsFalse(withNonNullOperationNumberFound);
        }
       
        [Ignore] [Test]// zzz
        public void ShouldQueryByWorkOrderNumberAndOperationAndSource_NullWorkOrderNumber()
        {
            PermitRequestEdmonton permitRequest = CreateForInsert(DataSource.SAP);
            permitRequest.ClearWorkOrderSources();
            permitRequest.AddWorkOrderSource(null, "212", "333");
            dao.Insert(permitRequest);

            permitRequest = CreateForInsert(DataSource.SAP);
            permitRequest.ClearWorkOrderSources();
            permitRequest.AddWorkOrderSource("513", "212", "333");
            dao.Insert(permitRequest);

            List<PermitRequestEdmonton> result = dao.QueryByWorkOrderNumberAndOperationAndSource(null, "212", "333", DataSource.SAP);

            Assert.IsTrue(result.Count > 0);

            bool withNullWorkOrderNumberFound = result.Exists(
                pr =>
                pr.DataSource.IdValue == DataSource.SAP.IdValue &&
                pr.WorkOrderSourceList.Exists(wos => wos.Matches(null, "212", "333")));

            bool withNonNullWorkOrderNumberFound = result.Exists(
                pr =>
                pr.DataSource.IdValue == DataSource.SAP.IdValue &&
                pr.WorkOrderSourceList.Exists(wos => wos.Matches("513", "212", "333")));

            Assert.IsTrue(withNullWorkOrderNumberFound);
            Assert.IsFalse(withNonNullWorkOrderNumberFound);
        }
        
        [Ignore] [Test]
        public void ShouldQueryByWorkOrderNumberAndWorkCentre()
        {
            {
                PermitRequestEdmonton permitRequest = CreateForInsert(DataSource.SAP);
                permitRequest.WorkOrderNumber = "67";
                permitRequest.ClearWorkOrderSources();
                permitRequest.AddWorkOrderSource("67", "42", "99");
                permitRequest.SAPWorkCentre = "SAP1";
                PermitRequestEdmonton resultFromInsert = dao.Insert(permitRequest);

                PermitRequestEdmonton permitRequestEdmonton = dao.QueryById(resultFromInsert.IdValue);
                Assert.AreEqual("67", permitRequestEdmonton.WorkOrderNumber);
                Assert.AreEqual("SAP1", permitRequest.SAPWorkCentre);
            }
            {
                PermitRequestEdmonton permitRequest = CreateForInsert(DataSource.SAP);
                permitRequest.WorkOrderNumber = "456";
                permitRequest.ClearWorkOrderSources();
                permitRequest.AddWorkOrderSource("456", "42", "99");
                permitRequest.SAPWorkCentre = "SAP2";
                dao.Insert(permitRequest);
            }
            {
                List<PermitRequestEdmonton> results = dao.QueryByWorkOrderNumberAndSAPWorkCentre("67", "SAP1");

                Assert.IsTrue(results.Count == 1);

                bool found = results.Exists(
                    pr =>
                    pr.DataSource.IdValue == DataSource.SAP.IdValue &&
                    pr.WorkOrderSourceList.Exists(wos => wos.Matches("67", "42", "99")));

                Assert.IsTrue(found);                
            }
            {
                List<PermitRequestEdmonton> results = dao.QueryByWorkOrderNumberAndSAPWorkCentre("456", "SAP2");

                Assert.IsTrue(results.Count == 1);

                bool found = results.Exists(
                    pr =>
                    pr.DataSource.IdValue == DataSource.SAP.IdValue &&
                    pr.WorkOrderSourceList.Exists(wos => wos.Matches("456", "42", "99")));

                Assert.IsTrue(found);                
            }
        }
       
        [Ignore] [Test]
        public void ShouldQueryLastImportDateTime()
        {
            PermitRequestEdmonton original = CreateForInsert();
            DateTime futureDate = new DateTime(2525, 3, 9);
            original.LastImportedDateTime = futureDate; // There will be flying cars IN THE FUTURE!
            dao.Insert(original);

            DateTime? lastImportDateTime = dao.QueryLastImportDateTime();
            Assert.IsTrue(lastImportDateTime.HasValue);
            Assert.AreEqual(futureDate, lastImportDateTime);
        }
     
        [Ignore] [Test]
        public void ShouldQueryByFormGN59Id()
        {
            PermitRequestEdmonton requestOne = CreateForInsert();
            requestOne.FormGN59 = FormGN59Fixture.CreateFormWithExistingId();
            dao.Insert(requestOne);

            PermitRequestEdmonton requestTwo = CreateForInsert();
            requestTwo.FormGN59 = FormGN59Fixture.CreateFormWithExistingId();
            dao.Insert(requestTwo);

            PermitRequestEdmonton requestThree = CreateForInsert();
            requestThree.FormGN59 = FormGN59Fixture.CreateAnotherFormWithExistingId();
            dao.Insert(requestThree);

            {
                List<PermitRequestEdmonton> results = dao.QueryByFormGN59Id(requestOne.FormGN59.IdValue);
                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(request => request.Id == requestOne.Id));
                Assert.IsTrue(results.Exists(request => request.Id == requestTwo.Id));
            }

            {
                List<PermitRequestEdmonton> results = dao.QueryByFormGN59Id(requestThree.FormGN59.IdValue);
                Assert.AreEqual(1, results.Count);
                Assert.IsTrue(results.Exists(request => request.Id == requestThree.Id));
            }

        }
        
        [Ignore] [Test]
        public void ShouldQueryByFormGN7Id()
        {
            PermitRequestEdmonton requestOne = CreateForInsert();
            requestOne.FormGN7 = FormGN7Fixture.CreateFormWithExistingId();
            dao.Insert(requestOne);

            PermitRequestEdmonton requestTwo = CreateForInsert();
            requestTwo.FormGN7 = FormGN7Fixture.CreateFormWithExistingId();
            dao.Insert(requestTwo);

            PermitRequestEdmonton requestThree = CreateForInsert();
            requestThree.FormGN7 = FormGN7Fixture.CreateAnotherFormWithExistingId();
            dao.Insert(requestThree);

            {
                List<PermitRequestEdmonton> results = dao.QueryByFormGN7Id(requestOne.FormGN7.IdValue);
                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(request => request.Id == requestOne.Id));
                Assert.IsTrue(results.Exists(request => request.Id == requestTwo.Id));
            }

            {
                List<PermitRequestEdmonton> results = dao.QueryByFormGN7Id(requestThree.FormGN7.IdValue);
                Assert.AreEqual(1, results.Count);
                Assert.IsTrue(results.Exists(request => request.Id == requestThree.Id));
            }

        }
      
        [Ignore] [Test]
        public void ShouldQueryByFormGN24Id()
        {
            PermitRequestEdmonton requestOne = CreateForInsert();
            requestOne.FormGN24 = FormGN24Fixture.CreateFormWithExistingId();
            dao.Insert(requestOne);

            PermitRequestEdmonton requestTwo = CreateForInsert();
            requestTwo.FormGN24 = FormGN24Fixture.CreateFormWithExistingId();
            dao.Insert(requestTwo);

            PermitRequestEdmonton requestThree = CreateForInsert();
            requestThree.FormGN24 = FormGN24Fixture.CreateAnotherFormWithExistingId();
            dao.Insert(requestThree);

            {
                List<PermitRequestEdmonton> results = dao.QueryByFormGN24Id(requestOne.FormGN24.IdValue);
                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(request => request.Id == requestOne.Id));
                Assert.IsTrue(results.Exists(request => request.Id == requestTwo.Id));
            }

            {
                List<PermitRequestEdmonton> results = dao.QueryByFormGN24Id(requestThree.FormGN24.IdValue);
                Assert.AreEqual(1, results.Count);
                Assert.IsTrue(results.Exists(request => request.Id == requestThree.Id));
            }
        }
      
        [Ignore] [Test]
        public void ShouldQueryByFormGN6Id()
        {
            PermitRequestEdmonton requestOne = CreateForInsert();
            requestOne.FormGN6 = FormGN6Fixture.CreateFormWithExistingId();
            dao.Insert(requestOne);

            PermitRequestEdmonton requestTwo = CreateForInsert();
            requestTwo.FormGN6 = FormGN6Fixture.CreateFormWithExistingId();
            dao.Insert(requestTwo);

            PermitRequestEdmonton requestThree = CreateForInsert();
            requestThree.FormGN6 = FormGN6Fixture.CreateAnotherFormWithExistingId();
            dao.Insert(requestThree);

            {
                List<PermitRequestEdmonton> results = dao.QueryByFormGN6Id(requestOne.FormGN6.IdValue);
                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(request => request.Id == requestOne.Id));
                Assert.IsTrue(results.Exists(request => request.Id == requestTwo.Id));
            }

            {
                List<PermitRequestEdmonton> results = dao.QueryByFormGN6Id(requestThree.FormGN6.IdValue);
                Assert.AreEqual(1, results.Count);
                Assert.IsTrue(results.Exists(request => request.Id == requestThree.Id));
            }
        }
        
        [Ignore] [Test]
        public void InsertShouldInsertDocumentLinks()
        {
            PermitRequestEdmonton permitRequest = CreateForInsert();
            permitRequest.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            permitRequest.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink());
            permitRequest = dao.Insert(permitRequest);

            PermitRequestEdmonton requeried = dao.QueryById(permitRequest.IdValue);

            Assert.AreEqual(permitRequest.DocumentLinks.Count, requeried.DocumentLinks.Count);
            Assert.That(requeried.DocumentLinks, Has.Some.EqualTo(permitRequest.DocumentLinks[0]));
            Assert.That(requeried.DocumentLinks, Has.Some.EqualTo(permitRequest.DocumentLinks[1]));
        }
    
        [Ignore] [Test]
        public void UpdateShouldRemoveDeletedDocumentLinks()
        {
            PermitRequestEdmonton permitRequest = CreateForInsert();
            permitRequest.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            permitRequest.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink());
            permitRequest = dao.Insert(permitRequest);

            long removedLinkId = permitRequest.DocumentLinks[0].IdValue;
            long retainedLinkId = permitRequest.DocumentLinks[1].IdValue;

            permitRequest.DocumentLinks.Remove(permitRequest.DocumentLinks[0]);
            dao.Update(permitRequest);

            PermitRequestEdmonton requeried = dao.QueryById(permitRequest.IdValue);
            Assert.AreEqual(permitRequest.DocumentLinks.Count, requeried.DocumentLinks.Count);
            Assert.That(requeried.DocumentLinks, Has.None.Property("Id").EqualTo(removedLinkId));
            Assert.That(requeried.DocumentLinks, Has.Some.Property("Id").EqualTo(retainedLinkId));
        }
       
        [Ignore] [Test]
        public void UpdateShouldAddNewDocumentLink()
        {
            PermitRequestEdmonton permitRequest = CreateForInsert();
            permitRequest.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            permitRequest = dao.Insert(permitRequest);

            permitRequest.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink());
            dao.Update(permitRequest);

            PermitRequestEdmonton requeried = dao.QueryById(permitRequest.IdValue);
            Assert.AreEqual(permitRequest.DocumentLinks.Count, requeried.DocumentLinks.Count);
            Assert.That(requeried.DocumentLinks, Has.Some.Property("Id").EqualTo(permitRequest.DocumentLinks[0].Id));
            Assert.That(requeried.DocumentLinks, Has.Some.Property("Id").EqualTo(permitRequest.DocumentLinks[1].Id));
        }
       
        [Ignore] [Test]       
        public void ShouldQueryUnsubmittedByDateRangeAndDataSource()
        {
            // These should all show up in the result
            {
                // Oct 5 - Oct 9
                InsertRequest(new Date(2012, 10, 5), new Date(2012, 10, 9), DataSource.SAP, "1111", "1112", "1113");

                // Oct 10 - Oct 11
                InsertRequest(new Date(2012, 10, 10), new Date(2012, 10, 11), DataSource.SAP, "2221", "2222", "2223");

                // Oct 14 - Oct 16
                InsertRequest(new Date(2012, 10, 14), new Date(2012, 10, 16), DataSource.SAP, "3331", "3332", null);
            }

            // These should not show up in the result
            {
                // Oct 7 - Oct 7
                InsertRequest(new Date(2012, 10, 7), new Date(2012, 10, 7), DataSource.SAP, "4441", "4442", "4443");

                // Oct 15 - Oct 16
                InsertRequest(new Date(2012, 10, 15), new Date(2012, 10, 16), DataSource.SAP, "5551", "5552", "5553");

                // Oct 5 - Oct 9, not SAP data source
                InsertRequest(new Date(2012, 10, 15), new Date(2012, 10, 16), DataSource.MANUAL, "6661", "6662", "6663");

                // Oct 5 - Oct 9, not been submitted
                InsertRequest(new Date(2012, 10, 15), new Date(2012, 10, 16), DataSource.MANUAL, "7771", "7772", "7773", true);
            }

            // Import date range: Oct 8 - Oct 14
            List<PermitRequestEdmonton> results = dao.QueryByDateRangeAndDataSource(new Date(2012, 10, 8), new Date(2012, 10, 14), DataSource.SAP);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);

            Assert.IsTrue(results.Exists(z => MatchForTest(z, "1111")));
            Assert.IsTrue(results.Exists(z => MatchForTest(z, "2221")));
            Assert.IsTrue(results.Exists(z => MatchForTest(z, "3331")));

            Assert.IsFalse(results.Exists(z => MatchForTest(z, "4441")));
            Assert.IsFalse(results.Exists(z => MatchForTest(z, "5551")));
            Assert.IsFalse(results.Exists(z => MatchForTest(z, "6661")));
            Assert.IsFalse(results.Exists(z => MatchForTest(z, "7771")));
        }
      
        [Ignore] [Test]
        public void ShouldQueryUnsubmittedByDateRangeAndDataSource_SingleDayQueryForDateWithinMultiDayRequest()
        {
            {
                InsertRequest(new Date(2012, 10, 25), new Date(2012, 10, 27), DataSource.SAP, "3434", "1112", "1113");
            }

            List<PermitRequestEdmonton> results = dao.QueryByDateRangeAndDataSource(new Date(2012, 10, 26), new Date(2012, 10, 26), DataSource.SAP);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);

            Assert.IsTrue(results.Exists(z => MatchForTest(z, "3434")));

        }
        
        [Ignore] [Test]
        public void ShouldQueryUnsubmittedByDateRangeAndDataSource_QueryParamsOverlapStartDate()
        {
            {
                InsertRequest(new Date(2012, 10, 25), new Date(2012, 10, 27), DataSource.SAP, "3434", "1112", "1113");
            }

            List<PermitRequestEdmonton> results = dao.QueryByDateRangeAndDataSource(new Date(2012, 10, 24), new Date(2012, 10, 26), DataSource.SAP);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);

            Assert.IsTrue(results.Exists(z => MatchForTest(z, "3434")));

        }
       
        [Ignore] [Test]
        public void ShouldQueryUnsubmittedByDateRangeAndDataSource_QueryParamsOverlapEndDate()
        {
            {
                InsertRequest(new Date(2012, 10, 25), new Date(2012, 10, 27), DataSource.SAP, "3434", "1112", "1113");
            }

            List<PermitRequestEdmonton> results = dao.QueryByDateRangeAndDataSource(new Date(2012, 10, 26), new Date(2012, 10, 28), DataSource.SAP);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);

            Assert.IsTrue(results.Exists(z => MatchForTest(z, "3434")));

        }
     
        [Ignore] [Test]
        public void ShouldQueryUnsubmittedByDateRangeAndDataSource_QueryParamsOverlapEntireDateRangeOfItem()
        {
            {
                InsertRequest(new Date(2012, 10, 25), new Date(2012, 10, 27), DataSource.SAP, "3434", "1112", "1113");
            }

            List<PermitRequestEdmonton> results = dao.QueryByDateRangeAndDataSource(new Date(2012, 10, 24), new Date(2012, 10, 28), DataSource.SAP);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);

            Assert.IsTrue(results.Exists(z => MatchForTest(z, "3434")));

        }

        private bool MatchForTest(PermitRequestEdmonton request, string woNumber)
        {           
            return woNumber.Equals(request.WorkOrderNumber);
        }

        private void InsertRequest(Date start, Date end, DataSource dataSource, string workOrderNumber, string operationNumber, string subOperationNumber)
        {
            InsertRequest(start, end, dataSource, workOrderNumber, operationNumber, subOperationNumber, false);
        }

        private void InsertRequest(Date start, Date end, DataSource dataSource, string workOrderNumber, string operationNumber, string subOperationNumber, bool submitted)
        {
            PermitRequestEdmonton requestOne = CreateForInsert(dataSource);
            requestOne.RequestedStartDate = start;
            requestOne.EndDate = end;
            requestOne.Group = group;

            requestOne.ClearWorkOrderSources();
            requestOne.AddWorkOrderSource(workOrderNumber, operationNumber, subOperationNumber);

            if (submitted)
            {
                requestOne.LastSubmittedByUser = UserFixture.CreateOperatorOltUser1InFortMcMurrySite();
                requestOne.LastSubmittedDateTime = new DateTime(2012, 10, 10);
            }

            dao.Insert(requestOne);
        }

    }
}
