using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;

namespace Com.Suncor.Olt.Client.Validation
{
    public class FullWorkPermitValidator:  AbstractNewWorkPermitValidator
    {
        public FullWorkPermitValidator(WorkPermit workPermit) : base(workPermit)
        {
        }

        private List<IValidation<WorkPermit>> BuildDenverRules()
        {
            const string specialPrecautionsOrConsiderationsDescriptionTextBoxName = "specialPrecautionsOrConsiderationsDescriptionTextBox";

            WorkPermitDenverReport report = new WorkPermitDenverReport();
            LabelAttributes attributesForPrecautionsLabel = report.GetAttributesForPrecautionsLabel();

            Predicate<WorkPermit>[] requireCommentsForTestBump = RequireCommentsForTestBumpPredicates();
            Predicate<WorkPermit>[] requireCommentsForContainsResidual = RequireCommentsForContainsResidualPredicates();
            Predicate<WorkPermit>[] requireCommentsForLeakingValves = RequireCommentsForLeakingValvesPredicates();
            Predicate<WorkPermit>[] requireCommentsForSurroundingConditions = RequireCommentsForSurroundingConditionsPredicates();

            string commentRequiredForApprovalMessage = BuildCommentRequiredForApprovalMessage(requireCommentsForTestBump, requireCommentsForContainsResidual, requireCommentsForLeakingValves, requireCommentsForSurroundingConditions);

            Predicate<WorkPermit>[] recommendCommentsForFlow = RecommendCommentsForFlowRequiredPredicates();
            Predicate<WorkPermit>[] recommendCommentsForBondingGrounding = RecommendCommentsForBondingGroundingPredicates();

            string commentRecommendedMessage = BuildCommentRecommendedMessage(recommendCommentsForFlow, recommendCommentsForBondingGrounding);

            return new List<IValidation<WorkPermit>>
                       {
                           BuildRequiredForSaveValidator("toolsOtherToolsDescriptionTextBoxCheckBox",
                                                         wp => wp.Tools.IsOtherTools,
                                                         wp => wp.Tools.OtherToolsDescription.IsNullOrEmptyOrWhitespace()),


                           BuildRequiredForSaveValidator("coAuthorizationRequiredNoRadioButton",
                                                         wp => wp.IsCoauthorizationRequired.HasNoValue()),

                        //BuildRequiredForSaveValidator("jobSitePreparationControlRoomContactedYesRadioButton",       // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
                        //                                 wp => wp.IsControlRoomContacted.HasFalseValue()),


                           BuildRequiredForSaveValidator(StringResources.DescriptionEmptyError,
                                                         "coAuthorizationRequiredDescriptionTextBox",
                                                         wp => wp.IsCoauthorizationRequired.HasTrueValue(),
                                                         wp => wp.CoauthorizationDescription.IsNullOrEmptyOrWhitespace()),
                           BuildRequiredForApprovalValidator("An End Date and Time is required for Approval", "permitDateTimesGroupBox",
                                                             wp => wp.Specifics.StartAndOrEndTimesFinalized == false),
                           BuildRequiredForSaveValidator("specialFallOtherCheckBoxTextBox",
                                          wp => wp.SpecialProtectionRequirements.FallOtherDescription != null,
                                          wp => wp.SpecialProtectionRequirements.FallOtherDescription.IsNullOrEmptyOrWhitespace()),
                           
                           BuildRequiredForApprovalValidator(commentRequiredForApprovalMessage,
                                specialPrecautionsOrConsiderationsDescriptionTextBoxName,
                                requireCommentsForTestBump),

                           BuildRequiredForApprovalValidator(commentRequiredForApprovalMessage,
                                specialPrecautionsOrConsiderationsDescriptionTextBoxName,
                                requireCommentsForContainsResidual),

                           BuildRequiredForApprovalValidator(commentRequiredForApprovalMessage,
                                specialPrecautionsOrConsiderationsDescriptionTextBoxName,
                                requireCommentsForLeakingValves),

                           BuildRequiredForApprovalValidator(commentRequiredForApprovalMessage,
                                specialPrecautionsOrConsiderationsDescriptionTextBoxName,
                                requireCommentsForSurroundingConditions),

                           BuildRequiredForApprovalValidator(WorkPermitSection.Tools,
                                                 wp => !wp.Tools.HasData()),

                           BuildRequiredForApprovalValidator(WorkPermitSection.RespiratoryProtectionRequirements,
                                                 wp => !wp.RespiratoryProtectionRequirements.HasNonCartridgeTypeData() && !wp.RespiratoryProtectionRequirements.IsNotApplicable),

                           BuildRequiredForApprovalValidator(WorkPermitSection.RadiationInformation,
                                                 wp => !wp.RadiationInformation.HasData() && !wp.RadiationInformation.IsSealedSourceIsolationNotApplicable),

                           BuildRequiredForApprovalValidator(WorkPermitSection.AdditionalForms,
                                                 wp => !wp.AdditionItemsRequired.HasData() && !wp.AdditionItemsRequired.IsNotApplicable),

                                                 BuildRequiredForApprovalValidator(WorkPermitSection.AdditionalForms,
                                                 wp => !wp.AdditionItemsRequired.HasData() && !wp.AdditionItemsRequired.NASecondSection),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                                         "equipmentElectricBumpTestGroupBox",
                                          wp => !wp.EquipmentPreparationCondition.IsTestBumpNotApplicable,
                                          wp => wp.EquipmentPreparationCondition.IsTestBump.HasNoValue()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                                          "equipmentLeakingValvesGroupBox",
                                          wp => !wp.EquipmentPreparationCondition.IsLeakingValvesNotApplicable,                                          
                                          wp => wp.EquipmentPreparationCondition.IsLeakingValves.HasNoValue()),
                           
                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                                          "equipmentStillContainsResidualValvesGroupBox",
                                          wp => !wp.EquipmentPreparationCondition.IsStillContainsResidualNotApplicable,                                          
                                          wp => wp.EquipmentPreparationCondition.IsStillContainsResidual.HasNoValue()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                                          "equipmentConditionGroupBox",
                                          wp => !wp.EquipmentPreparationCondition.IsConditionNotApplicable,
                                          wp => !wp.EquipmentPreparationCondition.HasEquipmentConditionsData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                                          "equipmentPreviousContentsGroupBox",
                                          wp => !wp.EquipmentPreparationCondition.IsPreviousContentsNotApplicable,
                                          wp => !wp.EquipmentPreparationCondition.HasPreviousContentsData()),
                           
                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                                          "equipmentIsolationMethodGroupBox",
                                          wp => !wp.EquipmentPreparationCondition.IsIsolationMethodNotApplicable,
                                          wp => !wp.EquipmentPreparationCondition.HasEquipmentIsolationMethodData()),
                           
                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                                          "electricIsolationMethodGroupBox",
                                          wp => !wp.EquipmentPreparationCondition.IsElectricalIsolationMethodNotApplicable,
                                          wp => !wp.EquipmentPreparationCondition.HasElectricalIsolationMethodData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                                          "jobSitePreparationVentilationMethodGroupBox",
                                          wp => !wp.EquipmentPreparationCondition.IsVentilationMethodNotApplicable,
                                          wp => !wp.EquipmentPreparationCondition.HasVentilationMethodData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                                          "jobSitePreparationBondingOrGroundingRequiredGroupBox",
                                          wp => !wp.JobWorksitePreparation.IsBondingOrGroundingRequiredNotApplicable,
                                          wp => wp.JobWorksitePreparation.IsBondingOrGroundingRequired.HasNoValue()),
                           
                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "jobSitePreparationSurroundingConditionsAffectOrContaminatedGroupBox",
                               wp => !wp.JobWorksitePreparation.IsSurroundingConditionsAffectOrContaminatedNotApplicable,
                               wp => !wp.JobWorksitePreparation.IsSurroundingConditionsAffectOrContaminated.HasValue),
                           
                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "jobsitePreparationFlowRequiredForJobGroupBox",
                               wp => !wp.JobWorksitePreparation.IsFlowRequiredForJobNotApplicable,
                               wp => !wp.JobWorksitePreparation.IsFlowRequiredForJob.HasValue),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "jobSitePreparationSewerIsolationMethodGroupBox",
                               wp => !wp.JobWorksitePreparation.IsSewerIsolationMethodNotApplicable,
                               wp => !wp.JobWorksitePreparation.HasSewerIsolationMethodData()),
                           
                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "jobSitePreparationAreaPreparationGroupBox",
                               wp => !wp.JobWorksitePreparation.IsAreaPreparationNotApplicable,
                               wp => !wp.JobWorksitePreparation.HasAreaPreparationData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "jobSitePreparationLightingElectricalRequirementGroupBox",
                               wp => !wp.JobWorksitePreparation.IsLightingElectricalRequirementNotApplicable,
                               wp => !wp.JobWorksitePreparation.HasLightingElectricalRequirementData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "specialEyeOrFaceProtectionGroupBox",
                               wp => !wp.SpecialProtectionRequirements.IsEyeOrFaceProtectionNotApplicable,
                               wp => !wp.SpecialProtectionRequirements.HasEyeOrFaceProtectionData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "specialProtectiveClothingTypeGroupBox",
                               wp => !wp.SpecialProtectionRequirements.IsProtectiveClothingTypeNotApplicable,
                               wp => !wp.SpecialProtectionRequirements.HasProtectiveClothingData()),
                         
                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "specialProtectiveFootwearGroupBox",
                               wp => !wp.SpecialProtectionRequirements.IsProtectiveFootwearNotApplicable,
                               wp => !wp.SpecialProtectionRequirements.HasProtectiveFootwearData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "specialHandProtectionGroupBox",
                               wp => !wp.SpecialProtectionRequirements.IsHandProtectionNotApplicable,
                               wp => !wp.SpecialProtectionRequirements.HasHandProtectionData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "specialRescueFallProtectionGroupBox",
                               wp => !wp.SpecialProtectionRequirements.IsRescueOrFallNotApplicable,
                               wp => !wp.SpecialProtectionRequirements.HasRescueProtectionData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "specialFallProtectionGroupBox",
                               wp => !wp.SpecialProtectionRequirements.HasFallProtectionData()),

                           BuildRequiredForApprovalValidator("A Start Time is required for Approval",
                                "startOltTimePicker",
                                wp => wp.Specifics.StartTimeNotApplicable),

                           BuildRequiredForApprovalValidator("The Start Time must be before the End Time.",
                                "startOltTimePicker",
                                wp => !wp.Specifics.StartTimeNotApplicable,
                                wp => wp.Specifics.StartAndOrEndTimesFinalized,
                                wp => wp.Specifics.StartDateTime > wp.Specifics.EndDateTime),

                           BuildRequiredForSaveValidator(
                               "jobSitePreparationLightingElectricalRequirementOtherDescriptionTextBoxCheckBox",
                               wp => !wp.JobWorksitePreparation.IsLightingElectricalRequirementNotApplicable,
                               wp => wp.JobWorksitePreparation.LightingElectricalRequirementOtherDescription.HasEmptyValue()),

                           BuildWarningValidator(StringResources.FieldTextIsTooLong, specialPrecautionsOrConsiderationsDescriptionTextBoxName, 
                                wp => !DevExpressMeasurementUtility.StringWillFitIntoField(attributesForPrecautionsLabel, wp.SpecialPrecautionsOrConsiderations)),
                               
                           BuildWarningValidator(commentRecommendedMessage, specialPrecautionsOrConsiderationsDescriptionTextBoxName,
                                recommendCommentsForFlow),

                           BuildWarningValidator(commentRecommendedMessage, specialPrecautionsOrConsiderationsDescriptionTextBoxName,
                                recommendCommentsForBondingGrounding),
                       };
        }

        //ayman USPipeline workpermit
        private List<IValidation<WorkPermit>> BuildUSPipelineRules()
        {
            const string specialPrecautionsOrConsiderationsDescriptionTextBoxName = "specialPrecautionsOrConsiderationsDescriptionTextBox";

            WorkPermitUSPipelineReport report = new WorkPermitUSPipelineReport();
            LabelAttributes attributesForPrecautionsLabel = report.GetAttributesForPrecautionsLabel();

            Predicate<WorkPermit>[] requireCommentsForTestBump = RequireCommentsForTestBumpPredicates();
            Predicate<WorkPermit>[] requireCommentsForContainsResidual = RequireCommentsForContainsResidualPredicates();
            Predicate<WorkPermit>[] requireCommentsForLeakingValves = RequireCommentsForLeakingValvesPredicates();
            Predicate<WorkPermit>[] requireCommentsForSurroundingConditions = RequireCommentsForSurroundingConditionsPredicates();

            string commentRequiredForApprovalMessage = BuildCommentRequiredForApprovalMessage(requireCommentsForTestBump, requireCommentsForContainsResidual, requireCommentsForLeakingValves, requireCommentsForSurroundingConditions);

            Predicate<WorkPermit>[] recommendCommentsForFlow = RecommendCommentsForFlowRequiredPredicates();
            Predicate<WorkPermit>[] recommendCommentsForBondingGrounding = RecommendCommentsForBondingGroundingPredicates();

            string commentRecommendedMessage = BuildCommentRecommendedMessage(recommendCommentsForFlow, recommendCommentsForBondingGrounding);

            return new List<IValidation<WorkPermit>>
                       {
                           BuildRequiredForSaveValidator("toolsOtherToolsDescriptionTextBoxCheckBox",
                                                         wp => wp.Tools.IsOtherTools,
                                                         wp => wp.Tools.OtherToolsDescription.IsNullOrEmptyOrWhitespace()),
                           BuildRequiredForSaveValidator("coAuthorizationRequiredNoRadioButton",
                                                         wp => wp.IsCoauthorizationRequired.HasNoValue()),

                                                         
                            BuildRequiredForSaveValidator(StringResources.ControlRoomContactedError,"jobSitePreparationControlRoomContactedYesRadioButton",       // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
                                                         wp => wp.IsControlRoomContacted.HasFalseValue(),
                                                         wp => wp.IsControlRoomContacted == null &&
                                                             ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID // Added by Vibhor : DMND0011077 - Work Permit Clone History

                                                         ),

                         BuildRequiredForSaveValidator(StringResources.ControlRoomContactedError,"jobSitePreparationControlRoomContactedNoRadioButton",       // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
                                                         wp => !wp.JobWorksitePreparation.IsControlRoomContactedNotApplicable,
                                                         wp => wp.IsControlRoomContacted == null &&
                                                         ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID // Added by Vibhor : DMND0011077 - Work Permit Clone History

                                                         ),
                                                         

                           BuildRequiredForSaveValidator(StringResources.DescriptionEmptyError,
                                                         "coAuthorizationRequiredDescriptionTextBox",
                                                         wp => wp.IsCoauthorizationRequired.HasTrueValue(),
                                                         wp => wp.CoauthorizationDescription.IsNullOrEmptyOrWhitespace()),
                           BuildRequiredForApprovalValidator("An End Date and Time is required for Approval", "permitDateTimesGroupBox",
                                                             wp => wp.Specifics.StartAndOrEndTimesFinalized == false),
                           BuildRequiredForSaveValidator("specialFallOtherCheckBoxTextBox",
                                          wp => wp.SpecialProtectionRequirements.FallOtherDescription != null,
                                          wp => wp.SpecialProtectionRequirements.FallOtherDescription.IsNullOrEmptyOrWhitespace()),

                           BuildRequiredForApprovalValidator(commentRequiredForApprovalMessage,
                                specialPrecautionsOrConsiderationsDescriptionTextBoxName,
                                requireCommentsForTestBump),

                           BuildRequiredForApprovalValidator(commentRequiredForApprovalMessage,
                                specialPrecautionsOrConsiderationsDescriptionTextBoxName,
                                requireCommentsForContainsResidual),

                           BuildRequiredForApprovalValidator(commentRequiredForApprovalMessage,
                                specialPrecautionsOrConsiderationsDescriptionTextBoxName,
                                requireCommentsForLeakingValves),

                           BuildRequiredForApprovalValidator(commentRequiredForApprovalMessage,
                                specialPrecautionsOrConsiderationsDescriptionTextBoxName,
                                requireCommentsForSurroundingConditions),

                           BuildRequiredForApprovalValidator(WorkPermitSection.Tools,
                                                 wp => !wp.Tools.HasData()),

                           BuildRequiredForApprovalValidator(WorkPermitSection.RespiratoryProtectionRequirements,
                                                 wp => !wp.RespiratoryProtectionRequirements.HasNonCartridgeTypeData() && !wp.RespiratoryProtectionRequirements.IsNotApplicable),

                           BuildRequiredForApprovalValidator(WorkPermitSection.RadiationInformation,
                                                 wp => !wp.RadiationInformation.HasData() && !wp.RadiationInformation.IsSealedSourceIsolationNotApplicable),

                           BuildRequiredForApprovalValidator(WorkPermitSection.AdditionalForms,
                                                 wp => !wp.AdditionItemsRequired.HasData() && !wp.AdditionItemsRequired.IsNotApplicable),

                                                 BuildRequiredForApprovalValidator(WorkPermitSection.AdditionalForms,
                                                 wp => !wp.AdditionItemsRequired.HasData() && !wp.AdditionItemsRequired.NASecondSection),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                                         "equipmentElectricBumpTestGroupBox",
                                          wp => !wp.EquipmentPreparationCondition.IsTestBumpNotApplicable,
                                          wp => wp.EquipmentPreparationCondition.IsTestBump.HasNoValue()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                                          "equipmentLeakingValvesGroupBox",
                                          wp => !wp.EquipmentPreparationCondition.IsLeakingValvesNotApplicable,
                                          wp => wp.EquipmentPreparationCondition.IsLeakingValves.HasNoValue()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                                          "equipmentStillContainsResidualValvesGroupBox",
                                          wp => !wp.EquipmentPreparationCondition.IsStillContainsResidualNotApplicable,
                                          wp => wp.EquipmentPreparationCondition.IsStillContainsResidual.HasNoValue()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                                          "equipmentConditionGroupBox",
                                          wp => !wp.EquipmentPreparationCondition.IsConditionNotApplicable,
                                          wp => !wp.EquipmentPreparationCondition.HasEquipmentConditionsData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                                          "equipmentPreviousContentsGroupBox",
                                          wp => !wp.EquipmentPreparationCondition.IsPreviousContentsNotApplicable,
                                          wp => !wp.EquipmentPreparationCondition.HasPreviousContentsData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                                          "equipmentIsolationMethodGroupBox",
                                          wp => !wp.EquipmentPreparationCondition.IsIsolationMethodNotApplicable,
                                          wp => !wp.EquipmentPreparationCondition.HasEquipmentIsolationMethodData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                                          "electricIsolationMethodGroupBox",
                                          wp => !wp.EquipmentPreparationCondition.IsElectricalIsolationMethodNotApplicable,
                                          wp => !wp.EquipmentPreparationCondition.HasElectricalIsolationMethodData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                                          "jobSitePreparationVentilationMethodGroupBox",
                                          wp => !wp.EquipmentPreparationCondition.IsVentilationMethodNotApplicable,
                                          wp => !wp.EquipmentPreparationCondition.HasVentilationMethodData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                                          "jobSitePreparationBondingOrGroundingRequiredGroupBox",
                                          wp => !wp.JobWorksitePreparation.IsBondingOrGroundingRequiredNotApplicable,
                                          wp => wp.JobWorksitePreparation.IsBondingOrGroundingRequired.HasNoValue()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "jobSitePreparationSurroundingConditionsAffectOrContaminatedGroupBox",
                               wp => !wp.JobWorksitePreparation.IsSurroundingConditionsAffectOrContaminatedNotApplicable,
                               wp => !wp.JobWorksitePreparation.IsSurroundingConditionsAffectOrContaminated.HasValue),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "jobsitePreparationFlowRequiredForJobGroupBox",
                               wp => !wp.JobWorksitePreparation.IsFlowRequiredForJobNotApplicable,
                               wp => !wp.JobWorksitePreparation.IsFlowRequiredForJob.HasValue),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "jobSitePreparationSewerIsolationMethodGroupBox",
                               wp => !wp.JobWorksitePreparation.IsSewerIsolationMethodNotApplicable,
                               wp => !wp.JobWorksitePreparation.HasSewerIsolationMethodData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "jobSitePreparationAreaPreparationGroupBox",
                               wp => !wp.JobWorksitePreparation.IsAreaPreparationNotApplicable,
                               wp => !wp.JobWorksitePreparation.HasAreaPreparationData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "jobSitePreparationLightingElectricalRequirementGroupBox",
                               wp => !wp.JobWorksitePreparation.IsLightingElectricalRequirementNotApplicable,
                               wp => !wp.JobWorksitePreparation.HasLightingElectricalRequirementData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "specialEyeOrFaceProtectionGroupBox",
                               wp => !wp.SpecialProtectionRequirements.IsEyeOrFaceProtectionNotApplicable,
                               wp => !wp.SpecialProtectionRequirements.HasEyeOrFaceProtectionData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "specialProtectiveClothingTypeGroupBox",
                               wp => !wp.SpecialProtectionRequirements.IsProtectiveClothingTypeNotApplicable,
                               wp => !wp.SpecialProtectionRequirements.HasProtectiveClothingData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "specialProtectiveFootwearGroupBox",
                               wp => !wp.SpecialProtectionRequirements.IsProtectiveFootwearNotApplicable,
                               wp => !wp.SpecialProtectionRequirements.HasProtectiveFootwearData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "specialHandProtectionGroupBox",
                               wp => !wp.SpecialProtectionRequirements.IsHandProtectionNotApplicable,
                               wp => !wp.SpecialProtectionRequirements.HasHandProtectionData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "specialRescueFallProtectionGroupBox",
                               wp => !wp.SpecialProtectionRequirements.IsRescueOrFallNotApplicable,
                               wp => !wp.SpecialProtectionRequirements.HasRescueProtectionData()),

                           BuildRequiredForApprovalValidator(StringResources.WorkPermit_SectionEmptyError,
                               "specialFallProtectionGroupBox",
                               wp => !wp.SpecialProtectionRequirements.HasFallProtectionData()),

                           BuildRequiredForApprovalValidator("A Start Time is required for Approval",
                                "startOltTimePicker",
                                wp => wp.Specifics.StartTimeNotApplicable),

                           BuildRequiredForApprovalValidator("The Start Time must be before the End Time.",
                                "startOltTimePicker",
                                wp => !wp.Specifics.StartTimeNotApplicable,
                                wp => wp.Specifics.StartAndOrEndTimesFinalized,
                                wp => wp.Specifics.StartDateTime > wp.Specifics.EndDateTime),

                           BuildRequiredForSaveValidator(
                               "jobSitePreparationLightingElectricalRequirementOtherDescriptionTextBoxCheckBox",
                               wp => !wp.JobWorksitePreparation.IsLightingElectricalRequirementNotApplicable,
                               wp => wp.JobWorksitePreparation.LightingElectricalRequirementOtherDescription.HasEmptyValue()),

                           BuildWarningValidator(StringResources.FieldTextIsTooLong, specialPrecautionsOrConsiderationsDescriptionTextBoxName,
                                wp => !DevExpressMeasurementUtility.StringWillFitIntoField(attributesForPrecautionsLabel, wp.SpecialPrecautionsOrConsiderations)),

                           BuildWarningValidator(commentRecommendedMessage, specialPrecautionsOrConsiderationsDescriptionTextBoxName,
                                recommendCommentsForFlow),

                           BuildWarningValidator(commentRecommendedMessage, specialPrecautionsOrConsiderationsDescriptionTextBoxName,
                                recommendCommentsForBondingGrounding),
                       };
        }

        private static List<IValidation<WorkPermit>> BuildSarniaRules()
        {
            return new List<IValidation<WorkPermit>>
                       {
                           BuildRequiredForSaveValidator("jobSitePreparationVestedBuddySystemInEffectNoRadioButton",
                                          wp =>
                                          !wp.JobWorksitePreparation.
                                               IsVestedBuddySystemInEffectNotApplicable,
                                          wp =>
                                          !wp.JobWorksitePreparation.IsVestedBuddySystemInEffect.
                                               HasValue),
//Amit Shukla RITM0302870 Validation Workpermit on validate button click
                           BuildRequiredForSaveValidator(
                               "respiratoryProtectionRequirementsRespiratoryCartridgeTypeTextBox",
                               wp => wp.RespiratoryProtectionRequirements.IsFaceRespirator,
                               wp =>
                               wp.RespiratoryProtectionRequirements.CartridgeTypeDescription.IsNullOrEmptyOrWhitespace()),
                           BuildRequiredForSaveValidator("additionalOtherDescriptionTextBoxCheckBox",
                                                         wp => wp.AdditionItemsRequired.IsOtherItemDescription,
                                                         wp =>
                                                         wp.AdditionItemsRequired.OtherItemDescription.IsNullOrEmptyOrWhitespace()),


                          BuildRequiredForSaveValidator("additionalWaiverOrDeviationTextBoxCheckBox",                   //vibhor
                                                         wp => wp.AdditionItemsRequired.IsWaiverOrDeviation,
                                                         wp =>
                                                         wp.AdditionItemsRequired.WaiverOrDeviationDescription.IsNullOrEmptyOrWhitespace()),

                                                         

                           BuildRequiredForSaveValidator(
                               "jobSitePreparationCriticalConditionsRemainJobSiteNoRadioButton",
                               wp =>
                               !wp.JobWorksitePreparation.
                                    IsCriticalConditionRemainJobSiteNotApplicable,
                               wp =>
                               wp.JobWorksitePreparation.IsCriticalConditionRemainJobSite.
                                    DoesNotHaveAValue()),
                           BuildRequiredForSaveValidator("criticalConditionsCommentsTextBox",
                                          wp =>
                                          !wp.JobWorksitePreparation.
                                               IsCriticalConditionRemainJobSiteNotApplicable,
                                          wp =>
                                          wp.JobWorksitePreparation.
                                              IsCriticalConditionRemainJobSite.HasTrueValue(),
                                          wp =>
                                          wp.JobWorksitePreparation.
                                              CriticalConditionsComments.IsNullOrEmptyOrWhitespace()),
                           BuildRequiredForSaveValidator(
                               "jobSitePreparationPermitReceiverFieldOrEquipmentOrientationNoRadioButton",
                               wp =>
                               !wp.JobWorksitePreparation.
                                    IsPermitReceiverFieldOrEquipmentOrientationNotApplicable,
                               wp =>
                               !wp.JobWorksitePreparation.IsPermitReceiverFieldOrEquipmentOrientation.
                                    HasValue),


                                    //DMND0010814 / RITM0422801 : Added By Vibhor - Sarnia SWP New Changes

                                     BuildRequiredForSaveValidator("permitReceiverRequiresOrientationCommentsTextBox",
                           
                                          wp => (wp.EquipmentPreparationCondition.LockOutMethod != null && Equals(
                                              wp.EquipmentPreparationCondition.LockOutMethod, WorkPermitLockOutMethodType.INDIVIDUAL_BY_OPERATIONS)) &&

                                              (wp.JobWorksitePreparation.IsPermitReceiverFieldOrEquipmentOrientationNotApplicable || 
                                              wp.JobWorksitePreparation.IsPermitReceiverFieldOrEquipmentOrientation.HasFalseValue() 
                                              )
                                              ,
                                          wp => (wp.JobWorksitePreparation.PermitReceiverRequiresOrientationComments.IsNullOrEmptyOrWhitespace() &&  
                                              (wp.JobWorksitePreparation.IsPermitReceiverFieldOrEquipmentOrientationNotApplicable || 
                                              wp.JobWorksitePreparation.IsPermitReceiverFieldOrEquipmentOrientation.HasFalseValue() 
                                              ))
                                          ),

                        BuildRequiredForSaveValidator("permitReceiverRequiresOrientationCommentsTextBox",
                                          wp =>!wp.JobWorksitePreparation.IsPermitReceiverFieldOrEquipmentOrientationNotApplicable,
                                          wp =>wp.JobWorksitePreparation.IsPermitReceiverFieldOrEquipmentOrientation.HasTrueValue(),
                                          wp => wp.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequired.HasFalseValue(),
                                          wp =>wp.JobWorksitePreparation.PermitReceiverRequiresOrientationComments.IsNullOrEmptyOrWhitespace()),

                                          

                                           BuildRequiredForSaveValidator("permitReceiverRequiresOrientationCommentsTextBox",

                                              wp => (wp.EquipmentPreparationCondition.LockOutMethod != null && Equals(
                                              wp.EquipmentPreparationCondition.LockOutMethod, WorkPermitLockOutMethodType.COMPLEX_GROUP)) &&
                                              (wp.JobWorksitePreparation.IsPermitReceiverFieldOrEquipmentOrientationNotApplicable || 
                                              wp.JobWorksitePreparation.IsPermitReceiverFieldOrEquipmentOrientation.HasFalseValue())
                                              ,
                                          wp => wp.JobWorksitePreparation.PermitReceiverRequiresOrientationComments.IsNullOrEmptyOrWhitespace()),


                                          BuildRequiredForSaveValidator("permitReceiverRequiresOrientationCommentsTextBox",

                                              wp => (wp.EquipmentPreparationCondition.LockOutMethod != null && Equals(
                                              wp.EquipmentPreparationCondition.LockOutMethod, WorkPermitLockOutMethodType.INDIVIDUAL_BY_WORKER)) &&
                                              wp.JobWorksitePreparation.IsPermitReceiverFieldOrEquipmentOrientation.HasTrueValue() &&
                                              !wp.JobWorksitePreparation.IsPermitReceiverFieldOrEquipmentOrientationNotApplicable,
                                              
                                          wp => wp.JobWorksitePreparation.PermitReceiverRequiresOrientationComments.IsNullOrEmptyOrWhitespace()),
                                          
                           
//END
                                                                     BuildRequiredForSaveValidator("bondingGroundingNotRequiredCommentsTextBox",
                                          wp =>
                                          !wp.JobWorksitePreparation.IsBondingOrGroundingRequiredNotApplicable,
                                          wp =>
                                          wp.JobWorksitePreparation.IsBondingOrGroundingRequired.HasFalseValue(),
                                          wp =>
                                          wp.JobWorksitePreparation.BondingGroundingNotRequiredComments.IsNullOrEmptyOrWhitespace()),
                           BuildRequiredForSaveValidator("jobSitePreparationWeldingGroundWireInTestAreaNoRadioButton",
                                          wp =>
                                          !wp.JobWorksitePreparation.IsWeldingGroundWireInTestAreaNotApplicable,
                                          wp =>
                                          wp.JobWorksitePreparation.IsWeldingGroundWireInTestArea.HasNoValue()),
                           BuildRequiredForSaveValidator("weldingGroundWireNotWithinGasTestAreaCommentsTextBox",
                                          wp =>
                                          !wp.JobWorksitePreparation.IsWeldingGroundWireInTestAreaNotApplicable,
                                          wp =>
                                          wp.JobWorksitePreparation.IsWeldingGroundWireInTestArea.HasFalseValue(),
                                          wp =>
                                          wp.JobWorksitePreparation.
                                              WeldingGroundWireNotWithinGasTestAreaComments.IsNullOrEmptyOrWhitespace()),
                           BuildRequiredForSaveValidator("equipmentIsHazardousEnergyIsolationRequiredNoRadioButton",
                                          wp => !wp.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequiredNotApplicable,
                                          wp => wp.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequired.HasNoValue()),

                           BuildRequiredForSaveValidator(StringResources.LockOutMethodRequired, "lockOutMethodGroupBox",
                                          wp => !wp.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequiredNotApplicable,
                                          wp => wp.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequired.HasTrueValue(),
                                          wp => wp.EquipmentPreparationCondition.LockOutMethod == null),

                           BuildRequiredForSaveValidator("equipmentLockOutMethodIndividualByWorkerCommentsTextBox",
                                          wp => !wp.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequiredNotApplicable,
                                          wp => wp.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequired.HasTrueValue(),
                                          wp => wp.EquipmentPreparationCondition.LockOutMethod != null && Equals(wp.EquipmentPreparationCondition.LockOutMethod, WorkPermitLockOutMethodType.INDIVIDUAL_BY_WORKER),
                                          wp => wp.EquipmentPreparationCondition.LockOutMethodComments.IsNullOrEmptyOrWhitespace()),
                           BuildRequiredForSaveValidator("equipmentLockOutMethodIndividualByOperationsCommentsTextBox",
                                          wp => !wp.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequiredNotApplicable,
                                          wp => wp.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequired.HasTrueValue(),
                                          wp => wp.EquipmentPreparationCondition.LockOutMethod != null && Equals(wp.EquipmentPreparationCondition.LockOutMethod, WorkPermitLockOutMethodType.INDIVIDUAL_BY_OPERATIONS),
                                          wp => wp.EquipmentPreparationCondition.LockOutMethodComments.IsNullOrEmptyOrWhitespace()),
                           BuildRequiredForSaveValidator("equipmentEIPNumberTextBox",
                                          wp => !wp.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequiredNotApplicable,
                                          wp => wp.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequired.HasTrueValue(),
                                          wp => wp.EquipmentPreparationCondition.LockOutMethod != null && Equals(wp.EquipmentPreparationCondition.LockOutMethod, WorkPermitLockOutMethodType.COMPLEX_GROUP),
                                          wp => wp.EquipmentPreparationCondition.EnergyIsolationPlanNumber.IsNullOrEmptyOrWhitespace()),
                           BuildRequiredForSaveValidator("equipmentConditionsOfEIPSatisfiedNoRadioButton",
                                          wp => !wp.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequiredNotApplicable,
                                          wp => wp.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequired.HasTrueValue(),
                                          wp => wp.EquipmentPreparationCondition.LockOutMethod != null && Equals(wp.EquipmentPreparationCondition.LockOutMethod, WorkPermitLockOutMethodType.COMPLEX_GROUP),
                                          wp => wp.EquipmentPreparationCondition.ConditionsOfEIPSatisfied.HasNoValue()),
                           BuildRequiredForSaveValidator("equipmentConditionsOfEIPNotSatisfiedCommentsTextBox",
                                          wp => !wp.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequiredNotApplicable,
                                          wp => wp.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequired.HasTrueValue(),
                                          wp => wp.EquipmentPreparationCondition.LockOutMethod != null && Equals(wp.EquipmentPreparationCondition.LockOutMethod, WorkPermitLockOutMethodType.COMPLEX_GROUP),
                                          wp => wp.EquipmentPreparationCondition.ConditionsOfEIPSatisfied.HasFalseValue(),
                                          wp => wp.EquipmentPreparationCondition.ConditionsOfEIPNotSatisfiedComments.IsNullOrEmptyOrWhitespace()),
                           BuildRequiredForSaveValidator(StringResources.WorkPermitMustSelectAtLeastOneEquipmentCondition, "equipmentConditionGroupBox",
                                          wp => !wp.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequiredNotApplicable,
                                          wp => wp.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequired.HasTrueValue(),
                                          wp => !wp.EquipmentPreparationCondition.HasEquipmentConditionsData()),
                           BuildRequiredForSaveValidator("asbestosHazardsConsideredNoRadioButton",
                                          wp => !wp.Asbestos.HazardsConsideredNotApplicable,
                                          wp => wp.Asbestos.HazardsConsidered.HasNoValue()),
                           BuildRequiredForSaveValidator("equipmentEquipmentInServiceRadioButton",
                                          wp => !wp.EquipmentPreparationCondition.IsOutOfService.HasValue),
                           BuildRequiredForSaveValidator("equipmentConditionOtherDescriptionTextBoxCheckBox",
                                          wp => !wp.EquipmentPreparationCondition.IsConditionNotApplicable,
                                          wp => wp.EquipmentPreparationCondition.ConditionOtherDescription.HasEmptyValue()),
                           BuildRequiredForSaveValidator("stillContainsResidualCommentsTextBox",
                                          wp => !wp.EquipmentPreparationCondition.IsStillContainsResidualNotApplicable,                                          
                                          wp => wp.EquipmentPreparationCondition.IsStillContainsResidual.HasValue,                                          
                                          wp => wp.EquipmentPreparationCondition.IsStillContainsResidual.Value,                                          
                                          wp => wp.EquipmentPreparationCondition.StillContainsResidualComments.IsNullOrEmptyOrWhitespace()),                                          
                           BuildRequiredForSaveValidator("leakingValvesCommentsTextBox",
                                          wp => !wp.EquipmentPreparationCondition.IsLeakingValvesNotApplicable,                                          
                                          wp => wp.EquipmentPreparationCondition.IsLeakingValves.HasValue,                                          
                                          wp => wp.EquipmentPreparationCondition.IsLeakingValves.Value,
                                          wp => wp.EquipmentPreparationCondition.LeakingValvesComments.IsNullOrEmptyOrWhitespace()),
                           BuildRequiredForSaveValidator("surroundingConditionsAffectAreaCommentsTextBox",
                                          wp =>
                                          !wp.JobWorksitePreparation.
                                               IsSurroundingConditionsAffectOrContaminatedNotApplicable,
                                          wp =>
                                          wp.JobWorksitePreparation.IsSurroundingConditionsAffectOrContaminated.
                                              HasTrueValue(),
                                          wp =>
                                          wp.JobWorksitePreparation.SurroundingConditionsAffectAreaComments.IsNullOrEmptyOrWhitespace()),
                   
                           BuildRequiredForSaveValidator("equipmentLeakingValvesNoRadioButton",
                                          wp => !wp.EquipmentPreparationCondition.IsLeakingValvesNotApplicable,                                          
                                          wp => wp.EquipmentPreparationCondition.IsLeakingValves.HasNoValue()),
                           BuildRequiredForSaveValidator("equipmentStillContainsResidualNoRadioButton",
                                          wp => !wp.EquipmentPreparationCondition.IsStillContainsResidualNotApplicable,                                          
                                          wp => wp.EquipmentPreparationCondition.IsStillContainsResidual.HasNoValue()),                           
                           BuildRequiredForSaveValidator("jobSitePreparationBondingOrGroundingRequiredNoRadioButton",
                                          wp => !wp.JobWorksitePreparation.IsBondingOrGroundingRequiredNotApplicable,                                          
                                          wp => wp.JobWorksitePreparation.IsBondingOrGroundingRequired.HasNoValue()),                                          
                           BuildRequiredForSaveValidator(
                               "jobSitePreparationSurroundingConditionsAffectOrContaminatedNoRadioButton",
                               wp => !wp.JobWorksitePreparation.IsSurroundingConditionsAffectOrContaminatedNotApplicable,
                               wp => !wp.JobWorksitePreparation.IsSurroundingConditionsAffectOrContaminated.HasValue)
                               
                                    
                       };
        }

        private static List<IValidation<WorkPermit>> BuildJobWorksitePrepRules()
        {
            return new List<IValidation<WorkPermit>>
                       {
                           BuildRequiredForSaveValidator(
                               "jobSitePreparationSewerIsolationMethodOtherDescriptionTextBoxCheckBox",
                               wp => !wp.JobWorksitePreparation.IsSewerIsolationMethodNotApplicable,
                               wp =>
                               wp.JobWorksitePreparation.SewerIsolationMethodOtherDescription.HasEmptyValue()),
                           BuildRequiredForSaveValidator(
                               "jobSitePreparationAreaPreparationOtherDescriptionTextBoxCheckBox",
                               wp => !wp.JobWorksitePreparation.IsAreaPreparationNotApplicable,
                               wp =>
                               wp.JobWorksitePreparation.AreaPreparationOtherDescription.HasEmptyValue()),
                          // //Amit Shukla RITM0302870 Validation Workpermit on validate button click
                          // INC0388292  validation was getting applied for denver which they don't want hence moved code to function BuildSpecialProtectionRequirementsRulesForSarnia(); 12-mar-2019
                          //BuildRequiredForSaveValidator(StringResources.WorkPermit_SectionEmptyError,
                          //     "jobSitePreparationAreaPreparationGroupBox",
                          //     wp => !wp.JobWorksitePreparation.IsAreaPreparationNotApplicable,
                          //     wp => !wp.JobWorksitePreparation.HasAreaPreparationData()),
                          //BuildRequiredForSaveValidator(StringResources.WorkPermit_SectionEmptyError,
                          //     "jobSitePreparationSewerIsolationMethodGroupBox",
                          //     wp => !wp.JobWorksitePreparation.IsSewerIsolationMethodNotApplicable,
                          //     wp => !wp.JobWorksitePreparation.HasSewerIsolationMethodData())
                       };
        }


        private static List<IValidation<WorkPermit>> BuildEquipmentPrepRules()
        {
            return new List<IValidation<WorkPermit>>
                       {
                           BuildRequiredForSaveValidator("equipmentPreviousContentsOtherDescriptionTextBoxCheckBox",
                                          wp => !wp.EquipmentPreparationCondition.IsPreviousContentsNotApplicable,
                                          wp => wp.EquipmentPreparationCondition.PreviousContentsOtherDescription.HasEmptyValue()),

                           BuildRequiredForSaveValidator("equipmentIsolationMethodOtherDescriptionTextBoxCheckBox",
                                          wp => !wp.EquipmentPreparationCondition.IsIsolationMethodNotApplicable,                                          
                                          wp => wp.EquipmentPreparationCondition.IsolationMethodOtherDescription.HasEmptyValue()),   
                                                                                     
                           BuildRequiredForSaveValidator(StringResources.DescriptionEmptyError, "equipmentConditionPurgedMethodTextBox",
                                          wp => !wp.EquipmentPreparationCondition.IsConditionNotApplicable,
                                          wp => wp.EquipmentPreparationCondition.IsConditionPurged,
                                          wp =>
                                          wp.EquipmentPreparationCondition.ConditionPurgedDescription.IsNullOrEmptyOrWhitespace()),

                                           // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 

                                          BuildRequiredForSaveValidator("AsbestosHazardCommentsTextBox", 
                                          wp => wp.Asbestos.HazardsConsidered.HasTrueValue(),
                                          wp => !wp.Asbestos.HazardsConsideredNotApplicable,
                                          wp => wp.EquipmentPreparationCondition.InAsbestosHazardPresentComments.IsNullOrEmptyOrWhitespace()),


                          //RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                          
                           //BuildRequiredForSaveValidator("HazardousEnergyCommentsTextBox", 
                           //               wp => wp.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequiredSelected && wp.JobWorksitePreparation.IsPermitReceiverFieldOrEquipmentOrientationNotApplicable,
                           //               //wp => wp.JobWorksitePreparation.IsPermitReceiverFieldOrEquipmentOrientationNotApplicable,
                           //               wp => wp.JobWorksitePreparation.IsPermitReceiverFieldOrEquipmentOrientation.HasValue,
                           //               wp => wp.EquipmentPreparationCondition.InHazardousEnergyIsolationComments.IsNullOrEmptyOrWhitespace()
                           //               ),
                            
                           
                           BuildRequiredForSaveValidator("equipmentInServiceCommentsTextBox",
                                          wp => wp.EquipmentPreparationCondition.IsOutOfService.HasValue,
                                          wp => !wp.EquipmentPreparationCondition.IsOutOfService.Value,
                                          wp =>
                                          wp.EquipmentPreparationCondition.InServiceComments.IsNullOrEmptyOrWhitespace()),

                          
                                          

                           //               //Amit Shukla RITM0302870 Validation Workpermit on validate button click 
                          // INC0388292  validation was getting applied for denver which they don't want hence moved code to function BuildSpecialProtectionRequirementsRulesForSarnia(); 12-mar-2019
                           //BuildRequiredForSaveValidator(StringResources.WorkPermit_SectionEmptyError,
                           //               "equipmentPreviousContentsGroupBox",
                           //               wp => !wp.EquipmentPreparationCondition.IsPreviousContentsNotApplicable,
                           //               wp => !wp.EquipmentPreparationCondition.HasPreviousContentsData()),
                           //BuildRequiredForSaveValidator(StringResources.WorkPermit_SectionEmptyError,
                           //               "equipmentConditionGroupBox",
                           //               wp => !wp.EquipmentPreparationCondition.IsConditionNotApplicable,
                           //               wp => !wp.EquipmentPreparationCondition.HasEquipmentConditionsData()),
                           //BuildRequiredForSaveValidator(StringResources.WorkPermit_SectionEmptyError,
                           //               "jobSitePreparationVentilationMethodGroupBox",
                           //               wp => !wp.EquipmentPreparationCondition.IsVentilationMethodNotApplicable,
                           //               wp => !wp.EquipmentPreparationCondition.HasVentilationMethodData()),
                       };
        }

        protected override List<IValidation<WorkPermit>> BuildValidationRules()
        {
            var rules = new List<IValidation<WorkPermit>>();

            UserContext userContext = ClientSession.GetUserContext();
            if (Site.DENVER_ID == userContext.SiteId)
            {
                rules.AddRange(BuildDenverRules());
                rules.AddRange(BuildSpecialProtectionRequirementsRulesForDenver());
            }
            else if (Site.SARNIA_ID == userContext.SiteId)
            {
                rules.AddRange(BuildSarniaRules());
                rules.AddRange(BuildSpecialProtectionRequirementsRulesForSarnia());
            }
            else if (Site.USPipeline_ID == userContext.SiteId)         //ayman USPipeline workpermit
            {
                rules.AddRange(BuildUSPipelineRules());
                rules.AddRange(BuildSpecialProtectionRequirementsRulesForUSPipeline());
            }
            else if (Site.SELC_ID == userContext.SiteId)         //mangesh uspipeline to selc
            {
                rules.AddRange(BuildUSPipelineRules());
                rules.AddRange(BuildSpecialProtectionRequirementsRulesForUSPipeline());
            }
            rules.AddRange(BuildEquipmentPrepRules());
            rules.AddRange(BuildJobWorksitePrepRules());

            rules.AddRange(BuildCommunicationMethodsRules());
            

            rules.AddRange(BuildOtherRules());
            return rules;
        }

        private static List<IValidation<WorkPermit>> BuildOtherRules()
        {
            return new List<IValidation<WorkPermit>>
                       {
                           BuildRequiredForSaveValidator("fireConfinedSpaceOtherDescriptionTextBoxCheckBox",
                                                         wp =>
                                                         wp.FireConfinedSpaceRequirements.OtherDescription !=
                                                         null,
                                                         wp =>
                                                         wp.FireConfinedSpaceRequirements.
                                                             OtherDescription.IsNullOrEmptyOrWhitespace()),
                           BuildRequiredForSaveValidator(
                               "respiratoryProtectionRequirementsOtherDescriptionTextBoxCheckBox",
                               wp => wp.RespiratoryProtectionRequirements.OtherDescription != null,
                               wp =>
                               wp.RespiratoryProtectionRequirements.OtherDescription.IsNullOrEmptyOrWhitespace())
                       };
        }

        private static List<IValidation<WorkPermit>> BuildSpecialProtectionRequirementsRulesForSarnia()
        {
            return new List<IValidation<WorkPermit>>
                       {
                           BuildRequiredForSaveValidator("specialEyeOrFaceProtectionOtherDescriptionTextBoxCheckBox",
                                          wp =>
                                          wp.SpecialProtectionRequirements.
                                              EyeOrFaceProtectionOtherDescription != null ,
                                          wp =>
                                          wp.SpecialProtectionRequirements.
                                              EyeOrFaceProtectionOtherDescription.IsNullOrEmptyOrWhitespace()),
            //Amit Shukla RITM0302870 Validation Workpermit on validate button click start
            BuildRequiredForSaveValidator("fireConfinedSpaceProtectionGroupBox",
                                                         wp => !wp.FireConfinedSpaceRequirements.IsNotApplicable,
                                                         wp => !wp.FireConfinedSpaceRequirements.HasData()),

           BuildRequiredForSaveValidator("respiratoryProtectionRequirementsOtherDescriptionTextBoxCheckBox",
                               wp => !wp.RespiratoryProtectionRequirements.IsNotApplicable,
                               wp => !wp.RespiratoryProtectionRequirements.HasData()),

                            BuildRequiredForSaveValidator(StringResources.WorkPermit_SectionEmptyError,
                               "specialEyeOrFaceProtectionGroupBox",
                               wp => !wp.SpecialProtectionRequirements.IsEyeOrFaceProtectionNotApplicable,
                               wp => !wp.SpecialProtectionRequirements.HasEyeOrFaceProtectionData()),


                           BuildRequiredForSaveValidator(StringResources.WorkPermit_SectionEmptyError,"protectiveClothingControl",
                                          wp => !wp.SpecialProtectionRequirements.IsProtectiveClothingTypeNotApplicable,
                                          wp => !wp.SpecialProtectionRequirements.HasProtectiveClothingData()),

                           BuildRequiredForSaveValidator(StringResources.WorkPermit_SectionEmptyError,"specialProtectiveFootwearGroupBox",
                                          wp => !wp.SpecialProtectionRequirements.IsProtectiveFootwearNotApplicable,
                                          wp => !wp.SpecialProtectionRequirements.HasProtectiveFootwearData()),

                           BuildRequiredForSaveValidator(StringResources.WorkPermit_SectionEmptyError,"specialHandProtectionGroupBox",
                                          wp => !wp.SpecialProtectionRequirements.IsHandProtectionNotApplicable,
                                          wp => !wp.SpecialProtectionRequirements.HasHandProtectionData()),
          
                           BuildRequiredForSaveValidator(StringResources.WorkPermit_SectionEmptyError,"specialRescueFallProtectionGroupBox",
                                          wp => !wp.SpecialProtectionRequirements.IsRescueOrFallNotApplicable,
                                          wp => !wp.SpecialProtectionRequirements.HasRescueProtectionData()),

                           BuildRequiredForSaveValidator("coAuthorizationRequiredNoRadioButton",
                                                         wp => wp.IsCoauthorizationRequired.HasNoValue()),

                                                         
                            BuildRequiredForSaveValidator(StringResources.ControlRoomContactedError,"jobSitePreparationControlRoomContactedYesRadioButton",       // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
                                                         wp => (wp.IsControlRoomContacted.HasFalseValue() || wp.IsControlRoomContacted == null) && wp.Attributes.IsRadiationRadiography &&
                                                             ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID // Added by Vibhor : DMND0011077 - Work Permit Clone History
                                                         
                                                         ),


                                                          BuildRequiredForSaveValidator(StringResources.ControlRoomContactedError,"jobSitePreparationControlRoomContactedNoRadioButton",       // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
                                                         wp => !wp.JobWorksitePreparation.IsControlRoomContactedNotApplicable,
                                                         wp => wp.IsControlRoomContacted == null &&
                                                             ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID // Added by Vibhor : DMND0011077 - Work Permit Clone History

                                                         ),
                                                         

            //Amit Shukla RITM0302870 Validation Workpermit on validate button click end
                           BuildRequiredForSaveValidator("specialProtectiveFootwearOtherDescriptionTextBoxCheckBox",
                                          wp =>
                                          wp.SpecialProtectionRequirements.
                                              ProtectiveFootwearOtherDescription != null,
                                          wp =>
                                          wp.SpecialProtectionRequirements.
                                              ProtectiveFootwearOtherDescription.IsNullOrEmptyOrWhitespace()),
                           BuildRequiredForSaveValidator("specialHandProtectionOtherDescriptionTextBoxCheckBox",
                                          wp =>
                                          wp.SpecialProtectionRequirements.HandProtectionOtherDescription !=
                                          null,
                                          wp =>
                                          wp.SpecialProtectionRequirements.
                                              HandProtectionOtherDescription.IsNullOrEmptyOrWhitespace()),
                           BuildRequiredForSaveValidator("specialRescueOrFallOtherDescriptionTextBoxCheckBox",
                                          wp =>
                                          wp.SpecialProtectionRequirements.RescueOrFallOtherDescription !=
                                          null,
                                          wp =>
                                          wp.SpecialProtectionRequirements.
                                              RescueOrFallOtherDescription.IsNullOrEmptyOrWhitespace()),
                           BuildRequiredForSaveValidator("acidClothingTypeIDComboBox",
                                          wp =>
                                          wp.SpecialProtectionRequirements.
                                              IsProtectiveClothingTypeAcidClothing,
                                          wp =>
                                          wp.SpecialProtectionRequirements.
                                              ProtectiveClothingTypeAcidClothingType == null),
                          //Amit Shukla RITM0302870 Validation Workpermit on validate button click equipment prep validationami
                          BuildRequiredForSaveValidator(StringResources.WorkPermit_SectionEmptyError,
                               "jobSitePreparationAreaPreparationGroupBox",
                               wp => !wp.JobWorksitePreparation.IsAreaPreparationNotApplicable,
                               wp => !wp.JobWorksitePreparation.HasAreaPreparationData()),
                          BuildRequiredForSaveValidator(StringResources.WorkPermit_SectionEmptyError,
                               "jobSitePreparationSewerIsolationMethodGroupBox",
                               wp => !wp.JobWorksitePreparation.IsSewerIsolationMethodNotApplicable,
                               wp => !wp.JobWorksitePreparation.HasSewerIsolationMethodData()),
                               //Amit Shukla RITM0302870 Validation Workpermit on validate button click 
                           BuildRequiredForSaveValidator(StringResources.WorkPermit_SectionEmptyError,
                                          "equipmentPreviousContentsGroupBox",
                                          wp => !wp.EquipmentPreparationCondition.IsPreviousContentsNotApplicable,
                                          wp => !wp.EquipmentPreparationCondition.HasPreviousContentsData()),
                           BuildRequiredForSaveValidator(StringResources.WorkPermit_SectionEmptyError,
                                          "equipmentConditionGroupBox",
                                          wp => !wp.EquipmentPreparationCondition.IsConditionNotApplicable,
                                          wp => !wp.EquipmentPreparationCondition.HasEquipmentConditionsData()),
                           BuildRequiredForSaveValidator(StringResources.WorkPermit_SectionEmptyError,
                                          "jobSitePreparationVentilationMethodGroupBox",
                                          wp => !wp.EquipmentPreparationCondition.IsVentilationMethodNotApplicable,
                                          wp => !wp.EquipmentPreparationCondition.HasVentilationMethodData()),
                       };
        }
        private static List<IValidation<WorkPermit>> BuildSpecialProtectionRequirementsRulesForDenver()
        {
            return new List<IValidation<WorkPermit>>
                       {
                           BuildRequiredForSaveValidator("specialEyeOrFaceProtectionOtherDescriptionTextBoxCheckBox",
                                          wp => wp.SpecialProtectionRequirements.EyeOrFaceProtectionOtherDescription != null,
                                          wp => wp.SpecialProtectionRequirements.EyeOrFaceProtectionOtherDescription.IsNullOrEmptyOrWhitespace()),

                           BuildRequiredForSaveValidator("specialProtectiveClothingOtherDescriptonTextBoxCheckBox",
                                          wp => wp.SpecialProtectionRequirements.ProtectiveClothingTypeOtherDescription != null,
                                          wp => wp.SpecialProtectionRequirements.ProtectiveClothingTypeOtherDescription.IsNullOrEmptyOrWhitespace()),

                           BuildRequiredForSaveValidator("specialProtectiveFootwearOtherDescriptionTextBoxCheckBox",
                                          wp => wp.SpecialProtectionRequirements.ProtectiveFootwearOtherDescription != null,
                                          wp => wp.SpecialProtectionRequirements.ProtectiveFootwearOtherDescription.IsNullOrEmptyOrWhitespace()),

                           BuildRequiredForSaveValidator("specialHandProtectionOtherDescriptionTextBoxCheckBox",
                                          wp => wp.SpecialProtectionRequirements.HandProtectionOtherDescription != null,
                                          wp => wp.SpecialProtectionRequirements.HandProtectionOtherDescription.IsNullOrEmptyOrWhitespace()),

                           BuildRequiredForSaveValidator("specialRescueOrFallOtherDescriptionTextBoxCheckBox",
                                          wp => wp.SpecialProtectionRequirements.RescueOrFallOtherDescription != null,
                                          wp => wp.SpecialProtectionRequirements.RescueOrFallOtherDescription.IsNullOrEmptyOrWhitespace()),

                           BuildRequiredForSaveValidator("acidClothingTypeIDComboBox",
                                          wp => wp.SpecialProtectionRequirements.IsProtectiveClothingTypeAcidClothing,
                                          wp => wp.SpecialProtectionRequirements.ProtectiveClothingTypeAcidClothingType == null)
                       };
        }

        //ayman USPipeline workpermit
        private static List<IValidation<WorkPermit>> BuildSpecialProtectionRequirementsRulesForUSPipeline()
        {
            return new List<IValidation<WorkPermit>>
                       {
                           BuildRequiredForSaveValidator("specialEyeOrFaceProtectionOtherDescriptionTextBoxCheckBox",
                                          wp => wp.SpecialProtectionRequirements.EyeOrFaceProtectionOtherDescription != null,
                                          wp => wp.SpecialProtectionRequirements.EyeOrFaceProtectionOtherDescription.IsNullOrEmptyOrWhitespace()),

                           BuildRequiredForSaveValidator("specialProtectiveClothingOtherDescriptonTextBoxCheckBox",
                                          wp => wp.SpecialProtectionRequirements.ProtectiveClothingTypeOtherDescription != null,
                                          wp => wp.SpecialProtectionRequirements.ProtectiveClothingTypeOtherDescription.IsNullOrEmptyOrWhitespace()),

                           BuildRequiredForSaveValidator("specialProtectiveFootwearOtherDescriptionTextBoxCheckBox",
                                          wp => wp.SpecialProtectionRequirements.ProtectiveFootwearOtherDescription != null,
                                          wp => wp.SpecialProtectionRequirements.ProtectiveFootwearOtherDescription.IsNullOrEmptyOrWhitespace()),

                           BuildRequiredForSaveValidator("specialHandProtectionOtherDescriptionTextBoxCheckBox",
                                          wp => wp.SpecialProtectionRequirements.HandProtectionOtherDescription != null,
                                          wp => wp.SpecialProtectionRequirements.HandProtectionOtherDescription.IsNullOrEmptyOrWhitespace()),

                           BuildRequiredForSaveValidator("specialRescueOrFallOtherDescriptionTextBoxCheckBox",
                                          wp => wp.SpecialProtectionRequirements.RescueOrFallOtherDescription != null,
                                          wp => wp.SpecialProtectionRequirements.RescueOrFallOtherDescription.IsNullOrEmptyOrWhitespace()),

                           BuildRequiredForSaveValidator("acidClothingTypeIDComboBox",
                                          wp => wp.SpecialProtectionRequirements.IsProtectiveClothingTypeAcidClothing,
                                          wp => wp.SpecialProtectionRequirements.ProtectiveClothingTypeAcidClothingType == null)
                       };
        }

        private static List<IValidation<WorkPermit>> BuildCommunicationMethodsRules()
        {
            return new List<IValidation<WorkPermit>>
                       {
                           BuildRequiredForSaveValidator("communicationMethodsGroupBox",
                                          wp =>
                                          !wp.Specifics.Communication.
                                               IsWorkPermitCommunicationNotApplicable,
                                          wp => wp.Specifics.Communication.ByRadio.HasNoValue()),
                           BuildRequiredForSaveValidator("communicationRadioChannelTextBox",
                                          wp =>
                                          !wp.Specifics.Communication.
                                               IsWorkPermitCommunicationNotApplicable,
                                          wp => wp.Specifics.Communication.ByRadio.HasTrueValue(),
                                          wp =>
                                          wp.Specifics.Communication.RadioChannel.IsNullOrEmptyOrWhitespace()),
                           BuildRequiredForSaveValidator("communicationOtherDescriptionTextBox",
                                          wp =>
                                          !wp.Specifics.Communication.
                                               IsWorkPermitCommunicationNotApplicable,
                                          wp => wp.Specifics.Communication.IsOther,
                                          wp =>
                                          wp.Specifics.Communication.Description.IsNullOrEmptyOrWhitespace())
                       };
        }

        private Predicate<WorkPermit>[] RecommendCommentsForFlowRequiredPredicates()
        {
            Predicate<WorkPermit>[] recommendCommentsForFlowRequired = new Predicate<WorkPermit>[2];
            recommendCommentsForFlowRequired[0] = wp => wp.JobWorksitePreparation.IsFlowRequiredForJobApplicableAndIsFlowRequiredForJob;
            recommendCommentsForFlowRequired[1] = wp => wp.SpecialPrecautionsOrConsiderations.IsNullOrEmptyOrWhitespace();
            return recommendCommentsForFlowRequired;
        }

        private Predicate<WorkPermit>[] RecommendCommentsForBondingGroundingPredicates()
        {
            Predicate<WorkPermit>[] recommendCommentsForBondingGroundingRequired = new Predicate<WorkPermit>[2];
            recommendCommentsForBondingGroundingRequired[0] = wp => wp.JobWorksitePreparation.IsBondingOrGroundingRequiredApplicableAndIsNotBondingOrGroundingRequired;
            recommendCommentsForBondingGroundingRequired[1] = wp => wp.SpecialPrecautionsOrConsiderations.IsNullOrEmptyOrWhitespace();
            return recommendCommentsForBondingGroundingRequired;
        }

        private static Predicate<WorkPermit>[] RequireCommentsForSurroundingConditionsPredicates()
        {
            Predicate<WorkPermit>[] requireCommentsForSurroundingConditions = new Predicate<WorkPermit>[3];
            requireCommentsForSurroundingConditions[0] = wp => !wp.JobWorksitePreparation.IsSurroundingConditionsAffectOrContaminatedNotApplicable;
            requireCommentsForSurroundingConditions[1] = wp => wp.JobWorksitePreparation.IsSurroundingConditionsAffectOrContaminated.HasTrueValue();
            requireCommentsForSurroundingConditions[2] = wp => wp.SpecialPrecautionsOrConsiderations.IsNullOrEmptyOrWhitespace();
            return requireCommentsForSurroundingConditions;
        }

        private static Predicate<WorkPermit>[] RequireCommentsForLeakingValvesPredicates()
        {
            Predicate<WorkPermit>[] requireCommentsForLeakingValves = new Predicate<WorkPermit>[4];
            requireCommentsForLeakingValves[0] = wp => !wp.EquipmentPreparationCondition.IsLeakingValvesNotApplicable;
            requireCommentsForLeakingValves[1] = wp => wp.EquipmentPreparationCondition.IsLeakingValves.HasValue;
            requireCommentsForLeakingValves[2] = wp => wp.EquipmentPreparationCondition.IsLeakingValves.Value;
            requireCommentsForLeakingValves[3] = wp => wp.SpecialPrecautionsOrConsiderations.IsNullOrEmptyOrWhitespace();
            return requireCommentsForLeakingValves;
        }

        private static Predicate<WorkPermit>[] RequireCommentsForContainsResidualPredicates()
        {
            Predicate<WorkPermit>[] requireCommentsForContainsResidual = new Predicate<WorkPermit>[4];
            requireCommentsForContainsResidual[0] = wp => !wp.EquipmentPreparationCondition.IsStillContainsResidualNotApplicable;
            requireCommentsForContainsResidual[1] = wp => wp.EquipmentPreparationCondition.IsStillContainsResidual.HasValue;
            requireCommentsForContainsResidual[2] = wp => wp.EquipmentPreparationCondition.IsStillContainsResidual.Value;
            requireCommentsForContainsResidual[3] = wp => wp.SpecialPrecautionsOrConsiderations.IsNullOrEmptyOrWhitespace();
            return requireCommentsForContainsResidual;
        }

        private static Predicate<WorkPermit>[] RequireCommentsForTestBumpPredicates()
        {
            Predicate<WorkPermit>[] requireCommentsForTestBump = new Predicate<WorkPermit>[4];
            requireCommentsForTestBump[0] = wp => !wp.EquipmentPreparationCondition.IsTestBumpNotApplicable;
            requireCommentsForTestBump[1] = wp => wp.EquipmentPreparationCondition.IsTestBump.HasValue;
            requireCommentsForTestBump[2] = wp => !wp.EquipmentPreparationCondition.IsTestBump.Value;
            requireCommentsForTestBump[3] = wp => wp.SpecialPrecautionsOrConsiderations.IsNullOrEmptyOrWhitespace();
            return requireCommentsForTestBump;
        }

        private string BuildCommentRequiredForApprovalMessage(Predicate<WorkPermit>[] requireCommentsForTestBump, Predicate<WorkPermit>[] requireCommentsForContainsResidual, Predicate<WorkPermit>[] requireCommentsForLeakingValves, Predicate<WorkPermit>[] requireCommentsForSurroundingConditions)
        {
            List<string> commentRequiredFields = new List<string>();

            if (requireCommentsForTestBump.TrueForAll(p => p(workPermit)))
            {
                commentRequiredFields.Add("Electrical Test Bump Performed (No)");
            }

            if (requireCommentsForContainsResidual.TrueForAll(p => p(workPermit)))
            {
                commentRequiredFields.Add("Contains Residual (Yes)");
            }

            if (requireCommentsForLeakingValves.TrueForAll(p => p(workPermit)))
            {
                commentRequiredFields.Add("Leaking Valves (Yes)");
            }

            if (requireCommentsForSurroundingConditions.TrueForAll(p => p(workPermit)))
            {
                commentRequiredFields.Add("Surrounding Conditions Affect or Contaminate Work Area (Yes)");
            }

            return String.Format("A comment is required as the following fields were selected: {0}", commentRequiredFields.Join(", "));
        }

        private string BuildCommentRecommendedMessage(Predicate<WorkPermit>[] recommendCommentsForFlow, Predicate<WorkPermit>[] recommendCommentsForBondingGrounding)
        {
            List<string> commentRecommendedFields = new List<string>();

            if (recommendCommentsForFlow.TrueForAll(p => p(workPermit)))
            {
                commentRecommendedFields.Add("Flow Required (Yes)");
            }

            if (recommendCommentsForBondingGrounding.TrueForAll(p => p(workPermit)))
            {
                commentRecommendedFields.Add("Bonding/Grounding Required (No)");
            }

            return String.Format("A comment is recommended as the following fields were selected: {0}", commentRecommendedFields.Join(", "));
        }

    }
}