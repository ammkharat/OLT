using System;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public static class OpmXhqImporterDataConversionUtility
    {
        public static string ConvertNullableDecimalToStringValue(decimal? toeLimitValue)
        {
            return toeLimitValue.HasValue ? toeLimitValue.ToString() : string.Empty;
        }

        public static DateTime ConvertNullableDateTimeToDateTimeValue(DateTime? nullableDateTimeValue)
        {
            return nullableDateTimeValue.HasValue ? nullableDateTimeValue.Value : DateTime.MinValue;
        }

        public static ToeType GetToeType(string toeType)
        {
            var toeTypeUpper = toeType.ToUpper();

            if (toeTypeUpper == ToeType.HighSol.Name.ToUpper())
            {
                return ToeType.HighSol;
            }

            if (toeTypeUpper == ToeType.LowSol.Name.ToUpper())
            {
                return ToeType.LowSol;
            }

            if (toeTypeUpper == ToeType.HighSl.Name.ToUpper())
            {
                return ToeType.HighSl;
            }

            if (toeTypeUpper == ToeType.LowSl.Name.ToUpper())
            {
                return ToeType.LowSl;
            }

            if (toeTypeUpper == ToeType.HighTarget.Name.ToUpper())
            {
                return ToeType.HighTarget;
            }

            if (toeTypeUpper == ToeType.LowTarget.Name.ToUpper())
            {
                return ToeType.LowTarget;
            }

            var invalidToe = ToeType.InvalidToeType;
            invalidToe.TagValue = toeType;

            return invalidToe;
        }

        public static ExcursionStatus GetExcursionStatus(string status)
        {
            var statusUpper = status.ToUpper();

            if (status == ExcursionStatus.Open.Name.ToUpper())
            {
                return ExcursionStatus.Open;
            }

            if (status == ExcursionStatus.Closed.Name.ToUpper())
            {
                return ExcursionStatus.Closed;
            }

            var invalidExcursionStatus = ExcursionStatus.InvalidExcursionStatus;
            invalidExcursionStatus.TagValue = status;

            return invalidExcursionStatus;
        }

        public static decimal ConvertNullableDecimalToDecimalValue(decimal? nullableDecimalValue)
        {
            return nullableDecimalValue.HasValue ? nullableDecimalValue.Value : 0.0m;
        }
    }
}