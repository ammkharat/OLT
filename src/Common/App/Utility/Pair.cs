using System;

namespace Com.Suncor.Olt.Common.Utility
{
    // This will apparently be replaced with a Tuple class in .NET 4.0
    [Serializable]
    public class Pair<T1, T2>
    {
        public Pair(T1 firstItem, T2 secondItem)
        {
            FirstItem = firstItem;
            SecondItem = secondItem;
        }

        public T1 FirstItem { get; private set; }
        public T2 SecondItem { get; private set; }
    }
}