using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [Serializable]
    public class TargetThresholds
    {
        private readonly MaxThreshold maximum;
        private readonly MinThreshold minimum;
        private readonly MaxThreshold neverToExceedMaximum;
        private readonly MinThreshold neverToExceedMinimum;

        public TargetThresholds(MinThreshold neverToExceedMinimum, MinThreshold minimum,
            MaxThreshold maximum, MaxThreshold neverToExceedMaximum)
        {
            this.neverToExceedMinimum = neverToExceedMinimum;
            this.minimum = minimum;
            this.maximum = maximum;
            this.neverToExceedMaximum = neverToExceedMaximum;

            if (GetDefinedThresholds().Count == 0)
            {
                throw new ArgumentException("Cannot construct target thresholds with All null thresholds.");
            }
        }

        /// <summary>
        ///     Returns the number of samples (number of actual readings) required to evaluate All thresholds.
        /// </summary>
        public int SamplesRequiredToEvaluate
        {
            get
            {
                var maxSamplesRequired = -1;
                GetDefinedThresholds().ForEach(
                    t => maxSamplesRequired = Math.Max(t.SamplesRequiredToExceedThreshold, maxSamplesRequired));
                return maxSamplesRequired;
            }
        }

        public TargetThresholdEvaluation Evaluate(decimal actualValue)
        {
            return Evaluate(new List<decimal?> {actualValue});
        }

        public TargetThresholdEvaluation Evaluate(List<decimal?> actualValues)
        {
            if (neverToExceedMaximum != null)
            {
                var evaluation = neverToExceedMaximum.Evaluate(actualValues);
                if (evaluation.ExceededThreshold)
                {
                    return new TargetThresholdEvaluation(TargetThresholdExcessLevel.NeverToExceedMax,
                        neverToExceedMaximum.ThresholdValue,
                        actualValues.Last(),
                        evaluation.ThresholdGaps.Last());
                }
            }

            if (neverToExceedMinimum != null)
            {
                var evaluation = neverToExceedMinimum.Evaluate(actualValues);
                if (evaluation.ExceededThreshold)
                {
                    return new TargetThresholdEvaluation(TargetThresholdExcessLevel.NeverToExceedMin,
                        neverToExceedMinimum.ThresholdValue,
                        actualValues.Last(),
                        evaluation.ThresholdGaps.Last());
                }
            }

            if (maximum != null)
            {
                var evaluation = maximum.Evaluate(actualValues);
                if (evaluation.ExceededThreshold)
                {
                    return new TargetThresholdEvaluation(TargetThresholdExcessLevel.StandardMax,
                        maximum.ThresholdValue,
                        actualValues.Last(),
                        evaluation.ThresholdGaps.Last());
                }
            }

            if (minimum != null)
            {
                var evaluation = minimum.Evaluate(actualValues);
                if (evaluation.ExceededThreshold)
                {
                    return new TargetThresholdEvaluation(TargetThresholdExcessLevel.StandardMin,
                        minimum.ThresholdValue,
                        actualValues.Last(),
                        evaluation.ThresholdGaps.Last());
                }
            }

            return new TargetThresholdEvaluation(actualValues.Last());
        }

        public bool AreWithinPreApprovedLimits()
        {
            return GetDefinedThresholds().TrueForAll(t => t.IsWithinPreApprovedLimit());
        }

        /// <summary>
        ///     Returns target thresholds for evaluating only a single actual value (that is, assumes the
        ///     samples required for each threshold is 1).
        ///     <code>null</code> if All values are null.
        /// </summary>
        public static TargetThresholds CreateForEvaluatingSingleActualValue(decimal? neverToExceedMinimum,
            decimal? minimum,
            decimal? maximum,
            decimal? neverToExceedMaximum)
        {
            try
            {
                return new TargetThresholds(MinThreshold.Create(neverToExceedMinimum, 1),
                    MinThreshold.Create(minimum, 1),
                    MaxThreshold.Create(maximum, 1),
                    MaxThreshold.Create(neverToExceedMaximum, 1));
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        private List<Threshold> GetDefinedThresholds()
        {
            var definedThresholds = new List<Threshold>(4);
            AddToListIfNotNull(definedThresholds, neverToExceedMinimum);
            AddToListIfNotNull(definedThresholds, minimum);
            AddToListIfNotNull(definedThresholds, maximum);
            AddToListIfNotNull(definedThresholds, neverToExceedMaximum);
            return definedThresholds;
        }

        private static void AddToListIfNotNull(ICollection<Threshold> definedThresholds, Threshold threshold)
        {
            if (threshold != null)
            {
                definedThresholds.Add(threshold);
            }
        }
    }
}