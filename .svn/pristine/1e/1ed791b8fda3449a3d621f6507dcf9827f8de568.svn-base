using System;
using System.Collections.Generic;
using System.Globalization;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Utility
{
    public static class WorkPermitAttributesParseUtility
    {
        private const char Delimiter = '\\';

        public static string[] ConvertSAPAttributeStringToArray(string attributeString)
        {
            if (attributeString.IsNullOrEmptyOrWhitespace())
                return new string[0];

            string[] attribsStringArray;

            attributeString = attributeString.Trim();

            if (attributeString.Contains(Delimiter.ToString(CultureInfo.InvariantCulture)))
            {
                // new way
                attribsStringArray = attributeString.Split(Delimiter);
            }
            else
            {
                // old way
                var charArray = attributeString.ToCharArray();
                attribsStringArray = Array.ConvertAll(charArray, c => c + string.Empty);
            }

            if (attribsStringArray.Length > 0)
            {
                var attribsList = new List<string>(attribsStringArray);
                attribsList.RemoveAll(s => string.Equals(s, string.Empty, StringComparison.Ordinal));
                attribsStringArray = attribsList.ToArray();
            }

            return attribsStringArray;
        }
    }
}