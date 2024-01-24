using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    /// <summary>
    ///     Additional Forms / Assessments / Authorizations required  for a work permit
    /// </summary>
    [Serializable]
    [Alias("Additional")]
    public class WorkPermitAdditionalItemsRequired : DomainObject
    {
        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsCSEAssessmentOrAuthorization { get; set; }

        [SarniaWorkPermit("IsCSEAssessmentOrAuthorization")]
        public string CSEAssessmentOrAuthorizationDescription { get; set; }

        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]      //ayman USPipeline workpermit
        [SELCWorkPermit("!IsNotApplicable")]  // mangesh uspipeline to selc
        public bool IsFlareEntry { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [DenverWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")] 
        public bool IsCriticalLift { get; set; }

        [SarniaWorkPermit("IsCriticalLift")]
        public string CriticalLiftDescription { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [DenverWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")] 
        public bool IsExcavation { get; set; }

        [SarniaWorkPermit("IsExcavation")]
        public string ExcavationDescription { get; set; }

        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")] 
        public bool IsHotTap { get; set; }

        [SarniaWorkPermit]
        public bool IsSpecialWasteDisposal { get; set; }

        [SarniaWorkPermit]
        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")] 
        public bool IsBlankOrBlindLists { get; set; }

        [SarniaWorkPermit]
        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")] 
        public bool IsPJSROrSafetyPause { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsAsbestosHandling { get; set; }

        [SarniaWorkPermit("IsAsbestosHandling")]
        public string AsbestosHandlingDescription { get; set; }

        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")] 
        public bool IsRoadClosure { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsElectrical { get; set; }

        [SarniaWorkPermit("IsElectrical")]
        public string ElectricalDescription { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsBurnOrOpenFlameAssessment { get; set; }

        [SarniaWorkPermit("IsBurnOrOpenFlameAssessment")]
        public string BurnOrOpenFlameAssessmentDescription { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")] 
        public bool IsWaiverOrDeviation { get; set; }

        [SarniaWorkPermit("IsWaiverOrDeviation")]
        public string WaiverOrDeviationDescription { get; set; }

        [SarniaWorkPermit]
        [DenverWorkPermit("!IsNotApplicable")]
        public bool IsMSDS { get; set; }

        [SarniaWorkPermit]
        public bool IsOtherItemDescription { get; set; }

        [SarniaWorkPermit("IsOtherItemDescription")]
        public string OtherItemDescription { get; set; }

        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")] 
        public bool IsRadiationApproval { get; set; }

        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")] 
        public bool IsOnlineLeakRepairForm { get; set; }

        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")] 
        public bool IsEnergizedElectricalForm { get; set; }

        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsNotApplicable { get; set; }

        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool NASecondSection { get; set; }

        public WorkPermitAdditionalItemsRequired Copy()
        {
            return (WorkPermitAdditionalItemsRequired) Clone();
        }

//Added By Vibhor : RITM0627539 - Denver Site upgrades

        [DenverWorkPermit("!NASecondSection")]
        public bool PreExcavationAuthorization { get; set; }
        [DenverWorkPermit("!NASecondSection")]
        public bool SuspendedWorkPlatform { get; set; }
        [DenverWorkPermit("!NASecondSection")]
        public bool HotTurnoverApproval { get; set; }
        [DenverWorkPermit("!NASecondSection")]
        public bool ConfinedSpaceEntryAuthorizationForm { get; set; }
        [DenverWorkPermit("!NASecondSection")]
        public bool PreExcavationAuthorizationForm { get; set; }
        [DenverWorkPermit("!NASecondSection")]
        public bool SupplementalJobSiteSignInForm { get; set; }
        [DenverWorkPermit("!NASecondSection")]
        public bool SystemEntryGasTestLogFrom { get; set; }
        [DenverWorkPermit("!NASecondSection")]
        public bool HeatStressMonitoringForm { get; set; }
        [DenverWorkPermit("!NASecondSection")]
        public bool CriticalLiftApprovalForm { get; set; }
        [DenverWorkPermit("!NASecondSection")]
        public bool PjsrSecondSection { get; set; }
        [DenverWorkPermit("!NASecondSection")]
        public bool DeviationRequestForm { get; set; }
        [DenverWorkPermit("!NASecondSection")]
        public bool RoadClosureform { get; set; }
        [DenverWorkPermit("!NASecondSection")]
        public bool RadiographyApprovalForm { get; set; }
        [DenverWorkPermit("!NASecondSection")]
        public bool ConfinedSpaceEntryTrackingLog { get; set; }
        [DenverWorkPermit("!NASecondSection")]
        public bool FlareLineChecklists { get; set; }
        [DenverWorkPermit("!NASecondSection")]
        public bool HotTurnoverApprovalForm { get; set; }
        [DenverWorkPermit("!NASecondSection")]
        public bool IndustrialHygieneAreaRealTimeSamplingForm { get; set; }
        [DenverWorkPermit("!NASecondSection")]
        public bool CraneSuspendedWorkPlatformChecklist { get; set; }
        [DenverWorkPermit("!NASecondSection")]
        public bool ConfinedSpaceEntryAuthorizationFormSecondSection { get; set; }

        /// <summary>Tests if this section of the work permit has data (has been "filled out").</summary>
        public bool HasData()
        {
            return IsCSEAssessmentOrAuthorization
                   || CSEAssessmentOrAuthorizationDescription.HasValue()
                   || IsFlareEntry
                   || IsCriticalLift
                   || CriticalLiftDescription.HasValue()
                   || IsExcavation
                   || ExcavationDescription.HasValue()
                   || IsHotTap
                   || IsSpecialWasteDisposal
                   || IsBlankOrBlindLists
                   || IsPJSROrSafetyPause
                   || IsAsbestosHandling
                   || AsbestosHandlingDescription.HasValue()
                   || IsRoadClosure
                   || IsBurnOrOpenFlameAssessment
                   || BurnOrOpenFlameAssessmentDescription.HasValue()
                   || IsElectrical
                   || ElectricalDescription.HasValue()
                   || IsWaiverOrDeviation
                   || WaiverOrDeviationDescription.HasValue()
                   || IsMSDS
                   || IsOtherItemDescription
                   || IsRadiationApproval
                   || IsOnlineLeakRepairForm
                   || IsEnergizedElectricalForm

//Added By Vibhor : RITM0627539 - Denver Site upgrades

                   || PreExcavationAuthorization
                   || SuspendedWorkPlatform
                   || HotTurnoverApproval
                   || ConfinedSpaceEntryAuthorizationForm
                   || PreExcavationAuthorizationForm
                   || SupplementalJobSiteSignInForm
                   || SystemEntryGasTestLogFrom
                   || HeatStressMonitoringForm
                   || CriticalLiftApprovalForm
                   || PjsrSecondSection
                   || DeviationRequestForm
                   || RoadClosureform
                   || RadiographyApprovalForm
                   || ConfinedSpaceEntryTrackingLog
                   || FlareLineChecklists
                   || HotTurnoverApprovalForm
                   || IndustrialHygieneAreaRealTimeSamplingForm
                   || CraneSuspendedWorkPlatformChecklist
                   || ConfinedSpaceEntryAuthorizationFormSecondSection;

        }
    }
}