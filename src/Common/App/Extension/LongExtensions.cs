using System;

namespace Com.Suncor.Olt.Common.Extension
{
    public static class LongExtensions
    {
        public static bool TryParse(this string strVal, out long result)
        {
            return Int64.TryParse(strVal, out result);
        }
    }
}