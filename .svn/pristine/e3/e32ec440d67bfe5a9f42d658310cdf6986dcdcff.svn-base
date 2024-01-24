using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    /// <summary>
    ///     Work permit's communication options
    /// </summary>
    [Serializable]
    [Alias("CommunicationMethod")]
    public class WorkPermitCommunication : DomainObject
    {
        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]               //ayman USPipeline workpermit
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]                //mangesh uspipeline to selc
        public bool? ByRadio { get; set; }

        [SarniaWorkPermit("IsRadio")]
        [DenverWorkPermit("IsRadio")]
        [USPipelineWorkPermit("IsRadio")]
        [SELCWorkPermit("IsRadio")]
        public string RadioChannel { get; set; }

        [SarniaWorkPermit("IsRadio")]
        public string RadioColor { get; set; }

        [SarniaWorkPermit("IsOther")]
        [DenverWorkPermit("IsOther")]
        [USPipelineWorkPermit("IsOther")]
        [SELCWorkPermit("IsOther")]
        public string Description { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsWorkPermitCommunicationNotApplicable { get; set; }

        # region Work Permit Attribute Pre-Setter Condition Properties (called via reflection)

        public bool IsRadio
        {
            get { return !IsWorkPermitCommunicationNotApplicable && ByRadio.HasTrueValue(); }
        }

        public bool IsOther
        {
            get { return !IsWorkPermitCommunicationNotApplicable && ByRadio.HasFalseValue(); }
        }

        #endregion

        public void InitializeWithSensibleDefaults(SiteConfiguration siteConfiguration)
        {
            ByRadio = true;
            // Set N/A defaults:
            IsWorkPermitCommunicationNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
        }

        public WorkPermitCommunication Copy()
        {
            return (WorkPermitCommunication) Clone();
        }
    }
}