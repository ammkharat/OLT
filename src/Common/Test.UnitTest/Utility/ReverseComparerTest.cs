using System.Collections.Generic;
using Com.Suncor.Olt.Common.Utility.Comparer;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class ReverseComparerTest
    {
        [Test]
        public void ShouldReturnOppositeResultOfRegularComparer()
        {
            int doesntMatter = TestUtil.RandomNumber();
            Assert.AreEqual(1, new ReverseComparer<int>(new MockComparer(-1)).Compare(doesntMatter, doesntMatter));
            Assert.AreEqual(0, new ReverseComparer<int>(new MockComparer(0)).Compare(doesntMatter, doesntMatter));
            Assert.AreEqual(-1, new ReverseComparer<int>(new MockComparer(1)).Compare(doesntMatter, doesntMatter));
        }

        private class MockComparer : IComparer<int>
        {
            private readonly int alwaysReturn;

            public MockComparer(int alwaysReturn)
            {
                this.alwaysReturn = alwaysReturn;
            }

            public int Compare(int left, int right)
            {
                return alwaysReturn;
            }
        }
    }
}
