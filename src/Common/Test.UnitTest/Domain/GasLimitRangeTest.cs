using Com.Suncor.Olt.Common.Domain.WorkPermit;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class GasLimitRangeTest
    {
        #region String Format Validity Test

        private static readonly string[] ValidNonRangedLimits = {
                                                                        string.Empty, // IsEmpty string allowed
                                                                        "1", // Normal Numbers
                                                                        "12",
                                                                        "123456789",
                                                                        " 678 ", // Number With Leading and tailing space
                                                                        "0.00", // Decimal Numbers
                                                                        "1.12",
                                                                        " 0.00 ", // Decimal Number with leading and tailing spaces
                                                                        ".12" // Decimal Number starting with the dot
                                                                };

        private static readonly string[] InvalidNonRangedLimits = {
                                                                          ".", // Not a number
                                                                          "A",
                                                                          "!@#$%^&*()",
                                                                          "-",
                                                                          "12.", // Missing number after the dot
                                                                          "12.123", // Max Two Decimal Places
                                                                          "-98", // No Negative number allowed
                                                                          "-123",
                                                                          "123-456", // It is a ranged number
                                                                          "123 456", // Space in the number
                                                                          "123. 12"
                                                                  };

        private static readonly string[] ValidRangedLimits = {
                                                                     string.Empty, // Empty string alloed
                                                                     "1-1", // Normal numbers
                                                                     "456-789",
                                                                     " 2 - 2 ", // With srounding spaces 
                                                                     "1-1.12", // One Whole Number, One Decimal
                                                                     "1.12-2",
                                                                     "1.12-2.12", // Two Decimal Numbers
                                                                     "9.99 - 10.00",
                                                                     ".5-.6", // Decimal Numbers with no leading zeros
                                                                     "0-.5",
                                                                     ".5-1"
                                                             };

        private static readonly string[] InvalidRangedLimits = {
                                                                       ".-.", // Not a numbers
                                                                       "ABC-CDE",
                                                                       " 1 1 - 22", // Space withing a number
                                                                       "123 456 - 789",
                                                                       "123 - 456 79",
                                                                       "ABC - 987", // One Number but the other alphabets
                                                                       "123 - CDE",
                                                                       "123", // Is not ranged
                                                                       "1.23",
                                                                       " - ", // just a dash not allwoed, should use just empty string
                                                                       "-123-0", // Negative number not allowed
                                                                       "123--456", // Too many dashes
                                                                       "999-123", // Must specify in low-high format
                                                                       "3.00-2.99"
                                                               };

        private void IsValidFormatTest(string strValue, bool isRangedLimit, bool validInput)
        {
            string errorMessage = string.Empty;
            bool actual = GasLimitRange.IsValid(strValue, isRangedLimit, out errorMessage);
            Assert.AreEqual(validInput, actual, "Expected Valid = {0}, For Number = {1} ", validInput, strValue);
        }

        [Test]
        public void ShouldCheckRangedLimitString()
        {
            bool isRangedLimit = true;
            foreach(string str in ValidRangedLimits)
            {
                IsValidFormatTest(str, isRangedLimit, true);
            }
            foreach(string str in InvalidRangedLimits)
            {
                IsValidFormatTest(str, isRangedLimit, false);
            }
        }

        [Test]
        public void ShouldCheckNonRangedLimitString()
        {
            bool isRangedLimit = false;
            foreach(string str in ValidNonRangedLimits)
            {
                IsValidFormatTest(str, isRangedLimit, true);
            }
            foreach(string str in InvalidNonRangedLimits)
            {
                IsValidFormatTest(str, isRangedLimit, false);
            }
        }

        #endregion

        #region Equality Test

        [Test]
        public void LowerMeansLowerOfUpperLimit()
        {
            GasLimitRange upperRange = new GasLimitRange(0, 100);
            GasLimitRange lowerRange = new GasLimitRange(50, 75);
            Assert.AreEqual(lowerRange, upperRange.LowerOf(lowerRange));
            upperRange = new GasLimitRange(50, 150);
            lowerRange = new GasLimitRange(0, 100);
            Assert.AreEqual(lowerRange, upperRange.LowerOf(lowerRange));
            upperRange = new GasLimitRange(0, 100);
            lowerRange = new GasLimitRange(-50, 50);
            Assert.AreEqual(lowerRange, upperRange.LowerOf(lowerRange));
            upperRange = new GasLimitRange(0, 100);
            lowerRange = new GasLimitRange(0, 100);
            Assert.AreEqual(lowerRange, upperRange.LowerOf(lowerRange));
        }

        [Test]
        public void IgnoreEmptyLimitBound()
        {
            GasLimitRange upperRange = new GasLimitRange(null, 100);
            GasLimitRange lowerRange = new GasLimitRange(50, 75);
            Assert.AreEqual(lowerRange, upperRange.LowerOf(lowerRange));
            upperRange = new GasLimitRange(50, null);
            lowerRange = new GasLimitRange(50, 75);
            Assert.AreEqual(lowerRange, upperRange.LowerOf(lowerRange));
            upperRange = new GasLimitRange(null, 100);
            lowerRange = new GasLimitRange(null, 75);
            Assert.AreEqual(lowerRange, upperRange.LowerOf(lowerRange));
        }

        [Test]
        public void UndefinedWhenUpperBoundIsUndefined()
        {
            GasLimitRange upperRange = new GasLimitRange(100, null);
            GasLimitRange lowerRange = new GasLimitRange(50, null);
            Assert.IsTrue(
                    upperRange.LowerOf(lowerRange) == lowerRange ||
                    upperRange.LowerOf(lowerRange) == upperRange
                    );
        }

        [Test]
        public void EmptyRangeMeansNothing()
        {
            GasLimitRange upperRange = GasLimitRange.EmptyLimitRange;
            GasLimitRange lowerRange = new GasLimitRange(0, 100);
            Assert.AreEqual(lowerRange, upperRange.LowerOf(lowerRange));
            upperRange = new GasLimitRange(0, 100);
            lowerRange = GasLimitRange.EmptyLimitRange;
            Assert.AreEqual(upperRange, upperRange.LowerOf(lowerRange));
            upperRange = GasLimitRange.EmptyLimitRange;
            lowerRange = GasLimitRange.EmptyLimitRange;
            Assert.AreEqual(upperRange, upperRange.LowerOf(lowerRange));
        }

        #endregion

        #region FromString Parsing Test

        [Test]
        public void ShouldSetMinToDefaultMinValueOnParsingNonRangedValue()
        {
            string strValue = "100";
            GasLimitRange expectedRange = new GasLimitRange(GasLimitRange.DEFAULT_LOWER_BOUND, double.Parse(strValue));
            GasLimitRange actualRange = GasLimitRange.FromString(strValue);
            Assert.AreEqual(expectedRange, actualRange);
        }

        [Test]
        public void ShouldParseValueInRangedFormat()
        {
            GasLimitRange expectedRange = new GasLimitRange(100, 200);
            string strValue = expectedRange.ToLimitString(true, 2);
            GasLimitRange actualRange = GasLimitRange.FromString(strValue);
            Assert.AreEqual(expectedRange, actualRange);
        }

        [Test]
        public void ShouldParseNullValue()
        {
            string strValue = null;
            GasLimitRange expected = new GasLimitRange(null, null);
            GasLimitRange actual = GasLimitRange.FromString(strValue);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        [Test]
        public void ShouldSetMinToDefaultValueWhenNotProvided()
        {
            GasLimitRange maxOnlyRange = new GasLimitRange(100);
            Assert.AreEqual(GasLimitRange.DEFAULT_LOWER_BOUND, maxOnlyRange.Min);
        }

        [Test]
        public void ShouldNotOverWriteUserProvidedNullMinValue()
        {
            GasLimitRange nullMinRange = new GasLimitRange(null, 100);
            Assert.IsFalse(nullMinRange.Min.HasValue);
            Assert.AreEqual(100.0, nullMinRange.Max.Value);
        }

        #region ContainsInclusive Tests

        [Test]
        public void ShouldReturnTrueWhenIsWithinRange()
        {
            double lowerBound = 10;
            double upperBound = 20;
            GasLimitRange range = new GasLimitRange(lowerBound, upperBound);
            double testValue = lowerBound;
            while(testValue <= upperBound)
            {
                Assert.IsTrue(range.ContainsInclusive(testValue));
                testValue = testValue + 1;
            }
            Assert.IsFalse(range.ContainsInclusive(lowerBound - 1));
            Assert.IsFalse(range.ContainsInclusive(upperBound + 1));
        }

        [Test]
        public void ShouldAlsoCheckForUndefinedLowerBound()
        {
            double upperBound = 100;
            GasLimitRange range = new GasLimitRange(upperBound);
            Assert.IsTrue(range.ContainsInclusive(GasLimitRange.DEFAULT_LOWER_BOUND));
            Assert.IsTrue(range.ContainsInclusive(upperBound));
            Assert.IsFalse(range.ContainsInclusive(upperBound + 1));
        }

        #endregion
    }
}