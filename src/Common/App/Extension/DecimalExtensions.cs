using System;
using System.Globalization;

namespace Com.Suncor.Olt.Common.Extension
{
    public static class DecimalExtensions
    {
        public static string Format(this decimal? value)
        {
            return value.HasValue ? value.Value.ToString("N2") : String.Empty;
        }

        public static string Format(this decimal value)
        {
            return value.ToString("N2");
        }

        public static string FormatToThreePlaces(this decimal? value)
        {
            return value.HasValue ? value.Value.ToString("N3") : String.Empty;
        }

        public static string FormatToThreePlaces(this decimal value)
        {
            return value.ToString("N3");
        }

        public static bool TryParse(this string strVal, out decimal result)
        {
            return Decimal.TryParse(strVal, out result);
        }

        public static decimal? ParseOrNull(this string strVal)
        {
            decimal value;
            if (strVal.TryParse(out value))
            {
                return value;
            }
            return new decimal?();
        }

        public static string ToCurrencyForLosses(this decimal value)
        {
            return value.ToCurrency(0);
        }
        //RITM0252906-changed by Mukesh
        public static string ToCurrency(this decimal value)
        {
            //return value.ToCurrency(2);
            return value.ToCurrency(3);
        }

        public static bool IsWithinRange(this decimal value, decimal start, decimal end)
        {
            return value >= start && value <= end;
        }

        public static bool IsWithinRange(this decimal? value, decimal start, decimal end)
        {
            return value.HasValue && value.Value >= start && value.Value <= end;
        }

        private static string ToCurrency(this decimal value, int decimalDigitCount)
        {
            var currentCulture = (CultureInfo) CultureInfo.CurrentCulture.Clone();
            var numberFormatInfo = currentCulture.NumberFormat;
            numberFormatInfo.CurrencyDecimalDigits = decimalDigitCount;
            return value.ToString("C", numberFormatInfo);
        }
    }
}