using System;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    [Alias("Asbestos")]
    public class WorkPermitAsbestos : DomainObject
    {
        public WorkPermitAsbestos()
        {
            HazardsConsideredNotApplicable = true;
        }

        public void InitializeWithSensibleDefaults(SiteConfiguration siteConfiguration)
        {
            HazardsConsideredNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
        }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool HazardsConsideredNotApplicable { get; set; }

        [SarniaWorkPermit("!HazardsConsideredNotApplicable")]
        public bool? HazardsConsidered { get; set; }

        public WorkPermitAsbestos Copy()
        {
            return (WorkPermitAsbestos) Clone();
        }

        /// <summary>Tests if this section of the work permit has data (has been "filled out").</summary>
        public bool HasData()
        {
            return HazardsConsidered.HasValue;
        }
    }
}