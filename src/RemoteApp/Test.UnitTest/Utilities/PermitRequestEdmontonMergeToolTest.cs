using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Utilities
{    
    [TestFixture]
    public class PermitRequestEdmontonMergeToolTest
    {
        private PermitRequestEdmontonMergeTool tool;

        [SetUp]
        public void SetUp()
        {
            tool = new PermitRequestEdmontonMergeTool();
        }

        [Ignore] [Test]
        public void ShouldMergeDescriptionsLikeAChamp()
        {
            {
                PermitRequestEdmonton request1 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
                request1.Description = "Description 1";
                request1.SapDescription = "SAP Description 1";

                PermitRequestEdmonton request2 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
                request2.Description = "Description 2";
                request2.SapDescription = "SAP Description 2";

                string expectedDescription = string.Format("-> Description 1{0}-> Description 2", Environment.NewLine);
                string expectedSapDescription = string.Format("-> SAP Description 1{0}-> SAP Description 2", Environment.NewLine);

                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> {request1, request2});
                Assert.AreEqual(expectedDescription, mergedRequest.Description);
                Assert.AreEqual(expectedSapDescription, mergedRequest.SapDescription);
            }
        }

        [Ignore] [Test]
        public void ShouldTruncateEachDescriptionTo300Characters()
        {
            PermitRequestEdmonton request1 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request1.Description = CreateLongString(301, 'a');
            request1.SapDescription = CreateLongString(301, 'b');

            PermitRequestEdmonton request2 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request2.Description = CreateLongString(422, 'c');
            request2.SapDescription = CreateLongString(355, 'd');

            string expectedDescription = string.Format("-> {0}{1}{2}-> {3}{4}", CreateLongString(297, 'a'), "...", Environment.NewLine, CreateLongString(297, 'c'), "...");
            string expectedSapDescription = string.Format("-> {0}{1}{2}-> {3}{4}", CreateLongString(297, 'b'), "...", Environment.NewLine, CreateLongString(297, 'd'), "...");

            PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request1, request2 });
            Assert.AreEqual(expectedDescription, mergedRequest.Description);
            Assert.AreEqual(expectedSapDescription, mergedRequest.SapDescription);
        }

        [Ignore] [Test]
        public void ShouldSetSpecialWorkTypeIfAllValuesAreTheSame()
        {
            PermitRequestEdmonton request1 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request1.SpecialWork = true;
            request1.SpecialWorkType = EdmontonPermitSpecialWorkType.DivingOperations;

            PermitRequestEdmonton request2 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request2.SpecialWork = true;
            request2.SpecialWorkType = EdmontonPermitSpecialWorkType.DivingOperations;

            PermitRequestEdmonton request3 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request3.SpecialWork = true;
            request3.SpecialWorkType = EdmontonPermitSpecialWorkType.Excavation;

            PermitRequestEdmonton request4 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request4.SpecialWork = false;
            request4.SpecialWorkType = null;

            PermitRequestEdmonton request5 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request5.SpecialWork = false;
            request5.SpecialWorkType = null;

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request1, request2, request4 });
                Assert.AreEqual(true, mergedRequest.SpecialWork);
                Assert.AreEqual(EdmontonPermitSpecialWorkType.DivingOperations, mergedRequest.SpecialWorkType);
            }

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request1, request2, request3 });
                Assert.AreEqual(true, mergedRequest.SpecialWork);
                Assert.AreEqual(null, mergedRequest.SpecialWorkType);
            }

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request3, request4 });
                Assert.AreEqual(true, mergedRequest.SpecialWork);
                Assert.AreEqual(EdmontonPermitSpecialWorkType.Excavation, mergedRequest.SpecialWorkType);
            }

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request4, request5 });
                Assert.AreEqual(false, mergedRequest.SpecialWork);
                Assert.AreEqual(null, mergedRequest.SpecialWorkType);
            }
        }

        [Ignore] [Test]
        public void ShouldChooseWorkPermitTypeBasedOnAMadeUpConceptCalledPriority()
        {
            PermitRequestEdmonton request1 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request1.WorkPermitType = WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK;

            PermitRequestEdmonton request2 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request2.WorkPermitType = WorkPermitEdmontonType.HOT_WORK;

            PermitRequestEdmonton request3 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request3.WorkPermitType = WorkPermitEdmontonType.COLD_WORK;

            PermitRequestEdmonton request4 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request4.WorkPermitType = WorkPermitEdmontonType.ROUTINE_MAINTENANCE;

            PermitRequestEdmonton request5 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request5.WorkPermitType = WorkPermitEdmontonType.ROUTINE_MAINTENANCE;

            // high energy work trumps all
            {
                PermitRequestEdmonton permitRequestEdmonton = tool.Merge(new List<PermitRequestEdmonton> { request1, request2, request3, request4, request5 });
                Assert.AreEqual(WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK, permitRequestEdmonton.WorkPermitType);
            }

            // next is hot work
            {
                PermitRequestEdmonton permitRequestEdmonton = tool.Merge(new List<PermitRequestEdmonton> { request2, request3, request4, request5 });
                Assert.AreEqual(WorkPermitEdmontonType.HOT_WORK, permitRequestEdmonton.WorkPermitType);
            }

            // next is cold work
            {
                PermitRequestEdmonton permitRequestEdmonton = tool.Merge(new List<PermitRequestEdmonton> { request3, request4, request5 });
                Assert.AreEqual(WorkPermitEdmontonType.COLD_WORK, permitRequestEdmonton.WorkPermitType);
            }

            // and finally routine maintenance
            {
                PermitRequestEdmonton permitRequestEdmonton = tool.Merge(new List<PermitRequestEdmonton> { request4, request5 });
                Assert.AreEqual(WorkPermitEdmontonType.ROUTINE_MAINTENANCE, permitRequestEdmonton.WorkPermitType);
            }
        }

        [Ignore] [Test]
        public void ShouldSetFormToRequiredIfAnyRequestHasItSetToRequired()
        {
            PermitRequestEdmonton request1 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request1.GN11 = WorkPermitSafetyFormState.Required;
            request1.GN27 = WorkPermitSafetyFormState.Required;            

            PermitRequestEdmonton request2 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request2.GN11 = WorkPermitSafetyFormState.NotApplicable;
            request2.GN27 = WorkPermitSafetyFormState.NotApplicable;            

            PermitRequestEdmonton request3 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request3.GN11 = WorkPermitSafetyFormState.NotApplicable;
            request3.GN27 = WorkPermitSafetyFormState.Required;            

            PermitRequestEdmonton request4 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request4.GN11 = WorkPermitSafetyFormState.Required;
            request4.GN27 = WorkPermitSafetyFormState.NotApplicable;            

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request1, request2, request3 });
                Assert.AreEqual(WorkPermitSafetyFormState.Required, mergedRequest.GN11);
                Assert.AreEqual(WorkPermitSafetyFormState.Required, mergedRequest.GN27);
            }

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request2, request3 });
                Assert.AreEqual(WorkPermitSafetyFormState.NotApplicable, mergedRequest.GN11);
                Assert.AreEqual(WorkPermitSafetyFormState.Required, mergedRequest.GN27);
            }

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request2, request4 });
                Assert.AreEqual(WorkPermitSafetyFormState.Required, mergedRequest.GN11);
                Assert.AreEqual(WorkPermitSafetyFormState.NotApplicable, mergedRequest.GN27);
            }
        }

        [Ignore] [Test]
        public void ShouldCheckOffABooleanFormIfAnyRequestHasItCheckedOff()
        {
            PermitRequestEdmonton request1 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request1.GN59 = true;
            request1.GN7 = true;
            request1.GN24 = true;
            request1.GN6 = true;

            PermitRequestEdmonton request2 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request2.GN59 = false;
            request2.GN7 = false;
            request2.GN24 = false;
            request2.GN6 = false;

            PermitRequestEdmonton request3 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request3.GN59 = true;
            request3.GN7 = false;
            request3.GN24 = true;
            request3.GN6 = true;

            PermitRequestEdmonton request4 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request4.GN59 = false;
            request4.GN7 = true;
            request4.GN24 = false;
            request4.GN6 = false;

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request1, request2, request3 });
                Assert.AreEqual(true, mergedRequest.GN59);
                Assert.AreEqual(true, mergedRequest.GN7);
                Assert.AreEqual(true, mergedRequest.GN24);
                Assert.AreEqual(true, mergedRequest.GN6);
            }

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request2, request3 });
                Assert.AreEqual(true, mergedRequest.GN59);
                Assert.AreEqual(false, mergedRequest.GN7);
                Assert.AreEqual(true, mergedRequest.GN24);
                Assert.AreEqual(true, mergedRequest.GN6);
            }

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request2, request4 });
                Assert.AreEqual(false, mergedRequest.GN59);
                Assert.AreEqual(true, mergedRequest.GN7);
                Assert.AreEqual(false, mergedRequest.GN24);
                Assert.AreEqual(false, mergedRequest.GN6);
            }
        }

        [Ignore] [Test]
        public void ShouldCheckOffATypeOfWorkCheckboxIfAnyRequestHasItCheckedOff()
        {
            PermitRequestEdmonton request1 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request1.AlkylationEntry = true;
            request1.FlarePitEntry = true;
            request1.ConfinedSpace = true;
            request1.RescuePlan = true;
            request1.VehicleEntry = true;
            request1.SpecialWork = true;

            PermitRequestEdmonton request2 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request2.AlkylationEntry = true;
            request2.FlarePitEntry = true;
            request2.ConfinedSpace = true;
            request2.RescuePlan = false;
            request2.VehicleEntry = false;
            request2.SpecialWork = false;

            PermitRequestEdmonton request3 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request3.AlkylationEntry = false;
            request3.FlarePitEntry = false;
            request3.ConfinedSpace = false;
            request3.RescuePlan = false;
            request3.VehicleEntry = false;
            request3.SpecialWork = false;

            PermitRequestEdmonton request4 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request4.AlkylationEntry = false;
            request4.FlarePitEntry = false;
            request4.ConfinedSpace = false;
            request4.RescuePlan = true;
            request4.VehicleEntry = true;
            request4.SpecialWork = true;

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request1, request2, request3 });
                Assert.AreEqual(true, mergedRequest.AlkylationEntry);
                Assert.AreEqual(true, mergedRequest.FlarePitEntry);
                Assert.AreEqual(true, mergedRequest.ConfinedSpace);
                Assert.AreEqual(true, mergedRequest.RescuePlan);
                Assert.AreEqual(true, mergedRequest.VehicleEntry);
                Assert.AreEqual(true, mergedRequest.SpecialWork);
            }

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request2, request3 });
                Assert.AreEqual(true, mergedRequest.AlkylationEntry);
                Assert.AreEqual(true, mergedRequest.FlarePitEntry);
                Assert.AreEqual(true, mergedRequest.ConfinedSpace);
                Assert.AreEqual(false, mergedRequest.RescuePlan);
                Assert.AreEqual(false, mergedRequest.VehicleEntry);
                Assert.AreEqual(false, mergedRequest.SpecialWork);
            }

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request3, request4 });
                Assert.AreEqual(false, mergedRequest.AlkylationEntry);
                Assert.AreEqual(false, mergedRequest.FlarePitEntry);
                Assert.AreEqual(false, mergedRequest.ConfinedSpace);
                Assert.AreEqual(true, mergedRequest.RescuePlan);
                Assert.AreEqual(true, mergedRequest.VehicleEntry);
                Assert.AreEqual(true, mergedRequest.SpecialWork);
            }
        }

        [Ignore] [Test]
        public void ShouldSetWorkersMinimumSafetyRequirementsSectionNotApplicableToJobBasedOnHowItsAttributesAreSet()
        {
            PermitRequestEdmonton request1 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request1.AirHorn = false;
            request1.AirMover = false;
            request1.AirPurifyingRespirator = false;
            request1.AsbestosMMCPrecautions = false;
            request1.BarriersSigns = false;
            request1.BreathingAirApparatus = false;
            request1.BumpTestMonitorPriorToUse = false;
            request1.ContinuousGasMonitor = false;
            request1.DustMask = false;
            request1.EquipmentGrounded = false;
            request1.FaceShield = false;
            request1.FireBlanket = false;
            request1.FireExtinguisher = false;
            request1.FireMonitorManned = false;
            request1.FireWatch = false;
            request1.Goggles = false;
            request1.HighVoltagePPE = false;
            request1.LifeSupportSystem = false;
            request1.MechVentilationComfortOnly = false;
            request1.RadioChannel = false;
            request1.RubberBoots = false;
            request1.RubberGloves = false;
            request1.RubberSuit = false;
            request1.SafetyHarnessLifeline = false;
            request1.SafetyWatch = false;
            request1.SewersDrainsCovered = false;
            request1.SteamHose = false;
            request1.WorkersMonitor = false;
            request1.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = false;

            PermitRequestEdmonton request2 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request2.AirHorn = false;
            request2.AirMover = false;
            request2.AirPurifyingRespirator = false;
            request2.AsbestosMMCPrecautions = false;
            request2.BarriersSigns = false;
            request2.BreathingAirApparatus = false;
            request2.BumpTestMonitorPriorToUse = false;
            request2.ContinuousGasMonitor = false;
            request2.DustMask = false;
            request2.EquipmentGrounded = false;
            request2.FaceShield = false;
            request2.FireBlanket = false;
            request2.FireExtinguisher = false;
            request2.FireMonitorManned = false;
            request2.FireWatch = false;
            request2.Goggles = false;
            request2.HighVoltagePPE = false;
            request2.LifeSupportSystem = false;
            request2.MechVentilationComfortOnly = false;
            request2.RadioChannel = false;
            request2.RubberBoots = false;
            request2.RubberGloves = false;
            request2.RubberSuit = false;
            request2.SafetyHarnessLifeline = false;
            request2.SafetyWatch = false;
            request2.SewersDrainsCovered = false;
            request2.SteamHose = false;
            request2.WorkersMonitor = false;
            request2.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = false;

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request1, request2 });
                Assert.IsTrue(mergedRequest.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
            }

            {
                request2.AirHorn = true;
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request1, request2 });
                Assert.IsFalse(mergedRequest.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
            }
        }

        [Ignore] [Test]
        public void ShouldSetMinimumSafetyRequirementValueToTrueIfAnyRequestHasThatValueSetToTrue()
        {
            PermitRequestEdmonton request1 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request1.AirHorn = true;
            request1.AirMover = true;
            request1.AirPurifyingRespirator = true;
            request1.AsbestosMMCPrecautions = true;
            request1.BarriersSigns = true;
            request1.BreathingAirApparatus = true;
            request1.BumpTestMonitorPriorToUse = true;
            request1.ContinuousGasMonitor = true;
            request1.DustMask = true;
            request1.EquipmentGrounded = true;
            request1.FaceShield = true;
            request1.FireBlanket = true;
            request1.FireExtinguisher = true;
            request1.FireMonitorManned = true;
            request1.FireWatch = true;
            request1.Goggles = true;
            request1.HighVoltagePPE = true;
            request1.LifeSupportSystem = true;
            request1.MechVentilationComfortOnly = true;
            request1.RadioChannel = true;
            request1.RubberBoots = true;
            request1.RubberGloves = true;
            request1.RubberSuit = true;
            request1.SafetyHarnessLifeline = true;
            request1.SafetyWatch = true;
            request1.SewersDrainsCovered = true;
            request1.SteamHose = true;
            request1.WorkersMonitor = true;

            PermitRequestEdmonton request2 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request2.AirHorn = false;
            request2.AirMover = false;
            request2.AirPurifyingRespirator = false;
            request2.AsbestosMMCPrecautions = false;
            request2.BarriersSigns = false;
            request2.BreathingAirApparatus = false;
            request2.BumpTestMonitorPriorToUse = false;
            request2.ContinuousGasMonitor = false;
            request2.DustMask = false;
            request2.EquipmentGrounded = false;
            request2.FaceShield = false;
            request2.FireBlanket = false;
            request2.FireExtinguisher = false;
            request2.FireMonitorManned = false;
            request2.FireWatch = false;
            request2.Goggles = false;
            request2.HighVoltagePPE = false;
            request2.LifeSupportSystem = false;
            request2.MechVentilationComfortOnly = false;
            request2.RadioChannel = false;
            request2.RubberBoots = false;
            request2.RubberGloves = false;
            request2.RubberSuit = false;
            request2.SafetyHarnessLifeline = false;
            request2.SafetyWatch = false;
            request2.SewersDrainsCovered = false;
            request2.SteamHose = false;
            request2.WorkersMonitor = false;

            PermitRequestEdmonton request3 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request3.AirHorn = false;
            request3.AirMover = false;
            request3.AirPurifyingRespirator = false;
            request3.AsbestosMMCPrecautions = false;
            request3.BarriersSigns = false;
            request3.BreathingAirApparatus = false;
            request3.BumpTestMonitorPriorToUse = false;
            request3.ContinuousGasMonitor = false;
            request3.DustMask = false;
            request3.EquipmentGrounded = false;
            request3.FaceShield = false;
            request3.FireBlanket = false;
            request3.FireExtinguisher = false;
            request3.FireMonitorManned = true;
            request3.FireWatch = true;
            request3.Goggles = true;
            request3.HighVoltagePPE = true;
            request3.LifeSupportSystem = true;
            request3.MechVentilationComfortOnly = true;
            request3.RadioChannel = true;
            request3.RubberBoots = true;
            request3.RubberGloves = true;
            request3.RubberSuit = true;
            request3.SafetyHarnessLifeline = true;
            request3.SafetyWatch = true;
            request3.SewersDrainsCovered = true;
            request3.SteamHose = true;
            request3.WorkersMonitor = true;

            PermitRequestEdmonton request4 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request4.AirHorn = true;
            request4.AirMover = true;
            request4.AirPurifyingRespirator = true;
            request4.AsbestosMMCPrecautions = true;
            request4.BarriersSigns = true;
            request4.BreathingAirApparatus = true;
            request4.BumpTestMonitorPriorToUse = true;
            request4.ContinuousGasMonitor = true;
            request4.DustMask = true;
            request4.EquipmentGrounded = true;
            request4.FaceShield = true;
            request4.FireBlanket = true;
            request4.FireExtinguisher = true;
            request4.FireMonitorManned = false;
            request4.FireWatch = false;
            request4.Goggles = false;
            request4.HighVoltagePPE = false;
            request4.LifeSupportSystem = false;
            request4.MechVentilationComfortOnly = false;
            request4.RadioChannel = false;
            request4.RubberBoots = false;
            request4.RubberGloves = false;
            request4.RubberSuit = false;
            request4.SafetyHarnessLifeline = false;
            request4.SafetyWatch = false;
            request4.SewersDrainsCovered = false;
            request4.SteamHose = false;
            request4.WorkersMonitor = false;

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request1, request2, request3 });
                Assert.AreEqual(true, mergedRequest.AirHorn);
                Assert.AreEqual(true, mergedRequest.AirMover);
                Assert.AreEqual(true, mergedRequest.AirPurifyingRespirator);
                Assert.AreEqual(true, mergedRequest.AsbestosMMCPrecautions);
                Assert.AreEqual(true, mergedRequest.BarriersSigns);
                Assert.AreEqual(true, mergedRequest.BreathingAirApparatus);
                Assert.AreEqual(true, mergedRequest.BumpTestMonitorPriorToUse);
                Assert.AreEqual(true, mergedRequest.ContinuousGasMonitor);
                Assert.AreEqual(true, mergedRequest.DustMask);
                Assert.AreEqual(true, mergedRequest.EquipmentGrounded);
                Assert.AreEqual(true, mergedRequest.FaceShield);
                Assert.AreEqual(true, mergedRequest.FireBlanket);
                Assert.AreEqual(true, mergedRequest.FireExtinguisher);
                Assert.AreEqual(true, mergedRequest.FireMonitorManned);
                Assert.AreEqual(true, mergedRequest.FireWatch);
                Assert.AreEqual(true, mergedRequest.Goggles);
                Assert.AreEqual(true, mergedRequest.HighVoltagePPE);
                Assert.AreEqual(true, mergedRequest.LifeSupportSystem);
                Assert.AreEqual(true, mergedRequest.MechVentilationComfortOnly);
                Assert.AreEqual(true, mergedRequest.RadioChannel);
                Assert.AreEqual(true, mergedRequest.RubberBoots);
                Assert.AreEqual(true, mergedRequest.RubberGloves);
                Assert.AreEqual(true, mergedRequest.RubberSuit);
                Assert.AreEqual(true, mergedRequest.SafetyHarnessLifeline);
                Assert.AreEqual(true, mergedRequest.SafetyWatch);
                Assert.AreEqual(true, mergedRequest.SewersDrainsCovered);
                Assert.AreEqual(true, mergedRequest.SteamHose);
                Assert.AreEqual(true, mergedRequest.WorkersMonitor);
            }

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request2, request3 });
                Assert.AreEqual(false, mergedRequest.AirHorn);
                Assert.AreEqual(false, mergedRequest.AirMover);
                Assert.AreEqual(false, mergedRequest.AirPurifyingRespirator);
                Assert.AreEqual(false, mergedRequest.AsbestosMMCPrecautions);
                Assert.AreEqual(false, mergedRequest.BarriersSigns);
                Assert.AreEqual(false, mergedRequest.BreathingAirApparatus);
                Assert.AreEqual(false, mergedRequest.BumpTestMonitorPriorToUse);
                Assert.AreEqual(false, mergedRequest.ContinuousGasMonitor);
                Assert.AreEqual(false, mergedRequest.DustMask);
                Assert.AreEqual(false, mergedRequest.EquipmentGrounded);
                Assert.AreEqual(false, mergedRequest.FaceShield);
                Assert.AreEqual(false, mergedRequest.FireBlanket);
                Assert.AreEqual(false, mergedRequest.FireExtinguisher);
                Assert.AreEqual(true, mergedRequest.FireMonitorManned);
                Assert.AreEqual(true, mergedRequest.FireWatch);
                Assert.AreEqual(true, mergedRequest.Goggles);
                Assert.AreEqual(true, mergedRequest.HighVoltagePPE);
                Assert.AreEqual(true, mergedRequest.LifeSupportSystem);
                Assert.AreEqual(true, mergedRequest.MechVentilationComfortOnly);
                Assert.AreEqual(true, mergedRequest.RadioChannel);
                Assert.AreEqual(true, mergedRequest.RubberBoots);
                Assert.AreEqual(true, mergedRequest.RubberGloves);
                Assert.AreEqual(true, mergedRequest.RubberSuit);
                Assert.AreEqual(true, mergedRequest.SafetyHarnessLifeline);
                Assert.AreEqual(true, mergedRequest.SafetyWatch);
                Assert.AreEqual(true, mergedRequest.SewersDrainsCovered);
                Assert.AreEqual(true, mergedRequest.SteamHose);
                Assert.AreEqual(true, mergedRequest.WorkersMonitor);
            }

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request2, request4 });
                Assert.AreEqual(true, mergedRequest.AirHorn);
                Assert.AreEqual(true, mergedRequest.AirMover);
                Assert.AreEqual(true, mergedRequest.AirPurifyingRespirator);
                Assert.AreEqual(true, mergedRequest.AsbestosMMCPrecautions);
                Assert.AreEqual(true, mergedRequest.BarriersSigns);
                Assert.AreEqual(true, mergedRequest.BreathingAirApparatus);
                Assert.AreEqual(true, mergedRequest.BumpTestMonitorPriorToUse);
                Assert.AreEqual(true, mergedRequest.ContinuousGasMonitor);
                Assert.AreEqual(true, mergedRequest.DustMask);
                Assert.AreEqual(true, mergedRequest.EquipmentGrounded);
                Assert.AreEqual(true, mergedRequest.FaceShield);
                Assert.AreEqual(true, mergedRequest.FireBlanket);
                Assert.AreEqual(true, mergedRequest.FireExtinguisher);
                Assert.AreEqual(false, mergedRequest.FireMonitorManned);
                Assert.AreEqual(false, mergedRequest.FireWatch);
                Assert.AreEqual(false, mergedRequest.Goggles);
                Assert.AreEqual(false, mergedRequest.HighVoltagePPE);
                Assert.AreEqual(false, mergedRequest.LifeSupportSystem);
                Assert.AreEqual(false, mergedRequest.MechVentilationComfortOnly);
                Assert.AreEqual(false, mergedRequest.RadioChannel);
                Assert.AreEqual(false, mergedRequest.RubberBoots);
                Assert.AreEqual(false, mergedRequest.RubberGloves);
                Assert.AreEqual(false, mergedRequest.RubberSuit);
                Assert.AreEqual(false, mergedRequest.SafetyHarnessLifeline);
                Assert.AreEqual(false, mergedRequest.SafetyWatch);
                Assert.AreEqual(false, mergedRequest.SewersDrainsCovered);
                Assert.AreEqual(false, mergedRequest.SteamHose);
                Assert.AreEqual(false, mergedRequest.WorkersMonitor);
            }
        }

        [Ignore] [Test]
        public void ShouldChooseEarliestStartDatesAndTimesFromPermitsAndLatestEndDate()
        {
            PermitRequestEdmonton request1 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request1.RequestedStartDate = new Date(2012, 10, 22);
            request1.RequestedStartTimeDay = new Time(8, 30);
            request1.RequestedStartTimeNight = new Time(19, 15);
            request1.EndDate = new Date(2012, 11, 30);

            PermitRequestEdmonton request2 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request2.RequestedStartDate = new Date(2012, 9, 18);
            request2.RequestedStartTimeDay = new Time(9, 30);
            request2.RequestedStartTimeNight = new Time(22, 15);
            request2.EndDate = new Date(2012, 11, 30);

            PermitRequestEdmonton request3 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request3.RequestedStartDate = null;
            request3.RequestedStartTimeDay = null;
            request3.RequestedStartTimeNight = new Time(22, 15);
            request3.EndDate = new Date(2012, 12, 2);

            PermitRequestEdmonton request4 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request4.RequestedStartDate = new Date(2012, 10, 22);
            request4.RequestedStartTimeDay = new Time(9, 30);
            request4.RequestedStartTimeNight = null;
            request4.EndDate = null;

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request1, request2, request3, request4 });
                Assert.AreEqual(new Date(2012, 9, 18), mergedRequest.RequestedStartDate);
                Assert.AreEqual(new Time(7, 0), mergedRequest.RequestedStartTimeDay); // This is a weird case because the requested start time day is hard-coded to be this.                
                Assert.AreEqual(new Date(2012, 12, 2), mergedRequest.EndDate);
            }
        }

        [Ignore] [Test]
        public void ShouldMergeWorkOrderSources()
        {
            PermitRequestEdmonton request1 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request1.ClearWorkOrderSources();
            request1.AddWorkOrderSource("555", "0001", "0001");

            PermitRequestEdmonton request2 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request2.ClearWorkOrderSources();
            request2.AddWorkOrderSource("555", "0001", "0002");

            PermitRequestEdmonton request3 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request3.ClearWorkOrderSources();
            request3.AddWorkOrderSource("555", "0001", "0002");

            PermitRequestEdmonton request4 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request4.ClearWorkOrderSources();
            request4.AddWorkOrderSource("555", "0002", "0001");
            request4.AddWorkOrderSource("555", "0002", "0002");

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request1, request2, request3, request4 });
                Assert.AreEqual(4, mergedRequest.WorkOrderSourceList.Count);
                Assert.IsTrue(mergedRequest.WorkOrderSourceList.Exists(wos => wos.Matches("555", "0001", "0001")));
                Assert.IsTrue(mergedRequest.WorkOrderSourceList.Exists(wos => wos.Matches("555", "0001", "0002")));
                Assert.IsTrue(mergedRequest.WorkOrderSourceList.Exists(wos => wos.Matches("555", "0002", "0001")));
                Assert.IsTrue(mergedRequest.WorkOrderSourceList.Exists(wos => wos.Matches("555", "0002", "0002")));
            }
        }

        [Ignore] [Test]
        public void ShouldSetPriorityToCriticalIfAtLeastOnePermitBeingMergedIsCritical()
        {
            PermitRequestEdmonton request1 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request1.Priority = Priority.Normal;

            PermitRequestEdmonton request2 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request2.Priority = Priority.Normal;

            PermitRequestEdmonton request3 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request3.Priority = Priority.CriticalPath;

            PermitRequestEdmonton request4 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request4.Priority = Priority.CriticalPath;

            PermitRequestEdmonton request5 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request5.Priority = Priority.Normal;

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> {request1, request2, request5});
                Assert.That(mergedRequest.Priority, Is.EqualTo(Priority.Normal));
            }

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request1, request2, request3, request5 });
                Assert.That(mergedRequest.Priority, Is.EqualTo(Priority.CriticalPath));
            }

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request1, request2, request4, request5 });
                Assert.That(mergedRequest.Priority, Is.EqualTo(Priority.CriticalPath));
            }

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request1, request2, request3, request4, request5 });
                Assert.That(mergedRequest.Priority, Is.EqualTo(Priority.CriticalPath));
            }

        }

        [Ignore] [Test]
        public void ShouldSetTheConfinedSpaceClassToTheHighestPriorityLevel()
        {
            PermitRequestEdmonton request1 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request1.ConfinedSpaceClass = "1";

            PermitRequestEdmonton request2 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request2.ConfinedSpaceClass = "2";

            PermitRequestEdmonton request3 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request3.ConfinedSpaceClass = "3";

            PermitRequestEdmonton requestNull = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            requestNull.ConfinedSpaceClass = null;

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request1, request2, request3, requestNull });
                Assert.AreEqual(WorkPermitEdmonton.ConfinedSpaceLevel1, mergedRequest.ConfinedSpaceClass);
            }

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { requestNull, requestNull, requestNull, requestNull });
                Assert.IsNull(mergedRequest.ConfinedSpaceClass);
            }

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request2, request3 });
                Assert.AreEqual(WorkPermitEdmonton.ConfinedSpaceLevel2, mergedRequest.ConfinedSpaceClass);
            }

            {
                PermitRequestEdmonton mergedRequest = tool.Merge(new List<PermitRequestEdmonton> { request1, request3 });
                Assert.AreEqual(WorkPermitEdmonton.ConfinedSpaceLevel1, mergedRequest.ConfinedSpaceClass);
            }
        }

        private string CreateLongString(int numberOfCharacters, char character)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < numberOfCharacters; i++ )
            {
                stringBuilder.Append(character);
            }

            return stringBuilder.ToString();
        }



    }
}
