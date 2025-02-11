using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    /// <summary>
    ///     Eqiupment preparation conditions for a work permit.
    /// </summary>
    [Serializable]
    [Alias("Equipment")]
    public class WorkPermitEquipmentPreparationCondition : DomainObject
    {
        private readonly ISiteSpecificDateTimeHandler handler;
        private bool conditionNotApplicable = true; //default safe condition
        private string conditionsOfEIPNotSatisfiedComments;
        private bool? conditionsOfEIPSatisfied;
        private string energyIsolationPlanNumber;
        private bool? isHazardousEnergyIsolationRequired;
        private bool isHazardousEnergyIsolationRequiredNotApplicable = true;
        
        
        private bool? isOutOfService = true; //default safe condition
        private bool isolationMethodNotApplicable = true; //default safe condition
        private bool? leakingValves;
        private bool leakingValvesNotApplicable = true; //default safe condition
        private WorkPermitLockOutMethodType lockOutMethod;
        private string lockOutMethodComments;
        private bool previousContentsNotApplicable = true; //default safe condition
        private string previousContentsOtherDescription;
        private bool? stillContainsResidual;
        private bool stillContainsResidualNotApplicable = true; //default safe condition
        private bool testBumpNotApplicable = true; //default safe condition
        private bool ventilationMethodNotApplicable = true; //default safe condition

        internal WorkPermitEquipmentPreparationCondition(ISiteSpecificDateTimeHandler handler)
        {
            this.handler = handler;
        }

        public WorkPermitEquipmentPreparationCondition()
        {
            IsOutOfService = true;
            IsStillContainsResidual = false;
            IsLeakingValves = false;
        }

        public WorkPermitEquipmentPreparationCondition(SiteConfiguration siteConfiguration,
            ISiteSpecificDateTimeHandler handler)
        {
            this.handler = handler;
            handler.Initialize(this);

            SetOptionDefaults(siteConfiguration);

            // Set N/A defaults:
            IsConditionNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
            IsElectricalIsolationMethodNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
            IsIsolationMethodNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
            IsLeakingValvesNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
            IsPreviousContentsNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
            IsStillContainsResidualNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
            IsTestBumpNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
            IsVentilationMethodNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
            IsHazardousEnergyIsolationRequiredNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected; // // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
            
            IsAsbestosGasketsNotApplicable = true;
        }

        public bool IsPreviousContentsOtherDescription
        {
            get { return previousContentsOtherDescription.HasValue(); }
        }

        [SarniaWorkPermit(Constants.VERSION_3_2_STRING, WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsAsbestosGasketsNotApplicable { get; set; }

        [SarniaWorkPermit(Constants.VERSION_3_2_STRING, "!IsAsbestosGasketsNotApplicable")]
        public bool? IsAsbestosGaskets { get; set; }

        [SarniaWorkPermit(Constants.VERSION_3_2_STRING, WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]        //ayman USPipeline workpermit
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]            //mangesh uspipeline to selc
        public bool IsElectricalIsolationMethodNotApplicable { set; get; }

        [SarniaWorkPermit(Constants.VERSION_3_2_STRING, "!IsElectricalIsolationMethodNotApplicable")]
        [DenverWorkPermit("!IsElectricalIsolationMethodNotApplicable")]
        [USPipelineWorkPermit("!IsElectricalIsolationMethodNotApplicable")]
        [SELCWorkPermit("!IsElectricalIsolationMethodNotApplicable")]
        public bool IsElectricalIsolationMethodLOTO { set; get; }

        [SarniaWorkPermit(Constants.VERSION_3_2_STRING, "!IsElectricalIsolationMethodNotApplicable")]
        [DenverWorkPermit("!IsElectricalIsolationMethodNotApplicable")]
        [USPipelineWorkPermit("!IsElectricalIsolationMethodNotApplicable")]
        [SELCWorkPermit("!IsElectricalIsolationMethodNotApplicable")]
        public bool IsElectricalIsolationMethodWiring { set; get; }

        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsTestBumpNotApplicable
        {
            set { testBumpNotApplicable = value; }
            get { return testBumpNotApplicable; }
        }

        [SarniaWorkPermit(Constants.VERSION_3_2_STRING, "!IsElectricalIsolationMethodNotApplicable")]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool? IsTestBump { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsStillContainsResidualNotApplicable
        {
            set { stillContainsResidualNotApplicable = value; }
            get { return stillContainsResidualNotApplicable; }
        }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool? IsStillContainsResidual
        {
            set { stillContainsResidual = value; }
            get { return stillContainsResidual; }
        }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsLeakingValvesNotApplicable
        {
            set { leakingValvesNotApplicable = value; }
            get { return leakingValvesNotApplicable; }
        }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool? IsLeakingValves
        {
            set { leakingValves = value; }
            get { return leakingValves; }
        }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(Constants.VERSION_4_9_STRING, WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(Constants.VERSION_4_9_STRING, WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(Constants.VERSION_4_9_STRING, WorkPermitAttribute.Ordering.FirstSet)]
        public bool? IsOutOfService
        {
            set { isOutOfService = value; }
            get { return isOutOfService; }
        }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsConditionNotApplicable
        {
            set { conditionNotApplicable = value; }
            get { return conditionNotApplicable; }
        }

        [SarniaWorkPermit("!IsConditionNotApplicable")]
        [DenverWorkPermit("!IsConditionNotApplicable")]
        [USPipelineWorkPermit("!IsConditionNotApplicable")]
        [SELCWorkPermit("!IsConditionNotApplicable")]
        public bool IsConditionDepressured { set; get; }

        [SarniaWorkPermit("!IsConditionNotApplicable")]
        [DenverWorkPermit("!IsConditionNotApplicable")]
        [USPipelineWorkPermit("!IsConditionNotApplicable")]
        [SELCWorkPermit("!IsConditionNotApplicable")]
        public bool IsConditionDrained { set; get; }

        [SarniaWorkPermit("!IsConditionNotApplicable")]
        [DenverWorkPermit("!IsConditionNotApplicable")]
        [USPipelineWorkPermit("!IsConditionNotApplicable")]
        [SELCWorkPermit("!IsConditionNotApplicable")]
        public bool IsConditionCleaned { set; get; }

        [SarniaWorkPermit("!IsConditionNotApplicable")]
        public bool IsConditionPurgedCheckbox { set; get; }  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 

        [SarniaWorkPermit("!IsConditionNotApplicable")]
        [DenverWorkPermit("!IsConditionNotApplicable")]
        [USPipelineWorkPermit("!IsConditionNotApplicable")]
        [SELCWorkPermit("!IsConditionNotApplicable")]
        public bool IsConditionVentilated { set; get; }

        [SarniaWorkPermit("!IsConditionNotApplicable")]
        [DenverWorkPermit("!IsConditionNotApplicable")]
        [USPipelineWorkPermit("!IsConditionNotApplicable")]
        [SELCWorkPermit("!IsConditionNotApplicable")]
        public bool IsConditionH20Washed { set; get; }

        [SarniaWorkPermit("!IsConditionNotApplicable")]
        [DenverWorkPermit("!IsConditionNotApplicable")]
        [USPipelineWorkPermit("!IsConditionNotApplicable")]
        [SELCWorkPermit("!IsConditionNotApplicable")]
        public bool IsConditionNeutralized { set; get; }

        [DenverWorkPermit("!IsConditionNotApplicable")]
        [USPipelineWorkPermit("!IsConditionNotApplicable")]
        [SELCWorkPermit("!IsConditionNotApplicable")]
        public bool IsConditionPurged { set; get; }

        [DenverWorkPermit("IsConditionApplicableAndIsConditionPurged")]
        [USPipelineWorkPermit("IsConditionApplicableAndIsConditionPurged")]
        [SELCWorkPermit("IsConditionApplicableAndIsConditionPurged")]
        public string ConditionPurgedDescription { set; get; }

        [SarniaWorkPermit("!IsConditionNotApplicable")]
        public bool IsConditionPurgedN2 { get; set; }

        [SarniaWorkPermit("!IsConditionNotApplicable")]
        public bool IsConditionPurgedSteamed { get; set; }

        [SarniaWorkPermit("!IsConditionNotApplicable")]
        public bool IsConditionPurgedAir { get; set; }

        [SarniaWorkPermit("!IsConditionNotApplicable")]
        public string ConditionOtherDescription { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsPreviousContentsNotApplicable
        {
            set { previousContentsNotApplicable = value; }
            get { return previousContentsNotApplicable; }
        }

        [SarniaWorkPermit("!IsPreviousContentsNotApplicable")]
        [DenverWorkPermit("!IsPreviousContentsNotApplicable")]
        [USPipelineWorkPermit("!IsPreviousContentsNotApplicable")]
        [SELCWorkPermit("!IsPreviousContentsNotApplicable")]
        public bool IsPreviousContentsHydrocarbon { set; get; }

        [SarniaWorkPermit("!IsPreviousContentsNotApplicable")]
        [DenverWorkPermit("!IsPreviousContentsNotApplicable")]
        [USPipelineWorkPermit("!IsPreviousContentsNotApplicable")]
        [SELCWorkPermit("!IsPreviousContentsNotApplicable")]
        public bool IsPreviousContentsAcid { set; get; }

        [SarniaWorkPermit("!IsPreviousContentsNotApplicable")]
        [DenverWorkPermit("!IsPreviousContentsNotApplicable")]
        [USPipelineWorkPermit("!IsPreviousContentsNotApplicable")]
        [SELCWorkPermit("!IsPreviousContentsNotApplicable")]
        public bool IsPreviousContentsCaustic { set; get; }

        [SarniaWorkPermit("!IsPreviousContentsNotApplicable")]
        [DenverWorkPermit("!IsPreviousContentsNotApplicable")]
        [USPipelineWorkPermit("!IsPreviousContentsNotApplicable")]
        [SELCWorkPermit("!IsPreviousContentsNotApplicable")]
        public bool IsPreviousContentsH2S { set; get; }

        [SarniaWorkPermit("!IsPreviousContentsNotApplicable")]
        [DenverWorkPermit("!IsPreviousContentsNotApplicable")]
        [USPipelineWorkPermit("!IsPreviousContentsNotApplicable")]
        [SELCWorkPermit("!IsPreviousContentsNotApplicable")]
        public string PreviousContentsOtherDescription
        {
            set { previousContentsOtherDescription = value; }
            get { return previousContentsOtherDescription; }
        }

        [SarniaWorkPermit(Constants.VERSION_3_2_STRING, WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsIsolationMethodNotApplicable
        {
            set { isolationMethodNotApplicable = value; }
            get { return isolationMethodNotApplicable; }
        }

        [SarniaWorkPermit(Constants.VERSION_3_2_STRING, "!IsIsolationMethodNotApplicable")]
        [DenverWorkPermit("!IsIsolationMethodNotApplicable")]
        [USPipelineWorkPermit("!IsIsolationMethodNotApplicable")]
        [SELCWorkPermit("!IsIsolationMethodNotApplicable")]
        public bool IsIsolationMethodBlindedorBlanked { set; get; }

        [SarniaWorkPermit(Constants.VERSION_3_2_STRING, "!IsIsolationMethodNotApplicable")]
        [DenverWorkPermit("!IsIsolationMethodNotApplicable")]
        [USPipelineWorkPermit("!IsIsolationMethodNotApplicable")]
        [SELCWorkPermit("!IsIsolationMethodNotApplicable")]
        public bool IsIsolationMethodSeparation { set; get; }

        [DenverWorkPermit("!IsIsolationMethodNotApplicable")]
        [USPipelineWorkPermit("!IsIsolationMethodNotApplicable")]
        [SELCWorkPermit("!IsIsolationMethodNotApplicable")]
        public bool IsIsolationMethodMudderPlugs { set; get; }

        [SarniaWorkPermit(Constants.VERSION_3_2_STRING, "!IsIsolationMethodNotApplicable")]
        public bool IsIsolationMethodBlockedIn { set; get; }

        [DenverWorkPermit("!IsIsolationMethodNotApplicable")]
        [USPipelineWorkPermit("!IsIsolationMethodNotApplicable")]
        [SELCWorkPermit("!IsIsolationMethodNotApplicable")]
        public bool IsIsolationMethodCarBer { get; set; }

        [SarniaWorkPermit(Constants.VERSION_3_2_STRING, "!IsIsolationMethodNotApplicable")]
        [DenverWorkPermit("!IsIsolationMethodNotApplicable")]
        [USPipelineWorkPermit("!IsIsolationMethodNotApplicable")]
        [SELCWorkPermit("!IsIsolationMethodNotApplicable")]
        public bool IsIsolationMethodLOTO { set; get; }

        [SarniaWorkPermit(Constants.VERSION_3_2_STRING, "!IsIsolationMethodNotApplicable")]
        [DenverWorkPermit("!IsIsolationMethodNotApplicable")]
        [USPipelineWorkPermit("!IsIsolationMethodNotApplicable")]
        [SELCWorkPermit("!IsIsolationMethodNotApplicable")]
        public string IsolationMethodOtherDescription { set; get; }

        [SarniaWorkPermit("IsInServiceSelected")]
        [DenverWorkPermit(Constants.VERSION_4_9_STRING, "IsInServiceSelected")]
        [USPipelineWorkPermit(Constants.VERSION_4_9_STRING, "IsInServiceSelected")]
        [SELCWorkPermit(Constants.VERSION_4_9_STRING, "IsInServiceSelected")]
        public string InServiceComments { get; set; }

        [SarniaWorkPermit]
        public string InAsbestosHazardPresentComments { get; set; }  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 

        //[SarniaWorkPermit]
        //public string InHazardousEnergyIsolationComments { get; set; }  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 

       
        [SarniaWorkPermit("IsLeakingValvesSelected")]
        [DenverWorkPermit(Constants.VERSION_4_9_STRING, "IsLeakingValvesSelected")]
        [USPipelineWorkPermit(Constants.VERSION_4_9_STRING, "IsLeakingValvesSelected")]
        [SELCWorkPermit(Constants.VERSION_4_9_STRING, "IsLeakingValvesSelected")]
        public string LeakingValvesComments { get; set; }

        [SarniaWorkPermit("IsStillContainsResidualSelected")]
        [DenverWorkPermit(Constants.VERSION_4_9_STRING, "IsStillContainsResidualSelected")]
        [USPipelineWorkPermit(Constants.VERSION_4_9_STRING, "IsStillContainsResidualSelected")]
        [SELCWorkPermit(Constants.VERSION_4_9_STRING, "IsStillContainsResidualSelected")]
        public string StillContainsResidualComments { get; set; }

        [DenverWorkPermit(Constants.VERSION_4_9_STRING, "IsTestBumpApplicableAndIsTestBumpUnselected")]
        [USPipelineWorkPermit(Constants.VERSION_4_9_STRING, "IsTestBumpApplicableAndIsTestBumpUnselected")]
        [SELCWorkPermit(Constants.VERSION_4_9_STRING, "IsTestBumpApplicableAndIsTestBumpUnselected")]
        public string NoElectricalTestBumpComments { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsVentilationMethodNotApplicable
        {
            set { ventilationMethodNotApplicable = value; }
            get { return ventilationMethodNotApplicable; }
        }

        [SarniaWorkPermit("!IsVentilationMethodNotApplicable")]
        [DenverWorkPermit("!IsVentilationMethodNotApplicable")]
        [USPipelineWorkPermit("!IsVentilationMethodNotApplicable")]
        [SELCWorkPermit("!IsVentilationMethodNotApplicable")]
        public bool IsVentilationMethodNaturalDraft { set; get; }

        [SarniaWorkPermit("!IsVentilationMethodNotApplicable")]
        [DenverWorkPermit("!IsVentilationMethodNotApplicable")]
        [USPipelineWorkPermit("!IsVentilationMethodNotApplicable")]
        [SELCWorkPermit("!IsVentilationMethodNotApplicable")]
        public bool IsVentilationMethodLocalExhaust { set; get; }

        [SarniaWorkPermit("!IsVentilationMethodNotApplicable")]
        [DenverWorkPermit("!IsVentilationMethodNotApplicable")]
        [USPipelineWorkPermit("!IsVentilationMethodNotApplicable")]
        [SELCWorkPermit("!IsVentilationMethodNotApplicable")]
        public bool IsVentilationMethodForced { set; get; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsHazardousEnergyIsolationRequiredNotApplicable
        {
            get { return isHazardousEnergyIsolationRequiredNotApplicable; }
            set { isHazardousEnergyIsolationRequiredNotApplicable = value; }
        }
        
        [SarniaWorkPermit(WorkPermitAttribute.Ordering.SecondSet, "!IsHazardousEnergyIsolationRequiredNotApplicable")]
        public bool? IsHazardousEnergyIsolationRequired
        {
            get { return isHazardousEnergyIsolationRequired; }
            set { isHazardousEnergyIsolationRequired = value; }
        }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.ThirdSet, "IsHazardousEnergyIsolationRequiredSelected")]
        public WorkPermitLockOutMethodType LockOutMethod
        {
            get { return lockOutMethod; }
            set { lockOutMethod = value; }
        }

        [SarniaWorkPermit("IsLockOutMethodIndividualByWorkerOrIndividualByOperations")]
        public string LockOutMethodComments
        {
            get { return lockOutMethodComments; }
            set { lockOutMethodComments = value; }
        }

        [SarniaWorkPermit("IsLockOutMethodComplexGroup")]
        public string EnergyIsolationPlanNumber
        {
            get { return energyIsolationPlanNumber; }
            set { energyIsolationPlanNumber = value; }
        }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FourthSet, "IsConditionsOfEIPSatisfiedApplicable")]
        public bool? ConditionsOfEIPSatisfied
        {
            get { return conditionsOfEIPSatisfied; }
            set { conditionsOfEIPSatisfied = value; }
        }

        [SarniaWorkPermit("IsConditionsOfEIPNotSatisfied")]
        public string ConditionsOfEIPNotSatisfiedComments
        {
            get { return conditionsOfEIPNotSatisfiedComments; }
            set { conditionsOfEIPNotSatisfiedComments = value; }
        }

        public bool IsHazardousEnergyIsolationRequiredSelected
        {
            get
            {
                return !IsHazardousEnergyIsolationRequiredNotApplicable &&
                       IsHazardousEnergyIsolationRequired.HasValue &&
                       IsHazardousEnergyIsolationRequired.Value;
            }
        }

        public bool IsLockOutMethodIndividualByWorkerOrIndividualByOperations
        {
            get
            {
                return IsHazardousEnergyIsolationRequiredSelected &&
                       LockOutMethod != null &&
                       (Equals(LockOutMethod, WorkPermitLockOutMethodType.INDIVIDUAL_BY_WORKER) ||
                        Equals(LockOutMethod, WorkPermitLockOutMethodType.INDIVIDUAL_BY_OPERATIONS));
            }
        }

        public bool IsLockOutMethodComplexGroup
        {
            get
            {
                return IsHazardousEnergyIsolationRequiredSelected &&
                       LockOutMethod != null &&
                       Equals(LockOutMethod, WorkPermitLockOutMethodType.COMPLEX_GROUP);
            }
        }

        public bool IsConditionsOfEIPSatisfiedApplicable
        {
            get { return IsLockOutMethodComplexGroup; }
        }

        public bool IsConditionsOfEIPNotSatisfied
        {
            get
            {
                return IsConditionsOfEIPSatisfiedApplicable &&
                       ConditionsOfEIPSatisfied.HasValue &&
                       !ConditionsOfEIPSatisfied.Value;
            }
        }

        public bool IsInServiceSelected
        {
            get { return (IsOutOfService.HasValue && !IsOutOfService.Value); }
        }

        public bool IsLeakingValvesSelected
        {
            get { return !IsLeakingValvesNotApplicable && (IsLeakingValves.HasValue && IsLeakingValves.Value); }
        }

        public bool IsConditionApplicableAndIsConditionPurged
        {
            get { return !IsConditionNotApplicable && IsConditionPurged; }
        }

        public bool IsStillContainsResidualSelected
        {
            get
            {
                return !IsStillContainsResidualNotApplicable &&
                       (IsStillContainsResidual.HasValue && IsStillContainsResidual.Value);
            }
        }

        public bool IsTestBumpApplicableAndIsTestBumpUnselected
        {
            get { return !IsTestBumpNotApplicable && (IsTestBump.HasValue && !IsTestBump.Value); }
        }

        private void SetOptionDefaults(SiteConfiguration siteConfiguration)
        {
            if (!siteConfiguration.WorkPermitOptionAutoSelected)
            {
                IsTestBump = null;
                isOutOfService = null;
                stillContainsResidual = null;
                leakingValves = null;
            }
        }

        public WorkPermitEquipmentPreparationCondition Copy()
        {
            return (WorkPermitEquipmentPreparationCondition) Clone();
        }

        public bool HasEquipmentConditionsData()
        {
            return IsConditionDepressured
                   || IsConditionDrained
                   || IsConditionCleaned
                   || IsConditionPurgedCheckbox // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                   || IsConditionVentilated
                   || IsConditionH20Washed
                   || IsConditionNeutralized
                   || IsConditionPurged
                   || ConditionPurgedDescription.HasValue()
                   || IsConditionPurgedN2
                   || IsConditionPurgedAir
                   || IsConditionPurgedSteamed
                   || ConditionOtherDescription.HasValue();
        }

        /// <summary>Tests if this section of the work permit has data (has been "filled out").</summary>
        public bool HasData()
        {
            return HasEquipmentConditionsData()
                   || HasPreviousContentsData()
                   || IsAsbestosGaskets.HasValue
                   || HasEquipmentIsolationMethodData()
                   || HasElectricalIsolationMethodData()
                   || HasVentilationMethodData()
                   || InServiceComments.HasValue()
                   || InAsbestosHazardPresentComments.HasValue()  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                   //|| InHazardousEnergyIsolationComments.HasValue()  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                   || LeakingValvesComments.HasValue()
                   || StillContainsResidualComments.HasValue()
                   || NoElectricalTestBumpComments.HasValue()
                   || IsHazardousEnergyIsolationRequired.HasValue
                   || LockOutMethod != null
                   || LockOutMethodComments.HasValue()
                   || ConditionsOfEIPSatisfied.HasValue
                   || ConditionsOfEIPNotSatisfiedComments.HasValue()
                ;
        }

        public bool HasPreviousContentsData()
        {
            return IsPreviousContentsHydrocarbon
                   || IsPreviousContentsAcid
                   || IsPreviousContentsCaustic
                   || IsPreviousContentsH2S
                   || PreviousContentsOtherDescription.HasValue();
        }

        public bool HasEquipmentIsolationMethodData()
        {
            return IsIsolationMethodBlindedorBlanked
                   || IsIsolationMethodSeparation
                   || IsIsolationMethodMudderPlugs
                   || IsIsolationMethodBlockedIn
                   || IsIsolationMethodCarBer
                   || IsIsolationMethodLOTO
                   || IsolationMethodOtherDescription.HasValue();
        }

        public bool HasElectricalIsolationMethodData()
        {
            return IsElectricalIsolationMethodLOTO
                   || IsElectricalIsolationMethodWiring;
        }


        public bool HasVentilationMethodData()
        {
            return IsVentilationMethodNaturalDraft
                   || IsVentilationMethodLocalExhaust
                   || IsVentilationMethodForced;
        }
    }
}