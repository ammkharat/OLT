using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services.Excel
{
    [TestFixture]
    public class ExcelExtensionTest
    {
        [Ignore] [Test]
        public void ShouldReturnLettersForColumnNumber()
        {
            {
                int columnNumber = 0;
                string result = ExcelColumn.GetColumnString(columnNumber);
                Assert.That(result, Is.EqualTo("A"));
            }

            {
                int columnNumber = 6;
                string result = ExcelColumn.GetColumnString(columnNumber);
                Assert.That(result, Is.EqualTo("G"));
            }

            {
                int columnNumber = 25;
                string result = ExcelColumn.GetColumnString(columnNumber);
                Assert.That(result, Is.EqualTo("Z"));
            }

            {
                int columnNumber = 26;
                string result = ExcelColumn.GetColumnString(columnNumber);
                Assert.That(result, Is.EqualTo("AA"));
            }

            {
                int columnNumber = 28;
                string result = ExcelColumn.GetColumnString(columnNumber);
                Assert.That(result, Is.EqualTo("AC"));
            }

            {
                int columnNumber = 52;
                string result = ExcelColumn.GetColumnString(columnNumber);
                Assert.That(result, Is.EqualTo("BA"));
            }

        }

        [Ignore] [Test]
        public void ShouldReturnZeroBasedNumbersForColumnLetter()
        {
            {
                int result = ExcelColumn.TranslateColumnNameToNumber("A");
                Assert.That(result, Is.EqualTo(0));
            }

            {
                int result = ExcelColumn.TranslateColumnNameToNumber("Z");
                Assert.That(result, Is.EqualTo(25));
            }

            {
                int result = ExcelColumn.TranslateColumnNameToNumber("AA");
                Assert.That(result, Is.EqualTo(26));
            }

            {
                int result = ExcelColumn.TranslateColumnNameToNumber("AC");
                Assert.That(result, Is.EqualTo(28));
            }

            {
                int result = ExcelColumn.TranslateColumnNameToNumber("BA");
                Assert.That(result, Is.EqualTo(52));
            }
        }
    }
}