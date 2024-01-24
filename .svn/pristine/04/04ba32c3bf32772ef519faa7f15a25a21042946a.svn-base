using System;
using Com.Suncor.Olt.Common.Utility.Comparer;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class PropertyComparerTest
    {
        [Test]
        public void ShouldCompareProperties()
        {
            PropertyComparer<int?> comparer = new PropertyComparer<int?>("Value");
            Assert.AreEqual(-1, comparer.Compare(2, 3));
            Assert.AreEqual(0, comparer.Compare(2, 2));
            Assert.AreEqual(1, comparer.Compare(3, 2));
        }

        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void ShouldThrowExceptionIfPropertyDoesNotExist()
        {
            new PropertyComparer<int?>("DoesntExist");
        }

        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void ShouldThrowExceptionIfPropertyTypeIsNotComparable()
        {
            new PropertyComparer<NotComparable?>("Value");
        }

        [Test]
        public void ShouldCompareNullProperties()
        {
            PropertyComparer<int?> comparer = new PropertyComparer<int?>("Value");
            Assert.AreEqual(-1, comparer.Compare(null, 3));
            Assert.AreEqual(1, comparer.Compare(2, null));
            Assert.AreEqual(0, comparer.Compare(null, null));
        }

        /// <summary>
        /// Deliberate does not implement IComparable.
        /// </summary>
        private struct NotComparable {}
    }
}
