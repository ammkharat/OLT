using System.Globalization;
using System.Threading;

namespace Com.Suncor.Olt.Common.Localization
{
    public class CultureInfoTestHelper
    {
        public static void SetFormatsForEnglishFromResourceFile()
        {
            // Suncor uses en-US locale for Canada and US
            CultureInfo specificCulture = CultureInfo.CreateSpecificCulture("en-US");
            SetFormats(specificCulture);
        }

        public static void SetFormatsForFrenchFromResourceFile()
        {
            CultureInfo specificCulture = CultureInfo.CreateSpecificCulture("fr");
            SetFormats(specificCulture);            
        }

        private static void SetFormats(CultureInfo specificCulture)
        {
            LocaleSpecificFormatPatternResources.Culture = specificCulture;

            Thread.CurrentThread.CurrentCulture = specificCulture;
            Thread.CurrentThread.CurrentUICulture = specificCulture;

            DateTimeFormatInfo dateTimeFormatInfo = specificCulture.DateTimeFormat;

            Thread.CurrentThread.CurrentCulture = specificCulture;
            Thread.CurrentThread.CurrentUICulture = specificCulture;

            dateTimeFormatInfo.ShortDatePattern = LocaleSpecificFormatPatternResources.ShortDatePattern;
            dateTimeFormatInfo.LongDatePattern = LocaleSpecificFormatPatternResources.LongDatePattern;

            dateTimeFormatInfo.ShortTimePattern = LocaleSpecificFormatPatternResources.ShortTimePattern;
            dateTimeFormatInfo.LongTimePattern = LocaleSpecificFormatPatternResources.LongTimePattern;

            Thread.CurrentThread.CurrentCulture = specificCulture;
            Thread.CurrentThread.CurrentUICulture = specificCulture;
        }
    }
}
