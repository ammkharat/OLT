using System;
using System.Globalization;
using System.Threading;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Common.Localization
{
    public class Culture
    {
        public const string DEFAULT_CULTURE_NAME = "en";
        public const string FrenchCultureName = "fr";
        private const bool UseUserOverride = false;

        private static readonly ILog logger = GenericLogManager.GetLogger<Culture>();

        public static bool IsDefault
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture.Name.StartsWith(DEFAULT_CULTURE_NAME,
                    StringComparison.Ordinal);
            }
        }

        public static bool IsFrench
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture.Name.StartsWith(FrenchCultureName, StringComparison.Ordinal);
            }
        }

        public static CultureInfo CultureInfo
        {
            get { return Thread.CurrentThread.CurrentUICulture; }
        }

        private static void SetLocalizedFormatting(CultureInfo currentCulture)
        {
            var dateTimeFormatInfo = currentCulture.DateTimeFormat;
            dateTimeFormatInfo.ShortDatePattern = LocaleSpecificFormatPatternResources.ShortDatePattern;
            dateTimeFormatInfo.LongDatePattern = LocaleSpecificFormatPatternResources.LongDatePattern;
            dateTimeFormatInfo.ShortTimePattern = LocaleSpecificFormatPatternResources.ShortTimePattern;
            dateTimeFormatInfo.LongTimePattern = LocaleSpecificFormatPatternResources.LongTimePattern;

            var numberFormatInfo = currentCulture.NumberFormat;
            numberFormatInfo.CurrencySymbol = LocaleSpecificFormatPatternResources.CurrencySymbol;
        }

        public static void SetSpecificCultureOnThread(string cultureInfoName)
        {
            CultureInfo specificCulture;
            try
            {
                if (!string.IsNullOrEmpty(cultureInfoName))
                {
                    specificCulture = CultureInfo.CreateSpecificCulture(cultureInfoName);
                }
                else
                {
                    specificCulture = CultureInfo.CreateSpecificCulture(DEFAULT_CULTURE_NAME);
                }
            }
            catch (Exception e)
            {
                logger.Error("Cannot create culture for " + cultureInfoName + ". Using default culture. Exception: " + e);
                specificCulture = CultureInfo.CreateSpecificCulture(DEFAULT_CULTURE_NAME);
            }

            SetSpecificCultureOnThread(specificCulture);
        }

        public static void SetSpecificCultureOnThread(CultureInfo specificCulture)
        {
            // CultureInfo Customization needs to be removed. Some client machines are improperly configured. 
            // Particularly, NumberFormat.PositiveSign has been set to "0" (or using any digit as positive sign for that matter), 
            // and it can cause the app to crash during parsing string to number.
            specificCulture = new CultureInfo(specificCulture.Name, UseUserOverride);

            // Before attempting to access any resources (including date/time/number formats, we have to have a Culture set)
            Thread.CurrentThread.CurrentCulture = specificCulture;
            Thread.CurrentThread.CurrentUICulture = specificCulture;
            // This has to come after setting the Culture of the thread.
            SetLocalizedFormatting(specificCulture);
        }
    }
}