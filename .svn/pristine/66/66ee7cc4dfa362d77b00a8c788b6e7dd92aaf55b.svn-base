using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Extension
{
    [TestFixture]
    public class StringExtensionsTest
    {
        [Test]
        public void ShouldReturnTrueWhenUsingAWhitespaceOnlyString()
        {
            Assert.IsTrue("   ".IsNullOrEmptyOrWhitespace());
        }

        [Test]
        public void ShouldReturnTrueWhenUsingNullString()
        {
            const string someString = null;
            Assert.IsTrue(someString.IsNullOrEmptyOrWhitespace());
        }

        [Test]
        public void ShouldRemoveAllWhiteSpaceFromString()
        {
            string test = "UP2-P052, UP2-P056-BLDG, UP2-P056-CKPT, UP2-P056-PEW2, UP2-P057".RemoveAllWhiteSpace();
            Assert.IsFalse(test.Contains(" "));
        }

        [Test]
        public void ShouldReturnTrueIfPassingEmptyStringToIsEmpty()
        {
            string test = string.Empty;
            Assert.IsTrue(test.IsNullOrEmptyOrWhitespace());
        }

        [Test]
        public void ShouldReturnTrueIfPassingNullStringToIsEmpty()
        {
            const string test = null;
            Assert.IsTrue(test.IsNullOrEmptyOrWhitespace());
        }

        [Test]
        public void ShouldReturnFalseIfPassingNonEmptyStringToIsEmpty()
        {
            const string test = "test value";
            Assert.IsFalse(test.IsNullOrEmptyOrWhitespace());
        }

        [Test]
        public void ShouldSplitCommaSeparatedStringsIntoIntegerArray()
        {
            long[] integers = "23,54".BuildLongArrayFromCsv();
            Assert.AreEqual(2, integers.Length);
            Assert.AreEqual(23, integers[0]);
            Assert.AreEqual(54, integers[1]);

            Assert.AreEqual(0, " ".BuildLongArrayFromCsv().Length);
            Assert.AreEqual(0, StringExtensions.BuildLongArrayFromCsv(null).Length);
        }

        [Test]
        public void ShouldValidateAGoodNumber()
        {
            Assert.IsTrue("34534".IsIntegralNumber());
        }

        [Test]
        public void ShouldValidateAGoodNegativeNumber()
        {
            Assert.IsTrue("-34534".IsIntegralNumber());
        }

        [Test]
        public void ShouldValidateANegativeDecimalNumber()
        {
            Assert.IsFalse("-345.34".IsIntegralNumber());
        }

        [Test]
        public void ShouldNotValidateAnAlphaNumeric()
        {
            Assert.IsFalse("34f534".IsIntegralNumber());
        }

        [Test]
        public void ShouldNotValidateDecimalNumber()
        {
            Assert.IsFalse(".34534".IsIntegralNumber());
        }

        [Test]
        public void ShouldNotValidateDecimalNumberWithStartingZero()
        {
            Assert.IsFalse("0.34534".IsIntegralNumber());
        }

        [Test]
        public void ShouldNotValidateWholeNumberAndDecimalNumber()
        {
            Assert.IsFalse("234.34534".IsIntegralNumber());
        }

        [Test]
        public void ShouldUpperCaseASentence()
        {
            Assert.AreEqual("Word Two Your Mother", "WORD TWO YOUR MOTHER".CapitalizeFully());
        }

        [Test]
        public void LeftSubstringShouldTruncateToLength()
        {
            Assert.AreEqual(string.Empty, "abcde".LeftSubstring(0));
            Assert.AreEqual("abcd", "abcde".LeftSubstring(4));
            Assert.AreEqual("abcde", "abcde".LeftSubstring(5));
            Assert.AreEqual("abcde", "abcde".LeftSubstring(6));
        }

        [Test]
        public void ShouldBuildMonthStringSortedByMonthValueFromListOfMonths()
        {
            var monthList = new List<Month> {Month.December, Month.August, Month.January};

            const string expectedString = "January, August, December";
            Assert.AreEqual(expectedString, monthList.BuildMonthStringFromMonthList());
        }

        [Test]
        public void ShouldReturnTheSameStringForTwoListOfMonthsInDifferentOrder()
        {
            var monthList1 = new List<Month> {Month.August, Month.May};

            var monthList2 = new List<Month> {Month.May, Month.August};

            string monthString1 = monthList1.BuildMonthStringFromMonthList();
            string monthString2 = monthList2.BuildMonthStringFromMonthList();
            Assert.AreEqual("May, August", monthString1);
            Assert.AreEqual(monthString1, monthString2);
        }

        [Test]
        public void ShouldReplaceLineBreak()
        {
            string testString = "Line1" + Environment.NewLine + "Line2" + Environment.NewLine + Environment.NewLine +
                                "Line3";
            const string expected = "Line1" + " * " + "Line2" + " * " + "Line3";

            Assert.AreEqual(expected, testString.ReplaceWhitespaceWithDelimiter());
        }

        [Test]
        public void ShouldReturnNullForReplaceLineBreakWithNullParam()
        {
            const string testString = null;
            const string expected = null;
            Assert.AreEqual(expected, testString.ReplaceWhitespaceWithDelimiter());
        }

        [Test]
        public void ShouldReturnSameForReplaceLineBreakWithEmptyParam()
        {
            string testString = "     " + Environment.NewLine + "   ";
            string expected = string.Empty;
            Assert.AreEqual(expected, testString.ReplaceWhitespaceWithDelimiter());
        }

        [Test]
        public void ShouldPutOnlyAstrickInForAllWhiteSpaceBetweenTwoLines()
        {
            string testString = "Line1   " + Environment.NewLine + "   Line2";
            const string expected = "Line1" + " * " + "Line2";
            Assert.AreEqual(expected, testString.ReplaceWhitespaceWithDelimiter());
        }

        [Test]
        public void ShouldStripSpaceBetweenNewLines()
        {
            string testString = "Line1   " + Environment.NewLine + "  " + Environment.NewLine + "  Line2";
            const string expected = "Line1" + " * " + "Line2";
            Assert.AreEqual(expected, testString.ReplaceWhitespaceWithDelimiter());
        }

        [Test]
        public void ValidateUrlShouldValidURL()
        {
            Assert.IsFalse("http:\\www.microsoft.com".IsValidUri());
            Assert.IsTrue("http://www.microsoft.com".IsValidUri());

            Assert.IsFalse("\\file015".IsValidUri());
        }

        [Test]
        public void ShouldConvertToDatabaseSearchString()
        {
            Assert.AreEqual("1Ab2C3", "1Ab2C3".ToDatabaseSearchString());
            Assert.AreEqual("1Ab 2C3", "1Ab 2C3".ToDatabaseSearchString());
            Assert.AreEqual("1Ab'2C3", "1Ab'2C3".ToDatabaseSearchString());
            Assert.AreEqual("1Ab''2C3", "1Ab''2C3".ToDatabaseSearchString());
            Assert.AreEqual("1Ab[%]2C3", "1Ab%2C3".ToDatabaseSearchString());
            Assert.AreEqual("1Ab-2C3", "1Ab-2C3".ToDatabaseSearchString());
            Assert.AreEqual("1Ab[_]2C3", "1Ab_2C3".ToDatabaseSearchString());
            Assert.AreEqual("1Ab[[]2]C3", "1Ab[2]C3".ToDatabaseSearchString());
            Assert.AreEqual("1[%]Ab[[]2]C[%]3", "1%Ab[2]C%3".ToDatabaseSearchString());
            Assert.AreEqual("1Ab 2C3", "1Ab*2C3".ToDatabaseSearchString());
            Assert.AreEqual("1Ab#2C3", "1Ab#2C3".ToDatabaseSearchString());
            Assert.AreEqual("1Ab2C3", "  1Ab2C3   ".ToDatabaseSearchString());
            Assert.AreEqual("1 Ab2C3", "  1    Ab2C3   ".ToDatabaseSearchString());
            Assert.AreEqual("!@#$$[%]^&", "!@#$$%^&".ToDatabaseSearchString());
            Assert.AreEqual("", "".ToDatabaseSearchString());
            Assert.AreEqual("& (", "&*(".ToDatabaseSearchString());
        }

        [Test]
        public void EncryptAndDecryptString()
        {
            string text = "test-text";
            string encryptDes = text.Encrypt();

            string result = encryptDes.Decrypt();

            Assert.That(result, Is.EqualTo(text));
        }

        [Test]
        public void ShouldTrimWhitespace()
        {
            string s = "           abc            ";
            Assert.AreEqual("abc", s.TrimWhitespace());

            string sNull = null;
            Assert.IsNull(sNull.TrimWhitespace());

            string sEmpty = string.Empty;
            Assert.AreEqual(string.Empty, sEmpty.TrimWhitespace());
        }

        [Test]
        public void ShouldTruncate()
        {
            Assert.AreEqual("abc...", "abcdefg".Truncate(6));
            Assert.AreEqual("abcdefg", "abcdefg".Truncate(7));
            Assert.AreEqual("abcd[end]", "abcdefghijklmnop".Truncate(9, "[end]"));
            Assert.AreEqual("abc", "abcdef".Truncate(3, ""));

            // if numberOfChars is less than or equal to postfix length, should adjust numberOfChars to one more than length of postfix
            {
                Assert.AreEqual("a...", "abcdefg".Truncate(3, "..."));
                Assert.AreEqual("a...", "abcdefg".Truncate(2, "..."));
            }
        }

        [Test]
        public void ShouldCleanFileName()
        {
            Assert.AreEqual("abcdefghijklmnopqrstuvwxyz", "abcdefghijklmnopqrstuvwxyz".ToCleanFileName());
            Assert.AreEqual("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCleanFileName());
            Assert.AreEqual("0123456789", "0123456789".ToCleanFileName());
            Assert.AreEqual("a c", "a\bc".ToCleanFileName());
            Assert.AreEqual("a            _  -             _   b", @"a`~!@#$%^&*()_+=-[]\\{}|;':"",./<>?b".ToCleanFileName());
        }

        [Test]
        public void ShouldAppendSpace()
        {
            string noSpace = "This string has no space at the end";
            Assert.AreEqual("This string has no space at the end ", noSpace.AppendSpace());

            string nullString = null;
            Assert.AreEqual(" ", nullString.AppendSpace());
        }

        [Test]
        public void ShouldJoin()
        {
            Assert.AreEqual("one--two--three", new List<string> {"one", "two", "three"}.Join("--"));

            List<string> nullList = null;
            Assert.AreEqual("", nullList.Join("whatever"));

            Assert.AreEqual("", new List<string>().Join("--"));
        }

        [Test]
        public void ShouldBuildStringListFromCsvList()
        {
            string cvsList = " 1-2-troy, 4-5-6, this, 6-5-test ";
            List<string> result = cvsList.BuildListFromCommaSeparatedList();

            Assert.That(result.Count, Is.EqualTo(4));

            Assert.That(result[0], Is.EqualTo("1-2-troy"));

            Assert.That(result[3], Is.EqualTo("6-5-test"));
        }

        [Test]
        public void ShouldBuildStringListFromCsvListWithNoSpace()
        {
            string cvsList = "1-2-troy,4-5-6,this,6-5-test";
            List<string> result = cvsList.BuildListFromCommaSeparatedList();

            Assert.That(result.Count, Is.EqualTo(4));

            Assert.That(result[0], Is.EqualTo("1-2-troy"));

            Assert.That(result[3], Is.EqualTo("6-5-test"));
        }

        [Test]
        public void ShouldReturnEmptyStringIfNull()
        {
            string testString = null;
            string result = testString.NullToEmpty();
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void ShouldReturnSameStringIfIsNotNull()
        {
            string testString = "myText";
            string result = testString.NullToEmpty();
            Assert.That(result, Is.EqualTo(testString));
        }

        [Test]
        public void ShouldBuildListOfNamesForRoles()
        {
            Role administratorRole = new Role(1, "admin", string.Empty, true, false, false, false, false, "Admin", Site.OILSAND_ID);
            Role operatorRole = new Role(2, "operator", string.Empty, true, false, false, false, false, "oper", Site.OILSAND_ID);
            Role readOnlyRole = new Role(1, "readonly", string.Empty, true, false, false, false, false, "read", Site.OILSAND_ID);

            List<Role> roles = new List<Role> {administratorRole, operatorRole, readOnlyRole};
            string result = roles.BuildNameStringFromRoleList();
            Assert.That(result, Is.EqualTo("admin, operator, readonly"));
        }

        [Test]
        public void ShouldBuildEmptyStringForNullList()
        {
            IList<string> items = null;
            string result = items.ToDelimitedString('|');
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void ShouldBuildEmptyStringForEmptyList()
        {
            IList<string> items = new List<string>(0);
            string result = items.ToDelimitedString('|');
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void ShouldBuildEmptyListForNullString()
        {
            string testString = null;
            List<string> result = testString.BuildListFromCommaSeparatedList();
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void ShouldBuildEmptyListForEmptyString()
        {
            string testString = string.Empty;
            List<string> result = testString.BuildListFromCommaSeparatedList();
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void ShouldBuildEmptyListForWhitespaceString()
        {
            string testString = "      ";
            List<string> result = testString.BuildListFromCommaSeparatedList();
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void ShouldConverCamelCase()
        {
            string testString = "youAreAwesome";
            string result = testString.ConvertCamelCaseFieldName();
            Assert.That(result, Is.EqualTo("You Are Awesome"));
        }

        [Test]
        public void ShouldBeEqualIgnoringCase()
        {
            string s1 = "thisIsAStrinG,Eh!";
            string s2 = "THISisasTring,eH!";

            Assert.That(s1.EqualsIgnoreCase(s2), Is.True);
        }

        [Test]
        public void ShouldBeEqualIgnoringCaseFrench()
        {
            string s1 = "thisIsAStrinG,Èh!";
            string s2 = "THISisasTring,ÈH!";

            Assert.That(s1.EqualsIgnoreCase(s2), Is.True);
        }

        [Test]
        public void ShouldBeEqualIgnoringCaseFrenchUpper()
        {
            string s1 = "thisIsAStrinG,…h!";
            string s2 = "THISisasTring,ÈH!";

            Assert.That(s1.EqualsIgnoreCase(s2), Is.True);
        }

        [Test]
        public void ShouldNotBeEqualIgnoringCase()
        {
            string s1 = "thisIzzAStrinG,Eh!";
            string s2 = "THISIzAsTring,eH!";

            Assert.That(s1.EqualsIgnoreCase(s2), Is.False);
        }

        [Test]
        public void ShouldConvertListToIdList()
        {
            {
                List<DataSource> list = new List<DataSource> {DataSource.ACTION_ITEM, DataSource.DWS};
                string result = list.BuildIdStringFromList();
                Assert.That(result, Is.EqualTo("3, 5"));
            }

            {
                DataSource dws = DataSource.DWS;
                dws.Id = null;

                List<DataSource> list = new List<DataSource> { DataSource.ACTION_ITEM, dws };
                string result = list.BuildIdStringFromList();
                Assert.That(result, Is.EqualTo("3"));
            }
        }

        [Test]
        public void ShouldRemoveStringFromBeginning()
        {
            {
                string stringToTrim = "ED1-A001-P085";
                string stringToRemove = "ED1-A001";

                string result = stringToTrim.RemoveStringFromStartOf(stringToRemove);
                Assert.That(result, Is.EqualTo("-P085"));
            }
            {
                string stringToTrim = "ED1-A001-P085";
                string stringToRemove = "ED1-A002";

                string result = stringToTrim.RemoveStringFromStartOf(stringToRemove);
                Assert.That(result, Is.EqualTo("ED1-A001-P085"));
            }
        }
    }
}