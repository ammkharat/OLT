using System.Text;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class WorkPermitUSPipelineReportAdapter : IReportAdapter
    {
        public WorkPermitUSPipelineReportAdapter(WorkPermit workPermit, bool specialPrecautionsOrConsiderationsTooLong)
        {
            SpecialPrecautionsOrConsiderationsTooLong = specialPrecautionsOrConsiderationsTooLong;

            PermitNumber = workPermit.PermitNumber;

            IsColdType = workPermit.WorkPermitType.IsSame(WorkPermitType.COLD);
            IsHotType = workPermit.WorkPermitType.IsSame(WorkPermitType.HOT);

            if (workPermit.WorkPermitTypeClassification != null)
            {
                IsSpecificPermit = workPermit.WorkPermitTypeClassification.IsSame(WorkPermitTypeClassification.SPECIFIC);
                IsGeneralPermit = workPermit.WorkPermitTypeClassification.IsSame(WorkPermitTypeClassification.GENERAL);
            }

            var createdByUser = workPermit.CreatedBy;
            CreatedByUser = createdByUser != null ? createdByUser.FullNameWithUserName : string.Empty;
            var approvedByUser = workPermit.ApprovedBy;
            ApprovedByUser = approvedByUser != null ? approvedByUser.FullNameWithUserName : string.Empty;

            SetPermitAttributes(workPermit.Attributes);

            SetLocationAndJobSpecificsAndScope(workPermit.Specifics);
            SetToolsToBeUsed(workPermit.Tools);
            SetEquipmentPreparation(workPermit.EquipmentPreparationCondition);
            SetJobWorksitePreparation(workPermit.JobWorksitePreparation);
            SetRadiationInformation(workPermit.RadiationInformation);
            SetConfinedSpaceRequirements(workPermit.FireConfinedSpaceRequirements);
            SetRespitoryProtectionRequirements(workPermit.RespiratoryProtectionRequirements);
            SetPPERequirements(workPermit.SpecialProtectionRequirements);

            SpecialPrecautionsOrConsiderations = BuildSpecialPrecautions(workPermit).TrimOrEmpty();

            SetAdditionalForms(workPermit.AdditionItemsRequired);

            SetGasTestInfomation(workPermit.GasTests, workPermit.WorkPermitType, workPermit.Attributes);

            CoAuthorizationRequiredYes = workPermit.IsCoauthorizationRequired.HasTrueValue();
            // the old permit would default this to false if it wasn't true even when a user doesn't fill this information out.  This could be a case where we are 
            // reproducing an existing bug.
            CoAuthorizationRequiredNo = !workPermit.IsCoauthorizationRequired.HasTrueValue();

            CoAuthorizationRequiredDescription = workPermit.CoauthorizationDescription.NullToEmpty();
        }

        public bool SpecialPrecautionsOrConsiderationsTooLong { get; private set; }

        public string SpecialPrecautionsOrConsiderationsTooLongWarning
        {
            get
            {
                return
                    "Please refer to the electronic version of the Safe Work Permit for the full Special Precautions as entered by the Permit Issuer.";
            }
        }

        public string PermitNumber { get; private set; }

        public bool IsColdType { get; private set; }
        public bool IsHotType { get; private set; }

        public bool IsSpecificPermit { get; private set; }
        public bool IsGeneralPermit { get; private set; }

        public string CreatedByUser { get; private set; }
        public string ApprovedByUser { get; private set; }

        public string FunctionalLocation { get; private set; }
        public string WorkOrderNumber { get; private set; }
        public string StartDateTime { get; private set; }
        public string EndDateTime { get; private set; }
        public string ContactPerson { get; private set; }
        public string ContactorName { get; private set; }
        public string CraftOrTrade { get; private set; }

        public bool Radio { get; private set; }
        public string RadioChannel { get; private set; }
        public string RadioOther { get; private set; }
        public bool RadioNA { get; private set; }

        public string WorkOrderDescription { get; private set; }
        public string JobStepDescription { get; private set; }

        public string SpecialPrecautionsOrConsiderations { get; private set; }
        public bool CoAuthorizationRequiredYes { get; private set; }
        public bool CoAuthorizationRequiredNo { get; private set; }
        public string CoAuthorizationRequiredDescription { get; private set; }

        public string CopyBasedWatermarkText { get; set; }

        public bool GasTestConstantMonitoringRequired { get; private set; }
        public bool GasTestForkliftNotUsed { get; private set; }
        public string GasTestFrequencyOrDuration { get; private set; }
        public string GasTestWorkAreaTimeOfTest { get; private set; }
        public string GasTestConfinedSpaceTimeOfTest { get; private set; }
        public string GasTestSystemEntryTimeOfTest { get; private set; }

        public string GasTestOxygenLimits { get; private set; }
        public bool GasTestOxygenWorkAreaTestRequired { get; private set; }
        public string GasTestOxygenWorkAreaFirstTestResult { get; private set; }
        public string GasTestOxygenConfinedSpaceFirstTestResult { get; private set; }
        public string GasTestOxygenSystemEntryFirstTestResult { get; private set; }
        public bool GasTestOxygenSystemEntryNotApplicable { get; private set; }

        public string GasTestH2SLimits { get; private set; }
        public bool GasTestH2SWorkAreaTestRequired { get; private set; }
        public string GasTestH2SWorkAreaFirstTestResult { get; private set; }
        public string GasTestH2SConfinedSpaceFirstTestResult { get; private set; }
        public string GasTestH2SSystemEntryFirstTestResult { get; private set; }
        public bool GasTestH2SSystemEntryNotApplicable { get; private set; }

        public string GasTestLELLimits { get; private set; }
        public bool GasTestLELWorkAreaTestRequired { get; private set; }
        public string GasTestLELWorkAreaFirstTestResult { get; private set; }
        public string GasTestLELConfinedSpaceFirstTestResult { get; private set; }
        public string GasTestLELSystemEntryFirstTestResult { get; private set; }
        public bool GasTestLELSystemEntryNotApplicable { get; private set; }

        public string GasTestSO2Limits { get; private set; }
        public bool GasTestSO2WorkAreaTestRequired { get; private set; }
        public string GasTestSO2WorkAreaFirstTestResult { get; private set; }
        public string GasTestSO2ConfinedSpaceFirstTestResult { get; private set; }
        public string GasTestSO2SystemEntryFirstTestResult { get; private set; }
        public bool GasTestSO2SystemEntryNotApplicable { get; private set; }

        public string GasTestCOLimits { get; private set; }
        public bool GasTestCOWorkAreaTestRequired { get; private set; }
        public string GasTestCOWorkAreaFirstTestResult { get; private set; }
        public string GasTestCOConfinedSpaceFirstTestResult { get; private set; }
        public string GasTestCOSystemEntryFirstTestResult { get; private set; }
        public bool GasTestCOSystemEntryNotApplicable { get; private set; }

        public string GasTestPIDLimits { get; private set; }
        public bool GasTestPIDWorkAreaTestRequired { get; private set; }
        public string GasTestPIDWorkAreaFirstTestResult { get; private set; }
        public string GasTestPIDConfinedSpaceFirstTestResult { get; private set; }
        public string GasTestPIDSystemEntryFirstTestResult { get; private set; }
        public bool GasTestPIDSystemEntryNotApplicable { get; private set; }

        public string GasTestCustomName { get; private set; }
        public string GasTestCustomLimits { get; private set; }
        public bool GasTestCustomWorkAreaTestRequired { get; private set; }
        public string GasTestCustomWorkAreaFirstTestResult { get; private set; }
        public string GasTestCustomConfinedSpaceFirstTestResult { get; private set; }
        public string GasTestCustomSystemEntryFirstTestResult { get; private set; }
        public bool GasTestCustomSystemEntryNotApplicable { get; private set; }

        public bool AddtionalFormFlareEntry { get; private set; }
        public bool AddtionalFormCriticalLift { get; private set; }
        public bool AddtionalFormBlankBlindList { get; private set; }
        public bool AddtionalFormPJSR { get; private set; }
        public bool AddtionalFormExcavation { get; private set; }
        public bool AddtionalFormMSDS { get; private set; }
        public bool AddtionalFormDeviation { get; private set; }
        public bool AddtionalFormHotTap { get; private set; }
        public bool AddtionalFormRoadClosure { get; private set; }
        public bool AddtionalFormRadiationApproval { get; private set; }
        public bool AddtionalFormOnlineLeakRepairForm { get; private set; }
        public bool AdditionalFormEnergizedElectricalForm { get; private set; }
        public bool AdditionalFormNotApplicable { get; private set; }

        public bool PpeEyeGoggles { get; private set; }
        public bool PpeEyeFaceShield { get; private set; }
        public bool PpeEyeOther { get; private set; }
        public string PpeEyeOtherDescription { get; private set; }
        public bool PpeEyeNA { get; private set; }

        public bool PpeClothingTyvekSuit { get; private set; }
        public bool PpeClothingElectricalFlashGear { get; private set; }
        public bool PpeClothingKapplerSuit { get; private set; }
        public bool PpeClothingCorrosiveClothing { get; private set; }
        public bool PpeClothingOther { get; private set; }
        public string PpeClothingOtherDescription { get; private set; }
        public bool PpeClothingNA { get; private set; }

        public bool PpeProtectiveFootwearToeGuard { get; private set; }
        public bool PpeProtectiveFootwearChemicalImperviousBoots { get; private set; }
        public bool PpeProtectiveFootwearOther { get; private set; }
        public string PpeProtectiveFootwearOtherDescription { get; private set; }
        public bool PpeProtectiveFootwearNA { get; private set; }

        public bool PpeHandProtectionChemicalGloves { get; private set; }
        public bool PpeHandProtectionHighVoltage { get; private set; }
        public bool PpeHandProtectionNitrile { get; private set; }
        public bool PpeHandProtectionWelding { get; private set; }
        public bool PpeHandProtectionOther { get; private set; }
        public string PpeHandProtectionOtherDescription { get; private set; }
        public bool PpeHandProtectionNA { get; private set; }

        public bool PpeRescueBodyHarness { get; private set; }
        public bool PpeRescueLifeline { get; private set; }
        public bool PpRescueYoYo { get; private set; }
        public bool PpeRescueDevice { get; private set; }
        public bool PpeRescueOther { get; private set; }
        public string PpeRescueOtherDescription { get; private set; }
        public bool PpeRescueNA { get; private set; }

        public bool PpeFallTieoffRequiredYes { get; private set; }
        public bool PpeFallTieoffRequiredNo { get; private set; }
        public bool PpeFallRestraint { get; private set; }
        public bool PpeFallSelfRetractingDevice { get; private set; }
        public bool PpeFallOther { get; private set; }
        public string PpeFallOtherDescription { get; private set; }

        public bool RpRAirCart { get; private set; }
        public bool RpRAirHood { get; private set; }
        public bool RpRSCBA { get; private set; }
        public bool RpRHalfFaceRespirator { get; private set; }
        public bool RpRFullFaceRespirator { get; private set; }
        public bool RpROther { get; private set; }
        public string RpROtherDescription { get; private set; }
        public bool RpRNA { get; private set; }
        public bool RpRCartrideTypeOVAGHEPA { get; private set; }
        public bool RpRCartrideTypeOVAG { get; private set; }
        public bool RpRCartrideTypeAmmonia { get; private set; }
        public bool RpRCartrideTypeHEPA { get; private set; }

        public bool CseFireExtinguisher { get; private set; }
        public bool CseFireResistantTarp { get; private set; }
        public bool CseSparkContainment { get; private set; }
        public bool CseWaterHose { get; private set; }
        public bool CseSteamHose { get; private set; }
        public bool CseOther { get; private set; }
        public string CseOtherDescription { get; private set; }
        public bool CseNA { get; private set; }
        public string CseHoleWatchNumber { get; private set; }
        public string CseFireWatchNumber { get; private set; }
        public string CseBottleWatchNumber { get; private set; }

        public bool RadiationLOTO { get; private set; }
        public bool RadiationNA { get; private set; }

        public bool SewerIsolationSealedCovered { get; private set; }
        public bool SewerIsolationPlugged { get; private set; }
        public bool SewerIsolationBlindBlank { get; private set; }
        public bool SewerIsolationOther { get; private set; }
        public string SewerIsolationOtherDescription { get; private set; }
        public bool SewerIsolationNA { get; private set; }

        public bool JobSiteBarricadeTape { get; private set; }
        public bool JobSiteNonEssentialPersonnelEvacuation { get; private set; }
        public bool JobSiteHardBarricade { get; private set; }
        public bool JobSiteRadiationRope { get; private set; }
        public bool JobSiteRadiationOther { get; private set; }
        public string JobSiteRadiationOtherDescription { get; private set; }
        public bool JobSiteRadiationNA { get; private set; }

        public bool LightingLowVoltage { get; private set; }
        public bool Lighting110V { get; private set; }
        public bool LightingGeneratorLights { get; private set; }
        public bool LightingOther { get; private set; }
        public string LightingOtherDescription { get; private set; }
        public bool LightingNA { get; private set; }

        public bool FlowRequiredForJobsYes { get; private set; }
        public bool FlowRequiredForJobsNo { get; private set; }
        public bool FlowRequiredForJobsNA { get; private set; }

        public bool BondingGroundingRequiredYes { get; private set; }
        public bool BondingGroundingRequiredNo { get; private set; }
        public bool BondingGroundingRequiredNA { get; private set; }

        public bool SurroundingConditionsAffectWorkAreaYes { get; private set; }
        public bool SurroundingConditionsAffectWorkAreaNo { get; private set; }
        public bool SurroundingConditionsAffectWorkAreaNA { get; private set; }

        public bool EquipmentInService { get; private set; }
        public bool EquipmentOutOfService { get; private set; }
        public bool ElectricalBumpTestPerformedYes { get; private set; }
        public bool ElectricalBumpTestPerformedNo { get; private set; }
        public bool ElectricalBumpTestPerformedNA { get; private set; }
        public bool StillContainsResidualYes { get; private set; }
        public bool StillContainsResidualNo { get; private set; }
        public bool StillContainsResidualNA { get; private set; }

        public bool LeakingTestValvesYes { get; private set; }
        public bool LeakingTestValvesNo { get; private set; }
        public bool LeakingTestValvesNA { get; private set; }

        public bool EquipmentConditionDepressured { get; private set; }
        public bool EquipmentConditionVentilated { get; private set; }
        public bool EquipmentConditionDrained { get; private set; }
        public bool EquipmentConditionH20Washed { get; private set; }
        public bool EquipmentConditionCleaned { get; private set; }
        public bool EquipmentConditionNeutralized { get; private set; }
        public bool EquipmentConditionPurged { get; private set; }
        public bool EquipmentConditionNA { get; private set; }
        public string EquipmentConditionPurgeMethod { get; private set; }

        public bool EquipmentPriorContentsHydocarbon { get; private set; }
        public bool EquipmentPriorContentsAcid { get; private set; }
        public bool EquipmentPriorContentsCaustic { get; private set; }
        public bool EquipmentPriorContentsH2S { get; private set; }
        public bool EquipmentPriorContentsNA { get; private set; }
        public bool EquipmentPriorContentsOther { get; private set; }
        public string EquipmentPriorContentsOtherDescription { get; private set; }

        public bool EquipmentIsolationBlindBlank { get; private set; }
        public bool EquipmentIsolationLOTO { get; private set; }
        public bool EquipmentIsolationSeparation { get; private set; }
        public bool EquipmentIsolationExpansionPlugs { get; private set; }
        public bool EquipmentIsolationCarBer { get; private set; }
        public bool EquipmentIsolationNA { get; private set; }
        public bool EquipmentIsolationOther { get; private set; }
        public string EquipmentIsolationOtherDescription { get; private set; }

        public bool ElectricIsolationLOTO { get; private set; }
        public bool ElectricIsolationWiringDisconnected { get; private set; }
        public bool ElectricIsolationNA { get; private set; }

        public bool VentilationNaturalDraft { get; private set; }
        public bool VentilationLocalExhaust { get; private set; }
        public bool VentilationForced { get; private set; }
        public bool VentilationNA { get; private set; }

        public bool ToolsAirtool { get; private set; }
        public bool ToolsCementSaw { get; private set; }
        public bool ToolsCompressor { get; private set; }
        public bool ToolsChemicals { get; private set; }
        public bool ToolsCraneOrCarrydeck { get; private set; }
        public bool ToolsElectricTools { get; private set; }
        public bool ToolsForkLift { get; private set; }
        public bool ToolsHandTools { get; private set; }
        public bool ToolsHeavyEquipment { get; private set; }
        public bool ToolsHEPAVacuum { get; private set; }
        public bool ToolsHotTapMachine { get; private set; }
        public bool ToolsJackhammer { get; private set; }
        public bool ToolsLanda { get; private set; }
        public bool ToolsManlift { get; private set; }
        public bool ToolsPortLighting { get; private set; }
        public bool ToolsScaffolding { get; private set; }
        public bool ToolsTamper { get; private set; }
        public bool ToolsTorch { get; private set; }
        public bool ToolsVacuumTruck { get; private set; }
        public bool ToolsVehicle { get; private set; }
        public bool ToolsWelder { get; private set; }
        public bool ToolsOther { get; private set; }
        public string ToolsOtherDescription { get; private set; }

        public bool AttributeConfinedSpaceEntry { get; private set; }
        public bool AttributeInertConfinedSpaceEntry { get; private set; }
        public bool AttributeBreatingAirSCBA { get; private set; }
        public bool AttributeSystemEntry { get; private set; }
        public bool AttributeCriticalLift { get; private set; }
        public bool AttributeVehicleEntry { get; private set; }
        public bool AttributeElectricalWork { get; private set; }
        public bool AttributeBurnOrOpenFlame { get; private set; }
        public bool AttributeLeadAbatement { get; private set; }
        public bool AttributeExcavation { get; private set; }
        public bool AttributeHotTap { get; private set; }
        public bool AttributeAsbestos { get; private set; }
        public bool AttributeRadiationRadiography { get; private set; }
        public bool AttributeRadiationSealed { get; private set; }

        private string BuildSpecialPrecautions(WorkPermit workPermit)
        {
            if (!WorkPermit.IsOldVersionForUSPipeline(workPermit.Version))
            {
                return workPermit.SpecialPrecautionsOrConsiderations;
            }

            var builder = new StringBuilder();
            var prepConditions = workPermit.EquipmentPreparationCondition;
            if (prepConditions != null)
            {
                if (prepConditions.InServiceComments.HasValue())
                {
                    builder.AppendLine(string.Format("<Equipment in Service - {0}>",
                        prepConditions.InServiceComments.Trim()));
                }
                if (prepConditions.NoElectricalTestBumpComments.HasValue())
                {
                    builder.AppendLine(string.Format("<No Electrical Test Bump - {0}>",
                        prepConditions.NoElectricalTestBumpComments.Trim()));
                }
                if (prepConditions.StillContainsResidualComments.HasValue())
                {
                    builder.AppendLine(string.Format("<Still Contain Residue - {0}>",
                        prepConditions.StillContainsResidualComments.Trim()));
                }
                if (prepConditions.LeakingValvesComments.HasValue())
                {
                    builder.AppendLine(string.Format("<Leaking Valves - {0}>",
                        prepConditions.LeakingValvesComments.Trim()));
                }
            }
            var worksitePrep = workPermit.JobWorksitePreparation;
            if (worksitePrep != null)
            {
                if (worksitePrep.FlowRequiredComments.HasValue())
                {
                    builder.AppendLine(string.Format("<Flow Required for Job - {0}>",
                        worksitePrep.FlowRequiredComments.Trim()));
                }
                if (worksitePrep.BondingGroundingNotRequiredComments.HasValue())
                {
                    builder.AppendLine(string.Format("<Bonding/Grounding Not Required - {0}>",
                        worksitePrep.BondingGroundingNotRequiredComments.Trim()));
                }
                if (worksitePrep.WeldingGroundWireNotWithinGasTestAreaComments.HasValue())
                {
                    builder.AppendLine(string.Format("<Welding Ground Wire Not Within Gas Test Areas - {0}>",
                        worksitePrep.WeldingGroundWireNotWithinGasTestAreaComments.Trim()));
                }
                if (worksitePrep.SurroundingConditionsAffectAreaComments.HasValue())
                {
                    builder.AppendLine(string.Format("<Surrounding Conditions Affect Area - {0}>",
                        worksitePrep.SurroundingConditionsAffectAreaComments.Trim()));
                }
            }
            if (workPermit.SpecialPrecautionsOrConsiderations.HasValue())
            {
                builder.AppendLine(string.Format("<Additional Comments - {0}>",
                    workPermit.SpecialPrecautionsOrConsiderations.Trim()));
            }
            return builder.ToString();
        }

        private void SetGasTestInfomation(WorkPermitGasTests gasTests, WorkPermitType workPermitType,
            WorkPermitAttributes workPermitAttributes)
        {
            if (gasTests == null)
                return;

            GasTestConstantMonitoringRequired = gasTests.ConstantMonitoringRequired;
            GasTestForkliftNotUsed = gasTests.ForkliftNotUsed;
            GasTestFrequencyOrDuration = gasTests.FrequencyOrDuration;

            var gasTestElements = gasTests.Elements;
            foreach (var element in gasTestElements)
            {
                var gasTestElementInfo = element.ElementInfo;

                var limits = gasTestElementInfo.IsStandard
                    ? gasTestElementInfo.GetLimitRange(workPermitType, workPermitAttributes)
                        .ToLimitStringWithUnit(gasTestElementInfo)
                    : gasTestElementInfo.OtherLimits;

                var gasTestName = gasTestElementInfo.Name;

                switch (gasTestName)
                {
                    case "Oxygen":
                        GasTestOxygenLimits = limits;
                        GasTestOxygenWorkAreaTestRequired = element.ImmediateAreaTestRequired;
                        GasTestOxygenWorkAreaFirstTestResult = element.ImmediateAreaTestResult.NullableToString();
                        GasTestOxygenConfinedSpaceFirstTestResult = element.ConfinedSpaceTestResult.NullableToString();
                        GasTestOxygenSystemEntryFirstTestResult = element.SystemEntryTestResult.NullableToString();
                        GasTestOxygenSystemEntryNotApplicable = element.SystemEntryTestNotApplicable;
                        break;
                    case "H2S":
                        GasTestH2SLimits = limits;
                        GasTestH2SWorkAreaTestRequired = element.ImmediateAreaTestRequired;
                        GasTestH2SWorkAreaFirstTestResult = element.ImmediateAreaTestResult.NullableToString();
                        GasTestH2SConfinedSpaceFirstTestResult = element.ConfinedSpaceTestResult.NullableToString();
                        GasTestH2SSystemEntryFirstTestResult = element.SystemEntryTestResult.NullableToString();
                        GasTestH2SSystemEntryNotApplicable = element.SystemEntryTestNotApplicable;
                        break;

                    case "LEL":
                        GasTestLELLimits = limits;
                        GasTestLELWorkAreaTestRequired = element.ImmediateAreaTestRequired;
                        GasTestLELWorkAreaFirstTestResult = element.ImmediateAreaTestResult.NullableToString();
                        GasTestLELConfinedSpaceFirstTestResult = element.ConfinedSpaceTestResult.NullableToString();
                        GasTestLELSystemEntryFirstTestResult = element.SystemEntryTestResult.NullableToString();
                        GasTestLELSystemEntryNotApplicable = element.SystemEntryTestNotApplicable;
                        break;
                    case "SO2":
                        GasTestSO2Limits = limits;
                        GasTestSO2WorkAreaTestRequired = element.ImmediateAreaTestRequired;
                        GasTestSO2WorkAreaFirstTestResult = element.ImmediateAreaTestResult.NullableToString();
                        GasTestSO2ConfinedSpaceFirstTestResult = element.ConfinedSpaceTestResult.NullableToString();
                        GasTestSO2SystemEntryFirstTestResult = element.SystemEntryTestResult.NullableToString();
                        GasTestSO2SystemEntryNotApplicable = element.SystemEntryTestNotApplicable;
                        break;
                    case "CO":
                        GasTestCOLimits = limits;
                        GasTestCOWorkAreaTestRequired = element.ImmediateAreaTestRequired;
                        GasTestCOWorkAreaFirstTestResult = element.ImmediateAreaTestResult.NullableToString();
                        GasTestCOConfinedSpaceFirstTestResult = element.ConfinedSpaceTestResult.NullableToString();
                        GasTestCOSystemEntryFirstTestResult = element.SystemEntryTestResult.NullableToString();
                        GasTestCOSystemEntryNotApplicable = element.SystemEntryTestNotApplicable;
                        break;
                    case "PID":
                        GasTestPIDLimits = limits;
                        GasTestPIDWorkAreaTestRequired = element.ImmediateAreaTestRequired;
                        GasTestPIDWorkAreaFirstTestResult = element.ImmediateAreaTestResult.NullableToString();
                        GasTestPIDConfinedSpaceFirstTestResult = element.ConfinedSpaceTestResult.NullableToString();
                        GasTestPIDSystemEntryFirstTestResult = element.SystemEntryTestResult.NullableToString();
                        GasTestPIDSystemEntryNotApplicable = element.SystemEntryTestNotApplicable;
                        break;
                    default:
                        GasTestCustomName = gasTestName.NullableToString();
                        GasTestCustomLimits = limits;
                        GasTestCustomWorkAreaTestRequired = element.ImmediateAreaTestRequired;
                        GasTestCustomWorkAreaFirstTestResult = element.ImmediateAreaTestResult.NullableToString();
                        GasTestCustomConfinedSpaceFirstTestResult = element.ConfinedSpaceTestResult.NullableToString();
                        GasTestCustomSystemEntryFirstTestResult = element.SystemEntryTestResult.NullableToString();
                        GasTestCustomSystemEntryNotApplicable = element.SystemEntryTestNotApplicable;
                        break;
                }
            }

            GasTestWorkAreaTimeOfTest = gasTests.ImmediateAreaTestTime.NullableToString();
            GasTestConfinedSpaceTimeOfTest = gasTests.ConfinedSpaceTestTime.NullableToString();
            GasTestSystemEntryTimeOfTest = gasTests.SystemEntryTestTime.NullableToString();
        }

        private void SetAdditionalForms(WorkPermitAdditionalItemsRequired additionItemsRequired)
        {
            if (additionItemsRequired == null)
                return;

            AdditionalFormNotApplicable = additionItemsRequired.IsNotApplicable;

            if (!AdditionalFormNotApplicable)
            {
                AddtionalFormFlareEntry = additionItemsRequired.IsFlareEntry;
                AddtionalFormCriticalLift = additionItemsRequired.IsCriticalLift;
                AddtionalFormBlankBlindList = additionItemsRequired.IsBlankOrBlindLists;
                AddtionalFormPJSR = additionItemsRequired.IsPJSROrSafetyPause;
                AddtionalFormExcavation = additionItemsRequired.IsExcavation;
                AddtionalFormMSDS = additionItemsRequired.IsMSDS;
                AddtionalFormDeviation = additionItemsRequired.IsWaiverOrDeviation;
                AddtionalFormHotTap = additionItemsRequired.IsHotTap;
                AddtionalFormRoadClosure = additionItemsRequired.IsRoadClosure;
                AddtionalFormRadiationApproval = additionItemsRequired.IsRadiationApproval;
                AddtionalFormOnlineLeakRepairForm = additionItemsRequired.IsOnlineLeakRepairForm;
                AdditionalFormEnergizedElectricalForm = additionItemsRequired.IsEnergizedElectricalForm;
            }
        }

        private void SetPPERequirements(WorkPermitSpecialPPERequirements ppe)
        {
            if (ppe == null)
                return;

            PpeEyeNA = ppe.IsEyeOrFaceProtectionNotApplicable;
            if (PpeEyeNA == false)
            {
                PpeEyeGoggles = ppe.IsEyeOrFaceProtectionGoggles;
                PpeEyeFaceShield = ppe.IsEyeOrFaceProtectionFaceshield;
                PpeEyeOther = ppe.EyeOrFaceProtectionOtherDescription.HasValue();
                PpeEyeOtherDescription = PpeEyeOther ? ppe.EyeOrFaceProtectionOtherDescription : string.Empty;
            }

            PpeClothingNA = ppe.IsProtectiveClothingTypeNotApplicable;
            if (PpeClothingNA == false)
            {
                PpeClothingTyvekSuit = ppe.IsProtectiveClothingTypeTyvekSuit;
                PpeClothingElectricalFlashGear = ppe.IsProtectiveClothingTypeElectricalFlashGear;
                PpeClothingKapplerSuit = ppe.IsProtectiveClothingTypeKapplerSuit;
                PpeClothingCorrosiveClothing = ppe.IsProtectiveClothingTypeCorrosiveClothing;
                PpeClothingOther = ppe.ProtectiveClothingTypeOtherDescription.HasValue();
                PpeClothingOtherDescription = PpeClothingOther
                    ? ppe.ProtectiveClothingTypeOtherDescription
                    : string.Empty;
            }

            PpeProtectiveFootwearNA = ppe.IsProtectiveFootwearNotApplicable;
            if (PpeProtectiveFootwearNA == false)
            {
                PpeProtectiveFootwearToeGuard = ppe.IsProtectiveFootwearToeGuard;
                PpeProtectiveFootwearChemicalImperviousBoots = ppe.IsProtectiveFootwearChemicalImperviousBoots;
                PpeProtectiveFootwearOther = ppe.ProtectiveFootwearOtherDescription.HasValue();
                PpeProtectiveFootwearOtherDescription = PpeProtectiveFootwearOther
                    ? ppe.ProtectiveFootwearOtherDescription
                    : string.Empty;
            }

            PpeHandProtectionNA = ppe.IsHandProtectionNotApplicable;
            if (PpeHandProtectionNA == false)
            {
                PpeHandProtectionChemicalGloves = ppe.IsHandProtectionChemicalGloves;
                PpeHandProtectionHighVoltage = ppe.IsHandProtectionHighVoltage;
                PpeHandProtectionNitrile = ppe.IsHandProtectionNitrile;
                PpeHandProtectionWelding = ppe.IsHandProtectionWelding;
                PpeHandProtectionOther = ppe.HandProtectionOtherDescription.HasValue();
                PpeHandProtectionOtherDescription = PpeHandProtectionOther
                    ? ppe.HandProtectionOtherDescription
                    : string.Empty;
            }

            PpeRescueNA = ppe.IsRescueOrFallNotApplicable;
            if (PpeRescueNA == false)
            {
                PpeRescueBodyHarness = ppe.IsRescueOrFallBodyHarness;
                PpeRescueLifeline = ppe.IsRescueOrFallLifeline;
                PpRescueYoYo = ppe.IsRescueOrFallYoYo;
                PpeRescueDevice = ppe.IsRescueOrFallRescueDevice;
                PpeRescueOther = ppe.RescueOrFallOtherDescription.HasValue();
                PpeRescueOtherDescription = PpeRescueOther ? ppe.RescueOrFallOtherDescription : string.Empty;
            }

            PpeFallTieoffRequiredYes = ppe.FallTieoffRequired.HasTrueValue();
            PpeFallTieoffRequiredNo = ppe.FallTieoffRequired.HasFalseValue();
            PpeFallRestraint = ppe.FallRestraint;
            PpeFallSelfRetractingDevice = ppe.FallSelfRetractingDevice;
            PpeFallOther = ppe.FallOtherDescription.HasValue();
            PpeFallOtherDescription = ppe.FallOtherDescription;
        }

        private void SetRespitoryProtectionRequirements(WorkPermitRespiratoryProtectionRequirements resRequirements)
        {
            RpRNA = resRequirements == null || resRequirements.IsNotApplicable;

            if (RpRNA)
                return;

            RpRAirCart = resRequirements.IsAirCartorAirLine;
            RpRAirHood = resRequirements.IsAirHood;
            RpRSCBA = resRequirements.IsSCBA;
            RpRHalfFaceRespirator = resRequirements.IsHalfFaceRespirator;
            RpRFullFaceRespirator = resRequirements.IsFullFaceRespirator;
            RpROther = resRequirements.OtherDescription.HasValue();
            RpROtherDescription = RpROther ? resRequirements.OtherDescription : string.Empty;

            if (resRequirements.CartridgeType == null)
                return;

            RpRCartrideTypeOVAGHEPA = resRequirements.CartridgeType.IsSame(WorkPermitRespiratoryCartridgeType.OV_AG_HEPA);
            RpRCartrideTypeOVAG = resRequirements.CartridgeType.IsSame(WorkPermitRespiratoryCartridgeType.OV_AG);
            RpRCartrideTypeAmmonia = resRequirements.CartridgeType.IsSame(WorkPermitRespiratoryCartridgeType.AMMONIA);
            RpRCartrideTypeHEPA = resRequirements.CartridgeType.IsSame(WorkPermitRespiratoryCartridgeType.HEPA);
        }

        private void SetConfinedSpaceRequirements(WorkPermitFireConfinedSpaceRequirements cseRequirements)
        {
            CseNA = cseRequirements == null || cseRequirements.IsNotApplicable;

            if (CseNA)
                return;

            CseFireExtinguisher = cseRequirements.IsC02Extinguisher;
            CseFireResistantTarp = cseRequirements.IsFireResistantTarp;
            CseSparkContainment = cseRequirements.IsSparkContainment;
            CseWaterHose = cseRequirements.IsWaterHose;
            CseSteamHose = cseRequirements.IsSteamHose;
            CseOther = cseRequirements.OtherDescription.HasValue();
            CseOtherDescription = CseOther ? cseRequirements.OtherDescription : string.Empty;
            CseHoleWatchNumber = cseRequirements.HoleWatchNumber.NullToEmpty();
            CseFireWatchNumber = cseRequirements.FireWatchNumber.NullToEmpty();
            CseBottleWatchNumber = cseRequirements.SpotterNumber.NullToEmpty();
        }

        private void SetRadiationInformation(WorkPermitRadiationInformation radiationInformation)
        {
            RadiationNA = radiationInformation == null || radiationInformation.IsSealedSourceIsolationNotApplicable;

            if (RadiationNA)
                return;

            RadiationLOTO = radiationInformation.IsSealedSourceIsolationLOTO;
        }

        private void SetJobWorksitePreparation(WorkPermitJobWorksitePreparation jobPrep)
        {
            if (jobPrep == null)
                return;

            SewerIsolationNA = jobPrep.IsSewerIsolationMethodNotApplicable;
            if (SewerIsolationNA == false)
            {
                SewerIsolationSealedCovered = jobPrep.IsSewerIsolationMethodSealedOrCovered;
                SewerIsolationPlugged = jobPrep.IsSewerIsolationMethodPlugged;
                SewerIsolationBlindBlank = jobPrep.IsSewerIsolationMethodBlindedOrBlanked;
                SewerIsolationOther = jobPrep.SewerIsolationMethodOtherDescription.HasValue();
                SewerIsolationOtherDescription = SewerIsolationOther
                    ? jobPrep.SewerIsolationMethodOtherDescription
                    : string.Empty;
            }

            JobSiteRadiationNA = jobPrep.IsAreaPreparationNotApplicable;
            if (JobSiteRadiationNA == false)
            {
                JobSiteBarricadeTape = jobPrep.IsAreaPreparationBoundaryRopeTape;
                JobSiteNonEssentialPersonnelEvacuation = jobPrep.IsAreaPreparationNonEssentialEvac;
                JobSiteHardBarricade = jobPrep.IsAreaPreparationBarricade;
                JobSiteRadiationRope = jobPrep.IsAreaPreparationRadiationRope;
                JobSiteRadiationOther = jobPrep.AreaPreparationOtherDescription.HasValue();
                JobSiteRadiationOtherDescription = JobSiteRadiationOther
                    ? jobPrep.AreaPreparationOtherDescription
                    : string.Empty;
            }

            LightingNA = jobPrep.IsLightingElectricalRequirementNotApplicable;
            if (LightingNA == false)
            {
                LightingLowVoltage = jobPrep.IsLightingElectricalRequirementLowVoltage12V;
                Lighting110V = jobPrep.IsLightingElectricalRequirement110VWithGFCI;
                LightingGeneratorLights = jobPrep.IsLightingElectricalRequirementGeneratorLights;
                LightingOther = jobPrep.LightingElectricalRequirementOtherDescription.HasValue();
                LightingOtherDescription = LightingOther
                    ? jobPrep.LightingElectricalRequirementOtherDescription
                    : string.Empty;
            }

            FlowRequiredForJobsNA = jobPrep.IsFlowRequiredForJobNotApplicable;
            if (FlowRequiredForJobsNA == false)
            {
                FlowRequiredForJobsYes = jobPrep.IsFlowRequiredForJob.HasTrueValue();
                // the previous version of the report would set this to No if nothing else was selected. This could actually be a bug
                FlowRequiredForJobsNo = !jobPrep.IsFlowRequiredForJob.HasTrueValue();
                //FlowRequiredForJobsNo = jobPrep.IsFlowRequiredForJob.HasFalseValue(); 
            }

            BondingGroundingRequiredNA = jobPrep.IsBondingOrGroundingRequiredNotApplicable;
            if (BondingGroundingRequiredNA == false)
            {
                BondingGroundingRequiredYes = jobPrep.IsBondingOrGroundingRequired.HasTrueValue();
                BondingGroundingRequiredNo = jobPrep.IsBondingOrGroundingRequired.HasFalseValue();
            }

            SurroundingConditionsAffectWorkAreaNA = jobPrep.IsSurroundingConditionsAffectOrContaminatedNotApplicable;
            if (SurroundingConditionsAffectWorkAreaNA == false)
            {
                SurroundingConditionsAffectWorkAreaYes =
                    jobPrep.IsSurroundingConditionsAffectOrContaminated.HasTrueValue();
                SurroundingConditionsAffectWorkAreaNo =
                    jobPrep.IsSurroundingConditionsAffectOrContaminated.HasFalseValue();
            }
        }

        private void SetEquipmentPreparation(WorkPermitEquipmentPreparationCondition condition)
        {
            if (condition == null)
                return;

            EquipmentInService = condition.IsInServiceSelected;
            EquipmentOutOfService = !condition.IsInServiceSelected;

            ElectricalBumpTestPerformedNA = condition.IsTestBumpNotApplicable;
            if (ElectricalBumpTestPerformedNA == false)
            {
                ElectricalBumpTestPerformedYes = condition.IsTestBump.HasTrueValue();
                ElectricalBumpTestPerformedNo = condition.IsTestBump.HasFalseValue();
            }

            StillContainsResidualNA = condition.IsStillContainsResidualNotApplicable;
            if (StillContainsResidualNA == false)
            {
                StillContainsResidualYes = condition.IsStillContainsResidual.HasTrueValue();
                StillContainsResidualNo = condition.IsStillContainsResidual.HasFalseValue();
            }

            LeakingTestValvesNA = condition.IsLeakingValvesNotApplicable;
            if (LeakingTestValvesNA == false)
            {
                LeakingTestValvesYes = condition.IsLeakingValves.HasTrueValue();
                LeakingTestValvesNo = condition.IsLeakingValves.HasFalseValue();
            }

            EquipmentConditionNA = condition.IsConditionNotApplicable;
            if (EquipmentConditionNA == false)
            {
                EquipmentConditionDepressured = condition.IsConditionDepressured;
                EquipmentConditionVentilated = condition.IsConditionVentilated;
                EquipmentConditionDrained = condition.IsConditionDrained;
                EquipmentConditionH20Washed = condition.IsConditionH20Washed;
                EquipmentConditionCleaned = condition.IsConditionCleaned;
                EquipmentConditionNeutralized = condition.IsConditionNeutralized;
                EquipmentConditionPurged = condition.IsConditionPurged;
                EquipmentConditionPurgeMethod = EquipmentConditionPurged
                    ? condition.ConditionPurgedDescription
                    : string.Empty;
            }

            EquipmentPriorContentsNA = condition.IsPreviousContentsNotApplicable;
            if (EquipmentPriorContentsNA == false)
            {
                EquipmentPriorContentsHydocarbon = condition.IsPreviousContentsHydrocarbon;
                EquipmentPriorContentsAcid = condition.IsPreviousContentsAcid;
                EquipmentPriorContentsCaustic = condition.IsPreviousContentsCaustic;
                EquipmentPriorContentsH2S = condition.IsPreviousContentsH2S;
                EquipmentPriorContentsOther = condition.IsPreviousContentsOtherDescription;
                EquipmentPriorContentsOtherDescription = EquipmentPriorContentsOther
                    ? condition.PreviousContentsOtherDescription
                    : string.Empty;
            }

            EquipmentIsolationNA = condition.IsIsolationMethodNotApplicable;
            if (EquipmentIsolationNA == false)
            {
                EquipmentIsolationBlindBlank = condition.IsIsolationMethodBlindedorBlanked;
                EquipmentIsolationLOTO = condition.IsIsolationMethodLOTO;
                EquipmentIsolationSeparation = condition.IsIsolationMethodSeparation;
                EquipmentIsolationExpansionPlugs = condition.IsIsolationMethodMudderPlugs;
                EquipmentIsolationCarBer = condition.IsIsolationMethodCarBer;
                // Troy todo: is this not on the work permit?
                EquipmentIsolationOther = condition.IsolationMethodOtherDescription.HasValue();
                EquipmentIsolationOtherDescription = EquipmentIsolationOther
                    ? condition.IsolationMethodOtherDescription
                    : string.Empty;
            }

            ElectricIsolationNA = condition.IsElectricalIsolationMethodNotApplicable;
            if (ElectricIsolationNA == false)
            {
                ElectricIsolationLOTO = condition.IsElectricalIsolationMethodLOTO;
                ElectricIsolationWiringDisconnected = condition.IsElectricalIsolationMethodWiring;
            }

            VentilationNA = condition.IsVentilationMethodNotApplicable;
            if (VentilationNA == false)
            {
                VentilationNaturalDraft = condition.IsVentilationMethodNaturalDraft;
                VentilationLocalExhaust = condition.IsVentilationMethodLocalExhaust;
                VentilationForced = condition.IsVentilationMethodForced;
            }
        }

        private void SetToolsToBeUsed(WorkPermitTools tools)
        {
            if (tools == null)
                return;

            ToolsAirtool = tools.IsAirTools;
            ToolsCementSaw = tools.IsCementSaw;
            ToolsCompressor = tools.IsCompressor;
            ToolsChemicals = tools.IsChemicals;
            ToolsCraneOrCarrydeck = tools.IsCraneOrCarrydeck;
            ToolsElectricTools = tools.IsElectricTools;
            ToolsForkLift = tools.IsForklift;
            ToolsHandTools = tools.IsHandTools;
            ToolsHeavyEquipment = tools.IsHeavyEquipment;
            ToolsHEPAVacuum = tools.IsHEPAVacuum;
            ToolsHotTapMachine = tools.IsHotTapMachine;
            ToolsJackhammer = tools.IsJackhammer;
            ToolsLanda = tools.IsLanda;
            ToolsManlift = tools.IsManlift;
            ToolsPortLighting = tools.IsPortLighting;
            ToolsScaffolding = tools.IsScaffolding;
            ToolsTamper = tools.IsTamper;
            ToolsTorch = tools.IsTorch;
            ToolsVacuumTruck = tools.IsVacuumTruck;
            ToolsVehicle = tools.IsVehicle;
            ToolsWelder = tools.IsWelder;
            ToolsOther = !string.IsNullOrEmpty(tools.OtherToolsDescription);
            ToolsOtherDescription = ToolsOther ? tools.OtherToolsDescription : string.Empty;
        }

        private void SetLocationAndJobSpecificsAndScope(WorkPermitSpecifics specifics)
        {
            if (specifics == null)
                return;

            FunctionalLocation = specifics.FunctionalLocation.FullHierarchy;
            WorkOrderNumber = specifics.WorkOrderNumber;
            StartDateTime = specifics.StartDateTime.ToLongDateAndTimeString();
            EndDateTime = specifics.EndDateTime.HasValue
                ? specifics.EndDateTime.Value.ToLongDateAndTimeString()
                : string.Empty;
            ContactPerson = specifics.ContactName;
            ContactorName = specifics.ContractorCompanyName;
            CraftOrTrade = specifics.CraftOrTradeName;

            WorkOrderDescription = specifics.WorkOrderDescription.ReplaceWhitespaceWithDelimiter();
            JobStepDescription = specifics.JobStepDescription.ReplaceWhitespaceWithDelimiter();

            var communication = specifics.Communication;
            if (communication != null)
            {
                Radio = communication.IsRadio;
                RadioChannel = communication.RadioChannel;
                RadioOther = communication.Description;
                RadioNA = communication.IsWorkPermitCommunicationNotApplicable;
            }
        }

        private void SetPermitAttributes(WorkPermitAttributes workPermitAttributes)
        {
            if (workPermitAttributes == null)
                return;

            AttributeConfinedSpaceEntry = workPermitAttributes.IsConfinedSpaceEntry;
            AttributeInertConfinedSpaceEntry = workPermitAttributes.IsInertConfinedSpaceEntry;
            AttributeBreatingAirSCBA = workPermitAttributes.IsBreathingAirOrSCBA;

            AttributeSystemEntry = workPermitAttributes.IsSystemEntry;
            AttributeCriticalLift = workPermitAttributes.IsCriticalLift;
            AttributeVehicleEntry = workPermitAttributes.IsVehicleEntry;

            AttributeElectricalWork = workPermitAttributes.IsElectricalWork;
            AttributeBurnOrOpenFlame = workPermitAttributes.IsBurnOrOpenFlame;
            AttributeLeadAbatement = workPermitAttributes.IsLeadAbatement;

            AttributeExcavation = workPermitAttributes.IsExcavation;
            AttributeHotTap = workPermitAttributes.IsHotTap;
            AttributeAsbestos = workPermitAttributes.IsAsbestos;

            AttributeRadiationRadiography = workPermitAttributes.IsRadiationRadiography;
            AttributeRadiationSealed = workPermitAttributes.IsRadiationSealed;
        }
    }
}