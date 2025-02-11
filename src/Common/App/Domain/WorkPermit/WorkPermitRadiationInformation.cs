using System;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    /// <summary>
    ///     Radiation information for a work permit
    /// </summary>
    [Serializable]
    [Alias("Radiation")]
    public class WorkPermitRadiationInformation : DomainObject
    {
        public WorkPermitRadiationInformation()
        {
            IsSealedSourceIsolationNotApplicable = true;
        }

        [SarniaWorkPermit(Constants.VERSION_3_2_STRING, WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsSealedSourceIsolationNotApplicable { get; set; }

        [SarniaWorkPermit(Constants.VERSION_3_2_STRING, "!IsSealedSourceIsolationNotApplicable")]
        [DenverWorkPermit("!IsSealedSourceIsolationNotApplicable")]
        [USPipelineWorkPermit("!IsSealedSourceIsolationNotApplicable")]
        [SELCWorkPermit("!IsSealedSourceIsolationNotApplicable")]
        public bool IsSealedSourceIsolationLOTO { get; set; }

        [SarniaWorkPermit(Constants.VERSION_3_2_STRING, "!IsSealedSourceIsolationNotApplicable")]
        public bool IsSealedSourceIsolationOpen { get; set; }

        [SarniaWorkPermit(Constants.VERSION_3_2_STRING, "!IsSealedSourceIsolationNotApplicable")]
        public int? SealedSourceIsolationNumberOfSources { get; set; }

        public void InitializeWithSensibleDefaults(SiteConfiguration siteConfiguration)
        {
            IsSealedSourceIsolationNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
        }

        public WorkPermitRadiationInformation Copy()
        {
            return (WorkPermitRadiationInformation) Clone();
        }

        /// <summary>Tests if this section of the work permit has data (has been "filled out").</summary>
        public bool HasData()
        {
            return IsSealedSourceIsolationLOTO
                   || IsSealedSourceIsolationOpen
                   || SealedSourceIsolationNumberOfSources.HasValue;
        }
    }
}