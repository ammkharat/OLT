using System;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    /// <summary>
    ///     The 'Permit Attributes' section of a Work Permit.
    /// </summary>
    [Serializable]
    public class WorkPermitAttributes : ComparableObject
    {
        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]          //ayman USPipeline workpermit // mangesh uspipeline to selc
        public bool IsConfinedSpaceEntry { get; set; }

        [DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public bool IsInertConfinedSpaceEntry { get; set; }

        [DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public bool IsLeadAbatement { get; set; }

        [DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public bool IsBreathingAirOrSCBA { get; set; }

        [SarniaWorkPermit, DenverWorkPermit(Constants.VERSION_4_9_STRING, null), USPipelineWorkPermit(Constants.VERSION_4_9_STRING, null), SELCWorkPermit(Constants.VERSION_4_9_STRING, null)]
        public bool IsVehicleEntry { get; set; }

        [DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public bool IsHotTap { get; set; }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public bool IsBurnOrOpenFlame { get; set; }

        [DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public bool IsSystemEntry { get; set; }

        [DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public bool IsCriticalLift { get; set; }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit,  SELCWorkPermit]
        public bool IsExcavation { get; set; }

        [DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public bool IsElectricalWork { get; set; }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public bool IsAsbestos { get; set; }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public bool IsRadiationRadiography { get; set; }

        [SarniaWorkPermit]
        public bool IsFreshAir { get; set; } // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 

        [DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public bool IsRadiationSealed { get; set; }

        public WorkPermitAttributes Copy()
        {
            return (WorkPermitAttributes) MemberwiseClone();
        }
    }
}