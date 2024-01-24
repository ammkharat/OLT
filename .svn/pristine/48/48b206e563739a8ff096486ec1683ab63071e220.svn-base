using Com.Suncor.Olt.Common.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class RangeTest
    {
        [Test]
        public void ShouldEvaluateInRangeInclusive()
        {
            Range<double> range = new Range<double>(1.0, 10.0);

            Assert.AreEqual(true, range.ContainsInclusive(1.0));
            Assert.AreEqual(true, range.ContainsInclusive(5.0));
            Assert.AreEqual(true, range.ContainsInclusive(10.0));

            Assert.AreEqual(false, range.ContainsInclusive(11.0));
            Assert.AreEqual(false, range.ContainsInclusive(10.1));
            Assert.AreEqual(false, range.ContainsInclusive(0.9));
            Assert.AreEqual(false, range.ContainsInclusive(0.0));
        }

        [Test]
        public void ShouldTimeRangeOverLapped()
        {
            Time startTime1 = new Time(8, 0, 0);
            Time endTime1 = new Time(20, 0, 0);
            Range<Time> range1 = new Range<Time>(startTime1, endTime1);

            Time startTime2 = new Time(9, 0, 0);
            Time endTime2 = new Time(21, 0, 0);
            Range<Time> range2 = new Range<Time>(startTime2, endTime2);
            Assert.AreEqual(false, range1.IsRangeNotOverLapped(range2));

            Time startTime3 = new Time(10, 0, 0);
            Time endTime3 = new Time(18, 0, 0);
            Range<Time> range3 = new Range<Time>(startTime3, endTime3);
            Assert.AreEqual(false, range1.IsRangeNotOverLapped(range3));

            Time startTime4 = new Time(6, 0, 0);
            Time endTime4 = new Time(9, 0, 0);
            Range<Time> range4 = new Range<Time>(startTime4, endTime4);
            Assert.AreEqual(false, range1.IsRangeNotOverLapped(range4));

            Time startTime5 = new Time(8, 0, 0);
            Time endTime5 = new Time(20, 0, 0);
            Range<Time> range5 = new Range<Time>(startTime5, endTime5);
            Assert.AreEqual(false, range1.IsRangeNotOverLapped(range5));

            Time startTime6 = new Time(13, 0, 0);
            Time endTime6 = new Time(1, 0, 0);
            Range<Time> range6 = new Range<Time>(startTime6, endTime6);
            Assert.AreEqual(false, range1.IsRangeNotOverLapped(range6));            
        }

        [Test]
        public void ShouldTimeRangeOverLappedToo()
        {
            Time startTime0 = new Time(20, 0, 0);
            Time endTime0 = new Time(8, 0, 0);
            Range<Time> range0 = new Range<Time>(startTime0, endTime0);

            Time startTime1 = new Time(10, 0, 0);
            Time endTime1 = new Time(22, 0, 0);
            Range<Time> range1 = new Range<Time>(startTime1, endTime1);
            Assert.AreEqual(false, range0.IsRangeNotOverLapped(range1));

            Time startTime2 = new Time(21, 0, 0);
            Time endTime2 = new Time(9, 0, 0);
            Range<Time> range2 = new Range<Time>(startTime2, endTime2);
            Assert.AreEqual(false, range0.IsRangeNotOverLapped(range2));

            Time startTime3 = new Time(9, 0, 0);
            Time endTime3 = new Time(21, 0, 0);
            Range<Time> range3 = new Range<Time>(startTime3, endTime3);
            Assert.AreEqual(false, range0.IsRangeNotOverLapped(range3));

            Time startTime4 = new Time(21, 0, 0);
            Time endTime4 = new Time(23, 0, 0);
            Range<Time> range4 = new Range<Time>(startTime4, endTime4);
            Assert.AreEqual(false, range0.IsRangeNotOverLapped(range4));

            Time startTime5 = new Time(1, 0, 0);
            Time endTime5 = new Time(7, 0, 0);
            Range<Time> range5 = new Range<Time>(startTime5, endTime5);
            Assert.AreEqual(false, range0.IsRangeNotOverLapped(range5));

            Time startTime6 = new Time(21, 0, 0);
            Time endTime6 = new Time(9, 0, 0);
            Range<Time> range6 = new Range<Time>(startTime6, endTime6);
            Assert.AreEqual(false, range0.IsRangeNotOverLapped(range6));

            Time startTime7 = new Time(3, 0, 0);
            Time endTime7 = new Time(9, 0, 0);
            Range<Time> range7 = new Range<Time>(startTime7, endTime7);
            Assert.AreEqual(false, range0.IsRangeNotOverLapped(range7));

            Time startTime8 = new Time(20, 0, 0);
            Time endTime8 = new Time(8, 0, 0);
            Range<Time> range8 = new Range<Time>(startTime8, endTime8);
            Assert.AreEqual(false, range0.IsRangeNotOverLapped(range8));
        }

        [Test]
        public void ShouldTimeRangeNotOverLapped()
        {
            Time startTime1 = new Time(8, 0, 0);
            Time endTime1 = new Time(20, 0, 0);
            Range<Time> range1 = new Range<Time>(startTime1, endTime1);

            Time startTime2 = new Time(20, 0, 0);
            Time endTime2 = new Time(8, 0, 0);
            Range<Time> range2 = new Range<Time>(startTime2, endTime2);
            Assert.AreEqual(true, range1.IsRangeNotOverLapped(range2));

            Time startTime3 = new Time(1, 0, 0);
            Time endTime3 = new Time(8, 0, 0);
            Range<Time> range3 = new Range<Time>(startTime3, endTime3);
            Assert.AreEqual(true, range1.IsRangeNotOverLapped(range3));

            Time startTime4 = new Time(1, 0, 0);
            Time endTime4 = new Time(7, 0, 0);
            Range<Time> range4 = new Range<Time>(startTime4, endTime4);
            Assert.AreEqual(true, range1.IsRangeNotOverLapped(range4));

            Time startTime5 = new Time(21, 0, 0);
            Time endTime5 = new Time(23, 0, 0);
            Range<Time> range5 = new Range<Time>(startTime5, endTime5);
            Assert.AreEqual(true, range1.IsRangeNotOverLapped(range5));

            Time startTime6 = new Time(20, 0, 0);
            Time endTime6 = new Time(21, 0, 0);
            Range<Time> range6 = new Range<Time>(startTime6, endTime6);
            Assert.AreEqual(true, range1.IsRangeNotOverLapped(range6));

            Time startTime7 = new Time(20, 0, 0);
            Time endTime7 = new Time(8, 0, 0);
            Range<Time> range7 = new Range<Time>(startTime7, endTime7);
            Assert.AreEqual(true, range1.IsRangeNotOverLapped(range7));
        }

        [Test]
        public void ShouldTimeRangeNotOverLappedEither()
        {
            Time startTime0 = new Time(20, 0, 0);
            Time endTime0 = new Time(8, 0, 0);
            Range<Time> range0 = new Range<Time>(startTime0, endTime0);

            Time startTime1 = new Time(8, 0, 0);
            Time endTime1 = new Time(20, 0, 0);
            Range<Time> range1 = new Range<Time>(startTime1, endTime1);
            Assert.AreEqual(true, range0.IsRangeNotOverLapped(range1));

            Time startTime2 = new Time(8, 0, 0);
            Time endTime2 = new Time(16, 0, 0);
            Range<Time> range2 = new Range<Time>(startTime2, endTime2);
            Assert.AreEqual(true, range0.IsRangeNotOverLapped(range2));            
        }
    }
}
