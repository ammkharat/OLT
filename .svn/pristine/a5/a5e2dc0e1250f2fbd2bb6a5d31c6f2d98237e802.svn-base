using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    /// <summary>
    ///     Tools related to a single work permit
    /// </summary>
    [Serializable]
    [Alias("Tools")]
    public class WorkPermitTools : DomainObject
    {
        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool IsAirTools { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool IsCraneOrCarrydeck { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool IsHandTools { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool IsJackhammer { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        public bool IsVacuumTruck { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool IsCementSaw { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool IsElectricTools { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool IsHeavyEquipment { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool IsLanda { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool IsScaffolding { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool IsVehicle { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool IsCompressor { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool IsForklift { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool IsHEPAVacuum { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool IsManlift { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool IsTamper { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool IsHotTapMachine { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool IsPortLighting { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool IsTorch { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool IsWelder { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool IsChemicals { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool IsOtherTools { get; set; }

        [DenverWorkPermit("IsOtherTools")]
        [USPipelineWorkPermit("IsOtherTools")]
        [SELCWorkPermit("IsOtherTools")]
        public string OtherToolsDescription { get; set; }

        public void InitializeWithSensibleDefaults()
        {
            IsWelder = false;
        }

        public WorkPermitTools Copy()
        {
            return (WorkPermitTools) Clone();
        }

        /// <summary>Tests if this section of the work permit has data (has been "filled out").</summary>
        public bool HasData()
        {
            return IsAirTools
                   || IsCraneOrCarrydeck
                   || IsHandTools
                   || IsJackhammer
                   || IsVacuumTruck
                   || IsCementSaw
                   || IsElectricTools
                   || IsHeavyEquipment
                   || IsLanda
                   || IsScaffolding
                   || IsVehicle
                   || IsCompressor
                   || IsForklift
                   || IsHEPAVacuum
                   || IsManlift
                   || IsTamper
                   || IsHotTapMachine
                   || IsPortLighting
                   || IsTorch
                   || IsWelder
                   || IsChemicals
                   || OtherToolsDescription.HasValue();
        }
    }
}