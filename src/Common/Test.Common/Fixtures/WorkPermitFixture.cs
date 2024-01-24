using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public static class WorkPermitFixture
    {
        public static WorkPermit CreateWorkPermit(User user, bool isOperations)
        {
            return CreateWorkPermit(user, isOperations, FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF());
        }

        private static WorkPermit CreateWorkPermit(User user, bool isOperations, FunctionalLocation floc)
        {
            var workPermit = new WorkPermit(user.AvailableSites[0])
            {
                LastModifiedBy = user,
                LastModifiedDate = DateTimeFixture.DateTimeNow,
                PermitNumber = null,
                PermitValidDateTime = new DateTime(2005, 12, 2, 23, 59, 59),
                WorkPermitType = WorkPermitType.HOT
            };
            workPermit.SetCreatedBy(user, isOperations);

            workPermit.SetWorkPermitStatus(WorkPermitStatus.Pending);

            workPermit.WorkPermitTypeClassification = WorkPermitTypeClassification.GENERAL;

            WorkPermitSpecifics specifics = workPermit.Specifics;
            specifics.WorkOrderNumber = "Work Order Number xxx";
            specifics.StartDateTime = new DateTime(2005, 12, 2, 23, 59, 59);
            specifics.EndDateTime = new DateTime(2005, 12, 2, 23, 59, 59);

            specifics.WorkOrderDescription = "WorkOrderDescription xxx";
            specifics.FunctionalLocation = floc;
            specifics.JobStepDescription = "Job Steps Description xxx";
            specifics.Communication = CreateWorkPermitCommunication();
            specifics.CraftOrTrade = CreateCraftOrTrade();
            specifics.ContractorCompanyName = "Contractor Company Name xxx";
            specifics.ContactName = "Contact Name xxx";

            PopulateWorkPermitAttributes(workPermit.Attributes);
            workPermit.SpecialPrecautionsOrConsiderations = "SpecialPrecautionsOrConsiderations xxx";
            workPermit.IsCoauthorizationRequired = true;
            workPermit.CoauthorizationDescription = "Coauthorization desc xxx";
            workPermit.Source = DataSource.SAP;
            workPermit.AdditionItemsRequired = CreateWorkPermitAdditionalItemsRequired();
            workPermit.Tools = CreateWorkPermitTools();
            CreateWorkPermitEquipmentPreparationCondition(workPermit.EquipmentPreparationCondition);
            workPermit.JobWorksitePreparation = CreateWorkPermitJobWorksitePreparation();
            workPermit.RadiationInformation = CreateWorkPermitRadiationInformation();

            workPermit.GasTests = CreateWorkPermitGasTests(workPermit.FunctionalLocation.Site);

            workPermit.FireConfinedSpaceRequirements = CreateWorkPermitFireConfinedSpaceRequirements();
            workPermit.RespiratoryProtectionRequirements = CreateWorkPermitRespiratoryProtectionRequirements();
            workPermit.SpecialProtectionRequirements = CreateWorkPermitSpecialPPERequirements();

            return workPermit;            
        }

        public static WorkPermit CreateWorkPermit()
        {
            User sarniaUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            return CreateWorkPermit(sarniaUser, true);
        }

        public static WorkPermit CreateWorkPermit(FunctionalLocation floc)
        {
            User sarniaUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            WorkPermit workPermit = CreateWorkPermit(sarniaUser, true, floc);
            return workPermit;
        }
       
        public static WorkPermit CreateWorkPermit(long id)
        {
            return CreateWorkPermit(id, WorkPermitStatus.Pending);
        }

        public static WorkPermit CreateWorkPermit(WorkPermitStatus status)
        {
            return CreateWorkPermit(null, status);
        }

        public static WorkPermit CreateWorkPermit(WorkPermitStatus status, FunctionalLocation floc)
        {
            User sarniaUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            WorkPermit workPermit = CreateWorkPermit(sarniaUser, true, floc);
            workPermit.SetWorkPermitStatusAndApprover(status, sarniaUser);
            return workPermit;
        }

        public static WorkPermit CreateWorkPermit(long? id, WorkPermitStatus status)
        {
            WorkPermit workPermit = CreateWorkPermit();
            workPermit.Id = id;
            
            User user = status == WorkPermitStatus.Approved ? UserFixture.CreateSupervisor(7, "oltuser7") : null;
            workPermit.SetWorkPermitStatusAndApprover(status, user);
            
            return workPermit;
        }
        
        public static WorkPermit CreateValidWorkPermit(long id)
        {
            WorkPermit permit = CreateWorkPermitWithGivenId(id);
            permit.Attributes = new WorkPermitAttributes();
            return permit;
        }
        
        public static WorkPermit CreateWorkPermitWithWarning(long id)
        {
            WorkPermit permit = CreateValidWorkPermit(id);
            MakePermitHaveWarning(permit);
            return permit;
        }

        public static WorkPermit CreateWorkPermitWithError(long id)
        {
            WorkPermit permit = CreateValidWorkPermit(id);
            MakePermitHaveError(permit);
            return permit;
        }
        
        public static WorkPermit CreateWorkPermitWithFieldLevelError(long id)
        {
            WorkPermit permit = CreateValidWorkPermit(id);
            MakePermitHaveFieldLevelError(permit);
            return permit;
        }

        public static WorkPermit CreateWorkPermitWithWarningAndError(long id)
        {
            WorkPermit permit = CreateValidWorkPermit(id);
            MakePermitHaveWarning(permit);
            MakePermitHaveError(permit);
            return permit;
        }

        private static void MakePermitHaveFieldLevelError(WorkPermit permit)
        {
            permit.EquipmentPreparationCondition.IsStillContainsResidual = null;
            permit.EquipmentPreparationCondition.IsStillContainsResidualNotApplicable = false;
        }
        
        private static void MakePermitHaveError(WorkPermit permit)
        {
            permit.WorkPermitType = WorkPermitType.HOT;
            permit.FireConfinedSpaceRequirements = new WorkPermitFireConfinedSpaceRequirements();
        }

        private static void MakePermitHaveWarning(WorkPermit permit)
        {
            permit.Attributes.IsCriticalLift = true;
            permit.AdditionItemsRequired = new WorkPermitAdditionalItemsRequired();
        }

        private static void PopulateWorkPermitAttributes(WorkPermitAttributes workPermitAttributes)
        {
            workPermitAttributes.IsConfinedSpaceEntry = true;
            workPermitAttributes.IsBreathingAirOrSCBA = true;
            workPermitAttributes.IsElectricalWork = true;
            workPermitAttributes.IsVehicleEntry = true;
            workPermitAttributes.IsHotTap = true;
            workPermitAttributes.IsBurnOrOpenFlame = true;
            workPermitAttributes.IsSystemEntry = true;
            workPermitAttributes.IsCriticalLift = true;
            workPermitAttributes.IsExcavation = true;
            workPermitAttributes.IsAsbestos = true;
            workPermitAttributes.IsRadiationRadiography = true;
            workPermitAttributes.IsRadiationSealed = true;
            workPermitAttributes.IsInertConfinedSpaceEntry = true;
            workPermitAttributes.IsLeadAbatement = true;
        }

        public static WorkPermit CreateWorkPermitWithNoLastModifiedBy()
        {
            User user = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();

            var workPermit = new WorkPermit(user.AvailableSites[0])
                                 {
                                     LastModifiedDate = new DateTime(2005, 12, 2, 23, 59, 59),
                                     PermitNumber = null
                                 };

            workPermit.SetCreatedBy(user, true);

            WorkPermitSpecifics specifics = workPermit.Specifics;
            specifics.WorkOrderNumber = "Work Order Number xxx";
            specifics.StartDateTime = new DateTime(2005, 12, 2, 23, 59, 59);
            specifics.EndDateTime = new DateTime(2005, 12, 2, 23, 59, 59);
            specifics.WorkOrderDescription = "WorkOrderDescription xxx";
            specifics.FunctionalLocation = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            specifics.JobStepDescription = "Job Steps Description xxx";
            specifics.Communication = CreateWorkPermitCommunication();
            specifics.CraftOrTrade = CreateCraftOrTrade();
            specifics.ContractorCompanyName = "Contractor Company Name xxx";
            specifics.ContactName = "Contact Name xxx";

            workPermit.PermitValidDateTime = new DateTime(2005, 12, 2, 23, 59, 59);
            workPermit.WorkPermitType = WorkPermitType.HOT;
            workPermit.SetWorkPermitStatus(WorkPermitStatus.Pending);

            workPermit.WorkPermitTypeClassification = WorkPermitTypeClassification.GENERAL;
            PopulateWorkPermitAttributes(workPermit.Attributes);
            workPermit.SpecialPrecautionsOrConsiderations = "SpecialPrecautionsOrConsiderations xxx";
            workPermit.IsCoauthorizationRequired = true;
            workPermit.Source = DataSource.SAP;
            workPermit.AdditionItemsRequired = CreateWorkPermitAdditionalItemsRequired();
            workPermit.Tools = CreateWorkPermitTools();
            CreateWorkPermitEquipmentPreparationCondition(workPermit.EquipmentPreparationCondition);
            workPermit.JobWorksitePreparation = CreateWorkPermitJobWorksitePreparation();
            workPermit.RadiationInformation = CreateWorkPermitRadiationInformation();

            workPermit.GasTests = CreateWorkPermitGasTests(workPermit.FunctionalLocation.Site);

            workPermit.FireConfinedSpaceRequirements = CreateWorkPermitFireConfinedSpaceRequirements();
            workPermit.RespiratoryProtectionRequirements = CreateWorkPermitRespiratoryProtectionRequirements();
            workPermit.SpecialProtectionRequirements = CreateWorkPermitSpecialPPERequirements();

            return workPermit;
        }

        public static WorkPermit CreateWorkPermitWithGivenId(long id)
        {
            WorkPermit workPermit = CreateWorkPermit();
            workPermit.Id = id;
            workPermit.PermitNumber = "SARNIA-" + id;
            return workPermit;
        }

        public static WorkPermit CreateWorkPermitWithGivenStatus(WorkPermitStatus status)
        {
            WorkPermit workPermit = CreateWorkPermit();
            if (status == WorkPermitStatus.Approved)
            {
                User approver = UserFixture.CreateSupervisor();
                workPermit.SetWorkPermitStatusAndApprover(status, approver);
            }
            else
                workPermit.SetWorkPermitStatus(status);

            return workPermit;
        }

        public static List<WorkPermit> CreateWorkPermitListOfACertainStatus(int size, WorkPermitStatus status)
        {
            return CreateWorkPermitListOfACertainStatus(size, status, DateTimeFixture.DateTimeNow);
        }

        public static List<WorkPermit> CreateWorkPermitListOfACertainStatus(int size, WorkPermitStatus status, DateTime now)
        {
            var workPermitList = new List<WorkPermit>();
            WorkPermit workPermit;
            for (int i = 0; i < size; i++)
            {
                workPermit = CreateWorkPermitWithGivenId(i);
                workPermit.LastModifiedDate = now;
                workPermit.SetWorkPermitStatus(status);
                workPermitList.Add(workPermit);
            }
            return workPermitList;
        }
        
        public static WorkPermit CreateValidWorkPermitForValidator()
        {
            var workPermit = new WorkPermit(SiteFixture.Sarnia()) { WorkPermitType = WorkPermitType.COLD };
            workPermit.FireConfinedSpaceRequirements.IsNotApplicable = true;
            return workPermit;
        }

        public static List<WorkPermit> CreateWorkPermitComparableList(int size)
        {
            var workPermitList = new List<WorkPermit>();
            for (int i = 0; i < size; i++)
            {
                workPermitList.Add(CreateWorkPermitWithGivenId(i));
            }
            return workPermitList;
        }

        public static WorkPermit CreateWorkPermitWithRadiationInformationSetWithNoID()
        {
            return CreateWorkPermitWithRadiationInformationSetWithNoID(DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow.AddDays(1));
        }

        public static WorkPermit CreateWorkPermitWithStartAndEndDateTime(DateTime startDateTime, DateTime endDateTime)
        {
            WorkPermit workPermit = CreateWorkPermit();
            workPermit.Specifics.StartDateTime = startDateTime;
            workPermit.Specifics.EndDateTime = endDateTime;
            return workPermit;
        }

        public static WorkPermit CreateWorkPermitWithRadiationInformationSetWithNoID(DateTime startDateTime, DateTime endDateTime)
        {
            WorkPermit workPermit = CreateWorkPermit();
            //workPermit.LastModifiedBy = UserFixture.CreateOperatorOltUser1ThatMapsToFirstUserInDB();
            workPermit.SetCreatedBy(UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(), true);
            workPermit.LastModifiedDate = new DateTime(2006, 07, 03, 16, 21, 00);
            workPermit.WorkPermitType = WorkPermitTypeFixture.CreateWorkPermitTypeCold();
            workPermit.WorkPermitTypeClassification =
                WorkPermitTypeClassificationFixture.CreateWorkPermitTypeClasificationGeneral();
            workPermit.SetWorkPermitStatus(WorkPermitStatus.Pending);
            workPermit.PermitNumber = null; //work permit is generated by server

            WorkPermitSpecifics specifics = workPermit.Specifics;
            specifics.CraftOrTrade = CraftOrTradeFixture.CreateCraftOrTradeWelder();
            specifics.WorkOrderNumber = "A100000000";
            specifics.FunctionalLocation = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            specifics.Communication.ByRadio = true;
            specifics.StartDateTime = startDateTime;
            specifics.EndDateTime = endDateTime;

            return workPermit;
        }

        public static WorkPermit CreateABigManualWorkPermitWithNoID(DateTime startDateTime, DateTime endDateTime)
        {
            WorkPermit workPermit = CreateWorkPermitWithRadiationInformationSetWithNoID(startDateTime, endDateTime);
            workPermit.LastModifiedBy = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            workPermit.Source = DataSource.MANUAL;
            workPermit.AdditionItemsRequired.OtherItemDescription = "This is another item description";

            WorkPermitSpecifics specifics = workPermit.Specifics;
            specifics.Communication.ByRadio = true;
            specifics.Communication.RadioChannel = "Channel 20";
            specifics.Communication.RadioColor = "Blue";
            specifics.Communication.IsWorkPermitCommunicationNotApplicable = false;
            specifics.ContactName = "Joe Smith";
            specifics.ContractorCompanyName = "ACME Inc.";
            specifics.JobStepDescription =
                "Job Step Description. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. All work and no play makes John a dull boy. ";
            specifics.WorkOrderDescription =
                "Work order description. Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.Work order description.";
            specifics.CraftOrTrade = CreateCraftOrTrade();

            workPermit.EquipmentPreparationCondition.IsConditionPurged = true;
            workPermit.EquipmentPreparationCondition.ConditionPurgedDescription = "Chemical fire";

            workPermit.EquipmentPreparationCondition.IsPreviousContentsNotApplicable = false;
            workPermit.EquipmentPreparationCondition.PreviousContentsOtherDescription = "Small pieces of stuff";

            workPermit.EquipmentPreparationCondition.IsStillContainsResidualNotApplicable = false;
            workPermit.IsCoauthorizationRequired = true;
            workPermit.CoauthorizationDescription = "Co-auth description";

            workPermit.FireConfinedSpaceRequirements.OtherDescription = "Require everybody to where firesuit";

            workPermit.JobWorksitePreparation.IsAreaPreparationNotApplicable = false;
            workPermit.JobWorksitePreparation.AreaPreparationOtherDescription = "Clean it All up";

            workPermit.JobWorksitePreparation.IsLightingElectricalRequirementNotApplicable = false;
            workPermit.JobWorksitePreparation.LightingElectricalRequirementOtherDescription = "Lots of lights";

            workPermit.JobWorksitePreparation.IsSewerIsolationMethodNotApplicable = false;
            workPermit.JobWorksitePreparation.SewerIsolationMethodOtherDescription = "Blow up the main pipe";

            workPermit.RadiationInformation.SealedSourceIsolationNumberOfSources = 23;
            workPermit.RespiratoryProtectionRequirements.OtherDescription = "Wear a small mask";
            workPermit.RespiratoryProtectionRequirements.CartridgeTypeDescription = "Air";

            workPermit.SpecialPrecautionsOrConsiderations =
                "Special Precautions. Be careful. Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.Special Precautions. Be careful.";
            workPermit.SpecialProtectionRequirements.EyeOrFaceProtectionOtherDescription = "Wear glasses";
            workPermit.SpecialProtectionRequirements.HandProtectionOtherDescription = "Wear gloves";
            workPermit.SpecialProtectionRequirements.ProtectiveClothingTypeOtherDescription = "Stuff";
            workPermit.SpecialProtectionRequirements.ProtectiveFootwearOtherDescription = "Footwear stuff";
            workPermit.SpecialProtectionRequirements.RescueOrFallOtherDescription = "Rescue stuff";
            workPermit.SpecialProtectionRequirements.IsRescueOrFallBodyHarness = true;
            workPermit.SpecialProtectionRequirements.IsRescueOrFallLifeline = false;

            return workPermit;
        }

        public static WorkPermit CreateABigManualWorkPermitWithNoID()
        {
            DateTime now = Clock.Now;
            return CreateABigManualWorkPermitWithNoID(now);
        }

        public static WorkPermit CreateABigManualWorkPermitWithNoID(DateTime now)
        {
            return CreateABigManualWorkPermitWithNoID(now, now.AddDays(1));
        }

        public static WorkPermit CreateManualWorkPermit(WorkPermitStatus status)
        {
            WorkPermit workPermit = CreateABigManualWorkPermitWithNoID();
            workPermit.SetWorkPermitStatus(status);
            return workPermit;
        }

        public static WorkPermitTypeClassification CreateWorkPermitTypeClassification()
        {
            var workPermitTypeClassification = new WorkPermitTypeClassification
                                                   {Name = "WorkPermitTypeClassification xxx"};
            return workPermitTypeClassification;
        }

        public static WorkPermitCommunication CreateWorkPermitCommunication()
        {
            var workPermitCommunication = new WorkPermitCommunication
                                              {
                                                  Description = "Work Permit Communication xxx",
                                                  RadioChannel = "Radio Channel xxx",
                                                  RadioColor = "Radio Color xxx",
                                                  ByRadio = true
                                              };
            return workPermitCommunication;
        }

        public static CraftOrTrade CreateCraftOrTrade()
        {
            return new CraftOrTrade(1, "Boilermaker Welder, Contract", "BMW-C", 1);
        }

        public static WorkPermitAdditionalItemsRequired CreateWorkPermitAdditionalItemsRequired()
        {
            var additionalItemsRequired = new WorkPermitAdditionalItemsRequired
                                              {
                                                  IsCSEAssessmentOrAuthorization = true,
                                                  IsFlareEntry = true,
                                                  IsCriticalLift = true,
                                                  IsExcavation = true,
                                                  IsHotTap = true,
                                                  IsSpecialWasteDisposal = true,
                                                  IsBlankOrBlindLists = true,
                                                  IsPJSROrSafetyPause = true,
                                                  IsAsbestosHandling = true,
                                                  IsRoadClosure = true,
                                                  IsElectrical = true,
                                                  IsBurnOrOpenFlameAssessment = true,
                                                  IsWaiverOrDeviation = true,
                                                  IsMSDS = true,
                                                  IsRadiationApproval = true,
                                                  IsOnlineLeakRepairForm = true,
                                                  IsEnergizedElectricalForm = true,
                                                  OtherItemDescription = "Other Item Description xxx"
                                              };
            return additionalItemsRequired;
        }

        public static WorkPermitTools CreateWorkPermitTools()
        {
            var tools = new WorkPermitTools
                            {
                                IsAirTools = true,
                                IsCraneOrCarrydeck = true,
                                IsHandTools = true,
                                IsJackhammer = true,
                                IsVacuumTruck = true,
                                IsCementSaw = true,
                                IsElectricTools = true,
                                IsHeavyEquipment = true,
                                IsLanda = true,
                                IsScaffolding = true,
                                IsVehicle = true,
                                IsCompressor = true,
                                IsForklift = true,
                                IsHEPAVacuum = true,
                                IsManlift = true,
                                IsTamper = true,
                                IsHotTapMachine = true,
                                IsPortLighting = true,
                                IsTorch = true,
                                IsWelder = true,
                                IsChemicals = true,
                                OtherToolsDescription = "Other Tools Description xxx"
                            };
            return tools;
        }

        public static void CreateWorkPermitEquipmentPreparationCondition(WorkPermitEquipmentPreparationCondition equipmentPrepCondition)
        {
            equipmentPrepCondition.IsElectricalIsolationMethodNotApplicable = false;
            equipmentPrepCondition.IsElectricalIsolationMethodLOTO = true;
            equipmentPrepCondition.IsElectricalIsolationMethodWiring = true;
            equipmentPrepCondition.IsTestBumpNotApplicable = true;
            equipmentPrepCondition.IsTestBump = true;
            equipmentPrepCondition.IsStillContainsResidualNotApplicable = false;
            equipmentPrepCondition.IsStillContainsResidual = false;
            equipmentPrepCondition.IsLeakingValvesNotApplicable = true;
            equipmentPrepCondition.IsLeakingValves = false;
            equipmentPrepCondition.IsOutOfService = true;
            equipmentPrepCondition.IsConditionNotApplicable = false;
            equipmentPrepCondition.IsConditionDepressured = true;
            equipmentPrepCondition.IsConditionDrained = true;
            equipmentPrepCondition.IsConditionCleaned = true;
            equipmentPrepCondition.IsConditionVentilated = true;
            equipmentPrepCondition.IsConditionH20Washed = true;
            equipmentPrepCondition.IsConditionNeutralized = true;
            equipmentPrepCondition.IsConditionPurged = true;
            equipmentPrepCondition.ConditionPurgedDescription = "Condition Purged Description xxx";
            equipmentPrepCondition.IsPreviousContentsNotApplicable = true;
            equipmentPrepCondition.IsPreviousContentsHydrocarbon = false;
            equipmentPrepCondition.IsPreviousContentsAcid = false;
            equipmentPrepCondition.IsPreviousContentsCaustic = false;
            equipmentPrepCondition.IsPreviousContentsH2S = false;
            equipmentPrepCondition.PreviousContentsOtherDescription = string.Empty;
            equipmentPrepCondition.IsIsolationMethodNotApplicable = false;
            equipmentPrepCondition.IsIsolationMethodBlindedorBlanked = true;
            equipmentPrepCondition.IsIsolationMethodSeparation = true;
            equipmentPrepCondition.IsIsolationMethodMudderPlugs = true;
            equipmentPrepCondition.IsIsolationMethodBlockedIn = true;
            equipmentPrepCondition.IsIsolationMethodCarBer = true;            
            equipmentPrepCondition.IsolationMethodOtherDescription = "Isolation Method Other Description xxx";
            equipmentPrepCondition.IsVentilationMethodNotApplicable = true;
            equipmentPrepCondition.IsVentilationMethodNaturalDraft = false;
            equipmentPrepCondition.IsVentilationMethodLocalExhaust = false;
            equipmentPrepCondition.IsVentilationMethodForced = false;
        }

        public static WorkPermitJobWorksitePreparation CreateWorkPermitJobWorksitePreparation()
        {
            var jobWorksitePrep = new WorkPermitJobWorksitePreparation
                                      {
                                          IsFlowRequiredForJob = false,                    
                                          IsFlowRequiredForJobNotApplicable = false,
                                          IsBondingOrGroundingRequiredNotApplicable = false,
                                          IsBondingOrGroundingRequired = true,
                                          IsWeldingGroundWireInTestAreaNotApplicable = false,
                                          IsWeldingGroundWireInTestArea = true,
                                          IsSurroundingConditionsAffectOrContaminatedNotApplicable = true,
                                          IsSurroundingConditionsAffectOrContaminated = false,
                                          IsVestedBuddySystemInEffectNotApplicable = false,
                                          IsVestedBuddySystemInEffect = true,
                                          IsSewerIsolationMethodNotApplicable = false,
                                          IsSewerIsolationMethodSealedOrCovered = true,
                                          IsSewerIsolationMethodPlugged = true,
                                          IsSewerIsolationMethodBlindedOrBlanked = true,
                                          SewerIsolationMethodOtherDescription = "sewerIsolationMethodOtherDescription",
                                          IsAreaPreparationNotApplicable = false,
                                          IsAreaPreparationBarricade = true,
                                          IsAreaPreparationNonEssentialEvac = true,
                                          IsAreaPreparationBoundaryRopeTape = true,
                                          IsAreaPreparationRadiationRope = true,
                                          AreaPreparationOtherDescription = "areaPreparationOtherDescription",
                                          IsLightingElectricalRequirementNotApplicable = true,
                                          IsLightingElectricalRequirementLowVoltage12V = false,
                                          IsLightingElectricalRequirement110VWithGFCI = false,
                                          IsLightingElectricalRequirementGeneratorLights = false,
                                          LightingElectricalRequirementOtherDescription = string.Empty
                                      };

            return jobWorksitePrep;
        }

        public static WorkPermitRadiationInformation CreateWorkPermitRadiationInformation()
        {
            var radiationInfo = new WorkPermitRadiationInformation
                                    {
                                        IsSealedSourceIsolationNotApplicable = false,
                                        IsSealedSourceIsolationLOTO = true,
                                        IsSealedSourceIsolationOpen = true,
                                        SealedSourceIsolationNumberOfSources = 99999                                        
                                    };
            return radiationInfo;
        }

        private static WorkPermitGasTests CreateWorkPermitGasTests(Site site)
        {
            var gasTests = new WorkPermitGasTests
                               {
                                   FrequencyOrDuration = "frequencyOrDuration",
                                   ConstantMonitoringRequired = true,
                                   ForkliftNotUsed = true,
                                   Elements = GasTestElementFixture.ElementListInTheOrderAppearedAsOnTheWorkSheet(site),
                                   ImmediateAreaTestTime = new Time(16, 34),
                                   ConfinedSpaceTestTime = new Time(16, 35)
                               };
            return gasTests;
        }

        public static WorkPermitFireConfinedSpaceRequirements CreateWorkPermitFireConfinedSpaceRequirements()
        {
            var fireRequirements = new WorkPermitFireConfinedSpaceRequirements
                                       {
                                           IsTwentyABCorDryChemicalExtinguisher = true,
                                           IsC02Extinguisher = true,
                                           IsFireResistantTarp = true,
                                           IsWatchmen = true,                                           
                                           OtherDescription = "Other Requirement Description xxx",
                                           IsSparkContainment = true,
                                           IsSteamHose = true,
                                           IsWaterHose = true
                                       };
            return fireRequirements;
        }

        public static WorkPermitRespiratoryProtectionRequirements CreateWorkPermitRespiratoryProtectionRequirements()
        {
            var respiratoryRequirements =
                new WorkPermitRespiratoryProtectionRequirements
                    {
                        IsAirCartorAirLine = true,
                        IsDustMask = true,
                        IsSCBA = true,
                        IsAirHood = true,
                        IsHalfFaceRespirator = true,
                        IsFullFaceRespirator = true,
                        OtherDescription = "Other Description xxx",
                        CartridgeTypeDescription = "Respiratory Cartridge Type xxx"
                    };

            return respiratoryRequirements;
        }

        public static WorkPermitSpecialPPERequirements CreateWorkPermitSpecialPPERequirements()
        {
            var specialPPERequirements = new WorkPermitSpecialPPERequirements
                                             {
                                                 IsEyeOrFaceProtectionGoggles = true,
                                                 IsEyeOrFaceProtectionFaceshield = true,
                                                 EyeOrFaceProtectionOtherDescription =
                                                     "EyeOrFaceProtectionOtherDescription xxx",                                                 
                                                 IsProtectiveClothingTypeRainCoat = true,
                                                 IsProtectiveClothingTypeRainPants = true,                                                 
                                                 IsProtectiveClothingTypeAcidClothing = true,
                                                 ProtectiveClothingTypeAcidClothingType =
                                                     AcidClothingTypeFixture.CreateAcidClothingTypeA(),
                                                 IsProtectiveClothingTypeCausticWear = true,
                                                 IsProtectiveClothingTypeTyvekSuit = true,
                                                 IsProtectiveClothingTypeKapplerSuit = true,
                                                 IsProtectiveClothingTypeElectricalFlashGear = true,
                                                 IsProtectiveClothingTypeCorrosiveClothing = true,
                                                 ProtectiveClothingTypeOtherDescription =
                                                     "ProtectiveClothingTypeOtherDescripton xxx",
                                                 IsProtectiveFootwearChemicalImperviousBoots = true,
                                                 IsProtectiveFootwearMetatarsalGuard = true,
                                                 IsProtectiveFootwearToeGuard = true,
                                                 ProtectiveFootwearOtherDescription =
                                                     "ProtectiveFootwearOtherDescription xxx",
                                                 IsHandProtectionChemicalNeoprene = true,
                                                 IsHandProtectionNaturalRubber = true,
                                                 IsHandProtectionNitrile = true,
                                                 IsHandProtectionPVC = true,
                                                 IsHandProtectionChemicalGloves = true,
                                                 IsHandProtectionHighVoltage = true,
                                                 IsHandProtectionWelding = true,
                                                 IsHandProtectionLeather = true,
                                                 HandProtectionOtherDescription = "HandProtectionOtherDescription xxx",
                                                 IsRescueOrFallBodyHarness = false,
                                                 IsRescueOrFallLifeline = true,
                                                 IsRescueOrFallYoYo = true,
                                                 IsRescueOrFallRescueDevice = true,
                                                 RescueOrFallOtherDescription = "RescueOrFallOtherDescription xxx",
                                                 FallRestraint = true,
                                                 FallSelfRetractingDevice = true,
                                                 FallTieoffRequired = true,
                                                 FallOtherDescription = "FallOtherDescription xxx"
                                             };

            return specialPPERequirements;
        }

        public static WorkPermit CreateWorkPermitWithWarning(long id, string permitNumber)
        {
            WorkPermit permit = CreateWorkPermitWithWarning(id);
            permit.PermitNumber = permitNumber;
            return permit;
        }
    }
}