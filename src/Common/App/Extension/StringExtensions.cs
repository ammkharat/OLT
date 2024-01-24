using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Extension
{
    public static class StringExtensions
    {
        private const string NewLineReplacement = " * ";
        private const string CommaAndSpace = ", ";
        private const string Token = "olt-encrypt";
        private static readonly string newLinePattern = @"\s*" + Environment.NewLine + @"+\s*";

        private static readonly Regex newLineRegularExpression = new Regex(newLinePattern);
        private static readonly Regex regEx = new Regex(@".+, .+ \(#.+\)");

        public static bool Exceeds(this string value, int maxLength)
        {
            if (value.IsNullOrEmptyOrWhitespace()) return false;

            return value.Length > maxLength;
        }

        /// <summary>
        ///     Checks if a string is null, empty or contains only whitespace
        /// </summary>
        /// <param name="aValue"></param>
        /// <returns></returns>
        public static bool IsNullOrEmptyOrWhitespace(this string aValue)
        {
            // TODO: Remove this and just use what's built into the framework?
            return String.IsNullOrWhiteSpace(aValue);
        }

        /// <summary>
        ///     Checks if a string is equal to string.Empty
        /// </summary>
        /// <param name="aValue"></param>
        /// <returns></returns>
        private static bool IsEmpty(this string aValue)
        {
            return String.Equals(String.Empty, aValue.Trim());
        }

        /// <summary>
        ///     Checks if a non-null string has an empty value.
        /// </summary>
        /// <param name="aValue"></param>
        /// <returns></returns>
        public static bool HasEmptyValue(this string aValue)
        {
            return aValue != null && aValue.IsEmpty();
        }

        /// <summary>
        ///     Returns null if a string is empty otherwise returns the string
        /// </summary>
        /// <param name="stringToConvert"></param>
        /// <returns></returns>
        public static string EmptyToNull(this string stringToConvert)
        {
            return stringToConvert.IsNullOrEmptyOrWhitespace() ? null : stringToConvert;
        }

        /// <summary>
        ///     Tests whether given string has value or not (opposite to <code>IsEmpty</code>.
        /// </summary>
        public static bool HasValue(this string test)
        {
            return !test.IsNullOrEmptyOrWhitespace();
        }

        public static string NullToEmpty(this string stringToConvert)
        {
            return stringToConvert ?? string.Empty;
        }

        /// <summary>
        ///     Validates that a Number is
        /// </summary>
        /// <param name="aString"></param>
        /// <returns></returns>
        public static bool IsIntegralNumber(this string aString)
        {
            long aNumber;
            return aString.TryParse(out aNumber);
        }

        public static string CapitalizeFully(this string str)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            var textInfo = new CultureInfo(currentCulture.Name, false).TextInfo;
            return textInfo.ToTitleCase(str.ToLower());
        }

        public static string LeftSubstring(this string value, int length)
        {
            if (length > value.Length)
            {
                return value;
            }

            return value.Substring(0, length);
        }

        /// <summary>
        ///     Replaces all whitespace (including new line) between string with ' * '
        /// </summary>
        /// <param name="stringWithLineBreaks"></param>
        /// <returns></returns>
        public static string ReplaceWhitespaceWithDelimiter(this string stringWithLineBreaks)
        {
            if (stringWithLineBreaks.HasValue())
            {
                return newLineRegularExpression.Replace(stringWithLineBreaks, NewLineReplacement);
            }

            return stringWithLineBreaks != null ? String.Empty : null;
        }

        public static string NullableToString<T>(this T? value) where T : struct
        {
            return value.HasValue ? value.Value.ToString() : String.Empty;
        }

        public static string NullableToString(this object value)
        {
            return value != null ? value.ToString() : string.Empty;
        }

        public static string BuildNameStringFromRoleList(this List<Role> roleList)
        {
            return roleList.BuildCommaSeparatedList(role => role.Name);
        }

        public static string BuildNameStringFromWorkAssignmentList(this List<WorkAssignment> workAssignments)
        {
            return workAssignments.BuildCommaSeparatedList(wa => wa.Name);
        }

        public static string ToSemiColonSeparatedString<T>(this IList<T> items)
        {
            return items.ToDelimitedString("; ");
        }

        public static string ToCommaSeparatedString<T>(this IList<T> items)
        {
            return items.ToDelimitedString(", ");
        }

        public static string ToDelimitedString<T>(this IList<T> items, char delimiter)
        {
            return items.ToDelimitedString(new String(delimiter, 1));
        }

        private static string ToDelimitedString<T>(this IList<T> items, string delimiter)
        {
            if (items == null)
                return string.Empty;

            var sb = new StringBuilder();
            for (var i = 0; i < items.Count; i++)
            {
                if (i > 0)
                {
                    sb.Append(delimiter);
                }
                sb.Append(items[i]);
            }
            return sb.ToString();
        }

        public static string BuildCommaSeparatedList<T>(this ICollection<T> theList, Converter<T, string> converter)
        {
            var stringList = theList.ConvertAll(converter);
            return stringList.BuildCommaSeparatedList();
        }

        public static string Join(this ICollection<string> theList, string seperator)
        {
            if (theList == null || theList.Count == 0) return String.Empty;

            return string.Join(seperator, theList.ToArray());
        }

        public static string BuildCommaSeparatedList(this ICollection<string> theList)
        {
            return Join(theList, CommaAndSpace);
        }

        public static string BuildCommaSeparatedList<T>(this ICollection<T> theList)
        {
            return theList.BuildCommaSeparatedList(v => Convert.ToString(v));
        }

        public static string BuildIdStringFromList<T>(this IEnumerable<T> list) where T : DomainObject
        {
            return
                list.FindAll(i => i != null && i.Id.HasValue)
                    .BuildCommaSeparatedList(item => item.IdValue.ToString(CultureInfo.InvariantCulture));
        }

        public static List<string> BuildListFromCommaSeparatedList(this string csvList)
        {
            if (csvList.IsNullOrEmptyOrWhitespace())
                return new List<string>(0);

            var strings = csvList.Split(',');
            return strings.ConvertAll(s => s.Trim());
        }

        public static long[] BuildLongArrayFromCsv(this string p)
        {
            if (!p.IsNullOrEmptyOrWhitespace())
            {
                var stringSplit = p.Split(',');
                return Array.ConvertAll(stringSplit, Int64.Parse);
            }
            return new long[0];
        }


        public static string BuildMonthStringFromMonthList(this List<Month> monthsToInclude)
        {
            monthsToInclude.Sort();
            return monthsToInclude.BuildCommaSeparatedList(month => month.Name);
        }

        public static string ConvertCamelCaseFieldName(this string camelCaseFieldName)
        {
            var convertedFieldName = new StringBuilder();
            for (var i = 0; i < camelCaseFieldName.Length; i++)
            {
                var c = camelCaseFieldName[i];
                if (!c.IsAlphabeticalCharacter())
                {
                    convertedFieldName.Append(c);
                }
                else
                {
                    if (i == 0)
                    {
                        convertedFieldName.Append(c.ConvertCharacterToUpperCase());
                    }
                    else
                    {
                        var previousCharacter = camelCaseFieldName[i - 1];
                        if (previousCharacter.IsLowerCaseCharacter() && c.isUpperCaseCharacter())
                        {
                            convertedFieldName.Append(' ');
                            convertedFieldName.Append(c);
                        }
                        else
                        {
                            convertedFieldName.Append(c);
                        }
                    }
                }
            }
            return convertedFieldName.ToString();
        }

        public static string ConvertFirstCharacterToUpperCase(this string source)
        {
            var firstCharacter = source[0];
            if (firstCharacter >= 'a' && firstCharacter <= 'z')
            {
                var upperCaseCharacter = firstCharacter.ConvertCharacterToUpperCase();
                var result = upperCaseCharacter + source.Substring(1);
                return result;
            }
            return source;
        }

        public static bool TrimAndEqual(this string aString, string bString)
        {
            if (aString == null && bString == null)
                return true;

            return aString != null && (aString.Equals(bString) ||
                                       aString.Trim().Equals(bString.Trim()));
        }

        public static string TrimOrEmpty(this string aString)
        {
            return aString.HasValue() ? aString.Trim() : string.Empty;
        }

        public static string TrimOrNull(this string aString)
        {
            return aString.HasValue() ? aString.Trim() : null;
        }

        public static string CreateStringOfConsecutiveDigits(this int length)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                sb.Append(i%10);
            }
            return sb.ToString();
        }

        public static MemoryStream CreateMemoryStream(this string data)
        {
            return new MemoryStream(Encoding.Default.GetBytes(data));
        }

        public static bool IsValidUncPath(this string data)
        {
            try
            {
                var directoryInfo = new DirectoryInfo(data);
                return directoryInfo.IsUncDrive();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsValidUri(this string data)
        {
            Uri output;
            return Uri.TryCreate(data, UriKind.Absolute, out output);
        }

        public static string ToDatabaseSearchString(this string data)
        {
            var result = data.Trim()
                .Replace("*", " ")
                .Replace("[", "[[]")
                .Replace("%", "[%]")
                .Replace("_", "[_]")
                ;
            while (result.Contains("  "))
            {
                result = result.Replace("  ", " ");
            }
            return result.Trim();
        }

        public static bool EqualsIgnoreCase(this string data, string other)
        {
            return string.Equals(data, other, StringComparison.OrdinalIgnoreCase);
        }

        private static byte[] GenerateKey()
        {
            var hashProvider = new MD5CryptoServiceProvider();
            return hashProvider.ComputeHash(Encoding.UTF8.GetBytes(Token));
        }

        public static string Encrypt(this string data)
        {
            var dataInBytes = Encoding.UTF8.GetBytes(data);
            var encyrptionAlg = TripleDES.Create();
            encyrptionAlg.Key = GenerateKey();
            encyrptionAlg.Mode = CipherMode.ECB;

            using (var memoryStream = new MemoryStream())
            {
                using (var cs = new CryptoStream(memoryStream, encyrptionAlg.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataInBytes, 0, dataInBytes.Length);
                    cs.FlushFinalBlock();

                    var encryptedBytes = memoryStream.ToArray();
                    return Convert.ToBase64String(encryptedBytes);
                }
            }
        }

        public static string Decrypt(this string data)
        {
            var encrptedBytes = Convert.FromBase64String(data);
            var tripleDes = TripleDES.Create();
            tripleDes.Key = GenerateKey();
            tripleDes.Mode = CipherMode.ECB;

            using (var memoryStream = new MemoryStream())
            {
                using (var cs = new CryptoStream(memoryStream, tripleDes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(encrptedBytes, 0, encrptedBytes.Length);
                    cs.FlushFinalBlock();
                }
                var decryptedBytes = memoryStream.ToArray();
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }

        public static string TrimWhitespace(this string value)
        {
            if (value != null)
            {
                return value.Trim();
            }

            return null;
        }

        public static string Truncate(this string value, int numberOfChars)
        {
            return value.Truncate(numberOfChars, "...");
        }

        public static string Truncate(this string value, int numberOfChars, string postfix)
        {
            if (value == null || value.Length <= numberOfChars)
            {
                return value;
            }

            if (numberOfChars <= postfix.Length)
            {
                numberOfChars = postfix.Length + 1;
            }

            var substring = value.Substring(0, numberOfChars - postfix.Length);
            return substring + postfix;
        }

        public static string ToCleanFileName(this string value)
        {
            var newValue = value;
            newValue = Regex.Replace(newValue, "[/]", "_");
            newValue = Regex.Replace(newValue, "[^a-zA-Z0-9_-]", " ");
            return newValue;
        }

        public static string AppendSpace(this string value)
        {
            return string.Format("{0} ", value);
        }

        public static bool IsRtf(this string value)
        {
            return value.StartsWith(@"{\rtf1");
        }

        public static string BuildCommaSeparatedList(this List<long> listOfLongs)
        {
            return BuildCommaSeparatedList(listOfLongs, l => l.ToString(CultureInfo.InvariantCulture));
        }

        public static T Parse<T>(this string value)
        {
            if (Enum.IsDefined(typeof (T), value))
            {
                return (T) Enum.Parse(typeof (T), value);
            }
            throw new Exception(string.Format("Could not Parse {0} to type {1}.", value, typeof (T)));
        }

        public static string RemoveStringFromStartOf(this string value, string stringToRemove)
        {
            if (value.StartsWith(stringToRemove))
            {
                var lengthToStartAt = stringToRemove.Length;
                return value.Substring(lengthToStartAt);
            }
            return value;
        }
        
        public static string RemoveAllWhiteSpace(this string value)
        {
            if (value != null)
            {
                return(Regex.Replace(value, @"\s+", ""));
            }
            return null;
        }

        // Example is "Smith, Bob (#12345)"

        public static bool IsInFormatOfEdmontonCardSwipeSystem(this string value)
        {
            return regEx.IsMatch(value);
        }

        /// <summary>
        ///     mangesh: Checks if a string is alphanumeric or not
        /// </summary>
        /// <param name="aValue"></param>
        /// <returns></returns>
        public static bool IsAlphaNumeric(this string aValue)
        {
            if (aValue.IsNullOrEmptyOrWhitespace()) return false;
            Regex numeric = new Regex(@"^[0-9]\d*(\.\d+)?$");
            return !numeric.IsMatch(aValue);
        }
    }
}