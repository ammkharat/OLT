using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    /// <summary>
    ///     Resulting evaluation of a threshold.
    /// </summary>
    public class ThresholdEvaluation
    {
        private readonly List<decimal> thresholdGaps;

        /// <summary>
        ///     Construct an evaluation with a list of the threshold gaps (a gap is the difference between the
        ///     actual reading and the threshold).
        /// </summary>
        /// <param name="thresholdGaps"></param>
        public ThresholdEvaluation(List<decimal> thresholdGaps)
        {
            this.thresholdGaps = thresholdGaps;
        }

        public bool ExceededThreshold
        {
            get { return thresholdGaps.TrueForAll(gap => gap > 0.0m); }
        }

        public List<decimal> ThresholdGaps
        {
            get { return thresholdGaps; }
        }
    }
}