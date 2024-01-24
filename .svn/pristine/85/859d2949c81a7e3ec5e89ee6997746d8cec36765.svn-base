using System;
using System.Data;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Remote.DataAccess
{
    [TestFixture]
    public class SqlDataReaderExtensionsTest
    {
        IDataRecord mockSqlDataReader;
        const string fieldName = "someFieldName";

        [SetUp]
        public void SetUp()
        {
            mockSqlDataReader = MockRepository.GenerateStub<IDataReader>();
        }

        [Ignore] [Test]
        public void GettingAStringFromASqlDataReaderWrapperShouldConvertDBNullToNull()
        {
            mockSqlDataReader.Expect(m => m.Get(fieldName)).Return(DBNull.Value);
            object result = mockSqlDataReader.Get(fieldName);
            Assert.IsNull(result);
        }

        [Ignore] [Test]
        public void GettingAStringFromASqlDataReaderWrapperShouldLetNonNullStringsPassThroughUnChanged()
        {
            const string expectedValue = "someString";
            mockSqlDataReader.Expect(m => m.Get(fieldName)).Return(expectedValue);

            object o = mockSqlDataReader.Get(fieldName);
            string result = o as string;
            Assert.AreEqual(expectedValue, result);
        }

        [Ignore] [Test]
        public void GettingANullableIntFromASqlDataReaderWrapperShouldConvertDBNullToNull()
        {
            mockSqlDataReader.Expect(m => m.Get(fieldName)).Return(DBNull.Value);

            object o = mockSqlDataReader.Get(fieldName);
            int? result = o as int?;
            Assert.IsNull(result);
        }

        [Ignore] [Test]
        public void GettingAnIntFromASqlDataReaderWrapperShouldLetNonNullIntsPassThroughUnchanged()
        {
            const int expectedValue = 1;
            mockSqlDataReader.Expect(m => m.Get(fieldName)).Return(expectedValue);

            int? result = (int?)mockSqlDataReader.Get(fieldName);
            Assert.AreEqual(expectedValue, result);
        }

        [Ignore] [Test]
        public void GettingADateFromASqlDataReaderWrapperShouldConvertDBNullToSpecifiedValue()
        {
            mockSqlDataReader.Expect(m => m.Get(fieldName)).Return(DBNull.Value);

            DateTime? result = (DateTime?)mockSqlDataReader.Get(fieldName);
            Assert.IsNull(result);

        }

        [Ignore] [Test]
        public void GettingADateFromASqlDataReaderWrapperShouldLetNonNullDatesPassThroughUnChanged()
        {
            DateTime expectedValue = new DateTime(2005, 12, 14);
            mockSqlDataReader.Expect(m => m.Get(fieldName)).Return(expectedValue);

            DateTime? result = (DateTime?)mockSqlDataReader.Get(fieldName);
            Assert.AreEqual(expectedValue, result);
        }

        [Ignore] [Test]
        public void GettingADateUsingGenericFromASqlDataReaderWrapperShouldConvertDBNullToSpecifiedValue()
        {
            mockSqlDataReader.Expect(m => m.Get(fieldName)).Return(DBNull.Value);

            DateTime? result = mockSqlDataReader.Get<DateTime?>(fieldName);
            Assert.IsNull(result);
        }

        [Ignore] [Test]
        public void GettingADateUsingGenericFromASqlDataReaderWrapperShouldLetNonNullDatesPassThroughUnChanged()
        {
            DateTime expectedValue = new DateTime(2005, 12, 14);
            mockSqlDataReader.Expect(m => m.Get(fieldName)).Return(expectedValue);

            DateTime? result = mockSqlDataReader.Get<DateTime?>(fieldName);
            Assert.AreEqual(expectedValue, result);
        }

        [Ignore] [Test]
        public void GettingAStringUsingGenericFromASqlDataReaderWrapperShouldConvertDBNullToNull()
        {
            mockSqlDataReader.Expect(m => m.Get(fieldName)).Return(DBNull.Value);

            string result = mockSqlDataReader.Get<string>(fieldName);
            Assert.IsNull(result);
        }

        [Ignore] [Test]
        public void GettingAStringUsingGenericFromASqlDataReaderWrapperShouldLetNonNullStringsPassThroughUnChanged()
        {
            const string expectedValue = "someString";
            mockSqlDataReader.Expect(m => m.Get(fieldName)).Return(expectedValue);

            string result = mockSqlDataReader.Get<string>(fieldName);
            Assert.AreEqual(expectedValue, result);
        }
    }
}