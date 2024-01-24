using System;
using System.Text.RegularExpressions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class GasLimitRange : ComparableObject
    {
        public const double DEFAULT_LOWER_BOUND = 0;

        public static readonly GasLimitRange EmptyLimitRange = new GasLimitRange(null, null);

        private double? maxValue;
        private double? minValue;

        public GasLimitRange(double maxValue)
            : this(DEFAULT_LOWER_BOUND, maxValue)
        {
        }

        public GasLimitRange(double? minValue, double? maxValue)
        {
            this.maxValue = maxValue;
            this.minValue = minValue;
        }

        public double? Max
        {
            get { return maxValue; }
        }

        public double? Min
        {
            get { return minValue; }
        }


        public bool ContainsInclusive(double value)
        {
            return ContainsInclusive(new GasLimitRange(value, value));
        }

        public bool ContainsInclusive(GasLimitRange rhsRange)
        {
            var myMin = minValue.HasValue ? minValue.Value : double.MinValue;
            var myMax = maxValue.HasValue ? maxValue.Value : double.MaxValue;

            var rhsMin = rhsRange.minValue.HasValue ? rhsRange.minValue.Value : myMin;
            var rhsMax = rhsRange.maxValue.HasValue ? rhsRange.maxValue.Value : myMax;

            var validLowerBound = myMin <= rhsMin && rhsMin <= myMax;
            var validUpperBound = myMax >= rhsMax && rhsMax >= myMin;

            return validLowerBound && validUpperBound;
        }

        public GasLimitRange LowerOf(GasLimitRange rightHandSide)
        {
            var leftMax = maxValue.HasValue ? maxValue.Value : double.MaxValue;
            var rightMax = rightHandSide.maxValue.HasValue ? rightHandSide.maxValue.Value : double.MaxValue;

            return leftMax < rightMax ? this : rightHandSide;
        }

        public string ToLimitStringWithUnit(GasTestElementInfo gasTestElementInfo)
        {
            return ToLimitStringWithUnit(gasTestElementInfo.IsRangedLimit, gasTestElementInfo.DecimalPlaceCount,
                gasTestElementInfo.Unit);
        }

        public string ToLimitStringWithUnit(bool inRangedFormat, int decimalPlaceCount, GasLimitUnit unit)
        {
            return Equals(EmptyLimitRange)
                ? string.Empty
                : ToLimitString(inRangedFormat, decimalPlaceCount) + " " + unit.UnitName;
        }

        public string ToLimitString(bool inRangedFormat, int decimalPlaceCount)
        {
            if (inRangedFormat)
            {
                return minValue.HasValue && maxValue.HasValue
                    ? FormatDouble(minValue.Value, decimalPlaceCount) + "-" +
                      FormatDouble(maxValue.Value, decimalPlaceCount)
                    : string.Empty;
            }
            return maxValue.HasValue ? FormatDouble(maxValue.Value, decimalPlaceCount) : string.Empty;
        }

        private static string FormatDouble(double value, int decimalPlaceCount)
        {
            if (decimalPlaceCount < 0)
                decimalPlaceCount = 0;

            var FORMAT = string.Format("{{0:F{0}}}", decimalPlaceCount);
            return string.Format(FORMAT, value);
        }

        public override string ToString()
        {
            if (maxValue == null && minValue == null)
                return string.Empty;
            if (maxValue.HasValue && minValue.HasNoValue())
                return maxValue.Value.ToString();
            if (maxValue.HasNoValue() && minValue.HasValue)
                return minValue.Value.ToString();

            return minValue + "-" + maxValue;
        }

        public static GasLimitRange FromString(string strValue)
        {
            double? max;
            double? min;
            string errorMessage;

            return TryParse(strValue, out min, out max, out errorMessage) ? new GasLimitRange(min, max) : null;
        }

        public static bool IsValid(string strValue, bool isRanged, out string errorMessage)
        {
            double? min;
            double? max;

            return IsValidPattern(strValue, isRanged, out errorMessage) &&
                   TryParse(strValue, out min, out max, out errorMessage);
        }

        private static bool IsValidPattern(string strValue, bool isRanged, out string errorMessage)
        {
            const string maxTwoDecimalPlaceNumberPattern = @"\s*[0-9]*(\.[0-9][0-9]?)?\s*";
            var pattern = "^" + maxTwoDecimalPlaceNumberPattern;
            pattern += isRanged ? @"-" + maxTwoDecimalPlaceNumberPattern : "$";

            errorMessage = string.Empty;

            if (strValue.IsNullOrEmptyOrWhitespace())
                return true;

            if (Regex.IsMatch(strValue, pattern) == false)
            {
                errorMessage = isRanged
                    ? StringResources.GasLimitRange_InvalidPatternRanged
                    : StringResources.GasLimitRange_InvalidPatternUnranged;
                return false;
            }
            return true;
        }

        private static bool TryParse(string strValue, out double? leftNumber, out double? rightNumber,
            out string errorMessage)
        {
            leftNumber = null;
            rightNumber = null;
            double min;
            double max;

            errorMessage = string.Empty;

            if (strValue.IsNullOrEmptyOrWhitespace())
            {
                return true;
            }

            var dashPosition = strValue.IndexOf('-');
            if (dashPosition < 0 && strValue.Trim().TryParseNumber(out max))
            {
                leftNumber = DEFAULT_LOWER_BOUND;
                rightNumber = max;
                return true;
            }

            if (dashPosition > 0 &&
                strValue.Substring(0, dashPosition).Trim().TryParseNumber(out min) &&
                strValue.Substring(dashPosition + 1).Trim().TryParseNumber(out max))
            {
                leftNumber = min;
                rightNumber = max;
                if (leftNumber > rightNumber)
                {
                    errorMessage = StringResources.GasLimitRange_NumbersOutOfOrder;
                    return false;
                }
                return true;
            }

            errorMessage = StringResources.GasLimitRange_UnrecognizedFormat;
            return false;
        }
    }

    public static class RangeExtensions
    {
        public static bool OutsideOf(this double? value, GasLimitRange range)
        {
            return value.HasValue && !range.ContainsInclusive(value.Value);
        }
    }
}