using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Utility.Comparer
{
    /// <summary>
    ///     A decorator which compares the opposite of the given comparer.
    /// </summary>
    public class ReverseComparer<T> : IComparer<T>
    {
        private readonly IComparer<T> forwardComparer;

        public ReverseComparer(IComparer<T> forwardComparer)
        {
            this.forwardComparer = forwardComparer;
        }

        public int Compare(T left, T right)
        {
            return -1*forwardComparer.Compare(left, right);
        }
    }
}