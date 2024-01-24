using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    /// <summary>
    ///     A threshold that's exceeded if an actual reading is lower than the threshold.
    /// </summary>
    public class MinThreshold : Threshold
    {
        private readonly decimal? preApprovedFloorLimit;

        public MinThreshold(decimal thresholdValue,
            int samplesRequiredToExceedThreshold,
            decimal? preApprovedFloorLimit)
            : base(thresholdValue, samplesRequiredToExceedThreshold)
        {
            this.preApprovedFloorLimit = preApprovedFloorLimit;
        }

        protected override decimal CalculateGap(decimal thresholdValue, decimal actualReading)
        {
            return thresholdValue - actualReading;
        }

        public static MinThreshold Create(decimal? thresholdValue,
            int? samplesRequiredToExceedThreshold)
        {
            return Create(thresholdValue, samplesRequiredToExceedThreshold, null);
        }

        public static MinThreshold Create(decimal? thresholdValue,
            int? samplesRequiredToExceedThreshold,
            decimal? preApprovedFloorLimit)
        {
            if (thresholdValue.HasNoValue())
            {
                return null;
            }
            if (samplesRequiredToExceedThreshold.HasNoValue())
            {
                return null;
            }

            return new MinThreshold(thresholdValue.Value,
                samplesRequiredToExceedThreshold.Value,
                preApprovedFloorLimit);
        }

        public override bool IsWithinPreApprovedLimit()
        {
            if (preApprovedFloorLimit == null)
            {
                return true;
            }
            return ThresholdValue >= preApprovedFloorLimit;
        }
    }
}