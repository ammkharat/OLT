using System;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [Serializable]
    public class TargetThresholdEvaluation : ComparableObject
    {
        private readonly decimal? actualValueUsed;
        private readonly TargetThresholdExcessLevel excessLevel;
        private readonly decimal gapValue;
        private readonly decimal? thresholdValue;

        /// <summary>
        ///     Creates evaluation where no threshold was exceeded.
        /// </summary>
        public TargetThresholdEvaluation(decimal? actualValueUsed)
            : this(TargetThresholdExcessLevel.None, null, actualValueUsed, 0.0m)
        {
        }

        public TargetThresholdEvaluation(TargetThresholdExcessLevel excessLevel,
            decimal? thresholdValue,
            decimal? actualValueUsed,
            decimal gapValue)
        {
            this.excessLevel = excessLevel;
            this.thresholdValue = thresholdValue;
            this.actualValueUsed = actualValueUsed;
            this.gapValue = gapValue;
        }

        public TargetThresholdExcessLevel ExcessLevel
        {
            get { return excessLevel; }
        }

        public decimal? ThresholdValue
        {
            get { return thresholdValue; }
        }

        /// <summary>
        ///     Returns the actual reading used for this evaluation.
        /// </summary>
        public decimal? ActualValueUsed
        {
            get { return actualValueUsed; }
        }

        /// <summary>
        ///     Returns the gap between the actual reading and the threshold..
        /// </summary>
        public decimal GapValue
        {
            get { return gapValue; }
        }

        public bool NeverToExceedLimitExceeded
        {
            get
            {
                return excessLevel == TargetThresholdExcessLevel.NeverToExceedMax
                       || excessLevel == TargetThresholdExcessLevel.NeverToExceedMin;
            }
        }

        public bool AnyLimitExceeded
        {
            get { return excessLevel != TargetThresholdExcessLevel.None; }
        }

        /// <param name="gapUnitValue">rate for calculating losses due to gap ($/unit)</param>
        public decimal CalculateLosses(decimal gapUnitValue)
        {
            return gapUnitValue*GapValue;
        }
    }
}