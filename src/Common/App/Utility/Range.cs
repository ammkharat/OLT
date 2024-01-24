using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Utility
{
    [Serializable]
    public class Range<T>
    {
        private readonly Comparer<T> comparer;
        private readonly T lowerBound;
        private readonly T upperBound;

        public Range(T lowerBound, T upperBound)
        {
            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
            comparer = Comparer<T>.Default;
        }

        public T LowerBound
        {
            get { return lowerBound; }
        }

        public T UpperBound
        {
            get { return upperBound; }
        }

        /// <summary>
        ///     Tests if the given value is in the range:
        ///     lower bound &lt;= value &lt;= upper bound
        /// </summary>
        public bool ContainsInclusive(T value)
        {
            return IsLessThanEqual(lowerBound, value) && IsLessThanEqual(value, upperBound);
        }

        public bool ContainsInclusive(Range<T> smallerRange)
        {
            return ContainsInclusive(smallerRange.LowerBound) && ContainsInclusive(smallerRange.UpperBound);
        }

        private bool IsLessThanEqual(T left, T right)
        {
            return comparer.Compare(left, right) <= 0;
        }

        private bool IsLessThan(T left, T right)
        {
            return comparer.Compare(left, right) < 0;
        }

        /**
         * to check if two ranges are overlapped or not.  This is good from time, lowerBound == upperBound means not overlapped
         * 
         * i.e.
         * 8:00 - 20:00 and 20:00 to 8:00 is not overlapped
         * */

        public bool IsRangeNotOverLapped(Range<T> range)
        {
            if (IsLessThan(lowerBound, upperBound) && IsLessThan(range.lowerBound, range.upperBound))
            {
                return (IsLessThanEqual(range.upperBound, lowerBound) ||
                        IsGreaterThanEqual(range.lowerBound, upperBound));
            }
            if (IsGreaterThan(lowerBound, upperBound) &&
                IsGreaterThan(range.lowerBound, range.upperBound))
            {
                return (IsGreaterThanEqual(range.upperBound, lowerBound) ||
                        IsLessThanEqual(range.lowerBound, upperBound));
            }
            return ((IsLessThanEqual(range.upperBound, lowerBound) &&
                     IsLessThanEqual(upperBound, range.lowerBound)) ||
                    (IsGreaterThanEqual(range.lowerBound, upperBound) &&
                     IsGreaterThanEqual(lowerBound, range.upperBound)));
        }


        public bool IsRangeOverLapped(Range<T> range)
        {
            return !IsRangeNotOverLapped(range);
        }

        private bool IsGreaterThanEqual(T left, T right)
        {
            return comparer.Compare(left, right) >= 0;
        }

        private bool IsGreaterThan(T left, T right)
        {
            return comparer.Compare(left, right) > 0;
        }

        public override int GetHashCode()
        {
            return lowerBound.GetHashCode() + 29*upperBound.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            var range = obj as Range<T>;
            if (range == null) return false;
            if (comparer.Compare(lowerBound, range.lowerBound) != 0) return false;
            if (comparer.Compare(upperBound, range.upperBound) != 0) return false;
            return true;
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", lowerBound, upperBound);
        }
    }
}