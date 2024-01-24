using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    /// <summary>
    ///     A threshold that's exceeded if an actual reading is higher than the threshold.
    /// </summary>
    public class MaxThreshold : Threshold
    {
        private readonly decimal? preApprovedCeilingLimit;

        public MaxThreshold(decimal thresholdValue, int samplesRequiredToExceedThreshold,
            decimal? preApprovedCeilingLimit)
            : base(thresholdValue, samplesRequiredToExceedThreshold)
        {
            this.preApprovedCeilingLimit = preApprovedCeilingLimit;
        }

        protected override decimal CalculateGap(decimal thresholdValue, decimal actualReading)
        {
            return actualReading - thresholdValue;
        }

        public static MaxThreshold Create(decimal? thresholdValue,
            int? samplesRequiredToExceedThreshold)
        {
            return Create(thresholdValue, samplesRequiredToExceedThreshold, null);
        }

        public static MaxThreshold Create(decimal? thresholdValue,
            int? samplesRequiredToExceedThreshold, decimal? preApprovedCeilingLimit)
        {
            if (thresholdValue.HasNoValue() || samplesRequiredToExceedThreshold.HasNoValue())
            {
                return null;
            }

            return new MaxThreshold(thresholdValue.Value, samplesRequiredToExceedThreshold.Value,
                preApprovedCeilingLimit);
        }

        public override bool IsWithinPreApprovedLimit()
        {
            if (preApprovedCeilingLimit == null)
            {
                return true;
            }
            return ThresholdValue <= preApprovedCeilingLimit;
        }
    }
}