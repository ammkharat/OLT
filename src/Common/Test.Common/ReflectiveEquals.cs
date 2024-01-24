using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common
{
    public class ReflectiveEquals<T> : IEqualityComparer<T> where T : class
    {
        public bool Equals(T x, T y)
        {
            return x.ReflectionEquals(y);
        }

        public int GetHashCode(T obj)
        {
            return obj.ReflectionGetHashCode();
        }
    }
}