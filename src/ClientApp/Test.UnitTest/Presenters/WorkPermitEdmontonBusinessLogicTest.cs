using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Validation.Edmonton;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Client.Presenters
{ 
    [TestFixture]
    public class WorkPermitEdmontonBusinessLogicTest
    {
        private MockWorkPermitEdmontonForm mockForm;
        private WorkPermitEdmontonBusinessLogic workPermitEdmontonBusinessLogic;

        [SetUp]
        public void SetUp()
        {
            mockForm = new MockWorkPermitEdmontonForm();
            workPermitEdmontonBusinessLogic = new WorkPermitEdmontonBusinessLogic(mockForm);

            // set up some basic stuff to prevent null reference exceptions
            mockForm.WorkPermitType = WorkPermitEdmontonType.ROUTINE_MAINTENANCE;
        }


        [Test][Ignore]
        public void TestResultsOfSelectingNormalHotWorkPermitType()
        {
            // initial setup
            {
                mockForm.ContinuousGasMonitor = false;
                mockForm.GasTestsSectionNotApplicableToJob = true;
            }

            // set work permit type to hot work
            {
                mockForm.WorkPermitType = WorkPermitEdmontonType.HOT_WORK;

                workPermitEdmontonBusinessLogic.HandlePermitTypeSelectedValueChanged();

                Assert.IsTrue(mockForm.GasTestsSectionNotApplicableToJob);         // normal hot work no longer affects the gas tests section
                Assert.IsTrue(mockForm.GasTestsSectionNotApplicableToJobEnabled);

                Assert.IsTrue(mockForm.ContinuousGasMonitor);
                Assert.IsFalse(mockForm.ContinuousGasMonitorEnabled);
            }

            // change work permit type back to cold work
            {
                mockForm.WorkPermitType = WorkPermitEdmontonType.COLD_WORK;

                workPermitEdmontonBusinessLogic.HandlePermitTypeSelectedValueChanged();

                Assert.IsTrue(mockForm.GasTestsSectionNotApplicableToJob);
                Assert.IsTrue(mockForm.GasTestsSectionNotApplicableToJobEnabled);

                Assert.IsTrue(mockForm.ContinuousGasMonitor);
                Assert.IsTrue(mockForm.ContinuousGasMonitorEnabled);
            }

            // test what happens when you move it from hot work to cold work but have special work set as 'hot tapping'
            {
                mockForm.WorkPermitType = WorkPermitEdmontonType.HOT_WORK;
                workPermitEdmontonBusinessLogic.HandlePermitTypeSelectedValueChanged();

                mockForm.SpecialWork = true;
                mockForm.SpecialWorkType = EdmontonPermitSpecialWorkType.HotTapping;
                workPermitEdmontonBusinessLogic.HandleSpecialWorkTypeChanged();

                mockForm.WorkPermitType = WorkPermitEdmontonType.COLD_WORK;
                workPermitEdmontonBusinessLogic.HandlePermitTypeSelectedValueChanged();

                Assert.IsTrue(mockForm.ContinuousGasMonitor);
                Assert.IsFalse(mockForm.ContinuousGasMonitorEnabled);   // still disabled because special work type is 'hot tapping'
            }
        }

        [Test][Ignore]
        public void TestThatContinuousGasMonitorIsCheckedAndEnabledOrDisabledUnderTheCorrectCircumstances()
        {
            mockForm.SpecialWorkType = EdmontonPermitSpecialWorkType.Excavation;

            {
                mockForm.WorkPermitType = WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK;
                mockForm.Group = WorkPermitEdmontonGroupFixture.CreateP4();
                workPermitEdmontonBusinessLogic.HandlePermitTypeSelectedValueChanged();

                Assert.IsTrue(mockForm.ContinuousGasMonitor);
                //TODO:Add another test set for the true condition
                //Assert.IsFalse(mockForm.ContinuousGasMonitorEnabled);
                Assert.IsTrue(mockForm.ContinuousGasMonitorEnabled);//Mingle#4001, Added on April 22 by mangesh
                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJobEnabled);

                mockForm.WorkPermitType = WorkPermitEdmontonType.HOT_WORK;
                workPermitEdmontonBusinessLogic.HandlePermitTypeSelectedValueChanged();
                Assert.IsTrue(mockForm.ContinuousGasMonitor);
                Assert.IsFalse(mockForm.ContinuousGasMonitorEnabled);
                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJobEnabled);

                mockForm.WorkPermitType = WorkPermitEdmontonType.COLD_WORK;
                workPermitEdmontonBusinessLogic.HandlePermitTypeSelectedValueChanged();
                Assert.IsTrue(mockForm.ContinuousGasMonitor);
                Assert.IsTrue(mockForm.ContinuousGasMonitorEnabled);
                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
                Assert.IsTrue(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJobEnabled);

                mockForm.ContinuousGasMonitor = false;
                mockForm.SpecialWork = true;
                mockForm.SpecialWorkType = EdmontonPermitSpecialWorkType.HotTapping;
                workPermitEdmontonBusinessLogic.HandleSpecialWorkTypeChanged();
                Assert.IsTrue(mockForm.ContinuousGasMonitor);
                Assert.IsFalse(mockForm.ContinuousGasMonitorEnabled);
                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJobEnabled);

                mockForm.ContinuousGasMonitor = false;
                mockForm.SpecialWork = true;
                mockForm.SpecialWorkType = EdmontonPermitSpecialWorkType.PowderActuatedTool;
                workPermitEdmontonBusinessLogic.HandleSpecialWorkTypeChanged();
                Assert.IsTrue(mockForm.ContinuousGasMonitor);
                Assert.IsFalse(mockForm.ContinuousGasMonitorEnabled);
                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJobEnabled);

                mockForm.SpecialWork = true;
                mockForm.SpecialWorkType = EdmontonPermitSpecialWorkType.HighVoltageElectricalWork;
                workPermitEdmontonBusinessLogic.HandleSpecialWorkTypeChanged();
                Assert.IsTrue(mockForm.ContinuousGasMonitor);
                Assert.IsFalse(mockForm.ContinuousGasMonitorEnabled);
                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJobEnabled);

                mockForm.ContinuousGasMonitor = false;
                mockForm.SpecialWork = true;
                mockForm.SpecialWorkType = EdmontonPermitSpecialWorkType.OnstreamLeakSealing;
                workPermitEdmontonBusinessLogic.HandleSpecialWorkTypeChanged();
                Assert.IsTrue(mockForm.ContinuousGasMonitor);
                Assert.IsFalse(mockForm.ContinuousGasMonitorEnabled);
                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJobEnabled);
            }
        }

        [Test] // DATODO - figure this out
        public void TestThatStatusOfPipingSectionIsMandatoryBasedOnValueOfGn75()
        {
            mockForm.StatusOfPipingEquipmentSectionNotApplicableToJob = true;
            mockForm.GN75A = true;
            workPermitEdmontonBusinessLogic.HandleGn75SelectedValueChanged();
            Assert.IsFalse(mockForm.StatusOfPipingEquipmentSectionNotApplicableToJob);
            Assert.IsFalse(mockForm.StatusOfPipingEquipmentSectionNotApplicableToJobEnabled);

            mockForm.GN75A = false;
            workPermitEdmontonBusinessLogic.HandleGn75SelectedValueChanged();
            Assert.IsFalse(mockForm.StatusOfPipingEquipmentSectionNotApplicableToJob);
            Assert.IsTrue(mockForm.StatusOfPipingEquipmentSectionNotApplicableToJobEnabled);

            mockForm.StatusOfPipingEquipmentSectionNotApplicableToJob = true;
            mockForm.GN75A = true;
            workPermitEdmontonBusinessLogic.HandleGn75SelectedValueChanged();
            Assert.IsFalse(mockForm.StatusOfPipingEquipmentSectionNotApplicableToJob);
            Assert.IsFalse(mockForm.StatusOfPipingEquipmentSectionNotApplicableToJobEnabled);
        }

        [Test][Ignore]
        public void SelectingConfinedSpaceShouldUncheckAndDisableWorkerToProvideGasTestCheckbox()
        {
            mockForm.WorkerToProvideGasTestDataEnabled = true;
            mockForm.WorkerToProvideGasTestData = true;
            mockForm.Group = WorkPermitEdmontonGroupFixture.CreateP4();

            mockForm.ConfinedSpace = true;
            workPermitEdmontonBusinessLogic.HandleConfinedSpaceCheckBoxCheckChanged();

            Assert.IsFalse(mockForm.WorkerToProvideGasTestDataEnabled);
            Assert.IsFalse(mockForm.WorkerToProvideGasTestData);
        }

        [Test][Ignore]
        public void SelectingAnySpecialWorkShouldUncheckAndDisableWorkerToProvideGasTestCheckbox()
        {
            mockForm.WorkerToProvideGasTestDataEnabled = true;
            mockForm.WorkerToProvideGasTestData = true;

            mockForm.SpecialWork = true;
            workPermitEdmontonBusinessLogic.HandleSpecialWorkTypeChanged();

            Assert.IsFalse(mockForm.WorkerToProvideGasTestDataEnabled);
            Assert.IsFalse(mockForm.WorkerToProvideGasTestData);
        }

        [Test]
        public void SelectingHighEnergyHotWorkShouldUncheckAndDisableWorkerToProvideGasTestCheckbox()
        {
            mockForm.WorkerToProvideGasTestDataEnabled = true;
            mockForm.WorkerToProvideGasTestData = true;
            mockForm.Group = WorkPermitEdmontonGroupFixture.CreateP4();

            mockForm.WorkPermitType = WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK;
            workPermitEdmontonBusinessLogic.HandlePermitTypeSelectedValueChanged();

            Assert.IsFalse(mockForm.WorkerToProvideGasTestDataEnabled);
            Assert.IsFalse(mockForm.WorkerToProvideGasTestData);
        }

        [Test][Ignore]
        public void SelectingColdWorkShouldUncheckAndDisableWorkerToProvideGasTestCheckbox()
        {
            mockForm.WorkerToProvideGasTestDataEnabled = true;
            mockForm.WorkerToProvideGasTestData = true;

            mockForm.WorkPermitType = WorkPermitEdmontonType.COLD_WORK;
            workPermitEdmontonBusinessLogic.HandlePermitTypeSelectedValueChanged();

            Assert.IsFalse(mockForm.WorkerToProvideGasTestDataEnabled);
            Assert.IsFalse(mockForm.WorkerToProvideGasTestData);
        }

        [Test]
        public void ReenablingTheGasTestSectionShouldDisableTheWorkerToProvideGasTestCheckboxIfAppropriate()
        {
            // set special work to true because this means that the 'worker to provide gas test' checkbox should be disabled
            mockForm.SpecialWork = true;

            // simulate what happens if the user enables the gas tests section -- the form will enable the 'worker to provide gas test' checkbox since it is a child control
            mockForm.GasTestsSectionNotApplicableToJob = false;
            mockForm.WorkerToProvideGasTestDataEnabled = true;

            // make sure the business logic disables it again, since special work is true
            workPermitEdmontonBusinessLogic.HandleGasTestsSectionNotApplicableToJobCheckBoxCheckChanged();
            Assert.IsFalse(mockForm.WorkerToProvideGasTestDataEnabled);
        }

        [Test]
        public void TestThatTheWorkerToProvideGasTestCheckboxIsReenabledUnderTheRightCircumstances()
        {
            // if (confined space is not selected) and (special work is not selected) and (permit type is not high energy hot work or cold work)
            // then we want the 'worker to provide gas test' checkbox to be enabled

            mockForm.ConfinedSpace = false;
            mockForm.SpecialWork = false;
            mockForm.WorkPermitType = WorkPermitEdmontonType.ROUTINE_MAINTENANCE;

            {
                mockForm.WorkerToProvideGasTestDataEnabled = false;
                mockForm.WorkerToProvideGasTestData = false;

                workPermitEdmontonBusinessLogic.HandleConfinedSpaceCheckBoxCheckChanged();

                Assert.IsTrue(mockForm.WorkerToProvideGasTestDataEnabled);
            }

            {
                mockForm.WorkerToProvideGasTestDataEnabled = false;
                mockForm.WorkerToProvideGasTestData = false;

                workPermitEdmontonBusinessLogic.HandleSpecialWorkTypeChanged();

                Assert.IsTrue(mockForm.WorkerToProvideGasTestDataEnabled);
            }

            {
                mockForm.WorkerToProvideGasTestDataEnabled = false;
                mockForm.WorkerToProvideGasTestData = false;

                workPermitEdmontonBusinessLogic.HandlePermitTypeSelectedValueChanged();

                Assert.IsTrue(mockForm.WorkerToProvideGasTestDataEnabled);
            }
        }

        [Test]
        public void TestThatGasTestSectionMustBeCompletedIfVehicleEntryIsSelected()
        {
            mockForm.GasTestsSectionNotApplicableToJob = true;
            mockForm.Group = WorkPermitEdmontonGroupFixture.CreateP4();

            mockForm.VehicleEntry = true;
            workPermitEdmontonBusinessLogic.HandleVehicleEntryCheckBoxCheckChanged();
            Assert.IsFalse(mockForm.GasTestsSectionNotApplicableToJob);
            Assert.IsFalse(mockForm.GasTestsSectionNotApplicableToJobEnabled);
            Assert.IsFalse(mockForm.WorkerToProvideGasTestData);
            Assert.IsTrue(mockForm.WorkerToProvideGasTestDataEnabled);

            mockForm.VehicleEntry = false;
            workPermitEdmontonBusinessLogic.HandleVehicleEntryCheckBoxCheckChanged();
            Assert.IsFalse(mockForm.GasTestsSectionNotApplicableToJob);
            Assert.IsTrue(mockForm.GasTestsSectionNotApplicableToJobEnabled);
            Assert.IsFalse(mockForm.WorkerToProvideGasTestData);
            Assert.IsTrue(mockForm.WorkerToProvideGasTestDataEnabled);
        }

        [Test]
        public void TestResultsOfSettingSpecialWorkTypeToDivingOperations()
        {
            // change special work to Diving
            {
                mockForm.SpecialWork = true;
                mockForm.SpecialWorkType = EdmontonPermitSpecialWorkType.DivingOperations;

                
                mockForm.specialworktype = new SpecialWork();
                mockForm.specialworktype.CompanyName = "Diving Operations";
                mockForm.SpecialWorkName = "Diving Operations";
                
                workPermitEdmontonBusinessLogic.HandleSpecialWorkTypeChanged();

                Assert.IsTrue(mockForm.SafetyWatch);
                Assert.IsFalse(mockForm.SafetyWatchEnabled);

                Assert.IsTrue(mockForm.RadioChannelChecked);
                Assert.IsFalse(mockForm.RadioChannelEnabled);
            }

            // then change special work away from Diving
            {
                mockForm.SpecialWork = true;
                mockForm.SpecialWorkType = EdmontonPermitSpecialWorkType.OnstreamLeakSealing;
                mockForm.specialworktype.CompanyName = "On-Stream Leak Sealing";
                mockForm.SpecialWorkName = "On-Stream Leak Sealing";

                workPermitEdmontonBusinessLogic.HandleSpecialWorkTypeChanged();

                Assert.IsTrue(mockForm.SafetyWatch);
                Assert.IsTrue(mockForm.SafetyWatchEnabled);

                Assert.IsTrue(mockForm.RadioChannelChecked);
                Assert.IsTrue(mockForm.RadioChannelEnabled);
            }
        }

        [Test][Ignore]
        public void TestResultsOfSettingSpecialWorkTypeToExcavation()
        {
            mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = true;

            // change special work to Excavation
            {
                mockForm.SpecialWork = true;
                mockForm.SpecialWorkType = EdmontonPermitSpecialWorkType.Excavation;

                workPermitEdmontonBusinessLogic.HandleSpecialWorkTypeChanged();

                Assert.IsTrue(mockForm.BarriersSigns);
                Assert.IsFalse(mockForm.BarriersSignsEnabled);
                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJobEnabled);
            }

            // change it away from Excavation
            {
                mockForm.SpecialWork = false;
                workPermitEdmontonBusinessLogic.HandleSpecialWorkTypeChanged();

                Assert.IsTrue(mockForm.BarriersSigns);
                Assert.IsTrue(mockForm.BarriersSignsEnabled);
                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
                Assert.IsTrue(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJobEnabled);
            }
        }

        [Test][Ignore]
        public void MakeSureThatTheGasTestSectionIsLockedDownIfYouHaveConfinedSpaceSelectedButThenSelectSomethingThatEnablesIt()
        {
            mockForm.GasTestsSectionNotApplicableToJob = true;
            mockForm.GasTestsSectionNotApplicableToJobEnabled = true;
            mockForm.WorkerToProvideGasTestData = true;
            mockForm.WorkerToProvideGasTestDataEnabled = true;
            mockForm.Group = WorkPermitEdmontonGroupFixture.CreateP4();

            mockForm.ConfinedSpace = true;
            workPermitEdmontonBusinessLogic.HandleConfinedSpaceCheckBoxCheckChanged();

            mockForm.SpecialWorkType = EdmontonPermitSpecialWorkType.Excavation;
            workPermitEdmontonBusinessLogic.HandleSpecialWorkTypeChanged();

            Assert.IsFalse(mockForm.GasTestsSectionNotApplicableToJob);
            Assert.IsFalse(mockForm.GasTestsSectionNotApplicableToJobEnabled);
            Assert.IsFalse(mockForm.WorkerToProvideGasTestData);
            Assert.IsFalse(mockForm.WorkerToProvideGasTestDataEnabled);
        }

        [Test][Ignore]
        public void TestResultsOfSelectingConfinedSpace()
        {
            // setup
            {
                mockForm.GasTestsSectionNotApplicableToJob = true;
                mockForm.GasTestsSectionNotApplicableToJobEnabled = true;
                mockForm.WorkerToProvideGasTestData = true;
                mockForm.Group = WorkPermitEdmontonGroupFixture.CreateP4();

                mockForm.WorkerToProvideGasTestDataEnabled = true;
            }

            // check it
            {
                mockForm.ConfinedSpace = true;
                workPermitEdmontonBusinessLogic.HandleConfinedSpaceCheckBoxCheckChanged();

                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJobEnabled);

                Assert.IsFalse(mockForm.GasTestsSectionNotApplicableToJob);
                Assert.IsFalse(mockForm.GasTestsSectionNotApplicableToJobEnabled);
                Assert.IsFalse(mockForm.WorkerToProvideGasTestData);
                Assert.IsFalse(mockForm.WorkerToProvideGasTestDataEnabled);

                Assert.IsTrue(mockForm.SafetyWatch);
                Assert.IsFalse(mockForm.SafetyWatchEnabled);

                Assert.IsTrue(mockForm.BarriersSigns);
                Assert.IsFalse(mockForm.BarriersSignsEnabled);

                Assert.IsTrue(mockForm.AirHorn);
                Assert.IsFalse(mockForm.AirHornEnabled);
            }

            // uncheck it
            {
                mockForm.ConfinedSpace = false;
                workPermitEdmontonBusinessLogic.HandleConfinedSpaceCheckBoxCheckChanged();

                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
                Assert.IsTrue(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJobEnabled);

                Assert.IsFalse(mockForm.GasTestsSectionNotApplicableToJob);
                Assert.IsTrue(mockForm.GasTestsSectionNotApplicableToJobEnabled);
                Assert.IsFalse(mockForm.WorkerToProvideGasTestData);
                Assert.IsTrue(mockForm.WorkerToProvideGasTestDataEnabled);

                Assert.IsTrue(mockForm.SafetyWatch);
                Assert.IsTrue(mockForm.SafetyWatchEnabled);

                Assert.IsTrue(mockForm.BarriersSigns);
                Assert.IsTrue(mockForm.BarriersSignsEnabled);

                Assert.IsTrue(mockForm.AirHorn);
                Assert.IsTrue(mockForm.AirHornEnabled);
            }

            // Allow events to over-ride the current checked values. 
            {
                mockForm.ConfinedSpace = false;
                
                workPermitEdmontonBusinessLogic.AllowEventsToOverrideUserSelectedCheckboxes = true;
                workPermitEdmontonBusinessLogic.HandleConfinedSpaceCheckBoxCheckChanged();

                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
                Assert.IsTrue(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJobEnabled);

                Assert.IsFalse(mockForm.GasTestsSectionNotApplicableToJob);
                Assert.IsTrue(mockForm.GasTestsSectionNotApplicableToJobEnabled);

                Assert.IsFalse(mockForm.SafetyWatch);
                Assert.IsTrue(mockForm.SafetyWatchEnabled);

                Assert.IsFalse(mockForm.BarriersSigns);
                Assert.IsTrue(mockForm.BarriersSignsEnabled);

                Assert.IsFalse(mockForm.AirHorn);
                Assert.IsTrue(mockForm.AirHornEnabled);
            }

            // Don't allow events to over-ride the current checked values, mock the values being set by the user and make sure they are maintained.
            {
                mockForm.SafetyWatch = true;
                mockForm.BarriersSigns = true;
                mockForm.AirHorn = true;

                mockForm.ConfinedSpace = false;

                workPermitEdmontonBusinessLogic.AllowEventsToOverrideUserSelectedCheckboxes = false;
                workPermitEdmontonBusinessLogic.HandleConfinedSpaceCheckBoxCheckChanged();

                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
                Assert.IsTrue(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJobEnabled);

                Assert.IsFalse(mockForm.GasTestsSectionNotApplicableToJob);
                Assert.IsTrue(mockForm.GasTestsSectionNotApplicableToJobEnabled);

                Assert.IsTrue(mockForm.SafetyWatch);
                Assert.IsTrue(mockForm.SafetyWatchEnabled);

                Assert.IsTrue(mockForm.BarriersSigns);
                Assert.IsTrue(mockForm.BarriersSignsEnabled);

                Assert.IsTrue(mockForm.AirHorn);
                Assert.IsTrue(mockForm.AirHornEnabled);

            }
        }

        [Test]
        public void TestSelectionOfConfinedSpaceClass()
        {
            
            // select class A
            {
                mockForm.ConfinedSpace = true;
                mockForm.ConfinedSpaceClass = WorkPermitEdmonton.ConfinedSpaceLevel1;
                workPermitEdmontonBusinessLogic.HandleConfinedSpaceClassChanged();
                mockForm.Group = WorkPermitEdmontonGroupFixture.CreateP4();

                Assert.IsTrue(mockForm.BreathingAirApparatus);
                Assert.IsFalse(mockForm.BreathingAirApparatusEnabled);

                Assert.IsTrue(mockForm.RescuePlan);
                Assert.IsFalse(mockForm.RescuePlanEnabled);

                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJobEnabled);
            }

            // turn off confined space
            {
                mockForm.ConfinedSpace = false;
                workPermitEdmontonBusinessLogic.HandleConfinedSpaceCheckBoxCheckChanged();

                Assert.IsTrue(mockForm.BreathingAirApparatus);
                Assert.IsTrue(mockForm.BreathingAirApparatusEnabled);

                Assert.IsTrue(mockForm.RescuePlan);
                Assert.IsTrue(mockForm.RescuePlanEnabled);

                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
                Assert.IsTrue(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJobEnabled);
            }

            mockForm.BreathingAirApparatus = false;
            mockForm.RescuePlan = false;
            mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = true;

            // select class B
            {
                mockForm.ConfinedSpace = true;
                mockForm.ConfinedSpaceClass = WorkPermitEdmonton.ConfinedSpaceLevel2;
                workPermitEdmontonBusinessLogic.HandleConfinedSpaceCheckBoxCheckChanged();

                Assert.IsFalse(mockForm.BreathingAirApparatus);

                Assert.IsTrue(mockForm.RescuePlan);
                Assert.IsFalse(mockForm.RescuePlanEnabled);

                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
                Assert.IsFalse(mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJobEnabled);
            }
        }

        [Test]
        public void TestSelectionOfContinuousGasMonitor()
        {
            {
                mockForm.ContinuousGasMonitor = true;
                workPermitEdmontonBusinessLogic.HandleContinuousGasMonitorCheckBoxCheckChanged();

                Assert.IsTrue(mockForm.WorkersMonitor);
                Assert.IsFalse(mockForm.WorkersMonitorEnabled);

                Assert.IsTrue(mockForm.BumpTestMonitorPriorToUse);
                Assert.IsFalse(mockForm.BumpTestMonitorPriorToUseEnabled);
            }

            {
                mockForm.ContinuousGasMonitor = false;
                workPermitEdmontonBusinessLogic.HandleContinuousGasMonitorCheckBoxCheckChanged();

                Assert.IsTrue(mockForm.WorkersMonitor);
                Assert.IsTrue(mockForm.WorkersMonitorEnabled);

                Assert.IsTrue(mockForm.BumpTestMonitorPriorToUse);
                Assert.IsTrue(mockForm.BumpTestMonitorPriorToUseEnabled);
            }
        }

        [Test]   // bug #2037
        public void TestThatReenablingWorkersMinimumSafetyRequirementsSectionWillReapplyBusinessLogic()
        {
            // flip on continuous gas monitor, which will disable workers monitor and bump test monitor prior to use
            mockForm.ContinuousGasMonitor = true;
            workPermitEdmontonBusinessLogic.HandleContinuousGasMonitorCheckBoxCheckChanged();
            Assert.IsTrue(mockForm.BumpTestMonitorPriorToUse);
            Assert.IsFalse(mockForm.BumpTestMonitorPriorToUseEnabled);
            Assert.IsTrue(mockForm.WorkersMonitor);
            Assert.IsFalse(mockForm.WorkersMonitorEnabled);

            // now pretend to disable and reenable the workers minimum safety requirements section, which will disable and then reenable all fields (including ones that should still be disabled)
            mockForm.BumpTestMonitorPriorToUseEnabled = true;
            mockForm.WorkersMonitorEnabled = true;

            // now run the business logic for reenabling the workers minimum safety requirements section and ensure it disables the correct checkboxes
            mockForm.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = false;
            workPermitEdmontonBusinessLogic.HandleWorkersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBoxCheckChanged();
            Assert.IsTrue(mockForm.BumpTestMonitorPriorToUse);
            Assert.IsFalse(mockForm.BumpTestMonitorPriorToUseEnabled);
            Assert.IsTrue(mockForm.WorkersMonitor);
            Assert.IsFalse(mockForm.WorkersMonitorEnabled);
        }

        [Test]
        public void CheckingUseCurrentWorkPermitNumberShouldDisableZeroEnergyFormNumberField()
        {
            mockForm.ZeroEnergyFormNumberEnabled = true;
            mockForm.UseCurrentPermitNumberForZeroEnergyFormNumber = true;
            workPermitEdmontonBusinessLogic.HandleUseCurrentWorkPermitNumberCheckBoxCheckChanged();

            Assert.IsFalse(mockForm.ZeroEnergyFormNumberEnabled);            
        }

        [Test]
        public void EnablingStatusOfPipingSectionShouldNotEnableZeroEnergyFormNumberFieldIfUseCurrentWorkPermitNumberIsChecked()
        {
            {
                mockForm.ZeroEnergyFormNumberEnabled = false;
                mockForm.UseCurrentPermitNumberForZeroEnergyFormNumber = true;

                // enable section; this automatically enables the zero energy form number field, so we fake that behaviour here:
                mockForm.StatusOfPipingEquipmentSectionNotApplicableToJob = false;
                mockForm.ZeroEnergyFormNumberEnabled = true;

                workPermitEdmontonBusinessLogic.HandleStatusOfPipingEquipmentNotApplicabletoJobCheckBoxCheckChanged(false);

                // the zero energy form number field becomes disabled since the 'use current work permit number' checkbox is checked
                Assert.IsFalse(mockForm.ZeroEnergyFormNumberEnabled);
            }

            {
                mockForm.ZeroEnergyFormNumberEnabled = false;
                mockForm.UseCurrentPermitNumberForZeroEnergyFormNumber = false;

                // enable section; this automatically enables the zero energy form number field, so we fake that behaviour here:
                mockForm.StatusOfPipingEquipmentSectionNotApplicableToJob = false;
                mockForm.ZeroEnergyFormNumberEnabled = true;

                workPermitEdmontonBusinessLogic.HandleStatusOfPipingEquipmentNotApplicabletoJobCheckBoxCheckChanged(false);

                // the zero energy form number field stays enabled since the 'use current work permit number' checkbox is not checked
                Assert.IsTrue(mockForm.ZeroEnergyFormNumberEnabled);
            }
        }

        [Test]
        public void IfThereIsAPermitNumberAlreadyThenTheUseCurrentWorkPermitNumberCheckBoxShouldPopulateTheZeroEnergyFormNumberFieldWithIt()
        {
            {
                mockForm.PermitNumber = "100";
                mockForm.ZeroEnergyFormNumber = null;

                mockForm.UseCurrentPermitNumberForZeroEnergyFormNumber = true;
                workPermitEdmontonBusinessLogic.HandleUseCurrentWorkPermitNumberCheckBoxCheckChanged();

                Assert.IsFalse(mockForm.ZeroEnergyFormNumberEnabled);
                Assert.AreEqual("100", mockForm.ZeroEnergyFormNumber);
            }

            // if there isn't a permit number, the field should be made empty
            {
                mockForm.PermitNumber = "";
                mockForm.ZeroEnergyFormNumber = "111";

                mockForm.UseCurrentPermitNumberForZeroEnergyFormNumber = true;
                workPermitEdmontonBusinessLogic.HandleUseCurrentWorkPermitNumberCheckBoxCheckChanged();

                Assert.IsFalse(mockForm.ZeroEnergyFormNumberEnabled);
                Assert.AreEqual(string.Empty, mockForm.ZeroEnergyFormNumber);
            }
        }

        [Test]
        public void IfConfinedSpaceClassIsEmptyThenCheckingConfinedSpaceShouldNotUncheckRescuePlan()
        {
            workPermitEdmontonBusinessLogic.AllowEventsToOverrideUserSelectedCheckboxes = true;

            mockForm.RescuePlan = true;
            mockForm.RescuePlanEnabled = true;
            mockForm.Group = WorkPermitEdmontonGroupFixture.CreateP4();

            mockForm.ConfinedSpaceClass = null;
            mockForm.ConfinedSpace = true;

            workPermitEdmontonBusinessLogic.HandleConfinedSpaceCheckBoxCheckChanged();

            Assert.IsTrue(mockForm.RescuePlanEnabled);
            Assert.IsTrue(mockForm.RescuePlan);
        }
    }
     
    internal class MockWorkPermitEdmontonForm : IWorkPermitEdmontonView
    {
        public IntPtr Handle { get; private set; }
        public event EventHandler Load { add {} remove {} }
        public event EventHandler Disposed { add {} remove {} }
        public event FormClosingEventHandler FormClosing { add {} remove {} }
        public event Action ExpireTimeChangedByUser {
            add { }
            remove { }
        }

        public int Height { get; set; }
        public DialogResult DialogResult { get; set; }

        Point IForm.Location{ get; set; }

        public int Width { get; set; }
        
        public DialogResult ShowDialog(IWin32Window form)
        {
            return DialogResult.OK;
        }

        public void Dispose()
        {
        }

        public void Close()
        {
        }

        public void SetFormVisibleState(bool visible)
        {            
        }

        public bool ConfirmCancelDialog()
        {
            return false;
        }

        public void SaveFailedMessage()
        {
        }

        public void SaveSucceededMessage()
        {
        }

        public void ShowMessageBox(string title, string error)
        {
        }

        public void UpdateTitleAsCreateOrEdit(bool isEdit, string titleText)
        {
        }

        public event EventHandler SaveButtonClicked { add { } remove { } }
        public event EventHandler CancelButtonClicked { add {} remove {} }
        public event Action GroupChanged { add {} remove {} }

        public void ClearErrorProviders()
        {
        }

        public void ShowWaitScreenAndDisableForm()
        {        
        }

        public void CloseWaitScreenAndEnableForm()
        {       
        }

        public FunctionalLocation FunctionalLocation { get; set; }
        public bool IssuedToSuncor { get; set; }
        
        public bool IssuedToContractor { get; set; }
        public string Occupation { get; set; }
        public int? NumberOfWorkers { get; set; }
        public WorkPermitEdmontonGroup Group { get; set; }
        public WorkPermitEdmontonType WorkPermitType { get; set; }

        public string PermitNumber { get;  set; }

        public bool DurationPermit { get; set; }
        public string Location { get; set; }
        public string Company { get; set; }
        public string WorkOrderNumber { get; set; }
        public string OperationNumber { get; set; }
        public string SubOperationNumber { get; set; }
        public string Description { get; set; }
        public string HazardsAndOrRequirements { get; set; }
        public List<string> AlkylationEntryClassOfClothingSelectionList { set; private get; }
        public List<string> FlarePitEntryTypeSelectionList { set; private get; }
        public List<string> ConfinedSpaceClassSelectionList { set; private get; }
        public List<EdmontonPermitSpecialWorkType> SpecialWorkTypeSelectionList { set; private get; }
        public string AlkylationEntryClassOfClothing { get; set; }
        public bool AlkylationEntry { get; set; }
        public bool FlarePitEntry { get; set; }
        public string FlarePitEntryType { get; set; }
        public bool ConfinedSpace { get; set; }
        public string ConfinedSpaceCardNumber { get; set; }
        public string ConfinedSpaceClass { get; set; }
        public bool RescuePlan { get; set; }
        public string RescuePlanFormNumber { get; set; }
        public bool VehicleEntry { get; set; }
        public int? VehicleEntryTotal { get; set; }
        public string VehicleEntryType { get; set; }
        public bool SpecialWork { get; set; }
        public string SpecialWorkFormNumber { get; set; }
        public EdmontonPermitSpecialWorkType SpecialWorkType { get; set; }
        public SpecialWork specialworktype { get; set; }//mangesh for SpecialWork

        //mangesh for RoadAccessOnPermit
        public bool RoadAccessOnPermit { get; set; }
        public string RoadAccessOnPermitFormNumber { get; set; }
        public string RoadAccessOnPermitType { get; set; }

        public string SpecialWorkName { get; set; }

        public bool GN59 { get; set; }
        public bool GN6 { get; set; }
        public bool GN7 { get; set; }
        public bool GN24 { get; set; }
        public bool GN75A { get; set; }
        public bool GN1 { get; set; }
        public string FormGN1TradeChecklistNumber { get; set; }
        public FormGN59 FormGN59 { get; set; }
        public FormGN6 FormGN6 { get; set; }
        public FormGN7 FormGN7 { get; set; }
        public FormGN24 FormGN24 { get; set; }
        public FormGN75A FormGN75A { get; set; }
        public FormGN1 FormGN1 { get; set; }
        public long? FormGN1TradeChecklistId { get; set; }        

        public WorkPermitSafetyFormState GN11 { get; set; }
        public WorkPermitSafetyFormState GN27 { get; set; }        
        public List<WorkPermitSafetyFormState> GN11Values { set; private get; }
        public List<WorkPermitSafetyFormState> GN24Values { set; private get; }
        public List<WorkPermitSafetyFormState> GN27Values { set; private get; }        
        public string OtherAreasAndOrUnitsAffectedArea { get; private set; }
        public string OtherAreasAndOrUnitsAffectedPersonNotified { get; private set; }
        public bool OtherAreasAndOrUnitsAffected { get; private set; }
        public void SetOtherAreasAndOrUnitsAffected(bool otherAreasAndOrUnitsAffected, string otherAreasAndOrUnitsAffectedArea, string otherAreasAndOrUnitsAffectedPersonNotified) {}

        public bool WorkersMinimumSafetyRequirementsSectionNotApplicableToJob { get; set; }
        public bool FaceShield { get; set; }
        public bool Goggles { get; set; }
        public bool RubberBoots { get; set; }
        public bool RubberGloves { get; set; }
        public bool RubberSuit { get; set; }
        public bool SafetyHarnessLifeline { get; set; }
        public bool HighVoltagePPE { get; set; }
        public bool Other1 { get; set; }
        public string Other1Value { get; set; }
        public bool EquipmentGrounded { get; set; }
        public bool FireBlanket { get; set; }
        public bool FireExtinguisher { get; set; }
        public bool FireMonitorManned { get; set; }
        public bool FireWatch { get; set; }
        public bool SewersDrainsCovered { get; set; }
        public bool SteamHose { get; set; }
        public bool Other2 { get; set; }
        public string Other2Value { get; set; }
        public bool AirPurifyingRespirator { get; set; }
        public bool BreathingAirApparatus { get; set; }
        public bool DustMask { get; set; }
        public bool LifeSupportSystem { get; set; }
        public bool SafetyWatch { get; set; }
        public bool ContinuousGasMonitor { get; set; }
        public bool WorkersMonitor { get; set; }
        public string WorkersMonitorNumber { get; set; }
        public bool BumpTestMonitorPriorToUse { get; set; }
        public bool Other3 { get; set; }
        public string Other3Value { get; set; }
        public bool AirMover { get; set; }
        public bool BarriersSigns { get; set; }

        public bool RadioChannel { get; set; }
        public string RadioChannelNumber { get; set; }
        public bool AirHorn { get; set; }
        public bool MechVentilationComfortOnly { get; set; }
        public bool AsbestosMMCPrecautions { get; set; }
        public bool Other4 { get; set; }
        public string Other4Value { get; set; }
        public DateTime LastModifiedDateTime { set; private get; }
        public User LastModifiedBy { set; private get; }

        public List<AreaLabel> AreaLabels { set {} }

        public AreaLabel AreaLabel
        {
            get { return null; }
            set { }
        }

        public string PermitAcceptor { get; set; }
        public string ShiftSupervisor { get; set; }

        public List<string> ShiftSupervisorSelectionList
        {
            set { throw new NotImplementedException(); }
        }

        public List<Priority> Priorities
        {
            set { throw new NotImplementedException(); }
        }

        public Priority Priority
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public List<string> AllAffectedAreas
        {
            set {  }
        }

        public bool SaveAndIssueButtonEnabled
        {
            set { throw new NotImplementedException(); }
        }

        public bool FormEnabled
        {
            set { throw new NotImplementedException(); }
        }

        public void SetFormGN1ToolTip(string tip)
        {
            throw new NotImplementedException();
        }

        public void SetFormGN7ToolTip(string tip)
        {
            throw new NotImplementedException();
        }

        public void SetFormGN59ToolTip(string tip)
        {
            throw new NotImplementedException();
        }

        public void SetFormGN11ToolTip(string tip)
        {
            throw new NotImplementedException();
        }

        public void SetFormGN24ToolTip(string tip)
        {
            throw new NotImplementedException();
        }

        public void SetFormGN27ToolTip(string tip)
        {
            throw new NotImplementedException();
        }

        public void SetFormGN6ToolTip(string tip)
        {
            throw new NotImplementedException();
        }

        public void SetFormGN75ToolTip(string tip)
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoFunctionalLocation()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoPermitType()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoDescription()
        {
            throw new NotImplementedException();
        }

        //mangesh - for numeric field
        public void SetErrorForNoAlphaNumeric(string name)
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoContractor()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNumberOfWorkersLessThanOrEqualToZero()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoAreaAffected()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoPersonNotified()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForStartDateTimeNotBeforeEndDateTime()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoOccupation()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoLocation()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoGroup()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoClassOfClothing()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoFlarePitEntryType()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoApprovedGN24Form()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoApprovedGN75AForm()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoApprovedGN1Form() { }

        public void ActionForGroupMaintenance() { } // Swapnil Patki For DMND0005325 Point Number 9
        public void ActionForValidTradeCheckGN1Form() { } //Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016

        public void SetErrorForNoConfinedSpaceCardNumber()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoConfinedSpaceClass()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoRescuePlanFormNumber()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoVehicleEntryTotalNumber()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoVehicleEntryType()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoSpecialWorkFormNumber()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoSpecialWorkType()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoRoadAccessOnPermitFormNumber()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoRoadAccessOnPermit()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoGN59FormNumber()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoGN6FormNumber()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoGN7FormNumber()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForInvalidGN6Value()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForInvalidGN11Value()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForInvalidGN24Value()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForInvalidGN27Value()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForInvalidGN75Value()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoApprovedGN59Form()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoApprovedGN6Form()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoApprovedGN7Form()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoRescuePlanDueToConfinedSpaceClassValue()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForOther1CheckedWithNoValue()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForOther2CheckedWithNoValue()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForOther3CheckedWithNoValue()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForOther4CheckedWithNoValue()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoSafetyRequirementChosen()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoWorkersMonitorNumber()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoRadioChannelNumber()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForHazardsTooLong()
        {
            throw new NotImplementedException();
        }

        public event Action FunctionalLocationBrowseClicked { add { } remove { } }
        public event Action FormLoad { add {} remove {} }
        public event Action SelectFormGN1ButtonClicked;
        public event Action SelectFormGN6ButtonClicked;
        public event Action SelectFormGN7ButtonClicked { add { } remove { } }
        public event Action SelectFormGN59ButtonClicked { add { } remove { } }
        public event Action SelectFormGN24ButtonClicked { add { } remove { } }
        public event Action SelectFormGN75AButtonClicked { add { } remove { } }
        public event Action SaveAndIssueButtonClicked { add { } remove { } }
        public event Action PrintPreferencesButtonClicked { add { } remove { } }        
        public event Action ViewConfiguredDocumentLinkClicked { add { } remove { } }
        public event Action InProcessButtonClicked { add { } remove { } } //swapnil test
        public bool ContinuousGasMonitorChecked { set; get; } //Mingle#4001, added on April 1, by mangesh
        public bool WorkOrderNumberReadOnly { set; private get; }
        public bool OperationNumberReadOnly { set; private get; }
        public bool SubOperationNumberReadOnly { set; private get; }
        public FunctionalLocation ShowSecondLevelOrLowerFunctionalLocationSelector()
        {
            throw new NotImplementedException();
        }

        public DateTime RequestedStartDateTime { get; set; }
        public DateTime IssuedDateTime { get; set; }
        public DateTime ExpiryDateTime { get; set; }
        public List<WorkPermitEdmontonType> AllPermitTypes { set; private get; }
        public List<Contractor> AllCompanies { set; private get; }
        public List<WorkPermitEdmontonGroup> AllGroups { set; private get; }
        public List<CraftOrTrade> AllCraftOrTrades { set; private get; }
        public List<CraftOrTrade> AllRoadAccessOnPermitType { set; private get; }   //mangesh for RoadAccessOnPermit 
        public List<SpecialWork> AllSpecialWorkType { set; get; }

        public bool AreaAffectedEnabled { set; private get; }
        public bool PersonNotifiedEnabled { set; private get; }
        public string ProductNormallyInPipingEquipment { get; set; }
        public YesNoNotApplicable IsolationValvesLocked { get; set; }
        public YesNoNotApplicable DepressuredDrained { get; set; }
        public YesNoNotApplicable Ventilated { get; set; }
        public YesNoNotApplicable Purged { get; set; }
        public YesNoNotApplicable BlindedAndTagged { get; set; }
        public YesNoNotApplicable DoubleBlockAndBleed { get; set; }
        public YesNoNotApplicable ElectricalLockout { get; set; }
        public YesNoNotApplicable MechanicalLockout { get; set; }
        public YesNoNotApplicable BlindSchematicAvailable { get; set; }
        public string ZeroEnergyFormNumber { get; set; }

        public bool UseCurrentPermitNumberForZeroEnergyFormNumber { get; set; }

        public string LockBoxNumber { get; set; }
        public bool JobsiteEquipmentInspected { get; set; }
        public string OperatorGasDetectorNumber { get; set; }
        public YesNoNotApplicable QuestionOneResponse { get; set; }
        public YesNoNotApplicable QuestionTwoResponse { get; set; }
        public YesNoNotApplicable QuestionTwoAResponse { get; set; }
        public YesNoNotApplicable QuestionTwoBResponse { get; set; }
        public YesNoNotApplicable QuestionThreeResponse { get; set; }
        public YesNoNotApplicable QuestionFourResponse { get; set; }
        public string GasTestDataLine1CombustibleGas { get; set; }
        public string GasTestDataLine1Oxygen { get; set; }
        public string GasTestDataLine1ToxicGas { get; set; }
        public Time GasTestDataLine1Time { get; set; }
        public string GasTestDataLine2CombustibleGas { get; set; }
        public string GasTestDataLine2Oxygen { get; set; }
        public string GasTestDataLine2ToxicGas { get; set; }
        public Time GasTestDataLine2Time { get; set; }
        public string GasTestDataLine3CombustibleGas { get; set; }
        public string GasTestDataLine3Oxygen { get; set; }
        public string GasTestDataLine3ToxicGas { get; set; }
        public Time GasTestDataLine3Time { get; set; }
        public string GasTestDataLine4CombustibleGas { get; set; }
        public string GasTestDataLine4Oxygen { get; set; }
        public string GasTestDataLine4ToxicGas { get; set; }
        public Time GasTestDataLine4Time { get; set; }
        public bool StatusOfPipingEquipmentSectionNotApplicableToJob { get; set; }
        public bool ConfinedSpaceWorkSectionNotApplicableToJob { get; set; }
        public bool GasTestsSectionNotApplicableToJob { get; set; }

        public bool WorkerToProvideGasTestData { get; set; }
        public bool WorkerToProvideGasTestDataEnabled { get; set; }

        public void ShowHasValidationWarningsAndErrorsMessageBox()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoProductNormallyInPipingEquipment()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForAtLeastOneGasTestsTableLineMustBeFilledOut()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForGasTestsTableLine1IsInvalid()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForGasTestsTableLine2IsInvalid()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForGasTestsTableLine3IsInvalid()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForGasTestsTableLine4IsInvalid()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoOperatorGasDetectorNumber()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForTimeSpanTooLong()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForExpiryDateTimeInThePast()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoIssuedToOptionSelected()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoHazardsAndOrRequirements()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForExpiryMustNotBeMoreThanTwoHoursAfterTheIssuedShift()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForNoFireProtectiveMeasuresChosenButTypeIsHighEnergyHotWork()
        {
            throw new NotImplementedException();
        }

        public void SetErrorForQuestionOneNotSetToYes()
        {
            throw new NotImplementedException();
        }

        public bool RadioChannelChecked { get; set; }
        public bool RadioChannelEnabled { get; set; }
        public bool SafetyWatchEnabled { get; set; }
        public bool BarriersSignsEnabled { get; set; }
        public bool ContinuousGasMonitorEnabled { get; set; }
        public bool GasTestsSectionNotApplicableToJobEnabled { get; set; }
        public bool WorkersMinimumSafetyRequirementsSectionNotApplicableToJobEnabled { get; set; }
        public string oltlabel43 { get; set; } //Minlge Story #4002, Change By : Swapnil, Changed On : 30 Mar 2016
        //Changes for SNOW Incident # INC0025434 On 18Aug2016 by Dharmesh_s
        public bool IsEdit { get; set; }
        public bool IsClone { get; set; }
        //Changes for SNOW Incident # INC0025434 On 18Aug2016 by Dharmesh_e
        public bool WorkersMonitorEnabled { get; set; }
        public bool BumpTestMonitorPriorToUseEnabled { get; set; }
        public bool ConfinedSpaceWorkSectionNotApplicableToJobEnabled { get; set; }
        public bool RescuePlanEnabled { get; set; }
        public bool BreathingAirApparatusEnabled { get; set; }
        public bool StatusOfPipingEquipmentSectionNotApplicableToJobEnabled { get; set; }
        public bool AirHornEnabled { get; set; }
        public void ForceExecutionOfBusinessLogic(PermitRequestBasedWorkPermitStatus status) { }
        public DialogResult ShowWarnings(WorkPermitEdmontonOtherWarnings otherWarnings, bool validationWarning)
        {
            return DialogResult.Yes;
        }

        public void ShowFlocNeedsToBeSelectedMessage() { }

        public bool AllowEventsToOverrideUserSelectedCheckboxes
        {
            set {  }
        }

        public List<DocumentLink> DocumentLinks
        {
            get { return new List<DocumentLink>(); }
            set {  }
        }

        public void DisableConfiguredDocumentLinks()
        {            
        }

        public List<ConfiguredDocumentLink> ConfiguredDocumentLinks
        {
            set {  }
        }

        public ConfiguredDocumentLink SelectedConfiguredDocumentLink
        {
            get { return null; }
        }

        public bool ZeroEnergyFormNumberEnabled { get; set; }

        public bool UseCurrentWorkPermitNumberEnabled { get; set; }

        public void OpenFileOrDirectoryOrWebsite(string path)
        {
        }

        public DialogResult ShowSaveAndCloseMessageForWarnings()
        {            
            return DialogResult.Yes;
        }

        public event Action ValidateButtonClicked { add { } remove { } }
        public void ShowIsValidMessageBox()
        {
        }

        public void ShowHasValidationErrorsMessageBox()
        {
        }

        public void ShowHasValidationWarningsMessageBox()
        {
        }

        public void TurnOnAutosetIndicatorsForDateTimes()
        {
            ;
        }


        public void ClearAutosetIndicatorsForDateTimes()
        {
            ;
        }

        public void DisplayInvalidPrintMessage(string message)
        {            
        }

        public void DisplayErrorMessageDialog(string message, string title)
        {            
        }

        public void PopulateFunctionalLocationSelector(List<FunctionalLocation> functionalLocations)
        {
            throw new NotImplementedException();
        }

        public event Action FormGN1CheckBoxCheckChanged;
        public bool ConfinedSpaceCheckBoxEnabled { set; private get; }
        public bool RescuePlanCheckBoxEnabled { set; private get; }
        public bool RescuePlanFormNumberEnabled { set; private get; }
        public bool ConfinedSpaceClassEnabled { set; private get; }
        public bool ConfinedSpaceCardNumberEnabled { set; private get; }


        public string ClonedFormDetailEdmonton { get; set; } // Added by Vibhor : DMND0011077 - Work Permit Clone History
    }
}
