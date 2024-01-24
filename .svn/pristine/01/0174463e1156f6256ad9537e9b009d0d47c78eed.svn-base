using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    /// <summary>
    ///     A threshold is some boundary defined by a value, and the number of samples needed to determine
    ///     that this threshold has been exceeded.
    /// </summary>
    public abstract class Threshold
    {
        private readonly int samplesRequiredToExceedThreshold;
        private readonly decimal thresholdValue;

        protected Threshold(decimal thresholdValue, int samplesRequiredToExceedThreshold)
        {
            if (samplesRequiredToExceedThreshold < 1)
            {
                throw new ArgumentException("At least 1 sample required to evaluate threshold.",
                    "samplesRequiredToExceedThreshold");
            }

            this.thresholdValue = thresholdValue;
            this.samplesRequiredToExceedThreshold = samplesRequiredToExceedThreshold;
        }

        public decimal ThresholdValue
        {
            get { return thresholdValue; }
        }

        public int SamplesRequiredToExceedThreshold
        {
            get { return samplesRequiredToExceedThreshold; }
        }

        public ThresholdEvaluation Evaluate(List<decimal?> actualReadings)
        {
            if (actualReadings.Count == 0)
            {
                throw new ArgumentException("At least one reading is required for threshold evaluation.",
                    "actualReadings");
            }

            if (actualReadings.Count < samplesRequiredToExceedThreshold)
            {
                throw new NotSupportedException("Need:<" + samplesRequiredToExceedThreshold +
                                                "> samples to evaluate threshold, but got:<" + actualReadings.Count +
                                                ">");
            }

            var relevantReadings = actualReadings.Last(samplesRequiredToExceedThreshold);

            var thresholdGaps = relevantReadings.ConvertAll(reading =>
            {
                if (DidNotFindAValueForATag(reading))
                {
                    // There is no gap when you can't get a tag reading,
                    // so return a gap of zero which won't cause an alert to fire.
                    return 0.0m;
                }

                var gap =
                    CalculateGap(thresholdValue,
                        reading.Value);
                return Math.Max(gap, 0.0m);
            });

            return new ThresholdEvaluation(new List<decimal>(thresholdGaps));
        }

        private static bool DidNotFindAValueForATag(decimal? reading)
        {
            return !reading.HasValue;
        }

        public abstract bool IsWithinPreApprovedLimit();

        protected abstract decimal CalculateGap(decimal thresholdValue, decimal actualReading);
    }
}