using System.Globalization;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Integration.Handlers
{
    public class LanguageCode
    {
        public static readonly LanguageCode English = new LanguageCode("EN", CultureInfo.GetCultureInfo("en"));
        public static readonly LanguageCode French = new LanguageCode("FR", CultureInfo.GetCultureInfo("fr"));

        private readonly CultureInfo cultureInfo;
        private readonly string sapCode;

        private LanguageCode(string sapCode, CultureInfo cultureInfo)
        {
            this.sapCode = sapCode;
            this.cultureInfo = cultureInfo;
        }

        public string SapCode
        {
            get { return sapCode; }
        }

        public CultureInfo CultureInfo
        {
            get { return cultureInfo; }
        }

        public static CultureInfo GetCultureInfoFromSAPALanguageCode(string code)
        {
            CultureInfo cultureInfo;

            if (code != null)
            {
                // This E and F code is just to be safe. We aren't totally confident that we are going to get the EN and FR
                // that we were told, since the original spec was for E of F. This can be taken out in 4.2 or later.
                if (code == "E")
                {
                    cultureInfo = English.CultureInfo;
                }
                else if (code == "F")
                {
                    cultureInfo = French.CultureInfo;
                }
                else
                {
                    cultureInfo = code == French.SapCode ? French.CultureInfo : English.CultureInfo;
                }
            }
            else
            {
                cultureInfo = English.CultureInfo;
            }

            return cultureInfo;
        }

        public static string GetCultureStringFromSAPLanguageCode(string code)
        {
            string culture;

            if (code != null)
            {
                // This E and F code is just to be safe. We aren't totally confident that we are going to get the EN and FR
                // that we were told, since the original spec was for E of F. This can be taken out in 4.2 or later.
                if (code == "E")
                {
                    culture = Culture.DEFAULT_CULTURE_NAME;
                }
                else if (code == "F")
                {
                    culture = Culture.FrenchCultureName;
                }
                else
                {
                    culture = code == French.SapCode ? Culture.FrenchCultureName : Culture.DEFAULT_CULTURE_NAME;
                }
            }
            else
            {
                culture = Culture.DEFAULT_CULTURE_NAME;
            }

            return culture;
        }
    }
}