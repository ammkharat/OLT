using System;

namespace Com.Suncor.Olt.Common.Extension
{
    public static class DoubleExtensions
    {
        public static string Format(this double? value)
        {
            return value.HasValue ? value.Value.ToString() : String.Empty;
        }

        /// <summary>
        ///     Parse string to number independent of cultural info setting.
        ///     As the OLT does not and should not depend on the machine that it's running on,
        ///     any parsing should be done via this method.
        /// </summary>
        public static bool TryParseNumber(this string strVal, out double result)
        {
            return Double.TryParse(strVal, out result);
        }
    }
}