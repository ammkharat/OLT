using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class PermitRequestLubesTest
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
        public void CloneShouldSetFormFieldsToRequiredIfTheyAreSetToApproved()
        {
            User user = UserFixture.CreateOperator();

            PermitRequestLubes permitRequest = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "Heyo", 1));

            permitRequest.HighEnergy = WorkPermitSafetyFormState.Approved;
            permitRequest.CriticalLift = WorkPermitSafetyFormState.Required;
            permitRequest.Excavation = WorkPermitSafetyFormState.NotApplicable;
            permitRequest.EnergyControlPlan = WorkPermitSafetyFormState.Approved;
            permitRequest.EquivalencyProc = WorkPermitSafetyFormState.Required;
            permitRequest.TestPneumatic = WorkPermitSafetyFormState.NotApplicable;
            permitRequest.LiveFlareWork = WorkPermitSafetyFormState.Approved;
            permitRequest.EntryAndControlPlan = WorkPermitSafetyFormState.Required;
            permitRequest.EnergizedElectrical = WorkPermitSafetyFormState.Approved;

            permitRequest.ConvertToClone(user, null, UserShiftFixture.CreateUserShift());

            Assert.AreEqual(WorkPermitSafetyFormState.Required, permitRequest.HighEnergy);
            Assert.AreEqual(WorkPermitSafetyFormState.Required, permitRequest.CriticalLift);
            Assert.AreEqual(WorkPermitSafetyFormState.NotApplicable, permitRequest.Excavation);
            Assert.AreEqual(WorkPermitSafetyFormState.Required, permitRequest.EnergyControlPlan);
            Assert.AreEqual(WorkPermitSafetyFormState.Required, permitRequest.EquivalencyProc);
            Assert.AreEqual(WorkPermitSafetyFormState.NotApplicable, permitRequest.TestPneumatic);
            Assert.AreEqual(WorkPermitSafetyFormState.Required, permitRequest.LiveFlareWork);
            Assert.AreEqual(WorkPermitSafetyFormState.Required, permitRequest.EntryAndControlPlan);
            Assert.AreEqual(WorkPermitSafetyFormState.Required, permitRequest.EnergizedElectrical);
        }

        [Test]
        public void CloneShouldLeaveStartTimesAloneButSetStartDateToCurrentDate()
        {
            Clock.Now = new DateTime(2012, 6, 21, 15, 0, 1);
            User user = UserFixture.CreateOperator();

            PermitRequestLubes permitRequest = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "Heyo", 1));
            permitRequest.RequestedStartDate = new Date(2012, 5, 22);
            permitRequest.RequestedStartTimeDay = new Time(13, 3, 58);
            permitRequest.RequestedStartTimeNight = new Time(19, 5, 52);

            permitRequest.ConvertToClone(user, null, UserShiftFixture.CreateUserShift());

            Assert.AreEqual(new Date(Clock.Now), permitRequest.RequestedStartDate);
            Assert.AreEqual(new Time(13, 3, 58), permitRequest.RequestedStartTimeDay);
            Assert.AreEqual(new Time(19, 5, 52), permitRequest.RequestedStartTimeNight);
        }

        [Test]
        public void CloneShouldSetEndDateToEndDateOfTheCurrentShift()
        {
            Clock.Now = new DateTime(2012, 6, 21, 19, 0, 1);
            User user = UserFixture.CreateOperator();

            UserShift userShift = UserShiftFixture.CreateUserShift(new Time(17, 30, 0), new Time(5, 30, 0), Clock.Now.Date);

            PermitRequestLubes permitRequest = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "Heyo", 1));
            permitRequest.EndDate = new Date(2012, 5, 22);

            permitRequest.ConvertToClone(user, null, userShift);

            Assert.AreEqual(new Date(2012, 6, 22), permitRequest.EndDate);
        }

        [Test]
        public void WhenImportingShouldUpdateStartDateTimeAndExpiryDateRegardlessOfWhetherThePermitRequestWasManuallyEditedOrNot()
        {
            PermitRequestLubes permitRequestToUpdate = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "Request to update", 0));
            PermitRequestLubes permitRequestToUpdateFrom = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(0, "Request to update from", 0));

            permitRequestToUpdateFrom.RequestedStartDate = new Date(2013, 8, 16);
            permitRequestToUpdateFrom.RequestedStartTimeDay = new Time(8, 0, 1);
            permitRequestToUpdateFrom.RequestedStartTimeNight = new Time(20, 0, 1);
            permitRequestToUpdateFrom.EndDate = new Date(2013, 8, 21);

            {
                permitRequestToUpdate.RequestedStartDate = new Date(2013, 8, 15);
                permitRequestToUpdate.RequestedStartTimeDay = new Time(8, 0, 0);
                permitRequestToUpdate.RequestedStartTimeNight = new Time(20, 0, 0);
                permitRequestToUpdate.EndDate = new Date(2013, 8, 20);

                permitRequestToUpdate.UpdateFrom(permitRequestToUpdateFrom);

                Assert.AreEqual(permitRequestToUpdateFrom.RequestedStartDate, permitRequestToUpdate.RequestedStartDate);
                Assert.AreEqual(permitRequestToUpdateFrom.RequestedStartTimeDay, permitRequestToUpdate.RequestedStartTimeDay);
                Assert.AreEqual(permitRequestToUpdateFrom.RequestedStartTimeNight, permitRequestToUpdate.RequestedStartTimeNight);
                Assert.AreEqual(permitRequestToUpdateFrom.EndDate, permitRequestToUpdate.EndDate);
            }

            {
                permitRequestToUpdate.RequestedStartDate = new Date(2013, 8, 15);
                permitRequestToUpdate.RequestedStartTimeDay = new Time(8, 0, 0);
                permitRequestToUpdate.RequestedStartTimeNight = new Time(20, 0, 0);
                permitRequestToUpdate.EndDate = new Date(2013, 8, 20);

                permitRequestToUpdate.UpdateIfModifiedFrom(permitRequestToUpdateFrom);

                Assert.AreEqual(permitRequestToUpdateFrom.RequestedStartDate, permitRequestToUpdate.RequestedStartDate);
                Assert.AreEqual(permitRequestToUpdateFrom.RequestedStartTimeDay, permitRequestToUpdate.RequestedStartTimeDay);
                Assert.AreEqual(permitRequestToUpdateFrom.RequestedStartTimeNight, permitRequestToUpdate.RequestedStartTimeNight);
                Assert.AreEqual(permitRequestToUpdateFrom.EndDate, permitRequestToUpdate.EndDate);
            }
        }

        [Test]
        public void ShouldUpdateAndHandleVehicleEntryFlagProperly()
        {
            {
                PermitRequestLubes permitRequestToUpdate = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "Request to update", 0));
                PermitRequestLubes permitRequestToUpdateFrom = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(0, "Request to update from", 0));

                permitRequestToUpdate.WorkPermitType = WorkPermitLubesType.HOT_WORK;
                permitRequestToUpdate.IsVehicleEntry = true;

                permitRequestToUpdateFrom.WorkPermitType = WorkPermitLubesType.HAZARDOUS_COLD_WORK;
                permitRequestToUpdateFrom.IsVehicleEntry = false;

                permitRequestToUpdate.UpdateFrom(permitRequestToUpdateFrom);

                Assert.AreEqual(WorkPermitLubesType.HAZARDOUS_COLD_WORK, permitRequestToUpdate.WorkPermitType);
                Assert.IsFalse(permitRequestToUpdate.IsVehicleEntry);
            }

            {
                PermitRequestLubes permitRequestToUpdate = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "Request to update", 0));
                PermitRequestLubes permitRequestToUpdateFrom = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(0, "Request to update from", 0));

                permitRequestToUpdate.WorkPermitType = WorkPermitLubesType.HAZARDOUS_COLD_WORK;
                permitRequestToUpdate.IsVehicleEntry = false;

                permitRequestToUpdateFrom.WorkPermitType = WorkPermitLubesType.HOT_WORK;
                permitRequestToUpdateFrom.IsVehicleEntry = false;

                permitRequestToUpdate.UpdateFrom(permitRequestToUpdateFrom);

                Assert.AreEqual(WorkPermitLubesType.HOT_WORK, permitRequestToUpdate.WorkPermitType);
                Assert.IsFalse(permitRequestToUpdate.IsVehicleEntry);
            }

            {
                PermitRequestLubes permitRequestToUpdate = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "Request to update", 0));
                PermitRequestLubes permitRequestToUpdateFrom = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(0, "Request to update from", 0));

                permitRequestToUpdate.WorkPermitType = WorkPermitLubesType.HAZARDOUS_COLD_WORK;
                permitRequestToUpdate.IsVehicleEntry = false;

                permitRequestToUpdateFrom.WorkPermitType = WorkPermitLubesType.HOT_WORK;
                permitRequestToUpdateFrom.IsVehicleEntry = true;

                permitRequestToUpdate.UpdateFrom(permitRequestToUpdateFrom);

                Assert.AreEqual(WorkPermitLubesType.HOT_WORK, permitRequestToUpdate.WorkPermitType);
                Assert.IsTrue(permitRequestToUpdate.IsVehicleEntry);
            }
        }

        [Test]
        public void ShouldSortPermitRequestsByPermitKeyData()
        {
            PermitRequestLubes prl1 = PermitRequestLubesFixture.Create(1, "2222", "7777", null);
            PermitRequestLubes prl2 = PermitRequestLubesFixture.Create(2, "2222", "7777", "2222");
            PermitRequestLubes prl3 = PermitRequestLubesFixture.Create(3, "3222", "7777", "2222");
            PermitRequestLubes prl4 = PermitRequestLubesFixture.Create(4, "1222", "7777", "2222");
            PermitRequestLubes prl5 = PermitRequestLubesFixture.Create(5, "4222", null, null);

            List<PermitRequestLubes> mixedList = new List<PermitRequestLubes> { prl4, prl3, prl5, prl2, prl1 };

            mixedList.Sort((pr1, pr2) => String.Compare(pr1.PermitKeySortValue, pr2.PermitKeySortValue, StringComparison.Ordinal));

            Assert.AreEqual(4, mixedList[0].IdValue);
            Assert.AreEqual(1, mixedList[1].IdValue);
            Assert.AreEqual(2, mixedList[2].IdValue);
            Assert.AreEqual(3, mixedList[3].IdValue);
            Assert.AreEqual(5, mixedList[4].IdValue);
        }

        [Test]
        public void ShouldUpdateFromSAP()
        {
            PermitRequestLubes existingPermitRequest;
            PermitRequestLubes incomingPermitRequest;

            {
                existingPermitRequest = PermitRequestLubesFixture.Create(1, "2222", "7777", null);
                Assert.AreEqual(1, existingPermitRequest.WorkOrderSourceList.Count);

                existingPermitRequest.FunctionalLocation = FunctionalLocationFixture.GetReal_MI1_A001_IFST();
                existingPermitRequest.Location = "Location from existing";
                existingPermitRequest.RequestedByGroup = new WorkPermitLubesGroup(1, "Some Fake Group", 0);

                existingPermitRequest.Description = "This is the user description";
                existingPermitRequest.SapDescription = "This is the SAP description 1";

                existingPermitRequest.WorkPermitType = WorkPermitLubesType.HAZARDOUS_COLD_WORK;
                existingPermitRequest.IsVehicleEntry = false;
                existingPermitRequest.Trade = "existing PR trade";
                existingPermitRequest.SAPWorkCentre = "Existing SAP work centre";
                
                existingPermitRequest.RequestedStartDate = new Date(2014, 1, 1);
                existingPermitRequest.EndDate = new Date(2014, 1, 5);
                existingPermitRequest.RequestedStartTimeDay = null;
                existingPermitRequest.RequestedStartTimeNight = new Time(1, 1, 1);
                                
                existingPermitRequest.HighEnergy = WorkPermitSafetyFormState.Approved;
                existingPermitRequest.CriticalLift = WorkPermitSafetyFormState.Required;
                existingPermitRequest.Excavation = WorkPermitSafetyFormState.NotApplicable;
                existingPermitRequest.EnergyControlPlan = WorkPermitSafetyFormState.Approved;
                existingPermitRequest.EquivalencyProc = WorkPermitSafetyFormState.NotApplicable;
                existingPermitRequest.TestPneumatic = WorkPermitSafetyFormState.NotApplicable;
                existingPermitRequest.LiveFlareWork = WorkPermitSafetyFormState.Required;
                existingPermitRequest.EntryAndControlPlan = WorkPermitSafetyFormState.Required;
                existingPermitRequest.EnergizedElectrical = WorkPermitSafetyFormState.Approved;

                existingPermitRequest.HazardHydrocarbonGas = true;
                existingPermitRequest.HazardHydrocarbonLiquid = true;
                existingPermitRequest.HazardHydrogenSulphide = false;
                existingPermitRequest.HazardInertGasAtmosphere = false;
                existingPermitRequest.HazardOxygenDeficiency = true;
                existingPermitRequest.HazardRadioactiveSources = true;
                existingPermitRequest.HazardUndergroundOverheadHazards = false;
                existingPermitRequest.HazardDesignatedSubstance = false;

                existingPermitRequest.FireWatch = false;
                existingPermitRequest.HydrantPermit = false;
                existingPermitRequest.DesignateHotOrColdCutChecked = false;

                existingPermitRequest.ConfinedSpace = false;
                existingPermitRequest.RescuePlan = false;
            }

            {
                incomingPermitRequest = PermitRequestLubesFixture.Create(null, "2222", "7777", null);
                incomingPermitRequest.AddWorkOrderSource("2222", "7778", null);

                incomingPermitRequest.FunctionalLocation = FunctionalLocationFixture.GetReal_MI1_A001_LVFL();
                incomingPermitRequest.Location = "Location from incoming";
                incomingPermitRequest.RequestedByGroup = new WorkPermitLubesGroup(2, "Some Fake Group for Incoming PR", 0);

                incomingPermitRequest.Description = "New description";
                incomingPermitRequest.SapDescription = "New description";

                incomingPermitRequest.WorkPermitType = WorkPermitLubesType.HOT_WORK;
                incomingPermitRequest.IsVehicleEntry = true;
                incomingPermitRequest.Trade = "incoming PR trade";
                incomingPermitRequest.SAPWorkCentre = "incoming SAP work centre";

                incomingPermitRequest.RequestedStartDate = new Date(2014, 1, 2);
                incomingPermitRequest.EndDate = new Date(2014, 1, 4);
                incomingPermitRequest.RequestedStartTimeDay = new Time(2, 2, 2);
                incomingPermitRequest.RequestedStartTimeNight = null;

                incomingPermitRequest.HighEnergy = WorkPermitSafetyFormState.Required; // was approved, so no change
                incomingPermitRequest.CriticalLift = WorkPermitSafetyFormState.NotApplicable;
                incomingPermitRequest.Excavation = WorkPermitSafetyFormState.Required;
                incomingPermitRequest.EnergyControlPlan = WorkPermitSafetyFormState.NotApplicable; // was approved, so no change
                incomingPermitRequest.EquivalencyProc = WorkPermitSafetyFormState.NotApplicable;
                incomingPermitRequest.TestPneumatic = WorkPermitSafetyFormState.Required;
                incomingPermitRequest.LiveFlareWork = WorkPermitSafetyFormState.Required;
                incomingPermitRequest.EntryAndControlPlan = WorkPermitSafetyFormState.Required;
                incomingPermitRequest.EnergizedElectrical = WorkPermitSafetyFormState.Required; // was approved, so no change

                incomingPermitRequest.HazardHydrocarbonGas = true; 
                incomingPermitRequest.HazardHydrocarbonLiquid = false; 
                incomingPermitRequest.HazardHydrogenSulphide = true;
                incomingPermitRequest.HazardInertGasAtmosphere = false;
                incomingPermitRequest.HazardOxygenDeficiency = true;
                incomingPermitRequest.HazardRadioactiveSources = false;
                incomingPermitRequest.HazardUndergroundOverheadHazards = false;
                incomingPermitRequest.HazardDesignatedSubstance = true;

                incomingPermitRequest.FireWatch = true;
                incomingPermitRequest.HydrantPermit = true;
                incomingPermitRequest.DesignateHotOrColdCutChecked = true;

                incomingPermitRequest.ConfinedSpace = true;
                incomingPermitRequest.RescuePlan = true;
            }

            existingPermitRequest.UpdateFromSAPPermitRequest(incomingPermitRequest);

            // Operation sources
            {
                Assert.AreEqual(2, existingPermitRequest.WorkOrderSourceList.Count);
                Assert.IsTrue(existingPermitRequest.WorkOrderSourceList.Exists(s => s.OperationNumber == "7777"));
                Assert.IsTrue(existingPermitRequest.WorkOrderSourceList.Exists(s => s.OperationNumber == "7778"));
            }

            // misc SAP fields
            {
                Assert.AreEqual(FunctionalLocationFixture.GetReal_MI1_A001_LVFL(), existingPermitRequest.FunctionalLocation);
                Assert.AreEqual("Location from incoming", existingPermitRequest.Location);
                Assert.AreEqual(new WorkPermitLubesGroup(2, "Some Fake Group for Incoming PR", 0), existingPermitRequest.RequestedByGroup);
                Assert.AreEqual(WorkPermitLubesType.HOT_WORK, existingPermitRequest.WorkPermitType);
                Assert.IsTrue(existingPermitRequest.IsVehicleEntry);
                Assert.AreEqual("incoming PR trade", existingPermitRequest.Trade);
                Assert.AreEqual("incoming SAP work centre", existingPermitRequest.SAPWorkCentre);
                Assert.AreEqual("New description", existingPermitRequest.SapDescription);
                Assert.AreEqual("This is the user description", existingPermitRequest.Description);
                Assert.IsTrue(existingPermitRequest.ConfinedSpace);
                Assert.IsTrue(existingPermitRequest.RescuePlan);
            }

            // dates and times
            {
                Assert.AreEqual(new Date(2014, 1, 2), existingPermitRequest.RequestedStartDate);
                Assert.AreEqual(new Date(2014, 1, 4), existingPermitRequest.EndDate);
                Assert.AreEqual(new Time(2, 2, 2), existingPermitRequest.RequestedStartTimeDay);
                Assert.IsNull(existingPermitRequest.RequestedStartTimeNight);                
            }

            // form requirements
            {
                Assert.AreEqual(WorkPermitSafetyFormState.Approved, existingPermitRequest.HighEnergy);
                Assert.AreEqual(WorkPermitSafetyFormState.NotApplicable, existingPermitRequest.CriticalLift);
                Assert.AreEqual(WorkPermitSafetyFormState.Required, existingPermitRequest.Excavation);
                Assert.AreEqual(WorkPermitSafetyFormState.Approved, existingPermitRequest.EnergyControlPlan);
                Assert.AreEqual(WorkPermitSafetyFormState.NotApplicable, existingPermitRequest.EquivalencyProc);
                Assert.AreEqual(WorkPermitSafetyFormState.Required, existingPermitRequest.TestPneumatic);
                Assert.AreEqual(WorkPermitSafetyFormState.Required, existingPermitRequest.LiveFlareWork);
                Assert.AreEqual(WorkPermitSafetyFormState.Required, existingPermitRequest.EntryAndControlPlan);
                Assert.AreEqual(WorkPermitSafetyFormState.Approved, existingPermitRequest.EnergizedElectrical);
            }

            // Hazards
            {                
                Assert.AreEqual(true, existingPermitRequest.HazardHydrocarbonGas);
                Assert.AreEqual(true, existingPermitRequest.HazardHydrocarbonLiquid);
                Assert.AreEqual(true, existingPermitRequest.HazardHydrogenSulphide);
                Assert.AreEqual(false, existingPermitRequest.HazardInertGasAtmosphere);
                Assert.AreEqual(true, existingPermitRequest.HazardOxygenDeficiency);
                Assert.AreEqual(true, existingPermitRequest.HazardRadioactiveSources);
                Assert.AreEqual(false, existingPermitRequest.HazardUndergroundOverheadHazards);
                Assert.AreEqual(true, existingPermitRequest.HazardDesignatedSubstance);
            }

            // Specific requirements
            {
                Assert.IsTrue(existingPermitRequest.FireWatch);
                Assert.IsTrue(existingPermitRequest.HydrantPermit);
                Assert.IsTrue(existingPermitRequest.DesignateHotOrColdCutChecked);   

                Assert.IsFalse(existingPermitRequest.SpecificRequirementsSectionNotApplicableToJob);
            }
        }

        private void FetchNewPermitRequests(out PermitRequestLubes request1, out PermitRequestLubes request2)
        {
            request1 = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "group1", 1));
            request2 = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(2, "group2", 2));            
        }

        private WorkPermitSafetyFormState GetDifferentWorkPermitSafetyFormState(WorkPermitSafetyFormState original)
        {
            if (WorkPermitSafetyFormState.Required.Equals(original))
            {
                return WorkPermitSafetyFormState.NotApplicable;
            }

            if (WorkPermitSafetyFormState.NotApplicable.Equals(original))
            {
                return WorkPermitSafetyFormState.Required;
            }

            return WorkPermitSafetyFormState.Required;
        }
    }
}
